---
title: "PowerPoint‑presentaties naar XPS converteren op Android"
linktitle: "PowerPoint naar XPS"
type: docs
weight: 70
url: /nl/androidjava/convert-powerpoint-to-xps/
keywords:
- "PowerPoint converteren"
- "presentatie converteren"
- "dia converteren"
- "PPT converteren"
- "PPTX converteren"
- "PowerPoint naar XPS"
- "presentatie naar XPS"
- "dia naar XPS"
- "PPT naar XPS"
- "PPTX naar XPS"
- "PPT opslaan als XPS"
- "PPTX opslaan als XPS"
- "PPT exporteren naar XPS"
- "PPTX exporteren naar XPS"
- "PowerPoint"
- "presentatie"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardig, platformonafhankelijk XPS in Java met Aspose.Slides voor Android. Ontvang een stapsgewijze gids en voorbeeldcode."
---
## **Overzicht**

Aspose.Slides stelt u in staat PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe u de conversie kunt uitvoeren met Aspose.Slides met behulp van standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xpsoptions/)-instellingen.

## **Over XPS**

Microsoft heeft [XPS](https://docs.fileformat.com/page-description-language/xps/) ontwikkeld als een alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het maakt het mogelijk om inhoud te printen door een bestand te genereren dat sterk lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft op alle besturingssystemen en printers hetzelfde.

## **Wanneer Microsoft XPS‑formaat te gebruiken**

{{% alert color="primary" %}} 
Om te zien hoe Aspose.Slides PPT‑ of PPTX‑presentaties naar het XPS‑formaat converteert, kun je [deze gratis online converter‑app](https://products.aspose.app/slides/nl/conversion). 
{{% /alert %}} 

Als u de opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op die manier wordt het makkelijker om uw documenten op te slaan, te delen en af te drukken.

Microsoft blijft sterke ondersteuning voor XPS in Windows (zelfs in Windows 10) implementeren, dus wellicht wilt u overwegen om bestanden in dit formaat op te slaan. Als u werkt met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS voor bepaalde bewerkingen uw beste optie zijn.

- **Windows 8** gebruikt het OXPS (Open XPS)-formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/reader en afdrukken naar XPS‑functie beschikbaar. 
  - **PDF**: PDF‑lezer beschikbaar maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS**: Ingebouwde XPS‑viewer en afdrukken naar XPS‑functie beschikbaar. 
  - **PDF**: Geen PDF‑lezer. Geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft heeft uiteindelijk ondersteuning voor afdrukbewerkingen in PDF geïmplementeerd via de Print‑naar‑PDF‑functie in Windows 10. Voorheen werd van gebruikers verwacht documenten af te drukken via het XPS‑formaat.

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/androidjava/) voor Java kunt u de [**Save**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑methode gebruiken die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation)-klasse om de volledige presentatie te converteren naar een XPS‑document.

Bij het converteren van een presentatie naar XPS moet u de presentatie opslaan met een van deze instellingen:
- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xpsoptions))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xpsoptions))

### **Presentaties converteren naar XPS met standaardinstellingen**

Deze voorbeeldcode in Java laat zien hoe u een presentatie converteert naar een XPS‑document met standaardinstellingen:

```java
// Maak een Presentation-object aan dat een presentatie-bestand vertegenwoordigt
Presentation pres = new Presentation("Convert_XPS.pptx");
try {
    // Presentatie opslaan naar XPS-document
    pres.save("XPS_Output_Without_XPSOption.xps", SaveFormat.Xps);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Presentaties converteren naar XPS met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie converteert naar een XPS‑document met aangepaste instellingen in Java:

```java
// Maak een Presentation-object aan dat een presentatie-bestand vertegenwoordigt
Presentation pres = new Presentation("Convert_XPS_Options.pptx");
try {
    // Maak een instantie van de TiffOptions-klasse
    XpsOptions options = new XpsOptions();

    // Meta-bestanden opslaan als PNG
    options.setSaveMetafilesAsPng(true);

    // Sla de presentatie op als XPS-document
    pres.save("XPS_Output_With_Options.xps", SaveFormat.Xps, options);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik naar XPS opslaan in een stream in plaats van een bestand?**

Ja—Aspose.Slides maakt het mogelijk om direct naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines of elke situatie waarin u de XPS wilt verzenden zonder het bestandssysteem te gebruiken.

**Worden verborgen dia’s meegenomen naar XPS en kan ik ze uitsluiten?**

Standaard worden alleen normale (zichtbare) dia’s gerenderd. U kunt [verborgen dia’s opnemen of uitsluiten](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xpsoptions/#setShowHiddenSlides-boolean-) via [export‑instellingen](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/xpsoptions/) vóór het opslaan naar XPS, zodat de output precies de pagina’s bevat die u wilt.