---
title: Verbessern Sie Ihre Präsentationen mit AutoFit in C#
linktitle: Autofit-Einstellungen verwalten
type: docs
weight: 30
url: /de/net/manage-autofit-settings/
keywords:
- Textfeld
- Autofit
- kein Autofit
- Text anpassen
- Text verkleinern
- Text umbrechen
- Formgröße ändern
- PowerPoint
- Präsentation
- C#
- .NET
- Aspose.Slides
description: "Erfahren Sie, wie Sie die AutoFit-Einstellungen in Aspose.Slides für .NET verwalten, um die Textdarstellung in Ihren PowerPoint- und OpenDocument-Präsentationen zu optimieren und die Lesbarkeit des Inhalts zu verbessern."
---

## **Übersicht**

Standardmäßig verwendet Microsoft PowerPoint beim Einfügen eines Textfeldes die Einstellung **Resize shape to fit text** – das Textfeld wird automatisch in der Größe angepasst, sodass der Text immer hineinpasst.

![Ein Textfeld in PowerPoint](textbox-in-powerpoint.png)

* Wenn der Text im Textfeld länger oder größer wird, vergrößert PowerPoint das Textfeld automatisch – die Höhe wird erhöht –, um mehr Text aufnehmen zu können.  
* Wenn der Text im Textfeld kürzer oder kleiner wird, reduziert PowerPoint das Textfeld automatisch – die Höhe wird verringert –, um überschüssigen Raum zu entfernen.

In PowerPoint gibt es vier wichtige Parameter bzw. Optionen, die das Autofit‑Verhalten eines Textfeldes steuern:

* **Do not Autofit**  
* **Shrink text on overflow**  
* **Resize shape to fit text**  
* **Wrap text in shape**

![Autofit‑Optionen in PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides für .NET bietet ähnliche Optionen – Eigenschaften der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) – mit denen Sie das Autofit‑Verhalten von Textfeldern in Präsentationen steuern können.

## **Resize Shape to Fit Text**

Wenn der Text in einem Feld immer in dieses Feld passen soll, nachdem Änderungen am Text vorgenommen wurden, müssen Sie die Option **Resize shape to fit text** verwenden. Legen Sie dafür die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `Shape` fest.

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

Dieser C#‑Code zeigt, wie Sie festlegen, dass der Text in einer PowerPoint‑Präsentation stets in sein Feld passen muss:
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


Wird der Text länger oder größer, wird das Textfeld automatisch vergrößert (Höhe wird erhöht), sodass der gesamte Text hineinpasst. Wird der Text kürzer, geschieht das Gegenteil.

## **Do Not Autofit**

Wenn ein Textfeld oder eine Form ihre Abmessungen unabhängig von Änderungen am enthaltenen Text beibehalten soll, müssen Sie die Option **Do not Autofit** verwenden. Setzen Sie dafür die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `None`.

![„Do not Autofit“-Einstellung in PowerPoint](donotautofit-setting-powerpoint.png)

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


Wird der Text zu lang für sein Feld, läuft er über das Feld hinaus.

## **Shrink Text on Overflow**

Wenn der Text zu lang für sein Feld wird, können Sie mit der Option **Shrink text on overflow** festlegen, dass Größe und Abstand des Textes reduziert werden, damit er in das Feld passt. Setzen Sie dafür die Eigenschaft `AutofitType` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `Normal`.

![„Shrink text on overflow“-Einstellung in PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

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
Wenn die Option **Shrink text on overflow** verwendet wird, wird die Einstellung nur angewendet, wenn der Text zu lang für sein Feld wird.
{{% /alert %}}

## **Wrap Text**

Wenn der Text in einer Form umbrochen werden soll, sobald er die Breite der Form überschreitet, verwenden Sie den Parameter **Wrap text in shape**. Setzen Sie dafür die Eigenschaft `WrapText` der Klasse [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) auf `NullableBool.True`.

Dieser C#‑Code zeigt, wie Sie die Einstellung „Wrap Text“ in einer PowerPoint‑Präsentation verwenden:
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
Wenn Sie die Eigenschaft `WrapText` für eine Form auf `NullableBool.False` setzen, erstreckt sich der Text bei Überschreiten der Formbreite über die Formgrenzen in einer einzelnen Zeile.
{{% /alert %}}

## **FAQ**

**Beeinflussen die internen Ränder des Textrahmens die AutoFit‑Funktion?**

Ja. Innenabstände reduzieren den nutzbaren Textbereich, sodass AutoFit früher greift – die Schrift wird früher verkleinert oder die Form früher angepasst. Prüfen und passen Sie die Ränder an, bevor Sie AutoFit feinjustieren.

**Wie interagiert AutoFit mit manuellen und weichen Zeilenumbrüchen?**

Erzwungene Umbrüche bleiben erhalten, und AutoFit passt Schriftgröße und Abstand um diese herum an. Das Entfernen unnötiger Umbrüche reduziert häufig das Ausmaß, in dem AutoFit den Text verkleinern muss.

**Wirkt sich das Ändern der Design‑Schriftart oder das Auslösen einer Schriftart‑Substitution auf das AutoFit‑Ergebnis aus?**

Ja. Das Ersetzen durch eine Schriftart mit anderen Glyphen‑Metriken ändert Breite/Höhe des Textes, wodurch sich die finale Schriftgröße und der Zeilenumbruch ändern können. Nach jeder Schriftart‑Änderung oder -Substitution sollten Sie die Folien erneut prüfen.