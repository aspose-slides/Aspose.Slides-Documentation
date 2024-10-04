---
title: Encabezado y pie de página de presentación
type: docs
weight: 140
url: /net/presentation-header-and-footer/
keywords: "Encabezado, pie de página, establecer encabezado, establecer pie de página, establecer encabezado y pie de página, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Encabezado y pie de página de PowerPoint en C# o .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/net/) proporciona soporte para trabajar con el texto de los encabezados y pies de página de las diapositivas que se mantienen en el nivel de maestro de diapositiva.

{{% /alert %}} 

[Aspose.Slides para .NET](/slides/net/) proporciona la funcionalidad para gestionar encabezados y pies de página dentro de las diapositivas de presentación. De hecho, estos se gestionan a nivel de maestro de presentación.
## **Gestionar texto de Encabezado y Pie de Página**
Las notas de una diapositiva específica podrían ser actualizadas como se muestra en el siguiente ejemplo:

```c#
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");

// Configuración de pie de página
pres.HeaderFooterManager.SetAllFootersText("Mi texto de pie de página");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Acceder y actualizar encabezado
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Guardar presentación
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Método para establecer texto de Encabezado/Pie de Página
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "Hola, nuevo encabezado";
            }
        }
    }
}
```




## **Gestionar Encabezado y Pie de Página en Diapositivas de Entrega y Notas**
Aspose.Slides para .NET admite encabezados y pies de página en diapositivas de entrega y notas. Por favor, siga los pasos a continuación:

- Cargar una [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga un video.
- Cambiar la configuración de Encabezado y Pie de Página para el maestro de notas y todas las diapositivas de notas.
- Hacer visibles el maestro de notas y todos los marcadores de pie de página hijos.
- Hacer visibles el maestro de notas y todos los marcadores de fecha y hora hijos.
- Cambiar la configuración de Encabezado y Pie de Página solo para la primera diapositiva de notas.
- Hacer visible el marcador de encabezado de la diapositiva de notas.
- Establecer texto en el marcador de encabezado de la diapositiva de notas.
- Establecer texto en el marcador de fecha y hora de la diapositiva de notas.
- Escribir el archivo de presentación modificado.

Fragmento de código proporcionado en el siguiente ejemplo.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Cambiar la configuración de Encabezado y Pie de Página para el maestro de notas y todas las diapositivas de notas
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // hacer visibles el maestro de notas y todos los marcadores de pie de página hijos
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // hacer visibles el maestro de notas y todos los marcadores de encabezado hijos
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // hacer visibles el maestro de notas y todos los marcadores de número de diapositiva hijos
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // hacer visibles el maestro de notas y todos los marcadores de fecha y hora hijos

		headerFooterManager.SetHeaderAndChildHeadersText("Texto del encabezado"); // establecer texto en el maestro de notas y todos los marcadores de encabezado hijos
		headerFooterManager.SetFooterAndChildFootersText("Texto del pie de página"); // establecer texto en el maestro de notas y todos los marcadores de pie de página hijos
		headerFooterManager.SetDateTimeAndChildDateTimesText("Texto de fecha y hora"); // establecer texto en el maestro de notas y todos los marcadores de fecha y hora hijos
	}

	// Cambiar la configuración de Encabezado y Pie de Página solo para la primera diapositiva de notas
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // hacer visible este marcador de encabezado de la diapositiva de notas

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // hacer visible este marcador de pie de página de la diapositiva de notas

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // hacer visible este marcador de número de diapositiva de la diapositiva de notas

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // hacer visible este marcador de fecha y hora de la diapositiva de notas

		headerFooterManager.SetHeaderText("Nuevo texto de encabezado"); // establecer texto en el marcador de encabezado de la diapositiva de notas
		headerFooterManager.SetFooterText("Nuevo texto de pie de página"); // establecer texto en el marcador de pie de página de la diapositiva de notas
		headerFooterManager.SetDateTimeText("Nuevo texto de fecha y hora"); // establecer texto en el marcador de fecha y hora de la diapositiva de notas
	}
	presentation.Save("testresult.pptx", SaveFormat.Pptx);
}
		
 }
```