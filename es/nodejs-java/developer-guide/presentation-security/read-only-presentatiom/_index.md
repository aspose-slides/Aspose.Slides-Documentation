---
title: Presentación de solo lectura
type: docs
weight: 30
url: /es/nodejs-java/read-only-presentation/
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Es posible que desee utilizar esta configuración de solo lectura para proteger una presentación cuando

- Desee evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Desee avisar a las personas que la presentación que usted suministró es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abran la presentación, verán la recomendación **Read-Only** y pueden ver un mensaje en esta forma: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo de solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una acción para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarles esto de manera cortés, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión antigua de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for Node.js via Java le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este código de ejemplo le muestra cómo establecer una presentación en **Read-Only** en JavaScript usando Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** simplemente pretende desalentar la edición o impedir que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si realmente necesita evitar la edición no autorizada, es mejor usar [protecciones más estrictas que implican cifrados y contraseñas](https://docs.aspose.com/slides/nodejs-java/password-protected-presentation/).

{{% /alert %}} 

## **Preguntas frecuentes**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia de abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/nodejs-java/password-protected-presentation/) realmente restringe la apertura o edición y es apropiado cuando necesita controles de seguridad reales.

**¿Puede 'Read-Only recommended' combinarse con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/nodejs-java/watermark/) como un disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [contraseñas y cifrado](/slides/es/nodejs-java/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los indicadores 'IsEncrypted' e 'IsWriteProtected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/) y [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/protectionmanager/isencrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.