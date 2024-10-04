---
title: Presentación Protegida por Contraseña
type: docs
weight: 20
url: /cpp/password-protected-presentation/
keywords: "Bloquear presentación de PowerPoint"
description: "Bloquear presentación de PowerPoint. Presentación de PowerPoint protegida por contraseña con Aspose.Slides."
---

## **Acerca de la Protección por Contraseña**
### **¿Cómo funciona la protección por contraseña para presentaciones?**
Cuando proteges por contraseña una presentación, significa que estás estableciendo una contraseña que impone ciertas restricciones en la presentación. Para eliminar las restricciones, se debe ingresar la contraseña. Una presentación protegida por contraseña se considera una presentación bloqueada.

Típicamente, puedes establecer una contraseña para imponer estas restricciones en una presentación:

- **Modificación**

  Si deseas que solo ciertos usuarios modifiquen tu presentación, puedes establecer una restricción de modificación. La restricción aquí impide que las personas modifiquen, cambien o copien cosas en tu presentación (a menos que proporcionen la contraseña). 

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o las cosas—hipertexto, animaciones, efectos y otros—dentro de tu presentación, pero no puede copiar elementos ni guardar la presentación. 

- **Apertura**

  Si deseas que solo ciertos usuarios abran tu presentación, puedes establecer una restricción de apertura. La restricción aquí impide que las personas incluso vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: Cuando las personas no pueden abrir una presentación, no pueden modificarla ni hacerle cambios. 
  
  **Nota** que cuando proteges por contraseña una presentación para prevenir su apertura, el archivo de presentación se convierte en un archivo encriptado.

## **Cómo Proteger por Contraseña una Presentación en Línea**

