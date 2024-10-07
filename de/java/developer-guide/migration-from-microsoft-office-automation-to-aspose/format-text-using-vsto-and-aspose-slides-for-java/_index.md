---
title: Text formatieren mit VSTO und Aspose.Slides für Java
type: docs
weight: 30
url: /java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

Manchmal müssen Sie den Text auf Folien programmgesteuert formatieren. Dieser Artikel zeigt, wie Sie eine Beispieldpräsentation mit etwas Text auf der ersten Folie mit entweder [VSTO](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/) oder [Aspose.Slides für Java](/slides/java/format-text-using-vsto-and-aspose-slides-for-java/) lesen. Der Code formatiert den Text im dritten Textfeld auf der Folie so, dass er wie der Text im letzten Textfeld aussieht.

{{% /alert %}} 
## **Text formatieren**
Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

1. Öffnen Sie die Quelldpräsentation.
1. Greifen Sie auf die erste Folie zu.
1. Greifen Sie auf das dritte Textfeld zu.
1. Ändern Sie die Formatierung des Textes im dritten Textfeld.
1. Speichern Sie die Präsentation auf der Festplatte.

Die untenstehenden Screenshots zeigen die Beispieldfolie vor und nach der Ausführung des VSTO- und Aspose.Slides für Java-Codes.

**Die Eingabpräsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO-Codebeispiel**
Der folgende Code zeigt, wie Sie den Text auf einer Folie mit VSTO neu formatieren.

**Der mit VSTO neu formatierte Text** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides für Java-Beispiel**
Um Text mit Aspose.Slides zu formatieren, fügen Sie die Schriftart hinzu, bevor Sie den Text formatieren.

**Die Ausgabpräsentation, erstellt mit Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}