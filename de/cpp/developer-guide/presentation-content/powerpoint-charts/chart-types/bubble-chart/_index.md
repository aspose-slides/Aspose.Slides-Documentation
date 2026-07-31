---
title: Bubble-Diagramme in Präsentationen mit C++ anpassen
linktitle: Bubble-Diagramm
type: docs
url: /de/cpp/bubble-chart/
keywords:
- Bubble-Diagramm
- Bubble-Größe
- Größenskalierung
- Größenrepräsentation
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erstellen und passen Sie leistungsstarke Bubble-Diagramme in PowerPoint mit Aspose.Slides für C++ an, um Ihre Datenvisualisierung einfach zu verbessern."
---
## **Übersicht**

Dieser Artikel zeigt, wie man mit Bubble‑Diagrammen in Aspose.Slides arbeitet. Er behandelt zwei spezifische Anpassungsoptionen: die Skalierung der Bubble‑Größen über die Methode `set_BubbleSizeScale` und die Steuerung, wie Bubble‑Größenwerte über die Methode `set_BubbleSizeRepresentation` dargestellt werden.

Die Beispiele demonstrieren, wie man ein Bubble‑Diagramm erstellt, die Größenskalierung anpasst und die Darstellung der Bubble‑Größe auf Breite umstellt. Der Artikel enthält außerdem einen kurzen FAQ‑Abschnitt, der die Unterstützung des Diagrammtyps „Bubble mit 3‑D“ erläutert, darauf hinweist, dass praktische Diagramm‑Grenzwerte von der Leistung und der Ziel‑PowerPoint‑Version abhängen, und erklärt, dass beim Export das Aussehen des Diagramms durch die Rendering‑Engine von Aspose.Slides erhalten bleibt.

## **Skalierung der Bubble‑Chart‑Größe**
Aspose.Slides für C++ unterstützt die Skalierung der Größe von Bubble‑Diagrammen. In Aspose.Slides für **C++ IChartSeries.BubbleSizeScale** und **IChartSeriesGroup.BubbleSizeScale** wurden Eigenschaften hinzugefügt. Im Folgenden ein Beispiel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Daten als Bubble‑Chart‑Größen darstellen**
Die neue Methode **get_BubbleSizeRepresentation()** wurde zu den Klassen **IChartSeries** und **ChartSeries** hinzugefügt. **BubbleSizeRepresentation** gibt an, wie die Bubble‑Größenwerte im Bubble‑Diagramm dargestellt werden. Mögliche Werte sind: **BubbleSizeRepresentationType.Area** und **BubbleSizeRepresentationType.Width**. Entsprechend wurde das Aufzählungselement **BubbleSizeRepresentationType** hinzugefügt, um die möglichen Arten der Darstellung von Daten als Bubble‑Chart‑Größen zu spezifizieren. Nachfolgend wird Beispielcode gezeigt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **FAQ**

**Wird ein „Bubble‑Diagramm mit 3‑D‑Effekt“ unterstützt und wie unterscheidet es sich von einem normalen Diagramm?**

Ja. Es gibt einen separaten Diagrammtyp „Bubble mit 3‑D“. Er wendet 3‑D‑Styling auf die Bubbles an, fügt jedoch keine zusätzliche Achse hinzu; die Daten bleiben X‑Y‑S (Größe). Der Typ ist in der Aufzählung [chart type](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/charttype/) verfügbar.

**Gibt es ein Limit für die Anzahl von Serien und Punkten in einem Bubble‑Diagramm?**

Es gibt auf API‑Ebene kein festes Limit; die Beschränkungen werden durch die Leistung und die Ziel‑PowerPoint‑Version bestimmt. Es wird empfohlen, die Anzahl der Punkte für Lesbarkeit und Rendering‑Geschwindigkeit auf einem vernünftigen Wert zu halten.

**Wie wirkt sich der Export auf das Aussehen eines Bubble‑Diagramms (PDF, Bilder) aus?**

Der Export in unterstützte Formate bewahrt das Aussehen des Diagramms; das Rendering erfolgt durch die Aspose.Slides‑Engine. Für Raster‑/Vektor‑Formate gelten allgemeine Regeln für das Rendern von Diagrammgrafiken (Auflösung, Anti‑Aliasing), daher sollte ein ausreichender DPI‑Wert für den Druck gewählt werden.