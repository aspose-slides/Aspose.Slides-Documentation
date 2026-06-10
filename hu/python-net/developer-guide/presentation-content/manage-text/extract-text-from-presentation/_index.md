---
title: "Speciális szövegkivonás prezentációkból Python nyelven"
linktitle: "Szöveg kivonása"
type: docs
weight: 90
url: /hu/python-net/extract-text-from-presentation/
keywords:
- "szöveg kivonása"
- "szöveg kivonása diáról"
- "szöveg kivonása prezentációból"
- "szöveg kivonása PowerPointból"
- "szöveg kivonása OpenDocumentből"
- "szöveg kivonása PPT-ből"
- "szöveg kivonása PPTX-ből"
- "szöveg kivonása ODP-ből"
- "szöveg lekérése"
- "szöveg lekérése diáról"
- "szöveg lekérése prezentációból"
- "szöveg lekérése PowerPointból"
- "szöveg lekérése OpenDocumentből"
- "szöveg lekérése PPT-ből"
- "szöveg lekérése PPTX-ből"
- "szöveg lekérése ODP-ből"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Gyorsan kinyerhet szöveget PowerPoint és OpenDocument prezentációkból az Aspose.Slides for Python via .NET használatával. Kövesse egyszerű, lépésről lépésre útmutatónkat az idő megtakarítása érdekében."
---
## **Áttekintés**

A prezentációkból szöveg kinyerése gyakori, ugyanakkor alapvető feladat a dia tartalmával dolgozó fejlesztők számára. Akár Microsoft PowerPoint fájlokkal PPT vagy PPTX formátumban dolgozol, akár OpenDocument prezentációkkal (ODP), a szöveges adatok elérése és kinyerése kritikus lehet elemzés, automatizálás, indexelés vagy tartalom‑migráció céljából.

Ez a cikk átfogó útmutatót nyújt arról, hogyan lehet hatékonyan kinyerni a szöveget különböző prezentációformátumokból, beleértve a PPT, PPTX és ODP formátumokat, az Aspose.Slides for Python via .NET segítségével. Megtanulod, hogyan lehet rendszerszerűen végigjárni a prezentációelemeket a szükséges szövegtartalom pontos lekéréséhez.

## **Szöveg kinyerése egy diáról**

Aspose.Slides for Python via .NET biztosítja a [aspose.slides.util](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/) névteret, amely tartalmazza a [SlideUtil](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/) osztályt. Ez az osztály több túlterhelt statikus metódust tesz elérhetővé a teljes szöveg kinyerésére egy prezentációból vagy diából. Egy diából való szövegkivonáshoz egy prezentációban, használd a [get_all_text_boxes](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) metódust. Ez a metódus egy [BaseSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/) típusú objektumot fogad paraméterként. Végrehajtáskor a metódus átvizsgálja az egész diát a szöveg után, és egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) típusú objektumok tömbjét adja vissza, megtartva a szövegformázást.

Az alábbi kódrészlet kinyeri a prezentáció első diáján lévő összes szöveget:

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("demo.pptx") as presentation:
    slide = presentation.slides[slide_index]

    text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Szöveg kinyerése egy prezentációból**

