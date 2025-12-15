---
title: 3D-Diagramme in Präsentationen auf Android anpassen
linktitle: 3D-Diagramm
type: docs
url: /de/androidjava/3d-chart/
keywords:
- 3D-Diagramm
- Rotation
- Tiefe
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie 3‑D‑Diagramme in Aspose.Slides für Android via Java erstellen und anpassen, mit Unterstützung für PPT‑ und PPTX‑Dateien – verbessern Sie noch heute Ihre Präsentationen."
---

## **RotationX-, RotationY- und DepthPercents-Eigenschaften eines 3D-Diagramms festlegen**
Aspose.Slides für Android über Java bietet eine einfache API zum Festlegen dieser Eigenschaften. Der folgende Artikel hilft Ihnen, verschiedene Eigenschaften wie **X‑, Y‑Rotation, DepthPercents** usw. festzulegen. Der Beispielcode demonstriert das Einstellen der genannten Eigenschaften.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Greifen Sie auf die erste Folie zu.
1. Fügen Sie ein Diagramm mit Standarddaten hinzu.
1. Setzen Sie die Rotation3D‑Eigenschaften.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```java
Presentation pres = new Presentation();
try {
    // Erste Folie zugreifen
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Diagramm mit Standarddaten hinzufügen
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Index des Diagrammdatenblatts festlegen
    int defaultWorksheetIndex = 0;
    
    // Diagrammdaten-Arbeitsblatt abrufen
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Serie hinzufügen
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Kategorien hinzufügen
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Rotation3D-Eigenschaften festlegen
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Zweite Diagrammserie nehmen
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Jetzt die Seriendaten füllen
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Überlappungswert festlegen
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Präsentation auf Festplatte schreiben
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Welche Diagrammtypen unterstützen den 3D‑Modus in Aspose.Slides?**

Aspose.Slides unterstützt 3D‑Varianten von Säulendiagrammen, darunter Column 3D, Clustered Column 3D, Stacked Column 3D und 100 % Stacked Column 3D, sowie verwandte 3D‑Typen, die über die Klasse [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) bereitgestellt werden. Für eine genaue, aktuelle Liste prüfen Sie die Mitglieder von [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) in der API‑Referenz Ihrer installierten Version.

**Kann ich ein Rasterbild eines 3D‑Diagramms für einen Bericht oder das Web erhalten?**

Ja. Sie können ein Diagramm über die [chart API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) in ein Bild exportieren oder die gesamte Folie mit [render the entire slide](/slides/de/androidjava/convert-powerpoint-to-png/) in Formate wie PNG oder JPEG rendern. Das ist nützlich, wenn Sie eine pixelgenaue Vorschau benötigen oder das Diagramm in Dokumente, Dashboards oder Webseiten einbetten möchten, ohne PowerPoint zu benötigen.

**Wie performant ist das Erstellen und Rendern großer 3D‑Diagramme?**

Die Leistung hängt vom Datenvolumen und der visuellen Komplexität ab. Für optimale Ergebnisse sollten 3D‑Effekte minimal gehalten, schwere Texturen an Wänden und Plot‑Bereichen vermieden, die Anzahl der Datenpunkte pro Serie nach Möglichkeit begrenzt und die Ausgabe in einer angemessenen Größe (Auflösung und Abmessungen) gerendert werden, um den Ziel‑Display‑ oder Druckanforderungen zu entsprechen.