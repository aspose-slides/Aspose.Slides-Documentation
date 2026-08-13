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
description: "Cargue y guarde archivos PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides para Java, ofreciendo vistas previas precisas de las diapositivas sin alterar sus presentaciones."
---
## **Introducción**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Puede que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Desea evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Desea alertar a las personas de que la presentación que ha proporcionado es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abren la presentación, ven la recomendación **Read-Only** y pueden ver un mensaje como este: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo de solo lectura.*

La recomendación **Read-Only** es una medida simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para eliminarla antes de poder editar una presentación. Si no quiere que los usuarios realicen cambios en una presentación y desea comunicarlo de manera educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

## **Aplicar modo de solo lectura**

Aspose.Slides for Java le permite establecer una presentación como **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este código de ejemplo le muestra cómo establecer una presentación como **Read-Only** en Java usando Aspose.Slides:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="info" %}} 

**Nota**: La recomendación **Read-Only** está pensada simplemente para desalentar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si realmente necesita impedir la edición no autorizada, es mejor utilizar [protecciones más estrictas que implican cifrados y contraseñas](https://docs.aspose.com/slides/es/java/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

### ¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/java/password-protected-presentation/) realmente restringe la apertura o edición y es apropiado cuando necesita controles de seguridad reales.

### ¿Se puede combinar 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/java/watermark/) como un elemento disuasorio visual; son mecanismos separados y funcionan bien juntos.

### ¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, utilice [contraseñas y cifrado](/slides/es/java/password-protected-presentation/).

### ¿Cómo se relaciona 'Read-Only recommended' con los métodos 'isEncrypted' e 'isWriteProtected'?

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/es/java/com.aspose.slides/protectionmanager/#isWriteProtected--) y [isEncrypted](https://reference.aspose.com/slides/es/java/com.aspose.slides/protectionmanager/#isEncrypted--) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.