---
title: Arbeitslösung für die Größenänderung von Diagrammen in PPTX
type: docs
weight: 40
url: /php-java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass in eine PowerPoint-Präsentation eingebettete Excel-Diagramme als OLE über Aspose-Komponenten nach der ersten Aktivierung auf einen nicht identifizierten Maßstab verkleinert werden. Dieses Verhalten erzeugt einen erheblichen visuellen Unterschied der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose-Team hat mit Hilfe des Microsoft-Teams dieses Problem ausführlich untersucht und eine Lösung gefunden. Dieser Artikel behandelt die Gründe für und die Lösung dieses Problems.

{{% /alert %}} 
## **Hintergrund**
Im [vorherigen Artikel](/slides/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel-Diagramm mit Aspose.Cells für Java erstellt und dieses Diagramm anschließend in eine PowerPoint-Präsentation mit Aspose.Slides für PHP über Java einbettet. Um das [Problem mit dem geänderten Objekt](/slides/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) zu berücksichtigen, haben wir das Diagrammbild dem OLE-Diagrammobjektrahmen zugewiesen. In der Ausgabenpräsentation, wenn wir doppelt auf den OLE-Diagrammobjektrahmen klicken, der das Diagrammbild anzeigt, wird das Excel-Diagramm aktiviert. Die Endbenutzer können beliebige gewünschte Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und kehren dann zur betreffenden Folie zurück, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Diagrammobjektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Größenänderungsfaktor unterscheidet sich je nach Größe des OLE-Diagrammobjektrahmens und der eingebetteten Excel-Arbeitsmappe.
## **Ursache der Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Andererseits wird der OLE-Diagrammobjektrahmen seine eigene Größe haben. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe über die Größe und stellen sicher, dass sie im richtigen Verhältnis als Teil des Einbettungsprozesses sind. Basierend auf den Unterschieden in der Größe und Position der Excel-Fenster und des OLE-Diagrammobjektrahmens erfolgt die Größenänderung.
## **Funktionierende Lösung**
Es gibt zwei mögliche Szenarien zur Erstellung der PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java.**Szenario 1:** Erstellen Sie die Präsentation basierend auf einer vorhandenen Vorlage**Szenario 2:** Erstellen Sie die Präsentation von Grund auf neu. Die Lösung, die wir hier bereitstellen, gilt für beide Szenarien. Die Grundlage aller Lösungsansätze wird dieselbe sein. Das heißt: **Die Fenstergröße des eingebetteten OLE-Objekts sollte der des OLE-Diagrammobjektrahmens in der PowerPoint-Folie entsprechen**. Nun werden wir die beiden Ansätze der Lösung erörtern.
## **Erster Ansatz**
In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel-Arbeitsmappe entsprechend der Größe des OLE-Diagrammobjektrahmens in der PowerPoint-Folie festlegt.**Szenario 1**Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Nehmen wir an, es gibt eine Form an Index 2 in der Vorlage, an der wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Diagrammobjektrahmens als vordefiniert betrachtet (was der Größe der Form am Index 2 in der Vorlage entspricht). Alles, was wir tun müssen: Stellen Sie die Fenstergröße der Arbeitsmappe gleich der Größe der Form ein. Der folgende Codeausschnitt dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}

**Szenario 2**
Lassen Sie uns sagen, dass wir eine Präsentation von Grund auf neu erstellen und einen OLE-Diagrammobjektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe wünschen. Im folgenden Codeausschnitt haben wir einen OLE-Diagrammobjektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie bei x-Achse = 0,5 Zoll und y-Achse = 1 Zoll erstellt. Außerdem haben wir die äquivalente Fenstergröße der Excel-Arbeitsmappe festgelegt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}

## **Zweiter Ansatz**
In diesem Ansatz lernen wir, wie man die Größe des Diagramms in der eingebetteten Excel-Arbeitsmappe entsprechend der Größe des OLE-Diagrammobjektrahmens in der PowerPoint-Folie festlegt. Dieser Ansatz ist nützlich, wenn die Größe des Diagramms im Vorfeld bekannt ist und sich niemals ändern wird.**Szenario 1**Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Nehmen wir an, es gibt eine Form an Index 2 in der Vorlage, an der wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Rahmens als vordefiniert betrachtet (was der Größe der Form am Index 2 in der Vorlage entspricht). Alles, was wir tun müssen: Stellen Sie die Größe des Diagramms in der Arbeitsmappe gleich der Größe der Form ein. Der folgende Codeausschnitt dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Szenario 2**: Lassen Sie uns sagen, dass wir eine Präsentation von Grund auf neu erstellen und einen OLE-Diagrammobjektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe wünschen. Im folgenden Codeausschnitt haben wir einen OLE-Diagrammobjektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie bei x-Achse = 0,5 Zoll und y-Achse = 1 Zoll erstellt. Außerdem haben wir die äquivalente Diagrammgröße festgelegt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze, um das Problem der Größenänderung von Diagrammen zu beheben. Die Auswahl des geeigneten Ansatzes hängt vom Bedarf und dem Anwendungsfall ab. Beide Ansätze funktionieren auf die gleiche Weise, ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Außerdem gibt es keine Begrenzung der Größe des OLE-Diagrammobjektrahmens in der Lösung.

{{% /alert %}}