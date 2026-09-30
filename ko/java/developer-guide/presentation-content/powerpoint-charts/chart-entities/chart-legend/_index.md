---
title: Java를 사용하여 프레젠테이션에서 차트 범례 맞춤 설정
linktitle: 차트 범례
type: docs
url: /ko/java/chart-legend/
keywords:
- 차트 범례
- 범례 위치
- 글꼴 크기
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 차트 범례를 맞춤 설정하고, 맞춤형 범례 서식으로 PowerPoint 프레젠테이션을 최적화합니다."
---
## **개요**

Aspose.Slides for Java는 PowerPoint 프레젠테이션에서 차트 범례를 사용자 지정하는 옵션을 제공합니다. 이 문서에서는 범례의 위치와 크기를 지정하고, 전체 범례의 글꼴 크기를 설정하고, 개별 범례 항목을 서식 지정하며, 선택한 항목을 숨기거나 복원하는 방법을 보여줍니다.

FAQ에서는 범례에 대한 공간을 예약하고, 여러 줄 레이블을 표시하며, 프레젠테이션 테마의 서식을 상속받는 등 관련 동작을 다룹니다.

## **범례 위치 지정**

범례의 [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), 및 [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) 메서드를 사용하여 차트 크기에 대한 비율로 위치와 크기를 지정합니다.

이 예제는 프레젠테이션을 생성하고 첫 번째 슬라이드에 기본 데이터가 있는 클러스터형 열 차트를 추가합니다. 원하는 범례 오프셋과 차원값을 차트의 너비와 높이로 나누면 상대값으로 변환됩니다. 범례는 차트 왼쪽 위 모서리에서 50포인트만큼 오프셋되며 크기는 100×100 포인트입니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // 차트에 상대적인 범례의 위치와 크기를 지정합니다.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **범례의 글꼴 크기 설정**

범례의 [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--)을 사용하여 텍스트 서식에 접근하고, [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-)을 사용하여 포인트 단위로 글꼴 크기를 설정합니다.

이 예제는 기본 데이터가 있는 차트를 생성하고 범례 텍스트를 20포인트로 설정합니다. 또한 수직 축의 자동 범위를 비활성화하고 범위를 -5부터 10까지로 설정합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **개별 범례 항목의 글꼴 크기 설정**

범례의 [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) 메서드가 반환하는 컬렉션을 사용하여 특정 항목의 서식에 접근합니다. 항목 인덱스는 0부터 시작하므로 인덱스 `1`은 두 번째 항목을 의미합니다.

이 예제는 기본 데이터에 최소 두 개의 시리즈가 포함된 클러스터형 열 차트를 생성합니다. 두 번째 범례 항목을 굵게, 기울임꼴 및 20포인트 파란색 텍스트로 서식 지정합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **개별 범례 항목 숨기기**

데이터는 그대로 두고 보조 시리즈를 범례에서 제외하려면 [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-)을 `true`와 함께 [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--)를 통해 호출합니다. 이렇게 하면 선택한 범례 항목만 숨겨지고 시리즈나 데이터 포인트는 제거되지 않습니다. 반대로 [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-)을 `false`로 호출하면 전체 범례가 숨겨집니다.

아래 예제는 기본 데이터를 사용하여 여러 시리즈가 있는 클러스터형 열 차트를 생성합니다. 두 번째 시리즈의 범례 항목(인덱스 `1`)을 숨기고 프레젠테이션을 저장합니다. 그런 다음 [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-)을 `false`로 호출하여 항목을 복원하고 두 번째 사본을 저장합니다. 두 파일 모두에서 열은 계속 표시됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // 차트 데이터를 변경하지 않고 동일한 항목을 복원합니다.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

아래 비교는 모든 항목이 표시되고 시리즈 2가 범례에서 숨겨진 차트를 보여줍니다. 두 번째 시리즈의 열은 변경되지 않습니다.

![모든 범례 항목이 표시되고 시리즈 2가 범례에서 숨겨진 차트 비교; 모든 열은 계속 표시됩니다.](hide-legend-entry.png)

열, 막대 및 선 차트에서는 범례 항목이 시리즈를 식별합니다. 파이 차트에서는 개별 데이터 포인트(슬라이스)를 식별하므로 선택한 슬라이스에 대해 [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--)을 사용합니다. API에서는 이 데이터 포인트 메서드를 `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie`, `BarOfPie` 차트 유형에 대해 문서화합니다. 해당 목록에 포함되지 않은 도넛 차트에는 적용된다고 가정하지 마세요.

## **FAQ**

**차트가 범례 위에 겹치지 않고 범례를 위해 공간을 할당하도록 할 수 있나요?**

예. [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)을 `false`로 호출하면 플롯 영역과 겹치지 않고 범례를 위해 공간을 예약합니다.

**다중 줄 범례 레이블을 만들 수 있나요?**

예. 사용 가능한 너비가 부족하면 긴 레이블이 자동으로 줄 바꿈됩니다. 또한 시리즈 이름에 줄 바꿈 문자를 사용하여 강제로 줄을 나눌 수 있습니다.

**범례가 프레젠테이션 테마의 색 구성표를 따르게 하려면 어떻게 해야 하나요?**

범례의 색상, 채우기 및 글꼴을 설정하지 않으면 테마 서식을 상속받습니다. 명시적인 서식 지정은 해당 테마 설정을 재정의합니다.