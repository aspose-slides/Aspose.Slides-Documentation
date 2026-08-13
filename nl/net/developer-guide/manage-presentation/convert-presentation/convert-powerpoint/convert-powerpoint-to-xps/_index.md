---
title: Converteer PowerPoint-presentaties naar XPS in .NET
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/net/convert-powerpoint-to-xps/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, platformonafhankelijke XPS in .NET met Aspose.Slides. Ontvang een stapsgewijze handleiding en voorbeeldcode in C#."
---
## **Overzicht**

Aspose.Slides stelt u in staat PowerPoint‑presentaties om te zetten naar XPS door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe u de conversie uitvoert met Aspose.Slides, met standaardinstellingen of met aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/)‑instellingen.

## **Over XPS**
Microsoft ontwikkelde [XPS](https://docs.fileformat.com/page-description-language/xps/) als alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het maakt het mogelijk inhoud af te drukken door een bestand te genereren dat zeer lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft hetzelfde op alle besturingssystemen en printers. 

## **Wanneer u Microsoft XPS‑formaat moet gebruiken**

{{% alert color="info" %}} 

Om te zien hoe Aspose.Slides een PPT‑ of PPTX‑presentatie omzet naar het XPS‑formaat, kunt u de [gratis online converter‑app](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}} 

Als u opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie omzetten naar het XPS‑formaat. Zo wordt het makkelijker om uw documenten op te slaan, te delen en af te drukken. 

Microsoft blijft sterke ondersteuning voor XPS implementeren in Windows (ook in Windows 10), dus het kan de moeite waard zijn om bestanden in dit formaat op te slaan. Werkt u met Windows 8.1, Windows 8, Windows 7 of Windows Vista, dan kan XPS voor bepaalde bewerkingen zelfs de beste optie zijn. 

- **Windows 8** gebruikt het OXPS‑formaat (Open XPS) voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/reader en afdrukken naar XPS beschikbaar. 
  - **PDF:** PDF‑reader beschikbaar, maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het originele XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS:** Ingebouwde XPS‑viewer en afdrukken naar XPS beschikbaar. 
  - **PDF:** Geen PDF‑reader. Geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft heeft uiteindelijk ondersteuning toegevoegd voor afdrukken naar PDF via de Print‑to‑PDF‑functie in Windows 10. Voorheen werd verwacht dat gebruikers documenten afdrukten via het XPS‑formaat. 

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/net/) voor .NET kunt u de [**Save**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse gebruiken om de volledige presentatie om te zetten naar een XPS‑document. 

Bij het converteren van een presentatie naar XPS moet u de presentatie opslaan met een van de volgende instellingen:

- Standaardinstellingen (zonder [**XpsOptions**](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions))
- Aangepaste instellingen (met [**XpsOptions**](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode in C# laat zien hoe u een presentatie naar een XPS‑document converteert met de standaardinstellingen:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation("Convert_XPS.pptx"))
{
    // De presentatie opslaan als XPS-document
    pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
}
```

### **Presentaties naar XPS converteren met aangepaste instellingen**
Deze voorbeeldcode laat zien hoe u een presentatie naar een XPS‑document converteert met aangepaste instellingen in C#:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantieer een Presentation-object dat een presentiebestand vertegenwoordigt
using (Presentation pres = new Presentation("Convert_XPS_Options.pptx"))
{
    // Instantieer de TiffOptions-klasse
    XpsOptions options = new XpsOptions();

    // MetaFiles opslaan als PNG
    options.SaveMetafilesAsPng = true;

    // De presentatie opslaan als XPS-document
    pres.Save("XPS_With_Options_out.xps", SaveFormat.Xps, options);
}
```

## **FAQ**

### Kan ik XPS opslaan in een stream in plaats van een bestand?

Ja—Aspose.Slides stelt u in staat direct naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines, of elk scenario waarin u het XPS‑bestand wilt verzenden zonder het bestandssysteem te raken.

### Worden verborgen dia’s meegenomen naar XPS en kan ik ze uitsluiten?

Standaard worden alleen gewone (zichtbare) dia’s gerenderd. U kunt [verborgen dia’s opnemen of uitsluiten](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/showhiddenslides/) via de [export‑instellingen](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/) vóór het opslaan naar XPS, zodat de uitvoer precies de pagina’s bevat die u wilt.