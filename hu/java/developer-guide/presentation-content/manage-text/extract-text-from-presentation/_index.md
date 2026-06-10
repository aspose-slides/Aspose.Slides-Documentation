---
title: Fejlett szövegkinyerés prezentációkból Java-ban
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/java/extract-text-from-presentation/
keywords:
- szöveg kinyerése
- szöveg kinyerése a diáról
- szöveg kinyerése a prezentációból
- szöveg kinyerése PowerPointból
- szöveg kinyerése OpenDocumentből
- szöveg kinyerése PPT-ből
- szöveg kinyerése PPTX-ből
- szöveg kinyerése ODP-ből
- szöveg lekérése
- szöveg lekérése a diáról
- szöveg lekérése a prezentációból
- szöveg lekérése PowerPointból
- szöveg lekérése OpenDocumentből
- szöveg lekérése PPT-ből
- szöveg lekérése PPTX-ből
- szöveg lekérése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Gyorsan kinyerhet szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Java használatával. Kövesse egyszerű, lépésről lépésre útmutatónkat, hogy időt takarítson meg."
---
## **Áttekintés**

A prezentációkból szöveg kinyerése gyakori, ugyanakkor elengedhetetlen feladat a diák tartalmával dolgozó fejlesztők számára. Legyen szó Microsoft PowerPoint fájlokról PPT vagy PPTX formátumban, vagy OpenDocument prezentációkról (ODP), a szöveges adatok elérése és kinyerése kritikus lehet elemzés, automatizálás, indexelés vagy tartalom-migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációs formátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for Java használatával. Megtanulod, hogyan lehet rendszerezetten végigjárni a prezentáció elemeit a szükséges szövegtartalom pontos visszanyerése érdekében.

## **Dia szövegének kinyerése**

Az Aspose.Slides for Java a [SlideUtil](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/) osztályt biztosítja. Ez az osztály több túlterhelt statikus metódust kínál a teljes szöveg kinyerésére egy prezentációból vagy diából. Egy diáról történő szövegkinyeréshez használd a [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) metódust. Ez a metódus egy [IBaseSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseslide/) típusú objektumot vár paraméterként. A végrehajtás során a metódus végigellenőrzi a teljes diát, és egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, megőrizve minden szövegformázást.

Az alábbi kódrészlet kinyeri a prezentáció első diájának teljes szövegét:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Szöveg kinyerése a bemutatóból**

A teljes prezentáció szövegének beolvasásához használd a [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) statikus metódust, amely a [SlideUtil](https://reference.aspose.com/slides/hu/java/com.aspose.slides/slideutil/) osztályban érhető el. Két paramétert fogad:

1. Először egy [IPresentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/) objektumot, amely egy PowerPoint vagy OpenDocument prezentációt képvisel, amelyből a szöveget ki szeretnénk nyerni.
2. Másodszor egy `boolean` értéket, amely azt jelzi, hogy a mesterdíák is bele legyenek-e vonva a szöveg beolvasásakor.

A metódus egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat is. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mesterdíákat is.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Kategorizált és gyors szövegkinyerés**

A [PresentationFactory](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentationfactory/) osztály szintén nyújt módszereket a prezentációk teljes szövegének kinyerésére:

```java
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textextractionarrangingmode/) enum argumentum határozza meg a szövegkinyerés eredményének rendezési módját, és a következő értékekre állítható:

- `Unarranged` – A nyers szöveg a dia pozícióját figyelembe véve, rendezés nélkül.
- `Arranged` – A szöveg ugyanabban a sorrendben van, mint a dián.

A rendezés nélküli mód akkor használható, amikor a sebesség kritikus; gyorsabb, mint a rendezett mód.

Az [IPresentationText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentationtext/) a prezentációból kinyert nyers szöveget képviseli. A `getSlidesText` metódusa egy [ISlideText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidetext/) típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét reprezentálja. Az [ISlideText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/islidetext/) típusú objektumnak a következő metódusai vannak:

- `getText` – A dia alakzatai közötti szöveg.
- `getMasterText` – A mesterdia alakzataihoz tartozó szöveg.
- `getLayoutText` – A layoutdia alakzataihoz tartozó szöveg.
- `getNotesText` – A jegyzetdia alakzataihoz tartozó szöveg.
- `getCommentsText` – A megjegyzésekhez tartozó szöveg.

```java
String presentationPath = "presentation.ppt";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **GYIK**

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy bemutatókat a szövegkinyerés során?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és még a [nagy bemutatókat](/slides/hu/java/open-presentation/) is képes feldolgozni, így alkalmas valós idejű vagy tömeges feldolgozási forgatókönyvekre.

**Képes az Aspose.Slides szöveget kinyerni a táblázatokból és diagrammokból a bemutatókban?**

Igen. Az Aspose.Slides képes szöveget kinyerni sok dián szereplő elemből, beleértve a táblázatokat és a diagramokhoz kapcsolódó objektumokat, így hozzáférhet és elemezheti a gyakori prezentációs struktúrák szöveges tartalmát.

**Szükségem van speciális Aspose.Slides licencre a bemutatók szövegének kinyeréséhez?**

A szöveget a Aspose.Slides ingyenes próbaverziójával is ki lehet nyerni, bár ez [bizonyos korlátozásokkal](/slides/hu/java/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezeléséhez a teljes licenc megvásárlása ajánlott.