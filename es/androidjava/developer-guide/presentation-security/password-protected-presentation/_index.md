---
title: Presentación Protegida por Contraseña
type: docs
weight: 20
url: /es/androidjava/password-protected-presentation/
keywords: "Bloquear presentación de PowerPoint en Java"
description: "Bloquear presentación de PowerPoint. Presentación de PowerPoint protegida por contraseña en Java"
---

## **Acerca de la Protección por Contraseña**
### **¿Cómo funciona la protección por contraseña para presentaciones?**
Cuando proteges una presentación con contraseña, significa que estableces una contraseña que aplica ciertas restricciones a la presentación. Para eliminar las restricciones, se debe ingresar la contraseña. Una presentación protegida por contraseña se considera una presentación bloqueada.

Típicamente, puedes establecer una contraseña para hacer cumplir estas restricciones en una presentación:

- **Modificación**

  Si solo deseas que ciertos usuarios modifiquen tu presentación, puedes establecer una restricción de modificación. La restricción aquí evita que las personas modifiquen, cambien o copien cosas en tu presentación (a menos que proporcionen la contraseña).

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a tu documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o las cosas—hiperenlaces, animaciones, efectos, entre otros—dentro de tu presentación, pero no pueden copiar elementos ni guardar la presentación.

- **Apertura**

  Si solo deseas que ciertos usuarios abran tu presentación, puedes establecer una restricción de apertura. La restricción aquí evita que las personas incluso vean el contenido de tu presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen tus presentaciones: cuando las personas no pueden abrir una presentación, no pueden modificarla ni hacerle cambios.

  **Nota** que cuando proteges una presentación con contraseña para evitar su apertura, el archivo de la presentación se encripta.

## **Cómo Proteger una Presentación con Contraseña en Línea**

1. Ve a nuestra página de [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Haz clic en **Suelta o sube tus archivos**.

3. Selecciona el archivo que deseas proteger con contraseña en tu computadora.

4. Ingresa tu contraseña preferida para protección de modificación; Ingresa tu contraseña preferida para protección de visualización.

5. Si deseas que los usuarios vean tu presentación como la copia final, marca la casilla **Marcar como final**.

6. Haz clic en **PROTEGER AHORA.**

7. Haz clic en **DESCARGAR AHORA.**

## **Protección por Contraseña para Presentaciones en Aspose.Slides**
**Formatos soportados**

Aspose.Slides soporta la protección por contraseña, encriptación y operaciones similares para presentaciones en estos formatos:

- PPTX y PPT - Presentación de Microsoft PowerPoint
- ODP - Presentación de OpenDocument
- OTP - Plantilla de Presentación de OpenDocument

**Operaciones soportadas**

Aspose.Slides te permite usar la protección por contraseña en presentaciones para prevenir modificaciones de estas maneras:

- Encriptando una presentación
- Estableciendo una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides te permite realizar otras tareas relacionadas con la protección por contraseña y encriptación de estas maneras:

- Desencriptando una presentación; abriendo una presentación encriptada
- Eliminando la encriptación; deshabilitando la protección por contraseña
- Eliminando la protección de escritura de una presentación
- Obteniendo las propiedades de una presentación encriptada
- Verificando si una presentación está encriptada
- Verificando si una presentación está protegida por contraseña.

## **Encriptando una Presentación**

Puedes encriptar una presentación estableciendo una contraseña. Luego, para modificar la presentación bloqueada, un usuario debe proporcionar la contraseña.

Para encriptar o proteger con contraseña una presentación, debes usar el método encrypt (de [IProtectionManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager)) para establecer una contraseña para la presentación. Pasas la contraseña al método encrypt y usas el método save para guardar la presentación ahora encriptada.

Este código de ejemplo te muestra cómo encriptar una presentación:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Estableciendo Protección de Escritura en una Presentación**

Puedes agregar una marca que diga "No modificar" a una presentación. De esta manera, le indicas a los usuarios que no deseas que hagan cambios en la presentación.

**Nota** que el proceso de protección de escritura no encripta la presentación. Por lo tanto, los usuarios—si realmente lo desean—pueden modificar la presentación, pero para guardar los cambios, deberán crear una presentación con un nombre diferente.

Para establecer una protección de escritura, debes usar el método [setWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-). Este código de ejemplo te muestra cómo establecer una protección de escritura en una presentación:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Desencriptando una Presentación; Abriendo una Presentación Encriptada**

Aspose.Slides te permite cargar un archivo encriptado pasando su contraseña. Para desencriptar una presentación, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) sin parámetros. Luego tendrás que ingresar la contraseña correcta para cargar la presentación.

