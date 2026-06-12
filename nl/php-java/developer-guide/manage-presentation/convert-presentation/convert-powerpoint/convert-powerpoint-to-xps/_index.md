---
title: Converteer PowerPoint‑presentaties naar XPS in PHP
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/php-java/convert-powerpoint-to-xps/
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
- PHP
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, platformonafhankelijke XPS met Aspose.Slides voor PHP via Java. Ontvang een stapsgewijze handleiding en voorbeeldcode."
---
## **Overzicht**

Aspose.Slides stelt je in staat PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand in het XPS‑formaat op te slaan. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en toont hoe je de conversie uitvoert met Aspose.Slides met behulp van standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xpsoptions/)‑instellingen.

## **Over XPS**
Microsoft heeft [XPS](https://docs.fileformat.com/page-description-language/xps/) ontwikkeld als alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het maakt het mogelijk inhoud af te drukken door een bestand te produceren dat sterk lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft op alle besturingssystemen en printers hetzelfde. 

## **Wanneer Microsoft XPS gebruiken**

{{% alert color="primary" %}} 
Om te zien hoe Aspose.Slides een PPT‑ of PPTX‑presentatie naar het XPS‑formaat converteert, kun je de [gratis online converter‑app](https://products.aspose.app/slides/nl/conversion) bekijken. 
{{% /alert %}} 

Als je opslagkosten wilt verlagen, kun je je Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Zo wordt het makkelijker om documenten op te slaan, te delen en af te drukken. 

Microsoft blijft sterke ondersteuning voor XPS in Windows bieden (ook in Windows 10), dus het kan de moeite waard zijn om bestanden in dit formaat op te slaan. Als je werkt met Windows 8.1, Windows 8, Windows 7 of Windows Vista, dan is XPS wellicht je beste optie voor bepaalde handelingen. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** ingebouwde XPS‑viewer/lezer en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** PDF‑lezer beschikbaar, maar geen afdrukken‑naar‑PDF‑functie. 

- **Windows 7 en Windows Vista** gebruiken het originele XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS:** ingebouwde XPS‑viewer en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** geen PDF‑lezer. geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |

Microsoft heeft uiteindelijk ondersteuning voor afdrukken naar PDF geïmplementeerd via de Print‑to‑PDF‑functie in Windows 10. Eerder werden gebruikers geacht documenten af te drukken via het XPS‑formaat. 

## **XPS‑conversie met Aspose.Slides**

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/php-java/) voor Java kun je de [**Save**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑methode van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) gebruiken om de volledige presentatie om te zetten naar een XPS‑document.

Bij het converteren van een presentatie naar XPS moet je de presentatie opslaan met een van deze instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xpsoptions))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xpsoptions))

### **Presentaties naar XPS converteren met standaardinstellingen**

Deze voorbeeldcode laat zien hoe je een presentatie naar een XPS‑document converteert met de standaardinstellingen:

```php
  # Maak een Presentation‑object aan dat een presentatie‑bestand vertegenwoordigt
  $pres = new Presentation("Convert_XPS.pptx");
  try {
    # De presentatie opslaan als XPS‑document
    $pres->save("XPS_Output_Without_XPSOption.xps", SaveFormat::Xps);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Presentaties naar XPS converteren met aangepaste instellingen**
Deze voorbeeldcode laat zien hoe je een presentatie naar een XPS‑document converteert met aangepaste instellingen:

```php
  # Maak een Presentation-object aan dat een presentatie‑bestand vertegenwoordigt
  $pres = new Presentation("Convert_XPS_Options.pptx");
  try {
    # Maak een TiffOptions‑klasse aan
    $options = new XpsOptions();
    # Sla MetaFiles op als PNG
    $options->setSaveMetafilesAsPng(true);
    # Sla de presentatie op als XPS‑document
    $pres->save("XPS_Output_With_Options.xps", SaveFormat::Xps, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik naar XPS opslaan in een stream in plaats van een bestand?**

Ja—Aspose.Slides stelt je in staat direct naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines, of elke situatie waarin je de XPS wilt verzenden zonder het bestandssysteem aan te raken.

**Worden verborgen dia’s meegenomen naar XPS en kan ik ze uitsluiten?**

Standaard worden alleen normale (zichtbare) dia’s gerenderd. Je kunt via de [export‑instellingen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xpsoptions/) [verborgen dia’s opnemen of uitsluiten](https://reference.aspose.com/slides/nl/php-java/aspose.slides/xpsoptions/setshowhiddenslides/) vóór het opslaan naar XPS, zodat de output precies de pagina’s bevat die je wilt.