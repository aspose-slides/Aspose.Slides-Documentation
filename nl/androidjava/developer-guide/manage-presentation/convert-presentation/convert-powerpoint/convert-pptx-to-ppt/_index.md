---
title: PPTX naar PPT converteren op Android
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/androidjava/convert-pptx-to-ppt/
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
- Android
- Java
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides voor Android via Java—zorg voor naadloze compatibiliteit met PowerPoint-formaten terwijl u de lay-out en kwaliteit van uw presentatie behoudt."
---
## **Overzicht**

Dit artikel legt uit hoe u een PowerPoint‑presentatie in PPTX‑formaat omzet naar PPT‑formaat met Java. Het volgende onderwerp wordt behandeld.

- PPTX naar PPT converteren in Java

## **PPTX naar PPT converteren op Android**

Voor voorbeeldcode in Java om PPTX naar PPT te converteren, zie de sectie hieronder, namelijk [Convert PPTX to PPT](#convert-pptx-to-ppt). Het laadt alleen het PPTX‑bestand en slaat het op in PPT‑formaat. Door verschillende opslagformaten op te geven, kunt u het PPTX‑bestand ook opslaan in vele andere formaten zoals PDF, XPS, ODP, HTML enzovoort, zoals besproken in deze artikelen. 

- [PPTX naar PDF converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-pdf/)
- [PPTX naar XPS converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-xps/)
- [PPTX naar HTML converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-html/)
- [PPTX naar ODP converteren op Android](/slides/nl/androidjava/save-presentation/)
- [PPTX naar PNG converteren op Android](/slides/nl/androidjava/convert-powerpoint-to-png/)

## **PPTX naar PPT converteren**
Om een PPTX naar PPT te converteren geeft u gewoon de bestandsnaam en het opslagformaat door aan de **Save**‑methode van de klasse [**Presentation**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation). De Java‑codevoorbeeld hieronder converteert een presentatie van PPTX naar PPT met de standaardopties.

```java
// instantieer een Presentation object dat een PPTX bestand vertegenwoordigt
Presentation presentation = new Presentation("template.pptx");

// sla de presentatie op als PPT
presentation.save("output.ppt", SaveFormat.Ppt);  
```

## **FAQ**

**Blijven alle PPTX‑effecten en -functies behouden bij het opslaan naar het legacy PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijv. bepaalde effecten, objecten en gedrag), waardoor functies kunnen worden vereenvoudigd of gerasterd tijdens de conversie.

**Kan ik alleen geselecteerde dia's naar PPT converteren in plaats van de volledige presentatie?**

Direct opslaan richt zich op de volledige presentatie. Om specifieke dia's te converteren, maakt u een nieuwe presentatie met alleen die dia's en slaat u deze op als PPT; u kunt ook een dienst/API gebruiken die per‑dia‑conversie‑parameters ondersteunt.

**Worden wachtwoord‑beveiligde presentaties ondersteund?**

Ja. U kunt detecteren of een bestand is beveiligd, het openen met een wachtwoord, en ook [beschermings‑/versleutelingsinstellingen configureren](/slides/nl/androidjava/password-protected-presentation/) voor de opgeslagen PPT.