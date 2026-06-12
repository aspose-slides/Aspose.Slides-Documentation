---
title: Installatie
type: docs
weight: 70
url: /nl/python-net/installation/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- gebruiken Aspose.Slides
- Aspose.Slides installatie
- Windows
- macOS
- Python
description: "Leer hoe u snel Aspose.Slides for Python via .NET kunt installeren. Stapsgewijze handleiding, systeemvereisten en code-voorbeelden — begin vandaag nog met het werken met PowerPoint-presentaties!"
---
## **Overzicht**

Het Aspose.Slides for Python via .NET-pakket wordt geleverd met alle essentiële .NET‑bibliotheken, waardoor .NET niet apart geïnstalleerd hoeft te worden. Dit vereenvoudigt het installatieproces en stelt ontwikkelaars in staat meteen met presentaties aan de slag te gaan. Het is echter belangrijk op te merken dat, afhankelijk van uw besturingssysteem of omgeving, u mogelijk toch platform‑specifieke afhankelijkheden die .NET nodig heeft, moet installeren. Bovendien moeten aan bepaalde systeemvereisten voldaan worden om volledige compatibiliteit en een juiste werking van het pakket te garanderen.

## **Windows**

**Systeemvereisten**

Controleer en bevestig dat de specificaties van uw machine voldoen aan of hoger zijn dan de [systeemvereisten](/slides/nl/python-net/system-requirements/).

### **Installeer Aspose.Slides**

`pip` is de gemakkelijkste manier om [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) op Windows te downloaden en installeren.

Om Aspose.Slides te installeren, voert u het volgende commando uit:

```sh
pip install aspose-slides
```

**Gebruik Aspose.Slides**

Test uw Aspose.Slides‑installatie door de volgende code uit te voeren om een PowerPoint‑presentatie te maken:

```python
# Importeer de Aspose.Slides voor Python via .NET module.
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand voorstelt.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Systeemvereisten**

Controleer en bevestig dat de specificaties van uw machine voldoen aan of hoger zijn dan de [systeemvereisten](/slides/nl/python-net/system-requirements/).

### **Voorvereisten**

**Python met gedeelde bibliotheken**

Er zijn verschillende manieren om Python op macOS te installeren, maar we bevelen ten zeerste aan om het [pyenv‑tool](https://github.com/pyenv/pyenv#homebrew-in-macos) te gebruiken.

Na het installeren en configureren van **pyenv**, installeert u Python met gedeelde bibliotheken door de volgende commando’s in de Terminal‑app uit te voeren:

1. Installeer Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Stel deze in als de globale Python‑versie:

```sh
pyenv global 3.9.13
```

3. Stel deze in als de shell‑specifieke Python‑versie:

```sh
pyenv shell 3.9.13
```

4. Maak een symbolische link voor de libpython‑bibliotheek in een systeem‑bibliotheekmap:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Opmerking: Python 3.5 of hoger is vereist. Versie 3.9.13 wordt hier alleen als voorbeeld gebruikt.

**Installeer de libgdiplus‑bibliotheek**

De **libgdiplus**‑bibliotheek is een Windows‑GDI+‑implementatie voor macOS en Linux waar .NET op vertrouwt voor grafische functionaliteit op die platformen.  
Om deze bibliotheek op macOS te installeren, voert u het volgende commando uit:

```sh
brew install mono-libgdiplus
```

### **Installeer Aspose.Slides**

`pip` is de gemakkelijkste manier om [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) op macOS te downloaden en installeren.

Om Aspose.Slides te installeren, voert u het volgende commando uit:

```sh
pip install aspose-slides
```

**Gebruik Aspose.Slides**

Test uw Aspose.Slides‑installatie door de volgende code uit te voeren om een PowerPoint‑presentatie te maken:

```python
# Importeer de Aspose.Slides voor Python via .NET module.
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik Aspose.Slides installeren in een virtuele omgeving?**

Ja, u kunt het installeren in elke Python‑virtuele omgeving met behulp van `pip`. Zorg er gewoon voor dat de omgeving toegang heeft tot de vereiste native afhankelijkheden, afhankelijk van uw OS.

**Kan ik Aspose.Slides gebruiken in Docker‑containers?**

Ja, maar u moet ervoor zorgen dat uw Docker‑image de vereiste native bibliotheken (**libgdiplus**, lettertype‑pakketten, enz.) en de juiste versie van Python bevat.

**Is er een gratis versie of proefbeperking?**

Ja, standaard draait Aspose.Slides in evaluatiemodus, waardoor watermerken verschijnen en er mogelijk andere beperkingen zijn. Om de restricties te verwijderen moet u een geldige [licentie](/slides/nl/python-net/licensing/) toepassen.