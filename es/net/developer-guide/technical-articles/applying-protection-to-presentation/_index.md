---
title: Aplicar Protección a Presentaciones
type: docs
weight: 70
url: /net/applying-protection-to-presentation/
---

{{% alert color="primary" %}} 

Un uso común de Aspose.Slides es crear, actualizar y guardar presentaciones de Microsoft PowerPoint 2007 (PPTX) como parte de un flujo de trabajo automatizado. Los usuarios de la aplicación que utiliza Aspose.Slides de esta manera tienen acceso a las presentaciones generadas. Protegerlas de la edición es una preocupación común. Es importante que las presentaciones generadas automáticamente mantengan su formato y contenido originales.

Este artículo explica cómo [se construyen las presentaciones y diapositivas](/slides/net/applying-protection-to-presentation/) y cómo Aspose.Slides para .NET puede [aplicar protección a](/slides/net/applying-protection-to-presentation/) y luego [eliminarla de](/slides/net/applying-protection-to-presentation/) una presentación. Esta función es exclusiva de Aspose.Slides y, en el momento de escribir, no está disponible en Microsoft PowerPoint. Proporciona a los desarrolladores una forma de controlar cómo se utilizan las presentaciones que sus aplicaciones crean.

{{% /alert %}} 
## **Composición de una Diapositiva**
Una diapositiva PPTX se compone de varios componentes como formas automáticas, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de video, conectores y los diversos otros elementos disponibles para construir una presentación.

En Aspose.Slides para .NET, cada elemento en una diapositiva se convierte en un objeto Shape. En otras palabras, cada elemento en la diapositiva es un objeto Shape o un objeto derivado del objeto Shape.

La estructura de PPTX es compleja, así que a diferencia de PPT, donde se puede usar un bloqueo genérico para todos los tipos de formas, hay diferentes tipos de bloqueos para diferentes tipos de formas. La clase BaseShapeLock es la clase de bloqueo genérica para PPTX. Los siguientes tipos de bloqueos son compatibles en Aspose.Slides para .NET para PPTX.

- AutoShapeLock bloquea formas automáticas.
- ConnectorLock bloquea formas de conector.
- GraphicalObjectLock bloquea objetos gráficos.
- GroupshapeLock bloquea formas agrupadas.
- PictureFrameLock bloquea marcos de imagen.

Cualquier acción realizada en todos los objetos Shape en un objeto Presentation se aplica a toda la presentación.
## **Aplicar y Eliminar Protección**
Aplicar protección asegura que una presentación no pueda ser editada. Es una técnica útil para proteger el contenido de una presentación.
### **Aplicar Protección a Formas PPTX**
Aspose.Slides para .NET proporciona la clase Shape para manejar una forma en la diapositiva.

Como se mencionó anteriormente, cada clase de forma tiene una clase de bloqueo de forma asociada para protección. Este artículo se centra en los bloqueos NoSelect, NoMove y NoResize. Estos bloqueos aseguran que las formas no puedan ser seleccionadas (a través de clics del ratón u otros métodos de selección), y no pueden ser movidas ni redimensionadas.

Los ejemplos de código que siguen aplican protección a todos los tipos de formas en una presentación.

