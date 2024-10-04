---
title: Presentación Solo Lectura
type: docs
weight: 30
url: /cpp/read-only-presentation/

---

En PowerPoint 2019, Microsoft introdujo la opción de **Abrir Siempre en Solo Lectura** como una de las opciones que los usuarios pueden utilizar para proteger sus presentaciones. Puede que desee utilizar esta opción de Solo Lectura para proteger una presentación cuando

- Desea prevenir ediciones accidentales y mantener el contenido de su presentación seguro.
- Desea alertar a las personas que la presentación que proporcionó es la versión final.

Después de seleccionar la opción de **Abrir Siempre en Solo Lectura** para una presentación, cuando los usuarios abran la presentación, verán la recomendación de **Solo Lectura** y pueden ver un mensaje en este formato: *Para prevenir cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación de Solo Lectura es un disuasivo simple pero efectivo que desalienta la edición porque los usuarios tienen que realizar una tarea para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios hagan cambios en una presentación y quiere informarles sobre esto de una manera educada, entonces la recomendación de Solo Lectura puede ser una buena opción para usted.

> Si una presentación con la protección de **Solo Lectura** se abre en una aplicación de Microsoft PowerPoint más antigua—que no soporta la función recién introducida—la recomendación de **Solo Lectura** es ignorada (la presentación se abre normalmente).

Aspose.Slides para C++ le permite establecer una presentación como **Solo Lectura**, lo que significa que los usuarios (después de abrir la presentación) verán la recomendación de **Solo Lectura**. Este código de ejemplo le muestra cómo establecer una presentación como **Solo Lectura** en C++ utilizando Aspose.Slides:

``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" %}} 

**Nota**: La recomendación de **Solo Lectura** simplemente está destinada a desalentar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que está haciendo—decide editar su presentación, puede eliminar fácilmente la configuración de Solo Lectura. Si realmente necesita prevenir la edición no autorizada, es mejor usar [protecciones más estrictas que involucren encriptaciones y contraseñas](https://docs.aspose.com/slides/cpp/password-protected-presentation/).

{{% /alert %}}