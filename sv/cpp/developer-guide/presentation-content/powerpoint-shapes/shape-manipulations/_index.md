---
title: Hantera presentationsformer i C++
linktitle: Formmanipulation
type: docs
weight: 40
url: /sv/cpp/shape-manipulations/
keywords:
- PowerPoint-form
- presentationsform
- form på bild
- hitta form
- klona form
- ta bort form
- dölj form
- ändra formordning
- hämta interop-form-ID
- formens alternativa text
- formens layoutformat
- form som SVG
- form till SVG
- justera form
- vänd form
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du identifierar, klonar, tar bort, döljer, omordnar, exporterar, justerar och vänder presentationsformer med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides for C++ representerar formerna på en bild som en ordnad [IShapeCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/). Samlingen är både platsen där du hittar och ändrar former samt källan till deras staplingsordning: index `0` är den längst bak, medan det sista indexet är den längst fram.

Denna artikel följer den modellen. Den förklarar först hur man identifierar en form på ett pålitligt sätt, sedan visar hur man klonar, tar bort, döljer och omordnar former. De sista avsnitten täcker format på layoutnivå, SVG‑export, justering och flip‑inställningar. Varje exempel är oberoende, så du kan bara använda de operationer ditt arbetsflöde kräver.

## **Identifiera och hitta former**

- [Name](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_name/) är användbart för utvecklarkontrollerade mallar och är enkelt att inspektera i PowerPoints urvals‑panel. Namn kan redigeras och är inte garanterade att vara unika, så etablera en namngivningskonvention om kod beror på dem.
- [AlternativeText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_alternativetext/) är användbart när en tillgänglighetsbeskrivning eller en författar‑tillhandahållen tagg redan identifierar formen. Den är synlig för användare, kan lokaliseras eller skrivas om för tillgänglighet, och är inte garanterad att vara unik. Använd inte meningsfull tillgänglighetstext som en databaskey i hemlighet.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_officeinteropshapeid/) är en skrivskyddad identifierare som är unik inom en bild och motsvarar den form‑ID som används av PowerPoint‑interop. Använd den när du integrerar med PowerPoint eller när du behöver en entydig referens under en forms livstid. En klonad eller åter‑skapad form är en annan form och får sin egen ID.

Den relaterade egenskapen [UniqueId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_uniqueid/) har presentationsomfattning, men är avsedd för tillägg och kan omfördelas. Den bör inte behandlas som en permanent extern nyckel. Om långsiktig identitet är väsentlig, behåll mappningen i programdata och validera att den förväntade formen fortfarande finns.

Följande exempel söker efter `Name` och rapporterar slide‑omfattande interop‑ID. När mallen inte innehåller den förväntade formen, rapporterar koden det resultatet istället för att fortsätta med fel objekt.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> targetShape;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"RevenueChart")
    {
        targetShape = shape;
        break;
    }
}

if (targetShape == nullptr)
{
    Console::WriteLine(u"The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console::WriteLine(String::Format(u"Found {0}; interop ID: {1}", targetShape->get_Name(), targetShape->get_OfficeInteropShapeId()));
}

presentation->Dispose();
```

När en operation är specifik för en formtyp, kontrollera interfacet innan du använder typ‑specifika medlemmar. Detta exempel uppdaterar text och alternativ text endast om det namngivna objektet är en [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/).

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IShape> candidate;
for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"StatusLabel")
    {
        candidate = shape;
        break;
    }
}

if (candidate != nullptr && ObjectExt::Is<IAutoShape>(candidate))
{
    auto autoShape = ExplicitCast<IAutoShape>(candidate);
    autoShape->get_TextFrame()->set_Text(u"Approved");
    autoShape->set_AlternativeText(u"Approval status: approved");
    presentation->Save(u"identified-shape.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"'StatusLabel' is missing or is not an AutoShape.");
}

presentation->Dispose();
```

## **Ändra form‑samlingen**

Metoderna för att lägga till, klona, ta bort och omordna verkar på samlingen omedelbart. Om en operation förändrar antalet eller ordningen av former, fortsätt inte att förlita dig på index som fångades innan den operationen.

### **Klona en form**

[AddClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/addclone/) skapar en oberoende kopia och lägger till den i mål‑samlingen. [InsertClone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/insertclone/) skapar också en kopia men placerar den på ett angivet z‑order‑index. Överlagringarna som accepterar koordinater flyttar klonen utan att ändra dess storlek; överlagringar med bredd och höjd kan även ändra storlek.

Exemplet skapar en målbild, klonar en etiketterad rektangel till fronten och infogar en andra klon längst bak. Ändringar i någon av klonerna ändrar inte källformen.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto sourceSlide = presentation->get_Slide(0);
auto sourceShape = sourceSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 180, 60);
sourceShape->set_Name(u"SourceLabel");
sourceShape->get_TextFrame()->set_Text(u"Source");

auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto destinationSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

