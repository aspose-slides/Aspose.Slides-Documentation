---
title: Präsentationshintergründe in .NET verwalten
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
- Hintergrund-Eigenschaften
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie dynamische Hintergründe in PowerPoint- und OpenDocument-Dateien mit Aspose.Slides für .NET festlegen, inklusive Code‑Tipps zur Verbesserung Ihrer Präsentationen."
---

## **Überblick**

Einfarbige Farben, Verläufe und Bilder werden häufig für Folienhintergründe verwendet. Sie können den Hintergrund für eine **normale Folie** (eine einzelne Folie) oder eine **Masterfolie** (gilt für mehrere Folien gleichzeitig) festlegen.

![PowerPoint-Hintergrund](powerpoint-background.png)

## **Einfarbigen Hintergrund für eine normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen – selbst wenn die Präsentation eine Masterfolie verwendet. Die Änderung wirkt nur auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) auf `Solid` .
4. Verwenden Sie die Eigenschaft [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) , um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie man eine blaue einfarbige Farbe als Hintergrund für eine normale Folie festlegt:
```cs
// Erstellen Sie eine Instanz der Presentation-Klasse.
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


## **Einfarbigen Hintergrund für die Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einfarbige Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die die Formatierung für alle Folien steuert, sodass die Wahl einer einfarbigen Farbe für den Hintergrund der Masterfolie auf jeder Folie angewendet wird.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Masterfolie (über `masters`) auf `OwnBackground` .
3. Setzen Sie den Masterfolien‑Hintergrund [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) auf `Solid` .
4. Verwenden Sie [SolidFillColor], um die einfarbige Hintergrundfarbe festzulegen.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie man eine einfarbige (waldgrüne) Farbe als Hintergrund für eine Masterfolie festlegt:
```cs
// Erstellen Sie eine Instanz der Presentation-Klasse.
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


## **Verlaufs‑Hintergrund für eine Folie festlegen**

Ein Verlauf ist ein grafischer Effekt, der durch einen allmählichen Farbwechsel entsteht. Als Folienhintergrund verwendet, können Verläufe Präsentationen künstlerischer und professioneller wirken lassen. Aspose.Slides ermöglicht es Ihnen, eine Farbverlauf als Hintergrund für Folien festzulegen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) auf `Gradient` .
4. Verwenden Sie die Eigenschaft [GradientFormat] von [FillFormat], um Ihre gewünschten Verlaufseinstellungen zu konfigurieren.
5. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie man eine Verlauffarbe als Hintergrund für eine Folie festlegt:
```cs
// Erstellen Sie eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Wenden Sie einen Verlaufseffekt auf den Hintergrund an.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Ein Bild als Folienhintergrund festlegen**

Zusätzlich zu einfarbigen und Verlaufs‑Füllungen ermöglicht Aspose.Slides die Verwendung von Bildern als Folienhintergründe.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) der Folie auf `OwnBackground` .
3. Setzen Sie den Folienhintergrund [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) auf `Picture` .
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die Eigenschaft [PictureFillFormat] von [FillFormat], um das Bild als Hintergrund zuzuweisen.
7. Speichern Sie die geänderte Präsentation.

Das folgende C#‑Beispiel zeigt, wie man ein Bild als Hintergrund für eine Folie festlegt:
```c#
// Erstellen Sie eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Setzen Sie die Eigenschaften des Hintergrundbilds.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Laden Sie das Bild.
    IImage image = Images.FromFile("Tulips.jpg");
    // Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Speichern Sie die Präsentation auf dem Datenträger.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


Das folgende Codebeispiel zeigt, wie man den Hintergrund‑Fülltyp auf ein gekacheltes Bild setzt und die Kachel‑Eigenschaften ändert:
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


{{% alert color="primary" %}}
Mehr lesen: [**Bild als Textur kacheln**](/slides/de/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Transparenz des Hintergrundbildes ändern**

Möglicherweise möchten Sie die Transparenz des Hintergrundbildes einer Folie anpassen, um den Inhalt der Folie hervorzuheben. Der folgende C#‑Code zeigt, wie Sie die Transparenz eines Folien‑Hintergrundbildes ändern:
```cs
var transparencyValue = 30; // Zum Beispiel.

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
```


## **Den Folienhintergrundwert abrufen**

Aspose.Slides stellt die Schnittstelle [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) zur Verfügung, um die effektiven Hintergrundwerte einer Folie abzurufen. Diese Schnittstelle stellt das effektive [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) und [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) bereit.

Mit der `background`‑Eigenschaft der Klasse [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) können Sie den effektiven Hintergrund einer Folie erhalten.

Das folgende C#‑Beispiel zeigt, wie man den effektiven Hintergrundwert einer Folie abruft:
```cs
// Erstellen Sie eine Instanz der Presentation-Klasse.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Rufen Sie den effektiven Hintergrund ab, wobei Master-, Layout- und Theme-Einstellungen berücksichtigt werden.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **FAQ**

**Kann ich einen benutzerdefinierten Hintergrund zurücksetzen und den Themen-/Layout‑Hintergrund wiederherstellen?**

Ja. Entfernen Sie die benutzerdefinierte Füllung der Folie, und der Hintergrund wird erneut vom entsprechenden [layout](/slides/de/net/slide-layout/)/[master](/slides/de/net/slide-master/)‑Slide (d. h. dem [theme background](/slides/de/net/presentation-theme/)) geerbt.

**Was passiert mit dem Hintergrund, wenn ich das Design der Präsentation später ändere?**

Hat eine Folie ihre eigene Füllung, bleibt sie unverändert. Wird der Hintergrund vom [layout](/slides/de/net/slide-layout/)/[master](/slides/de/net/slide-master/)‑Slide geerbt, wird er aktualisiert, um dem [new theme](/slides/de/net/presentation-theme/) zu entsprechen.