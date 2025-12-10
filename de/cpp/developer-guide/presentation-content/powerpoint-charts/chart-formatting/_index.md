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
- Schriftarteigenschaften
- Abgerundete Rahmen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme in Aspose.Slides für C++ formatieren und heben Sie Ihre PowerPoint-Präsentation mit professionellem, auffälligem Design hervor."
---

## **Diagramm-Entitäten formatieren**
Aspose.Slides für C++ ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagramm-Entitäten formatiert werden, einschließlich Diagramm‑Kategorien‑ und Werte‑Achse.

Aspose.Slides für C++ bietet eine einfache API zur Verwaltung verschiedener Diagramm‑Entitäten und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation**‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen beliebigen gewünschten Typ auswählen (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Werte‑Achse
   1. Festlegen des **Line format** für die Hilfs‑Gitternetzlinien der Werte‑Achse
   1. Festlegen des **Number Format** für die Werte‑Achse
   1. Festlegen von **Min, Max, Major und Minor units** für die Werte‑Achse
   1. Festlegen von **Text Properties** für die Daten der Werte‑Achse
   1. Festlegen des **Title** für die Werte‑Achse
   1. Festlegen des **Line Format** für die Werte‑Achse
1. Greifen Sie auf die Kategorien‑Achse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen des **Line format** für die Hauptgitternetzlinien der Kategorien‑Achse
   1. Festlegen des **Line format** für die Hilfs‑Gitternetzlinien der Kategorien‑Achse
   1. Festlegen von **Text Properties** für die Daten der Kategorien‑Achse
   1. Festlegen des **Title** für die Kategorien‑Achse
   1. Festlegen von **Label Positioning** für die Kategorien‑Achse
   1. Festlegen des **Rotation Angle** für die Beschriftungen der Kategorien‑Achse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Legenden des Diagramms anzeigen, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen des **Line Format** für die sekundäre Werte‑Achse
   1. Festlegen des **Number Format** für die sekundäre Werte‑Achse
   1. Festlegen von **Min, Max, Major und Minor units** für die sekundäre Werte‑Achse
1. Zeichnen Sie nun die erste Diagramm‑Serie auf der sekundären Werte‑Achse
1. Setzen Sie die Hintergrundfläche des Diagramms auf eine Füllfarbe
1. Setzen Sie die Füllfarbe des Diagramm‑Plotbereichs
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Schriftart‑Eigenschaften für ein Diagramm festlegen**
Aspose.Slides für C++ unterstützt das Festlegen von schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftart‑Eigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein Objekt der Klasse Presentation.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Setzen Sie die Schriftgröße.
- Speichern Sie die modifizierte Präsentation.

Ein untenstehendes Beispiel wird gezeigt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Schriftart‑Eigenschaften für eine Diagramm‑Datentabelle festlegen**
Aspose.Slides für C++ unterstützt das Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie ein Objekt der Klasse Presentation.
2. Fügen Sie ein Diagramm zur Folie hinzu.
3. Setzen Sie die Diagrammtabelle.
4. Setzen Sie die Schriftgröße.
5. Speichern Sie die modifizierte Präsentation.

Ein untenstehendes Beispiel wird gezeigt. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Abgerundete Ränder im Diagrammbereich festlegen**
Aspose.Slides für C++ unterstützt das Festlegen des Diagrammbereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt.

1. Instanziieren Sie ein Objekt der Klasse Presentation.
2. Fügen Sie ein Diagramm zur Folie hinzu.
3. Setzen Sie den Fülltyp und die Füllfarbe des Diagramms
4. Setzen Sie die Eigenschaft für abgerundete Ecken auf **True**.
5. Speichern Sie die modifizierte Präsentation. 

Ein untenstehendes Beispiel wird gezeigt. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Numerisches Format festlegen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Klasse.
1. Holen Sie sich eine Referenz auf eine Folie über deren Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen beliebigen gewünschten Typ auswählen (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Setzen Sie das vordefinierte Zahlenformat aus den möglichen vordefinierten Werten.
1. Durchlaufen Sie die Datenzellen jedes Diagramms in jeder Serie und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Setzen Sie das benutzerdefinierte Zahlenformat.
1. Durchlaufen Sie die Datenzellen jedes Diagramms in jeder Serie und setzen Sie ein anderes Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Die möglichen vordefinierten Zahlenformatwerte zusammen mit ihrem Index, die unten angegeben sind:**|
| :- | :- |
|**0**|Allgemein|
| :- | :- |
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
|**46**|h :mm:ss|
|**47**|[mm:ss.0](http://mmss.0/)|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Bereiche festlegen und gleichzeitig die Kontur undurchsichtig lassen?**

Ja. Transparenz der Füllung und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), setzen Sie den Beschriftungs‑Offset bzw. die Position, zeigen Sie Beschriftungen nur für ausgewählte Punkte an, falls nötig, oder wechseln Sie das Format zu "Wert + Legende".

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf-/Musterfüllungen sind in der Regel verfügbar. Verwenden Sie Verläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitter und zum Text verringern.