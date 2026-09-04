---
title: Proteger presentaciones con contraseña en C++
linktitle: Protección de contraseñas
type: docs
weight: 20
url: /es/cpp/password-protected-presentation/
keywords:
- presentación protegida con contraseña
- contraseña de apertura
- cifrar PowerPoint
- descifrar PowerPoint
- validar la contraseña de la presentación
- comprobar la contraseña de la presentación
- abrir presentación cifrada
- eliminar cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- C++
- Aspose.Slides
description: "Cifre, detecte, valide, abra y descifre presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en C++ con Aspose.Slides."
---
## **Descripción general**

Una contraseña de apertura cifra una presentación. La contraseña correcta es necesaria para cargar y ver el contenido de la presentación, por lo que esta protección brinda confidencialidad.

Una contraseña de apertura es diferente de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para gestionar contraseñas para modificar presentaciones, consulte [Write-Protect Presentations](/slides/es/cpp/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [IProtectionManager::Encrypt](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/encrypt/) para asignar una contraseña de apertura. Después utilice [IPresentation::Save](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/save/) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Mantener públicas las propiedades del documento**

Por defecto, Aspose.Slides incluye las propiedades del documento en el cifrado de la presentación. [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) controla este comportamiento de forma independiente al cifrado del contenido de las diapositivas. Pase `false` a este método antes de llamar a [IProtectionManager::Encrypt](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/encrypt/) cuando un sistema de indexado, clasificación, búsqueda o gestión documental necesite leer los metadatos sin la contraseña de apertura.

El siguiente ejemplo crea una presentación PPTX cifrada mientras deja sus propiedades de documento incorporadas públicas:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto properties = presentation->get_DocumentProperties();
properties->set_Author(u"Contoso Knowledge Management");
properties->set_Title(u"Quarterly Product Roadmap");
properties->set_Keywords(u"roadmap, planning, internal");

presentation->get_Slide(0)->set_Name(u"Encrypted presentation content");
presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"public-properties-encrypted.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

Pasar `false` a `set_EncryptDocumentProperties` no hace públicas las diapositivas, maestros, diseños, formas, medios u otro contenido de la presentación. Afecta solo a las propiedades del documento. Para leer esas propiedades sin cargar el contenido cifrado, consulte [Manage Presentation Properties](/slides/es/cpp/presentation-properties/).

## **Cargar una presentación cifrada**

Establezca [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/) a la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/cpp/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Trabaje con la presentación descifrada.
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/removeencryption/) y guarde el resultado. La presentación guardada puede entonces cargarse sin contraseña.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Validar una contraseña de apertura antes de cargar**

Utilice [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) para obtener [IPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/) sin crear una instancia completa de la presentación. Verifique [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions::set_Password](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_password/) y luego carga la presentación completa:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Flujo de trabajo con flujo**

La sobrecarga de flujo de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ofrece el mismo flujo de trabajo. Restablezca la posición de un flujo que permita búsqueda antes de cargar la presentación completa desde ese flujo.

El siguiente ejemplo utiliza un archivo PPT:

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Valores de retorno de CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentationinfo/checkpassword/) devuelve `true` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `false` en cada uno de estos casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es nula o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) para confirmar que la presentación original estaba cifrada. Para detectar la protección por contraseña de apertura antes de cargar, utilice `IPresentationInfo::get_IsPasswordProtected` como se mostró arriba.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Security Recommendations**

{{% alert color="warning" title="Seguridad" %}}
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso al cargar inmediatamente la presentación.

Las propiedades públicas del documento pueden revelar nombres de autor, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados aunque el contenido de la presentación esté cifrado. Cifre los metadatos sensibles junto con la presentación. Dejar las propiedades públicas debe ser una decisión explícita que solo se tome cuando los sistemas deban indexar, clasificar, buscar o gestionar el archivo sin una contraseña de apertura.
{{% /alert %}}

## **Proteger una presentación con contraseña en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
1. Seleccione o cargue la presentación.
1. Introduzca una contraseña para la protección de visualización.
1. Opcionalmente introduzca una contraseña distinta para la protección de edición.
1. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="Ver también" %}}
- [Write-Protect Presentations](/slides/es/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/es/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección contra escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección contra escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, verifique si la protección por contraseña de apertura está presente y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Puede una aplicación leer los metadatos sin la contraseña de apertura?**

Sí, pero solo cuando la presentación se cifró con `set_EncryptDocumentProperties(false)`. La aplicación debe entonces usar el modo de carga solo de propiedades de documento descrito en [Manage Presentation Properties](/slides/es/cpp/presentation-properties/).

**¿Los flujos de trabajo de comprobación de contraseñas son compatibles con PPT y PPTX?**

Sí. La detección y validación de contraseñas basada en ruta de archivo y en flujo se comportan de la misma manera para presentaciones PPT y PPTX.