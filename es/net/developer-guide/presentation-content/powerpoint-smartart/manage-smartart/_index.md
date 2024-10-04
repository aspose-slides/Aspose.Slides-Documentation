---
title: Administrar SmartArt
type: docs
weight: 10
url: /net/manage-smartart/
keywords: "SmartArt, texto de SmartArt, gráfico de tipo organización, gráfico de organización de imagen, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "SmartArt y gráfico de tipo organización en presentaciones de PowerPoint en C# o .NET"
---

## **Obtener texto de SmartArt**
Ahora se ha agregado la propiedad TextFrame a la interfaz ISmartArtShape y a la clase SmartArtShape respectivamente. Esta propiedad te permite obtener todo el texto de SmartArt si no tiene solo texto de nodos. El siguiente código de ejemplo te ayudará a obtener texto de un nodo de SmartArt.

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
Para cambiar el tipo de diseño de SmartArt, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega SmartArt BasicBlockList.
- Cambia el LayoutType a BasicProcess.
- Guarda la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```c#
using (Presentation presentation = new Presentation())
{
    // Agregar SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // Cambiar LayoutType a BasicProcess
    smart.Layout = SmartArtLayoutType.BasicProcess;

    // Guardar presentación
    presentation.Save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
}
```



## **Comprobar propiedad oculta de SmartArt**
Ten en cuenta que el método com.aspose.slides.ISmartArtNode.isHidden() devuelve verdadero si este nodo es un nodo oculto en el modelo de datos. Para comprobar la propiedad oculta de cualquier nodo de SmartArt, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Agrega SmartArt RadialCycle.
- Agrega un nodo en SmartArt.
- Comprueba la propiedad isHidden.
- Guarda la presentación como un archivo PPTX.

En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```c#
using (Presentation presentation = new Presentation())
{
    // Agregar SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // Agregar nodo en SmartArt 
    ISmartArtNode node = smart.AllNodes.AddNode();

    // Comprobar propiedad isHidden
    bool hidden = node.IsHidden; // Devuelve verdadero

    if (hidden)
    {
        // Realizar algunas acciones o notificaciones
    }
    // Guardar presentación
    presentation.Save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
}
```



## **Obtener o establecer tipo de gráfico organizacional**
Los métodos com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) permiten obtener o establecer el tipo de gráfico organizacional asociado con el nodo actual. Para obtener o establecer el tipo de gráfico organizacional, sigue los pasos a continuación:

- Crea una instancia de la clase `Presentation`.
- Agrega SmartArt en la diapositiva.
- Obtén o establece el tipo de gráfico organizacional.
- Guarda la presentación como un archivo PPTX.
  En el ejemplo dado a continuación, hemos agregado un conector entre dos formas.

```c#
using (Presentation presentation = new Presentation())
{
    // Agregar SmartArt BasicProcess 
    ISmartArt smart = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // Obtener o establecer el tipo de gráfico organizacional 
    smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

    // Guardar presentación
    presentation.Save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
}
```




## **Crear gráfico de organización de imagen**
Aspose.Slides para .NET proporciona una API simple para crear gráficos y gráficos de organización de imagen de manera fácil. Para crear un gráfico en una diapositiva:

1. Crea una instancia de la clase `Presentation`.
2. Obtén la referencia de una diapositiva mediante su índice.
3. Agrega un gráfico con datos predeterminados junto con el tipo deseado (ChartType.PictureOrganizationChart).
4. Guarda la presentación modificada en un archivo PPTX.

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