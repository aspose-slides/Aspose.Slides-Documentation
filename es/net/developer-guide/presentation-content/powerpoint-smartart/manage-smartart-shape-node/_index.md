---
title: Administrar nodos de forma SmartArt en presentaciones en .NET
linktitle: Nodo de forma SmartArt
type: docs
weight: 30
url: /es/net/manage-smartart-shape-node/
keywords:
- nodo SmartArt
- nodo hijo
- agregar nodo
- posición del nodo
- acceder al nodo
- eliminar nodo
- posición personalizada
- nodo asistente
- formato de relleno
- renderizar nodo
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Administre los nodos de forma SmartArt en PPT y PPTX con Aspose.Slides para .NET. Obtenga ejemplos de código claros y consejos para optimizar sus presentaciones."
---

## **Agregar un nodo SmartArt**
Aspose.Slides for .NET ha proporcionado la API más simple para administrar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayuda a agregar un nodo y un nodo hijo dentro de una forma SmartArt.

- Crear una instancia de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es de tipo SmartArt y convertir el tipo de la forma seleccionada a SmartArt si lo es.
- Agregar un nuevo nodo a la colección NodeCollection de la forma SmartArt y establecer el texto en TextFrame.
- Ahora, agregar un nodo hijo al nodo SmartArt recién agregado y establecer el texto en TextFrame.
- Guardar la presentación.
```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AddNodes.pptx");

// Recorrer cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verificar si la forma es del tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Agregar un nuevo nodo SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Agregar texto
        TemNode.TextFrame.Text = "Test";

        // Agregar un nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Agregar texto
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Guardar la presentación
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Agregar un nodo SmartArt en una posición específica**
En el siguiente código de ejemplo explicamos cómo agregar los nodos hijos que pertenecen a los respectivos nodos de la forma SmartArt en una posición concreta.

- Crear una instancia de la clase `Presentation`.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Agregar una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Acceder al primer nodo de la forma SmartArt agregada.
- Ahora, agregar el nodo hijo para el nodo seleccionado en la posición 2 y establecer su texto.
- Guardar la presentación.
```c#
// Crear una instancia de presentación
Presentation pres = new Presentation();

// Acceder a la diapositiva de la presentación
ISlide slide = pres.Slides[0];

// Agregar IShape Smart Art
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Acceder al nodo SmartArt en el índice 0
ISmartArtNode node = smart.AllNodes[0];

// Agregar un nuevo nodo hijo en la posición 2 del nodo padre
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Agregar texto
chNode.TextFrame.Text = "Sample Text Added";

// Guardar presentación
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Acceder a un nodo SmartArt**
El siguiente código de ejemplo ayuda a acceder a los nodos dentro de una forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt, ya que es de solo lectura y se establece únicamente cuando se agrega la forma SmartArt.

- Crear una instancia de la clase `Presentation` y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es de tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt.
- Acceder y mostrar información como la posición del nodo SmartArt, nivel y texto.
```c#
  // Cargar la presentación deseada
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Recorrer cada forma dentro de la primera diapositiva
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Verificar si la forma es del tipo SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Convertir la forma a SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Recorrer todos los nodos dentro de SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Acceder al nodo SmartArt en el índice i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Imprimir los parámetros del nodo SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```


## **Acceder a un nodo hijo SmartArt**
El siguiente código de ejemplo ayuda a acceder a los nodos hijos que pertenecen a los respectivos nodos de la forma SmartArt.

- Crear una instancia de la clase PresentationEx y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es de tipo SmartArt y convertir la forma seleccionada a SmartArtEx si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt.
- Para cada nodo de forma SmartArt seleccionado, recorrer todos los nodos hijos dentro del nodo particular.
- Acceder y mostrar información como la posición del nodo hijo, nivel y texto.
```c#
 // Cargar la presentación deseada
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Recorrer cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verificar si la forma es del tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Recorrer todos los nodos dentro de SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Acceder al nodo SmartArt en el índice i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Recorrer los nodos hijos del nodo SmartArt en el índice i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Acceder al nodo hijo en el nodo SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Imprimiendo los parámetros del nodo hijo SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```


## **Acceder a un nodo hijo SmartArt en una posición específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición determinada que pertenecen a los respectivos nodos de la forma SmartArt.

- Crear una instancia de la clase `Presentation`.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Agregar una forma SmartArt de tipo StackedList.
- Acceder a la forma SmartArt agregada.
- Acceder al nodo con índice 0 de la forma SmartArt accedida.
- Ahora, acceder al nodo hijo en la posición 1 del nodo SmartArt accedido usando el método GetNodeByPosition().
- Acceder y mostrar información como la posición del nodo hijo, nivel y texto.
```c#
// Instanciar la presentación
Presentation pres = new Presentation();

// Accediendo a la primera diapositiva
ISlide slide = pres.Slides[0];

// Agregando la forma SmartArt en la primera diapositiva
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accediendo al nodo SmartArt en el índice 0
ISmartArtNode node = smart.AllNodes[0];

// Accediendo al nodo hijo en la posición 1 del nodo padre
int position = 1;
SmartArtNode chNode = (SmartArtNode)node.ChildNodes[position]; 

// Imprimiendo los parámetros del nodo hijo SmartArt
string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", position, chNode.TextFrame.Text, chNode.Level, chNode.Position);
Console.WriteLine(outString);
```


