---
title: Presentaciones seguras con contraseñas en JavaScript
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/nodejs-java/password-protected-presentation/
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
- seguridad PowerPoint
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Bloquear y desbloquear sin esfuerzo presentaciones de PowerPoint y OpenDocument protegidas con contraseña con Aspose.Slides para Node.js mediante Java. Protege tus presentaciones."
---
## **Introducción**

Cuando proteges una presentación con contraseña, estableces una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar las restricciones, es necesario introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puedes establecer una contraseña para aplicar estas restricciones a una presentación:

- **Modificación**

  Si deseas que solo determinados usuarios modifiquen tu presentación, puedes establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y demás— dentro de tu presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si deseas que solo determinados usuarios abran tu presentación, puedes establecer una restricción de apertura. Esta restricción impide que las personas incluso vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni realizar cambios en ella.  
  
  **Nota** que cuando proteges una presentación con contraseña para impedir la apertura, el archivo de la presentación queda cifrado.

## **Cómo proteger una presentación con contraseña en línea**

1. Ve a nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/es/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Drop or upload your files**.

3. Selecciona el archivo que deseas proteger con contraseña en tu computadora.

4. Introduce la contraseña que prefieras para la protección de edición; introduce la contraseña que prefieras para la protección de visualización.

5. Si deseas que los usuarios vean tu presentación como copia final, marca la casilla **Mark as final**.

6. Haz clic en **PROTECT NOW.**

7. Haz clic en **DOWNLOAD NOW.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite protección con contraseña, cifrado y operaciones similares para presentaciones en los siguientes formatos:

- PPTX y PPT - Microsoft PowerPoint Presentation
- ODP - OpenDocument Presentation
- OTP - OpenDocument Presentation Template

**Operaciones compatibles**

Aspose.Slides permite aplicar protección con contraseña a presentaciones para impedir modificaciones de las siguientes maneras:

- Cifrar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de las siguientes maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrado de una presentación**

Puedes cifrar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña.

Para cifrar o proteger con contraseña una presentación, debes usar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y utilizas el método save para guardar la presentación ahora cifrada.

Este fragmento de código muestra cómo cifrar una presentación:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Establecer protección de escritura en una presentación**

Puedes añadir una marca que indique “No modificar” a una presentación. De este modo, indicas a los usuarios que no deseas que realicen cambios en la presentación.

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios —si realmente lo desean— pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debes usar el método [setWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Este fragmento de código muestra cómo establecer una protección de escritura en una presentación:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Descifrar una presentación; abrir una presentación cifrada**

Aspose.Slides permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) sin parámetros. Entonces tendrás que introducir la contraseña correcta para cargar la presentación.

Este fragmento de código muestra cómo descifrar una presentación:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // trabajar con la presentación descifrada
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Eliminar el cifrado; desactivar la protección con contraseña**

Puedes eliminar el cifrado o la protección con contraseña de una presentación. De este modo, los usuarios pueden acceder o modificar la presentación sin restricciones.

Para eliminar el cifrado o la protección con contraseña, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Este fragmento de código muestra cómo eliminar el cifrado de una presentación:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Eliminar la protección de escritura de una presentación**

Puedes usar Aspose.Slides para eliminar la protección de escritura aplicada a un archivo de presentación. De este modo, los usuarios pueden modificar a su gusto y no recibirán advertencias al realizar dichas tareas.

Puedes eliminar la protección de escritura de una presentación mediante el método [removeWriteProtection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) . Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Obtener propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para recuperar las propiedades del documento de una presentación cifrada o protegida con contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que permite proteger una presentación con contraseña y, al mismo tiempo, conservar la posibilidad de que los usuarios accedan a sus propiedades.

**Nota:** Por defecto, cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también quedan protegidas con contraseña. Si necesitas que las propiedades del documento sean accesibles incluso después del cifrado, Aspose.Slides permite hacerlo.

Si deseas que los usuarios conserven la capacidad de acceder a las propiedades de una presentación cifrada, pasa `false` a `setEncryptDocumentProperties` en [ProtectionManager](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/protectionmanager/). Este fragmento de código muestra cómo cifrar una presentación manteniendo el acceso de los usuarios a sus propiedades de documento:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Cargar solo propiedades del documento desde una presentación cifrada**

Para inspeccionar los metadatos de una presentación cifrada sin cargar sus diapositivas ni otro contenido, crea un objeto [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/) y pasa `true` a `setOnlyLoadDocumentProperties`. En este modo, Aspose.Slides ignora la contraseña y carga únicamente las propiedades del documento que son accesibles públicamente.

El siguiente ejemplo de código lee propiedades de documento incorporadas y personalizadas mediante `getDocumentProperties` en [Presentation](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/):

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // Leer propiedades de documento incorporadas.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // Leer propiedades de documento personalizadas.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Este flujo de trabajo solo funciona cuando las propiedades del documento quedaron sin cifrar (públicas) al cifrar la presentación. Si las propiedades del documento están cifradas, pasar `true` a `LoadOptions.setOnlyLoadDocumentProperties` provoca una excepción porque la contraseña se ignora en este modo. Para acceder a propiedades de documento cifradas o cargar la presentación completa, incluidas sus diapositivas y demás contenido, proporciona la contraseña correcta a través de `LoadOptions.setPassword` en [LoadOptions](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/loadoptions/).

## **Comprobar si una presentación está protegida con contraseña antes de cargarla**

Antes de cargar una presentación, puede que desees comprobar y confirmar que la presentación no está protegida con una contraseña. De este modo, evitas errores y problemas similares que aparecen cuando se carga una presentación protegida sin su contraseña.

Este código JavaScript muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Comprobar si una presentación está cifrada**

Aspose.Slides permite comprobar si una presentación está cifrada. Para realizar esta tarea, puedes usar la propiedad [isEncrypted](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) , que devuelve `true` si la presentación está cifrada o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está cifrada:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar la propiedad [isWriteProtected](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) , que devuelve `true` si la presentación está cifrada o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está protegida contra escritura:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Validar o confirmar que se ha utilizado una contraseña específica para proteger una presentación**

Puede que necesites comprobar y confirmar que se ha utilizado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña.

Este fragmento de código muestra cómo validar una contraseña:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // comprobar si "pass" coincide con
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada. En caso contrario, devuelve `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de cifrado son compatibles con Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para tus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, indicando que el acceso a la presentación está denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta de manera significativa el tiempo total de procesamiento de tus tareas con presentaciones.