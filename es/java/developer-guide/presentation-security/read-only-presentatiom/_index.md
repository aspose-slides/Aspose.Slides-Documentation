---
title: Guardar presentaciones en modo de solo lectura usando Java
linktitle: Presentación de solo lectura
type: docs
weight: 30
url: /es/java/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar edición
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Cargue y guarde archivos PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides for Java, ofreciendo vistas previas precisas de diapositivas sin alterar sus presentaciones."
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Es posible que desee utilizar esta configuración de solo lectura para proteger una presentación cuando

- Quiere evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Quiere avisar a las personas que la presentación que proporcionó es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abran la presentación, verán la recomendación **Read-Only** y pueden ver un mensaje de este tipo: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para quitarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de forma cortés, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for Java le permite establecer una presentación como **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este fragmento de código muestra cómo establecer una presentación como **Read-Only** en Java usando Aspose.Slides:
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

**Nota**: La recomendación **Read-Only** está pensada simplemente para desalentar la edición o impedir que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración **Read-Only**. Si necesita prevenir seriamente la edición no autorizada, es mejor usar [protecciones más estrictas que involucren cifrados y contraseñas](https://docs.aspose.com/slides/java/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de evitar. [Protección con contraseña](/slides/es/java/password-protected-presentation/) realmente restringe la apertura o edición y es apropiada cuando necesita controles de seguridad reales.

**¿Puede 'Read-Only recommended' combinarse con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/java/watermark/) como un disuasivo visual; son mecanismos independientes y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para prevenir ediciones automatizadas, use [contraseñas y cifrado](/slides/es/java/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los métodos 'isEncrypted' e 'isWriteProtected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isWriteProtected--) y [isEncrypted](https://reference.aspose.com/slides/java/com.aspose.slides/protectionmanager/#isEncrypted--) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.