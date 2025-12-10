---
title: Actualizar objetos OLE automáticamente usando un complemento de PowerPoint
type: docs
weight: 10
url: /es/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- objeto OLE
- actualizar OLE
- automáticamente
- complemento
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Descubra cómo actualizar automáticamente gráficos y objetos OLE en PowerPoint con un complemento y Aspose.Slides para Java, con código práctico y consejos de optimización."
---

## **Actualizar objetos OLE automáticamente**

Una de las preguntas más frecuentes de los clientes de Aspose.Slides for Java es cómo crear o modificar gráficos editables (u otros objetos OLE) para que se actualicen automáticamente al abrir la presentación. Desafortunadamente, PowerPoint no admite macros automáticas de la misma manera que Excel y Word. Las únicas macros disponibles son `Auto_Open` y `Auto_Close`, y solo se ejecutan automáticamente desde un complemento. Este breve consejo técnico muestra cómo lograrlo.

Primero, existen varios complementos gratuitos que añaden la función de macro Auto_Open a PowerPoint, por ejemplo [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) y [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Después de instalar uno de estos complementos, simplemente añada la macro `Auto_Open()` (o `OnPresentationOpen()` si está usando Event Generator) a su presentación plantilla como se muestra a continuación:
```java
// Recorrer cada diapositiva en la presentación.
for (var oSlide : ActivePresentation.Slides) {
    // Recorrer todas las formas en la diapositiva actual.
    for (var oShape : oSlide.Shapes) {
        // Verificar si la forma es un objeto OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Objeto OLE encontrado. Obtener su referencia y luego actualizarlo.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Ahora, cerrar el programa servidor OLE.
            // Esto libera memoria y previene cualquier problema.
            // Además, establecer oObject a Nothing para liberar el objeto.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


Cualquier cambio realizado en los objetos OLE con Aspose.Slides for Java se actualizará automáticamente cuando PowerPoint abra la presentación. Si tiene muchos objetos OLE y no desea actualizarlos todos, simplemente añada una etiqueta personalizada a las formas que necesita procesar y verifíquela en la macro.