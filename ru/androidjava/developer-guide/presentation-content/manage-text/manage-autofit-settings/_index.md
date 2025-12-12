---
title: Улучшите свои презентации с помощью AutoFit на Android
linktitle: Настройки автоподгонки
type: docs
weight: 30
url: /ru/androidjava/manage-autofit-settings/
keywords:
- текстовое поле
- автоподгонка
- не автоподгонка
- подгонка текста
- уменьшить текст
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

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует параметр **Resize shape to fix text** для этого поля — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался в нём. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает высоту поля, чтобы в нём поместилось больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает высоту поля, освобождая лишнее пространство. 

В PowerPoint существует 4 важных параметра, управляющих поведением автоподгонки текста в текстовом поле: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java предоставляет аналогичные возможности — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat), которые позволяют управлять автоподгонкой текста в презентациях.

## **Resize a Shape to Fit Text**

Если вы хотите, чтобы текст в поле всегда помещался в этом поле после изменения текста, используйте параметр **Resize shape to fix text**. Чтобы задать этот параметр, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот Java‑код показывает, как указать, что текст всегда должен помещаться в своём поле в презентации PowerPoint:
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


Если текст становится длиннее или больше, текстовое поле автоматически изменяет размер (увеличивает высоту), чтобы весь текст поместился. Если текст становится короче, произойдёт обратное действие. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста, используйте параметр **Do not Autofit**. Чтобы задать этот параметр, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `None`.

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


Когда текст становится слишком длинным для своего поля, он выходит за его пределы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своего поля, с помощью параметра **Shrink text on overflow** можно задать уменьшение размера и межбуквенного интервала текста, чтобы он уместился. Чтобы задать этот параметр, установите свойство [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот Java‑код показывает, как указать, что текст должен уменьшаться при переполнении в презентации PowerPoint:
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
При использовании параметра **Shrink text on overflow** настройка применяется только тогда, когда текст становится слишком длинным для своего поля. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда он выходит за пределы ширины фигуры, используйте параметр **Wrap text in shape**. Чтобы задать этот параметр, установите свойство [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (из класса [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) в значение `true`.

Этот Java‑код показывает, как использовать параметр Wrap Text в презентации PowerPoint:
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
Если установить свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится длиннее её ширины, текст будет продолжать выводиться за пределами фигуры в одну линию. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового фрейма на AutoFit?**

Да. Отступы (внутренние поля) уменьшают доступную площадь для текста, поэтому AutoFit срабатывает раньше — уменьшая шрифт или изменяя размер фигуры раньше. Проверьте и отрегулируйте отступы перед настройкой AutoFit.

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**

Принудительные разрывы остаются на месте, а AutoFit подбирает размер шрифта и интервал вокруг них. Удаление ненужных разрывов часто снижает агрессивность сжатия текста.

**Влияет ли изменение шрифта темы или подмена шрифта на результаты AutoFit?**

Да. Замена шрифта на другой с другими метриками глифов изменяет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любой смены или подмены шрифта рекомендуется повторно проверить слайды.