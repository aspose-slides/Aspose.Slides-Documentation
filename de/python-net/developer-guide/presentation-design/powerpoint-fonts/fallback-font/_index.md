---
title: "Verwalten von Fallback-Schriften für Präsentationen in Python"
linktitle: "Fallback-Schrift"
type: docs
weight: 50
url: /de/python-net/fallback-font/
keywords:
- "Fallback-Schrift"
- "verfügbare Schrift"
- "Glyphen-Ersetzung"
- "Schrift angeben"
- "Regel angeben"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Erfahren Sie, wie Aspose.Slides für Python über .NET Fallback-Schriften verwendet, um Text in PowerPoint- und OpenDocument-Präsentationen lesbar zu halten, wenn die Originalschriften nicht verfügbar sind."
---

## **Fallback-Schrift**

Eine Fallback-Schrift wird verwendet, wenn die für den Text angegebene Schrift im System vorhanden ist, diese jedoch nicht das erforderliche Glyph enthält. In diesem Fall kann eine der angegebenen Fallback-Schriften für die Glyphen-Ersetzung verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Schriften, das Hinzufügen zu einer Fallback-Schriften‑Sammlung, das Festlegen einer Fallback‑Schriftensammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Schriften aus einer Präsentation, das Angeben von Regeln zur Anwendung von Fallback‑Schriften und weitere Funktionen.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Fallback-Schrift erstellen](/slides/de/python-net/create-fallback-font)
- [Fallback-Schriften‑Sammlung erstellen](/slides/de/python-net/create-fallback-fonts-collection)
- [Präsentation mit Fallback-Schrift rendern](/slides/de/python-net/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Schriften von der Schrift‑Substitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schrift bestimmte Glyphen nicht enthält; sie füllt nur die fehlenden Zeichen. [Substitution](/slides/de/python-net/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schrift für einen gesamten Lauf oder Textabschnitt durch eine andere Schrift. Sie können kombiniert werden, jedoch unterscheiden sich ihr Anwendungsbereich und ihre Auswahllogik.

**Werden Fallback‑Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Beeinflusst Fallback Elemente, die von PowerPoint‑Objekten (SmartArt, Diagramme, WordArt) erstellt wurden?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln wie für normalen Text gelten.