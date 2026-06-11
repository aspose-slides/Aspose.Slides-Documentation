---
title: Konvertera PowerPoint-bilder till PNG på Android
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/androidjava/convert-powerpoint-to-png/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PNG
- presentation till PNG
- bild till PNG
- PPT till PNG
- PPTX till PNG
- spara PPT som PNG
- spara PPTX som PNG
- exportera PPT till PNG
- exportera PPTX till PNG
- Android
- Java
- Aspose.Slides
description: "Konvertera PowerPoint-presentationer till högkvalitativa PNG-bilder snabbt med Aspose.Slides för Android via Java, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur man konverterar PowerPoint-presentationer till PNG‑bilder med Aspose.Slides. Den visar hur man läser presentationsfiler i format som PPT, PPTX och ODP, renderar bilder som bilder och sparar resultaten i PNG‑format.

Artikeln demonstrerar också hur man anpassar de genererade PNG‑bilderna genom att ange skalvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Följ dessa steg:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation)-klassen.  
2. Hämta bildobjektet från [Presentation.getSlides()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--)‑samlingen under [ISlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlide)-gränssnittet.  
3. Använd metoden [ISlide.getImage()](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlide) för att hämta miniatyrbilden för varje bild.  
4. Använd [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat))-metoden för att spara bildens miniatyr till PNG‑format.

Denna Java‑kod visar hur du konverterar en PowerPoint‑presentation till PNG:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konvertera PowerPoint till PNG med anpassad skala**

Om du vill få PNG‑filer med en viss skala kan du ange värdena för `desiredX` och `desiredY`, som bestämmer dimensionerna på den resulterande miniatyrbilden. 

Denna kod i Java demonstrerar den beskrivna operationen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konvertera PowerPoint till PNG med anpassad storlek**

Om du vill få PNG‑filer med en viss storlek kan du ange dina föredragna `width`‑ och `height`‑argument för `ImageSize`. 

Denna kod visar hur du konverterar en PowerPoint till PNG samtidigt som du specificerar bildernas storlek: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Vanliga frågor**

**Hur kan jag exportera endast en specifik form (t.ex. diagram eller bild) istället för hela bilden?**

Aspose.Slides stöder [att generera miniatyrbilder för enskilda former](/slides/sv/androidjava/create-shape-thumbnails/); du kan rendera en form till en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja, men [dela inte](/slides/sv/androidjava/multithreading/) en enda presentationsinstans över trådar. Använd en separat instans per tråd eller process.

**Vilka begränsningar har provversionen vid export till PNG?**

Utvärderingsläget lägger till ett vattenstämpel på utdatatbilderna och tillämpar [andra begränsningar](/slides/sv/androidjava/licensing/) tills en licens har aktiverats.