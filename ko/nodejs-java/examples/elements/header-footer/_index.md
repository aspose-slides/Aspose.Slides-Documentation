---
title: 헤더 및 푸터
type: docs
weight: 220
url: /ko/nodejs-java/examples/elements/header-footer/
keywords:
- 코드 예제
- 헤더
- 푸터
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js로 슬라이드 머리글 및 바닥글을 제어합니다: PPT, PPTX 및 ODP에서 날짜, 슬라이드 번호, 사용자 정의 텍스트를 JavaScript 예제로 추가합니다."
---
이 문서는 **Aspose.Slides for Node.js via Java**를 사용하여 푸터를 추가하고 날짜 및 시간 자리 표시자를 업데이트하는 방법을 보여줍니다.

## **푸터 추가**
슬라이드의 푸터 영역에 텍스트를 추가하고 표시되게 합니다.

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **날짜 및 시간 업데이트**
슬라이드의 날짜 및 시간 자리 표시자를 수정합니다.

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```