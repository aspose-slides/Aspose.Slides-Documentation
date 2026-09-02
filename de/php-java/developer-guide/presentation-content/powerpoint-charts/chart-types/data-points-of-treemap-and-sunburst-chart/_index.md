---
title: Datenpunkte in Treemap- und Sunburst-Diagrammen in PHP anpassen
linktitle: Datenpunkte in Treemap- und Sunburst-Diagrammen
type: docs
url: /de/php-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap-Diagramm
- Sunburst-Diagramm
- Hierarchisches Diagramm
- Datenpunkt
- Datenbeschriftung
- Zweigfarbe
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie hierarchische Daten erstellen und Ebenen, Beschriftungen und Farben in Treemap- und Sunburst-Diagrammen mit Aspose.Slides für PHP via Java anpassen."
---
## **Übersicht**

Treemap‑ und Sunburst‑Diagramme stellen dieselbe Art von hierarchischen Daten dar, verwenden jedoch unterschiedliche Layouts. Ein Treemap zeichnet die Hierarchie als verschachtelte Rechtecke, deren Flächen die Blattwerte repräsentieren. Ein Sunburst stellt sie als konzentrische Ringe dar: Oberste Gruppen befinden sich nahe dem Zentrum, Blattkategorien liegen am äußeren Ring.

