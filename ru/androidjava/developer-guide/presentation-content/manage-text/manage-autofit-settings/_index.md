---
title: "Улучшите свои презентации с AutoFit на Android"
linktitle: "Настройки Autofit"
type: docs
weight: 30
url: /ru/androidjava/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- отключить автоподгонку
- подогнать текст
- сжать текст
- перенос текста
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Android
- Java
- Aspose.Slides
description: "Управляйте настройками AutoFit в Aspose.Slides для Android через Java, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и улучшить читаемость контента."
---


По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fix text** для текстового поля — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался в нём. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы разместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы убрать лишнее пространство. 

В PowerPoint существуют 4 важных параметра или опции, которые управляют поведением автоподгонки для текстового поля: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java предоставляет аналогичные параметры — некоторые свойства в классе [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) — которые позволяют управлять поведением автоподгонки для текстовых полей в презентациях.

## **Resize a Shape to Fit Text**

Если вы хотите, чтобы текст в рамке всегда помещался в неё после изменения текста, необходимо использовать параметр **Resize shape to fix text**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот Java‑код показывает, как указать, что текст всегда должен помещаться в своё поле в презентации PowerPoint:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст поместился. Если текст становится короче, произойдёт обратное действие. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, необходимо использовать параметр **Do not Autofit**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот Java‑код показывает, как указать, что текстовое поле всегда должно сохранять свои размеры в презентации PowerPoint:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


Когда текст становится слишком длинным для поля, он выходит за его границы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для поля, с помощью параметра **Shrink text on overflow** можно указать, что размер текста и межстрочный интервал должны уменьшаться, чтобы он поместился в поле. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот Java‑код показывает, как указать, что текст должен сжиматься при переполнении в презентации PowerPoint:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Info" color="info" %}}
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для поля. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст выходит за её ширину, используйте параметр **Wrap text in shape**. Чтобы задать эту настройку, необходимо установить свойство [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `true`.

Этот Java‑код показывает, как использовать настройку Wrap Text в презентации PowerPoint:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert title="Note" color="warning" %}} 
Если установить свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится длиннее её ширины, текст будет продолжаться за пределами фигуры в одну линию. 
{{% /alert %}}

## **FAQ**

**Внутренние отступы текстового кадра влияют на AutoFit?**

Да. Отступы (внутренние поля) уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — уменьшая шрифт или изменяя размер фигуры быстрее. Проверьте и при необходимости отрегулируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а AutoFit подстраивает размер шрифта и межстрочный интервал вокруг них. Удаление лишних разрывов часто снижает степень сжатия текста AutoFit.

**Влияет ли изменение шрифта темы или подстановка шрифта на результаты AutoFit?**

Да. Замена шрифта на другой с другими метриками глифов меняет ширину/высоту текста, что может изменить итоговый размер шрифта и перенос строк. После любой замены шрифта рекомендуется повторно проверить слайды.