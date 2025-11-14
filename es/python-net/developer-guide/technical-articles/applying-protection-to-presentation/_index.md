---
title: Aplicando Protección a la Presentación
type: docs
weight: 70
url: /es/python-net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Un uso común de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint 2007 (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de la aplicación que utiliza Aspose.Slides de esta manera acceden a las presentaciones generadas. Protegerlas de la edición es una preocupación común. Es importante que las presentaciones autogeneradas mantengan su formato y contenido originales.

Este artículo explica cómo [se construyen las presentaciones y las diapositivas](/slides/es/python-net/applying-protection-to-presentation/) y cómo Aspose.Slides para Python a través de .NET puede [aplicar protección a](/slides/es/python-net/applying-protection-to-presentation/), y luego [eliminarla de](/slides/es/python-net/applying-protection-to-presentation/) una presentación. Esta función es única de Aspose.Slides y, en el momento de escribir esto, no está disponible en Microsoft PowerPoint. Proporciona a los desarrolladores una forma de controlar cómo se utilizan las presentaciones que sus aplicaciones crean.

{{% /alert %}} 
## **Composición de una Diapositiva**
Una diapositiva PPTX está compuesta por varios componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y los diversos otros elementos disponibles para construir una presentación.

En Aspose.Slides para Python a través de .NET, cada elemento de una diapositiva se convierte en un objeto Shape. En otras palabras, cada elemento en la diapositiva es un objeto Shape o un objeto derivado del objeto Shape.

La estructura de PPTX es compleja, por lo que a diferencia de PPT, donde se puede utilizar un bloqueo genérico para todo tipo de formas, hay diferentes tipos de bloqueos para diferentes tipos de formas. La clase BaseShapeLock es la clase de bloqueo genérica de PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides para Python a través de .NET para PPTX.

- AutoShapeLock bloquea formas automáticas.
- ConnectorLock bloquea formas conectores.
- GraphicalObjectLock bloquea objetos gráficos.
- GroupshapeLock bloquea formas de grupo.
- PictureFrameLock bloquea marcos de imagen.

Cualquier acción realizada en todos los objetos Shape en un objeto Presentation se aplica a toda la presentación.
## **Aplicando y Eliminando Protección**
Aplicar protección garantiza que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de una presentación.
### **Aplicando Protección a Formas PPTX**
Aspose.Slides para Python a través de .NET proporciona la clase Shape para manejar una forma en la diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo de forma asociada para protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (a través de clics del ratón u otros métodos de selección) y no se puedan mover o redimensionar.

Los fragmentos de código que siguen aplican protección a todos los tipos de formas en una presentación.

```py
import aspose.slides as slides

#Instanciar la clase Presentation que representa un archivo PPTX
with slides.Presentation(path + "RectPicFrame.pptx") as pres:
    #ISlide objeto para acceder a las diapositivas en la presentación
    slide = pres.slides[0]

    #Recorriendo todas las diapositivas en la presentación
    for slide in pres.slides:
        for shape in slide.shapes:
            #si la forma es automática
            if type(shape) is slides.AutoShape:
                auto_shape_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                auto_shape_lock.position_locked = True
                auto_shape_lock.select_locked = True
                auto_shape_lock.size_locked = True

            #si la forma es un grupo
            elif type(shape) is slides.GroupShape:
                group_shape_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                group_shape_lock.grouping_locked = True
                group_shape_lock.position_locked = True
                group_shape_lock.select_locked = True
                group_shape_lock.size_locked = True

            #si la forma es un conector
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                connector_lock.position_move = True
                connector_lock.select_locked = True
                connector_lock.size_locked = True
            #si la forma es un marco de imagen
            elif type(shape) is slides.PictureFrame:
                #Casting al marco de imagen y obteniendo el bloqueo del marco de imagen
                picture_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                picture_lock.position_locked = True
                picture_lock.select_locked = True
                picture_lock.size_locked = True

    #Guardar el archivo de presentación
    pres.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```


### **Eliminando Protección**
La protección aplicada usando Aspose.Slides para Python a través de .NET solo se puede eliminar con Aspose.Slides para Python a través de .NET. Para desbloquear una forma, establezca el valor del bloqueo aplicado en falso. El fragmento de código que sigue muestra cómo desbloquear formas en una presentación bloqueada.

```py
import aspose.slides as slides

#Abrir la presentación deseada
with slides.Presentation("ProtectedSample.pptx") as pres:
    for slide in pres.slides:
        for shape in slide.shapes:
            
            if type(shape) is slides.AutoShape: 
                auto_shape_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                auto_shape_lock.position_locked = False
                auto_shape_lock.select_locked = False
                auto_shape_lock.size_locked = False
            
            elif type(shape) is slides.GroupShape:  
                group_shape_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                group_shape_lock.grouping_locked = False
                group_shape_lock.position_locked = False
                group_shape_lock.select_locked = False
                group_shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                connector_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                connector_lock.position_move = False
                connector_lock.select_locked = False
                connector_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                picture_lock = shape.shape_lock

                #Aplicando bloqueos a las formas
                picture_lock.position_locked = False
                picture_lock.select_locked = False
                picture_lock.size_locked = False
    #Guardar el archivo de presentación
    pres.save("RemoveProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```



### **Resumen**
{{% alert color="primary" %}} 

Aspose.Slides proporciona una serie de opciones para aplicar protección a las formas en una presentación. Es posible bloquear una forma particular, o recorrer todas las formas en una presentación y bloquear todas ellas para efectivamente bloquear la presentación.

Solo Aspose.Slides para Python a través de .NET puede eliminar la protección de una presentación que ha protegido previamente. Elimine la protección estableciendo el valor de un bloqueo en falso.

{{% /alert %}} 