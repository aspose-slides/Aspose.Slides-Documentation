---
title: Flash
type: docs
weight: 10
url: /de/androidjava/flash/
description: Extrahiere Flash-Objekte aus einer PowerPoint-Präsentation mit Java
---

## **Flash-Objekte aus der Präsentation extrahieren**

Aspose.Slides für Android über Java bietet eine Funktion zum Extrahieren von Flash-Objekten aus einer Präsentation. Sie können das Flash-Steuerelement nach Name zugreifen und es aus der Präsentation extrahieren sowie die SWF-Objektdaten speichern.

```java
// Instanziiere die Presentation-Klasse, die das PPTX darstellt
Presentation pres = new Presentation();
try {
    IControlCollection controls = pres.getSlides().get_Item(0).getControls();
    Control flashControl = null;
    for (IControl control : controls)
    {
        if (control.getName() == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```