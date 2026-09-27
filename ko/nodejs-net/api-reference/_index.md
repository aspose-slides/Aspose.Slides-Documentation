---
title: API 레퍼런스
type: docs
weight: 50
url: /ko/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET은 Aspose.Slides for .NET API 레퍼런스로 문서화됩니다. .NET 클래스 및 멤버 이름이 JavaScript에 어떻게 매핑되는지 확인하십시오."
---
## **개요**

Aspose.Slides for Node.js via .NET은 자체 API 참조가 없습니다. 이 패키지는 Aspose.Slides for .NET의 클래스를 동일한 이름으로 JavaScript에 노출하며, 멤버 이름은 camelCase로 변환됩니다. 따라서 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/)에서 해당 클래스, 멤버 및 열거형을 문서화하고 있습니다.

## **.NET 이름을 JavaScript에 매핑**

- **클래스와 열거형은 .NET 이름을 유지합니다**, 열거형 값도 마찬가지입니다: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. 패키지에서 다음과 같이 가져옵니다: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **속성 및 메서드는 소문자로 시작합니다.** `Presentation.Slides`는 `presentation.slides`가 되고, `ShapeCollection.AddAutoShape`는 `shapes.addAutoShape`가 됩니다. 속성은 그대로 속성이며, 괄호 없이 읽고 할당합니다.
- **컬렉션 항목은 `get(index)`로 읽고**, 항목 수는 `count`로 확인합니다: `presentation.slides.get(0)`은 `presentation.Slides[0]` 대신 사용합니다.
- **일부 오버로드는 별도의 이름을 가집니다.** 예를 들어, `Slide.GetImage(Size)` 오버로드는 `slide.getImageWithImageSize({ width, height })`입니다. 다른 경우는 선택적 뒤쪽 인수를 포함하는 하나의 메서드로 공유됩니다: `presentation.save(path, format, options, slides)`는 여러 `Presentation.Save` 오버로드를 포괄하고, `new Presentation(null, buffer)`는 `Buffer`에서 프레젠테이션을 엽니다. 각 클래스는 패키지의 `lib` 폴더 아래 하나의 파일에 존재합니다(예: `node_modules/aspose.slides.via.net/lib/Slide.js`), 여기서 정확한 이름을 확인할 수 있습니다.
- **사용이 끝난 프레젠테이션은 `dispose`로 해제합니다**; JavaScript에는 `using` 문이 없습니다.

패키지는 모든 .NET 멤버를 래핑하지 않습니다. .NET API 참조에 있는 멤버가 클래스 파일에 없으면 JavaScript에서 사용할 수 없습니다.

## **예제**

다음 스크립트는 위의 규칙을 사용합니다. 각 주석은 다음 줄에 해당하는 .NET 호출을 보여줍니다. 첫 번째 슬라이드에 텍스트가 있는 사각형을 추가하고, 슬라이드를 960 × 540 픽셀 PNG 이미지로 렌더링하며, 프레젠테이션을 PDF로 저장합니다. 패키지가 설치된 프로젝트 폴더에서 [Installation](/slides/ko/nodejs-net/installation/)에 설명된 대로 실행하십시오.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

스크립트는 현재 폴더에 `slide.png`와 `slide.pdf`를 작성합니다. 두 파일 모두 텍스트가 포함된 사각형을 보여줍니다. 라이선스가 없으면 평가 워터마크가 표시됩니다; [Licensing](/slides/ko/nodejs-net/licensing/)을 참조하십시오.

여기서 사용된 멤버에 대한 자세한 내용은 Aspose.Slides for .NET API 참조의 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) 및 [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/)를 참조하십시오.