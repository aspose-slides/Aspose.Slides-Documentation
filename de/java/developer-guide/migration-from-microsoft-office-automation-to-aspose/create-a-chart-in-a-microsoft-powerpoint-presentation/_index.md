---
title: Diagramme mit VSTO und Aspose.Slides für Java erstellen
linktitle: Diagramm erstellen
type: docs
weight: 70
url: /de/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- Diagramm erstellen
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie die Erstellung von PowerPoint‑Diagrammen in Java automatisieren können. Diese Schritt‑für‑Schritt‑Anleitung zeigt, warum Aspose.Slides für Java eine schnellere, leistungsfähigere Alternative zu Microsoft.Office.Interop darstellt."
---
{{% alert color="info" %}} 

Diagramme sind visuelle Darstellungen von Daten, die in Präsentationen häufig verwendet werden. Dieser Artikel zeigt den Code zum programmgesteuerten Erstellen eines Diagramms in Microsoft PowerPoint mithilfe von [VSTO](/slides/de/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) und [Aspose.Slides for Java](/slides/de/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Erstellen eines Diagramms**
Die nachstehenden Codebeispiele beschreiben den Vorgang, ein einfaches 3D gruppiertes Säulendiagramm mit VSTO hinzuzufügen. Sie erstellen eine Präsentationsinstanz, fügen ein Standarddiagramm hinzu. Anschließend verwenden Sie ein Microsoft Excel‑Arbeitsbuch, um auf die Diagrammdaten zuzugreifen und diese zu ändern sowie Diagrammeigenschaften festzulegen. Schließlich speichern Sie die Präsentation.
### **VSTO‑Beispiel**
Mit VSTO werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint‑Präsentation.  
1. Fügen Sie der Präsentation eine leere Folie hinzu.  
1. Fügen Sie ein **3D gruppiertes Säulendiagramm** hinzu und greifen Sie darauf zu.  
1. Erstellen Sie eine neue Microsoft Excel‑Arbeitsbuch‑Instanz und laden Sie die Diagrammdaten.  
1. Greifen Sie auf das Diagrammdaten‑Arbeitsblatt mithilfe der Microsoft Excel Workbook‑Instanz **instancefromworkbook** zu.  
1. Setzen Sie den Diagrammbereich im Arbeitsblatt und entfernen Sie Serie 2 und 3 aus dem Diagramm.  
1. Ändern Sie die Diagrammkategorie‑Daten im Diagramm‑Daten‑Arbeitsblatt.  
1. Ändern Sie die Daten der Diagrammserie 1 im Diagramm‑Daten‑Arbeitsblatt.  
1. Greifen Sie nun auf den Diagrammtitel zu und setzen Sie die schriftbezogenen Eigenschaften.  
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die Haupteinheit, Nebeneinheiten, den Maximalwert und die Minimalwerte.  
1. Greifen Sie auf die Tiefen‑ oder Serien‑Achse des Diagramms zu und entfernen Sie diese, da in diesem Beispiel nur **onlyoneserieisused** verwendet wird.  
1. Legen Sie nun die Rotationswinkel des Diagramms in X‑ und Y‑Richtung fest.  
1. Speichern Sie die Präsentation.  
1. Schließen Sie die Instanzen von Microsoft Excel und PowerPoint.  

**Die mit VSTO erstellte Ausgabepäsentation** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides für Java‑Beispiel**
Mit Aspose.Slides für Java werden die folgenden Schritte ausgeführt:

1. Erstellen Sie eine Instanz einer Microsoft PowerPoint‑Präsentation.  
1. Fügen Sie der Präsentation eine leere Folie hinzu.  
1. Fügen Sie ein **3D gruppiertes Säulendiagramm** hinzu und greifen Sie darauf zu.  
1. Greifen Sie mithilfe einer Microsoft Excel Workbook‑Instanz **instancefromworkbook** auf das Arbeitsblatt mit den Diagrammdaten zu.  
1. Entfernen Sie die ungenutzten Serien 2 und 3.  
1. Greifen Sie auf die Diagrammkategorien zu und ändern Sie die Beschriftungen.  
1. Greifen Sie auf **series1** zu und ändern Sie die Serienwerte.  
1. Greifen Sie nun auf den Diagrammtitel zu und setzen Sie die Schriftarteigenschaften.  
1. Greifen Sie auf die Werte‑Achse des Diagramms zu und setzen Sie die Haupteinheit, Nebeneinheiten, den Maximalwert und die Minimalwerte.  
1. Legen Sie nun die Rotationswinkel des Diagramms in X‑ und Y‑Richtung fest.  
1. Speichern Sie die Präsentation im PPTX‑Format.  

**Die mit Aspose.Slides erstellte Ausgabepäsentation** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Kann ich mit Aspose.Slides andere Diagrammtypen wie Kreis-, Linien- oder Balkendiagramme erstellen?

Ja. Aspose.Slides unterstützt eine große Auswahl an [Diagrammtypen](/slides/de/java/create-chart/), darunter Kreisdiagramme, Liniendiagramme, Balkendiagramme, Streudiagramme, Blasendiagramme und mehr. Sie können den gewünschten Diagrammtyp über die Klasse [ChartType](https://reference.aspose.com/slides/de/java/com.aspose.slides/charttype/) festlegen, wenn Sie ein Diagramm hinzufügen.

### Kann ich benutzerdefinierte Stile oder Designs auf das Diagramm anwenden?

Ja. Sie können das Aussehen des Diagramms vollständig anpassen, einschließlich Farben, Schriftarten, Füllungen, Konturen, Gitternetzlinien und Layout. Das genaue Anwenden von Office‑Designs, wie sie in PowerPoint zu sehen sind, erfordert jedoch das manuelle Festlegen einzelner Stile.

### Kann ich das Diagramm als Bild separat von der Folie exportieren?

Ja, Aspose.Slides ermöglicht es, jede Form – einschließlich Diagrammen – als separates Bild (z. B. PNG, JPEG) über die Methode `getImage` des Diagramm‑[Shape](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/) zu exportieren.