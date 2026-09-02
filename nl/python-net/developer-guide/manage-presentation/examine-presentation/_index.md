---
title: Ophalen en bijwerken van presentatiesinformatie in Python
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/python-net/examine-presentation/
keywords:
- presentatiefomaat
- presentatieweigenschappen
- documenteigenschappen
- eigenschappen ophalen
- eigenschappen lezen
- eigenschappen wijzigen
- eigenschappen aanpassen
- eigenschappen bijwerken
- PPTX onderzoeken
- PPT onderzoeken
- ODP onderzoeken
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument-presentaties met Python voor snellere inzichten en slimmer content-audit."
---
## **Overzicht**

Dit artikel laat zien hoe u presentatiedetails in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer het presentatiefomaat**

Voordat u met een presentatie werkt, wilt u misschien weten in welk formaat (PPT, PPTX, ODP en anderen) de presentatie zich momenteel bevindt.

U kunt het formaat van een presentatie controleren zonder de presentatie te laden. Zie deze Python‑code:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Presentatie‑eigenschappen ophalen**

Deze Python‑code laat zien hoe u presentatieweigenschappen (informatie over de presentatie) kunt ophalen:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

U wilt misschien de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/#properties) klasse bekijken.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) methode die u in staat stelt wijzigingen aan te brengen in presentatieweigenschappen.

Stel, we hebben een PowerPoint‑presentatie met de hieronder getoonde documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Deze code‑voorbeeld laat zien hoe u enkele presentatieweigenschappen kunt bewerken:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Om meer informatie over een presentatie en de beveiligingsattributen te verkrijgen, kunt u deze links nuttig vinden:

- [Password-Protect Presentations](/slides/nl/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/nl/python-net/write-protected-presentation/)

## **Veelgestelde vragen**

**Hoe kan ik controleren of lettertypen zijn ingesloten en welke dat zijn?**

Zoek naar [embedded-font-informatie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) op presentatieniveau, vergelijk die items vervolgens met de set van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_fonts/) om te bepalen welke lettertypen cruciaal zijn voor het renderen.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Itereer door de [slide-collectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/hidden/) van elke dia.

**Kan ik detecteren of een aangepaste dia‑grootte en -oriëntatie worden gebruikt, en of deze afwijken van de standaardinstellingen?**

Ja. Vergelijk de huidige [dia-grootte](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slide_size/) en oriëntatie met de standaardpresets; dit helpt bij het voorspellen van gedrag bij afdrukken en export.

**Is er een snelle manier om te zien of grafieken naar externe gegevensbronnen verwijzen?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/), en noteer of de gegevens intern of via een link zijn, inclusief eventuele gebroken koppelingen.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Voor elke dia, tel het aantal objecten en zoek naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om potentiële prestatie‑knelpunten te markeren.