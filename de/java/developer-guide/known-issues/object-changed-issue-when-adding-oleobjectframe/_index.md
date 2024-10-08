---
title: Objekt geändert Problem beim Hinzufügen von OleObjectFrame
type: docs
weight: 10
url: /de/java/object-changed-issue-when-adding-oleobjectframe/
---

## **Problemstellung**
Wenn Entwickler ein **OleObjectFrame** zu ihren Folien mit Aspose.Slides für Java hinzufügen, wird anstelle des **OLE-Objekts** eine **Objekt geändert**-Nachricht auf der Ausgabefolie angezeigt. Die meisten der Kunden von Aspose.Slides für Java denken, dass es sich um einen Fehler oder ein Bug in Aspose.Slides für Java handelt.
## **Kritische Analyse und Erklärung**
Zuerst ist es wichtig zu wissen, dass die von Aspose.Slides für Java angezeigte **Objekt geändert**-Nachricht nach dem Hinzufügen von **OleObjectFrame** in die Folie **KEIN** Fehler oder Bug in Aspose.Slides für Java ist. Es ist nur eine Information oder Nachricht, die die Benutzer darüber informiert, dass das Objekt geändert wurde und das Bild aktualisiert werden sollte.

Wenn Sie beispielsweise ein **Microsoft Excel-Diagramm** als **OleObjectFrame** zu Ihrer Folie hinzufügen (für weitere Details und Codebeispiele zum Hinzufügen von **OleObjectFrame** zu Ihrer Folie, [klicken Sie hier](/slides/de/java/adding-frame-to-the-slide/)) und dann die Präsentationsdatei mit MS PowerPoint öffnen, würde die Folie (auf der das **OLE-Objekt** hinzugefügt wurde) so aussehen:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_1.png)

**Abbildung**: Folie zeigt die **Objekt geändert**-Nachricht nach dem Hinzufügen des **OLE-Objekts**

Dies ist kein Fehler, und Ihr OLE-Objekt ist weiterhin in die Folie eingefügt. Wenn Sie dies testen möchten, **Doppelklicken** Sie auf die **Objekt geändert**-Nachricht oder **Rechtsklicken** Sie darauf und wählen Sie die Option **Arbeitsblattobjekt -> Bearbeiten** wie unten in der Abbildung gezeigt:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_2.png)

**Abbildung**: Auswahl der **Bearbeiten**-Option, um das **OLE-Objekt** zu bearbeiten

Nachdem Sie die **Bearbeiten**-Option des Popup-Menüs ausgewählt haben, werden Sie sehen, dass das **Eingebettete OLE-Objekt** in bearbeitbarer Form sichtbar wird, wie unten gezeigt:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_3.png)

**Abbildung**: **OLE-Objekt** in bearbeitbarer Form

Sie können immer noch die **Objekt geändert**-Nachricht auf der Folie im **Linken Bereich** von MS PowerPoint sehen, der die Folienvorschauen anzeigt. Sobald Sie auf das **OLE-Objekt** klicken, werden Sie sehen, dass die Folienvorschau ebenfalls geändert wird und die **Geänderte Objekt**-Nachricht durch das Bild des **OLE-Objekts** ersetzt wird, wie unten gezeigt:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_4.png)

**Abbildung**: Aktualisierung des **OLE-Objekt**-Bildes

Jetzt sollten Sie Ihre Präsentationsdatei mit MS PowerPoint **speichern**, damit das Bild des **OLE-Objekts** aktualisiert wird. Nachdem Sie Ihre Präsentation gespeichert und erneut in MS PowerPoint geöffnet haben, werden Sie sehen, dass keine **Objekt geändert**-Nachricht mehr vorhanden ist.
## **Weitere Lösungen**
In der obigen kritischen Analyse haben wir demonstriert, dass das Bild des **OLE-Objekts** aktualisiert werden kann, indem die Präsentationsdatei in MS PowerPoint geöffnet und anschließend gespeichert wird. Es gibt jedoch zwei weitere Lösungen, um mit der **Objekt geändert**-Nachricht umzugehen.
## **1. Lösung: Ersetzen der Objekt geändert Nachricht durch ein Bild**
Wenn Ihnen die **Objekt geändert**-Nachricht nicht gefällt, können Sie diese Nachricht auch durch Ihr eigenes Bild ersetzen. Sie können jedes gewünschte Bild zu Ihrer Präsentation hinzufügen und dann die ID dieses hinzugefügten Bildes verwenden, um die **Objekt geändert**-Nachricht zu ersetzen.

Um dies zu erreichen, können Sie diese wenigen Zeilen Code in Ihre Anwendung hinzufügen, nachdem Sie **OleObjectFrame** zu Ihrer Folie hinzugefügt haben.
## **Beispiel**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplacingObjectChangedMessageWithAnImage-ReplacingObjectChangedMessageWithAnImage.java" >}}

Nachdem Sie die obigen Zeilen in Ihre Anwendung eingefügt haben, würde die resultierende Folie mit dem **OleObjectFrame** so aussehen:

![todo:image_alt_text](object-changed-issue-when-adding-oleobjectframe_5.png)

**Abbildung**: **Objekt geändert**-Nachricht durch ein Bild ersetzt
## **2. Lösung: Erstellen eines Add-Ons für MS PowerPoint**
Sie können auch versuchen, ein Add-On für MS PowerPoint zu erstellen, das alle **OLE-Objekte** aktualisiert, wenn Sie die Präsentation in MS PowerPoint öffnen.