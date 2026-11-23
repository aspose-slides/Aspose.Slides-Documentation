---
title: Prezentáció szövegének formázása Pythonon keresztül Java-val
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/python-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illesztés beállítás
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java segítségével. Testreszabhatja a betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhat szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával. Kitér a háttérszínekre, átlátszóságra, karakterközökre, betűtulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szöveg rögzítésére, tabulátorhelyekre és nyelvi beállításokra.

Ha nincs másként feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdése tartalmazza az alább látható szöveget. A diák és az alakzat indexei nullától indulnak. Azokat a példákat, amelyek félkövér részeket választanak, a hatékony formázás, beleértve az örökölt félkövér formázást, használják:

![Példa szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek megtalálásához és kiemeléséhez lásd [Szöveg keresése és cseréje](/slides/hu/python-java/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust egy bekezdés alapértelmezett kiemelési szín beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) metódust az egyedi szövegrészekhez.

A következő példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részekre explicit módon beállított kiemelési színek felülírják ezt az alapértelmezést:

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

    # Állítsa be a kiemelés színét a teljes bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítsa be a háttérszínt **félkövér betűtípussal rendelkező szövegrészeknek**:

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
            # Állítsa be a kiemelés színét a szövegrészhez.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra, sorkizárt stb.

A következő kódrészlet bemutatja, hogyan igazítsa a bekezdést **középre**:

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

## **Betűk igazítása egy soron belül**

Használja a [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) metódust a soron belül különböző betűméretű szövegrészek függőleges igazításához. Ez a beállítás a teljes bekezdésre vonatkozik, és minden sorban vezérli az igazítást.

A következő önálló példa egy dián négy feliratos szövegdobozt hoz létre. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontban, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és a szövegdobozok elég nagyok egy sor megjelenítéséhez.

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

![Összehasonlítás a baseline, felső, középső és alsó betűigazításról vegyes betűméretekkel](font_alignment.png)

A betűigazítás a betűmetrikákon alapul, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan. A példa tartalmaz egy nagybetűt és egy legalsóg betűt is, hogy bemutassa a baseline és az alsó igazítás közti különbséget. A betűtípus elérhetősége, a karakterek típusa és a betűméretek közti különbség befolyásolja az eredményt. A keretméretek, margók, sortávolság, sortörés és az automatikus illesztés szintén hatnak a megjelenésre; a módok összehasonlításához használja ugyanazt a betűtípust és elrendezési beállításokat.

Ez a beállítás különbözik a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) metódustól, amely a vízszintes bekezdésigazítást szabályozza, illetve a [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) metódustól, amely a szövegdoboz függőleges elhelyezkedését határozza meg az alakzaton belül. A [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) metódussal történő felső- vagy alsóindexelés egyes részeket a baseline-hoz képest mozgat, nem a bekezdés soraihoz állítja be a betűigazítást.

## **Szöveg átlátszóság beállítása**

