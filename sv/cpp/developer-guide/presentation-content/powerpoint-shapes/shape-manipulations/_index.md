---
title: Hantera presentationsformer i C++
linktitle: Formhantering
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
- dölja form
- ändra formordning
- hämta Interop-form-ID
- alternativ text för form
- formlayoutformat
- form som SVG
- form till SVG
- justera form
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig skapa, redigera och optimera former i Aspose.Slides för C++ och leverera högpresterande PowerPoint-presentationer."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med former i presentationer med Aspose.Slides. Den visar hur man hittar en form på en bild, klonar den, tar bort den, döljer den, ändrar dess ordning, får dess Interop‑form‑ID och anger alternativ text för identifiering och vidare bearbetning.

Den behandlar också hur man får åtkomst till layoutformat för former, renderar en form som SVG, justerar former på en bild och använder flip‑egenskaper för horisontell och vertikal spegling. Dessutom innehåller artikeln en kort FAQ om formkombination, staplingsordning och låsning av former.

## **Hitta en form på en bild**
Detta ämne beskriver en enkel teknik för att göra det lättare för utvecklare att hitta en specifik form på en bild utan att använda dess interna Id. Det är viktigt att veta att PowerPoint‑presentationsfiler inte har något sätt att identifiera former på en bild förutom ett internt unikt Id. Det kan vara svårt för utvecklare att hitta en form med dess interna unika Id. Alla former som läggs till på bilderna har någon alternativ text. Vi föreslår att utvecklare använder alternativ text för att hitta en specifik form. Du kan använda MS PowerPoint för att definiera den alternativa texten för objekt som du planerar att ändra i framtiden.

Efter att du har ställt in den alternativa texten för önskad form kan du öppna presentationen med Aspose.Slides för C++ och iterera genom alla former som lagts till på en bild. Under varje iteration kan du kontrollera den alternativa texten för formen och den form som har matchande alternativ text blir den form du söker. För att demonstrera denna teknik på ett bättre sätt har vi skapat en metod, [FindShape](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) som gör jobbet att hitta en specifik form i en bild och sedan helt enkelt returnerar den formen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Klona en form**
För att klona en form till en bild med Aspose.Slides för C++:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Hämta referensen till en bild genom att använda dess index.
1. Åtkomst till källbildens form‑samling.
1. Lägg till en ny bild i presentationen.
1. Klona former från källbildens form‑samling till den nya bilden.
1. Spara den modifierade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Ta bort en form**
Aspose.Slides för C++ låter utvecklare ta bort vilken form som helst. För att ta bort formen från en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Åtkomst till den första bilden.
1. Hitta formen med specifik AlternativeText.
1. Ta bort formen.
1. Spara filen till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Dölj en form**
Aspose.Slides för C++ låter utvecklare dölja vilken form som helst. För att dölja formen från en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Åtkomst till den första bilden.
1. Hitta formen med specifik AlternativeText.
1. Dölj formen.
1. Spara filen till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Ändra formens ordning**
Aspose.Slides för C++ låter utvecklare ändra ordningen på former. Att ändra ordning anger vilken form som ligger längst fram eller längst bak. För att ändra ordning på formerna i en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Åtkomst till den första bilden.
1. Lägg till en form.
1. Lägg till text i formens textruta.
1. Lägg till en annan form med samma koordinater.
1. Ändra ordningen på formerna.
1. Spara filen till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Hämta Interop‑form‑ID**
Aspose.Slides för C++ låter utvecklare hämta ett unikt form‑identifieringsnummer i bildens omfattning, i motsats till UniqueId‑egenskapen som ger ett unikt identifieringsnummer i presentationsomfattning. Egenskapen OfficeInteropShapeId lades till IShape‑gränssnittet och Shape‑klassen. Värdet som returneras av OfficeInteropShapeId‑egenskapen motsvarar värdet av Id för Microsoft.Office.Interop.PowerPoint.Shape‑objektet. Nedan visas exempelprogramkoden.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **Ange AlternativeText‑egenskapen**
Aspose.Slides för C++ låter utvecklare ange AlternateText för vilken form som helst. För att ange AlternateText för en form, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation).
1. Åtkomst till den första bilden.
1. Lägg till någon form på bilden.
1. Gör något arbete med den nylagda formen.
1. Gå igenom former för att hitta en form.
1. Ange AlternativeText.
1. Spara filen till disk.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Åtkomst till layoutformat för en form**
Aspose.Slides för C++ låter utvecklare få åtkomst till layoutformat för en form. Denna artikel visar hur du kan komma åt egenskaperna **FillFormat** och **LineFormat** för en form.

