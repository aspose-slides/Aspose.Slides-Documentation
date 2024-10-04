---
title: Examinar Presentación
type: docs
weight: 30
url: /python-net/examine-presentation/
keywords:
- PowerPoint
- presentación
- formato de presentación
- propiedades de presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- PPTX
- PPT
- Python
description: "Leer y modificar propiedades de la presentación de PowerPoint en Python"
---

Aspose.Slides para Python a través de .NET te permite examinar una presentación para descubrir sus propiedades y entender su comportamiento. 

{{% alert title="Info" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Verificar un Formato de Presentación**

Antes de trabajar en una presentación, puede que desees averiguar en qué formato (PPT, PPTX, ODP, y otros) se encuentra la presentación en ese momento.

Puedes comprobar el formato de una presentación sin cargarla. Ve este código de Python:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Obtener Propiedades de la Presentación**

Este código de Python te muestra cómo obtener propiedades de la presentación (información sobre la presentación):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Puede que desees ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Actualizar Propiedades de la Presentación**

Aspose.Slides proporciona el método [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) que te permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento que se muestran a continuación.

![Propiedades del documento originales de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código te muestra cómo editar algunas propiedades de la presentación:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "Mi título"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades del documento cambiadas de la presentación de PowerPoint](output_properties.png)

## **Enlaces Útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que encuentres útiles estos enlaces:

- [Verificando si una Presentación está Encriptada](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Verificando si una Presentación está Protegida contra Escritura (solo lectura)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Verificando si una Presentación está Protegida con Contraseña Antes de Cargarla](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmando la Contraseña Usada para Proteger una Presentación](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).