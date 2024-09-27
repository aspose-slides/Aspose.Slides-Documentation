---
title: Управление настройками автоматического изменения размера
type: docs
weight: 30
url: /ru/java/manage-autofit-settings/
keywords: "Текстовое поле, Автоматическое изменение размера, Презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Установите настройки автоматического изменения размера для текстового поля в PowerPoint на Java"
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Изменить размер фигуры, чтобы текст помещался** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы текст всегда помещался в него.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы оно могло содержать больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — чтобы избавиться от избыточного пространства.

В PowerPoint есть 4 важных параметра или опции, которые управляют поведением автоматического изменения размера для текстового поля:

* **Не изменять размер автоматически**
* **Уменьшить текст при переполнении**
* **Изменить размер фигуры, чтобы текст помещался**
* **Перенос текста в фигуре.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides для Java предоставляет аналогичные опции — некоторые свойства из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) — которые позволяют вам контролировать поведение автоматического изменения размера для текстовых полей в презентациях.

## **Изменить размер фигуры, чтобы текст помещался**

Если вы хотите, чтобы текст в коробке всегда помещался в эту коробку после внесения изменений в текст, вам нужно использовать опцию **Изменить размер фигуры, чтобы текст помещался**. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот код на Java показывает, как указать, что текст должен всегда помещаться в свою коробку в презентации PowerPoint:

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

Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличение высоты), чтобы обеспечить размещение всего текста в нем. Если текст становится короче, происходит обратное.

## **Не изменять размер автоматически**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры, независимо от изменений, внесенных в текст внутри них, вам нужно использовать опцию **Не изменять размер автоматически**. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот код на Java показывает, как указать, что текстовое поле должно всегда сохранять свои размеры в презентации PowerPoint:

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

Когда текст становится слишком длинным для своего поля, он выходит за его пределы.

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своего поля, с помощью опции **Уменьшить текст при переполнении** вы можете указать, что размер и интервал текста должны быть уменьшены, чтобы текст помещался в его коробку. Чтобы указать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот код на Java показывает, как указать, что текст должен быть уменьшен при переполнении в презентации PowerPoint:

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

{{% alert title="Информация" color="info" %}}

Когда используется опция **Уменьшить текст при переполнении**, настройка применяется только тогда, когда текст становится слишком длинным для своей коробки.

{{% /alert %}}

## **Перенос текста**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст превышает границы фигуры (только по ширине), вам нужно использовать параметр **Перенос текста в фигуре**. Чтобы указать эту настройку, вам нужно установить свойство [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в `true`.

Этот код на Java показывает, как использовать настройку Перенос текста в презентации PowerPoint:

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

{{% alert title="Примечание" color="warning" %}} 

Если вы установите свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится длиннее ширины фигуры, текст будет продолжен за пределами границ фигуры в одной строке.

{{% /alert %}}