---
title: Cómo crear un documento de presentación Hello World
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

Se ha lanzado una nueva [Aspose.Slides para .NET API](/slides/net/) y ahora este único producto admite la capacidad de generar documentos de PowerPoint desde cero y editar los existentes.

{{% /alert %}} 
## **Soporte para código heredado**
Para utilizar el código heredado desarrollado con Aspose.Slides para .NET versiones anteriores a 13.x, necesita hacer algunos cambios menores en su código y el código funcionará como antes. Todas las clases que estaban presentes en la antigua Aspose.Slides para .NET bajo los espacios de nombres Aspose.Slide y Aspose.Slides.Pptx ahora se han fusionado en un solo espacio de nombres Aspose.Slides. Por favor, eche un vistazo al siguiente fragmento de código simple para crear un documento de presentación Hello World en la API heredada de Aspose.Slides y siga los pasos que describen cómo migrar a la nueva API fusionada.
## **Enfoque antiguo de Aspose.Slides para .NET**
```c#
//Instanciar un objeto Presentation que representa un archivo PPT
Presentation pres = new Presentation();

//Crear un objeto License
License license = new License();

//Establecer la licencia de Aspose.Slides para .NET para evitar las limitaciones de evaluación
license.SetLicense("Aspose.Slides.lic");

//Agregar una diapositiva vacía a la presentación y obtener la referencia de
//esa diapositiva vacía
Slide slide = pres.AddEmptySlide();

//Agregar un rectángulo (X=2400, Y=1800, Ancho=1000 y Altura=500) a la diapositiva
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Ocultar las líneas del rectángulo
rect.LineFormat.ShowLines = false;

//Agregar un marco de texto al rectángulo con "Hello World" como texto predeterminado
rect.AddTextFrame("Hello World");

//Eliminar la primera diapositiva de la presentación que siempre se agrega por
//Aspose.Slides para .NET por defecto al crear la presentación
pres.Slides.RemoveAt(0);

//Escribir la presentación como un archivo PPT
pres.Write("C:\\hello.ppt");
```



## **Nuevo enfoque de Aspose.Slides para .NET 13.x**
```c#
// Instanciar Presentación
Presentation pres = new Presentation();

// Obtener la primera diapositiva
ISlide sld = (ISlide)pres.Slides[0];

// Agregar un AutoShape de tipo Rectángulo
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Agregar ITextFrame al Rectángulo
ashp.AddTextFrame("Hello World");

// Cambiar el color del texto a Negro (que es Blanco por defecto)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Cambiar el color de línea del rectángulo a Blanco
ashp.ShapeStyle.LineColor.Color = Color.White;

// Eliminar cualquier formato de relleno en la forma
ashp.FillFormat.FillType = FillType.NoFill;

// Guardar la presentación en disco
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```