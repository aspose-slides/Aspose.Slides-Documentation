---
title: Präsentationslokalisierung in C++ automatisieren
linktitle: Präsentationslokalisierung
type: docs
weight: 100
url: /de/cpp/presentation-localization/
keywords:
- Sprache ändern
- Rechtschreibprüfung
- Sprach-ID
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Automatisieren Sie die Lokalisierung von PowerPoint- und OpenDocument-Folien in C++ mit Aspose.Slides, indem Sie praktische Codebeispiele und Tipps für eine schnellere globale Einführung nutzen."
---

## **Sprache für eine Präsentation und Form‑Text ändern**
- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
- Holen Sie die Referenz einer Folie mithilfe ihres Index.
- Fügen Sie der Folie eine AutoShape vom Typ Rechteck hinzu.
- Fügen Sie dem TextFrame etwas Text hinzu.
- Setzen der Language Id für den Text.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Die Implementierung der oben genannten Schritte wird unten in einem Beispiel gezeigt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-TextBoxOnSlideProgram-TextBoxOnSlideProgram.cpp" >}}

## **FAQ**

**Löst die Language ID automatische Textübersetzung aus?**

Nein. Die [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) in Aspose.Slides speichert die Sprache für Rechtschreib‑ und Grammatikprüfung, übersetzt den Text jedoch nicht und ändert dessen Inhalt nicht. Es handelt sich um Metadaten, die PowerPoint für die Prüfung versteht.

**Beeinflusst die Language ID die Silbentrennung und Zeilenumbrüche beim Rendern?**

In Aspose.Slides ist die [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) für die Prüfung vorgesehen. Die Qualität der Silbentrennung und des Zeilenumbruchs hängt hauptsächlich von der Verfügbarkeit [geeigneter Schriftarten](/slides/de/cpp/powerpoint-fonts/) und den Layout‑/Zeilenumbruch‑Einstellungen für das jeweilige Schriftsystem ab. Um korrektes Rendern zu gewährleisten, stellen Sie die erforderlichen Schriftarten bereit, konfigurieren Sie [Schriftartersatzregeln](/slides/de/cpp/font-substitution/) und/oder betten Sie [Schriftarten einbetten](/slides/de/cpp/embedded-font/) in die Präsentation ein.

**Kann ich verschiedene Sprachen innerhalb eines einzelnen Absatzes festlegen?**

Ja. Die [Language ID](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) wird auf Ebene des Textabschnitts angewendet, sodass ein einzelner Absatz mehrere Sprachen mit unterschiedlichen Prüfungseinstellungen mischen kann.