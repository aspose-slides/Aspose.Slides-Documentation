---
title: Dia renderelése SVG képként
type: docs
weight: 50
url: /hu/net/render-slide-as-svg-image/
---
SVG—a Scalable Vector Graphics rövidítése—egy szabványos grafikai típus vagy formátum, amelyet kétdimenziós képek megjelenítésére használnak. Az SVG képeket vektorokként tárolja XML-ben, részletekkel, amelyek meghatározzák viselkedésüket vagy megjelenésüket.

Az SVG az egyik kevés képformátum közül, amely nagyon magas szintű követelményeknek felel meg ezen szempontokban: méretezhetőség, interaktivitás, teljesítmény, hozzáférhetőség, programozhatóság és egyebek. Ezek miatt gyakran használják webfejlesztésben.

Érdemes SVG fájlokat használni az alábbi helyzetekben:

- amikor a prezentációját nagyon nagy formátumban szeretné nyomtatni. Az SVG képek bármilyen felbontásra vagy szintre méretezhetők. Az SVG képeket annyiszor átméretezheti, amennyire szüksége van, anélkül, hogy a minőség romlana.
- amikor a diákon lévő diagramokat és grafikonokat különböző médiumokban vagy platformokon kívánja felhasználni. A legtöbb olvasó képes értelmezni az SVG fájlokat.
- amikor a lehető legkisebb képméretekre van szüksége. Az SVG fájlok általában kisebbek, mint a magas felbontású megfelelőik más formátumokban, különösen a bitmap‑alapú formátumok (JPEG vagy PNG) esetén.

Az Aspose.Slides for .NET lehetővé teszi, hogy a prezentáció diákját **SVG** képként exportálja. Egy SVG kép előállításához bármelyikből, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból.
- Iteráljon végig a prezentáció összes diáján.
- Írja minden diát saját SVG fájlként a FileStream segítségével.

{{% alert color="primary" %}} 
Érdemes kipróbálni [ingyenes webalkalmazásunkat](https://products.aspose.app/slides/hu/conversion/ppt-to-svg), amelyben megvalósítottuk a PPT‑ről SVG‑re konvertálás funkciót az Aspose.Slides for .NET‑ből.
{{% /alert %}} 

Ez a C# mintakód bemutatja, hogyan lehet PPT‑t SVG‑vé konvertálni az Aspose.Slides segítségével:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```