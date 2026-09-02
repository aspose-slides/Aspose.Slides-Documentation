---
title: Presentaciones seguras con contraseñas en C++
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/cpp/password-protected-presentation/
keywords:
- bloquear PowerPoint
- bloquear presentación
- desbloquear PowerPoint
- desbloquear presentación
- proteger PowerPoint
- proteger presentación
- establecer contraseña
- añadir contraseña
- cifrar PowerPoint
- cifrar presentación
- descifrar PowerPoint
- descifrar presentación
- protección de escritura
- seguridad de PowerPoint
- seguridad de presentación
- eliminar contraseña
- eliminar protección
- eliminar cifrado
- desactivar contraseña
- desactivar protección
- eliminar protección de escritura
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo bloquear y desbloquear fácilmente presentaciones de PowerPoint y OpenDocument protegidas con contraseña usando Aspose.Slides para C++. Asegure sus presentaciones."
---
## **Introducción**

Cuando protege con contraseña una presentación, está estableciendo una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar las restricciones, hay que introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puede establecer una contraseña para aplicar estas restricciones a una presentación:

- **Modificación**

  Si desea que solo ciertos usuarios modifiquen su presentación, puede establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de su presentación (a menos que proporcionen la contraseña). 

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a su documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y otros— dentro de su presentación, pero no puede copiar elementos ni guardar la presentación. 

- **Apertura**

  Si desea que solo ciertos usuarios abran su presentación, puede establecer una restricción de apertura. Esta restricción impide que las personas incluso vean el contenido de su presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen sus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni hacer cambios en ella. 

  **Nota** que cuando protege con contraseña una presentación para impedir su apertura, el archivo de la presentación se cifra.

## **Cómo proteger con contraseña una presentación en línea**

1. Visite nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/es/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Haga clic en **Suelta o cargue sus archivos**.

3. Seleccione el archivo que desea proteger con contraseña en su equipo. 

4. Introduzca la contraseña que prefiera para la protección de edición; introduzca la contraseña que prefiera para la protección de visualización. 

5. Si desea que los usuarios vean su presentación como la copia final, marque la casilla **Mark as final**.

6. Haga clic en **PROTECT NOW.** 

7. Haga clic en **DOWNLOAD NOW.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite la protección con contraseña, el cifrado y operaciones similares para presentaciones en los siguientes formatos: 

- PPTX y PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Operaciones compatibles**

Aspose.Slides le permite usar la protección con contraseña en presentaciones para evitar modificaciones de las siguientes maneras:

- Encriptar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides le permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de las siguientes formas:

- Desencriptar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrar una presentación**

Puede cifrar una presentación estableciendo una contraseña. Entonces, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña. 

Para cifrar o proteger con contraseña una presentación, debe utilizar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.protection_manager)) para establecer una contraseña para la presentación. Pasa la contraseña al método encrypt y utiliza el método save para guardar la presentación ya cifrada. 

Este fragmento de código muestra cómo cifrar una presentación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Establecer protección de escritura en una presentación** 

Puede añadir una marca que indique “No modificar” a una presentación. De este modo, informa a los usuarios que no desea que realicen cambios en la presentación.  

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios —si realmente lo desean— pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente. 

Para establecer una protección de escritura, debe usar el método setWriteProtection. Este fragmento de código muestra cómo establecer una protección de escritura en una presentación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Cargar una presentación cifrada**

