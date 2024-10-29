---
title: Arbeitslösung zur Größenänderung von Arbeitsblättern
type: docs
weight: 20
url: /de/php-java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Es wurde festgestellt, dass Excel-Arbeitsblätter, die über Aspose-Komponenten als OLE in eine PowerPoint-Präsentation eingebettet sind, nach der erstmaligen Aktivierung auf einen nicht identifizierbaren Maßstab skaliert werden. Dieses Verhalten führt zu einem erheblichen visuellen Unterschied der Präsentation zwischen dem Zustand vor und nach der Aktivierung des Diagramms. Wir haben dieses Problem detailliert untersucht und die Lösung für dieses Problem gefunden, die in diesem Artikel behandelt wird.

{{% /alert %}} 
## **Hintergrund**
Im [Artikel Hinzufügen von Ole-Rahmen](), haben wir erläutert, wie man einen Ole-Rahmen in einer PowerPoint-Präsentation unter Verwendung von Aspose.Slides für PHP über Java hinzufügt. Um das [Objektänderungsproblem](/slides/de/php-java/object-changed-issue-when-adding-oleobjectframe/) zu berücksichtigen, haben wir das Arbeitsblattbild des ausgewählten Bereichs dem Chart OLE-Objektrahmen zugewiesen. In der Ausgabepräsentation wird das Excel-Diagramm aktiviert, wenn wir auf den OLE-Objektrahmen doppelklicken, der das Arbeitsblattbild anzeigt. Die Endbenutzer können alle gewünschten Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann zur betreffenden Folie zurückkehren, indem sie außerhalb der aktivierten Excel-Arbeitsmappe klicken. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor wird für unterschiedliche Größen des OLE-Objektrahmens und der eingebetteten Excel-Arbeitsmappe unterschiedlich sein.
## **Ursache der Größenänderung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe beim ersten Aktivieren beizubehalten. Andererseits hat der OLE-Objektrahmen seine eigene Größe. Laut Microsoft verhandeln Excel und PowerPoint beim Aktivieren der Excel-Arbeitsmappe über die Größe und stellen sicher, dass sie in den richtigen Proportionen als Teil des Einbettungsvorgangs ist. Basierend auf den Unterschieden in der Fenstergröße von Excel und der Größe / Position des OLE-Objektrahmens findet die Größenänderung statt.
## **Arbeitslösung**
Es gibt zwei mögliche Lösungen, um den Größenänderungseffekt zu vermeiden.* Passen Sie die Größe des Ole-Rahmens in PPT an die Höhe/Breite der gewünschten Anzahl von Zeilen/Spalten im Ole-Rahmen an.* Behalten Sie die Größe des Ole-Rahmens konstant und skalieren Sie die Größe der beteiligten Zeilen/Spalten, um in die ausgewählte Ole-Rahmengröße zu passen.
## **Größe des Ole-Rahmens an die ausgewählten Zeilen/Spalten des Arbeitsblatts anpassen**
In diesem Ansatz lernen wir, wie wir die Größe des Ole-Rahmens der eingebetteten Excel-Arbeitsmappe entsprechend der kumulierten Größe der Anzahl der beteiligten Zeilen und Spalten im Excel-Arbeitsblatt festlegen.
## **Beispiel**
Angenommen, wir haben ein Vorlage-Excel-Blatt definiert und möchten dieses als Ole-Rahmen in die Präsentation einfügen. In diesem Szenario wird die Größe des OLE-Objektrahmens zunächst basierend auf der kumulierten Höhe der Zeilen und der Breite der Spalten der beteiligten Arbeitsmappenzeilen und -spalten berechnet. Danach setzen wir die Größe des Ole-Rahmens auf diesen berechneten Wert. Um die rote **Eingebettetes Objekt**-Nachricht für den Ole-Rahmen in PowerPoint zu vermeiden, erhalten wir außerdem das Bild der gewünschten Teile von Zeilen und Spalten in der Arbeitsmappe und setzen dies als Ole-Rahmenbild ein.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **Höhen der Arbeitsblattzeilen und Breite der Spalten gemäß der Ole-Rahmengröße anpassen**
In diesem Ansatz lernen wir, wie wir die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalte entsprechend der benutzerdefiniert festgelegten Ole-Rahmengröße skalieren.
## **Beispiel**
Angenommen, wir haben ein Vorlage-Excel-Blatt definiert und möchten dieses als Ole-Rahmen in die Präsentation einfügen. In diesem Szenario setzen wir die Größe des Ole-Rahmens und skalieren die Größe der Zeilen und Spalten, die im Ole-Rahmenbereich beteiligt sind. Danach speichern wir die Arbeitsmappe im Stream, um Änderungen zu speichern, und konvertieren sie in ein Byte-Array, um sie im Ole-Rahmen hinzuzufügen. Um die rote **Eingebettetes Objekt**-Nachricht für den Ole-Rahmen in PowerPoint zu vermeiden, erhalten wir außerdem das Bild der gewünschten Teile von Zeilen und Spalten in der Arbeitsmappe und setzen dies als Ole-Rahmenbild ein.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze, um das Problem der Größenänderung von Arbeitsblättern zu beheben. Die Auswahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren auf die gleiche Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage oder von Grund auf neu erstellt werden. Außerdem gibt es keine Begrenzung der Größe des OLE-Objektrahmens in der Lösung.

{{% /alert %}}