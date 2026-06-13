---
title: Java를 사용한 프레젠테이션에서 차트 데이터 마커 관리
linktitle: 데이터 마커
type: docs
url: /ko/java/chart-data-marker/
keywords:
- 차트
- 데이터 포인트
- 마커
- 마커 옵션
- 마커 크기
- 채우기 유형
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 차트 데이터 마커를 사용자 지정하는 방법을 배우고, 명확한 Java 코드 예제를 통해 PPT 및 PPTX 형식에서 프레젠테이션 효과를 강화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 데이터 마커를 사용하는 방법을 설명합니다. 차트를 생성하고 시리즈와 해당 데이터 포인트에 접근하며, 데이터 포인트 수준에서 마커에 그림 채우기를 적용하고, 마커 크기를 조정한 뒤 업데이트된 프레젠테이션을 저장하는 과정을 보여줍니다. 또한 표준 마커 모양이 `MarkerStyleType` 열거형을 통해 제공되며, 차트를 래스터 형식이나 SVG로 내보낼 때 마커 모양이 유지된다는 점을 언급합니다.

## **차트 마커 옵션 설정**
마커는 특정 시리즈의 차트 데이터 포인트에 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 아래 단계를 따르세요.

- [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 그림을 설정합니다.
- 첫 번째 차트 시리즈를 가져옵니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 씁니다.

아래 예제에서는 데이터 포인트 수준에서 차트 마커 옵션을 설정했습니다.

```java
// 빈 프레젠테이션 생성
Presentation pres = new Presentation();
try {
    // 첫 번째 슬라이드에 접근
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 기본 차트 생성
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // 기본 차트 데이터 워크시트 인덱스 가져오기
    int defaultWorksheetIndex = 0;
    
    // 차트 데이터 워크시트 가져오기
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // 데모 시리즈 삭제
    chart.getChartData().getSeries().clear();
    
    // 새 시리즈 추가
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // 그림 1 로드
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 그림 2 로드
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // 첫 번째 차트 시리즈 가져오기
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // 새 포인트 (1:3) 추가
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // 차트 시리즈 마커 변경
    series.getMarker().setSize(15);
    
    // 차트가 포함된 프레젠테이션 저장
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**기본 제공되는 마커 모양은 무엇입니까?**

표준 모양(원, 사각형, 다이아몬드, 삼각형 등)이 제공되며, 목록은 [MarkerStyleType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/markerstyletype/) 클래스로 정의됩니다. 비표준 모양이 필요하면 그림 채우기가 적용된 마커를 사용해 사용자 정의 시각 효과를 구현할 수 있습니다.

**차트를 이미지나 SVG로 내보낼 때 마커가 유지됩니까?**

예. 차트를 [raster formats](/slides/ko/java/convert-powerpoint-to-png/) 로 렌더링하거나 [shapes as SVG](/slides/ko/java/render-a-slide-as-an-svg-image/) 로 저장할 때 마커는 크기, 채우기, 외곽선 등의 모양과 설정을 그대로 유지합니다.