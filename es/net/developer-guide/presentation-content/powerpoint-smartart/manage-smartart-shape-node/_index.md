---
title: Administrar Nodo de Forma SmartArt
type: docs
weight: 30
url: /net/manage-smartart-shape-node/
keywords:
- SmartArt
- nodo SmartArt
- nodo hijo SmartArt
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides para .NET
description: "Administra nodos SmartArt y nodos hijos en presentaciones de PowerPoint en C# o .NET"
---


## **Agregar Nodo SmartArt**
Aspose.Slides para .NET ha proporcionado la API más simple para gestionar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de la forma SmartArt.

- Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva usando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.
- Agrega un nuevo Nodo en la colección de nodos de la forma SmartArt y establece el texto en el TextFrame.
- Ahora, agrega un Nodo Hijo en el Nodo SmartArt recién agregado y establece el texto en el TextFrame.
- Guarda la presentación.

```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AddNodes.pptx");

// Recorre cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verifica si la forma es del tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convierte la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Agregando un nuevo Nodo SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Agregando texto
        TemNode.TextFrame.Text = "Prueba";

        // Agregando un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Agregando texto
        newNode.TextFrame.Text = "Nuevo Nodo Agregado";

    }
}

// Guardando la presentación
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Agregar Nodo SmartArt en una Posición Específica**
En el siguiente código de ejemplo hemos explicado cómo agregar los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt en una posición particular.

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de la primera diapositiva usando su índice.
- Agrega una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Accede al primer nodo en la forma SmartArt agregada.
- Ahora, agrega el Nodo Hijo para el Nodo seleccionado en la posición 2 y establece su texto.
- Guarda la presentación.

```c#
// Creando una instancia de presentación
Presentation pres = new Presentation();

// Accediendo a la diapositiva de la presentación
ISlide slide = pres.Slides[0];

// Agregando forma SmartArt IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accediendo al nodo SmartArt en el índice 0
ISmartArtNode node = smart.AllNodes[0];

// Agregando nuevo nodo hijo en la posición 2 en el nodo padre
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Agregar texto
chNode.TextFrame.Text = "Texto de Ejemplo Agregado";

// Guardar presentación
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Acceder al Nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Ten en cuenta que no puedes cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece solo cuando se agrega la forma SmartArt.

- Crea una instancia de la clase `Presentation` y carga la presentación con la forma SmartArt.

- Obtén la referencia de la primera diapositiva usando su índice.

- Recorre cada forma dentro de la primera diapositiva.

- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.

- Recorre todos los Nodos dentro de la forma SmartArt.

- Accede y muestra información como la posición del Nodo SmartArt, nivel y Texto.

```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessSmartArt.pptx");
  
// Recorre cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Verifica si la forma es del tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
  
        // Convierte la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
        // Recorre todos los nodos dentro de SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accediendo al nodo SmartArt en el índice i
            Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
            // Imprimiendo los parámetros del nodo SmartArt
            string outString = string.Format("i = {0}, Texto = {1},  Nivel = {2}, Posición = {3}", i, node.TextFrame.Text, node.Level, node.Position);
            Console.WriteLine(outString);
        }
    }
}
```



## **Acceder al Nodo Hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos pertenecientes a los nodos respectivos de la forma SmartArt.

- Crea una instancia de la clase PresentationEx y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva usando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArtEx si es SmartArt.
- Recorre todos los Nodos dentro de la forma SmartArt.
- Para cada Nodo SmartArt seleccionado, recorre todos los Nodos Hijos dentro de un nodo particular.
- Accede y muestra información como la posición del Nodo Hijo, nivel y Texto.

```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Recorre cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verifica si la forma es del tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convierte la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Recorre todos los nodos dentro de SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accediendo al nodo SmartArt en el índice i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Recorriendo los nodos hijos en el nodo SmartArt en el índice i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Accediendo al nodo hijo en el nodo SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Imprimiendo los parámetros del nodo hijo SmartArt
                string outString = string.Format("j = {0}, Texto = {1},  Nivel = {2}, Posición = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```



## **Acceder al Nodo Hijo SmartArt en una Posición Específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular pertenecientes a los nodos respectivos de la forma SmartArt.

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de la primera diapositiva usando su índice.
- Agrega una forma SmartArt de tipo StackedList.
- Accede a la forma SmartArt agregada.
- Accede al nodo en el índice 0 para la forma SmartArt accedida.
- Ahora, accede al Nodo Hijo en la posición 1 para el nodo SmartArt accedido usando el método GetNodeByPosition().
- Accede y muestra información como la posición del Nodo Hijo, nivel y Texto.

```c#
// Instanciar la presentación
Presentation pres = new Presentation();

// Accediendo a la primera diapositiva
ISlide slide = pres.Slides[0];

// Agregando la forma SmartArt en la primera diapositiva
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accediendo al nodo SmartArt en el índice 0
ISmartArtNode node = smart.AllNodes[0];

// Accediendo al nodo hijo en la posición 1 en el nodo padre
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Imprimiendo los parámetros del nodo hijo SmartArt
string outString = string.Format("j = {0}, Texto = {1},  Nivel = {2}, Posición = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```



