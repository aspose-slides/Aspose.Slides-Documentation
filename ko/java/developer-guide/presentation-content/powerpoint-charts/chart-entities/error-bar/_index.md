---
title: Java를 사용하여 프레젠테이션 차트의 오류 막대 사용자 지정
linktitle: 오류 막대
type: docs
url: /ko/java/error-bar/
keywords:
- 오류 막대
- 사용자 지정 값
- 파워포인트
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 차트에 오류 막대를 추가하고 사용자 지정하는 방법을 배우고, PowerPoint 프레젠테이션의 데이터 시각화를 최적화하세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 막대를 사용하는 방법을 설명합니다. 차트 시리즈에 오류 막대를 추가하고, X 및 Y 오류 막대 설정을 구성하며, 고정값, 백분율 및 사용자 지정값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다.

또한 해당 데이터 포인트 컬렉션을 사용하여 시리즈의 개별 데이터 포인트에 사용자 지정 오류 막대 값을 할당하는 방법을 보여줍니다. 추가로, 오류 막대가 내보내기 중에 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 그리고 관련 API 참조 클래스와 열거형을 찾을 수 있는 위치에 대한 간단한 참고 사항도 포함하고 있습니다.

## **오류 막대 추가**
Aspose.Slides for Java는 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 사용자 지정 값 유형을 사용할 때 적용됩니다. 값을 지정하려면 시리즈의 [**DataPoints**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesCollection) 컬렉션에서 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용하십시오:

1. 프레젠테이션 클래스인 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation)의 인스턴스를 생성합니다.
2. 원하는 슬라이드에 버블 차트를 추가합니다.
3. 첫 번째 차트 시리즈에 액세스하고 오류 막대 X 형식을 설정합니다.
4. 첫 번째 차트 시리즈에 액세스하고 오류 막대 Y 형식을 설정합니다.
5. 막대 값과 형식을 설정합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// Presentation 클래스의 인스턴스 생성
Presentation pres = new Presentation();
try {
    // 버블 차트 생성
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 오류 막대를 추가하고 형식 설정
    IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Fixed);
    errBarX.setValue(0.1f);
    errBarY.setValueType((byte) ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType((byte) ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0f);
    errBarX.hasEndCap();

    // 프레젠테이션 저장
    pres.save("ErrorBars.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **사용자 지정 오류 막대 값 추가**
Aspose.Slides for Java는 사용자 지정 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IErrorBarsFormat#getValue--) 속성이 **Custom**과 같은 경우에 적용됩니다. 값을 지정하려면 시리즈의 [**DataPoints**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IChartSeriesCollection) 컬렉션에서 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용하십시오:

1. 프레젠테이션 클래스인 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation)의 인스턴스를 생성합니다.
2. 원하는 슬라이드에 버블 차트를 추가합니다.
3. 첫 번째 차트 시리즈에 액세스하고 오류 막대 X 형식을 설정합니다.
4. 첫 번째 차트 시리즈에 액세스하고 오류 막대 Y 형식을 설정합니다.
5. 차트 시리즈의 개별 데이터 포인트에 액세스하고 개별 시리즈 데이터 포인트에 대한 오류 막대 값을 설정합니다.
6. 막대 값과 형식을 설정합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```java
// Presentation 클래스의 인스턴스 생성
Presentation pres = new Presentation();
try {
    // 버블 차트 생성
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

    // 사용자 지정 오류 막대를 추가하고 형식 설정
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IErrorBarsFormat errBarX = series.getErrorBarsXFormat();
    IErrorBarsFormat errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType((byte) ErrorBarValueType.Custom);
    errBarY.setValueType((byte) ErrorBarValueType.Custom);

    // 차트 시리즈 데이터 포인트에 접근하고 오류 막대 값을 설정
    // 개별 포인트
    IChartDataPointCollection points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues((byte) DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues((byte) DataSourceType.DoubleLiterals);

    // 차트 시리즈 포인트에 대한 오류 막대 설정
    for (int i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }

    // 프레젠테이션 저장
    pres.save("ErrorBarsCustomValues.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**프레젠테이션을 PDF 또는 이미지로 내보낼 때 오류 막대는 어떻게 되나요?**

오류 막대는 차트의 일부로 렌더링되며, 호환 가능한 버전이나 렌더러를 사용하는 경우 변환 과정에서 차트 서식과 함께 보존됩니다.

**오류 막대를 마커 및 데이터 레이블과 함께 사용할 수 있나요?**

예. 오류 막대는 별개의 요소이며 마커 및 데이터 레이블과 호환됩니다. 요소가 겹치는 경우 서식을 조정해야 할 수도 있습니다.

**API에서 오류 막대를 다루기 위한 속성 및 클래스 목록은 어디서 찾을 수 있나요?**

API 참조에서 찾을 수 있습니다: [ErrorBarsFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/errorbarsformat/) 클래스와 관련 클래스인 [ErrorBarType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/errorbarvaluetype/)이 있습니다.