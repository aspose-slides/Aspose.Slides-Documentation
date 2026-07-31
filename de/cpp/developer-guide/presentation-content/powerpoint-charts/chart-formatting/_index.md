---
title: Diagramme in C++ formatieren
linktitle: Diagrammformatierung
type: docs
weight: 60
url: /de/cpp/chart-formatting/
keywords:
- Diagramm formatieren
- Diagrammformatierung
- Diagramm‑Entität
- Diagramm‑Eigenschaften
- Diagrammeinstellungen
- Diagrammoptionen
- Schriftarteigenschaften
- abgerundete Rahmen
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Diagramme in Aspose.Slides für C++ formatiert werden und geben Sie Ihrer PowerPoint‑Präsentation ein professionelles, ansprechendes Aussehen."
---
## **Übersicht**

Dieser Artikel erklärt, wie Diagramme in PowerPoint‑Präsentationen mit Aspose.Slides formatiert werden. Er zeigt, wie wichtige Diagrammelemente wie Achsen, Gitternetzlinien, Titel, Legenden, der Plot‑Bereich und Wandfüllungen angepasst werden, um das Erscheinungsbild und die Lesbarkeit der Diagrammdaten zu verbessern.

Er demonstriert außerdem, wie Schriftarteigenschaften für Diagrammtext festgelegt, voreingestellte und benutzerdefinierte Zahlenformate auf Diagrammdaten angewendet und abgerundete Ecken für den Diagrammbereich aktiviert werden. Zusammen zeigen diese Beispiele, wie sowohl der visuelle Stil als auch die Datenpräsentation von Diagrammen in einer Präsentation gesteuert werden können.

## **Diagramm‑Entitäten formatieren**
Aspose.Slides für C++ ermöglicht Entwicklern, benutzerdefinierte Diagramme von Grund auf zu ihren Folien hinzuzufügen. Dieser Artikel erklärt, wie verschiedene Diagrammentitäten, einschließlich Kategorien‑ und Werteachse, formatiert werden.

Aspose.Slides für C++ bietet eine einfache API zum Verwalten verschiedener Diagrammentitäten und zum Formatieren mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation** Klasse.
1. Holen Sie sich einen Folien‑Verweis über dessen Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen gewünschten Diagrammtyp auswählen (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Werteachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen von **Line format** für die Haupt‑Gitternetzlinien der Werteachse
   1. Festlegen von **Line format** für die Neben‑Gitternetzlinien der Werteachse
   1. Festlegen von **Number Format** für die Werteachse
   1. Festlegen von **Min, Max, Major and Minor units** für die Werteachse
   1. Festlegen von **Text Properties** für die Werteachsendaten
   1. Festlegen des **Title** für die Werteachse
   1. Festlegen von **Line Format** für die Werteachse
1. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Festlegen von **Line format** für die Haupt‑Gitternetzlinien der Kategorienachse
   1. Festlegen von **Line format** für die Neben‑Gitternetzlinien der Kategorienachse
   1. Festlegen von **Text Properties** für die Kategorienachsen‑Daten
   1. Festlegen des **Title** für die Kategorienachse
   1. Festlegen von **Label Positioning** für die Kategorienachse
   1. Festlegen des **Rotation Angle** für die Kategorienachsen‑Beschriftungen
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Properties** dafür
1. Stellen Sie ein, dass Diagrammlegenden angezeigt werden, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **Secondary Value Axis** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Value Axis**
   1. Festlegen von **Line Format** für die sekundäre Werteachse
   1. Festlegen von **Number Format** für die sekundäre Werteachse
   1. Festlegen von **Min, Max, Major and Minor units** für die sekundäre Werteachse
1. Plotten Sie nun die erste Diagrammreihe auf der sekundären Werteachse
1. Legen Sie die Hintergrundwand des Diagramms auf eine Füllfarbe fest
1. Legen Sie die Füllfarbe des Diagramm‑Plot‑Bereichs fest
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Schriftarteigenschaften für ein Diagramm festlegen**
Aspose.Slides für C++ bietet Unterstützung zum Festlegen der schriftbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den nachstehenden Schritten, um die Schriftarteigenschaften des Diagramms festzulegen.

- Instanziieren Sie ein Objekt der Klasse Presentation.
- Fügen Sie ein Diagramm auf der Folie hinzu.
- Legen Sie die Schriftgröße fest.
- Speichern Sie die modifizierte Präsentation.

Ein Beispiel ist unten angegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Schriftarteigenschaften für eine Diagrammdatentabelle festlegen**
Aspose.Slides für C++ bietet Unterstützung zum Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie ein Objekt der Klasse Presentation.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Legen Sie die Diagrammtabelle fest.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die modifizierte Präsentation.

Ein Beispiel ist unten angegeben.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Abgerundete Rahmen des Diagrammbereichs festlegen**
Aspose.Slides für C++ bietet Unterstützung zum Festlegen des Diagrammbereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt.

1. Instanziieren Sie ein Objekt der Klasse Presentation.
1. Fügen Sie ein Diagramm auf der Folie hinzu.
1. Legen Sie den Fülltyp und die Füllfarbe des Diagramms fest.
1. Setzen Sie die Eigenschaft für abgerundete Ecken auf True.
1. Speichern Sie die modifizierte Präsentation.

Ein Beispiel ist unten angegeben.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Zahlenformat festlegen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/) Klasse.
1. Holen Sie sich einen Folien‑Verweis über dessen Index.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu, wobei Sie einen gewünschten Typ auswählen (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Legen Sie das voreingestellte Zahlenformat aus den verfügbaren Vorgabewerten fest.
1. Durchlaufen Sie die Datenzellen jedes Diagrammreihe und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Legen Sie das benutzerdefinierte Zahlenformat fest.
1. Durchlaufen Sie die Datenzellen jeder Diagrammreihe und setzen Sie ein unterschiedliches Zahlenformat für die Diagrammdaten.
1. Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem Index, die verwendet werden können, sind unten aufgeführt:**|
| :- | :- |

|**0**|General|
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
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Kann ich halbtransparente Füllungen für Spalten/Flächen festlegen und dabei die Kontur undurchsichtig lassen?**

Ja. Die Fülltransparenz und die Kontur werden separat konfiguriert. Dies ist nützlich, um die Lesbarkeit des Gitters und der Daten in dichten Visualisierungen zu verbessern.

**Wie kann ich mit überlappenden Datenbeschriftungen umgehen?**

Reduzieren Sie die Schriftgröße, deaktivieren Sie nicht wesentliche Beschriftungselemente (z. B. Kategorien), stellen Sie den Beschriftungsversatz/-position ein, zeigen Sie Beschriftungen nur für ausgewählte Punkte an oder wechseln Sie das Format zu „Wert + Legende“.

**Kann ich Farbverläufe oder Musterfüllungen auf Serien anwenden?**

Ja. Sowohl einfarbige als auch Verlauf/Muster‑Füllungen sind in der Regel verfügbar. Verwenden Sie Verläufe sparsam und vermeiden Sie Kombinationen, die den Kontrast zum Gitter und zum Text verringern.