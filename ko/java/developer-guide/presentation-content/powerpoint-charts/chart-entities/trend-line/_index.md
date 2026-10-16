---
title: Java에서 프레젠테이션 차트에 추세선 추가
linktitle: 추세선
type: docs
url: /ko/java/trend-line/
keywords:
- 차트
- 추세선
- 지수 추세선
- 선형 추세선
- 로그 추세선
- 이동 평균 추세선
- 다항식 추세선
- 멱 추세선
- 사용자 지정 추세선
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 차트에 추세선을 빠르게 추가하고 사용자 지정하여 청중을 사로잡는 실용적인 가이드."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에 추세선을 추가하는 방법을 설명합니다. 차트를 만들고, 차트 시리즈에 추세선을 추가하며, 지수, 선형, 로그, 이동 평균, 다항식 및 멱형을 포함한 여러 추세선 유형을 사용하는 방법을 보여줍니다.

또한 선 모양을 삽입하여 차트에 사용자 지정 선을 추가하는 방법을 설명하고, 앞·뒤 추세선 투영 값 및 PDF 또는 SVG로 내보내거나 차트를 이미지로 렌더링할 때 추세선이 보존되는지에 관한 간단한 FAQ를 포함합니다.

## **추세선 추가**

차트 시리즈에 추세선을 추가하려면 [ITrendlineCollection.add](https://reference.aspose.com/slides/java/com.aspose.slides/itrendlinecollection/#add-int-)을 사용하고, 유형은 [TrendlineType](https://reference.aspose.com/slides/java/com.aspose.slides/trendlinetype/)으로 선택합니다. 예제는 기본 데이터가 포함된 군집형 세로 막대 차트를 만들고 각 시리즈 세 개에 두 개의 추세선을 추가합니다.

지수 추세선은 [setDisplayEquation](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayEquation-boolean-) 및 [setDisplayRSquaredValue](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setDisplayRSquaredValue-boolean-)을 통해 방정식과 R² 값을 숨기며, 선형 추세선은 빨간색으로 표시됩니다. 로그 추세선은 사용자 지정 레이블을 위해 [addTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#addTextFrameForOverriding-java.lang.String-)을 사용합니다. 이동 평균은 세 개 데이터 포인트의 [setPeriod](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setPeriod-byte-)과 사용자 지정 [setTrendlineName](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setTrendlineName-java.lang.String-)을 사용합니다.

다항식 추세선은 [setOrder](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setOrder-byte-)가 3이며, [setForward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setForward-double-)를 통해 한 카테고리 앞쪽으로 확장됩니다. 멱형 추세선은 [setBackward](https://reference.aspose.com/slides/java/com.aspose.slides/itrendline/#setBackward-double-)를 통해 한 카테고리 뒤쪽으로 확장됩니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

    IChartSeries firstSeries = chart.getChartData().getSeries().get_Item(0);

    ITrendline exponentialTrendline = firstSeries.getTrendLines().add(TrendlineType.Exponential);
    exponentialTrendline.setDisplayEquation(false);
    exponentialTrendline.setDisplayRSquaredValue(false);

    ITrendline linearTrendline = firstSeries.getTrendLines().add(TrendlineType.Linear);
    linearTrendline.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    linearTrendline.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);

    IChartSeries secondSeries = chart.getChartData().getSeries().get_Item(1);

    ITrendline logarithmicTrendline = secondSeries.getTrendLines().add(TrendlineType.Logarithmic);
    logarithmicTrendline.addTextFrameForOverriding("New log trend line");

    ITrendline movingAverageTrendline = secondSeries.getTrendLines().add(TrendlineType.MovingAverage);
    movingAverageTrendline.setPeriod((byte) 3);
    movingAverageTrendline.setTrendlineName("New TrendLine Name");

    IChartSeries thirdSeries = chart.getChartData().getSeries().get_Item(2);

    ITrendline polynomialTrendline = thirdSeries.getTrendLines().add(TrendlineType.Polynomial);
    polynomialTrendline.setForward(1);
    polynomialTrendline.setOrder((byte) 3);

    ITrendline powerTrendline = thirdSeries.getTrendLines().add(TrendlineType.Power);
    powerTrendline.setBackward(1);

    presentation.save("ChartTrendLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **추세선 절편 설정**

[setIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#setIntercept-double-)을 사용하여 X = 0에서 추세선의 Y 값을 고정합니다. 이 설정은 선형, 지수 및 다항식 추세선에 대해 지원됩니다.

예를 들어, 생산 비용 모델은 비정상 생산량에서 측정값이 다른 기준선을 나타내더라도 알려진 고정 비용 100에서 시작해야 할 수 있습니다. 선형 추세선의 경우, 절편을 고정하면 방정식 `y = ax + b`가 `b = 100`으로 제한되고, 기울기는 해당 제한 하에서 데이터에 맞춰집니다. 이는 이미 맞춰진 선을 단순히 이동하는 것이 아닙니다. 축 교차 설정은 차트 축이 만나는 위치를 제어하며, 맞춰진 추세선의 계수를 제어하지 않습니다.

다음 예제는 생산량이 1에서 4까지인 산점도(XY) 차트를 만들고 비용을 170, 200, 230, 260으로 설정합니다. 차트를 기본 자동 절편으로 저장한 후 절편을 100으로 설정하고 두 번째 PPTX를 저장합니다. 두 파일은 절편 설정만 다릅니다. 추세선은 방정식을 표시하고 X = 0까지 뒤로 확장됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ScatterWithMarkers, 20, 20, 480, 210);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell nameCell = workbook.getCell(0, 0, 1, "Production cost");
    IChartSeries series = chart.getChartData().getSeries().add(nameCell, ChartType.ScatterWithMarkers);
    double[] costs = { 170, 200, 230, 260 };

    for (int i = 0; i < costs.length; i++) {
        IChartDataCell xCell = workbook.getCell(0, i + 1, 0, i + 1);
        IChartDataCell yCell = workbook.getCell(0, i + 1, 1, costs[i]);
        series.getDataPoints().addDataPointForScatterSeries(xCell, yCell);
    }

    ITrendline trendline = series.getTrendLines().add(TrendlineType.Linear);
    trendline.setDisplayEquation(true);
    trendline.setBackward(1);

    presentation.save("AutomaticIntercept.pptx", SaveFormat.Pptx);

    trendline.setIntercept(100);
    presentation.save("FixedIntercept.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

자동 계산을 사용하면 이 데이터에서 `y = 30x + 140`이 생성됩니다. 절편을 100으로 설정하면 대략 `y = 43.33x + 100`이 됩니다. 이는 0에서의 맞춰진 값이 알려진 기준선과 일치하지만, 선이 더 이상 모든 데이터 포인트를 통과하지 않음을 의미합니다.

| 자동 절편 | 절편 100 고정 |
| --- | --- |
| ![자동 계산된 절편 140을 가진 선형 추세선](intercept-automatic.png) | ![절편 100이 고정된 선형 추세선](intercept-fixed.png) |

두 이미지 모두 동일한 데이터와 축 눈금을 사용합니다. 추세선은 절편을 표시하기 위해 X = 0까지 뒤로 확장됩니다.

기본적으로 [getIntercept](https://reference.aspose.com/slides/java/com.aspose.slides/trendline/#getIntercept--)은 `Double.NaN`을 반환하는데, 이는 0이 아닌 지정되지 않은 절편을 의미합니다. 이후 절편은 데이터에서 자동으로 계산됩니다.

## **사용자 지정 선 추가**

사용자 지정 선은 시리즈 데이터에서 계산된 추세선이 아니라 차트 위에 그려지는 도형입니다. 이 예제에서는 [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-)를 사용하여 차트 위 슬라이드에 수평선을 추가합니다. 선의 위치는 포인트 단위의 슬라이드 좌표로 지정되어 차트의 왼쪽 가장자리에서 시작해 차트 중간 높이에 배치됩니다. 너비는 차트 너비와 동일합니다. [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--)은 선에 단색 빨간색을 적용합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);

    IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, chart.getX(), chart.getY() + chart.getHeight() / 2, chart.getWidth(), 0);
    line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("AddCustomLines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**추세선의 '앞쪽'과 '뒤쪽'은 무엇을 의미합니까?**

추세선이 앞쪽/뒤쪽으로 투영되는 길이를 나타냅니다. 산점도(XY) 차트에서는 축 단위로, 비산점도 차트에서는 카테고리 수로 표시됩니다. 음수값은 허용되지 않습니다.

**프레젠테이션을 PDF 또는 SVG로 내보내거나 슬라이드를 이미지로 렌더링할 때 추세선이 보존됩니까?**

예. Aspose.Slides는 프레젠테이션을 [PDF](/slides/ko/java/convert-powerpoint-to-pdf/) 또는 [SVG](/slides/ko/java/render-a-slide-as-an-svg-image/)로 변환하고 차트를 이미지로 렌더링합니다. 차트의 일부인 추세선은 이러한 작업 중에 보존됩니다. 또한 차트 이미지 내보내기를 위한 [차트 이미지 내보내기](/slides/ko/java/create-shape-thumbnails/) 메서드도 제공됩니다.