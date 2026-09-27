---
title: Installatie
type: docs
weight: 70
url: /nl/python-java/installation/
keywords:
- downloaden Aspose.Slides
- installeren Aspose.Slides
- installatie van Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Installeer Aspose.Slides voor Python via Java op Windows, Linux of macOS, configureer Java en JPype, en controleer de installatie met een werkend voorbeeld."
---
Aspose.Slides voor Python via Java draait op Windows, Linux en macOS. Het gebruikt JPype om toegang te krijgen tot de Java‑bibliotheek vanuit Python. Microsoft PowerPoint is niet vereist.

## **Voorwaarden**

Voordat u de Python‑pakketten installeert, installeert u Python en een JDK die voldoen aan de [Systeemvereisten](/slides/nl/python-java/system-requirements/). Die pagina bevat een lijst met compatibele versies, architectuurvereisten en eventuele afhankelijkheden die nodig zijn om JPype vanuit de broncode te bouwen.

Stel `JAVA_HOME` in op de installatie‑map van de JDK, niet op de `bin`‑submap, en voeg de `bin`‑map van de JDK toe aan `PATH`. Open een nieuwe terminal nadat u de omgevingsvariabelen hebt aangepast.

## **Installeren vanaf PyPI**

Voer de volgende opdrachten uit in een terminal, niet in de interactieve Python‑prompt. Maak een projectmap en een virtuele omgeving om de pakketten geïsoleerd te houden van andere projecten.

### **Windows**

Zodra uw gekozen Python‑interpreter beschikbaar is als `python` in `PATH`, voert u de volgende opdrachten uit in de Opdrachtprompt:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux en macOS**

Zodra uw gekozen Python‑versie beschikbaar is als `python3`, voert u de volgende opdrachten uit in Bash of zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Op Debian of Ubuntu, als het maken van de omgeving mislukt omdat `ensurepip` niet beschikbaar is, installeert u het pakket `python3-venv` met `sudo apt-get install python3-venv` en herhaalt u vervolgens de opdracht om de omgeving te maken. Een apart geïnstalleerde Python‑versie kan een bijbehorend versie‑specifiek `venv`‑pakket nodig hebben.

### **Installeer de pakketten**

Met de virtuele omgeving actief, installeert u JPype en Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Het gebruik van `python -m pip` zorgt ervoor dat pakketten worden geïnstalleerd voor de interpreter die wordt gebruikt om uw applicatie uit te voeren.

Om een bestaande Aspose.Slides‑installatie bij te werken, voert u `python -m pip install --upgrade aspose-slides-java` uit in dezelfde omgeving.

## **Installeren vanuit een ZIP‑archief**

U kunt de bibliotheek ook gebruiken vanaf de [Aspose.Slides downloadpagina](https://releases.aspose.com/slides/python-java/):

1. Installeer Python en Java zoals beschreven in [Prerequisites](#prerequisites).
2. Maak een virtuele omgeving aan en activeer deze met behulp van de bovenstaande instructies.
3. Installeer JPype met `python -m pip install JPype1`.
4. Download en pak het ZIP‑archief van Aspose.Slides voor Python via Java uit.
5. Zoek de uitgepakte `asposeslides`‑pakketmap. Houd de inhoud, inclusief de `lib`‑map en het JAR‑bestand, samen.
6. Plaats `example.py` uit de volgende sectie naast de `asposeslides`‑map zodat Python het pakket kan importeren. Het archief bevat al een eigen `example.py` naast `asposeslides`; vervang deze door de onderstaande.

## **Verifieer de installatie**

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

Met de virtuele omgeving actief, voert u het voorbeeld uit vanuit de map die `example.py` bevat:

```sh
python example.py
```

De `asposeslides`‑import registreert de meegeleverde Java‑bibliotheek voordat de JVM start. Importeer `asposeslides.api` nadat de JVM is gestart, en maak de presentatieresources vrij voordat u deze afsluit.

{{% alert color="info" title="Note" %}}
Zonder licentie bevat de uitvoer een evaluatiewatermerk. Zie [Evalueren van Aspose.Slides](/slides/nl/python-java/evaluate-aspose-slides/) voor evaluatiebeperkingen en informatie over een tijdelijke licentie.
{{% /alert %}}

## **FAQ**

**Waarom meldt Python dat de JVM niet gevonden of geladen kan worden?**

Controleer of `JAVA_HOME` verwijst naar een JDK die compatibel is met uw Python‑ en JPype‑installatie, zoals beschreven in de [Systeemvereisten](/slides/nl/python-java/system-requirements/). Zie de [JPype installatie‑troubleshooting‑gids](https://jpype.readthedocs.io/en/latest/install.html) voor extra controles.

**Waarom meldt Python dat `asposeslides` ontbreekt na installatie?**

Het pakket is mogelijk geïnstalleerd voor een andere Python‑interpreter. Activeer de virtuele omgeving die u voor de installatie hebt gebruikt en voer `python -m pip show aspose-slides-java` uit. Zorg bij een ZIP‑installatie ervoor dat de `asposeslides`‑map naast uw script staat of anderszins beschikbaar is in het module‑zoekpad van Python.

**Kan ik het voorbeeld herhaaldelijk uitvoeren in een notebook?**

Het voorbeeld is bedoeld voor een zelfstandig Python‑proces. Voordat u het aanpast voor herhaaldelijke notebook‑uitvoering, bekijk [Beperkingen en API‑verschillen](/slides/nl/python-java/limitations-and-api-differences/#import-the-library) voor informatie over de JVM‑levenscyclus en notebook‑richtlijnen.

**Waarom faalt pip met `CERTIFICATE_VERIFY_FAILED`?**

Als uw netwerk een HTTPS‑inspectie‑proxy gebruikt, moet pip de certificaatautoriteit ervan vertrouwen. Configureer de vertrouwde CA‑bundel met de `--cert`‑optie van pip of de `PIP_CERT`‑omgevingsvariabele, volgens de [pip HTTPS‑certificaat‑instructies](https://pip.pypa.io/en/stable/topics/https-certificates/). De benodigde configuratie hangt af van uw netwerk en de pip‑versie.