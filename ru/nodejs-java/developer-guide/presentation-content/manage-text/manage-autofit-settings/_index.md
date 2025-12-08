---
title: Управление параметрами автоподгонки
type: docs
weight: 30
url: /ru/nodejs-java/manage-autofit-settings/
keywords: "Текстовое поле, Автоподгонка, Презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Настройте параметры автоподгонки для текстового поля в PowerPoint с помощью JavaScript"
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fix text** для текстового поля — она автоматически меняет размер текстового поля, чтобы его текст всегда помещался в него. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы разместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы удалить лишнее пространство. 

В PowerPoint это 4 важных параметра или опции, которые контролируют поведение автоподгонки для текстового поля: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java предоставляет похожие варианты — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) — которые позволяют управлять поведением автоподгонки для текстовых полей в презентациях.

## **Resize Shape to Fit Text**

Если вы хотите, чтобы текст в коробке всегда помещался в эту коробку после изменения текста, необходимо использовать опцию **Resize shape to fix text**. Чтобы задать эту настройку, вызовите метод [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) с значением `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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


Если текст становится длиннее или больше, текстовое поле будет автоматически изменено в размере (увеличена высота), чтобы весь текст поместился. Если текст становится короче, произойдёт обратное. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, необходимо использовать опцию **Do not Autofit**. Чтобы задать эту настройку, вызовите метод [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) с значением `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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


Когда текст становится слишком длинным для своего поля, он выходит за пределы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своего поля, с помощью опции **Shrink text on overflow** вы можете указать, что размер и интервал текста должны быть уменьшены, чтобы он поместился в поле. Чтобы задать эту настройку, вызовите метод [setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) со значением `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своего поля. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда он выходит за пределы её границы (только по ширине), необходимо использовать параметр **Wrap text in shape**. Чтобы задать эту настройку, вызовите метод [setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) класса [TextFrameFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrameFormat) со значением `true`.

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
Если вызвать метод `setWrapText` со значением `False` для фигуры, когда текст внутри неё становится длиннее ширины фигуры, текст будет выходить за пределы её границ в одну строку. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового кадра на AutoFit?**

Да. Отступы (внутренние поля) уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — шрифт уменьшается или фигура изменяется в размере быстрее. Проверьте и скорректируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются на своих местах, а AutoFit адаптирует размер шрифта и межсимвольный интервал вокруг них. Удаление лишних разрывов часто уменьшает необходимость агрессивного уменьшения текста.

**Влияет ли изменение шрифта темы или подстановка шрифта на результаты AutoFit?**

Да. Замена шрифта на другой с другими метриками глифов меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой смены или подстановки шрифта повторно проверьте слайды.