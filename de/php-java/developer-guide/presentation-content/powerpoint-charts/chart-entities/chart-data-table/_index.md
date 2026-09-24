---
title: Diagrammdatentabellen in Präsentationen mit PHP anpassen
linktitle: Datentabelle
type: docs
url: /de/php-java/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Passen Sie Schriften, Rahmen und Legenden‑Schlüssel von Diagrammdatentabellen in PowerPoint‑Präsentationen mit Aspose.Slides für PHP via Java an."
---
## **Übersicht**

Aspose.Slides for PHP via Java ermöglicht das Anzeigen einer Diagrammdatentabelle und das Anpassen von Textformatierung, Rahmen und Legenden‑Schlüsseln. Dieser Artikel erklärt, wie die Tabelle aktiviert, ihr Text formatiert, jeder Rahmentyp gesteuert und Legenden‑Schlüssel angezeigt oder ausgeblendet werden. Die Beispiele speichern die konfigurierten Diagramme in PPTX‑Dateien.

## **Schrifteigenschaften festlegen**

Um die Datentabelle eines Diagramms anzuzeigen, übergeben Sie `true` an [setDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/setdatatable/). Verwenden Sie [getChartDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/getchartdatatable/), um auf die Tabelle zuzugreifen und deren Textformatierung zu konfigurieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/de/php-java/aspose.slides/presentation/) .
1. Fügen Sie der ersten Folie ein gruppiertes Säulendiagramm hinzu.
1. Aktivieren Sie die Datentabelle des Diagramms.
1. Aktivieren Sie fetten Text mit [setFontBold](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setFontBold) und übergeben Sie `20` an [setFontHeight](https://reference.aspose.com/slides/de/php-java/aspose.slides/baseportionformat/#setFontHeight) für Text mit 20 Punkt.
1. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erfordert `test.pptx` im Arbeitsverzeichnis mit mindestens einer Folie. Es fügt ein Diagramm mit Standarddaten an Position (50, 50) ein, mit einer Breite von 600 Punkten und einer Höhe von 400 Punkten. Die gespeicherte `output.pptx` enthält das Diagramm mit aktivierter Datentabelle und den angegebenen Schrifteinstellungen.

```php
use aspose\slides\ChartType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("test.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $portionFormat = $chart->getChartDataTable()->getTextFormat()->getPortionFormat();
    $portionFormat->setFontBold(NullableBool::True);
    $portionFormat->setFontHeight(20);

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Rahmen der Datentabelle anpassen**

Aktivieren Sie die Tabelle mit [Chart::setDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/setdatatable/) und greifen Sie über [Chart::getChartDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/getchartdatatable/) darauf zu. Sie können drei Arten von Rahmen unabhängig steuern:

- [setBorderHorizontal](https://reference.aspose.com/slides/de/php-java/aspose.slides/datatable/setborderhorizontal/) steuert horizontale Zellenrahmen.
- [setBorderVertical](https://reference.aspose.com/slides/de/php-java/aspose.slides/datatable/setbordervertical/) steuert vertikale Zellenrahmen.
- [setBorderOutline](https://reference.aspose.com/slides/de/php-java/aspose.slides/datatable/setborderoutline/) steuert den äußeren Rahmen der Tabelle.

Übergeben Sie `true` an jede Methode, um deren Rahmen anzuzeigen, oder `false`, um sie auszublenden. Das folgende Beispiel erstellt ein gruppiertes Säulendiagramm mit Standarddaten, zeigt horizontale Rahmen und den äußeren Rahmen an und blendet vertikale Rahmen aus. Es benötigt keine Eingabedatei. Position und Größe des Diagramms werden in Punkten angegeben.

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(false);
    $dataTable->setBorderOutline(true);

    $presentation->save("data-table-borders.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der Vergleich unten verwendet dieselben Diagrammdaten und Legenden‑Schlüssel‑Einstellungen in allen vier Fällen. Beginnend mit allen aktivierten Rahmen deaktiviert jede verbleibende Variante genau ein Rahmenelement. Die Variante unten links entspricht den Rahmeneinstellungen im Beispiel.

![Diagrammdaten‑tabellen mit allen Rahmen aktiviert, ohne horizontale Rahmen, ohne vertikale Rahmen und ohne äußeren Rahmen](data-table-borders.png)

## **Legenden‑Schlüssel anzeigen oder ausblenden**

Legenden‑Schlüssel sind kleine farbige Markierungen neben den Seriennamen in der Datentabelle. Sie helfen dem Leser, jede Tabellenzeile einer Diagrammserie zuzuordnen. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/php-java/aspose.slides/datatable/setshowlegendkey/), um diese Markierungen anzuzeigen, oder `false`, um sie auszublenden.

Die separate Legende des Diagramms wird über [Chart::setLegend](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/setlegend/) gesteuert. Diese Einstellungen sind unabhängig: Das Ausblenden der separaten Legende blendet die Schlüssel in der Datentabelle nicht aus, und das Ausblenden der Tabellenschlüssel blendet die separate Legende nicht aus.

Das folgende Beispiel erstellt ein Diagramm mit Standarddaten, aktiviert dessen Datentabelle und zeigt Legenden‑Schlüssel darin an, während die separate Legende ausgeblendet wird. Alle Tabellengrenzen werden explizit aktiviert. Es wird keine Eingabepräsentation benötigt. Um nur die Tabellenschlüssel auszublenden, übergeben Sie `false` an [setShowLegendKey](https://reference.aspose.com/slides/de/php-java/aspose.slides/datatable/setshowlegendkey/).

```php
use aspose\slides\ChartType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->setLegend(false);

    $dataTable = $chart->getChartDataTable();
    $dataTable->setBorderHorizontal(true);
    $dataTable->setBorderVertical(true);
    $dataTable->setBorderOutline(true);
    $dataTable->setShowLegendKey(true);

    $presentation->save("data-table-legend-keys.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Der Vergleich unten zeigt dieselbe Tabelle mit aktivierten und deaktivierten Legenden‑Schlüsseln. Alle Rahmen bleiben aktiviert, und die separate Diagrammlegende ist in beiden Fällen ausgeblendet.

![Diagrammdaten‑tabellen mit angezeigten Legenden‑Schlüsseln links und ausgeblendeten rechts](data-table-legend-keys.png)

## **FAQ**

**Kann ich Legenden‑Schlüssel in der Datentabelle eines Diagramms anzeigen?**

Ja. Übergeben Sie `true` an [setShowLegendKey](https://reference.aspose.com/slides/de/php-java/aspose.slides/datatable/setshowlegendkey/), um Legenden‑Schlüssel anzuzeigen, oder `false`, um sie auszublenden.

**Wird die Datentabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm und dessen angezeigte Datentabelle als Teil der Folie, wenn es nach [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/de/php-java/convert-powerpoint-to-html/) oder [Bilder](/slides/de/php-java/convert-powerpoint-to-png/) exportiert wird.

**Kann ich mit Datentabellen in aus einer Vorlage geladenen Diagrammen arbeiten?**

Ja. Für ein aus einer vorhandenen Präsentation oder Vorlage geladenes Diagramm verwenden Sie [hasDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/hasdatatable/) und [setDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/setdatatable/), um zu prüfen oder zu ändern, ob dessen Datentabelle angezeigt wird.

**Wie kann ich Diagramme finden, bei denen die Datentabelle aktiviert ist?**

Iterieren Sie über die Formen jeder Folie, ermitteln Sie die Diagramme und rufen Sie deren [hasDataTable](https://reference.aspose.com/slides/de/php-java/aspose.slides/chart/hasdatatable/)-Methode auf. Ein Wert von `true` bedeutet, dass die Datentabelle aktiviert ist.