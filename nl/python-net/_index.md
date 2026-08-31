---
title: Aspose.Slides voor Python via .NET
second_title: Aspose.Slides voor Python
type: docs
weight: 35
url: /nl/python-net/
is_root: true
keywords:
- Aspose.Slides voor Python
- PowerPoint-automatisering Python
- Python PPT-bibliotheek
- PowerPoint exporteren naar PDF met Python
- PowerPoint exporteren naar SVG met Python
- PowerPoint bewerken in Python
- Python PowerPoint zonder Microsoft Office
- PPTX beheren met Python
- dia-voorvertoning Python
- Python audio aan dia's toevoegen
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides voor Python via .NET biedt een uitgebreide reeks functies, waaronder het beheren van tekst, vormen, tabellen en animaties, audio en video aan dia's toevoegen, dia's voorvertonen en exporteren naar SVG, PDF en meer."
---
{{% alert color="info" %}}

**Welkom bij Aspose.Slides voor Python via .NET**

![Aspose.Slides voor Python via .NET productlogo](aspose_slides-for-python.png)

Aspose.Slides voor Python via .NET is een robuuste klassenbibliotheek die uw toepassingen in staat stelt PowerPoint®‑presentaties te lezen en te schrijven zonder dat Microsoft PowerPoint® vereist is.

Het is de eerste en enige component die volledige PowerPoint®‑documentbeheer biedt voor Python‑ontwikkelaars.

Aspose.Slides voor Python via .NET bevat een breed scala aan functies, zoals werken met tekst, vormen, tabellen en animaties; audio en video toevoegen; dia‑voorvertoning; en dia’s exporteren naar formaten zoals SVG, PDF en meer.

{{% /alert %}}

## Installeer Aspose.Slides voor Python via .NET

```bash
pip install aspose.slides
```

Het pakket bevat de benodigde .NET‑runtime, dus er is niets anders te installeren en Microsoft PowerPoint is niet vereist. Python 3.7 of hoger op Windows, Linux of macOS.

## Maak een PowerPoint‑presentatie in Python

Dit voorbeeld maakt een presentatie, voegt een vorm met tekst toe aan de eerste dia en slaat het resultaat op zowel als PPTX als PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Na uitvoering wordt `presentation.pptx` (ongeveer 34 KB) en `presentation.pdf` (ongeveer 36 KB) naar de werkmap geschreven.

Zonder licentie draait de bibliotheek in evaluatiemodus, die een watermerk toevoegt en het aantal dia’s beperkt. Zie [Licensing](/slides/nl/python-net/licensing/) om er een toe te passen.

## Aspose.Slides voor Python via .NET‑bronnen

Ontdek deze handige bronnen:

- [Aspose.Slides voor Python via .NET online documentatie](/slides/nl/python-net/)
- [Aspose.Slides voor Python via .NET functies](/slides/nl/python-net/features-overview/)
- [Aspose.Slides voor Python via .NET release‑notities](https://releases.aspose.com/slides/nl/python-net/release-notes/)
- [Aspose.Slides voor Python via .NET productpagina](https://products.aspose.com/slides/nl/python-net/)
- [Download Aspose.Slides voor Python via .NET](https://releases.aspose.com/slides/nl/python-net/)
- [Installeer Aspose.Slides voor Python via .NET PyPi‑pakket](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides voor Python via .NET API‑referentiegids](https://reference.aspose.com/slides/nl/python-net/)
- [Aspose.Slides voor Python via .NET gratis ondersteuningsforum](https://forum.aspose.com/c/slides/nl/11)
- [Aspose.Slides voor Python via .NET betaald ondersteuningshelpdesk](https://helpdesk.aspose.com/)

## FAQ

### Wat is Aspose.Slides voor Python via .NET?

Aspose.Slides voor Python via .NET is een krachtige Python‑bibliotheek die u in staat stelt PowerPoint‑presentaties (PPT, PPTX, ODP) programmatisch te maken, bewerken en converteren zonder dat Microsoft PowerPoint geïnstalleerd is.

### Welke presentatiefuncties ondersteunt Aspose.Slides?

De bibliotheek ondersteunt het beheren van tekst, vormen, tabellen, grafieken, animaties, master‑dia’s, audio, video en meer. Het maakt ook dia‑voorvertoning, rendering en export naar formaten zoals PDF, SVG, HTML en afbeeldingen mogelijk.

### Kan ik presentaties naar andere formaten converteren met Aspose.Slides?

Ja. Aspose.Slides maakt de conversie van PowerPoint‑bestanden naar PDF, SVG, HTML, JPG, PNG, TIFF en andere formaten mogelijk met hoge getrouwheid en prestaties.

### Is Microsoft PowerPoint vereist om Aspose.Slides te gebruiken?

Nee. Aspose.Slides is een zelfstandige API en vereist geen Microsoft Office of andere derde‑partij software.

### Welke platformen ondersteunt Aspose.Slides voor Python via .NET?

Het is cross‑platform en werkt in Windows-, Linux- en macOS‑omgevingen.

### Hoe begin ik met Aspose.Slides voor Python?

U kunt het installeren via PyPi en de [Ontwikkelaarsgids](/slides/nl/python-net/developer-guide/) verkennen om aan de slag te gaan met voorbeelden, API‑referenties en tutorials.