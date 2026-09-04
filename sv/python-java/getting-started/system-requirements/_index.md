---
title: Systemkrav
type: docs
weight: 60
url: /sv/python-java/system-requirements/
keywords:
- systemkrav
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Kontrollera operativsystemet, Python, Java och JPype-kraven för att köra Aspose.Slides för Python via Java på Windows, Linux och macOS."
---
## **Översikt**

Aspose.Slides for Python via Java skapar, ändrar, konverterar och renderar presentationer utan att Microsoft PowerPoint är installerat. Den använder JPype för att få åtkomst till Java‑biblioteket från Python, så miljön måste stödja Python, Java och JPype tillsammans.

## **Stödda operativsystem**

[Aspose.Slides‑paketet](https://pypi.org/project/aspose-slides-java/) stödjer följande operativsystemfamiljer:

- Windows
- Linux
- macOS

Välj en version av operativsystemet som stöds av dina valda Python‑, Java‑ och JPype‑utgåvor. Enbart Java‑tillgänglighet garanterar inte kompatibilitet med Python‑paketet och dess brygga.

## **Krav för Python, Java och JPype**

| Komponent | Krav |
| --- | --- |
| Python | Aspose.Slides‑paketet anger stöd för Python 3.7 till 3.14. Den valda JPype‑utgåvan måste stödja samma Python‑version; till exempel, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) kräver Python 3.8 eller senare. |
| Java | Installera en Java‑runtime eller JDK som är kompatibel med den valda JPype‑utgåvan. De aktuella [JPype‑förutsättningarna](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) specificerar Java 11 eller senare. Java 8 kan inte köra JPype1 1.7.1. |
| JPype | Installera JPype1‑paketet för din Python‑tolk, operativsystem och CPU‑arkitektur. |
| CPU architecture | Python och Java Virtual Machine (JVM) måste använda matchande arkitekturer. Till exempel kräver en 64‑bit Python‑tolk en kompatibel 64‑bit JVM. |

På Apple Silicon måste både Python och Java använda ARM64 eller båda använda x64. En JVM som körs fristående kan fortfarande misslyckas att laddas via JPype om dess arkitektur skiljer sig från Pythons.

För en ny miljö är Python 3.12, JDK 17 och JPype1 1.7.1 en lämplig startpunkt. Denna kombination verifierades med Aspose.Slides for Python via Java 26.6.0 på Windows. Andra kombinationer måste uppfylla kraven för alla tre komponenter.

För miljöinställning och ett fungerande verifieringsexempel, se [Installation](/slides/sv/python-java/installation/).

## **Ytterligare beroenden**

Ett kompatibelt förbyggt JPype‑wheel kräver ingen C++‑kompilator. Om JPype måste byggas från källkod, installera en kompatibel C++‑kompilator och de Python‑utvecklingsfiler som krävs för din plattform. Se [JPype‑installationsinstruktionerna](https://jpype.readthedocs.io/en/latest/install.html) för byggkrav och felsökning.

## **FAQ**

**Behöver jag ha Microsoft PowerPoint installerat?**

Nej. Aspose.Slides bearbetar presentationer oberoende av PowerPoint. Python, Java och JPype krävs fortfarande.

**Kan jag använda Python 3.7 med någon JPype‑utgåva?**

Nej. Trots att Aspose.Slides‑paketet anger stöd för Python 3.7, kräver JPype1 1.7.1 Python 3.8 eller senare. Välj versioner vars krav överlappar.

**Kan jag blanda 32‑bit Python med 64‑bit Java?**

Nej. JPype laddar JVM:n i Python‑processen, så Python och Java måste ha matchande arkitekturer. Samma krav gäller för ARM64 och x64 på macOS.