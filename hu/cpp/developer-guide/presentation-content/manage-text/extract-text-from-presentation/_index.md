---
title: Haladó szövegkivonás prezentációkból C++-ban
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/cpp/extract-text-from-presentation/
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
- C++
- Aspose.Slides
description: "Gyorsan nyerje ki a szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for C++ használatával. Kövesse egyszerű, lépésről‑lépésre szóló útmutatónkat az időspórolásért."
---
## **Áttekintés**

A prezentációkból szöveg kinyerése gyakori, ugyanakkor alapvető feladat a diákkal dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal (PPT vagy PPTX formátumban), akár OpenDocument prezentációkkal (ODP) dolgozol, a szöveges adatok elérése és lekérése kulcsfontosságú lehet elemzés, automatizálás, indexelés vagy tartalom migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for C++ használatával. Megtanulod, hogyan iterálj rendszeresen a prezentáció elemein, hogy pontosan kinyerd a szükséges szöveges tartalmat.

## **Szöveg kinyerése egy diáról**

Az Aspose.Slides for C++ a [Aspose.Slides.Util](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/) névtérrel rendelkezik, amely tartalmazza a [SlideUtil](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust tesz elérhetővé a prezentáció vagy dia összes szövegének kinyerésére. Egy diáról való szövegkivonáshoz egy prezentációban használd a [GetAllTextBoxes](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextboxes/) metódust. Ez a metódus egy [IBaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/) típusú objektumot vár paraméterként. Végrehajtáskor a metódus az egész diát átvizsgálja a szöveg után, és egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, megőrizve a szöveg formázását.

Az alábbi kódrészlet kinyeri a teljes szöveget a prezentáció első diájáról:

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

Az egész prezentáció szövegének beolvasásához használd a [SlideUtil](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/) osztály által kínált [GetAllTextFrames](https://reference.aspose.com/slides/hu/cpp/aspose.slides.util/slideutil/getalltextframes/) statikus metódust. Ez két paramétert fogad:

1. Először egy [IPresentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentation/) objektum, amely egy PowerPoint vagy OpenDocument prezentációt képvisel, amelyből a szöveget ki kell nyerni.
2. Másodszor egy `Boolean` érték, amely azt jelzi, hogy a mesterdiák is bele legyenek véve a prezentáció szövegének beolvasásakor.

A metódus egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, amely tartalmazza a szöveg formázási információkat is. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mesterdiákat.

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

## **Kategorizált és gyors szövegkivonás**

A [PresentationFactory](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentationfactory/) osztály szintén metódusokat kínál a prezentációkból történő teljes szövegkivonáshoz:

```cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode);
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode, System::SharedPtr<ILoadOptions> options);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textextractionarrangingmode/) felsorolt típus argumentuma a szövegkivonási eredmény rendezésének módját jelzi, és a következő értékekre állítható:
- `Unarranged` – A nyers szöveg, a dia pozíciója figyelembe vétele nélkül.
- `Arranged` – A szöveg a dián lévő sorrendben van rendezve.

Az `Unarranged` mód akkor használható, ha a sebesség kritikus; gyorsabb, mint a `Arranged` mód.

Az [IPresentationText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ipresentationtext/) a prezentációból kinyert nyers szöveget képviseli. A `get_SlidesText()` metódusa egy [ISlideText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidetext/) típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét reprezentálja. A [ISlideText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidetext/) típusú objektumnak a következő metódusai vannak:
- `get_Text()` – A dia alakzatain belüli szöveg.
- `get_MasterText()` – A diához kapcsolódó mesterdia alakzatain belüli szöveg.
- `get_LayoutText()` – A diához kapcsolódó elrendezésdia alakzatain belüli szöveg.
- `get_NotesText()` – A diához kapcsolódó jegyzetdia alakzatain belüli szöveg.
- `get_CommentsText()` – A diához kapcsolódó megjegyzések szövege.

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

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat a szövegkivonás során?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és képes nagy [prezentációk](/slides/hu/cpp/open-presentation/) feldolgozására is, így alkalmas valós idejű vagy tömeges feldolgozási helyzetekben.

**Kivonhatja az Aspose.Slides a szöveget a prezentációk táblázataiból és diagramjaiból?**

Igen. Az Aspose.Slides szöveget tud kinyerni számos diavázlatból, beleértve a táblázatokat és diagramokkal kapcsolatos objektumokat is, így hozzáférhetsz és elemezheted a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van külön Aspose.Slides licencre a prezentációk szövegének kinyeréséhez?**

A szöveget kinyerheted az Aspose.Slides ingyenes próba Verziójával, bár ez [bizonyos korlátozásokkal](/slides/hu/cpp/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezeléséhez ajánlott teljes licencet vásárolni.