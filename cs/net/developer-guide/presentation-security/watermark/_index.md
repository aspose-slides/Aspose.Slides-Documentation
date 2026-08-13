---
title: Přidání vodoznaků do prezentací v .NET
linktitle: Vodoznak
type: docs
weight: 40
url: /cs/net/watermark/
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
- .NET
- C#
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v .NET, abyste označili návrh, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková razítko používané na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, které společnosti patří (např. vodoznak „Company Name“), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušení autorských práv tím, že naznačuje, že prezentaci by nemělo být kopírováno. Vodoznaky se používají jak v formátech PowerPoint, tak OpenDocument. V Aspose.Slides můžete přidat vodoznak do souborových formátů PowerPoint PPT, PPTX a OpenDocument ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/net/) existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenDocument a upravit jejich vzhled i chování. Společným prvkem je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape), což vám umožní použít veškerá flexibilní nastavení objektu tvaru. Protože `ITextFrame` není tvar a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape).

Existují dva způsoby, jak aplikovat vodoznak: na jeden snímek nebo na všechny snímky prezentace. Pro aplikaci vodoznaku na všechny snímky se používá Slide Master — vodoznak je přidán do Slide Master, kompletně tam navržen a aplikován na všechny snímky, aniž by to ovlivnilo možnost upravovat vodoznak na jednotlivých snímcích.

Vodoznak je obvykle považován za needitovatelný ostatními uživateli. Aby se zabránilo úpravám vodoznaku (nebo spíše jeho nadřazeného tvaru), Aspose.Slides poskytuje funkci zamykání tvarů. Konkrétní tvar může být uzamčen na běžném snímku nebo na Slide Master. Když je tvar vodoznaku uzamčen na Slide Master, bude uzamčen na všech snímcích prezentace.

Můžete nastavit název pro vodoznak, aby jej bylo možné v budoucnu, když budete chtít odstranit, najít mezi tvary snímku podle názvu.

