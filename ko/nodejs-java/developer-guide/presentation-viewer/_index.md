---
title: JavaScript로 프레젠테이션 뷰어 만들기
linktitle: 프레젠테이션 뷰어
type: docs
weight: 50
url: /ko/nodejs-java/presentation-viewer/
keywords:
- 프레젠테이션 보기
- 프레젠테이션 뷰어
- 프레젠테이션 뷰어 만들기
- PPT 보기
- PPTX 보기
- ODP 보기
- 파워포인트
- 오픈문서
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript로 맞춤형 프레젠테이션 뷰어를 만들 수 있습니다. Microsoft PowerPoint 없이도 PowerPoint 및 OpenDocument 파일을 손쉽게 표시합니다."
---
## **소개**

Aspose.Slides for Node.js via Java은 슬라이드가 포함된 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 예를 들어 Microsoft PowerPoint에서 프레젠테이션을 열어 볼 수 있습니다. 하지만 때때로 개발자는 슬라이드를 선호하는 이미지 뷰어에서 이미지로 보거나 자체 프레젠테이션 뷰어를 만들 필요가 있을 수 있습니다. 이런 경우 Aspose.Slides를 사용하면 개별 슬라이드를 이미지로 내보낼 수 있습니다. 이 기사에서는 그 방법을 설명합니다.

## **슬라이드에서 SVG 이미지 생성**

다음 단계에 따라 Aspose.Slides를 사용하여 프레젠테이션 슬라이드에서 SVG 이미지를 생성하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 파일 스트림을 엽니다.
1. 슬라이드를 SVG 이미지로 파일 스트림에 저장합니다.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```

## **사용자 정의 Shape ID로 SVG 생성**

Aspose.Slides를 사용하여 사용자 정의 Shape ID가 있는 슬라이드에서 [SVG](https://docs.fileformat.com/page-description-language/svg/)를 생성할 수 있습니다. 이를 위해서는 [SvgShape](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/svgshape/)의 `setId` 메서드를 사용합니다. `CustomSvgShapeFormattingController`를 사용하여 Shape ID를 설정할 수 있습니다.

```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```
```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```

## **슬라이드 썸네일 이미지 생성**

Aspose.Slides는 슬라이드의 썸네일 이미지를 생성하는 데 도움을 줍니다. Aspose.Slides를 사용하여 슬라이드 썸네일을 생성하려면, 다음 단계에 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 스케일로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **사용자 정의 차원으로 슬라이드 썸네일 생성**

사용자 정의 차원으로 슬라이드 썸네일 이미지를 만들려면, 다음 단계에 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 정의된 차원으로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```

## **슬라이드 썸네일에 발표자 노트 포함하기**

Aspose.Slides를 사용하여 발표자 노트가 포함된 슬라이드 썸네일을 생성하려면, 다음 단계에 따르세요:

1. [RenderingOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/renderingoptions/) 클래스의 인스턴스를 생성합니다.
1. `RenderingOptions.setSlidesLayoutOptions` 메서드를 사용하여 발표자 노트 위치를 설정합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. 인덱스로 슬라이드 참조를 가져옵니다.
1. 렌더링 옵션을 적용하여 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```

## **실시간 예제**

다음 무료 앱인 [**Aspose.Slides Viewer**](https://products.aspose.app/slides/ko/viewer/)을 사용해 Aspose.Slides API로 구현할 수 있는 기능을 확인해 보세요:

![온라인 PowerPoint 뷰어](online-PowerPoint-viewer.png)

## **FAQ**

**Node.js 웹 애플리케이션에 프레젠테이션 뷰어를 삽입할 수 있나요?**

예. 서버 측에서 Aspose.Slides를 사용해 슬라이드를 이미지나 HTML로 렌더링하고 브라우저에 표시할 수 있습니다. 탐색 및 확대/축소 기능은 JavaScript를 사용해 인터랙티브한 경험으로 구현할 수 있습니다.

**맞춤 뷰어 안에서 슬라이드를 표시하는 가장 좋은 방법은 무엇인가요?**

권장 방법은 각 슬라이드를 이미지(PNG 또는 SVG 등)로 렌더링하거나 Aspose.Slides를 사용해 HTML로 변환한 후, 데스크톱에서는 PictureBox에, 웹에서는 HTML 컨테이너에 출력물을 표시하는 것입니다.

**많은 슬라이드가 있는 대형 프레젠테이션을 어떻게 처리하나요?**

대용량 프레젠테이션의 경우 슬라이드를 지연 로드하거나 필요할 때만 렌더링하는 방식을 고려하십시오. 이는 사용자가 해당 슬라이드로 이동했을 때만 슬라이드 내용을 생성함으로써 메모리 사용량과 로드 시간을 줄이는 효과가 있습니다.