---
title: Presentación Solo de Lectura
type: docs
weight: 30
url: /es/java/read-only-presentation/

---

En PowerPoint 2019, Microsoft introdujo la configuración de **Siempre Abrir en Solo Lectura** como una de las opciones que los usuarios pueden utilizar para proteger sus presentaciones. Puede que desee utilizar esta configuración de Solo Lectura para proteger una presentación cuando

- Desea prevenir ediciones accidentales y mantener el contenido de su presentación seguro.
- Desea alertar a las personas de que la presentación que proporcionó es la versión final.

Después de seleccionar la opción **Siempre Abrir en Solo Lectura** para una presentación, cuando los usuarios abren la presentación, ven la recomendación de **Solo Lectura** y pueden ver un mensaje en esta forma: *Para evitar cambios accidentales, el autor ha establecido este archivo para abrirse como solo lectura.*

La recomendación de Solo Lectura es un disuasivo simple pero efectivo que desanima la edición porque los usuarios deben realizar una tarea para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y desea decírselo de manera cortés, entonces la recomendación de Solo Lectura puede ser una buena opción para usted.

> Si una presentación con la protección de **Solo Lectura** se abre en una aplicación de Microsoft PowerPoint más antigua—que no admite la función introducida recientemente—la recomendación de **Solo Lectura** se ignora (la presentación se abre normalmente).

Aspose.Slides para Java le permite establecer una presentación en **Solo Lectura**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación de **Solo Lectura**. Este código de ejemplo muestra cómo establecer una presentación en **Solo Lectura** en Java utilizando Aspose.Slides:

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

**Nota**: La recomendación de **Solo Lectura** está simplemente destinada a desincentivar la edición o a detener a los usuarios de hacer cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que está haciendo—decide editar su presentación, puede eliminar fácilmente la configuración de Solo Lectura. Si realmente necesita prevenir la edición no autorizada, le conviene utilizar [protecciones más estrictas que involucren cifrados y contraseñas](https://docs.aspose.com/slides/java/password-protected-presentation/). 

{{% /alert %}}