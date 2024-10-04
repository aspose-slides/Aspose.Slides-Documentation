---
title: Presentación de Solo Lectura
type: docs
weight: 30
url: /es/androidjava/read-only-presentation/

---

En PowerPoint 2019, Microsoft introdujo la configuración de **Abrir Siempre como Solo Lectura** como una de las opciones que los usuarios pueden utilizar para proteger sus presentaciones. Puede que desee usar esta configuración de Solo Lectura para proteger una presentación cuando

- Desea prevenir ediciones accidentales y mantener el contenido de su presentación seguro.
- Desea alertar a las personas que la presentación que proporcionó es la versión final.

Después de seleccionar la opción de **Abrir Siempre como Solo Lectura** para una presentación, cuando los usuarios abren la presentación, ven la recomendación de **Solo Lectura** y pueden ver un mensaje en esta forma: *Para prevenir cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación de Solo Lectura es un simple pero efectivo disuasivo que desanima la edición porque los usuarios deben realizar una tarea para eliminarla antes de que se les permita editar la presentación. Si no desea que los usuarios realicen cambios en una presentación y desea comunicarles esto de manera educada, entonces la recomendación de Solo Lectura puede ser una buena opción para usted.

> Si se abre una presentación con la protección de **Solo Lectura** en una aplicación más antigua de Microsoft PowerPoint—que no admite la función recientemente introducida—la recomendación de **Solo Lectura** se ignora (la presentación se abre normalmente).

Aspose.Slides para Android a través de Java le permite establecer una presentación como **Solo Lectura**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación de **Solo Lectura**. Este código de muestra le muestra cómo establecer una presentación como **Solo Lectura** en Java utilizando Aspose.Slides:

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

**Nota**: La recomendación de **Solo Lectura** simplemente tiene como objetivo desincentivar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que está haciendo—decide editar su presentación, puede eliminar fácilmente la configuración de Solo Lectura. Si realmente necesita evitar la edición no autorizada, es mejor utilizar [protecciones más estrictas que involucren encriptaciones y contraseñas](https://docs.aspose.com/slides/androidjava/password-protected-presentation/).

{{% /alert %}} 