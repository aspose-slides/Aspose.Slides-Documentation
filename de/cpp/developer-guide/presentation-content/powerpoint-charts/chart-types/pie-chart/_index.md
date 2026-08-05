---
title: Kreisdiagramme in Präsentationen mit C++ anpassen
linktitle: Kreisdiagramm
type: docs
url: /de/cpp/pie-chart/
keywords:
- Kreisdiagramm
- Diagramm verwalten
- Diagramm anpassen
- Diagrammoptionen
- Diagrammeinstellungen
- Plot-Optionen
- Segmentfarbe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides in C++ Kreisdiagramme erstellen und anpassen, exportierbar nach PowerPoint, und so Ihre Datenpräsentation in Sekunden verbessern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Kreisdiagrammen in Aspose.Slides arbeitet. Er zeigt, wie man sekundäre Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme konfiguriert und wie man automatische Segmentfärbung für ein Standard‑Kreisdiagramm aktiviert.

Die Beispiele konzentrieren sich auf praktische Schritte zur Diagrammanpassung, wie das Hinzufügen eines Diagramms zu einer Folie, das Anpassen von Serien‑ und Beschriftungseinstellungen, das Ersetzen von Standarddiagrammdaten durch benutzerdefinierte Kategorien und Werte sowie das Speichern der aktualisierten Präsentation.

## **Zweite Plot‑Optionen für Pie of Pie‑ und Bar of Pie‑Diagramme**
Aspose.Slides für C++ unterstützt jetzt Optionen für das zweite Plot für Pie of Pie‑ oder Bar of Pie‑Diagramme. In diesem Abschnitt zeigen wir anhand eines Beispiels, wie diese Optionen mit Aspose.Slides festgelegt werden. Um die Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)-Klassenobjekt.
1. Fügen Sie ein Diagramm zur Folie hinzu.
1. Geben Sie die Optionen für das zweite Plot des Diagramms an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im unten angegebenen Beispiel haben wir verschiedene Eigenschaften des Pie of Pie‑Diagramms festgelegt.

{{< gist "aspose‑slides" "a690df625dc0b1fff869ab198affe7a4" "Examples‑SlidesCPP‑SecondPlotOptionsforCharts‑SecondPlotOptionsforCharts.cpp" >}}

## **Automatische Farben für Kreisdiagrammsegmente festlegen**
Aspose.Slides für C++ bietet eine einfache API zum Festlegen automatischer Farben für Kreisdiagrammsegmente. Der Beispielcode wendet die oben genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der Presentation‑Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie den Diagrammtitel.
1. Setzen Sie die erste Serie auf Show Values.
1. Legen Sie den Index des Diagrammdatenblatts fest.
1. Rufen Sie das Diagrammdaten‑Arbeitsblatt ab.
1. Löschen Sie die standardmäßig generierten Serien und Kategorien.
1. Fügen Sie neue Kategorien hinzu.
1. Fügen Sie neue Serien hinzu.

Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose‑slides" "a690df625dc0b1fff869ab198affe7a4" "Examples‑SlidesCPP‑SettingAutomicPieChartSliceColors‑SettingAutomicPieChartSliceColors.cpp" >}}

## **FAQ**

**Werden die Varianten 'Pie of Pie' und 'Bar of Pie' unterstützt?**

Ja, die Bibliothek [unterstützt](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/charttype/) ein sekundäres Plot für Kreisdiagramme, einschließlich der Typen 'Pie of Pie' und 'Bar of Pie'.

**Kann ich das Diagramm allein als Bild (z. B. PNG) exportieren?**

Ja, Sie können das Diagramm selbst als Bild [exportieren](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getimage/) (z. B. PNG), ohne die gesamte Präsentation.