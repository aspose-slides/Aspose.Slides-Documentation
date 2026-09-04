---
title: Proteger presentaciones con contraseña en .NET
linktitle: Protección de contraseña
type: docs
weight: 20
url: /es/net/password-protected-presentation/
keywords:
- presentación protegida con contraseña
- contraseña de apertura
- cifrar PowerPoint
- descifrar PowerPoint
- validar contraseña de presentación
- comprobar contraseña de presentación
- abrir presentación cifrada
- eliminar cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cifre, detecte, valide, abra y descifre presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en C# con Aspose.Slides para .NET."
---
## **Visión general**

Una contraseña de apertura cifra una presentación. Se necesita la contraseña correcta para cargar y ver el contenido de la presentación, por lo que esta protección proporciona confidencialidad.

Una contraseña de apertura es diferente de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para administrar contraseñas para modificar presentaciones, consulte [Proteger presentaciones contra escritura](/slides/es/net/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Use [IProtectionManager.Encrypt](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/encrypt/) para asignar una contraseña de apertura. Luego use [IPresentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/save/) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Mantener las propiedades del documento públicas**

De forma predeterminada, Aspose.Slides incluye las propiedades del documento en el cifrado de la presentación. La propiedad [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) controla este comportamiento de forma independiente del cifrado del contenido de las diapositivas. Establézcalo en `false` antes de llamar a [IProtectionManager.Encrypt](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/encrypt/) cuando un sistema de indexado, clasificación, búsqueda o gestión documental necesite leer metadatos sin la contraseña de apertura.

El siguiente ejemplo crea una presentación PPTX cifrada dejando públicas sus propiedades de documento integradas:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Establecer `EncryptDocumentProperties` en `false` no hace públicos los diapositivas, maestros, diseños, formas, medios u otro contenido de la presentación. Afecta solo a las propiedades del documento. Para leer esas propiedades sin cargar el contenido cifrado, vea [Administrar propiedades de la presentación](/slides/es/net/presentation-properties/).

## **Cargar una presentación cifrada**

Establezca [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Trabajar con la presentación descifrada.
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/removeencryption/), y guarde el resultado. La presentación guardada puede entonces cargarse sin una contraseña.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Validar una contraseña de apertura antes de cargar**

Use [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationfactory/getpresentationinfo/) para obtener [IPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/) sin crear una instancia completa de la presentación. Verifique [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/ispasswordprotected/) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/), y luego carga la presentación completa:

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Flujo de trabajo con flujo**

La sobrecarga de flujo de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationfactory/getpresentationinfo/) proporciona el mismo flujo de trabajo. Restablezca la posición de un flujo buscable antes de cargar la presentación completa desde ese flujo.

El siguiente ejemplo usa un archivo PPT:

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Valores de retorno de CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/checkpassword/) devuelve `true` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `false` en cada uno de estos casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `null` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/isencrypted/) para confirmar que la presentación original estaba cifrada. Para detectar la protección por contraseña de apertura antes de cargar, use `IPresentationInfo.IsPasswordProtected` como se mostró arriba.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Recomendaciones de seguridad**

{{% alert color="warning" title="Seguridad" %}}
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso cuando cargue inmediatamente la presentación.

Las propiedades públicas del documento pueden revelar nombres de autor, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados aunque el contenido de la presentación esté cifrado. Cifre los metadatos sensibles junto con la presentación. Dejar las propiedades públicas debe ser una decisión explícita tomada solo cuando los sistemas deben indexar, clasificar, buscar o gestionar el archivo sin una contraseña de apertura.
{{% /alert %}}

## **Proteger con contraseña una presentación en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
1. Seleccione o cargue la presentación.
1. Introduzca una contraseña para la protección de visualización.
1. Opcionalmente, introduzca una contraseña distinta para la protección de edición.
1. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="Ver también" %}}
- [Proteger presentaciones contra escritura](/slides/es/net/write-protected-presentation/)
- [Firma digital en PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección contra escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección contra escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si existe protección por contraseña de apertura y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Puede una aplicación leer los metadatos sin la contraseña de apertura?**

Sí, pero solo cuando la presentación se cifró con `EncryptDocumentProperties` establecido en `false`. La aplicación debe entonces usar el modo de carga solo de propiedades del documento descrito en [Administrar propiedades de la presentación](/slides/es/net/presentation-properties/).

**¿Los flujos de trabajo de comprobación de contraseña admiten tanto PPT como PPTX?**

Sí. La detección y validación de contraseñas basadas en ruta de archivo y en flujo se comportan de la misma manera para presentaciones PPT y PPTX.