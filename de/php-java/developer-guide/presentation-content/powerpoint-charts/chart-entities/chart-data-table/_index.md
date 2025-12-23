---
title: Diagrammdatentabellen in Präsentationen mit PHP anpassen
linktitle: Datentabelle
type: docs
url: /de/php-java/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schriftattribute
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Diagrammdatentabellen für PPT und PPTX mit Aspose.Slides für PHP via Java anpassen, um Effizienz und Attraktivität in Präsentationen zu steigern."
---

## **Schriftattribute für eine Diagrammdatentabelle festlegen**
Aspose.Slides for PHP via Java bietet Unterstützung für das Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie das [Presentation] Klassenobjekt.
1. Fügen Sie dem Folie ein Diagramm hinzu.
1. Setzen Sie die Diagrammtabelle.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die geänderte Präsentation.

Unten ist ein Beispiel angegeben.  
```php
  # Erstellen einer leeren Präsentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich kleine Legendenbeschriftungen neben den Werten in der Diagrammdatentabelle anzeigen?**

Ja. Die Datentabelle unterstützt [Legendenbeschriftungen](https://reference.aspose.com/slides/php-java/aspose.slides/datatable/setshowlegendkey/), und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildern beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass die exportierten [PDF](/slides/de/php-java/convert-powerpoint-to-pdf/)/[HTML](/slides/de/php-java/convert-powerpoint-to-html/)/[Bild](/slides/de/php-java/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthalten.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wird, können Sie über die Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [angezeigt](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) wird.

**Wie kann ich schnell herausfinden, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [angezeigt](https://reference.aspose.com/slides/php-java/aspose.slides/chart/hasdatatable/) wird, und iterieren Sie durch die Folien, um die Diagramme zu identifizieren, bei denen sie aktiviert ist.