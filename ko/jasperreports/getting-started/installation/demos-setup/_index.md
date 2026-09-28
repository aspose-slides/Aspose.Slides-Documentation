---
title: 데모 설정
type: docs
weight: 70
url: /ko/jasperreports/demos-setup/
description: "Aspose.Slides for JasperReports 다운로드에서 데모 프로젝트를 설정하고, 사용 중인 익스포터 클래스를 변경한 뒤 Ant로 빌드합니다."
---
## **데모가 무엇인지**

다운로드한 Aspose.Slides for JasperReports의 *samples* 폴더에는 *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text*, *xmldatasource* 총 여덟 개의 데모 프로젝트가 있습니다. 이들은 표준 JasperReports 데모이며, 채워진 보고서를 PPT로 내보내는 `ppt` 빌드 타깃을 추가하도록 변경되었습니다. 다운로드 파일 자체에는 내보낸 프레젠테이션이 포함되지 않으며, 데모를 빌드하여 생성합니다.

## **빌드 전에 익스포터 클래스를 변경하세요**

기본 상태에서는 데모의 Java 코드가 `com.aspose.slides.jasperreports.JRPptExporter` 클래스를 사용하지만, 현재 jar에는 이 클래스가 포함되어 있지 않아 컴파일되지 않습니다. 예를 들어 *shapes* 데모의 *ShapesApp.java*와 같은 애플리케이션 클래스에서 `JRPptExporter`를 `ASPptExporter`(같은 패키지에 있는 PPT 익스포터)로 교체합니다. *fonts* 데모는 전체 패키지를 import하므로 코드에서 클래스 이름만 변경하면 됩니다.

데모는 또한 이후 JasperReports 버전에서 제거된 `JExcelApiExporter`와 `JRExporterParameter.FONT_MAP` 같은 클래스를 사용합니다. 위의 변경을 적용하면 데모는 다음과 같이 컴파일됩니다:

| JasperReports 버전 | 컴파일되는 데모 |
| :- | :- |
| 5.5.1 | all eight |
| 5.5.2 and 6.4.0 | *charts*, *images*, *landscape*, *shapes* and *xmldatasource* |
| 6.16.0 | *charts* |

## **데모 빌드하기**

각 데모의 *build.xml*은 JasperReports 프로젝트의 폴더 레이아웃을 전제로 합니다. 데모 폴더를 기준으로 *../../../build/classes*와 *../../../lib*에 있는 jar를 사용해 컴파일합니다.

1. 데모 폴더를 JasperReports 프로젝트 폴더의 *demo/samples* 아래에 복사합니다.  
2. 다운로드의 *lib* 서브폴더에 있는 *aspose.slides.jasperreports.library-xx.x.jar*(JasperReports 버전에 맞는)를 JasperReports 프로젝트의 *lib* 폴더에 복사합니다. 자세히 보려면 [Installing Aspose.Slides for JasperReports](/slides/ko/jasperreports/installing-aspose-slides-for-jasperreports/)를 참고하세요.  
3. 해당 JasperReports 버전과 그 의존성 jar를 같은 *lib* 폴더에 넣습니다. *build.xml*은 데모 파일 외에 *build/classes*와 *lib* 폴더의 jar만 클래스패스로 사용하며, *build/classes*는 JasperReports를 소스에서 컴파일한 뒤에만 JasperReports 클래스를 포함합니다.  
4. *charts*, *subreport*, *text* 데모는 JasperReports 샘플 데이터베이스(`jdbc:hsqldb:hsql://localhost`)를 사용하므로, 다운로드의 *samples/Readme.txt*에 설명된 대로 먼저 서버를 시작합니다. 다른 데모는 데이터베이스가 필요하지 않습니다.  
5. 데모 폴더에서 애플리케이션을 컴파일하고, 보고서 디자인을 컴파일한 뒤 채우고, PPT로 내보냅니다:

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt` 타깃은 채워진 보고서와 같은 위치에 프레젠테이션을 작성하며, 보고서 이름을 그대로 사용합니다(예: *LandscapeReport.ppt*).

다음 두 데모는 위 단계 외에 추가 작업이 필요합니다:

- *images* 데모는 내보낼 때 `http://jasperreports.sourceforge.net/jasperreports.png`에서 그림을 하나 로드합니다. 해당 주소가 현재 HTTPS로 리다이렉트되므로 *ImagesReport.jrxml*에 있는 주소를 `https://`로 변경해야 프레젠테이션이 생성됩니다. JasperReports 6.4.0에서는 HTTPS에서도 그림을 내보내는 것이 실패합니다.  
- *xmldatasource* 보고서는 Arial 글꼴을 사용합니다. 시스템에 Arial이 없으면 `ant fill` 실행 시 글꼴이 “JVM에 사용할 수 없습니다”라는 메시지가 출력되고 보고서가 생성되지 않아 `ant ppt`가 내보낼 파일이 없습니다. 빌드는 성공으로 표시되지만 각 단계의 출력을 확인하십시오.