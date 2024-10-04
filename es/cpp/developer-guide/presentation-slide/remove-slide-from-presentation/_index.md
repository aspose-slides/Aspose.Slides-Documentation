---
title: Eliminar diapositiva de la presentación
type: docs
weight: 30
url: /es/cpp/remove-slide-from-presentation/
keywords: "Eliminar diapositiva, Borrar diapositiva, PowerPoint, Presentación, C++, Aspose.Slides"
description: "Eliminar diapositiva de PowerPoint por referencia o índice en C++"

---

Si una diapositiva (o su contenido) se vuelve redundante, puedes eliminarla. Aspose.Slides proporciona la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que encapsula [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), que es un repositorio para todas las diapositivas en una presentación. Usando punteros (referencia o índice) para un objeto [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/), puedes especificar la diapositiva que deseas eliminar. 

## **Eliminar diapositiva por referencia**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtén una referencia de la diapositiva que deseas eliminar a través de su ID o índice.
1. Elimina la diapositiva referenciada de la presentación.
1. Guarda la presentación modificada. 

Este código C++ muestra cómo eliminar una diapositiva a través de su referencia: 

```c++
	// La ruta al directorio de documentos
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Instancia un objeto Presentation que representa un archivo de presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accede a una diapositiva a través de su índice en la colección de diapositivas
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Elimina una diapositiva a través de su referencia
	pres->get_Slides()->Remove(slide);

	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Eliminar diapositiva por índice**

1. Crea una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Elimina la diapositiva de la presentación a través de su posición de índice.
1. Guarda la presentación modificada. 

Este código C++ muestra cómo eliminar una diapositiva a través de su índice: 

```c++
	// La ruta al directorio de documentos
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instancia un objeto Presentation que representa un archivo de presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Elimina una diapositiva a través de su índice de diapositiva
	pres->get_Slides()->RemoveAt(0);

	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Eliminar diapositiva de diseño no utilizada**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas de diseño no deseadas y no utilizadas. Este código C++ muestra cómo eliminar una diapositiva de diseño de una presentación de PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Eliminar diapositiva maestra no utilizada**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) para permitirte eliminar diapositivas maestras no deseadas y no utilizadas. Este código C++ muestra cómo eliminar una diapositiva maestra de una presentación de PowerPoint:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```