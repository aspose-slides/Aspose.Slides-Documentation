---
title: Presentación de Solo Lectura
type: docs
weight: 30
url: /es/python-net/read-only-presentation/
keywords: "Configuración de solo lectura, presentación de PowerPoint, Python, Aspose.Slides para Python a través de .NET"
description: "Presentación de PowerPoint de solo lectura en Python"
---

En PowerPoint 2019, Microsoft introdujo la configuración de **Siempre Abrir en Solo Lectura** como una de las opciones que los usuarios pueden utilizar para proteger sus presentaciones. Puede que desee utilizar esta configuración de Solo Lectura para proteger una presentación cuando

- Desea prevenir ediciones accidentales y mantener el contenido de su presentación a salvo.
- Desea alertar a las personas de que la presentación que proporcionó es la versión final.

Después de seleccionar la opción de **Siempre Abrir en Solo Lectura** para una presentación, cuando los usuarios abren la presentación, ven la recomendación de **Solo Lectura** y pueden ver un mensaje en esta forma: *Para prevenir cambios accidentales, el autor ha configurado este archivo para abrirse como solo lectura.*

La recomendación de Solo Lectura es un disuasivo simple pero efectivo que desanima la edición porque los usuarios deben realizar una tarea para eliminarla antes de que se les permita editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y desea informarles sobre esto de manera educada, entonces la recomendación de Solo Lectura puede ser una buena opción para usted.

> Si una presentación con la protección de **Solo Lectura** se abre en una aplicación anterior de Microsoft PowerPoint—que no soporta la función introducida recientemente—la recomendación de **Solo Lectura** se ignora (la presentación se abre normalmente).

Aspose.Slides para Python a través de .NET le permite configurar una presentación como **Solo Lectura**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación de **Solo Lectura**. Este código de muestra le muestra cómo configurar una presentación como **Solo Lectura** en Python utilizando Aspose.Slides:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.read_only_recommended = True
    pres.save("ReadOnlyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

**Nota**: La recomendación de **Solo Lectura** está simplemente destinada a desincentivar la edición o a evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que está haciendo—decide editar su presentación, puede eliminar fácilmente la configuración de Solo Lectura. Si realmente necesita prevenir ediciones no autorizadas, es mejor usar [protecciones más estrictas que impliquen encriptaciones y contraseñas](https://docs.aspose.com/slides/python-net/password-protected-presentation/).

{{% /alert %}}