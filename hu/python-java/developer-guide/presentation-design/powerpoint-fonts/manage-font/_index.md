---
title: Betűtípusok kezelése a prezentációkban Python via Java segítségével
linktitle: Betűtípusok kezelése
type: docs
weight: 10
url: /hu/python-java/manage-fonts/
keywords:
- betűtípusok kezelése
- betűtípus tulajdonságok
- bekezdés
- szövegformázás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Betűtípusok kezelése Python via Java segítségével az Aspose.Slides használatával: beágyazás, helyettesítés és egyéni betűtípusok betöltése, hogy a PPT, PPTX és ODP prezentációk tiszták, márkaszerűek és konzisztensak maradjanak."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi a betűtípus tulajdonságainak kezelését a prezentáció szövegében közvetlenül a kódból. A szövegekhez a diákon az alakzatok, szövegkeretek, bekezdések és szövegdarabok (Portion) segítségével férhetünk hozzá, majd formázhatjuk a kiválasztott szöveget.

Ez a cikk bemutatja, hogyan állíthatók be a betűtípussal kapcsolatos tulajdonságok egy meglévő szöveghez a prezentációban, beleértve a betűcsaládot, a félkövér és dőlt stílusokat, a bekezdés igazítását és a betűszínt. A cikk azt is mutatja, hogyan hozhatunk létre egy szövegdobozt, adhatunk hozzá szöveget, és állíthatunk be olyan betűtulajdonságokat, mint a betűcsalád, a félkövér, dőlt, aláhúzott, betűméret és szín, mielőtt a végeredményt PPTX fájlként mentenénk.

## **Betűtípussal kapcsolatos tulajdonságok kezelése**
{{% alert color="info" title="Megjegyzés" %}} 

A prezentációk általában szöveget és képeket is tartalmaznak. A szöveget különféle módokon lehet formázni, akár egyes részek és szavak kiemelésére, akár a vállalati stílusoknak megfelelően. A szövegformázás segít a felhasználóknak változatosabb megjelenést biztosítani a prezentáció tartalmának. Ez a cikk bemutatja, hogyan használható az Aspose.Slides for Python via Java a diákon lévő szövegbekezdések betűtípus‑tulajdonságainak konfigurálásához.

{{% /alert %}} 

A betűtípus‑tulajdonságok kezeléséhez egy bekezdésben az Aspose.Slides for Python via Java segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a [Placeholder](https://reference.aspose.com/slides/hu/python-java/aspose.slides/placeholder/) alakzatokat a dián, mint [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/).
1. Kapja meg a [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) elemet a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)-ből, amelyet a [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) biztosít.
1. Igazítsa a bekezdést.
1. Hozzáférés a [Paragraph](https://reference.aspose.com/slides/hu/python-java/aspose.slides/paragraph/) szövegének [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) részéhez.
1. Definiálja a betűtípust a [FontData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fontdata/) segítségével, és állítsa be a szöveg [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) **Font** attribútumát ennek megfelelően.
   1. Állítsa be a betűtípust félkövérre.
   1. Állítsa be a betűtípust dőltre.
1. Állítsa be a betűszínt a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) objektum által biztosított [FillFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/fillformat/) segítségével.
1. Mentse a módosított prezentációt PPTX fájlként.

Az előző lépések megvalósítása alább látható. Egy egyszerű prezentációt vesz alapul, és formázza a betűket az egyik dia üzerinde. A következő képernyőképek mutatják a bemeneti fájlt és azt, ahogyan a kódrészletek módosítják azt. A kód megváltoztatja a betűtípust, a színt és a betűstílust.

