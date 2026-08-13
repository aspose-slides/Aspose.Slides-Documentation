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
- Java
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v jazyce Java, abyste označili návrh, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrazová značka používaná na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, které firmě patří (např. vodoznak „Company Name“), k identifikaci autora prezentace apod. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci nesmí být kopírována. Vodoznaky se používají jak v formátech PowerPoint, tak OpenOffice. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/java/) existuje několik způsobů, jak můžete vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich design a chování. Společným rysem je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), což vám umožňuje použít všechna flexibilní nastavení objektu tvaru. Protože `ITextFrame` není tvar a jeho nastavení jsou omezená, je zabaleno do objektu [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/).

Existují dva způsoby aplikace vodoznaku: na jediný snímek nebo na všechny snímky prezentace. **Slide Master** se používá k aplikaci vodoznaku na všechny snímky – vodoznak se přidá do Slide Masteru, je zde plně navržen a následně se použije na všechny snímky, aniž by to ovlivnilo možnost upravovat vodoznak na jednotlivých snímcích.

Vodoznak je obvykle považován za nedostupný pro úpravy ostatními uživateli. Pro zabránění úprav vodoznaku (nebo spíše jeho nadřazeného tvaru) poskytuje Aspose.Slides funkci zamykání tvarů. Konkrétní tvar může být uzamčen na běžném snímku nebo na Slide Masteru. Když je tvar vodoznaku uzamčen na Slide Masteru, bude uzamčen na všech snímcích prezentace.

Můžete nastavit název pro vodoznak, aby jej v budoucnu bylo možné najít podle názvu a případně smazat.

Vodoznak lze navrhnout libovolně; obvykle však mají vodoznaky společné rysy, jako je zarovnání na střed, otočení, pozice v popředí apod. Níže ukážeme, jak tyto vlastnosti použít v příkladech.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Pro přidání textového vodoznaku v PPT, PPTX nebo ODP nejprve přidejte tvar na snímek a poté k tomuto tvaru přidejte textový rámeček. Textový rámeček je reprezentován rozhraním [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/). Tento typ není odvozený od [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/), který poskytuje širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [addTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) jak je ukázáno níže.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Viz také" %}} 
- [Jak použít třídu TextFrame](/slides/cs/java/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jediný snímek – vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/) a poté k němu přidejte vodoznak pomocí metody [addTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Viz také" %}} 
- [Jak použít Slide Master](/slides/cs/java/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován výplní a barvou čáry. Následující řádky kódu tvar učiní průhledným.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Nastavení písma pro textový vodoznak**

Font textového vodoznaku můžete změnit takto.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte následující kód:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Centrovaný textový vodoznak**

Je možné centrovat vodoznak na snímku, což lze provést následujícím způsobem:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Obrázek níže ukazuje finální výsledek.

![The text watermark](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Pro přidání obrázkového vodoznaku do snímku prezentace můžete postupovat takto:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Zamknutí vodoznaku proti úpravám**

Pokud je nutné zabránit úpravám vodoznaku, použijte metodu [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přemístěním, seskupením s dalšími prvky, uzamčením textu proti úpravám a mnoha dalším akcím:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Zamknout tvar vodoznaku před úpravami
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Přenesení vodoznaku do popředí**

V Aspose.Slides lze pořadí Z‑tvarů nastavit pomocí metody [IShapeCollection.reorder](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). K tomu je třeba tuto metodu zavolat z kolekce snímků prezentace a předat odkaz na tvar a jeho pořadové číslo. Tím lze tvar přenést do popředí nebo naopak poslat do pozadí snímku. Tato funkce je obzvláště užitečná, pokud potřebujete umístit vodoznak před obsah prezentace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Nastavení rotace vodoznaku**

Níže je ukázka kódu, jak upravit rotaci vodoznaku, aby byl umístěn úhlopříčně napříč snímkem:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Nastavení názvu vodoznaku**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru můžete v budoucnu přistupovat k jeho úpravě či odstranění. Pro nastavení názvu tvaru vodoznaku přiřaďte jej metodě [IAutoShape.setName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte metodu [IAutoShape.getName](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getName--) k jeho vyhledání v kolekci tvarů snímku. Poté předajte tvar vodoznaku metodě [IShapeCollection.remove](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **Často kladené otázky**

### Co je vodoznak a proč ho používám?

Vodoznak je textová nebo obrazová překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat rozpoznatelnost značky nebo zabraňovat neoprávněnému použití prezentací.

### Mohu přidat vodoznak na všechny snímky v prezentaci?

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek prezentace. Můžete iterovat přes všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

### Jak mohu upravit průhlednost vodoznaku?

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([getFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getFillFormat--)) tvaru. To zajistí, že vodoznak bude decentní a neodvrátí pozornost od obsahu snímku.

### Jaké formáty obrázků jsou podporovány pro vodoznaky?

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

### Mohu přizpůsobit písmo a styl textového vodoznaku?

Ano, můžete zvolit libovolné písmo, velikost a styl tak, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

### Jak změním pozici nebo orientaci vodoznaku?

Pozici a orientaci vodoznaku můžete programově upravit změnou souřadnic, rozměrů a rotačních vlastností tvaru.