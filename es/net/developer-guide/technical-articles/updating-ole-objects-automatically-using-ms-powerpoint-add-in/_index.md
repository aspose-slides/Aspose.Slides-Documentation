---
title: Actualizar objetos OLE automáticamente usando un complemento de PowerPoint
type: docs
weight: 10
url: /es/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- objeto OLE
- actualizar OLE
- automáticamente
- complemento
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Descubra cómo actualizar automáticamente gráficos y objetos OLE en PowerPoint con un complemento y Aspose.Slides para .NET, con código práctico y consejos de optimización."
---

## **Actualizar objetos OLE automáticamente**

Una de las preguntas más frecuentes de los clientes de Aspose.Slides para .NET es cómo crear o modificar gráficos editables (u otros objetos OLE) de modo que se actualicen automáticamente al abrir la presentación. Desafortunadamente, PowerPoint no admite macros automáticas de la misma forma que lo hacen Excel y Word. Las únicas macros disponibles son `Auto_Open` y `Auto_Close`, y solo se ejecutan automáticamente desde un complemento. Este breve consejo técnico muestra cómo lograrlo.

Primero, existen varios complementos gratuitos que añaden la funcionalidad de macro Auto_Open a PowerPoint, por ejemplo [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) y [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Después de instalar uno de estos complementos, simplemente añada la macro `Auto_Open()` (o `OnPresentationOpen()` si está utilizando Event Generator) a su presentación plantilla como se muestra a continuación:
```cs
public void Auto_Open()
{
    // Recorrer cada diapositiva en la presentación.
    foreach (var oSlide in ActivePresentation.Slides)
    {
        // Recorrer todas las formas en la diapositiva actual.
        foreach (var oShape in oSlide.Shapes)
        {
            // Verificar si la forma es un objeto OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {
                // Se encontró un objeto OLE. Obtenga su referencia de objeto y luego actualícelo.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Ahora, salga del programa del servidor OLE.
                // Esto libera memoria y evita cualquier problema.
                // Además, establezca oObject a Nothing para liberar el objeto.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```


Cualquier cambio realizado en los objetos OLE con Aspose.Slides para .NET se actualizará automáticamente cuando PowerPoint abra la presentación. Si tiene muchos objetos OLE y no desea actualizarlos todos, simplemente añada una etiqueta personalizada a las formas que necesita procesar y verifíquela en la macro.