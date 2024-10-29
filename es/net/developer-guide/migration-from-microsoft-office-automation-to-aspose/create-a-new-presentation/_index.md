---
title: Crear una Nueva Presentación
type: docs
weight: 10
url: /es/net/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO fue desarrollado para permitir a los desarrolladores construir aplicaciones que pudieran ejecutarse dentro de Microsoft Office. VSTO se basa en COM, pero está envuelto dentro de un objeto .NET para que pueda ser utilizado en aplicaciones .NET. VSTO necesita soporte del marco .NET así como el runtime CLR de Microsoft Office. Aunque se puede utilizar para crear complementos de Microsoft Office, es casi imposible usarlo como un componente del lado del servidor. También tiene serios problemas de implementación.

Aspose.Slides para .NET es un componente que se puede usar para manipular presentaciones de Microsoft PowerPoint, al igual que VSTO, pero tiene varias ventajas:

- Aspose.Slides contiene solo código administrado y no requiere que se instale el runtime de Microsoft Office.
- Puede usarse como un componente del lado del cliente o como un componente del lado del servidor.
- La implementación es fácil ya que Aspose.Slides está contenido en una sola DLL.

{{% /alert %}} 
## **Creando una Presentación**
A continuación, se presentan dos ejemplos de código que ilustran cómo VSTO y Aspose.Slides para .NET se pueden usar para lograr el mismo objetivo. El primer ejemplo es [VSTO](/slides/es/net/create-a-new-presentation/); [el segundo ejemplo](/slides/es/net/create-a-new-presentation/) utiliza Aspose.Slides.
### **Ejemplo de VSTO**
**La salida de VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)



```c#
//Nota: PowerPoint es un espacio de nombres que ha sido definido arriba de la siguiente manera
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
slide.Shapes.Title.TextFrame.TextRange.Text = "Encabezado del Título de la Diapositiva";

//Establecer el texto del subtítulo
slide.Shapes[2].TextFrame.TextRange.Text = "Subtítulo del Título de la Diapositiva";

//Escribir la salida en el disco
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
((IAutoShape)slide.Shapes[0]).TextFrame.Text = "Encabezado del Título de la Diapositiva";

//Establecer el texto del subtítulo
((IAutoShape)slide.Shapes[1]).TextFrame.Text = "Subtítulo del Título de la Diapositiva";

//Escribir la salida en el disco
pres.Save("c:\\data\\outAsposeSlides.pptx", SaveFormat.Ppt);
```