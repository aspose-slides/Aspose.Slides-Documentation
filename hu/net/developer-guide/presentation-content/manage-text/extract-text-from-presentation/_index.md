---
title: Fejlett szövegkinyerés prezentációkból .NET-ben
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/net/extract-text-from-presentation/
keywords:
- szöveg kinyerése
- szöveg kinyerése a diákról
- szöveg kinyerése a prezentációból
- szöveg kinyerése PowerPoint-ból
- szöveg kinyerése OpenDocument-ból
- szöveg kinyerése PPT-ből
- szöveg kinyerése PPTX-ből
- szöveg kinyerése ODP-ből
- szöveg lekérése
- szöveg lekérése a diákról
- szöveg lekérése a prezentációból
- szöveg lekérése PowerPoint-ból
- szöveg lekérése OpenDocument-ból
- szöveg lekérése PPT-ből
- szöveg lekérése PPTX-ből
- szöveg lekérése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Gyorsan kinyerhet szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for .NET használatával. Kövesse egyszerű, lépésről-lépésre útmutatónkat, hogy időt takarítson meg."
---
## **Áttekintés**

A prezentációkból szöveg kinyerése gyakori, ám elengedhetetlen feladat a diák tartalmával dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal (PPT vagy PPTX), akár OpenDocument prezentációkkal (ODP) dolgozol, a szöveges adatok elérése és visszanyerése kritikus lehet elemzés, automatizálás, indexelés vagy tartalom migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációs formátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for .NET segítségével. Megtanulod, hogyan iterálj rendszeresen a prezentációelemeken a szükséges szövegtartalom pontos visszanyerése érdekében.

## **Szöveg kinyerése egy diából**

Az Aspose.Slides for .NET biztosítja a [Aspose.Slides.Util](https://reference.aspose.com/slides/hu/net/aspose.slides.util/) névteret, amely tartalmazza a [SlideUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust kínál a prezentáció vagy dia összes szövegének kinyerésére. Egy prezentáció egy diájáról történő szövegkivonáshoz használd a [GetAllTextBoxes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextboxes/) metódust. Ez a metódus egy [IBaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/) típusú objektumot fogad paraméterként. A végrehajtás során a metódus bejárja a teljes diát a szöveg után és egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, megőrizve a szövegformázást.

Az alábbi kódrészlet kinyeri a prezentáció első diájának az összes szövegét:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Szöveg kinyerése egy prezentációból**

Az egész prezentáció szövegének beolvasásához használd a [SlideUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/) osztály által biztosított [GetAllTextFrames](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextframes/) statikus metódust. Két paramétert fogad:

1. Először egy [IPresentation](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/) objektumot, amely egy PowerPoint vagy OpenDocument prezentációt képvisel, amelyből a szöveget ki szeretnénk nyerni.
2. Másodként egy `Boolean` értéket, amely azt jelzi, hogy a mesterdia-kat is bele kell-e venni a szövegvizsgálatba.

A metódus egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat is. Az alábbi kód beolvassa a szöveget és a formázási részleteket a prezentációból, beleértve a mesterdia-kat is.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **Kategorizált és gyors szövegkinyerés**

A [PresentationFactory](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/) osztály szintén metódusokat biztosít a prezentációk összes szövegének kinyerésére:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/net/aspose.slides/textextractionarrangingmode/) enum argumentum határozza meg a szövegkinyerési eredmény rendezésének módját, és a következő értékekkel állítható be:
- `Unarranged` – A nyers szöveg, a dia helyzetére tekintet nélkül.
- `Arranged` – A szöveg a dián látható sorrendben van rendezve.

Az `Unarranged` módot akkor használhatod, ha a sebesség kritikus; ez gyorsabb, mint a `Arranged` mód.

Az [IPresentationText](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationtext/) a prezentációból kinyert nyers szöveget képviseli. `SlidesText` tulajdonsága egy [ISlideText](https://reference.aspose.com/slides/hu/net/aspose.slides/islidetext/) típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét reprezentálja. A [ISlideText](https://reference.aspose.com/slides/hu/net/aspose.slides/islidetext/) típusú objektumnak a következő tulajdonságai vannak:

- `Text` – A dia alakzatain belüli szöveg.
- `MasterText` – A mesterdia alakzatain belüli szöveg, amely ehhez a diához tartozik.
- `LayoutText` – A layoutdia alakzatain belüli szöveg, amely ehhez a diához tartozik.
- `NotesText` – A jegyzetdia alakzatain belüli szöveg, amely ehhez a diához tartozik.
- `CommentsText` – A megjegyzésekben lévő szöveg, amely ehhez a diához tartozik.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **GYIK**

**Mennyire gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat a szövegkinyerés során?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és még [nagy prezentációkat](/slides/hu/net/open-presentation/) is képes feldolgozni, így alkalmas valós idejű vagy tömeges feldolgozási forgatókönyvekre.

**Képes-e az Aspose.Slides szöveget kinyerni a táblázatokból és diagramokból a prezentációkban?**

Igen. Az Aspose.Slides képes szöveget kinyerni a diák számos eleméből, beleértve a táblázatokat és a diagramokhoz kapcsolódó objektumokat, így hozzáférhetsz és elemezheted a szöveges tartalmat a közös prezentációs struktúrákban.

**Szükségem van külön licencre az Aspose.Slides-hoz a prezentációk szövegének kinyeréséhez?**

A szöveget a Aspose.Slides ingyenes próbaverziójával is kinyerheted, bár ez [bizonyos korlátozásokkal](/slides/hu/net/licensing/) jár, például csak korlátozott számú dia feldolgozható. Korlátlan használathoz és nagyobb prezentációk kezeléséhez teljes licenc vásárlását ajánljuk.