## **Eliminar un nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Crear una instancia de la clase `Presentation` y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es de tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Verificar si el SmartArt tiene más de 0 nodos.
- Seleccionar el nodo SmartArt que se eliminará.
- Ahora, eliminar el nodo seleccionado usando el método RemoveNode() y guardar la presentación.
```c#
// Cargar la presentación deseada
using (Presentation pres = new Presentation("RemoveNode.pptx"))
{

    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {

        // Verificar si la forma es de tipo SmartArt
        if (shape is ISmartArt)
        {
            // Convertir la forma a SmartArtEx
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

    // Guardar la presentación
    pres.Save("RemoveSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Eliminar un nodo SmartArt en una posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición concreta.

- Crear una instancia de la clase `Presentation` y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la primera diapositiva mediante su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es de tipo SmartArt y convertir la forma seleccionada a SmartArt si lo es.
- Seleccionar el nodo de la forma SmartArt en el índice 0.
- Ahora, verificar si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, eliminar el nodo en la posición 1 usando el método RemoveNodeByPosition().
- Guardar la presentación.
```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("RemoveNodeSpecificPosition.pptx");

// Recorrer cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{
    // Verificar si la forma es de tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {
        // Convertir la forma a SmartArt
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

// Guardar la presentación
pres.Save("RemoveSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Establecer una posición personalizada para un nodo hijo en un objeto SmartArt**
Ahora Aspose.Slides for .NET admite la configuración de las propiedades X e Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer una posición, tamaño y rotación personalizados para SmartArtShape; también tenga en cuenta que agregar nuevos nodos provoca un recálculo de las posiciones y tamaños de todos los nodos.
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

	// Cambiar el ancho de la forma SmartArt
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


## **Comprobar un nodo asistente**
En el siguiente código de ejemplo investigaremos cómo identificar los nodos asistente en la colección de nodos SmartArt y modificarlos.

- Crear una instancia de la clase PresentationEx y cargar la presentación con una forma SmartArt.
- Obtener la referencia de la segunda diapositiva mediante su índice.
- Recorrer cada forma dentro de la primera diapositiva.
- Verificar si la forma es de tipo SmartArt y convertir la forma seleccionada a SmartArtEx si lo es.
- Recorrer todos los nodos dentro de la forma SmartArt y comprobar si son nodos asistente.
- Cambiar el estado del nodo asistente a nodo normal.
- Guardar la presentación.
```c#
// Crear una instancia de presentación
using (Presentation pres = new Presentation("AssistantNode.pptx"))
{
    // Recorrer cada forma dentro de la primera diapositiva
    foreach (IShape shape in pres.Slides[0].Shapes)
    {
        // Verificar si la forma es de tipo SmartArt
        if (shape is Aspose.Slides.SmartArt.ISmartArt)
        {
            // Convertir la forma a SmartArtEx
            Aspose.Slides.SmartArt.ISmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
            // Recorrer todos los nodos de la forma SmartArt

            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smart.AllNodes)
            {
                String tc = node.TextFrame.Text;
                // Verificar si el nodo es asistente
                if (node.IsAssistant)
                {
                    // Establecer el nodo asistente a false y convertirlo en nodo normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Guardar la presentación
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Establecer el formato de relleno de un nodo**
Aspose.Slides for .NET permite agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for .NET.

- Crear una instancia de la clase `Presentation`.
- Obtener la referencia de una diapositiva usando su índice.
- Agregar una forma SmartArt configurando su LayoutType.
- Establecer el FillFormat para los nodos de la forma SmartArt.
- Guardar la presentación modificada como un archivo PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Accediendo a la diapositiva
    ISlide slide = presentation.Slides[0];

    // Añadiendo forma SmartArt y nodos
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

    // Estableciendo color de relleno del nodo
    foreach (var item in node.Shapes)
    {
        item.FillFormat.FillType = FillType.Solid;
        item.FillFormat.SolidFillColor.Color = Color.Red;
    }

    // Guardando presentación
    presentation.Save("FillFormat_SmartArt_ShapeNode_out.pptx", SaveFormat.Pptx);
}
```


## **Generar una miniatura de un nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

- Instanciar la clase `Presentation` que representa el archivo PPTX.
- Agregar SmartArt.
- Obtener la referencia de un nodo usando su índice.
- Obtener la imagen de miniatura.
- Guardar la imagen de miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura del nodo hijo de SmartArt.
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


## **FAQ**

**¿Se admite la animación de SmartArt?**

Sí. SmartArt se trata como una forma normal, por lo que puede [aplicar animaciones estándar](/slides/es/net/shape-animation/) (entrada, salida, énfasis, trayectorias de movimiento) y ajustar el tiempo. También puede animar las formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de forma fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asigne y busque por [texto alternativo](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Configurar un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se conservará la apariencia de SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/net/convert-powerpoint-to-pdf/), conservando el diseño, los colores y los efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos rasterizados](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o a [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) para obtener una salida vectorial escalable, lo que lo hace adecuado para miniaturas, informes o uso web.