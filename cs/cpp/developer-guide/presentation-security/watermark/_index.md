---
title: Přidání vodoznaků do prezentací v C++
linktitle: Vodoznak
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
description: "Spravujte textové a obrázkové vodoznaky v prezentacích PowerPoint a OpenDocument v C++ za účelem označení návrhu, důvěrných informací, autorských práv a dalších."
---
## **Úvod**

**Vodoznak** v prezentaci je textová nebo obrázková pečeť použitá na snímku nebo na všech snímcích prezentace. Obvykle se vodoznak používá k označení, že prezentace je návrh (např. vodoznak „Draft“), že obsahuje důvěrné informace (např. vodoznak „Confidential“), k uvedení, které firmě patří (např. vodoznak „Company Name“), k identifikaci autora prezentace apod. Vodoznak pomáhá předcházet porušení autorských práv tím, že naznačuje, že prezentaci nelze kopírovat. Vodoznaky se používají jak v PowerPoint, tak v OpenOffice formátech prezentací. V Aspose.Slides můžete přidat vodoznak do souborů PowerPoint PPT, PPTX a OpenOffice ODP.

V [**Aspose.Slides**](https://products.aspose.com/slides/cs/cpp/) existuje několik způsobů, jak vytvořit vodoznaky v dokumentech PowerPoint nebo OpenOffice a upravit jejich design a chování. Společným prvkem je, že pro přidání textových vodoznaků byste měli použít rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/), a pro přidání obrázkových vodoznaků použít třídu [PictureFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/pictureframe/) nebo vyplnit tvar vodoznaku obrázkem. `PictureFrame` implementuje rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), což vám umožňuje využít všech flexibilních nastavení objektu tvaru. Protože `ITextFrame` není tvarem a jeho nastavení jsou omezená, je zabalen do objektu [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/).

Existují dva způsoby, jak lze vodoznak použít: na jediný snímek nebo na všechny snímky prezentace. Slide Master se používá k aplikaci vodoznaku na všechny snímky – vodoznak je přidán do Slide Master, kompletně tam navržen a aplikován na všechny snímky, aniž by to ovlivnilo možnost úpravy vodoznaku na jednotlivých snímcích.

Vodoznak se obvykle považuje za nedostupný pro úpravy ostatními uživateli. Pro zamezení úprav vodoznaku (nebo spíše jeho nadřazeného tvaru) poskytuje Aspose.Slides funkci zamykání tvarů. Konkrétní tvar může být uzamčen na běžném snímku nebo na Slide Master. Když je tvar vodoznaku uzamčen na Slide Master, bude uzamčen na všech snímcích prezentace.

Můžete nastavit název pro vodoznak, aby jej bylo v budoucnu možné vyhledat podle názvu a případně smazat.

Vodoznak můžete navrhnout libovolně; však mají často společné rysy, jako je centrované zarovnání, rotace, umístění v popředí apod. V následujících příkladech si ukážeme, jak tyto vlastnosti použít.

## **Textový vodoznak**

### **Přidání textového vodoznaku na snímek**

Chcete‑li přidat textový vodoznak v PPT, PPTX nebo ODP, nejprve přidejte tvar na snímek a poté tomuto tvaru přidejte textový rámeček. Textový rámeček představuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/). Tento typ není odvozen od [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), který nabízí širokou sadu vlastností pro flexibilní umístění vodoznaku. Proto je objekt [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) zabalen do objektu [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/). Pro přidání textu vodoznaku do tvaru použijte metodu [AddTextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/addtextframe/) podle níže uvedeného příkladu.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Viz také" %}} 
- [Jak používat třídu TextFrame](/slides/cs/cpp/text-formatting/)
{{% /alert %}}

### **Přidání textového vodoznaku do celé prezentace**

Pokud chcete přidat textový vodoznak do celé prezentace (tj. na všechny snímky najednou), přidejte jej do [MasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/masterslide/). Zbytek logiky je stejný jako při přidávání vodoznaku na jeden snímek – vytvořte objekt [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) a poté do něj vodoznak přidejte pomocí metody [AddTextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="info" title="Viz také" %}} 
- [Jak používat Slide Master](/slides/cs/cpp/slide-master/)
{{% /alert %}}

### **Nastavení průhlednosti tvaru vodoznaku**

Ve výchozím nastavení je obdélníkový tvar stylizován výplní a barvou čáry. Následující řádky kódu udělají tvar průhledným.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Nastavení písma pro textový vodoznak**

Písmo textového vodoznaku můžete změnit pomocí níže uvedeného kódu.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Nastavení barvy textu vodoznaku**

