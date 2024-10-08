---
title: Erstellen einer PowerPoint-Präsentation mit Java
linktitle: Präsentation erstellen
type: docs
weight: 10
url: /de/androidjava/create-presentation/
keywords: ppt java erstellen, ppt präsentiation erstellen, pptx java erstellen
description: Erfahren Sie, wie Sie PowerPoint-Präsentationen, z.B. PPT, PPTX, mit Java von Grund auf erstellen.
---

## **PowerPoint-Präsentation erstellen**
Um eine einfache, gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, folgen Sie bitte den folgenden Schritten:

1. Erstellen Sie eine Instanz der Präsentationsklasse.
1. Holen Sie sich die Referenz einer Folie, indem Sie ihren Index verwenden.
1. Fügen Sie eine AutoShape des Linientypen mit der Methode addAutoShape hinzu, die vom Shapes-Objekt bereitgestellt wird.
1. Schreiben Sie die modifizierte Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir eine Linie zur ersten Folie der Präsentation hinzugefügt.

```java
// Instanziieren Sie ein Presentation-Objekt, das eine Präsentationsdatei darstellt
Presentation pres = new Presentation();
try {
    // Holen Sie sich die erste Folie
    ISlide slide = pres.getSlides().get_Item(0);

    // Fügen Sie eine AutoShape vom Typ Linie hinzu
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```