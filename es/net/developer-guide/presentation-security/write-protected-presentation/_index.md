---
title: Proteger presentaciones contra escritura en .NET
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/net/write-protected-presentation/
keywords:
- protección contra escritura
- PowerPoint con protección contra escritura
- contraseña para modificar
- restringir la edición de la presentación
- eliminar la protección contra escritura
- validar contraseña de modificación
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX utilizando Aspose.Slides para .NET."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación, pero no cifra su contenido. Los usuarios pueden cargar y ver una presentación protegida contra escritura sin la contraseña. Según la aplicación, también pueden editar el contenido y guardarlo con otro nombre, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura tiene un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, vea [Password-Protect Presentations](/slides/es/net/password-protected-presentation/).

Los flujos de trabajo en este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan archivos PPTX; al guardar en PPT, use la extensión `.ppt` y el formato de guardado PPT correspondiente.

## **Establecer protección contra escritura en una presentación**

Utilice [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/setwriteprotection/) para asignar una contraseña que permita modificar una presentación. Guardar la presentación conserva la configuración de protección.

El siguiente ejemplo establece protección contra escritura en una presentación PPTX:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Cargar una presentación protegida contra escritura**

Dado que la protección contra escritura no cifra el contenido de la presentación, no se requiere contraseña para cargar la presentación. La contraseña es relevante solo al validar la autorización para modificar la presentación protegida.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

No pase una contraseña de protección contra escritura a [LoadOptions.Password](https://reference.aspose.com/slides/es/net/aspose.slides/loadoptions/password/). Esa propiedad acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporcione la contraseña de apertura para cargarla y gestione la contraseña de protección contra escritura por separado.

## **Eliminar la protección contra escritura de una presentación**

Utilice [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/removewriteprotection/) para eliminar la restricción de modificación, luego guarde la presentación.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/), llame a [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationfactory/getpresentationinfo/) y examine [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/iswriteprotected/). La propiedad utiliza [NullableBool](https://reference.aspose.com/slides/es/net/aspose.slides/nullablebool/) y devuelve `NullableBool.True` cuando se detecta protección contra escritura.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

La sobrecarga de flujo de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationfactory/getpresentationinfo/) proporciona la misma información para una presentación suministrada como flujo.

## **Validar una contraseña de protección contra escritura**

Utilice [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/checkwriteprotection/) para validar una contraseña de modificación sin cargar la presentación completa. Compruebe [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/iswriteprotected/) primero para que la aplicación solicite o valide una contraseña solo cuando exista protección contra escritura.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/checkwriteprotection/) valida solo la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si se puede cargar contenido cifrado. Por el contrario, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentationinfo/checkpassword/) valida solo una contraseña de apertura. Si ya se ha cargado una presentación completa, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/es/net/aspose.slides/iprotectionmanager/checkwriteprotection/) proporciona la comprobación equivalente de protección contra escritura a través de su gestor de protección.

En aplicaciones de producción, no registre contraseñas ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios y conserve las contraseñas en memoria solo durante el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Password-Protect Presentations](/slides/es/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/es/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/es/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargarlo y visualizarlo.

**¿Se requiere la contraseña de protección contra escritura para abrir una presentación?**

No. Solo se necesita una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una contraseña de protección contra escritura?**

Sí. Proporcione la contraseña de apertura mediante las opciones de carga para abrir la presentación cifrada, y valide la contraseña de protección contra escritura por separado cuando se requiera autorización para modificar.