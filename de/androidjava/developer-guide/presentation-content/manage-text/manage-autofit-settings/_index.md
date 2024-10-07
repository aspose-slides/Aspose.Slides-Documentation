---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /androidjava/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint-Präsentation, Java, Aspose.Slides für Android über Java"
description: "Stellen Sie die Autofit-Einstellungen für Textboxen in PowerPoint in Java ein"
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen einer Textbox die Einstellung **Form an Text anpassen** für die Textbox - sie passt die Textbox automatisch an, um sicherzustellen, dass der Text immer hineinpasst.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text in der Textbox länger oder größer wird, vergrößert PowerPoint automatisch die Textbox - erhöht deren Höhe - um mehr Text aufnehmen zu können. 
* Wenn der Text in der Textbox kürzer oder kleiner wird, reduziert PowerPoint automatisch die Textbox - verringert deren Höhe - um redundanten Platz zu bereinigen. 

In PowerPoint sind dies die 4 wichtigen Parameter oder Optionen, die das Autofit-Verhalten für eine Textbox steuern: 

* **Nicht anpassen**
* **Text bei Überlauf verkleinern**
* **Form an Text anpassen**
* **Text in der Form umbrechen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für Android über Java bietet ähnliche Optionen - einige Eigenschaften unter der [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) Klasse - die es Ihnen ermöglichen, das Autofit-Verhalten für Textboxen in Präsentationen zu steuern.

## **Form an Text anpassen**

Wenn Sie möchten, dass der Text in einer Box nach Änderungen am Text immer in diese Box passt, müssen Sie die Option **Form an Text anpassen** verwenden. Um diese Einstellung zu spezifizieren, setzen Sie die [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) Klasse) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser Java-Code zeigt Ihnen, wie Sie festlegen können, dass ein Text immer in seine Box in einer PowerPoint-Präsentation passen muss:

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

Wenn der Text länger oder größer wird, wird die Textbox automatisch angepasst (Höhenvergrößerung), damit der gesamte Text hineinpasst. Wenn der Text kürzer wird, tritt das Gegenteil ein. 

## **Nicht anpassen**

Wenn Sie möchten, dass eine Textbox oder Form ihre Abmessungen unabhängig von den Änderungen am Text, den sie enthält, beibehält, müssen Sie die Option **Nicht anpassen** verwenden. Um diese Einstellung zu spezifizieren, setzen Sie die [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) Klasse) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser Java-Code zeigt Ihnen, wie Sie festlegen können, dass eine Textbox immer ihre Abmessungen in einer PowerPoint-Präsentation beibehalten muss:

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

Wenn der Text zu lang für seine Box wird, überläuft er. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für seine Box wird, können Sie durch die Option **Text bei Überlauf verkleinern** festlegen, dass die Größe und der Abstand des Textes reduziert werden müssen, um in die Box zu passen. Um diese Einstellung zu spezifizieren, setzen Sie die [AutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) Klasse) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Java-Code zeigt Ihnen, wie Sie festlegen können, dass ein Text bei Überlauf in einer PowerPoint-Präsentation verkleinert werden muss:

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

Wenn die Option **Text bei Überlauf verkleinern** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für seine Box wird. 

{{% /alert %}}

## **Text umbrechen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umbrochen wird, wenn der Text die Grenze der Form (nur Breite) überschreitet, müssen Sie den Parameter **Text in der Form umbrechen** verwenden. Um diese Einstellung zu spezifizieren, müssen Sie die [WrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrameFormat) Klasse) auf `true` setzen.

Dieser Java-Code zeigt Ihnen, wie Sie die Wrap Text-Einstellung in einer PowerPoint-Präsentation verwenden:

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

Wenn Sie die `WrapText`-Eigenschaft für eine Form auf `False` setzen, wenn der Text innerhalb der Form länger als die Breite der Form wird, wird der Text über die Grenzen der Form hinaus in einer einzigen Zeile verlängert. 

{{% /alert %}}