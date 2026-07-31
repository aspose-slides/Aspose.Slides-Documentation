---
title: Verwalten von Fallback‑Schriften für Präsentationen in C++
linktitle: Fallback‑Schrift
type: docs
weight: 50
url: /de/cpp/fallback-font/
keywords:
- Fallback‑Schrift
- verfügbare Schrift
- Glyph‑Ersetzung
- Schrift angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für C++ Fallback‑Schriften verwendet, um Text in PowerPoint‑ und OpenDocument‑Präsentationen lesbar zu halten, wenn die ursprünglichen Schriften nicht verfügbar sind."
---
## **Einführung**

Fallback‑Schriften werden verwendet, wenn die für den Text angegebene Schrift im System vorhanden ist, aber das erforderliche Glyph nicht enthält. In diesem Fall kann Aspose.Slides eine der angegebenen Fallback‑Schriften nutzen, um das fehlende Glyph zu ersetzen.

## **Fallback‑Schrift**
Eine Fallback‑Schrift wird verwendet, wenn die für den Text angegebene Schrift im System vorhanden ist, diese Schrift jedoch das notwendige Glyph nicht enthält. In diesem Fall kann man eine der angegebenen Fallback‑Schriften für den Glyph‑Ersatz verwenden.

Aspose.Slides ermöglicht das Erstellen von Fallback‑Schriften, das Hinzufügen zu einer Fallback‑Schriftensammlung, das Festlegen einer Fallback‑Schriftensammlung für eine bestimmte Präsentation, das Entfernen von Fallback‑Schriften aus einer Präsentation, das Festlegen von Regeln zur Anwendung von Fallback‑Schriften und weitere.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:
- [Fallback‑Schrift erstellen](/slides/de/cpp/create-fallback-font)
- [Fallback‑Schriftensammlung erstellen](/slides/de/cpp/create-fallback-fonts-collection)
- [Präsentation mit Fallback‑Schrift rendern](/slides/de/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback‑Schriften von Schriftartenersatz?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schrift bestimmte Glyphs nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/cpp/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schrift für einen gesamten Lauf oder Textabschnitt durch eine andere Schrift. Sie können kombiniert werden, aber ihr Anwendungsumfang und die Auswahllogik sind unterschiedlich.

**Werden Fallback‑Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX‑Datei serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Wirkt sich Fallback auf von PowerPoint‑Objekten erstellte Elemente aus (SmartArt, Diagramme, WordArt)?**

Ja. Der Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln darauf wie auf normalen Text angewendet werden.