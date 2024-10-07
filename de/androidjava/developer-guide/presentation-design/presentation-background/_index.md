---
title: Präsentationshintergrund
type: docs
weight: 20
url: /androidjava/presentation-background/
keywords: "PowerPoint-Hintergrund, Hintergrund in Java festlegen"
description: "Hintergrund in der PowerPoint-Präsentation in Java festlegen"
---

Einfache Farben, Farbverläufe und Bilder werden oft als Hintergrundbilder für Folien verwendet. Sie können den Hintergrund entweder für eine **normale Folie** (einzelne Folie) oder **Masterfolie** (mehrere Folien gleichzeitig) festlegen.

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Feste Farbe als Hintergrund für normale Folie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine feste Farbe als Hintergrund für eine bestimmte Folie in einer Präsentation festzulegen (auch wenn diese Präsentation eine Masterfolie enthält). Die Hintergrundänderung betrifft nur die ausgewählte Folie.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) Enumerationswert für die Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) Enumerationswert für den Folienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) bereitgestellt wird, um eine feste Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine feste Farbe (blau) als Hintergrund für eine normale Folie festlegen:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Setzt die Hintergrundfarbe für die erste ISlide auf Blau
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("ContentBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Feste Farbe als Hintergrund für Masterfolie festlegen**

Aspose.Slides ermöglicht es Ihnen, eine feste Farbe als Hintergrund für die Masterfolie in einer Präsentation festzulegen. Die Masterfolie fungiert als Vorlage, die Formatierungseinstellungen für alle Folien enthält und steuert. Wenn Sie also eine feste Farbe als Hintergrund für die Masterfolie auswählen, wird dieser neue Hintergrund für alle Folien verwendet.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) Enumerationswert für die Masterfolie (`Masters`) auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) Enumerationswert für den Masterfolienhintergrund auf `Solid`.
4. Verwenden Sie die [SolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) bereitgestellt wird, um eine feste Farbe für den Hintergrund anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine feste Farbe (fichtengrün) als Hintergrund für eine Masterfolie in einer Präsentation festlegen:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Setzt die Hintergrundfarbe für die Master ISlide auf Fichten Grün
    pres.getMasters().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Solid);
    pres.getMasters().get_Item(0).getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("MasterBG.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Farbverlauf als Hintergrund für Folie festlegen**

Ein Farbverlauf ist ein grafischer Effekt, der auf einer allmählichen Farbänderung basiert. Farbverläufe, die als Hintergründe für Folien verwendet werden, verleihen Präsentationen einen künstlerischen und professionellen Look. Aspose.Slides ermöglicht es Ihnen, eine Farbverlauffarbe als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) Enumerationswert für die Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) Enumerationswert für den Masterfolienhintergrund auf `Gradient`.
4. Verwenden Sie die [GradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) bereitgestellt wird, um Ihre bevorzugten Gradienteneinstellungen anzugeben.
5. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie eine Farbverlauffarbe als Hintergrund für eine Folie festlegen:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("MasterBG.pptx");
try {
    // Wendet den Farbverlaufseffekt auf den Hintergrund an
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Gradient);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getGradientFormat().setTileFlip(TileFlip.FlipBoth);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("ContentBG_Grad.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Bild als Hintergrund für Folie festlegen**

Neben festen Farben und Farbverläufen ermöglicht es Aspose.Slides Ihnen, Bilder als Hintergrund für Folien in Präsentationen festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) Klasse.
2. Setzen Sie den [BackgroundType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/backgroundtype/) Enumerationswert für die Folie auf `OwnBackground`.
3. Setzen Sie den [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) Enumerationswert für den Masterfolienhintergrund auf `Picture`.
4. Laden Sie das Bild, das Sie als Folienhintergrund verwenden möchten.
5. Fügen Sie das Bild der Bildsammlung der Präsentation hinzu.
6. Verwenden Sie die [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) Eigenschaft, die von [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) bereitgestellt wird, um das Bild als Hintergrund festzulegen.
7. Speichern Sie die modifizierte Präsentation.

Dieser Java-Code zeigt Ihnen, wie Sie ein Bild als Hintergrund für eine Folie festlegen:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Setzt Bedingungen für das Hintergrundbild
    pres.getSlides().get_Item(0).getBackground().setType(BackgroundType.OwnBackground);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().setFillType(FillType.Picture);
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat()
            .setPictureFillMode(PictureFillMode.Stretch);
    
    // Lädt das Bild
    IPPImage imgx;
    IImage image = Images.fromFile("Desert.jpg");
    try {
        imgx = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Fügt das Bild der Bildsammlung der Präsentation hinzu
    pres.getSlides().get_Item(0).getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(imgx);
    
    // Schreibt die Präsentation auf die Festplatte
    pres.save("ContentBG_Img.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Transparenz des Hintergrundbilds ändern**

Sie möchten möglicherweise die Transparenz des Hintergrundbilds einer Folie anpassen, um die Inhalte der Folie hervorzuheben. Dieser Java-Code zeigt Ihnen, wie Sie die Transparenz für ein Folienhintergrundbild ändern:

```java
int transparencyValue = 30; // zum Beispiel

// Erhält eine Sammlung von Bildtransformationsoperationen
IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Findet einen Transparenzeffekt mit festem Prozentsatz.
AlphaModulateFixed transparencyOperation = null;
for (IImageTransformOperation operation : imageTransform)
{
    if (operation instanceof AlphaModulateFixed)
    {
        transparencyOperation = (AlphaModulateFixed)operation;
        break;
    }
}

// Setzt den neuen Transparenzwert.
if (transparencyOperation == null)
{
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Wert des Folienhintergrunds abrufen**

Aspose.Slides bietet die [IBackgroundEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/) Schnittstelle, um die effektiven Werte der Folienhintergründe abzurufen. Diese Schnittstelle enthält Informationen zu den effektiven [FillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) und effektiven [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

Mit der [Background](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getBackground--) Eigenschaft der [BaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/) Klasse können Sie den effektiven Wert für einen Folienhintergrund abrufen.

Dieser Java-Code zeigt Ihnen, wie Sie den effektiven Hintergrundwert einer Folie abrufen:

```java
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("SamplePresentation.pptx");
try {
    IBackgroundEffectiveData effBackground = pres.getSlides().get_Item(0).getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Füllfarbe: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fülltyp: " + effBackground.getFillFormat().getFillType());
} finally {
    if (pres != null) pres.dispose();
}
```