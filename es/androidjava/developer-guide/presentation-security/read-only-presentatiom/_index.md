---
title: Guardar presentaciones en modo de solo lectura en Android
linktitle: Presentación de solo lectura
type: docs
weight: 30
url: /es/androidjava/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar edición
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Guarde archivos PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides para Android mediante Java, ofreciendo vistas previas precisas de diapositivas sin alterar sus presentaciones."
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Es posible que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Desea prevenir ediciones accidentales y mantener el contenido de su presentación seguro. 
- Desea avisar a las personas que la presentación que proporcionó es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abran la presentación, verán la recomendación **Read-Only** y pueden ver un mensaje como este: *Para evitar cambios accidentales, el autor ha configurado este archivo para que se abra en modo de solo lectura.*

La recomendación **Read-Only** es una medida simple pero eficaz que desanima la edición porque los usuarios deben realizar una acción para eliminarla antes de poder editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y desea comunicarlo de forma educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for Android mediante Java le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este fragmento de código muestra cómo establecer una presentación en **Read-Only** en Java usando Aspose.Slides:
```java
Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** está simplemente destinada a desanimar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si necesita impedir seriamente la edición no autorizada, es mejor que utilice [protecciones más estrictas que impliquen cifrados y contraseñas](https://docs.aspose.com/slides/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Preguntas frecuentes**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/androidjava/password-protected-presentation/) realmente restringe la apertura o edición y es apropiado cuando necesita controles de seguridad reales.

**¿Se puede combinar 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/androidjava/watermark/) como un disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o una herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [contraseñas y cifrado](/slides/es/androidjava/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los métodos 'isEncrypted' e 'isWriteProtected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) y [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.