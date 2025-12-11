---
title: Verbessern Sie Ihre Präsentationen mit AutoFit auf Android
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/androidjava/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- nicht autofit
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße anpassen
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie AutoFit-Einstellungen in Aspose.Slides für Android via Java, um die Textdarstellung in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

Standardmäßig verwendet Microsoft PowerPoint für ein Textfeld die Einstellung **Resize shape to fix text** – das Textfeld wird automatisch angepasst, sodass der Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld – erhöht die Höhe – um mehr Text aufnehmen zu können.  
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld – reduziert die Höhe – um überflüssigen Raum zu entfernen.  

In PowerPoint gibt es vier wichtige Parameter bzw. Optionen, die das Autofit‑Verhalten eines Textfelds steuern: 

* **Do not Autofit**  
* **Shrink text on overflow**  
* **Resize shape to fit text**  
* **Wrap text in shape.**  

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für Android via Java bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) – mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können.

## **Formgröße an Text anpassen**

Wenn der Text in einem Feld stets in das Feld passen soll, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Resize shape to fix text** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser Java‑Code zeigt, wie Sie festlegen, dass ein Text immer in sein Feld in einer PowerPoint‑Präsentation passen muss:
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


Wird der Text länger oder größer, wird das Textfeld automatisch vergrößert (Höhe wird erhöht), damit der gesamte Text hineinpasst. Wird der Text kürzer, passiert das Gegenteil. 

## **Nicht automatisch anpassen**

Wenn ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehalten soll, verwenden Sie die Option **Do not Autofit**. Setzen Sie dazu die Eigenschaft [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser Java‑Code zeigt, wie Sie festlegen, dass ein Textfeld seine Abmessungen in einer PowerPoint‑Präsentation immer beibehält:
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


Wird der Text zu lang für sein Feld, läuft er über. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie mit der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Setzen Sie dazu die Eigenschaft [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Java‑Code zeigt, wie Sie festlegen, dass ein Text bei Überlauf in einer PowerPoint‑Präsentation verkleinert wird:
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
Wird die Option **Shrink text on overflow** verwendet, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 
{{% /alert %}}

## **Text umbrechen**

Wenn der Text in einer Form umbrochen werden soll, sobald er die Breite der Form überschreitet, verwenden Sie den Parameter **Wrap text in shape**. Setzen Sie dazu die Eigenschaft [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `true`.

Dieser Java‑Code zeigt, wie Sie die Einstellung Wrap Text in einer PowerPoint‑Präsentation verwenden:
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
Setzen Sie die `WrapText`‑Eigenschaft für eine Form auf `False`, wird bei längeren Texten die Zeile über die Formgrenzen hinaus verlängert, statt umzubrechen. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textfelds das AutoFit?**

Ja. Innenabstände (Padding) verkleinern den nutzbaren Bereich für Text, sodass AutoFit früher greift – die Schrift wird früher verkleinert oder die Form früher angepasst. Überprüfen und korrigieren Sie die Ränder, bevor Sie AutoFit feinjustieren.

**Wie verhält sich AutoFit bei manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand rund um diese an. Das Entfernen unnötiger Umbrüche reduziert meist das Ausmaß, in dem AutoFit den Text verkleinern muss.

**Wirkt sich das Ändern der Design‑Schriftart oder das Auslösen einer Schriftersetzung auf AutoFit‑Ergebnisse aus?**

Ja. Der Austausch gegen eine Schriftart mit anderen Glyphen‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und den Zeilenumbruch beeinflussen kann. Nach jeder Schriftänderung oder -ersetzung sollten Sie die Folien erneut prüfen.