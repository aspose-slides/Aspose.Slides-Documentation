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

VSTO se desarrolló para permitir a los desarrolladores crear aplicaciones que puedan ejecutarse dentro de Microsoft Office. VSTO se basa en COM, pero está envuelto dentro de un objeto .NET para que pueda usarse en aplicaciones .NET. VSTO necesita soporte del .NET Framework así como del tiempo de ejecución basado en CLR de Microsoft Office. Aunque puede usarse para crear complementos de Microsoft Office, es casi imposible usarlo como componente del lado del servidor. También tiene serios problemas de implementación.

Aspose.Slides for .NET es un componente que puede usarse para manipular presentaciones de Microsoft PowerPoint, al igual que VSTO, pero tiene varias ventajas:

- Aspose.Slides contiene solo código administrado y no requiere que el tiempo de ejecución de Microsoft Office esté instalado.
- Puede usarse como componente del lado del cliente o del lado del servidor.
- La implementación es fácil ya que Aspose.Slides se encuentra en un solo DLL.

{{% /alert %}} 
## **Creando una presentación**
A continuación se presentan dos ejemplos de código que ilustran cómo VSTO y Aspose.Slides for .NET pueden usarse para lograr el mismo objetivo. El primer ejemplo es [VSTO](/slides/es/net/create-a-new-presentation/); [el segundo ejemplo](/slides/es/net/create-a-new-presentation/) utiliza Aspose.Slides.
### **Ejemplo VSTO**
**La salida de VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)
```c#
//Nota: PowerPoint es un espacio de nombres que se ha definido arriba de esta manera
//using PowerPoint = Microsoft.Office.Interop.PowerPoint;

//Crear una presentación
PowerPoint.Presentation pres = Globals.ThisAddIn.Application
	.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Obtener el diseño de la diapositiva de título
PowerPoint.CustomLayout layout = pres.SlideMaster.
	CustomLayouts[PowerPoint.PpSlideLayout.ppLayoutTitle];

//Agregar una diapositiva de título.
PowerPoint.Slide slide = pres.Slides.AddSlide(1, layout);

//Establecer el texto del título
slide.Shapes.Title.TextFrame.TextRange.Text = "Slide Title Heading";

//Establecer el texto del subtítulo
slide.Shapes[2].TextFrame.TextRange.Text = "Slide Title Sub-Heading";

//Escribir la salida en disco
pres.SaveAs("c:\\outVSTO.ppt",
	PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
	Microsoft.Office.Core.MsoTriState.msoFalse);
```



### **Ejemplo Aspose.Slides for .NET**
**La salida de Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)
{{af720cbf-37d1-445c-8f1d-69c457ced98}}