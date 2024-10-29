---
title: Formatieren von Text mit VSTO und Aspose.Slides für PHP über Java
type: docs
weight: 30
url: /de/php-java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

Manchmal müssen Sie den Text auf Folien programmgesteuert formatieren. Dieser Artikel zeigt, wie man eine Beispielpräsentation mit etwas Text auf der ersten Folie liest, entweder mit [VSTO](/slides/de/php-java/format-text-using-vsto-and-aspose-slides-for-java/) oder [Aspose.Slides für PHP über Java](/slides/de/php-java/format-text-using-vsto-and-aspose-slides-for-java/). Der Code formatiert den Text im dritten Textfeld auf der Folie, sodass er wie der Text im letzten Textfeld aussieht.

{{% /alert %}} 
## **Textformatierung**
Sowohl die VSTO- als auch die Aspose.Slides-Methoden führen die folgenden Schritte aus:

1. Öffnen der Quellpräsentation.
1. Zugriff auf die erste Folie.
1. Zugriff auf das dritte Textfeld.
1. Ändern der Formatierung des Textes im dritten Textfeld.
1. Speichern der Präsentation auf der Festplatte.

Die Screenshots unten zeigen die Beispiel-Folie vor und nach der Ausführung des VSTO und Aspose.Slides für PHP über PHP-Code.

**Die Eingabepräsentation** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **VSTO-Codebeispiel**
Der folgende Code zeigt, wie man Text auf einer Folie mit VSTO neu formatieren kann.

**Der mit VSTO neu formatierte Text** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Aspose.Slides für PHP über Java-Beispiel**
Um Text mit Aspose.Slides zu formatieren, fügen Sie die Schriftart hinzu, bevor Sie den Text formatieren.

**Die Ausgabpräsentation, die mit Aspose.Slides erstellt wurde** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}