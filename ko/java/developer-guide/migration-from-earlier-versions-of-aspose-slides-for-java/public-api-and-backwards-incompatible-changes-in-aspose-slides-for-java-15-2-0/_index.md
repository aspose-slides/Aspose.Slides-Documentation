---
title: Aspose.Slides for Java 15.2.0의 공개 API 및 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.2.0
type: docs
weight: 110
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for Java 15.2.0 API와 함께 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) 클래스, 메서드, 속성 등, 새로운 제한 및 기타 [변경](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/)을 나열합니다.

{{% /alert %}} {{% alert color="primary" %}} 

일부 이미지 글머리 기호와 WordArt 개체에 대한 알려진 문제가 있으며, 이는 Aspose.Slides for Java 15.2.0에서 수정될 예정입니다.

{{% /alert %}} 
## **공용 API 변경 사항**
### **addDataPointForDoughnutSeries 메서드가 추가되었습니다**
IChartDataPointCollection.addDataPointForDoughnutSeries() 메서드의 두 오버로드가 도넛 유형 시리즈에 데이터 포인트를 추가하기 위해 추가되었습니다.
### **com.aspose.slides.SmartArtShape 클래스가 com.aspose.slides.GeometryShape 클래스로부터 상속되었습니다**
com.aspose.slides.SmartArtShape 클래스가 com.aspose.slides.GeometryShape 클래스로부터 상속되었습니다. 이 변경으로 Aspose.Slides 객체 모델이 향상되고 SmartArtShape 클래스에 새로운 기능이 추가되었습니다.
### **IGradientStopCollection.add(...) 및 IGradientStopCollection.insert(...) 메서드가 변경되었습니다**
IGradientStop add(float position, int presetColor) 서명은 IGradientStop addPresetColor(float position, int presetColor) 서명으로 교체되었습니다.

IGradientStopCollection 메서드 IGradientStop add(float position, SchemeColor schemeColor) 서명은 IGradientStop addSchemeColor(float position, int schemeColor) 서명으로 교체되었습니다.

IGradientStopCollection 메서드 void insert(int index, float position, int presetColor) 서명은 void insertPresetColor(int index, float position, int presetColor) 서명으로 교체되었습니다.

IGradientStopCollection 메서드 void insert(int index, float position, SchemeColor schemeColor) 서명은 void insertSchemeColor(int index, float position, int schemeColor) 서명으로 교체되었습니다.
### **java.awt.Color getAutomaticSeriesColor() 메서드가 com.aspose.slides.IChartSeries에 추가되었습니다**
getAutomaticSeriesColor() 메서드는 시리즈 인덱스와 차트 스타일을 기반으로 시리즈의 자동 색상을 반환합니다. FillType이 NotDefined인 경우 기본적으로 이 색상이 사용됩니다.
 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **인덱스로 차트 데이터 포인트와 차트 카테고리를 제거하는 메서드가 추가되었습니다**
IChartDataPointCollection.removeAt(int index) 메서드는 인덱스로 차트 데이터 포인트를 제거하기 위해 추가되었습니다.
IChartCategoryCollection.removeAt(int index) 메서드는 인덱스로 차트 카테고리를 제거하기 위해 추가되었습니다.
### **PptXPptY 값이 com.aspose.slides.PropertyType 열거형에 추가되었습니다**
직렬화 문제 해결을 위해 com.aspose.slides.PropertyType 열거형에 PptXPptY 값이 추가되었습니다.