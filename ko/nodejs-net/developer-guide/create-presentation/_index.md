---
title: Node.js via .NET에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/nodejs-net/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새 프레젠테이션
- PowerPoint 만들기
- PPTX 만들기
- 텍스트 상자 추가
- 슬라이드 추가
- 슬라이드 크기
- 와이드스크린
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET를 사용하여 JavaScript로 PowerPoint 프레젠테이션을 만들고, 텍스트 상자와 슬라이드를 추가하며, 16:9 슬라이드 크기를 설정하고 결과를 PPTX로 저장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Node.js via .NET을 사용하여 프레젠테이션을 만들고, 첫 번째 슬라이드에 텍스트 상자를 추가한 뒤 결과를 PPTX 파일로 저장하는 방법을 보여줍니다. 또한 슬라이드를 더 추가하고 프레젠테이션을 와이드스크린(16:9) 슬라이드로 전환하는 방법도 보여줍니다.

예제들은 [Installation](/slides/ko/nodejs-net/installation/)에 설명된 대로 프로젝트를 설정해야 합니다. 각 예제를 프로젝트 폴더에 `.js` 파일로 저장하고 해당 폴더에서 `node`를 사용해 실행하십시오. 예: `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET에는 자체 API 레퍼런스가 없습니다. camelCase 이름을 사용하여 Aspose.Slides for .NET API를 그대로 반영하므로, 이 문서의 API 링크는 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ko/net/)에 있는 해당 클래스와 멤버로 연결됩니다.
{{% /alert %}}

## **텍스트 상자가 포함된 프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 넣으려면 다음 단계를 따르세요:

1. 새 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 새로운 프레젠테이션에는 이미 빈 슬라이드가 하나 포함되어 있습니다.
2. [slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션에서 해당 슬라이드를 가져옵니다. 이 패키지의 컬렉션은 `get(index)` 로 읽으며, 인덱스는 0부터 시작합니다.
3. [addAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/shapecollection/addautoshape/) 메서드로 사각형을 추가하고, 해당 [textFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/textframe/)의 [text](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/text/)를 설정합니다.
4. [save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드와 `SaveFormat.Pptx` 값을 사용하여 프레젠테이션을 저장합니다.
5. `finally` 블록에서 `dispose`를 호출하여 프레젠테이션을 지원하는 .NET 리소스를 해제합니다.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 위치 (x, y)와 크기 (너비, 높이)는 포인트 단위입니다.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

스크립트는 `new-presentation.pptx` 파일을 프로젝트 폴더에 작성합니다. 이 파일에는 하나의 슬라이드가 있으며, 슬라이드 왼쪽 및 위쪽 가장자리에서 50 포인트 떨어진 위치에 채워진 사각형이 있습니다. 사각형의 너비는 400 포인트, 높이는 100 포인트이며, 텍스트는 가운데 정렬됩니다. 포인트는 1인치당 72 포인트입니다. 라이선스가 없을 경우 Aspose.Slides는 슬라이드에 평가 워터마크를 추가합니다; 자세한 내용은 [Licensing](/slides/ko/nodejs-net/licensing/)을 참조하십시오.

## **슬라이드 추가**

새 프레젠테이션에는 슬라이드가 하나 있습니다. 더 추가하려면 `slides` 컬렉션의 [addEmptySlide](https://reference.aspose.com/slides/ko/net/aspose.slides/slidecollection/addemptyslide/) 메서드에 레이아웃 슬라이드를 전달합니다. [layoutSlides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/layoutslides/) 컬렉션의 [getByType](https://reference.aspose.com/slides/ko/net/aspose.slides/layoutslidecollection/getbytype/) 메서드는 지정된 [SlideLayoutType](https://reference.aspose.com/slides/ko/net/aspose.slides/slidelayouttype/)의 첫 번째 레이아웃을 반환합니다.

다음 예제는 Blank 레이아웃을 사용하여 두 개의 슬라이드를 추가합니다:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

스크립트는 `Slide count: 3`을 출력하고 `three-slides.pptx`를 작성합니다. 새 슬라이드는 첫 번째 슬라이드 뒤에 추가되며 도형이 없습니다. 새 프레젠테이션은 항상 Blank 레이아웃을 갖지만 파일에서 연 프레젠테이션은 요청된 유형의 레이아웃이 없을 수 있습니다; 이 경우 `getByType`은 `null`을 반환하므로 사용하기 전에 결과를 확인하십시오.

## **슬라이드 크기 설정**

새 프레젠테이션은 4:3 슬라이드(720 × 540 포인트, 10 × 7.5 인치)를 사용합니다. 와이드스크린 슬라이드를 만들려면 프레젠테이션의 [slideSize](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slidesize/)에 대해 [setSize](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesize/setsize/) 메서드를 호출하고, [SlideSizeType](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesizetype/) 값과 [SlideSizeScaleType](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesizescaletype/) 값을 지정합니다. 스케일 유형은 이미 슬라이드에 존재하는 도형을 어떻게 처리할지 Aspose.Slides에 알려줍니다; `DoNotScale`은 도형을 그대로 두어 아직 내용이 없는 프레젠테이션에 적합합니다.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

스크립트는 `Slide size: 960 x 540 points`을 출력하고 이는 13.33 × 7.5 인치이며 `widescreen.pptx`를 작성합니다. `SlideSizeType.OnScreen16x9`는 동일한 16:9 비율이지만 더 작아 720 × 405 포인트가 됩니다.

## **FAQ**

**위치와 크기는 어떤 단위로 측정되나요?**  
포인트 단위입니다. 1인치는 72 포인트이므로 기본 4:3 슬라이드는 720 × 540 포인트이고, 16:9 와이드스크린 슬라이드는 960 × 540 포인트입니다.

**새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?**  
[SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 열거형의 모든 값을 사용할 수 있습니다. 예를 들어 PowerPoint 97–2003용 `SaveFormat.Ppt`, OpenDocument용 `SaveFormat.Odp`, 또는 `SaveFormat.Pdf` 등이 있습니다. PDF 출력에 대해서는 [Convert PowerPoint to PDF](/slides/ko/nodejs-net/convert-powerpoint-to-pdf/)을 참고하십시오.

**저장된 프레젠테이션에 "Evaluation only" 텍스트가 포함된 이유는 무엇인가요?**  
라이선스가 없을 경우 Aspose.Slides는 저장된 슬라이드에 평가 워터마크를 추가합니다. 워터마크를 제거하려면 [Licensing](/slides/ko/nodejs-net/licensing/)에 설명된 대로 라이선스를 적용하십시오.

**왜 `dispose`를 호출해야 하나요?**  
`Presentation` 객체는 메모리와 기타 리소스를 보유한 .NET 객체에 의해 지원됩니다. `dispose`를 호출하면 프레젠테이션이 더 이상 필요하지 않을 때 해당 리소스를 즉시 해제할 수 있으며, `finally` 블록에서 호출하면 오류가 발생하더라도 리소스가 해제됩니다.