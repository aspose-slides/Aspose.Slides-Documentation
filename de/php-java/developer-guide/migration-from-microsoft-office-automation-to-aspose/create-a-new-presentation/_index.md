---
title: Erstellen einer neuen Präsentation
type: docs
weight: 10
url: /de/php-java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO wurde entwickelt, damit Entwickler Anwendungen erstellen können, die innerhalb von Microsoft Office ausgeführt werden können. VSTO ist COM-basiert, aber es ist in ein .NET-Objekt eingebettet, sodass es in .NET-Anwendungen verwendet werden kann. VSTO benötigt die Unterstützung des .NET-Frameworks sowie die Microsoft Office CLR-basierte Laufzeit. Obwohl es zur Erstellung von Microsoft Office-Add-Ins verwendet werden kann, ist es nahezu unmöglich, es als serverseitige Komponente zu verwenden. Es gibt auch ernsthafte Bereitstellungsprobleme.

Aspose.Slides für PHP über Java ist eine Komponente, die verwendet werden kann, um Microsoft PowerPoint-Präsentationen zu manipulieren, ähnlich wie VSTO, aber es hat mehrere Vorteile:

- Aspose.Slides enthält nur verwalteten Code und erfordert nicht, dass Microsoft Office-Laufzeit installiert ist.
- Es kann als clientseitige Komponente oder als serverseitige Komponente verwendet werden.
- Die Bereitstellung ist einfach, da Aspose.Slides in einer einzigen JAR-Datei enthalten ist.

{{% /alert %}} 
## **Erstellen einer Präsentation**
Im Folgenden sind zwei Codebeispiele, die veranschaulichen, wie VSTO und Aspose.Slides für PHP über Java verwendet werden können, um dasselbe Ziel zu erreichen. Das erste Beispiel ist [VSTO](/slides/de/php-java/create-a-new-presentation/); [das zweite Beispiel](/slides/de/php-java/create-a-new-presentation/) verwendet Aspose.Slides.
### **VSTO-Beispiel**
**Die VSTO-Ausgabe** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides für PHP über Java-Beispiel**
**Die Ausgabe von Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}