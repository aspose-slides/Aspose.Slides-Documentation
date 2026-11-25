---
title: Restringir la edición de presentaciones con bloqueos de forma en .NET
linktitle: Restringir la edición de presentaciones
type: docs
weight: 70
url: /es/net/applying-protection-to-presentation/
keywords:
- evitar ediciones
- proteger contra edición
- bloquear forma
- bloquear posición
- bloquear selección
- bloquear cambio de tamaño
- bloquear agrupación
- PowerPoint
- PPTX
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a bloquear y desbloquear formas en presentaciones PPTX con Aspose.Slides para .NET para restringir la selección, el movimiento, el cambio de tamaño y la agrupación."
---
## **Antecedentes**

Un uso común de Aspose.Slides for .NET es crear, actualizar y guardar presentaciones PowerPoint (PPTX) como parte de un flujo de trabajo automatizado. Cuando los usuarios reciben estas presentaciones, restringir los cambios en las formas puede ayudar a preservar el diseño y el contenido previsto.

Este artículo explica cómo se organizan las formas en las diapositivas y cómo aplicar y eliminar bloqueos de forma en una presentación PPTX. Estos bloqueos le permiten restringir operaciones de edición específicas en formas individuales.

## **Composición de una diapositiva**

Una diapositiva de presentación se compone de componentes como autoshapes, tablas, objetos OLE, formas agrupadas, marcos de imagen, marcos de vídeo, conectores y otros elementos utilizados para crear una presentación. En Aspose.Slides for .NET, cada elemento en una diapositiva está representado por un objeto que implementa la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) o hereda de una clase que lo hace.

Los distintos tipos de forma exponen diferentes opciones de bloqueo. La interfaz [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) es la interfaz base para los bloqueos de forma. Aspose.Slides for .NET proporciona las siguientes interfaces de bloqueo:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) bloquea autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bloquea formas de conector.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) bloquea objetos gráficos.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) bloquea formas agrupadas.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) bloquea marcos de imagen.  

Para aplicar bloqueos en una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), itere a través de sus diapositivas y establezca los bloqueos apropiados en cada forma compatible.

## **Aplicar y eliminar protección**

Los editores de presentaciones compatibles utilizan bloqueos de forma para restringir operaciones de edición individuales. El cifrado de archivos y la protección de escritura a nivel de documento son configuraciones de [configuraciones de protección de presentación](/slides/es/net/password-protected-presentation/) independientes.

### **Aplicar protección a formas PPTX**

Aspose.Slides for .NET proporciona la interfaz [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) para trabajar con formas en una diapositiva.

El ejemplo establece [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/) , [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) y [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) en `true` para autoshapes, con bloqueos equivalentes para formas agrupadas, conectores y marcos de imagen. Los conectores utilizan [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) para movimiento; los grupos también utilizan [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) para restringir la agrupación.

El ejemplo carga una presentación PPTX existente, comprueba las formas en la colección de formas de cada diapositiva y guarda una copia con estas restricciones aplicadas. Las formas fuera de los cuatro tipos manejados se dejan sin cambios. El bucle no recorre las formas secundarias dentro de un grupo.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Eliminar protección**

Para eliminar un bloqueo de forma, establezca su valor en `false`. El siguiente ejemplo carga una presentación con bloqueos de forma y elimina las restricciones de selección, movimiento y redimensionado mediante [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) y [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/). También elimina [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) y guarda una copia de la presentación. Otras configuraciones de bloqueo permanecen sin cambios.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Conservar recorte de imagen**

Coloque una foto llamada `photo.jpg` en el directorio de trabajo. El ejemplo recorta un 12 % desde la izquierda y un 8 % desde la derecha, luego establece [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) en el marco de imagen. Esta bandera restringe recortes adicionales y conserva el recorte existente.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` almacena el bloqueo de recorte como `true`. En PowerPoint, el comando **Crop** está deshabilitado cuando la foto está seleccionada.

### **Mantener diagramas agrupados**

El ejemplo agrupa un rectángulo y una flecha, luego establece [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) en el propio grupo para mantener los componentes del diagrama juntos. Otras ediciones, como mover el grupo o cambiar el relleno de un componente, siguen estando disponibles.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` almacena el bloqueo de desagrupación como `true`. En PowerPoint, el comando **Ungroup** está deshabilitado cuando todo el diagrama está seleccionado.

### **Informar bloqueos de forma existentes**

Para revisar una plantilla, ábrala y lea el objeto de bloqueo de cada forma. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) es `true` cuando todas las banderas de ese objeto están desactivadas y `false` cuando al menos una está activada. Un grupo y sus hijos tienen objetos de bloqueo independientes, por lo que inspeccione los hijos incluso cuando el grupo no tenga bloqueos.

Este ejemplo verifica el movimiento para autoshapes, marcos de imagen y grupos, el recorte para imágenes y la desagrupación para grupos. Informa de las banderas que reconoce y marca los tipos de forma que no inspecciona.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Supongamos que la diapositiva 1 de `Sample.pptx` contiene un grupo llamado `Layout` con la desagrupación bloqueada, una imagen llamada `Photo` dentro de él con el recorte bloqueado, y un rectángulo sin bloqueo llamado `Free`. El informe omite `Free` y muestra estas dos líneas:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

El informe lee las banderas de edición almacenadas a nivel de forma sin cambiarlas ni guardar la presentación. La protección de escritura a nivel de documento es una configuración independiente, y la aplicación de cada bandera depende del editor.

### **Conclusión**

Aspose.Slides for .NET le permite restringir operaciones de edición específicas en formas individuales o aplicar las mismas restricciones en todas las diapositivas. Elija los bloqueos compatibles con cada tipo de forma y establezca sus valores en `false` cuando necesite eliminar esas restricciones.

## **Preguntas frecuentes**

**¿Puedo combinar bloqueos de forma y protección con contraseña en la misma presentación?**

Sí. Los bloqueos de forma restringen operaciones de edición específicas, mientras que la [protección con contraseña](/slides/es/net/password-protected-presentation/) puede restringir la apertura o modificación de la presentación. Puede usar ambos en el mismo archivo.

**¿Puedo restringir la edición en diapositivas específicas sin afectar a otras?**

Sí. aplique bloqueos solo a las formas de las diapositivas seleccionadas. Esto no cambia la configuración de bloqueos en otras diapositivas.

**¿Cómo puedo aplicar bloqueos a formas individuales dentro de un grupo?**

Itere a través de la colección [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) del grupo y aplique los bloqueos apropiados a cada forma secundaria. Repita esto para cualquier grupo anidado, siguiendo el recorrido del ejemplo de informe.