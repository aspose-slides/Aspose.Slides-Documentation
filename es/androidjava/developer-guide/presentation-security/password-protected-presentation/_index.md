---
title: Presentaciones seguras con contraseñas en Android
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/androidjava/password-protected-presentation/
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
- seguridad de la presentación
- eliminar contraseña
- eliminar protección
- eliminar cifrado
- desactivar contraseña
- desactivar protección
- eliminar protección de escritura
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Bloquee y desbloquee sin esfuerzo presentaciones de PowerPoint y OpenDocument protegidas con contraseña con Aspose.Slides para Android mediante Java. Proteja sus presentaciones."
---
## **Introducción**

Cuando protege con contraseña una presentación, significa que está estableciendo una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar las restricciones, hay que introducir la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puede establecer una contraseña para imponer estas restricciones en una presentación:

- **Modificación**

  Si desea que sólo ciertos usuarios modifiquen su presentación, puede establecer una restricción de modificación. La restricción aquí impide que las personas modifiquen, cambien o copien elementos de su presentación (a menos que proporcionen la contraseña). 

  Sin embargo, en este caso, incluso sin la contraseña, un usuario podrá acceder a su documento y abrirlo. En este modo de solo lectura, el usuario puede ver el contenido o elementos —hipervínculos, animaciones, efectos y otros— dentro de su presentación, pero no puede copiar elementos ni guardar la presentación. 

- **Apertura**

  Si desea que sólo ciertos usuarios abran su presentación, puede establecer una restricción de apertura. La restricción aquí impide que las personas incluso vean el contenido de su presentación (a menos que proporcionen la contraseña).

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen sus presentaciones: cuando la gente no puede abrir una presentación, no puede modificarla ni realizar cambios en ella. 
  
  **Nota** que cuando protege con contraseña una presentación para impedir su apertura, el archivo de la presentación se cifra.

## **Protección con contraseña de presentaciones en Aspose.Slides**
**Formatos admitidos**

Aspose.Slides admite la protección con contraseña, el cifrado y operaciones similares para presentaciones en los siguientes formatos: 

- PPTX y PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Operaciones admitidas**

Aspose.Slides le permite usar la protección con contraseña en presentaciones para impedir modificaciones de las siguientes maneras:

- Cifrar una presentación
- Establecer una protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides le permite realizar otras tareas relacionadas con la protección con contraseña y el cifrado de las siguientes maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña.

## **Cifrar una presentación**

Puede cifrar una presentación estableciendo una contraseña. Entonces, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña. 

Para cifrar o proteger con contraseña una presentación, debe utilizar el método encrypt (de [IProtectionManager](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IProtectionManager)) para establecer una contraseña para la presentación. Pasa la contraseña al método encrypt y usa el método save para guardar la presentación ahora cifrada.

Este fragmento de código muestra cómo cifrar una presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Establecer protección de escritura en una presentación**

Puede añadir una marca que indique "No modificar" a una presentación. De este modo, indica a los usuarios que no desea que realicen cambios en la presentación.  

**Nota** que el proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios —si realmente lo desean— pueden modificar la presentación, pero para guardar los cambios tendrán que crear una presentación con un nombre diferente. 

Para establecer una protección de escritura, debe utilizar el método [setWriteProtection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) . Este fragmento de código muestra cómo establecer una protección de escritura en una presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Cargar una presentación cifrada**

Aspose.Slides le permite cargar una presentación cifrada pasando la contraseña correcta a través de [LoadOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/).

Este fragmento de código muestra cómo abrir una presentación cifrada: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // trabajar con la presentación descifrada
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Eliminar el cifrado de una presentación**

Puede eliminar el cifrado o la protección con contraseña de una presentación. De este modo, los usuarios pueden acceder o modificar la presentación sin restricciones. 

Para eliminar el cifrado o la protección con contraseña, debe llamar al método [removeEncryption](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) . Este fragmento de código muestra cómo eliminar el cifrado de una presentación:

