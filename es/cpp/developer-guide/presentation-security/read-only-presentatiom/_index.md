---
title: Guardar presentaciones en modo solo lectura usando C++
linktitle: Presentación solo lectura
type: docs
weight: 30
url: /es/cpp/read-only-presentation/
keywords:
- solo lectura
- proteger presentación
- evitar edición
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Cargue y guarde archivos de PowerPoint (PPT, PPTX) en modo solo lectura con Aspose.Slides para C++, ofreciendo vistas previas precisas de diapositivas sin alterar sus presentaciones."
---

## **Aplicar modo de solo lectura**

En PowerPoint 2019, Microsoft introdujo la configuración **Always Open Read-Only** como una de las opciones que los usuarios pueden usar para proteger sus presentaciones. Puede que desee usar esta configuración de solo lectura para proteger una presentación cuando

- Desea prevenir ediciones accidentales y mantener el contenido de su presentación seguro. 
- Desea alertar a las personas de que la presentación que proporcionó es la versión final. 

Después de seleccionar la opción **Always Open Read-Only** para una presentación, cuando los usuarios la abren, ven la recomendación **Read-Only** y pueden ver un mensaje de este tipo: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo de solo lectura.*

La recomendación **Read-Only** es un disuasivo simple pero eficaz que desalienta la edición porque los usuarios deben realizar una tarea para eliminarla antes de poder editar una presentación. Si no desea que los usuarios realicen cambios en una presentación y quiere comunicarlo de manera educada, la recomendación **Read-Only** puede ser una buena opción para usted. 

> Si una presentación con la protección **Read-Only** se abre en una versión anterior de Microsoft PowerPoint—que no admite la función introducida recientemente—la recomendación **Read-Only** se ignora (la presentación se abre normalmente).

Aspose.Slides for C++ le permite establecer una presentación en **Read-Only**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Read-Only**. Este código de ejemplo muestra cómo establecer una presentación en **Read-Only** en C++ usando Aspose.Slides:
``` cpp
auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" %}} 

**Nota**: La recomendación **Read-Only** simplemente está destinada a desalentar la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada—que sabe lo que hace—decide editar su presentación, puede eliminar fácilmente la configuración de solo lectura. Si necesita prevenir seriamente la edición no autorizada, es mejor usar [protecciones más estrictas que incluyen encriptaciones y contraseñas](https://docs.aspose.com/slides/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

**¿Cómo se diferencia 'Read-Only recommended' de la protección completa con contraseña?**

'Read-Only recommended' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/cpp/password-protected-presentation/) realmente restringe la apertura o edición y es adecuada cuando necesita controles de seguridad reales.

**¿Se puede combinar 'Read-Only recommended' con marcas de agua para desalentar aún más las ediciones?**

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/cpp/watermark/) como un disuasivo visual; son mecanismos separados y funcionan bien juntos.

**¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?**

Sí. La recomendación no bloquea cambios programáticos. Para prevenir ediciones automatizadas, use [contraseñas y encriptación](/slides/es/cpp/password-protected-presentation/).

**¿Cómo se relaciona 'Read-Only recommended' con los indicadores 'is encrypted' e 'is write protected'?**

Son señales distintas. 'Read-Only recommended' es un aviso suave y opcional; [get_IsWriteProtected](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) y [get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/protectionmanager/get_isencrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o encriptación.