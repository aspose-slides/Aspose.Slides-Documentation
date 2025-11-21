---
title: Guardar presentaciones en modo solo lectura usando Python
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
description: "Cargar y guardar archivos PowerPoint (PPT, PPTX) en modo solo lectura con Aspose.Slides para Python a través de .NET, ofreciendo vistas previas de diapositivas precisas sin alterar sus presentaciones."
---

## **Aplicar modo Read-Only**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Es posible que desee usar esta configuración de Read-Only para proteger una presentación cuando

- Quiere evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Quiere avisar a la gente que la presentación que proporcionó es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abren la presentación, ven la recomendación **Read-Only** y pueden ver un mensaje como el siguiente: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de manera educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint—que no admite la función introducida recientemente—la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for Python via .NET le permite establecer una presentación como **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este código de ejemplo muestra cómo establecer una presentación como **Read-Only** en Python usando Aspose.Slides:
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** está simplemente destinada a desalentar la edición o impedir que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que hace—decide editar su presentación, puede eliminar fácilmente la configuración Read-Only. Si realmente necesita evitar la edición no autorizada, es mejor utilizar [protecciones más estrictas que implican cifrados y contraseñas](https://docs.aspose.com/slides/python-net/password-protected-presentation/). 

{{% /alert %}} 

## **FAQ**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo solo lectura y es fácil de evitar. [Password protection](/slides/es/python-net/password-protected-presentation/) realmente restringe la apertura o edición y es apropiada cuando necesita controles de seguridad reales.

**¿Se puede combinar 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [watermarks](/slides/es/python-net/watermark/) como un disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [passwords and encryption](/slides/es/python-net/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con las banderas 'is_encrypted' y 'is_write_protected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_write_protected/) y [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_encrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.