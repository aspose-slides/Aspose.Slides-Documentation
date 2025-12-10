---
title: "Anpassen von Diagrammlegenden in Präsentationen mit C++"
linktitle: "Diagrammlegende"
type: docs
url: /de/cpp/chart-legend/
keywords:
- "Diagrammlegende"
- "Legendenposition"
- "Schriftgröße"
- "PowerPoint"
- "Präsentation"
- "C++"
- "Aspose.Slides"
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für C++ an, um PowerPoint-Präsentationen mit individuell gestalteter Legendenformatierung zu optimieren."
---

## **Legendenpositionierung**
Um die Eigenschaften der Legende festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
- Holen Sie die Referenz der Folie.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir die Position und Größe der Diagrammlegende gesetzt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}


## **Schriftgröße einer Legende festlegen**
Aspose.Slides für C++ ermöglicht es Entwicklern, die Schriftgröße der Legende festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die Presentation‑Klasse.
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}




## **Schriftgröße einer einzelnen Legende festlegen**
Aspose.Slides für C++ ermöglicht es Entwicklern, die Schriftgröße einzelner Legenden‑Einträge festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die Presentation‑Klasse.
- Erstellen Sie das Standarddiagramm.
- Greifen Sie auf den Legenden‑Eintrag zu.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)); in diesem Fall wird der Zeichenbereich verkleinert, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legenden‑Beschriftungen erstellen?**

Ja. Lange Beschriftungen werden automatisch umgebrochen, wenn nicht genügend Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruch‑Zeichen im Seriennamen unterstützt.

**Wie bringe ich die Legende dazu, dem Farbschema des Präsentations‑Themas zu folgen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie erben dann vom Thema und passen sich bei einer Design‑Änderung automatisch an.