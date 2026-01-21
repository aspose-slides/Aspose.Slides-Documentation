---
title: Diagrammformatierung in C++
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/cpp/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm-Entität
- Diagrammeigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schrifteigenschaften
- abgerundete Rahmen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie mehr über die Diagrammformatierung in Aspose.Slides für C++ und verbessern Sie Ihre PowerPoint-Präsentation mit professionellem, auffälligem Design."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides für C++ ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm-Entitäten formatiert werden, einschließlich Kategorien- und Werte-Achse.

Aspose.Slides für C++ stellt eine einfache API zum Verwalten verschiedener Diagramm-Entitäten und zum Formatieren mit benutzerdefinierten Werten bereit:

1. Erstellen Sie eine Instanz der **Presentation**-Klasse.  
1. Holen Sie die Referenz einer Folie über ihren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und wählen Sie einen der gewünschten Typen (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).  
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für die Hauptgitternetzlinien der Werte‑Achse  
   1. Festlegen des **Linienformats** für die Neben‑Gitternetzlinien der Werte‑Achse  
   1. Festlegen des **Zahlenformats** für die Werte‑Achse  
   1. Festlegen von **Min, Max, Haupt‑ und Neben‑Einheiten** für die Werte‑Achse  
   1. Festlegen der **Texteigenschaften** für die Daten der Werte‑Achse  
   1. Festlegen des **Titels** für die Werte‑Achse  
   1. Festlegen des **Linienformats** für die Werte‑Achse  
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Linienformats** für die Hauptgitternetzlinien der Kategorien‑Achse  
   1. Festlegen des **Linienformats** für die Neben‑Gitternetzlinien der Kategorien‑Achse  
   1. Festlegen der **Texteigenschaften** für die Daten der Kategorien‑Achse  
   1. Festlegen des **Titels** für die Kategorien‑Achse  
   1. Festlegen der **Beschriftungspositionierung** für die Kategorien‑Achse  
   1. Festlegen des **Rotationswinkels** für die Beschriftungen der Kategorien‑Achse  
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Texteigenschaften** dafür  
1. Diagrammlegenden anzeigen, ohne das Diagramm zu überlappen  
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren der sekundären **Value Axis**  
   1. Festlegen des **Linienformats** für die sekundäre Value Axis  
   1. Festlegen des **Zahlenformats** für die sekundäre Value Axis  
   1. Festlegen von **Min, Max, Haupt‑ und Neben‑Einheiten** für die sekundäre Value Axis  
1. Plotten Sie jetzt die erste Diagrammserie auf der sekundären Value Axis  
1. Setzen Sie die Rückwand des Diagramms auf Füllfarbe  
1. Setzen Sie die Füllfarbe des Diagramm‑Plotbereichs  
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Schriftarteneigenschaften für ein Diagramm festlegen**
Aspose.Slides für C++ unterstützt das Festlegen von schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den untenstehenden Schritten, um die Schriftarteneigenschaften für das Diagramm zu setzen.

- Instanziieren Sie ein Objekt der Klasse **Presentation**.  
- Fügen Sie ein Diagramm auf der Folie hinzu.  
- Setzen Sie die Schriftgröße.  
- Speichern Sie die modifizierte Präsentation.

Nachfolgend ein Beispiel.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Schriftarteneigenschaften für die Diagrammdaten‑Tabelle festlegen**
Aspose.Slides für C++ unterstützt das Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie ein Objekt der Klasse **Presentation**.  
1. Fügen Sie ein Diagramm auf der Folie hinzu.  
1. Diagrammtabelle festlegen.  
1. Setzen Sie die Schriftgröße.  
1. Speichern Sie die modifizierte Präsentation.

Nachfolgend ein Beispiel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Abgerundete Ränder im Diagrammbereich festlegen**
Aspose.Slides für C++ unterstützt das Festlegen des Diagrammbereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt.

1. Instanziieren Sie ein Objekt der Klasse **Presentation**.  
1. Fügen Sie ein Diagramm auf der Folie hinzu.  
1. Festlegen von Fülltyp und Füllfarbe des Diagramms  
1. Setzen der Eigenschaft runde Ecken auf **True**.  
1. Speichern Sie die modifizierte Präsentation.  

Nachfolgend ein Beispiel.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Numerisches Format festlegen**
Aspose.Slides für C++ stellt eine einfache API zum Verwalten des Diagramm‑Datenformats bereit:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.  
1. Holen Sie die Referenz einer Folie über ihren Index.  
1. Fügen Sie ein Diagramm mit Standarddaten hinzu und wählen Sie einen gewünschten Typ (dieses Beispiel verwendet **ChartType.ClusteredColumn**).  
1. Setzen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten.  
1. Durchlaufen Sie die Datenzellen jedes Diagramm‑Serien und setzen Sie das Zahlenformat der Diagrammdaten.  
1. Speichern Sie die Präsentation.  
1. Setzen Sie das benutzerdefinierte Zahlenformat.  
1. Durchlaufen Sie die Datenzellen in jeder Diagramm‑Serie und legen Sie ein anderes Zahlenformat für die Diagrammdaten fest.  
1. Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:**|
| :- | :- |
|**0**|Allgemein|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen und gleichzeitig die Kontur undurchsichtig lassen?**

Ja. Transparenz der Füllung und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Rasters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit Datenbeschriftungen umgehen, wenn sie sich überschneiden?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht notwendige Beschriftungselemente (z. B. Kategorien), setzen Sie den Beschriftungsversatz/-position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie das Format zu „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf‑/Musterfüllungen stehen typischerweise zur Verfügung. In der Praxis sollten Verläufe sparsam eingesetzt und Kombinationen vermieden werden, die den Kontrast zum Raster und Text verringern.