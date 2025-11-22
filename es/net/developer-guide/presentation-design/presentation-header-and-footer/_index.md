---
title: Encabezado y pie de página de la presentación
type: docs
weight: 140
url: /es/net/presentation-header-and-footer/
keywords: "Encabezado, pie de página, establecer encabezado, establecer pie de página, establecer encabezado y pie de página, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Encabezado y pie de página de PowerPoint en C# o .NET"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/net/) ofrece soporte para trabajar con el texto de encabezados y pies de página de diapositivas que, en realidad, se mantiene a nivel de patrón de diapositiva.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/es/net/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de una presentación. Estos se administran, de hecho, a nivel del patrón de la presentación.
## **Administrar texto de encabezado y pie de página**
Las notas de una diapositiva específica pueden actualizarse como se muestra en el ejemplo a continuación:
```c#
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");

// Estableciendo pie de página
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
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
// Método para establecer texto de encabezado/pie de página
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```





## **Administrar encabezado y pie de página en diapositivas de folleto y notas**
Aspose.Slides for .NET admite encabezado y pie de página en diapositivas de folleto y notas. Siga los pasos a continuación:

- Cargue una [Presentación ](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga un video.
- Cambie la configuración de encabezado y pie de página para el patrón de notas y todas las diapositivas de notas.
- Establezca visibles los marcadores de posición de pie de página del patrón de notas y de todos sus hijos.
- Establezca visibles los marcadores de posición de fecha y hora del patrón de notas y de todos sus hijos.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Establezca visible el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de fecha‑hora de la diapositiva de notas.
- Guarde el archivo de presentación modificado.

Fragmento de código proporcionado en el ejemplo a continuación.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Cambiar la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de número de diapositiva secundarios
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // hacer visible la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios
	}

	// Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // hacer visible el marcador de posición de encabezado de esta diapositiva de notas

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // hacer visible el marcador de posición de pie de página de esta diapositiva de notas

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // hacer visible el marcador de posición de número de diapositiva de esta diapositiva de notas

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // hacer visible el marcador de posición de fecha y hora de esta diapositiva de notas

		headerFooterManager.SetHeaderText("New header text"); // establecer texto en el marcador de posición de encabezado de la diapositiva de notas
		headerFooterManager.SetFooterText("New footer text"); // establecer texto en el marcador de posición de pie de página de la diapositiva de notas
		headerFooterManager.SetDateTimeText("New date and time text"); // establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **Preguntas frecuentes**

**¿Puedo agregar un "encabezado" a diapositivas normales?**

En PowerPoint, el "encabezado" solo existe para notas y folletos; en diapositivas normales, los elementos compatibles son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notas/Folleto, y en diapositivas—Pie de página/FechaHora/NúmeroDeDiapositiva.

**¿Y si el diseño no contiene un área de pie de página, puedo "activar" su visibilidad?**

Sí. Verifique la visibilidad mediante el administrador de encabezado/pie de página y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en los que el marcador de posición falta o está oculto.

**¿Cómo hago que la numeración de diapositivas comience en un valor distinto de 1?**

Establezca el [primer número de diapositiva] (https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la presentación; después de eso, toda la numeración se recalcula. Por ejemplo, puede iniciar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imágenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en las diapositivas o páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.