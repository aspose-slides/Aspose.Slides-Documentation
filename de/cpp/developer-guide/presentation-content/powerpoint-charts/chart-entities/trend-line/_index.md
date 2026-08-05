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
- Trendlinie für gleitenden Mittelwert
- polynomiale Trendlinie
- Potenztrendlinie
- benutzerdefinierte Trendlinie
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Fügen Sie schnell Trendlinien in PowerPoint‑Diagrammen mit Aspose.Slides für C++ hinzu und passen Sie sie an – ein praktischer Leitfaden, um Ihr Publikum zu begeistern."
---
## **Übersicht**

Dieser Artikel erklärt, wie man Trendlinien zu Präsentationsdiagrammen mit Aspose.Slides hinzufügt. Er zeigt, wie man ein Diagramm erstellt, Trendlinien zu Diagrammserien hinzufügt und mit verschiedenen Trendlinientypen arbeitet, einschließlich exponentiell, linear, logarithmisch, gleitender Mittelwert, polynomial und Potenz.

Er beschreibt außerdem, wie man eine benutzerdefinierte Linie zu einem Diagramm hinzufügt, indem man eine Linienform einfügt, und enthält ein kurzes FAQ zu Vorwärts‑ und Rückwärts‑Projektion von Trendlinien sowie zur Erhaltung von Trendlinien beim Export nach PDF oder SVG und beim Rendern von Diagrammen als Bilder.

## **Trendlinie hinzufügen**
Aspose.Slides for C++ bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz einer Folie über ihren Index.
3. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
4. Hinzufügen der exponentiellen Trendlinie für Diagrammserie 1.
5. Hinzufügen einer linearen Trendlinie für Diagrammserie 1.
6. Hinzufügen einer logarithmischen Trendlinie für Diagrammserie 2.
7. Hinzufügen einer Trendlinie für gleitenden Mittelwert für Diagrammserie 2.
8. Hinzufügen einer polynomialen Trendlinie für Diagrammserie 3.
9. Hinzufügen einer Potenz‑Trendlinie für Diagrammserie 3.
10. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Benutzerdefinierte Linie hinzufügen**
Aspose.Slides for C++ bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in ein Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, befolgen Sie bitte die folgenden Schritte:

- Erstellen Sie eine Instanz der Presentation‑Klasse
- Holen Sie sich die Referenz einer Folie über ihren Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode des Shapes‑Objekts
- Fügen Sie eine AutoShape vom Typ Linie mit der AddAutoShape‑Methode des Shapes‑Objekts hinzu
- Setzen Sie die Farbe der Formlinien.
- Schreiben Sie die modifizierte Präsentation als PPTX‑Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **FAQ**

**Was bedeuten „vorwärts“ und „rückwärts“ bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. hinten projiziert werden: Für Streudiagramme (XY) — in Achseneinheiten; für nicht‑Streudiagramme — in Anzahl der Kategorien. Nur nicht‑negative Werte sind zulässig.

**Wird die Trendlinie beim Export der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie als Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen zu [PDF](/slides/de/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien bleiben als Teil des Diagramms während dieser Vorgänge erhalten. Es gibt außerdem eine Methode zum [Exportieren eines Bildes des Diagramms](/slides/de/cpp/create-shape-thumbnails/) selbst.