```c#
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pTemplate = new Presentation("RectPicFrame.pptx");
           

//Objeto ISlide para acceder a las diapositivas de la presentación
ISlide slide = pTemplate.Slides[0];

//Objeto IShape para almacenar formas temporales
IShape shape;

//Recorriendo todas las diapositivas de la presentación
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Recorriendo todas las formas en las diapositivas
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //si la forma es una forma automática
        if (shape is IAutoShape)
        {
            //Casting a forma automática y obteniendo el bloqueo de forma automática
            IAutoShape Ashp = shape as IAutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Aplicando bloqueos de formas
            AutoShapeLock.PositionLocked = true;
            AutoShapeLock.SelectLocked = true;
            AutoShapeLock.SizeLocked = true;
        }

        //si la forma es una forma agrupada
        else if (shape is IGroupShape)
        {
            //Casting a forma agrupada y obteniendo el bloqueo de forma agrupada
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Aplicando bloqueos de formas
            groupShapeLock.GroupingLocked = true;
            groupShapeLock.PositionLocked = true;
            groupShapeLock.SelectLocked = true;
            groupShapeLock.SizeLocked = true;
        }

        //si la forma es un conector
        else if (shape is IConnector)
        {
            //Casting a forma de conector y obteniendo el bloqueo de forma de conector
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Aplicando bloqueos de formas
            ConnLock.PositionMove = true;
            ConnLock.SelectLocked = true;
            ConnLock.SizeLocked = true;
        }

        //si la forma es un marco de imagen
        else if (shape is IPictureFrame)
        {
            //Casting a forma de marco de imagen y obteniendo el bloqueo de forma de marco de imagen
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Aplicando bloqueos de formas
            PicLock.PositionLocked = true;
            PicLock.SelectLocked = true;
            PicLock.SizeLocked = true;
        }
    }


}
//Guardando el archivo de presentación
pTemplate.Save("ProtectedSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


### **Eliminar Protección**
La protección aplicada con Aspose.Slides para .NET solo puede ser eliminada con Aspose.Slides para .NET. Para desbloquear una forma, establece el valor del bloqueo aplicado a falso. El ejemplo de código que sigue muestra cómo desbloquear formas en una presentación bloqueada.

```c#
//Abrir la presentación deseada
Presentation pTemplate = new Presentation("ProtectedSample.pptx");

//Objeto ISlide para acceder a las diapositivas de la presentación
ISlide slide = pTemplate.Slides[0];

//Objeto IShape para almacenar formas temporales
IShape shape;

//Recorriendo todas las diapositivas de la presentación
for (int slideCount = 0; slideCount < pTemplate.Slides.Count; slideCount++)
{
    slide = pTemplate.Slides[slideCount];

    //Recorriendo todas las formas en las diapositivas
    for (int count = 0; count < slide.Shapes.Count; count++)
    {
        shape = slide.Shapes[count];

        //si la forma es una forma automática
        if (shape is IAutoShape)
        {
            //Casting a forma automática y obteniendo el bloqueo de forma automática
            IAutoShape Ashp = shape as AutoShape;
            IAutoShapeLock AutoShapeLock = Ashp.ShapeLock;

            //Aplicando bloqueos de formas
            AutoShapeLock.PositionLocked = false;
            AutoShapeLock.SelectLocked = false;
            AutoShapeLock.SizeLocked = false;
        }

        //si la forma es una forma agrupada
        else if (shape is IGroupShape)
        {
            //Casting a forma agrupada y obteniendo el bloqueo de forma agrupada
            IGroupShape Group = shape as IGroupShape;
            IGroupShapeLock groupShapeLock = Group.ShapeLock;

            //Aplicando bloqueos de formas
            groupShapeLock.GroupingLocked = false;
            groupShapeLock.PositionLocked = false;
            groupShapeLock.SelectLocked = false;
            groupShapeLock.SizeLocked = false;
        }

        //si la forma es una forma de conector
        else if (shape is IConnector)
        {
            //Casting a forma de conector y obteniendo el bloqueo de forma de conector
            IConnector Conn = shape as IConnector;
            IConnectorLock ConnLock = Conn.ShapeLock;

            //Aplicando bloqueos de formas
            ConnLock.PositionMove = false;
            ConnLock.SelectLocked = false;
            ConnLock.SizeLocked = false;
        }

        //si la forma es un marco de imagen
        else if (shape is IPictureFrame)
        {
            //Casting a forma de marco de imagen y obteniendo el bloqueo de forma de marco de imagen
            IPictureFrame Pic = shape as IPictureFrame;
            IPictureFrameLock PicLock = Pic.ShapeLock;

            //Aplicando bloqueos de formas
            PicLock.PositionLocked = false;
            PicLock.SelectLocked = false;
            PicLock.SizeLocked = false;
        }
    }

}
//Guardando el archivo de presentación
pTemplate.Save("RemoveProtectionSample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



### **Resumen**
{{% alert color="primary" %}} 

Aspose.Slides proporciona una serie de opciones para aplicar protección a formas en una presentación. Es posible bloquear una forma en particular o recorrer todas las formas en una presentación y bloquear todas efectivamente para bloquear la presentación.

Solo Aspose.Slides para .NET puede eliminar la protección de una presentación que ha protegido anteriormente. Eliminar la protección estableciendo el valor de un bloqueo a falso.

{{% /alert %}} 