---
title: Presentación protegida con contraseña
type: docs
weight: 20
url: /es/nodejs-java/password-protected-presentation/
keywords: "Bloquear presentación PowerPoint en JavaScript"
description: "Bloquear presentación PowerPoint. PowerPoint protegido con contraseña en JavaScript"
---

## **Acerca de la protección con contraseña**
### **¿Cómo funciona la protección con contraseña para presentaciones?**
Cuando proteges una presentación con contraseña, estableces una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar las restricciones, se debe introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puedes establecer una contraseña para imponer estas restricciones en una presentación:

- **Modificación**

  Si deseas que solo ciertos usuarios puedan modificar tu presentación, puedes establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien contenido de tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y otros— dentro de tu presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si deseas que solo ciertos usuarios puedan abrir tu presentación, puedes establecer una restricción de apertura. Esta restricción impide que las personas vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: cuando la gente no puede abrir una presentación, no puede modificarla ni realizar cambios en ella.  

  **Nota** que cuando proteges una presentación con contraseña para impedir la apertura, el archivo de la presentación se cifra.

## **Cómo proteger una presentación con contraseña en línea**

1. Visita nuestra página [**Bloqueo de Aspose.Slides**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Drop or upload your files**.

3. Selecciona el archivo que deseas proteger con contraseña en tu computadora. 

4. Introduce la contraseña que prefieras para la protección de edición; Introduce la contraseña que prefieras para la protección de visualización. 

5. Si deseas que los usuarios vean tu presentación como la copia final, marca la casilla **Mark as final**.

6. Haz clic en **PROTECT NOW.** 

7. Haz clic en **DOWNLOAD NOW.**

## **Protección con contraseña para presentaciones en Aspose.Slides**
**Formatos compatibles**

Aspose.Slides admite protección con contraseña, cifrado y operaciones similares para presentaciones en los siguientes formatos: 

- PPTX y PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP - OpenDocument Presentation Template 

**Operaciones compatibles**

Aspose.Slides te permite usar protección con contraseña en presentaciones para impedir modificaciones de las siguientes maneras:

- Cifrar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides te permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de estas maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrar una presentación**

Puedes cifrar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña. 

Para cifrar o proteger con contraseña una presentación, debes usar el método encrypt (de [ProtectionManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y utilizas el método save para guardar la presentación ahora cifrada.

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

Puedes añadir una marca que indique “No modificar” a una presentación. De esta forma, indicas a los usuarios que no deseas que realicen cambios en la presentación.  

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios—si realmente quieren—pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente. 

Para establecer una protección de escritura, debes usar el método [setWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-). Este fragmento de código muestra cómo establecer protección de escritura en una presentación:
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

Aspose.Slides te permite cargar un archivo cifrado pasando su contraseña. Para descifrar una presentación, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) sin parámetros. Luego deberás introducir la contraseña correcta para cargar la presentación.

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

Puedes eliminar el cifrado o la protección con contraseña de una presentación. De esta forma, los usuarios pueden acceder o modificar la presentación sin restricciones. 

Para eliminar el cifrado o la protección con contraseña, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--). Este fragmento de código muestra cómo eliminar el cifrado de una presentación:
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

Puedes usar Aspose.Slides para eliminar la protección de escritura utilizada en un archivo de presentación. De esta forma, los usuarios pueden modificar a su antojo y no reciben advertencias al realizar esas operaciones.

Puedes eliminar la protección de escritura de una presentación usando el método [removeWriteProtection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--). Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:
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


## **Obtener las propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación cifrada o protegida con contraseña. Aspose.Slides, sin embargo, ofrece un mecanismo que permite proteger una presentación con contraseña manteniendo la posibilidad de que los usuarios accedan a sus propiedades.

**Nota** que cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también se protegen con contraseña por defecto. Pero si necesitas que las propiedades de la presentación sean accesibles (incluso después de que la presentación se haya cifrado), Aspose.Slides permite hacerlo. 

Si deseas que los usuarios mantengan la capacidad de acceder a las propiedades de una presentación que has cifrado, puedes establecer la propiedad [encryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#getEncryptDocumentProperties--) en `true`. Este fragmento de código muestra cómo cifrar una presentación mientras se brinda a los usuarios el acceso a sus propiedades del documento:
```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **Comprobar si una presentación está protegida con contraseña antes de cargarla**

Antes de cargar una presentación, puede que desees comprobar y confirmar que la presentación no está protegida con contraseña. Así evitas errores y problemas similares que aparecen cuando se carga una presentación protegida sin su contraseña.

Este código JavaScript muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):
```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```


## **Comprobar si una presentación está cifrada**

Aspose.Slides te permite comprobar si una presentación está cifrada. Para realizar esta tarea, puedes usar la propiedad [isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) que devuelve `true` si la presentación está cifrada o `false` si no lo está.

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

Aspose.Slides te permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar la propiedad [isWriteProtected](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) que devuelve `true` si la presentación está cifrada o `false` si no lo está.

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


## **Validar o confirmar que se ha usado una contraseña específica para proteger una presentación**

Puede que desees comprobar y confirmar que se ha usado una contraseña específica para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña. 

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


Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada. De lo contrario, devuelve `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Qué métodos de cifrado admite Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para tus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, indicando que el acceso a la presentación está denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto de rendimiento es mínimo y no afecta de manera significativa el tiempo total de procesamiento de tus tareas de presentación.