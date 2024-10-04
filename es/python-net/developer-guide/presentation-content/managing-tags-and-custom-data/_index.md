---
title: Gestión de Etiquetas y Datos Personalizados
type: docs
weight: 300
url: /python-net/gestion-de-etiquetas-y-datos-personalizados/
keywords: "Etiquetas, Datos personalizados, Valor para etiquetas, Agregar etiquetas, Presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Agrega etiquetas y datos personalizados a presentaciones de PowerPoint en Python"
---

## Almacenamiento de Datos en Archivos de Presentación

Los archivos PPTX—elementos con la extensión .pptx—se almacenan en el formato PresentationML, que es parte de la especificación Office Open XML. El formato Office Open XML define la estructura para los datos contenidos en las presentaciones.

Con una *diapositiva* siendo uno de los elementos en las presentaciones, una *parte de diapositiva* contiene el contenido de una sola diapositiva. Se permite que una parte de diapositiva tenga relaciones explícitas con muchas partes—como Etiquetas Definidas por el Usuario—definidas por ISO/IEC 29500.

Los datos personalizados (específicos de una presentación) o del usuario pueden existir como etiquetas ([ITagCollection](https://reference.aspose.com/slides/python-net/aspose.slides/itagcollection/)) y CustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/python-net/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 

Las etiquetas son esencialmente pares de valores de clave de cadena. 

{{% /alert %}} 

## Obtener los Valores para Etiquetas

En las diapositivas, una etiqueta corresponde a la propiedad IDocumentProperties.Keywords. Este código de muestra te muestra cómo obtener el valor de una etiqueta con Aspose.Slides para Python a través de .NET para [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    print(pres.document_properties.keywords)
```

## Agregar Etiquetas a Presentaciones

Aspose.Slides te permite agregar etiquetas a las presentaciones. Una etiqueta típicamente consiste en dos elementos: 

- el nombre de una propiedad personalizada - `MyTag` 
- el valor de la propiedad personalizada - `My Tag Value`

Si necesitas clasificar algunas presentaciones basadas en una regla o propiedad específica, entonces puedes beneficiarte al agregar etiquetas a esas presentaciones. Por ejemplo, si deseas categorizar o agrupar todas las presentaciones de países de América del Norte, puedes crear una etiqueta de América del Norte y luego asignar los países relevantes (EE.UU., México y Canadá) como los valores.

Este código de muestra te muestra cómo agregar una etiqueta a una [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) utilizando Aspose.Slides para Python a través de .NET:

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
   tags = pres.custom_data.tags 
   tags.add("MyTag", "My Tag Value")
```

Las etiquetas también se pueden establecer para [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/):

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
    shape.text_frame.text = "Mi texto"
    shape.custom_data.tags.add("tag", "value")
```