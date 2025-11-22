---
title: Gestionar nodos de forma SmartArt
type: docs
weight: 30
url: /es/net/manage-smartart-shape-node/
keywords:
- SmartArt
- Nodo SmartArt
- Nodo hijo SmartArt
- PowerPoint
- presentación
- C#
- Csharp
- Aspose.Slides for .NET
description: "Gestionar nodos SmartArt y nodos hijos en presentaciones PowerPoint con C# o .NET"
---

## **Agregar nodo SmartArt**
Aspose.Slides for .NET ha proporcionado la API más simple para administrar las formas SmartArt de la manera más fácil. El siguiente código de ejemplo ayudará a agregar un nodo y un nodo hijo dentro de una forma SmartArt.

- Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Agregue un nuevo nodo en la colección NodeCollection de la forma SmartArt y establezca el texto en TextFrame.
- Ahora, agregue un nodo hijo al nodo SmartArt recién añadido y establezca el texto en TextFrame.
- Guarde la presentación.
```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AddNodes.pptx");

// Recorrer cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verificar si la forma es de tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Añadir un nuevo nodo SmartArt
        Aspose.Slides.SmartArt.SmartArtNode TemNode = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes.AddNode();

        // Añadir texto
        TemNode.TextFrame.Text = "Test";

        // Añadir nuevo nodo hijo en el nodo padre. Se añadirá al final de la colección
        Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)TemNode.ChildNodes.AddNode();

        // Añadir texto
        newNode.TextFrame.Text = "New Node Added";

    }
}

// Guardar la presentación
pres.Save("AddSmartArtNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```




## **Agregar nodo SmartArt en posición específica**
En el siguiente código de ejemplo hemos explicado cómo agregar los nodos hijos que pertenecen a los nodos respectivos de la forma SmartArt en una posición particular.

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Agregue una forma SmartArt de tipo StackedList en la diapositiva accedida.
- Acceda al primer nodo en la forma SmartArt añadida.
- Ahora, agregue el nodo hijo para el nodo seleccionado en la posición 2 y establezca su texto.
- Guarde la presentación.
```c#
// Crear una instancia de presentación
Presentation pres = new Presentation();

// Acceder a la diapositiva de la presentación
ISlide slide = pres.Slides[0];

// Agregar SmartArt IShape
ISmartArt smart = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

// Accediendo al nodo SmartArt en el índice 0
ISmartArtNode node = smart.AllNodes[0];

// Agregar nuevo nodo hijo en la posición 2 del nodo padre
SmartArtNode chNode = (SmartArtNode)((SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

// Agregar texto
chNode.TextFrame.Text = "Sample Text Added";

// Guardar la presentación
pres.Save("AddSmartArtNodeByPosition_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```





## **Acceder al nodo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos dentro de la forma SmartArt. Tenga en cuenta que no puede cambiar el LayoutType del SmartArt ya que es de solo lectura y se establece únicamente cuando se agrega la forma SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Recorra todos los nodos dentro de la forma SmartArt.
- Acceda y muestre información como la posición del nodo SmartArt, nivel y texto.
```c#
  // Cargar la presentación deseada
   Presentation pres = new Presentation("AccessSmartArt.pptx");
  
  // Recorrer cada forma dentro de la primera diapositiva
  foreach (IShape shape in pres.Slides[0].Shapes)
  {
      // Verificar si la forma es de tipo SmartArt
      if (shape is Aspose.Slides.SmartArt.SmartArt)
      {
  
          // Convertir la forma a SmartArt
          Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;
  
          // Recorrer todos los nodos dentro del SmartArt
          for (int i = 0; i < smart.AllNodes.Count; i++)
          {
              // Accediendo al nodo SmartArt en el índice i
              Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];
  
              // Imprimiendo los parámetros del nodo SmartArt
              string outString = string.Format("i = {0}, Text = {1},  Level = {2}, Position = {3}", i, node.TextFrame.Text, node.Level, node.Position);
              Console.WriteLine(outString);
          }
      }
  }
```




## **Acceder al nodo hijo SmartArt**
El siguiente código de ejemplo ayudará a acceder a los nodos hijos que pertenecen a los nodos respectivos de la forma SmartArt.

- Cree una instancia de la clase PresentationEx y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArtEx si lo es.
- Recorra todos los nodos dentro de la forma SmartArt.
- Para cada nodo de forma SmartArt seleccionado, recorra todos los nodos hijos dentro de ese nodo.
- Acceda y muestre información como la posición del nodo hijo, nivel y texto.
```c#
// Cargar la presentación deseada
Presentation pres = new Presentation("AccessChildNodes.pptx");

// Recorrer cada forma dentro de la primera diapositiva
foreach (IShape shape in pres.Slides[0].Shapes)
{

    // Verificar si la forma es de tipo SmartArt
    if (shape is Aspose.Slides.SmartArt.SmartArt)
    {

        // Convertir la forma a SmartArt
        Aspose.Slides.SmartArt.SmartArt smart = (Aspose.Slides.SmartArt.SmartArt)shape;

        // Recorrer todos los nodos dentro de SmartArt
        for (int i = 0; i < smart.AllNodes.Count; i++)
        {
            // Accediendo al nodo SmartArt en el índice i
            Aspose.Slides.SmartArt.SmartArtNode node0 = (Aspose.Slides.SmartArt.SmartArtNode)smart.AllNodes[i];

            // Recorrer los nodos hijos en el nodo SmartArt en el índice i
            for (int j = 0; j < node0.ChildNodes.Count; j++)
            {
                // Accediendo al nodo hijo en el nodo SmartArt
                Aspose.Slides.SmartArt.SmartArtNode node = (Aspose.Slides.SmartArt.SmartArtNode)node0.ChildNodes[j];

                // Imprimiendo los parámetros del nodo hijo SmartArt
                string outString = string.Format("j = {0}, Text = {1},  Level = {2}, Position = {3}", j, node.TextFrame.Text, node.Level, node.Position);
                Console.WriteLine(outString);
            }
        }
    }
}
```




