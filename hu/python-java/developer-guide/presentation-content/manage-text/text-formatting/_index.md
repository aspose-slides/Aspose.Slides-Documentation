---
title: Prezentáció szövegének formázása Python via Java
linktitle: Szöveg formázás
type: docs
weight: 50
url: /hu/python-java/text-formatting/
keywords:
- bekezdés igazítása
- szöveg stílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sorköz
- automatikus illesztés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával. Kitérünk a háttérszínekre, átlátszóságra, karakterközökre, betűtulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Kivéve, ha másként szerepel, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakja egy szövegdoboz, és az első bekezdése a lent látható szöveget tartalmazza. A diák és alakok indexei nullával kezdődnek. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések kereséséhez és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/python-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használd a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) metódust egyedi szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részekre vonatkozó explicit kiemelési színek elsőbbséget élveznek ezen alapértelmezéssel szemben:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Állítsa be az egész bekezdés kiemelő színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szövegrészek** számára:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Állítsa be a szövegrész kiemelési színét.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használd a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet megmutatja, hogyan igazítsuk a bekezdést **középre**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Állítsa be a bekezdés igazítását középre.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az igazított bekezdés](aligned_paragraph.png)

## **Betűtípusok igazítása egy soron belül**

Használd a [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás a teljes bekezdésre vonatkozik, és a soroknál szabályozza az igazítást.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos mérettel, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és a szövegkereteket elég nagyra állítja egyetlen sorhoz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az alapvonal, felső, középső és alsó betűtárgy igazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákat használ, így az egyes betűk látható szélén nem feltétlenül illeszkedik pontosan. A példa tartalmaz egy nagybetűt és egy alsókaraktert, hogy bemutassa a különbséget az alapvonal és az alsó igazítás között. A betűtípuskészlet és helyettesítés, a használt karakterek és a betűméretek közti különbség befolyásolja az eredményt. A keretméretek, margók, sorköz, sortörés és automatikus illesztés szintén hatnak a megjelenésre; a módok összehasonlításakor ugyanazokat a betűket és elrendezési beállításokat használd.

Ez a beállítás különbözik a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) metódustól, amely a vízszintes bekezdésigazítást szabályozza, valamint a [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) metódustól, amely a szöveggörgető blokk függőleges pozícióját állítja be az alakban. A felső és alsó indexelés a [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) segítségével egyes szövegrészeket elmozdít a baseline-hez képest, ahelyett, hogy a bekezdés sorainak betűigazítását állítaná be.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) színének alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet megmutatja, hogyan alkalmazz átlátszóságot a **teljes bekezdésre**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Állítsa be a szöveg kitöltő színét átlátszó színre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő példakód azt mutatja, hogyan alkalmazz átlátszóságot **félkövér betűtípusú szövegrészekre**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Állítsa be a szövegrész átlátszóságát.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása a szöveghez**

Használd a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pontnyi távolságot adnak hozzá; a negatív értékek összehúzzák a szöveget.

Az alábbi Python kód megmutatja, hogyan növelhető a karakterköz **a teljes bekezdésben**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

A következő kódrészlet azt mutatja, hogyan növelhető a karakterköz **félkövér betűtípusú szövegrészekben**:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
            portion.getPortionFormat().setSpacing(3) # Karakterköz növelése.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabbnak tűnhet, mint a PowerPointban megjelenő szöveg. Ennek oka lehet, hogy a PowerPoint figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információkat, és a kerning engedélyezve van a PowerPoint beállításaiban.

