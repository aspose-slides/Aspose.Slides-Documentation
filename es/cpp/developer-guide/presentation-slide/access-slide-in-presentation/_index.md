---
title: Acceder a la Diapositiva en la Presentación
type: docs
weight: 20
url: /cpp/access-slide-in-presentation/
keywords: "Acceder a la Presentación de PowerPoint, Acceder diapositiva, Editar propiedades de la diapositiva, Cambiar posición de la diapositiva, Establecer número de diapositiva, índice, ID, posición C++, CPP, Aspose.Slides"
description: "Acceder a la diapositiva de PowerPoint por índice, ID o posición en C++. Editar propiedades de la diapositiva"
---

Aspose.Slides permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a la Diapositiva por Índice**

Todas las diapositivas en una presentación están ordenadas numéricamente según la posición de la diapositiva, comenzando desde 0. La primera diapositiva es accesible a través del índice 0; la segunda diapositiva se accede a través del índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)). Este código C++ muestra cómo acceder a una diapositiva a través de su índice:

```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene la referencia de una diapositiva a través de su índice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Acceder a la Diapositiva por ID**

Cada diapositiva en una presentación tiene un ID único asociado a ella. Puedes usar el método [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) para apuntar a ese ID. Este código C++ muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva a través del método [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/):

```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene el ID de una diapositiva
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Accede a la diapositiva a través de su ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Cambiar la Posición de la Diapositiva**

Aspose.Slides permite cambiar la posición de una diapositiva. Por ejemplo, puedes especificar que la primera diapositiva debe convertirse en la segunda diapositiva.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén la referencia de la diapositiva (cuya posición deseas cambiar) a través de su índice.
1. Establece una nueva posición para la diapositiva a través de la propiedad [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/).
1. Guarda la presentación modificada.

Este código C++ demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:

```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene la diapositiva cuya posición será cambiada
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Establece la nueva posición para la diapositiva
	slide->set_SlideNumber(2);

	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

La primera diapositiva se convirtió en la segunda; la segunda diapositiva se convirtió en la primera. Al cambiar la posición de una diapositiva, otras diapositivas se ajustan automáticamente.

## **Establecer Número de Diapositiva**

Usando la propiedad [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), puedes especificar un nuevo número para la primera diapositiva en una presentación. Esta operación hace que otros números de diapositivas se recalculen.

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén el número de la diapositiva.
1. Establece el número de la diapositiva.
1. Guarda la presentación modificada.

Este código C++ muestra una operación donde el número de la primera diapositiva se establece en 10:

```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene el número de la diapositiva
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Establece el número de la diapositiva
	pres->set_FirstSlideNumber(2);
	
	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Si prefieres omitir la primera diapositiva, puedes iniciar la numeración desde la segunda diapositiva (y ocultar la numeración para la primera diapositiva) de esta manera:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Establece el número para la primera diapositiva de la presentación
presentation->set_FirstSlideNumber(0);

// Muestra los números de las diapositivas para todas las diapositivas
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Oculta el número de la diapositiva para la primera diapositiva
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Guarda la presentación modificada
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```