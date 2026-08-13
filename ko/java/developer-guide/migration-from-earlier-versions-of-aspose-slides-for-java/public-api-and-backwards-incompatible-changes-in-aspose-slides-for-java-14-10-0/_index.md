---
title: Aspose.Slides for Java 14.10.0의 공개 API 및 역방향 호환 불가능한 변경 사항
linktitle: Aspose.Slides for Java 14.10.0
type: docs
weight: 90
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
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
{{% alert color="info" %}} 

이 페이지는 Aspose.Slides for Java 14.10.0 API에 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) 클래스, 메서드, 속성 등을 나열하고, 새로운 제한 사항 및 기타 [변경 사항](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/)을 보여줍니다.

{{% /alert %}} 
## **공용 API 변경 사항**
### **com.aspose.slides.FieldType.getFooter() 메서드가 추가되었습니다**
getFooter() 메서드는 푸터 필드 유형을 반환합니다. 이 메서드는 해당 유형의 필드를 생성할 수 있는 기능과 올바른 프레젠테이션 직렬화를 위해 추가되었습니다.
### **요소 com.aspose.slides.ShapeElementFillSource.Own 가 삭제되었습니다**
ShapeElementFillSource.Own 요소가 중복되어 삭제되었습니다. ShapeElementFillSource.Own 대신 ShapeElementFillSource.Shape 를 사용하십시오.
### **차트 데이터 포인트 및 카테고리 삭제를 위한 메서드가 추가되었습니다**
**차트 데이터 포인트 컬렉션에서 차트 데이터 포인트를 삭제할 수 있는 다음 메서드가 추가되었습니다:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**포함된 컬렉션에서 차트 카테고리를 삭제할 수 있는 다음 메서드가 추가되었습니다:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ChartCategory.remove() 로 제거

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ChartCategoryCollection.remove() 로 제거

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ChartDataPoint.remove() 로 제거

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **구식 Aspose.Slides.ParagraphFormat 메서드가 제거되었습니다**
메서드 getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() 및 해당 set 메서드들이 제거되었습니다. 이 메서드들은 오래전부터 구식으로 표시되어 왔습니다.
### **쓸모 없고 구식인 생성자가 제거되었습니다**
다음 생성자들이 제거되었습니다:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)