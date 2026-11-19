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
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 프레젠테이션에 3D 차트를 만들 수 있습니다. JavaScript 예제를 통해 회전, 높이 비율, 차트 깊이 및 시리즈 간 간격을 조정합니다."
---
## **개요**

Aspose.Slides for Node.js via Java를 사용하면 [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/) 메서드를 통해 3D 차트의 보기를 사용자 지정할 수 있습니다. 이 문서에서는 회전, 높이 비율, 깊이, 직각 축 및 시리즈 간 간격을 조정하고 프레젠테이션을 PPTX 형식으로 저장하는 방법을 보여줍니다.

## **3D 차트의 회전 및 깊이 설정**

아래 예제는 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 을 생성하고 [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) 을 사용하여 첫 번째 슬라이드에 누적 3D 열 차트를 추가합니다. 기본 시리즈와 범주를 각각 세 개의 값을 가진 두 개의 시리즈로 교체합니다. 워크시트 인덱스 `0` 은 차트의 첫 데이터 워크시트를 식별하고, 행 `0` 은 시리즈 이름을, 열 `0` 은 범주 레이블을 보유합니다.

[setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) 및 [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) 메서드는 차트의 회전을 각각 40도와 270도로 설정합니다. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) 은 깊이를 너비의 150%로 설정하고, [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) 은 원근 대신 직각 축을 활성화합니다. 결과 프레젠테이션에는 이러한 3D 보기 설정이 적용된 차트가 포함됩니다.

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

## **3D 차트의 높이 비율 조정**

[Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) 를 사용하여 3D 차트의 높이를 너비에 대한 백분율로 설정합니다. 이렇게 하면 슬라이드의 차트 개체 크기를 변경하지 않고 3D 장면의 비율이 바뀝니다.

다음 예제는 기본 데이터(시리즈 3개와 범주 4개)를 가진 [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 차트를 생성합니다. 높이 비율을 50%, 100%, 200% 로 설정한 세 개의 프레젠테이션을 저장합니다. 차트의 위치, 너비 및 높이는 고정된 상태로 유지됩니다. 데이터, 회전, 깊이, 시리즈 간 간격 및 서식은 세 파일 모두 동일하며, 높이 백분율만 변경됩니다.

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

다음 이미지들은 동등한 .NET 예제에서 동일한 높이 설정을 보여주며 Microsoft PowerPoint를 사용해 내보냈습니다. 작은 백분율은 평평한 장면을 만들고, 큰 백분율은 동일한 차트 개체 내에서 더 높은 장면을 생성합니다. PowerPoint는 장면에 맞추기 위해 축 눈금 간격 및 레이블 배치를 조정할 수도 있습니다.

| 높이: 50% | 높이: 100% | 높이: 200% |
| --- | --- | --- |
| ![너비의 50% 로 높이가 설정된 3D 컬럼 차트](height_percent_50.png) | ![너비의 100% 로 높이가 설정된 3D 컬럼 차트](height_percent_100.png) | ![너비의 200% 로 높이가 설정된 3D 컬럼 차트](height_percent_200.png) |

이러한 메서드는 차트의 다양한 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | 3D 장면의 높이를 너비에 대한 백분율로 표시합니다. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | 슬라이드에 있는 차트 개체의 높이(포인트 단위)입니다. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 3D 장면의 깊이를 너비에 대한 백분율로 표시합니다. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 나타냅니다. |

높이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 열 및 막대 차트와 3D 선, 영역, 파이, 표면 차트에 영향을 줍니다. 위 비교에서는 검증된 `Column3D` 유형을 사용했습니다. 이 설정은 2D `ClusteredColumn` 차트나 `BubbleWith3D` 차트의 모양을 변경하지 않으며, 이러한 이름은 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 클래스의 멤버입니다. 다른 차트 외관 설정은 [Chart Formatting](/slides/ko/nodejs-java/chart-formatting/)을 참조하십시오.

## **시리즈 간 간격 조정**

[ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) 을 사용하여 3D 차트의 깊이 축을 따라 데이터 시리즈 간 거리를 마커 너비의 백분율로 제어합니다. **0에서 500** 사이의 값을 사용할 수 있으며, `0` 은 간격을 제거하고 값이 커질수록 간격이 증가합니다. 차트 깊이가 고정된 상태에서 간격을 늘리면 깊이 축을 따라 마커가 더 얇아집니다.

[ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/) 를 통해 그룹에 접근합니다. 이 설정은 해당 그룹의 모든 시리즈에 적용되며, 접근에 사용된 시리즈에만 적용되는 것이 아닙니다. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) 은 깊이 간격을 반환하고 상위 그룹의 설정을 반영합니다.

