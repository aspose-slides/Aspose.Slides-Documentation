---
title: ODP converteren naar PPTX in JavaScript
linktitle: ODP naar PPTX
type: docs
weight: 10
url: /nl/nodejs-java/convert-odp-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "ODP naar PPTX converteren met Aspose.Slides voor Node.js. Schone JavaScript-code-voorbeelden, batch-tips en resultaten van hoge kwaliteit- geen PowerPoint nodig."
---
## **Overzicht**

Dit artikel legt uit hoe u een ODP‑presentatie kunt converteren naar PPTX‑formaat met Aspose.Slides.

## **ODP converteren naar PPTX/PPT‑presentatie**
Aspose.Slides voor Node.js via Java biedt de klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) die een presentatiebestand vertegenwoordigt. De klasse [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) kan nu ook ODP openen via de constructor [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#Presentation-java.lang.String-) wanneer het object wordt geïnstantieerd. Het volgende voorbeeld laat zien hoe u een ODP‑presentatie kunt converteren naar een PPTX‑presentatie.

```javascript
// Open het ODP bestand
var pres = new aspose.slides.Presentation("AccessOpenDoc.odp");
// De ODP presentatie opslaan in PPTX formaat
pres.save("AccessOpenDoc_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **Live‑voorbeeld**
U kunt de webapp [**Aspose.Slides Conversion**](https://products.aspose.app/slides/nl/conversion/) bezoeken, die is gebouwd met de **Aspose.Slides API**. De app laat zien hoe de conversie van ODP naar PPTX kan worden geïmplementeerd met de Aspose.Slides API.

## **FAQ**

**Moet ik Microsoft PowerPoint of LibreOffice installeren om ODP naar PPTX te converteren?**

Nee. Aspose.Slides werkt zelfstandig en vereist geen externe toepassingen om ODP/PPTX te lezen of te schrijven.

**Worden master‑dia’s, lay-outs en thema’s behouden tijdens de conversie?**

Ja. De bibliotheek gebruikt een volledig presentatiemodel en behoudt de structuur, inclusief master‑dia’s en lay-outs, zodat het ontwerp correct blijft na de conversie.

**Kan ik wachtwoord‑beveiligde ODP‑bestanden converteren?**

Ja. Aspose.Slides ondersteunt het detecteren van beveiliging, het openen en bewerken van [protected presentations](/slides/nl/nodejs-java/password-protected-presentation/) (inclusief ODP) wanneer u het wachtwoord opgeeft, evenals het configureren van versleuteling en toegang tot documenteigenschappen.

**Is Aspose.Slides geschikt voor cloud‑ of REST‑gebaseerde conversiediensten?**

Ja. U kunt de lokale bibliotheek in uw eigen backend gebruiken of [Aspose.Slides Cloud](https://products.aspose.cloud/slides/nl/family/) (REST‑API); beide opties ondersteunen ODP → PPTX‑conversie.