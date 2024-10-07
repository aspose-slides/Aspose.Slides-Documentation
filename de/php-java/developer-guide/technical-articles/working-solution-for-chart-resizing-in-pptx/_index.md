---
title: Funktionierende Lösung für die Größenänderung von Diagrammen in PPTX
type: docs
weight: 40
url: /php-java/funktionierende-lösung-für-die-größenänderung-von-diagrammen-in-pptx/
---

{{% alert color="primary" %}} 

Es wurde festgestellt, dass in eine PowerPoint-Präsentation eingebettete Excel-Diagramme als OLE über Aspose-Komponenten beim ersten Aktivieren auf einen unbekannten Maßstab skaliert werden. Dieses Verhalten verursacht einen erheblichen visuellen Unterschied der Präsentation zwischen den Zuständen vor und nach der Diagrammaktivierung. Das Aspose-Team hat gemeinsam mit dem Microsoft-Team dieses Problem im Detail untersucht und eine Lösung gefunden. Dieser Artikel behandelt die Ursachen und die Lösung für dieses Problem.

{{% /alert %}} 
## **Hintergrund**
Im [vorherigen Artikel](/slides/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) haben wir erklärt, wie man mithilfe von Aspose.Cells für Java ein Excel-Diagramm erstellt und dieses Diagramm über Aspose.Slides für PHP mit Java in eine PowerPoint-Präsentation einfügt. Um das [Problem mit der Objektänderung](/slides/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) zu berücksichtigen, haben wir das Diagrammbild dem OLE-Objektrahmen zugewiesen. In der Ausgabpräsentation wird das Excel-Diagramm aktiviert, wenn wir auf den OLE-Objektrahmen doppelklicken, der das Diagrammbild anzeigt. Die Endbenutzer können gewünschte Änderungen in der aktiven Excel-Arbeitsmappe vornehmen und dann zum betreffenden Slide zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zum Slide zurückkehrt. Der Skalierungsfaktor ist für verschiedene Größen des OLE-Objektrahmens und der eingebetteten Excel-Arbeitsmappe unterschiedlich.
## **Ursache für die Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe beim ersten Aktivieren beizubehalten. Andererseits hat der OLE-Objektrahmen seine eigene Größe. Laut Microsoft wird beim Aktivieren der Excel-Arbeitsmappe die Größe zwischen Excel und PowerPoint ausgehandelt, um sicherzustellen, dass sie im richtigen Verhältnis als Teil des Einbettungsvorgangs ist. Basierend auf den Unterschieden in der Größe und Position des Excel-Fensters und des OLE-Objektrahmens erfolgt die Größenänderung.
## **Funktionierende Lösung**
Es gibt zwei mögliche Szenarien für die Erstellung der PowerPoint-Präsentationen mit Aspose.Slides für PHP über Java.**Szenario 1:** Erstellen Sie die Präsentation basierend auf einer vorhandenen Vorlage.**Szenario 2:** Erstellen Sie die Präsentation von Grund auf. Die Lösung, die wir hier bereitstellen, gilt für beide Szenarien. Die Basis aller Lösungsansätze wird dieselbe sein. Das heißt: **Die Fenstergröße des eingebetteten OLE-Objekts sollte die gleiche sein wie die des OLE-Objektrahmens in der PowerPoint-Folie.** Nun werden wir die beiden Ansätze der Lösung diskutieren.
## **Erster Ansatz**
In diesem Ansatz lernen wir, wie wir die Fenstergröße der eingebetteten Excel-Arbeitsmappe gleich der Größe des OLE-Objektrahmens in der PowerPoint-Folie einstellen.**Szenario 1**Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Angenommen, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Rahmen platzieren möchten, der eine eingebettete Excel-Arbeitsmappe enthält. In diesem Szenario wird die Größe des OLE-Objektrahmens als vordefiniert betrachtet (was die Größe der Form an Index 2 in der Vorlage ist). Alles, was wir tun müssen, ist, die Fenstergröße der Arbeitsmappe gleich der Größe der Form einzustellen. Der folgende Codeausschnitt dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}


**Szenario 2
**Angenommen, wir möchten eine Präsentation von Grund auf erstellen und einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe wünschen. Im folgenden Codeausschnitt haben wir einen OLE-Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie bei x-Achse=0,5 Zoll und y-Achse=1 Zoll erstellt. Außerdem haben wir die entsprechende Fenstergröße der Excel-Arbeitsmappe festgelegt, d.h.: Höhe 4 Zoll und Breite 9,5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}


## **Zweiter Ansatz**
In diesem Ansatz lernen wir, wie wir die Größe des Diagramms, das in der eingebetteten Excel-Arbeitsmappe vorhanden ist, gleich der Größe des OLE-Objektrahmens in der PowerPoint-Folie einstellen. Dieser Ansatz ist nützlich, wenn die Größe des Diagramms im Voraus bekannt ist und sich niemals ändern wird.**Szenario 1**Angenommen, wir haben eine Vorlage definiert und möchten die Präsentationen basierend auf dieser Vorlage erstellen. Angenommen, es gibt eine Form an Index 2 in der Vorlage, wo wir einen OLE-Rahmen platzieren möchten, der eine eingebettete Excel-Arbeitsmappe enthält. In diesem Szenario wird die Größe des OLE-Rahmens als vordefiniert betrachtet (was die Größe der Form an Index 2 in der Vorlage ist). Alles, was wir tun müssen, ist, die Größe des Diagramms in der Arbeitsmappe gleich der Größe der Form einzustellen. Der folgende Codeausschnitt dient diesem Zweck:

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Szenario 2**: Angenommen, wir möchten eine Präsentation von Grund auf erstellen und einen OLE-Objektrahmen beliebiger Größe mit einer eingebetteten Excel-Arbeitsmappe wünschen. Im folgenden Codeausschnitt haben wir einen OLE-Objektrahmen mit einer Höhe von 4 Zoll und einer Breite von 9,5 Zoll in der Folie bei x-Achse=0,5 Zoll und y-Achse=1 Zoll erstellt. Darüber hinaus haben wir die entsprechende Diagrammgröße festgelegt, d.h.: Höhe 4 Zoll und Breite 9,5 Zoll.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze, um das Problem der Größenänderung von Diagrammen zu beheben. Die Auswahl des richtigen Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf die gleiche Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt oder von Grund auf neu erstellt werden. Außerdem gibt es keine Begrenzung der Größe des OLE-Objektrahmens in der Lösung.

{{% /alert %}}