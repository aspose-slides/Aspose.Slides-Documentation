---
title: Bubble-Diagramme in Präsentationen mit С++ anpassen
linktitle: Bubble-Diagramm
type: docs
url: /de/cpp/bubble-chart/
keywords:
- Bubble-Diagramm
- Bubble-Größe
- Größenskala
- Größenrepräsentation
- PowerPoint
- Präsentation
- С++
- Aspose.Slides
description: "Erstellen und passen Sie leistungsstarke Bubble-Diagramme in PowerPoint mit Aspose.Slides für С++ an, um Ihre Datenvisualisierung einfach zu verbessern."
---

## **Skalierung der Bubble-Diagrammgröße**
Aspose.Slides für C++ bietet Unterstützung für die Skalierung von Bubble-Diagrammgrößen. In Aspose.Slides für **C++ IChartSeries.BubbleSizeScale** und **IChartSeriesGroup.BubbleSizeScale** Eigenschaften wurden hinzugefügt. Unten ist ein Beispiel angegeben. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Daten als Bubble-Diagrammgrößen darstellen**
Neue **get_BubbleSizeRepresentation()**‑Methode wurde zu den Klassen **IChartSeries** und **ChartSeries** hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Diagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.Area** und **BubbleSizeRepresentationType.Width**. Entsprechend wurde das **BubbleSizeRepresentationType**‑Enum hinzugefügt, um die möglichen Methoden zur Darstellung von Daten als Bubble‑Diagrammgrößen zu definieren. Beispielcode ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Wird ein "Bubble‑Diagramm mit 3‑D‑Effekt" unterstützt und wie unterscheidet es sich von einem normalen Diagramm?**

Ja. Es gibt einen eigenen Diagrammtyp, „Bubble mit 3‑D“. Er wendet 3‑D‑Stil auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Aufzählung [chart type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) verfügbar.

**Gibt es eine Begrenzung für die Anzahl von Serien und Punkten in einem Bubble‑Diagramm?**

Auf API‑Ebene gibt es keine feste Obergrenze; Einschränkungen ergeben sich aus der Leistung und der Ziel‑PowerPoint‑Version. Es wird empfohlen, die Punktzahl für Lesbarkeit und Rendering‑Geschwindigkeit angemessen zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Diagramms aus (PDF, Bilder)?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten die allgemeinen Rendering‑Regeln für Diagrammgrafiken (Auflösung, Antialiasing), wählen Sie daher für den Druck eine ausreichende DPI.