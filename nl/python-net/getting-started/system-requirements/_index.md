---
title: Systeemvereisten
type: docs
weight: 60
url: /nl/python-net/system-requirements/
keywords:
- systeemvereisten
- besturingssysteem
- installatie
- afhankelijkheden
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek de systeemvereisten van Aspose.Slides for Python via .NET. Zorg voor naadloze ondersteuning van PowerPoint en OpenDocument op Windows, Linux en macOS."
---
## **Introductie**

Aspose.Slides for Python via .NET vereist geen derden‑producten, zoals Microsoft PowerPoint, die geïnstalleerd moeten worden. Aspose.Slides is een engine voor het maken, wijzigen, converteren en renderen van documenten in verschillende formaten, inclusief Microsoft PowerPoint‑presentatieformaten.

## **Ondersteunde besturingssystemen**

Aspose.Slides for Python ondersteunt Windows (32-bit en 64-bit), macOS en 64-bit Linux op systemen met Python 3.5 of hoger geïnstalleerd.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Besturingssysteem</td>
        <td style="font-weight: bold; width:400px">Versies</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>en andere</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Systeemvereisten voor doel‑Linux en macOS‑platforms**

- GCC 6 runtime‑bibliotheken (of later).
- [libgdiplus](https://github.com/mono/libgdiplus), een open‑source‑implementatie van de GDI+‑API.
- Afhankelijkheden van de .NET Core Runtime. Het installeren van de .NET Core Runtime zelf is NIET vereist.
- Voor Python 3.5–3.7: de `pymalloc`‑build van Python is vereist. De `--with-pymalloc`‑build‑optie is standaard ingeschakeld. Meestal wordt de `pymalloc`‑build van Python gemarkeerd met een `m`‑achtervoegsel in de bestandsnaam.
- De `libpython`‑shared library. De `--enable-shared`‑Python‑build‑optie is standaard uitgeschakeld, en sommige Python‑distributies bevatten de `libpython`‑shared library niet. Op sommige Linux‑platformen kun je de `libpython`‑shared library installeren via de pakketbeheerder (bijvoorbeeld `sudo apt-get install libpython3.7`). Een veelvoorkomend probleem is dat de `libpython`‑library geïnstalleerd is op een niet‑standaard locatie voor gedeelde libraries. Je kunt dit oplossen door Python‑build‑opties te gebruiken om alternatieve bibliotheekpaden in te stellen bij het compileren van Python, of door een symbolische link naar het `libpython`‑bibliotheekbestand te maken in de standaard gedeelde bibliotheeklocatie van het systeem. Meestal heeft het `libpython`‑shared library‑bestand de naam `libpythonX.Ym.so.1.0` voor Python 3.5–3.7 of `libpythonX.Y.so.1.0` voor Python 3.8 of hoger (bijvoorbeeld `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Moet ik Microsoft PowerPoint geïnstalleerd hebben voor conversies en weergave?**

Nee, PowerPoint is niet vereist; Aspose.Slides is een zelfstandige engine voor [maken](/slides/nl/python-net/create-presentation/), wijzigen, [converteren](/slides/nl/python-net/convert-presentation/) en [renderen](/slides/nl/python-net/convert-powerpoint-to-png/) van presentaties.

**Is een specifieke .NET‑versie (Core/5+/6+) vereist op de machine?**

Het installeren van de .NET Runtime zelf is niet nodig, maar de afhankelijkheden moeten wel aanwezig zijn op Linux/macOS. Dit betekent dat het systeem de pakketten moet bevatten die gewoonlijk als .NET‑afhankelijkheden worden geïnstalleerd, zonder de volledige runtime te installeren.

**Welke lettertypen zijn nodig voor correcte weergave?**

In de praktijk moeten de lettertypen die in de presentatie worden gebruikt of passende [alternatieven](/slides/nl/python-net/font-substitution/) beschikbaar zijn. Om consistente weergave op Linux/macOS te garanderen, is het aan te raden om veelvoorkomende lettertypepakketten te installeren.

**Waarom wordt een aangepast lettertype op Linux weergegeven als fallback of ontbrekende tekst?**

Als het lettertype‑bestand inconsistente of corrupte name‑table‑vermeldingen heeft, kan de Linux lettertype‑matching‑stack (FreeType/fontconfig) een ongeldige record selecteren, waardoor het lettertype niet gevonden wordt. Het gebruik van een lettertype‑versie met gecorrigeerde name‑table‑records of het installeren van een consistente vervanging lost het probleem op.