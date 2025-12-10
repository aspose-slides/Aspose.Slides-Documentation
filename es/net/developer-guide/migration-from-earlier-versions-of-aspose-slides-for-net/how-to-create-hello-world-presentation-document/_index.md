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
description: "Cree una presentación PowerPoint PPT, PPTX y ODP Hello World en .NET con Aspose.Slides usando tanto APIs heredadas como modernas en una guía simple."
---

{{% alert color="primary" %}} 

Se ha lanzado una nueva [Aspose.Slides for .NET API](/slides/es/net/) y ahora este único producto admite la capacidad de generar documentos PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Compatibilidad con código heredado**
Para usar el código heredado desarrollado con versiones de Aspose.Slides for .NET anteriores a la 13.x, debe realizar algunos cambios menores en su código y este continuará funcionando como antes. Todas las clases que estaban presentes en el antiguo Aspose.Slides for .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora están fusionadas en un único espacio de nombres Aspose.Slides. Por favor, revise el siguiente fragmento de código simple para crear un documento de presentación Hello World en la API legacy de Aspose.Slides y siga los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque legacy de Aspose.Slides for .NET**
```c#
//Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();

//Crear un objeto License
License license = new License();

//Establecer la licencia de Aspose.Slides for .NET para evitar las limitaciones de evaluación
license.SetLicense("Aspose.Slides.lic");

//Agregar una diapositiva vacía a la presentación y obtener la referencia de
//esa diapositiva vacía
Slide slide = pres.AddEmptySlide();

//Agregar un rectángulo (X=2400, Y=1800, Ancho=1000 & Alto=500) a la diapositiva
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ocultar las líneas del rectángulo
rect.LineFormat.ShowLines = false;

//Agregar un marco de texto al rectángulo con "Hello World" como texto predeterminado
rect.AddTextFrame("Hello World");

//Eliminar la primera diapositiva de la presentación que siempre es agregada por
//Aspose.Slides for .NET por defecto al crear la presentación
pres.Slides.RemoveAt(0);

//Escribir la presentación como un archivo PPT
pres.Write("C:\\hello.ppt");
```




## **Nuevo enfoque de Aspose.Slides for .NET 13.x**
```c#
 // Instanciar Presentation
 Presentation pres = new Presentation();

 // Obtener la primera diapositiva
 ISlide sld = (ISlide)pres.Slides[0];

 // Agregar una AutoShape de tipo Rectángulo
 IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

 // Agregar ITextFrame al rectángulo
 ashp.AddTextFrame("Hello World");

 // Cambiar el color del texto a Negro (que es Blanco por defecto)
 ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
 ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

 // Cambiar el color de la línea del rectángulo a Blanco
 ashp.ShapeStyle.LineColor.Color = Color.White;

 // Eliminar cualquier formato de relleno en la forma
 ashp.FillFormat.FillType = FillType.NoFill;

 // Guardar la presentación en disco
 pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
