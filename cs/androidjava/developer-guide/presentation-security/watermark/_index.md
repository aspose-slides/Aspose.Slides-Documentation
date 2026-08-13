---
title: Přidání vodoznaků do prezentací na Androidu
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/androidjava/watermark/
keywords:
- vodoznak
- textový vodoznak
- obrazový vodoznak
- přidat vodoznak
- změnit vodoznak
- odstranit vodoznak
- smazat vodoznak
- přidat vodoznak do PPT
- přidat vodoznak do PPTX
- přidat vodoznak do ODP
- odstranit vodoznak z PPT
- odstran

  it vodoznak z PPTX
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
description: "Spravujte textové a obrazové vodoznaky v prezentacích PowerPoint a OpenDocument na Androidu v Javě, abyste označili koncept, důvěrné informace a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrazová známka používaná na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je koncept (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, ke které společnosti patří (např. vodoznak „Company Name“), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci nelze kopírovat. Vodoznaky se používají jak v PowerPoint, tak v OpenOffice formátech prezentací. V Aspose.Slides můžete přidat vodoznak do souborových formátů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/android-java/) existuje několik způsobů, jak můžete vytvářet vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravovat jejich návrh a chování. Obecným řešením je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/), a pro přidání obrazových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/), což vám umožní použít všechna flexibilní nastavení objektu tvaru. Protože `ITextFrame` není tvar a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/).

Existují dva způsoby, jak lze vodoznak použít: na jediný snímek nebo na všechny snímky prezentace. Pro použití vodoznaku na všech snímcích se používá Slide Master — vodoznak se přidá do Slide Master, je tam plně navržen a aplikován na všechny snímky, aniž by to ovlivnilo možnost úpravy vodoznaku na jednotlivých snímcích.

Vodoznak se obvykle považuje za nevhodný k úpravám ostatními uživateli. Aby bylo zabráněno úpravám vodoznaku (nebo spíše jeho nadřazeného tvaru), Aspose.Slides poskytuje funkci zamykání tvarů. Konkrétní tvar může být zamčený na běžném snímku nebo na Slide Master. Když je tvar vodoznaku zamčený na Slide Master, bude zamčený na všech snímcích prezentace.

Můžete nastavit název vodoznaku, aby jej v budoucnu, pokud ho budete chtít smazat, bylo možné najít mezi tvary snímku podle názvu.

Vodoznak můžete navrhnout libovolně; obvykle však vodoznaky mají společné rysy, jako je zarovnání na střed, rotace, umístění dopředu atd. Tyto možnosti ukážeme v následujících příkladech.

## **Textový vodoznak**

### **Přidat textový vodoznak na snímek**

Pro přidání textového vodoznaku v PPT, PPTX nebo ODP nejprve přidejte tvar na snímek a potom do tohoto tvaru přidejte textový rámec. Textový rámec je reprezentován rozhraním [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/). Tento typ není odvozen od [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/), který má širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [addTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) jak je ukázáno níže.

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
- [Jak použít třídu TextFrame](/slides/cs/androidjava/text-formatting/)
{{% /alert %}}

### **Přidat textový vodoznak do prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jediný snímek — vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/) a potom přidejte vodoznak pomocí metody [addTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

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
- [Jak použít Slide Master](/slides/cs/androidjava/slide-master/)
{{% /alert %}}

### **Nastavit průhlednost tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován barvami výplně a čáry. Následující řádky kódu učiní tvar průhledným.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Nastavit písmo pro textový vodoznak**

Písmo textového vodoznaku můžete změnit podle následujícího příkladu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Nastavit barvu textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Vystředit textový vodoznak**

Je možné vystředit vodoznak na snímku, a proto můžete provést následující:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Obrázek níže ukazuje konečný výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrazový vodoznak**

### **Přidat obrazový vodoznak do prezentace**

Pro přidání obrazového vodoznaku na snímek prezentace můžete postupovat následovně:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Zamknout vodoznak proti úpravám**

Pokud je potřeba zabránit úpravám vodoznaku, použijte metodu [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunutím, seskupením s dalšími prvky, zamčením jeho textu proti úpravám a dalšími možnostmi:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Zamknout tvar vodoznaku proti úpravám
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Přenést vodoznak dopředu**

V Aspose.Slides lze pořadí Z tvarů nastavit metodou [IShapeCollection.reorder](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). K tomu je třeba zavolat tuto metodu z kolekce snímků prezentace a předat odkaz na tvar a jeho pořadové číslo. Tím je možné přenést tvar dopředu nebo jej poslat dozadu na snímku. Tato funkce je zvláště užitečná, pokud potřebujete umístit vodoznak před obsah prezentace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Nastavit rotaci vodoznaku**

Níže je příklad kódu, jak upravit rotaci vodoznaku tak, aby byl umístěn diagonálně napříč snímkem:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Nastavit název vodoznaku**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu najít a upravit nebo odstranit. Pro nastavení názvu tvaru vodoznaku použijte metodu [IAutoShape.setName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Odstranit vodoznak**

Pro odstranění tvaru vodoznaku použijte metodu [IAutoShape.getName](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getName--) k jeho vyhledání v kolekci tvarů snímku. Poté předáte tento tvar metodě [IShapeCollection.remove](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

### Co je vodoznak a proč ho používat?

Vodoznak je textová nebo obrazová vrstva aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat povědomí o značce nebo zabraňuje neoprávněnému užívání prezentací.

### Mohu přidat vodoznak na všechny snímky v prezentaci?

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete projít všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

### Jak mohu upravit průhlednost vodoznaku?

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([getFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getFillFormat--)) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude rušit obsah snímku.

### Jaké formáty obrázků jsou podporovány pro vodoznaky?

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

### Mohu přizpůsobit písmo a styl textového vodoznaku?

Ano, můžete zvolit libovolné písmo, velikost a styl tak, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

### Jak změním umístění nebo orientaci vodoznaku?

Umístění a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a vlastností rotace tvaru.