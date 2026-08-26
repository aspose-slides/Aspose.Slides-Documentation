---
title: Proteger presentaciones con contraseña en .NET
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/net/password-protected-presentation/
keywords:
- presentación protegida con contraseña
- contraseña de apertura
- cifrar PowerPoint
- descifrar PowerPoint
- validar la contraseña de la presentación
- comprobar la contraseña de la presentación
- abrir presentación cifrada
- eliminar cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- .NET
- C#
- Aspose.Slides
description: "Cifrar, detectar, validar, abrir y descifrar presentaciones PowerPoint PPT y PPTX protegidas con contraseña en C# con Aspose.Slides para .NET."
---
## **Visión general**

Una contraseña de apertura encripta una presentación. La contraseña correcta es necesaria para cargar y ver el contenido de la presentación, por lo que esta protección proporciona confidencialidad.

Una contraseña de apertura es diferente de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no encripta el contenido ni impide que se cargue la presentación. Para gestionar contraseñas para modificar presentaciones, consulte [Proteger presentaciones contra escritura](/slides/es/net/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [IProtectionManager.Encrypt](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/encrypt/) para asignar una contraseña de apertura. A continuación, utilice [IPresentation.Save](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/save/) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Cargar una presentación cifrada**

Establezca [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Trabajar con la presentación descifrada.
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/removeencryption/) y guarde el resultado. La presentación guardada puede entonces cargarse sin contraseña.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Validar una contraseña de apertura antes de cargar**

Utilice [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationfactory/getpresentationinfo/) para obtener [IPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/) sin crear una instancia completa de la presentación. Verifique [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/ispasswordprotected/) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor suministrado con [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/) y luego carga la presentación completa:

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

La sobrecarga de flujo de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationfactory/getpresentationinfo/) ofrece el mismo flujo de trabajo. Restablezca la posición de un flujo con capacidad de búsqueda antes de cargar la presentación completa desde ese flujo.

El siguiente ejemplo utiliza un archivo PPT:

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

Después de cargar una presentación con la contraseña correcta, inspeccione [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/isencrypted/) para confirmar que la presentación original estaba cifrada. Para detectar la protección con contraseña de apertura antes de cargar, utilice `IPresentationInfo.IsPasswordProtected` como se mostró anteriormente.

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
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso cuando cargue la presentación inmediatamente.
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

Sí. Obtenga la información de la presentación, verifique si la protección con contraseña de apertura está presente y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Los flujos de trabajo de comprobación de contraseñas son compatibles con PPT y PPTX?**

Sí. La detección y validación de contraseñas basada en rutas de archivo y en flujos se comportan de la misma manera para presentaciones PPT y PPTX.