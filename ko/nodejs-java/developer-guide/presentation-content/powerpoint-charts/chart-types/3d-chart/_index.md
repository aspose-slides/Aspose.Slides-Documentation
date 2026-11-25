---
title: JavaScript를 사용하여 프레젠테이션에서 3D 차트 사용자 지정
linktitle: 3D 차트
type: docs
url: /ko/nodejs-java/3d-chart/
keywords:
- 3D 차트
- 회전
- 깊이
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 만들고, JavaScript 예제를 통해 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 조정합니다.
---
## **개요**

Aspose.Slides for Node.js via Java를 사용하면 [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) 메서드를 통해 3D 차트의 뷰를 사용자 지정할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정하고 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)을 생성하고 [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/)을 사용하여 첫 번째 슬라이드에 누적 3D 컬럼 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0`은 차트의 첫 번째 데이터 워크시트를 나타내며, 행 `0`은 시리즈 이름을, 열 `0`은 범주 레이블을 보유합니다.

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) 및 [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) 메서드는 차트의 회전을 각각 40도와 270도로 설정합니다. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/)는 깊이를 너비의 150%로 설정하고, [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/)는 원근 대신 직각 축을 사용하도록 합니다. 결과 프레젠테이션에는 이러한 3D 뷰 설정이 적용된 차트가 포함됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **3D 차트 표면에 그림 채우기 적용**

3D 차트의 [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/), 및 [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/)을 각각 독립적으로 채울 수 있습니다. 표면의 [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/)을 `Picture`로 설정하고 이미지를 할당합니다. [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/)와 표면의 [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/)을 모두 `Stretch`로 설정하여 이미지 한 장이 표면 전체에 맞도록 합니다.

[arrow.png](arrow.png)를 작업 디렉터리에 저장합니다. 예제에서는 차트를 회전시키고 수직 축의 최대값을 높여 바닥이 열 사이에 보이게 합니다. 그런 다음 슬라이드를 두 번 복제하고 각 슬라이드의 다른 표면에 화살표를 적용합니다. 세 차트 모두 동일한 데이터, 시점 및 배경을 유지합니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint는 세 슬라이드를 다음과 같이 표시합니다.

| 측면 | 뒷면 | 바닥 |
| --- | --- | --- |
| ![차트 측면 벽을 가리키는 화살표](side-wall.png) | ![뒷면을 가로질러 오른쪽을 가리키는 화살표](back-wall.png) | ![열 사이 바닥을 가로질러 오른쪽을 가리키는 화살표](floor.png) |

## **3D 차트의 높이 비율 조정**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/)을 사용하여 3D 차트의 높이를 너비의 백분율로 설정합니다. 이렇게 하면 슬라이드의 차트 객체 크기를 변경하지 않고 3D 장면의 비율이 조정됩니다.

다음 예제는 기본 데이터(시리즈 3개와 범주 4개)를 사용하여 [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 차트를 생성합니다. 높이 비율을 50%, 100%, 200%로 설정한 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 너비 및 높이는 고정된 상태로 유지됩니다. 데이터, 회전, 깊이, 시리즈 간 간격 및 서식은 모든 파일에서 동일하며, 높이 비율만 변경됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

다음 이미지는 동일한 높이 설정을 .NET 예제에서 나타낸 것으로 Microsoft PowerPoint를 사용해 내보낸 것입니다. 작은 비율은 더 평평한 장면을 생성하고, 큰 비율은 같은 차트 객체 내에서 더 높은 장면을 생성합니다. PowerPoint는 장면에 맞게 축 눈금 간격과 레이블 배치를 조정할 수도 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![너비의 50%로 높이가 설정된 3D 컬럼 차트](height_percent_50.png) | ![너비의 100%로 높이가 설정된 3D 컬럼 차트](height_percent_100.png) | ![너비의 200%로 높이가 설정된 3D 컬럼 차트](height_percent_200.png) |

이 메서드들은 차트의 다양한 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D 장면의 높이를 너비의 백분율로 설정합니다. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | 슬라이드에서 차트 객체의 높이를 포인트 단위로 설정합니다. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D 장면의 깊이를 너비의 백분율로 설정합니다. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 마커 너비의 백분율로 깊이 축을 따라 시리즈 간 간격을 설정합니다. |

높이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선, 영역, 원형 및 표면 차트에 영향을 줍니다. 위 비교는 검증된 `Column3D` 유형을 사용했습니다. 이 설정은 2D `ClusteredColumn` 차트나 `BubbleWith3D` 차트의 모양을 변경하지 않습니다; 이러한 이름은 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 클래스의 멤버입니다. 다른 차트 외관 설정은 [Chart Formatting](/slides/ko/nodejs-java/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/)을 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 너비의 백분율로 제어합니다. **0에서 500**까지의 값을 사용할 수 있으며, `0`은 간격을 없애고 큰 값일수록 간격이 증가합니다. 차트 깊이가 고정된 경우, 간격을 늘리면 깊이 축을 따라 마커가 더 얇아집니다.

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/)으로 그룹에 접근합니다. 이 설정은 해당 그룹의 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 적용되는 것이 아닙니다. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/)은 깊이 간격을 반환하고 부모 그룹의 설정을 반영합니다.

이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 컬럼 및 막대 차트와 3D 선 및 영역 차트에 영향을 줍니다. 외관은 시리즈가 깊이, 클러스터 또는 누적 형태로 배열되는지에 따라 달라집니다. 개별 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 클래스의 `ChartType.Column3D`를 사용하십시오.

| 메서드 | 효과 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 마커 너비의 백분율로 깊이 축을 따라 시리즈 간 간격을 설정합니다. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 바 또는 컬럼 너비의 백분율로 인접한 바 또는 컬럼 클러스터 사이의 간격을 설정합니다. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 차트 너비의 백분율로 전체 차트 깊이를 설정합니다. |

다음 자체 포함 예제는 기본 차트 데이터(시리즈 3개와 범주 4개)를 사용합니다. 데이터, 회전, 간격 너비 및 차트 깊이가 동일한 두 개의 프레젠테이션을 저장하며, 간격 깊이만 변경됩니다.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

다음 이미지는 동일한 간격 깊이 설정을 .NET 예제에서 나타낸 것으로 Microsoft PowerPoint를 사용해 내보낸 것입니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![깊이 축을 따라 시리즈 간 간격이 없는 3D 컬럼 차트](gap_depth_0.png) | ![깊이 축을 따라 시리즈 간 500% 간격이 있는 3D 컬럼 차트](gap_depth_500.png) |

## **3D 시리즈 유형 및 바 모양 변경**

클러스터 실린더 차트에서 첫 번째 시리즈는 실린더 바 모양으로 시작합니다. 예제는 각 변경 전후에 [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) 및 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/)에서 반환된 정수 값을 출력합니다. 표는 해당 상수 이름을 제공합니다.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 첫 번째 시리즈에 대한 변경 | 시리즈 유형 | 바 모양 |
| --- | --- | --- |
| 차트 생성 | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone`(으)로 시리즈 유형 설정 | `ClusteredCone` | `Cone` |
| `Box`(으)로 바 모양 설정 | `ClusteredColumn3D` | `Box` |

`Box`로 바 모양을 설정하면 시리즈 유형도 `ClusteredColumn3D`로 변경됩니다. 코드가 시리즈 유형에 따라 분기되는 경우, 모양을 변경한 후 `series.getType()`을 호출하십시오. 할당 전에 캐시된 값은 여전히 `ClusteredCone` 분기를 선택하게 됩니다.

![PowerPoint 비교: 첫 번째 시리즈가 왼쪽부터 실린더, 원뿔, 직사각형 컬럼으로 표시됨](series-shapes.png)

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등 컬럼 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 클래스를 통해 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참고 문서에서 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 멤버를 확인하십시오.

**보고서나 웹용 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. 차트를 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)으로 이미지로 내보내거나 [전체 슬라이드 렌더링](/slides/ko/nodejs-java/convert-powerpoint-to-png/)을 통해 PNG 또는 JPEG와 같은 형식으로 변환할 수 있습니다. 래스터 미리보이가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지 등에 삽입하려는 경우에 유용합니다.

**대형 3D 차트를 구축하고 렌더링하는 성능은 어떻습니까?**

성능은 데이터 양과 시각적 복잡성에 따라 달라집니다. 최상의 결과를 얻으려면 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 피하며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기의 출력으로 렌더링하십시오.