## **Acceder al nodo hijo SmartArt en posición específica**
En este ejemplo, aprenderemos a acceder a los nodos hijos en una posición particular que pertenecen a los nodos respectivos de la forma SmartArt.

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Agregue una forma SmartArt de tipo StackedList.
- Acceda a la forma SmartArt añadida.
- Acceda al nodo en el índice 0 de la forma SmartArt a la que se accedió.
- Ahora, acceda al nodo hijo en la posición 1 del nodo SmartArt accedido usando el método GetNodeByPosition().
- Acceda y muestre información como la posición del nodo hijo, nivel y texto.
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




## **Eliminar nodo SmartArt**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Verifique si el SmartArt tiene más de 0 nodos.
- Seleccione el nodo SmartArt a eliminar.
- Ahora, elimine el nodo seleccionado usando el método RemoveNode() y guarde la presentación.
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




## **Eliminar nodo SmartArt en posición específica**
En este ejemplo, aprenderemos a eliminar los nodos dentro de la forma SmartArt en una posición particular.

- Cree una instancia de la clase `Presentation` y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la primera diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta (typecast) la forma seleccionada a SmartArt si lo es.
- Seleccione el nodo de la forma SmartArt en el índice 0.
- Ahora, verifique si el nodo SmartArt seleccionado tiene más de 2 nodos hijos.
- Ahora, elimine el nodo en la posición 1 usando el método RemoveNodeByPosition().
- Guarde la presentación.
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




## **Establecer posición personalizada para nodo hijo en SmartArt**
Ahora Aspose.Slides for .NET admite la configuración de las propiedades X e Y de SmartArtShape. El fragmento de código a continuación muestra cómo establecer la posición, el tamaño y la rotación personalizados de SmartArtShape; tenga en cuenta que agregar nuevos nodos provoca un recálculo de las posiciones y tamaños de todos los nodos.
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




## **Comprobar nodo asistente**
En el siguiente código de ejemplo investigaremos cómo identificar los nodos Asistente en la colección de nodos SmartArt y modificarlos.

- Cree una instancia de la clase PresentationEx y cargue la presentación con la forma SmartArt.
- Obtenga la referencia de la segunda diapositiva usando su índice.
- Recorra cada forma dentro de la primera diapositiva.
- Verifique si la forma es de tipo SmartArt y convierta la forma seleccionada a SmartArtEx si lo es.
- Recorra todos los nodos dentro de la forma SmartArt y verifique si son Nodos Asistente.
- Cambie el estado del nodo Asistente a nodo normal.
- Guarde la presentación.
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
                // Comprobar si el nodo es un nodo Asistente
                if (node.IsAssistant)
                {
                    // Establecer el nodo Asistente a false y convertirlo en un nodo normal
                    node.IsAssistant = false;
                }
            }
        }
    }
    // Guardar la presentación
    pres.Save("ChangeAssitantNode_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```




## **Establecer formato de relleno del nodo**
Aspose.Slides for .NET permite agregar formas SmartArt personalizadas y establecer sus formatos de relleno. Este artículo explica cómo crear y acceder a formas SmartArt y establecer su formato de relleno usando Aspose.Slides for .NET.

Por favor, siga los pasos a continuación:

- Cree una instancia de la clase `Presentation`.
- Obtenga la referencia de una diapositiva usando su índice.
- Agregue una forma SmartArt estableciendo su LayoutType.
- Establezca el FillFormat para los nodos de la forma SmartArt.
- Escriba la presentación modificada como un archivo PPTX.
```c#
using (Presentation presentation = new Presentation())
{
    // Accediendo a la diapositiva
    ISlide slide = presentation.Slides[0];

    // Añadiendo forma SmartArt y nodos
    var chevron = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.AllNodes.AddNode();
    node.TextFrame.Text = "Some text";

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




## **Generar miniatura del nodo hijo SmartArt**
Los desarrolladores pueden generar una miniatura del nodo hijo de un SmartArt siguiendo los pasos a continuación:

1. Instancie la clase `Presentation` que representa el archivo PPTX.
1. Agregue SmartArt.
1. Obtenga la referencia de un nodo usando su índice
1. Obtenga la imagen en miniatura.
1. Guarde la imagen en miniatura en cualquier formato de imagen deseado.

El ejemplo a continuación genera una miniatura del nodo hijo de SmartArt
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

Sí. SmartArt se trata como una forma regular, por lo que puede [aplicar animaciones estándar](/slides/es/net/shape-animation/) (entrada, salida, énfasis, rutas de movimiento) y ajustar la sincronización. También puede animar las formas dentro de los nodos SmartArt cuando sea necesario.

**¿Cómo puedo localizar de manera fiable un SmartArt específico en una diapositiva si su ID interno es desconocido?**

Asignar y buscar por [texto alternativo](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/). Establecer un AltText distintivo en el SmartArt le permite encontrarlo programáticamente sin depender de identificadores internos.

**¿Se preservará la apariencia del SmartArt al convertir la presentación a PDF?**

Sí. Aspose.Slides renderiza SmartArt con alta fidelidad visual durante la [exportación a PDF](/slides/es/net/convert-powerpoint-to-pdf/), preservando el diseño, los colores y los efectos.

**¿Puedo extraer una imagen de todo el SmartArt (para vistas previas o informes)?**

Sí. Puede renderizar una forma SmartArt a [formatos raster](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) o a [SVG](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) para obtener una salida vectorial escalable, lo que la hace adecuada para miniaturas, informes o uso web.