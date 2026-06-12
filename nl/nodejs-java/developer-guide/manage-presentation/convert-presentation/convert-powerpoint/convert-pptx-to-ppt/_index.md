---
title: PPTX naar PPT converteren met JavaScript
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/nodejs-java/convert-pptx-to-ppt/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPTX converteren
- PPTX naar PPT
- PPTX opslaan als PPT
- PPTX exporteren naar PPT
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides—zorg voor naadloze compatibiliteit met PowerPoint-formaten terwijl u de lay-out en kwaliteit van uw presentatie behoudt."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPTX‑indeling kunt omzetten naar PPT‑indeling met JavaScript. Het volgende onderwerp wordt behandeld.

- PPTX naar PPT converteren met JavaScript

## **JavaScript PPTX naar PPT converteren**

Voor voorbeeldcode in JavaScript om PPTX naar PPT te converteren, zie de onderstaande sectie, namelijk [Convert PPTX to PPT](#convert-pptx-to-ppt). Het laadt simpelweg het PPTX‑bestand en slaat het op in PPT‑indeling. Door verschillende opslaformaten op te geven, kun je het PPTX‑bestand ook in vele andere formaten opslaan, zoals PDF, XPS, ODP, HTML enz., zoals besproken in deze artikelen. 

- [Convert PPTX to PDF in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/)
- [Convert PPTX to XPS in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-xps/)
- [Convert PPTX to HTML in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-html/)
- [Convert PPTX to ODP in JavaScript](/slides/nl/nodejs-java/save-presentation/)
- [Convert PPTX to PNG in JavaScript](/slides/nl/nodejs-java/convert-powerpoint-to-png/)

## **Convert PPTX to PPT**

Om een PPTX naar PPT te converteren, geef je eenvoudig de bestandsnaam en het opslaformaat door aan de **Save**‑methode van de [**Presentation**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation)‑klasse. De onderstaande JavaScript‑codevoorbeeld converteert een Presentation van PPTX naar PPT met de standaardopties.

```javascript
// instantieer een Presentation-object dat een PPTX-bestand vertegenwoordigt
var presentation = new aspose.slides.Presentation("template.pptx");
// sla de presentatie op als PPT
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```

## **FAQ**

**Blijven alle PPTX-effecten en -functies behouden bij het opslaan naar het verouderde PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijv. bepaalde effecten, objecten en gedragingen), waardoor functies tijdens de conversie kunnen worden vereenvoudigd of gerasterd.

**Kan ik alleen geselecteerde dia's naar PPT converteren in plaats van de volledige presentatie?**

Direct opslaan richt zich op de volledige presentatie. Om specifieke dia's te converteren, maak je een nieuwe presentatie met alleen die dia's en sla je deze op als PPT; of gebruik je een service/API die per‑dia conversie‑parameters ondersteunt.

**Worden met een wachtwoord beveiligde presentaties ondersteund?**

Ja. Je kunt detecteren of een bestand beveiligd is, het openen met een wachtwoord, en ook [configure protection/encryption settings](/slides/nl/nodejs-java/password-protected-presentation/) voor de opgeslagen PPT configureren.