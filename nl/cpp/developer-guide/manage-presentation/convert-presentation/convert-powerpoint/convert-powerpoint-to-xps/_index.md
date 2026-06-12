---
title: PowerPoint-presentaties naar XPS converteren in C++
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

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en laat zien hoe u de conversie uitvoert met Aspose.Slides met standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/xpsoptions/)‑instellingen.

## **Over XPS**
Microsoft ontwikkelde [XPS](https://docs.fileformat.com/page-description-language/xps/) als een alternatief voor [PDF](https://docs.fileformat.com/pdf/).  Het stelt u in staat inhoud af te drukken door een bestand te genereren dat zeer lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft op alle besturingssystemen en printers gelijk. 

## **Wanneer Microsoft XPS‑format te gebruiken**

{{% alert color="primary" %}} 

Om te zien hoe Aspose.Slides een PPT‑ of PPTX‑presentatie naar het XPS‑formaat converteert, kunt u de [gratis online converter‑app](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}} 

Als u opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op die manier wordt het makkelijker om uw documenten op te slaan, te delen en af te drukken. 

Microsoft blijft uitgebreide ondersteuning voor XPS in Windows (zelfs in Windows 10) implementeren, dus u kunt overwegen om bestanden in dit formaat op te slaan. Als u werkt met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS voor bepaalde bewerkingen uw beste optie zijn. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** ingebouwde XPS‑viewer/reader en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** PDF‑lezer beschikbaar maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden eveneens betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** ingebouwde XPS‑viewer en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** geen PDF‑lezer. geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft heeft uiteindelijk ondersteuning voor afdrukken in PDF geïmplementeerd via de Print‑to‑PDF‑functie in Windows 10. Voorheen werden documenten afgedrukt via het XPS‑formaat. 

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/cpp/) voor C++ kunt u de [**Save**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation)‑klasse gebruiken om de hele presentatie naar een XPS‑document te converteren. 

Bij het converteren van een presentatie naar XPS moet u de presentatie opslaan met een van deze instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.xps_options))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.xps_options))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode in C++ laat zien hoe u een presentatie naar een XPS‑document converteert met standaardinstellingen:

``` cpp
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS.pptx");
// De presentatie opslaan als XPS-document
pres->Save(u"XPS_Output_Without_XPSOption_out.xps", SaveFormat::Xps);
```

### **Presentaties naar XPS converteren met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie naar een XPS‑document converteert met aangepaste instellingen in C++:

``` cpp
// Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
auto pres = System::MakeObject<Presentation>(u"Convert_XPS_Options.pptx");
// Instantieer de XpsOptions-klasse
auto options = System::MakeObject<XpsOptions>();

// Sla MetaFiles op als PNG
options->set_SaveMetafilesAsPng(true);

// Sla de presentatie op als XPS-document
pres->Save(u"XPS_With_Options_out.xps", SaveFormat::Xps, options);
```

## **FAQ**

**Kan ik XPS opslaan in een stream in plaats van een bestand?**

Ja—Aspose.Slides laat u direct exporteren naar een stream, wat ideaal is voor web‑API’s, server‑side pipelines, of elke situatie waarin u XPS wilt verzenden zonder het bestandssysteem aan te tasten.

**Worden verborgen dia’s meegenomen naar XPS, en kan ik ze uitsluiten?**

Standaard worden alleen gewone (zichtbare) dia’s gerenderd. U kunt [verborgen dia’s opnemen of uitsluiten](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/xpsoptions/set_showhiddenslides/) via de [exportinstellingen](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/xpsoptions/) vóór het opslaan naar XPS, zodat de output precies de pagina’s bevat die u wilt.