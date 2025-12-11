---
title: Verbessern Sie Ihre Präsentationen mit AutoFit auf Android
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/androidjava/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- Nicht automatisch anpassen
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

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfeldes die Einstellung **Resize shape to fix text** für das Textfeld – es passt die Größe des Textfeldes automatisch an, damit der Text stets hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – die Höhe wird erhöht – um mehr Text aufnehmen zu können. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld automatisch – die Höhe wird reduziert – um überflüssigen Raum zu entfernen. 

In PowerPoint sind dies die 4 wichtigen Parameter bzw. Optionen, die das Autofit‑Verhalten für ein Textfeld steuern: 

* **Nicht automatisch anpassen**
* **Text bei Überlauf verkleinern**
* **Formgröße an Text anpassen**
* **Text in Form umbrechen**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java bietet ähnliche Optionen – einige Eigenschaften in der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) – mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können.

## **Formgröße an Text anpassen**

Wenn der Text in einem Feld nach Änderungen immer in dieses Feld passen soll, müssen Sie die Option **Resize shape to fix text** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser Java‑Code zeigt, wie Sie festlegen können, dass ein Text stets in sein Feld in einer PowerPoint‑Präsentation passt:
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


Wird der Text länger oder größer, wird das Textfeld automatisch in der Größe angepasst (die Höhe wird erhöht), damit der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Nicht automatisch anpassen**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen unverändert beibehält, unabhängig von Änderungen am enthaltenen Text, müssen Sie die Option **Do not Autofit** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser Java‑Code zeigt, wie Sie festlegen können, dass ein Textfeld seine Abmessungen in einer PowerPoint‑Präsentation stets beibehält:
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


Wenn der Text zu lang für das Feld wird, läuft er über. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie mithilfe der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Setzen Sie dazu die Eigenschaft [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Java‑Code zeigt, wie Sie festlegen können, dass ein Text bei Überlauf in einer PowerPoint‑Präsentation verkleinert wird:
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
Wenn die Option **Shrink text on overflow** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für das Feld wird. 
{{% /alert %}}

## **Text umbrechen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umbrochen wird, sobald er die Formbegrenzung (nur Breite) überschreitet, müssen Sie den Parameter **Wrap text in shape** verwenden. Setzen Sie dazu die Eigenschaft [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat)) auf `true`.

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
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `False` setzen, wird der Text bei einer Breitenüberschreitung der Form in einer einzigen Zeile über die Formgrenzen hinaus erweitert. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textbereichs das AutoFit?**

Ja. Innenabstände reduzieren die nutzbare Textfläche, sodass AutoFit früher eingreift – die Schrift wird verkleinert oder die Form früher angepasst. Prüfen und passen Sie die Ränder an, bevor Sie AutoFit feineinstellen.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand rund um diese an. Das Entfernen unnötiger Umbrüche verringert häufig, wie aggressiv AutoFit den Text verkleinern muss.

**Wirkt sich das Ändern der Design‑Schriftart oder das Auslösen einer Schriftart‑Substitution auf die AutoFit‑Ergebnisse aus?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyphen‑Maßen ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und den Zeilenumbruch beeinflussen kann. Nach jeder Schriftart‑Änderung sollten Sie die Folien erneut prüfen.