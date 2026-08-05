---
title: 3D-Diagramme in Präsentationen mit C++ anpassen
linktitle: 3D-Diagramm
type: docs
url: /de/cpp/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie 3D-Diagramme in Aspose.Slides für C++ erstellen und anpassen, mit Unterstützung für PPT- und PPTX-Dateien - verbessern Sie noch heute Ihre Präsentationen."
---
## **Overview**

Dieser Artikel erklärt, wie man ein 3D‑Diagramm in Aspose.Slides anpasst, indem man die `Rotation3D`‑Einstellungen wie `RotationX`, `RotationY`, `DepthPercents` und `RightAngleAxes` konfiguriert. Er führt durch das Erstellen einer Präsentation, das Hinzufügen eines 3D‑Diagramms mit Standarddaten, das Anwenden der erforderlichen 3D‑Ansichtseinstellungen und das Speichern der modifizierten Präsentation als PPTX‑Datei.

## **RotationX-, RotationY- und DepthPercents‑Eigenschaften eines 3D‑Diagramms festlegen**

Aspose.Slides für C++ bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel hilft Ihnen dabei, verschiedene Eigenschaften wie X‑, Y‑Rotation, **DepthPercents** usw. zu setzen. Der Beispielcode wendet die genannten Eigenschaften an.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D‑Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, einschließlich Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Aufzählung [ChartType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getimage/) in ein Bild exportieren oder die gesamte Folie über [render the entire slide](/slides/de/cpp/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Das ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse halten Sie 3D‑Effekte minimal, vermeiden schwere Texturen an Wänden und Plot‑Bereichen, begrenzen nach Möglichkeit die Anzahl der Datenpunkte pro Serie und rendern Sie in eine angemessen dimensionierte Ausgabe (Auflösung und Abmessungen), die den Anforderungen des Zielgeräts oder Drucks entspricht.