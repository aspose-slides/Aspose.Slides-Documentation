---
title: Erstellen und Einbetten von Excel-Diagrammen als OLE-Objekte mit VSTO und Aspose.Slides für Java
linktitle: Erstellen und Einbetten von Excel-Diagrammen als OLE-Objekte
type: docs
weight: 60
url: /de/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- Diagramm erstellen
- Excel-Diagramm einbetten
- OLE-Objekt
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Migrieren Sie von der Microsoft-Office-Automatisierung zu Aspose.Slides für Java und betten Sie Excel-Diagramme als OLE-Objekte in PowerPoint-Folien (PPT, PPTX) in Java ein."
---
{{% alert color="info" %}} 
Diagramme sind visuelle Darstellungen Ihrer Daten und werden häufig in Präsentationsfolien verwendet. Dieser Artikel zeigt Ihnen den Code, um ein Excel‑Diagramm programmgesteuert als OLE‑Objekt in eine PowerPoint‑Folien einzubetten, und zwar mit Hilfe von [VSTO](/slides/de/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) und [Aspose.Slides for Java](/slides/de/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).
{{% /alert %}} 
## **Erstellen und Einbetten eines Excel‑Diagramms**
Die beiden nachfolgenden Code‑Beispiele sind lang und detailliert, weil die beschriebene Aufgabe komplex ist. Sie erstellen eine Microsoft‑Excel‑Arbeitsmappe, erzeugen ein Diagramm und anschließend die Microsoft‑PowerPoint‑Präsentation, in die Sie das Diagramm einbetten. OLE‑Objekte enthalten Verknüpfungen zum Originaldokument, sodass ein Benutzer, der die eingebettete Datei doppelklickt, die Datei und deren Anwendung startet.
### **VSTO‑Beispiel**
Bei Verwendung von VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz des Microsoft‑Excel‑ApplicationClass‑Objekts.
1. Erstellen Sie eine neue Arbeitsmappe mit einem Arbeitsblatt.
1. Fügen Sie dem Arbeitsblatt ein Diagramm hinzu.
1. Speichern Sie die Arbeitsmappe.
1. Öffnen Sie die Excel‑Arbeitsmappe, die das Arbeitsblatt mit den Diagrammdaten enthält.
1. Rufen Sie die ChartObjects‑Sammlung für das Arbeitsblatt ab.
1. Ermitteln Sie das zu kopierende Diagramm.
1. Erstellen Sie eine Microsoft‑PowerPoint‑Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Kopieren Sie das Diagramm vom Excel‑Arbeitsblatt in die Zwischenablage.
1. Fügen Sie das Diagramm in die PowerPoint‑Präsentation ein.
1. Positionieren Sie das Diagramm auf der Folie.
1. Speichern Sie die Präsentation.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java‑Beispiel**
Bei Verwendung von Aspose.Slides für .NET werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Arbeitsmappe mit Aspose.Cells für Java.
1. Erstellen Sie ein Microsoft‑Excel‑Diagramm.
1. Legen Sie die OLE‑Größe des Excel‑Diagramms fest.
1. Erhalten Sie ein Bild des Diagramms.
1. Betten Sie das Excel‑Diagramm als OLE‑Objekt in eine PPTX‑Präsentation ein, indem Sie Aspose.Slides für Java verwenden.
1. Ersetzen Sie das Bild des geänderten Objekts durch das in Schritt 3 erhaltene Bild, um das Problem des geänderten Objekts zu beheben.
1. Schreiben Sie die Ergebnis‑Präsentation im PPTX‑Format auf die Festplatte.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}