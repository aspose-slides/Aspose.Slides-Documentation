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
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v .NET, abyste označili koncept, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková značka použitá na snímku nebo na všech snímcích prezentace. Vodoznak se obvykle používá k označení, že prezentace je koncept (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, které společnosti přísluší (např. vodoznak „Company Name“), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušování autorských práv tím, že naznačuje, že prezentaci nelze kopírovat. Vodoznaky se používají jak ve formátech PowerPoint, tak OpenDocument. V Aspose.Slides můžete přidat vodoznak do souborových formátů PowerPoint PPT, PPTX a OpenDocument ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/net/), existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenDocument a upravit jejich vzhled a chování. Společné je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape), což vám umožňuje využít všech flexibilních nastavení objektu tvaru. Protože `ITextFrame` není tvarem a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape).

Existují dva způsoby, jak lze vodoznak použít: na jediný snímek nebo na všechny snímky prezentace. Pro použití vodoznaku na všechny snímky se používá Slide Master – vodoznak se přidá do Slide Masteru, je zde plně navržen a poté se aplikuje na všechny snímky, aniž by to ovlivnilo oprávnění upravovat vodoznak na jednotlivých snímcích.

Vodoznak se obvykle považuje za nepřístupný pro úpravy ostatními uživateli. Pro zamezení úprav vodoznaku (nebo spíše jeho nadřazeného tvaru) poskytuje Aspose.Slides funkci zamykání tvarů. konkrétní tvar lze zamknout na běžném snímku nebo na Slide Masteru. Když je tvar vodoznaku zamčen na Slide Masteru, bude zamčen na všech snímcích prezentace.

Můžete nastavit název vodoznaku, aby jej v budoucnu bylo možné snadno najít a odstranit v seznamu tvarů snímku.

