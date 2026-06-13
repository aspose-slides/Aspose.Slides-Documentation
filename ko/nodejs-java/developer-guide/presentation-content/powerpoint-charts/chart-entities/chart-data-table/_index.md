---
title: JavaScript를 사용하여 프레젠테이션에서 차트 데이터 테이블 사용자 지정
linktitle: 데이터 테이블
type: docs
url: /ko/nodejs-java/chart-data-table/
keywords:
- 차트 데이터
- 데이터 테이블
- 글꼴 속성
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PPT 및 PPTX용 JavaScript에서 차트 데이터 테이블을 맞춤 설정하여 프레젠테이션의 효율성과 매력을 높입니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 차트 데이터 테이블을 사용하는 방법을 설명합니다. 차트에 데이터 테이블을 표시하고 굵은 스타일 및 글꼴 높이와 같은 글꼴 속성을 설정하여 텍스트 서식을 사용자 정의하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 로드하고, 차트를 추가하며, 차트 데이터 테이블을 활성화하고, 글꼴 설정을 적용한 뒤, 업데이트된 프레젠테이션을 저장하는 과정을 시연합니다.

또한 차트 데이터 테이블에 범례 키를 표시하는 방법, 내보내기 시 데이터 테이블을 보존하는 방법, 기존 프레젠테이션이나 템플릿에서 로드한 차트를 다루는 방법, 그리고 데이터 테이블이 활성화된 차트를 식별하는 일반적인 질문에 대한 간단한 답변도 포함합니다.

## **차트 데이터 테이블의 글꼴 속성 설정**

Aspose.Slides for Node.js via Java는 시리즈 색상의 범주 색상을 변경하는 기능을 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스 개체를 인스턴스화합니다.
1. 슬라이드에 차트를 추가합니다.
1. 차트 테이블을 설정합니다.
1. 글꼴 높이를 설정합니다.
1. 수정된 프레젠테이션을 저장합니다.

아래 예제가 제공됩니다.

```javascript
// 빈 프레젠테이션 만들기
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**차트 데이터 테이블의 값 옆에 작은 범례 키를 표시할 수 있나요?**

예. 데이터 테이블은 [legend keys](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/datatable/setshowlegendkey/)를 지원하며, 이를 켜거나 끌 수 있습니다.

**프레젠테이션을 PDF, HTML 또는 이미지로 내보낼 때 데이터 테이블이 보존됩니까?**

예. Aspose.Slides는 차트를 슬라이드의 일부로 렌더링하므로, 내보낸 [PDF](/slides/ko/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/ko/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/ko/nodejs-java/convert-powerpoint-to-png/)에는 차트와 함께 데이터 테이블이 포함됩니다.

**템플릿 파일에서 가져온 차트에도 데이터 테이블이 지원됩니까?**

예. 기존 프레젠테이션이나 템플릿에서 로드한 차트라면, 차트의 속성을 사용하여 데이터 테이블이 [표시되는지](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/hasdatatable/) 확인하고 변경할 수 있습니다.

**파일 내에서 데이터 테이블이 활성화된 차트를 빠르게 찾으려면 어떻게 해야 하나요?**

각 차트의 [표시되는지](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/chart/hasdatatable/) 확인하는 속성을 검사하고 슬라이드를 순회하여 데이터 테이블이 활성화된 차트를 식별합니다.