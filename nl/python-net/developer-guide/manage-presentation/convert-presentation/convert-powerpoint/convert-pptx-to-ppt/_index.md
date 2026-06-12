---
title: Converteer PPTX naar PPT in Python
linktitle: PPTX naar PPT
type: docs
weight: 21
url: /nl/python-net/convert-pptx-to-ppt/
keywords:
- PPTX naar PPT
- converteer PPTX naar PPT
- converteer PowerPoint
- converteer presentatie
- Python
- Aspose.Slides
description: "Converteer eenvoudig PPTX naar PPT met Aspose.Slides voor Python via .NET—zorg voor naadloze compatibiliteit met PowerPoint-formats terwijl u de lay-out en kwaliteit van uw presentatie behoudt."
---
## **Overzicht**

Aspose.Slides for Python laat u moderne PPTX‑presentaties converteren naar het legacy PPT‑formaat volledig via code. Open een PPTX en exporteer deze als PPT terwijl u de inhoud en lay‑out van de presentatie behoudt, waardoor het resultaat compatibel is met oudere versies van PowerPoint. dezelfde workflow kan andere uitvoerformaten genereren — zoals PDF, XPS, ODP, HTML of afbeeldingen — zodat het soepel past in scripts, CI‑pipelines en batchverwerking.

## **PPTX naar PPT converteren**

Om een PPTX naar PPT te converteren geeft u simpelweg de bestandsnaam en het opslaformat door aan de [save](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/save/)‑methode van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse. Het onderstaande Python‑voorbeeld converteert een presentatie van PPTX naar PPT met de standaardopties.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
presentation = slides.Presentation("presentation.pptx")

# Sla de presentatie op als een PPT-bestand.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **FAQ**

**Blijven alle PPTX‑effecten en functies behouden bij het opslaan naar het legacy PPT‑formaat (97–2003)?**

Niet altijd. Het PPT‑formaat mist enkele nieuwere mogelijkheden (bijv. bepaalde effecten, objecten en gedragingen), waardoor functies tijdens de conversie kunnen worden vereenvoudigd of gerasterd.

**Kan ik alleen geselecteerde dia's naar PPT converteren in plaats van de hele presentatie?**

Direct opslaan richt zich op de hele presentatie. Om specifieke dia's te converteren, maakt u een nieuwe presentatie met alleen die dia's en slaat u deze op als PPT; of u gebruikt een service/API die per‑dia conversie‑parameters ondersteunt.

**Worden wachtwoord‑beveiligde presentaties ondersteund?**

Ja. U kunt detecteren of een bestand beschermd is, het openen met een wachtwoord, en ook [configure protection/encryption settings](/slides/nl/python-net/password-protected-presentation/) voor de opgeslagen PPT configureren.

**Zie ook:**
- [PPT & PPTX naar PDF converteren in Python | Geavanceerde opties](/slides/nl/python-net/convert-powerpoint-to-pdf/)
- [PowerPoint‑presentaties naar XPS converteren in Python](/slides/nl/python-net/convert-powerpoint-to-xps/)
- [PowerPoint‑presentaties naar HTML converteren in Python](/slides/nl/python-net/convert-powerpoint-to-html/)
- [PowerPoint‑dia's naar PNG converteren in Python](/slides/nl/python-net/convert-powerpoint-to-png/)