---
title: Diagrammlegenden in Präsentationen mit C++ anpassen
linktitle: Diagrammlegende
type: docs
url: /de/cpp/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Diagrammlegenden mit Aspose.Slides für C++ anpassen, um PowerPoint‑Präsentationen durch individuell formatierte Legenden zu optimieren."
---
## **Übersicht**

Aspose.Slides bietet Optionen zum Anpassen von Diagrammlegenden in PowerPoint‑Präsentationen. Dieser Artikel zeigt, wie man die Position und Größe einer Legende festlegt, die Schriftgröße für die gesamte Legende einstellt und das Format für einen einzelnen Legendeintrag anwendet.

Er behandelt zudem mehrere zugehörige Verhaltensweisen im FAQ, darunter die Verwendung des Nicht‑Overlay‑Modus, damit der Zeichenbereich Platz für die Legende schafft, das Umbrechen langer Legendenbeschriftungen oder die Nutzung von Zeilenumbrüchen, sowie das Erben der Legendenformatierung aus dem Präsentationsthema, wenn keine expliziten Text‑ und Füllungseinstellungen vorgenommen werden.

## **Legendenpositionierung**
Um die Legenden‑Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
- Holen Sie die Referenz der Folie.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im unten gezeigten Beispiel haben wir die Position und Größe der Diagrammlegende festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **Schriftgröße einer Legende festlegen**
Aspose.Slides für C++ ermöglicht es Entwicklern, die Schriftgröße der Legende festzulegen. Bitte folgen Sie den untenstehenden Schritten: 

- Instanziieren Sie die Presentation Klasse.
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **Schriftgröße eines einzelnen Legendeeintrags festlegen**
Aspose.Slides für C++ ermöglicht es Entwicklern, die Schriftgröße einzelner Legendeeinträge festzulegen. Bitte folgen Sie den untenstehenden Schritten: 

- Instanziieren Sie die Presentation Klasse.
- Erstellen Sie das Standarddiagramm.
- Greifen Sie auf den Legendeeintrag zu.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Kann ich die Legende so aktivieren, dass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([set_Overlay(false)](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/legend/set_overlay/)); in diesem Fall schrumpft der Zeichenbereich, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen werden automatisch umbrochen, wenn nicht genügend Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruchszeichen im Seriennamen unterstützt.

**Wie lässt sich die Legende an das Farbschema des Präsentationsthemas anpassen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie erben dann das Design des Themas und werden bei Designänderungen korrekt aktualisiert.