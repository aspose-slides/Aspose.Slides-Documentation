---
title: Funktionierende Lösung für das Größenanpassung von Diagrammen in PPTX
type: docs
weight: 40
url: /java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass Excel-Diagramme, die als OLE in eine PowerPoint-Präsentation über Aspose-Komponenten eingebettet sind, nach der erstmaligen Aktivierung auf eine unbekannte Größe verkleinert werden. Dieses Verhalten führt zu einem erheblichen visuellen Unterschied der Präsentation zwischen den Zuständen vor und nach der Aktivierung des Diagramms. Das Aspose-Team hat mit Hilfe des Microsoft-Teams dieses Problem detailliert untersucht und eine Lösung gefunden. Dieser Artikel behandelt die Gründe und die Lösung für dieses Problem.

{{% /alert %}} 
## **Hintergrund**
Im [vorherigen Artikel](/slides/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man ein Excel-Diagramm mit Aspose.Cells für Java erstellt und dieses Diagramm anschließend in eine PowerPoint-Präsentation mit Aspose.Slides für Java einbettet. Um das [Problem mit dem geänderten Objekt](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) zu berücksichtigen, haben wir das Diagramm-Bild dem Chart OLE-Objekt-Frame zugewiesen. In der AusgabPräsentation wird das Excel-Diagramm aktiviert, wenn wir auf den OLE-Objekt-Frame doppelklicken, der das Diagramm-Bild zeigt. Die Endbenutzer können beliebige gewünschte Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann durch Klicken außerhalb der aktiven Excel-Arbeitsmappe zur betreffenden Folie zurückkehren. Die Größe des OLE-Objekt-Frames wird sich ändern, wenn der Benutzer zur Folie zurückkehrt. Der Größenfaktor wird für verschiedene Größen des OLE-Objekt-Frames und der eingebetteten Excel-Arbeitsmappe unterschiedlich sein.
## **Ursache der Größenanpassung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der ersten Aktivierung beizubehalten. Auf der anderen Seite hat der OLE-Objekt-Frame seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint bei der Aktivierung der Excel-Arbeitsmappe über die Größe und stellen sicher, dass sie im richtigen Verhältnis als Teil des Einbettungsprozesses ist. Basierend auf den Unterschieden in der Excel-Fenstergröße und der Größe / Position des OLE-Objekt-Frames findet die Größenanpassung statt.
## **Funktionierende Lösung**
Es gibt zwei mögliche Szenarien für die Erstellung der PowerPoint-Präsentationen mit Aspose.Slides für Java.**Szenario 1:** Erstellen Sie die Präsentation basierend auf einer vorhandenen Vorlage**Szenario 2:** Erstellen Sie die Präsentation von Grund auf. Die Lösung, die wir hier bereitstellen werden, gilt für beide Szenarien. Die Grundlage aller Lösungsansätze wird die gleiche sein. Das heißt: **Die Fenstergröße des eingebetteten OLE-Objekts sollte die gleiche sein wie die des OLE-Objekt-Frames** **in der PowerPoint-Folie.** Nun werden wir die zwei Ansätze der Lösung diskutieren.
## **Erster Ansatz**
In diesem Ansatz lernen wir, wie man die Fenstergröße der eingebetteten Excel-Arbeitsmappe auf die Größe des OLE-Objekt-Frames in der PowerPoint-Folie setzt.**Szenario 1**Nehmen wir an, wir haben eine Vorlage definiert und wollen die Präsentationen basierend auf dieser Vorlage erstellen. Angenommen, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Frame platzieren möchten, der eine eingebettete Excel-Arbeitsmappe enthält. In diesem Szenario wird die Größe des OLE-Objekt-Frames als vordefiniert angesehen (was die Größe der Form an Index 2 in der Vorlage ist). Alles, was wir tun müssen: Setzen Sie die Fenstergröße der Arbeitsmappe gleich der Größe der Form. Der folgende Code-Schnipsel dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}



**Szenario 2
**Angenommen, wir möchten eine Präsentation von Grund auf erstellen und wünschen uns einen OLE-Objekt-Frame beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Code-Schnipsel haben wir einen OLE-Objekt-Frame mit 4 Zoll Höhe und 9.5 Zoll Breite in der Folie an der x-Achse=0.5 Zoll und der y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Fenstergröße der Excel-Arbeitsmappe festgelegt, das heißt: Höhe 4 Zoll und Breite 9.5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **Zweiter Ansatz**
In diesem Ansatz lernen wir, wie man die Diagrammgröße in der eingebetteten Excel-Arbeitsmappe auf die Größe des OLE-Objekt-Frames in der PowerPoint-Folie setzt. Dieser Ansatz ist nützlich, wenn die Größe des Diagramms im Voraus bekannt ist und sich nie ändern wird.**Szenario 1**Nehmen wir an, wir haben eine Vorlage definiert und wollen die Präsentationen basierend auf dieser Vorlage erstellen. Angenommen, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Frame platzieren möchten, der eine eingebettete Excel-Arbeitsmappe enthält. In diesem Szenario wird die Größe des OLE-Frames als vordefiniert angesehen (was die Größe der Form an Index 2 in der Vorlage ist). Alles, was wir tun müssen: Stellen Sie die Größe des Diagramms in der Arbeitsmappe gleich der Größe der Form ein. Der folgende Code-Schnipsel dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Szenario 2**: Angenommen, wir möchten eine Präsentation von Grund auf erstellen und wünschen uns einen OLE-Objekt-Frame beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe. Im folgenden Code-Schnipsel haben wir einen OLE-Objekt-Frame mit 4 Zoll Höhe und 9.5 Zoll Breite in der Folie an der x-Achse=0.5 Zoll und der y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Diagrammgröße festgelegt, das heißt: Höhe 4 Zoll und Breite 9.5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze, um das Problem der Größenanpassung von Diagrammen zu beheben. Die Wahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf die gleiche Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt oder von Grund auf neu erstellt werden. Außerdem gibt es im Rahmen der Lösung keine Begrenzung der Größe des OLE-Objekt-Frames.

{{% /alert %}}