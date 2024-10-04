---
title: Presentación de Solo Lectura
type: docs
weight: 30
url: /php-java/read-only-presentation/

---

En PowerPoint 2019, Microsoft introdujo la configuración de **Siempre abrir como solo lectura** como una de las opciones que los usuarios pueden utilizar para proteger sus presentaciones. Es posible que desee utilizar esta configuración de solo lectura para proteger una presentación cuando

- Desea evitar ediciones accidentales y mantener el contenido de su presentación a salvo.
- Desea alertar a las personas de que la presentación que proporcionó es la versión final.

Después de seleccionar la opción **Siempre abrir como solo lectura** para una presentación, cuando los usuarios abren la presentación, ven la recomendación de **Solo lectura** y pueden ver un mensaje en esta forma: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación de solo lectura es un disuasivo simple pero efectivo que desanima la edición porque los usuarios tienen que realizar una tarea para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y desea informarles sobre esto de manera educada, entonces la recomendación de solo lectura puede ser una buena opción para usted.

> Si una presentación con la protección de **Solo lectura** se abre en una aplicación de Microsoft PowerPoint más antigua—que no admite la función recientemente introducida—la recomendación de **Solo lectura** es ignorada (la presentación se abre normalmente).

Aspose.Slides para PHP a través de Java le permite establecer una presentación como **Solo lectura**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación de **Solo lectura**. Este código de muestra le muestra cómo establecer una presentación como **Solo lectura** utilizando Aspose.Slides:

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

**Nota**: La recomendación de **Solo lectura** está simplemente destinada a desincentivar la edición o a evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que está haciendo—decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si realmente necesita evitar la edición no autorizada, es mejor utilizar [protecciones más estrictas que involucren encriptaciones y contraseñas](https://docs.aspose.com/slides/php-java/password-protected-presentation/).

{{% /alert %}}