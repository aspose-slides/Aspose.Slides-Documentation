---
title: Prezentáció szövegének formázása Pythonon keresztül Java-val
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/python-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttere
- szöveg átlátszósága
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illesztés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Szöveg formázása és stílusának testreszabása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával. Betűtípusok, színek, igazítás és egyéb beállítások testreszabása."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdésközöket, automatikus illesztés viselkedését, szöveg‑rögzítést, tabulátor‑állomásokat és nyelvi beállításokat.

Kivéve, ha másként van megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első forma egy szövegdoboz, és az első bekezdés tartalmazza az alább látható szöveget. A diá‑ és forma‑indexek 0‑tól indulnak. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/python-java/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust egy bekezdés alapértelmezett kiemelési színének beállításához, vagy a [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) metódust egyes szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott explicit kiemelési színek elsőbbséget élveznek az alapértelmezéshez képest:

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

    # Állítsa be a kiemelés színét az egész bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel** formázott **szövegrészek** számára:

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

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra, sorkizárás, stb.

Az alábbi kódrészlet azt mutatja, hogyan lehet a bekezdést **középre** igazítani:

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
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

## **Betűk igazítása a soron belül**

Használja a [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás a teljes bekezdésre vonatkozik, és az egyes sorokban belüli igazítást szabályozza.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos mérettel, eltérő betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és a szövegdobozok elég nagyok a egy soros megjelenítéshez.

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

![Alapvonal, felső, középső és alsó betűigazítás összehasonlítása kevert betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákon alapul, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan. A példa tartalmaz egy nagybetűt és egy alsónyúlványos karaktert, hogy megmutassa a különbséget az alapvonal és az alsó igazítás között. A betűkészlet elérhetősége és helyettesítése, a használt karakterek, valamint a betűméretkülönbségek befolyásolják az eredményt. A keretméretek, margók, sortávolság, sortörés és automatikus illesztés szintén hatnak a megjelenésre; a módok összehasonlításakor ugyanazokat a betűket és elrendezésbeállításokat használja.

Ez a beállítás különbözik a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) metódustól, amely a vízszintes bekezdés‑igazítást szabályozza, és a [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) metódustól, amely a szövegtömb függőleges elhelyezkedését határozza meg a formában. A felső‑ és alsó indexű felirat beállítása a [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) metódussal az egyes részeket az alapvonalhoz képest mozgatja, a bekezdés sorainak betűigazítása helyett.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) szín‑alfa komponensén keresztül vezérli. Az alábbi példákban a `alpha = 50` egy 0–255 skálájú ARGB alfa‑csatorna érték, nem átlátszósági százalék.

Az alábbi kódrészlet megmutatja, hogyan alkalmazzon átlátszóságot a **teljes bekezdésre**:

```python
import jpage
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

A következő kódrészlet azt mutatja, hogyan alkalmazzon átlátszóságot **félkövér betűvel** formázott **szövegrészekre**:

```python
import jpype
import asposeslides

if not jpile.isJVMStarted():
    jpile.startJVM()

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

## **Karakterköz beállítása a szövegben**

Használja a [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) metódust a karakterek közti távolság növeléséhez vagy csökkentéséhez egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek szűkítik a szöveget.

Az alábbi Python‑kód megmutatja, hogyan növelje a karakterközöket a **teljes bekezdésben**:

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

    # Megjegyzés: Negatív értékek használata a karakterköz szorításához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelje a karakterközöket **félkövér betűvel** formázott **szövegrészekben**:

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
            # Megjegyzés: Negatív értékek használata a karakterköz szorításához.
            portion.getPortionFormat().setSpacing(3) # Karakterköz növelése.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűkészleteknél**

Bizonyos esetekben az Aspose.Slides által megjelenített szöveg valamivel szorosabb lehet, mint a PowerPoint‑ban látott szöveg. Ez akkor fordulhat elő, ha a PowerPoint bizonyos betűk esetén figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betű rendelkezik érvényes kerning információval, és a PowerPoint beállításaiban a kerning be van kapcsolva.

Az ilyen esetekben a kerning letiltásával a szövegrészeken, amelyek az érintett betűtípust használják, közelebb hozható a megjelenés a PowerPoint‑éhoz. Állítsa a [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) értékét a tényleges betűméretnél nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első diáján az első forma egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be azokhoz a részekhez, amelyek a Roboto betűtípust használják. Ez letiltja a kerninget az 100 pont alatt lévő, egyező betűmérettel rendelkező részeknél:

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

Az alsó küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint‑ban megjelenő vizuális kimenethez való igazításában az érintett betűtípusok esetén.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés‑szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódussal, vagy egyes részekre a [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) segítségével.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja be félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott explicit formázás felülírja ezeket az alapértelmezéseket:

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

A következő példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja be azokban a részekben, amelyek hatékony formázása félkövér:

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
            # Állítsa be a szövegrész betűtulajdonságait.
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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust, hogy előre definiált szöveg‑orientációt állítson be egy formában.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

