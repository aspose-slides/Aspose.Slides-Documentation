---
title: Fallback-Schriftart - PowerPoint JavaScript API
linktitle: Fallback-Schriftart
type: docs
weight: 50
url: /de/nodejs-java/fallback-font/
description: Fallback-Schriftart wird verwendet, wenn die für den Text angegebene Schriftart im System verfügbar ist, diese Schriftart jedoch nicht das erforderliche Glyph enthält. In diesem Fall kann die PowerPoint Java API eine der angegebenen Fallback-Schriftarten für den Glyphenaustausch verwenden.
---

## **Fallback-Schriftart**
Eine Fallback-Schriftart wird verwendet, wenn die für den Text angegebene Schriftart im System verfügbar ist, diese Schriftart jedoch das erforderliche Glyph enthält. In diesem Fall kann eine der angegebenen Fallback-Schriftarten zum Ersetzen des Glyphs verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Schriftarten, das Hinzufügen zu einer Fallback-Schriftartsammlung, das Festlegen einer Fallback-Schriftartsammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Schriftarten aus der Präsentation, das Angeben von Regeln zur Anwendung von Fallback-Schriftarten und weitere Funktionen.

Um sich mit diesen Funktionen vertraut zu machen, nutzen Sie die folgenden Links:

- [Create Fallback Font](/slides/de/nodejs-java/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/de/nodejs-java/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/de/nodejs-java/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Schriftarten von der Schriftart-Substitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphen nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/nodejs-java/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, aber ihr Geltungsbereich und die Auswahllogik sind unterschiedlich.

**Werden Fallback-Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Beeinflusst Fallback Elemente, die von PowerPoint‑Objekten (SmartArt, Diagramme, WordArt) erstellt wurden?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln darauf wie auf normalen Text angewendet werden.