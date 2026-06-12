---
title: PowerPoint‑presentaties naar XPS converteren in .NET
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

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe u de conversie kunt uitvoeren met Aspose.Slides met behulp van standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/)‑instellingen.

## **Over XPS**
Microsoft heeft [XPS](https://docs.fileformat.com/page-description-language/xps/) ontwikkeld als alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het stelt u in staat inhoud af te drukken door een bestand te genereren dat sterk lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay-out of structuur van een XPS‑bestand blijft op alle besturingssystemen en printers gelijk. 

## **Wanneer Microsoft XPS‑formaat gebruiken**

{{% alert color="primary" %}} 

Om te zien hoe Aspose.Slides PPT‑ of PPTX‑presentaties naar het XPS‑formaat converteert, kunt u [deze gratis online converter‑app](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}} 

Als u opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op deze manier vindt u het eenvoudiger om uw documenten op te slaan, te delen en af te drukken. 

Microsoft blijft stevige ondersteuning voor XPS in Windows (zelfs in Windows 10) implementeren, dus u kunt overwegen bestanden in dit formaat op te slaan. Werkt u met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS juist uw beste optie zijn voor bepaalde bewerkingen. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/reader en afdrukken naar XPS‑functie beschikbaar. 
  - **PDF**: PDF‑lezer beschikbaar maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS**: Ingebouwde XPS‑viewer en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF**: Geen PDF‑lezer. Geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft heeft uiteindelijk ondersteuning voor afdrukoperaties in PDF geïmplementeerd via de Print‑to‑PDF‑functie in Windows 10. Voorheen werd van gebruikers verwacht documenten af te drukken via het XPS‑formaat. 

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/net/) voor .NET kunt u de [**Save**](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save/index)‑methode gebruiken die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse om de volledige presentatie om te zetten naar een XPS‑document. 

Bij het converteren van een presentatie naar XPS moet u de presentatie opslaan met een van de volgende instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode in C# toont hoe u een presentatie naar een XPS‑document kunt converteren met standaardinstellingen:

```c#
 // Maak een Presentation‑object aan dat een presentatiebestand voorstelt
 using (Presentation pres = new Presentation("Convert_XPS.pptx"))
 {
     // De presentatie opslaan als XPS‑document
     pres.Save("XPS_Output_Without_XPSOption_out.xps", SaveFormat.Xps);
 }
```

### **Presentaties naar XPS converteren met aangepaste instellingen**
Deze voorbeeldcode toont hoe u een presentatie naar een XPS‑document kunt converteren met aangepaste instellingen in C#:

```c#
 // Instantieer een Presentation object dat een presentiebestand voorstelt
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

**Kan ik XPS opslaan naar een stream in plaats van een bestand?**

Ja—Aspose.Slides stelt u in staat rechtstreeks naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines of elke situatie waarin u de XPS wilt verzenden zonder het bestandssysteem aan te raken.

**Worden verborgen dia’s meegenomen naar XPS, en kan ik ze uitsluiten?**

Standaard worden alleen reguliere (zichtbare) dia’s gerenderd. U kunt [verborgen dia’s opnemen of uitsluiten](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/showhiddenslides/) via de [export‑instellingen](https://reference.aspose.com/slides/nl/net/aspose.slides.export/xpsoptions/) voordat u naar XPS opslaat, zodat de output precies de pagina’s bevat die u wilt.