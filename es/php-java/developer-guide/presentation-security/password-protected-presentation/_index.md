---
title: Presentaciones seguras con contraseñas en PHP
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/php-java/password-protected-presentation/
keywords:
- bloquear PowerPoint
- bloquear presentación
- desbloquear PowerPoint
- desbloquear presentación
- proteger PowerPoint
- proteger presentación
- establecer contraseña
- añadir contraseña
- encriptar PowerPoint
- encriptar presentación
- desencriptar PowerPoint
- desencriptar presentación
- protección de escritura
- seguridad PowerPoint
- seguridad de la presentación
- eliminar contraseña
- eliminar protección
- eliminar encriptación
- desactivar contraseña
- desactivar protección
- eliminar protección de escritura
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprende a bloquear y desbloquear fácilmente presentaciones de PowerPoint y OpenDocument protegidas con contraseña usando Aspose.Slides para PHP. Protege tus presentaciones."
---
## **Introducción**

Cuando proteges una presentación con contraseña, estableces una clave que impone ciertas restricciones sobre la presentación. Para eliminar esas restricciones, debe introducirse la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puedes establecer una contraseña para imponer estas restricciones sobre una presentación:

- **Modificación**

  Si deseas que solo ciertos usuarios puedan modificar tu presentación, puedes establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En modo solo lectura, el usuario puede ver el contenido o los elementos —hipervínculos, animaciones, efectos y otros— dentro de la presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si deseas que solo ciertos usuarios puedan abrir tu presentación, puedes establecer una restricción de apertura. Esta restricción impide que las personas vean siquiera el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni hacer cambios en ella.  
  
  **Nota** que cuando proteges una presentación con contraseña para impedir su apertura, el archivo de la presentación se encripta.

## **Cómo proteger una presentación con contraseña en línea**

1. Ve a nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/es/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Drop or upload your files**.

3. Selecciona el archivo que deseas proteger con contraseña en tu ordenador.

4. Introduce la contraseña que prefieras para la protección de edición; introduce la contraseña que prefieras para la protección de visualización.

5. Si deseas que los usuarios vean tu presentación como la copia final, marca la casilla **Mark as final**.

6. Haz clic en **PROTECT NOW.**

7. Haz clic en **DOWNLOAD NOW.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite protección con contraseña, encriptación y operaciones similares para presentaciones en estos formatos:

- PPTX y PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**Operaciones compatibles**

Aspose.Slides te permite usar la protección con contraseña en presentaciones para impedir modificaciones de las siguientes maneras:

- Encriptar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides te permite realizar otras tareas relacionadas con la protección con contraseña y la encriptación de estas formas:

- Desencriptar una presentación; abrir una presentación encriptada
- Eliminar la encriptación; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación encriptada
- Comprobar si una presentación está encriptada
- Comprobar si una presentación está protegida con contraseña.

## **Encriptar una presentación**

Puedes encriptar una presentación estableciendo una contraseña. Después, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña.

Para encriptar o proteger con contraseña una presentación, debes usar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y utilizas el método save para guardar la presentación ahora encriptada.

Este fragmento de código muestra cómo encriptar una presentación:

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

## **Establecer protección de escritura en una presentación**

Puedes añadir una marca que indique “No modificar” a una presentación. De este modo, indicas a los usuarios que no deseas que realicen cambios en la presentación.

