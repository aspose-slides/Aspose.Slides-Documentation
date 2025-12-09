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
description: "Aprenda cómo añadir, leer, actualizar y eliminar etiquetas y datos personalizados en Aspose.Slides para Python mediante .NET, con ejemplos para presentaciones de PowerPoint y OpenDocument."
---

## **Almacenamiento de datos en archivos de presentación**

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que forma parte de la especificación Office Open XML. El formato Office Open XML define la estructura de los datos contenidos en presentaciones. 

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una única diapositiva. A una parte de diapositiva se le pueden asignar relaciones explícitas a muchas partes—como las Etiquetas definidas por el usuario—definidas por ISO/IEC 29500. 

Los datos personalizados (específicos de una presentación) o el usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)). 

{{% alert color="primary" %}} 
Las etiquetas son esencialmente pares clave‑valor de cadena. 
{{% /alert %}} 

## **Obtener los valores de las etiquetas**

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este código de ejemplo muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Python mediante .NET para [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```


## **Agregar etiquetas a presentaciones**

Aspose.Slides permite agregar etiquetas a presentaciones. Una etiqueta normalmente consta de dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesita clasificar algunas presentaciones según una regla o propiedad específica, puede beneficiarse de agregar etiquetas a esas presentaciones. Por ejemplo, si desea agrupar todas las presentaciones de países de América del Norte, puede crear una etiqueta “North American” y asignar los países relevantes (EE. UU., México y Canadá) como valores. 

Este código de ejemplo muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) usando Aspose.Slides para Python mediante .NET:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```


Las etiquetas también pueden establecerse para [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    tags = slide.custom_data.tags
    tags.add("tag", "value")
```


O para cualquier [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) individual:
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slide = pres.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```


## **Preguntas frecuentes**

**¿Puedo eliminar todas las etiquetas de una presentación, diapositiva o forma en una sola operación?**

Sí. La [colección de etiquetas](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) admite una operación [clear](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/clear/) que elimina todos los pares clave‑valor a la vez.

**¿Cómo elimino una única etiqueta por su nombre sin iterar sobre toda la colección?**

Utilice la operación [remove(name)](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/remove/) en [TagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/) para borrar la etiqueta mediante su clave.

**¿Cómo puedo obtener la lista completa de nombres de etiquetas para análisis o filtrado?**

Utilice [get_names_of_tags](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/get_names_of_tags/) en la [colección de etiquetas](https://reference.aspose.com/slides/python-net/aspose.slides/tagcollection/); devuelve una matriz con todos los nombres de etiquetas.