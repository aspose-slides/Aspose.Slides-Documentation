---
title: Node.js via .NET에서 프레젠테이션 슬라이드를 이미지로 변환
linktitle: 슬라이드 이미지
type: docs
weight: 40
url: /ko/nodejs-net/convert-slide/
keywords:
- 슬라이드 변환
- 슬라이드 이미지
- 슬라이드 PNG
- 슬라이드 이미지 저장
- 슬라이드 렌더링
- 슬라이드 썸네일
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET를 사용해 JavaScript에서 PPTX, PPT 및 ODP 프레젠테이션의 슬라이드를 PNG 이미지로 렌더링합니다. 스케일 팩터 또는 정확한 픽셀 크기로 변환할 수 있습니다."
---
## **개요**

Aspose.Slides for Node.js via .NET은 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드를 이미지로 렌더링합니다. 예를 들어 웹 페이지에 슬라이드 미리보기를 표시할 때 사용할 수 있습니다. 이 문서에서는 이미지 크기를 선택하는 두 가지 방법, 즉 슬라이드 크기에 대한 비율 인자와 픽셀 단위의 정확한 크기를 보여줍니다. 두 예제 모두 PNG 파일을 저장합니다.

예제는 프로젝트 폴더에 `sample.pptx`라는 이름의 프레젠테이션이 있다고 가정합니다. 이 프레젠테이션은 [Installation](/slides/ko/nodejs-net/installation/)에서 설정한 프로젝트 폴더에 있어야 합니다. 어떤 PowerPoint 프레젠테이션이든 사용할 수 있습니다. 각 예제를 프로젝트 폴더에 `.js` 파일로 저장하고 해당 폴더에서 `node` 명령으로 실행하십시오.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET에는 자체 API 레퍼런스가 없습니다. 이 제품은 Aspose.Slides for .NET API를 camelCase 이름으로 그대로 반영하므로, 이 문서의 API 링크는 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ko/net/)의 해당 클래스와 멤버로 연결됩니다.
{{% /alert %}}

슬라이드를 이미지로 변환하려면 다음 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/presentation/) 생성자를 사용해 프레젠테이션을 엽니다.
2. `get(index)`를 사용해 [slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 컬렉션에서 슬라이드를 가져옵니다. 인덱스는 0부터 시작합니다.
3. `getImageWithScale` 또는 `getImageWithImageSize`로 슬라이드를 렌더링합니다. .NET API 레퍼런스에서는 두 메서드 모두 [Slide.GetImage](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/getimage/)의 오버로드이며, [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체를 반환합니다.
4. 이미지의 [save](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/save/) 메서드와 [ImageFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/) 값을 사용해 저장한 뒤, `dispose` 메서드로 해제합니다.

## **모든 슬라이드를 PNG 이미지로 변환**

`getImageWithScale`은 가로와 세로 비율 인자를 받습니다. 비율이 1이면 슬라이드의 1포인트가 이미지의 1픽셀에 해당합니다. 다음 예제는 모든 슬라이드를 비율 2로 렌더링합니다:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// 스케일 1은 포인트당 한 픽셀을 렌더링합니다; 2는 너비와 높이를 두 배로 늘립니다.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

스크립트는 슬라이드마다 하나의 파일을 작성합니다(`slide_1.png`, `slide_2.png` 등). 파일 번호는 1부터 시작합니다. 960 × 540 포인트 슬라이드를 가진 16:9 프레젠테이션의 경우 각 이미지 크기는 1920 × 1080 픽셀입니다. 숨김 슬라이드도 렌더링되며, 이를 건너뛰려면 슬라이드의 [hidden](https://reference.aspose.com/slides/ko/net/aspose.slides/slide/hidden/) 속성을 확인하세요. 각 이미지는 자체 `finally` 블록에서 해제되어 다음 슬라이드가 렌더링되기 전에 메모리가 해제됩니다. 라이선스가 없으면 이미지에 평가용 워터마크가 표시됩니다. 자세한 내용은 [Licensing](/slides/ko/nodejs-net/licensing/)를 참조하세요.

## **지정 크기의 이미지로 슬라이드 변환**

`getImageWithImageSize`는 픽셀 단위의 `width`와 `height`를 포함하는 객체를 받습니다. 다음 예제는 첫 번째 슬라이드를 가로 1280픽셀로 렌더링하고 슬라이드 크기로부터 높이를 계산하여 이미지가 슬라이드의 종횡비를 유지하도록 합니다:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

[slideSize.size](https://reference.aspose.com/slides/ko/net/aspose.slides/slidesize/size/) 속성은 슬라이드의 너비와 높이를 포인트 단위로 반환합니다. 16:9 프레젠테이션의 경우 스크립트는 `Saved a 1280 x 720 image`를 출력하고 `slide_1_1280px.png` 파일을 생성합니다. 4:3 프레젠테이션에서는 이미지가 1280 × 960 픽셀이 됩니다.

## **FAQ**

**`getImage`를 인수 없이 호출하면 이미지가 왜 이렇게 작나요?**  
인수를 제공하지 않을 경우 `getImage`는 슬라이드를 포인트 크기의 20%로 렌더링하므로, 960 × 540 포인트 슬라이드가 192 × 108 픽셀 이미지가 됩니다. 크기를 지정하려면 `getImageWithScale` 또는 `getImageWithImageSize`를 사용하세요.

**JPEG 등 다른 이미지 형식으로 저장하려면 어떻게 해야 하나요?**  
이미지의 `save` 메서드에 다른 `ImageFormat` 값을 전달하면 됩니다. 예: `image.save("slide_1.jpg", ImageFormat.Jpeg)`. 형식은 `ImageFormat` 값에 따라 결정되며 파일 확장자와 일치시켜야 합니다.

**Linux에서 이미지의 텍스트가 다르게 보이는 이유는 무엇인가요?**  
Aspose.Slides는 슬라이드를 렌더링하는 머신에 설치된 폰트만 사용할 수 있습니다. 프레젠테이션에 사용된 폰트가 누락된 경우(예: 일반적인 Linux 서버에 Calibri가 없을 때) Aspose.Slides는 대체 폰트를 사용해 텍스트 모양과 줄 바꿈이 달라질 수 있습니다. Windows와 동일한 이미지를 얻으려면 프레젠테이션에 사용된 폰트를 설치하세요.

**`getThumbnailWithImageSize`가 TypeError를 발생시키는 이유는 무엇인가요?**  
패키지 README에 `getThumbnailWithImageSize`가 언급되어 있지만 패키지에는 `getThumbnail` 메서드가 없습니다. 대신 동일한 `{ width, height }` 인자를 받는 `getImageWithImageSize`를 사용하세요.