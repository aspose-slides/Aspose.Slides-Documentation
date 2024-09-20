---
title: Управление настройками автоматической подгонки
type: docs
weight: 30
url: /androidjava/manage-autofit-settings/
keywords: "Текстовое поле, Автоподгонка, Презентация PowerPoint, Java, Aspose.Slides для Android через Java"
description: "Установите настройки автоматической подгонки для текстового поля в PowerPoint в Java"
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует настройку **Изменить размер фигуры для соответствия тексту** для текстового поля — оно автоматически изменяет размер текстового поля, чтобы текст всегда помещался в него.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — увеличивает его высоту — чтобы вместить больше текста.
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — уменьшает его высоту — для удаления избыточного пространства.

В PowerPoint есть 4 важных параметра или опции, которые контролируют поведение автоподгонки для текстового поля:

* **Не автоподгонять**
* **Уменьшить текст при переполнении**
* **Изменить размер фигуры для соответствия тексту**
* **Перенос текста в фигуре.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides для Android через Java предоставляет аналогичные опции — некоторые свойства в классе [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat), которые позволяют вам контролировать поведение автоподгонки для текстовых полей в презентациях.

## **Изменить размер фигуры для соответствия тексту**

Если вы хотите, чтобы текст в рамке всегда помещался в эту рамку после внесения изменений в текст, вам необходимо использовать опцию **Изменить размер фигуры для соответствия тексту**. Чтобы установить эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот код на Java показывает, как указать, что текст всегда должен помещаться в свою рамку в презентации PowerPoint:

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

Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличение высоты), чтобы гарантировать, что весь текст помещается в него. Если текст становится короче, происходит обратное.

## **Не автоподгонять**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры, независимо от изменений, вносимых в содержащий их текст, вам необходимо использовать опцию **Не автоподгонять**. Чтобы установить эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `None`.

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

Когда текст становится слишком длинным для своей рамки, он выходит за её пределы.

## **Уменьшить текст при переполнении**

Если текст становится слишком длинным для своей рамки, с помощью опции **Уменьшить текст при переполнении** вы можете указать, что размер и расстояние текста должны быть уменьшены, чтобы текст поместился в рамку. Чтобы установить эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `Normal`.

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

Когда используется опция **Уменьшить текст при переполнении**, настройка применяется только в том случае, если текст становится слишком длинным для своей рамки.

{{% /alert %}}

## **Перенос текста**

Если вы хотите, чтобы текст в фигуре оборачивался внутри этой фигуры, когда текст выходит за пределы границ фигуры (только по ширине), вам необходимо использовать параметр **Перенос текста в фигуре**. Чтобы установить эту настройку, вам необходимо установить свойство [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `true`.

Этот код на Java показывает, как использовать настройку переноса текста в презентации PowerPoint:

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

Если вы установите свойство `WrapText` в значение `False` для фигуры, когда текст внутри фигуры становится длиннее ширины фигуры, текст выходит за пределы границ фигуры в одну линию.

{{% /alert %}}