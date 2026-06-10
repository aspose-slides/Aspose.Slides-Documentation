---
title: PowerPoint diák konvertálása PNG-re Androidon
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint PNG-re
- prezentáció PNG-re
- dia PNG-re
- PPT PNG-re
- PPTX PNG-re
- PPT mentése PNG-ként
- PPTX mentése PNG-ként
- PPT exportálása PNG-be
- PPTX exportálása PNG-be
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint prezentációkat magas minőségű PNG képekké gyorsan az Aspose.Slides for Android segítségével Java-ból, biztosítva a pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a PowerPoint előadásokat PNG képekké konvertálni az Aspose.Slides használatával. Megmutatja, hogyan tölthetőek be a prezentációs fájlok PPT, PPTX és ODP formátumokban, hogyan renderelhetők a diák képekként, és hogyan menthetők az eredmények PNG formátumban.

A cikk továbbá azt is bemutatja, hogyan testreszabhatók a generált PNG képek méretezési értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG-be**

Kövesse ezeket a lépéseket:

1. Hozza létre a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályt.
2. Szerezze meg a diapozitív objektumot a [Presentation.getSlides()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation#getSlides--) gyűjteményből az [ISlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide) interfész alatt.
3. Használja a [ISlide.getImage()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ISlide) metódust, hogy minden diára előállítsa a miniatűrt.
4. Használja a [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) metódust a diaminatűr PNG formátumba történő mentéséhez.

Ez a Java kód bemutatja, hogyan konvertálható egy PowerPoint prezentáció PNG formátumba:

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

## **PowerPoint konvertálása PNG-be egyéni méretekkel**

Ha egy bizonyos méretarány körüli PNG fájlokat szeretne, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a létrejövő miniatűr méretét.

Ez a Java kód bemutatja a leírt műveletet:

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

## **PowerPoint konvertálása PNG-be egyéni mérettel**

Ha egy bizonyos méretű PNG fájlokat szeretne, megadhatja a kívánt `width` és `height` argumentumokat az `ImageSize` esetén.

Ez a kód bemutatja, hogyan konvertálható egy PowerPoint PNG-be, miközben megadja a képek méretét:

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

## **GYIK**

**Hogyan exportálhatok csak egy adott alakzatot (pl. diagram vagy kép) a teljes dia helyett?**  
Az Aspose.Slides támogatja az [egyedi alakzatok miniatűrök létrehozását](/slides/hu/androidjava/create-shape-thumbnails/); egy alakzatot PNG képpé is renderelhet.

**Támogatott-e a párhuzamos konvertálás a szerveren?**  
Igen, de [ne ossza meg](/slides/hu/androidjava/multithreading/) egyetlen prezentációpéldányt a szálak között. Használjon külön példányt szálanként vagy folyamatanként.

**Mik a próbaverzió korlátozásai PNG exportálásakor?**  
Az értékelő mód vízjelet helyez az exportált képekre, és [más korlátozásokat](/slides/hu/androidjava/licensing/) alkalmaz, amíg a licencet be nem állítják.