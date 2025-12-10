---
title: Administrar encabezados y pies de página de la presentación en .NET
linktitle: Encabezado y Pie de página
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
description: "Utilice Aspose.Slides para .NET para añadir y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument, logrando un aspecto profesional."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/net/) proporciona soporte para trabajar con el texto de encabezados y pies de página de las diapositivas, que se mantienen realmente a nivel del maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides for .NET](/slides/es/net/) ofrece la funcionalidad para administrar encabezados y pies de página dentro de las diapositivas de la presentación. De hecho, se gestionan a nivel del maestro de la presentación.
## **Administrar texto de encabezado y pie de página**
Las notas de alguna diapositiva específica pueden actualizarse como se muestra en el siguiente ejemplo:
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
 // Método para establecer el texto del encabezado/pie de página
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





## **Administrar encabezados y pies de página en diapositivas de folleto y notas**
Aspose.Slides for .NET admite encabezados y pies de página en diapositivas de folleto y notas. Siga los pasos a continuación:

- Cargue una [Presentación ](https://reference.aspose.com/slides/net/aspose.slides/presentation)que contenga un video.
- Cambie la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas.
- Haga visibles los marcadores de posición de pie de página del maestro de notas y de todos los hijos.
- Haga visibles los marcadores de posición de fecha y hora del maestro de notas y de todos los hijos.
- Cambie la configuración de encabezado y pie de página solo para la primera diapositiva de notas.
- Haga visible el marcador de posición de encabezado de la diapositiva de notas.
- Asigne texto al marcador de posición de encabezado de la diapositiva de notas.
- Asigne texto al marcador de posición de fecha y hora de la diapositiva de notas.
- Guarde el archivo de presentación modificado.

Fragmento de código proporcionado en el siguiente ejemplo.
```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Cambiar la configuración de encabezado y pie de página para el maestro de notas y todas las diapositivas de notas
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // hacer visibles la diapositiva maestra de notas y todos los marcadores de posición de pie de página hijos
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // hacer visibles la diapositiva maestra de notas y todos los marcadores de posición de encabezado hijos
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // hacer visibles la diapositiva maestra de notas y todos los marcadores de posición de número de diapositiva hijos
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // hacer visibles la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora hijos

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de encabezado hijos
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de pie de página hijos
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora hijos
	}

	// Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // hacer visible este marcador de posición de encabezado de la diapositiva de notas

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // hacer visible este marcador de posición de pie de página de la diapositiva de notas

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // hacer visible este marcador de posición de número de diapositiva de la diapositiva de notas

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // hacer visible este marcador de posición de fecha y hora de la diapositiva de notas

		headerFooterManager.SetHeaderText("New header text"); // establecer texto en el marcador de posición de encabezado de la diapositiva de notas
		headerFooterManager.SetFooterText("New footer text"); // establecer texto en el marcador de posición de pie de página de la diapositiva de notas
		headerFooterManager.SetDateTimeText("New date and time text"); // establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```


## **Preguntas frecuentes**

**¿Puedo añadir un "encabezado" a diapositivas normales?**

En PowerPoint, el "encabezado" solo existe para notas y folletos; en diapositivas normales, los elementos compatibles son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para notas/folletos, y en las diapositivas—pie de página/fecha‑hora/número‑de‑diapositiva.

**¿Qué pasa si el diseño no contiene un área de pie de página, puedo "activar" su visibilidad?**

Sí. Verifique la visibilidad mediante el gestor de encabezado/pie de página y habilítela si es necesario. Estos indicadores y métodos de la API están diseñados para los casos en que el marcador de posición falta o está oculto.

**¿Cómo hago que la numeración de diapositivas comience desde un valor distinto de 1?**

Establezca el [primer número de diapositiva](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) de la presentación; después de eso, toda la numeración se recalcula. Por ejemplo, puede iniciar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imagenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en las diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.