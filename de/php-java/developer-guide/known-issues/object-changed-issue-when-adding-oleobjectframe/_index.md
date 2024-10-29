---
title: Objektänderungsproblem beim Hinzufügen von OleObjectFrame
type: docs
weight: 10
url: /de/php-java/object-changed-issue-when-adding-oleobjectframe/
---

## **Problemstellung**
Wenn Entwickler ein **OleObjectFrame** zu ihren Folien mithilfe von Aspose.Slides für PHP über Java hinzufügen, wird eine **Objekt geändert**-Nachricht auf der Ausgabefolie anstelle des **OLE-Objekts** angezeigt. Die meisten Kunden von Aspose.Slides für PHP über Java denken, dass es sich um einen Fehler oder ein Problem in Aspose.Slides für PHP über Java handelt.
## **Kritische Analyse und Erklärung**
Zunächst ist es wichtig zu wissen, dass die **Objekt geändert**-Nachricht, die von Aspose.Slides für PHP über Java nach dem Hinzufügen eines **OleObjectFrame** in die Folie angezeigt wird, **KEIN** Fehler oder Bug in Aspose.Slides für PHP über Java ist. Es ist lediglich eine Information oder Nachricht, um die Benutzer zu benachrichtigen, dass das Objekt geändert wurde und das Bild aktualisiert werden sollte.

Wenn Sie beispielsweise ein **Microsoft Excel-Diagramm** als **OleObjectFrame** zu Ihrer Folie hinzufügen (für weitere Details und Codebeispiele zum Hinzufügen von **OleObjectFrame** zu Ihrer Folie, [hier klicken](/slides/de/php-java/adding-frame-to-the-slide/)) und dann die Präsentationsdatei mit MS PowerPoint öffnen, sieht die Folie (auf der das **OLE-Objekt** hinzugefügt wurde) so aus:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Abbildung**: Folie, die die **Objekt geändert**-Nachricht anzeigt, nachdem das **OLE-Objekt** hinzugefügt wurde

Das ist kein Fehler, und Ihr OLE-Objekt wurde weiterhin zur Folie hinzugefügt. Wenn Sie es testen möchten, dann **Doppelklicken** Sie auf die **Objekt geändert**-Nachricht oder **Rechtsklicken** Sie darauf und wählen Sie die Option **Arbeitsblattobjekt -> Bearbeiten** aus, wie in der Abbildung unten gezeigt:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Abbildung**: Auswahl der **Bearbeiten**-Option, um das **OLE-Objekt** zu bearbeiten

Nachdem Sie die **Bearbeiten**-Option des Kontextmenüs ausgewählt haben, werden Sie sehen, dass das **Eingebettete OLE-Objekt** in bearbeitbarer Form sichtbar wird, wie unten gezeigt:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Abbildung**: **OLE-Objekt** in bearbeitbarer Form

Sie können die **Objekt geändert**-Nachricht immer noch auf der Folie im **Linken Bereich** von MS PowerPoint sehen, der Folienvorschauen anzeigt. Sobald Sie auf das **OLE-Objekt** klicken, sehen Sie, dass sich auch die Folienvorschau ändert und die **Geänderte Objekt**-Nachricht durch das Bild des **OLE-Objekts** ersetzt wird, wie unten gezeigt:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Abbildung**: Aktualisierung des **OLE-Objekt**-Bildes

Jetzt sollten Sie Ihre Präsentationsdatei mit MS PowerPoint **Speichern**, damit das Bild des **OLE-Objekts** aktualisiert wird. Sobald Sie Ihre Präsentation speichern und erneut mit MS PowerPoint öffnen, werden Sie sehen, dass keine **Objekt geändert**-Nachricht mehr vorhanden ist.
## **Weitere Lösungen**
In der obigen kritischen Analyse haben wir gezeigt, dass das Bild des **OLE-Objekts** aktualisiert werden kann, indem die Präsentationsdatei in MS PowerPoint geöffnet und dann gespeichert wird. Es gibt jedoch zwei weitere Lösungen, um mit der **Objekt geändert**-Nachricht umzugehen.
## **1. Lösung: Ersetzen der Objekt geändert-Nachricht durch ein Bild**
Wenn Ihnen die **Objekt geändert**-Nachricht nicht gefällt, können Sie diese Nachricht auch durch Ihr eigenes Bild ersetzen. Sie können ein beliebiges gewünschtes Bild in Ihre Präsentation hinzufügen und dann die Id dieses hinzugefügten Bildes verwenden, um die **Objekt geändert**-Nachricht zu ersetzen.

Um dies zu erreichen, können Sie diese wenigen Zeilen Code in Ihrer Anwendung hinzufügen, nachdem Sie **OleObjectFrame** zu Ihrer Folie hinzugefügt haben.
## **Beispiel**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

Nachdem Sie die obigen Zeilen in Ihre Anwendung hinzugefügt haben, würde die resultierende Folie mit **OleObjectFrame** so aussehen:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Abbildung**: **Objekt geändert**-Nachricht durch ein Bild ersetzt
## **2. Lösung: Erstellen eines Add-Ons für MS PowerPoint**
Sie können auch versuchen, ein Add-On für MS PowerPoint zu erstellen, das alle **OLE-Objekte** aktualisiert, wenn Sie die Präsentation in MS PowerPoint öffnen.