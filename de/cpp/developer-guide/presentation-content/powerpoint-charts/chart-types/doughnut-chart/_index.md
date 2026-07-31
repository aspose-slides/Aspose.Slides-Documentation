---
title: Anpassen von Donut-Diagrammen in Präsentationen mit C++
linktitle: Donut-Diagramm
type: docs
weight: 30
url: /de/cpp/doughnut-chart/
keywords:
- Donut-Diagramm
- Mittelabstand
- Lochgröße
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donut-Diagramme in Aspose.Slides für C++ erstellen und anpassen, um PowerPoint-Formate für dynamische Präsentationen zu unterstützen."
---
## **Übersicht**

Dieser Artikel zeigt, wie man in Aspose.Slides mit einem Donut‑Diagramm arbeitet, indem das Diagramm zu einer Folie hinzugefügt, die Größe des Mittellochs festgelegt und die Präsentation gespeichert wird. Er konzentriert sich auf die Methode `set_DoughnutHoleSize` und demonstriert die grundlegenden Schritte, die erforderlich sind, um diesen Diagrammtyp im Code anzupassen.

## **Geben Sie die Lücke in der Mitte eines Donut‑Diagramms an**

Um die Größe des Lochs in einem Donut‑Diagramm festzulegen, befolgen Sie bitte die folgenden Schritte:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) .
- Fügen Sie ein Donut‑Diagramm zur Folie hinzu.
- Geben Sie die Größe des Lochs im Donut‑Diagramm an.
- Speichern Sie die Präsentation auf dem Datenträger.

Im nachstehenden Beispiel haben wir die Größe des Lochs im Donut‑Diagramm festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Kann ich ein mehrstufiges Donut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzelnen Donut‑Diagramm mehrere Reihen hinzu – jede Reihe wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Reihen in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [chart type](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut‑Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [Raster‑Bild](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/getimage/) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/writeassvg/) exportieren.