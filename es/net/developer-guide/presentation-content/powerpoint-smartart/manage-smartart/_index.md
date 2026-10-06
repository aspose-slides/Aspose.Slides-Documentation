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
- organigrama pictórico
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprende a crear y editar SmartArt de PowerPoint con Aspose.Slides para .NET usando claros ejemplos de código C# que aceleran el diseño y la automatización de diapositivas."
---
## **Visión general**

SmartArt es un diagrama de PowerPoint formado por nodos, formas de nodo y un diseño. Con Aspose.Slides para .NET, puedes crear SmartArt, leer texto de sus nodos, cambiar su diseño, inspeccionar nodos ocultos, configurar diseños de organigramas y crear organigramas pictóricos.

## **Obtener texto de un objeto SmartArt**

Un nodo SmartArt puede contener una o más formas. Para leer el texto de las formas del nodo, recorre [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), luego lee el [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) devuelto por [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/).

El ejemplo requiere una presentación con al menos una diapositiva y un objeto SmartArt como la primera forma en esa diapositiva. Imprime cada marco de texto disponible en la consola.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **Cambiar el tipo de diseño de un objeto SmartArt**

La disposición SmartArt controla cómo se organizan y conectan los nodos. El siguiente ejemplo crea un objeto SmartArt con el valor [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList`, lo cambia al valor `BasicProcess` y guarda la presentación. La posición y el tamaño pasados a [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) se miden en puntos. Establece [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) para cambiar el diseño.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Comprobar si un nodo SmartArt está oculto**

[ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) indica si el nodo está oculto en el modelo de datos de SmartArt. Los nodos ocultos pueden existir en la estructura incluso cuando el diseño seleccionado no los muestra como elementos de diagrama visibles.

El siguiente ejemplo añade un nodo a un objeto SmartArt que utiliza el valor [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` y comprueba el estado oculto del nodo añadido. Imprime un mensaje si el nodo está oculto y guarda el diagrama.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **Obtener o establecer el diseño del organigrama**

Para diagramas SmartArt que utilizan un diseño de organigrama, [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) define cómo se disponen los nodos hijos bajo un nodo padre. Por ejemplo, puedes establecer que los nodos hijos cuelguen a la izquierda, a la derecha o a ambos lados, según el [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) seleccionado.

El siguiente ejemplo crea un organigrama y establece el diseño del primer nodo al valor [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging`. El índice basado en cero `0` selecciona el primer nodo de nivel superior; sus nodos hijos usan la disposición seleccionada. La presentación modificada se guarda entonces.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Crear un organigrama pictórico**

Un organigrama pictórico es un diseño SmartArt pensado para diagramas jerárquicos que incluyen marcadores de posición de imagen. Usa el valor [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` al añadir el objeto SmartArt a una diapositiva. Este ejemplo guarda un diagrama con marcadores de posición de imagen; no rellena los marcadores con imágenes.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Convertir diagramas heredados a grupos de formas**

Al modernizar una presentación existente, puede que necesites actualizar un organigrama creado originalmente en PowerPoint 97–2003. Aspose.Slides representa estos diagramas heredados como objetos [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/). Usa [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) para convertir un diagrama en un grupo de formas para que puedas editar elementos visuales individuales. Consulta la [Referencia de la API LegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) para obtener más detalles.

La conversión añade un nuevo grupo a la colección de formas sin eliminar el diagrama original. Tras una conversión exitosa, elimina el original con [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) para evitar contenido duplicado. Agrupa los diagramas heredados en una matriz antes de convertirlos para que añadir y eliminar formas no interrumpa la iteración.

El siguiente ejemplo abre una presentación, busca en cada diapositiva, convierte los diagramas en grupos de formas y guarda la presentación actualizada como PPTX.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

La presentación guardada contiene grupos de formas editables en lugar de los diagramas heredados convertidos, sin diagramas originales junto a ellos. Abre el PPTX en PowerPoint para editar elementos individuales dentro de cada grupo, como su texto, relleno o posición.

## **Preguntas frecuentes**

**¿SmartArt admite reflejo o inversión para lenguas RTL?**

Sí. La propiedad [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) cambia la dirección del diagrama de izquierda a derecha a derecha a izquierda, o viceversa, cuando el diseño SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puedes [clonar la forma SmartArt](/slides/es/net/shape-manipulations/) con [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) o [clonar toda la diapositiva](/slides/es/net/clone-slides/) que contiene el SmartArt. Ambos enfoques conservan el tamaño, la posición y el formato.

**¿Cómo renderizo SmartArt a una imagen rasterizada para vista previa o exportación web?**

Puedes [renderizar la diapositiva](/slides/es/net/convert-powerpoint-to-png/) o toda la presentación a PNG o JPEG. SmartArt se renderiza como parte de la diapositiva.

**¿Cómo puedo encontrar un objeto SmartArt específico en una diapositiva si hay varios?**

Establece un valor distintivo en [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) o [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) en la forma SmartArt, busca ese valor en [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), y, a continuación, verifica que la forma coincidente sea un [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).