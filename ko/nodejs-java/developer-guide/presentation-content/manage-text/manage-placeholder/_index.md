---
title: JavaScript에서 프레젠테이션 자리 표시자 관리
linktitle: 자리 표시자 관리
type: docs
weight: 10
url: /ko/nodejs-java/manage-placeholder/
keywords:
- 자리 표시자
- 텍스트 자리 표시자
- 이미지 자리 표시자
- 차트 자리 표시자
- 프롬프트 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 자리 표시자를 손쉽게 관리: 텍스트 교체, 프롬프트 사용자 지정 및 PowerPoint와 OpenDocument에서 이미지 투명도 설정."
---
## **개요**

Aspose.Slides를 사용하면 프레젠테이션 자리 표시자를 프로그래밍 방식으로 관리할 수 있습니다. 이 문서에서는 슬라이드에서 자리 표시자를 찾고 텍스트를 변경하는 방법, 자리 표시자 레이아웃에 사용자 지정 프롬프트 텍스트를 설정하는 방법, 자리 표시자 배경으로 사용되는 그림의 투명도를 조정하는 방법을 설명합니다. 또한 기본 자리 표시자와 로컬 도형의 차이를 명확히 하고, 자리 표시자 변경을 레이아웃이나 마스터를 통해 적용하는 방법을 설명하며, 머리글 및 바닥글 자리 표시자 관리에 대한 간단한 FAQ를 포함합니다.

## **자리 표시자 텍스트 변경**

[Aspose.Slides for Node.js via Java](/slides/ko/nodejs-java/)를 사용하면 프레젠테이션 슬라이드에서 자리 표시자를 찾아 수정할 수 있습니다. Aspose.Slides를 통해 자리 표시자의 텍스트를 변경할 수 있습니다.

**필수 조건**: 자리 표시자가 포함된 프레젠테이션이 필요합니다. 이러한 프레젠테이션은 표준 Microsoft PowerPoint 앱에서 만들 수 있습니다.

아래는 Aspose.Slides를 사용하여 해당 프레젠테이션의 자리 표시자 텍스트를 교체하는 방법입니다:

1. [`Presentation`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스를 인스턴스화하고 프레젠테이션을 인수로 전달합니다.
2. 인덱스를 사용하여 슬라이드 참조를 가져옵니다.
3. 도형을 반복하여 자리 표시자를 찾습니다.
4. 자리 표시자 도형을 [`AutoShape`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)으로 형변환하고, 해당 [`AutoShape`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/AutoShape)와 연결된 [`TextFrame`](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrame)을 사용하여 텍스트를 변경합니다.
5. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 자리 표시자 텍스트를 변경하는 방법을 보여줍니다:

```javascript
// Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // 첫 번째 슬라이드에 접근합니다
    var sld = pres.getSlides().get_Item(0);
    // 도형을 반복하여 자리 표시자를 찾습니다
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // 각 자리 표시자의 텍스트를 변경합니다
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // 프레젠테이션을 디스크에 저장합니다
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자리 표시자 프롬프트 텍스트 설정**

표준 및 미리 만든 레이아웃에는 ***Click to add a title*** 또는 ***Click to add a subtitle***와 같은 자리 표시자 프롬프트 텍스트가 포함되어 있습니다. Aspose.Slides를 사용하면 원하는 프롬프트 텍스트를 자리 표시자 레이아웃에 삽입할 수 있습니다.

다음 JavaScript 코드는 자리 표시자에 프롬프트 텍스트를 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // 슬라이드를 순회합니다
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint는 "Click to add title"을 표시합니다
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // 자막을 추가합니다
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **자리 표시자 이미지 투명도 설정**

Aspose.Slides를 사용하면 텍스트 자리 표시자 배경 이미지의 투명도를 설정할 수 있습니다. 해당 프레임의 그림 투명도를 조정하면 텍스트 또는 이미지가 돋보이게 할 수 있습니다(텍스트와 그림 색상에 따라 달라집니다).

다음 JavaScript 코드는 도형 내부의 그림 배경에 대한 투명도를 설정하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**기본 자리 표시자란 무엇이며, 슬라이드의 로컬 도형과는 어떻게 다릅니까?**

기본 자리 표시자는 레이아웃 또는 마스터에 있는 원본 도형으로, 슬라이드의 도형이 유형, 위치 및 일부 서식을 해당 도형에서 상속받습니다. 로컬 도형은 독립적이며, 기본 자리 표시자가 없는 경우 상속이 적용되지 않습니다.

**프레젠테이션 전체의 모든 제목이나 캡션을 각 슬라이드를 순회하지 않고 어떻게 업데이트할 수 있나요?**

레이아웃이나 마스터에 있는 해당 자리 표시자를 편집합니다. 해당 레이아웃/마스터를 기반으로 하는 슬라이드는 자동으로 변경 사항을 상속합니다.

**표준 머리글/바닥글 자리 표시자(날짜 및 시간, 슬라이드 번호, 바닥글 텍스트)를 어떻게 제어합니까?**

적절한 범위(일반 슬라이드, 레이아웃, 마스터, 노트/유인물)에서 HeaderFooter 관리자를 사용하여 해당 자리 표시자를 켜거나 끄고, 내용을 설정합니다.