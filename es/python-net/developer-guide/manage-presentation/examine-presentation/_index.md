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
description: "Explore diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando Python para obtener ideas más rápidas y auditorías de contenido más inteligentes."
---

Aspose.Slides for Python a través de .NET le permite examinar una presentación para conocer sus propiedades y comprender su comportamiento. 

{{% alert title="Info" color="info" %}} 
Las clases [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) contienen las propiedades y métodos usados en las operaciones aquí.
{{% /alert %}} 

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, es posible que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

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


Es posible que desee ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) que le permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades originales del documento de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:
```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```


Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades cambiadas del documento de la presentación de PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede encontrar útiles los siguientes enlaces:

- [Comprobando si una presentación está encriptada](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobando si una presentación está protegida contra escritura (solo lectura)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobando si una presentación está protegida con contraseña antes de cargarla](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando la contraseña utilizada para proteger una presentación](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**
Busque la [información de fuentes incrustadas](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) a nivel de presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**
Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) de cada diapositiva.

**¿Puedo detectar si se utiliza un tamaño y orientación de diapositiva personalizados, y si difieren de los valores predeterminados?**
Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) y la orientación actuales con los valores predeterminados estándar; esto ayuda a anticipar el comportamiento para la impresión y la exportación.

**¿Existe una manera rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**
Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) y observe si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas 'pesadas' que pueden ralentizar la renderización o la exportación a PDF?**
Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para señalar posibles puntos críticos de rendimiento.