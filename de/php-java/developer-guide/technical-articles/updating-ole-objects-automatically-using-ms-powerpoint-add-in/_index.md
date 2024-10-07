---
title: Automatisches Aktualisieren von OLE-Objekten mit dem MS PowerPoint Add-In
type: docs
weight: 10
url: /php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Über das automatische Aktualisieren von OLE-Objekten**
Eine der häufigsten Fragen, die von den Kunden von Aspose.Slides gestellt wird, ist, wie man bearbeitbare Diagramme oder andere OLE-Objekte erstellen oder ändern kann, sodass sie beim Öffnen der Präsentation automatisch aktualisiert werden. Leider unterstützt PowerPoint keine automatischen Makros, die in Excel und Word verfügbar sind. Die einzigen verfügbaren sind die Auto_Open- und Auto_Close-Makros. Diese laufen jedoch nur automatisch aus einem Add-In. Dieser kurze technische Tipp zeigt, wie man das erreicht.

Zunächst stehen mehrere Freeware-Add-Ins zur Verfügung, die die Auto_Open-Makrofunktion zu PowerPoint hinzufügen, zum Beispiel [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) und [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Nachdem Sie ein solches Add-In installiert haben, fügen Sie einfach das Auto_Open() Makro (OnPresentationOpen() im Fall von "Event Generator") zu Ihrer Vorlage-Präsentation hinzu, wie unten gezeigt:

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}





{{% alert color="primary" %}} 

Änderungen, die an OLE-Objekten mit Aspose.Slides vorgenommen werden, werden automatisch aktualisiert, wenn PowerPoint die Präsentation öffnet. Wenn Sie viele OLE-Objekte in einer Präsentation haben und nicht alle aktualisieren möchten, fügen Sie einfach ein benutzerdefiniertes Tag zu den Formen hinzu, die Sie verarbeiten müssen, und überprüfen Sie es im Makro.

{{% /alert %}}