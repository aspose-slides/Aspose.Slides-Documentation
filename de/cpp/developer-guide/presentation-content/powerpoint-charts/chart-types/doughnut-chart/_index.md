---
title: Anpassen von Donut-Diagrammen in Präsentationen mit C++
linktitle: Donut-Diagramm
type: docs
weight: 30
url: /de/cpp/doughnut-chart/
keywords:
- Donut-Diagramm
- Mittelpunktlücke
- Lochgröße
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Donut-Diagramme in Aspose.Slides für C++ erstellen und anpassen und dabei PowerPoint-Formate für dynamische Präsentationen unterstützen."
---

## **Geben Sie die Lücke in der Mitte eines Donut‑Diagramms an**
Um die Größe der Lücke in einem Donut‑Diagramm festzulegen, folgen Sie bitte den nachstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Fügen Sie der Folie ein Donut‑Diagramm hinzu.
- Geben Sie die Größe der Lücke im Donut‑Diagramm an.
- Speichern Sie die Präsentation auf dem Datenträger.

Im untenstehenden Beispiel haben wir die Größe der Lücke im Donut‑Diagramm festgelegt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Kann ich ein mehrstufiges Donut mit mehreren Ringen erstellen?**

Ja. Fügen Sie einem einzelnen Donut‑Diagramm mehrere Serien hinzu – jede Serie wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Serien in der Sammlung bestimmt.

**Wird ein „explodiertes“ Donut (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Diagrammtyp [Exploded Doughnut](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Donut‑Diagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist eine Form; Sie können es in ein [Rasterbild](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) rendern oder das Diagramm in ein [SVG‑Bild](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) exportieren.