auto frontCloneShape = destinationSlide->get_Shapes()->AddClone(sourceShape, 80, 80);
frontCloneShape->set_Name(u"FrontClone");
if (ObjectExt::Is<IAutoShape>(frontCloneShape))
{
    auto frontClone = ExplicitCast<IAutoShape>(frontCloneShape);
    frontClone->get_TextFrame()->set_Text(u"Front clone");
}
else
{
    Console::WriteLine(u"The front clone is not an AutoShape; its text was not changed.");
}

auto backCloneShape = destinationSlide->get_Shapes()->InsertClone(0, sourceShape, 80, 180);
backCloneShape->set_Name(u"BackClone");
if (ObjectExt::Is<IAutoShape>(backCloneShape))
{
    auto backClone = ExplicitCast<IAutoShape>(backCloneShape);
    backClone->get_TextFrame()->set_Text(u"Back clone");
}
else
{
    Console::WriteLine(u"The back clone is not an AutoShape; its text was not changed.");
}

presentation->Save(u"cloned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kloning kopierar formens innehåll och formatering, inklusive dess namn och alternativ text. Tilldela nya logiska identifierare till klonen när dessa värden måste vara unika. Resurser som används av komplexa former hanteras av presentationen, men en klon förblir ett nytt samlingsobjekt med en ny formidentitet.

### **Ta bort former**

[Remove](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/remove/) tar bort ett specifikt formobjekt från dess samling. När du tar bort flera matchningar under en indexerad iteration, traversera från slutet så att varje återstående index förblir giltigt.

Detta exempel tar bort varje form med ett angivet namn. Det läser den aktuella indexerade formen, inte ett fast samlingsobjekt, och kastar inte formen i onödan.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto keepShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 140, 60);
keepShape->set_Name(u"Keep");

auto firstTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 220, 40, 80, 80);
firstTemporaryShape->set_Name(u"Temporary");

auto secondTemporaryShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 340, 40, 100, 80);
secondTemporaryShape->set_Name(u"Temporary");

for (int32_t i = slide->get_Shapes()->get_Count() - 1; i >= 0; --i)
{
    auto shape = slide->get_Shape(i);
    if (shape->get_Name() == u"Temporary")
    {
        slide->get_Shapes()->Remove(shape);
    }
}

presentation->Save(u"removed-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Efter borttagning förändras antalet former och indexen för senare former. Referenser till opåverkade former förblir mer pålitliga än sparade index. Tänk också på kopplingar, animationer och andra presentationsfunktioner som kan referera till det borttagna objektet; att ta bort en synlig form kan ändra mer än bildens utseende.

### **Dölj en form**

Att sätta [Hidden](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/set_hidden/) till `true` behåller formen i samlingen men förhindrar att den visas i den normala presentationen. Dess index, formatering och innehåll förblir tillgängliga för kod, så dölja är lämpligt för valfria element som kan återställas senare.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto visibleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 160, 60);
visibleShape->set_Name(u"VisibleLabel");

auto optionalShape = slide->get_Shapes()->AddAutoShape(ShapeType::Moon, 240, 40, 100, 100);
optionalShape->set_Name(u"OptionalDecoration");

for (auto shape : slide->get_Shapes())
{
    if (shape->get_Name() == u"OptionalDecoration")
    {
        shape->set_Hidden(true);
    }
}

presentation->Save(u"hidden-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Döljning är inte en borttagning eller säkerhet. Objektet kan fortfarande upptäckas och visas igen av en användare eller av kod, och det förblir en del av presentationsfilen.

### **Ändra Z‑ordning**

Överlappande former målas i samlingsordning. [Reorder](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishapecollection/reorder/) flyttar en befintlig form till ett mål‑index utan att klona den. Index `0` är bakre; `Count - 1` är främre.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto blueRectangle = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 220, 120);
blueRectangle->set_Name(u"BlueRectangle");
blueRectangle->get_FillFormat()->set_FillType(FillType::Solid);
blueRectangle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());

auto orangeEllipse = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 180, 140, 220, 120);
orangeEllipse->set_Name(u"OrangeEllipse");
orangeEllipse->get_FillFormat()->set_FillType(FillType::Solid);
orangeEllipse->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());

