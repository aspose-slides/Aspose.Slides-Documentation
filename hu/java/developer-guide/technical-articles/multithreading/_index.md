---
title: Többszálú feldolgozás az Aspose.Slides for Java-ban
linktitle: Többszálú
type: docs
weight: 310
url: /hu/java/multithreading/
keywords:
- többszálú feldolgozás
- több szál
- párhuzamos munka
- diák konvertálása
- diák képekké
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Az Aspose.Slides for Java többszálú feldolgozása felgyorsítja a PowerPoint és OpenDocument feldolgozást. Fedezze fel a hatékony prezentációs munkafolyamatok legjobb gyakorlatait."
---
## **Bevezetés**

Miközben a prezentációk párhuzamos feldolgozása lehetséges (a beolvasás/töltés/klónozás mellett) és a legtöbbször minden rendben megy, mégis kisebb esély van arra, hogy helytelen eredményeket kapjon, ha a könyvtárat több szálban használja.

Határozottan javasoljuk, hogy **ne** használjon egyetlen [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) példányt többszálú környezetben, mivel ez kiszámíthatatlan hibákhoz vagy nehezen észlelhető meghibásodásokhoz vezethet.

Nem **biztonságos** egy [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) példány betöltése, mentése és/vagy klónozása több szálban. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatok elvégzésére van szükség, a műveleteket több egyszálas folyamat használatával kell párhuzamosítani, és minden folyamatnak a saját prezentációpéldányát kell használnia.

## **Prezentációs Diák Párhuzamos Átalakítása Képekké**

Tegyük fel, hogy minden diát egy PowerPoint prezentációból párhuzamosan PNG képekké szeretnénk konvertálni. Mivel egyetlen `Presentation` példány használata több szálban nem biztonságos, a prezentáció diáit különálló prezentációkra bontjuk, és a diák konvertálását párhuzamosan végezzük, minden prezentációt külön szálban használva. Az alábbi kódrészlet bemutatja, hogyan kell ezt megtenni.

```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // Kinyeri a i. diát egy külön prezentációba.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // Átkonvertálja a diát egy külön feladatban képpé.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// Várja meg, amíg az összes feladat befejeződik.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```

## **GYIK**

**Szükséges-e minden szálban licencbeállítást hívni?**

Nem. Elég egyszer, a folyamat/app domain indítása előtt végrehajtani, mielőtt a szálak elindulnak. Ha a [license setup](/slides/hu/java/licensing/) párhuzamosan hívható (például lusta inicializálás esetén), szinkronizálni kell ezt a hívást, mivel a licencbeállítási metódus nem szálbiztos.

**Átadhatok `Presentation` vagy `Slide` objektumokat szálak között?**

Az élő prezentációobjektumok szálak közti átadása nem ajánlott: használjon szálanként független példányokat, vagy előre hozza létre a különálló prezentációkat/diakonténereket minden szálnak. Ez a megközelítés megfelel az általános ajánlásnak, miszerint ne osszuk meg egyetlen prezentációpéldányt a szálak között.

**Biztonságos-e a különböző formátumokba (PDF, HTML, képek) történő export párhuzamosítása, ha minden szálnak saját `Presentation` példánya van?**

Igen. Független példányok és különálló kimeneti útvonalak esetén az ilyen feladatok általában helyesen párhuzamosíthatók; kerülje a megosztott prezentációobjektumokat és a közös I/O folyamokat.

**Mit tegyek a globális betűtípusbeállításokkal (mappák, helyettesítések) többszálú környezetben?**

Inicializálja az összes globális [font settings](/slides/hu/java/powerpoint-fonts/) beállítást a szálak indítása előtt, és ne módosítsa őket a párhuzamos munka során. Ez megszünteti a versengéseket a megosztott betűtípus-erőforrások elérésekor.