---
title: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /de/net/manage-autofit-settings/
keywords: "Textbox, Autofit, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Legen Sie die Autofit-Einstellungen für Textfelder in PowerPoint in C# oder .NET fest"
---

Standardmäßig verwendet Microsoft PowerPoint beim Hinzufügen eines Textfelds die Einstellung **Form um Text anpassen** für das Textfeld – es passt das Textfeld automatisch an, um sicherzustellen, dass der Text immer hineinpasst.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – erhöht dessen Höhe –, damit es mehr Text aufnehmen kann. 
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint das Textfeld automatisch – verringert dessen Höhe –, um überflüssigen Platz freizumachen. 

In PowerPoint sind dies die 4 wichtigen Parameter oder Optionen, die das Autofit-Verhalten für ein Textfeld steuern:

* **Nicht anpassen**
* **Text bei Überlauf verkleinern**
* **Form um Text anpassen**
* **Text in der Form umbrechen.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides für .NET bietet ähnliche Optionen – einige Eigenschaften der [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) Klasse –, die es Ihnen ermöglichen, das Autofit-Verhalten für Textfelder in Präsentationen zu steuern. 

## **Form um Text anpassen**

Wenn Sie möchten, dass der Text in einem Feld immer in dieses Feld passt, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Form um Text anpassen** verwenden. Um diese Einstellung zu spezifizieren, setzen Sie die [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) Eigenschaft (von der [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) Klasse) auf `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Dieser C#-Code zeigt Ihnen, wie Sie angeben, dass ein Text immer in sein Feld in einer PowerPoint-Präsentation passen muss:

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Wenn der Text länger oder größer wird, wird das Textfeld automatisch angepasst (Höhenvergrößerung), um sicherzustellen, dass der gesamte Text hineinpasst. Wenn der Text kürzer wird, geschieht das Gegenteil.

## **Nicht anpassen**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Dimensionen unabhängig von den Änderungen am enthaltenen Text beibehält, müssen Sie die Option **Nicht anpassen** verwenden. Um diese Einstellung zu spezifizieren, setzen Sie die [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) Eigenschaft (von der [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) Klasse) auf `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Dieser C#-Code zeigt Ihnen, wie Sie angeben können, dass ein Textfeld immer seine Dimensionen in einer PowerPoint-Präsentation beibehalten muss:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Wenn der Text zu lang für sein Feld wird, läuft er über. 

## **Text bei Überlauf verkleinern**

Wenn ein Text zu lang für sein Feld wird, können Sie mit der Option **Text bei Überlauf verkleinern** festlegen, dass die Größe und der Abstand des Textes reduziert werden, um ihn in sein Feld passen zu lassen. Um diese Einstellung zu spezifizieren, setzen Sie die [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) Eigenschaft (von der [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) Klasse) auf `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser C#-Code zeigt Ihnen, wie Sie angeben, dass ein Text bei Überlauf in einer PowerPoint-Präsentation verkleinert werden muss:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}

Wenn die Option **Text bei Überlauf verkleinern** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird. 

{{% /alert %}}

## **Text umschließen**

Wenn Sie möchten, dass der Text in einer Form innerhalb dieser Form umschließt, wenn der Text über die Ränder der Form hinausgeht (nur Breite), müssen Sie den Parameter **Text in der Form umschließen** verwenden. Um diese Einstellung zu spezifizieren, müssen Sie die [WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) Eigenschaft (von der [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) Klasse) auf `true` setzen.

Dieser C#-Code zeigt Ihnen, wie Sie die Wrap-Text-Einstellung in einer PowerPoint-Präsentation verwenden:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Hinweis" color="warning" %}}

Wenn Sie die `WrapText`-Eigenschaft für eine Form auf `False` setzen, wird der Text innerhalb der Form, wenn er länger als die Breite der Form wird, über die Ränder der Form hinaus in einer einzigen Zeile angezeigt. 

{{% /alert %}}