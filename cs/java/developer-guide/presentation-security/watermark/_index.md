---
title: Přidání vodoznaků do prezentací v jazyce Java
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/java/watermark/
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
- Java
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v jazyce Java, abyste označili návrh, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrazová značka používaná na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je návrhem (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k specifikaci, ke které společnosti patří (např. vodoznak „Company Name“), k identifikaci autora prezentace a podobně. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci nelze kopírovat. Vodoznaky se používají jak ve formátech PowerPoint, tak OpenOffice. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX i OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/java/) existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich design a chování. Společným prvkem je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) a pro přidání obrázkových vodoznaků třídu [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), což vám umožňuje využít všech flexibilních nastavení objektu tvaru. Protože `ITextFrame` není tvarem a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).

Existují dva způsoby, jak lze vodoznak použít: na jediný snímek nebo na všechny snímky prezentace. Slide Master se používá k aplikaci vodoznaku na všechny snímky – vodoznak se přidá do Slide Masteru, kompletně se zde navrhne a aplikuje na všechny snímky, aniž by to ovlivnilo možnost upravovat vodoznak na jednotlivých snímcích.

Vodoznak se obvykle považuje za needitovatelný ostatními uživateli. Pro zabránění úprav vodoznaku (nebo spíše nadřazeného tvaru vodoznaku) poskytuje Aspose.Slides funkci zamykání tvarů. Konkrétní tvar může být zamčen na běžném snímku nebo na Slide Masteru. Když je tvar vodoznaku zamčen na Slide Masteru, bude zamčen na všech snímcích prezentace.

Můžete nastavit název vodoznaku, aby ho v budoucnu šlo podle názvu najít mezi tvary snímku a případně smazat.

Vodoznak můžete navrhnout libovolně; typicky však mají vodoznaky společné rysy, jako je zarovnání na střed, rotace, umístění v popředí atd. V níže uvedených příkladech si ukážeme, jak tyto vlastnosti použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Chcete‑li přidat textový vodoznak v PPT, PPTX nebo ODP, nejprve přidejte na snímek tvar a pak tomuto tvaru přidejte textový rámec. Textový rámec představuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/). Tento typ není zděděný z [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), který poskytuje širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [addTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) podle níže uvedeného příkladu.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak použít třídu TextFrame](/slides/cs/java/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do prezentace**

Chcete‑li přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jediný snímek — vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a pak do něj vložte vodoznak pomocí metody [addTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak použít Slide Master](/slides/cs/java/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován barvou výplně a čáry. Následující řádky kódu učiní tvar průhledným.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Nastavení písma pro textový vodoznak**

Font textového vodoznaku můžete změnit, jak je ukázáno níže.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Vycentrování textového vodoznaku**

Vodoznak lze vycentrovat na snímku, a to následovně:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Níže je zobrazen výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Pro přidání obrázkového vodoznaku na snímek prezentace můžete použít následující postup:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Zamčení vodoznaku proti úpravám**

Pokud je potřeba zabránit úpravám vodoznaku, použijte na tvar metodu [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) . Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunutím, seskupením s dalšími prvky, uzamknout jeho text před úpravou a mnoho dalšího:

```java
// Zamknout tvar vodoznaku před úpravou
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Přesunutí vodoznaku dopředu**

V Aspose.Slides lze pořadí tvarů (Z‑order) nastavit pomocí metody [IShapeCollection.reorder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . K tomu je třeba tuto metodu zavolat z kolekce snímků prezentace a předat jí odkaz na tvar a jeho požadované pořadí. Tím lze tvar přenést dopředu nebo poslat dozadu na snímku. Tato funkce se zvláště hodí, pokud chcete umístit vodoznak před obsah prezentace:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Nastavení rotace vodoznaku**

Následující příklad ukazuje, jak upravit rotaci vodoznaku, aby byl umístěn diagonálně napříč snímkem:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Nastavení názvu pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu najít a upravit nebo smazat. Pro nastavení názvu tvaru vodoznaku použijte metodu [IAutoShape.setName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setName-java.lang.String-) :

```java
watermarkShape.setName("watermark");
```

### **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte metodu [IAutoShape.getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--) k jeho vyhledání mezi tvary snímku. Poté předáte tvar vodoznaku metodě [IShapeCollection.remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Často kladené otázky**

**Co je vodoznak a proč jej použít?**

Vodoznak je textová nebo obrázková překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, zvyšovat povědomí o značce nebo zabraňovat neoprávněnému používání prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete iterovat přes všechny snímky a aplikovat nastavení vodoznaku individuálně.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([getFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getFillFormat--)) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude rušit obsah snímku.

**Jaké formáty obrázků jsou pro vodoznaky podporovány?**

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit font a styl textového vodoznaku?**

Ano, můžete zvolit libovolný font, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

**Jak změním umístění nebo orientaci vodoznaku?**

Umístění a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a vlastností rotace tvaru.