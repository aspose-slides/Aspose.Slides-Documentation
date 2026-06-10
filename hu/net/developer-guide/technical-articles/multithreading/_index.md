---
title: Többszálúság az Aspose.Slides for .NET-ben
linktitle: Többszálúság
type: docs
weight: 310
url: /hu/net/multithreading/
keywords:
- többszálú feldolgozás
- több szál
- párhuzamos munkavégzés
- diák konvertálása
- diák képekké
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET többszálúsága felgyorsítja a PowerPoint és OpenDocument feldolgozást. Fedezze fel a hatékony prezentációs munkafolyamatok legjobb gyakorlatait."
---
## **Bevezetés**

Miközben a prezentációkkal való párhuzamos munka lehetséges (a feldolgozás/töltés/másolás mellett) és a legtöbb esetben minden rendben megy, mégis van egy kis esély arra, hogy helytelen eredményeket kapjon, ha a könyvtárat több szálon használja.

Erősen javasoljuk, hogy **ne** használjon egyetlen [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) példányt több szálas környezetben, mivel ez kiszámíthatatlan hibákhoz vagy nehezen észlelhető hibákhoz vezethet. 

Nem **biztonságos** betölteni, menteni és/vagy klónozni egy [Prezentáció](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation) osztály példányát több szálon. Az ilyen műveletek **nem** támogatottak. Ha ilyen feladatokat kell végrehajtania, akkor párhuzamosan kell futtatnia a műveleteket több egyetlen szálas folyamat segítségével – és minden folyamatnak saját prezentáció példányt kell használnia. 

## **Prezentációs diák párhuzamos konvertálása képekké**

Tegyük fel, hogy párhuzamosan szeretnénk egy PowerPoint prezentáció összes diaját PNG képekké konvertálni. Mivel nem biztonságos egyetlen `Presentation` példányt több szálon használni, a prezentáció diákját különálló prezentációkra bontjuk, és a diák konvertálását képekké párhuzamosan végezzük, minden prezentációt egy külön szálban használva. Az alábbi kódrészlet bemutatja, hogyan lehet ezt megtenni.

```cs
var inputFilePath = "sample.pptx";
var outputFilePathTemplate = "slide_{0}.png";
var imageScale = 2;

using var presentation = new Presentation(inputFilePath);

var slideCount = presentation.Slides.Count;
var slideSize = presentation.SlideSize.Size;

var conversionTasks = new List<Task>(slideCount);

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    // Kivonja a i. diát egy külön prezentációba.
    var slidePresentation = new Presentation();
    slidePresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);
    slidePresentation.Slides.RemoveAt(0);
    slidePresentation.Slides.AddClone(presentation.Slides[slideIndex]);

    // Átalakítja a diát képpé egy külön feladatban.
    var slideNumber = slideIndex + 1;
    conversionTasks.Add(Task.Run(() =>
    {
        try
        {
            var slide = slidePresentation.Slides[0];

            using var image = slide.GetImage(imageScale, imageScale);
            var imageFilePath = string.Format(outputFilePathTemplate, slideNumber);
            image.Save(imageFilePath, ImageFormat.Png);
        }
        finally
        {
            slidePresentation.Dispose();
        }
    }));
}

await Task.WhenAll(conversionTasks);
```

## **GYIK**

**Meg kell hívnom a licenc beállítást minden szálban?**

Nem. Elég egyszer végrehajtani a folyamat/alrendszer indítása előtt, mielőtt a szálak elindulnának. Ha a [licenc beállítás](/slides/hu/net/licensing/) párhuzamosan hívható meg (például lusta inicializálás során), szinkronizálja a hívást, mivel maga a licenc beállítási metódus nem szálbiztos.

**Átadhatok `Presentation` vagy `Slide` objektumokat szálak között?**

A „élő” prezentációobjektumok szálak közötti átvitele nem ajánlott: használjon szálanként független példányokat, vagy hozzon létre előre külön prezentációkat/diakonténereket minden szál számára. Ez a megközelítés követi az általános javaslatot, hogy egyetlen prezentáció példányt ne osszanak meg szálak között.

**Biztonságos-e a különböző formátumokba (PDF, HTML, képek) történő export párhuzamosítása, ha minden szálnak saját `Presentation` példánya van?**

Igen. Független példányokkal és külön kimeneti útvonalakkal az ilyen feladatok általában helyesen párhuzamosíthatók; kerüljön minden közös prezentáció objektumot és közös I/O adatfolyamot.

**Mit kell tennem a globális betűtípus beállításokkal (mappák, helyettesítések) több szálas környezetben?**

Inicializálja az összes globális betűtípus beállítást a szálak indítása előtt, és ne változtassa meg őket a párhuzamos munka során. Ez kiküszöböli a versenyhelyzeteket a megosztott betűtípus erőforrások elérésekor.