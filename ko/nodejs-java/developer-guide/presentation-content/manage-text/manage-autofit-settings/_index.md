---
title: JavaScript에서 AutoFit으로 프레젠테이션을 향상시키세요
linktitle: AutoFit 설정
type: docs
weight: 30
url: /ko/nodejs-java/manage-autofit-settings/
keywords:
- 텍스트 상자
- 자동 맞춤
- 자동 맞춤 사용 안 함
- 텍스트 맞춤
- 텍스트 축소
- 텍스트 줄 바꿈
- 도형 크기 조정
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js에서 AutoFit 설정을 관리하여 PowerPoint 및 OpenDocument 프레젠테이션의 텍스트 표시를 최적화하고 콘텐츠 가독성을 향상시킵니다."
---
## **소개**

기본적으로 텍스트 상자를 추가하면 Microsoft PowerPoint는 텍스트 상자에 대해 **Resize shape to fix text** 설정을 사용합니다—텍스트가 항상 상자 안에 들어가도록 자동으로 텍스트 상자의 크기를 조정합니다.

![PowerPoint의 텍스트 상자](textbox-in-powerpoint.png)

* 텍스트 상자의 텍스트가 길어지거나 커지면 PowerPoint가 자동으로 텍스트 상자를 확대(높이를 증가)시켜 더 많은 텍스트를 담을 수 있게 합니다.  
* 텍스트 상자의 텍스트가 짧아지거나 작아지면 PowerPoint가 자동으로 텍스트 상자를 축소(높이를 감소)시켜 불필요한 공간을 없앱니다.  

PowerPoint에서 텍스트 상자의 자동 맞춤 동작을 제어하는 4가지 중요한 매개변수 또는 옵션은 다음과 같습니다.

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![PowerPoint 자동 맞춤 옵션](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java는 유사한 옵션을 제공합니다—[TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스 아래의 일부 속성을 통해 프레젠테이션의 텍스트 상자에 대한 자동 맞춤 동작을 제어할 수 있습니다.

## **텍스트에 맞게 도형 크기 조정**

텍스트를 변경한 후에도 텍스트가 항상 해당 상자 안에 들어가게 하려면 **Resize shape to fix text** 옵션을 사용해야 합니다. 이 설정을 지정하려면 `Shape` 값을 사용하여 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setAutofitType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) 메서드를 호출합니다.

![텍스트에 맞게 도형 크기 자동 조정 설정](alwaysfit-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

텍스트가 길어지거나 커지면 텍스트 상자가 자동으로 높이가 늘어나도록 크기가 조정되어 모든 텍스트가 들어가게 됩니다. 텍스트가 짧아지면 그 반대가 일어납니다.

## **자동 맞춤 사용 안 함**

텍스트 상자나 도형이 텍스트 변경과 관계없이 원래 크기를 유지하도록 하려면 **Do not Autofit** 옵션을 사용해야 합니다. 이 설정을 지정하려면 `None` 값을 사용하여 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setAutofitType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) 메서드를 호출합니다.

![자동 맞춤 사용 안 함 설정](donotautofit-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

텍스트가 상자보다 길어지면 내용이 밖으로 흘러 나갑니다.

## **오버플로 시 텍스트 축소**

텍스트가 상자보다 길어질 경우 **Shrink text on overflow** 옵션을 사용하면 텍스트의 크기와 간격을 줄여 상자에 맞출 수 있습니다. 이 설정을 지정하려면 `Normal` 값을 사용하여 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setAutofitType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) 메서드를 호출합니다.

![오버플로 시 텍스트 축소 설정](shrinktextonoverflow-setting-powerpoint.png)

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
**Shrink text on overflow** 옵션을 사용하면 텍스트가 상자보다 길어질 때만 설정이 적용됩니다.
{{% /alert %}}

## **텍스트 줄 바꿈**

텍스트가 도형의 가로 경계(폭)를 넘어갈 때 텍스트를 도형 안에서 줄 바꿈하려면 **Wrap text in shape** 매개변수를 사용해야 합니다. 이 설정을 지정하려면 `true` 값을 사용하여 [TextFrameFormat](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat) 클래스의 [setWrapText](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) 메서드를 호출합니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
도형에 대해 `setWrapText` 메서드를 `False` 값으로 호출하면, 텍스트가 도형의 폭보다 길어질 때 텍스트가 한 줄로 도형 경계를 넘어 확장됩니다. 
{{% /alert %}}

## **FAQ**

**텍스트 프레임의 내부 여백이 AutoFit에 영향을 줍니까?**  
예. 내부 여백(패딩)으로 사용 가능한 텍스트 영역이 줄어들어 AutoFit이 더 일찍 작동합니다—글꼴을 축소하거나 도형 크기를 조정합니다. AutoFit을 조정하기 전 여백을 확인하고 조정하십시오.

**AutoFit은 수동 및 소프트 라인 브레이크와 어떻게 상호 작용합니까?**  
강제 라인 브레이크는 그대로 유지되며, AutoFit은 그 주위의 글꼴 크기와 간격을 조정합니다. 불필요한 라인 브레이크를 제거하면 AutoFit이 텍스트를 축소해야 하는 정도가 감소합니다.

**테마 글꼴을 변경하거나 글꼴 대체를 트리거하면 AutoFit 결과에 영향을 줍니까?**  
예. 다른 글리프 메트릭을 가진 글꼴로 대체하면 텍스트의 너비·높이가 변해 최종 글꼴 크기와 줄 바꿈이 달라질 수 있습니다. 글꼴을 변경하거나 대체한 후에는 슬라이드를 다시 확인하십시오.