---
title: Excel-Diagramm erstellen und als OLE-Objekt in die Präsentation einbetten
type: docs
weight: 30
url: /de/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

In PowerPoint-Folien ist die Verwendung von bearbeitbaren Diagrammen zur grafischen Darstellung von Daten eine gängige Aktivität. Aspose bietet die Unterstützung zum Erstellen von Excel-Diagrammen mit der Verwendung von Aspose.Cells für Java, und diese Diagramme können anschließend als OLE-Objekt in die PowerPoint-Folie über Aspose.Slides für Java eingebettet werden. Dieser Artikel beschreibt die erforderlichen Schritte sowie die Implementierung in Java, um ein MS Excel-Diagramm als OLE-Objekt in die PowerPoint-Präsentation einzufügen, mithilfe von Aspose.Cells für Java und Aspose.Slides für Java.

{{% /alert %}} 
## **Erforderliche Schritte**
Folgende Schrittfolge ist erforderlich, um ein Excel-Diagramm als OLE-Objekt in die PowerPoint-Folie einzufügen:# Erstellen Sie ein Excel-Diagramm mit Aspose.Cells für Java.# Setzen Sie die OLE-Größe des Excel-Diagramms mit Aspose.Cells für Java.# Erhalten Sie das Bild des Excel-Diagramms mit Aspose.Cells für Java.# Betten Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation mit Aspose.Slides für Java ein.# Ersetzen Sie das geänderte Objektbild durch das in Schritt 3 erhaltene Bild, um das Problem mit dem geänderten Objekt zu beheben.# Speichern Sie die Ausgabepräsentation im PPTX-Format auf der Festplatte.
## **Implementierung der erforderlichen Schritte**
Die Implementierung der obigen Schritte in Java erfolgt wie folgt:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

Die durch die obige Methode erstellte Präsentation enthält das Excel-Diagramm als OLE-Objekt, das durch Doppelklicken auf den OLE-Objektrahmen aktiviert werden kann.

{{% /alert %}} 
## **Fazit**
{{% alert color="primary" %}} 

Durch die Verwendung von Aspose.Cells für Java zusammen mit Aspose.Slides für Java können wir jedes von Aspose.Cells für Java unterstützte Excel-Diagramm erstellen und das erstellte Diagramm als OLE-Objekt in eine PowerPoint-Folie einbetten. Die OLE-Größe des Excel-Diagramms kann ebenfalls definiert werden. Endbenutzer können das Excel-Diagramm wie jedes andere OLE-Objekt weiter bearbeiten.

{{% /alert %}} 
## **Verwandte Abschnitte**
[Funktionsfähige Lösung zum Skalieren von Diagrammen](/slides/de/java/working-solution-for-chart-resizing-in-pptx/)

[Problem mit geänderten Objekten](/slides/de/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)