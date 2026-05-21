---
title: Gestionar etiquetas y datos personalizados en presentaciones con Python
linktitle: Etiquetas y datos personalizados
type: docs
weight: 300
url: /es/python-net/managing-tags-and-custom-data/
keywords:
- propiedades del documento
- etiqueta
- datos personalizados
- añadir etiqueta
- valores de pares
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Aprenda a añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para Python a través de .NET, con ejemplos para presentaciones de PowerPoint y OpenDocument."
---
## **Descripción general**

Este artículo explica cómo Aspose.Slides trabaja con etiquetas y datos personalizados en presentaciones de PowerPoint. Describe brevemente cómo se almacenan los datos en los archivos PPTX, indica que los datos específicos de la presentación pueden existir como etiquetas y partes XML personalizadas, y describe las etiquetas como pares de cadena clave‑valor.

También muestra cómo leer los valores de las etiquetas y cómo añadir etiquetas a una presentación, a una diapositiva individual o a una forma. Además, el artículo cubre tareas comunes de gestión de etiquetas, como borrar todas las etiquetas, eliminar una etiqueta por nombre y obtener la lista de nombres de etiquetas.

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos de las presentaciones, una *parte de diapositiva* contiene el contenido de una única diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/itagcollection/)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
Las etiquetas son esencialmente pares de cadena clave‑valor. 
{{% /alert %}} 

## **Obtener los valores de las etiquetas**

En Slides, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este código de ejemplo muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Python a través de .NET para [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## **Añadir etiquetas a presentaciones**

Aspose.Slides permite añadir etiquetas a presentaciones. Una etiqueta normalmente consta de dos elementos:

- el nombre de una propiedad personalizada - `MyTag`
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse de añadir etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta “North American” y asignar los países relevantes (EE. UU., México y Canadá) como valores.

Este código de ejemplo muestra cómo añadir una etiqueta a una [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/) usando Aspose.Slides para Python a través de .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```

O cualquier [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/) individual:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Limitaciones**

Las etiquetas añadidas a través de la colección `custom_data.tags` se almacenan solo dentro del archivo PowerPoint. **No** se transfieren a la estructura de etiquetas PDF cuando la presentación se exporta a PDF. En consecuencia, un identificador personalizado asignado como etiqueta no puede recuperarse del PDF etiquetado.

**Solución alternativa**: Puede almacenar un identificador personalizado en el **Texto alternativo** del objeto (p. ej., `shape.alternative_text = "MyId"`). Después de exportar a PDF, el Texto alternativo puede aparecer en la estructura de etiquetas del PDF.

## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [tag collection](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor de una sola vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [remove(name)](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/) para borrar la etiqueta por su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [get_names_of_tags](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/get_names_of_tags/) en la [tag collection](https://reference.aspose.com/slides/es/python-net/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.