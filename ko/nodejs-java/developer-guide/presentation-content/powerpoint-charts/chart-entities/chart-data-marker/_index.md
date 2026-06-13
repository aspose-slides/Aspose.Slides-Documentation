---
title: JavaScript를 사용한 프레젠테이션의 차트 데이터 마커 관리
linktitle: 데이터 마커
type: docs
url: /ko/nodejs-java/chart-data-marker/
keywords:
- 차트
- 데이터 포인트
- 마커
- 마커 옵션
- 마커 크기
- 채우기 유형
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Node.js용 Aspose.Slides에서 차트 데이터 마커를 사용자 정의하는 방법을 배우고, 명확한 코드 예제로 PPT 및 PPTX 형식 전반에 걸쳐 프레젠테이션 효과를 높이세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 마커를 사용하는 방법을 설명합니다. 차트를 생성하고, 시리즈와 해당 데이터 포인트에 접근하며, 데이터 포인트 수준에서 마커에 사진 채우기를 적용하고, 마커 크기를 조정한 뒤 갱신된 프레젠테이션을 저장하는 과정을 보여줍니다. 또한 표준 마커 모양은 `MarkerStyleType` 열거형을 통해 제공되며, 차트를 래스터 형식이나 SVG로 내보낼 때 마커 모양이 유지된다는 점을 안내합니다.

## **차트 마커 옵션 설정**

특정 시리즈의 차트 데이터 포인트에 마커를 설정할 수 있습니다. 차트 마커 옵션을 설정하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화합니다.
- 기본 차트를 생성합니다.
- 그림을 설정합니다.
- 첫 번째 차트 시리즈를 가져옵니다.
- 새 데이터 포인트를 추가합니다.
- 프레젠테이션을 디스크에 저장합니다.

아래 예제에서는 데이터 포인트 수준에서 차트 마커 옵션을 설정했습니다.

```javascript
// 빈 프레젠테이션 생성
var pres = new aspose.slides.Presentation();
try {
    // 첫 번째 슬라이드에 접근
    var slide = pres.getSlides().get_Item(0);
    // 기본 차트 생성
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // 기본 차트 데이터 워크시트 인덱스 가져오기
    var defaultWorksheetIndex = 0;
    // 차트 데이터 워크시트 가져오기
    var fact = chart.getChartData().getChartDataWorkbook();
    // 데모 시리즈 삭제
    chart.getChartData().getSeries().clear();
    // 새 시리즈 추가
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // 그림 1 로드
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // 그림 2 로드
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // 첫 번째 차트 시리즈 가져오기
    var series = chart.getChartData().getSeries().get_Item(0);
    // 새 포인트 (1:3) 추가.
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // 차트 시리즈 마커 변경
    series.getMarker().setSize(15);
    // 차트가 포함된 프레젠테이션 저장
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**기본 제공되는 마커 모양은 무엇입니까?**

표준 모양(원, 사각형, 다이아몬드, 삼각형 등)이 제공되며, 목록은 [MarkerStyleType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/markerstyletype/) 열거형에 정의되어 있습니다. 비표준 모양이 필요한 경우 사진 채우기가 적용된 마커를 사용하여 사용자 지정 시각 효과를 구현할 수 있습니다.

**차트를 이미지 또는 SVG로 내보낼 때 마커가 유지됩니까?**

예. 차트를 [래스터 형식](/slides/ko/nodejs-java/convert-powerpoint-to-png/)으로 렌더링하거나 [SVG 형태의 도형](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/)으로 저장할 때 마커는 크기, 채우기 및 외곽선 등 외관과 설정을 그대로 유지합니다.