---
title: Guardar presentaciones en modo de solo lectura usando PHP
linktitle: Presentación de solo lectura
type: docs
weight: 30
url: /es/php-java/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar edición
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Cargar y guardar archivos de PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides para PHP, ofreciendo vistas previas precisas de las diapositivas sin alterar sus presentaciones."
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Puede que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Quiere evitar ediciones accidentales y mantener el contenido de su presentación seguro. 
- Quiere alertar a las personas de que la presentación que ha proporcionado es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios abren la presentación, ven la recomendación **Read-Only** y pueden ver un mensaje de este tipo: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desanima la edición porque los usuarios deben realizar una acción para eliminarla antes de que se les permita editar una presentación. Si no quiere que los usuarios hagan cambios en una presentación y desea comunicarlo de forma educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for PHP via Java le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este fragmento de código muestra cómo establecer una presentación en **Read-Only** usando Aspose.Slides:
```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** simplemente pretende desanimar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar su presentación, puede eliminar fácilmente la configuración **Read-Only**. Si realmente necesita impedir la edición no autorizada, es mejor usar [protecciones más estrictas que implican cifrados y contraseñas](https://docs.aspose.com/slides/php-java/password-protected-presentation/).

{{% /alert %}} 

## **FAQ**

**¿En qué se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia de abrir el archivo en modo solo lectura y es fácil de eludir. [Password protection](/slides/es/php-java/password-protected-presentation/) restringe realmente la apertura o edición y es adecuada cuando necesita controles de seguridad reales.

**¿Puede combinarse 'Read-Only recommended' con marcas de agua para desanimar aún más las ediciones?**

Sí. La recomendación puede combinarse con [watermarks](/slides/es/php-java/watermark/) como un disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automatizadas, use [passwords and encryption](/slides/es/php-java/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los métodos 'isEncrypted' e 'isWriteProtected'?**

Son señales diferentes. 'Read-Only recommended' es un aviso suave y opcional; [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/iswriteprotected/) e [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isencrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.