Pro nastavení barvy textu vodoznaku použijte tento kód:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(u"CONFIDENTIAL");

auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Centrovaný textový vodoznak**

Vodoznak lze centrovat na snímku, a k tomu můžete provést následující:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Obrázek níže ukazuje konečný výsledek.

![Textový vodoznak](text_watermark.png)

## **Obrázkový vodoznak**

### **Přidání obrázkového vodoznaku do prezentace**

Chcete‑li přidat obrázkový vodoznak na snímek prezentace, můžete postupovat následovně:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Zamknutí vodoznaku proti úpravám**

Pokud je třeba zabránit úpravám vodoznaku, použijte metodu [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/get_autoshapelock/) na tvaru. Pomocí této vlastnosti můžete chránit tvar před výběrem, změnou velikosti, přesunem, seskupením s jinými prvky, zamčením textu před úpravou a mnoha dalšími věcmi:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IAutoShapeLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

// Zamknout tvar vodoznaku před úpravami
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->set_SizeLocked(true);
watermarkShape->get_AutoShapeLock()->set_TextLocked(true);
watermarkShape->get_AutoShapeLock()->set_PositionLocked(true);
watermarkShape->get_AutoShapeLock()->set_GroupingLocked(true);
```

## **Přesunutí vodoznaku dopředu**

V Aspose.Slides lze pořadí Z‑tvarů nastavit pomocí metody [IShapeCollection::Reorder](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/reorder/). K tomu je třeba zavolat tuto metodu z kolekce snímků prezentace a předat odkaz na tvar spolu s jeho pořadovým číslem. Tím je možné tvar přesunout dopředu nebo dozadu ve vrstvě snímku. Tato funkce je zvláště užitečná, když potřebujete umístit vodoznak před obsah prezentace:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Nastavení rotace vodoznaku**

Níže je ukázka kódu, jak upravit rotaci vodoznaku tak, aby byl umístěn šikmo napříč snímkem:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/size_f.h>
#include <system/math.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto slideSize = presentation->get_SlideSize()->get_Size();

auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Nastavení názvu pro vodoznak**

Aspose.Slides umožňuje nastavit název tvaru. Pomocí názvu tvaru jej můžete v budoucnu snadno najít a upravit nebo smazat. Pro nastavení názvu tvaru vodoznaku přiřaďte jej metodě [IAutoShape::set_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/set_name/):

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);

watermarkShape->set_Name(u"watermark");
```

## **Odstranění vodoznaku**

Pro odstranění tvaru vodoznaku použijte metodu [IAutoShape::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/get_name/) k jeho vyhledání v kolekci tvarů snímku. Poté předáte tvar vodoznaku metodě [IShapeCollection::Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/remove/):

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_watermark.pptx");
auto slide = presentation->get_Slide(0);

auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(shape);
    }
}
```

## **Ukázkový živý příklad**

Můžete vyzkoušet **Aspose.Slides free** online nástroje [Add Watermark](https://products.aspose.app/slides/cs/watermark) a [Remove Watermark](https://products.aspose.app/slides/cs/watermark/remove-watermark).

![Online nástroje pro přidání a odstranění vodoznaků](online_tools.png)

## **Časté dotazy**

### Co je to vodoznak a proč jej použít?

Vodoznak je textová nebo obrázková překrytí aplikovaná na snímky, která pomáhá chránit duševní vlastnictví, posilovat povědomí o značce nebo zabraňuje neoprávněnému použití prezentací.

### Mohu přidat vodoznak na všechny snímky v prezentaci?

Ano, Aspose.Slides umožňuje programově přidat vodoznak na každý snímek v prezentaci. Můžete projít všechny snímky a aplikovat nastavení vodoznaku jednotlivě.

### Jak mohu upravit průhlednost vodoznaku?

Průhlednost vodoznaku můžete upravit změnou výplňových nastavení ([FillFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/shape/get_fillformat/)) tvaru. Tím zajistíte, že vodoznak bude decentní a nebude rušit obsah snímku.

### Jaké formáty obrázků jsou podporovány pro vodoznaky?

Aspose.Slides podporuje různé formáty obrázků, jako jsou PNG, JPEG, GIF, BMP, SVG a další.

### Mohu přizpůsobit písmo a styl textového vodoznaku?

Ano, můžete zvolit libovolné písmo, velikost a styl, aby odpovídaly designu vaší prezentace a zachovaly konzistenci značky.

### Jak změním polohu nebo orientaci vodoznaku?

Polohu a orientaci vodoznaku můžete programově upravit změnou souřadnic, velikosti a vlastností rotace tvaru.