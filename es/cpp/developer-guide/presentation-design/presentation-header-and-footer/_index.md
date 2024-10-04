---
title: Encabezado y pie de página de presentación
type: docs
weight: 140
url: /es/cpp/presentation-header-and-footer/
keywords: "Encabezado y pie de página en PowerPoint"
description: "Encabezado y pie de página en PowerPoint con Aspose.Slides."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/es/cpp/) proporciona soporte para trabajar con el texto de los encabezados y pies de página de las diapositivas que se mantienen a nivel de maestro de diapositivas.

{{% /alert %}} 

[Aspose.Slides para C++](/slides/es/cpp/) proporciona la función para gestionar encabezados y pies de página dentro de las diapositivas de presentación. Estos se gestionan en el nivel de maestro de presentación.
## **Gestionar texto de encabezado y pie de página**
Las notas de una diapositiva específica pueden actualizarse como se muestra en el ejemplo a continuación:

``` cpp
// Función para establecer texto de Encabezado/Pie de Página
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"Hola, nuevo encabezado");
            }
        }
    }
}
```

``` cpp
// Cargar presentación
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Establecer pie de página
pres->get_HeaderFooterManager()->SetAllFootersText(u"Mi texto de pie de página");
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

## **Gestionar encabezado y pie de página en diapositivas de entrega y notas**
Aspose.Slides para C++ soporta encabezado y pie de página en diapositivas de entrega y notas. Siga los pasos a continuación:

- Cargue una [Presentación](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) que contenga un video.
- Cambie la configuración del encabezado y pie de página para el maestro de notas y todas las diapositivas de notas.
- Establezca el maestro de diapositivas de notas y todos los marcadores de pie de página visibles.
- Establezca el maestro de diapositivas de notas y todos los marcadores de fecha y hora visibles.
- Cambie la configuración del encabezado y pie de página solo para la primera diapositiva de notas.
- Haga visible el marcador de encabezado de la diapositiva de notas.
- Establezca el texto en el marcador de encabezado de la diapositiva de notas.
- Establezca el texto en el marcador de fecha y hora de la diapositiva de notas.
- Escriba el archivo de presentación modificado.

Fragmento de código proporcionado en el siguiente ejemplo.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Cambie la configuración del encabezado y pie de página para el maestro de notas y todas las diapositivas de notas
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// haga visible el maestro de diapositivas de notas y todos los marcadores de pie de página
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// haga visible el maestro de diapositivas de notas y todos los marcadores de encabezado
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// haga visible el maestro de diapositivas de notas y todos los marcadores de número de diapositiva
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// haga visible el maestro de diapositivas de notas y todos los marcadores de fecha y hora
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// establezca el texto en el maestro de diapositivas de notas y todos los marcadores de encabezado
	headerFooterManager->SetHeaderAndChildHeadersText(u"Texto del encabezado");
	// establezca el texto en el maestro de diapositivas de notas y todos los marcadores de pie de página
	headerFooterManager->SetFooterAndChildFootersText(u"Texto del pie de página");
	// establezca el texto en el maestro de diapositivas de notas y todos los marcadores de fecha y hora
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Texto de fecha y hora");
}

// Cambie la configuración del encabezado y pie de página solo para la primera diapositiva de notas
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// haga visible el marcador de encabezado de esta diapositiva de notas
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// haga visible el marcador de pie de página de esta diapositiva de notas
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// haga visible el marcador de número de diapositiva de esta diapositiva de notas
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// haga visible el marcador de fecha y hora de esta diapositiva de notas
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// establezca el texto en el marcador de encabezado de la diapositiva de notas
	headerFooterManager->SetHeaderText(u"Nuevo texto de encabezado");
	// establezca el texto en el marcador de pie de página de la diapositiva de notas
	headerFooterManager->SetFooterText(u"Nuevo texto de pie de página");
	// establezca el texto en el marcador de fecha y hora de la diapositiva de notas
	headerFooterManager->SetDateTimeText(u"Nuevo texto de fecha y hora");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```