이 설정은 실린더, 원뿔, 피라미드 변형을 포함한 3D 열 및 막대 차트와 3D 선 및 영역 차트에 영향을 줍니다. 외관은 시리즈가 깊이, 클러스터, 스택 형태로 배열되는지에 따라 달라집니다. 별도 시리즈 간 간격을 명확히 비교하려면 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 클래스의 `ChartType.Column3D` 를 사용하십시오.

이러한 메서드는 차트의 다양한 측면을 제어합니다:

| 메서드 | 효과 |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | 깊이 축을 따라 시리즈 간 간격을 마커 너비의 백분율로 나타냅니다. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | 인접한 막대 또는 열 클러스터 간 간격을 막대 또는 열 너비의 백분율로 나타냅니다. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | 차트 전체 깊이를 차트 너비의 백분율로 나타냅니다. |

다음 독립 실행형 예제는 세 개의 시리즈와 네 개의 범주를 포함한 기본 차트 데이터를 사용합니다. 데이터, 회전, 간격 너비 및 차트 깊이가 동일한 두 개의 프레젠테이션을 저장하며, 간격 깊이만 변경됩니다.

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

다음 이미지들은 동등한 .NET 예제에서 동일한 간격 깊이 설정을 보여주며 Microsoft PowerPoint를 사용해 내보냈습니다.

| 간격 깊이: 0% | 간격 깊이: 500% |
| --- | --- |
| ![깊이 축을 따라 시리즈 간 간격이 없는 3D 컬럼 차트](gap_depth_0.png) | ![깊이 축을 따라 시리즈 간 500% 간격이 있는 3D 컬럼 차트](gap_depth_500.png) |

## **3D 시리즈 유형 및 막대 모양 변경**

클러스터 실린더 차트에서 첫 번째 시리즈는 실린더 막대 모양으로 시작합니다. 예제는 각 변경 전후에 [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) 및 [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) 이 반환하는 정수 값을 출력합니다. 표는 해당 상수 이름을 제공합니다.

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

| 첫 시리즈 변경 | 시리즈 유형 | 막대 모양 |
| --- | --- | --- |
| 차트 생성 | `ClusteredCylinder` | `Cylinder` |
| `ClusteredCone` 로 시리즈 유형 설정 | `ClusteredCone` | `Cone` |
| `Box` 로 막대 모양 설정 | `ClusteredColumn3D` | `Box` |

`Box` 로 모양을 설정하면 시리즈 유형도 `ClusteredColumn3D` 로 변경됩니다. 코드가 시리즈 유형에 따라 분기한다면 모양을 변경한 후 `series.getType()` 을 호출하십시오. 할당 전에 캐시된 값은 여전히 `ClusteredCone` 분기를 선택하게 됩니다.

![왼쪽에서 오른쪽으로 첫 번째 시리즈가 실린더, 원뿔, 직사각형 열로 표시된 PowerPoint 비교](series-shapes.png)

## **FAQ**

**Aspose.Slides에서 3D 모드를 지원하는 차트 유형은 무엇입니까?**

Aspose.Slides는 Column 3D, Clustered Column 3D, Stacked Column 3D, 100% Stacked Column 3D 등을 포함한 열 차트의 3D 변형과 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 클래스에서 노출되는 관련 3D 유형을 지원합니다. 정확하고 최신 목록은 설치된 버전의 API 참고 문서에서 [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) 멤버를 확인하십시오.

**보고서나 웹용 3D 차트의 래스터 이미지를 얻을 수 있나요?**

예. 차트를 [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) 로 이미지로 내보내거나 전체 슬라이드를 [전체 슬라이드 렌더링](/slides/ko/nodejs-java/convert-powerpoint-to-png/) 하여 PNG 또는 JPEG와 같은 형식으로 저장할 수 있습니다. 이는 래스터 미리보기가 필요하거나 PowerPoint 없이 차트를 문서, 대시보드, 웹 페이지에 삽입하려는 경우에 유용합니다.

**대규모 3D 차트를 구축하고 렌더링하는 성능은 어떠한가요?**

성능은 데이터 양과 시각적 복잡도에 따라 달라집니다. 최상의 결과를 위해 3D 효과를 최소화하고, 벽과 플롯 영역에 무거운 텍스처를 피하며, 가능하면 시리즈당 데이터 포인트 수를 제한하고, 대상 디스플레이 또는 인쇄 요구에 맞게 적절한 해상도와 크기의 출력으로 렌더링하십시오.