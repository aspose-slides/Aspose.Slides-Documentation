---
title: Presentatie-informatie ophalen en bijwerken in Python
linktitle: Presentatie-informatie
type: docs
weight: 30
url: /nl/python-net/examine-presentation/
keywords:
- presentatieformaat
- presentatie‑eigenschappen
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
description: "Ontdek dia's, structuur en metadata in PowerPoint- en OpenDocument‑presentaties met Python voor snellere inzichten en slimmere inhoudsaudits."
---
## **Overzicht**

Dit artikel toont hoe u presentatiewinformatie in Aspose.Slides kunt inspecteren. Het legt uit hoe u het huidige formaat van een presentatie kunt bepalen zonder het volledige bestand te laden, de documenteigenschappen kunt lezen en die eigenschappen indien nodig kunt bijwerken.

De voorbeelden zijn gebaseerd op de [PresentationInfo](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/) en [DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/) API's en demonstreren typische bewerkingen voor het werken met presentatiemetadata.

## **Controleer het formaat van een presentatie**

Voordat u aan een presentatie werkt, wilt u wellicht weten in welk formaat (PPT, PPTX, ODP en andere) de presentatie zich momenteel bevindt.

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

Deze Python‑code laat zien hoe u presentatie‑eigenschappen (informatie over de presentatie) kunt ophalen:

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

U wilt misschien de [eigenschappen onder de DocumentProperties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/documentproperties/#properties)‑klasse bekijken.

## **Presentatie‑eigenschappen bijwerken**

Aspose.Slides biedt de [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties)‑methode die u in staat stelt wijzigingen in presentatie‑eigenschappen aan te brengen.

Stel dat we een PowerPoint‑presentatie hebben met de onderstaande documenteigenschappen.

![Originele documenteigenschappen van de PowerPoint‑presentatie](input_properties.png)

Dit code‑voorbeeld laat zien hoe u enkele presentatie‑eigenschappen kunt bewerken:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

De resultaten van het wijzigen van de documenteigenschappen worden hieronder getoond.

![Gewijzigde documenteigenschappen van de PowerPoint‑presentatie](output_properties.png)

## **Handige links**

Voor meer informatie over een presentatie en de beveiligingskenmerken kunt u deze links nuttig vinden:

- [Controleren of een presentatie is versleuteld](https://docs.aspose.com/slides/nl/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Controleren of een presentatie alleen-lezen (write‑protected) is](https://docs.aspose.com/slides/nl/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Controleren of een presentatie wachtwoordbeveiligd is voordat deze wordt geladen](https://docs.aspose.com/slides/nl/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Bevestigen van het wachtwoord dat gebruikt is om een presentatie te beveiligen](https://docs.aspose.com/slides/nl/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Hoe kan ik controleren of lettertypen zijn ingebed en welke dat zijn?**

Zoek naar [informatie over ingebedde lettertypen](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) op presentatieniveau, en vergelijk die vermeldingen vervolgens met de set van [lettertypen die daadwerkelijk in de inhoud worden gebruikt](https://reference.aspose.com/slides/nl/python-net/aspose.slides/fontsmanager/get_fonts/) om te bepalen welke lettertypen kritisch zijn voor weergave.

**Hoe kan ik snel zien of het bestand verborgen dia's bevat en hoeveel?**

Loop door de [slide‑collectie](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slidecollection/) en inspecteer de [zichtbaarheidsvlag](https://reference.aspose.com/slides/nl/python-net/aspose.slides/slide/hidden/) van elke dia.

**Kan ik detecteren of er een aangepast diaformaat en -oriëntatie worden gebruikt, en of deze afwijken van de standaardwaarden?**

Ja. Vergelijk de huidige [dia‑grootte](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/slide_size/) en oriëntatie met de standaardpresets; dit helpt om het gedrag bij afdrukken en export te anticiperen.

**Is er een snelle manier om te zien of grafieken naar externe gegevensbronnen verwijzen?**

Ja. Doorloop alle [grafieken](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/), controleer hun [gegevensbron](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdata/data_source_type/), en noteer of de gegevens intern of link‑gebaseerd zijn, inclusief eventuele gebroken links.

**Hoe kan ik 'zware' dia's beoordelen die de weergave of PDF‑export kunnen vertragen?**

Voor elke dia telt u het aantal objecten en zoekt u naar grote afbeeldingen, transparantie, schaduwen, animaties en multimedia; ken een ruwe complexiteitsscore toe om potentiële prestatieknelpunten te markeren.