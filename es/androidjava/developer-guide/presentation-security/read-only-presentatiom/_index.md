---
title: Guardar presentaciones en modo solo lectura en Android
linktitle: Presentación solo lectura
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
description: "Guarde archivos PowerPoint (PPT, PPTX) en modo solo lectura con Aspose.Slides para Android vía Java, ofreciendo vistas previas precisas de las diapositivas sin modificar sus presentaciones."
---
## **Introducción**

En PowerPoint 2019, Microsoft introdujo la configuración **Abrir siempre como solo lectura** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Puede que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Quiere evitar ediciones accidentales y mantener seguro el contenido de su presentación. 
- Quiere avisar a la gente que la presentación que ha proporcionado es la versión final. 

Después de seleccionar la opción **Abrir siempre como solo lectura** para una presentación, cuando los usuarios la abran, verán la recomendación **Solo lectura** y pueden ver un mensaje con esta forma: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación **Solo lectura** es una medida simple pero eficaz que disuade la edición porque los usuarios deben realizar una acción para eliminarla antes de poder editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de forma educada, la recomendación **Solo lectura** puede ser una buena opción para usted. 

> Si una presentación con la protección **Solo lectura** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Solo lectura** se ignora (la presentación se abre normalmente).

## **Aplicar modo Solo lectura**

Aspose.Slides for Android via Java le permite establecer una presentación como **Solo lectura**, lo que significa que los usuarios (después de abrir la presentación) verán la recomendación **Solo lectura**. Este código de ejemplo muestra cómo establecer una presentación como **Solo lectura** en Java usando Aspose.Slides:

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

**Nota**: La recomendación **Solo lectura** está pensada simplemente para desincentivar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si necesita impedir seriamente la edición no autorizada, es mejor utilizar [protecciones más estrictas que implican cifrados y contraseñas](https://docs.aspose.com/slides/es/androidjava/password-protected-presentation/).

{{% /alert %}} 

## **Preguntas frecuentes**

### ¿En qué se diferencia 'Solo lectura recomendado' de la protección completa con contraseña?

'Solo lectura recomendado' solo muestra una sugerencia para abrir el archivo en modo solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/androidjava/password-protected-presentation/) realmente restringe la apertura o edición y es apropiada cuando necesita controles de seguridad reales.

### ¿Se puede combinar 'Solo lectura recomendado' con marcas de agua para desalentar aún más las ediciones?

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/androidjava/watermark/) como un elemento disuasorio visual; son mecanismos separados y funcionan bien juntos.

### ¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está activada?

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, utilice [contraseñas y cifrado](/slides/es/androidjava/password-protected-presentation/).

### ¿Cómo se relaciona 'Solo lectura recomendado' con los métodos 'isEncrypted' e 'isWriteProtected'?

Son señales diferentes. 'Solo lectura recomendado' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/protectionmanager/#isWriteProtected--) y [isEncrypted](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/protectionmanager/#isEncrypted--) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.