Az átlátszóság a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) színének alfa komponensével szabályozható. Az alábbi példákban a `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazzon átlátszóságot a **teljes bekezdésre**:

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

    # Állítsa be a szöveg kitöltőszínét átlátszó színre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet bemutatja, hogyan alkalmazzon átlátszóságot **félkövér betűtípussal rendelkező szövegrészekre**:

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

## **Karakterköz beállítása szöveghez**

Használja a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közötti térköz növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pontnyi térközt adnak hozzá; negatív értékek szűkítik a szöveget.

Az alábbi Python kód megmutatja, hogyan növelje a karakterközt a **teljes bekezdésben**:

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

    # Megjegyzés: Negatív értékek használata a karakterköz szűkítéséhez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelje a karakterközt **félkövér betűtípussal rendelkező szövegrészekben**:

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
            # Megjegyzés: Negatív értékek használata a karakterköz szűkítéséhez.
            portion.getPortionFormat().setSpacing(3) # Karakterköz növelése.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Specifikus betűtípusok esetén a kerning letiltása**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenített szöveg. Ez akkor fordul elő, ha a PowerPoint figyelmen kívül hagyja egyes betűtípusok kerning adatait, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban a kerning engedélyezve van.

A renderelt kimenet PowerPoint-hoz közelebb hozásához letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első diájának első alakzata egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűtípusokat, és 100 pontos küszöböt állít be a Roboto betűtípust használó részekhez. Ez letiltja a kerninget a 100 pont alatti méretű egyező részeknél:

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

A küszöb alatti szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában az érintett betűtípusok esetén.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) segítségével.

A következő példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Romanra állítja be félkövérrel, dőltel, és pontozott aláhúzással. Az egyes részekre kifejezett formázás felülírja ezeket az alapértelmezéseket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Állítsa be a betűtulajdonságokat a bekezdéshez.
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

![A betűtulajdonságok a bekezdésben](font_properties_for_paragraph.png)

A következő példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja be azokra a részekre, amelyek hatékony formázása félkövér:

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

![A betűtulajdonságok a szövegrészekben](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használja a [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setNormaliseHeight) metódust sablon tipográfia reprodukálásakor vagy a karaktermagasság különbségeinek vizsgálatakor. PowerPointban a normalizálás engedélyezése a karaktereket függőlegesen nyújtja vagy összenyomja, hogy egyenletes látható magasságot érjenek el a szövegrészben. Ez nem garantálja, hogy a különböző betűtípusok szövegmagassága megegyezik.

Állítsa a tulajdonságot [NullableBool.True_ vagy False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) értékre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` helyi beállítást üresen hagyja, így a részörökölheti az értéket, például a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) beállításából. Nem jelenti azt, hogy `False`. Használja a [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) metódust, és olvassa ki a `getNormaliseHeight` értékét a hatékony formázásból a feloldott logikai értékhez.

