---
title: Verwalten von Präsentationshintergründen in .NET
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/net/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- einfarbige Farbe
- Farbverlauf
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für .NET festlegen, inklusive Code-Tipps zur Optimierung Ihrer Präsentationen."
---
## **Einführung**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt gleichzeitig für mehrere Folien) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht es, für eine bestimmte Folie in einer Präsentation eine einfarbige Hintergrundfarbe festzulegen – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) des Folienhintergrunds auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/solidfillcolor/)-Eigenschaft von [FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie für eine normale Folie eine blaue einfarbige Hintergrundfarbe festlegen:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellen Sie eine Instanz der Presentation‑Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Setzen Sie die Hintergrundfarbe der Folie auf Blau.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Einfarbigen Hintergrund für eine Masterfolie festlegen**

Aspose.Slides ermöglicht es, für die Masterfolie einer Präsentation eine einfarbige Hintergrundfarbe festzulegen. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert. Wenn Sie also eine einfarbige Hintergrundfarbe für die Masterfolie wählen, wird sie auf jeder Folie angewendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/net/aspose.slides/backgroundtype/) der Masterfolie (über `masters`) auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) des Masterfolienhintergrunds auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/solidfillcolor/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie für eine Masterfolie eine einfarbige Hintergrundfarbe (Waldgrün) festlegen:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellen Sie eine Instanz der Presentation‑Klasse.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Setzen Sie die Hintergrundfarbe der Masterfolie auf Waldgrün.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Verlaufshintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch eine allmähliche Farbänderung entsteht. Als Folienhintergrund verwendet, können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht es, einen Farbverlauf als Hintergrund für Folien festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) des Folienhintergrunds auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/gradientformat/)-Eigenschaft von [FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/), um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie für eine Folie einen Farbverlauf als Hintergrund festlegen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellen Sie eine Instanz der Presentation‑Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Wenden Sie einen Farbverlaufseffekt auf den Hintergrund an.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```

## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und verlaufenden Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/de/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/de/net/aspose.slides/filltype/) des Folienhintergrunds auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/picturefillformat/)-Eigenschaft von [FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellen Sie eine Instanz der Presentation‑Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Setzen Sie die Hintergrundbildeigenschaften.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Bild laden.
    IImage image = Images.FromFile("Tulips.jpg");
    // Bild zur Bildsammlung der Präsentation hinzufügen.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Präsentation auf dem Datenträger speichern.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```

Das folgende Codebeispiel zeigt, wie Sie den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzen und die Kacheleigenschaften anpassen:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Setzen Sie das Bild, das für die Hintergrundfüllung verwendet wird.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Setzen Sie den Bildfüllmodus auf Kachel und passen Sie die Kacheleigenschaften an.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}}
Weitere Informationen: [**Kachelbild als Textur**](/slides/de/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, um den Inhalt der Folie hervorzuheben. Der folgende C#‑Code zeigt, wie Sie die Transparenz eines Folienhintergrundbildes ändern können:

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Zum Beispiel.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Holen Sie die Sammlung der Bildtransformationsoperationen.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Suchen Sie einen vorhandenen Transparenzeffekt mit festem Prozentsatz.
    var transparencyOperation = null as IAlphaModulateFixed;
    foreach (var operation in imageTransform)
    {
        if (operation is IAlphaModulateFixed alphaModulateFixed)
        {
            transparencyOperation = alphaModulateFixed;
            break;
        }
    }

    // Setzen Sie den neuen Transparenzwert.
    if (transparencyOperation == null)
    {
        imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else
    {
        transparencyOperation.Amount = (100 - transparencyValue);
    }

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt die Schnittstelle [IBackgroundEffectiveData](https://reference.aspose.com/slides/de/net/aspose.slides/ibackgroundeffectivedata/) bereit, um die effektiven Hintergrundwerte einer Folie abzurufen. Diese Schnittstelle stellt das effektive [FillFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibackgroundeffectivedata/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/de/net/aspose.slides/ibackgroundeffectivedata/effectformat/) bereit.

Über die `background`‑Eigenschaft der Klasse [BaseSlide](https://reference.aspose.com/slides/de/net/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende C#‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```cs
using Aspose.Slides;

// Erstellen Sie eine Instanz der Presentation‑Klasse.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Rufen Sie den effektiven Hintergrund ab, wobei Master, Layout und Theme berücksichtigt werden.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme‑/Layout‑Hintergrund wiederherstellen?

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [Layout](/slides/de/net/slide-layout/)/[Master](/slides/de/net/slide-master/)‑Folie (also dem [Theme‑Hintergrund](/slides/de/net/presentation-theme/)) geerbt.

### Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?

Wenn eine Folie eine eigene Füllung hat, bleibt diese unverändert. Wenn der Hintergrund vom [Layout](/slides/de/net/slide-layout/)/[Master](/slides/de/net/slide-master/)‑Folie ererbt wird, wird er aktualisiert, um dem [neuen Theme](/slides/de/net/presentation-theme/) zu entsprechen.