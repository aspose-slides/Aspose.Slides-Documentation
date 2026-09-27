---
title: Aspose.Slides 평가
type: docs
weight: 120
url: /ko/nodejs-net/evaluate-aspose-slides/
keywords:
- Aspose.Slides 평가
- 평가 버전
- 평가 워터마크
- 평가 제한 사항
- 임시 라이선스
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET 평가 버전이 제한하는 내용과, 두 제한을 보여주고 라이선스로 제거하는 방법을 보여주는 스크립트."
---
## **개요**

Aspose.Slides for Node.js via .NET 평가 버전은 정식 라이선스 버전과 동일한 npm 패키지입니다. 라이선스가 없으면 평가 모드로 실행되며: 모든 기능이 작동하지만 저장된 프레젠테이션 및 대부분의 내보내기에는 워터마크가 삽입되고 코드가 읽어오는 텍스트가 잘립니다. 이 문서에서는 두 제한 사항을 설명하고 이를 제거하는 방법을 보여줍니다.

## **평가 제한 사항**

**모든 슬라이드에 평가 워터마크가 표시됩니다.** 라이선스 없이 프레젠테이션을 저장하면 Aspose.Slides가 저장 파일의 각 슬라이드 중앙에 텍스트 상자를 추가합니다. 텍스트 상자는 잠겨 있으며 “Evaluation only.”라는 문구와 제품 라인, 저작권 라인이 표시됩니다. 워터마크는 메모리상의 프레젠테이션이 아니라 저장 파일에 들어가며, 프레젠테이션을 열 때 자동으로 추가되지 않습니다. 그러나 평가 모드에서 저장된 파일은 이미 텍스트 상자를 포함하고 있으므로 다시 열어 저장하면 각 슬라이드에 두 번째 워터마크가 추가됩니다.

PDF, XPS 또는 HTML로 내보내거나 슬라이드를 이미지로 렌더링할 때도 동일한 워터마크가 출력에 그려집니다. 이미 평가 모드에서 저장된 프레젠테이션을 렌더링하면 이미지에 저장된 워터마크와 렌더링된 워터마크가 모두 표시됩니다.

**코드가 읽을 때 텍스트가 잘립니다.** 텍스트 프레임, 단락 또는 부분의 `text` 속성을 통해 코드가 읽는 텍스트는 처음 다섯 문자로 잘리고 뒤에 “… text has been truncated due to evaluation version limitation.”라는 안내가 붙습니다. 다섯 문자 이하의 텍스트는 전체가 반환됩니다. 이 제한은 모든 슬라이드에 적용되며, 코드가 방금 할당한 텍스트에도 적용됩니다. Markdown 및 HTML5 내보내기도 동일하게 잘립니다.

코드가 쓰는 텍스트는 전체가 저장됩니다: PPTX 파일, PDF 페이지 및 슬라이드 이미지에는 완전한 텍스트가 포함됩니다.

## **스크립트에서 제한 사항 확인하기**

다음 스크립트는 두 제한 사항을 모두 보여줍니다. [설치](/slides/ko/nodejs-net/installation/)에 설명된 대로 패키지를 설치했고 프로젝트 폴더에서 실행한다고 가정합니다. 스크립트는 첫 번째 슬라이드에 문장이 포함된 사각형을 추가하고, 문장을 다시 읽고, 프레젠테이션을 `evaluation.pptx`로 저장한 뒤 파일을 다시 열어 슬라이드의 도형 수를 셉니다.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // 라이선스가 없으면 첫 다섯 문자만 반환됩니다.
    console.log("Text read back:", rectangle.textFrame.text);

    // 저장하면 파일의 모든 슬라이드에 평가 워터마크가 추가됩니다.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // 이 슬라이드에는 이제 사각형과 워터마크 텍스트 상자가 포함됩니다.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

라이선스가 없을 경우 스크립트 출력은 다음과 같습니다:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

두 번째 도형이 워터마크 텍스트 상자입니다. `evaluation.pptx`를 열어 사각형 안의 전체 문장과 슬라이드 중앙의 워터마크를 확인하십시오.

## **제한 사항 제거하기**

두 제한 사항을 모두 제거하려면 `Presentation` 객체를 만들기 전에 라이선스를 적용하십시오. [라이선스](/slides/ko/nodejs-net/licensing/)에서 라이선스 파일 적용 방법을 확인할 수 있습니다.

{{% alert color="success" title="Tip" %}}
구매 전에 평가 제한 없이 Aspose.Slides를 시험해 보려면 무료 **30일 임시 라이선스**를 요청하십시오. 자세한 내용은 [임시 라이선스를 받는 방법은?](https://purchase.aspose.com/temporary-license) 를 참조하십시오.
{{% /alert %}}

## **FAQ**

**평가 모드가 슬라이드 수를 제한합니까?**

아니요. 프레젠테이션은 모든 슬라이드를 포함한 상태로 생성, 열기 및 저장됩니다. 워터마크와 텍스트 잘림은 모든 슬라이드에 동일하게 적용됩니다.

**내가 내보낸 슬라이드 이미지에 워터마크가 두 번 표시되는 이유는 무엇인가요?**

프레젠테이션이 평가 모드에서 저장된 후 렌더링했기 때문에 이미 워터마크 텍스트 상자를 포함하고 있으며, 라이선스 없이 렌더링하면 또 다른 워터마크가 그 위에 그려집니다.

**평가 모드에서도 내 코드가 올바른 텍스트를 생성하는지 확인할 수 있나요?**

예. 저장된 파일이나 내보낸 PDF를 열면 전체 텍스트가 포함되어 있습니다. 코드가 다시 읽어오는 텍스트와 Markdown 또는 HTML5 출력만 잘립니다.