Vodoznak můžete navrhnout libovolně; obvykle však vodoznaky mají společné vlastnosti, jako je zarovnání na střed, otočení, umístění v popředí atd. V níže uvedených příkladech si ukážeme, jak tyto vlastnosti použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Pro přidání textového vodoznaku v PPT, PPTX nebo ODP nejprve přidejte tvar na snímek a poté do tohoto tvaru přidejte textový rámec. Textový rámec je reprezentován rozhraním [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe). Tento typ není děděn z [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), který má širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [AddTextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/methods/addtextframe), jak je ukázáno níže.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Přidejte vodoznak na snímek.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Viz také" %}} 
- [Jak používat třídu TextFrame?](/slides/cs/net/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jeden snímek — vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a poté přidejte vodoznak pomocí metody [AddTextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Přidejte vodoznak na hlavní snímek.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Viz také" %}} 
- [Jak používat Slide Master?](/slides/cs/net/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován výplní a barvou čáry. To znamená, že po přidání vodoznaku se může zobrazit se solidním pozadím nebo okrajem, což může odvádět pozornost od obsahu snímku. Aby vodoznak zůstal nenápadný a neovlivňoval vizuální design prezentace, můžete tvar učinit zcela průhledným.

Následující řádky kódu učiní tvar průhledným odstraněním jak výplně, tak barvy okraje:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Nastavení písma pro textový vodoznak**

Před aplikací textového vodoznaku na snímek je důležité přizpůsobit jeho vzhled tak, aby ladil s celkovým designem. Můžete změnit typ a velikost písma, aby byl vodoznak čitelný a esteticky příjemný. Přizpůsobení písma může také pomoci posílit identitu značky nebo jednoduše odpovídat stylu prezentace.

Následující úryvek kódu ukazuje, jak upravit nastavení písma vodoznaku výběrem konkrétního latinského písma a nastavením vhodné výšky písma:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Nastavení barvy textu vodoznaku**

Před aplikací vodoznaku je nutné zajistit, že barva textu je nastavena vhodně, aby se dobře sloučila s obsahem snímku a nepřehlušila jej. Úprava průhlednosti barvy (alpha) spolu s červenou, zelenou a modrou složkou vám umožní vytvořit nenápadný, poloprůhledný vodoznak, který je viditelný, ale neruší. Tento přístup pomáhá udržet pozornost na hlavní prezentaci a zároveň chrání váš obsah.

Chcete-li nastavit barvu textu vodoznaku, použijte následující kód:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Vystředění textového vodoznaku**

Správné vystředění textového vodoznaku může výrazně zlepšit celkovou estetiku vaší prezentace tím, že zajistí symetrické umístění vodoznaku bez ohledu na rozměry snímku. Tento přístup nejenže dodává snímkům profesionální vzhled, ale také zajišťuje, že vodoznak nezasahuje do hlavního obsahu snímku.

Následující úryvek kódu ukazuje, jak vypočítat středovou pozici snímku a umístit textový vodoznak podle toho:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Obrázek níže zobrazuje konečný výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

V mnoha případech může obrázkový vodoznak poskytnout jedinečný prvek značky nebo vizuálně atraktivnější alternativu k textovému vodoznaku. Před přidáním vodoznaku se ujistěte, že soubor s obrázkem je dostupný (např. PNG pro průhlednost). Následující příklad ukazuje, jak načíst obrázek ze souborového systému, přidat jej do prezentace a poté jej použít jako vodoznak pomocí výplně tvaru.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Zamknutí vodoznaku proti úpravám**

Pokud je nutné zabránit úpravám vodoznaku, použijte vlastnost [IAutoShape.ShapeLock](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/properties/shapelock) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přemístěním, seskupením s jinými prvky, uzamknout jeho text proti úpravám a dalšími možnostmi:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Zamkněte tvar vodoznaku před úpravami.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Přesunutí vodoznaku do popředí**

V Aspose.Slides lze Z-řazení tvarů nastavit pomocí metody [IShapeCollection.Reorder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/reorder/#reorder). K tomu je třeba volat tuto metodu ze seznamu snímků prezentace a předat do ní odkaz na tvar a jeho pořadové číslo. Tímto způsobem je možné převést tvar do popředí nebo ho poslat do pozadí snímku. Tato funkce je obzvláště užitečná, pokud potřebujete umístit vodoznak před obsah prezentace:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Nastavení otočení vodoznaku**

Úprava natočení vodoznaku může výrazně zvýšit vizuální dopad a nenápadnost vaší prezentace. Diagonální vodoznak může být méně rušivý a zároveň poskytovat silnou ochranu proti neoprávněnému použití. Následující příklad vypočítá vhodný úhel na základě rozměrů snímku, aby byl vodoznak umístěn diagonálně přes snímek. Tento dynamický výpočet zajišťuje, že vodoznak zůstane efektivní bez ohledu na různé velikosti snímků.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Nastavení názvu pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru můžete v budoucnu k tvaru přistupovat, upravovat jej nebo jej odstranit. Pro nastavení názvu tvaru vodoznaku přiřaďte ho vlastnosti [IAutoShape.Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte vlastnost [IAutoShape.Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/name) k jeho vyhledání mezi tvary snímku. Poté předajte tvar vodoznaku metodě [IShapeCollection.Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/remove/):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Ukázkový příklad**

Možná si chcete vyzkoušet **Aspose.Slides free** online nástroje [Add Watermark](https://products.aspose.app/slides/cs/watermark) a [Remove Watermark](https://products.aspose.app/slides/cs/watermark/remove-watermark).

![Online nástroje pro přidání a odstranění vodoznaků](online_tools.png)

## **Často kladené otázky**

### **Co je vodoznak a proč jej používat?**

Vodoznak je textová nebo obrázková překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posílit rozpoznatelnost značky nebo zabránit neautorizovanému použití prezentací.

### **Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides vám umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete projít všechny snímky a nastavení vodoznaku aplikovat jednotlivě.

### **Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit úpravou nastavení výplně ([FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/fillformat/)) tvaru. Tím zajistíte, že vodoznak bude nenápadný a nebude odvádět pozornost od obsahu snímku.

### **Jaké formáty obrázků jsou pro vodoznaky podporovány?**

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

### **Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit libovolné písmo, velikost a styl tak, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

### **Jak změním umístění nebo orientaci vodoznaku?**

Umístění a orientaci vodoznaku můžete programově upravit úpravou souřadnic, velikosti a natočení tvaru.