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
- dia-preview met Python
- Python audio toevoegen aan dia's
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides voor Python via .NET biedt een uitgebreide reeks functies, waaronder het beheren van tekst, vormen, tabellen en animaties, het toevoegen van audio en video aan dia's, het previewen van dia's en het exporteren naar SVG, PDF en meer."
---
{{% alert color="primary" %}}

**Welkom bij Aspose.Slides for Python via .NET**

![Aspose.Slides voor Python via .NET productlogo](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET is een robuuste class library die uw applicaties in staat stelt PowerPoint®-presentaties te lezen en te schrijven zonder dat Microsoft PowerPoint® vereist is.

Het is de eerste en enige component die volledige PowerPoint®-documentbeheer biedt voor Python-ontwikkelaars.

Aspose.Slides for Python via .NET bevat een breed scala aan functies, zoals werken met tekst, vormen, tabellen en animaties; audio en video toevoegen; dia’s previewen; en dia’s exporteren naar formaten zoals SVG, PDF en meer.

{{% /alert %}}

## Installeer Aspose.Slides for Python via .NET

```bash
pip install aspose.slides
```

Het pakket bevat de .NET-runtime die nodig is, dus er is verder niets te installeren en Microsoft PowerPoint is niet vereist. Python 3.7 of hoger op Windows, Linux of macOS.

## Maak een PowerPoint-presentatie in Python

Dit voorbeeld maakt een presentatie, voegt een vorm met tekst toe aan de eerste dia en slaat het resultaat op als zowel PPTX als PDF.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

Het uitvoeren schrijft `presentation.pptx` (ongeveer 34 KB) en `presentation.pdf` (ongeveer 36 KB) naar de werkmap.

Zonder licentie draait de bibliotheek in evaluatiemodus, wat een watermerk toevoegt en het aantal dia’s beperkt. Zie [Licensing](/slides/nl/python-net/licensing/) om er een toe te passen.

## Aspose.Slides for Python via .NET-bronnen

Verken deze nuttige bronnen::

- [Aspose.Slides for Python via .NET Online Documentation](/slides/nl/python-net/)
- [Aspose.Slides for Python via .NET Features](/slides/nl/python-net/features-overview/)
- [Aspose.Slides for Python via .NET Release Notes](https://releases.aspose.com/slides/nl/python-net/release-notes/)
- [Aspose.Slides for Python via .NET Product Page](https://products.aspose.com/slides/nl/python-net/)
- [Download Aspose.Slides for Python via .NET](https://releases.aspose.com/slides/nl/python-net/)
- [Installeer Aspose.Slides for Python via .NET PyPi Package](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API Reference Guide](https://reference.aspose.com/slides/nl/python-net/)
- [Aspose.Slides for Python via .NET Free Support Forum](https://forum.aspose.com/c/slides/nl/11)
- [Aspose.Slides for Python via .NET Paid Support Helpdesk](https://helpdesk.aspose.com/)

## FAQ

### Wat is Aspose.Slides for Python via .NET?

Aspose.Slides for Python via .NET is een krachtige Python-bibliotheek die u in staat stelt PowerPoint-presentaties (PPT, PPTX, ODP) programmatisch te maken, bewerken en converteren zonder Microsoft PowerPoint geïnstalleerd te hebben.

### Welke presentatiefuncties ondersteunt Aspose.Slides?

De bibliotheek ondersteunt het beheren van tekst, vormen, tabellen, grafieken, animaties, master-dia's, audio, video en meer. Daarnaast maakt het mogelijk dia-preview, rendering, afdrukken en exporteren naar formaten zoals PDF, SVG, HTML en afbeeldingen.

### Kan ik presentaties omzetten naar andere formaten met Aspose.Slides?

Ja. Aspose.Slides maakt conversie van PowerPoint-bestanden naar PDF, SVG, HTML, JPG, PNG, TIFF en andere formaten mogelijk met hoge getrouwheid en prestaties.

### Is Microsoft PowerPoint vereist om Aspose.Slides te gebruiken?

Nee. Aspose.Slides is een zelfstandige API en vereist geen Microsoft Office of andere derde-partijsoftware.

### Welke platformen ondersteunt Aspose.Slides for Python via .NET?

Het is cross-platform en werkt op Windows, Linux en macOS omgevingen.

### Hoe begin ik met Aspose.Slides for Python?

U kunt het installeren via PyPi en de [Developer Guide](/slides/nl/python-net/developer-guide/) verkennen om aan de slag te gaan met voorbeelden, API-referenties en tutorials.