In Aspose.Slides for PHP via Java ist jeder numerische Wert ein [ChartDataPoint](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/). Seine [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#getDataPointLevels)-Methode gibt Zugriff auf das Blatt und seine übergeordneten Gruppen. Dieser Artikel erklärt diese Zuordnung und zeigt, wie beide Diagrammtypen aus denselben Beispieldaten erstellt und formatiert werden.

![Ein Treemap‑Diagramm mit den Bereichen Consumer und Business](treemap-hierarchy.png)

![Ein Sunburst‑Diagramm mit derselben Consumer‑ und Business‑Hierarchie](sunburst-hierarchy.png)

## **Kategorien, Datenpunkte und Ebenen verstehen**

Das unten verwendete Beispiel hat drei Kategorienebenen und eine numerische Serie:

| Bereich | Stamm | Blatt | Umsatz |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Jede Zeile erzeugt eine Blattkategorie und einen Datenpunkt. Die Kategoriegruppierungsebenen beschreiben den Pfad von diesem Blatt zu seinen Eltern. Für die erste Zeile lautet der Pfad `Consumer > Computers > Laptops`.

Die von [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) zurückgegebenen Indizes laufen vom Blatt nach oben:

| `getDataPointLevels()`‑Index | Logische Ebene | Treemap‑Darstellung | Sunburst‑Darstellung |
| ---: | --- | --- | --- |
| `0` | Blatt | Werte‑Rechteck | Segment am äußeren Ring |
| `1` | Stamm | Eltern‑Rechteck oder -Kopfzeile | Segment am mittleren Ring |
| `2` | Bereich | Rechteck oder Kopfzeile der obersten Ebene | Segment am inneren Ring |

Diese Reihenfolge ist für beide Diagrammtypen identisch, obwohl sich ihre visuellen Layouts unterscheiden. Ein übergeordnetes Segment wird von mehreren Blättern gemeinsam genutzt. Um es zu formatieren, verwenden Sie die entsprechende Ebene des ersten Datenpunkts in dieser Gruppe. Beispiel: Der `Consumer`‑Bereich beginnt mit dem Punkt `Laptops`, während der `Software`‑Stamm mit dem Punkt `Licenses` startet. Referenzen zu diesen Punkten zu behalten ist klarer und sicherer als ungeklärte Ausdrücke wie `$dataPoints->get_Item(0)` oder `$dataPoints->get_Item(6)` zu verwenden.

## **Beide Diagrammtypen erstellen und anpassen**

Das folgende vollständige Beispiel erstellt ein Treemap auf der ersten Folie und ein Sunburst auf der zweiten Folie. Es baut die Hierarchie auf, zeigt den Wert für `Tablets` an, weist ausgewählten Ebenen feste Farben zu, formatiert ein Bereichs‑Label und speichert die Präsentation.

```php
$presentation = new Presentation();
try {
    $worksheetIndex = 0;
    $leafLevelIndex = 0;
    $stemLevelIndex = 1;
    $branchLevelIndex = 2;

    $branchNames = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ];
    $stemNames = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ];
    $leafNames = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ];
    $revenues = [12, 8, 15, 6, 10, 7, 11, 14];
    $dataPointCount = count($leafNames);

    $chartTypes = [ChartType::Treemap, ChartType::Sunburst];
    $chartCount = count($chartTypes);
    $layoutSlide = $presentation->getLayoutSlides()->get_Item(0);

    for ($chartIndex = 0; $chartIndex < $chartCount; $chartIndex++) {
        $chartType = $chartTypes[$chartIndex];

        if ($chartIndex === 0) {
            $slide = $presentation->getSlides()->get_Item(0);
        } else {
            $slide = $presentation->getSlides()->addEmptySlide($layoutSlide);
        }

        $chart = $slide->getShapes()->addChart($chartType, 40, 40, 640, 440);
        $chart->setTitle(false);
        $chart->setLegend(false);

        $chartData = $chart->getChartData();
        $chartData->getCategories()->clear();
        $chartData->getSeries()->clear();

        $workbook = $chartData->getChartDataWorkbook();
        $workbook->clear($worksheetIndex);

        // Füge die Blattkategorien hinzu. Ein Gruppierungselement wird nur gesetzt, wenn eine neue Gruppe beginnt;
        // die folgenden Kategorien bleiben in dieser Gruppe, bis ein weiteres Element gesetzt wird.
        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $categoryCell = $workbook->getCell($worksheetIndex, $rowIndex, 2, $leafName);
            $category = $chartData->getCategories()->add($categoryCell);

            $stemName = $stemNames[$dataIndex];
            $startsNewStem = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousStemName = $stemNames[$dataIndex - 1];
                $startsNewStem = $stemName !== $previousStemName;
            }
            if ($startsNewStem) {
                $category->getGroupingLevels()->setGroupingItem($stemLevelIndex, $stemName);
            }

            $branchName = $branchNames[$dataIndex];
            $startsNewBranch = $dataIndex === 0;
            if ($dataIndex > 0) {
                $previousBranchName = $branchNames[$dataIndex - 1];
                $startsNewBranch = $branchName !== $previousBranchName;
            }
            if ($startsNewBranch) {
                $category->getGroupingLevels()->setGroupingItem($branchLevelIndex, $branchName);
            }
        }

        $seriesNameCell = $workbook->getCell($worksheetIndex, 0, 3, "Revenue");
        $series = $chartData->getSeries()->add($seriesNameCell, $chartType);
        $series->getLabels()->getDefaultDataLabelFormat()->setShowCategoryName(true);

        $laptopsDataPoint = null;
        $tabletsDataPoint = null;
        $licensesDataPoint = null;

        for ($dataIndex = 0; $dataIndex < $dataPointCount; $dataIndex++) {
            $rowIndex = $dataIndex + 1;
            $leafName = $leafNames[$dataIndex];
            $revenue = $revenues[$dataIndex];
            $valueCell = $workbook->getCell($worksheetIndex, $rowIndex, 3, $revenue);

            if ($chartType === ChartType::Treemap) {
                $dataPoint = $series->getDataPoints()->addDataPointForTreemapSeries($valueCell);
            } else {
                $dataPoint = $series->getDataPoints()->addDataPointForSunburstSeries($valueCell);
            }

            if ($leafName === "Laptops") {
                $laptopsDataPoint = $dataPoint;
            } elseif ($leafName === "Tablets") {
                $tabletsDataPoint = $dataPoint;
            } elseif ($leafName === "Licenses") {
                $licensesDataPoint = $dataPoint;
            }
        }

        // Zeige die Kategorie und den Wert im Blatt Tablets.
        $tabletsLeafLevel = $tabletsDataPoint->getDataPointLevels()->get_Item($leafLevelIndex);
        $tabletsLabelFormat = $tabletsLeafLevel->getLabel()->getDataLabelFormat();
        $tabletsLabelFormat->setShowCategoryName(true);
        $tabletsLabelFormat->setShowValue(true);
        $tabletsLabelFormat->setSeparator("\n");
        $tabletsLabelFormat->setNumberFormat('$0');

        // Formatiere den Consumer-Zweig über das erste Blatt in diesem Zweig.
        $consumerBranchLevel = $laptopsDataPoint->getDataPointLevels()->get_Item($branchLevelIndex);
        $consumerBranchFill = $consumerBranchLevel->getFormat()->getFill();
        $consumerBranchColor = new java("java.awt.Color", 31, 78, 121);
        $consumerBranchFill->setFillType(FillType::Solid);
        $consumerBranchFill->getSolidFillColor()->setColor($consumerBranchColor);

        $consumerLabelFormat = $consumerBranchLevel->getLabel()->getDataLabelFormat();
        $consumerLabelFormat->setShowCategoryName(true);
        $consumerLabelFormat->setShowSeriesName(false);
        $consumerLabelTextFill = $consumerLabelFormat->getTextFormat()->getPortionFormat()->getFillFormat();
        $white = java("java.awt.Color")->WHITE;
        $consumerLabelTextFill->setFillType(FillType::Solid);
        $consumerLabelTextFill->getSolidFillColor()->setColor($white);

        // Formatiere den Software-Stamm über das erste Blatt in diesem Stamm.
        $softwareStemLevel = $licensesDataPoint->getDataPointLevels()->get_Item($stemLevelIndex);
        $softwareStemFill = $softwareStemLevel->getFormat()->getFill();
        $softwareStemColor = new java("java.awt.Color", 112, 173, 71);
        $softwareStemFill->setFillType(FillType::Solid);
        $softwareStemFill->getSolidFillColor()->setColor($softwareStemColor);

        // ParentLabelLayout beeinflusst die Eltern-Labels bei Treemap; Sunburst verwendet Ringsegmente.
        if ($chartType === ChartType::Treemap) {
            $series->setParentLabelLayout(ParentLabelLayoutType::Overlapping);
        }
    }

    $presentation->save("hierarchical-charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Die Kategorien‑ und Werte‑Zellen verwenden dieselbe Arbeitsblattzeile, sodass ihre Sammlungspositionen ausgerichtet bleiben. Wenn Sie mit einem bereits vorhandenen Diagramm arbeiten, statt eines neuen, prüfen Sie zunächst die Kategoriezeilen und speichern Sie benannte Verweise auf die Datenpunkte und Ebenen, die Sie formatieren möchten.

## **Verhalten und praktische Überlegungen**

### **Unterschiede zwischen Treemap und Sunburst**

- Ein Treemap verwendet die Fläche, um den Wert zu kommunizieren, und verschachtelte Rechtecke, um die Hierarchie darzustellen. Die [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#setParentLabelLayout)-Methode steuert, wie Eltern‑Labels in diesem Diagrammtyp erscheinen.
- Ein Sunburst verwendet den Winkel, um den Wert zu kommunizieren, und die Ringtiefe, um die Hierarchie darzustellen. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartseries/#setParentLabelLayout) beeinflusst seine Ring‑Labels nicht.
- Beide Diagrammtypen nutzen dieselben Kategoriegruppierungsebenen und dieselbe Blatt‑zu‑Eltern‑Reihenfolge, die von [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapoint/#getDataPointLevels) zurückgegeben wird, sodass der Code zum Aufbau von Daten und zur Ebenen‑Formatierung gemeinsam verwendet werden kann.
- Elternwerte werden aus ihren nachfolgenden Blättern berechnet. Fügen Sie keine separaten numerischen Punkte für Bereiche oder Stämme hinzu.

### **Sortierung und Segmentreihenfolge**

Die Diagrammlayout‑Engine bestimmt die endgültige Platzierung von Rechtecken und Ringsegmenten. Ordnen Sie zusammengehörige Kategorienzeilen vor dem Hinzufügen, verlassen Sie sich jedoch nicht auf eine bestimmte Rechtecksposition oder Startwinkel. Wenn die Reihenfolge Bedeutung hat, integrieren Sie sie in die Labels oder verwenden Sie einen Diagrammtyp mit expliziter Kategorienachse.

### **Thema und feste Farben**

Nicht formatierte Diagrammebenen erben Farben aus dem Präsentationsthema. Das Beispiel verwendet explizite RGB‑Füllungen für vorhersehbare Ausgabe. Sollte das Diagramm Themenänderungen folgen, benutzen Sie Schema‑Farben statt fester RGB‑Werte und vermeiden Sie das Überschreiben jeder Ebene. Prüfen Sie außerdem den Label‑Kontrast, nachdem Sie eine Bereichs‑ oder Stamm‑Füllung geändert haben.

### **Labels und verfügbarer Platz**

PowerPoint kann Labels ausblenden oder abschneiden, wenn ein Segment zu klein ist. Das Vergrößern des Diagramms, das Kürzen von Kategorienamen oder das Anzeigen weniger Label‑Felder führt meist zu klareren Ergebnissen. Ein Label kann den Kategorienamen, den Seriennamen und den Wert mittels [DataLabelFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabelformat/) kombinieren, aber das Aktivieren aller Felder erschwert das Lesen hierarchischer Diagramme häufig.

### **Export und Rendering**

Das Speichern als PPTX hält das Diagramm bearbeitbar. Wenn Aspose.Slides die Präsentation in PDF oder ein Bild rendert, werden die unterstützten Füllungen und Label‑Einstellungen mit dem Diagramm gerendert. Schriftart‑Substitution und geringe Unterschiede im verfügbaren Layout‑Platz können Zeilenumbrüche oder Label‑Sichtbarkeit ändern; installieren Sie daher die benötigten Schriftarten und überprüfen Sie wichtige Exportziele.

## **FAQ**

**Warum wirkt sich das Ändern einer Eltern‑Ebene auf mehrere Blätter aus?**

Ein Bereich oder Stamm ist ein gemeinsam genutztes visuelles Segment. Sein [ChartDataPointLevel](https://reference.aspose.com/slides/de/php-java/aspose.slides/chartdatapointlevel/) kann über ein nachfolgendes Blatt erreicht werden, aber die Formatierung gehört zum gemeinsam genutzten Eltern‑Segment und nicht nur zu diesem Blatt.

**Warum fehlt ein Daten‑Label?**

Aktivieren Sie zunächst die benötigten Felder im [DataLabelFormat](https://reference.aspose.com/slides/de/php-java/aspose.slides/datalabelformat/)-Objekt des Labels. Prüfen Sie dann, ob das Segment genug Platz hat. Treemap‑Eltern‑Label‑Layout, Diagrammgröße, Label‑Länge, Schriftgröße und die Anzahl aktivierter Felder beeinflussen, ob ein Label angezeigt werden kann.

**Kann ich die exakte Reihenfolge oder Koordinaten von Segmenten festlegen?**

Sie können die Reihenfolge der Quell‑Zeilen steuern und jede Gruppe zusammenhängend halten, aber Sie können keine genauen Treemap‑Rechtecke oder Sunburst‑Winkel zuweisen. Die Diagrammlayout‑Engine berechnet sie aus Hierarchie, Werten und verfügbarem Platz.

**Warum ändern sich Farben, wenn das Präsentationsthema gewechselt wird?**

Themenbasierte Füllungen sind dafür gedacht, der Präsentationspalette zu folgen. Verwenden Sie explizite RGB‑Farben für Ebenen, die fest bleiben sollen, oder behalten Sie Schema‑Farben bei, wenn die Anpassung an ein neues Thema gewünscht ist.

**Werden benutzerdefinierte Formatierungen bei PDF‑ und Bild‑Exporten beibehalten?**

Ja, unterstützte Diagramm‑Füllungen und Label‑Einstellungen werden beim Rendern übernommen. Für konsistente Ergebnisse stellen Sie die erforderlichen Schriftarten bereit und testen Sie die endgültige Exportgröße, da das Anpassen von Labels layoutspezifisch ist.

## **Siehe auch**

- [Create Treemap charts](/slides/de/php-java/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/de/php-java/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/de/php-java/export-chart/)
- [Manage presentation themes](/slides/de/php-java/presentation-theme/)