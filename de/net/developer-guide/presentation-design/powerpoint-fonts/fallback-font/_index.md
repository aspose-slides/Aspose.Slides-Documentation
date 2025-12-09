---
title: Verwalten von Fallback-Schriftarten für Präsentationen in .NET
linktitle: Fallback-Schriftart
type: docs
weight: 50
url: /de/net/fallback-font/
keywords:
- Fallback-Schriftart
- verfügbare Schriftart
- Glyph-Ersatz
- Schriftart angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für .NET Fallback-Schriftarten verwendet, um Text in PowerPoint- und OpenDocument-Präsentationen lesbar zu halten, wenn die ursprünglichen Schriftarten nicht verfügbar sind."
---

## **Fallback-Schriftart**
Eine Fallback-Schriftart wird verwendet, wenn die für den Text angegebene Schriftart im System vorhanden ist, diese aber kein erforderliches Glyph enthält. In diesem Fall kann eine der angegebenen Fallback-Schriftarten für den Glyph-Ersatz verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback-Schriftarten, das Hinzufügen zu einer Fallback-Schriftartensammlung, das Festlegen einer Fallback-Schriftartensammlung für eine bestimmte Präsentation, das Entfernen von Fallback-Schriftarten aus einer Präsentation, das Angeben von Regeln zum Anwenden von Fallback-Schriftarten und weitere Vorgänge.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Fallback-Schriftart erstellen](/slides/de/net/create-fallback-font)
- [Fallback-Schriftartensammlung erstellen](/slides/de/net/create-fallback-fonts-collection)
- [Präsentation mit Fallback-Schriftart rendern](/slides/de/net/render-presentation-with-fallback-font)

## **FAQ**

**Wie unterscheiden sich Fallback-Schriftarten von der Schriftartersetzung?**

Fallback wird pro Zeichen oder pro Unicode-Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphen nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/net/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, jedoch unterscheiden sich ihr Anwendungsbereich und die Auswahllogik.

**Werden Fallback-Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback-Konfiguration existiert zur Verarbeitungs-/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback-Regeln nicht.

**Wirkt sich Fallback auf Elemente aus PowerPoint-Objekten (SmartArt, Diagramme, WordArt) aus?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering-Pipeline, sodass dieselben Fallback-Regeln darauf wie auf normalen Text angewendet werden.