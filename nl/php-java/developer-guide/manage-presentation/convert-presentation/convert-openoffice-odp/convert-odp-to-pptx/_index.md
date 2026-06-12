---
title: ODP naar PPTX converteren in PHP
linktitle: ODP naar PPTX
type: docs
weight: 10
url: /nl/php-java/convert-odp-to-pptx/
keywords:
- OpenDocument converteren
- presentatie converteren
- dia converteren
- ODP converteren
- OpenDocument naar PPTX
- ODP naar PPTX
- ODP opslaan als PPTX
- ODP exporteren naar PPTX
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "ODP naar PPTX converteren met Aspose.Slides voor PHP via Java. Schone code-voorbeelden, batch-tips en resultaten van hoge kwaliteit — geen PowerPoint nodig."
---
## **Overzicht**

Dit artikel legt uit hoe u een ODP‑presentatie kunt converteren naar PPTX‑formaat met behulp van Aspose.Slides.

## **ODP naar PPTX/PPT‑presentatie converteren**
Aspose.Slides voor PHP via Java biedt de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) die een presentatieweergave vertegenwoordigt. De klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) kan nu ook ODP openen via de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation#Presentation-java.lang.String-) constructor wanneer het object wordt aangemaakt. Het volgende voorbeeld laat zien hoe u een ODP‑presentatie kunt converteren naar een PPTX‑presentatie.

```php
// Open het ODP-bestand
  $pres = new Presentation("AccessOpenDoc.odp");
  try {
  } finally {
  }
  # Opslaan van de ODP-presentatie naar PPTX-formaat
  $pres->save("AccessOpenDoc_out.pptx", SaveFormat::Pptx);
```

## **Live voorbeeld**
U kunt de webapp [**Aspose.Slides Conversion**](https://products.aspose.app/slides/nl/conversion/) bezoeken, die is gebouwd met de **Aspose.Slides API**. De app toont hoe de conversie van ODP naar PPTX kan worden geïmplementeerd met de Aspose.Slides API.

## **FAQ**

**Moet ik Microsoft PowerPoint of LibreOffice installeren om ODP naar PPTX te converteren?**

Nee. Aspose.Slides werkt zelfstandig en vereist geen externe toepassingen om ODP/PPTX te lezen of te schrijven.

**Worden master‑dia’s, lay‑outs en thema’s behouden tijdens de conversie?**

Ja. De bibliotheek maakt gebruik van een volledig presentatiemodel en behoudt de structuur, inclusief master‑dia’s en lay‑outs, zodat het ontwerp na de conversie correct blijft.

**Kan ik met een wachtwoord beveiligde ODP‑bestanden converteren?**

Ja. Aspose.Slides ondersteunt het detecteren van beveiliging, het openen en bewerken van [protected presentations](/slides/nl/php-java/password-protected-presentation/) (inclusief ODP) wanneer u het wachtwoord opgeeft, en u kunt ook de versleuteling en de toegang tot documenteigenschappen configureren.

**Is Aspose.Slides geschikt voor cloud‑ of REST‑gebaseerde conversiediensten?**

Ja. U kunt de lokale bibliotheek in uw eigen backend gebruiken of [Aspose.Slides Cloud](https://products.aspose.cloud/slides/nl/family/) (REST‑API); beide opties ondersteunen ODP → PPTX‑conversie.