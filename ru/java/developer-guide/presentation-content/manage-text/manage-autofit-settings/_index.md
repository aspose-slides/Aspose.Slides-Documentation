---
title: Улучшите свои презентации с помощью AutoFit в Java
linktitle: Настройки автоподгонки
type: docs
weight: 30
url: /ru/java/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- без автоподгонки
- подгонка текста
- уменьшить текст
- перенос текста
- изменить размер фигуры
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для Java, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и повысить читаемость контента."
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Resize shape to fix text** для текстового поля — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался в нём. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически расширяет текстовое поле — увеличивает его высоту — чтобы вместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — снижает его высоту — чтобы удалить лишнее пространство. 

В PowerPoint это 4 важных параметра или опции, контролирующих поведение автоподгонки для текстового поля: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java предоставляет аналогичные варианты — некоторые свойства в классе [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) — которые позволяют управлять поведением автоподгонки для текстовых полей в презентациях. 

## **Resize a Shape to Fit Text**

Если вы хотите, чтобы текст в поле всегда помещался в этом поле после изменения текста, необходимо использовать параметр **Resize shape to fix text**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот Java‑код демонстрирует, как указать, что текст всегда должен помещаться в своё поле в презентации PowerPoint:
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


Если текст становится длиннее или больше, размер текстового поля будет автоматически изменён (увеличен по высоте), чтобы весь текст поместился в нём. Если текст становится короче, произойдёт обратное. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или форма сохраняли свои размеры независимо от изменений текста, вам нужно использовать параметр **Do not Autofit**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот Java‑код демонстрирует, как указать, что текстовое поле всегда должно сохранять свои размеры в презентации PowerPoint:
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


Когда текст становится слишком длинным для своего поля, он выходит за пределы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своего поля, через параметр **Shrink text on overflow** можно указать, что размер и интервал текста должны быть уменьшены, чтобы он поместился в поле. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот Java‑код демонстрирует, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:
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
При использовании опции **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своего поля. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в форме переносился внутри этой формы, когда текст выходит за её границы по ширине, необходимо использовать параметр **Wrap text in shape**. Чтобы задать эту настройку, нужно установить свойство [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `true`. 

Этот Java‑код демонстрирует, как использовать настройку Wrap Text в презентации PowerPoint:
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
Если установить свойство `WrapText` в `False` для формы, когда текст внутри формы становится длиннее её ширины, текст будет выходить за пределы границ формы в одну строку. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового кадра на AutoFit?**

Да. Внутренние отступы (padding) уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — шрифт уменьшается или форма изменяется быстрее. Проверьте и при необходимости скорректируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с принудительными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а AutoFit подбирает размер шрифта и интервал вокруг них. Удаление лишних разрывов часто уменьшает необходимость сильного сжатия текста.

**Влияют ли изменение шрифта темы или подстановка шрифта на результаты AutoFit?**

Да. Подмена шрифта на другой с другими метриками глифов меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой замены или подстановки шрифта рекомендуется пересмотреть слайды.