Az egész prezentáció szövegének beolvasásához használd a [SlideUtil](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/) osztály által biztosított [get_all_text_frames](https://reference.aspose.com/slides/hu/python-net/aspose.slides.util/slideutil/get_all_text_frames/) statikus metódust. Két paramétert fogad:

1. Először egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumot, amely a kinyerni kívánt szöveget tartalmazó PowerPoint vagy OpenDocument prezentációt reprezentálja.
1. Másodszor egy `Boolean` értéket, amely azt jelzi, hogy a mester diák is bele legyenek vonva a prezentáció szövegének beolvasásakor.

A metódus egy [TextFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/) típusú objektumok tömbjét adja vissza, beleértve a szövegformázási információkat. Az alábbi kód beolvassa a szöveget és a formázási részleteket egy prezentációból, beleértve a mester diákat.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    include_master_slides = True
    text_frames = slides.util.SlideUtil.get_all_text_frames(presentation, include_master_slides)

    for text_frame in text_frames:
        for paragraph in text_frame.paragraphs:
            for portion in paragraph.portions:
                portion_text = portion.text
                print(portion_text)

                portion_format = portion.portion_format
                font_height = portion_format.font_height
                print(font_height)

                latin_font = portion_format.latin_font
                if latin_font is not None:
                    font_name = latin_font.font_name
                    print(font_name)
```

## **Kategorizált és gyors szövegkivonás**

A [PresentationFactory](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationfactory/) osztály szintén biztosít módszereket a prezentációkból való teljes szövegkivonáshoz:

```py
PresentationFactory.get_presentation_text(file, mode)
PresentationFactory.get_presentation_text(stream, mode)
PresentationFactory.get_presentation_text(stream, mode, options)
```

A [TextExtractionArrangingMode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textextractionarrangingmode/) felsorolás argumentuma jelzi a szövegkivonási eredmény rendezésének módját, és a következő értékek közül állítható be:
- `UNARRANGED` – A nyers szöveg a dia pozíciójától függetlenül.
- `ARRANGED` – A szöveg a diához hasonló sorrendben van rendezve.

A `UNARRANGED` mód akkor használható, amikor a sebesség kritikus; gyorsabb a `ARRANGED` móddal szemben.

A [PresentationText](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentationtext/) a prezentációból kinyert nyers szöveget képviseli. `slides_text` tulajdonsága egy diaszöveg objektumok tömbjét adja vissza. Minden objektum a megfelelő dia szövegét reprezentálja, és a következő tulajdonságokkal rendelkezik:
- `text` – A dián lévő alakzatok szövege.
- `master_text` – A mester dia alakzataiban lévő szöveg, amely ehhez a diához tartozik.
- `layout_text` – Az elrendezés dia alakzataiban lévő szöveg, amely ehhez a diához tartozik.
- `notes_text` – A jegyzet dia alakzataiban lévő szöveg, amely ehhez a diához tartozik.
- `comments_text` – A diához tartozó kommentek szövege.

```py
import aspose.slides as slides

presentation_path = "presentation.ppt"
arranging_mode = slides.TextExtractionArrangingMode.UNARRANGED
presentation_text = slides.PresentationFactory.instance.get_presentation_text(presentation_path, arranging_mode)
first_slide_text = presentation_text.slides_text[0]

print(first_slide_text.text)
print(first_slide_text.layout_text)
print(first_slide_text.master_text)
print(first_slide_text.notes_text)
print(first_slide_text.comments_text)
```

## **GYIK**

**Milyen gyorsan dolgozza fel az Aspose.Slides a nagy prezentációkat szövegkivonás során?**

Az Aspose.Slides nagy teljesítményre van optimalizálva, és még a [nagy prezentációkat](/slides/hu/python-net/open-presentation/) is képes feldolgozni, így alkalmas valós időben vagy tömeges feldolgozási forgatókönyvekre.

**Kivonhat-e az Aspose.Slides szöveget táblázatokból és diagramokból a prezentációkban?**

Igen. Az Aspose.Slides sok dián szereplő elemből tud szöveget kivonni, beleértve a táblázatokat és a diagramokhoz kapcsolódó objektumokat, így hozzáférhetsz és elemezheted a szöveges tartalmat a gyakori prezentációs struktúrákban.

**Szükségem van speciális Aspose.Slides licencre a prezentációkból való szövegkivonáshoz?**

A szöveget a Aspose.Slides ingyenes próbaverziójával is ki tudod nyerni, bár ez [bizonyos korlátozásokkal](/slides/hu/python-net/licensing/) jár, például csak korlátozott számú dia feldolgozásával. Korlátlan használathoz és nagyobb prezentációk kezeléséhez ajánlott teljes licencet vásárolni.