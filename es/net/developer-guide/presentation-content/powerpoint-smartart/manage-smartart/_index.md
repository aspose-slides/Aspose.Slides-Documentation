---
title: Gestionar SmartArt en presentaciones de PowerPoint en .NET
linktitle: Gestionar SmartArt
type: docs
weight: 10
url: /es/net/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama con imágenes
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para .NET utilizando ejemplos de código C# claros que aceleran el diseño y la automatización de diapositivas."
---
## **Resumen**

SmartArt es un diagrama de PowerPoint compuesto por nodos, formas de nodo y un diseño. Con Aspose.Slides para .NET, puedes crear SmartArt, leer el texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas con imágenes.

## **Obtener texto de un objeto SmartArt**

Un nodo de SmartArt puede contener una o más formas. Para leer el texto visible, recorre [ISmartArt.AllNodes](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartart/allnodes/), luego lee el [ITextFrame](https://reference.aspose.com/slides/es/net/aspose.slides/itextframe/) devuelto por [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartartshape/textframe/).

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    if (slide.Shapes[0] is ISmartArt smartArt)
    {
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            foreach (ISmartArtShape nodeShape in node.Shapes)
            {
                if (nodeShape.TextFrame != null)
                {
                    Console.WriteLine(nodeShape.TextFrame.Text);
                }
            }
        }
    }
}
```

## **Cambiar el tipo de diseño de un objeto SmartArt**

El diseño de SmartArt controla cómo se disponen y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor `BasicBlockList` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/smartartlayouttype/), lo cambia al valor `BasicProcess` y guarda la presentación.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.Layout = SmartArtLayoutType.BasicProcess;

    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Comprobar si un nodo SmartArt está oculto**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartartnode/ishidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos visibles del diagrama.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor `RadialCycle` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/smartartlayouttype/) y comprueba el estado de ocultación del nodo.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.AllNodes.AddNode();
    bool isHidden = node.IsHidden;

    if (isHidden)
    {
        Console.WriteLine("The node is hidden in the SmartArt data model.");
    }

    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que utilizan un diseño de organigrama, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) define cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen por la izquierda, la derecha o ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor `LeftHanging` de [OrganizationChartLayoutType](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/organizationchartlayouttype/).

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.Nodes[0];
    rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    presentation.Save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
}
```

## **Crear un organigrama con imágenes**

Un organigrama con imágenes es un diseño SmartArt creado para diagramas jerárquicos que incluyen marcadores de posición de imágenes. Utiliza el valor `PictureOrganizationChart` de [SmartArtLayoutType](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/smartartlayouttype/) al añadir el objeto SmartArt a una diapositiva.

```c#
using (Presentation presentation = new Presentation())
{
    ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.Save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
}
```

## **Preguntas frecuentes**

**¿SmartArt admite reflejo o inversión para idiomas RTL?**

Sí. La propiedad [IsReversed](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/smartart/isreversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación manteniendo el formato?**

Puedes [clonar la forma SmartArt](/slides/es/net/shape-manipulations/) con [ShapeCollection.AddClone](https://reference.aspose.com/slides/es/net/aspose.slides/shapecollection/addclone/) o [clonar toda la diapositiva](/slides/es/net/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

Renderiza la [diapositiva](/slides/es/net/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Establece un valor distintivo de [AlternativeText](https://reference.aspose.com/slides/es/net/aspose.slides/shape/alternativetext/) o [Name](https://reference.aspose.com/slides/es/net/aspose.slides/shape/name/) en la forma SmartArt, busca ese valor en [Slide.Shapes](https://reference.aspose.com/slides/es/net/aspose.slides/baseslide/shapes/), y luego verifica que la forma coincidente sea un [ISmartArt](https://reference.aspose.com/slides/es/net/aspose.slides.smartart/ismartart/).