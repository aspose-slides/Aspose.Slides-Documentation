---
title: Erstellen und Einbetten eines Excel-Diagramms als OLE-Objekt in eine Microsoft PowerPoint-Folie
type: docs
weight: 60
url: /de/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Diagramme sind visuelle Darstellungen Ihrer Daten und werden häufig in Präsentationsfolien verwendet. Dieser Artikel zeigt Ihnen den Code, um ein Excel-Diagramm als OLE-Objekt in die PowerPoint-Folie programmgesteuert zu erstellen und einzubetten, indem Sie [VSTO](/slides/de/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) und [Aspose.Slides für PHP über Java](/slides/de/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) verwenden.

{{% /alert %}} 
## **Erstellen und Einbetten eines Excel-Diagramms**
Die beiden folgenden Codebeispiele sind lang und detailliert, da die beschriebene Aufgabe umfangreich ist. Sie erstellen eine Microsoft Excel-Arbeitsmappe, erstellen ein Diagramm und erstellen dann die Microsoft PowerPoint-Präsentation, in die Sie das Diagramm einbetten werden. OLE-Objekte enthalten Links zum Originaldokument, sodass ein Benutzer, der auf die eingebettete Datei doppelklickt, die Datei und deren Anwendung öffnet.
### **VSTO-Beispiel**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz des Microsoft Excel ApplicationClass-Objekts.
1. Erstellen Sie eine neue Arbeitsmappe mit einem Blatt darin.
1. Fügen Sie dem Blatt ein Diagramm hinzu.
1. Speichern Sie die Arbeitsmappe.
1. Öffnen Sie die Excel-Arbeitsmappe, die das Arbeitsblatt mit den Diagrammdaten enthält.
1. Holen Sie sich die ChartObjects-Sammlung für das Blatt.
1. Holen Sie sich das zu kopierende Diagramm.
1. Erstellen Sie eine Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Kopieren Sie das Diagramm aus dem Excel-Arbeitsblatt in die Zwischenablage.
1. Fügen Sie das Diagramm in die PowerPoint-Präsentation ein.
1. Positionieren Sie das Diagramm auf der Folie.
1. Speichern Sie die Präsentation.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides für PHP über Java Beispiel**
Mit Aspose.Slides für .NET werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Arbeitsmappe mit Aspose.Cells für Java.
1. Erstellen Sie ein Microsoft Excel-Diagramm.
1. Legen Sie die OLE-Größe des Excel-Diagramms fest.
1. Holen Sie sich ein Bild des Diagramms.
1. Betten Sie das Excel-Diagramm als OLE-Objekt in die PPTX-Präsentation ein, indem Sie Aspose.Slides für PHP über Java verwenden.
1. Ersetzen Sie das geänderte Bild des Objekts durch das in Schritt 3 erhaltene Bild, um das Problem mit dem geänderten Objekt zu lösen.
1. Schreiben Sie die Ausgabpräsentation im PPTX-Format auf die Festplatte.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}