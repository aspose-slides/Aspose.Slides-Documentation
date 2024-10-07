---
title: Diagrammformatierung
type: docs
weight: 60
url: /cpp/chart-formatting/
---



## **Diagrammobjekte formatieren**
Aspose.Slides für C++ ermöglicht es Entwicklern, benutzerdefinierte Diagramme von Grund auf in ihre Folien hinzuzufügen. Dieser Artikel erklärt, wie man verschiedene Diagrammobjekte, einschließlich der Achse für Kategorien und Werte, formatiert.

Aspose.Slides für C++ bietet eine einfache API zum Verwalten verschiedener Diagrammobjekte und deren Formatierung mit benutzerdefinierten Werten:

1. Erstellen Sie eine Instanz der **Presentation** Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem beliebigen gewünschten Typ hinzu (in diesem Beispiel verwenden wir ChartType.LineWithMarkers).
1. Greifen Sie auf die Wertachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Einstellungen für das **Linienformat** der Hauptgitternetzlinien der Wertachse
   1. Einstellungen für das **Linienformat** der Nebengitternetzlinien der Wertachse
   1. Einstellungen für das **Zahlenformat** der Wertachse
   1. Einstellungen für **Min-, Max-, Haupt- und Neben-Einheiten** der Wertachse
   1. Einstellungen für die **Text Eigenschaften** der Daten der Wertachse
   1. Einstellungen für den **Titel** der Wertachse
   1. Einstellungen für das **Linienformat** der Wertachse
1. Greifen Sie auf die Kategorienachse des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Einstellungen für das **Linienformat** der Hauptgitternetzlinien der Kategorienachse
   1. Einstellungen für das **Linienformat** der Nebengitternetzlinien der Kategorienachse
   1. Einstellungen für die **Text Eigenschaften** der Daten der Kategorienachse
   1. Einstellungen für den **Titel** der Kategorienachse
   1. Einstellungen für die **Beschriftungsplatzierung** der Kategorienachse
   1. Einstellungen für den **Drehwinkel** der Beschriftungen der Kategorienachse
1. Greifen Sie auf die Legende des Diagramms zu und setzen Sie die **Text Eigenschaften** für diese
1. Legen Sie fest, dass Diagrammlegenden angezeigt werden, ohne das Diagramm zu überlappen
1. Greifen Sie auf die **Sekundäre Wertachse** des Diagramms zu und setzen Sie die folgenden Eigenschaften:
   1. Aktivieren Sie die sekundäre **Wertachse**
   1. Einstellungen für das **Linienformat** der sekundären Wertachse
   1. Einstellungen für das **Zahlenformat** der sekundären Wertachse
   1. Einstellungen für **Min-, Max-, Haupt- und Neben-Einheiten** der sekundären Wertachse
1. Zeichnen Sie nun die erste Diagrammreihe auf der sekundären Wertachse
1. Stellen Sie die Hintergrundwand des Diagramms auf Füllfarbe ein
1. Stellen Sie die Füllfarbe des Diagrammzeichnungsbereichs ein
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Schriftarteigenschaften für Diagramm einstellen**
Aspose.Slides für C++ bietet Unterstützung für das Setzen der schriftartbezogenen Eigenschaften für das Diagramm. Bitte folgen Sie den folgenden Schritten, um die Schriftarteigenschaften für das Diagramm festzulegen.

- Instanziieren Sie ein Presentation Klassenobjekt.
- Fügen Sie das Diagramm auf der Folie hinzu.
- Stellen Sie die Schriftgröße ein.
- Speichern Sie die modifizierte Präsentation.

Unten ist ein Beispiel gegeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Schriftarteigenschaften für die Diagrammtabelle einstellen**
Aspose.Slides für C++ bietet Unterstützung für das Ändern der Farben von Kategorien in einer Serienfarbe. 

1. Instanziieren Sie ein Presentation Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Stellen Sie die Diagrammtabelle ein.
1. Stellen Sie die Schriftgröße ein.
1. Speichern Sie die modifizierte Präsentation.

Unten ist ein Beispiel gegeben. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Gerundete Ecken für den Diagramm-Bereich einstellen**
Aspose.Slides für C++ bietet Unterstützung für die Einstellung des Diagramm Bereichs. Die Eigenschaften **IChart.HasRoundedCorners** und **Chart.HasRoundedCorners** wurden in Aspose.Slides hinzugefügt. 

1. Instanziieren Sie ein Presentation Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Stellen Sie den Fülltyp und die Füllfarbe des Diagramms ein.
1. Stellen Sie die Eigenschaft „runde Ecken“ auf True.
1. Speichern Sie die modifizierte Präsentation. 

Unten ist ein Beispiel gegeben. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Diagrammdaten Zahlen einstellen**
Aspose.Slides für C++ bietet eine einfache API zur Verwaltung des Diagrammdatenformats:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
1. Erhalten Sie eine Referenz auf eine Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem beliebigen gewünschten Typ hinzu (dieses Beispiel verwendet **ChartType.ClusteredColumn**).
1. Stellen Sie das voreingestellte Zahlenformat aus den möglichen voreingestellten Werten ein.
1. Durchlaufen Sie die Diagrammdatenzelle in jeder Diagrammreihe und setzen Sie das Zahlenformat der Diagrammdaten.
1. Speichern Sie die Präsentation.
1. Stellen Sie das benutzerdefinierte Zahlenformat ein.
1. Durchlaufen Sie die Diagrammdatenzelle innerhalb jeder Diagrammreihe und setzen Sie ein anderes Diagrammdatenformat.
1. Speichern Sie die Präsentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Die möglichen voreingestellten Zahlenformatwerte zusammen mit ihrem voreingestellten Index, die verwendet werden können, sind unten angegeben:**|
| :- | :- |

|**0**|Allgemein|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Rot$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Rot$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/jj|
|**15**|d-mmm-jj|
|**16**|d-mmm|
|**17**|mmm-jj|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/jj h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Rot-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Rot-#,##0.00|
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