---
title: Guardar presentaciones en modo de solo lectura usando C++
linktitle: Presentación de solo lectura
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
description: "Cargue y guarde archivos de PowerPoint (PPT, PPTX) en modo de solo lectura con Aspose.Slides para C++, ofreciendo vistas previas precisas de diapositivas sin alterar sus presentaciones."
---
## **Introducción**

En PowerPoint 2019, Microsoft introdujo la opción **Abrir siempre en modo de solo lectura** como una de las configuraciones que los usuarios pueden utilizar para proteger sus presentaciones. Es posible que desees usar esta configuración de solo lectura para proteger una presentación cuando

- Quieras evitar ediciones accidentales y mantener el contenido de tu presentación seguro. 
- Quieras avisar a la gente de que la presentación que proporcionas es la versión final. 

Después de seleccionar la opción **Abrir siempre en modo de solo lectura** para una presentación, cuando los usuarios la abran, verán la recomendación **Solo lectura** y pueden ver un mensaje similar a este: *Para evitar cambios accidentales, el autor ha configurado este archivo para abrirse en modo de solo lectura.*

La recomendación **Solo lectura** es una medida simple pero eficaz que disuade la edición porque los usuarios deben realizar una acción para eliminarla antes de poder editar una presentación. Si no deseas que los usuarios realicen cambios en una presentación y quieres comunicarlo de forma educada, entonces la recomendación **Solo lectura** puede ser una buena opción para ti. 

> Si una presentación con la protección **Solo lectura** se abre en una versión anterior de Microsoft PowerPoint —que no admite la función introducida recientemente— la recomendación **Solo lectura** se ignora (la presentación se abre normalmente).

## **Aplicar modo de solo lectura**

Aspose.Slides para C++ permite establecer una presentación en **Solo lectura**, lo que significa que los usuarios (después de abrir la presentación) ven la recomendación **Solo lectura**. Este código de ejemplo muestra cómo establecer una presentación en **Solo lectura** en C++ usando Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**Nota**: La recomendación **Solo lectura** está pensada simplemente para disuadir la edición o evitar que los usuarios realicen cambios accidentales en una presentación de PowerPoint. Si una persona motivada —que sabe lo que hace— decide editar tu presentación, puede eliminar fácilmente la configuración de solo lectura. Si necesitas impedir seriamente la edición no autorizada, es mejor utilizar [protecciones más estrictas que incluyen cifrados y contraseñas](https://docs.aspose.com/slides/es/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **Preguntas frecuentes**

### ¿En qué se diferencia 'Solo lectura recomendado' de la protección completa con contraseña?

'Solo lectura recomendado' solo muestra una sugerencia para abrir el archivo en modo de solo lectura y es fácil de eludir. [Protección con contraseña](/slides/es/cpp/password-protected-presentation/) restringe realmente la apertura o edición y es apropiada cuando necesitas controles de seguridad reales.

### ¿Se puede combinar 'Solo lectura recomendado' con marcas de agua para desalentar aún más las ediciones?

Sí. La recomendación puede combinarse con [marcas de agua](/slides/es/cpp/watermark/) como un elemento disuasorio visual; son mecanismos independientes y funcionan bien juntos.

### ¿Puede una macro o herramienta externa seguir modificando el archivo cuando la recomendación está habilitada?

Sí. La recomendación no bloquea los cambios programáticos. Para evitar ediciones automáticas, usa [contraseñas y cifrado](/slides/es/cpp/password-protected-presentation/).

### ¿Cómo se relaciona 'Solo lectura recomendado' con los indicadores 'está cifrado' y 'está protegido contra escritura'?

Son señales diferentes. 'Solo lectura recomendado' es un mensaje suave y opcional; [get_IsWriteProtected](https://reference.aspose.com/slides/es/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) y [get_IsEncrypted](https://reference.aspose.com/slides/es/cpp/aspose.slides/protectionmanager/get_isencrypted/) indican restricciones reales de escritura o lectura que dependen de contraseñas o cifrado.