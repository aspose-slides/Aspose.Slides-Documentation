---
title: Compatibiliteit met PyInstaller en cx_Freeze
linktitle: Compatibiliteit met PyInstaller
type: docs
weight: 122
url: /nl/python-net/compatibility-with-pyinstaller/
keywords:
- compatibiliteit
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Bundel Aspose.Slides for Python via .NET met PyInstaller. Volg deze handleiding om uw app te bundelen, configureren en problemen op te lossen tot een zelfstandige uitvoerbare bestand."
---
## **Inleiding**

Aspose.Slides for Python via .NET-extensies zijn standaard Python C-extensies, zodat ze kunnen worden bevroren als programmadependencies met gereedschappen zoals PyInstaller en cx_Freeze (of soortgelijk). Dit stelt u in staat om uitvoerbare bestanden te maken vanuit uw Python-scripts. Dergelijke gereedschappen worden "freezers" genoemd omdat ze uw code en de bijbehorende afhankelijkheden bundelen in één distributiebestand dat op andere computers draait zonder dat een Python-installatie of extra bibliotheken nodig zijn. Deze aanpak vereenvoudigt het distribueren van uw Python-applicaties.

Het bevriezen van een Aspose.Slides for Python via .NET-extensie als een afhankelijkheid wordt hieronder geïllustreerd met een eenvoudig programma dat Aspose.Slides gebruikt.

## **PyInstaller**

In het algemeen is er niets bijzonders vereist bij het verpakken van een programma dat afhankelijk is van een Aspose.Slides for Python via .NET-extensie. Wanneer een programma de extensie importeert op een manier die zichtbaar is voor PyInstaller, wordt de extensie gebundeld met het programma. Omdat Aspose.Slides for Python via .NET PyInstaller-hooks bevat, worden de afhankelijkheden automatisch gedetecteerd en gekopieerd naar de bundle.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

PyInstaller kan echter af en toe verborgen imports missen - modules die dynamisch of indirect door uw code worden geïmporteerd. Om een verborgen import op te nemen, gebruikt u de opties van PyInstaller. De afhankelijkheden van de extensie worden gespecificeerd in de PyInstaller-hooks die worden meegeleverd met Aspose.Slides for Python via .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

## **cx_Freeze**

Om een programma met cx_Freeze te bevriezen, configureert u het zodat het het hoofdpakket van de door u gebruikte Aspose.Slides for Python via .NET-extensie opneemt. Dit zorgt ervoor dat de extensie en alle afhankelijke modules worden gekopieerd naar de build naast uw applicatie.

### **Het cxfreeze-script gebruiken**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

### **Het setup-script gebruiken**

setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)
```

```bash
$ python setup.py build_exe
```

## **FAQ**

**Heb ik Microsoft PowerPoint of .NET geïnstalleerd nodig op de computer van de gebruiker?**

Nee, PowerPoint is niet vereist. Aspose.Slides is een zelfstandige engine; het Python-pakket levert alles wat nodig is als een extensie voor CPython. De gebruiker hoeft .NET niet apart te installeren.

**Hoe moet ik de licentie correct aan een bevroren applicatie koppelen?**

U kunt het licentie-XML naast het uitvoerbare bestand opslaan of het embedden als een resource en laden vanaf een toegankelijke pad vóór de eerste API-aanroep. Belangrijk: wijzig de XML-inhoud niet (niet eens regelafbrekingen).

**Wat moet ik doen als lettertypen er na de build anders uitzien dan tijdens de ontwikkeling?**

Zorg ervoor dat de lettertypen die u gebruikt beschikbaar zijn in de doelomgeving (ge-bundeld of systeem-geïnstalleerd) en dat hun paden correct worden opgelost tijdens runtime; het gedrag van lettertypen is vooral gevoelig op Linux.