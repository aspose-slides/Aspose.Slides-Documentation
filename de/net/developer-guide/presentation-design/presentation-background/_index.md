---
title: Präsentationshintergrund
type: docs
weight: 20
url: /net/presentation-background/
keywords:
- PowerPoint-Hintergrund
- Hintergrund festlegen
- C#
- Csharp
- Aspose.Slides für .NET
description: "Hintergrund in PowerPoint-Präsentation in C# oder .NET festlegen"
---

Einfache Farben, Farbverläufe und Bilder werden häufig als Hintergrundbilder für Folien verwendet. Sie können den Hintergrund entweder für eine **normale Folie** (einzelne Folie) oder **Masterfolie** (mehrere Folien gleichzeitig) festlegen.

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Einfache Farbe als Hintergrund für normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einheitliche Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen (auch wenn diese Präsentation eine Masterfolie enthält). Die Hintergrundänderung hat nur Auswirkungen auf die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) Enum für den Folienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) bereitgestellt wird, um eine einheitliche Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine einheitliche Farbe (blau) als Hintergrund für eine normale Folie festlegen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
using (Presentation pres = new Presentation())
{

    // Setzt die Hintergrundfarbe für die erste ISlide auf Blau
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // Schreibt die Präsentation auf die Festplatte
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **Einfache Farbe als Hintergrund für Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine einheitliche Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die Formatierungsoptionen für alle Folien enthält und steuert. Daher wird, wenn Sie eine einheitliche Farbe als Hintergrund für die Masterfolie wählen, dieser neue Hintergrund für alle Folien verwendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) Enum für die Masterfolie (`Masters`) auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) Enum für den Hintergrund der Masterfolie auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) bereitgestellt wird, um eine einheitliche Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine einheitliche Farbe (forstgrün) als Hintergrund für eine Masterfolie in einer Präsentation festlegen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
using (Presentation pres = new Presentation())
{

    // Setzt die Hintergrundfarbe für die Master ISlide auf Forstgrün
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Schreibt die Präsentation auf die Festplatte
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);

}
```

## **Farbverlauf als Hintergrund für Folie festlegen**

Ein Farbverlauf ist ein grafischer Effekt, der auf einem allmählichen Farbwechsel basiert. Farbverläufe, die als Hintergründe für Folien verwendet werden, verleihen Präsentationen ein künstlerisches und professionelles Aussehen. Aspose.Slides ermöglicht es Ihnen, eine Farbverlaufsfarbe als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) Enum für den Hintergrund der Masterfolie auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) bereitgestellt wird, um Ihre bevorzugten Verlaufseinstellungen anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Farbverlaufsfarbe als Hintergrund für eine Folie festlegen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // Wendet den Verlaufseffekt auf den Hintergrund an
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Schreibt die Präsentation auf die Festplatte
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **Bild als Hintergrund für Folie festlegen**

Neben einheitlichen Farben und Farbverläufen ermöglicht es Aspose.Slides auch, Bilder als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Setzen Sie das [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) Enum für die Folie auf `OwnBackground`.
3. Setzen Sie das [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) Enum für den Hintergrund der Masterfolie auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild zur Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) bereitgestellt wird, um das Bild als Hintergrund festzulegen.
7. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{
    // Setzt Bedingungen für das Hintergrundbild
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Lädt ein Bild und fügt es der Bildsammlung der Präsentation hinzu
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Schreibt die Präsentation auf die Festplatte
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}
```

### **Transparenz des Hintergrundbildes ändern**

Sie möchten möglicherweise die Transparenz des Hintergrundbildes einer Folie anpassen, um die Inhalte der Folie hervorzuheben. Dieser C#-Code zeigt Ihnen, wie Sie die Transparenz für ein Folienhintergrundbild ändern:

```c#
var transparencyValue = 30; // Zum Beispiel

// erhält eine Sammlung von Bildtransformationsoperationen
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Findet einen Transparenzeffekt mit festem Prozentsatz.
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Setzt den neuen Transparenzwert.
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

Aspose.Slides bietet das [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) Interface, um die effektiven Werte von Folienhintergründen abzurufen. Dieses Interface enthält Informationen zu dem effektiven [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat) und dem effektiven [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

Mit der [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/) Eigenschaft aus der [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/) Klasse können Sie den effektiven Wert für den Folienhintergrund abrufen.

Dieser C#-Code zeigt Ihnen, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("Füllfarbe: " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("Fülltyp: " + effBackground.FillFormat.FillType);
```