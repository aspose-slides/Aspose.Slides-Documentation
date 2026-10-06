---
title: Sicherheit
type: docs
weight: 160
url: /de/java/security/
keywords:
- Sicherheit
- Abhängigkeiten
- Drittanbieter-Komponenten
- Maven
- JAR-Signatur
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Überprüfen Sie, wie Aspose.Slides für Java Präsentationen verarbeitet, was es zu den Abhängigkeiten Ihres Projekts hinzufügt, wie Sie die JAR-Datei überprüfen und welche Drittanbieter-Komponenten es enthält."
---
## **Einleitung**

Dieser Artikel sammelt die Informationen, die eine Sicherheitsüberprüfung einer Anwendung, die Aspose.Slides für Java verwendet, normalerweise benötigt: wie die Bibliothek Präsentationen verarbeitet, was sie zu den Abhängigkeiten Ihres Projekts hinzufügt, wie Sie überprüfen können, dass die JAR-Datei von Aspose stammt, und welche Drittanbieter‑Komponenten die JAR‑Datei enthält.

## **Sicherheit in Aspose.Slides**

* Aspose.Slides für Java wird verwendet, um Präsentationen zu erstellen, zu ändern und zu konvertieren. Es führt keine Skripte in Präsentationen aus. Aspose.Slides analysiert die Präsentationsstruktur und ermöglicht Ihrem Code die Arbeit mit dem Objektmodell.
* Aspose.Slides funktioniert als Bibliothek, die Dokumente analysiert und interpretiert, ohne entfernten Code auszuführen. Alle Aspose‑Produkte laufen auf Ihren Rechnern. Sie übertragen keine Daten an Aspose. Die einzige Ausnahme ist [metered licensing](/slides/de/java/metered-licensing/): Wenn Sie diese verwenden, werden nur Ihre API‑Nutzungsinformationen verarbeitet.
* Aspose‑Komponenten laufen im selben Benutzerkontext wie reguläre Anwendungen. Daher stellen Aspose‑Komponenten keine Gefahr für wichtige Systemressourcen dar. Außerdem werden beim Öffnen eines Dokuments durch eine Aspose‑Komponente Makros nicht automatisch ausgeführt.

## **Maven-Abhängigkeiten**

Das Maven‑Artefakt von Aspose.Slides für Java, `com.aspose:aspose-slides`, deklariert keine Abhängigkeiten: seine POM‑Datei enthält nur die eigenen Koordinaten des Artefakts. Wenn Sie es zu einem Projekt hinzufügen, fügt Maven nur diese eine JAR‑Datei hinzu und nichts weiter. Um jedes Artefakt aufzulisten, das Ihr Projekt auflöst, einschließlich transitiver Abhängigkeiten, führen Sie diesen Befehl im Projektordner aus:

```bash
mvn dependency:tree
```

Im Projekt aus [Installation](/slides/de/java/installation/) listet die Ausgabe Aspose.Slides als einzige Abhängigkeit auf:

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **JAR‑Datei überprüfen**

Aspose signiert die JAR‑Datei. Um die Signatur zu überprüfen, führen Sie das `jarsigner`‑Tool aus dem JDK im Ordner aus, der die JAR‑Datei enthält:

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

Der Befehl gibt `jar verified.` aus, wenn die Signatur gültig ist und kein Eintrag seit der Signierung geändert wurde. Diese Meldung nennt nicht den Unterzeichner. Um zu bestätigen, dass Aspose die Datei signiert hat, fügen Sie die Optionen `-verbose` und `-certs` hinzu und prüfen Sie, dass das Zertifikat des Unterzeichners an `CN=ASPOSE PTY LTD` ausgestellt ist. Beim Herunterladen der JAR‑Datei prüft Maven außerdem die SHA‑1‑Prüfsumme, die das Repository neben der Datei veröffentlicht.

## **Drittanbieter‑Komponenten**

Aspose.Slides für Java enthält Code und Daten von Drittanbieter‑Komponenten. Sie sind Teil der JAR‑Datei und nicht separate Maven‑Artefakte, sodass `mvn dependency:tree` und andere Werkzeuge, die Maven‑Abhängigkeiten auslesen, sie nicht auflisten. Die JAR‑Datei enthält den Hinweis *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, der die Komponenten und deren Lizenzen auflistet:

| Komponente | Lizenz im Hinweis |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT‑Lizenz |
| Mono | MIT‑Lizenz; einige Teile unter anderen Lizenzen, die im Hinweis aufgeführt sind |
| RSWOP.ICM color profile | Microsoft‑Lizenzbedingungen |
| sRGB_v4_ICC_preference.icc color profile | ICC‑Erlaubnis zur Nutzung, Kopie und Weiterverbreitung der unveränderten Datei |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Um den Hinweis aus der JAR‑Datei zu extrahieren, führen Sie das `jar`‑Tool aus dem JDK im Ordner aus, der die JAR‑Datei enthält:

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Verwendet Aspose.Slides für Java externe Pakete?**

Es hat keine Maven‑Abhängigkeiten, wie [Maven Dependencies](#maven-dependencies) zeigt, aber es enthält die in [Third-Party Components](#third-party-components) aufgeführten Drittanbieter‑Komponenten. Berücksichtigen Sie sowohl die JAR‑Datei als auch diese Komponenten in Ihrer Sicherheitsüberprüfung.

**Benötigt Aspose.Slides für Java Netzwerkzugriff?**

Nein. Das Erstellen, Speichern und Rendern von Präsentationen funktioniert auf einem System ohne Netzwerkverbindung. Die einzige Funktion, die Daten an Aspose sendet, ist [metered licensing](/slides/de/java/metered-licensing/), die die API‑Nutzung meldet.

**Enthält Aspose.Slides für Java nativen Code?**

Nein. Die JAR‑Datei enthält nur Java‑Klassen und Ressourcen, sodass keine nativen Bibliotheken zu Ihrer Anwendung hinzugefügt werden. Unter Linux benötigt die Schriftunterstützung der Java‑Laufzeit die fontconfig‑Bibliothek und Schriften des Betriebssystems; siehe [System Requirements](/slides/de/java/system-requirements/#linux).