---
title: Flash
type: docs
weight: 10
url: /es/java/flash/
description: Extraer objetos Flash de presentaciones de PowerPoint utilizando Java
---

## **Extraer objetos Flash de la presentación**

Aspose.Slides para Java proporciona una funcionalidad para extraer objetos flash de una presentación. Puedes acceder al control flash por nombre y extraerlo de la presentación e incluir almacenar datos del objeto SWF.

```java
// Instanciar la clase Presentation que representa el PPTX
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