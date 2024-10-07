---
title: Aktualisierung von OLE-Objekten automatisch mit dem MS PowerPoint Add-In
type: docs
weight: 10
url: /java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Über die automatische Aktualisierung von OLE-Objekten**
Eine der häufigsten Fragen, die von den Aspose.Slides-Kunden gestellt werden, ist, wie man bearbeitbare Diagramme oder andere OLE-Objekte erstellt oder ändert und sicherstellt, dass diese automatisch aktualisiert werden, wenn die Präsentation geöffnet wird. Leider unterstützt PowerPoint keine automatischen Makros, die in Excel und Word verfügbar sind. Die einzigen verfügbaren Makros sind die Auto_Open- und Auto_Close-Makros. Diese werden jedoch nur automatisch von einem Add-In ausgeführt. Dieser kurze technische Hinweis zeigt, wie man das erreicht.

Zunächst gibt es mehrere Freeware-Add-Ins, die die Auto_Open-Makrofunktion zu PowerPoint hinzufügen, zum Beispiel [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) und [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Nach der Installation eines solchen Add-Ins fügen Sie einfach das Auto_Open() Makro (OnPresentationOpen() im Fall von "Event Generator") zu Ihrer Vorlage-Präsentation hinzu, wie unten gezeigt:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}



{{% alert color="primary" %}} 

Änderungen an OLE-Objekten mit Aspose.Slides werden automatisch aktualisiert, wenn PowerPoint die Präsentation öffnet. Wenn Sie viele OLE-Objekte in einer Präsentation haben und nicht alle aktualisieren möchten, fügen Sie einfach ein benutzerdefiniertes Tag zu den Formen hinzu, die Sie verarbeiten möchten, und überprüfen Sie es im Makro.

{{% /alert %}}