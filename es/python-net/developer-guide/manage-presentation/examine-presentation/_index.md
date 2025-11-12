---
title: Recuperar y actualizar información de la presentación en Python
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
description: "Explore diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando Python para obtener información más rápida y auditorías de contenido más inteligentes."
---

Aspose.Slides para Python a través de .NET le permite examinar una presentación para descubrir sus propiedades y comprender su comportamiento. 

{{% alert title="Info" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Verificar el formato de una presentación**

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

Puede consultar las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) que permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "Mi título"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Los resultados del cambio de las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que encuentre útiles estos enlaces:

- [Comprobar si una presentación está cifrada](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobar si una presentación está protegida contra escritura (solo lectura)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobar si una presentación está protegida con contraseña antes de cargarla](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmar la contraseña utilizada para proteger una presentación](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la información de [fuentes incrustadas](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a nivel de presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) y revise la [bandera de visibilidad](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se utilizan tamaños y orientaciones de diapositiva personalizados, y si difieren de los predeterminados?**

Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) y la orientación actuales con los valores predeterminados; esto ayuda a anticipar el comportamiento para impresión y exportación.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) y observe si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, contabilice la cantidad de objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación aproximada de complejidad para señalar posibles cuellos de botella de rendimiento.