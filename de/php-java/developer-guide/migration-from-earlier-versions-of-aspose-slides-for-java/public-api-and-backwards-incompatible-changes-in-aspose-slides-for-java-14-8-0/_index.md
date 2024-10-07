---
title: Öffentliches API und nicht rückwärtskompatible Änderungen in Aspose.Slides für PHP über Java 14.8.0
type: docs
weight: 70
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/
---

{{% alert color="primary" %}} 

Diese Seite listet alle [hinzugefügten](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) Klassen, Methoden, Eigenschaften usw., alle neuen Einschränkungen und andere [Änderungen](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-8-0/) auf, die mit dem Aspose.Slides für PHP über Java 14.8.0 API eingeführt wurden.

{{% /alert %}} 
## **Öffentliche API-Änderungen**
### **Hinzugefügt die Aspose.Slides.Charts.IChartSeries.getOverlap(), IChartSeriesGroup.getOverlap() und setOverlap(byte) Methoden**
Die Aspose.Slides.Charts.IChartSeries.getOverlap() gibt an, wie sehr Balken und Säulen in 2D-Diagrammen überlappen sollen (in einem Bereich von -100 bis 100).
Diese Methode gilt nicht nur für bestimmte Serien, sondern für alle Serien der übergeordneten Seriengruppe - dies ist eine Projektion der entsprechenden Gruppenproperty.

- Verwenden Sie die Methode IChartSeries.getParentSeriesGroup() um auf die übergeordnete Seriengruppe zuzugreifen.
- Verwenden Sie die Methoden IChartSeriesGroup.getOverlap() und setOverlap(byte) um den Wert zu verwalten.

```php
  $pres = new Presentation();
  $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
  $series = $chart->getChartData()->getSeries();
  if (java_values($series->get_Item(0)->getOverlap()) == 0) {
    $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
  }
```
### **Hinzugefügt den ShapeThumbnailBounds.Appearance Enum-Wert**
Diese Methode zur Erstellung von Formminiaturen ermöglicht es Entwicklern, eine Formminiatur im Rahmen ihres Erscheinens zu erstellen. Es berücksichtigt alle Formeffekte. Die generierte Formminiatur wird durch die Folienbegrenzungen eingeschränkt.

```php
  $pres = new Presentation();
  $st = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getThumbnail(ShapeThumbnailBounds->Appearance, 1, 1);

```
### **Hinzugefügt die VbaProject Klasse und IVbaProject Schnittstelle, geändert die Methoden Presentation.getVbaProject() und setVbaProject(VbaProject)**
Eine neue Funktion ermöglicht es Entwicklern, VBA-Projekte in einer Präsentation zu erstellen und zu bearbeiten.

```php
  $pres = new Presentation();
  # Neues VBA-Projekt erstellen
  $pres->setVbaProject(new VbaProject());
  # Leeres Modul zum VBA-Projekt hinzufügen
  $module = $pres->getVbaProject()->getModules()->addEmptyModule("Modul");
  # Quellcode des Moduls festlegen
  $module->setSourceCode("Sub Test(oShape As Shape)\r\n    MsgBox \"Test\"\r\nEnd Sub");
  # Referenz zu <stdole> erstellen
  $stdoleReference = new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
  # Referenz zu Office erstellen
  $officeReference = new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
  # Referenzen zum VBA-Projekt hinzufügen
  $pres->getVbaProject()->getReferences()->add($stdoleReference);
  $pres->getVbaProject()->getReferences()->add($officeReference);
  $pres->save("data\\test.pptm", SaveFormat::Pptm);

```