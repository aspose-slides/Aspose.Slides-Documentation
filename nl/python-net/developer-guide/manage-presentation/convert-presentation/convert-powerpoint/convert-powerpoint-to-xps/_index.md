---
title: PowerPoint-presentaties naar XPS converteren in Python
linktitle: PowerPoint naar XPS
type: docs
weight: 70
url: /nl/python-net/convert-powerpoint-to-xps/
keywords:
- PowerPoint converteren
- presentatie converteren
- PowerPoint naar XPS
- presentatie naar XPS
- PPT naar XPS
- PPTX naar XPS
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Converteer PowerPoint PPT/PPTX naar hoogwaardige, platformonafhankelijke XPS in Python met Aspose.Slides. Ontvang een stapsgewijze handleiding en voorbeeldcode."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties naar XPS te converteren door een PPT‑ of PPTX‑bestand op te slaan in het XPS‑formaat. Dit artikel legt uit wanneer het XPS‑formaat nuttig kan zijn en laat zien hoe u de conversie kunt uitvoeren met Aspose.Slides met behulp van de standaardinstellingen of aangepaste [XpsOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/xpsoptions/) instellingen.

## **Over XPS**
Microsoft heeft [XPS](https://docs.fileformat.com/page-description-language/xps/) ontwikkeld als alternatief voor [PDF](https://docs.fileformat.com/pdf/). Het maakt het mogelijk om inhoud af te drukken door een bestand te genereren dat sterk lijkt op een PDF. Het XPS‑formaat is gebaseerd op XML. De lay‑out of structuur van een XPS‑bestand blijft op alle besturingssystemen en printers gelijk. 

## Wanneer Microsoft XPS‑formaat gebruiken

{{% alert color="primary" %}} 

Om te zien hoe Aspose.Slides PPT‑ of PPTX‑presentaties naar het XPS‑formaat converteert, kunt u een kijkje nemen op [deze gratis online converter‑app](https://products.aspose.app/slides/nl/conversion). 

{{% /alert %}} 

Als u de opslagkosten wilt verlagen, kunt u uw Microsoft PowerPoint‑presentatie naar het XPS‑formaat converteren. Op die manier wordt het makkelijker om uw documenten op te slaan, te delen en af te drukken. 

Microsoft blijft sterke ondersteuning voor XPS in Windows implementeren (zelfs in Windows 10), dus het kan de moeite waard zijn om bestanden in dit formaat op te slaan. Als u werkt met Windows 8.1, Windows 8, Windows 7 en Windows Vista, dan kan XPS uw beste optie zijn voor bepaalde bewerkingen. 

- **Windows 8** gebruikt het OXPS (Open XPS)‑formaat voor XPS‑bestanden. OXPS is een gestandaardiseerde versie van het oorspronkelijke XPS‑formaat. Windows 8 biedt betere ondersteuning voor XPS‑bestanden dan voor PDF‑bestanden. 
  - **XPS:** Ingebouwde XPS‑viewer/reader en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** PDF‑reader beschikbaar maar geen afdrukken‑naar‑PDF‑functie. 

-  **Windows 7 and Windows Vista** gebruiken het oorspronkelijke XPS‑formaat. Deze besturingssystemen bieden ook betere ondersteuning voor XPS‑bestanden dan voor PDF’s. 
  - **XPS:** Ingebouwde XPS‑viewer en afdrukken‑naar‑XPS‑functie beschikbaar. 
  - **PDF:** Geen PDF‑reader. Geen afdrukken‑naar‑PDF‑functie. 

|<p>**Invoer PPT(X):**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png)**</p>|<p>**Uitvoer XPS:**</p><p>**![todo:image_alt_text](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png)**</p>|
| :- | :- |



Microsoft heeft uiteindelijk ondersteuning voor afdrukoperaties in PDF geïmplementeerd via de Print‑to‑PDF‑functie in Windows 10. Eerder werden gebruikers geacht documenten af te drukken via het XPS‑formaat. 

## XPS-conversie met Aspose.Slides

In [**Aspose.Slides**](https://products.aspose.com/slides/nl/python-net/) voor .NET kunt u de [**Save**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑methode gebruiken die wordt aangeboden door de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides.presentation/)‑klasse om de volledige presentatie naar een XPS‑document te converteren. 

Bij het converteren van een presentatie naar XPS moet u de presentatie opslaan met een van deze instellingen:

- Standaardinstellingen (zonder [**XPSOptions**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/xpsoptions/))
- Aangepaste instellingen (met [**XPSOptions**](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/xpsoptions/))

### **Presentaties converteren naar XPS met standaardinstellingen**

Deze voorbeeldcode in Python toont hoe u een presentatie naar een XPS‑document converteert met standaardinstellingen:

```py
import aspose.slides as slides

# Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
pres = slides.Presentation("Convert_XPS.pptx")

# Sla de presentatie op als XPS-document
pres.save("XPS_Output_Without_XPSOption_out.xps", slides.export.SaveFormat.XPS)
```


### **Presentaties converteren naar XPS met aangepaste instellingen**
Deze voorbeeldcode toont hoe u een presentatie naar een XPS‑document converteert met aangepaste instellingen in Python:

```py
import aspose.slides as slides

# Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
pres = slides.Presentation("Convert_XPS_Options.pptx")

# Instantieer de TiffOptions-klasse
options = slides.export.XpsOptions()

# Sla MetaFiles op als PNG
options.save_metafiles_as_png = True

# Sla de presentatie op als XPS-document
pres.save("XPS_With_Options_out.xps", slides.export.SaveFormat.XPS, options)
```

## **Veelgestelde vragen**

**Kan ik XPS opslaan in een stream in plaats van in een bestand?**

Ja—Aspose.Slides stelt u in staat direct naar een stream te exporteren, wat ideaal is voor web‑API’s, server‑side pipelines, of elke situatie waarin u het XPS wilt verzenden zonder het bestandssysteem aan te raken.

**Worden verborgen dia's meegenomen naar XPS, en kan ik ze uitsluiten?**

Standaard worden alleen gewone (zichtbare) dia's gerenderd. U kunt [verborgen dia's opnemen of uitsluiten](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/xpsoptions/show_hidden_slides/) via [exportinstellingen](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/xpsoptions/) voordat u naar XPS opslaat, zodat de output precies de pagina’s bevat die u wenst.