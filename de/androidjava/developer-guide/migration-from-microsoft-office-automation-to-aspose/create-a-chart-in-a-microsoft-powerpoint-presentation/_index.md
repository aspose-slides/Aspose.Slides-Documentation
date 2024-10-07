---
title: Erstelle ein Diagramm in einer Microsoft PowerPoint-Präsentation
type: docs
weight: 70
url: /androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Diagramme sind visuelle Darstellungen von Daten, die häufig in Präsentationen verwendet werden. Dieser Artikel zeigt den Code zum programmgesteuerten Erstellen eines Diagramms in Microsoft PowerPoint unter Verwendung von [VSTO](/slides/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/) und [Aspose.Slides für Android über Java](/slides/androidjava/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Erstellen eines Diagramms**
Die folgenden Codebeispiele beschreiben den Prozess des Hinzufügens eines einfachen 3D gruppierten Säulendiagramms mit VSTO. Sie erstellen eine Präsentationsinstanz, fügen ein Standarddiagramm hinzu und verwenden dann eine Microsoft Excel-Arbeitsmappe, um auf die Diagrammdaten zuzugreifen und diese zu bearbeiten sowie die Diagrammeigenschaften einzustellen. Schließlich speichern Sie die Präsentation.
### **VSTO Beispiel**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Fügen Sie ein **3D gruppiertes Säulendiagramm** hinzu und greifen Sie darauf zu.
1. Erstellen Sie eine neue Microsoft Excel-Arbeitsmappe und laden Sie die Diagrammdaten.
1. Greifen Sie auf das Diagrammdaten-Arbeitsblatt über die Microsoft Excel-Arbeitsmappeninstanz zu.
1. Setzen Sie den Diagrammbereich im Arbeitsblatt und entfernen Sie die Serien 2 und 3 aus dem Diagramm.
1. Ändern Sie die Kategoriedaten des Diagramms im Diagrammdaten-Arbeitsblatt.
1. Ändern Sie die Daten der Diagrammserie 1 im Diagrammdaten-Arbeitsblatt.
1. Greifen Sie nun auf den Diagrammtitel zu und setzen Sie die schriftdverwandten Eigenschaften.
1. Greifen Sie auf die Wertachse des Diagramms zu und setzen Sie die Haupteinheit, die Untereinheiten, den Maximalwert und den Minimalwert.
1. Greifen Sie auf die Tiefen- oder Serienachse des Diagramms zu und entfernen Sie diese, da in diesem Beispiel nur eine Serie verwendet wird.
1. Setzen Sie jetzt die Rotationswinkel des Diagramms in X- und Y-Richtung.
1. Speichern Sie die Präsentation.
1. Schließen Sie die Instanzen von Microsoft Excel und PowerPoint.

**Die Ausgabepräsentation, erstellt mit VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides für Android über Java Beispiel**
Mit Aspose.Slides für Android über Java werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint-Präsentation.
1. Fügen Sie der Präsentation eine leere Folie hinzu.
1. Fügen Sie ein **3D gruppiertes Säulendiagramm** hinzu und greifen Sie darauf zu.
1. Greifen Sie auf das Diagrammdaten-Arbeitsblatt über eine Microsoft Excel-Arbeitsmappeninstanz zu.
1. Entfernen Sie die ungenutzten Serien 2 und 3.
1. Greifen Sie auf die Diagrammkategorien zu und ändern Sie die Beschriftungen.
1. Greifen Sie auf die Serie 1 zu und ändern Sie die Serienwerte.
1. Greifen Sie nun auf den Diagrammtitel zu und setzen Sie die Schriftarten-Eigenschaften.
1. Greifen Sie auf die Wertachse des Diagramms zu und setzen Sie die Haupteinheit, die Untereinheiten, den Maximalwert und den Minimalwert.
1. Setzen Sie jetzt die Rotationswinkel des Diagramms in X- und Y-Richtung.
1. Speichern Sie die Präsentation im PPTX-Format.

**Die Ausgabepräsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}