|![Text in the input presentation](https://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Ábra: A bemeneti fájlban lévő szöveg**|


|![Text with updated font formatting](https://i.imgur.com/rY27Lt9.png)|
| :- |
|**Ábra: Ugyanaz a szöveg frissített formázással**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, TextAlignment
from java.awt import Color

# Töltsük be a prezentációt.
presentation = Presentation("FontProperties.pptx")
try:
    # Érjük el az első diát és az első két helyőrző szövegkereteit.
    slide = presentation.getSlides().get_Item(0)
    title_text_frame = slide.getShapes().get_Item(0).getTextFrame()
    body_text_frame = slide.getShapes().get_Item(1).getTextFrame()

    # Érjük el az első bekezdést minden szövegkeretben.
    title_paragraph = title_text_frame.getParagraphs().get_Item(0)
    body_paragraph = body_text_frame.getParagraphs().get_Item(0)
    body_paragraph.getParagraphFormat().setAlignment(TextAlignment.JustifyLow)

    # Érjük el az első szövegdarabot minden bekezdésben.
    title_portion = title_paragraph.getPortions().get_Item(0)
    body_portion = body_paragraph.getPortions().get_Item(0)

    # Definiáljuk és rendeljük hozzá az új betűtípusokat.
    title_font = FontData("Elephant")
    body_font = FontData("Castellar")
    title_portion.getPortionFormat().setLatinFont(title_font)
    body_portion.getPortionFormat().setLatinFont(body_font)

    # Állítsuk be a betűtípusokat félkövérre és dőltre.
    title_portion.getPortionFormat().setFontBold(NullableBool.True_)
    body_portion.getPortionFormat().setFontBold(NullableBool.True_)
    title_portion.getPortionFormat().setFontItalic(NullableBool.True_)
    body_portion.getPortionFormat().setFontItalic(NullableBool.True_)

    # Állítsuk be a betűtípus színeit.
    title_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    title_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    body_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    body_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN)

    # Mentsük a prezentációt.
    presentation.save("WelcomeFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Szöveg betűtípusának beállítása**
{{% alert color="info" title="Megjegyzés" %}} 

A **Betűtípus‑tulajdonságok kezelése** részben említett [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) objektumot használjuk olyan szöveg tárolására, amelynek formázása egységes egy bekezdésen belül. Ez a cikk bemutatja, hogyan hozhatunk létre egy szövegdobozt némi szöveggel, majd hogyan definiálhatunk egy adott betűtípust és különféle egyéb betűtulajdonságokat.

{{% /alert %}} 

Szövegdoboz létrehozása és a benne lévő szöveg betűtípus‑tulajdonságainak beállítása:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Adjon egy **Rectangle** típusú [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) elemet a diához.
1. Távolítsa el az [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/)-hez rendelt kitöltési stílust.
1. Hozzáférés az [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)-jéhez.
1. Adjon hozzá szöveget a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)-hez.
1. Szerezze meg a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) objektumot, amely a [TextFrame](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/)-hez tartozik.
1. Definiálja a betűtípust, amelyet a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) használni fog.
1. Állítsa be a további betűtulajdonságokat, például a félkövér, dőlt, aláhúzott, szín és magasság attribútumokat a [Portion](https://reference.aspose.com/slides/hu/python-java/aspose.slides/portion/) objektum által biztosított megfelelő tulajdonságokkal.
1. Írja ki a módosított prezentációt PPTX fájlként.

Az előző lépések megvalósítása alább látható.

|![Text with font properties applied](https://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Ábra: Szöveg néhány betűtípus‑tulajdonossal, amelyet az Aspose.Slides for Python via Java állított be**|

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextUnderlineType
from java.awt import Color

presentation = Presentation()
try:
    # Szerezze meg az első diát és adjon hozzá egy téglalapot.
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50)

    # Távolítsa el az alakzat kitöltését.
    shape.getFillFormat().setFillType(FillType.NoFill)

    # Szöveg hozzáadása az alakzat szövegkeretéhez.
    text_frame = shape.getTextFrame()
    text_frame.setText("Aspose TextBox")
    portion = text_frame.getParagraphs().get_Item(0).getPortions().get_Item(0)

    # A betűcsalád beállítása.
    font = FontData("Times New Roman")
    portion.getPortionFormat().setLatinFont(font)

    # Félkövér, dőlt, aláhúzott és betűméret beállítása.
    portion.getPortionFormat().setFontBold(NullableBool.True_)
    portion.getPortionFormat().setFontItalic(NullableBool.True_)
    portion.getPortionFormat().setFontUnderline(TextUnderlineType.Single)
    portion.getPortionFormat().setFontHeight(25)

    # A betűszín beállítása.
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    # A prezentáció mentése.
    presentation.save("pptxFont.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```