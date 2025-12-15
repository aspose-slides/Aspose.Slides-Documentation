---
title: Verwalten von Fallback-Schriftarten für Präsentationen auf Android
linktitle: Fallback-Schriftart
type: docs
weight: 50
url: /de/androidjava/fallback-font/
keywords:
- Fallback-Schriftart
- verfügbare Schriftart
- Glyphen-Ersetzung
- Schriftart angeben
- Regel angeben
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für Android via Java Fallback-Schriftarten verwendet, um Text in PowerPoint- und OpenDocument-Präsentationen lesbar zu halten, wenn die Originalschriftarten nicht verfügbar sind."
---

## **Fallback Font**
Fallback‑Schriftart wird verwendet, wenn die für den Text angegebene Schriftart im System verfügbar ist, diese Schriftart jedoch keinen benötigten Glyphen enthält. In diesem Fall kann eine der angegebenen Fallback‑Schriftarten zum Ersetzen des Glyphen verwendet werden.

Aspose.Slides ermöglicht das Erstellen von Fallback‑Schriftarten, das Hinzufügen zu einer Fallback‑Schriftartensammlung, das Festlegen einer Fallback‑Schriftartensammlung für eine bestimmte Präsentation, das Entfernen von Fallback‑Schriftarten aus einer Präsentation, das Definieren von Regeln zur Anwendung von Fallback‑Schriftarten und weitere Funktionen.

Um sich mit diesen Funktionen vertraut zu machen, nutzen Sie die folgenden Links:

- [Fallback‑Schriftart erstellen](/slides/de/androidjava/create-fallback-font)
- [Fallback‑Schriftartensammlung erstellen](/slides/de/androidjava/create-fallback-fonts-collection)
- [Präsentation mit Fallback‑Schriftart rendern](/slides/de/androidjava/render-presentation-with-fallback-font)

## **FAQ**

**How do fallback fonts differ from font substitution?**  
Wie unterscheiden sich Fallback‑Schriftarten von der Schriftarten‑Substitution?

Fallback wird pro Zeichen oder pro Unicode‑Bereich angewendet, wenn die primäre Schriftart bestimmte Glyphen nicht enthält; es füllt nur die fehlenden Zeichen. [Substitution](/slides/de/androidjava/font-substitution/) ersetzt eine fehlende oder nicht verfügbare Schriftart für einen gesamten Lauf oder Textabschnitt durch eine andere Schriftart. Sie können kombiniert werden, jedoch unterscheiden sich ihr Anwendungsbereich und die Auswahllogik.

**Are fallback settings saved inside the presentation file?**  
Werden Fallback‑Einstellungen in der Präsentationsdatei gespeichert?

Nein. Die Fallback‑Konfiguration existiert nur zur Verarbeitungs‑/Renderzeit in der Bibliothek und wird nicht in die PPTX serialisiert. Die Präsentation speichert Ihre Fallback‑Regeln nicht.

**Does fallback affect elements created by PowerPoint objects (SmartArt, charts, WordArt)?**  
Wirkt sich Fallback auf Elemente aus, die von PowerPoint‑Objekten erstellt wurden (SmartArt, Diagramme, WordArt)?

Ja. Der Text innerhalb dieser Objekte durchläuft die gleiche Rendering‑Pipeline, sodass dieselben Fallback‑Regeln wie bei normalem Text angewendet werden.