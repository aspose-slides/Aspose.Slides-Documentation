---
title: Recuperar y actualizar información de presentación en Python
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/python-net/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Explora diapositivas, estructura y metadatos en presentaciones PowerPoint y OpenDocument utilizando Python para obtener información más rápida y auditorías de contenido más inteligentes."
---
## **Visión general**

Este artículo muestra cómo inspeccionar la información de una presentación en Aspose.Slides. Explica cómo determinar el formato actual de una presentación sin cargar el archivo completo, leer sus propiedades de documento y actualizar dichas propiedades cuando sea necesario.

Los ejemplos se basan en las APIs [PresentationInfo](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/) y demuestran operaciones típicas para trabajar con los metadatos de una presentación.

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP, y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Obtener propiedades de la presentación**

Este código Python le muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Puede que desee ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/es/python-net/aspose.slides/documentproperties/#properties).

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) que le permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que encuentre útiles los siguientes enlaces:

- [Presentaciones protegidas con contraseña](/slides/es/python-net/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/python-net/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la [información de fuentes incrustadas](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a nivel de presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/es/python-net/aspose.slides/fontsmanager/get_fonts/) para identificar qué fuentes son críticas para la representación.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Recorra la [colección de diapositivas](https://reference.aspose.com/slides/es/python-net/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/es/python-net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**

Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/slide_size/) y la orientación actuales con los valores predefinidos estándar; esto ayuda a anticipar el comportamiento al imprimir y exportar.

**¿Existe una forma rápida de saber si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/), compruebe su [fuente de datos](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chartdata/data_source_type/) y observe si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para señalar posibles puntos críticos de rendimiento.