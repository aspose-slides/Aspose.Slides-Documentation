---
title: Prezentáció szövegének formázása Pythonon keresztül Java használatával
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/python-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatás
- forgatási szög
- szövegkeret
- sortávolság
- automatikus méretezés tulajdonság
- szövegkeret rögzítés
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java segítségével. Testreszabja betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Python via Java használatával. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtípus‑tulajdonságokra, forgatásra, bekezdés‑távolságra, automatikus méretezési viselkedésre, szövegtörzs rögzítésre, tabulátor‑állomásokra és nyelvi beállításokra.

Kivéve, ha másként van megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián lévő első alakzat egy szövegdoboz, és az első bekezdés tartalmazza az alább látható szöveget. Mind a dia, mind az alakzat indexe nullától indul. A példák, amelyek félkövér részeket választanak, a hatékony formázást használják, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szöveges vagy reguláris kifejezés egyezések kereséséhez és kiemeléséhez tekintse meg a [Keresés és csere szöveg](/slides/hu/python-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy használja a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#getHighlightColor) metódust az egyes szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott kiemelési színek felülírják ezt az alapértelmezést:

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

    # Állítsa be a kiemelés színét az egész bekezdésre.
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

if not jpace.isJVMStarted():
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
            # Állítsa be a kiemelés színét a szövegrésznek.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre igazított, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés **középre**:

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

## **Átlátszóság beállítása szöveghez**

A szöveg átlátszósága a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#getFillFormat) színek alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság az **egész bekezdés**‑re:

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

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság **félkövér betűtípusú szövegrészek**‑re:

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

## **Karaktertávolság beállítása szöveghez**

Használja a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közti távolság növelésére vagy szűkítésére egy szövegdobozban. A példák 3 ponttal növelik a távolságot; negatív érték szűkíti a szöveget.

Az alábbi Python‑kód megmutatja, hogyan növelhető a karaktertávolság az **egész bekezdés**‑ben:

```python
import jpway
import asposeslides

if not jpway.isJVMStarted():
    jpway.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # Megjegyzés: Negatív értékek használata a karaktertávolság tömörítéséhez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Növeli a karaktertávolságot.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelhető a karaktertávolság **félkövér betűtípusú szövegrészek**‑ben:

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
            # Megjegyzés: Negatív értékek használata a karaktertávolság tömörítéséhez.
            portion.getPortionFormat().setSpacing(3) # Növeli a karaktertávolságot.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabb lehet, mint a PowerPoint‑ban megjelenő szöveg. Ennek oka lehet, hogy a PowerPoint egyes betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még ha a betűtípus tartalmazza is a kerning információkat és a PowerPoint beállításaiban engedélyezve is van.

Az ilyen esetekben a megfelelő betűtípust használó szövegrészeknél letiltható a kerning. Állítsa a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto‑t használó részekhez. Ez letiltja a kerninget a 100 pont alatti méretű, egyező részeknél:

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

A küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet a Aspose.Slides renderelésének a PowerPoint vizuális megjelenéséhez igazításában azoknál a betűtípusoknál, amelyeket a PowerPoint speciális viselkedése érint.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók a bekezdés szintjén a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja be félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott explicit formázás felülírja ezeket az alapértelmezéseket:

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

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz olyan részekre, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setRotationAngle) metódust egy egyéni forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal forgatja az óramutató járásával megegyező irányban az alakzaton belül:

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

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdés távolságát. Ezeket a tulajdonságokat a következőképpen használhatja:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a első bekezdés soron belüli távolságát a sormagasság **200 %**‑ra (dupla sor) állítja be:

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

![A sortávolság a bekezdésben](line_spacing.png)

## **Soreltörés szabályainak szabályozása**

A bekezdés soreltörési szabályai szűk szövegtömbökben és olyan bemutatókban hasznosak, ahol latin és kelet‑ázsiai szöveg keveredik. Az alábbi metódusok a [ParagraphFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/) részei, így egy egész bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) a latin soreltörési szabályokat irányítja. Vegyes szövegben ennek módosítása befolyásolhatja a kelet‑ázsiai szöveg és írásjelek sortörését is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) a kelet‑ázsiai soreltörési szabályokat irányítja, beleértve a sor elején és végén megengedett karaktereket.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setWrapText) metódust, amely automatikus sortörést engedélyez egy szövegkeretben. A szabályok a layoutot befolyásolják, amikor a sortörés megtörténik; nem helyeznek be sorvége karaktert. Egy explicit sortörés új sort hoz létre a bekezdésben a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa egy szűk szövegtömböt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét soreltörési opciót explicit módon beállítja, és elmenti a „line_breaking.pptx” fájlt. Az egyes szabályok kipróbálásához módosítsa a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pontos keretszélességgel és nulla vízszintes szövegkeret‑margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) metódus a [TextAutofitType.None_](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textautofittype/) értékkel van meghívva, hogy a szöveg mérete és a keret méretei rögzítve maradjanak:

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

## **Függőleges írásjelek kezelése**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a megfelelő írásjelek a szövegsor jobb szélén túl nyúljanak, ahelyett, hogy a következő sorra kerülnek. Ez a teljes bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa függőleges írásjeleket engedélyez egy 100 pont széles szövegkeretben, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial‑t és nulla vízszintes szövegkeret‑margóval a végpont a „mondat” után marad, és túlnyúlik a jobb szövegélén. Állítsa a tulajdonságot a [NullableBool.False_](https://reference.aspose.com/slides/hu/python-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorban jelenik meg. A sortörés engedélyezett, az automatikus méretezés le van tiltva a szélesség rögzítése érdekében.

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

Nem minden írásjel függőleges lehet. A látható eredmény a betűtípus elérhetőségétől és a layouttól függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés módosítása eltüntetheti a látható különbséget.

## **Automatikus méretezés típusa szövegkeretekhez**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) határozza meg, hogy a szöveg hogyan viselkedik, ha meghaladja a tárolója határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kilógjon vagy automatikusan átméretezze az alakzatot. Az alábbi példa úgy konfigurálja az alakzatot, hogy a szöveghez igazodva méreteződjön, és elmenti az eredményt a „autofit_type.pptx” fájlba:

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

Az automatikus sortörés utáni sorok számolásához és a szöveg‑ vagy alakzatszélesség változásának hatásának megtekintéséhez tekintse meg a [Count Rendered Lines](/slides/hu/python-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg kilóg-e a tárolóból.

## **Szövegkeretek rögzítésének beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogy a szöveg a alakzaton belül vertikálisan hol helyezkedjen el, például felül, középen vagy alul. Az alábbi példa a szöveget az első alakzat aljára rögzíti, és elmenti a „text_anchor.pptx” fájlt:

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

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getTabs) metódusokat a bekezdés tabulátor‑állomásainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szövegre hatnak:

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

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#setLanguageId) metódus segítségével lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás‑ és nyelvtanellenőrzéshez.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első diáján egy szövegdoboz az első alakzatként, és legalább egy bekezdést tartalmaz. Lecseréli az első bekezdés tartalmát „1。”‑re, a betűtípust SimSun‑ra állítja, és a Simplified Chinese ellenőrző nyelvet (`zh-CN`) rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a betöltés vagy létrehozás során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre az US English alapértelmezett szövegnyelvvel, szövegdobozt ad hozzá, és kiírja az első szövegrész nyelvét `en-US`‑ként:

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

    # Adjunk hozzá egy szöveget tartalmazó téglalap alakzatot.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Ellenőrizze az első szövegrész nyelvét.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén az alapértelmezett szövegformázás alkalmazásához használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be az új prezentáció felső‑szintű bekezdéseihez, és elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nincs specifikusabb formázás, amely felülírja őket:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Szerezze meg a felső szintű bekezdés formátumát.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg kinyerése All‑Caps effektussal**

PowerPointban az **All Caps** betűtípus‑effektus alkalmazása a szöveget nagybetűsre jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel írták. Amikor az Aspose.Slides‑kel ilyen szövegrészt nyer ki, a könyvtár a beírt szöveget adja vissza. A megjelenített szöveghez a [TextCapType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textcaptype/) ellenőrzése után a visszakapott karakterláncot nagybetűssé kell konvertálni, ha az érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján egy szövegdoboz az első alakzatként. Az első bekezdés első része tartalmazza a „Hello, Aspose!” szöveget az All Caps effektussal, az alábbiak szerint:

![Az All Caps effektus](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg az **All Caps** effektussal:

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

**Hogyan módosítható egy táblázat szövege egy dián?**

A táblázat szövegének módosításához használja a [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse minden cellát a [Cell.getTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/#getTextFrame) és a bekezdésformázást a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getParagraphFormat) segítségével.

**Hogyan alkalmazhatók színátmenetek a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#setFillType) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/) típusra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.