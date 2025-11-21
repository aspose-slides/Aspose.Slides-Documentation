---
title: Administrar encabezados y pies de página de presentaciones en .NET
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/net/presentation-header-and-footer/
keywords:
- encabezado
- texto de encabezado
- pie de página
- texto de pie de página
- establecer encabezado
- establecer pie de página
- folleto
- notas
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Utilice Aspose.Slides para .NET para agregar y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument, logrando un aspecto profesional."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/net/) brinda soporte para trabajar con los textos de encabezados y pies de página de las diapositivas, que en realidad se mantienen a nivel de maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/es/net/) ofrece la funcionalidad para gestionar encabezados y pies de página dentro de las diapositivas de la presentación. Estos se gestionan, de hecho, a nivel del maestro de la presentación.
## **Administrar Texto de Encabezado y Pie de Página**
Las notas de una diapositiva específica pueden actualizarse como se muestra en el ejemplo a continuación:
```c#
// Cargar presentación
Presentation pres = new Presentation("headerTest.pptx");

// Establecer pie de página
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





## **Administrar Encabezado y Pie de Página en Diapositivas de Folleto y Notas**
Aspose.Slides for .NET admite Header y Footer en diapositivas de folleto y notas. Por favor, siga los pasos a continuación:

- Cargue una [Presentación](https://reference.aspose.com/slides/net/aspose.slides/presentation) que contenga un video.
- Cambie la configuración de Header y Footer para el maestro de notas y todas las diapositivas de notas.
- Establezca la diapositiva maestra de notas y todos los marcadores de posición de Footer secundarios visibles.
- Establezca la diapositiva maestra de notas y todos los marcadores de posición de Date and time secundarios visibles.
- Cambie la configuración de Header y Footer solo para la primera diapositiva de notas.
- Establezca visible el marcador de posición de Header de la diapositiva de notas.
- Establezca texto en el marcador de posición de Header de la diapositiva de notas.
- Establezca texto en el marcador de posición de Date-time de la diapositiva de notas.
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

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // establecer texto en la diapositiva maestra de notas y en todos los marcadores de posición de encabezado secundarios
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // establecer texto en la diapositiva maestra de notas y en todos los marcadores de posición de pie de página secundarios
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // establecer texto en la diapositiva maestra de notas y en todos los marcadores de posición de fecha y hora secundarios
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

**¿Puedo agregar un "header" a diapositivas normales?**

En PowerPoint, "Header" solo existe para notes y handouts; en diapositivas normales, los elementos compatibles son footer, date/time y slide number. En Aspose.Slides esto coincide con las mismas limitaciones: header solo para Notes/Handout, y en diapositivas—Footer/DateTime/SlideNumber.

**¿Qué pasa si el diseño no contiene un área de pie de página—puedo "activar" su visibilidad?**

Sí. Verifique la visibilidad a través del administrador de header/footer y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para casos en que el marcador de posición está ausente o oculto.

**¿Cómo hago que el número de diapositiva comience desde un valor distinto de 1?**

Establezca el [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/); después de eso, toda la numeración se recalcula. Por ejemplo, puede comenzar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué sucede con los encabezados/pies de página al exportar a PDF/Imágenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en diapositivas/notes pages, también aparecerán en el formato de salida junto con el resto del contenido.