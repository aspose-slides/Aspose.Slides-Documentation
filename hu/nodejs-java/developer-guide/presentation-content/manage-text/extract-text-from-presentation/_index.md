---
title: Fejlett szövegkivonás prezentációkból JavaScriptben
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/nodejs-java/extract-text-from-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gyorsan nyerje ki a szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Node.js via Java segítségével. Kövesse egyszerű, lépésről lépésre útmutatónkat, hogy időt takarítson meg."
---
## **Áttekintés**

A prezentációkból szöveg kinyerése gyakori, ugyanakkor fontos feladat a diák tartalmával dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal (PPT vagy PPTX formátumban), akár OpenDocument prezentációkkal (ODP) dolgozol, a szöveges adatok elérése és kinyerése kritikus lehet elemzés, automatizálás, indexelés vagy tartalom migráció céljaira.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for Node.js via Java segítségével. Megtanulod, hogyan iterálj rendszerezetten a prezentációelemeken a szükséges szövegtartalom pontos visszanyerése érdekében.

## **Szöveg kinyerése egy diából**

Az Aspose.Slides for Node.js via Java a [SlideUtil](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/) osztályt biztosítja. Ez az osztály több túlterhelt statikus metódust tesz elérhetővé a prezentáció vagy dia összes szövegének kinyerésére. Egy diából történő szövegkivonáshoz a [getAllTextBoxes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) metódust kell használni. Ez a metódus egy diaobjektumot vár paraméterként. Végrehajtáskor a metódus átvizsgálja az egész diát a szövegért, és egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumok tömbjét adja vissza, megőrizve a szövegformázást.

Az alábbi kódrészlet a prezentáció első diájából nyeri ki az összes szöveget:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg kinyerése egy prezentációból**

Az egész prezentáció szövegének beolvasásához használd a [SlideUtil](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/) osztály által biztosított [getAllTextFrames](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) statikus metódust. Két paramétert vár:

1. Először egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumot, amely PowerPoint vagy OpenDocument prezentációt reprezentál, amelyből a szöveget ki szeretnénk nyerni.
2. Másodszor egy `boolean` értéket, amely azt jelzi, hogy a mesterdiák is be legyenek-e vonva a szöveg beolvasásakor.

A metódus egy [TextFrame](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/) objektumok tömbjét adja vissza, a szövegformázási információkat is tartalmazva. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mesterdiákat.

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const includeMasterSlides = true;
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategorizált és gyors szövegkivonás**

A [PresentationFactory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/) osztály szintén biztosít módszereket a prezentációkból származó összes szöveg kinyerésére:

```javascript
PresentationText getPresentationText(String file, int mode);
PresentationText getPresentationText(InputStream stream, int mode);
PresentationText getPresentationText(InputStream stream, int mode, LoadOptions options);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textextractionarrangingmode/) enum argumentum jelzi a szövegkivonási eredmény rendezésének módját, és a következő értékekre állítható:

- `Unarranged` – A nyers szöveg, amely nem veszi figyelembe a dia pozícióját.
- `Arranged` – A szöveg a dián található sorrendben van rendezve.

Az unarranged mód akkor használható, amikor a sebesség kritikus; gyorsabb, mint a rendezett mód.

A [PresentationText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationtext/) a prezentációból kinyert nyers szöveget képviseli. A `getSlidesText` metódusa egy objektumtömböt ad vissza, ahol minden objektum a megfelelő dia szövegét tartalmazza. Minden dia szöveg objektumnak a következő metódusai vannak:

- `getText` metódusa visszaadja a dia alakzatain belüli szöveget.
- `getMasterText` metódusa visszaadja a mesterdia alakzataiban lévő szöveget, amely ehhez a diához kapcsolódik.
- `getLayoutText` metódusa visszaadja a elrendezésdia alakzataiban lévő szöveget, amely ehhez a diához kapcsolódik.
- `getNotesText` metódusa visszaadja a jegyzetdiák alakzataiban lévő szöveget, amely ehhez a diához kapcsolódik.
- `getCommentsText` metódusa visszaadja a megjegyzésekben lévő szöveget, amely ehhez a diához kapcsolódik.

```javascript
const presentationPath = "presentation.ppt";
const arrangingMode = aspose.slides.TextExtractionArrangingMode.Unarranged;
const presentationText = aspose.slides.PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
const firstSlideText = presentationText.getSlidesText()[0];

console.log(firstSlideText.getText());
console.log(firstSlideText.getLayoutText());
console.log(firstSlideText.getMasterText());
console.log(firstSlideText.getNotesText());
console.log(firstSlideText.getCommentsText());
```

## **GYIK**

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat a szövegkivonás során?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és képes feldolgozni még a [nagy prezentációkat](/slides/hu/nodejs-java/open-presentation/), így alkalmas valós idejű vagy nagyméretű kötegelt feldolgozási forgatókönyvekre.

**Képes az Aspose.Slides szöveget kinyerni a prezentációk táblázataiból és diagramjaiból?**

Igen. Az Aspose.Slides képes szöveget kinyerni számos diatelemből, többek között táblázatokból és diagramokhoz kapcsolódó objektumokból, így hozzáférhet és elemezhet a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van-e speciális Aspose.Slides licencre a prezentációkból történő szövegkivonáshoz?**

A szöveget kinyerheted az Aspose.Slides ingyenes próba verziójával, bár ez [bizonyos korlátozásokkal](/slides/hu/nodejs-java/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezeléséhez teljes licenc megvásárlása ajánlott.