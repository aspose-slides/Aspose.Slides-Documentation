---
title: Proteger presentaciones contra escritura en Python
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/python-java/write-protected-presentation/
keywords:
- protección contra escritura
- PowerPoint con protección contra escritura
- contraseña de modificación
- restringir la edición de la presentación
- eliminar protección contra escritura
- validar contraseña de modificación
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX usando Aspose.Slides para Python mediante Java."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación pero no cifra su contenido. Los usuarios pueden cargar y visualizar una presentación protegida contra escritura sin la contraseña. Según la aplicación, también pueden editar el contenido y guardarlo con otro nombre, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura cumple un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, consulte [Proteger presentaciones con contraseña](/slides/es/python-java/password-protected-presentation/).

Los flujos de trabajo en este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos usan archivos PPTX; al guardar en PPT, utilice la extensión `.ppt` y el formato de guardado PPT correspondiente.

## **Establecer protección contra escritura en una presentación**

Utilice [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#setWriteProtection) para asignar una contraseña que permita modificar una presentación. Guardar la presentación conserva la configuración de protección.

El siguiente ejemplo establece la protección contra escritura en una presentación PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Cargar una presentación protegida contra escritura**

Debido a que la protección contra escritura no cifra el contenido de la presentación, no se requiere contraseña para cargarla. La contraseña solo es relevante al validar la autorización para modificar la presentación protegida.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

No pase una contraseña de protección contra escritura a [LoadOptions.setPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/loadoptions/#setPassword). Ese método acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporcione la contraseña de apertura para cargarla y gestione la contraseña de protección contra escritura por separado.

## **Eliminar la protección contra escritura de una presentación**

Utilice [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#removeWriteProtection) para eliminar la restricción de modificación y, a continuación, guarde la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), llame a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) y examine [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#isWriteProtected). El método utiliza [NullableBool](https://reference.aspose.com/slides/es/python-java/aspose.slides/nullablebool/) y devuelve `NullableBool.True_` cuando se detecta protección contra escritura.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

La sobrecarga de flujo de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationfactory/#getPresentationInfo) proporciona la misma información para una presentación suministrada como flujo.

## **Validar una contraseña de protección contra escritura**

Utilice [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#checkWriteProtection) para validar una contraseña de modificación sin cargar la presentación completa. Verifique primero [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#isWriteProtected) para que la aplicación solicite o valide una contraseña solo cuando la protección contra escritura esté presente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#checkWriteProtection) valida únicamente la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si se puede cargar contenido cifrado. Por el contrario, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentationinfo/#checkPassword) valida solo una contraseña de apertura. Si ya se ha cargado una presentación completa, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#checkWriteProtection) proporciona la comprobación equivalente de protección contra escritura mediante su gestor de protección.

En aplicaciones en producción, no registre contraseñas ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios y mantenga las contraseñas en memoria solo el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Proteger presentaciones con contraseña](/slides/es/python-java/password-protected-presentation/)
- [Presentaciones de solo lectura](/slides/es/python-java/read-only-presentation/)
- [Firma digital en PowerPoint](/slides/es/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargar y visualizar.

**¿Se requiere la contraseña de protección contra escritura para abrir una presentación?**

No. Solo se requiere una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una contraseña de protección contra escritura?**

Sí. Proporcione la contraseña de apertura mediante las opciones de carga para abrir la presentación cifrada y valide la contraseña de protección contra escritura por separado cuando sea necesaria la autorización de modificación.