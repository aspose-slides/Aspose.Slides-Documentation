---
title: Presentación Protegida por Contraseña
type: docs
weight: 20
url: /es/php-java/password-protected-presentation/
keywords: "Bloquear presentación de PowerPoint"
description: "Bloquear presentación de PowerPoint. Presentación de PowerPoint protegida por contraseña"
---

## **Acerca de la Protección por Contraseña**
### **¿Cómo funciona la protección por contraseña para la presentación?**
Cuando proteges por contraseña una presentación, significa que estás configurando una contraseña que impone ciertas restricciones en la presentación. Para eliminar las restricciones, se debe ingresar la contraseña. Una presentación protegida por contraseña se considera una presentación bloqueada.

Normalmente, puedes establecer una contraseña para imponer estas restricciones en una presentación:

- **Modificación**

  Si deseas que solo ciertos usuarios modifiquen tu presentación, puedes establecer una restricción de modificación. La restricción aquí impide que las personas modifiquen, cambien o copien cosas en tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En este modo de solo lectura, el usuario puede ver los contenidos o elementos—hipervínculos, animaciones, efectos y otros—dentro de tu presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si deseas que solo ciertos usuarios abran tu presentación, puedes establecer una restricción de apertura. La restricción aquí impide que las personas incluso vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: Cuando las personas no pueden abrir una presentación, no pueden modificar o hacer cambios en ella.

  **Nota** que cuando proteges por contraseña una presentación para prevenir la apertura, el archivo de presentación se convierte en un archivo cifrado.

## **Cómo Proteger por Contraseña una Presentación en Línea**

1. Ve a nuestra página de [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Suelta o sube tus archivos**.

3. Selecciona el archivo que deseas proteger con contraseña en tu computadora.

4. Ingresa tu contraseña preferida para la protección de edición; Ingresa tu contraseña preferida para la protección de visualización.

5. Si deseas que los usuarios vean tu presentación como la copia final, marca la casilla **Marcar como final**.

6. Haz clic en **PROTEGER AHORA.**

7. Haz clic en **DESCARGAR AHORA.**

## **Protección por Contraseña para Presentaciones en Aspose.Slides**
**Formatos soportados**

Aspose.Slides soporta la protección por contraseña, cifrado y operaciones similares para presentaciones en estos formatos:

- PPTX y PPT - Presentación de Microsoft PowerPoint
- ODP - Presentación de OpenDocument
- OTP - Plantilla de Presentación de OpenDocument

**Operaciones soportadas**

Aspose.Slides te permite utilizar la protección por contraseña en presentaciones para prevenir modificaciones de estas maneras:

- Cifrando una presentación
- Estableciendo una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides te permite realizar otras tareas que involucran protección por contraseña y cifrado de estas maneras:

- Descifrando una presentación; abriendo una presentación cifrada
- Eliminando el cifrado; deshabilitando la protección por contraseña
- Eliminando la protección de escritura de una presentación
- Obteniendo las propiedades de una presentación cifrada
- Comprobando si una presentación está cifrada
- Comprobando si una presentación está protegida por contraseña.

## **Cifrando una Presentación**

Puedes cifrar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, un usuario tiene que proporcionar la contraseña.

Para cifrar o proteger con contraseña una presentación, debes usar el método encrypt (de [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y usas el método save para guardar la presentación ahora cifrada.

Este código de muestra te muestra cómo cifrar una presentación:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Estableciendo Protección de Escritura en una Presentación**

Puedes agregar una marca que diga “No modificar” a una presentación. De esta manera, le indicas a los usuarios que no deseas que hagan cambios en la presentación.

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios—si realmente lo desean—pueden modificar la presentación, pero para guardar los cambios, tendrán que crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debes usar el método [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Este código de muestra te muestra cómo establecer una protección de escritura en una presentación:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setWriteProtection("123123");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Descifrando una Presentación; Abriendo una Presentación Cifrada**

Aspose.Slides te permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) sin parámetros. Luego deberás ingresar la contraseña correcta para cargar la presentación.

Este código de muestra te muestra cómo descifrar una presentación:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # trabajar con la presentación descifrada
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Eliminando el Cifrado; Deshabilitando la Protección por Contraseña**

Puedes eliminar el cifrado o la protección por contraseña en una presentación. De esta manera, los usuarios pueden acceder o modificar la presentación sin restricciones.

Para eliminar el cifrado o la protección por contraseña, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--). Este código de muestra te muestra cómo eliminar el cifrado de una presentación:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Eliminando la Protección de Escritura de una Presentación**

Puedes usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De esta manera, los usuarios pueden modificar como deseen—y no reciben advertencias cuando realizan tales tareas.

Puedes eliminar la protección de escritura de una presentación utilizando el método [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--). Este código de muestra te muestra cómo eliminar la protección de escritura de una presentación:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Obteniendo las Propiedades de una Presentación Cifrada**

Normalmente, los usuarios luchan por obtener las propiedades del documento de una presentación cifrada o protegida por contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que permite proteger por contraseña una presentación mientras se retienen los medios para que los usuarios accedan a las propiedades de esa presentación.

**Nota** que cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también se protegen por contraseña por defecto. Pero si necesitas que las propiedades de la presentación sean accesibles (incluso después de que la presentación esté cifrada), Aspose.Slides te permite hacer precisamente eso.

Si deseas que los usuarios mantengan la capacidad de acceder a las propiedades de una presentación que cifraste, puedes establecer la propiedad [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) en `true`. Este código de muestra te muestra cómo cifrar una presentación mientras proporcionas los medios para que los usuarios accedan a sus propiedades del documento:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(true);
    $presentation->getProtectionManager()->encrypt("123123");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Comprobando si una Presentación está Protegida por Contraseña Antes de Cargarla**

Antes de cargar una presentación, es posible que desees verificar y confirmar que la presentación no ha sido protegida con una contraseña. De esta manera, puedes evitar errores y problemas similares que surgen cuando se carga una presentación protegida por contraseña sin su contraseña.

Este código PHP te muestra cómo examinar una presentación para ver si está protegida por contraseña (sin cargar la presentación en sí):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("La presentación está protegida por contraseña: " . $presentationInfo->isPasswordProtected());
```

## **Comprobando si una Presentación está Cifrada**

Aspose.Slides te permite comprobar si una presentación está cifrada. Para realizar esta tarea, puedes utilizar la propiedad [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--), que devuelve `true` si la presentación está cifrada o `false` si la presentación no está cifrada.

Este código de muestra te muestra cómo comprobar si una presentación está cifrada:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Comprobando si una Presentación está Protegida contra Escritura**

Aspose.Slides te permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes utilizar la propiedad [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--), que devuelve `true` si la presentación está cifrada o `false` si la presentación no está cifrada.

Este código de muestra te muestra cómo comprobar si una presentación está protegida contra escritura:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isWriteProtected();
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Validando o Confirmando que se ha Usado una Contraseña Específica para Proteger una Presentación**

Es posible que desees verificar y confirmar que se ha utilizado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña.

Este código de muestra te muestra cómo validar una contraseña:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    # comprobar si "pass" coincide con
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada. De lo contrario, devuelve `false`.

{{% alert color="primary" title="Ver también" %}} 
- [Firma Digital en PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}