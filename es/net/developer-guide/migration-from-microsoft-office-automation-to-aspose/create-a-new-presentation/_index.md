---
title: Crear nuevas presentaciones usando VSTO y Aspose.Slides para .NET
linktitle: Crear nueva presentación
type: docs
weight: 10
url: /es/net/create-a-new-presentation/
keywords:
- crear presentación
- nueva presentación
- migración
- VSTO
- automatización de Office
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Migra de la automatización de Microsoft Office a Aspose.Slides para .NET y crea nuevas presentaciones de PowerPoint (PPT, PPTX) en C# con código limpio y fiable."
---

{{% alert color="primary" %}} 

VSTO se desarrolló para permitir a los desarrolladores crear aplicaciones que pudieran ejecutarse dentro de Microsoft Office. VSTO se basa en COM, pero está envuelto en un objeto .NET para que pueda usarse en aplicaciones .NET. VSTO necesita compatibilidad con el framework .NET así como el tiempo de ejecución basado en CLR de Microsoft Office. Aunque puede usarse para crear complementos de Microsoft Office, es casi imposible emplearlo como componente del lado del servidor. También presenta serios problemas de implementación.

Aspose.Slides para .NET es un componente que puede usarse para manipular presentaciones de Microsoft PowerPoint, al igual que VSTO, pero tiene varias ventajas:

- Aspose.Slides contiene solo código administrado y no requiere que el tiempo de ejecución de Microsoft Office esté instalado.
- Puede usarse como componente del lado del cliente o como componente del lado del servidor.
- La implementación es sencilla, ya que Aspose.Slides se encuentra en un solo DLL.

{{% /alert %}} 
## **Crear una presentación**
A continuación se presentan dos ejemplos de código que ilustran cómo VSTO y Aspose.Slides para .NET pueden usarse para lograr el mismo objetivo. El primer ejemplo es [VSTO](/slides/es/net/create-a-new-presentation/); [el segundo ejemplo](/slides/es/net/create-a-new-presentation/) usa Aspose.Slides.
### **Ejemplo de VSTO**
**La salida de VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Nota: PowerPoint es un espacio de nombres que se ha definido arriba de esta forma
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Crear una presentación
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Get the title slide layout
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Add a title slide.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Set the title text
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Set the sub title text
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Write the output to disk
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Ejemplo de Aspose.Slides para .NET**
**La salida de Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
```c#
//Crear una presentación
Presentation pres = new Presentation();

//Agregar la diapositiva de título
ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);


//Establecer el texto del título
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Slide Title Heading";

//Establecer el texto del subtítulo
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Slide Title Sub-Heading";

//Escribir la salida en disco
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```
