---
title: Prezentáció szövegének formázása Pythonban Java-n keresztül
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/python-java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakter távolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus méretezés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Formázza és stílusolja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via Java használatával. Testreszabhat betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Python via Java használatával. Tárgyalja a háttérszíneket, átlátszatlanságot, karaktertávolságot, betűtulajdonságokat, forgatást, bekezdés távolságot, automatikus méretezést, szöveg rögzítést, tabulátor pozíciókat és nyelvi beállításokat.

Az alábbi példákban egy **sample.pptx** nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések kereséséhez és kiemeléséhez lásd [Keresés és csere szöveg](/slides/hu/python-java/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) metódust a bekezdés alapértelmezett kiemelés színének beállításához, vagy a [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) metódust az egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** számára:

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

    # Állítsa be az egész bekezdés kiemelési színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan állítható be a háttérszín a **félkövér betűtípussal rendelkező szövegrészek** számára:

```python
import jpype
import asposeslides

if not jpase.isJVMStarted():
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

Használja a [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setAlignment) metódust a bekezdés igazításának beállításához egy szövegdobozban. Az érték lehet középre igazított, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés a **középre**:

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

## **Átlátszóság beállítása a szöveghez**

A szöveg átlátszóságát a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) színének alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem átlátszóság százalék.

Az alábbi kódrészlet mutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** esetén:

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

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **félkövér betűtípussal rendelkező szövegrészek** számára:

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

## **Karakter távolság beállítása a szöveghez**

Használja a [PortionFormat.setSpacing](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Python kód megmutatja, hogyan növelhető a karaktertávolság a **teljes bekezdés** esetén:

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

    # Megjegyzés: Negatív értékek használata a karaktertávolság szorításához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # Bővítse a karaktertávolságot.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakter távolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet mutatja, hogyan növelhető a karaktertávolság a **félkövér betűtípussal rendelkező szövegrészek** esetén:

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
            # Megjegyzés: Negatív értékek használata a karaktertávolság szorításához.
            portion.getPortionFormat().setSpacing(3) # Bővítse a karaktertávolságot.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![A karakter távolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kicsit szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve van a kerning.

Az ilyen esetekben a renderelt kimenetet közelebb hozhatja a PowerPointhoz, ha letiltja a kerninget a érintett betűtípust használó szövegrészeknél. Állítsa a [PortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) értékét lényegesen nagyobbra, mint a tényleges betűméret:

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
            portion_format = portion.getPortionFormat()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion_format.setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ez a beállítás megakadályozza, hogy a kerning alkalmazásra kerüljön a megfelelő szövegrészeknél, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában az érintett betűtípusok esetén.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) vagy egyedi részeknél a [PortionFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a teljes bekezdéshez: betűméretet, félkövér, dőlt, pontozott aláhúzás, valamint a Times New Roman betűtípust alkalmazza minden részre a bekezdésben.

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi kódrészlet hasonló beállításokat alkalmaz a **félkövér betűtípussal rendelkező szövegrészek** számára:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatás beállítása**

Használja a [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setTextVerticalType) metódust egy előre meghatározott szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szöveg orientációját `Vertical270`-re állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja a [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setRotationAngle) metódust egy egyedi forgatási szög beállításához egy [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/) számára.

Az alábbi kódrészlet 3 fokkal forgatja a szövegdobozt az alakzaton belül az óramutató járásával megegyező irányban:

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

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolság beállítása**

Az Aspose.Slides a [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setSpaceBefore) és [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setSpaceWithin) metódusokkal szabályozza a bekezdés távolságait. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív értékkel a sor távolsága a sor magasságának százalékában adható meg.
* Negatív értékkel a sor távolsága pontban megadható.

Az alábbi kódrészlet megmutatja, hogyan adható meg a sor távolsága a bekezdésen belül:

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

## **Automatikus méretezés típus beállítása szövegdobozokhoz**

A [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAutofitType) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tárolója határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy automatikusan átméretezze az alakzatot.

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

## **Szövegdobozok rögzítésének beállítása**

A [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframeformat/#setAnchoringType) meghatározza, hogy a szöveg vertikálisan hol helyezkedjen el egy alakzatban, például a tetején, közepén vagy alján.

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

## **Szöveg tabulálás beállítása**

Használja a [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) és a [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraphformat/#getTabs) metódusokat a tabulátorpozíciók konfigurálásához egy bekezdésben.

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

Az Aspose.Slides a [PortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) metódussal lehetővé teszi a helyesírási és nyelvtani ellenőrzés nyelvének beállítását egy szövegrészhez. A helyesírási nyelv határozza meg, hogy PowerPoint mely nyelven ellenőrizze a helyesírást és a nyelvtant.

Az alábbi kódrészlet megmutatja, hogyan állítható be a helyesírási nyelv egy szövegrészhez:

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

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) metódust a prezentáció betöltése vagy létrehozása közben létrehozott szövegek alapértelmezett nyelvének meghatározásához.

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

    # Adj egy téglalap alakzatot szöveggel.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # Ellenőrizze az első szövegrész nyelvét.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Alapértelmezett szövegstílus beállítása**

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja a [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getDefaultTextStyle) metódust.

Az alábbi kódrészlet megmutatja, hogyan állítható be egy alapértelmezett félkövér betű 14 pt mérettel minden szöveghez az új prezentáció diáin.

```python
import jpype
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

## **Szöveg kinyerése nagybetűs hatással**

PowerPointban az **All Caps** (nagybetűs) betűhatás alkalmazása azt eredményezi, hogy a szöveg a dián nagybetűsen jelenik meg, még ha eredetileg kisbetűkkel íródott is. Amikor az Aspose.Slides visszaadja ezt a szövegrészt, a könyvtár pontosan úgy adja vissza a szöveget, ahogy azt beírták. A megjelenített szöveghez való illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textcaptype/) értékét, és a visszaadott karakterláncot nagybetűssé kell konvertálni, ha az érték `All`.

Tegyük fel, hogy a **sample2.pptx** fájl első diáján a következő szövegdoboz található:

![A nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a szöveg az **All Caps** hatással:

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

**Hogyan módosíthatom a szöveget egy táblázatban a dián?**

A szöveg táblázatban való módosításához használja a [Table](https://reference.aspose.com/slides/hu/python-java/aspose.slides/table/) osztályt. Iteráljon a cellákon, és frissítse minden cellát a [Cell.getTextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/cell/#getTextFrame) segítségével, valamint a bekezdésformázást a [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/#getParagraphFormat) segítségével.

**Hogyan alkalmazhatok fokozatos színt a szövegre egy PowerPoint diához?**

A szövegre való fokozatos szín alkalmazásához használja a [PortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portionformat/) metódust. Állítsa a [FillFormat.setFillType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/#setFillType) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/python-java/aspose.slides/filltype/#Gradient) típusra, és konfigurálja a gradiensek állomásait, irányát és átlátszatlanságát.