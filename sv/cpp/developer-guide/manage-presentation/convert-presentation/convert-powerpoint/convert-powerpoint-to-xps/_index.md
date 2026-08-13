---
title: Konvertera PowerPoint-presentationer till XPS i C++
linktitle: PowerPoint till XPS
type: docs
weight: 70
url: /sv/cpp/convert-powerpoint-to-xps
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till XPS
- presentation till XPS
- bild till XPS
- PPT till XPS
- PPTX till XPS
- spara PPT som XPS
- spara PPTX som XPS
- exportera PPT till XPS
- exportera PPTX till XPS
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Konvertera PowerPoint PPT/PPTX till högkvalitativ, plattformsoberoende XPS i C++ med Aspose.Slides. Få steg-för-steg-guide och exempel på kod."
---
## **Översikt**

Aspose.Slides låter dig konvertera PowerPoint-presentationer till XPS genom att spara en PPT- eller PPTX-fil i XPS-formatet. Den här artikeln förklarar när XPS-formatet kan vara användbart och visar hur du utför konverteringen med Aspose.Slides med antingen standardinställningar eller anpassade [XpsOptions](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/xpsoptions/) inställningar.

## **Om XPS**
Microsoft utvecklade [XPS](https://docs.fileformat.com/page-description-language/xps/) som ett alternativ till [PDF](https://docs.fileformat.com/pdf/). Det låter dig skriva ut innehåll genom att generera en fil som är mycket lik en PDF. XPS-formatet är baserat på XML. Layouten eller strukturen i en XPS-fil förblir densamma på alla operativsystem och skrivare. 

## **När du ska använda Microsoft XPS-format**

{{% alert color="info" %}} 

För att se hur Aspose.Slides konverterar PPT- eller PPTX-presentation till XPS-formatet kan du kolla in [denna gratis online‑konverteringsapp](https://products.aspose.app/slides/sv/conversion). 

{{% /alert %}} 

Om du vill minska lagringskostnaderna kan du konvertera din Microsoft PowerPoint-presentation till XPS-formatet. På så sätt blir det enklare att spara, dela och skriva ut dina dokument. 

Microsoft fortsätter att implementera starkt stöd för XPS i Windows (även i Windows 10), så du kan överväga att spara filer i detta format. Om du arbetar med Windows 8.1, Windows 8, Windows 7 och Windows Vista kan XPS faktiskt vara ditt bästa alternativ för vissa operationer. 

- **Windows 8** använder OXPS (Open XPS)-formatet för XPS‑filer. OXPS är en standardiserad version av det ursprungliga XPS-formatet. Windows 8 ger bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare/läsare och möjlighet att skriva ut till XPS finns tillgänglig. 
  - **PDF:** PDF‑läsare finns men ingen möjlighet att skriva ut till PDF. 

- **Windows 7 och Windows Vista** använder det ursprungliga XPS‑formatet. Dessa operativsystem ger också bättre stöd för XPS‑filer än för PDF‑filer. 
  - **XPS:** Inbyggd XPS‑visare och möjlighet att skriva ut till XPS finns tillgänglig. 
  - **PDF:** Ingen PDF‑läsare. Ingen möjlighet att skriva ut till PDF. 

|<p>**Input PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Output XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft implementerade så småningom stöd för utskriftsoperationer i PDF genom funktionen Skriv ut till PDF i Windows 10. Tidigare förväntades användare skriva ut dokument via XPS-formatet. 

## **XPS-konvertering med Aspose.Slides**

I [**Aspose.Slides**](https://products.aspose.com/slides/sv/cpp/) för C++ kan du använda [**Save**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)-metoden som exponeras av [Presentation](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation)-klassen för att konvertera hela presentationen till ett XPS‑dokument. 

När du konverterar en presentation till XPS måste du spara presentationen med någon av dessa inställningar:

- Standardinställningar (utan [**XPSOptions**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.xps_options))
- Anpassade inställningar (med [**XPSOptions**](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.export.xps_options))

### **Konvertera presentationer till XPS med standardinställningar**

Detta exempel i C++ visar hur du konverterar en presentation till ett XPS‑dokument med standardinställningar:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantiate a Presentation object that represents a presentation file
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// Saving the presentation to XPS document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```


### **Konvertera presentationer till XPS med anpassade inställningar**
Detta exempel visar hur du konverterar en presentation till ett XPS‑dokument med anpassade inställningar i C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instansiera ett Presentation-objekt som representerar en presentationsfil
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instansiera TiffOptions-klassen
auto options = System::MakeObject<XpsOptions>();

// Spara MetaFiles som PNG
options->set_SaveMetafilesAsPng(true);

// Spara presentationen till XPS-dokument
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

### Kan jag spara XPS till en ström istället för en fil?

Ja—Aspose.Slides låter dig exportera direkt till en ström, vilket är idealiskt för webb‑API:er, server‑sidpipelines eller alla scenarier där du vill skicka XPS utan att röra filsystemet.

### Är dolda bilder med i XPS, och kan jag exkludera dem?

Som standard renderas endast vanliga (synliga) bilder. Du kan [inkludera eller exkludera dolda bilder](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) via [exportinställningar](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/xpsoptions/) innan du sparar till XPS, så att utdata innehåller exakt de sidor du avser.