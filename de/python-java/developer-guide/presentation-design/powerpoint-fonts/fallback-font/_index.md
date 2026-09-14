---
title: Verwalten von Fallback‑Schriftarten für Präsentationen in Python über Java
linktitle: Fallback‑Schriftart
type: docs
weight: 50
url: /de/python-java/fallback-font/
keywords:
- Fallback‑Schriftart
- verfügbare Schriftart
- Glyph‑Ersetzung
- Schriftart angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Python über Java Fallback‑Schriftarten verwendet, um Text in PowerPoint‑ und OpenDocument‑Präsentationen lesbar zu halten, wenn die ursprünglichen Schriftarten nicht verfügbar sind."
---
## **Einleitung**

Fallback‑Schriftarten werden verwendet, wenn die für den Text angegebene Schriftart im System vorhanden ist, aber das erforderliche Glyph nicht enthält. In diesem Fall kann Aspose.Slides eine der angegebenen Fallback‑Schriftarten verwenden, um das fehlende Glyph zu ersetzen.

## **Fallback‑Schriftart**

Aspose.Slides ermöglicht das Erstellen von Fallback‑Schriftarten, das Hinzufügen zu einer Fallback‑Schriftartensammlung, das Festlegen der Fallback‑Schriftartensammlung für eine bestimmte Präsentation, das Entfernen von Fallback‑Schriftarten aus der Präsentation, das Festlegen der Regeln für die Anwendung von Fallback‑Schriftarten und weitere damit zusammenhängende Vorgänge.

Um sich mit diesen Funktionen vertraut zu machen, verwenden Sie die folgenden Links:

- [Fallback‑Schriftart erstellen](/slides/de/python-java/create-fallback-font/)
- [Fallback‑Schriftartensammlung erstellen](/slides/de/python-java/create-fallback-fonts-collection/)
- [Präsentation mit Fallback‑Schriftart rendern](/slides/de/python-java/render-presentation-with-fallback-font/)

## **FAQ**

**Wie unterscheiden sich Fallback‑Schriftarten von der Schriftartensubstitution?**

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphs nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/python-java/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, jedoch unterscheiden sich ihr Geltungsbereich und die Auswahllogik.

**Werden Fallback‑Einstellungen in der Präsentationsdatei gespeichert?**

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Beeinflusst Fallback Elemente, die von PowerPoint‑Objekten (SmartArt, Diagrammen, WordArt) erstellt wurden?**

Ja. Text in diesen Objekten durchläuft dieselbe Rendering‑Pipeline, sodass die gleichen Fallback‑Regeln wie bei normalem Text angewendet werden.