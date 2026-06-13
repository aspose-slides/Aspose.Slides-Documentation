---
title: 데모 설정
type: docs
weight: 70
url: /ko/jasperreports/demos-setup/
---
Aspose.Slides for JasperReports에서 제공하는 모든 데모는 변경된 표준 데모입니다. 모든 데모를 JasperReports 데모 폴더로 복사하는 것이 좋습니다:
...\jasperreports-x.x.x\demo\samples\

보고서를 빌드하고 내보내기 위해 표준 명령 순서를 사용하십시오:

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="primary" %}} 
테스트 데이터베이스와 함께 HSQLDB를 실행하고, aspose.slides.jasperreports.library-xx.x.jar 파일을 aspose-slides-xx.x-jasperreports.zip의 \lib\JasperReports X.X.X - X.X.X 폴더에서 &#60;InstallDir&#62;\lib 디렉터리로 복사하는 것을 잊지 마세요.
{{% /alert %}} 

Charts를 제외한 대부분의 데모는 이미 생성된 프레젠테이션이 포함되어 있으므로 모든 “ant” 단계를 건너뛰고 즉시 결과를 확인할 수 있습니다.