Aspose.Slides le permite cargar un archivo cifrado proporcionando su contraseña. Para descifrar una presentación, debe llamar al método [RemoveEncryption](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sin parámetros. A continuación, deberá introducir la contraseña correcta para cargar la presentación. 

Este fragmento de código muestra cómo descifrar una presentación: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// trabajar con la presentación descifrada
```

## **Eliminar el cifrado de una presentación**

Puede eliminar el cifrado o la protección con contraseña de una presentación. De este modo, los usuarios pueden acceder o modificar la presentación sin restricciones. 

Para eliminar el cifrado o la protección con contraseña, debe llamar al método [RemoveEncryption](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Este fragmento de código muestra cómo eliminar el cifrado de una presentación:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Eliminar la protección de escritura de una presentación**

Puede usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De este modo, los usuarios pueden modificar a su gusto —y no reciben advertencias al realizar esas tareas.

Puede eliminar la protección de escritura de una presentación usando el método [RemoveWriteProtection](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Obtener propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para recuperar las propiedades del documento de una presentación cifrada o protegida con contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que le permite proteger con contraseña una presentación y, al mismo tiempo, habilitar el acceso a sus propiedades del documento.

**Nota:** Por defecto, cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también quedan protegidas con contraseña. Si necesita que las propiedades del documento sigan accesibles incluso después del cifrado, Aspose.Slides le permite hacerlo.

Si desea que los usuarios conserven la capacidad de acceder a las propiedades de una presentación cifrada, pase `false` al método `set_EncryptDocumentProperties` de [IProtectionManager](https://reference.aspose.com/slides/es/cpp/aspose.slides/iprotectionmanager/). Este fragmento de código muestra cómo cifrar una presentación y, al mismo tiempo, proporcionar a los usuarios acceso a sus propiedades del documento:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Cargar solo propiedades del documento de una presentación cifrada**

Para inspeccionar los metadatos de una presentación cifrada sin cargar sus diapositivas u otro contenido, cree un objeto [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/) y establezca [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) a `true`. En este modo, Aspose.Slides ignora la contraseña y carga solo las propiedades del documento que son accesibles públicamente.

El siguiente ejemplo de código lee las propiedades del documento incorporadas y personalizadas mediante [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_documentproperties/):

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Este flujo de trabajo funciona solo cuando las propiedades del documento se dejaron sin cifrar (públicas) al cifrar la presentación. Si las propiedades del documento están cifradas, establecer `LoadOptions::set_OnlyLoadDocumentProperties` a `true` provoca una excepción porque la contraseña se ignora en este modo. Para acceder a las propiedades del documento cifradas o cargar la presentación completa, incluidas sus diapositivas y otro contenido, proporcione la contraseña correcta con `LoadOptions::set_Password` en [LoadOptions](https://reference.aspose.com/slides/es/cpp/aspose.slides/loadoptions/).

## **Comprobar si una presentación está protegida con contraseña**

Antes de cargar una presentación, puede que desee comprobar y confirmar que la presentación no está protegida con contraseña. De este modo, evita errores y problemas similares que aparecen cuando se carga una presentación protegida con contraseña sin contar con ella.

Este código C++ muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Comprobar si una presentación está cifrada**

Aspose.Slides le permite comprobar si una presentación está cifrada. Para realizar esta tarea, puede usar el método [get_IsEncrypted()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), que devuelve `true` si la presentación está cifrada o `false` si no lo está. 

Este fragmento de código muestra cómo comprobar si una presentación está cifrada:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides le permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puede usar el método [get_IsWriteProtected()](https://reference.aspose.com/slides/es/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), que devuelve `true` si la presentación está protegida contra escritura o `false` si no lo está. 

Este fragmento de código muestra cómo comprobar si una presentación está protegida contra escritura:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verificar uso de contraseña en la presentación**

Puede que desee comprobar y confirmar que se ha usado una contraseña concreta para proteger el documento de una presentación. Aspose.Slides ofrece los medios para validar una contraseña. 

Este fragmento de código muestra cómo validar una contraseña:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// comprobar si "pass" coincide con
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada. En caso contrario, devuelve `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/es/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**¿Qué métodos de cifrado son compatibles con Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos los algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para sus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se utiliza una contraseña incorrecta, avisándole de que el acceso a la presentación está denegado. Esto ayuda a evitar accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto de rendimiento es mínimo y no afecta de manera significativa el tiempo total de procesamiento de sus tareas con presentaciones.