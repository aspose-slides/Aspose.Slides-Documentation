---
title: Diagrammdatentabellen in Präsentationen auf Android anpassen
linktitle: Datentabelle
type: docs
url: /de/androidjava/chart-data-table/
keywords:
- Diagrammdaten
- Datentabelle
- Schrifteigenschaften
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Diagrammdatentabellen in Java für PPT und PPTX mit Aspose.Slides für Android anpassen, um Effizienz und Attraktivität in Präsentationen zu steigern."
---

## **Schriftarteigenschaften für eine Diagrammdatentabelle festlegen**
Aspose.Slides für Android via Java bietet Unterstützung für das Ändern der Farbe von Kategorien in einer Serienfarbe.

1. Instanziieren Sie das Klassenobjekt [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. Diagramm zur Folie hinzufügen.
1. Diagrammtabelle festlegen.
1. Schriftgröße festlegen.
1. Modifizierte Präsentation speichern.

 Nachfolgend ein Beispiel.
```java
// Leere Präsentation erstellen
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich kleine Legenden-Schlüssel neben den Werten in der Diagrammdatentabelle anzeigen?**

Ja. Die Datentabelle unterstützt [legend keys](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), und Sie können sie ein- oder ausschalten.

**Wird die Datentabelle beim Exportieren der Präsentation nach PDF, HTML oder Bildformaten beibehalten?**

Ja. Aspose.Slides rendert das Diagramm als Teil der Folie, sodass das exportierte [PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/de/androidjava/convert-powerpoint-to-html/)/[image](/slides/de/androidjava/convert-powerpoint-to-png/) das Diagramm mit seiner Datentabelle enthält.

**Werden Datentabellen für Diagramme unterstützt, die aus einer Vorlagendatei stammen?**

Ja. Für jedes Diagramm, das aus einer bestehenden Präsentation oder Vorlage geladen wird, können Sie mithilfe der Diagrammeigenschaften prüfen und ändern, ob eine Datentabelle [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) angezeigt wird.

**Wie kann ich schnell feststellen, welche Diagramme in einer Datei die Datentabelle aktiviert haben?**

Untersuchen Sie die Eigenschaft jedes Diagramms, die angibt, ob die Datentabelle [is shown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#hasDataTable--) angezeigt wird, und durchlaufen Sie die Folien, um die Diagramme zu ermitteln, bei denen sie aktiviert ist.