---
title: Haladó szövegkivonás prezentációkból Pythonon keresztül Java-ral
linktitle: Szöveg kinyerése
type: docs
weight: 90
url: /hu/python-java/extract-text-from-presentation/
keywords:
- szöveg kinyerése
- szöveg kinyerése a diáról
- szöveg kinyerése a prezentációból
- szöveg kinyerése PowerPointból
- szöveg kinyerése OpenDocumentből
- szöveg kinyerése PPT‑ből
- szöveg kinyerése PPTX‑ből
- szöveg kinyerése ODP‑ből
- szöveg lekérése
- szöveg lekérése a diáról
- szöveg lekérése a prezentációból
- szöveg lekérése PowerPointból
- szöveg lekérése OpenDocumentből
- szöveg lekérése PPT‑ből
- szöveg lekérése PPTX‑ből
- szöveg lekérése ODP‑ből
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Gyorsan nyerj ki szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Python via Java használatával. Kövesd egyszerű, lépésről‑lépésre útmutatónkat, hogy időt takaríts meg."
---
## **Áttekintés**

A prezentációkból szöveget kinyerni gyakori, ugyanakkor elengedhetetlen feladat a diatartalommal dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal (PPT vagy PPTX formátumban), akár OpenDocument prezentációkkal (ODP) dolgozol, a szöveges adatok elérése és lekérdezése kritikus lehet elemzés, automatizálás, indexelés vagy tartalom‑migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for Python via Java használatával. Megtanulod, hogyan iterálj rendszerezetten a prezentációelemeken a szükséges szövegtartalom pontos lekérdezéséhez.

## **Szöveg kinyerése egy diáról**

Az Aspose.Slides for Python via Java biztosítja a [SlideUtil](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust kínál a prezentáció vagy dia teljes szövegének kinyerésére. Egy diához tartozó szöveg kinyeréséhez a [SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#getAllTextBoxes) metódust kell használni. Ez a metódus egy [BaseSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/) típusú objektumot fogad paraméterként. Végrehajtáskor a metódus a teljes diát bejárja a szöveg után, és egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) típusú objektumok tömbjét adja vissza, megőrizve a szöveg formázását.

Az alábbi kódrészlet a prezentáció első diáján lévő összes szöveget nyeri ki:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

slide_index = 0

presentation = Presentation("demo.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    text_frames = SlideUtil.getAllTextBoxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Szöveg kinyerése egy prezentációból**

A teljes prezentáció szövegének beolvasásához használd a [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#getAllTextFrames) statikus metódust, amely a [SlideUtil](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/) osztályban érhető el. Két paramétert fogad:

1. Először egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektum, amely egy PowerPoint vagy OpenDocument prezentációt képvisel, ahonnan a szöveget ki kell nyerni.
2. Másodszor egy `bool` érték, amely azt jelzi, hogy a mesterdiák is bele legyenek foglalva a prezentáció szövegének beolvasásakor.

A metódus egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) típusú objektumok tömbjét adja vissza, amely tartalmazza a szöveg formázási információit is. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mesterdiákat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil

presentation = Presentation("demo.pptx")
try:
    include_master_slides = True
    text_frames = SlideUtil.getAllTextFrames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.getParagraphs():
            for portion in paragraph.getPortions():
                portion_text = portion.getText()
                print(portion_text)

                portion_format = portion.getPortionFormat()
                font_height = portion_format.getFontHeight()
                print(font_height)

                latin_font = portion_format.getLatinFont()
                if latin_font is not None:
                    font_name = latin_font.getFontName()
                    print(font_name)
finally:
    presentation.dispose()
```

## **Kategorizált és gyors szövegkivonás**

A [PresentationFactory](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationfactory/) osztály szintén rendelkezik módszerekkel a prezentációkból származó összes szöveg kinyerésére:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationFactory, TextExtractionArrangingMode
from java.io import FileInputStream

mode = TextExtractionArrangingMode.Unarranged
load_options = LoadOptions()

# Kinyeri a szöveget egy fájlból.
file_text = PresentationFactory.getInstance().getPresentationText("presentation.pptx", mode)

# Kinyeri a szöveget egy adatfolyamból.
stream = FileInputStream("presentation.pptx")
try:
    stream_text = PresentationFactory.getInstance().getPresentationText(stream, mode)
finally:
    stream.close()

# Kinyeri a szöveget egy adatfolyamból betöltési beállításokkal.
stream_with_options = FileInputStream("presentation.pptx")
try:
    stream_text_with_options = PresentationFactory.getInstance().getPresentationText(stream_with_options, mode, load_options)
finally:
    stream_with_options.close()
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textextractionarrangingmode/) felsorolt típusú argumentum jelzi a szövegkivonás eredményének rendezési módját, és a következő értékekre állítható:

- [Unarranged](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textextractionarrangingmode/#Unarranged) – A nyers szöveg a dia pozíciójától függetlenül.
- [Arranged](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textextractionarrangingmode/#Arranged) – A szöveg ugyanabban a sorrendben van elrendezve, mint a dián.

A nem rendezett mód akkor használható, amikor a sebesség kritikus; gyorsabb, mint a rendezett mód.

[PresentationText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationtext/) a prezentációból kinyert nyers szöveget képviseli. A [getSlidesText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentationtext/#getSlidesText) metódusa egy `SlideText` típusú objektumok tömbjét adja vissza. Minden objektum a megfelelő dián lévő szöveget reprezentálja. A `SlideText` típusú objektumnak a következő metódusai vannak:

- `getText` – A dia alakzatain belüli szöveg.
- `getMasterText` – A kapcsolódó mesterdia alakzatain belüli szöveg.
- `getLayoutText` – A kapcsolódó elrendezésdia alakzatain belüli szöveg.
- `getNotesText` – A kapcsolódó jegyzetdia alakzatain belüli szöveg.
- `getCommentsText` – A diához kapcsolódó megjegyzések szövege.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, TextExtractionArrangingMode

presentation_path = "presentation.ppt"
arranging_mode = TextExtractionArrangingMode.Unarranged
presentation_text = PresentationFactory.getInstance().getPresentationText(presentation_path, arranging_mode)
first_slide_text = presentation_text.getSlidesText()[0]

print(first_slide_text.getText())
print(first_slide_text.getLayoutText())
print(first_slide_text.getMasterText())
print(first_slide_text.getNotesText())
print(first_slide_text.getCommentsText())
```

## **FAQ**

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat szövegkivonás közben?**

Az Aspose.Slides magas teljesítményre van optimalizálva, és még [nagy prezentációkat](/slides/hu/python-java/open-presentation/) is képes feldolgozni, így alkalmas valós idejű vagy tömeges feldolgozási helyzetekben.

**Képes az Aspose.Slides szöveget kinyerni a táblázatokból és diagramokból a prezentációkban?**

Igen. Az Aspose.Slides számos diáselemből képes szöveget kinyerni, beleértve a táblázatokat és a diagramokkal kapcsolatos objektumokat, így hozzáférhetsz és elemezheted a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van speciális Aspose.Slides licencre a prezentációk szövegkivonásához?**

A szöveget a Aspose.Slides ingyenes próbaverziójával is ki tudod nyerni, bár ez [bizonyos korlátozásokkal](/slides/hu/python-java/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezelése esetén a teljes licenc megvásárlása ajánlott.