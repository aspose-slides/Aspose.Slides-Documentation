---
title: Guardar presentaciones en modo de solo lectura usando Python
linktitle: Presentación de solo lectura
type: docs
weight: 30
url: /es/python-net/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar edición
- PowerPoint
- presentación
- Python
- Aspose.Slides
description: "Cargar y guardar archivos de PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides para Python mediante .NET, ofreciendo vistas previas precisas de diapositivas sin modificar sus presentaciones."
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Es posible que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Desea evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Desea avisar a los usuarios que la presentación que ha proporcionado es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios la abren, ven la recomendación **Read-Only** y pueden ver un mensaje de este tipo: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de forma educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint—que no admite la función introducida recientemente—la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides para Python mediante .NET le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este fragmento de código muestra cómo establecer una presentación en **Read-Only** en Python usando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** está simplemente destinada a desalentar la edición o impedir cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que hace—decide editar su presentación, puede eliminar fácilmente la configuración **Read-Only**. Si necesita prevenir seriamente la edición no autorizada, es mejor utilizar [protecciones más estrictas que involucren cifrados y contraseñas](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/python-net/password-protected-presentation/) realmente restringe la apertura o edición y es adecuada cuando necesita controles de seguridad reales.

**¿Se puede combinar 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/python-net/watermark/) como disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [contraseñas y cifrado](/slides/es/python-net/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los indicadores 'is_encrypted' e 'is_write_protected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso blando y opcional; [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) e [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.