Az ilyen esetekben a renderelt kimenet PowerPoint-hoz való közelebb hozásához letilthatod a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsd a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek első alakja egy szövegdoboz az első dián. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto betűtípust használó részeknél. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alacsonyabb küszöb alatt a megfelelő szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez való igazításában a PowerPoint-specifikus viselkedés által érintett betűtípusoknál.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók a bekezdés szintjén a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja be, félkövér, dőlt és pontozott aláhúzással. Az egyes részekre vonatkozó explicit formázás elsőbbséget élvez ezeken az alapértelmezéseken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Állítsa be a bekezdés betűtulajdonságait.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A betűtulajdonságok a bekezdéshez](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja a **félkövér** hatékony formázású részekre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # Állítsa be a betűtulajdonságokat a szövegrészhez.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A betűtulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használd a [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) metódust, amikor sablon tipográfiát reprodukálunk vagy a karaktermagasság különbségeit vizsgáljuk. PowerPointban a normalizálás engedélyezése függőlegesen nyújtja vagy tömöríti az egyes karaktereket, hogy egységes látható magasságot kapjanak a szövegrészben. Ez nem garantálja, hogy különböző betűtípusok esetén a szövegmagasság egyenlő legyen.

Állítsd a tulajdonságot [NullableBool.True_ vagy False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) értékekre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` érték meghagyja a helyi beállítást beállítatlanul, így a részörökli azt például a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódusától. Ez nem azt jelenti, hogy `False`. Használd a [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) metódust, és olvasd ki a `getNormaliseHeight` értékét a visszaadott hatékony formázásból a feloldott logikai értékhez.

Az alábbi önálló példa **Arial** betűtípus telepítését feltételezi. Két szövegb blokkot hoz létre, amelyek ugyanazokat a nagybetűket, kisbetűket, alsókaraktereket és ékezetes karaktereket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső rész explicit módon letiltja, az alsó rész örökli. A keretméretek, margók és bekezdésközök azonosak, a sortörés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa kiírja a `False: False` és `NotDefined: True` értékeket, majd elmenti a **text_height_normalization.pptx** fájlt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    settings = [NullableBool.False_, NullableBool.NotDefined]
    setting_names = ["False", "NotDefined"]

    for i, setting in enumerate(settings):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.setText("Hxgjpq ÅÉ 0123")
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setMarginTop(0)
        text_frame.getTextFrameFormat().setMarginLeft(0)

        paragraph = text_frame.getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        paragraph.getParagraphFormat().setSpaceWithin(100)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True_)

        portion = paragraph.getPortions().get_Item(0)
        font = FontData("Arial")
        portion.getPortionFormat().setLatinFont(font)
        portion.getPortionFormat().setFontHeight(54)
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
        portion.getPortionFormat().setNormaliseHeight(setting)

        print(f"{setting_names[i]}: {bool(portion.getPortionFormat().getEffective().getNormaliseHeight())}")

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`False`); az alsó sor örökli az engedélyezett beállítást (`NotDefined` → `True`). Az Arial legyen telepítve a megjelenés reprodukálásához.

![Arial 54-pontos szöveg normalizálással letiltva felül és örökölt normalizálással alul](text_height_normalization.png)

A normalizálás megváltoztatja a karaktermagasságot anélkül, hogy a hozzárendelt [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) értéket módosítaná, amely a betűméretet pontban adja meg. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) kontrollálja a sortávolságot, míg a szövegkeret [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) szabályozza, hogy a szöveg vagy annak tárolója hogyan igazodjon. Ezek a beállítások különböző célokra szolgálnak, és önállóan befolyásolhatják az elrendezést. További információkért a bekezdés formázásáról és öröklődéséről lásd a [Bekezdés kezelése](/slides/hu/python-java/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használd a [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) metódust egy szövegrészre, hogy megjelenítsd a javításokat, törölt kifejezéseket vagy korábbi árakat anélkül, hogy törölnéd az eredeti szöveget. Állítsd be a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez a szövegben.

Az áthúzás eltávolításához add át a [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a hatást, még akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) érték meghagyja a helyi beállítást meghatározatlanul, lehetővé téve a részörökletes formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás eltávolításra kerül. Használd a [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) metódust a végeredmény formázásának, köztük az örökölt értékeknek az olvasásához.

Az alábbi önálló példa három ár összehasonlítást hoz létre. Minden bekezdésben külön részek vannak a címke, a korábbi ár és a jelenlegi ár számára, így csak a korábbi ár érintett. Az első sor alkalmazza, majd eltávolítja az áthúzást; a többi sor egy- és dupla áthúzást tartalmaz. Ennek a beállításnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextStrikethroughType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220)
    shape.getFillFormat().setFillType(FillType.NoFill)
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    shape.getTextFrame().getParagraphs().clear()

    labels = ["None: ", "Single: ", "Double: "]

    for label in labels:
        paragraph = Paragraph()
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().setSpaceAfter(20)

        portion_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        portion_format.setFontHeight(28)
        font = FontData("Arial")
        portion_format.setLatinFont(font)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        label_portion = Portion(label)
        paragraph.getPortions().add(label_portion)

        previous_price = Portion("$100")
        previous_price.getPortionFormat().setFontBold(NullableBool.True_)
        paragraph.getPortions().add(previous_price)
        current_price = Portion(" → $80")
        paragraph.getPortions().add(current_price)

        shape.getTextFrame().getParagraphs().add(paragraph)

    paragraphs = shape.getTextFrame().getParagraphs()

    # Alkalmazza az áthúzást, majd kifejezetten távolítsa el az első korábbi árból.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény, felülről lefelé: áthúzás nélkül, egy vonallal, és dupla vonallal.

![Korábbi árak áthúzás nélkül, egy vonallal és dupla vonallal](strikethrough.png)

## **Szöveg forgatása**

Használd a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust, hogy előre definiált szövegtájolást állíts be egy alakban.

Az alábbi kódrészlet a szöveg tájolását a shape-ban a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használd a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) metódust, hogy egyedi forgatásszöget állíts be egy [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal óramutató járásával megegyező irányban forgatja a shape-ban:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az egyéni szöveg forgatása](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal biztosítja a bekezdésközök szabályozását. Ezeket a tulajdonságokat a következőképpen használjuk:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a első bekezdés sortávolságát a sormagasság 200%-ára (dupla sortávolság) állítja be:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Sortörés vezérlése**

A bekezdés sortörés szabályai szűk szövegblokkok és a latin és kelet-ázsiai szövegeket keverő prezentációk esetén hasznosak. Az alábbi módszerek a [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) részei, így egy teljes bekezdésre alkalmazandók:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) szabályozza a latin sortörés szabályait. Vegyes szöveg esetén ennek módosítása megváltoztathatja a kelet-ázsiai szöveg és írásjelek sortörését is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) szabályozza a kelet-ázsiai sortörés szabályait, beleértve a sor elején és végén megengedett karaktereket.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) metódust, amely engedélyezi az automatikus sortörést egy szövegkereten belül. A sortörés szabályok befolyásolják az elrendezést, ha sortörés történik; nem illesztenek be sortörés karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy keskeny szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörés opciót explicit módon beállítja, és elmenti a **line_breaking.pptx** fájlt. A szabályok egyikének kísérletezéséhez módosítsd a megfelelő értéket, miközben a másik beállítást változatlanul hagyod. A példa 24 pontos Arial és SimSun betűtípust használ 160 pontos keretszélességgel és nulla vízszintes szövegkeret-margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) metódus a [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) értékre van állítva, így a szöveg mérete és a keret mérete rögzített marad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Függőleges írásjel felfüggesztése**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a jogosult írásjelek a sor jobb szélén túlnyúljanak a következő sor helyett. Ez az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a felfüggesztett írásjelet, és elmenti a **hanging_punctuation.pptx** fájlt. 24 pontos Arial és nulla vízszintes szövegkeret-margó mellett a végpont a "sentence" után marad, és túlnyúlik a jobb szövegélén. Állítsd a tulajdonságot [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezen beállításokkal a pont külön sorra kerül. A sortörés engedélyezett, az automatikus illesztés letiltott a rendelkezésre álló szélesség rögzítése érdekében.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nem minden írásjel felfüggeszthető. A fent leírt [betű- és elrendezési feltételek](#control-line-breaking) szintén alkalmazandók erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) meghatározza, hogy a szöveg hogyan viselkedjen, ha meghaladja a tároló határait. Használd a szöveg zsugorításának, kifolyásának vagy az alak automatikus átméretezésének vezérlésére. Az alábbi példa úgy konfigurálja az alakot, hogy a szöveghez igazodva átméretezze, és elmenti az eredményt **autofit_type.pptx** néven.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az automatikus sortörés után a sorok számának meghatározásához és a szöveg vagy az alak szélességének változásának megtekintéséhez lásd a [Renderelt sorok számlálása](/slides/hu/python-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg kifolyik-e a tárolóból.

## **Szövegkeretek rögzítési pontjának beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza a szöveg függőleges elhelyezkedését egy alakban, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alak aljára rögzíti, és elmenti a **text_anchor.pptx** fájlt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg tabulációjának beállítása**

Használd a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) metódusokat a tabulátorok konfigurálásához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátort 100 pont, és egy balra igazított tabulátort 30 pontnál állít be. Ezek a beállítások a tabulátor karaktereket tartalmazó szövegre hatnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Lektoráló nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) metódussal lehetővé teszi, hogy egy szövegrész lektoráló nyelvét állítsd be. A lektoráló nyelv határozza meg a PowerPoint helyesírás- és nyelvtan-ellenőrzéséhez használt nyelvet.

Az alábbi példa a **presentation.pptx** fájlt igényli, amelynek első alakja egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. Lecseréli az első bekezdés tartalmát a "1。" szövegre, a betűtípust SimSunra állítja, és a Simplified Chinese (`zh-CN`) lektoráló nyelvet rendeli hozzá. Az eredményt a **proofing_language.pptx** fájlba menti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # Állítsa be a lektoráló nyelv azonosítóját.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nyelvi metaadatok másolása**

Többnyelvű szöveg sablonból való másolásakor őrizd meg mind a [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId), mind a [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) értékeket. Az alábbi önálló példa egy forrásrészletet hoz létre, amely US English nyelvet használ elsődleges nyelvként, és French nyelvet alternatív nyelvként, majd a szöveget és az azonosítókat egy új prezentációban egy részlethez másolja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Portion, Presentation, SaveFormat, ShapeType

source = Portion("Hello! Bonjour!")
source.getPortionFormat().setLanguageId("en-US")
source.getPortionFormat().setAlternativeLanguageId("fr-FR")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    destination = Portion()
    destination.setText(source.getText())
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId())
    # Ha a forrásnak nincs alternatív nyelve, a None törli a cél értékét.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId())
    paragraph.getPortions().add(destination)

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ha egy forrást akarsz tesztelni alternatív nyelv nélkül, hagyd el a `"fr-FR"` hozzárendelését. Az alternatív azonosító ekkor `None`, és ugyanaz a másolási utasítás megőrzi a hiányát anélkül, hogy alapértelmezett értéket vezetne be, még akkor is, ha a célhelyen korábban már meghatározott alternatív nyelv volt.

Ezek az azonosítók nyelvi metaadatként tárolódnak. Azok megőrzése nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás- vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használd a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelve az US English, hozzáad egy szövegdobozt, és az első szövegrész nyelvét `en-US`‑ként írja ki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # Adjunk hozzá egy téglalap alakzatot szöveggel.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Ellenőrizze az első szövegrész nyelvét.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás prezentációs szinten történő alkalmazásához használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, és elmenti a **default_text_style.pptx** fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nem felülírja őket egy specifikusabb formázás.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Szerezze meg a felső szintű bekezdésformátumot.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg kinyerése all-caps hatással**

PowerPointban a **All Caps** betűhatás alkalmazása miatt a szöveg nagybetűként jelenik meg a dián, még ha eredetileg kisbetűs formában írták be is. Amikor egy ilyen szövegrészt az Aspose.Slides visszaad, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való igazításhoz ellenőrizd a [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) értékét, és ha `All` értékre van állítva, konvertáld a visszakapott karakterláncot nagybetűssé.

Ez a példa a **sample2.pptx** fájlt igényli, amelynek első alakja egy szövegdoboz az első dián. Az első bekezdés első része a "Hello, Aspose!" szöveget tartalmazza, amelyre az All Caps hatás alkalmazva van, az alábbiak szerint:

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a **All Caps** hatással formázott szöveg:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosíthatom a táblázat szövegét egy dián?**

A táblázat szövegének módosításához egy dián használja a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/). Iteráljon a cellákon, és frissítse az egyes cellákat a [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) és a bekezdés formázását a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) segítségével.

**Hogyan alkalmazhatok gradient színt a szövegre egy PowerPoint dián?**

A gradient szín alkalmazásához a szövegre használd a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsd a [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) értékét a [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) típusra, és konfiguráld a gradient állomásokat, irányt és átlátszóságot.