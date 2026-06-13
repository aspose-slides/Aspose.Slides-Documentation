---
title: 제품 개요
type: docs
weight: 10
url: /ko/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Aspose.Slides for JasperReports에 오신 것을 환영합니다!**

Aspose.Slides for JasperReports는 JasperReports에서 Microsoft PowerPoint Presentation(PPT) 및 Microsoft PowerPoint Show(PPS) 형식으로 보고서를 쉽게 내보내야 하는 개발자를 위해 특별히 설계·개발된 라이브러리입니다. 모든 보고서 기능은 최고 수준의 정밀도로 Microsoft PowerPoint 프레젠테이션으로 변환됩니다. Aspose.Slides for JasperReports는 JasperReports 5+를 지원합니다.

## **제품 설명**
JasperReports와 JasperServer는 Microsoft PowerPoint 프레젠테이션으로 보고서를 내보내는 기본 기능을 제공하지 않지만 Aspose.Slides for JasperReports를 사용하면 두 가지 추가 내보내기 형식을 사용할 수 있습니다:

- PPT – PowerPoint 프레젠테이션 via Aspose.Slides
- PPS - PowerPoint 쇼 via Aspose.Slides
- PPTX – PowerPoint 프레젠테이션 via Aspose.Slides
- PPSX - PowerPoint 쇼 via Aspose.Slides

Aspose.Slides for JasperReports는 내부적으로 100% 순수 Java 라이브러리인 Aspose.Slides for Java 및 Aspose.Metafiles for Java를 사용하며, 서버 측 프레젠테이션 및 메타파일 처리에 세계적 수준의 라이브러리입니다.

Aspose.Slides for JasperReports를 사용하면 모든 보고서를 PPT 또는 PPS 형식으로 내보낼 수 있습니다.

### **출력 예시**
ASPptExporter 클래스는 ASAbstractExporter 클래스를 상속받아 다른 표준 내보내기와 동일한 방식으로 사용할 수 있습니다. 이 간단한 예제는 일반적인 코드와 MS PowerPoint에서 본 보고서의 스크린샷을 보여줍니다. 자세한 예제는 제공된 데모 보고서에서 확인할 수 있습니다.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**JasperReports xmldatasource 데모로 생성된 프레젠테이션** 

![JasperReports로 생성된 프레젠테이션](product-overview_2.png)