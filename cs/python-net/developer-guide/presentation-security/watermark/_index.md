---
title: Přidání vodoznaků do prezentací v Pythonu
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/python-net/watermark/
keywords:
- vodoznak
- textový vodoznak
- obrázkový vodoznak
- přidat vodoznak
- změnit vodoznak
- odebrat vodoznak
- smazat vodoznak
- přidat vodoznak do PPT
- přidat vodoznak do PPTX
- přidat vodoznak do ODP
- odebrat vodoznak z PPT
- odebrat vodoznak z PPTX
- odebrat vodoznak z ODP
- smazat vodoznak z PPT
- smazat vodoznak z PPTX
- smazat vodoznak z ODP
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v Pythonu, aby označovaly návrh, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková razítko použité na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), aby se specifikovalo, ke které společnosti patří (např. vodoznak „Company Name“), k identifikaci autora prezentace apod. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci by nemělo být kopírováno. Vodoznaky se používají jak ve formátech PowerPoint, tak OpenOffice. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/python-net/) existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich vzhled a chování. Společným prvkem je, že pro přidání textových vodoznaků byste měli používat třídu [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje třídu [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/), což vám umožňuje použít všechna flexibilní nastavení objektu shape. Protože `TextFrame` není shape a jeho nastavení jsou omezená, je zabalen do objektu [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/).

Existují dva způsoby, jak lze vodoznak aplikovat: na jeden snímek nebo na všechny snímky prezentace. Slide Master se používá k aplikaci vodoznaku na všechny snímky – vodoznak je přidán do Slide Master, zde plně navržen a aplikován na všechny snímky, aniž by to ovlivnilo možnost úpravy vodoznaku na jednotlivých snímcích.

Vodoznak se obvykle považuje za needitovatelný pro ostatní uživatele. Aby se zabránilo úpravám vodoznaku (nebo spíše jeho nadřazeného tvaru), poskytuje Aspose.Slides funkci zamykání tvarů. Konkrétní tvar může být zamčen na běžném snímku nebo na Slide Masteru. Když je tvar vodoznaku zamčen na Slide Masteru, bude zamčen na všech snímcích prezentace.

Můžete nastavit název pro vodoznak, takže v budoucnu, pokud jej budete chtít smazat, jej můžete najít mezi tvary snímku podle názvu.

Vodoznak můžete navrhnout libovolně; obvykle však mají vodoznaky společné rysy, jako je centrování, rotace, umístění vpředu apod. Níže si ukážeme, jak tyto vlastnosti v příkladech použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Pro přidání textového vodoznaku v PPT, PPTX nebo ODP nejprve přidejte tvar na snímek a poté k tomuto tvaru přidejte textový rámec. Textový rámec představuje třída [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/). Tento typ není odvozen od [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/), která má širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) zabalen do objektu [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [add_text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/add_text_frame/#str), jak je ukázáno níže.

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    slide = presentation.slides[0]

    watermark_shape = slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat třídu TextFrame](/slides/cs/python-net/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jeden snímek – vytvořte objekt [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) a poté k němu přidejte vodoznak pomocí metody [add_text_frame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/add_text_frame/#str).

```py
watermark_text = "CONFIDENTIAL"

with Presentation() as presentation:
    master_slide = presentation.masters[0]

    watermark_shape = master_slide.shapes.add_auto_shape(ShapeType.RECTANGLE, 100, 100, 400, 40)
    watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat Slide Master](/slides/cs/python-net/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován barvou výplně a obrysu. Následující řádky kódu učiní tvar průhledným.

```py
watermark_shape.fill_format.fill_type = FillType.NO_FILL
watermark_shape.line_format.fill_format.fill_type = FillType.NO_FILL
```

### **Nastavení písma pro textový vodoznak**

Písmo textového vodoznaku můžete změnit, jak je ukázáno níže.

```py
text_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format
text_format.latin_font = FontData("Arial")
text_format.font_height = 50
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```py
alpha = 150
red = 200
green = 200
blue = 200

fill_format = watermark_frame.paragraphs[0].paragraph_format.default_portion_format.fill_format
fill_format.fill_type = FillType.SOLID
fill_format.solid_fill_color.color = drawing.Color.from_argb(alpha, red, green, blue)
```

### **Centrovaní textového vodoznaku**

Textový vodoznak lze centrovat na snímku a k tomu můžete provést následující:

```py
slide_size = presentation.slide_size.size

watermark_width = 400
watermark_height = 40
watermark_x = (slide_size.width - watermark_width) / 2
watermark_y = (slide_size.height - watermark_height) / 2

watermark_shape = slide.shapes.add_auto_shape(
    ShapeType.RECTANGLE, watermark_x, watermark_y, watermark_width, watermark_height)

watermark_frame = watermark_shape.add_text_frame(watermark_text)
```

Obrázek níže ukazuje konečný výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Pro přidání obrázkového vodoznaku na snímek prezentace můžete provést následující:

```py
with open("watermark.png", "rb") as image_stream:
    image = presentation.images.add_image(image_stream.read())

    watermark_shape.fill_format.fill_type = FillType.PICTURE
    watermark_shape.fill_format.picture_fill_format.picture.image = image
    watermark_shape.fill_format.picture_fill_format.picture_fill_mode = PictureFillMode.STRETCH
```

## **Zamčení vodoznaku před úpravou**

Pokud je nutné zabránit úpravám vodoznaku, použijte vlastnost [AutoShape.auto_shape_lock](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/auto_shape_lock/) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunutím, seskupením s dalšími prvky, zamknout jeho text před úpravou a mnoho dalšího:

```py
# Zamknout tvar vodoznaku před úpravou
watermark_shape.auto_shape_lock.select_locked = True
watermark_shape.auto_shape_lock.size_locked = True
watermark_shape.auto_shape_lock.text_locked = True
watermark_shape.auto_shape_lock.position_locked = True
watermark_shape.auto_shape_lock.grouping_locked = True
```

## **Přesun vodoznaku dopředu**

V Aspose.Slides lze pořadí (Z‑order) tvarů nastavit pomocí metody [ShapeCollection.reorder](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ishapecollection/reorder/#int-ishape). K tomu je nutné tuto metodu zavolat z kolekce snímků prezentace a předat do ní referenci na tvar a jeho pořadové číslo. Tím je možné tvar přenést dopředu nebo poslat dozadu snímku. Tato funkce se hodí zejména tehdy, když potřebujete umístit vodoznak před obsah prezentace:

```py
shape_count = len(slide.shapes)
slide.shapes.reorder(shape_count - 1, watermark_shape)
```

## **Nastavení rotace vodoznaku**

Níže je ukázka kódu, jak upravit rotaci vodoznaku, aby byl umístěn diagonálně přes snímek:

```py
diagonal_angle = math.atan(slide_size.height / slide_size.width) * 180 / math.pi

watermark_shape.rotation = float(diagonal_angle)
```

## **Nastavení názvu pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu získat pro úpravy nebo smazání. Pro nastavení názvu tvaru vodoznaku přiřaďte ho k vlastnosti [AutoShape.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/name/):

```py
watermark_shape.name = "watermark"
```

## **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte metodu [AutoShape.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/name/) k jeho vyhledání v kolekci tvarů snímku. Poté předáte tvar vodoznaku metodě [ShapeCollection.remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/remove/#ishape):

```py
slide_shapes = list(slide.shapes)
for shape in slide_shapes:
    if shape.name == "watermark":
        slide.shapes.remove(watermark_shape)
```

## **Živý příklad**

Můžete si vyzkoušet **Aspose.Slides free** online nástroje [Add Watermark](https://products.aspose.app/slides/cs/watermark) a [Remove Watermark](https://products.aspose.app/slides/cs/watermark/remove-watermark).

![Online nástroje pro přidání a odstranění vodoznaků](online_tools.png)

## **Často kladené otázky**

**Co je to vodoznak a proč jej mám používat?**

Vodoznak je textová nebo obrázková vrstva aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posílit rozpoznatelnost značky nebo zabránit neoprávněnému použití prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides vám umožní přidat vodoznak na každý snímek v prezentaci. Můžete iterovat přes všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([FillFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/fillformat/)) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude rozptylovat pozornost od obsahu snímku.

**Jaké formáty obrázků jsou podporovány pro vodoznaky?**

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit libovolné písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

**Jak změním umístění nebo orientaci vodoznaku?**

Umístění a orientaci vodoznaku můžete upravit změnou souřadnic, velikosti a vlastností rotace [shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/).