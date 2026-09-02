---
title: Proteger presentaciones contra escritura en C++
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/cpp/write-protected-presentation/
keywords:
- protección contra escritura
- protección contra escritura PowerPoint
- contraseña para modificar
- restringir la edición de la presentación
- eliminar la protección contra escritura
- validar contraseña de modificación
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX usando Aspose.Slides para C++."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación pero no cifra su contenido. Los usuarios pueden cargar y ver una presentación protegida contra escritura sin la contraseña. Según la aplicación, también pueden editar el contenido y guardarlo con otro nombre, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura cumple un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, consulte [Proteger presentaciones con contraseña](/slides/es/cpp/password-protected-presentation/).

Los flujos de trabajo de este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan archivos PPTX; al guardar en PPT, use la extensión `.ppt` y el formato de guardado PPT correspondiente.

## **Establecer protección contra escritura en una presentación**

Utilice [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) para asignar una contraseña que permita modificar una presentación. Guardar la presentación conserva la configuración de protección.

El siguiente ejemplo establece protección contra escritura en una presentación PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Cargar una presentación protegida contra escritura**

Debido a que la protección contra escritura no cifra el contenido de la presentación, no se requiere contraseña para cargarla. La contraseña solo es relevante al validar la autorización para modificar la presentación protegida.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

No pase una contraseña de protección contra escritura a [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/). Esa propiedad acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporcione la contraseña de apertura para cargarla y gestione la contraseña de protección contra escritura por separado.

## **Eliminar la protección contra escritura de una presentación**

Utilice [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) para eliminar la restricción de modificación y luego guarde la presentación.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/), llame a [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) y examine [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). La propiedad utiliza [NullableBool](https://reference.aspose.com/slides/es/cpp/aspose.slides/nullablebool/) y devuelve `NullableBool::True` cuando se detecta protección contra escritura.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

La sobrecarga de flujo de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) proporciona la misma información para una presentación suministrada como flujo.

## **Validar una contraseña de protección contra escritura**

Utilice [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) para validar una contraseña de modificación sin cargar la presentación completa. Verifique primero [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) para que la aplicación solicite o valide una contraseña solo cuando exista protección contra escritura.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) valida únicamente la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si se puede cargar contenido cifrado. Por el contrario, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/checkpassword/) valida solo una contraseña de apertura. Si ya se ha cargado una presentación completa, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) ofrece la comprobación equivalente de protección contra escritura a través de su gestor de protección.

En aplicaciones en producción, no registre contraseñas ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios y mantenga las contraseñas en memoria solo el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Proteger presentaciones con contraseña](/slides/es/cpp/password-protected-presentation/)
- [Presentaciones de solo lectura](/slides/es/cpp/read-only-presentation/)
- [Firma digital en PowerPoint](/slides/es/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargar y ver.

**¿Se requiere la contraseña de protección contra escritura para abrir una presentación?**

No. Sólo se requiere una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una contraseña de protección contra escritura?**

Sí. Proporcione la contraseña de apertura a través de las opciones de carga para abrir la presentación cifrada y valide la contraseña de protección contra escritura por separado cuando se requiera autorización para modificar.