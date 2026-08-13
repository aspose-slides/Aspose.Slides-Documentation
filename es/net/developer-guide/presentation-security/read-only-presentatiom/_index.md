---
title: Guardar presentaciones en modo de solo lectura en .NET
linktitle: Presentación de solo lectura
type: docs
weight: 30
url: /es/net/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar la edición
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cargar y guardar archivos PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides para .NET, ofreciendo vistas previas precisas de diapositivas sin alterar sus presentaciones."
---
## **Introducción**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Es posible que desee utilizar esta configuración de solo lectura para proteger una presentación cuando

- Quiere evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Quiere indicar a las personas que la presentación que ha proporcionado es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios la abren, ven la recomendación **Read-Only** y pueden ver un mensaje de este tipo: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo de solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para eliminarla antes de poder editar la presentación. Si no quiere que los usuarios realicen cambios en una presentación y desea comunicarlo de forma educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

## **Aplicar modo de solo lectura**

Aspose.Slides for .NET le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este fragmento de código muestra cómo establecer una presentación en **Read-Only** en C# usando Aspose.Slides:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="info" %}} 

**Nota**: La recomendación **Read-Only** está pensada simplemente para desalentar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si necesita impedir seriamente la edición no autorizada, es mejor usar [protecciones más estrictas que implican cifrados y contraseñas](https://docs.aspose.com/slides/es/net/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

### ¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Password protection](/slides/es/net/password-protected-presentation/) restringe realmente la apertura o edición y es apropiada cuando necesita controles de seguridad reales.

### ¿Se puede combinar 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?

Sí. La recomendación puede combinarse con [watermarks](/slides/es/net/watermark/) como disuasivo visual; son mecanismos independientes y funcionan bien juntos.

### ¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [passwords and encryption](/slides/es/net/password-protected-presentation/).

### ¿Cómo se relaciona 'Read-Only recommended' con las banderas 'IsEncrypted' y 'IsWriteProtected'?

Son señales diferentes. 'Read-Only recommended' es una sugerencia blanda y opcional; [IsWriteProtected](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager/iswriteprotected/) y [IsEncrypted](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager/isencrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.