A következő önálló példa **Arial** betűtípus telepítését igényli. Két szövegblo­kkot hoz létre, amelyek ugyanazokat a nagy- és kisbetűket, legalsó karaktereket és ívelt betűjeleket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezetten engedélyezi a normalizálást. A felső rész kifejezetten letiltja; az alsó örökli. A keretméretek, margók és bekezdésközök azonosak, a sortörés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa `False: False` és `NotDefined: True` értékeket ír ki, majd elmenti a „text_height_normalization.pptx” fájlt.

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

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`False`); az alsó sor örökli az engedélyezett beállítást (`NotDefined` → `True`). Az eredmény reprodukálásához telepítve kell legyen az Arial.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy a hozzárendelt [getFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFontHeight) értéket módosítaná, amely a betűméretet pontban adja meg. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) vezérli a sortávolságot, míg a szövegdoboz [setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) a szöveg vagy a konténer méretezését szabályozza. Ezek a beállítások külön célra szolgálnak, és önállóan befolyásolhatják a teljes elrendezést. A bekezdés formázásáról és öröklődéséről további információkért lásd a [Bekezdések kezelése](/slides/hu/python-java/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használja a [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setStrikethroughType) metódust egy szövegrészre, hogy kijelölje a javításokat, törölt kifejezéseket vagy korábbi árakat anélkül, hogy törölné az eredeti szöveget. Állítsa [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/) értékre egy vagy két áthúzási vonalat a szöveg felett.

Az áthúzás eltávolításához adja meg a [TextStrikethroughType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a hatást, még ha a környező formázás áthúzást is meghatározna. Ezzel szemben a [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/python-java/aspose.slides/textstrikethroughtype/#NotDefined) helyi beállítást elhagyja, így a rész örökölheti a formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás valóban eltávolításra kerül. Használja a [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective) metódust a kapott formázás, beleértve az öröklött értékek, kiolvasásához.

Az alábbi önálló példa három ár-összehasonlítást hoz létre. Minden bekezdésnek külön részei vannak a címke, a korábbi ár és a jelenlegi ár számára, így csak a korábbi ár érintett. Az első sorban alkalmazza, majd eltávolítja az áthúzást; a többi sor egy- és kétszeri áthúzást tart fenn. Ennek a beállításnak a módosítása megőrzi a szöveget és a többi formázást, beleértve a félkövér korábbi árat.

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

    # Alkalmazza a vonalazást, majd kifejezetten eltávolítja az első előző árból.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None_)

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single)
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double)

    presentation.save("strikethrough.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény, felülről lefelé: nincs áthúzás, egyetlen áthúzás és dupla áthúzás.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Szöveg forgatás beállítása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal az óramutató járásával ellentétesen** forgatja a szöveget:

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

![A szöveg forgatás](text_rotation.png)

## **Számjegyek egymás melletti megjelenítése függőleges szövegben**

A kétjegyű szám számjegyeinek függőleges japán címkében való egymás melletti megjelenítéséhez helyezze mindkét számjegyet egy szövegrészbe, és hívja meg a [BasePortionFormat.setKumimoji](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKumimoji) metódust azon a részen. Mindkét címke ebben a példában a [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/#EastAsianVertical) és 40 pontos MS Gothic betűtípust használ. A két címke között csak a számjegyekhez tartozó [NullableBool](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) beállítás különbözik.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Portion, Presentation, SaveFormat, ShapeType, TextVerticalType

Color = jpype.JClass("java.awt.Color")
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    font = FontData("MS Gothic")

    for x, kumimoji in [(120, NullableBool.True_), (360, NullableBool.False_)]:
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        frame = label.addTextFrame("")
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical)

        paragraph = frame.getParagraphs().get_Item(0)
        default_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
        default_format.setLatinFont(font)
        default_format.setEastAsianFont(font)
        default_format.setFontHeight(40)
        default_format.getFillFormat().setFillType(FillType.Solid)
        default_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        digits = Portion("12")
        digits.getPortionFormat().setKumimoji(kumimoji)
        
        portions = paragraph.getPortions()
        portions.clear()
        portions.add(Portion("令和"))
        portions.add(digits)
        portions.add(Portion("年"))

    presentation.save("vertical_date.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

PowerPointban a bal címke (`True`) állították a számjegyeket függőlegesen helyesnek és egymás mellett a 和 és 年 karakterek között. A jobb címke (`False`) esetén a páros 90 fokkal az óramutató járásával megegyezően van elforgatva. A környező japán karakterek mindkét címkén függőlegesen maradnak.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Egyedi forgatás beállítása szövegkeretekhez**

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) metódust egy egyedi forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) elemhez.

Az alábbi kódrészlet a szövegkeretet 3 fokkal az óramutató járásával megegyezően forgatja az alakzaton belül:

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

![Az egyedi szöveg forgatás](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdésközöket. Ezeket a tulajdonságokat a következőképpen használhatja:

* Pozitív értékkel a sortávolságot a sormagasság százalékában adhatja meg.
* Negatív értékkel a sortávolságot pontban adhatja meg.

A következő példa a sortávolságot az első bekezdésen belül 200 %‑ra (dupla sortávolság) állítja be:

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

A bekezdés sortörés szabályai szűk szövegdobozok és vegyes latin‑kelet‑ázsiai szöveget tartalmazó prezentációk esetén hasznosak. Az alábbi módszerek a [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) részei, ezért egész bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) szabályozza a latin sortörési szabályokat. Vegyes szöveg esetén ennek módosítása megváltoztathatja a kelet‑ázsiai szöveg és írásjelek környezetét is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) szabályozza a kelet‑ázsiai sortörési szabályokat, beleértve a sor elején és végén lévő karakterekre vonatkozó korlátozásokat.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) metódust, amely automatikus sortörést engedélyez a szövegdobozon belül. Hatásuk a layoutra érvényesül, ha sortörés történik; nem illesztenek sortörés karaktert. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, majd elmenti a „line_breaking.pptx” fájlt. Az egyes szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűtípusokat használ 160 pont széles kerettel és nulla vízszintes szövegdoboz margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) értékkel van meghívva, hogy a szövegméret és a keret méretei rögzítve maradjanak.

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

## **Függőben lévő írásjelek vezérlése**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a megfelelő írásjelek a sor jobb széle mögé nyúljanak, ahelyett, hogy a következő sorra kerülnének. Ez az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegdobozban engedélyezi a függőben lévő írásjeleket, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial betűtípussal és nulla vízszintes szövegdoboz margóval a végső pont a „sentence” után marad, és túlnyúlik a jobb szövegszegmens szélén. Állítsa a tulajdonságot [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illesztés le van tiltva a rendelkezésre álló szélesség rögzítéséhez.

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

