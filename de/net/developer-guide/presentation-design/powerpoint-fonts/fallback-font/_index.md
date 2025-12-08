---
title: Fallback-Schrift - PowerPoint C# API
linktitle: Fallback-Schrift
type: docs
weight: 50
url: /de/net/fallback-font/
keywords: "Fallback-Schrift, Schrift, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Wenn die Schrift nicht das erforderliche Glyph enthält, ermöglicht die PowerPoint C# API die Verwendung einer der angegebenen Fallback-Schriften für den Glyph-Ersatz."
---

## **Fallback-Schrift**
Eine Fallback-Schrift wird verwendet, wenn die für den Text angegebene Schrift im System vorhanden ist, diese Schrift jedoch nicht das erforderliche Glyph enthält. In diesem Fall kann eine der angegebenen Fallback-Schriften für den Glyph‑Austausch verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Schriften, das Hinzufügen zu einer Fallback-Schriftensammlung, das Festlegen einer Fallback-Schriftensammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Schriften aus einer Präsentation, das Angeben von Regeln zur Anwendung von Fallback-Schriften und Weitere.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Fallback-Schrift erstellen](/slides/de/net/create-fallback-font)
- [Fallback-Schriftensammlung erstellen](/slides/de/net/create-fallback-fonts-collection)
- [Präsentation mit Fallback-Schrift rendern](/slides/de/net/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Schriften von der Schriftart-Substitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schrift bestimmte Glyphen nicht enthält; sie füllt nur die fehlenden Zeichen. [Substitution](/slides/de/net/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schrift für einen gesamten Lauf oder Textabschnitt durch eine andere Schrift. Sie können kombiniert werden, jedoch unterscheiden sich ihr Umfang und die Auswahllogik.

**Werden Fallback-Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback-Konfiguration existiert zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Beeinflusst Fallback Elemente, die von PowerPoint‑Objekten (SmartArt, Diagrammen, WordArt) erstellt wurden?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln auf ihn wie auf normalen Text angewendet werden.