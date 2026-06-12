---
title: PowerPoint-presentaties naar XPS in Java
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/java/convert-powerpoint-to-xps/
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
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX omzetten naar hoogwaardige, platformonafhankelijke XPS in Java met Aspose.Slides. Verkrijg een stapsgewijze handleiding en voorbeeldcode."
---
## **Overzicht**

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand in het XPS‑formaat op te slaan. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe u de conversie kunt uitvoeren met Aspose.Slides met behulp van de standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xpsoptions/) instellingen.

## **Over XPS**
Microsoft heeft [XPS](https://docs.fileformat.com/page-description-language/xps/) ontwikkeld als alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het stelt u in staat inhoud af te drukken door een bestand te genereren dat sterk lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft op alle besturingssystemen en printers hetzelfde. 

## **Wanneer Microsoft XPS‑formaat gebruiken**

{{% alert color="primary" %}} 

Om te zien hoe Aspose.Slides een PPT‑ of PPTX‑presentatie naar het XPS‑formaat converteert, kunt u [deze gratis online converter app](https://products.aspose.app/slides/nl/conversion) bekijken. 

{{% /alert %}} 

Als u opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op die manier wordt het opslaan, delen en afdrukken van uw documenten eenvoudiger. 

Microsoft blijft sterke ondersteuning voor XPS in Windows (zelfs in Windows 10) implementeren, dus u wilt wellicht overwegen om bestanden in dit formaat op te slaan. Als u werkt met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS daadwerkelijk uw beste optie zijn voor bepaalde bewerkingen. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/reader en afdrukken naar XPS‑functie beschikbaar. 
  - **PDF:** PDF‑reader beschikbaar maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** Geen PDF‑reader. Geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft heeft uiteindelijk ondersteuning voor afdrukbewerkingen in PDF geïmplementeerd via de Print to PDF‑functie in Windows 10. Voorheen werd van gebruikers verwacht documenten af te drukken via het XPS‑formaat. 

## **XPS-conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/java/) voor Java kunt u de [**Save**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode gebruiken die wordt blootgesteld door de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation) om de volledige presentatie naar een XPS‑document te converteren. 

Bij het converteren van een presentatie naar XPS moet u de presentatie opslaan met een van deze instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xpsoptions))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xpsoptions))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode in Java laat zien hoe u een presentatie naar een XPS‑document converteert met standaardinstellingen:

```java
// Maak een Presentation object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // De presentatie opslaan naar XPS document
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Presentaties naar XPS converteren met aangepaste instellingen**
Deze voorbeeldcode laat zien hoe u een presentatie naar een XPS‑document converteert met aangepaste instellingen in Java:

```java
// Maak een Presentation object dat een presentatiebestand vertegenwoordigt
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Maak een TiffOptions klasse aan
    XpsOptions options = new XpsOptions();

    // MetaFiles opslaan als PNG
    options.setSaveMetafilesAsPng(true);

    // De presentatie opslaan naar XPS document
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik naar XPS opslaan in een stream in plaats van een bestand?**

Ja—Aspose.Slides stelt u in staat rechtstreeks naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines of elk scenario waarin u de XPS wilt verzenden zonder het bestandssysteem aan te raken.

**Worden verborgen dia's meegenomen naar XPS, en kan ik ze uitsluiten?**

Standaard worden alleen reguliere (zichtbare) dia's gerenderd. U kunt [verborgen dia's opnemen of uitsluiten](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) via de [exportinstellingen](https://reference.aspose.com/slides/nl/java/com.aspose.slides/xpsoptions/) voordat u naar XPS opslaat, zodat de uitvoer precies de pagina’s bevat die u wilt.