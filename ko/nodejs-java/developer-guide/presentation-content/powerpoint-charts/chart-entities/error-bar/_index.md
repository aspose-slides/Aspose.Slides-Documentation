---
title: JavaScript를 사용하여 프레젠테이션 차트에서 오류 막대 맞춤 설정
linktitle: 오류 막대
type: docs
url: /ko/nodejs-java/error-bar/
keywords:
- 오류 막대
- 사용자 지정 값
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript와 Aspose.Slides for Node.js via Java를 사용하여 차트에 오류 막대를 추가하고 맞춤 설정하는 방법을 배우고, PowerPoint 프레젠테이션에서 데이터 시각화를 최적화하세요."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 막대를 작업하는 방법을 설명합니다. 차트 시리즈에 오류 막대를 추가하고, X 및 Y 오류 막대 설정을 구성하며, 고정값, 백분율 및 사용자 지정 값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다.

또한 해당 데이터 포인트 컬렉션을 사용하여 시리즈의 개별 데이터 포인트에 사용자 지정 오류 막대 값을 지정하는 방법을 시연합니다. 추가로 오류 막대가 내보내기 중에 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 관련 API 참조 클래스 및 열거형을 찾을 수 있는 위치에 대한 간단한 참고 사항도 포함합니다.

## **오류 막대 추가**

Aspose.Slides for Node.js via Java는 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 사용자 지정 값 유형을 사용할 때 적용됩니다. 값을 지정하려면 시리즈의 [**DataPoints**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesCollection) 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 막대 값 및 형식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 버블 차트를 생성합니다
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // 오류 막대를 추가하고 형식을 설정합니다
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2.0);
    errBarX.hasEndCap();
    // 프레젠테이션을 저장합니다
    pres.save("ErrorBars.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **사용자 지정 오류 막대 값 추가**

Aspose.Slides for Node.js via Java는 사용자 지정 오류 막대 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 [**ErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ErrorBarsFormat#getValue--) 속성이 **Custom**인 경우에 적용됩니다. 값을 지정하려면 시리즈의 [**DataPoints**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ChartSeriesCollection) 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 원하는 슬라이드에 버블 차트를 추가합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 X 형식을 설정합니다.
1. 첫 번째 차트 시리즈에 접근하여 오류 막대 Y 형식을 설정합니다.
1. 차트 시리즈의 개별 데이터 포인트에 접근하여 각 데이터 포인트에 대한 오류 막대 값을 설정합니다.
1. 막대 값 및 형식을 설정합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```javascript
// Presentation 클래스의 인스턴스를 생성합니다
var pres = new aspose.slides.Presentation();
try {
    // 버블 차트를 생성합니다
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    // 사용자 지정 오류 막대를 추가하고 형식을 설정합니다
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.isVisible();
    errBarY.isVisible();
    errBarX.setValueType(aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(aspose.slides.ErrorBarValueType.Custom);
    // 차트 시리즈 데이터 포인트에 접근하고 오류 막대 값을 설정합니다
    // 개별 포인트
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(aspose.slides.DataSourceType.DoubleLiterals);
    // 차트 시리즈 포인트에 대한 오류 막대를 설정합니다
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    // 프레젠테이션을 저장합니다
    pres.save("ErrorBarsCustomValues.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**프레젠테이션을 PDF 또는 이미지로 내보낼 때 오류 막대는 어떻게 되나요?**

차트의 일부로 렌더링되며, 호환 가능한 버전이나 렌더러를 사용한다면 차트 서식과 함께 변환 과정에서 유지됩니다.

**오류 막대를 마커 및 데이터 레이블과 함께 사용할 수 있나요?**

예. 오류 막대는 별도 요소이며 마커 및 데이터 레이블과 호환됩니다. 요소가 겹칠 경우 서식을 조정해야 할 수도 있습니다.

**API에서 오류 막대를 다루기 위한 속성 및 열거형 목록은 어디에서 찾을 수 있나요?**

API 참조의 [ErrorBarsFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/errorbarsformat/) 클래스와 관련 열거형 [ErrorBarType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/errorbarvaluetype/)에서 확인할 수 있습니다.