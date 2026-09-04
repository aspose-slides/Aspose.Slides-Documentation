---
title: Installatie
type: docs
weight: 70
url: /nl/python-java/installation/
keywords:
- download Aspose.Slides
- installeer Aspose.Slides
- Aspose.Slides installatie
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Installeer Aspose.Slides voor Python via Java op Windows, Linux of macOS, configureer Java en JPype, en controleer de installatie met een werkend voorbeeld."
---
Aspose.Slides for Python via Java draait op Windows, Linux en macOS. Het maakt gebruik van JPype om vanuit Python toegang te krijgen tot de Java‑bibliotheek. Microsoft PowerPoint is niet vereist.

## **Vereisten**

Installeer eerst Python en een JDK die voldoen aan de [Systeemvereisten](/slides/nl/python-java/system-requirements/). Die pagina bevat een lijst met compatibele versies, architectuurvereisten en eventuele afhankelijkheden die nodig zijn om JPype vanuit de bron te bouwen.

Stel `JAVA_HOME` in op de installatiemap van de JDK, niet op de `bin`‑submap, en voeg de `bin`‑map van de JDK toe aan `PATH`. Open een nieuwe terminal nadat de omgevingsvariabelen zijn aangepast.

## **Installeren vanuit PyPI**

Voer de volgende opdrachten uit in een terminal, niet in de interactieve Python‑prompt. Maak een projectmap en een virtuele omgeving aan om de pakketten geïsoleerd te houden van andere projecten.

### **Windows**

Zorg ervoor dat de door u gekozen Python‑interpreter beschikbaar is als `python` in `PATH` en voer de volgende opdrachten uit in de Opdrachtprompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux en macOS**

Zorg ervoor dat de door u gekozen Python‑versie beschikbaar is als `python3` en voer de volgende opdrachten uit in Bash of zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Op Debian of Ubuntu, wanneer het aanmaken van de omgeving mislukt omdat `ensurepip` niet beschikbaar is, installeer het pakket `python3-venv` met `sudo apt-get install python3-venv` en herhaal vervolgens de opdracht om de omgeving te maken. Een afzonderlijk geïnstalleerde Python‑versie kan een versie‑specifiek `venv`‑pakket nodig hebben.

### **Pakketten installeren**

Zet de virtuele omgeving aan en installeer JPype en Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Met `python -m pip` wordt gegarandeerd dat de pakketten worden geïnstalleerd voor de interpreter die u gebruikt om uw applicatie uit te voeren.

Om een bestaande Aspose.Slides‑installatie bij te werken, voert u `python -m pip install --upgrade aspose-slides-java` uit in dezelfde omgeving.

## **Installeren vanuit een ZIP‑archief**

U kunt de bibliotheek ook gebruiken vanaf de [Aspose.Slides‑downloadpagina](https://releases.aspose.com/slides/nl/python-java/):

1. Installeer Python en Java zoals beschreven in [Vereisten](#prerequisites).
2. Maak een virtuele omgeving aan en activeer deze met behulp van de bovenstaande instructies.
3. Installeer JPype met `python -m pip install JPype1`.
4. Download en pak het ZIP‑archief van Aspose.Slides for Python via Java uit.
5. Zoek de uitgepakte `asposeslides`‑pakketmap. Houd de inhoud, inclusief de `lib`‑map en het JAR‑bestand, samen.
6. Plaats `example.py` uit de volgende sectie naast de `asposeslides`‑map zodat Python het pakket kan importeren.

## **Verifiëren van de installatie**

Sla de volgende code op als `example.py`. Deze maakt een presentatie met een tekstvak en slaat deze op als `out.pptx` in de huidige werkmap.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Met de virtuele omgeving actief, voer het voorbeeld uit vanuit de map die `example.py` bevat:

```sh
python example.py
```

De import `asposeslides` registreert de meegeleverde Java‑bibliotheek voordat de JVM start. Importeer `asposeslides.api` nadat de JVM is gestart en maak de presentatiebronnen vrij voordat u de JVM afsluit.

{{% alert color="info" title="Opmerking" %}}
Zonder licentie bevat de uitvoer een evaluatiewatermerk. Zie [Evalueer Aspose.Slides](/slides/nl/python-java/evaluate-aspose-slides/) voor beperkingen van de evaluatie en informatie over tijdelijke licenties.
{{% /alert %}}

## **FAQ**

**Waarom geeft Python aan dat de JVM niet gevonden of geladen kan worden?**

Controleer of `JAVA_HOME` wijst naar een JDK die compatibel is met uw Python‑ en JPype‑installatie, zoals beschreven in de [Systeemvereisten](/slides/nl/python-java/system-requirements/). Raadpleeg de [JPype‑installatie‑foutopsporingsgids](https://jpype.readthedocs.io/en/latest/install.html) voor extra controles.

**Waarom meldt Python dat `asposeslides` ontbreekt na installatie?**

Het pakket is mogelijk geïnstalleerd voor een andere Python‑interpreter. Activeer de virtuele omgeving die u voor de installatie hebt gebruikt en voer `python -m pip show aspose-slides-java` uit. Zorg er bij een ZIP‑installatie voor dat de `asposeslides`‑map naast uw script staat of anderszins beschikbaar is op het module‑zoekpad van Python.

**Kan ik het voorbeeld herhaaldelijk uitvoeren in een notebook?**

Het voorbeeld is bedoeld voor een zelfstandig Python‑proces. Voordat u het aanpast voor herhaaldelijke uitvoering in een notebook, zie [Beperkingen en API‑verschillen](/slides/nl/python-java/limitations-and-api-differences/#import-the-library) voor informatie over de levenscyclus van de JVM en richtlijnen voor notebooks.

**Waarom faalt pip met `CERTIFICATE_VERIFY_FAILED`?**

Wanneer uw netwerk een HTTPS‑inspectie‑proxy gebruikt, moet pip de certificaatautoriteit daarvan vertrouwen. Configureer het vertrouwde CA‑pakket met de `--cert`‑optie van pip of de omgevingsvariabele `PIP_CERT`, volgens de [pip‑HTTPS‑certificaatinstructies](https://pip.pypa.io/en/stable/topics/https-certificates/). De benodigde configuratie hangt af van uw netwerk en de pip‑versie.