## **Egyedi forgatás beállítása szövegdobozokhoz**

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) metódust, hogy egyedi forgatási szöget állítson be egy [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet 3 fokkal óramutató járásával megegyezően forgatja a szövegdobozt a formán belül:

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

![Az egyedi szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdésközöket. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a első bekezdés sortávolságát a sormagasság 200 %-ára (dupla sortávolság) állítja:

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

## **Sortörés szabályainak vezérlése**

A bekezdés sortörés szabályai szűk szövegblokkoknál és olyan prezentációknál hasznosak, ahol latin és kelet‑ázsiai szöveg keveredik. Az alábbi metódusok a [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) osztályhoz tartoznak, ezért egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) a latin szövegek sortörés‑szabályait szabályozza. Vegyes szöveg esetén ennek módosítása hatással lehet a szomszédos kelet‑ázsiai szöveg és írásjelek tördelődésére is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) a kelet‑ázsiai szövegek sortörés‑szabályait szabályozza, beleértve a sor elején és végén megjelenő karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) metódust, amely automatikus sortörést engedélyez a szövegdobozon belül. A szabályok a layoutot befolyásolják, amikor sortörés történik; nem szúrnak be sortörés‑karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa szűk szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörés‑opciót explicit módon beállítja, és a „line_breaking.pptx” fájlt menti. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűket használ 160 pont széles kerettel, valamint nulla vízszintes szövegdoboz‑margóval. A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) a [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) értékre van állítva, hogy a szövegméret és a keretméretek rögzítve maradjanak.

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

## **Függőleges írásjelek szabályozása**

A [ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) lehetővé teszi, hogy a megfelelő írásjelek a sor jobb szélén túlnyúljanak a következő sor helyett. A beállítás a teljes bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa függőleges írásjeleket engedélyez egy 100 pont széles szövegdobozban, és a „hanging_punctuation.pptx” fájlt menti. 24 pontos Arial és nulla vízszintes szövegdoboz‑margó használatával a végső pont a „sentence” szó után marad, és a jobb szövegszegmensen túlnyúlik. Állítsa a tulajdonságot a [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorban jelenik meg. A sortörés engedélyezett, az automatikus illesztés letiltott, hogy a rendelkezésre álló szélesség rögzítve maradjon.

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

Nem minden írásjel függőlegesen helyezhető el. A fenti [betű- és elrendezési feltételek](#control-line-breaking) szintén alkalmazandók erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés beállításainak módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusa a szövegdobozokban**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) meghatározza, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használja a szöveg zsugorításának, túlcsordulásának vagy a forma automatikus átméretezésének vezérlésére. Az alábbi példa úgy konfigurálja a formát, hogy a szöveghez igazodva átméretezze, és a „autofit_type.pptx” fájlba menti az eredményt.

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy a forma szélességének változásának vizsgálatához lásd a [Renderelt sorok számlálása](/slides/hu/python-java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg túlcsordul-e a tárolóból.

## **Szövegdobozok rögzítési beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) határozza meg, hogy a szöveg hogyan helyezkedik el függőlegesen egy formában, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első forma aljához rögzíti, majd a „text_anchor.pptx” fájlba menti.

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

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) metódusokat a tabulátorpozíciók konfigurálásához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátortávolságot 100 pontra állítja, és balra igazított tabulátort ad hozzá 30 pontra. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szövegre vonatkoznak.

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

## **Javítási nyelv beállítása**

Az Aspose.Slides a [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) metódussal lehetővé teszi, hogy egy szövegrész javítási nyelvét állítsa be. A javítási nyelv határozza meg, hogy a PowerPoint milyen nyelven végez helyesírás‑ és nyelvtani ellenőrzést.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első diáján az első forma egy szövegdoboz, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSunra állítja, és a Simplified Chinese (`zh-CN`) javítási nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelyben az alapértelmezett szövegnyelv az amerikai angol, egy szövegdobozt ad hozzá, és az első szövegrészhez `en-US` értéket ír ki.

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

Az alapértelmezett szövegformázás prezentáció‑szintű alkalmazásához használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be az új prezentáció felső‑szintű bekezdéseinek alapértelmezettként, majd a „default_text_style.pptx” fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nem felülírja egy specifikusabb formázás.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # Szerezze meg a legfelső szintű bekezdés formátumát.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg kinyerése ALL CAPS hatással**

PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűsre jeleníti meg a dián, még akkor is, ha eredetileg kisbetűkkel írták. Amikor az Aspose.Slides-szel egy ilyen szövegrészt olvas ki, a könyvtár pontosan a beírt szöveget adja vissza. A megjelenített szöveghez való illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján az első forma egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyre az All Caps hatás alkalmazva van, az alábbiak szerint:

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerje ki a **All Caps** hatással rendelkező szöveget:

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

**Hogyan módosíthatok szöveget egy dián lévő táblázatban?**

A táblázat szövegének módosításához használja a [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse őket a [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) és a bekezdésformázást a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) segítségével.

**Hogyan alkalmazhatok fokozatos színt a szövegre PowerPoint dián?**

A fokozatos szín alkalmazásához használja a [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) értékét a [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) típusra, és konfigurálja a fokozat‑állomásokat, irányt és átlátszóságot.