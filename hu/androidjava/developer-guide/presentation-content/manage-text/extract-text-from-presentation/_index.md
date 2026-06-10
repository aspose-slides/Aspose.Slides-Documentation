---
title: Speciális szövegkinyerés prezentációkból Androidon
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/androidjava/extract-text-from-presentation/
keywords:
- szöveg kinyerése
- szöveg kinyerése a diáról
- szöveg kinyerése a prezentációból
- szöveg kinyerése PowerPoint-ból
- szöveg kinyerése OpenDocument-ból
- szöveg kinyerése PPT-ből
- szöveg kinyerése PPTX-ből
- szöveg kinyerése ODP-ből
- szöveg lekérése
- szöveg lekérése a diáról
- szöveg lekérése a prezentációból
- szöveg lekérése PowerPoint-ból
- szöveg lekérése OpenDocument-ból
- szöveg lekérése PPT-ből
- szöveg lekérése PPTX-ből
- szöveg lekérése ODP-ből
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Gyorsan nyerje ki a szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Android via Java használatával. Kövesse egyszerű, lépésről‑lépésre útmutatónkat az időmegtakarítás érdekében."
---
## **Áttekintés**

A prezentációkból származó szöveg kinyerése gyakori, ugyanakkor alapvető feladat a diatartalommal dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal dolgozol PPT vagy PPTX formátumban, akár OpenDocument prezentációkkal (ODP), a szöveges adatok elérése és kinyerése döntő fontosságú lehet elemzés, automatizálás, indexelés vagy tartalom‑migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for Android via Java segítségével. Megtanulod, hogyan iterálhatsz rendszeresen a prezentációelemeken, hogy pontosan visszanyerd a szükséges szövegtartalmat.

## **Szöveg kinyerése egy diából**

Az Aspose.Slides for Android via Java biztosítja a [SlideUtil](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust kínál a teljes szöveg kinyerésére egy prezentációból vagy diából.  
A prezentáció egy diájának szövegének kinyeréséhez használd a [getAllTextBoxes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) metódust. Ez a metódus egy [IBaseSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseslide/) típusú objektumot vár paraméterként. Végrehajtáskor a metódus bejárja az egész diát szöveg után, és egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, megtartva a szövegformázást.

Az alábbi kódrészlet kinyeri a teljes szöveget a prezentáció első diájáról:

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

## **Szöveg kinyerése egy prezentációból**

A teljes prezentáció szövegének beolvasásához használd a [getAllTextFrames](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) statikus metódust, amelyet a [SlideUtil](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/) osztály biztosít. Két paramétert fogad:

1. Először egy [IPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/) objektum, amely PowerPoint vagy OpenDocument prezentációt képvisel, amelyből a szöveget ki kell nyerni.  
1. Másodszor egy `boolean` érték, amely azt jelzi, hogy a mesterdiák is bele legyenek vonva a szöveg beolvasásakor.

A metódus egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mesterdiákat.

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

## **Kategorizált és gyors szöveg kinyerés**

A [PresentationFactory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentationfactory/) osztály szintén biztosít módszereket a prezentációkból származó teljes szöveg kinyerésére:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

[TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textextractionarrangingmode/) enumerációs argumentum határozza meg a szövegkinyerési eredmény rendezésének módját, és a következő értékekre állítható:
- `Unarranged` - A nyers szöveg a dia pozíciójától függetlenül.  
- `Arranged` - A szöveg a dián lévő sorrendnek megfelelően van rendezve.

A nem rendezett mód akkor használható, amikor a gyorsaság kritikus; gyorsabb, mint a rendezett mód.

[IPresentationText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentationtext/) a prezentációból kinyert nyers szöveget képviseli. A `getSlidesText` metódusa egy [ISlideText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidetext/) típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét képviseli. Az [ISlideText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/islidetext/) típusú objektumnak a következő metódusai vannak:
- `getText` - A dia alakzatain belüli szöveg.  
- `getMasterText` - A mesterdia alakzatain belüli szöveg, amely ehhez a diához kapcsolódik.  
- `getLayoutText` - A layoutdia alakzatain belüli szöveg, amely ehhez a diához kapcsolódik.  
- `getNotesText` - A jegyzetdia alakzatain belüli szöveg, amely ehhez a diához kapcsolódik.  
- `getCommentsText` - A megjegyzésekben szereplő szöveg, amely ehhez a diához kapcsolódik.

```java
String presentationPath = "presentation.pptx";
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

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat szövegkinyerés közben?**  
Az Aspose.Slides nagy teljesítményre van optimalizálva, és képes még a [nagy prezentációk](/slides/hu/androidjava/open-presentation/) feldolgozására is, ami alkalmas valós idejű vagy tömeges feldolgozási forgatókönyvekre.

**Képes az Aspose.Slides szöveget kinyerni a táblázatokból és diagramokból a prezentációkban?**  
Igen. Az Aspose.Slides képes szöveget kinyerni a diák számos eleméből, beleértve a táblázatokat és diagramokkal kapcsolatos objektumokat, így hozzáférhetsz és elemezheted a szöveges tartalmat a szokásos prezentációs struktúrákban.

**Szükségem van speciális Aspose.Slides licencre a prezentációk szövegének kinyeréséhez?**  
A szöveget a Aspose.Slides ingyenes próbaverziójával is ki tudod nyerni, bár ez [bizonyos korlátozásokkal](/slides/hu/androidjava/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezelésehez ajánlott a teljes licenc megvásárlása.