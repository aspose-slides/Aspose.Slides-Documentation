---
title: Erstellen eines Diagramms in einer Microsoft PowerPoint-Präsentation
type: docs
weight: 70
url: /java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Diagramme sind visuelle Darstellungen von Daten, die häufig in Präsentationen verwendet werden. Dieser Artikel zeigt den Code zum programmgesteuerten Erstellen eines Diagramms in Microsoft PowerPoint unter Verwendung von [VSTO](/slides/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) und [Aspose.Slides für Java](/slides/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Ein Diagramm erstellen**
Die folgenden Codebeispiele beschreiben den Prozess des Hinzufügens eines einfachen 3D-geclusterten Säulendiagramms mit VSTO. Sie erstellen eine Instanz einer Präsentation, fügen ein Standarddiagramm hinzu und verwenden dann eine Microsoft Excel-Arbeitsmappe, um auf die Diagrammdaten zuzugreifen und diese zu ändern sowie die Diagrammeigenschaften festzulegen. Schließlich speichern Sie die Präsentation.
### **VSTO-Beispiel**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Fügen Sie ein **3D-geclustertes Säulendiagramm** hinzu und greifen Sie darauf zu.
1. Erstellen Sie eine neue Microsoft Excel-Arbeitsmappeninstanz und laden Sie die Diagrammdaten.
1. Greifen Sie auf das Diagrammdaten-Arbeitsblatt mithilfe der Microsoft Excel-Arbeitsmappeninstanz zu.
1. Legen Sie den Diagrammbereich im Arbeitsblatt fest und entfernen Sie die Serien 2 und 3 aus dem Diagramm.
1. Ändern Sie die Kategoriedaten des Diagramms im Diagrammdaten-Arbeitsblatt.
1. Ändern Sie die Daten der Diagrammserie 1 im Diagrammdaten-Arbeitsblatt.
1. Greifen Sie jetzt auf den Diagrammtitel zu und legen Sie die Schriftart-Related-Eigenschaften fest.
1. Greifen Sie auf die Diagrammwertachse zu und legen Sie die Haupt-, Neben-, Maximal- und Minimalwerte fest.
1. Greifen Sie auf die Diagrammtiefe oder die Serienachse zu und entfernen Sie diese, da in diesem Beispiel nur eine Serie verwendet wird.
1. Legen Sie jetzt die Drehwinkel des Diagramms in X- und Y-Richtung fest.
1. Speichern Sie die Präsentation.
1. Schließen Sie die Instanzen von Microsoft Excel und PowerPoint.

**Die Ausgabepräsentation, erstellt mit VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides für Java Beispiel**
Mit Aspose.Slides für Java werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Fügen Sie ein **3D-geclustertes Säulendiagramm** hinzu und greifen Sie darauf zu.
1. Greifen Sie auf das Diagrammdaten-Arbeitsblatt mithilfe einer Microsoft Excel-Arbeitsmappeninstanz zu.
1. Entfernen Sie die ungenutzten Serien 2 und 3.
1. Greifen Sie auf die Diagrammkategorien zu und ändern Sie die Beschriftungen.
1. Greifen Sie auf die Serie 1 zu und ändern Sie die Serienwerte.
1. Greifen Sie jetzt auf den Diagrammtitel zu und legen Sie die Schriftarteigenschaften fest.
1. Greifen Sie auf die Diagrammwertachse zu und legen Sie die Haupt-, Neben-, Maximal- und Minimalwerte fest.
1. Legen Sie jetzt die Drehwinkel des Diagramms in X- und Y-Richtung fest.
1. Speichern Sie die Präsentation im PPTX-Format.

**Die Ausgabepräsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}