1. Ve a nuestra página de [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Arrastra o sube tus archivos**.

3. Selecciona el archivo que deseas proteger por contraseña en tu computadora. 

4. Ingresa tu contraseña preferida para la protección de edición; Ingresa tu contraseña preferida para la protección de vista. 

5. Si deseas que los usuarios vean tu presentación como la copia final, marca la casilla **Marcar como final**.

6. Haz clic en **PROTEGER AHORA.** 

7. Haz clic en **DESCARGAR AHORA.**

## **Protección por Contraseña para Presentaciones en Aspose.Slides**
**Formatos soportados**

Aspose.Slides soporta protección por contraseña, encriptación y operaciones similares para presentaciones en estos formatos: 

- PPTX y PPT - Presentación de Microsoft PowerPoint 
- ODP - Presentación de OpenDocument 
- OTP - Plantilla de Presentación de OpenDocument 

**Operaciones soportadas**

Aspose.Slides te permite usar la protección por contraseña en presentaciones para prevenir modificaciones de estas maneras:

- Encriptando una presentación
- Estableciendo una protección contra escritura en una presentación

**Otras operaciones**

Aspose.Slides te permite realizar otras tareas que involucran protección por contraseña y encriptación de estas maneras:

- Desencriptar una presentación; abrir una presentación encriptada
- Remover encriptación; deshabilitar la protección por contraseña
- Remover protección contra escritura de una presentación
- Obtener las propiedades de una presentación encriptada
- Verificar si una presentación está encriptada
- Verificar si una presentación está protegida por contraseña.

## **Encriptando una Presentación**

Puedes encriptar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, un usuario debe proporcionar la contraseña. 

Para encriptar o proteger por contraseña una presentación, debes usar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y utilizas el método save para guardar la presentación ahora encriptada. 

Este código de muestra te muestra cómo encriptar una presentación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Estableciendo Protección contra Escritura en una Presentación** 

Puedes agregar una marca que indique “No modificar” a una presentación. De esta manera, le informas a los usuarios que no deseas que realicen cambios en la presentación.  

**Nota** que el proceso de protección contra escritura no encripta la presentación. Por lo tanto, los usuarios—si realmente quieren—pueden modificar la presentación, pero para guardar los cambios, tendrán que crear una presentación con otro nombre. 

Para establecer una protección contra escritura, debes usar el método setWriteProtection. Este código de muestra te muestra cómo establecer una protección contra escritura en una presentación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Desencriptando una Presentación; Abriendo una Presentación Encriptada**

Aspose.Slides te permite cargar un archivo encriptado pasando su contraseña. Para desencriptar una presentación, debes llamar al método [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sin parámetros. Luego tendrás que ingresar la contraseña correcta para cargar la presentación. 

Este código de muestra te muestra cómo desencriptar una presentación: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// trabajar con la presentación desencriptada
```

## **Removiendo encriptación; Deshabilitando la Protección por Contraseña**

Puedes remover la encriptación o la protección por contraseña en una presentación. De esta manera, los usuarios pueden acceder o modificar la presentación sin restricciones. 

Para remover encriptación o protección por contraseña, debes llamar al método [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Este código de muestra te muestra cómo remover la encriptación de una presentación:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Removiendo Protección contra Escritura de una Presentación**

Puedes usar Aspose.Slides para remover la protección contra escritura utilizada en un archivo de presentación. De esta manera, los usuarios pueden modificar como deseen—y no reciben advertencias cuando realizan tales tareas.

Puedes remover la protección contra escritura de una presentación usando el método [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Este código de muestra te muestra cómo remover la protección contra escritura de una presentación:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Obteniendo las Propiedades de una Presentación Encriptada**

Típicamente, los usuarios luchan por obtener las propiedades del documento de una presentación encriptada o protegida por contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que te permite proteger por contraseña una presentación mientras mantienes los medios para que los usuarios accedan a las propiedades de esa presentación.

**Nota** que cuando Aspose.Slides encripta una presentación, las propiedades del documento de la presentación también quedan protegidas por contraseña por defecto. Pero si necesitas que las propiedades de la presentación sean accesibles (incluso después de que la presentación se haya encriptado), Aspose.Slides te permite hacer precisamente eso. 

Si deseas que los usuarios mantengan la capacidad de acceder a las propiedades de una presentación que encriptaste, puedes pasar `true` al método [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Este código de muestra te muestra cómo encriptar una presentación mientras proporcionas los medios para que los usuarios accedan a sus propiedades de documento:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Verificando si una Presentación Está Protegida por Contraseña Antes de Cargarla**

Antes de cargar una presentación, es posible que desees verificar y confirmar que la presentación no ha sido protegida con una contraseña. De esta manera, puedes evitar errores y problemas similares que surgen cuando se carga una presentación protegida por contraseña sin su contraseña.

Este código C++ te muestra cómo examinar una presentación para ver si está protegida por contraseña (sin cargar la presentación en sí):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"La presentación está protegida por contraseña: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Verificando si una Presentación Está Encriptada**

Aspose.Slides te permite verificar si una presentación está encriptada. Para realizar esta tarea, puedes usar el método [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), que devuelve `true` si la presentación está encriptada o `false` si la presentación no está encriptada. 

Este código de muestra te muestra cómo verificar si una presentación está encriptada:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Verificando si una Presentación Está Protegida contra Escritura**

Aspose.Slides te permite verificar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar el método [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), que devuelve `true` si la presentación está encriptada o `false` si la presentación no está encriptada. 

Este código de muestra te muestra cómo verificar si una presentación está protegida contra escritura:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Validando o Confirmando que se ha Usado una Contraseña Específica para Proteger una Presentación**

Es posible que desees verificar y confirmar que se ha usado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para que valides una contraseña. 

Este código de muestra te muestra cómo validar una contraseña:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// verifica si "pass" coincide con
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Devuelve `true` si la presentación ha sido encriptada con la contraseña especificada. De lo contrario, devuelve `false`. 

{{% alert color="primary" title="Ver también" %}} 
- [Firma Digital en PowerPoint](/slides/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}