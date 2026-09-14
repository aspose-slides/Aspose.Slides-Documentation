---
title: Guardar presentaciones en modo solo lectura usando Python
linktitle: Presentación solo lectura
type: docs
weight: 30
url: /es/python-java/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar edición
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Cargue y guarde archivos PowerPoint (PPT, PPTX) en modo solo lectura con Aspose.Slides para Python vía Java, ofreciendo vistas previas precisas de diapositivas sin modificar sus presentaciones."
---
## **Introducción**

En PowerPoint 2019, Microsoft introdujo la opción **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Puede que desee usar esta configuración de solo lectura para proteger una presentación cuando:

- Quiere evitar ediciones accidentales y mantener el contenido de su presentación a salvo. 
- Quiere avisar a las personas de que la presentación que ha proporcionado es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abran la presentación, verán la recomendación **Read-Only** y pueden ver un mensaje como este: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para eliminarla antes de poder editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de forma educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión antigua de Microsoft PowerPoint—que no soporta la función recientemente introducida—la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

## **Aplicar modo solo lectura**

Aspose.Slides for Python via Java le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) verán la recomendación **Read-Only**. Este fragmento de código muestra cómo establecer una presentación en **Read-Only** en Python usando Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getProtectionManager().setReadOnlyRecommended(True)
    presentation.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}} 

La recomendación **Read-Only** simplemente pretende desalentar la edición o impedir que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que hace—decide editar su presentación, puede eliminar fácilmente la configuración **Read-Only**. Si necesita evitar seriamente la edición no autorizada, es mejor utilizar [protecciones más estrictas que implican cifrado y contraseñas](/slides/es/python-java/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/python-java/password-protected-presentation/) realmente restringe la apertura o edición y es apropiado cuando necesita controles de seguridad reales.

**¿Puede combinarse 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/python-java/watermark/) como un disuasivo visual; son mecanismos independientes y funcionan bien juntos.

**¿Puede una macro o una herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [contraseñas y cifrado](/slides/es/python-java/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los métodos [isEncrypted](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isEncrypted) y [isWriteProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isWriteProtected)?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isWriteProtected) y [isEncrypted](https://reference.aspose.com/slides/es/python-java/aspose.slides/protectionmanager/#isEncrypted) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.