## **Eliminar Nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Crea una instancia de la clase `Presentation` y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva usando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.
- Verifica si el SmartArt tiene más de 0 nodos.
- Selecciona el nodo SmartArt que se eliminará.
- Ahora, elimina el nodo seleccionado usando el método RemoveNode(). Guarda la presentación.

```c#
// Cargar la presentación deseada
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Recorre cada forma dentro de la primera diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Verifica si la forma es del tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convierte la forma a SmartArtEx
            ISmartArt smart = (ISmartArt)shape;

            if (smart.AllNodes.Count > 0)
            {
                // Accediendo al nodo SmartArt en el índice 0
                ISmartArtNode node = smart.AllNodes[0];

                // Eliminando el nodo seleccionado
                smart.AllNodes.RemoveNode(node);

            }
        }
    }

    // Guardar presentación
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Eliminar Nodo SmartArt en una Posición Específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

- Crea una instancia de la clase `Presentation` y carga la presentación con la forma SmartArt.
- Obtén la referencia de la primera diapositiva usando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArt si es SmartArt.
- Selecciona el nodo de la forma SmartArt en el índice 0.
- Ahora, verifica si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, elimina el nodo en la Posición 1 usando el método RemoveNodeByPosition().
- Guarda la presentación.

```c#
// Cargar la presentación deseada             
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Recorre cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Verifica si la forma es del tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Convierte la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        if (smart.AllNodes.Count > 0)
        {
            // Accediendo al nodo SmartArt en el índice 0
            Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

            if (node.ChildNodes.Count >= 2)
            {
                // Eliminando el nodo hijo en la posición 1
                ((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).RemoveNode(1);
            }

        }
    }
}

// Guardar presentación
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```



## **Establecer Posición Personalizada para el Nodo Hijo en SmartArt**
Ahora Aspose.Slides para .NET tiene soporte para establecer las propiedades X e Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer la posición, tamaño y rotación personalizada de SmartArtShape. Ten en cuenta que agregar nuevos nodos provoca un recalculo de las posiciones y tamaños de todos los nodos.

```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessChildNodes.pptx");

{
	ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

	// Mover la forma SmartArt a una nueva posición
	ISmartArtNode node = smart.AllNodes[1];
	ISmartArtShape shape = node.Shapes[1];
	shape.X += (shape.Width * 2);
	shape.Y -= (shape.Height / 2);

	// Cambiar las anchuras de la forma SmartArt
	node = smart.AllNodes[2];
	shape = node.Shapes[1];
	shape.Width += (shape.Width / 2);

	// Cambiar la altura de la forma SmartArt
	node = smart.AllNodes[3];
	shape = node.Shapes[1];
	shape.Height += (shape.Height / 2);

	// Cambiar la rotación de la forma SmartArt
	node = smart.AllNodes[4];
	shape = node.Shapes[1];
	shape.Rotation = 90;

	pres.Save("SmartArt.pptx", SaveFormat.Pptx);
}
```



## **Verificar Nodo Asistente**
En el siguiente código de ejemplo investigaremos cómo identificar Nodos Asistentes en la colección de nodos SmartArt y cambiarlos.

- Crea una instancia de la clase PresentationEx y carga la presentación con la forma SmartArt.
- Obtén la referencia de la segunda diapositiva usando su índice.
- Recorre cada forma dentro de la primera diapositiva.
- Verifica si la forma es del tipo SmartArt y convierte la forma seleccionada a SmartArtEx si es SmartArt.
- Recorre todos los nodos dentro de la forma SmartArt y verifica si son Nodos Asistentes.
- Cambia el estado del Nodo Asistente a nodo normal.
- Guarda la presentación.

```c#
// Creando una instancia de presentación
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Recorre cada forma dentro de la primera diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verifica si la forma es del tipo SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Convierte la forma a SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Recorriendo todos los nodos de la forma SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Verifica si el nodo es un nodo asistente
                if (node.IsAssistant)
                {
                    // Estableciendo el nodo asistente en falso y convirtiéndolo en un nodo normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Guardar presentación
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **Establecer el Formato de Relleno del Nodo**
Aspose.Slides para .NET permite agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides para .NET.

Sigue los siguientes pasos:

- Crea una instancia de la clase `Presentation`.
- Obtén la referencia de una diapositiva utilizando su índice.
- Agrega una forma SmartArt estableciendo su LayoutType.
- Establece el FillFormat para los nodos de la forma SmartArt.
- Escribe la presentación modificada como un archivo PPTX.

```c#
using (Presentation presentation = new Presentation())
{
    // Accediendo a la diapositiva
    ISlide slide = presentation.Slides[0];

    // Agregando forma SmartArt y nodos
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Algún texto";

    // Estableciendo el color de relleno del nodo
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Guardando la presentación
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```



## **Generar Miniatura del Nodo Hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los siguientes pasos:

1. Instanciar la clase `Presentation` que representa el archivo PPTX.
1. Agregar SmartArt.
1. Obtener la referencia de un nodo usando su índice.
1. Obtener la imagen de la miniatura.
1. Guardar la imagen de la miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura del nodo hijo SmartArt.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);
    ISmartArtNode node = smartArt.Nodes[1];

    using (IImage image = node.Shapes[0].GetImage())
    {
        image.Save("SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat.Jpeg);
    }
}
```