---
title: Añadir firmas digitales a presentaciones en .NET
linktitle: Firma digital
type: docs
weight: 10
url: /es/net/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad certificadora
- certificado PFX
- PKCS#12
- validar firma
- PowerPoint
- PPTX
- seguridad de presentaciones
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo firmar presentaciones PPTX existentes con certificados PFX y utilizar Aspose.Slides para .NET para validar o eliminar firmas digitales."
---
## **Visión general**

Una firma digital ayuda al destinatario a determinar quién firmó una presentación y si el contenido firmado ha cambiado. Tres conceptos de seguridad relacionados son importantes aquí:

- Un **certificado digital** es una credencial electrónica que asocia una identidad con una clave pública. Una autoridad certificadora de confianza (CA) puede emitir un certificado, o una organización puede usar un certificado autofirmado para flujos de trabajo internos.
- Una **firma digital** se crea a partir del contenido de la presentación y la clave privada del titular del certificado. La clave pública del certificado puede usarse entonces para verificar la firma. Una firma proporciona evidencia de origen e integridad; no cifra la presentación.
- **Protección con contraseña** controla si un usuario puede abrir o modificar una presentación. Es independiente de la firma digital y se describe en [Presentaciones protegidas con contraseña](/slides/es/net/password-protected-presentation/).

PowerPoint ofrece el comando **Add a Digital Signature** bajo **File > Info > Protect Presentation**.

![Menú Proteger presentación de PowerPoint con Agregar una firma digital resaltada](add-digital-signature-in-powerpoint.png)

Después de abrir una presentación firmada, PowerPoint puede mostrar una notificación de estado de la firma.

