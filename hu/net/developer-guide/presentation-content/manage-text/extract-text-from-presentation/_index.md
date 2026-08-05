---
title: Haladó szövegkinyerés prezentációkból .NET környezetben
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/hu/
keywords:
- szöveg kinyerése
- szöveg kinyerése diából
- szöveg kinyerése prezentációból
- szöveg kinyerése PowerPointból
- szöveg kinyerése OpenDocumentből
- szöveg kinyerése PPT-ből
- szöveg kinyerése PPTX-ből
- szöveg kinyerése ODP-ből
- szöveg lekérése
- szöveg lekérése diából
- szöveg lekérése prezentációból
- szöveg lekérése PowerPointból
- szöveg lekérése OpenDocumentből
- szöveg lekérése PPT-ből
- szöveg lekérése PPTX-ből
- szöveg lekérése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Gyorsan nyerje ki a szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for .NET használatával. Kövesse egyszerű, lépésről lépésre útmutatónkat időmegtakarítás érdekében."
---
## **Áttekintés**

A prezentációkból történő szövegkinyerés gyakori, de lényeges feladat a diatartalommal dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal (PPT vagy PPTX formátumban), akár OpenDocument prezentációkkal (ODP) dolgozol, a szöveges adatok elérése és lekérdezése kritikus lehet az elemzés, automatizálás, indexelés vagy a tartalom migrációs célokra.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, többek között PPT, PPTX és ODP, az Aspose.Slides for .NET segítségével. Megtanulod, hogyan iterálj rendszerezetten a prezentáció elemein, hogy pontosan visszanyerd a szükséges szövegtartalmat.

## **Szöveg kinyerése egy diából**

Aspose.Slides for .NET biztosítja a [Aspose.Slides.Util](https://reference.aspose.com/slides/hu/net/aspose.slides.util/) névteret, amely tartalmazza a [SlideUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust kínál a prezentáció vagy dia összes szövegének kinyerésére. A diához tartozó szöveg kinyeréséhez a [GetAllTextBoxes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextboxes/) metódust kell használni. Ez a metódus egy [IBaseSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseslide/) típusú objektumot fogad paraméterként. A végrehajtás során a metódus végig pásztázza a teljes diát a szövegért, és egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, megőrizve a szövegformázást.

Az alábbi kódrészlet kinyeri a prezentáció első diájának összes szövegét:

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

A teljes prezentáció szövegének beolvasásához a [GetAllTextFrames](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/getalltextframes/) statikus metódust kell használni, amely a [SlideUtil](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/) osztályban érhető el. Két paramétert fogad:

1. Először egy [IPresentation](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentation/) objektumot, amely egy PowerPoint vagy OpenDocument prezentációt reprezentál, amelyből a szöveget ki szeretnénk nyerni.
1. Másodszor egy `Boolean` értéket, amely azt jelzi, hogy a mesterdiák is bele legyenek véve a szöveg beolvasásakor.

A metódus egy [ITextFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mesterdiákat.

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

A [PresentationFactory](https://reference.aspose.com/slides/hu/net/aspose.slides/presentationfactory/) osztály szintén nyújt módszereket az összes szöveg kinyerésére a prezentációkból:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/net/aspose.slides/textextractionarrangingmode/) enum argumentum a szövegkinyerés eredményének szervezési módját jelöli, és a következő értékek közül választható:
- `Unarranged` - A nyers szöveg, a dia helyzetére való tekintet nélkül.
- `Arranged` - A szöveg a dia sorrendjének megfelelően van rendezve.

A nem rendezett mód akkor használható, ha a sebesség kritikus; gyorsabb a rendezett módnál.

Az [IPresentationText](https://reference.aspose.com/slides/hu/net/aspose.slides/ipresentationtext/) a prezentációból kinyert nyers szöveget képviseli. A `SlidesText` tulajdonsága egy [ISlideText](https://reference.aspose.com/slides/hu/net/aspose.slides/islidetext/) típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő diára vonatkozó szöveget tartalmazza. Az [ISlideText](https://reference.aspose.com/slides/hu/net/aspose.slides/islidetext/) típusú objektumnak a következő tulajdonságai vannak:

- `Text` - A dia alakzatainak szövege.
- `MasterText` - A mesterdia alakzatainak szövege, amely ehhez a diához kapcsolódik.
- `LayoutText` - A vázlatdia alakzatainak szövege, amely ehhez a diához kapcsolódik.
- `NotesText` - A jegyzetdia alakzatainak szövege, amely ehhez a diához kapcsolódik.
- `CommentsText` - A megjegyzések szövege, amely ehhez a diához kapcsolódik.

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

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat a szövegkinyerés során?**

Aspose.Slides magas teljesítményre van optimalizálva, és még a [nagy prezentációkat](/slides/hu/net/open-presentation/) is képes feldolgozni, így alkalmas valós idejű vagy tömeges feldolgozási forgatókönyvekre.

**Képes-e az Aspose.Slides szöveget kinyerni a táblázatokból és diagramokból a prezentációkban?**

Igen. Az Aspose.Slides képes szöveget kinyerni számos diák eleméből, többek között táblázatokból és diagramokhoz kapcsolódó objektumokból, így hozzáférhet és elemezheti a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van-e külön Aspose.Slides licencre a prezentációk szövegének kinyeréséhez?**

A szöveget az Aspose.Slides ingyenes próbaverziójával is ki lehet nyerni, bár ez [bizonyos korlátozásokkal](/slides/hu/net/licensing/) jár, például csak korlátozott számú dia feldolgozható. Korlátlan használathoz és nagyobb prezentációk kezeléséhez ajánlott teljes licencet vásárolni.