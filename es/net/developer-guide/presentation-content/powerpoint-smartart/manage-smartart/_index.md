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
- organigrama de imágenes
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a crear y editar SmartArt de PowerPoint con Aspose.Slides para .NET usando claros ejemplos de código C# que aceleran el diseño de diapositivas y la automatización."
---

## **Obtener texto de SmartArt**
Ahora se ha agregado la propiedad TextFrame a la interfaz ISmartArtShape y a la clase SmartArtShape respectivamente. Esta propiedad le permite obtener todo el texto de SmartArt aunque no solo sea texto de nodos. El siguiente código de ejemplo le ayudará a obtener texto del nodo SmartArt.
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




## **Cambiar tipo de diseño de SmartArt**
Para cambiar el tipo de diseño de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de una diapositiva mediante su índice.
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




## **Comprobar la propiedad Hidden de SmartArt**
Tenga en cuenta que el método com.aspose.slides.ISmartArtNode.isHidden() devuelve true si este nodo está oculto en el modelo de datos. Para comprobar la propiedad oculto de cualquier nodo de SmartArt, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Añada SmartArt RadialCycle.
- Añada un nodo a SmartArt.
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
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permiten obtener o establecer el tipo de organigrama asociado al nodo actual. Para obtener o establecer el tipo de organigrama, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Añada SmartArt en la diapositiva.
- Obtenga o establezca el tipo de organigrama.
- Guarde la presentación como un archivo PPTX.
  En el ejemplo que se muestra a continuación, hemos añadido un conector entre dos formas.
```c#
using (Presentation presentation = new Presentation())
{
    // Agregar SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtener o establecer el tipo de organigrama 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Guardando presentación
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```





## **Crear un organigrama de imágenes**
Aspose.Slides for .NET proporciona una API simple para crear gráficos PictureOrganization de forma sencilla. Para crear un gráfico en una diapositiva:

1. Cree una instancia de la clase `Presentation`.
1. Obtenga la referencia de una diapositiva mediante su índice.
1. Añada un gráfico con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
1. Guarde la presentación modificada como un archivo PPTX.

El siguiente código se utiliza para crear un gráfico.
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

**¿SmartArt admite espejo/inversión para idiomas RTL?**

Sí. La propiedad [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) cambia la dirección del diagrama (LTR/RTL) si el tipo de SmartArt seleccionado admite la inversión.

**¿Cómo puedo copiar SmartArt a la misma diapositiva o a otra presentación conservando el formato?**

Puede [clonar la forma SmartArt](/slides/es/net/shape-manipulations/) mediante la colección de formas ([ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/)) o [clonar toda la diapositiva](/slides/es/net/clone-slides/) que contiene esa forma. Ambos enfoques conservan el tamaño, la posición y el estilo.

**¿Cómo renderizo SmartArt a una imagen raster para vista previa o exportación web?**

[Renderice la diapositiva](/slides/es/net/convert-powerpoint-to-png/) (o la presentación completa) a PNG/JPEG mediante la API que convierte diapositivas/presentaciones a imágenes; SmartArt se dibujará como parte de la diapositiva.

**¿Cómo puedo seleccionar programáticamente un SmartArt específico en una diapositiva si hay varios?**

Una práctica común es usar el [texto alternativo](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) (Alt Text) o un [Nombre](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) y buscar la forma por ese atributo dentro de [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/), luego comprobar el tipo para confirmar que es [SmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/). La documentación describe técnicas típicas para encontrar y trabajar con formas.