```java
import com.aspose.slides.*;

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

## **Eliminar la protección de escritura de una presentación**

Puede usar Aspose.Slides para eliminar la protección de escritura de un archivo de presentación. De este modo, los usuarios pueden modificar a su gusto —y no reciben advertencias al realizar esas tareas.

Puede eliminar la protección de escritura de una presentación utilizando el método [removeWriteProtection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) . Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Obtener propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación cifrada o protegida con contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que permite proteger una presentación con contraseña y, al mismo tiempo, mantener la capacidad de los usuarios para acceder a sus propiedades.

**Nota:** Por defecto, cuando Aspose.Slides cifra una presentación, las propiedades del documento de la presentación también quedan protegidas con contraseña. Si necesita que las propiedades del documento sean accesibles incluso después del cifrado, Aspose.Slides le permite hacer precisamente eso.

Si desea que los usuarios mantengan la capacidad de acceder a las propiedades de una presentación cifrada, pase `false` a [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-). Este fragmento de código muestra cómo cifrar una presentación mientras sigue proporcionando a los usuarios acceso a sus propiedades del documento:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Cargar solo las propiedades del documento de una presentación cifrada**

Para inspeccionar los metadatos de una presentación cifrada sin cargar sus diapositivas u otro contenido, cree un objeto [LoadOptions](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/) y pase `true` a [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-). En este modo, Aspose.Slides ignora la contraseña y carga solo las propiedades del documento que son accesibles públicamente.

El siguiente ejemplo de código lee las propiedades del documento incorporadas y personalizadas a través de [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getDocumentProperties--):

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // Leer las propiedades de documento incorporadas.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // Leer las propiedades de documento personalizadas.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

Este flujo de trabajo funciona solo cuando las propiedades del documento se dejaron sin cifrar (públicas) al cifrar la presentación. Si las propiedades del documento están cifradas, pasar `true` a `loadOptions.setOnlyLoadDocumentProperties` provoca una excepción porque la contraseña se ignora en este modo. Para acceder a las propiedades del documento cifradas o cargar la presentación completa, incluidas sus diapositivas y demás contenido, proporcione la contraseña correcta mediante [ILoadOptions.setPassword](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-).

## **Comprobar si una presentación está protegida con contraseña**

Antes de cargar una presentación, puede que desee comprobar y confirmar que la presentación no está protegida con una contraseña. De este modo, evita errores y problemas similares que surgen cuando se carga una presentación protegida con contraseña sin proporcionar la contraseña.

Este código Java muestra cómo examinar una presentación para ver si está protegida con contraseña (sin cargar la propia presentación):

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **Comprobar si una presentación está cifrada**

Aspose.Slides le permite comprobar si una presentación está cifrada. Para realizar esta tarea, puede usar la propiedad [isEncrypted](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) , que devuelve `true` si la presentación está cifrada o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está cifrada:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides le permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puede usar la propiedad [isWriteProtected](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) , que devuelve `true` si la presentación está protegida contra escritura o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está protegida contra escritura:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validar o confirmar que se ha utilizado una contraseña específica**

Puede que desee comprobar y confirmar que se ha utilizado una contraseña específica para proteger un documento de presentación. Aspose.Slides ofrece los medios para validar una contraseña. 

Este fragmento de código muestra cómo validar una contraseña:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // comprobar si "pass" coincide
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

Devuelve `true` si la presentación ha sido protegida contra escritura con la contraseña especificada. En caso contrario, devuelve `false`. 

{{% alert color="info" title="Ver también" %}} 
- [Digital Signature in PowerPoint](/slides/es/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**¿Qué métodos de cifrado son compatibles con Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para sus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, avisándole de que el acceso a la presentación está denegado. Esto ayuda a prevenir el acceso no autorizado y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta de forma significativa al tiempo total de procesamiento de sus tareas con presentaciones.