Este código de ejemplo te muestra cómo desencriptar una presentación:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // trabajar con la presentación desencriptada
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Eliminando la Encriptación; Deshabilitando la Protección por Contraseña**

Puedes eliminar la encriptación o la protección por contraseña en una presentación. De esta manera, los usuarios pueden acceder o modificar la presentación sin restricciones.

Para eliminar la encriptación o la protección por contraseña, debes llamar al método [removeEncryption](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Este código de ejemplo te muestra cómo eliminar la encriptación de una presentación:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eliminando la Protección de Escritura de una Presentación**

Puedes usar Aspose.Slides para eliminar la protección de escritura aplicada a un archivo de presentación. De esta manera, los usuarios pueden modificar a su gusto—y no reciben advertencias cuando realizan tales tareas.

Puedes eliminar la protección de escritura de una presentación utilizando el método [removeWriteProtection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Este código de ejemplo te muestra cómo eliminar la protección de escritura de una presentación:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obteniendo las Propiedades de una Presentación Encriptada**

Típicamente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación encriptada o protegida por contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que te permite proteger una presentación con contraseña mientras retienes los medios para que los usuarios accedan a las propiedades de esa presentación.

**Nota** que cuando Aspose.Slides encripta una presentación, las propiedades del documento de la presentación también se protegen por contraseña por defecto. Pero si necesitas hacer las propiedades de la presentación accesibles (incluso después de que la presentación sea encriptada), Aspose.Slides te permite hacer precisamente eso.

Si deseas que los usuarios conserven la capacidad de acceder a las propiedades de una presentación que encriptaste, puedes establecer la propiedad [encryptDocumentProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) en `true`. Este código de ejemplo te muestra cómo encriptar una presentación mientras proporcionas los medios para que los usuarios accedan a sus propiedades del documento:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verificando si una Presentación está Protegida por Contraseña Antes de Cargarla**

Antes de cargar una presentación, es posible que desees verificar y confirmar que la presentación no ha sido protegida con contraseña. De esta manera, evitas errores y problemas similares que surgen cuando se carga una presentación protegida por contraseña sin su contraseña.

Este código Java te muestra cómo examinar una presentación para ver si está protegida por contraseña (sin cargar la presentación en sí):

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("La presentación está protegida por contraseña: " + presentationInfo.isPasswordProtected());
```

## **Verificando si una Presentación está Encriptada**

Aspose.Slides te permite verificar si una presentación está encriptada. Para realizar esta tarea, puedes usar la propiedad [isEncrypted](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , que devuelve `true` si la presentación está encriptada o `false` si la presentación no está encriptada.

Este código de ejemplo te muestra cómo verificar si una presentación está encriptada:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Verificando si una Presentación está Protegida contra Escritura**

Aspose.Slides te permite verificar si una presentación está protegida contra escritura. Para realizar esta tarea, puedes usar la propiedad [isWriteProtected](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , que devuelve `true` si la presentación está encriptada o `false` si la presentación no está encriptada.

Este código de ejemplo te muestra cómo verificar si una presentación está protegida contra escritura:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validando o Confirmando que una Contraseña Específica ha Sido Usada para Proteger una Presentación**

Es posible que desees verificar y confirmar que una contraseña específica ha sido utilizada para proteger un documento de presentación. Aspose.Slides proporciona los medios para que valides una contraseña.

Este código de ejemplo te muestra cómo validar una contraseña:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // verificar si "pass" coincide con
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Devuelve `true` si la presentación ha sido encriptada con la contraseña especificada. De lo contrario, devuelve `false`.

{{% alert color="primary" title="Ver también" %}} 
- [Firma Digital en PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}