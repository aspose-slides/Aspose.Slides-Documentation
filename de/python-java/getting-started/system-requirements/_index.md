---
title: Systemanforderungen
type: docs
weight: 60
url: /de/python-java/system-requirements/
keywords:
- Systemanforderungen
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Prüfen Sie die Betriebssystem-, Python-, Java- und JPype-Anforderungen für die Ausführung von Aspose.Slides for Python via Java unter Windows, Linux und macOS."
---
## **Übersicht**

Aspose.Slides for Python via Java erstellt, ändert, konvertiert und rendert Präsentationen, ohne dass Microsoft PowerPoint installiert sein muss. Es verwendet JPype, um von Python aus auf die Java-Bibliothek zuzugreifen, daher muss die Umgebung Python, Java und JPype gemeinsam unterstützen.

## **Unterstützte Betriebssysteme**

Das [Aspose.Slides package](https://pypi.org/project/aspose-slides-java/) unterstützt die folgenden Betriebssystem-Familien:

- Windows
- Linux
- macOS

Wählen Sie eine Betriebssystemversion, die von Ihren ausgewählten Python-, Java- und JPype-Versionen unterstützt wird. Allein die Verfügbarkeit von Java stellt keine Kompatibilität mit dem Python-Paket und seiner Brücke sicher.

## **Python-, Java- und JPype-Anforderungen**

| Komponente | Anforderung |
| --- | --- |
| Python | Das Aspose.Slides-Paket gibt Python 3.7 bis 3.14 an. Die gewählte JPype-Version muss dieselbe Python-Version unterstützen; zum Beispiel erfordert [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) Python 3.8 oder neuer. |
| Java | Installieren Sie eine Java-Runtime oder ein JDK, das mit der gewählten JPype-Version kompatibel ist. Die aktuellen [JPype-Voraussetzungen](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) geben Java 11 oder höher an. Java 8 kann JPype1 1.7.1 nicht ausführen. |
| JPype | Installieren Sie das JPype1-Paket für Ihren Python-Interpreter, Ihr Betriebssystem und Ihre CPU-Architektur. |
| CPU-Architektur | Python und die Java Virtual Machine (JVM) müssen passende Architekturen verwenden. Beispielsweise erfordert ein 64-bit Python-Interpreter eine kompatible 64-bit JVM. |

Auf Apple Silicon müssen Python und Java beide ARM64 oder beide x64 verwenden. Eine eigenständig laufende JVM kann dennoch fehlschlagen, wenn ihre Architektur von der von Python abweicht.

Für eine neue Umgebung sind Python 3.12, JDK 17 und JPype1 1.7.1 ein geeigneter Ausgangspunkt. Diese Kombination wurde mit Aspose.Slides for Python via Java 26.6.0 unter Windows verifiziert. Andere Kombinationen müssen die Anforderungen aller drei Komponenten erfüllen.

Für die Umgebungseinrichtung und ein funktionierendes Verifikationsbeispiel siehe [Installation](/slides/de/python-java/installation/).

## **Zusätzliche Abhängigkeiten**

Ein kompatibles vorgefertigtes JPype-Wheel erfordert keinen C++-Compiler. Wenn JPype aus dem Quellcode gebaut werden muss, installieren Sie einen passenden C++-Compiler und die für Ihre Plattform erforderlichen Python-Entwicklungsdateien. Siehe die [JPype-Installationsanweisungen](https://jpype.readthedocs.io/en/latest/install.html) für Build-Voraussetzungen und Fehlersuche.

## **FAQ**

**Muss ich Microsoft PowerPoint installiert haben?**

Nein. Aspose.Slides verarbeitet Präsentationen unabhängig von PowerPoint. Python, Java und JPype werden dennoch benötigt.

**Kann ich Python 3.7 mit irgendeiner JPype-Version verwenden?**

Nein. Obwohl das Aspose.Slides-Paket Unterstützung für Python 3.7 angibt, erfordert JPype1 1.7.1 Python 3.8 oder neuer. Wählen Sie Versionen, deren Anforderungen sich überschneiden.

**Kann ich 32-bit Python mit 64-bit Java kombinieren?**

Nein. JPype lädt die JVM in den Python-Prozess, daher müssen Python und Java passende Architekturen haben. dieselbe Anforderung gilt für ARM64 und x64 unter macOS.