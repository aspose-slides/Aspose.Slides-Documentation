---
title: Diseño de Diapositivas
type: docs
weight: 60
url: /es/cpp/slide-layout/
keyword: "Configurar tamaño de diapositivas, establecer opciones de diapositivas, especificar tamaño de diapositiva, visibilidad del pie de página, pie de página secundario, escalado de contenido, tamaño de página, C++, CPP, Aspose.Slides"
description: "Configurar el tamaño y las opciones de las diapositivas de PowerPoint en C++"
---

Un diseño de diapositivas contiene las cajas de marcadores de posición e información de formato para todo el contenido que aparece en una diapositiva. El diseño determina los marcadores de posición de contenido disponibles y dónde se colocan.

Los diseños de diapositivas te permiten crear y diseñar presentaciones rápidamente (ya sea sencillas o complejas). Estos son algunos de los diseños de diapositivas más populares utilizados en presentaciones de PowerPoint:

* **Diseño de Diapositiva de Título**. Este diseño consiste en dos marcadores de posición de texto. Un marcador de posición es para el título y el otro es para el subtítulo.
* **Diseño de Título y Contenido**. Este diseño contiene un marcador de posición relativamente pequeño en la parte superior para el título y un marcador de posición más grande para el contenido principal (gráfico, párrafos, lista con viñetas, lista numerada, imágenes, etc.).
* **Diseño en Blanco**. Este diseño carece de marcadores de posición, por lo que te permite crear elementos desde cero.

Dado que una maestra de diapositivas es la diapositiva jerárquica principal que almacena información sobre los diseños de diapositivas, puedes usar la diapositiva maestra para acceder a los diseños de diapositivas y realizar cambios en ellos. Una diapositiva de diseño puede ser accedida por tipo o nombre. De manera similar, cada diapositiva tiene un id único, que se puede utilizar para acceder a ella.

Alternativamente, puedes hacer cambios directamente en un diseño de diapositiva específico en una presentación.

* Para permitirte trabajar con diseños de diapositivas (incluyendo aquellos en diapositivas maestras), Aspose.Slides proporciona propiedades como [get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/) y [get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) bajo la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
* Para realizar tareas relacionadas, Aspose.Slides proporciona [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/), y muchos otros tipos.

{{% alert title="Información" color="info" %}}

Para más información sobre el trabajo con Diapositivas Maestras en particular, consulta el artículo [Diapositiva Maestra](https://docs.aspose.com/slides/cpp/slide-master/).

{{% /alert %}}

## **Agregar Diseño de Diapositiva a la Presentación**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Accede a la colección [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Revisa las diapositivas de diseño existentes para confirmar que la diapositiva de diseño requerida ya existe en la colección de Diapuestas. De lo contrario, agrega la diapositiva de diseño que desees.
1. Agrega una diapositiva vacía basada en la nueva diapositiva de diseño.
1. Guarda la presentación.

Este código C++ te muestra cómo agregar un diseño de diapositiva a una presentación de PowerPoint:

```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/AddLayoutSlides.pptx";

	// Instancia una clase de Presentación que representa el archivo de presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Revisa los tipos de diapositivas de diseño
	SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();

	SharedPtr<ILayoutSlide> layoutSlide;
	if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
	}
	else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
	{
		layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
	}

	if (layoutSlide == NULL)
	{
		// La situación en la que una presentación no contiene algunos tipos de diseño.
		// El archivo de presentación solo contiene tipos de diseño en Blanco y Personalizado.
		// Pero las diapositivas de diseño con tipos Personalizados tienen diferentes nombres de diapositiva,
		// como "Título", "Título y Contenido", etc. Y es posible usar estos
		// nombres para la selección de diapositivas de diseño.
		// También puedes usar un conjunto de tipos de formas de marcador de posición. Por ejemplo,
		// la diapositiva de título debe tener solo el tipo de marcador de posición de Título, etc.

		for (int i = 0; i<layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

			if (titleAndObjectLayoutSlide->get_Name().Equals(u"Título y Objeto"))
			{
				layoutSlide = titleAndObjectLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			for (int i = 0; i < layoutSlides->get_Count(); i++)
			{
				SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

				if (titleLayoutSlide->get_Name().Equals(u"Título"))
				{
					layoutSlide = titleLayoutSlide;
					break;
				}
			}

			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
				if (layoutSlide == NULL)
				{
					layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Título y Objeto");
				}
			}
		}
	}

	// Agrega una diapositiva vacía con el diseño de diapositiva añadido  
	pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

	// Guarda la presentación en disco
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Eliminar Diapositivas de Diseño No Utilizadas**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código C++ te muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);

```

## **Configurar Tamaño y Tipo de Diapositiva**

Para permitirte establecer el tamaño y tipo de una diapositiva de diseño específica, Aspose.Slides proporciona las propiedades [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) y [get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/) (de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)). Este C++ demuestra la operación:

