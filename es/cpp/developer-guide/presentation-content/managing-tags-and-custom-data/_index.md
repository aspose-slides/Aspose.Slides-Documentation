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
- valores de pares
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para C++, con ejemplos para presentaciones PowerPoint y OpenDocument."
---
## **Visión general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Describe brevemente cómo se almacenan los datos en los archivos PPTX, indica que los datos específicos de la presentación pueden existir como etiquetas y partes XML personalizadas, y define las etiquetas como pares de cadena clave-valor.

También muestra cómo leer los valores de las etiquetas y cómo añadir etiquetas a una presentación, a una diapositiva individual o a una forma. Además, el artículo cubre tareas comunes de gestión de etiquetas, como borrar todas las etiquetas, eliminar una etiqueta por nombre y obtener la lista de nombres de etiquetas.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX —elementos con la extensión .pptx— se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones. 

Siendo una *diapositiva* uno de los elementos de una presentación, una *parte de diapositiva* contiene el contenido de una única diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas con muchas partes —como las Etiquetas definidas por el usuario— definidas por la ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/itagcollection/)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 

Las etiquetas son esencialmente valores de pares cadena-clave. 

{{% /alert %}} 

## **Obtener valores de etiquetas**

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este fragmento de código muestra cómo obtener el valor de una etiqueta con Aspose.Slides para C++ para [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **Agregar etiquetas a presentaciones**

Aspose.Slides le permite añadir etiquetas a presentaciones. Una etiqueta normalmente consta de dos elementos:

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse añadiendo etiquetas a esas presentaciones. Por ejemplo, si desea agrupar o categorizar todas las presentaciones de países de América del Norte, puede crear una etiqueta América del Norte y asignar como valores los países correspondientes (EE. UU., México y Canadá). 

Este fragmento de código muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) usando Aspose.Slides para C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

O cualquier [Shape](https://reference.aspose.com/slides/es/cpp/aspose.slides/shape/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **Limitaciones**

Las etiquetas añadidas mediante la colección de etiquetas de datos personalizados usando `get_CustomData()->get_Tags()` se almacenan solo dentro del archivo PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Alt Text** del objeto (p.ej., `shape->set_AlternativeText(u"MyId")`). Después de exportar a PDF, el Alt Text puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/clear/) que elimina todos los pares clave-valor de una vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [Remove(name)](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/) para eliminar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [GetNamesOfTags](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/getnamesoftags/) en la [tag collection](https://reference.aspose.com/slides/es/cpp/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.