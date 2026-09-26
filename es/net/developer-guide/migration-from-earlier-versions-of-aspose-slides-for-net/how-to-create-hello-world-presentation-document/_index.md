---
title: Cómo crear presentaciones Hello World en .NET
linktitle: Presentación Hello World
type: docs
weight: 10
url: /es/net/how-to-create-hello-world-presentation-document/
keywords:
- migración
- hola mundo
- código heredado
- código moderno
- enfoque heredado
- enfoque moderno
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cree una presentación PowerPoint PPT, PPTX y ODP Hello World en .NET con Aspose.Slides utilizando tanto APIs heredadas como modernas en una guía sencilla."
---
{{% alert color="info" %}} 

Se ha lanzado una nueva [Aspose.Slides for .NET API](/slides/es/net/) y ahora este único producto admite la capacidad de generar documentos PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Compatibilidad con código heredado**
Para utilizar el código heredado desarrollado con versiones de Aspose.Slides for .NET anteriores a la 13.x, es necesario realizar algunos cambios menores en su código y éste seguirá funcionando como antes. Todas las clases que estaban presentes en la versión antigua de Aspose.Slides for .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora se han fusionado en un único espacio de nombres Aspose.Slides. Revise el siguiente fragmento de código simple para crear un documento de presentación Hello World con la API heredada de Aspose.Slides y siga los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque heredado de Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//Instanciar un objeto Presentation que representa un archivo PPT
//Crear un objeto License
//Establecer la licencia de Aspose.Slides for .NET para evitar las limitaciones de evaluación
//Añadir una diapositiva vacía a la presentación y obtener la referencia de
//esa diapositiva vacía
//Añadir un rectángulo (X=2400, Y=1800, Ancho=1000 & Alto=500) a la diapositiva
//Ocultar las líneas del rectángulo
//Añadir un marco de texto al rectángulo con "Hello World" como texto predeterminado
//Eliminar la primera diapositiva de la presentación que siempre se añade por
//Aspose.Slides for .NET de forma predeterminada al crear la presentación
//Escribir la presentación como un archivo PPT
Presentation pres = new Presentation();

//Create a License object
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//that empty slide
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Aspose.Slides for .NET by default while creating the presentation
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **Enfoque nuevo de Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```