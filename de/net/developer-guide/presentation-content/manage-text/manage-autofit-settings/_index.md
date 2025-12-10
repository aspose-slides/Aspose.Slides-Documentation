---
title: Präsentationen mit AutoFit in .NET verbessern
linktitle: AutoFit-Einstellungen
type: docs
weight: 30
url: /de/net/manage-autofit-settings/
keywords:
- Textfeld
- AutoFit
- kein AutoFit
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße ändern
- PowerPoint
- Präsentation
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie AutoFit-Einstellungen in Aspose.Slides für .NET verwalten, um die Textanzeige in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

## **Übersicht**

Standardmäßig verwendet Microsoft PowerPoint, wenn Sie ein Textfeld hinzufügen, die Einstellung **Resize shape to fit text** für das Textfeld – es passt die Größe des Textfelds automatisch an, um sicherzustellen, dass sein Text immer hineinpasst.

![Ein Textfeld in PowerPoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – die Höhe wird erhöht – um mehr Text aufnehmen zu können.
* Wenn der Text im Textfeld kürzer oder kleiner wird, verkleinert PowerPoint das Textfeld automatisch – die Höhe wird reduziert – um überflüssigen Platz zu entfernen.

In PowerPoint sind dies die vier wichtigen Parameter oder Optionen, die das Autofit‑Verhalten für ein Textfeld steuern:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Autofit‑Optionen in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides für .NET bietet ähnliche Optionen – Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) – die es Ihnen ermöglichen, das Autofit‑Verhalten von Textfeldern in Präsentationen zu steuern.

## **Größe einer Form an Text anpassen**

Wenn Sie möchten, dass der Text in einem Feld nach Änderungen stets in dieses Feld passt, müssen Sie die Option **Resize shape to fit text** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `Shape`.

![Formgröße an Text anpassen](alwaysfit-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass Text immer in sein Feld in einer PowerPoint‑Präsentation passt:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Wenn der Text länger oder größer wird, wird das Textfeld automatisch in der Größe angepasst (Höhe erhöht), sodass der gesamte Text hineinpassen kann. Wird der Text kürzer, geschieht das Gegenteil.

## **Do Not Autofit**

Wenn Sie möchten, dass ein Textfeld oder eine Form ihre Abmessungen beibehält, egal welche Änderungen am enthaltenen Text vorgenommen werden, müssen Sie die Option **Do not Autofit** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `None`.

!["Do not Autofit" Einstellung in PowerPoint](donotautofit-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass ein Textfeld in einer PowerPoint‑Präsentation stets seine Abmessungen beibehält:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Wenn der Text zu lang für sein Feld wird, läuft er heraus.

## **Shrink Text on Overflow**

Wenn der Text zu lang für sein Feld wird, können Sie über die Option **Shrink text on overflow** festlegen, dass die Größe und der Abstand des Textes reduziert werden, damit er in das Feld passt. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `Normal`.

!["Shrink text on overflow" Einstellung in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass Text bei Überlauf in einer PowerPoint‑Präsentation verkleinert werden muss:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}
Wenn die Option **Shrink text on overflow** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird.
{{% /alert %}}

## **Wrap Text**

Wenn Sie möchten, dass der Text in einer Form umgebrochen wird, sobald er über die Formgrenze (nur Breite) hinausgeht, müssen Sie den Parameter **Wrap text in shape** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft `WrapText` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `NullableBool.True`.

Dieser C#‑Code zeigt, wie Sie die Einstellung Wrap Text in einer PowerPoint‑Präsentation verwenden:
```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}} 
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `NullableBool.False` setzen, wird der Text, sobald er länger als die Breite der Form wird, über die Formgrenzen hinweg in einer einzigen Zeile fortgesetzt.
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textfelds AutoFit?**

Ja. Innenabstände (Padding) reduzieren den nutzbaren Textbereich, sodass AutoFit früher greift – die Schrift wird früher verkleinert oder die Form früher geändert. Prüfen und passen Sie die Ränder an, bevor Sie AutoFit optimieren.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt die Schriftgröße und den Abstand um sie herum an. Das Entfernen unnötiger Umbrüche reduziert häufig, wie aggressiv AutoFit den Text verkleinern muss.

**Beeinflusst das Ändern der Designschriftart oder das Auslösen einer Schriftart‑Substitution die AutoFit‑Ergebnisse?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyphenmaßen ändert Textbreite/-höhe, was die endgültige Schriftgröße und Zeilenumbrüche ändern kann. Nach jeder Schriftartänderung oder Substitution sollten die Folien erneut überprüft werden.