**Nota** que el proceso de protección de escritura no encripta la presentación. Por lo tanto, los usuarios —si realmente lo desean— pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debes usar el método [setWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#setWriteProtection). Este fragmento de código muestra cómo establecer una protección de escritura en una presentación:

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

## **Cargar una presentación encriptada**

Aspose.Slides permite cargar un archivo encriptado proporcionando su contraseña. Para desencriptar una presentación, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#removeEncryption) sin parámetros. A continuación, deberás introducir la contraseña correcta para cargar la presentación.

Este fragmento de código muestra cómo desencriptar una presentación:

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("123123");
  $presentation = new Presentation("pres.pptx", $loadOptions);
  try {
    # trabajar con la presentación desencriptada
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Eliminar la encriptación de una presentación**

Puedes eliminar la encriptación o la protección con contraseña de una presentación. De este modo, los usuarios pueden acceder o modificar la presentación sin restricciones.

Para eliminar la encriptación o la protección con contraseña, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#removeEncryption). Este fragmento de código muestra cómo eliminar la encriptación de una presentación:

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

## **Eliminar la protección de escritura de una presentación**

Puedes usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De este modo, los usuarios pueden modificar a su gusto y no reciben advertencias al realizar esas tareas.

Puedes eliminar la protección de escritura de una presentación usando el método [removeWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#removeWriteProtection). Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:

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

## **Obtener propiedades de una presentación encriptada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación encriptada o protegida con contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que permite proteger una presentación con contraseña manteniendo la capacidad de los usuarios para acceder a sus propiedades.

**Nota:** Por defecto, cuando Aspose.Slides encripta una presentación, las propiedades del documento de la presentación también están protegidas con contraseña. Si necesitas que las propiedades del documento sean accesibles incluso después de la encriptación, Aspose.Slides te permite hacerlo exactamente.

Si deseas que los usuarios conserven la capacidad de acceder a las propiedades de una presentación encriptada, pasa `false` a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties). Este fragmento de código muestra cómo encriptar una presentación mientras sigues proporcionando a los usuarios acceso a sus propiedades del documento:

```php
  $presentation = new Presentation("pres.pptx");
  try {
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("123123");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Cargar solo propiedades del documento de una presentación encriptada**

Para inspeccionar los metadatos de una presentación encriptada sin cargar sus diapositivas u otro contenido, crea un objeto [LoadOptions](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/) y pasa `true` a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties). En este modo, Aspose.Slides ignora la contraseña y carga solo las propiedades del documento que son públicamente accesibles.

El siguiente ejemplo de código lee propiedades del documento incorporadas y personalizadas mediante [Presentation::getDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#getDocumentProperties):

```php
$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();

    # Leer propiedades incorporadas del documento.
    echo("Title: " . $documentProperties->getTitle() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");

    # Leer propiedades personalizadas del documento.
    $customPropertyCount = java_values($documentProperties->getCountOfCustomProperties());

    for ($propertyIndex = 0; $propertyIndex < $customPropertyCount; $propertyIndex++) {
        $propertyName = $documentProperties->getCustomPropertyName($propertyIndex);
        $propertyValue = java_values($documentProperties->get_Item($propertyName));

        echo($propertyName . ": " . $propertyValue . "\n");
    }
} finally {
    $presentation->dispose();
}
```

Este flujo de trabajo funciona solo cuando las propiedades del documento quedaron sin encriptar (públicas) al encriptarse la presentación. Si las propiedades del documento están encriptadas, pasar `true` a [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) provoca una excepción porque la contraseña se ignora en este modo. Para acceder a propiedades del documento encriptadas o cargar la presentación completa, incluidas sus diapositivas y otro contenido, proporciona la contraseña correcta mediante [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword).

## **Comprobar si una presentación está protegida con contraseña**

Antes de cargar una presentación, puede que desees comprobar y confirmar que la presentación no está protegida con una contraseña. De este modo, evitas errores y problemas similares que aparecen cuando se carga una presentación protegida con contraseña sin proporcionar la contraseña.

Este código PHP muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):

```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```

## **Comprobar si una presentación está encriptada**

Aspose.Slides permite comprobar si una presentación está encriptada. Para realizar esta tarea, puedes usar el método [isEncrypted](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#isEncrypted), que devuelve `true` si la presentación está encriptada o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está encriptada:

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

## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar el método [isWriteProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#isWriteProtected), que devuelve `true` si la presentación está protegida contra escritura o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está protegida contra escritura:

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

## **Validar o confirmar que se ha usado una contraseña específica**

Puede que quieras comprobar y confirmar que se ha utilizado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña.

Este fragmento de código muestra cómo validar una contraseña:

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

Devuelve `true` si la presentación ha sido encriptada con la contraseña especificada. En caso contrario, devuelve `false`.

{{% alert color="primary" title="Ver también" %}} 
- [Digital Signature in PowerPoint](/slides/es/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de encriptación admite Aspose.Slides?**

Aspose.Slides admite métodos de encriptación modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para tus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se utiliza una contraseña incorrecta, indicando que el acceso a la presentación ha sido denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de encriptación y desencriptación puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta de manera significativa al tiempo total de procesamiento de tus tareas de presentación.