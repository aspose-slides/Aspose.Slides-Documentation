---
title: Multithreading in Aspose.Slides
type: docs
weight: 310
url: /php-java/multithreading/
keywords:
- PowerPoint
- Präsentation
- Multithreading
- parallele Arbeit
- Folien konvertieren
- Folien zu Bildern
- PHP
- Java
- Aspose.Slides für PHP über Java
---

## **Einführung**

Während parallele Arbeiten mit Präsentationen möglich sind (neben dem Parsen/Laden/Klonen) und alles gut läuft (größtenteils), gibt es eine kleine Chance, dass Sie bei der Verwendung der Bibliothek in mehreren Threads falsche Ergebnisse erhalten.

Wir empfehlen dringend, **keine** einzelne [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Instanz in einer Multi-Thread-Umgebung zu verwenden, da dies zu unvorhersehbaren Fehlern oder Ausfällen führen kann, die nicht leicht zu erkennen sind.

Es ist **nicht** sicher, eine Instanz einer [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klasse in mehreren Threads zu laden, zu speichern und/oder zu klonen. Solche Operationen werden **nicht** unterstützt. Wenn Sie solche Aufgaben durchführen müssen, müssen Sie die Operationen mithilfe mehrerer einzelner Thread-Prozesse parallelisieren – und jeder dieser Prozesse sollte seine eigene Präsentationsinstanz verwenden.

Wir garantieren kein Multithreading in PHP bei Verwendung von Erweiterungen. Wenn Sie diese verwenden, tun Sie dies auf eigenes Risiko.