---
title: Actualización automática de objetos OLE utilizando el complemento de MS PowerPoint
type: docs
weight: 10
url: /net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **Acerca de la actualización automática de objetos OLE**
Una de las preguntas más frecuentes de los clientes de Aspose.Slides para .NET es cómo crear o cambiar gráficos editables u otros objetos OLE y hacer que se actualicen automáticamente al abrir la presentación. Desafortunadamente, PowerPoint no admite macros automáticas, que están disponibles en Excel y Word. Las únicas disponibles son las macros Auto_Open y Auto_Close. Sin embargo, estas solo se ejecutan automáticamente desde un complemento. Este breve consejo técnico muestra cómo lograrlo.

Primero, hay varios complementos gratuitos que añaden la funcionalidad de la macro Auto_Open a PowerPoint, como [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) y [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html). 

Después de instalar dicho complemento, simplemente añade la macro Auto_Open() (OnPresentationOpen() en el caso de "Event Generator") a tu presentación de plantilla como se muestra a continuación: 

```c#
public void Auto_Open()
{
    Shape oShape;
    Slide oSlide;
    object oGraph;

    // Recorrer cada diapositiva en la presentación.
    foreach (var oSlide in ActivePresentation.Slides)
    {

        // Recorrer todas las formas en la diapositiva actual.
        foreach (var oShape in oSlide.Shapes)
        {

            // Verificar si la forma es un objeto OLE.
            if (oShape.Type == msoEmbeddedOLEObject)
            {

                // Se encontró un objeto OLE; obtener la referencia del objeto y luego actualizar.
                oObject = oShape.OLEFormat.Object;
                oObject.Application.Update();

                // Ahora, salir del programa del servidor OLE. Esto libera
                // memoria y previene cualquier problema. Además, establece oObject igual
                // a Nothing para liberar el objeto.
                oObject.Application.Quit();
                oObject = null;
            }
        }
    }
}
```



{{% alert color="primary" %}} 

Cualquier cambio realizado en objetos OLE con Aspose.Slides para .NET se actualizará automáticamente cuando PowerPoint abra la presentación. Si tienes muchos objetos OLE en una presentación y no quieres actualizarlos todos, simplemente añade una etiqueta personalizada a las formas que necesitas procesar y verifícala en la macro. 

{{% /alert %}}