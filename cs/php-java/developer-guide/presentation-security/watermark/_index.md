---
title: Přidání vodoznaků do prezentací v PHP
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/php-java/watermark/
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

itvodoznak z PPTX
- odstranit vodoznak z ODP
- smazat vodoznak z PPT
- smazat vodoznak z PPTX
- smazat vodoznak z ODP
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte textové a obrazové vodoznaky v prezentacích PowerPoint a OpenDocument v PHP k označení konceptu, důvěrných informací, autorských práv a dalších."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrazová značka používaná na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je koncept (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, ke které společnosti patří (např. vodoznak „Company Name“), k identifikaci autora prezentace a podobně. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci nesmí být kopírována. Vodoznaky jsou používány jak v formátech PowerPoint, tak OpenOffice. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/cs/php-java/), existují různé způsoby, jak můžete vytvářet vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravovat jejich design a chování. Společným rysem je, že pro přidání textových vodoznaků byste měli použít třídu [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/), a pro přidání obrazových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje třídu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), což vám umožňuje použít všechna flexibilní nastavení objektu tvaru. Protože `ITextFrame` není tvarem a jeho nastavení jsou omezená, je zabalen do objektu [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/).

Existují dva způsoby, jak lze vodoznak použít: na jeden snímek nebo na všechny snímky prezentace. Slide Master se používá k aplikaci vodoznaku na všechny snímky – vodoznak je přidán do Slide Masteru, plně zde navržen a aplikován na všechny snímky, aniž by to ovlivnilo možnost úpravy vodoznaku na jednotlivých snímcích.

Vodoznak je obvykle považován za nedostupný pro úpravy ostatními uživateli. Aby se zabránilo úpravám vodoznaku (přesněji tvaru, který vodoznak obsahuje), poskytuje Aspose.Slides funkci uzamčení tvaru. Konkrétní tvar může být uzamčen na normálním snímku nebo na Slide Masteru. Když je tvar vodoznaku uzamčen na Slide Masteru, bude uzamčen na všech snímcích prezentace.

Název vodoznaku můžete nastavit, aby jej v budoucnu, pokud jej budete chtít smazat, bylo možné najít mezi tvary snímku podle názvu.

Vodoznak můžete navrhnout libovolně; přesto mají vodoznaky obvykle společné vlastnosti, jako je zarovnání na střed, otočení, pozice v popředí a podobně. V níže uvedených příkladech si ukážeme, jak tyto vlastnosti použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Chcete-li přidat textový vodoznak v PPT, PPTX nebo ODP, můžete nejprve přidat tvar na snímek a poté přidat textový rámec do tohoto tvaru. Textový rámec je reprezentován třídou [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/). Tento typ není odvozen od [Shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/), který má širokou škálu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/) zabalen do objektu [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [addTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#addTextFrame), jak je znázorněno níže.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat třídu TextFrame](/slides/cs/php-java/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jeden snímek – vytvořte objekt [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) a poté do něj přidejte vodoznak pomocí metody [addTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat Slide Master](/slides/cs/php-java/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován výplní a barvou čáry. Následující řádky kódu učiní tvar průhledným.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Nastavení písma pro textový vodoznak**

Můžete změnit písmo textového vodoznaku, jak je ukázáno níže.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Vystředění textového vodoznaku**

Je možné vystředit vodoznak na snímku, a k tomu můžete provést následující:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Obrázek níže ukazuje konečný výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrazový vodoznak**

### **Přidání obrazového vodoznaku do prezentace**

Chcete-li přidat obrazový vodoznak na snímek prezentace, můžete provést následující:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Zamknutí vodoznaku proti úpravám**

Pokud je potřeba zabránit úpravám vodoznaku, použijte metodu [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/#getAutoShapeLock) na tvaru. S touto vlastností můžete chránit tvar proti výběru, změně velikosti, přesunu, seskupení s ostatními elementy, uzamknout jeho text před editací a mnoho dalšího:

```php
// Zamknout tvar vodoznaku před úpravou
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Přenesení vodoznaku do popředí**

V Aspose.Slides lze Z-řazení tvarů nastavit pomocí metody [ShapeCollection.reorder](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#reorder). K tomu je potřeba zavolat tuto metodu ze seznamu snímků prezentace a předat do ní odkaz na tvar a jeho pořadové číslo. Tím lze tvar přenést do popředí nebo poslat do pozadí snímku. Tato funkce je zvláště užitečná, pokud potřebujete umístit vodoznak před ostatní obsah prezentace:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Nastavení otočení vodoznaku**

Následuje ukázka kódu, jak nastavit otočení vodoznaku tak, aby byl umístěn diagonálně napříč snímkem:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Nastavení názvu pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru k němu můžete v budoucnu přistupovat za účelem úpravy nebo smazání. Pro nastavení názvu tvaru vodoznaku přiřaďte jej metodě [AutoShape.setName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Odstranění vodoznaku**

Chcete-li odstranit tvar vodoznaku, použijte metodu [AutoShape.getName](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/#getName) k jeho nalezení mezi tvary snímku. Poté předávejte tvar vodoznaku metodě [ShapeCollection.remove](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **Často kladené otázky**

**Co je vodoznak a proč jej používat?**

Vodoznak je textová nebo obrazová vrstva aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, zvýšit povědomí o značce nebo zabránit neoprávněnému použití prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete projít všechny snímky a nastavit vodoznak na každém zvlášť.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit úpravou nastavení výplně ([getFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shape/getfillformat/)) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude odvádět pozornost od obsahu snímku.

**Jaké formáty obrázků jsou pro vodoznaky podporovány?**

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete vybrat libovolné písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

**Jak změním pozici nebo orientaci vodoznaku?**

Pozici a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a otočení tvaru.