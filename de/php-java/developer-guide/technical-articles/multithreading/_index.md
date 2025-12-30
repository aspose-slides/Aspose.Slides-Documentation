---
title: Multithreading in Aspose.Slides für PHP via Java
linktitle: Multithreading
type: docs
weight: 310
url: /de/php-java/multithreading/
keywords:
- Multithreading
- mehrere Threads
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Aspose.Slides für PHP via Java Multithreading beschleunigt die Verarbeitung von PowerPoint und OpenDocument. Entdecken Sie bewährte Methoden für effiziente Präsentations-Workflows."
---

## **Einleitung**

Während parallele Arbeit mit Präsentationen möglich ist (außer beim Parsen/Laden/Klonen) und die meisten Male alles gut läuft, besteht eine kleine Chance, dass Sie beim Einsatz der Bibliothek in mehreren Threads falsche Ergebnisse erhalten.

Wir empfehlen dringend, dass Sie **nicht** eine einzelne [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Instanz in einer Multi‑Thread‑Umgebung verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Derartige Vorgänge werden **nicht** unterstützt.  Wenn Sie solche Aufgaben ausführen müssen, müssen Sie die Vorgänge parallelisieren, indem Sie mehrere Single‑Thread‑Prozesse verwenden – und jeder dieser Prozesse sollte seine eigene Präsentations‑Instanz nutzen.

Wir garantieren kein Multithreading in PHP bei der Verwendung von Erweiterungen. Wenn Sie diese nutzen, tun Sie dies auf eigenes Risiko.

## **FAQ**

**Muss ich die Lizenzkonfiguration in jedem Thread aufrufen?**

Nein. Es reicht, dies einmal pro Prozess/App‑Domain vor dem Start der Threads durchzuführen. Falls die [license setup](/slides/de/php-java/licensing/)-Methode gleichzeitig aufgerufen werden könnte (z. B. während einer Lazy‑Initialisierung), sollten Sie diesen Aufruf synchronisieren, da die Lizenzkonfigurations‑Methode selbst nicht thread‑sicher ist.

**Kann ich `Presentation`‑ oder `Slide`‑Objekte zwischen Threads übergeben?**

Das Übergeben von „Live“‑Präsentationsobjekten zwischen Threads wird nicht empfohlen: Verwenden Sie unabhängige Instanzen pro Thread oder erstellen Sie im Voraus separate Präsentationen/Slide‑Container für jeden Thread. Dieser Ansatz folgt der allgemeinen Empfehlung, keine einzelne Präsentations‑Instanz über mehrere Threads zu teilen.

**Ist das Parallelisieren des Exports in verschiedene Formate (PDF, HTML, Bilder) sicher, sofern jeder Thread seine eigene `Presentation`‑Instanz hat?**

Ja. Bei unabhängigen Instanzen und separaten Ausgabepfaden lassen sich solche Vorgänge in der Regel korrekt parallelisieren; vermeiden Sie gemeinsam genutzte Präsentationsobjekte und geteilte I/O‑Streams.

**Was sollte ich mit globalen Schriftarteinstellungen (Ordner, Ersatz) beim Multithreading tun?**

Initialisieren Sie alle globalen [font settings](/slides/de/php-java/powerpoint-fonts/) vor dem Start der Threads und ändern Sie sie während paralleler Vorgänge nicht. Das verhindert Rennbedingungen beim Zugriff auf gemeinsam genutzte Schriftressourcen.