---
title: Gestionar etiquetas y datos personalizados en presentaciones usando C++
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/cpp/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- pares de valores
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para C++, con ejemplos para presentaciones PowerPoint y OpenDocument."
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —elementos con la extensión .pptx— se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en presentaciones. 

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas con muchas partes —como Etiquetas definidas por el usuario— definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o de usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Las etiquetas son esencialmente valores de pares clave‑cadena. 

{{% /alert %}} 

## **Obtener valores de etiquetas**

En diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para C++ para [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta normalmente consta de dos elementos: 

- el nombre de una propiedad personalizada – `MyTag` 
- el valor de la propiedad personalizada – `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse de agregar etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de países norteamericanos, puede crear una etiqueta “North American” y luego asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este fragmento de código muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) usando Aspose.Slides para C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


O cualquier [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) individual:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una única operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una sola vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar por toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Use [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.