![Notificación de PowerPoint indicando que la presentación contiene firmas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expone las firmas a través de [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/digitalsignatures/), una [IDigitalSignatureCollection](https://reference.aspose.com/slides/es/net/aspose.slides/idigitalsignaturecollection/) cuyos elementos implementan [IDigitalSignature](https://reference.aspose.com/slides/es/net/aspose.slides/idigitalsignature/). Una presentación puede contener múltiples firmas.

## **Entender los certificados PFX y contraseñas**

Un archivo PFX, también conocido como archivo PKCS#12 y habitualmente con la extensión `.pfx` o `.p12`, puede contener un certificado X.509, su clave privada y la cadena de certificados. La clave privada es lo que permite al titular crear una firma. Un certificado sin una clave privada accesible no puede usarse para firmar una presentación.

La contraseña del PFX protege el paquete del certificado y la clave privada. **No** es una contraseña para abrir o editar la presentación. No incluya archivos PFX ni sus contraseñas en el control de versiones. En producción, limite el acceso al archivo del certificado y obtenga su contraseña de un almacén de secretos u otra fuente de configuración protegida. Los ejemplos siguientes usan una variable de entorno solo para evitar incrustar la contraseña en el código.

## **Agregar una firma digital a una presentación**

Para firmar un flujo de trabajo real, cargue un archivo PPTX existente, cree una [DigitalSignature](https://reference.aspose.com/slides/es/net/aspose.slides/digitalsignature/) a partir de un certificado PFX y su contraseña, añada la firma a la colección de la presentación y guarde en un archivo PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Guardar el resultado con un nombre nuevo preserva el archivo fuente sin firmar. El valor de [DigitalSignature.Comments](https://reference.aspose.com/slides/es/net/aspose.slides/digitalsignature/comments/) describe el propósito de la firma; no es un control de seguridad.

## **Validar firmas digitales**

Cuando cargue un archivo PPTX firmado, inspeccione cada elemento en [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/digitalsignatures/). La propiedad [IDigitalSignature.IsValid](https://reference.aspose.com/slides/es/net/aspose.slides/idigitalsignature/isvalid/) indica si la firma incrustada es válida para el contenido actual de la presentación.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Un resultado inválido suele significar que el contenido firmado de la presentación o los datos de la firma cambiaron después de firmar, o que el archivo está dañado. Eliminar todas las firmas produce una presentación sin firmar, por lo que comprobar solo la validez de los elementos no es suficiente: un flujo de trabajo sensible a la seguridad también debe verificar que el número esperado de firmas y las identidades de los firmantes esperados estén presentes.

Este resultado de validez no debe considerarse una decisión completa de confianza del certificado. Según su política de seguridad, su aplicación también puede necesitar construir y validar la cadena de certificados X.509, comprobar las fechas de validez y el estado de revocación del certificado, confirmar el sujeto o huella esperados, verificar el uso de la clave y evaluar una marca de tiempo confiable. El valor de [IDigitalSignature.SignTime](https://reference.aspose.com/slides/es/net/aspose.slides/idigitalsignature/signtime/) por sí solo no constituye prueba de una autoridad de marcas de tiempo confiable.

## **Eliminar firmas digitales**

Eliminar firmas cambia el estado de seguridad de la presentación. El siguiente ejemplo carga un archivo PPTX firmado, elimina todas las firmas con [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/es/net/aspose.slides/idigitalsignaturecollection/clear/), y guarda una copia sin firmar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Para eliminar solo una firma, llame a [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/es/net/aspose.slides/idigitalsignaturecollection/removeat/) con su índice basado en cero. Guarde en un archivo nuevo a menos que sobrescribir el original firmado sea una parte explícita de su flujo de trabajo.

## **Consideraciones de edición y formato**

- Una firma no hace que la presentación sea de solo lectura. Los usuarios y las aplicaciones aún pueden editar el archivo, pero los cambios en el contenido firmado normalmente invalidan la firma existente.
- Complete todas las ediciones previstas antes de firmar. Si la presentación debe modificarse, guarde la versión revisada y firme esa revisión nuevamente.
- Mantenga la salida final en formato PPTX. Convertir una presentación firmada a otro formato no transfiere la firma PPTX original como una firma válida para el archivo convertido.
- Trate la clave privada del certificado como información sensible. Cualquiera que obtenga la clave privada y su contraseña podría crear firmas que parezcan provenir de ese titular del certificado.
- Conserve la fuente sin firmar o una copia controlada cuando su política de retención de documentos lo requiera.

## **Preguntas frecuentes**

**¿Una firma digital cifra la presentación?**

No. Una firma digital proporciona evidencia sobre el origen y la integridad, pero el contenido de la presentación sigue siendo legible a menos que se aplique un cifrado separado. Use [protección con contraseña](/slides/es/net/password-protected-presentation/) cuando se deba restringir el acceso al contenido.

**¿La contraseña del PFX es la misma que la contraseña de la presentación?**

No. La contraseña del PFX desbloquea la clave privada almacenada en el paquete del certificado. No controla quién puede abrir o editar el archivo PPTX.

**¿Puedo usar un certificado autofirmado?**

Técnicamente, un certificado autofirmado puede usarse cuando incluye una clave privada accesible. Sin embargo, los destinatarios no lo confiarán automáticamente a menos que ese certificado se haya añadido explícitamente a su entorno de confianza. Los flujos de trabajo públicos o entre organizaciones generalmente usan un certificado emitido por una CA de confianza.

**¿Qué hace que una firma sea inválida?**

Modificar el contenido firmado de la presentación o los datos de la firma después de firmar puede invalidar la firma. La corrupción del archivo también puede provocar que la validación falle. Si se eliminan todas las firmas, la presentación queda sin firmar, no contiene una firma inválida.

**¿Una firma válida implica que debo confiar en el firmante?**

No por sí sola. La integridad de la firma y la confianza en el firmante son decisiones separadas. Una política de validación en producción también debe comprobar la cadena de certificados, el período de validez, el estado de revocación, la identidad esperada, el uso de la clave y cualquier requisito de marca de tiempo confiable.

**¿Qué ocurre cuando el certificado expira?**

La expiración del certificado no altera los bytes de la presentación, pero afecta la evaluación de confianza del certificado. Si una firma sigue siendo aceptable depende de su política y de si una marca de tiempo confiable válida demuestra que la firma se realizó mientras el certificado era válido. No confíe únicamente en la hora de firma mostrada como marca de tiempo confiable.

**¿Una presentación firmada aún puede editarse?**

Sí. Firmar no bloquea el archivo. Editar el contenido firmado generalmente invalida la firma existente, por lo que debe terminar la presentación primero y firmar la revisión final.

**¿Una presentación puede contener más de una firma?**

Sí. Añada cada firma a [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/es/net/aspose.slides/ipresentation/digitalsignatures/) antes de guardar. Durante la validación, inspeccione cada firma y confirme que todos los firmantes requeridos estén presentes.

**¿Qué formatos de presentación admiten estas operaciones?**

Aspose.Slides soporta las operaciones de firma digital descritas aquí solo para PPTX. Los formatos PPT y OpenDocument no son compatibles con este flujo de trabajo de API.

**¿Puedo eliminar una firma sin afectar las diapositivas?**

Sí. Puede eliminar una firma o vaciar la colección completa y luego guardar la presentación. El contenido de las diapositivas permanece disponible, pero el archivo guardado ya no lleva la evidencia de la firma eliminada.