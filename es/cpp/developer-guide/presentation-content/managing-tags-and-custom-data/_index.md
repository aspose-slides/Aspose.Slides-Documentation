---
title: Administrar etiquetas y datos personalizados en presentaciones usando C++
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/cpp/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- agregar etiqueta
- valores de pares
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo agregar, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para C++, con ejemplos para presentaciones PowerPoint y OpenDocument."
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. A una parte de diapositiva se le permite tener relaciones explícitas con muchas partes—como las etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)). 

{{% alert color="primary" %}} 
Las etiquetas son esencialmente valores de pares cadena‑clave. 
{{% /alert %}} 

## **Obtener valores de etiquetas**

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este código de ejemplo muestra cómo obtener el valor de una etiqueta con Aspose.Slides para C++ para [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **Agregar etiquetas a presentaciones**

Aspose.Slides le permite agregar etiquetas a presentaciones. Una etiqueta típicamente consta de dos elementos:

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, entonces puede beneficiarse de agregar etiquetas a esas presentaciones. Por ejemplo, si desea categorizar o agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta América del Norte y luego asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este código de ejemplo muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) usando Aspose.Slides para C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


O cualquier [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape) individual:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una vez.

**¿Cómo elimino una sola etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.