---
title: Přidání vodoznaků do prezentací v Androidu
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument na Androidu v jazyce Java, abyste označili koncept, důvěrné informace a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková známka použitá na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je koncept (např. vodoznak "Draft"), že obsahuje důvěrné informace (např. vodoznak "Confidential"), k určení, které společnosti patří (např. vodoznak "Company Name"), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušení autorských práv tím, že naznačuje, že prezentaci nelze kopírovat. Vodoznaky se používají jak v PowerPoint, tak v OpenOffice formátech prezentací. V Aspose.Slides můžete přidat vodoznak do formátů souborů PowerPoint PPT, PPTX a OpenOffice ODP.

Ve [**Aspose.Slides**](https://products.aspose.com/slides/cs/android-java/) existuje několik způsobů, jak můžete vytvářet vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravovat jejich design a chování. Společným aspektem je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/), což vám umožňuje využít všech flexibilních nastavení objektu tvaru. Protože `ITextFrame` není tvar a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/).

Existují dva způsoby, jak lze vodoznak aplikovat: na jeden snímek nebo na všechny snímky prezentace. K aplikaci vodoznaku na všechny snímky se používá Slide Master – vodoznak se přidá do Slide Master, kompletně zde navrhne a aplikuje se na všechny snímky, aniž by to ovlivnilo možnost upravovat vodoznak na jednotlivých snímcích.

Vodoznak se obvykle považuje za needitovatelný pro ostatní uživatele. Aby se zabránilo úpravám vodoznaku (nebo spíše jeho nadřazeného tvaru), poskytuje Aspose.Slides funkci zamykání tvarů. Konkrétní tvar může být zamčen na běžném snímku nebo na Slide Master. Když je tvar vodoznaku zamčen na Slide Master, bude zamčen na všech snímcích prezentace.

Můžete nastavit název pro vodoznak, aby jej v budoucnu, pokud ho budete chtít smazat, bylo možné najít mezi tvary snímku podle názvu.

Vodoznak můžete navrhnout jakýmkoli způsobem; typicky však vodoznaky mají společné vlastnosti, jako zarovnání na střed, otočení, umístění vpředu atd. V níže uvedených příkladech si ukážeme, jak tyto prvky použít.

## **Textový vodoznak**

### **Přidat textový vodoznak na snímek**

Chcete‑li přidat textový vodoznak v PPT, PPTX nebo ODP, můžete nejprve přidat tvar na snímek a poté k tomuto tvaru přidat textový rámec. Textový rámec je reprezentován rozhraním [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/). Tento typ nedědí z rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/), které poskytuje širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/). K přidání textu vodoznaku do tvaru použijte metodu [addTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) tak, jak je uvedeno níže.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat třídu TextFrame](/slides/cs/androidjava/text-formatting/)
{{% /alert %}}

### **Přidat textový vodoznak do prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jednotlivý snímek — vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) a poté k němu přidejte vodoznak pomocí metody [addTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat Slide Master](/slides/cs/androidjava/slide-master/)
{{% /alert %}}

### **Nastavit průhlednost tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován barvami výplně a čáry. Následující řádky kódu učiní tvar průhledným.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Nastavit písmo pro textový vodoznak**

Můžete změnit písmo textového vodoznaku, jak je uvedeno níže.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Nastavit barvu textu vodoznaku**

Chcete‑li nastavit barvu textu vodoznaku, použijte tento kód:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Vycentrovat textový vodoznak**

Je možné vycentrovat vodoznak na snímku a k tomu můžete provést následující:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

![Textový vodoznak](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidat obrázkový vodoznak do prezentace**

Chcete‑li přidat obrázkový vodoznak na snímek prezentace, můžete postupovat následovně:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Zamknout vodoznak před úpravou**

Pokud je nutné zabránit úpravě vodoznaku, použijte metodu [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunutím, seskupením s dalšími prvky, zamknout jeho text před úpravou a mnoho dalšího:

```java
// Uzamknout tvar vodoznaku před úpravou
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Přenést vodoznak dopředu**

V Aspose.Slides lze Z‑pořadí tvarů nastavit pomocí metody [IShapeCollection.reorder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). K tomu je třeba zavolat tuto metodu ze seznamu snímků prezentace a předat odkaz na tvar a jeho pořadové číslo. Tím je možné přenést tvar dopředu nebo jej poslat dozadu na snímku. Tato funkce je zvláště užitečná, pokud potřebujete umístit vodoznak před prezentaci:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Nastavit otočení vodoznaku**

Zde je ukázka kódu, jak upravit otočení vodoznaku tak, aby byl umístěn diagonálně přes snímek:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Nastavit název pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu přistupovat k úpravě nebo smazání. Pro nastavení názvu tvaru vodoznaku přiřaďte jej metodě [IAutoShape.setName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Odstranit vodoznak**

Pro odstranění tvaru vodoznaku použijte metodu [IAutoShape.getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) k jeho nalezení mezi tvary snímku. Poté předáte tvar vodoznaku metodě [IShapeCollection.remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

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

**Co je to vodoznak a proč jej použít?**

Vodoznak je textová nebo obrázková překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, zvyšovat rozpoznatelnost značky nebo zabraňovat neautorizovanému použití prezentací.

**Mohu přidat vodoznak ke všem snímkům v prezentaci?**

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete iterovat přes všechny snímky a jednotlivě použít nastavení vodoznaku.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([getFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getFillFormat--)) tvaru. Tím zajistíte, že vodoznak bude decentní a neodvádí pozornost od obsahu snímku.

**Jaké formáty obrázků jsou podporovány pro vodoznaky?**

Aspose.Slides podporuje různé formáty obrázků, jako PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit libovolné písmo, velikost a styl, který odpovídá designu vaší prezentace a zachovává konzistenci značky.

**Jak změním umístění nebo orientaci vodoznaku?**

Pozici a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a vlastností otočení tvaru.