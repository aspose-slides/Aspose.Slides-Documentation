---
title: Proteger presentaciones contra escritura en Python
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/python-net/write-protected-presentation/
keywords:
- protección contra escritura
- PowerPoint con protección contra escritura
- contraseña para modificar
- restringir la edición de la presentación
- eliminar protección contra escritura
- validar contraseña de modificación
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX usando Aspose.Slides para Python."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación, pero no cifra su contenido. Los usuarios pueden cargar y ver una presentación protegida contra escritura sin la contraseña. Dependiendo de la aplicación, también pueden editar el contenido y guardarlo con otro nombre, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura tiene un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, consulta [Presentaciones protegidas con contraseña](/slides/es/python-net/password-protected-presentation/).

Los flujos de trabajo en este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan archivos PPTX; al guardar en PPT, utiliza la extensión `.ppt` y el formato de guardado PPT correspondiente.

## **Establecer protección contra escritura en una presentación**

Utiliza [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/set_write_protection/) para asignar una contraseña que permita modificar una presentación. Guardar la presentación mantiene la configuración de protección.

El siguiente ejemplo establece protección contra escritura en una presentación PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Cargar una presentación con protección contra escritura**

Dado que la protección contra escritura no cifra el contenido de la presentación, no se necesita contraseña para cargar la presentación. La contraseña solo es relevante al validar la autorización para modificar la presentación protegida.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

No pases una contraseña de protección contra escritura a [LoadOptions.password](https://reference.aspose.com/slides/es/python-net/aspose.slides/loadoptions/password/). Esa propiedad acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporciona la contraseña de apertura para cargarla y gestiona la contraseña de protección contra escritura por separado.

## **Quitar protección contra escritura de una presentación**

Utiliza [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/remove_write_protection/) para eliminar la restricción de modificación y, a continuación, guarda la presentación.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/), llama a [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) y examina [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/is_write_protected/). La propiedad utiliza [NullableBool](https://reference.aspose.com/slides/es/python-net/aspose.slides/nullablebool/) y devuelve `NullableBool.TRUE` cuando se detecta protección contra escritura.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

La sobrecarga que recibe un flujo de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationfactory/get_presentation_info/) proporciona la misma información para una presentación suministrada como flujo.

## **Validar una contraseña de protección contra escritura**

Utiliza [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/check_write_protection/) para validar una contraseña de modificación sin cargar la presentación completa. Comprueba primero [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/is_write_protected/) para que la aplicación solicite o valide una contraseña solo cuando exista protección contra escritura.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/check_write_protection/) valida solo la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si se puede cargar contenido cifrado. Por el contrario, [PresentationInfo.check_password](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentationinfo/check_password/) valida únicamente una contraseña de apertura. Si ya se ha cargado una presentación completa, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/es/python-net/aspose.slides/protectionmanager/check_write_protection/) proporciona la comprobación equivalente de protección contra escritura mediante su gestor de protección.

En aplicaciones de producción, no registres contraseñas ni las incluyas en mensajes de diagnóstico. Evita intentos de validación repetidos innecesariamente y conserva las contraseñas en memoria solo el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Presentaciones protegidas con contraseña](/slides/es/python-net/password-protected-presentation/)
- [Presentaciones de solo lectura](/slides/es/python-net/read-only-presentation/)
- [Firma digital en PowerPoint](/slides/es/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargar y ver.

**¿Se necesita la contraseña de protección contra escritura para abrir una presentación?**

No. Sólo se necesita una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una contraseña de protección contra escritura?**

Sí. Proporciona la contraseña de apertura mediante las opciones de carga para abrir la presentación cifrada y valida la contraseña de protección contra escritura por separado cuando se requiera autorización para modificar.