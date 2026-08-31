---
title: Dia renderelése SVG képként
type: docs
weight: 50
url: /hu/net/render-slide-as-svg-image/
---
Az SVG—a Scalable Vector Graphics (Skálázható Vektorgrafika) rövidítése—egy szabványos grafikai típus vagy formátum, amelyet kétdimenziós képek renderelésére használnak. Az SVG képeket vektorokként tárolja XML-ben, részletekkel, amelyek meghatározzák a viselkedésüket vagy megjelenésüket.

Az SVG az egyik kevés képformátum, amely ezen szempontok szerint nagyon magas követelményeket teljesít: skálázhatóság, interaktivitás, teljesítmény, hozzáférhetőség, programozhatóság és egyebek. Ezek miatt gyakran használják webfejlesztésben.

Az SVG fájlokat az alábbi esetekben lehet érdemes használni:

- amikor a bemutatóját nagyon nagy formátumban kívánja nyomtatni. Az SVG képek bármilyen felbontásra vagy szintre skálázhatók. Az SVG képeket annyiszor átméretezheti, amennyire csak szükség van, minőségromlás nélkül.
- amikor a diákon lévő diagramokat és grafikonokat különböző médiumokban vagy platformokon kívánja felhasználni. A legtöbb leolvasó képes értelmezni az SVG fájlokat.
- amikor a lehető legkisebb képméretekre van szükség. Az SVG fájlok általában kisebbek, mint a magas felbontású megfelelőik más formátumokban, különösen a bitmap‑alapú (JPEG vagy PNG) formátumok esetében.

Az Aspose.Slides for .NET lehetővé teszi, hogy a prezentációi diákját **SVG** képekként exportálja. Egy SVG kép előállításához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból.
- Iteráljon végig a prezentáció összes dián.
- Írja minden diát a saját SVG fájljába a FileStream segítségével.

{{% alert color="info" %}} 
Érdemes lehet kipróbálni a [ingyenes webalkalmazásunkat](https://products.aspose.app/slides/hu/conversion/ppt-to-svg), amelyben megvalósítottuk a PPT‑ből SVG‑be konvertálás funkciót az Aspose.Slides for .NET‑ből.
{{% /alert %}} 

Ez a C#‑os mintakód megmutatja, hogyan konvertálhat PPT‑t SVG‑vé az Aspose.Slides segítségével:

``` csharp
using Aspose.Slides;

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