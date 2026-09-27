---
title: Node.js(.NET)에서 프레젠테이션 텍스트 관리
linktitle: 텍스트 관리
type: docs
weight: 50
url: /ko/nodejs-net/manage-text/
keywords:
- 텍스트
- 텍스트 상자
- 텍스트 추가
- 텍스트 변경
- 텍스트 형식 지정
- 글꼴 크기
- 굵은 텍스트
- 텍스트 프레임
- 단락
- 포션
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET을 사용하여 JavaScript로 슬라이드에 텍스트 상자를 추가하고, 텍스트, 글꼴 크기 및 굵은 스타일을 변경합니다."
---
## **개요**

Aspose.Slides에서 슬라이드의 텍스트는 도형에 속합니다. 사각형과 같은 자동 도형에는 텍스트 프레임이 있으며, 텍스트 프레임은 단락을 포함하고 각 단락은 동일한 서식을 가진 텍스트 조각(포션)으로 구성됩니다. 텍스트는 텍스트 프레임을 통해 변경하고, 글꼴은 포션의 서식을 통해 변경합니다.

이 문서에서는 슬라이드에 텍스트 상자를 추가하고 프레젠테이션을 저장합니다. 그런 다음 저장된 파일을 열어 텍스트 상자의 텍스트, 글꼴 크기 및 굵게 스타일을 변경합니다.

예제는 [설치](/slides/ko/nodejs-net/installation/)에 설명된 대로 프로젝트를 설정해야 합니다. 각 예제를 프로젝트 폴더에 `.js` 파일로 저장하고 해당 폴더에서 `node`로 실행합니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET에는 자체 API 참조가 없습니다. camelCase 이름을 사용하는 Aspose.Slides for .NET API를 그대로 반영하므로, 이 문서의 API 링크는 [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/ko/net/)의 해당 클래스 및 멤버로 연결됩니다.
{{% /alert %}}

## **텍스트 상자 추가**

텍스트 상자를 추가하려면 [addAutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/shapecollection/addautoshape/) 메서드로 슬라이드에 자동 도형을 추가하고, [addTextFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/addtextframe/) 메서드로 텍스트를 지정합니다. 다음 예제는 새 프레젠테이션의 첫 번째 슬라이드에 사각형을 추가하고 프레젠테이션을 `text-box.pptx` 파일로 저장합니다.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // 위치 (x, y)와 크기 (width, height)는 포인트 단위입니다.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

`text-box.pptx`의 슬라이드에는 가로 500포인트, 세로 80포인트 크기의 사각형이 포함되어 있으며, 기본 글꼴 및 크기로 "Quarterly report" 텍스트가 표시됩니다. 다음 예제에서는 이 텍스트 상자를 변경합니다.

## **텍스트 및 서식 변경**

다음 예제는 이전 예제가 만든 `text-box.pptx`를 열어 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다. 사진이나 표와 같은 도형에는 텍스트 프레임이 없으므로, 예제에서는 도형이 [AutoShape](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/)인지 확인한 후 도형의 [textFrame](https://reference.aspose.com/slides/ko/net/aspose.slides/autoshape/textframe/)을 사용합니다. 그 후 다음 작업을 수행합니다.

1. 텍스트 프레임의 [text](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/text/) 속성을 통해 텍스트를 교체합니다. 이후 텍스트 프레임에는 하나의 단락과 하나의 포션이 포함됩니다.
1. [paragraphs](https://reference.aspose.com/slides/ko/net/aspose.slides/textframe/paragraphs/) 및 [portions](https://reference.aspose.com/slides/ko/net/aspose.slides/paragraph/portions/) 컬렉션에서 해당 포션을 가져와 [portionFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/portion/portionformat/)을 읽습니다.
1. [fontHeight](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontheight/) (포인트 단위 글꼴 크기)와 [fontBold](https://reference.aspose.com/slides/ko/net/aspose.slides/baseportionformat/fontbold/) (값이 [NullableBool](https://reference.aspose.com/slides/ko/net/aspose.slides/nullablebool/)인 속성)을 설정합니다.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

`text-box-updated.pptx`에서는 텍스트 상자가 "Quarterly report: third quarter"라는 내용을 굵게 32포인트 크기로 표시합니다. 새로운 텍스트가 하나의 포션으로 구성되었기 때문에 두 서식 속성이 전체에 적용됩니다. 라이선스가 없으면 저장할 때마다 평가 워터마크가 추가됩니다. `text-box.pptx` 자체도 평가 모드로 저장되었으므로 `text-box-updated.pptx`에는 워터마크가 두 개 포함됩니다. 자세한 내용은 [Evaluate Aspose.Slides](/slides/ko/nodejs-net/evaluate-aspose-slides/)를 참고하십시오.

## **FAQ**

**왜 `fontBold`는 `true`나 `false`가 아니라 `NullableBool` 값을 사용하나요?**

포션은 속성을 정의하지 않고 단락, 도형 또는 슬라이드 레이아웃·마스터에서 상속받을 수 있습니다. `NullableBool.NotDefined`는 "상속"을 의미하고, `NullableBool.True`와 `NullableBool.False`는 상속값을 덮어씁니다. `true` 또는 `false`를 직접 할당하면 오류가 발생합니다. 동일한 이유로 `fontHeight`는 포션이 글꼴 크기를 상속받을 때 `NaN`을 반환합니다.

**텍스트 색상을 어떻게 변경하나요?**

포션 서식의 fill을 설정합니다. `portionFormat.fillFormat.fillType`에 `FillType.Solid`를 지정하고, `portionFormat.fillFormat.solidFillColor.color`에 `"#FF0000"`와 같은 색상을 지정합니다. 패키지에서 가져오는 이름에 `FillType`을 추가하십시오.

**텍스트의 일부만 어떻게 서식 지정하나요?**

서식은 포션에 적용되므로, 서식을 적용할 텍스트 부분을 별도의 포션으로 만듭니다. `Portion.CreatePortionFromText`로 포션을 생성하고, 단락의 `portions` 컬렉션의 `add` 메서드로 추가한 뒤 새 포션의 `portionFormat`을 설정합니다. 패키지에서 가져오는 이름에 `Portion`을 추가하십시오.

**텍스트를 읽을 때 “… text has been truncated due to evaluation version limitation”라는 메시지가 나타나는 이유는 무엇인가요?**

라이선스가 없으면 Aspose.Slides는 읽은 텍스트가 길 경우 첫 다섯 문자만 반환하고 뒤에 이 안내문을 붙입니다. 작성한 텍스트는 전체가 저장됩니다. 전체 텍스트를 읽으려면 [Licensing](/slides/ko/nodejs-net/licensing/)에 설명된 대로 라이선스를 적용하십시오.