---
title: Text formatieren mit VSTO und Aspose.Slides für Java
linktitle: Text formatieren
type: docs
weight: 30
url: /de/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- Text formatieren
- Migration
- VSTO
- Office-Automatisierung
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Migrieren Sie von der Microsoft Office-Automatisierung zu Aspose.Slides für Java und formatieren Sie Text in PowerPoint (PPT, PPTX)-Präsentationen mit präziser Kontrolle."
---
{{% alert color="info" %}} 
Manchmal muss man den Text auf Folien programmgesteuert formatieren. Dieser Artikel zeigt, wie man eine Beispielpräsentation mit etwas Text auf der ersten Folie entweder mit [VSTO](/slides/de/java/format-text-using-vsto-and-aspose-slides-for-java/) und [Aspose.Slides for Java](/slides/de/java/format-text-using-vsto-and-aspose-slides-for-java/) einliest. Der Code formatiert den Text im dritten Textfeld der Folie so, dass er wie der Text im letzten Textfeld aussieht.
{{% /alert %}} 
## **Formatting Text**
Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

1. Öffnen Sie die Quellpräsentation.
1. Greifen Sie auf die erste Folie zu.
1. Greifen Sie auf das dritte Textfeld zu.
1. Ändern Sie die Formatierung des Textes im dritten Textfeld.
1. Speichern Sie die Präsentation auf dem Datenträger.

Die Screenshots unten zeigen die Beispielfolie vor und nach der Ausführung des VSTO- und Aspose.Slides‑for‑Java-Codes.

**Die Eingabepräsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO‑Codebeispiel**
Der nachstehende Code zeigt, wie man Text auf einer Folie mit VSTO neu formatiert.

**Der mit VSTO neu formatierte Text** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides for Java Beispiel**
Um Text mit Aspose.Slides zu formatieren, fügen Sie die Schriftart hinzu, bevor Sie den Text formatieren.

**Die mit Aspose.Slides erstellte Ausgabepäsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}