slide->get_Shapes()->Reorder(slide->get_Shapes()->get_Count() - 1, blueRectangle);
presentation->Save(u"reordered-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Rektangeln skapas först och sitter initialt bakom ellipsen. Att flytta den till det sista indexet placerar den framför. Slutför z‑ordning efter att du har lagt till eller klonat alla relaterade former, eftersom dessa operationer lägger till eller infogar nya samlingsobjekt och kan förändra den avsedda stapeln.

## **Inspektera former på layout‑bilder**

Normala bilder, layout‑bilder och master‑bilder har separata form‑samlingar. En form i en layout‑samling är inte samma objekt som en liknande placerad form på en normal bild. Inspektera layout‑former när du behöver förstå eller ändra formatering som tillhandahålls av en layout.

Följande exempel läser varje layout‑forms [FillFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_fillformat/) och [LineFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_lineformat/) utan att anta att varje form är en `AutoShape`.

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");

for (auto layoutSlide : presentation->get_LayoutSlides())
{
    for (auto shape : layoutSlide->get_Shapes())
    {
        auto fillType = shape->get_FillFormat()->get_FillType();
        auto lineWidth = shape->get_LineFormat()->get_Width();
        Console::WriteLine(String::Format(u"{0} / {1}: fill={2}, line width={3}", layoutSlide->get_Name(), shape->get_Name(), fillType, lineWidth));
    }
}

presentation->Dispose();
```

Att redigera en layout kan påverka flera bilder som använder den. Innan du ändrar en layout‑form, avgör om en normal bild ärver objektet eller innehåller en lokal överskrivning, och testa varje bild som använder den layouten.

## **Exportera en form till SVG**

[WriteAsSvg](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/writeassvg/) skriver en forms renderade innehåll till en ström. Resultatet innehåller formen, inte hela bildens bakgrund eller närliggande former.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

if (slide->get_Shapes()->get_Count() == 0)
{
    Console::WriteLine(u"Slide 1 does not contain a shape to export.");
}
else
{
    auto shape = slide->get_Shape(0);
    auto svgStream = File::Create(u"shape.svg");
    shape->WriteAsSvg(svgStream);
    svgStream->Close();
}

presentation->Dispose();
```

Behåll presentationen öppen under rendering. Utdata beror på formens formatering och på resurser såsom teckensnitt och bilder. Om du behöver hela sammansättningen, exportera bilden istället för en enskild form. Anroparen äger strömmen och måste stänga eller disponera den.

## **Justera former**

[SlideUtil::AlignShapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides.util/slideutil/alignshapes/) överlagringarna justerar antingen alla former eller valda samlingsindex. [ShapesAlignmentType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapesalignmenttype/) specificerar kanten, mittlinjen eller fördelningsläget. Sätt `alignToSlide` till `true` för att använda bildens kanter; sätt det till `false` för att justera de valda formerna relativt varandra.

Detta exempel justerar tre former till bildens övre kant. De returnerade form‑referenserna konverteras till deras aktuella index omedelbart före justeringen.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/ShapesAlignmentType.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto firstShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 60, 80, 120, 50);
auto secondShape = slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 240, 160, 120, 50);
auto thirdShape = slide->get_Shapes()->AddAutoShape(ShapeType::Triangle, 420, 240, 120, 50);
firstShape->set_Name(u"FirstAlignedShape");
secondShape->set_Name(u"SecondAlignedShape");
thirdShape->set_Name(u"ThirdAlignedShape");

auto shapeIndexes = MakeArray<int32_t>({slide->get_Shapes()->IndexOf(firstShape), slide->get_Shapes()->IndexOf(secondShape), slide->get_Shapes()->IndexOf(thirdShape)});

SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, slide, shapeIndexes);
presentation->Save(u"aligned-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Justering ändrar positioner, inte z‑ordning. Relativ justering kräver normalt minst två former, medan horisontell eller vertikal fördelning kräver tillräckligt många former för att definiera avstånd. Räkna om index om du ändrar samlingen innan du anropar metoden.

## **Vänd en form**

[ShapeFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapeframe/)‑klassen lagrar position, storlek, horisontella och vertikala vändinställningar samt rotation. Dess `FlipH` och `FlipV`‑värden använder [NullableBool](https://reference.aspose.com/slides/sv/cpp/aspose.slides/nullablebool/): `True` aktiverar vändning, `False` inaktiverar den, och `NotDefined` bevarar det ospecificerade/standardtillståndet.

Inmatningspresentationen nedan innehåller en ovänd form.

![Formen innan vändning](shape_to_be_flipped.png)

Exemplet bevarar alla andra ramvärden och ersätter endast de två vändinställningarna. Detta är viktigt eftersom tilldelning av en ny [Frame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/set_frame/) ersätter hela ramen.

```cpp
#include <DOM/IShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeFrame.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto frame = shape->get_Frame();

Console::WriteLine(String::Format(u"Horizontal flip before change: {0}", frame->get_FlipH()));
Console::WriteLine(String::Format(u"Vertical flip before change: {0}", frame->get_FlipV()));

shape->set_Frame(MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y(), frame->get_Width(), frame->get_Height(), NullableBool::True, NullableBool::True, frame->get_Rotation()));

presentation->Save(u"flipped-shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Den sparade formen är speglad horisontellt och vertikalt samtidigt som dess position, storlek och rotation behålls.

![Formen efter vändning](flipped_shape.png)

## **FAQ**

**Ska jag använda ett samlings‑index som formidentifierare?**

Endast för kortlivad bearbetning när samlingen inte kommer att förändras innan indexet används. Föredra en validerad `Name`‑ eller `AlternativeText`‑konvention för skapade mallar, eller `OfficeInteropShapeId` för slide‑omfattande interop‑arbete.

**Tar dölja en form bort den från z‑ordningen?**

Nej. En dold form förblir i samlingen på samma index. Den kan hittas, omordnas, redigeras eller göras synlig igen.

**Varför dök en klonad form upp framför en annan form?**

`AddClone` lägger till klonen i slutet av samlingen, vilket är framdelen av z‑ordningen. Använd `InsertClone` för att välja det initiala indexet eller `Reorder` efter att alla former har lagts till.