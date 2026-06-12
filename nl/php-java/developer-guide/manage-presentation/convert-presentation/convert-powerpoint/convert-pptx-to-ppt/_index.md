---
title: PPTX naar PPT converteren in PHP
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/php-java/convert-pptx-to-ppt/
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
- PHP
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides — zorg voor naadloze compatibiliteit met PowerPoint‑formaten terwijl de lay-out en kwaliteit van uw presentatie behouden blijven."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPTX‑formaat kunt omzetten naar PPT‑formaat met PHP. Het volgende onderwerp wordt behandeld.

- PPTX naar PPT converteren

## **PPTX naar PPT converteren in PHP**

Voor Java‑voorbeeldcode om PPTX naar PPT te converteren, zie de sectie hieronder, namelijk [Convert PPTX to PPT](#convert-pptx-to-ppt). Het laadt eenvoudig het PPTX‑bestand en slaat het op in PPT‑formaat. Door verschillende opslaformaten op te geven, kun je het PPTX‑bestand ook opslaan in vele andere formaten zoals PDF, XPS, ODP, HTML enz., zoals besproken in deze artikelen. 

- [PPTX naar PDF converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-pdf/)
- [PPTX naar XPS converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-xps/)
- [PPTX naar HTML converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-html/)
- [PPTX naar ODP converteren in PHP](/slides/nl/php-java/save-presentation/)
- [PPTX naar PNG converteren in PHP](/slides/nl/php-java/convert-powerpoint-to-png/)

## **PPTX naar PPT**
Om een PPTX naar PPT te converteren geef je eenvoudig de bestandsnaam en het opslaformat door aan de **Save**‑methode van de [**Presentation**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse. De PHP‑code‑voorbeeld hieronder converteert een Presentation van PPTX naar PPT met de standaardopties.

```php
  # instantieer een Presentation-object dat een PPTX-bestand vertegenwoordigt
  $presentation = new Presentation("template.pptx");
  # sla de presentatie op als PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```

## **FAQ**

**Blijven alle PPTX‑effecten en -functies behouden bij het opslaan naar het legacy‑PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijv. bepaalde effecten, objecten en gedragingen), waardoor functies mogelijk worden vereenvoudigd of gerasterd tijdens de conversie.

**Kan ik alleen geselecteerde dia's naar PPT converteren in plaats van de volledige presentatie?**

Direct opslaan richt zich op de volledige presentatie. Om specifieke dia's te converteren, maak je een nieuwe presentatie met alleen die dia's en sla je deze op als PPT; of je gebruikt een service/API die per‑dia‑conversie‑parameters ondersteunt.

**Worden met een wachtwoord beveiligde presentaties ondersteund?**

Ja. Je kunt detecteren of een bestand beveiligd is, het openen met een wachtwoord, en bovendien de [configuratie van beveiligings‑/versleutelingsinstellingen](/slides/nl/php-java/password-protected-presentation/) voor de opgeslagen PPT aanpassen.