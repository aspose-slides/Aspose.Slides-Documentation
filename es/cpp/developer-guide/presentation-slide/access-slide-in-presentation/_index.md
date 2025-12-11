---
title: Acceder a diapositivas de presentación en C++
linktitle: Acceder a diapositiva
type: docs
weight: 20
url: /es/cpp/access-slide-in-presentation/
keywords:
- acceder a diapositiva
- índice de diapositiva
- id de diapositiva
- posición de diapositiva
- cambiar posición
- propiedades de diapositiva
- número de diapositiva
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo acceder y gestionar diapositivas en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para C++. Mejore la productividad con ejemplos de código."
---

Aspose.Slides le permite acceder a las diapositivas de dos maneras: por índice y por ID.

## **Acceder a una diapositiva por índice**

Todas las diapositivas de una presentación se organizan numéricamente según la posición de la diapositiva, comenzando en 0. La primera diapositiva es accesible mediante el índice 0; la segunda diapositiva se accede mediante el índice 1; etc.

La clase Presentation, que representa un archivo de presentación, expone todas las diapositivas como una colección [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) (colección de objetos [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)). Este código C++ le muestra cómo acceder a una diapositiva mediante su índice: 
```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene una referencia a una diapositiva mediante su índice
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```



## **Acceder a una diapositiva por ID**

Cada diapositiva de una presentación tiene un ID único asociado. Puede usar el método [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) (expuesto por la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)) para dirigirse a ese ID. Este código C++ le muestra cómo proporcionar un ID de diapositiva válido y acceder a esa diapositiva mediante el método [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/):
```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene el ID de una diapositiva
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Accede a la diapositiva mediante su ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```


## **Cambiar la posición de una diapositiva**

Aspose.Slides le permite cambiar la posición de una diapositiva. Por ejemplo, puede especificar que la primera diapositiva se convierta en la segunda.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga la referencia de la diapositiva (cuya posición desea cambiar) mediante su índice
1. Establezca una nueva posición para la diapositiva mediante la propiedad [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/). 
1. Guarde la presentación modificada.

Este código C++ demuestra una operación en la que la diapositiva en la posición 1 se mueve a la posición 2:
```c++
	// La ruta al directorio de documentos.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene la diapositiva cuya posición se cambiará
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Establece la nueva posición para la diapositiva
	slide->set_SlideNumber(2);

	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



La primera diapositiva pasó a ser la segunda; la segunda diapositiva pasó a ser la primera. Cuando cambia la posición de una diapositiva, las demás diapositivas se ajustan automáticamente.

## **Establecer el número de diapositiva**

Usando la propiedad [set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) (expuesta por la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)), puede especificar un nuevo número para la primera diapositiva de una presentación. Esta operación provoca que se recalculen los números de las demás diapositivas.

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga el número de diapositiva.
1. Establezca el número de diapositiva.
1. Guarde la presentación modificada.

Este código C++ demuestra una operación en la que se establece el número de la primera diapositiva en 10: 
```c++
	// La ruta al directorio de documentos.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instancia la clase Presentation
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Obtiene el número de la diapositiva
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Establece el número de la diapositiva
	pres->set_FirstSlideNumber(2);
	
	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


Si prefiere omitir la primera diapositiva, puede comenzar la numeración a partir de la segunda diapositiva (y ocultar la numeración de la primera diapositiva) de esta manera:
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**¿El número de diapositiva que ve el usuario coincide con el índice basado en cero de la colección?**

El número que se muestra en una diapositiva puede comenzar en un valor arbitrario (por ejemplo, 10) y no tiene que coincidir con el índice; la relación está controlada por la configuración del [primer número de diapositiva](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) de la presentación.

**¿Las diapositivas ocultas afectan la indexación?**

Sí. Una diapositiva oculta sigue formando parte de la colección y se cuenta en la indexación; “oculta” se refiere a la visualización, no a su posición en la colección.

**¿Cambia el índice de una diapositiva cuando se añaden o eliminan otras diapositivas?**

Sí. Los índices siempre reflejan el orden actual de las diapositivas y se recalculan al insertar, eliminar o mover diapositivas.