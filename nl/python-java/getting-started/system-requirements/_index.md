---
title: Systeemvereisten
type: docs
weight: 60
url: /nl/python-java/system-requirements/
keywords:
- systeemvereisten
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Controleer de vereisten voor het besturingssysteem, Python, Java en JPype om Aspose.Slides for Python via Java uit te voeren op Windows, Linux en macOS."
---
## **Overzicht**

Aspose.Slides for Python via Java maakt, wijzigt, converteert en rendert presentaties zonder dat Microsoft PowerPoint geïnstalleerd is. Het gebruikt JPype om vanuit Python toegang te krijgen tot de Java‑bibliotheek, dus de omgeving moet Python, Java en JPype tegelijk ondersteunen.

## **Ondersteunde besturingssystemen**

Het [Aspose.Slides‑pakket](https://pypi.org/project/aspose-slides-java/) ondersteunt de volgende besturingssysteemfamilies:

- Windows
- Linux
- macOS

Selecteer een besturingssysteemversie die wordt ondersteund door de door u gekozen releases van Python, Java en JPype. Alleen de beschikbaarheid van Java garandeert geen compatibiliteit met het Python‑pakket en de brug.

## **Vereisten voor Python, Java en JPype**

| Component | Vereiste |
| --- | --- |
| Python | Het Aspose.Slides‑pakket geeft ondersteuning voor Python 3.7 tot en met 3.14 aan. De gekozen JPype‑release moet dezelfde Python‑versie ondersteunen; bijvoorbeeld, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) vereist Python 3.8 of hoger. |
| Java | Installeer een Java‑runtime of JDK die compatibel is met de gekozen JPype‑release. De huidige [JPype‑vereisten](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) geven Java 11 of hoger aan. Java 8 kan JPype1 1.7.1 niet draaien. |
| JPype | Installeer het JPype1‑pakket voor uw Python‑interpreter, besturingssysteem en CPU‑architectuur. |
| CPU‑architectuur | Python en de Java Virtual Machine (JVM) moeten dezelfde architectuur gebruiken. Bijvoorbeeld, een 64‑bit Python‑interpreter vereist een compatibele 64‑bit JVM. |

Op Apple Silicon moeten Python en Java beide ARM64 of beide x64 gebruiken. Een JVM die onafhankelijk wordt uitgevoerd, kan nog steeds falen bij het laden via JPype als de architectuur verschilt van die van Python.

Voor een nieuwe omgeving zijn Python 3.12, JDK 17 en JPype1 1.7.1 een geschikt startpunt. Deze combinatie is geverifieerd met Aspose.Slides for Python via Java 26.6.0 op Windows. Andere combinaties moeten voldoen aan de vereisten van alle drie de componenten.

Voor de configuratie van de omgeving en een werkend verificatie‑voorbeeld, zie [Installatie](/slides/nl/python-java/installation/).

## **Aanvullende afhankelijkheden**

Een compatibel vooraf gebouwd JPype‑wheel vereist geen C++‑compiler. Als JPype vanuit de bron moet worden gebouwd, installeer dan een compatibele C++‑compiler en de Python‑ontwikkelbestanden die uw platform nodig heeft. Zie de [JPype‑installatie‑instructies](https://jpype.readthedocs.io/en/latest/install.html) voor de bouwvereisten en probleemoplossing.

## **FAQ**

**Moet ik Microsoft PowerPoint geïnstalleerd hebben?**

Nee. Aspose.Slides verwerkt presentaties onafhankelijk van PowerPoint. Python, Java en JPype blijven wel vereist.

**Kan ik Python 3.7 gebruiken met elke JPype‑release?**

Nee. Hoewel het Aspose.Slides‑pakket ondersteuning voor Python 3.7 aangeeft, vereist JPype1 1.7.1 Python 3.8 of hoger. Kies versies waarvan de vereisten overlappen.

**Kan ik 32‑bit Python combineren met 64‑bit Java?**

Nee. JPype laadt de JVM in het Python‑proces, dus Python en Java moeten dezelfde architectuur hebben. Dezezelfde eis geldt voor ARM64 en x64 op macOS.