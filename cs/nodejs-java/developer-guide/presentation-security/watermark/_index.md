---
title: Přidání vodoznaků do prezentací v JavaScriptu
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/nodejs-java/watermark/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v PowerPoint a OpenDocument prezentacích v Node.js k označení návrhu, důvěrných informací, autorských práv a dalších."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková známka, která se používá na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že se jedná o návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), aby se uvedla společnost, které patří (např. vodoznak „Company Name“), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušení autorských práv tím, že naznačuje, že prezentaci nesmí být kopírována. Vodoznaky se používají jak ve formátech PowerPoint, tak OpenOffice. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/nodejs-java/) existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich vzhled a chování. Společným rysem je, že pro přidání textových vodoznaků byste měli použít typ [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje typ [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/), což umožňuje použít všechna flexibilní nastavení objektu tvaru. Protože `TextFrame` není tvarem a jeho nastavení jsou omezená, je zabalen do objektu [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/).

Existují dva způsoby, jak aplikovat vodoznak: na jeden snímek nebo na všechny snímky prezentace. Pro aplikaci vodoznaku na všechny snímky se používá Slide Master – vodoznak se přidá do Slide Master, plně se zde navrhne a použije se na všechny snímky, aniž by to ovlivnilo možnost úpravy vodoznaku na jednotlivých snímcích.

Vodoznak je obvykle považován za needitovatelný ostatními uživateli. Aby se zabránilo úpravám vodoznaku (nebo spíše jeho rodičovského tvaru), Aspose.Slides poskytuje funkci zamykání tvaru. Konkrétní tvar může být uzamčen na běžném snímku nebo na Slide Master. Když je tvar vodoznaku uzamčen na Slide Master, bude uzamčen na všech snímcích prezentace.

Můžete nastavit název vodoznaku, abyste jej v budoucnu mohli snadno najít a odstranit podle názvu v seznamu tvarů snímku.

Vodoznak můžete navrhnout libovolně; existují však běžné rysy, jako je centrování, rotace, umístění v popředí atd. Níže si ukážeme, jak tyto prvky použít v příkladech.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**
Chcete‑li přidat textový vodoznak do PPT, PPTX nebo ODP, nejprve přidejte tvar na snímek a poté k tomuto tvaru přidejte textový rámec. Textový rámec je reprezentován typem [**TextFrame**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame). Tento typ není odvozen od [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape), který má širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame) zabalen do objektu [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape). Pro přidání textu vodoznaku do tvaru použijte metodu [**addTextFrame**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) s textem vodoznaku jako argumentem:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- How to use [TextFrame](/slides/cs/nodejs-java/text-formatting/).
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Chcete‑li přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [**MasterSlide**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterSlide). Zbytek logiky je stejný jako při přidávání vodoznaku na jednotlivý snímek – vytvořte objekt [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) a pak k němu přidejte vodoznak pomocí metody [**addTextFrame**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="See also" %}} 
- [How to use ](/slides/cs/nodejs-java/slide-master/)[Slide Master](/slides/cs/nodejs-java/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován barvou výplně a obrysu. Následující řádky kódu udělají tvar průhledným.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Nastavení písma pro textový vodoznak**

Písmo textového vodoznaku můžete změnit takto:

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Centrovaný textový vodoznak**
Vodoznak lze centrovat na snímku a k tomu můžete provést následující:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Obrázek níže ukazuje výsledný vzhled.

![The text watermark](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Pro přidání obrázkového vodoznaku do všech snímků prezentace můžete provést následující:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Zamknutí vodoznaku proti úpravám**

Pokud je potřeba zabránit úpravám vodoznaku, použijte metodu [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape#getShapeLock--) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunutím, seskupením s dalšími prvky, zamknutím textu před úpravou a dalšími akcemi:

```javascript
// Uzamknout tvar vodoznaku před úpravami
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Přenesení vodoznaku do popředí**

V Aspose.Slides lze pořadí Z tvarů nastavit pomocí metody [**SlideCollection.reorder**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). K tomu zavolejte tuto metodu z kolekce snímků prezentace a předávejte referenci na tvar a jeho pořadové číslo. Tím lze tvar přenést do popředí nebo poslat dozadu. Tato funkce je užitečná, pokud potřebujete umístit vodoznak před obsah prezentace:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Nastavení rotace vodoznaku**

Následující ukázkový kód ukazuje, jak upravit rotaci vodoznaku, aby byl umístěn diagonálně napříč snímkem:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Nastavení názvu vodoznaku**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu najít a upravit nebo odstranit. Pro nastavení názvu tvaru vodoznaku použijte metodu [**AutoShape.getName**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Odstranění vodoznaku**

Chcete‑li odstranit tvar vodoznaku, použijte metodu [AutoShape.getName](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Shape#getName--) k jeho nalezení v kolekci tvarů snímku. Poté předávejte tvar vodoznaku metodě [**ShapeCollection.remove**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Často kladené otázky**

**Co je vodoznak a proč ho mám používat?**

Vodoznak je textová nebo obrázková vrstva aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat povědomí o značce nebo předcházet neoprávněnému používání prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides umožňuje přidat vodoznak na každý snímek v prezentaci. Můžete iterovat přes všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit změnou [nastavení výplně](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getfillformat/) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude rušit obsah snímku.

**Jaké formáty obrázků jsou podporovány pro vodoznaky?**

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit libovolné písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

**Jak změním umístění nebo orientaci vodoznaku?**

Umístění a orientaci vodoznaku můžete upravit změnou souřadnic, velikosti a vlastností rotace tvaru.