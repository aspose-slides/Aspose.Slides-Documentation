---
title: Erstellen einer neuen Präsentation
type: docs
weight: 10
url: /java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO wurde entwickelt, um Entwicklern zu ermöglichen, Anwendungen zu erstellen, die innerhalb von Microsoft Office ausgeführt werden können. VSTO ist COM-basiert, aber es ist in ein .NET-Objekt eingewickelt, sodass es in .NET-Anwendungen verwendet werden kann. VSTO benötigt Unterstützung des .NET-Frameworks sowie zur CLR-basierten Laufzeit von Microsoft Office. Obwohl es für die Erstellung von Microsoft Office-Add-ins verwendet werden kann, ist es nahezu unmöglich, es als serverseitige Komponente zu nutzen. Es hat auch ernsthafte Bereitstellungsprobleme.

Aspose.Slides für Java ist eine Komponente, die verwendet werden kann, um Microsoft PowerPoint-Präsentationen zu manipulieren, ganz wie VSTO, aber es hat mehrere Vorteile:

- Aspose.Slides enthält nur verwalteten Code und benötigt keine Installation der Microsoft Office Laufzeit.
- Es kann als clientseitige Komponente oder als serverseitige Komponente verwendet werden.
- Die Bereitstellung ist einfach, da Aspose.Slides in einer einzigen JAR-Datei enthalten ist.

{{% /alert %}} 
## **Erstellen einer Präsentation**
Unten stehen zwei Codebeispiele, die veranschaulichen, wie VSTO und Aspose.Slides für Java verwendet werden können, um dasselbe Ziel zu erreichen. Das erste Beispiel ist [VSTO](/slides/java/create-a-new-presentation/); [das zweite Beispiel](/slides/java/create-a-new-presentation/) verwendet Aspose.Slides.
### **VSTO-Beispiel**
**Die VSTO-Ausgabe** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Aspose.Slides für Java Beispiel**
**Die Ausgabe von Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}