---
title: Presentaciones seguras con contraseñas en .NET
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/net/password-protected-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda a bloquear y desbloquear sin esfuerzo presentaciones de PowerPoint y OpenDocument protegidas con contraseña utilizando Aspose.Slides para .NET. Proteja sus presentaciones."
---
## **Introducción**

Cuando protege una presentación con contraseña, está estableciendo una contraseña que impone ciertas restricciones sobre la presentación. Para eliminar esas restricciones, debe introducirse la contraseña. Una presentación protegida con contraseña se considera una presentación bloqueada.

Normalmente, puede establecer una contraseña para aplicar estas restricciones a una presentación:

- **Modificación**

  Si desea que solo ciertos usuarios puedan modificar su presentación, puede establecer una restricción de modificación. Esta restricción impide que las personas modifiquen, cambien o copien elementos de su presentación a menos que proporcionen la contraseña.

  Sin embargo, incluso sin la contraseña, un usuario podrá acceder y abrir su documento. En este modo de sólo lectura, el usuario puede ver el contenido—including hipervínculos, animaciones, efectos y otros elementos—dentro de su presentación, pero no puede copiar elementos ni guardar la presentación.

- **Apertura**

  Si desea que solo ciertos usuarios puedan abrir su presentación, puede establecer una restricción de apertura. Esta restricción impide que las personas incluso vean el contenido de su presentación a menos que proporcionen la contraseña.

  Técnicamente, la restricción de apertura también impide que los usuarios modifiquen sus presentaciones: si la gente no puede abrir una presentación, no puede modificarla ni realizar cambios en ella.

**Nota:** Cuando protege una presentación con contraseña para impedir su apertura, el archivo de la presentación se cifra.

## **Protección con contraseña en Aspose.Slides**

**Formatos admitidos**

Aspose.Slides admite la protección con contraseña, el cifrado y operaciones similares para presentaciones en los siguientes formatos:

- PPTX y PPT – Presentaciones de Microsoft PowerPoint
- ODP – Presentaciones OpenDocument
- OTP – Plantillas de presentación OpenDocument

**Operaciones admitidas**

Aspose.Slides le permite usar la protección con contraseña en presentaciones para impedir modificaciones de las siguientes maneras:

- Cifrar una presentación
- Establecer protección de escritura en una presentación

**Otras operaciones**

Aspose.Slides le permite realizar tareas adicionales relacionadas con la protección con contraseña y el cifrado de las siguientes maneras:

- Descifrar una presentación; abrir una presentación cifrada
- Eliminar el cifrado; desactivar la protección con contraseña
- Eliminar la protección de escritura de una presentación
- Obtener las propiedades de una presentación cifrada
- Comprobar si una presentación está protegida con contraseña antes de cargarla
- Comprobar si una presentación está cifrada
- Comprobar si una presentación está protegida con contraseña

## **Proteger una presentación con contraseña**

Puede cifrar una presentación estableciendo una contraseña. Entonces, para modificar la presentación bloqueada, el usuario debe proporcionar la contraseña.

Para cifrar (o proteger con contraseña) una presentación, utilice el método `Encrypt` de [ProtectionManager](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager) para establecer una contraseña. Pase la contraseña al método `Encrypt`, luego use el método `Save` para guardar la presentación ya cifrada.

Este fragmento de código muestra cómo cifrar una presentación:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Establecer protección de escritura en una presentación**

Puede añadir una marca que indique “No modificar” a una presentación. Esto informa a los usuarios de que no desea que realicen cambios en la presentación.

**Nota:** El proceso de protección de escritura no cifra la presentación. Por lo tanto, los usuarios—si lo desean—pueden modificar la presentación, pero para guardar los cambios tendrán que guardarla con otro nombre.

Para establecer la protección de escritura, utilice el método `SetWriteProtection`. Este fragmento de código muestra cómo establecer la protección de escritura en una presentación:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Cargar una presentación cifrada**