Nedan visas exempelprogramkoden.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Rendera en form som SVG**
Nu stödjer Aspose.Slides för C++ rendering av en form som SVG. Metoden WriteAsSvg (och dess överlagring) har lagts till i Shape‑klassen och IShape‑gränssnittet. Metoden gör det möjligt att spara innehållet i en form som en SVG‑fil. Kodsnutten nedan visar hur du exporterar en bilds form till en SVG‑fil.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Justering av former**
Aspose.Slides låter dig justera former antingen relativt till bildens marginaler eller relativt till varandra. För detta ändamål har en överlagrad metod [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) lagts till. Uppräkningen [ShapesAlignmentType](https://reference.aspose.com/slides/sv/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) definierar möjliga justeringsalternativ.

**Exempel 1**

Källkoden nedan justerar former med index 1, 2 och 4 längs bildens övre kant.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Exempel 2**

Exemplet nedan visar hur du justerar hela samlingen av former relativt till den allra nedersta formen i samlingen.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Flip‑egenskaper**

I Aspose.Slides ger klassen [ShapeFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapeframe/) kontroll över horisontell och vertikal spegling av former via egenskaperna `flipH` och `flipV`. Båda egenskaperna är av typen [NullableBool](https://reference.aspose.com/slides/sv/cpp/aspose.slides/nullablebool/), vilket tillåter värdena `True` för att spegla, `False` för ingen spegling eller `NotDefined` för att använda standardbeteendet. Dessa värden är åtkomliga via en forms [Frame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_frame/).

För att ändra flip‑inställningarna konstrueras en ny [ShapeFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapeframe/)‑instans med formens nuvarande position och storlek, önskade värden för `flipH` och `flipV` samt rotationsvinkeln. Genom att tilldela denna instans till formens [Frame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_frame/) och spara presentationen appliceras speglingarna och de skrivs till utskriftsfilen.

Anta att vi har en fil sample.pptx där den första bilden innehåller en enda form med standard‑flip‑inställningar, som visas nedan.

![The shape to be flipped](shape_to_be_flipped.png)

Följande kodexempel hämtar formens aktuella flip‑egenskaper och speglar den både horisontellt och vertikalt.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Hämta den horisontella flip‑egenskapen för formen.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Hämta den vertikala flip‑egenskapen för formen.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Flippa horisontellt.
auto flipV = NullableBool::True; // Flippa horisontellt.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Resultatet:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kan jag kombinera former (union/intersect/subtract) på en bild som i en desktop‑editor?**

Det finns inget inbyggt API för booleska operationer. Du kan approximera det genom att konstruera önskad kontur själv—t.ex. beräkna den resulterande geometrin (via [GeometryPath](https://reference.aspose.com/slides/sv/cpp/aspose.slides/geometrypath/)) och skapa en ny form med den konturen, eventuellt ta bort de ursprungliga.

**Hur kan jag kontrollera staplingsordningen (z‑order) så att en form alltid ligger "överst"?**

Ändra infognings‑/flyttningsordningen i bildens [shapes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseslide/get_shapes/)‑samling. För förutsägbara resultat, slutför z‑ordningen efter alla övriga bildmodifieringar.

**Kan jag "låsa" en form så att användare inte kan redigera den i PowerPoint?**

Ja. Ställ in [form‑nivå skydds‑flaggor](/slides/sv/cpp/applying-protection-to-presentation/) (t.ex. lås urval, flytt, storleksändring, textredigering). Om så önskas, spegla begränsningarna på mastern eller layouten. Observera att detta är ett UI‑skydd, inte en säkerhetsfunktion; för starkare skydd kombinera med fil‑nivå begränsningar som [rekommendationer om skrivskydd eller lösenord](/slides/sv/cpp/password-protected-presentation/).