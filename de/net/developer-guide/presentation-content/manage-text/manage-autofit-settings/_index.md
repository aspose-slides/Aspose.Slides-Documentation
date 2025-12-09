---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in .NET
linktitle: Autofit-Einstellungen
type: docs
weight: 30
url: /de/net/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- Kein Autofit
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße anpassen
- PowerPoint
- Präsentation
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie die AutoFit‑Einstellungen in Aspose.Slides für .NET verwalten, um die Textdarstellung in Ihren PowerPoint‑ und OpenDocument‑Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

## **Übersicht**

Standardmäßig verwendet Microsoft PowerPoint für das Textfeld die Einstellung **Größe der Form an Text anpassen** – es passt das Textfeld automatisch an, damit der Text immer hineinpasst.

![Ein Textfeld in PowerPoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – indem es die Höhe erhöht – damit mehr Text hineinpassen kann.
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint das Textfeld automatisch – indem es die Höhe verringert – um überflüssigen Raum zu entfernen.

In PowerPoint gibt es vier wichtige Parameter bzw. Optionen, die das Autofit‑Verhalten eines Textfelds steuern:

* **Kein AutoFit**
* **Text bei Überlauf verkleinern**
* **Größe der Form an Text anpassen**
* **Text in Form umbrechen**

![AutoFit-Optionen in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides für .NET bietet ähnliche Optionen – Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) – mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können.

## **Größe der Form an Text anpassen**

Wenn der Text in einem Feld stets in dieses Feld passen soll, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Größe der Form an Text anpassen** verwenden. Um diese Einstellung festzulegen, setzen Sie die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `Shape`.

![Größe der Form an Text anpassen](alwaysfit-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass Text immer in sein Feld passen muss, in einer PowerPoint‑Präsentation:
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


Wird der Text länger oder größer, wird das Textfeld automatisch vergrößert (Höhe erhöht), damit der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil.

## **Kein AutoFit**

Wenn ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehalten soll, müssen Sie die Option **Kein AutoFit** verwenden. Setzen Sie dazu die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `None`.

!["Kein AutoFit"-Einstellung in PowerPoint](donotautofit-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass ein Textfeld seine Abmessungen in einer PowerPoint‑Präsentation stets beibehält:
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


Wird der Text zu lang für das Feld, läuft er über den Rand hinaus.

## **Text bei Überlauf verkleinern**

Wenn der Text zu lang für das Feld wird, können Sie mit der Option **Text bei Überlauf verkleinern** festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Setzen Sie dazu die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `Normal`.

!["Text bei Überlauf verkleinern"-Einstellung in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass Text bei Überlauf in einer PowerPoint‑Präsentation verkleinert wird:
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
Wenn die **Text bei Überlauf verkleinern**‑Option verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für das Feld wird.
{{% /alert %}}

## **Text umbrechen**

Wenn der Text in einer Form umbrochen werden soll, sobald er die Breite der Form überschreitet, verwenden Sie den Parameter **Text in Form umbrechen**. Setzen Sie dazu die Eigenschaft `WrapText` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `NullableBool.True`.

Dieser C#‑Code zeigt, wie Sie die Einstellung „Text umbrechen“ in einer PowerPoint‑Präsentation verwenden:
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


{{% alert title="Hinweis" color="warning" %}}
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `NullableBool.False` setzen, erstreckt sich der Text bei Überschreitung der Formbreite in einer einzigen Zeile über die Formgrenzen hinaus.
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textframes AutoFit?**

Ja. Innenabstände (Padding) verringern den nutzbaren Textbereich, sodass AutoFit früher greift – die Schrift wird verkleinert oder die Form früher angepasst. Prüfen und passen Sie die Ränder an, bevor Sie AutoFit Feinjustieren.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand um diese herum an. Das Entfernen unnötiger Umbrüche reduziert häufig, wie aggressiv AutoFit den Text verkleinern muss.

**Beeinflusst das Ändern der Design‑Schriftart oder das Auslösen einer Schriftart‑Substitution die AutoFit‑Ergebnisse?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyph‑Metriken ändert Breite/Höhe des Textes, was die endgültige Schriftgröße und Zeilenumbrüche ändern kann. Nach jeder Schriftart‑Änderung oder -Substitution sollten Sie die Folien erneut prüfen.