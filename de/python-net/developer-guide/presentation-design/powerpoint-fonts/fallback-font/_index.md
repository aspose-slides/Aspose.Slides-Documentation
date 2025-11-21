---
title: Verwalten von Fallback-Schriftarten für Präsentationen in Python
linktitle: Fallback-Schriftart
type: docs
weight: 50
url: /de/python-net/fallback-font/
keywords:
- Fallback-Schriftart
- verfügbare Schriftart
- Glyphen-Ersetzung
- Schriftart angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python über .NET Fallback-Schriftarten verwendet, um Text in PowerPoint- und OpenDocument-Präsentationen lesbar zu halten, wenn die ursprünglichen Schriftarten nicht verfügbar sind."
---

## **Fallback-Schriftart**
Eine Fallback-Schriftart wird verwendet, wenn die für den Text angegebene Schriftart im System vorhanden ist, diese jedoch kein benötigtes Glyph enthält. In diesem Fall kann eines der angegebenen Fallback-Schriftarten zur Glyphen‑Ersetzung verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Schriftarten, das Hinzufügen zu einer Fallback-Schriftarten‑Sammlung, das Festlegen einer Fallback‑Schriftarten‑Sammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Schriftarten aus einer Präsentation, das Angeben von Regeln zur Anwendung von Fallback‑Schriftarten und weitere Vorgänge.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Create Fallback Font](/slides/de/python-net/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/de/python-net/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/de/python-net/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Schriftarten von der Schriftart-Substitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphen nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/python-net/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, aber ihr Geltungsbereich und die Auswahllogik unterscheiden sich.

**Werden Fallback‑Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Beeinflusst Fallback Elemente, die von PowerPoint‑Objekten (SmartArt, Diagrammen, WordArt) erstellt wurden?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass dieselben Fallback‑Regeln darauf wie auf normalen Text angewendet werden.