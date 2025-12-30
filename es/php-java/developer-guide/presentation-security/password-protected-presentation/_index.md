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
- cifrar PowerPoint
- cifrar presentación
- descifrar PowerPoint
- descifrar presentación
- protección contra escritura
- seguridad de PowerPoint
- seguridad de la presentación
- eliminar contraseña
- eliminar protección
- eliminar cifrado
- desactivar contraseña
- desactivar protección
- eliminar protección contra escritura
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda a bloquear y desbloquear fácilmente presentaciones de PowerPoint y OpenDocument protegidas con contraseña usando Aspose.Slides para PHP. Proteja sus presentaciones."
---

## **Acerca de la protección con contraseña**
### **¿Cómo funciona la protección con contraseña para una presentación?**
Cuando protege una presentación con contraseña, está estableciendo una contraseña que impone ciertas restricciones a la presentación. Para eliminar las restricciones, hay que introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puede establecer una contraseña para imponer estas restricciones a una presentación:

- **Modificación**

  Si desea que solo determinados usuarios modifiquen su presentación, puede establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de su presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, aunque no se introduzca la contraseña, un usuario podrá acceder a su documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y otros— dentro de su presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si desea que solo determinados usuarios abran su presentación, puede establecer una restricción de apertura. Esta restricción impide que las personas incluso vean el contenido de su presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen sus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni realizar cambios en ella.

  **Nota** que cuando protege una presentación con contraseña para impedir la apertura, el archivo de la presentación se cifra.

## **Cómo proteger una presentación con contraseña en línea**

1. Vaya a nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haga clic en **Suelte o cargue sus archivos**.

3. Seleccione el archivo que desea proteger con contraseña en su equipo.

4. Introduzca la contraseña que prefiera para la protección de edición; introduzca la contraseña que prefiera para la protección de visualización.

5. Si desea que los usuarios vean su presentación como la copia final, marque la casilla **Marcar como final**.

6. Haga clic en **PROTECT NOW**.

7. Haga clic en **DOWNLOAD NOW**.

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite la protección con contraseña, el cifrado y operaciones similares para presentaciones en estos formatos:

- PPTX y PPT - Presentación de Microsoft PowerPoint
- ODP - Presentación OpenDocument
- OTP - Plantilla de presentación OpenDocument

**Operaciones compatibles**

Aspose.Slides le permite usar la protección con contraseña en presentaciones para impedir modificaciones de estas maneras:

- Cifrar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides le permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de estas maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrar una presentación**

Puede cifrar una presentación estableciendo una contraseña. Entonces, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña.

Para cifrar o proteger con contraseña una presentación, debe usar el método encrypt (de [IProtectionManager](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager)) para establecer una contraseña para la presentación. Pasa la contraseña al método encrypt y usa el método save para guardar la presentación ahora cifrada.

Este fragmento de código muestra cómo cifrar una presentación:
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

Puede añadir una marca que indique “No modificar” a una presentación. De este modo, informa a los usuarios que no desea que realicen cambios en la presentación.

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios —si realmente lo desean— pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debe usar el método [setWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Este fragmento de código muestra cómo establecer una protección de escritura en una presentación:
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


## **Cargar una presentación cifrada**

Aspose.Slides le permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debe llamar al método [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--) sin parámetros. Luego tendrá que introducir la contraseña correcta para cargar la presentación.

Este fragmento de código muestra cómo descifrar una presentación:
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


## **Eliminar el cifrado de una presentación**

Puede eliminar el cifrado o la protección con contraseña de una presentación. De este modo, los usuarios pueden acceder o modificar la presentación sin restricciones.

Para eliminar el cifrado o la protección con contraseña, debe llamar al método [removeEncryption](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeEncryption--). Este fragmento de código muestra cómo eliminar el cifrado de una presentación:
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

Puede usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De este modo, los usuarios pueden modificarla a su gusto y no reciben advertencias al realizar esas tareas.

Puede eliminar la protección de escritura de una presentación mediante el método [removeWriteProtection](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#removeWriteProtection--) . Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:
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


## **Obtener las propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación cifrada o protegida con contraseña. Aspose.Slides, sin embargo, ofrece un mecanismo que le permite proteger una presentación con contraseña manteniendo la posibilidad de que los usuarios accedan a sus propiedades.

**Nota** que cuando Aspose.Slides cifra una presentación, también se protegen con contraseña por defecto las propiedades del documento de la presentación. Pero si necesita que las propiedades de la presentación estén accesibles (incluso después de que la presentación se haya cifrado), Aspose.Slides le permite hacerlo.

Si desea que los usuarios conserven la capacidad de acceder a las propiedades de una presentación que usted ha cifrado, puede establecer la propiedad [encryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#getEncryptDocumentProperties--) en `true`. Este fragmento de código muestra cómo cifrar una presentación proporcionando a los usuarios los medios para acceder a sus propiedades de documento:
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


## **Comprobar si una presentación está protegida con contraseña**

Antes de cargar una presentación, puede que desee comprobar y confirmar que la presentación no está protegida con contraseña. De este modo, evita errores y problemas similares que aparecen cuando se carga una presentación protegida sin su contraseña.

Este código PHP muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):
```php
  $presentationInfo = PresentationFactory->getInstance()->getPresentationInfo("example.pptx");
  echo("The presentation is password protected: " . $presentationInfo->isPasswordProtected());

```


## **Comprobar si una presentación está cifrada**

Aspose.Slides le permite comprobar si una presentación está cifrada. Para realizar esta tarea, puede usar la propiedad [isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isEncrypted--) , que devuelve `true` si la presentación está cifrada o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está cifrada:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
  finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides le permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puede usar la propiedad [isWriteProtected](https://reference.aspose.com/slides/php-java/aspose.slides/IProtectionManager#isWriteProtected--) , que devuelve `true` si la presentación está protegida contra escritura o `false` si no lo está.

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


## **Validar o confirmar que se ha utilizado una contraseña específica**

Puede que desee comprobar y confirmar que se ha utilizado una contraseña específica para proteger un documento de presentación. Aspose.Slides le proporciona los medios para validar una contraseña.

Este fragmento de código muestra cómo validar una contraseña:
```php
  $presentation = new Presentation("pres.pptx");
  try {
    # comprobar si "pass" coincide
    $isWriteProtected = $presentation->getProtectionManager()->checkWriteProtection("my_password");
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada. En caso contrario, devuelve `false`.

{{% alert color="primary" title="Ver también" %}} 
- [Firma digital en PowerPoint](/slides/es/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de cifrado admite Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para sus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, indicando que el acceso a la presentación está denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta significativamente el tiempo total de procesamiento de sus tareas de presentación.