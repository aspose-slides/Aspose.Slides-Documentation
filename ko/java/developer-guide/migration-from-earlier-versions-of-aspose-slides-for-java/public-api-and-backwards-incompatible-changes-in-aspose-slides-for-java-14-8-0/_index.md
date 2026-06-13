---
title: "Aspose.Slides for Java 14.8.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항"
linktitle: "Aspose.Slides for Java 14.8.0"
type: docs
weight: 70
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근법
- 최신 접근법
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공용 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 
이 페이지에서는 Aspose.Slides for Java 14.8.0 API와 함께 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) 클래스, 메서드, 속성 등을 나열하고, 새로운 제한 사항 및 기타 [변경 사항](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/)을 보여줍니다.
{{% /alert %}} 
## **공용 API 변경 사항**
### **Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() 및 setOverlap(byte) 메서드 추가**
Aspose.Slides.Charts.IChartSeries.getOverlap() 메서드는 2D 차트에서 막대와 열이 겹쳐야 하는 정도를 (-100에서 100까지) 범위로 반환합니다. 이 메서드는 특정 시리즈에만 적용되는 것이 아니라 상위 시리즈 그룹의 모든 시리즈에 적용되며, 해당 그룹 속성을 투영한 것입니다.

- 상위 시리즈 그룹에 접근하려면 IChartSeries.getParentSeriesGroup() 메서드를 사용합니다.
- 값을 관리하려면 IChartSeriesGroup.getOverlap() 및 setOverlap(byte) 메서드를 사용합니다.

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

IChartSeriesCollection series = chart.getChartData().getSeries();

if (series.get_Item(0).getOverlap() == 0) {

  series.get_Item(0).getParentSeriesGroup().setOverlap(-30);

}

```
### **ShapeThumbnailBounds.Appearance 열거형 값 추가**
이 쉐이프 썸네일 생성 방법을 사용하면 개발자가 해당 쉐이프의 외관 경계 내에서 썸네일을 생성할 수 있습니다. 모든 쉐이프 효과를 고려하며, 생성된 쉐이프 썸네일은 슬라이드 경계에 의해 제한됩니다.

``` java

 Presentation pres = new Presentation();

BufferedImage st = pres.getSlides().get_Item(0).getShapes().get_Item(0).getThumbnail(ShapeThumbnailBounds.Appearance, 1, 1);

```
### **VbaProject 클래스 및 IVbaProject 인터페이스 추가, Presentation.getVbaProject() 및 setVbaProject(VbaProject) 메서드 변경**
새로운 기능을 통해 개발자는 프레젠테이션에서 VBA 프로젝트를 생성하고 편집할 수 있습니다.

``` java

 Presentation pres = new Presentation();

// 새 VBA 프로젝트 생성

pres.setVbaProject(new VbaProject());

// VBA 프로젝트에 빈 모듈 추가

IVbaModule module = pres.getVbaProject().getModules().addEmptyModule("Module");

// 모듈 소스 코드 설정

module.setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");

// <stdole>에 대한 참조 생성

VbaReferenceOleTypeLib stdoleReference =

  new VbaReferenceOleTypeLib("stdole",

    "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office에 대한 참조 생성

VbaReferenceOleTypeLib officeReference =

  new VbaReferenceOleTypeLib("Office",

    "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA 프로젝트에 참조 추가

pres.getVbaProject().getReferences().add(stdoleReference);

pres.getVbaProject().getReferences().add(officeReference);

pres.save("data\\test.pptm", SaveFormat.Pptm);

```