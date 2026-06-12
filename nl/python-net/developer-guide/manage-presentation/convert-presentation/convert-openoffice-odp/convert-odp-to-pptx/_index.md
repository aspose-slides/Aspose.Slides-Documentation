---
title: Convert ODP naar PPTX in Python
linktitle: ODP naar PPTX
type: docs
weight: 10
url: /nl/python-net/convert-odp-to-pptx/
keywords:
- OpenDocument converteren
- ODP converteren
- OpenDocument naar PPTX
- ODP naar PPTX
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Converteer ODP naar PPTX met Aspose.Slides voor Python via .NET. Schone codevoorbeelden, batch‑tips en resultaten van hoge kwaliteit—geen PowerPoint nodig."
---
## **Overzicht**

Dit artikel legt uit hoe u een ODP‑presentatie kunt converteren naar PPTX‑indeling met behulp van Aspose.Slides.

## **Export ODP naar PPTX**

Aspose.Slides voor Python via .NET biedt de Presentation‑klasse die een presentatie‑bestand vertegenwoordigt. [**Presentation**](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse kan nu ook ODP benaderen via de Presentation‑constructor wanneer het object wordt geïnstantiëerd. Het volgende voorbeeld laat zien hoe u een ODP‑presentatie kunt omzetten naar een PPTX‑presentatie.

```py
# Importeer Aspose.Slides voor Python via .NET module
import aspose.slides as slides

# Open het ODP bestand
pres = slides.Presentation("AccessOpenDoc.odp")

# De ODP presentatie opslaan in PPTX formaat
pres.save("AccessOpenDoc_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Live‑voorbeeld**

U kunt de web‑app [**Aspose.Slides Conversion**](https://products.aspose.app/slides/nl/conversion/) bezoeken, die is gebouwd met de **Aspose.Slides API**. De app toont hoe ODP‑naar‑PPTX‑conversie kan worden geïmplementeerd met de Aspose.Slides API.

## **Veelgestelde vragen**

**Moet ik Microsoft PowerPoint of LibreOffice installeren om ODP naar PPTX te converteren?**

Nee. Aspose.Slides werkt zelfstandig en vereist geen externe toepassingen om ODP/PPTX te lezen of te schrijven.

**Worden master‑slides, lay‑outs en thema’s behouden tijdens de conversie?**

Ja. De bibliotheek gebruikt een volledig presentatiemodel en behoudt de structuur, inclusief master‑slides en lay‑outs, zodat het ontwerp na de conversie correct blijft.

**Kan ik wachtwoord‑beveiligde ODP‑bestanden converteren?**

Ja. Aspose.Slides ondersteunt het detecteren van beveiliging, het openen en bewerken van [beveiligde presentaties](/slides/nl/python-net/password-protected-presentation/) (inclusief ODP) wanneer u het wachtwoord opgeeft, evenals het configureren van encryptie en toegang tot documenteigenschappen.

**Is Aspose.Slides geschikt voor cloud‑ of REST‑gebaseerde conversiediensten?**

Ja. U kunt de lokale bibliotheek in uw eigen back‑end gebruiken of [Aspose.Slides Cloud](https://products.aspose.cloud/slides/nl/family/) (REST‑API); beide opties ondersteunen ODP → PPTX‑conversie.