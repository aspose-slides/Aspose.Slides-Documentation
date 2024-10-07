---
title: Funktionierende Lösung für die Größenanpassung von Arbeitsblättern
type: docs
weight: 20
url: /java/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Es wurde beobachtet, dass in eine PowerPoint-Präsentation eingebettete Excel-Arbeitsblätter als OLE über Aspose-Komponenten nach der erstmaligen Aktivierung auf einen nicht identifizierten Maßstab skaliert werden. Dieses Verhalten führt zu einem erheblichen visuellen Unterschied zwischen der Präsentation vor und nach der Aktivierung des Diagramms. Wir haben dieses Problem im Detail untersucht und die Lösung für dieses Problem gefunden, die in diesem Artikel behandelt wird.

{{% /alert %}} 
## **Hintergrund**
Im [Artikel Hinzufügen von Ole-Frames]() haben wir erklärt, wie man einen Ole-Frame in einer PowerPoint-Präsentation mit Aspose.Slides für Java hinzufügt. Um das [Problem mit dem Objektänderung](/slides/java/object-changed-issue-when-adding-oleobjectframe/) zu berücksichtigen, haben wir das Arbeitsblattbild des ausgewählten Bereichs dem OLE-Objektrahmen des Diagramms zugewiesen. In der Ausgabepräsentation wird, wenn wir doppelt auf den OLE-Objektrahmen klicken, der das Arbeitsblattbild zeigt, das Excel-Diagramm aktiviert. Die Endbenutzer können beliebige gewünschte Änderungen in der tatsächlichen Excel-Arbeitsmappe vornehmen und dann durch Klicken außerhalb der aktivierten Excel-Arbeitsmappe zur betreffenden Folie zurückkehren. Die Größe des OLE-Objektrahmens ändert sich, wenn der Benutzer zur Folie zurückkehrt. Der Skalierungsfaktor wird für unterschiedliche Größen des OLE-Objektrahmens und der eingebetteten Excel-Arbeitsmappe unterschiedlich sein.
## **Ursache der Größenanpassung**
Da die Excel-Arbeitsmappe ihre eigene Fenstergröße hat, versucht sie, ihre ursprüngliche Größe bei der erstmaligen Aktivierung beizubehalten. Auf der anderen Seite wird der OLE-Objektrahmen seine eigene Größe haben. Laut Microsoft verhandeln bei der Aktivierung der Excel-Arbeitsmappe Excel und PowerPoint die Größe und sorgen dafür, dass sie im richtigen Verhältnis als Teil des Einbettungsbetriebs ist. Basierend auf den Unterschieden in der Fenstergröße von Excel und der Größe / Position des OLE-Objektrahmens erfolgt die Größenanpassung.
## **Funktionierende Lösung**
Es gibt zwei mögliche Lösungen, um den Größenanpassungseffekt zu vermeiden.* Skaliere die Ole-Frame-Größe in PPT, um die Größe in Bezug auf Höhe/Breite der gewünschten Anzahl von Zeilen/Spalten im Ole-Frame zu entsprechen.* Halte die Ole-Frame-Größe konstant und skaliere die Größe der beteiligten Zeilen/Spalten, um in die ausgewählte Ole-Frame-Größe zu passen.
## **Skalieren der Ole-Frame-Größe auf die Größe der ausgewählten Zeilen/Spalten des Arbeitsblatts**
In diesem Ansatz lernen wir, wie man die Ole-Frame-Größe der eingebetteten Excel-Arbeitsmappe entsprechend der kumulierten Größe der beteiligten Zeilen und Spalten im Excel-Arbeitsblatt festlegt.
## **Beispiel**
Angenommen, wir haben ein Vorlagen-Excel-Blatt definiert und wünschen uns, das als Ole-Frame zur Präsentation hinzuzufügen. In diesem Szenario wird die Größe des OLE-Objektrahmens zunächst basierend auf der kumulierten Höhe der Zeilen und der Breite der Spalten der beteiligten Arbeitsmappenzeilen und -spalten berechnet. Dann setzen wir die Größe des Ole-Rahmens auf den berechneten Wert. Um die rote **Eingebettetes Objekt**-Nachricht für den Ole-Rahmen in PowerPoint zu vermeiden, werden wir auch das Bild der gewünschten Bereiche von Zeilen und Spalten in der Arbeitsmappe erfassen und das als Ole-Frame-Bild festlegen.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}






## **Skalieren der Zeilenhöhe und Spaltenbreite des Arbeitsblatts entsprechend der Ole-Frame-Größe**
In diesem Ansatz lernen wir, wie man die Höhen der beteiligten Zeilen und die Breite der beteiligten Spalten gemäß der benutzerdefinierten Ole-Frame-Größe skaliert.
## **Beispiel**
Angenommen, wir haben ein Vorlagen-Excel-Blatt definiert und wünschen uns, das als Ole-Frame zur Präsentation hinzuzufügen. In diesem Szenario werden wir die Größe des Ole-Rahmens festlegen und die Größe der Zeilen und Spalten, die im Ole-Frame-Bereich teilnehmen, skalieren. Dann speichern wir die Arbeitsmappe im Stream, um Änderungen zu speichern und konvertieren sie in ein Byte-Array, um sie im Ole-Rahmen hinzuzufügen. Um die rote **Eingebettetes Objekt**-Nachricht für den Ole-Rahmen in PowerPoint zu vermeiden, werden wir auch das Bild der gewünschten Bereiche von Zeilen und Spalten in der Arbeitsmappe erfassen und das als Ole-Frame-Bild festlegen.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Fazit**
{{% alert color="primary" %}} 

Es gibt zwei Ansätze zur Behebung des Problems mit der Größenanpassung von Arbeitsblättern. Die Wahl des geeigneten Ansatzes hängt von den Anforderungen und dem Anwendungsfall ab. Beide Ansätze funktionieren in der gleichen Weise, unabhängig davon, ob die Präsentationen aus einer Vorlage erstellt werden oder von Grund auf neu erstellt werden. Außerdem gibt es keine Begrenzung für die Größe des OLE-Objektrahmens in der Lösung.

{{% /alert %}}