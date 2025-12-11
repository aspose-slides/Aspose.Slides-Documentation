---
title: Verwalten von Fallback-Schriftarten für Präsentationen in С++
linktitle: Fallback-Schriftart
type: docs
weight: 50
url: /de/cpp/fallback-font/
keywords:
- fallback-Schriftart
- verfügbare Schriftart
- Glyph-Ersetzung
- Schriftart angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- С++
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für С++ Fallback-Schriftarten verwendet, um Text in PowerPoint- und OpenDocument-Präsentationen lesbar zu halten, wenn die ursprünglichen Schriftarten nicht verfügbar sind."
---

## **Fallback-Font**
Der Fallback-Font wird verwendet, wenn die für den Text angegebene Schriftart im System verfügbar ist, diese Schriftart jedoch das erforderliche Glyph nicht enthält. In diesem Fall kann einer der angegebenen Fallback-Fonts für den Glyph-Ersatz verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Fonts, das Hinzufügen zu einer Fallback-Fonts‑Sammlung, das Festlegen einer Fallback-Font‑Sammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Fonts aus einer Präsentation, das Festlegen von Regeln zur Anwendung von Fallback-Fonts und weitere Funktionen.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Fallback-Font erstellen](/slides/de/cpp/create-fallback-font)
- [Fallback-Fonts‑Sammlung erstellen](/slides/de/cpp/create-fallback-fonts-collection)
- [Präsentation mit Fallback-Font rendern](/slides/de/cpp/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Fonts von der Schriftart-Substitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphs nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/cpp/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, aber ihr Anwendungsbereich und die Auswahllogik sind unterschiedlich.

**Werden Fallback‑Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX-Datei serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Wirkt sich Fallback auf Elemente aus, die von PowerPoint‑Objekten erstellt wurden (SmartArt, Diagramme, WordArt)?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln darauf wie auf normalen Text angewendet werden.