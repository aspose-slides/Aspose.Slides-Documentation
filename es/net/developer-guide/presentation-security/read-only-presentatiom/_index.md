---
title: Presentación de Solo Lectura
type: docs
weight: 30
url: /net/read-only-presentation/
keywords: "Configuración de solo lectura, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Presentación de PowerPoint de solo lectura en C# o .NET"
---

En PowerPoint 2019, Microsoft introdujo la configuración de **Abrir Siempre en Solo Lectura** como una de las opciones que los usuarios pueden utilizar para proteger sus presentaciones. Podrías querer usar esta configuración de Solo Lectura para proteger una presentación cuando

- Quieres evitar ediciones accidentales y mantener el contenido de tu presentación a salvo. 
- Quieres alertar a las personas que la presentación que proporcionaste es la versión final. 

Después de seleccionar la opción **Abrir Siempre en Solo Lectura** para una presentación, cuando los usuarios abren la presentación, ven la recomendación de **Solo Lectura** y pueden ver un mensaje de esta forma: *Para prevenir cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación de Solo Lectura es un disuasivo simple pero efectivo que desalienta la edición porque los usuarios tienen que realizar una tarea para eliminarla antes de que se les permita editar una presentación. Si no quieres que los usuarios realicen cambios en una presentación y deseas avisarles de esto de manera educada, entonces la recomendación de Solo Lectura puede ser una buena opción para ti. 

> Si una presentación con la protección de **Solo Lectura** se abre en una aplicación de Microsoft PowerPoint más antigua—que no soporta la función recientemente introducida—la recomendación de **Solo Lectura** es ignorada (la presentación se abre normalmente).

Aspose.Slides para .NET te permite establecer una presentación en **Solo Lectura**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación de **Solo Lectura**. Este código de ejemplo te muestra cómo establecer una presentación en **Solo Lectura** en C# utilizando Aspose.Slides:

```c#
using (Presentation pres = new Presentation())
{
    pres.ProtectionManager.ReadOnlyRecommended = true;
    pres.Save("ReadOnlyPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" %}} 

**Nota**: La recomendación de **Solo Lectura** está simplemente destinada a desalentar la edición o detener a los usuarios de hacer cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que está haciendo—decide editar tu presentación, puede eliminar fácilmente la configuración de Solo Lectura. Si realmente necesitas prevenir la edición no autorizada, es mejor que utilices [protecciones más estrictas que involucren encriptaciones y contraseñas](https://docs.aspose.com/slides/net/password-protected-presentation/). 

{{% /alert %}} 