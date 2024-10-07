---
title: Erstellen Sie eine PowerPoint-Präsentation mit Java
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /java/create-presentation/
keywords: ppt java erstellen, ppt präsentation erstellen, pptx java erstellen
description: Lernen Sie, wie Sie PowerPoint-Präsentationen wie PPT, PPTX von Grund auf mit Java erstellen können.
---

## **PowerPoint-Präsentation erstellen**
Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Erhalten Sie die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape vom Typ Linie mit der addAutoShape-Methode hinzu, die vom Shapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```java
// Erstellen Sie ein Präsentationsobjekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine Autoshape vom Typ Linie hinzu
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```