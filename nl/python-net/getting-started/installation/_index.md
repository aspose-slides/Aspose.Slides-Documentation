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
- pip
- PyPI
- Windows
- Linux
- macOS
- Python
description: "Installeer Aspose.Slides voor Python via .NET vanaf PyPI met pip op Windows, Linux en macOS, en installeer de native bibliotheken die Linux en macOS nodig hebben."
---
## **Overzicht**

Dit artikel legt uit hoe u Aspose.Slides for Python via .NET installeert op Windows, Linux en macOS. Het pakket wordt gepubliceerd op [PyPI](https://pypi.org/project/aspose.slides/) en geïnstalleerd met pip. Het bevat de .NET-runtime die het gebruikt, dus u hoeft .NET niet apart te installeren. Op Linux en macOS heeft die runtime native bibliotheken nodig die het besturingssysteem mogelijk niet bevat; de onderstaande secties benoemen deze.

Aspose.Slides for Python via .NET ondersteunt Python 3.5 tot en met 3.14. PyPI levert pakketten voor Windows (32‑bit en 64‑bit), Linux (x86_64 en ARM64) en macOS (Intel en Apple silicon).

## **Windows**

Op Windows installeert u het pakket met pip. Er zijn geen andere bibliotheken vereist.

```bash
pip install aspose.slides
```

## **Linux**

Op Linux heeft de .NET-runtime die in het pakket is opgenomen twee bibliotheken nodig:

- **libgdiplus**, een implementatie van de Windows GDI+ Grafische API. Zonder deze mislukt het opslaan van een presentatie met de fout `The type initializer for 'Gdip' threw an exception`.
- **ICU** (International Components for Unicode). Zonder deze wordt het Python-proces beëindigd bij de eerste Aspose.Slides-aanroep met de melding `Couldn't find a valid ICU package installed on the system`.

Op Debian en Ubuntu installeert u beide met apt:

```bash
sudo apt-get update && sudo apt-get install -y libgdiplus libicu76
```

De naam van het ICU‑pakket bevat de versie: `libicu76` is het pakket voor Debian 13. Op Debian 12 installeert u in plaats daarvan `libicu72`, en op Ubuntu 24.04 `libicu74`. Om de naam op uw systeem te achterhalen, voert u uit:

```bash
apt-cache search --names-only '^libicu[0-9]+$'
```

Installeer vervolgens het pakket in een virtuele omgeving. Op de huidige Debian‑ en Ubuntu‑releases laat de systeem‑Python geen `pip install` buiten een virtuele omgeving toe en stopt met de fout `externally-managed-environment`.

```bash
sudo apt-get install -y python3-venv
python3 -m venv .venv
. .venv/bin/activate
pip install aspose.slides
```

Voer uw scripts uit met dezelfde geactiveerde virtuele omgeving. Als u een Python gebruikt die uw distributie niet beheert, zoals die in de officiële `python` Docker‑images, kunt u ook `pip install aspose.slides` uitvoeren zonder een virtuele omgeving.

De lettertypen die in uw presentaties worden gebruikt, of geschikte alternatieven, moeten op het systeem geïnstalleerd zijn zodat tekst correct wordt weergegeven bij het converteren van dia's naar PDF of afbeeldingen.

## **macOS**

We hebben de installatie op macOS niet geverifieerd. Op macOS heeft Aspose.Slides de volgende vereisten:

- **Python met gedeelde bibliotheken**, dat wil zeggen Python gebouwd met de configure‑optie `--enable-shared`. Als u Python installeert met [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos), stelt u de omgevingsvariabele `PYTHON_CONFIGURE_OPTS` in op `--enable-shared` wanneer u een Python‑versie installeert.
- **De libpython‑bibliotheek in een systeembibliotheekmap.** Een met pyenv geïnstalleerde Python bewaart zijn libpython‑bibliotheek, bijvoorbeeld *libpython3.9.dylib*, onder *~/.pyenv/versions*; maak er een symbolische link naar in */usr/local/lib*.
- **libgdiplus**, een implementatie van de Windows GDI+ Grafische API. Homebrew biedt dit aan als het `mono-libgdiplus`‑pakket.

Installeer vervolgens het pakket met pip.

## **Installatie controleren**

Om de installatie te controleren, slaat u het eerste voorbeeld uit [Presentaties maken](/slides/nl/python-net/create-presentation/) op als *hello.py* en voert u `python hello.py` uit. Het slaat *new_presentation.pptx* op in de huidige map.

## **Upgraden**

Om een bestaande installatie naar de nieuwste versie te upgraden, voert u dit commando uit in de omgeving waar u het pakket hebt geïnstalleerd:

```bash
pip install --upgrade aspose.slides
```

## **FAQ**

**Kan ik Aspose.Slides installeren in een virtuele omgeving?**

Ja. U kunt het in elke Python‑virtuele omgeving installeren met pip. De native bibliotheken die Linux en macOS nodig hebben, worden op het systeem geïnstalleerd, niet in de virtuele omgeving.

**Kan ik Aspose.Slides gebruiken in Docker‑containers?**

Ja. Het image moet dezelfde native bibliotheken bevatten als een Linux‑systeem — libgdiplus en ICU — en de lettertypen die uw presentaties gebruiken.

**Is er een gratis versie of proefbeperking?**

Ja. Zonder licentie draait Aspose.Slides in evaluatiemodus: het voegt een evaluatiewatermerk toe aan elke dia die wordt opgeslagen en knipt tekst af die uit presentaties wordt gelezen. Om deze beperkingen te verwijderen, past u een geldige [licentie](/slides/nl/python-net/licensing/) toe.