---
title: Erste Schritte
type: docs
weight: 10
url: /de/java/getting-started/
keywords:
- Erste Schritte
- Systemanforderungen
- Installation
- Erste Präsentation
- Maven
- PPT-Verarbeitung
- PPTX-Verarbeitung
- ODP-Verarbeitung
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Der Weg von einem neuen Java-Projekt zu einer ersten gespeicherten Präsentation mit Aspose.Slides: prüfen Sie die Anforderungen, fügen Sie die Bibliothek aus Asposes Maven-Repository hinzu, führen Sie ein erstes Programm aus und setzen Sie die gängigen Aufgaben fort."
---
## **Übersicht**

Arbeiten Sie die vier nachfolgenden Schritte in der angegebenen Reihenfolge durch. Jeder Schritt beschreibt, was zu tun ist, und verlinkt den Artikel mit den Details. Bewertung, Lizenzierung und Support werden nach den Schritten behandelt.

## **Schritt 1: Systemanforderungen prüfen**

Aspose.Slides for Java ist eine einzelne JAR‑Datei ohne nativen Code, sodass sie auf jedem Betriebssystem läuft, das eine unterstützte Java‑Runtime bereitstellt. [Systemanforderungen](/slides/de/java/system-requirements/) listet die unterstützten Betriebssysteme und Java‑Versionen auf. Das Projekt und die Befehle in den nächsten Schritten benötigen JDK 11 oder neuer und für den Maven‑Weg [Apache Maven](https://maven.apache.org/install.html).

## **Schritt 2: Bibliothek zu Ihrem Projekt hinzufügen**

Aspose.Slides for Java wird im eigenen Maven‑Repository von Aspose veröffentlicht, nicht in Maven Central. Wählen Sie einen dieser Wege:

- Mit Maven: deklarieren Sie das Repository `https://releases.aspose.com/java/repo/` in Ihrer *pom.xml* und fügen Sie die Abhängigkeit `com.aspose:aspose-slides` mit dem `jdk16`‑Classifier hinzu.
- Ohne Maven: laden Sie die JAR‑Datei herunter, deren Name auf *-jdk16.jar* endet, aus dem Repository und fügen Sie sie dem Klassenpfad hinzu.

Unter Linux installieren Sie außerdem die Bibliothek *fontconfig* und mindestens eine Schriftart. Ohne diese schlägt das Speichern einer Präsentation mit dem Fehler „Fontconfig head is null, check your fonts or fonts configuration“ fehl.

[Installation](/slides/de/java/installation/) liefert die *pom.xml*-Einträge, den JAR‑Download und den Linux‑Befehl.

## **Schritt 3: Erste Präsentation erstellen**

Der [Schnellstart auf der Aspose.Slides for Java-Startseite](/slides/de/java/#your-first-presentation) ist ein komplettes Maven‑Projekt: eine *pom.xml*-Datei und ein Programm, das einer Folie eine Wolkenform mit Text hinzufügt und die Präsentation als PPTX‑Datei speichert. Sie führen es mit `mvn compile exec:java` aus. [Präsentationen erstellen](/slides/de/java/create-presentation/) erklärt dasselbe Programm Schritt für Schritt. Um eine vorhandene Präsentation zu öffnen und in ein anderes Format zu speichern, siehe [Präsentationen öffnen](/slides/de/java/open-presentation/) und [Präsentationen speichern](/slides/de/java/save-presentation/).

## **Schritt 4: Mit gängigen Aufgaben fortfahren**

- [Präsentation öffnen](/slides/de/java/open-presentation/)
- [Präsentation speichern](/slides/de/java/save-presentation/)
- [Präsentation in PDF konvertieren](/slides/de/java/convert-powerpoint-to-pdf/)
- [Folien als Bilder rendern](/slides/de/java/convert-slide/)
- [Präsentationstext bearbeiten](/slides/de/java/manage-text/)
- [Beispiele nach Folienelement](/slides/de/java/examples/)

## **Bewerten und Lizenzieren**

Ohne Lizenz läuft Aspose.Slides im Evaluierungsmodus: Es fügt jedem gespeicherten Folien ein Wasserzeichen hinzu und kürzt Text, den Ihr Code aus Präsentationen liest.

- [Aspose.Slides evaluieren](/slides/de/java/evaluate-aspose-slides/) beschreibt die Evaluierungsbeschränkungen und wie man eine temporäre Lizenz anfordert.
- [Lizenzierung](/slides/de/java/licensing/) zeigt, wie man eine Lizenz aus einer Datei oder einem Stream anwendet.
- [Verbrauchsbasierte Lizenzierung](/slides/de/java/metered-licensing/) behandelt Lizenzen, die nach Nutzung abgerechnet werden.
- [Unterstützte Dateiformate](/slides/de/java/supported-file-formats/) listet die Formate auf, die Aspose.Slides laden und speichern kann.

## **Hilfe erhalten**

[Technischer Support](/slides/de/java/technical-support/) erklärt, wie Sie eine Frage im [kostenlosen Support‑Forum](https://forum.aspose.com/c/slides/de/11) stellen und welche Informationen Sie bei der Meldung eines Problems angeben sollten.

## **FAQ**

**Benötige ich Microsoft PowerPoint installiert?**

Nein. Aspose.Slides liest und schreibt Präsentationsdateien eigenständig und verwendet kein PowerPoint, sodass es auch auf Servern und unter Linux läuft.

**Warum findet Maven Aspose.Slides for Java nicht?**

Die Bibliothek ist nicht in Maven Central. Deklarieren Sie Asposes Repository in Ihrer *pom.xml*, wie in [Installation](/slides/de/java/installation/) gezeigt, und Maven lädt die Bibliothek von dort herunter.

**Bedeutet der `jdk16`‑Classifier, dass die Bibliothek Java 16 benötigt?**

Nein. Der Classifier wählt das Java‑SE‑Build der Bibliothek; das andere Build ist für Android vorgesehen. Das gleiche Build läuft auf aktuellen JDKs, wie zum Beispiel JDK 21.