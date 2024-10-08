---
title: Funktionierende Lösung für die Größenänderung von Diagrammen in PPTX
type: docs
weight: 40
url: /java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Es wurde festgestellt, dass in eine PowerPoint-Präsentation eingebettete Excel-Diagramme als OLE über Aspose-Komponenten bei der ersten Aktivierung auf einen unbekannten Maßstab skaliert werden. Dieses Verhalten erzeugt einen erheblichen visuellen Unterschied in der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Das Aspose-Team hat in Zusammenarbeit mit dem Microsoft-Team dieses Problem im Detail untersucht und eine Lösung gefunden. In diesem Artikel werden die Gründe und die Lösung für dieses Problem behandelt.

{{% /alert %}} 
## **Hintergrund**
Im [vorherigen Artikel](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel-Diagramm mit Aspose.Cells für Java erstellt und dieses Diagramm anschließend mit Aspose.Slides für Java in eine PowerPoint-Präsentation einbettet. Um das [Objektänderungsproblem](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) zu berücksichtigen, haben wir das Diagrammbild dem OLE-Objektrahmen des Diagramms zugewiesen. In der Ausgabpräsentation wird das Excel-Diagramm aktiviert, wenn wir auf den OLE-Objektrahmen doppelklicken, der das Diagrammbild anzeigt. Die Endbenutzer können beliebige gewünschte Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann zur betreffenden Folie zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Größenänderungsfaktor wird je nach Größe des OLE-Objektrahmens und der eingebetteten Excel-Arbeitsmappe unterschiedlich sein.
## **Ursache der Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Andererseits hat der OLE-Objektrahmen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe die Größe und stellen sicher, dass sie im richtigen Verhältnis als Teil des Einbettungsvorgangs ist. Basierend auf den Unterschieden in der Fenstergröße von Excel und der Größe/Position des OLE-Objektrahmens findet die Größenänderung statt.
## **Funktionierende Lösung**
Es gibt zwei mögliche Szenarien für die Erstellung von PowerPoint-Präsentationen mit Aspose.Slides für Java.**Szenario 1:** Erstellung der Präsentation basierend auf einer vorhandenen Vorlage**Szenario 2:** Erstellung der Präsentation von Grund auf. Die Lösung, die wir hier bereitstellen, gilt für beide Szenarien. Die Grundlage aller Lösungsansätze wird gleich sein. Das heißt: **Die Fenstergröße des eingebetteten OLE-Objekts sollte der Größe des OLE-Objektrahmens** **in der PowerPoint-Folie** entsprechen. Nun werden wir die beiden Ansätze der Lösung besprechen.
## **Erster Ansatz**
In diesem Ansatz werden wir lernen, wie man die Fenstergröße der eingebetteten Excel-Arbeitsmappe auf die Größe des OLE-Objektrahmens in der PowerPoint-Folie setzt.**Szenario 1**Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Nehmen wir an, es gibt eine Form an Index 2 in der Vorlage, an der wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Objektrahmens als vordefiniert betrachtet (was der Größe der Form an Index 2 in der Vorlage entspricht). Alles, was wir tun müssen, ist die Fenstergröße der Arbeitsmappe auf die Größe der Form einzustellen. Der folgende Codeausschnitt dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}



**Szenario 2
**Nehmen wir an, wir möchten eine Präsentation von Grund auf erstellen und wünschen uns einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Codeausschnitt haben wir einen OLE-Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie bei x-Achse=0,5 Zoll und y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Fenstergröße der Excel-Arbeitsmappe auf: Höhe 4 Zoll und Breite 9,5 Zoll eingestellt.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **Zweiter Ansatz**
In diesem Ansatz werden wir lernen, wie man die Diagrammgröße in der eingebetteten Excel-Arbeitsmappe auf die Größe des OLE-Objektrahmens in der PowerPoint-Folie setzt. Dieser Ansatz ist nützlich, wenn die Größe des Diagramms im Voraus bekannt ist und sich niemals ändern wird.**Szenario 1**Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Nehmen wir an, es gibt eine Form an Index 2 in der Vorlage, an der wir einen OLE-Rahmen mit einer eingebetteten Excel-Arbeitsmappe platzieren möchten. In diesem Szenario wird die Größe des OLE-Rahmens als vordefiniert betrachtet (was der Größe der Form an Index 2 in der Vorlage entspricht). Alles, was wir tun müssen, ist die Größe des Diagramms in der Arbeitsmappe auf die Größe der Form einzustellen. Der folgende Codeausschnitt dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Szenario 2**: Nehmen wir an, wir möchten eine Präsentation von Grund auf erstellen und wünschen uns einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Codeausschnitt haben wir einen OLE-Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie bei x-Achse=0,5 Zoll und y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Diagrammgröße eingestellt, das heißt: Höhe 4 Zoll und Breite 9,5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze zur Behebung des Problems der Größenänderung von Diagrammen. Die Auswahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt oder von Grund auf neu erstellt werden. Außerdem gibt es im Lösungsansatz keine Begrenzung der Größe des OLE-Objektrahmens.

{{% /alert %}}