Nem minden írásjel függőképes. Az előzőekben leírt [betű- és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegkeretekhez**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tárolójának határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kiterjedjen vagy automatikusan átméretezze az alakzatot. A következő példa a alakzatot úgy konfigurálja, hogy a szöveghez igazodva méretezze át, és elmenti a „autofit_type.pptx” fájlt.

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy alakzat szélességének változásának megfigyeléséhez lásd a [Megjelenített sorok számlálása](/slides/hu/python-java/manage-paragraph/). A sorok száma önmagában nem mutatja, hogy a szöveg túlnyúlik-e a konténerből.

## **Szövegkeretek rögzítésének beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például felül, középen vagy alul. Az alábbi példa a szöveget az első alakzat aljára rögzíti, és elmenti a „text_anchor.pptx” fájlt.

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

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) metódusokat a bekezdés tabulátorhelyeinek konfigurálásához. Az alábbi példa az alapértelmezett tabulátorszakaszt 100 pontra állítja, és 30 pontnál balra igazított tabulátort ad hozzá. Ezek a beállítások a tabulátor karaktert tartalmazó szövegre hatnak.

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

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) metódussal lehetővé teszi a szövegrész ellenőrző nyelvének beállítását. Az ellenőrző nyelv határozza meg, hogy a PowerPoint milyen nyelven végez helyesírás- és nyelvtani ellenőrzést.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első diáján egy szövegdobozot tartalmaz, és legalább egy bekezdést. Lecseréli az első bekezdés tartalmát „1。”‑re, a betűtípust SimSunra állítja, és a Simplified Chinese (`zh-CN`) ellenőrző nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

    # Állítsa be a helyesírási nyelv azonosítóját.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nyelvi metaadatok másolása**

Többnyelvű szöveg sablonból való másolásakor meg kell őrizni mind a [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getLanguageId), mind a [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getAlternativeLanguageId) értékét. Az alábbi önálló példa egy forrásrészletet hoz létre, amely US English nyelvet használ főnyelvként és French‑t alternatív nyelvként, majd a szöveget és az azonosítókat egy új prezentációban lévő részhez másolja.

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

Ha a forrásnak nincs alternatív nyelve, hagyja ki a `"fr-FR"` érték hozzárendelését. Ebben az esetben az alternatív azonosító `None`, és a másoló utasítás megőrzi ennek hiányát, anélkül hogy alapértelmezett értéket vezetne be, még akkor is, ha a célrésznek korábban már volt alternatív nyelve.

Ezek az azonosítók nyelvi metaadatként tárolódnak. A megőrzésük nem befolyásolja, hogy a PowerPoint melyik szótárt használja a helyesírás- vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a betöltés vagy létrehozás során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa US English nyelvet állít be alapértelmezett szövegnyelvként, szövegdobozt ad hozzá, és az első szövegrészhez `en-US` értéket ír ki.

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

A prezentáció szintjén alapértelmezett szövegformázás alkalmazásához használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa egy 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, majd a „default_text_style.pptx” fájlba menti. A szöveg örökölheti ezeket az alapértékeket, hacsak egy konkrétabb formázás nem felülírja őket.

```python
import jpate
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Szerezze meg a legfelső szintű bekezdésformátumot.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg kinyerése all-caps hatással**

PowerPointban az **All Caps** betűhatás alkalmazása a szöveget nagybetűkkel jeleníti meg a dián, még ha eredetileg kisbetűkkel is lett beírva. Amikor az Aspose.Slides ezzel a szövegrészlettel visszaolvassa a szöveget, a könyvtár a pontosan beírt szöveget adja vissza. A megjelenített szöveghez való illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) értékét, és ha `All` a visszakapott karakterláncot alakítsa nagybetűssé.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján egy szövegdoboz található. Az első bekezdés első része tartalmazza a „Hello, Aspose!” szöveget, amelyre az All Caps hatás alkalmazva van, ahogy az alább látható.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerje ki a szöveget az **All Caps** hatással:

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

A táblázat szövegének módosításához a dián használja a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse a cellákat a [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) segítségével, a bekezdés formázását pedig a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) metódussal.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenetes szöveghez használja a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) értékét a [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) típusra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.