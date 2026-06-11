---
title: Konvertera PowerPoint‑bilder till PNG i Java
linktitle: PowerPoint till PNG
type: docs
weight: 30
url: /sv/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Konvertera PowerPoint‑presentationer till högkvalitativa PNG‑bilder snabbt med Aspose.Slides för Java, vilket säkerställer precisa, automatiserade resultat."
---
## **Översikt**

Den här artikeln förklarar hur du konverterar PowerPoint‑presentationer till PNG‑bilder med Aspose.Slides. Den visar hur du läser in presentationsfiler i format som PPT, PPTX och ODP, renderar bilder som bilder och sparar resultatet i PNG‑format.

Artikeln visar också hur du anpassar de genererade PNG‑bilderna genom att ange skalningsvärden eller specificera önskad bredd och höjd.

## **Konvertera PowerPoint till PNG**

Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation).
2. Hämta bildobjektet från samlingen [Presentation.getSlides()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) under gränssnittet [ISlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide).
3. Använd metoden [ISlide.getImage()](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlide) för att hämta miniatyrbilden för varje bild.
4. Använd metoden [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) för att spara bildminiatyren i PNG‑format.

Den här Java‑koden visar hur du konverterar en PowerPoint‑presentation till PNG:

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

## **Konvertera PowerPoint till PNG med anpassade dimensioner**

Om du vill få PNG‑filer med en viss skala kan du ställa in värdena för `desiredX` och `desiredY`, som bestämmer dimensionerna på den resulterande miniatyrbilden.

Den här koden i Java demonstrerar den beskrivna operationen:

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

Om du vill få PNG‑filer med en viss storlek kan du ange dina föredragna argument `width` och `height` för `ImageSize`.

Den här koden visar hur du konverterar en PowerPoint till PNG samtidigt som du specificerar storleken på bilderna:

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

Aspose.Slides stödjer [generering av miniatyrbilder för enskilda former](/slides/sv/java/create-shape-thumbnails/); du kan rendera en form till en PNG‑bild.

**Stöds parallell konvertering på en server?**

Ja, men [dela inte](/slides/sv/java/multithreading/) en enda presentationsinstans mellan trådar. Använd en separat instans per tråd eller process.

**Vilka är begränsningarna i provversionen när du exporterar till PNG?**

Utvärderingsläget lägger till ett vattenstämpel på utdata‑bilder och tillämpar [andra begränsningar](/slides/sv/java/licensing/) tills en licens har aktiverats.