Vodoznak můžete navrhnout libovolně; typicky však vodoznaky mají společné rysy, jako je centrování, rotace, umístění v popředí atd. V následujících příkladech si ukážeme, jak tyto vlastnosti použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Pro přidání textového vodoznaku v PPT, PPTX nebo ODP nejprve přidejte na snímek tvar a poté k tomuto tvaru přidejte textový rámec. Textový rámec představuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe). Tento typ není odvozen od [IShape](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/), který nabízí širokou škálu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/itextframe) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [AddTextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/methods/addtextframe) dle níže uvedeného příkladu.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Přidejte vodoznak na snímek.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak použít třídu TextFrame?](/slides/cs/net/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jediný snímek – vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/) a poté použijte metodu [AddTextFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Přidejte vodoznak na hlavní snímek.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak použít Slide Master?](/slides/cs/net/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován výplní a barvou čáry. To znamená, že po přidání vodoznaku se může zobrazit s plným pozadím nebo okrajem, který může odvádět pozornost od obsahu snímku. Pro zajištění jemnosti vodoznaku a nepřekrývání vizuálního designu prezentace můžete tvar učinit zcela průhledným.

Následující řádky kódu učiní tvar průhledným odstraněním jak výplně, tak barvy okraje:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Nastavení písma pro textový vodoznak**

Před aplikací textového vodoznaku na snímek je důležité upravit jeho vzhled tak, aby ladil s celkovým designem. Můžete změnit typ a velikost písma, aby byl vodoznak čitelný i esteticky příjemný. Přizpůsobení písma může také pomoci posílit identitu značky nebo jednoduše odpovídat stylu prezentace.

Ukázkový fragment kódu níže ukazuje, jak nastavit písmo vodoznaku výběrem konkrétního latinského písma a nastavením vhodné výšky písma:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Nastavení barvy textu vodoznaku**

Než použijete vodoznak, je nutné nastavit barvu textu tak, aby dobře zapadala do obsahu snímku, aniž by ho přehlušila. Úprava průhlednosti (alfa) spolu s červenou, zelenou a modrou složkou vám umožní vytvořit jemný, poloprůhledný vodoznak, který je viditelný, ale nerušivý. Tento přístup pomáhá udržet pozornost na hlavní prezentaci a zároveň chrání váš obsah.

Pro nastavení barvy textu vodoznaku použijte následující kód:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrovaný textový vodoznak**

Správné vycentrování textového vodoznaku může výrazně zlepšit celkovou estetiku prezentace tím, že zajistí symetrické umístění vodoznaku bez ohledu na rozměry snímku. Tento přístup nejen dodá snímkům profesionální vzhled, ale také zajistí, že vodoznak nebude rušit hlavní obsah snímku.

Ukázkový fragment kódu níže ukazuje, jak vypočítat středovou pozici snímku a umístit textový vodoznak podle toho:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Obrázek níže ukazuje finální výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

V mnoha případech může obrázkový vodoznak poskytnout jedinečný prvek značky nebo vizuálně atraktivnější alternativu k textovému vodoznaku. Před přidáním vodoznaku se ujistěte, že máte k dispozici soubor obrázku (např. PNG pro průhlednost). Následující příklad ukazuje, jak načíst obrázek ze souborového systému, přidat jej do prezentace a poté jej použít jako vodoznak pomocí vlastností výplně tvaru.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Zamknutí vodoznaku před úpravou**

Pokud je potřeba zabránit úpravám vodoznaku, použijte vlastnost [IAutoShape.ShapeLock](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/properties/shapelock) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunem, seskupením s jinými prvky, zamknutím textu před úpravou a dalšími akcemi:

```cs
// Zamkněte tvar vodoznaku před úpravou.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Umístění vodoznaku do popředí**

V Aspose.Slides lze pořadí vrstev (Z-order) tvarů nastavit pomocí metody [IShapeCollection.Reorder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/reorder/#reorder). K tomu je potřeba zavolat tuto metodu z kolekce snímků prezentace a předat referenci na tvar a požadované pořadové číslo. Tím je možné umístit tvar do popředí nebo jej poslat dozadu. Tato funkce je užitečná, pokud chcete umístit vodoznak před ostatní obsah prezentace:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Nastavení rotace vodoznaku**

Úprava rotace vodoznaku může významně zlepšit vizuální dopad a nenápadnost vaší prezentace. Diagonální vodoznak je méně rušivý, ale stále poskytuje silnou ochranu proti neoprávněnému použití. Následující příklad vypočítá vhodný úhel na základě rozměrů snímku, takže vodoznak bude umístěn úhlopříčně napříč snímkem. Tento dynamický výpočet zajišťuje, že vodoznak zůstane efektivní bez ohledu na různé velikosti snímků.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Nastavení názvu vodoznaku**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru můžete v budoucnu snadno získat přístup k jeho úpravě nebo smazání. Pro nastavení názvu tvaru vodoznaku přiřaďte hodnotu do vlastnosti [IAutoShape.Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte vlastnost [IAutoShape.Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/properties/name) k jeho vyhledání v seznamech tvarů snímku. Poté předávejte tvar vodoznaku metodě [IShapeCollection.Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/remove/):

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Živý příklad**

Můžete si vyzkoušet **bezplatné** online nástroje Aspose.Slides [Přidat vodoznak](https://products.aspose.app/slides/cs/watermark) a [Odstranit vodoznak](https://products.aspose.app/slides/cs/watermark/remove-watermark).

![Online nástroje pro přidání a odstranění vodoznaků](online_tools.png)

## **Často kladené otázky**

**Co je vodoznak a proč jej používat?**

Vodoznak je textová nebo obrázková vrstva aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat povědomí o značce nebo předcházet neoprávněnému použití prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete iterovat přes všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit úpravou nastavení výplně ([FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/fillformat/)) tvaru. Tím zajistíte, že vodoznak bude jemný a nebude odvádět pozornost od obsahu snímku.

**Jaké formáty obrázků jsou podporovány pro vodoznaky?**

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit libovolné písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovávaly konzistenci značky.

**Jak změnit pozici nebo orientaci vodoznaku?**

Pozici a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a rotačních vlastností tvaru.