---
title: PPTX naar PPT converteren in C++
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/cpp/convert-pptx-to-ppt/
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
- C++
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides voor C++ - zorg voor naadloze compatibiliteit met PowerPoint-formaten terwijl u de lay-out en kwaliteit van uw presentatie behoudt."
---
## **Overzicht**

Dit artikel legt uit hoe je een PowerPoint‑presentatie in PPTX‑formaat kunt omzetten naar PPT‑formaat met C++. Het volgende onderwerp wordt behandeld.

- PPTX naar PPT converteren in C++

## **PPTX naar PPT converteren in C++**

Voor C++‑voorbeeldcode om PPTX naar PPT te converteren, zie de sectie hieronder, namelijk [PPTX naar PPT](#convert-pptx-to-ppt). Het laadt simpelweg het PPTX‑bestand en slaat het op in PPT‑formaat. Door verschillende opslaan‑formaten te specificeren, kun je het PPTX‑bestand ook opslaan in tal van andere formaten zoals PDF, XPS, ODP, HTML enz., zoals besproken in deze artikelen. 

- [PPTX naar PDF converteren in C++](/slides/nl/cpp/convert-powerpoint-to-pdf/)
- [PPTX naar XPS converteren in C++](/slides/nl/cpp/convert-powerpoint-to-xps/)
- [PPTX naar HTML converteren in C++](/slides/nl/cpp/convert-powerpoint-to-html/)
- [PPTX naar ODP converteren in C++](/slides/nl/cpp/save-presentation/)
- [PPTX naar PNG converteren in C++](/slides/nl/cpp/convert-powerpoint-to-png/)

## **PPTX naar PPT**
Om een PPTX naar PPT te converteren geef je eenvoudigweg de bestandsnaam en het opslagformaat door aan de **Save**‑methode van de klasse [**Presentation**](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation/) . Het C++‑codevoorbeeld hieronder zet een Presentation van PPTX naar PPT om met de standaardopties.

```cpp
// Laad de PPTX.
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// Sla op in PPT-formaat.
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```

## **FAQ**

**Blijven alle PPTX‑effecten en -functies behouden bij het opslaan naar het verouderde PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijv. bepaalde effecten, objecten en gedrag), waardoor functies tijdens de conversie kunnen worden vereenvoudigd of gerasterd.

**Kan ik alleen geselecteerde dia's naar PPT converteren in plaats van de volledige presentatie?**

Direct opslaan richt zich op de volledige presentatie. Om specifieke dia's te converteren, maak je een nieuwe presentatie met alleen die dia's en sla je deze op als PPT; je kunt ook een service/API gebruiken die per‑dia‑conversieparameters ondersteunt.

**Worden wachtwoord‑beveiligde presentaties ondersteund?**

Ja. Je kunt detecteren of een bestand beveiligd is, het openen met een wachtwoord, en bovendien [beveiligings‑/versleutelingsinstellingen configureren](/slides/nl/cpp/password-protected-presentation/) voor de opgeslagen PPT.