```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
	// Instancia un objeto de Presentación que representa un archivo de presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	SharedPtr<Presentation> destPres = MakeObject<Presentation>();

	// Accede a la Diapositiva por ID desde la colección
	SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();
	
	// Establece el tamaño de la diapositiva para la presentación generada al de la fuente
	destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

	slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

	// Guarda la presentación en disco
	destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Configurar Visibilidad del Pie de Página Dentro de la Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia a la diapositiva a través de su índice.
1. Establece la visibilidad del marcador de posición del pie de página de la diapositiva en visible.
1. Establece la visibilidad del marcador de posición de fecha y hora en visible.
1. Guarda la presentación.

Este código C++ te muestra cómo configurar la visibilidad de un pie de página de diapositiva (y realizar tareas relacionadas):

```c++
 // La ruta al directorio de documentos.
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instancia una clase SlideCollection
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // La propiedad IsFooterVisible se usa para especificar que falta un marcador de posición para el pie de página
{
	headerFooterManager->SetFooterVisibility(true); // El método SetFooterVisibility se usa para establecer un marcador de posición para el pie de página de la diapositiva en visible
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // La propiedad IsSlideNumberVisible se usa para especificar que falta un marcador de posición para el número de página de la diapositiva
{
	headerFooterManager->SetSlideNumberVisibility(true); // El método SetSlideNumberVisibility se usa para establecer un marcador de posición para el número de página de la diapositiva en visible
}
if (!headerFooterManager->get_IsDateTimeVisible()) // La propiedad IsDateTimeVisible se usa para especificar que falta un marcador de posición para la fecha y hora de la diapositiva
{
	headerFooterManager->SetDateTimeVisibility(true); // El método SetFooterVisibility se usa para establecer un marcador de posición para la fecha y hora de la diapositiva en visible
}
headerFooterManager->SetFooterText(u"Texto del pie de página"); // El método SetFooterText se usa para establecer un texto para un marcador de posición del pie de página de la diapositiva
headerFooterManager->SetDateTimeText(u"Texto de fecha y hora"); // El método SetDateTimeText se usa para establecer un texto para un marcador de posición de fecha y hora de la diapositiva.


// Guarda la presentación en disco
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Configurar Visibilidad del Pie de Página Secundario Dentro de la Diapositiva**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia para la diapositiva maestra a través de su índice.
1. Establece la visibilidad de la diapositiva maestra y todos los marcadores de posición de pie de página secundarios en visible.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios.
1. Establece un texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios.
1. Guarda la presentación.

Este código C++ demuestra la operación:

```c++
// La ruta al directorio de documentos.
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// Instancia una clase SlideCollection
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // El método SetFooterAndChildFootersVisibility se usa para establecer la diapositiva maestra y todos los marcadores de posición de pie de página secundarios en visible
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // El método SetSlideNumberAndChildSlideNumbersVisibility se usa para establecer la diapositiva maestra y todos los marcadores de posición de número de página secundarios en visible
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // El método SetDateTimeAndChildDateTimesVisibility se usa para establecer la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios en visible

headerFooterManager->SetFooterAndChildFootersText(u"Texto del pie de página"); // El método SetFooterAndChildFootersText se usa para establecer textos para la diapositiva maestra y todos los marcadores de posición de pie de página secundarios
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Texto de fecha y hora"); // El método SetDateTimeAndChildDateTimesText se usa para establecer texto para la diapositiva maestra y todos los marcadores de posición de fecha y hora secundarios

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Configurar Tamaño de Diapositiva con Respecto al Escalado de Contenido**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) y carga la presentación que contiene la diapositiva cuyo tamaño deseas establecer.
1. Crea otra instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) para generar una nueva presentación.
1. Obtén la referencia de la diapositiva (de la primera presentación) a través de su índice.
1. Establece la visibilidad del marcador de posición del pie de página de la diapositiva en visible.
1. Establece la visibilidad del marcador de posición de fecha y hora en visible.
1. Guarda la presentación.

Este código C++ demuestra la operación:

```c++
// La ruta al directorio de documentos.
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// Instancia una clase SlideCollection
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// Establece el tamaño de la diapositiva para las presentaciones generadas al de la fuente
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // El método SetSize se usa para establecer el tamaño de la diapositiva con escalado del contenido para asegurar que se ajuste
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // El método SetSize se usa para establecer el tamaño de la diapositiva con el tamaño máximo del contenido

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// Guarda la presentación
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Configurar Tamaño de Página al Generar PDF**

Ciertas presentaciones (como carteles) a menudo se convierten en documentos PDF. Si buscas convertir tu PowerPoint a PDF para acceder a las mejores opciones de impresión y accesibilidad, deseas establecer tus diapositivas en tamaños que se adapten a los documentos PDF (A4, por ejemplo).

Aspose.Slides proporciona la clase [SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/) para permitirte especificar tus configuraciones preferidas para las diapositivas. Este código C++ te muestra cómo usar la propiedad [get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/) (de la clase `SlideSize`) para establecer un tamaño de papel específico para las diapositivas en una presentación:

```c++
// La ruta al directorio de documentos.
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// Instancia un objeto de Presentación que representa un archivo de presentación 
	SharedPtr<Presentation>pres = MakeObject<Presentation>();

	// Establece la propiedad SlideSize.Type
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// Establece diferentes propiedades de las Opciones PDF
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution (600);

	// Guarda la presentación
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```