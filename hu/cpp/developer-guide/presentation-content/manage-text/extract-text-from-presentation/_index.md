---
title: Haladó szövegkinyerés prezentációkból C++-ban
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/cpp/extract-text-from-presentation/
aliases:
  - /cpp/szoveg-kinyerese-a-prezentaciobol/
keywords:
- szöveg kinyerése
- szöveg kinyerése diáról
- szöveg kinyerése prezentációból
- szöveg kinyerése PowerPointból
- szöveg kinyerése OpenDocumentből
- szöveg kinyerése PPT-ből
- szöveg kinyerése PPTX-ből
- szöveg kinyerése ODP-ből
- szöveg lekérése
- szöveg lekérése diáról
- szöveg lekérése prezentációból
- szöveg lekérése PowerPointból
- szöveg lekérése OpenDocumentből
- szöveg lekérése PPT-ből
- szöveg lekérése PPTX-ből
- szöveg lekérése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Gyorsan nyerjen ki szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for C++ segítségével. Kövesse egyszerű, lépésről-lépésre útmutatónkat az idő megtakarítása érdekében."
---
## **Áttekintés**

A prezentációkból történő szövegkinyerés gyakori, de elengedhetetlen feladat a diatartalommal dolgozó fejlesztők számára. Legyen szó Microsoft PowerPoint fájlokról PPT vagy PPTX formátumban, vagy OpenDocument prezentációkról (ODP), a szöveges adatok elérése és kinyerése kritikus lehet elemzés, automatizálás, indexelés vagy tartalom‑migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for C++ használatával. Megtanulja, hogyan iteráljon rendszerezetten a prezentációelemek között a szükséges szövegtartalom pontos lekéréséhez.

## **Szöveg kinyerése egy diáról**

Az Aspose.Slides for C++ a [Aspose.Slides.Util](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/) névtérrel rendelkezik, amely tartalmazza a [SlideUtil](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust biztosít a prezentáció vagy dia összes szövegének kinyeréséhez. Egy diáról történő szövegkivonáshoz a [GetAllTextBoxes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextboxes/) metódust kell használni. Ez a metódus egy [IBaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/) típusú objektumot vár paraméterként. Végrehajtásakor a metódus végig pásztázza a teljes diát a szöveg után, és egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, megőrizve a szövegformázást.

Az alábbi kódrészlet a prezentáció első diájáról nyeri ki az összes szöveget:

```cpp
auto slideIndex = 0;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto textFrames = Util::SlideUtil::GetAllTextBoxes(slide);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Szöveg kinyerése egy prezentációból**

A teljes prezentáció szövegének pásztázásához használja a [SlideUtil](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/) osztály által kiadott [GetAllTextFrames](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextframes/) statikus metódust. Két paramétert fogad:

1. Először egy [IPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/) objektum, amely egy PowerPoint vagy OpenDocument prezentációt képvisel, amelyből a szöveget ki kell nyerni.
1. Másodszor egy `Boolean` érték, amely azt jelzi, hogy a mesterdiák is bele legyenek véve a prezentáció szövegének pásztázásakor.

A metódus egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat is. Az alábbi kód a prezentáció szövegét és formázási részleteit pásztázza, beleértve a mesterdiákat.

```cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto includeMasterSlides = true;
auto textFrames = Util::SlideUtil::GetAllTextFrames(presentation, includeMasterSlides);

for (const auto& textFrame : textFrames)
{
    for (const auto& paragraph : textFrame->get_Paragraphs())
    {
        for (const auto& portion : paragraph->get_Portions())
        {
            auto portionText = portion->get_Text();
            Console::WriteLine(portionText);

            auto portionFormat = portion->get_PortionFormat();
            auto fontHeight = portionFormat->get_FontHeight();
            Console::WriteLine(fontHeight);

            auto latinFont = portionFormat->get_LatinFont();
            if (latinFont != nullptr)
            {
                auto fontName = latinFont->get_FontName();
                Console::WriteLine(fontName);
            }
        }
    }
}

presentation->Dispose();
```

## **Kategorizált és gyors szövegkinyerés**

A [PresentationFactory](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationfactory/) osztály szintén biztosít metódusokat a prezentációkból történő összes szöveg kinyeréséhez:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textextractionarrangingmode/) felsorolt argumentuma a szövegkinyerés eredményének rendezési módját jelzi, és a következő értékekre állítható:

- `Unarranged` – A nyers szöveg, anélkül, hogy figyelembe venné a dia helyzetét.
- `Arranged` – A szöveg a diához hasonló sorrendben van rendezve.

Az `Unarranged` mód akkor használható, amikor a sebesség kritikus; gyorsabb, mint a `Arranged` mód.

Az [IPresentationText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationtext/) a prezentációból kinyert nyers szöveget reprezentálja. `get_SlidesText()` metódusa egy [ISlideText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidettext/) típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét tartalmazza. Az [ISlideText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidettext/) típusú objektumnak a következő metódusai vannak:

- `get_Text()` – A dia alakzatain belüli szöveg.
- `get_MasterText()` – Az ehhez a diához tartozó mesterdia alakzatain belüli szöveg.
- `get_LayoutText()` – Az ehhez a diához tartozó elrendezésdia alakzatain belüli szöveg.
- `get_NotesText()` – A jegyzetdia alakzatain belüli szöveg.
- `get_CommentsText()` – A diához tartozó megjegyzések szövege.

```cpp
auto presentationPath = u"presentation.ppt";
auto arrangingMode = TextExtractionArrangingMode::Unarranged;
auto presentationText = PresentationFactory::get_Instance()->GetPresentationText(presentationPath, arrangingMode);
auto firstSlideText = presentationText->get_SlidesText()[0];

Console::WriteLine(firstSlideText->get_Text());
Console::WriteLine(firstSlideText->get_LayoutText());
Console::WriteLine(firstSlideText->get_MasterText());
Console::WriteLine(firstSlideText->get_NotesText());
Console::WriteLine(firstSlideText->get_CommentsText());
```

## **GYIK**

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat a szövegkinyerés során?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és még [nagy prezentációkat](/slides/hu/cpp/open-presentation/) is képes feldolgozni, így alkalmas valós idejű vagy tömeges feldolgozási szituációkra.

**Képes az Aspose.Slides szöveget kinyerni táblázatokból és diagramokból a prezentációkon belül?**

Igen. Az Aspose.Slides képes szöveget kinyerni számos dián lévő elemről, beleértve a táblázatokat és diagramokhoz kapcsolódó objektumokat is, így hozzáférhet és elemezheti a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van külön Aspose.Slides licencre a prezentációkból való szövegkinyeréshez?**

A szöveget a Aspose.Slides ingyenes próbaverziójával is ki lehet nyerni, bár ez [bizonyos korlátozásokkal](/slides/hu/cpp/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezeléséhez teljes licenc vásárlását ajánljuk.