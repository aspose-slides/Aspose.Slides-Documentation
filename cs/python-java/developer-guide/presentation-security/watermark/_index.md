---
title: Přidání vodoznaků do prezentací v Pythonu
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/python-java/watermark/
keywords:
- vodoznak
- textový vodoznak
- obrázkový vodoznak
- přidat vodoznak
- změnit vodoznak
- odstranit vodoznak
- smazat vodoznak
- přidat vodoznak do PPT
- přidat vodoznak do PPTX
- přidat vodoznak do ODP
- odstranit vodoznak z PPT
- odstranit vodoznak z PPTX
- odstranit vodoznak z ODP
- smazat vodoznak z PPT
- smazat vodoznak z PPTX
- smazat vodoznak z ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v Pythonu, abyste označili návrh, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková razítko používané na snímku nebo ve všech snímcích prezentace. Obvykle se vodoznak používá k označení, že se jedná o návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, ke které společnosti patří (např. vodoznak „Company Name“), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci nesmí být kopírována. Vodoznaky jsou používány jak v PowerPoint, tak v OpenOffice formátech prezentací. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/python-java/) existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich vzhled a chování. Společným prvkem je, že pro přidání textových vodoznaků byste měli použít třídu [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. [PictureFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pictureframe/) dědí z třídy [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), což vám umožňuje použít všechna flexibilní nastavení objektu tvaru. Protože [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) není tvar a jeho nastavení jsou omezená, je zabalený do objektu [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/).

Existují dva způsoby, jak lze vodoznak použít: na jediný snímek nebo na všechny snímky prezentace. K aplikaci vodoznaku na všechny snímky se používá Slide Master – vodoznak se přidá na Slide Master, plně se tam navrhne a aplikuje na všechny snímky, aniž by to ovlivnilo oprávnění upravovat vodoznak na jednotlivých snímcích.

Vodoznak je obvykle považován za needitovatelný pro jiné uživatele. Aby se zabránilo úpravě vodoznaku (nebo spíše nadřazeného tvaru vodoznaku), Aspose.Slides poskytuje funkci uzamčení tvaru. Konkrétní tvar lze uzamknout na běžném snímku nebo na Slide Masteru. Když je tvar vodoznaku uzamčen na Slide Masteru, bude uzamčen na všech snímcích prezentace.

Můžete nastavit název pro vodoznak, aby jej bylo v budoucnu možné najít podle názvu mezi tvary snímku a případně jej smazat.

Vodoznak můžete navrhnout libovolně; obvykle však vodoznaky mají společné rysy, jako je zarovnání na střed, otočení, pozice v popředí atd. V následujících příkladech si ukážeme, jak tyto vlastnosti použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Chcete‑li přidat textový vodoznak v PPT, PPTX nebo ODP, nejprve přidejte tvar na snímek a poté do tohoto tvaru přidejte textový rámeček. Textový rámeček představuje třída [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/). Tento typ nedědí z [Shape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/), který má širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) zabalený v objektu [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [addTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#addTextFrame) dle níže uvedeného příkladu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [How to Use the TextFrame Class](/slides/cs/python-java/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Chcete‑li přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/python-java/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jediný snímek — vytvořte objekt [AutoShape](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/) a poté přidejte vodoznak pomocí metody [addTextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#addTextFrame).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    watermark_shape = master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 
- [How to Use the Slide Master](/slides/cs/python-java/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován výplní a barvou čáry. Následující řádky kódu učiní tvar průhledným.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.getFillFormat().setFillType(FillType.NoFill)
    watermark_shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
finally:
    presentation.dispose()
```

### **Nastavení písma pro textový vodoznak**

Písmo textového vodoznaku můžete změnit podle níže uvedeného příkladu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FontData

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    text_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat()
    font = FontData("Arial")
    text_format.setLatinFont(font)
    text_format.setFontHeight(50)
finally:
    presentation.dispose()
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte následující kód:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_frame = watermark_shape.addTextFrame("CONFIDENTIAL")
    alpha, red, green, blue = 150, 200, 200, 200
    fill_format = watermark_frame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat()
    fill_format.setFillType(FillType.Solid)
    color = Color(red, green, blue, alpha)
    fill_format.getSolidFillColor().setColor(color)
finally:
    presentation.dispose()
```

### **Zarovnání textového vodoznaku na střed**

Vodoznak lze na snímku vycentrovat, k tomu můžete provést následující:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

watermark_text = "CONFIDENTIAL"
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_size = presentation.getSlideSize().getSize()
    watermark_width = 400
    watermark_height = 40
    watermark_x = (slide_size.getWidth() - watermark_width) / 2
    watermark_y = (slide_size.getHeight() - watermark_height) / 2
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, watermark_x, watermark_y, watermark_width, watermark_height)
    watermark_frame = watermark_shape.addTextFrame(watermark_text)
finally:
    presentation.dispose()
```

Obrázek níže ukazuje konečný výsledek.

![The text watermark](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Pro přidání obrázkového vodoznaku na snímek prezentace můžete provést následující:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, PictureFillMode

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    image_data = Path("watermark.png").read_bytes()
    image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(image_data))
    watermark_shape.getFillFormat().setFillType(FillType.Picture)
    watermark_shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image)
    watermark_shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
finally:
    presentation.dispose()
```

### **Zamknutí vodoznaku před úpravou**

Pokud je potřeba zabránit úpravám vodoznaku, použijte metodu [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/cs/python-java/aspose.slides/autoshape/#getAutoShapeLock) na tvaru. Pomocí této vlastnosti můžete chránit tvar před výběrem, změnou velikosti, přesunutím, seskupením s dalšími prvky, uzamčením jeho textu před úpravou a dalšími akcemi:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    # Uzamkněte tvar vodoznaku před úpravami.
    watermark_shape.getAutoShapeLock().setSelectLocked(True)
    watermark_shape.getAutoShapeLock().setSizeLocked(True)
    watermark_shape.getAutoShapeLock().setTextLocked(True)
    watermark_shape.getAutoShapeLock().setPositionLocked(True)
    watermark_shape.getAutoShapeLock().setGroupingLocked(True)
finally:
    presentation.dispose()
```

### **Přesunutí vodoznaku do popředí**

V Aspose.Slides lze Z‑pořadí tvarů nastavit metodou [ShapeCollection.reorder](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#reorder). K tomu je třeba zavolat tuto metodu z kolekce tvarů snímku a předat odkaz na tvar a jeho pořadové číslo. Tím je možné tvar přesunout do popředí nebo naopak do pozadí snímku. Tato funkce je zvláště užitečná, pokud potřebujete umístit vodoznak před obsah prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    shape_count = slide.getShapes().size()
    slide.getShapes().reorder(shape_count - 1, watermark_shape)
finally:
    presentation.dispose()
```

### **Nastavení otočení vodoznaku**

Níže je příklad kódu, jak nastavit otočení vodoznaku tak, aby byl umístěn diagonálně přes snímek:

```python
import jpype
import asposeslides
import math

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    slide_size = presentation.getSlideSize().getSize()
    diagonal_angle = math.atan((slide_size.getHeight() / slide_size.getWidth())) * 180 / math.pi
    watermark_shape.setRotation(diagonal_angle)
finally:
    presentation.dispose()
```

### **Nastavení názvu pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu získat pro úpravu nebo smazání. Pro nastavení názvu tvaru vodoznaku jej předáte metodě [Shape.setName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#setName):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    watermark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40)
    watermark_shape.setName("watermark")
finally:
    presentation.dispose()
```

### **Odebrání vodoznaku**

Pro odebrání tvaru vodoznaku použijte metodu [Shape.getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getName) k jeho vyhledání mezi tvary snímku. Pak předáte tvar vodoznaku metodě [ShapeCollection.remove](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#remove):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    slide_shapes = slide.getShapes().toArray()
    for shape in slide_shapes:
        if shape.getName() == "watermark":
            slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Co je vodoznak a proč ho použít?**

Vodoznak je textová nebo obrázková překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat rozpoznatelnost značky nebo zabránit neoprávněnému použití prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek prezentace. Můžete iterovat přes všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([getFillFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getFillFormat)) tvaru. Tím zajistíte, že vodoznak bude nenápadný a nebude rušit obsah snímku.

**Jaké formáty obrázků jsou podporovány pro vodoznaky?**

Aspose.Slides podporuje různé formáty obrázků, jako PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit libovolné písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

**Jak změním umístění nebo orientaci vodoznaku?**

Umístění a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a vlastností otáčení tvaru.