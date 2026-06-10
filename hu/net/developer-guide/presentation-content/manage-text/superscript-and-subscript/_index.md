---
title: Felső- és alsóindex kezelése a prezentációkban .NET-ben
linktitle: Felső- és alsóindex
type: docs
weight: 80
url: /hu/net/superscript-and-subscript/
keywords:
- felsőindex
- alsóindex
- felsőindex hozzáadása
- alsóindex hozzáadása
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Legyen mestere a felső- és alsóindexnek az Aspose.Slides for .NET-ben, és emelje fel prezentációit professzionális szövegformázással a maximális hatás érdekében."
---
## **Áttekintés**

Az Aspose.Slides for .NET olyan funkciókat kínál, amelyek lehetővé teszik a felső- és alsóindex szöveg integrálását a PowerPoint (PPT, PPTX) és OpenDocument (ODP) prezentációkba. Akár kémiai képletek, matematikai egyenletek kiemeléséről, akár lábjegyzetekkel való megjegyzésről van szó, ezek a speciális formázási lehetőségek segítenek a tisztaság és pontosság megőrzésében. Ebben a cikkben megtanulja, hogyan alkalmazza zökkenőmentesen a felső- és alsóindex stílusokat, és hogyan érjen el professzionális eredményeket minden dián.

## **Felső- és alsóindex szöveg hozzáadása**

Felső- és alsóindex szöveget bármely bekezdésben hozzáadhat a prezentációhoz. Az Aspose.Slides használatához a [PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/) osztály `Escapement` tulajdonságát kell használnia.

Ez a tulajdonság lehetővé teszi a felső- vagy alsóindex szöveg beállítását, -100% (alsóindex) és 100% (felsőindex) közötti értékekkel.

Implementation steps:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referencia a diára az indexe alapján.
1. Adjon hozzá egy `Rectangle` típusú [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diára.
1. Érje el a [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/)-hez kapcsolódó [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) objektumot.
1. Törölje a meglévő bekezdéseket.
1. Hozzon létre egy új [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) elemet a felsőindex szöveghez, és adja hozzá az [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) bekezdésgyűjteményéhez.
1. Hozzon létre egy új szövegrész objektumot.
1. Állítsa be a `Escapement` tulajdonságot a szövegrészre 0 és 100 között a felsőindex alkalmazásához (0 = nincs felsőindex).
1. Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/) számára, és adja hozzá a bekezdés részgyűjteményéhez.
1. Hozzon létre egy másik [Paragraph](https://reference.aspose.com/slides/hu/net/aspose.slides/paragraph/) elemet az alsóindex szöveghez, és adja hozzá a bekezdésgyűjteményhez.
1. Hozzon létre egy új szövegrész objektumot.
1. Állítsa be a `Escapement` tulajdonságot a szövegrészre 0 és -100 között az alsóindex alkalmazásához (0 = nincs alsóindex).
1. Állítson be szöveget a [Portion](https://reference.aspose.com/slides/hu/net/aspose.slides/portion/) számára, és adja hozzá a bekezdés részgyűjteményéhez.
1. Mentse a prezentációt PPTX fájlként.

A következő C# kód valósítja meg ezeket a lépéseket:

```c#
using (Presentation presentation = new Presentation())
{
    // Az első dia lekérése.
    ISlide slide = presentation.Slides[0];

    // Szövegdoboz létrehozása.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    ITextFrame textFrame = shape.TextFrame;

    textFrame.Paragraphs.Clear();

    // Létrehoz egy bekezdést a felsőindex szöveghez.
    IParagraph superPar = new Paragraph();

    // Létrehoz egy szövegrészt normál szöveggel.
    IPortion portion1 = new Portion();
    portion1.Text = "MyProduct";
    superPar.Portions.Add(portion1);

    // Létrehoz egy szövegrészt felsőindex szöveggel.
    IPortion superPortion = new Portion();
    superPortion.PortionFormat.Escapement = 30;
    superPortion.Text = "TM";
    superPar.Portions.Add(superPortion);

    // Létrehoz egy bekezdést az alsóindex szöveghez.
    IParagraph paragraph2 = new Paragraph();

    // Létrehoz egy szövegrészt normál szöveggel.
    IPortion portion2 = new Portion();
    portion2.Text = "a";
    paragraph2.Portions.Add(portion2);

    // Létrehoz egy szövegrészt alsóindex szöveggel.
    IPortion subPortion = new Portion();
    subPortion.PortionFormat.Escapement = -25;
    subPortion.Text = "i";
    paragraph2.Portions.Add(subPortion);

    // Hozzáadja a bekezdéseket a szövegdobozhoz.
    textFrame.Paragraphs.Add(superPar);
    textFrame.Paragraphs.Add(paragraph2);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Felső- és alsóindex](superscript_and_subscript.png)

## **GYIK**

**Megmarad a felső- és alsóindex a PDF vagy más formátumokba exportáláskor?**

Igen, az Aspose.Slides for .NET helyesen megőrzi a felső- és alsóindex formázást a prezentációk PDF, PPT/PPTX, képek és egyéb támogatott formátumokba történő exportálása során. A speciális formázás minden kimeneti fájlban érintetlen marad.

**Kombinálható a felső- és alsóindex más formázási stílusokkal, például félkövérré vagy dőlté?**

Igen, az Aspose.Slides lehetővé teszi különböző szövegstílusok keverését egyetlen szövegrészben. Engedélyezheti a félkövér, dőlt, aláhúzott formátumot, és egyidejűleg alkalmazhat felső- vagy alsóindexet a megfelelő [PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/) beállítások konfigurálásával.

**Működik a felső- és alsóindex formázás táblázatok, diagramok vagy SmartArt szövegében?**

Igen, az Aspose.Slides for .NET támogatja a formázást a legtöbb objektumban, beleértve a táblázatokat és diagram elemeket is. SmartArt használatakor hozzá kell férni a megfelelő elemekhez (például a [SmartArtNode](https://reference.aspose.com/slides/hu/net/aspose.slides.smartart/smartartnode/) elemhez) és azok szövegtárolóihoz, majd hasonló módon kell beállítani a [PortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/portionformat/) tulajdonságokat.