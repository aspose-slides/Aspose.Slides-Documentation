---
title: Converteer PowerPoint-presentaties naar XPS in C++
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/cpp/convert-powerpoint-to-xps
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar XPS
- presentatie naar XPS
- dia naar XPS
- PPT naar XPS
- PPTX naar XPS
- PPT opslaan als XPS
- PPTX opslaan als XPS
- PPT exporteren naar XPS
- PPTX exporteren naar XPS
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, platformonafhankelijke XPS in C++ met Aspose.Slides. Ontvang een stapsgewijze handleiding en voorbeeldcode."
---
## **Overzicht**

Aspose.Slides stelt je in staat om PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe je de conversie uitvoert met Aspose.Slides met behulp van standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/xpsoptions/) instellingen.

## **Over XPS**
Microsoft ontwikkelde [XPS](https://docs.fileformat.com/page-description-language/xps/) als een alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het stelt je in staat om inhoud af te drukken door een bestand te genereren dat zeer vergelijkbaar is met een PDF. Het XPS‑formaat is gebaseerd op XML. De lay-out of structuur van een XPS‑bestand blijft hetzelfde op alle besturingssystemen en printers. 

## **Wanneer Microsoft XPS‑formaat gebruiken**

{{% alert color="info" %}} 

Om te zien hoe Aspose.Slides PPT‑ of PPTX‑presentaties naar het XPS‑formaat converteert, kun je deze gratis online converter‑app bekijken([this free online converter app](https://products.aspose.app/slides/nl/conversion)). 

{{% /alert %}} 

Als je de opslagkosten wilt verlagen, kun je je Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op deze manier vind je het makkelijker om je documenten op te slaan, te delen en af te drukken. 

Microsoft blijft sterke ondersteuning voor XPS implementeren in Windows (zelfs in Windows 10), dus je wilt wellicht overwegen om bestanden in dit formaat op te slaan. Als je werkt met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS eigenlijk je beste optie zijn voor bepaalde bewerkingen. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/‑lezer en afdrukken naar XPS‑functie beschikbaar. 
  - **PDF:** PDF‑lezer beschikbaar maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS:** Ingebouwde XPS‑viewer en afdrukken naar XPS‑functie beschikbaar. 
  - **PDF:** Geen PDF‑lezer. Geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft heeft later ondersteuning voor afdrukoperaties in PDF geïmplementeerd via de Print to PDF‑functie in Windows 10. Eerder moesten gebruikers documenten afdrukken via het XPS‑formaat. 

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/cpp/) voor C++ kun je de [**Save**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑methode gebruiken die wordt blootgesteld door de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse om de volledige presentatie naar een XPS‑document te converteren. 

Wanneer je een presentatie naar XPS converteert, moet je de presentatie opslaan met een van deze instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.xps_options))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.xps_options))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode in C++ laat zien hoe je een presentatie naar een XPS‑document converteert met standaardinstellingen:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// De presentatie opslaan als XPS-document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Presentaties naar XPS converteren met aangepaste instellingen**
Deze voorbeeldcode laat zien hoe je een presentatie naar een XPS‑document converteert met aangepaste instellingen in C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Export/XpsOptions.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instantieer de TiffOptions-klasse
auto options = System::MakeObject<XpsOptions>();

// MetaFiles opslaan als PNG
options->set_SaveMetafilesAsPng(true);

// De presentatie opslaan als XPS-document
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

### Kan ik naar XPS opslaan in een stream in plaats van een bestand?

Ja—Aspose.Slides laat je direct naar een stream exporteren, wat ideaal is voor web‑API’s, server‑side pipelines, of elke situatie waarin je het XPS‑document wilt verzenden zonder het bestandssysteem te raken.

### Worden verborgen dia's meegenomen naar XPS, en kan ik ze uitsluiten?

Standaard worden alleen gewone (zichtbare) dia's gerenderd. Je kunt [verborgen dia's opnemen of uitsluiten](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) via de [export‑instellingen](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/xpsoptions/) voordat je opslaat naar XPS, zodat de output precies de pagina’s bevat die je wilt.