---
title: Trendlinien zu Präsentationsdiagrammen in C++ hinzufügen
linktitle: Trendlinie
type: docs
url: /de/cpp/trend-line/
keywords:
- Diagramm
- Trendlinie
- exponentielle Trendlinie
- lineare Trendlinie
- logarithmische Trendlinie
- gleitende Durchschnittstrendlinie
- polynomiale Trendlinie
- Potenztrendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien in PowerPoint-Diagrammen mit Aspose.Slides für C++ hinzu und passen Sie sie an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---

## **Trendlinie hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
4. Hinzufügen der exponentiellen Trendlinie für Diagrammreihe 1.
5. Hinzufügen einer linearen Trendlinie für Diagrammreihe 1.
6. Hinzufügen einer logarithmischen Trendlinie für Diagrammreihe 2.
7. Hinzufügen einer gleitenden Mittelwert‑Trendlinie für Diagrammreihe 2.
8. Hinzufügen einer polynomialen Trendlinie für Diagrammreihe 3.
9. Hinzufügen einer Potenz‑Trendlinie für Diagrammreihe 3.
10. Speichern Sie die geänderte Präsentation in einer PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides für C++ bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in einem Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den nachstehenden Schritten:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Holen Sie die Referenz einer Folie über ihren Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode, die vom Shapes‑Objekt bereitgestellt wird
- Fügen Sie mit der AddAutoShape‑Methode, die vom Shapes‑Objekt bereitgestellt wird, eine AutoShape vom Typ Linie hinzu
- Setzen Sie die Farbe der Linien der Form.
- Speichern Sie die geänderte Präsentation als PPTX‑Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie geben die Längen der Trendlinie an, die nach vorne bzw. nach hinten projiziert werden: Für Scatter‑(XY‑)Diagramme in Achseneinheiten; für Nicht‑Scatter‑Diagramme in Anzahl der Kategorien. Es sind nur nicht‑negative Werte zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG oder beim Rendern einer Folie zu einem Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien bleiben als Teil des Diagramms bei diesen Vorgängen erhalten. Es gibt zudem eine Methode, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/cpp/create-shape-thumbnails/).