Aspose.Slides le permite cargar una presentación cifrada proporcionando la contraseña correcta. Este fragmento de código muestra cómo cargar una presentación cifrada:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Trabajar con la presentación descifrada.
}
```

## **Eliminar el cifrado de una presentación**

Puede eliminar el cifrado o la protección con contraseña de una presentación, permitiendo a los usuarios acceder o modificarla sin restricciones.

Para eliminar el cifrado o la protección con contraseña, llame al método [RemoveEncryption](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager/methods/removeencryption). Este fragmento de código muestra cómo eliminar el cifrado de una presentación:

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Eliminar la protección de escritura de una presentación**

Puede usar Aspose.Slides para eliminar la protección de escritura de un archivo de presentación. De este modo, los usuarios pueden modificarla como deseen—y no recibirán advertencias al realizar dichas tareas.

Puede eliminar la protección de escritura mediante el método [RemoveWriteProtection](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager/methods/removewriteprotection). Este fragmento de código muestra cómo eliminar la protección de escritura de una presentación:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Obtener propiedades de una presentación cifrada**

Normalmente, los usuarios tienen dificultades para obtener las propiedades del documento de una presentación cifrada o protegida con contraseña. Sin embargo, Aspose.Slides ofrece un mecanismo que permite proteger una presentación con contraseña y, al mismo tiempo, mantener la capacidad de los usuarios para acceder a sus propiedades.

**Nota:** Por defecto, cuando Aspose.Slides cifra una presentación, también se protegen con contraseña las propiedades del documento de la presentación. Si necesita que las propiedades del documento sean accesibles incluso después del cifrado, Aspose.Slides le permite hacerlo.

Si desea que los usuarios puedan seguir accediendo a las propiedades de una presentación cifrada, establezca la propiedad `EncryptDocumentProperties` de [IProtectionManager](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/) en `false`. Este fragmento de código muestra cómo cifrar una presentación y, al mismo tiempo, proporcionar a los usuarios acceso a sus propiedades de documento:

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Cargar solo las propiedades del documento de una presentación cifrada**

Para inspeccionar los metadatos de una presentación cifrada sin cargar sus diapositivas u otro contenido, cree un objeto [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/) y establezca [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) en `true`. En este modo, Aspose.Slides ignora la contraseña y carga solo las propiedades del documento que son de acceso público.

El siguiente ejemplo de código lee las propiedades de documento incorporadas y personalizadas a través de [IPresentation.DocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/documentproperties/):

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Este flujo de trabajo funciona solo cuando las propiedades del documento quedaron sin cifrar (públicas) al cifrar la presentación. Si las propiedades del documento están cifradas, establecer `OnlyLoadDocumentProperties` en `true` provoca una excepción porque la contraseña se ignora en este modo. Para acceder a propiedades de documento cifradas o cargar la presentación completa, incluidas sus diapositivas y demás contenido, proporcione el valor correcto de `Password` en [LoadOptions](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/).

## **Comprobar si una presentación está protegida con contraseña**

Antes de cargar una presentación, puede que desee comprobar que no está protegida con contraseña. Esto le ayuda a evitar errores y problemas similares que se producen cuando se carga una presentación protegida con contraseña sin la contraseña correcta.

Este código C# muestra cómo examinar una presentación para ver si está protegida con contraseña sin cargarla realmente:

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Comprobar si una presentación está cifrada**

Aspose.Slides le permite comprobar si una presentación está cifrada. Para realizar esta tarea, puede usar la propiedad [IsEncrypted](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager/properties/isencrypted), que devuelve `true` si la presentación está cifrada o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está cifrada:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Comprobar si una presentación está protegida contra escritura**

Aspose.Slides le permite comprobar si una presentación está protegida contra escritura. Para realizar esta tarea, puede usar la propiedad [IsWriteProtected](https://reference.aspose.com/slides/es/net/aspose.slides/protectionmanager/properties/iswriteprotected), que devuelve `true` si la presentación está protegida contra escritura o `false` si no lo está.

Este fragmento de código muestra cómo comprobar si una presentación está protegida contra escritura:

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Verificar el uso de la contraseña de la presentación**

Puede que desee comprobar y confirmar que una contraseña específica se ha utilizado para proteger un documento de presentación. Aspose.Slides proporciona los medios para validar una contraseña.

Este fragmento de código muestra cómo validar una contraseña:

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Comprobar si la contraseña coincide.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Devuelve `true` si la presentación ha sido cifrada con la contraseña especificada; de lo contrario, devuelve `false`.

{{% alert color="primary" title="Ver también" %}} 
- [Firma digital en PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Proteger una presentación con contraseña en línea**

1. Visite nuestra página [**Aspose.Slides Lock**](https://products.aspose.app/slides/es/lock). 
2. Haga clic en **Arrastre o cargue sus archivos**. 
3. Seleccione el archivo que desea proteger con contraseña en su equipo. 
4. Introduzca su contraseña preferida para la protección de edición y su contraseña preferida para la protección de visualización. 
5. Si desea que los usuarios vean su presentación como la copia final, marque la casilla **Marcar como final**. 
6. Haga clic en **PROTEGER AHORA**. 
7. Haga clic en **DESCARGAR AHORA**.

![Protección con contraseña de presentaciones PowerPoint](slides-lock.png)

## **Preguntas frecuentes**

**¿Qué métodos de cifrado admite Aspose.Slides?**

Aspose.Slides admite métodos de cifrado modernos, incluidos los algoritmos basados en AES, garantizando un alto nivel de seguridad de datos para sus presentaciones.

**¿Qué ocurre si se introduce una contraseña incorrecta al intentar abrir una presentación?**

Se lanza una excepción si se usa una contraseña incorrecta, avisándole de que el acceso a la presentación está denegado. Esto ayuda a prevenir accesos no autorizados y protege el contenido de la presentación.

**¿Existen implicaciones de rendimiento al trabajar con presentaciones protegidas con contraseña?**

El proceso de cifrado y descifrado puede introducir una ligera sobrecarga durante las operaciones de apertura y guardado. En la mayoría de los casos, este impacto en el rendimiento es mínimo y no afecta de manera significativa el tiempo total de procesamiento de sus tareas de presentación.