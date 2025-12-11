---
title: Eliminar diapositivas de presentaciones en C++
linktitle: Eliminar diapositiva
type: docs
weight: 30
url: /es/cpp/remove-slide-from-presentation/
keywords:
- eliminar diapositiva
- suprimir diapositiva
- eliminar diapositiva sin uso
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Elimine diapositivas de presentaciones PowerPoint y OpenDocument de forma sencilla con Aspose.Slides para C++. Obtenga ejemplos de código claros y mejore su flujo de trabajo."
---

Si una diapositiva (o su contenido) se vuelve redundante, puede eliminarla. Aspose.Slides proporciona la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) que encapsula [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/), que es un repositorio de todas las diapositivas de una presentación. Usando punteros (referencia o índice) para un objeto [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) conocido, puede especificar la diapositiva que desea eliminar. 

## **Eliminar una diapositiva por referencia**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Obtenga una referencia de la diapositiva que desea eliminar mediante su ID o índice.
1. Elimine la diapositiva referenciada de la presentación.
1. Guarde la presentación modificada. 

Este código C++ muestra cómo eliminar una diapositiva mediante su referencia: 
```c++
	// La ruta al directorio de documentos
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Crea una instancia de un objeto Presentation que representa un archivo de presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Accede a una diapositiva mediante su índice en la colección de diapositivas
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Elimina una diapositiva mediante su referencia
	pres->get_Slides()->Remove(slide);

	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```



## **Eliminar una diapositiva por índice**

1. Cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. Elimine la diapositiva de la presentación mediante su posición de índice.
1. Guarde la presentación modificada. 

Este código C++ muestra cómo eliminar una diapositiva mediante su índice: 
```c++
	// La ruta al directorio de documentos
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instancia un objeto Presentation que representa un archivo de presentación
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Elimina una diapositiva mediante su índice
	pres->get_Slides()->RemoveAt(0);

	// Guarda la presentación modificada
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Eliminar diapositivas de diseño no usadas**

Aspose.Slides proporciona el método [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) para permitirle eliminar diapositivas de diseño no deseadas y no usadas. Este código C++ muestra cómo eliminar una diapositiva de diseño de una presentación PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **Eliminar diapositivas maestras no usadas**

Aspose.Slides proporciona el método [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) (de la clase [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)) para permitirle eliminar diapositivas maestras no deseadas y no usadas. Este código C++ muestra cómo eliminar una diapositiva maestra de una presentación PowerPoint:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **Preguntas frecuentes**

**¿Qué ocurre con los índices de las diapositivas después de eliminar una diapositiva?**

Después de la eliminación, la [collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) se vuelve a indexar: cada diapositiva posterior se desplaza una posición a la izquierda, por lo que los números de índice anteriores quedan desactualizados. Si necesita una referencia estable, use el ID persistente de cada diapositiva en lugar de su índice.

**¿El ID de una diapositiva es diferente de su índice, y cambia cuando se eliminan diapositivas adyacentes?**

Sí. El índice es la posición de la diapositiva y cambiará cuando se añadan o eliminen diapositivas. El ID de la diapositiva es un identificador persistente y no cambia cuando se eliminan otras diapositivas.

**¿Cómo afecta la eliminación de una diapositiva a las secciones de diapositivas?**

Si la diapositiva pertenecía a una sección, esa sección simplemente contendrá una diapositiva menos. La estructura de la sección permanece; si una sección queda vacía, puede [remove or reorganize sections](/slides/es/cpp/slide-section/) según sea necesario.

**¿Qué ocurre con las notas y los comentarios adjuntos a una diapositiva cuando se elimina?**

[Notes](/slides/es/cpp/presentation-notes/) y [comments](/slides/es/cpp/presentation-comments/) están vinculados a esa diapositiva específica y se eliminan junto con ella. El contenido de otras diapositivas no se ve afectado.

**¿En qué se diferencia la eliminación de diapositivas de la limpieza de diseños/maestros no usados?**

Eliminar quita diapositivas normales específicas del conjunto. La limpieza de diseños/maestros no usados elimina diapositivas de diseño o maestra que no son referenciadas, reduciendo el tamaño del archivo sin cambiar el contenido de las diapositivas restantes. Estas acciones son complementarias: normalmente se elimina primero y luego se limpia.