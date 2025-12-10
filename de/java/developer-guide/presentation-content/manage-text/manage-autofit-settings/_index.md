---
title: "Verbessern Sie Ihre Präsentationen mit AutoFit in Java"
linktitle: "Autofit-Einstellungen"
type: docs
weight: 30
url: /de/java/manage-autofit-settings/
keywords:
- Textfeld
- automatisches Anpassen
- Nicht automatisch anpassen
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße ändern
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie die AutoFit‑Einstellungen in Aspose.Slides für Java verwalten, um die Textanzeige in Ihren PowerPoint‑ und OpenDocument‑Präsentationen zu optimieren und die Lesbarkeit von Inhalten zu verbessern."
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die Einstellung **Resize shape to fix text** für das Textfeld – es passt die Größe des Textfelds automatisch an, damit sein Text immer hineinpasst. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – es erhöht die Höhe –, sodass mehr Text hineinpassen kann. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, verringert PowerPoint das Textfeld automatisch – es reduziert die Höhe –, um überflüssigen Platz zu entfernen. 

In PowerPoint sind dies die vier wichtigen Parameter bzw. Optionen, die das Autofit‑Verhalten für ein Textfeld steuern: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java bietet ähnliche Optionen – einige Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) –, mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können. 

## **Formgröße an Text anpassen**

Wenn Sie möchten, dass der Text in einem Feld nach Änderungen immer in dieses Feld passt, müssen Sie die Option **Resize shape to fix text** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

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


Wird der Text länger oder größer, wird das Textfeld automatisch in der Größe angepasst (Höhe erhöht), sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil. 

## **Nicht automatisch anpassen**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehält, müssen Sie die Option **Do not Autofit** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) auf `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

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


Wenn der Text zu lang für sein Feld wird, läuft er heraus. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie über die Option **Shrink text on overflow** festlegen, dass Größe und Zeilenabstand des Textes reduziert werden, damit er in das Feld passt. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

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
Wenn die Option **Shrink text on overflow** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 
{{% /alert %}}

## **Text umbrechen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umbrochen wird, sobald er die Formgrenze (nur Breite) überschreitet, müssen Sie den Parameter **Wrap text in shape** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) (aus der Klasse [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat)) auf `true`. 

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


{{% alert title="Hinweis" color="warning" %}} 
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `False` setzen, wird der Text, sobald er länger als die Breite der Form ist, über die Formgrenzen hinweg in einer einzigen Zeile fortgesetzt. 
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textrahmens das AutoFit?**

Ja. Innenabstände (Padding) verkleinern den nutzbaren Textbereich, sodass AutoFit früher greift – die Schrift wird früher verkleinert oder die Form früher skaliert. Passen Sie die Ränder an, bevor Sie AutoFit einstellen.

**Wie verhält sich AutoFit bei manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben bestehen, und AutoFit passt Schriftgröße und Abstand um diese herum an. Das Entfernen unnötiger Umbrüche reduziert oft, wie aggressiv AutoFit den Text verkleinern muss.

**Wirkt sich das Ändern der Designthemen‑Schriftart oder das Auslösen einer Schriftart‑Substitution auf das AutoFit-Ergebnis aus?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyph‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und den Zeilenumbruch verändern kann. Nach jeder Schriftart‑Änderung sollten die Folien erneut geprüft werden.