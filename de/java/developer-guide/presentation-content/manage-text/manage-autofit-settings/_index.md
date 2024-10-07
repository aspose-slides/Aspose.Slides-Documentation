---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /java/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint-Präsentation, Java, Aspose.Slides für Java"
description: "Stellen Sie die Autofit-Einstellungen für Textboxen in PowerPoint in Java ein"
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen einer Textbox die Einstellung **Form an Text anpassen** für die Textbox – sie passt die Textbox automatisch an, um sicherzustellen, dass der Text immer darin passt.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text in der Textbox länger oder größer wird, vergrößert PowerPoint automatisch die Textbox – erhöht ihre Höhe –, um mehr Text aufzunehmen.
* Wenn der Text in der Textbox kürzer oder kleiner wird, reduziert PowerPoint automatisch die Textbox – verringert ihre Höhe –, um überflüssigen Platz zu beseitigen.

In PowerPoint sind dies die 4 wichtigen Parameter oder Optionen, die das Autofit-Verhalten für eine Textbox steuern:

* **Nicht anpassen**
* **Text bei Überlauf verkleinern**
* **Form an Text anpassen**
* **Text in der Form umbrechen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für Java bietet ähnliche Optionen – einige Eigenschaften der [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) Klasse –, die es Ihnen ermöglichen, das Autofit-Verhalten für Textboxen in Präsentationen zu steuern.

## **Form an Text anpassen**

Wenn Sie möchten, dass der Text in einer Box immer in diese Box passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Form an Text anpassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) Klasse) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser Java-Code zeigt Ihnen, wie Sie angeben, dass ein Text immer in seine Box in einer PowerPoint-Präsentation passen muss:

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

Wenn der Text länger oder größer wird, wird die Textbox automatisch in der Höhe angepasst, um sicherzustellen, dass der gesamte Text darin passt. Wenn der Text kürzer wird, passiert das Gegenteil.

## **Nicht anpassen**

Wenn Sie möchten, dass eine Textbox oder Form ihre Abmessungen unabhängig von den Änderungen, die am enthaltenen Text vorgenommen werden, beibehält, müssen Sie die Option **Nicht anpassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) Klasse) auf `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser Java-Code zeigt Ihnen, wie Sie angeben, dass eine Textbox immer ihre Abmessungen in einer PowerPoint-Präsentation beibehalten muss:

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

Wenn der Text zu lang für seine Box wird, tritt ein Überlauf auf.

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für seine Box wird, können Sie über die Option **Text bei Überlauf verkleinern** angeben, dass die Größe und der Abstand des Textes verringert werden müssen, um in die Box zu passen. Um diese Einstellung festzulegen, setzen Sie die [AutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getAutofitType--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) Klasse) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser Java-Code zeigt Ihnen, wie Sie angeben, dass der Text bei Überlauf in einer PowerPoint-Präsentation verkleinert werden muss:

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

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umbrochen wird, wenn der Text über die Ränder der Form hinausgeht (nur Breite), müssen Sie den Parameter **Text in der Form umbrechen** verwenden. Um diese Einstellung festzulegen, müssen Sie die [WrapText](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat#getWrapText--) Eigenschaft (aus der [TextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrameFormat) Klasse) auf `true` setzen.

Dieser Java-Code zeigt Ihnen, wie Sie die Wrap-Text-Einstellung in einer PowerPoint-Präsentation verwenden:

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

Wenn Sie die `WrapText`-Eigenschaft für eine Form auf `False` setzen, wird der Text, der in der Form enthalten ist, wenn er länger als die Breite der Form wird, über die Ränder der Form hinaus verlängert und in einer einzigen Zeile dargestellt.

{{% /alert %}}