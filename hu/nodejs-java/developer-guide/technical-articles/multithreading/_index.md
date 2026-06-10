---
title: "Többszálú feldolgozás az Aspose.Slides számára Node.js-hez Java-n keresztül"
linktitle: "Többszálú feldolgozás"
type: docs
weight: 310
url: /hu/nodejs-java/multithreading/
keywords:
- "többszálúság"
- "több szál"
- "párhuzamos munka"
- "diák konvertálása"
- "diák képekké"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Az Aspose.Slides for Node.js via Java többszálú feldolgozása fokozza a PowerPoint és OpenDocument feldolgozást. Fedezze fel a leghatékonyabb prezentációs munkafolyamatok legjobb gyakorlatait."
---
## **Bevezetés**

Bár a prezentációk párhuzamos feldolgozása lehetséges (a felparsolás/betöltés/klónozás kivételével) és a legtöbb esetben minden rendben működik, kisebb eséllyel előfordulhat, hogy helytelen eredményeket kap, ha a könyvtárat több szálon használja.

Határozottan javasoljuk, hogy **ne** használjon egyetlen [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) példányt több szálas környezetben, mert ez kiszámíthatatlan hibákhoz vagy nehezen észlelhető meghibásodásokhoz vezethet.

Nem **biztonságos** egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztály példányát több szálban betölteni, menteni és/vagy klónozni. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatot kell végrehajtania, a műveleteket több, egyszálú folyamat segítségével kell párhuzamosítani – és minden folyamatnak a saját prezentációpéldányt kell használnia.

## **Prezentációs diák képekké konvertálása párhuzamosan**

Tegyük fel, hogy az összes diát egy PowerPoint prezentációból PNG képekké szeretnénk konvertálni párhuzamosan. Mivel nem biztonságos egyetlen `Presentation` példányt több szálban használni, a prezentáció diákját különálló prezentációkra bontjuk, és a diák konvertálását képekké párhuzamosan végezzük, minden prezentációt külön szálban felhasználva. Az alábbi kódrészlet mutatja, hogyan kell ezt megtenni.

```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // Kivonja az i. diát egy külön prezentációba.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // Várakozik, amíg az összes feladat befejeződik.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```

## **GYIK**

**Kell-e minden szálban licence beállítást meghívni?**

Nem. Elég egyszer elvégezni a folyamat/alkalmazás domainjában, mielőtt a szálak elindulnak. Ha a [license setup](/slides/hu/nodejs-java/licensing/) párhuzamosan hívható (például késleltetett inicializálás során), szinkronizálja a hívást, mivel a licence beállítási metódus önmagában nem szálbiztos.

**Átadhatok `Presentation` vagy `Slide` objektumokat szálak között?**

Az "élő" prezentációobjektumok szálak közti átadása nem ajánlott: használjon szálanként önálló példányokat, vagy előre hozzon létre külön prezentációkat/diakonténereket minden szál számára. Ez a megközelítés összhangban van az általános ajánlással, miszerint ne osszon meg egyetlen prezentációpéldányt a szálak között.

**Biztonságos a különböző formátumokba (PDF, HTML, képek) történő export párhuzamosítása, ha minden szálnak saját `Presentation` példánya van?**

Igen. Független példányokkal és különálló kimeneti útvonalakkal az ilyen feladatok általában helyesen párhuzamosíthatók; kerülje a megosztott prezentációobjektumokat és a megosztott I/O adatfolyamokat.

**Mit tegyek a globális betűkészlet beállításokkal (mappák, helyettesítések) több szálas környezetben?**

Inicializálja az összes globális betűkészlet-beállítást a szálak indítása előtt, és a párhuzamos munka során ne változtassa meg ezeket. Ez megszünteti a versengéseket a megosztott betűkészlet-eredmények elérésekor.