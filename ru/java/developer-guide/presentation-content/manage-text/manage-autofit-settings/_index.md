---
title: Улучшите ваши презентации с помощью AutoFit в Java
linktitle: Настройки AutoFit
type: docs
weight: 30
url: /ru/java/manage-autofit-settings/
keywords:
- текстовое поле
- автоналадка
- не автонастройка
- подгонка текста
- уменьшение текста
- перенос текста
- изменение размера фигуры
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Узнайте, как управлять настройками AutoFit в Aspose.Slides для Java, чтобы оптимизировать отображение текста в ваших презентациях PowerPoint и OpenDocument и повысить читаемость содержимого."
---

По умолчанию, когда вы добавляете текстовое поле, Microsoft PowerPoint использует параметр **Resize shape to fix text** для текстового поля — он автоматически изменяет размер текстового поля, чтобы его текст всегда помещался в нём. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Когда текст в текстовом поле становится длиннее или больше, PowerPoint автоматически увеличивает текстовое поле — повышает его высоту — чтобы разместить больше текста. 
* Когда текст в текстовом поле становится короче или меньше, PowerPoint автоматически уменьшает текстовое поле — снижает его высоту — освобождая лишнее пространство. 

В PowerPoint существуют 4 важных параметра или опции, управляющие поведением автонастройки для текстового поля: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java предоставляет аналогичные параметры — некоторые свойства класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) — которые позволяют управлять поведением автонастройки для текстовых полей в презентациях. 

## **Resize Shape to Fit Text**

Если вы хотите, чтобы текст в коробке всегда помещался в неё после изменений, необходимо использовать параметр **Resize shape to fix text**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Этот фрагмент кода на Java показывает, как задать, чтобы текст всегда помещался в свою коробку в презентации PowerPoint:
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


Если текст становится длиннее или больше, текстовое поле будет автоматически изменено (увеличена высота), чтобы весь текст поместился в нём. Если текст становится короче, происходит обратное. 

## **Do Not Autofit**

Если вы хотите, чтобы текстовое поле или фигура сохраняли свои размеры независимо от изменений текста внутри, необходимо использовать параметр **Do not Autofit**. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Этот фрагмент кода на Java показывает, как задать, чтобы текстовое поле всегда сохраняло свои размеры в презентации PowerPoint:
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


Когда текст становится слишком длинным для своего поля, он выходит за его границы. 

## **Shrink Text on Overflow**

Если текст становится слишком длинным для своего поля, с помощью параметра **Shrink text on overflow** можно задать уменьшение размера и интервала текста, чтобы он поместился в поле. Чтобы задать эту настройку, установите свойство [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Этот фрагмент кода на Java показывает, как задать уменьшение текста при переполнении в презентации PowerPoint:
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
Когда используется параметр **Shrink text on overflow**, настройка применяется только тогда, когда текст становится слишком длинным для своего поля. 
{{% /alert %}}

## **Wrap Text**

Если вы хотите, чтобы текст в фигуре переносился внутри этой фигуры, когда текст выходит за её границы (только по ширине), необходимо использовать параметр **Wrap text in shape**. Чтобы задать эту настройку, нужно установить свойство [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (класса [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) в значение `true`. 

Этот фрагмент кода на Java показывает, как использовать настройку Wrap Text в презентации PowerPoint:
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
Если установить свойство `WrapText` в `False` для фигуры, когда текст внутри фигуры становится длиннее её ширины, он будет продолжаться за пределами границы фигуры в одну линию. 
{{% /alert %}}

## **FAQ**

**Влияют ли внутренние отступы текстового кадра на AutoFit?**  

Да. Заполнение (внутренние отступы) уменьшает доступную область для текста, поэтому AutoFit срабатывает раньше — шрифт уменьшается или фигура изменяется быстрее. Проверьте и отрегулируйте отступы перед настройкой AutoFit.  

**Как AutoFit взаимодействует с ручными и мягкими разрывами строк?**  

Принудительные разрывы остаются, а AutoFit подстраивает размер шрифта и интервалы вокруг них. Удаление лишних разрывов часто уменьшает степень сжатия текста AutoFit.  

**Влияет ли изменение шрифта темы или замена шрифта на результаты AutoFit?**  

Да. Замена шрифта на другой с другими метриками глифов меняет ширину/высоту текста, что может изменить конечный размер шрифта и перенос строк. После любого изменения или замены шрифта следует повторно проверить слайды.