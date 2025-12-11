---
title: Administrar encabezados y pies de página de la presentación en C++
linktitle: Encabezado y pie de página
type: docs
weight: 140
url: /es/cpp/presentation-header-and-footer/
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
- C++
- Aspose.Slides
description: "Utilice Aspose.Slides para C++ para agregar y personalizar encabezados y pies de página en presentaciones de PowerPoint y OpenDocument, logrando un aspecto profesional."
---

{{% alert color="primary" %}}
[Aspose.Slides](/slides/es/cpp/) provee soporte para trabajar con los encabezados y pies de página de las diapositivas, cuyo texto se mantiene realmente a nivel de la diapositiva maestra.
{{% /alert %}}

[Aspose.Slides for C++](/slides/es/cpp/) proporciona la funcionalidad para gestionar encabezados y pies de página dentro de las diapositivas de la presentación. Estos se gestionan, de hecho, a nivel de la diapositiva maestra.
## **Administrar texto de encabezado y pie de página**
Las notas de una diapositiva específica pueden actualizarse como se muestra en el ejemplo a continuación:
``` cpp
// Función para establecer texto de encabezado/pie de página
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Cargar presentación
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Configurar pie de página
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Acceder y actualizar encabezado
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Guardar presentación
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```


## **Administrar encabezados y pies de página en diapositivas de folletos y notas**
Aspose.Slides para C++ admite encabezados y pies de página en diapositivas de folletos y notas. Por favor, siga los pasos a continuación:

- Cargue una [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que contenga un video.
- Cambie la configuración de Encabezado y Pie de página para la maestro de notas y todas las diapositivas de notas.
- Establezca visibles los marcadores de posición de pie de página en la diapositiva maestra de notas y en todas sus diapositivas secundarias.
- Establezca visibles los marcadores de posición de fecha y hora en la diapositiva maestra de notas y en todas sus diapositivas secundarias.
- Cambie la configuración de Encabezado y Pie de página solo para la primera diapositiva de notas.
- Establezca visible el marcador de posición de encabezado en la diapositiva de notas.
- Establezca texto en el marcador de posición de encabezado de la diapositiva de notas.
- Establezca texto en el marcador de posición de fecha y hora de la diapositiva de notas.
- Guarde el archivo de presentación modificado.

Fragmento de código provisto en el siguiente ejemplo.
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Cambiar la configuración de encabezado y pie de página para la diapositiva maestra de notas y todas las diapositivas de notas
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de número de diapositiva secundarios
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// hacer visible la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de encabezado secundarios
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de pie de página secundarios
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// establecer texto en la diapositiva maestra de notas y todos los marcadores de posición de fecha y hora secundarios
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Cambiar la configuración de encabezado y pie de página solo para la primera diapositiva de notas
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// hacer visible este marcador de posición de encabezado en la diapositiva de notas
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// hacer visible este marcador de posición de pie de página en la diapositiva de notas
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// hacer visible este marcador de posición de número de diapositiva en la diapositiva de notas
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// hacer visible este marcador de posición de fecha y hora en la diapositiva de notas
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// establecer texto en el marcador de posición de encabezado de la diapositiva de notas
	headerFooterManager->SetHeaderText(u"New header text");
	// establecer texto en el marcador de posición de pie de página de la diapositiva de notas
	headerFooterManager->SetFooterText(u"New footer text");
	// establecer texto en el marcador de posición de fecha y hora de la diapositiva de notas
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **FAQ**

**¿Puedo añadir un "encabezado" a diapositivas normales?**

En PowerPoint, el "Encabezado" existe solo para notas y folletos; en diapositivas normales, los elementos admitidos son el pie de página, la fecha/hora y el número de diapositiva. En Aspose.Slides esto coincide con las mismas limitaciones: encabezado solo para Notas/Folletos, y en diapositivas—Pie de página/FechaHora/NúmeroDeDiapositiva.

**¿Qué pasa si el diseño no contiene un área de pie de página—puedo "activarla"?**

Sí. Verifique la visibilidad mediante el administrador de encabezado/pie de página y actívela si es necesario. Estos indicadores y métodos de la API están diseñados para los casos en que el marcador de posición falta o está oculto.

**¿Cómo hago que el número de diapositiva empiece desde un valor diferente a 1?**

Configure el [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/); después de eso, toda la numeración se recalcula. Por ejemplo, puede comenzar en 0 o 10, y ocultar el número en la diapositiva de título.

**¿Qué ocurre con los encabezados/pies de página al exportar a PDF/imagenes/HTML?**

Se renderizan como elementos de texto normales de la presentación. Es decir, si los elementos son visibles en diapositivas/páginas de notas, también aparecerán en el formato de salida junto con el resto del contenido.