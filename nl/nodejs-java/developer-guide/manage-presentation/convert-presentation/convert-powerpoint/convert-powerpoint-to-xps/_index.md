---
title: PowerPoint-presentaties naar XPS converteren in JavaScript
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/nodejs-java/convert-powerpoint-to-xps/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, platformonafhankelijke XPS in JavaScript met Aspose.Slides voor Node.js. Ontvang een stapsgewijze gids en voorbeeldcode."
---
## **Overzicht**

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe u de conversie kunt uitvoeren met Aspose.Slides met behulp van standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xpsoptions/) instellingen.

## **Over XPS**

Microsoft heeft [XPS](https://docs.fileformat.com/page-description-language/xps/) ontwikkeld als een alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het stelt u in staat inhoud af te drukken door een bestand te genereren dat sterk lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft hetzelfde op alle besturingssystemen en printers.

## **Wanneer Microsoft XPS‑formaat te gebruiken**

{{% alert color="primary" %}} 

Om te zien hoe Aspose.Slides PPT‑ of PPTX‑presentaties naar het XPS‑formaat converteert, kunt u [deze gratis online converter‑app](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}} 

Als u de opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op die manier wordt het eenvoudiger om uw documenten op te slaan, te delen en af te drukken. 

Microsoft blijft sterke ondersteuning voor XPS in Windows implementeren (ook in Windows 10), dus u wilt misschien overwegen bestanden in dit formaat op te slaan. Werkt u met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS uw beste optie zijn voor bepaalde bewerkingen. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/reader en functie voor afdrukken naar XPS beschikbaar. 
  - **PDF**: PDF‑reader beschikbaar maar geen afdrukfunctie naar PDF. 

- **Windows 7 en Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS**: Ingebouwde XPS‑viewer en functie voor afdrukken naar XPS beschikbaar. 
  - **PDF**: Geen PDF‑reader. Geen afdrukfunctie naar PDF. 

|<p>**Invoer PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft implementeerde later ondersteuning voor afdrukken naar PDF via de Print to PDF‑functie in Windows 10. Eerder werd van gebruikers verwacht documenten af te drukken via het XPS‑formaat. 

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides voor Node.js via Java**](https://products.aspose.com/slides/nl/nodejs-java/), kunt u de [**save**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) methode die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse gebruiken om de volledige presentatie naar een XPS‑document te converteren.

Wanneer u een presentatie naar XPS converteert, moet u de presentatie opslaan met één van deze instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xpsoptions))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xpsoptions))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode in JavaScript laat zien hoe u een presentatie kunt converteren naar een XPS‑document met standaardinstellingen:

```javascript
// Maak een Presentation object aan dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Convert_XPS.pptx");
try {
    // De presentatie opslaan als XPS document
    pres.save("XPS_Output_Without_XPSOption.xps", aspose.slides.SaveFormat.Xps);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Presentaties naar XPS converteren met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie kunt converteren naar een XPS‑document met aangepaste instellingen in JavaScript:

```javascript
// Maak een Presentation object aan dat een presentatiebestand vertegenwoordigt
var pres = new aspose.slides.Presentation("Convert_XPS_Options.pptx");
try {
    // Maak de TiffOptions‑klasse aan
    var options = new aspose.slides.XpsOptions();
    // MetaFiles opslaan als PNG
    options.setSaveMetafilesAsPng(true);
    // De presentatie opslaan als XPS‑document
    pres.save("XPS_Output_With_Options.xps", aspose.slides.SaveFormat.Xps, options);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Kan ik naar XPS opslaan in een stream in plaats van een bestand?**

Ja—Aspose.Slides stelt u in staat direct naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines, of elke situatie waarin u de XPS wilt verzenden zonder het bestandssysteem te betrekken.

**Worden verborgen dia’s overgezet naar XPS, en kan ik ze uitsluiten?**

Standaard worden alleen gewone (zichtbare) dia’s gerenderd. U kunt [verborgen dia’s opnemen of uitsluiten](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xpsoptions/setshowhiddenslides/) via [exportinstellingen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/xpsoptions/) vóór het opslaan naar XPS, zodat de uitvoer precies de pagina’s bevat die u wilt.