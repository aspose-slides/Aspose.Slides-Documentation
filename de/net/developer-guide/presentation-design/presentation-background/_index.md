---
title: Verwalten von Präsentationshintergründen in C#
linktitle: Folienhintergrund
type: docs
weight: 20
url: /de/net/presentation-background/
keywords:
- Präsentationshintergrund
- Folienhintergrund
- Einfarbige Farbe
- Verlaufsfarbe
- Bildhintergrund
- Hintergrundtransparenz
- Hintergrundeigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für .NET festlegen, samt Code‑Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Übersicht**

Einfarbige Farben, Verläufe und Bilder werden häufig als Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Hintergrundfarbe für eine bestimmte Folie in einer Präsentation – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung gilt nur für die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) des Folienhintergrunds auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/)‑Eigenschaft von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie für eine normale Folie eine blaue einfarbige Hintergrundfarbe festlegen:
```cs
// Erstelle eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Setze die Hintergrundfarbe der Folie auf Blau.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Speichere die Präsentation auf dem Datenträger.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **Einfarbigen Hintergrund für die Masterfolie festlegen**

Aspose.Slides ermöglicht das Festlegen einer einfarbigen Hintergrundfarbe für die Masterfolie in einer Präsentation. Die Masterfolie dient als Vorlage, die die Formatierung aller Folien steuert. Wenn Sie also eine einfarbige Hintergrundfarbe für die Masterfolie festlegen, gilt sie für jede Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Masterfolie (über `masters`) auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) des Masterfolienhintergrunds auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/), um die einfarbige Hintergrundfarbe anzugeben.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie für die Masterfolie eine einfarbige Hintergrundfarbe (Waldgrün) festlegen:
```cs
// Erstelle eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Setze die Hintergrundfarbe der Masterfolie auf Waldgrün.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Speichere die Präsentation auf dem Datenträger.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Verlaufs‑Hintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen schrittweisen Farbwechsel entsteht. Als Folienhintergrund können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht das Festlegen eines Verlaufs als Folienhintergrund.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) des Folienhintergrunds auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/)-Eigenschaft von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), um Ihre gewünschten Verlaufeinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie für eine Folie einen Verlauf als Hintergrundfarbe festlegen:
```cs
// Erstelle eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Wende einen Verlaufseffekt auf den Hintergrund an.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Speichere die Präsentation auf dem Datenträger.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlauf‑Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) des Folienhintergrunds auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/)-Eigenschaft von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/), um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie Sie ein Bild als Hintergrund für eine Folie festlegen:
```c#
// Erstelle eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Setze die Eigenschaften des Hintergrundbildes.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Lade das Bild.
    IImage image = Images.FromFile("Tulips.jpg");
    // Füge das Bild zur Bildsammlung der Präsentation hinzu.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Speichere die Präsentation auf dem Datenträger.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


Das folgende Code‑Beispiel zeigt, wie Sie den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzen und die Kachel‑Eigenschaften ändern:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Setze das Bild, das für die Hintergrundfüllung verwendet wird.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Setze den Bildfüllungsmodus auf Kachel und passe die Kacheleigenschaften an.
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


{{% alert color="primary" %}}
Mehr lesen: [**Kachelbild als Textur**](/slides/de/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz eines Folienhintergrundbildes anpassen, damit der Inhalt der Folie besser hervorsticht. Der folgende C#‑Code zeigt, wie Sie die Transparenz für ein Folienhintergrundbild ändern:
```cs
var transparencyValue = 30; // Zum Beispiel.

// Get the collection of picture transform operations.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **Wert des Folienhintergrunds abrufen**

Aspose.Slides stellt das Interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) zum Abrufen der effektiven Hintergrundwerte einer Folie bereit. Dieses Interface gibt das effektive [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) frei.

Über die `background`‑Eigenschaft der Klasse [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende C#‑Beispiel zeigt, wie Sie den effektiven Hintergrundwert einer Folie abrufen:
```cs
// Erstelle eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Rufe den effektiven Hintergrund ab, wobei Master, Layout und Theme berücksichtigt werden.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Theme-/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird wieder vom entsprechenden [Layout](/slides/de/net/slide-layout/)/[Master](/slides/de/net/slide-master/)-Folie (d. h. dem [Theme‑Hintergrund](/slides/de/net/presentation-theme/)) geerbt.

**Was passiert mit dem Hintergrund, wenn ich später das Theme der Präsentation ändere?**

Hat eine Folie ihre eigene Füllung, bleibt diese unverändert. Wird der Hintergrund vom [Layout](/slides/de/net/slide-layout/)/[Master](/slides/de/net/slide-master/) geerbt, wird er an das [neue Theme](/slides/de/net/presentation-theme/) angepasst.