---
title: Presentación de solo lectura
type: docs
weight: 30
url: /es/net/read-only-presentation/
keywords: "Configuración de solo lectura, presentación de PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Presentación de PowerPoint de solo lectura en C# o .NET"
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Puede que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Quiere evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Quiere avisar a las personas que la presentación que proporcionó es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios la abren, ven la recomendación **Read-Only** y pueden ver un mensaje en esta forma: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una tarea para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de manera educada, entonces la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint —que no soporta la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for .NET le permite establecer una presentación como **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este código de ejemplo le muestra cómo establecer una presentación como **Read-Only** en C# usando Aspose.Slides:
```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** simplemente pretende desalentar la edición o impedir que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración Read-Only. Si realmente necesita evitar la edición no autorizada, es mejor utilizar [protecciones más estrictas que implican encriptaciones y contraseñas](https://docs.aspose.com/slides/net/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cómo se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/net/password-protected-presentation/) realmente restringe la apertura o edición y es apropiada cuando necesita controles de seguridad reales.

**¿Puede combinarse 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/net/watermark/) como un disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea cambios programáticos. Para evitar ediciones automatizadas, use [contraseñas y encriptación](/slides/es/net/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los indicadores 'IsEncrypted' y 'IsWriteProtected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/iswriteprotected/) y [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/isencrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o encriptación.