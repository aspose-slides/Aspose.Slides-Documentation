---
title: Administrar SmartArt en presentaciones de PowerPoint en .NET
linktitle: Administrar SmartArt
type: docs
weight: 10
url: /es/net/manage-smartart/
keywords:
- SmartArt
- texto de SmartArt
- tipo de diseño
- propiedad oculta
- organigrama
- organigrama de imagen
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para .NET utilizando ejemplos de código C# claros que aceleran el diseño y la automatización de diapositivas."
---

## **Obtener texto de un objeto SmartArt**
Ahora se ha añadido la propiedad TextFrame a la interfaz ISmartArtShape y a la clase SmartArtShape respectivamente. Esta propiedad le permite obtener todo el texto de SmartArt, no solo el texto de los nodos. El siguiente fragmento de código le ayudará a obtener el texto de un nodo SmartArt.
```c#
using (Presentation pres = new Presentation("Presentation.pptx"))
{
	ISlide slide = pres.Slides[0];
	ISmartArt smartArt = (ISmartArt)slide.Shapes[0];

	ISmartArtNodeCollection smartArtNodes = smartArt.AllNodes;
	foreach (ISmartArtNode smartArtNode in smartArtNodes)
	{
		foreach (ISmartArtShape nodeShape in smartArtNode.Shapes)
		{
			if (nodeShape.TextFrame != null)
				Console.WriteLine(nodeShape.TextFrame.Text);
		}
	}
}
```


## **Cambiar el tipo de diseño de un objeto SmartArt**
Para cambiar el tipo de diseño de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de una diapositiva usando su índice.
- Añada SmartArt BasicBlockList.
- Cambie LayoutType a BasicProcess.
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```c#
using (Presentation presentation = new Presentation())
{
    // Añadir SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Cambiar LayoutType a BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Guardar presentación
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```


## **Comprobar la propiedad Oculto de un objeto SmartArt**
Nota: el método com.aspose.slides.ISmartArtNode.isHidden() devuelve true si este nodo es un nodo oculto en el modelo de datos. Para comprobar la propiedad Oculto de cualquier nodo de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Añada SmartArt RadialCycle.
- Añada un nodo en SmartArt.
- Compruebe la propiedad isHidden.
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```c#
using (Presentation presentation = new Presentation())
{
    // Añadir SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Añadir nodo en SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Verificar la propiedad isHidden
    bool hidden = node.IsHidden; // Devuelve true

    if (hidden)
    {
        // Realizar algunas acciones o notificaciones
    }
    // Guardar presentación
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```


## **Obtener o establecer el tipo de organigrama**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() y setOrganizationChartLayout(int) permiten obtener o establecer el tipo de organigrama asociado al nodo actual. Para obtener o establecer el tipo de organigrama, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Añada SmartArt en la diapositiva.
- Obtenga o establezca el tipo de organigrama.
- Guarde la presentación como un archivo PPTX.

En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```c#
using (Presentation presentation = new Presentation())
{
    // Añadir SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtener o establecer el tipo de organigrama 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Guardar presentación
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```


## **Crear un organigrama de imagen**
Aspose.Slides para .NET proporciona una API simple para crear diagramas PictureOrganization de forma fácil. Para crear un diagrama en una diapositiva:

1. Cree una instancia de la clase `Presentation`.
2. Obtenga la referencia de una diapositiva mediante su índice.
3. Añada un diagrama con datos predeterminados y el tipo deseado (ChartType.PictureOrganizationChart).
4. Guarde la presentación modificada en un archivo PPTX

El siguiente código se utiliza para crear un diagrama.
```c#
public static void Run()
{
	using (Presentation pres = new Presentation("test.pptx"))
	{
		ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
		pres.Save("OrganizationChart.pptx", SaveFormat.Pptx);
	}			
}
```


## **FAQ**

**¿SmartArt admite el reflejo/inversión para idiomas RTL?**

Sí. La propiedad [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) cambia la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado admite la reversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación preservando el formato?**

Puede [clonar la forma SmartArt](/slides/es/net/shape-manipulations/) a través de la colección de formas ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) o [clonar la diapositiva completa](/slides/es/net/clone-slides/) que contiene esta forma. Ambos enfoques conservan el tamaño, la posición y el estilo.

**¿Cómo renderizo SmartArt a una imagen rasterizada para vista previa o exportación web?**

[Renderice la diapositiva](/slides/es/net/convert-powerpoint-to-png/) (o la presentación completa) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones a imágenes; SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

Una práctica común es usar [texto alternativo](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) o un [Nombre](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) y buscar la forma por ese atributo dentro de [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.