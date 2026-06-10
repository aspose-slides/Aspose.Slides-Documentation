---
title: PowerPoint diák konvertálása PNG-re Java-ban
linktitle: PowerPoint PNG-re
type: docs
weight: 30
url: /hu/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "PowerPoint előadásokat gyorsan konvertáljon magas minőségű PNG képekké az Aspose.Slides for Java használatával, biztosítva pontos, automatizált eredményeket."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a PowerPoint előadásokat PNG képekké konvertálni az Aspose.Slides segítségével. Bemutatja, hogyan lehet betölteni előadásfájlokat PPT, PPTX és ODP formátumban, megjeleníteni a diákot képekként, és elmenteni az eredményt PNG formátumban.

A cikk azt is bemutatja, hogyan lehet testreszabni a generált PNG képeket a skálázási értékek beállításával vagy a kívánt szélesség és magasság megadásával.

## **PowerPoint konvertálása PNG-re**

Kövesse az alábbi lépéseket:

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) példányt.
2. Szerezze meg a dia objektumot a [Presentation.getSlides()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getSlides--) gyűjteményből az [ISlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) interfész alatt.
3. Használja az [ISlide.getImage()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ISlide) metódust a dia bélyegképének lekéréséhez.
4. Használja az [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) metódust a dia bélyegkép PNG formátumba történő mentéséhez.

Ez a Java kód megmutatja, hogyan konvertál egy PowerPoint előadást PNG-re:

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

## **PowerPoint konvertálása PNG-re egyedi méretezéssel**

Ha PNG fájlokat szeretne egy bizonyos skála körül, beállíthatja a `desiredX` és `desiredY` értékeket, amelyek meghatározzák a létrejövő bélyegkép méreteit.

Ez a Java kód demonstrálja a leírt műveletet:

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

## **PowerPoint konvertálása PNG-re egyedi mérettel**

Ha PNG fájlokat egy bizonyos méret körül szeretne, megadhatja a kívánt `width` és `height` argumentumokat az `ImageSize` számára.

Ez a kód megmutatja, hogyan konvertál egy PowerPoint előadást PNG-re, miközben megadja a képek méretét:

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

## **Gyakran ismételt kérdések**

**Hogyan exportálhatok csak egy adott alakzatot (például diagramot vagy képet) az egész dia helyett?**

Az Aspose.Slides támogatja az [generating thumbnails for individual shapes](/slides/hu/java/create-shape-thumbnails/); így egy alakzatot PNG képre renderelhet.

**Támogatott-e a párhuzamos konvertálás egy szerveren?**

Igen, de ne ossza meg egyetlen prezentációs példányt a szálak között. Használjon külön példányt szálanként vagy folyamatanként.

**Mik a próba verzió korlátai PNG exportáláskor?**

Az értékelő mód vízjelet helyez az kimeneti képekre és egyéb korlátozásokat alkalmaz, amíg a licenc nincs aktiválva.