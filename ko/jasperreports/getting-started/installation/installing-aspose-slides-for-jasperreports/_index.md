---
title: Aspose.Slides for JasperReports 설치
type: docs
weight: 40
url: /ko/jasperreports/installing-aspose-slides-for-jasperreports/
description: "JasperReports 버전에 맞는 Aspose.Slides for JasperReports JAR 파일을 선택하고, 이를 JasperReports, Maven 프로젝트 또는 JasperReports Server에 추가하십시오."
---
## **JasperReports 버전에 맞는 JAR 선택**

Aspose.Slides for JasperReports는 [다운로드 페이지](https://releases.aspose.com/slides/jasperreport/)에서 ZIP 파일로 제공됩니다. *lib* 폴더에는 JasperReports 버전 범위별로 하위 폴더가 하나씩 있습니다. 사용 중인 JasperReports 버전을 포함하는 하위 폴더에서 JAR 파일을 가져오세요:

| JasperReports 버전 | *lib* 하위 폴더 |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

JasperReports 6.17.0 이상(또는 JasperReports 7 포함)에는 하위 폴더가 없습니다. *JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* 하위 폴더에는 JAR 파일이 없으며, 해당 버전에 대한 지원이 Aspose.Slides for JasperReports 17.6에서 종료되었다는 메모만 있습니다.

각 하위 폴더에는 두 개의 JAR 파일이 포함되어 있습니다; 파일 이름에 있는 *xx.x*는 제품 버전을 나타냅니다:

- *aspose.slides.jasperreports.library-xx.x.jar* 은 JasperReports Library용 익스포터(`ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` 및 `ASHtmlExporter`)와 `License` 클래스를 포함합니다.
- *aspose.slides.jasperreports.server-xx.x.jar* 은 JasperReports Server용 내보내기 작업을 포함합니다. 이는 라이브러리 JAR를 기반으로 하므로 서버는 항상 동일한 하위 폴더의 두 JAR를 모두 필요로 합니다.

## **JasperReports 또는 애플리케이션에 라이브러리 JAR 추가**

일치하는 하위 폴더에서 *aspose.slides.jasperreports.library-xx.x.jar* 를 JasperReports의 *lib* 폴더 또는 애플리케이션의 클래스패스로 복사합니다. 그런 다음 애플리케이션에서 코드로 익스포터를 생성할 수 있습니다.

{{% alert color="info" title="Note" %}}
Linux에서는 JasperReports가 보고서를 채우기 위해 fontconfig와 최소 하나의 설치된 글꼴이 필요합니다. 글꼴이 없으면 "Error initializing graphic environment" 오류와 함께 채우기가 실패합니다.
{{% /alert %}}

## **Maven 프로젝트에 라이브러리 JAR 추가**

JAR 파일은 Maven 저장소가 아닌 ZIP 파일에 포함되어 있습니다. Maven 빌드에서 사용하려면 로컬 Maven 저장소에 설치하십시오. 버전 26.6인 경우, JAR 파일이 있는 폴더에서 다음 명령을 실행합니다:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

그런 다음 *pom.xml* 의 dependencies에 추가하고, JAR 파일의 하위 폴더가 지원하는 JasperReports 버전을 함께 지정합니다:

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

install 명령에서 지정한 group 및 artifact ID를 사용합니다; 서로 일치하기만 하면 됩니다. JasperReports 6.16.0을 사용하는 전체 프로젝트는 [첫 번째 내보내기](/slides/ko/jasperreports/#your-first-export)에서 확인할 수 있습니다.

## **JasperReports Server에 JAR 추가**

일치하는 하위 폴더에서 두 JAR 파일을 JasperReports Server 웹 애플리케이션의 *WEB-INF/lib* 폴더로 복사한 다음, [JasperServer와 통합](/slides/ko/jasperreports/integration-with-jasperserver/)에 설명된 대로 익스포터를 등록합니다.