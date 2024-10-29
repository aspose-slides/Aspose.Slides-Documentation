---
title: Erstellen eines Excel-Diagramms und Einbetten als OLE-Objekt in eine Präsentation
type: docs
weight: 30
url: /de/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

In PowerPoint-Folien ist die Verwendung von bearbeitbaren Diagrammen zur grafischen Darstellung von Daten eine gängige Aktivität. Aspose unterstützt die Erstellung von Excel-Diagrammen mit Aspose.Cells für Java, und diese Diagramme können als OLE-Objekt in die PowerPoint-Folie eingebettet werden über Aspose.Slides für PHP mittels Java. Dieser Artikel behandelt die erforderlichen Schritte sowie die Implementierung zur Erstellung und Einbettung eines MS Excel-Diagramms als OLE-Objekt in einer PowerPoint-Präsentation unter Verwendung von Aspose.Cells für Java und Aspose.Slides für PHP über Java.

{{% /alert %}} 
## **Erforderliche Schritte**
Folgende Abfolge von Schritten ist erforderlich, um ein Excel-Diagramm als OLE-Objekt in die PowerPoint-Folie einzufügen: # Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für Java. # Setzen Sie die OLE-Größe des Excel-Diagramms mit Aspose.Cells für Java. # Holen Sie das Bild des Excel-Diagramms mit Aspose.Cells für Java. # Betten Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation ein, mithilfe von Aspose.Slides für PHP über Java. # Ersetzen Sie das geänderte Objektbild durch das Bild, das in Schritt 3 erhalten wurde, um das Problem „Objekt geändert“ zu berücksichtigen. # Speichern Sie die Ausgabpräsentation im PPTX-Format auf der Festplatte.
## **Implementierung der erforderlichen Schritte**
Die Implementierung der obigen Schritte ist wie folgt:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

Die durch die oben genannte Methode erstellte Präsentation wird das Excel-Diagramm als OLE-Objekt enthalten, das durch Doppelklicken auf den OLE-Objektrahmen aktiviert werden kann.

{{% /alert %}} 
## **Fazit**
{{% alert color="primary" %}} 

Durch die Verwendung von Aspose.Cells für Java zusammen mit Aspose.Slides für PHP über Java können wir jedes der von Aspose.Cells für Java unterstützten Excel-Diagramme erstellen und das erstellte Diagramm als OLE-Objekt in eine PowerPoint-Folie einbetten. Die OLE-Größe des Excel-Diagramms kann ebenfalls definiert werden. Die Endbenutzer können das Excel-Diagramm wie jedes andere OLE-Objekt weiterbearbeiten.

{{% /alert %}} 
## **Verwandte Abschnitte**
[Funktionsfähige Lösung zur Diagrammgröße](/slides/de/php-java/working-solution-for-chart-resizing-in-pptx/)

[Problem „Objekt geändert“](/slides/de/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)