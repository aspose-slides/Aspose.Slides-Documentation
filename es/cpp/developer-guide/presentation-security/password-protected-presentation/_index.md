---
title: Presentaciones Seguras con Contraseñas en C++
linktitle: Protección con Contraseña
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
description: "Aprenda a bloquear y desbloquear fácilmente presentaciones de PowerPoint y OpenDocument protegidas con contraseña usando Aspose.Slides para C++. Proteja sus presentaciones."
---

## **Acerca de la protección con contraseña**
### **¿Cómo funciona la protección con contraseña para presentaciones?**
Cuando protege una presentación con contraseña, está estableciendo una contraseña que impone ciertas restricciones en la presentación. Para eliminar las restricciones, se debe introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puede establecer una contraseña para imponer estas restricciones en una presentación:

- **Modificación**

  Si desea que solo ciertos usuarios modifiquen su presentación, puede establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de su presentación (a menos que proporcionen la contraseña). 

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a su documento y abrirlo. En modo de solo lectura, el usuario puede ver el contenido o elementos—hipervínculos, animaciones, efectos y otros—dentro de su presentación, pero no puede copiar elementos ni guardar la presentación. 

- **Apertura**

  Si desea que solo ciertos usuarios abran su presentación, puede establecer una restricción de apertura. Esta restricción impide que las personas siquiera vean el contenido de su presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen sus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni realizar cambios en ella. 
  
  **Nota** que cuando protege una presentación con contraseña para impedir la apertura, el archivo de la presentación se cifra.

## **Cómo proteger una presentación con contraseña en línea**

1. Vaya a nuestra página [**Bloqueo de Aspose.Slides**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides‑lock.png)

2. Haga clic en **Soltar o cargar sus archivos**.

3. Seleccione el archivo que desea proteger con contraseña en su computadora. 

4. Introduzca su contraseña preferida para la protección de edición; introduzca su contraseña preferida para la protección de visualización. 

5. Si desea que los usuarios vean su presentación como la copia final, marque la casilla **Marcar como final**.

6. Haga clic en **PROTEGER AHORA.** 

7. Haga clic en **DESCARGAR AHORA.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos admitidos**

Aspose.Slides admite protección con contraseña, cifrado y operaciones similares para presentaciones en estos formatos: 

- PPTX y PPT – Presentación de Microsoft PowerPoint 
- ODP – Presentación OpenDocument 
- OTP – Plantilla de presentación OpenDocument 

**Operaciones admitidas**

Aspose.Slides le permite usar protección con contraseña en presentaciones para impedir modificaciones de las siguientes maneras:

- Cifrar una presentación
- Establecer protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides le permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de las siguientes maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; deshabilitar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrar una presentación**

Puede cifrar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña. 

Para cifrar o proteger con contraseña una presentación, debe usar el método **encrypt** (de [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) para establecer una contraseña para la presentación. Pasa la contraseña al método **encrypt** y usa el método **save** para guardar la presentación ahora cifrada. 

Este código de ejemplo muestra cómo cifrar una presentación:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```


## **Establecer protección de escritura en una presentación** 

Puede añadir una marca que indique “No modificar” a una presentación. De esta forma, le indica a los usuarios que no desea que realicen cambios en la presentación.  

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios—si realmente lo desean—pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente. 

Para establecer una protección de escritura, debe usar el método **setWriteProtection**. Este código de ejemplo muestra cómo establecer una protección de escritura en una presentación:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```


## **Cargar una presentación cifrada**

Aspose.Slides le permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debe llamar al método [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sin parámetros. Luego deberá introducir la contraseña correcta para cargar la presentación. 

Este código de ejemplo muestra cómo descifrar una presentación: 
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// trabajar con la presentación descifrada
```


## **Eliminar el cifrado de una presentación**

Puede eliminar el cifrado o la protección con contraseña de una presentación. De esta forma, los usuarios pueden acceder o modificar la presentación sin restricciones. 

Para eliminar el cifrado o la protección con contraseña, debe llamar al método [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Este código de ejemplo muestra cómo eliminar el cifrado de una presentación:
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```


## **Eliminar la protección de escritura de una presentación**

Puede usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De esta forma, los usuarios pueden modificar a su gusto y no reciben advertencias al realizar dichas tareas.

Puede eliminar la protección de escritura de una presentación usando el método [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Este código de ejemplo muestra cómo eliminar la protección de escritura de una presentación:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```


## **Obtener las propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación cifrada o protegida con contraseña. Aspose.Slides, sin embargo, ofrece un mecanismo que le permite proteger una presentación con contraseña mientras mantiene la posibilidad de que los usuarios accedan a sus propiedades.

**Nota** que cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también se protegen con contraseña por defecto. Pero si necesita que las propiedades de la presentación sean accesibles (incluso después de que la presentación se haya cifrado), Aspose.Slides le permite hacer precisamente eso. 

Si desea que los usuarios conserven la capacidad de acceder a las propiedades de una presentación que ha cifrado, puede pasar `true` al método [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Este código de ejemplo muestra cómo cifrar una presentación proporcionando a los usuarios los medios para acceder a sus propiedades del documento:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```


## **Comprobar si una presentación está protegida con contraseña**

Antes de cargar una presentación, puede que desee comprobar y confirmar que la presentación no está protegida con contraseña. De esta forma, evita errores y problemas similares que se producen al cargar una presentación protegida con contraseña sin su contraseña.

Este código C++ le muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):
```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```


## **Comprobar si una presentación está cifrada**

Aspose.Slides le permite comprobar si una presentación está cifrada. Para realizar esta tarea, puede usar el método [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), que devuelve `true` si la presentación está cifrada o `false` si la presentación no está cifrada. 

Este código de ejemplo le muestra cómo comprobar si una presentación está cifrada:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```


## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides le permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puede usar el método [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), que devuelve `true` si la presentación está protegida contra escritura o `false` si la presentación no lo está. 

Este código de ejemplo le muestra cómo comprobar si una presentación está protegida contra escritura:
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```


## **Verificar el uso de la contraseña de la presentación**

Puede que desee comprobar y confirmar que una contraseña específica se ha utilizado para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña. 

Este código de ejemplo le muestra cómo validar una contraseña:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// comprobar si "pass" coincide con
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```


Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada. De lo contrario, devuelve `false`. 

{{% alert color="primary" title="Ver también" %}} 
- [Firma digital en PowerPoint](/slides/es/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de cifrado admite Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para sus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, alertándole de que se niega el acceso a la presentación. Esto ayuda a prevenir el acceso no autorizado y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta significativamente el tiempo total de procesamiento de sus tareas de presentación.