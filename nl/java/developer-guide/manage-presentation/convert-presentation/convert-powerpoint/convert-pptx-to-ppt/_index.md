---
title: PPTX naar PPT converteren in Java
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/java/convert-pptx-to-ppt/
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
- Java
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides for Java — zorg voor naadloze compatibiliteit met PowerPoint-formaten terwijl u de lay-out en kwaliteit van uw presentatie behoudt."
---
## **Overzicht**

Dit artikel legt uit hoe u een PowerPoint‑presentatie in PPTX‑indeling naar PPT‑indeling kunt converteren met Java. Het volgende onderwerp wordt behandeld.

- PPTX naar PPT converteren in Java

## **PPTX naar PPT converteren in Java**

Voor Java‑voorbeeldcode om PPTX naar PPT te converteren, zie de sectie hieronder, namelijk [Convert PPTX to PPT](#convert-pptx-to-ppt). Het laadt simpelweg het PPTX‑bestand en slaat het op in PPT‑indeling. Door verschillende opslagformaten op te geven, kunt u het PPTX‑bestand ook opslaan in vele andere indelingen zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen. 

- [PPTX naar PDF converteren in Java](/slides/nl/java/convert-powerpoint-to-pdf/)
- [PPTX naar XPS converteren in Java](/slides/nl/java/convert-powerpoint-to-xps/)
- [PPTX naar HTML converteren in Java](/slides/nl/java/convert-powerpoint-to-html/)
- [PPTX naar ODP converteren in Java](/slides/nl/java/save-presentation/)
- [PPTX naar PNG converteren in Java](/slides/nl/java/convert-powerpoint-to-png/)

## **PPTX naar PPT converteren**
Om een PPTX naar PPT te converteren, geeft u simpelweg de bestandsnaam en het opslagformaat door aan de **Save**‑methode van de klasse [**Presentation**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation). De Java‑code‑voorbeeld hieronder zet een Presentation van PPTX naar PPT om met de standaardopties.

```java
// maak een Presentation-object aan dat een PPTX-bestand vertegenwoordigt
Presentation presentation = new Presentation("template.pptx");

// sla de presentatie op als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Blijven alle PPTX‑effecten en -functionaliteiten behouden bij het opslaan naar het legacy‑PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijvoorbeeld bepaalde effecten, objecten en gedrag), waardoor functionaliteiten tijdens de conversie kunnen worden vereenvoudigd of gerasterd.

**Kan ik alleen geselecteerde dia's naar PPT converteren in plaats van de volledige presentatie?**

Direct opslaan richt zich op de volledige presentatie. Om specifieke dia's te converteren, maakt u een nieuwe presentatie met alleen die dia's en slaat u deze op als PPT; of u gebruikt een service/API die per-dias conversie‑parameters ondersteunt.

**Worden wachtwoord‑beveiligde presentaties ondersteund?**

Ja. U kunt detecteren of een bestand beveiligd is, het openen met een wachtwoord, en ook de [protectie-/versleuteling‑instellingen](/slides/nl/java/password-protected-presentation/) configureren voor de opgeslagen PPT.