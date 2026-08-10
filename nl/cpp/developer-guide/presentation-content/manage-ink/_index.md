---
title: Inkobjecten in PowerPoint beheren in C++
linktitle: Inkt beheren
type: docs
weight: 95
url: /nl/cpp/manage-ink/
keywords:
- inkt
- inkobject
- inkspoor
- ink beheren
- inkt tekenen
- tekenen
- inkexport
- inkrendering
- inkt verbergen
- IInkOptions
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer PowerPoint-inkobjecten, bewerk sporen en penseel‑eigenschappen, en regel de weergave van inkt tijdens PDF, HTML, SVG, TIFF en afbeeldings‑export met Aspose.Slides voor C++."
---
## **Inleiding**

PowerPoint biedt een inkt‑functie waarmee u vrije tekenstreken kunt maken. Inkt kan worden gebruikt om andere objecten te markeren, verbindingen en processen weer te geven en de aandacht op specifieke items op een dia te vestigen.

De [Aspose.Slides.Ink](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/) namespace bevat de klassen en interfaces die nodig zijn om met inktobjecten te werken. Bijvoorbeeld, de [IInk](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iink/) interface vertegenwoordigt een inktobject op een dia.

## **Verschillen tussen reguliere objecten en inktobjecten**

Objecten op een PowerPoint‑dia worden doorgaans weergegeven door vormobjecten. In de eenvoudigste vorm is een vorm een container die het gebied van het object zelf (het frame) definieert, samen met eigenschappen zoals de grootte van de container, vorm en achtergrond. Zie voor meer informatie [Shape Layout Format](https://docs.aspose.com/slides/nl/cpp/shape-manipulations/#access-layout-formats-for-shape).

Echter, wanneer PowerPoint een inktobject verwerkt, negeert het alle eigenschappen van het objectframe (container) behalve de grootte. De grootte van het containergebied wordt bepaald door de standaardmethoden [IShape::get_Width](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_width/) en [IShape::get_Height](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Inktsporen**

Een inktspoor is een basiselement dat wordt gebruikt om de traject van een pen vast te leggen terwijl een gebruiker digitale inkt schrijft. Een spoor slaat een reeks verbonden punten op.

De eenvoudigste vorm van codering specificeert de X‑ en Y‑coördinaten van elk monsterpunt. Wanneer alle verbonden punten worden gerenderd, produceren ze een afbeelding zoals deze:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penseleigenschappen voor tekenen**

Een penseel wordt gebruikt om lijnen te tekenen die de punten van een inktspoor met elkaar verbinden. Het penseel heeft zijn eigen kleur en grootte, weergegeven door de methoden [IInkBrush::get_Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iinkbrush/get_color/) en [IInkBrush::get_Size](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Ink Penseelkleur Instellen**

Deze C++‑code toont hoe u de kleur van een inktpenseel instelt:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **Ink Penseelgrootte Instellen**

Deze C++‑code toont hoe u de grootte van een inktpenseel instelt:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

Over het algemeen komen de breedte en hoogte van een penseel niet overeen, waardoor PowerPoint de penseelgrootte niet weergeeft (de overeenkomstige gegevenssectie is grijs weergegeven). Wanneer de breedte en hoogte van het penseel wel overeenkomen, toont PowerPoint de grootte op deze manier:

![ink_powerpoint3](ink_powerpoint3.png)

Voor de duidelijkheid verhogen we de hoogte van het inktobject en bekijken we de belangrijke afmetingen:

![ink_powerpoint4](ink_powerpoint4.png)

De container (frame) houdt geen rekening met de grootte van de penselen – hij gaat er altijd vanuit dat de lijndikte nul is (zie de vorige afbeelding).

Daarom moet, om het zichtbare gebied van het volledige inktobject te bepalen, de penseelgrootte van zijn sporen in aanmerking worden genomen. Hier is het doelobject (het handgeschreven tekstspoor) geschaald naar de grootte van de container (frame). Wanneer de grootte van de container verandert, blijft de penseelgrootte constant, en vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint hanteert een vergelijkbaar gedrag voor tekstobjecten:

![ink_powerpoint6](ink_powerpoint6.png)

## **Inktweergave tijdens export en rendering regelen**

Aspose.Slides biedt de interface [IInkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/) om te regelen hoe inktobjecten verschijnen in geëxporteerde of gerenderde output. U kunt de methoden gebruiken om inkt volledig te verbergen of om te wijzigen hoe maskerbewerkingen van inktpenselen worden geïnterpreteerd.

Inktopties zijn beschikbaar via de export‑ of renderingopties voor verschillende outputtypes:

| Uitvoer | Ink‑opties methode |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Slide image | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Via deze methoden zijn dezelfde twee instellingen beschikbaar:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/set_hideink/) bepaalt of inktobjecten worden opgenomen in de output. De standaardwaarde is `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) bepaalt of een maskerbewerking wordt geïnterpreteerd als opacity bij het renderen van een inktpenseel. De standaardwaarde is `true`; stel deze in op `false` om in plaats daarvan de ROP‑bewerking te gebruiken.

### **Inkobjecten verbergen in PDF‑output**

Standaard blijven inktobjecten zichtbaar tijdens export. Roep [IInkOptions::set_HideInk](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/set_hideink/) aan met `true` wanneer u een schone output nodig heeft zonder handgeschreven aantekeningen of andere inktinhoud.

Het volgende C++‑voorbeeld exporteert een presentatie naar PDF terwijl alle inktobjecten worden verborgen:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Inkobjecten verbergen bij het renderen van een dia als afbeelding**

Om inktobjecten te verbergen bij het renderen van dia's als bitmap‑afbeeldingen, configureer [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) en geef de renderingopties door aan de methode [ISlide::GetImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/getimage/).

Het volgende C++‑voorbeeld rendert de eerste dia als een PNG‑afbeelding zonder inktobjecten:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **Inktmasker Rendering regelen**

De methode [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) regelt hoe maskerbewerkingen worden geïnterpreteerd bij het renderen van inktpenselen. De standaardwaarde is `true`, waardoor opacity wordt gebruikt. Roep de methode aan met `false` om in plaats daarvan de ROP‑bewerking te gebruiken.

Het volgende C++‑voorbeeld exporteert een dia naar SVG en gebruikt ROP‑gebaseerde rendering voor inktmaskerbewerkingen:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

Dezelfde instelling kan worden toegepast via [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) bij het exporteren van een presentatie of het renderen van een dia naar TIFF.

### **Kies of u Ink wilt verbergen of behouden**

Gebruik [IInkOptions::set_HideInk](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/set_hideink/) met `true` wanneer het geëxporteerde bestand een schone versie van een geannoteerde presentatie moet zijn, bijvoorbeeld een definitieve kopie bedoeld voor distributie zonder reviewmarkeringen.

Laat inkt zichtbaar (de standaardinstelling `false`) wanneer inktannotaties deel uitmaken van de beoogde inhoud, zoals reviewcommentaren, handgeschreven notities, markeringen of tekeningen die zichtbaar moeten blijven in het geëxporteerde resultaat. Hierdoor kunnen toepassingen aparte review‑ en definitieve outputs genereren vanuit dezelfde presentatie zonder de bron‑inkobjecten te wijzigen.

## **FAQ**

**Kan ik de kleur of grootte van een bestaande inktstreep wijzigen?**

Ja. Haal het spoor op via [IInk::get_Traces](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iink/get_traces/), wijzig vervolgens zijn [IInkTrace::get_Brush](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iinktrace/get_brush/). U kunt [IInkBrush::set_Color](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iinkbrush/set_color/) en [IInkBrush::set_Size](https://reference.aspose.com/slides/nl/cpp/aspose.slides.ink/iinkbrush/set_size/) aanroepen op het penseel.

**Verandert het verbergen van inkt de bronpresentatie?**

Nee. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/iinkoptions/set_hideink/) heeft alleen invloed op het gerenderde of geëxporteerde resultaat; het verwijdert of wijzigt geen inktobjecten in de bronpresentatie.

**Welke exportformaten ondersteunen inktopties?**

U kunt inktopties configureren voor PDF, HTML, SVG, TIFF en bitmap‑dia‑afbeeldingen via de overeenkomstige export‑ of renderingopties die hierboven zijn weergegeven.

**Verdere lectuur**

* Voor algemene informatie over vormen, zie de sectie [PowerPoint Shapes](https://docs.aspose.com/slides/nl/cpp/powerpoint-shapes/).
* Voor meer informatie over effectieve waarden, zie [Shape Effective Properties](https://docs.aspose.com/slides/nl/cpp/shape-effective-properties/#get-effective-font-height-value).
* Voor details over PDF‑export, zie [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/nl/cpp/convert-powerpoint-to-pdf/).
* Voor details over HTML‑export, zie [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/nl/cpp/convert-powerpoint-to-html/).
* Voor details over SVG‑export, zie [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/nl/cpp/render-a-slide-as-an-svg-image/).
* Voor details over TIFF‑export, zie [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/nl/cpp/convert-powerpoint-to-tiff/).
* Voor details over dia‑naar‑afbeelding rendering, zie [Convert Presentation Slides to Images](https://docs.aspose.com/slides/nl/cpp/convert-slide/).