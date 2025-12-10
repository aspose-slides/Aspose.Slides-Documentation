---
title: Verwalten von Fallback-Schriftarten für Präsentationen in Java
linktitle: Fallback-Schriftart
type: docs
weight: 50
url: /de/java/fallback-font/
keywords:
- Fallback-Schriftart
- verfügbare Schriftart
- Glyphen-Ersetzung
- Schriftart angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Java Fallback-Schriftarten verwendet, um Text in PowerPoint- und OpenDocument-Präsentationen lesbar zu halten, wenn die ursprünglichen Schriftarten nicht verfügbar sind."
---

## **Fallback-Schriftart**
Fallback-Schriftart wird verwendet, wenn die für den Text angegebene Schriftart im System verfügbar ist, diese Schriftart jedoch kein erforderliches Glyph hat. In diesem Fall kann einer der angegebenen Fallback-Schriftarten für den Glyph‑Ersatz verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Schriftarten, das Hinzufügen zu einer Fallback-Schriftartensammlung, das Festlegen einer Fallback-Schriftartensammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Schriftarten aus der Präsentation, das Angeben von Regeln zur Anwendung von Fallback-Schriftarten und weitere.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Fallback-Schriftart erstellen](/slides/de/java/create-fallback-font)
- [Fallback-Schriftartensammlung erstellen](/slides/de/java/create-fallback-fonts-collection)
- [Präsentation mit Fallback-Schriftart rendern](/slides/de/java/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Schriftarten von der Schriftart-Substitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphen nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/java/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, aber ihr Anwendungsbereich und ihre Auswahllogik unterscheiden sich.

**Werden Fallback-Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback-Konfiguration existiert zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Beeinflusst Fallback Elemente, die von PowerPoint‑Objekten (SmartArt, Diagrammen, WordArt) erstellt wurden?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln darauf wie auf normalen Text angewendet werden.