---
title: Hantera bläckobjekt i C++
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/cpp/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- bläckexport
- bläckrendering
- dölj bläck
- IInkOptions
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera PowerPoint bläckobjekt, redigera spår och penselegenskaper samt kontrollera bläckens utseende vid export till PDF, HTML, SVG, TIFF och bild med Aspose.Slides för C++."
---
## **Introduktion**

PowerPoint tillhandahåller en bläckfunktion som låter dig rita fria streck. Bläck kan användas för att framhäva andra objekt, visa kopplingar och processer samt rikta uppmärksamheten mot specifika objekt på en bild.

Namnområdet [Aspose.Slides.Ink](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/) innehåller de klasser och gränssnitt som behövs för att arbeta med bläckobjekt. Till exempel representerar gränssnittet [IInk](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) tillsammans med egenskaper som behållarens storlek, form och bakgrund. För mer information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/cpp/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignoreras alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardmetoder [IShape::get_Width](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_width/) och [IShape::get_Height](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/get_height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundläggande element som används för att registrera pennans bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste kodningsformen specificerar X‑ och Y‑koordinaterna för varje samplingspunkt. När alla sammankopplade punkter renderas bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselinställningar för ritning**

En pensel används för att rita linjer som förbinder punkterna i ett bläckspår. Penseln har sin egen färg och storlek, som representeras av metoderna [IInkBrush::get_Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iinkbrush/get_color/) och [IInkBrush::get_Size](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iinkbrush/get_size/).

### **Ställ in bläckpenselns färg**

Denna C++‑kod visar hur du anger färgen på en bläckpensel:

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

### **Ställ in bläckpenselns storlek**

Denna C++‑kod visar hur du anger storleken på en bläckpensel:

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

Generellt matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är gråtonad). När penselns bredd och höjd matchar visar PowerPoint storleken så här:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull ökar vi höjden på bläckobjektet och granskar de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

För att bestämma det synliga området för hela bläckobjektet måste penselns storlek för dess spår tas med i beräkningen. Här har målobjektet (det handskrivna textspåret) skalats till storleken på behållaren (ramen). När behållarens storlek ändras förblir penselns storlek konstant, och vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint har liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrollera bläckens utseende under export och rendering**

Aspose.Slides tillhandahåller gränssnittet [IInkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/) för att styra hur bläckobjekt visas i exporterade eller renderade resultat. Du kan använda dess metoder för att helt dölja bläck eller ändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ finns tillgängliga via export‑ eller renderingsalternativen för flera utmatningstyper:

| Utdata | Metod för bläckalternativ |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| Bild av bild | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

Samma två inställningar är tillgängliga via dessa metoder:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/set_hideink/) bestämmer om bläckobjekt ska inkluderas i resultatet. Standardvärdet är `false`.
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) bestämmer om en maskoperation tolkas som opacitet vid rendering av en bläckpensel. Standardvärdet är `true`; sätt det till `false` för att använda ROP‑operationen istället.

### **Dölj bläckobjekt i PDF-utdata**

Som standard förblir bläckobjekt synliga under export. Anropa [IInkOptions::set_HideInk](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/set_hideink/) med `true` när du behöver ett rent resultat utan handskrivna kommentarer eller annat bläckinnehåll.

Följande C++‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

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

### **Dölj bläckobjekt när en bild renderas som en bild**

För att dölja bläckobjekt när bilder renderas som bitmap‑bilder konfigurerar du [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) och skickar renderingsalternativen till metoden [ISlide::GetImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islide/getimage/).

Följande C++‑exempel renderar den första bilden som en PNG‑fil utan bläckobjekt:

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

### **Kontrollera rendering av bläckmask**

Metoden [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) styr hur maskoperationer tolkas när bläckpenslar renderas. Standardvärdet är `true`, vilket använder opacitet. Anropa metoden med `false` för att använda ROP‑operationen istället.

Följande C++‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmaskoperationer:

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

Samma inställning kan tillämpas via [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) när en presentation exporteras eller en bild renderas till TIFF.

### **Välj om bläck ska döljas eller bevaras**

Använd [IInkOptions::set_HideInk](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/set_hideink/) med `true` när den exporterade filen ska vara en ren version av en annoterad presentation, till exempel en slutgiltig kopia avsedd för distribution utan granskningsmarkeringar.

Låt bläck vara synligt (standardvärdet `false`) när bläckanteckningar är en del av det avsedda innehållet, såsom granskningskommentarer, handskrivna anteckningar, markeringar eller teckningar som ska förbli synliga i det exporterade resultatet. Detta möjliggör att applikationer kan generera separata gransknings‑ och slutversioner från samma presentation utan att ändra källbläckobjekten.

## **Vanliga frågor**

**Kan jag ändra färg eller storlek på ett befintligt bläckstreck?**

Ja. Hämta spåret från [IInk::get_Traces](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iink/get_traces/), ändra sedan dess [IInkTrace::get_Brush](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iinktrace/get_brush/). Du kan anropa [IInkBrush::set_Color](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iinkbrush/set_color/) och [IInkBrush::set_Size](https://reference.aspose.com/slides/sv/cpp/aspose.slides.ink/iinkbrush/set_size/) på penseln.

**Påverkar dölja av bläck källpresentationen?**

Nej. [IInkOptions::set_HideInk](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/iinkoptions/set_hideink/) påverkar endast det renderade eller exporterade resultatet; den tar inte bort eller modifierar bläckobjekt i källpresentationen.

**Vilka exportformat stödjer bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bilder av bilder via de motsvarande export‑ eller renderingsalternativen som visas ovan.

**Vidare läsning**

* För allmän information om former, se avsnittet [PowerPoint Shapes](https://docs.aspose.com/slides/sv/cpp/powerpoint-shapes/).
* För information om effektiva värden, se [Shape Effective Properties](https://docs.aspose.com/slides/sv/cpp/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/sv/cpp/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/sv/cpp/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/sv/cpp/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/sv/cpp/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Convert Presentation Slides to Images](https://docs.aspose.com/slides/sv/cpp/convert-slide/).