---
title: Anpassen von 3D-Diagrammen in Präsentationen mit C++
linktitle: 3D Diagramm
type: docs
url: /de/cpp/3d-chart/
keywords:
- 3D Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie 3-D-Diagramme in Aspose.Slides für C++ erstellen und anpassen, mit Unterstützung für PPT- und PPTX-Dateien – verbessern Sie noch heute Ihre Präsentationen."
---

## **RotationX, RotationY und DepthPercents Eigenschaften eines 3D-Diagramms festlegen**
Aspose.Slides for C++ bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel zeigt, wie verschiedene Eigenschaften wie X‑, Y‑Rotation und **DepthPercents** usw. festgelegt werden können. Der Beispielcode demonstriert das Einstellen der genannten Eigenschaften.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D‑Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, darunter Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)‑Aufzählung verfügbar sind. Für eine genaue, aktuelle Liste prüfen Sie die [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/)-Mitglieder in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) in ein Bild exportieren oder die gesamte Folie [render the entire slide](/slides/de/cpp/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Dies ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie leistungsfähig ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse sollten Sie 3D‑Effekte minimal halten, schwere Texturen an Wänden und Plot‑Bereichen vermeiden, die Anzahl der Datenpunkte pro Serie nach Möglichkeit reduzieren und in einer angemessenen Ausgabegröße (Auflösung und Abmessungen) rendern, die den Zielanzeige‑ oder Druckanforderungen entspricht.