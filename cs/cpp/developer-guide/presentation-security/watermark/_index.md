---
title: "Přidání vodoznaků do prezentací v C++"
linktitle: "Vodoznak"
type: docs
weight: 40
url: /cs/cpp/watermark/
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
- C++
- Aspose.Slides
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v C++, abyste označili návrh, důvěrné informace, autorská práva a další."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková pečeť použita na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že se jedná o návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k určení, které společnosti prezentace patří (např. vodoznak „Company Name“), k identifikaci autora prezentace atd. Vodoznak pomáhá předcházet porušení autorských práv tím, že naznačuje, že prezentaci není vhodné kopírovat. Vodoznaky se používají jak v PowerPoint, tak v OpenOffice formátech. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/cpp/), existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich design a chování. Společným rysem je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), což vám umožňuje využít veškerá flexibilní nastavení objektu tvaru. Protože `ITextFrame` není tvar a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/).

Existují dva způsoby, jak může být vodoznak aplikován: na jediný snímek nebo na všechny snímky prezentace. Slide Master se používá k aplikaci vodoznaku na všechny snímky – vodoznak se přidá do Slide Masteru, plně se tam navrhne a použije se na všechny snímky, aniž by to ovlivnilo možnost úpravy vodoznaku na jednotlivých snímcích.

Vodoznak se obvykle považuje za needitovatelný pro ostatní uživatele. Aby se zabránilo úpravám vodoznaku (nebo spíše jeho rodičovského tvaru), Aspose.Slides poskytuje funkci zamykání tvarů. Konkrétní tvar může být zamčen na běžném snímku nebo na Slide Masteru. Když je tvar vodoznaku zamčen na Slide Masteru, bude zamčen na všech snímcích prezentace.

Můžete nastavit název vodoznaku, abyste jej v budoucnu mohli najít mezi tvary snímku podle názvu a případně jej smazat.

Vodoznak můžete navrhnout libovolným způsobem; obvykle však mají vodoznaky společné vlastnosti, jako je centrování, rotace, umístění v popředí atd. Níže si ukážeme, jak tyto vlastnosti použít v příkladech.

## **Textový vodoznak**

### **Přidání textového vodoznaku do snímku**

Chcete‑li přidat textový vodoznak do PPT, PPTX nebo ODP, nejprve přidejte tvar na snímek a poté do tohoto tvaru přidejte textový rámeček. Textový rámeček představuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/). Tento typ nedědí z [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), který nabízí širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [AddTextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/addtextframe/) tak, jak je uvedeno níže.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat třídu TextFrame](/slides/cs/cpp/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Chcete‑li přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jediný snímek – vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) a poté k němu přidejte vodoznak pomocí metody [AddTextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Viz také" %}} 
- [Jak používat Slide Master](/slides/cs/cpp/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení má obdélníkový tvar vyplněnou barvu a barvu čáry. Následující řádky kódu učiní tvar průhledným.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Nastavení písma pro textový vodoznak**

Písmo textového vodoznaku můžete změnit podle následujícího příkladu.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrovaný textový vodoznak**

Vodoznak lze centrovat na snímku a k tomu můžete provést následující:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Níže je zobrazen výsledek.

![The text watermark](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Pro přidání obrázkového vodoznaku do snímku prezentace můžete postupovat takto:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Zamknutí vodoznaku proti úpravám**

Je‑li potřeba zabránit úpravám vodoznaku, použijte metodu [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_autoshapelock/) na tvaru. Touto vlastností můžete chránit tvar před výběrem, změnou velikosti, přesunem, seskupováním s ostatními prvky, zamčením jeho textu před úpravou a mnoha dalšími věcmi:

```cpp
// Zamkněte tvar vodoznaku proti úpravám
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Přesunutí vodoznaku do popředí**

V Aspose.Slides lze pořadí vrstev tvarů nastavit pomocí metody [IShapeCollection::Reorder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/reorder/). K tomu je potřeba zavolat tuto metodu z kolekce snímků prezentace a předat jí referenci na tvar a požadované pořadové číslo. Tím lze tvar přesunout do popředí nebo naopak do pozadí snímku. Tato funkce je obzvláště užitečná, pokud potřebujete umístit vodoznak před obsah prezentace:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Nastavení rotace vodoznaku**

Níže je příklad kódu, jak upravit rotaci vodoznaku tak, aby byl umístěn úhlopříčně napříč snímkem:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Nastavení názvu vodoznaku**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu najít a upravit nebo smazat. Pro nastavení názvu tvaru vodoznaku použijte metodu [IAutoShape::set_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte metodu [IAutoShape::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) k jeho nalezení v kolekci tvarů snímku. Poté předávejte tvar vodoznaku metodě [IShapeCollection::Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Živý příklad**

Můžete si vyzkoušet **Aspose.Slides free** nástroje [Add Watermark](https://products.aspose.app/slides/cs/watermark) a [Remove Watermark](https://products.aspose.app/slides/cs/watermark/remove-watermark) online.

![Online tools to add and remove watermarks](online_tools.png)

## **Často kladené dotazy**

**Co je vodoznak a proč jej použít?**

Vodoznak je textová nebo obrázková překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat rozpoznatelnost značky nebo zabránit neautorizovanému použití prezentací.

**Mohu přidat vodoznak na všechny snímky v prezentaci?**

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete projít všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

**Jak mohu upravit průhlednost vodoznaku?**

Průhlednost vodoznaku můžete upravit změnou nastavení výplně ([FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_fillformat/)) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude rušit obsah snímku.

**Jaké formáty obrázků jsou pro vodoznaky podporovány?**

Aspose.Slides podporuje různé formáty obrázků, jako PNG, JPEG, GIF, BMP, SVG a další.

**Mohu přizpůsobit písmo a styl textového vodoznaku?**

Ano, můžete zvolit jakékoli písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

**Jak změním pozici nebo orientaci vodoznaku?**

Pozici a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a rotačních vlastností tvaru.