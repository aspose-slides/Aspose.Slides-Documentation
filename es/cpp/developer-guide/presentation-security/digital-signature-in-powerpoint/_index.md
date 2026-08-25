---
title: Añadir firmas digitales a presentaciones en C++
linktitle: Firma digital
type: docs
weight: 10
url: /es/cpp/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad de certificación
- certificado PFX
- PKCS#12
- validar firma
- PowerPoint
- PPTX
- seguridad de la presentación
- C++
- Aspose.Slides
description: "Aprenda cómo firmar presentaciones PPTX existentes con certificados PFX y usar Aspose.Slides para C++ para validar o eliminar firmas digitales."
---
## **Resumen**

Una firma digital ayuda al destinatario a determinar quién ha firmado una presentación y si el contenido firmado ha cambiado. Aquí son importantes tres conceptos de seguridad relacionados:

- Un **certificado digital** es una credencial electrónica que asocia una identidad con una clave pública. Una autoridad certificadora (CA) de confianza puede emitir un certificado, o una organización puede usar un certificado autofirmado para flujos de trabajo internos.
- Una **firma digital** se crea a partir del contenido de la presentación y la clave privada del titular del certificado. La clave pública del certificado puede entonces usarse para verificar la firma. Una firma proporciona evidencia de origen e integridad; no cifra la presentación.
- La **protección con contraseña** controla si un usuario puede abrir o modificar una presentación. Es independiente de la firma digital y se describe en [Presentaciones protegidas con contraseña](/slides/es/cpp/password-protected-presentation/).

PowerPoint ofrece el comando **Añadir una firma digital** bajo **Archivo > Información > Proteger presentación**.

![Menú Proteger presentación de PowerPoint con Añadir una firma digital resaltado](add-digital-signature-in-powerpoint.png)

Después de abrir una presentación firmada, PowerPoint puede mostrar una notificación del estado de la firma.

![Notificación de PowerPoint que indica que la presentación contiene firmas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expone las firmas a través de [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_digitalsignatures/), que devuelve una [IDigitalSignatureCollection](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignaturecollection/) cuyos elementos implementan [IDigitalSignature](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignature/). Una presentación puede contener varias firmas.

## **Entender los certificados PFX y las contraseñas**

Un archivo PFX, también conocido como archivo PKCS#12 y comúnmente con extensión `.pfx` o `.p12`, puede contener un certificado X.509, su clave privada y la cadena de certificados. La clave privada es la que permite al titular crear una firma. Un certificado sin una clave privada accesible no puede usarse para firmar una presentación.

La contraseña del PFX protege el paquete del certificado y la clave privada. **No** es una contraseña para abrir o editar la presentación. No commitas archivos PFX ni sus contraseñas al control de versiones. En producción, limita el acceso al archivo del certificado y obtén su contraseña de un almacén de secretos u otra fuente de configuración protegida. Los ejemplos siguientes usan una variable de entorno solo para evitar incrustar la contraseña en el código.

## **Añadir una firma digital a una presentación**

Para firmar una presentación real, carga un archivo PPTX existente, crea un [DigitalSignature](https://reference.aspose.com/slides/es/cpp/aspose.slides/digitalsignature/) a partir de un certificado PFX y su contraseña, añade la firma a la colección de la presentación y guarda en un archivo PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Guardar el resultado con un nombre nuevo preserva el archivo fuente sin firmar. El valor de [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignature/set_comments/) describe el propósito de la firma; no es un control de seguridad.

## **Validar firmas digitales**

Al cargar un archivo PPTX firmado, inspecciona cada elemento devuelto por [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_digitalsignatures/). El método [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignature/get_isvalid/) indica si la firma incrustada es válida para el contenido actual de la presentación.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Un resultado inválido suele significar que el contenido firmado de la presentación o los datos de la firma cambiaron después de la firma, o que el archivo está dañado. Eliminar todas las firmas produce una presentación sin firmar, por lo que solo comprobar la validez de los elementos no es suficiente: un flujo de trabajo sensible a la seguridad también debe verificar que el número esperado de firmas y las identidades de los firmantes esperados estén presentes.

Este resultado de validez no debe ser tratado como una decisión completa de confianza del certificado. Dependiendo de tu política de seguridad, tu aplicación también puede necesitar construir y validar la cadena de certificados X.509, comprobar las fechas de validez y el estado de revocación del certificado, confirmar el sujeto o huella esperada, verificar el uso de la clave y evaluar una marca de tiempo confiable. El valor de [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignature/get_signtime/) por sí solo no es prueba de una autoridad de marca de tiempo fiable.

## **Eliminar firmas digitales**

Eliminar firmas cambia el estado de seguridad de la presentación. El siguiente ejemplo carga un archivo PPTX firmado, elimina todas las firmas con [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignaturecollection/clear/), y guarda una copia sin firmas.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Para eliminar solo una firma, llama a [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/es/cpp/aspose.slides/idigitalsignaturecollection/removeat/) con su índice basado en cero. Guarda en un archivo nuevo a menos que sobrescribir el original firmado sea una parte explícita de tu flujo de trabajo.

## **Consideraciones de edición y formato**

- Una firma no convierte una presentación en solo lectura. Los usuarios y aplicaciones aún pueden editar el archivo, pero los cambios en el contenido firmado normalmente invalidan la firma existente.
- Completa todas las ediciones previstas antes de firmar. Si una presentación debe modificarse, guarda la presentación revisada y vuelve a firmar esa revisión.
- Mantén la salida final en formato PPTX. Convertir una presentación firmada a otro formato no transfiere la firma PPTX original como una firma válida para el archivo convertido.
- Trata la clave privada del certificado como información sensible. Cualquier persona que obtenga la clave privada y su contraseña podría crear firmas que parezcan originarse del titular del certificado.
- Conserva la fuente sin firmar o una copia controlada cuando tu política de retención de documentos lo requiera.

## **Preguntas frecuentes**

**¿Una firma digital cifra la presentación?**

No. Una firma digital proporciona evidencia sobre el origen y la integridad, pero el contenido de la presentación sigue siendo legible a menos que se aplique un cifrado separado. Usa [protección con contraseña](/slides/es/cpp/password-protected-presentation/) cuando sea necesario restringir el acceso al contenido.

**¿La contraseña del PFX es la misma que la contraseña de la presentación?**

No. La contraseña del PFX desbloquea la clave privada almacenada en el paquete del certificado. No controla quién puede abrir o editar el archivo PPTX.

**¿Puedo usar un certificado autofirmado?**

Técnicamente, un certificado autofirmado puede usarse siempre que incluya una clave privada accesible. Sin embargo, los destinatarios no lo confiarán automáticamente, a menos que ese certificado se haya añadido explícitamente a su entorno de confianza. Los flujos de trabajo públicos o interorganizacionales suelen usar un certificado emitido por una CA de confianza.

**¿Qué hace que una firma sea inválida?**

Cambiar el contenido firmado de la presentación o los datos de la firma después de firmar puede invalidar la firma. La corrupción del archivo también puede provocar que la validación falle. Si se eliminan todas las firmas, la presentación queda sin firmar en lugar de contener una firma inválida.

**¿Una firma válida significa que debo confiar en el firmante?**

No por sí sola. La integridad de la firma y la confianza en el firmante son decisiones separadas. Una política de validación en producción también debe comprobar la cadena de certificados, el período de validez, el estado de revocación, la identidad esperada, el uso de la clave y cualquier requisito de marca de tiempo fiable.

**¿Qué ocurre cuando el certificado caduca?**

La expiración del certificado no altera los bytes de la presentación, pero afecta la evaluación de confianza del certificado. Si una firma sigue siendo aceptable depende de tu política y de si una marca de tiempo fiable demuestra que la firma se realizó mientras el certificado era válido. No confíes solo en la hora de firma mostrada como marca de tiempo fiable.

**¿Una presentación firmada aún puede editarse?**

Sí. Firmar no bloquea el archivo. Editar el contenido firmado generalmente invalida la firma existente, por lo que debes terminar la presentación y firmar la revisión final.

**¿Una presentación puede contener más de una firma?**

Sí. Añade cada firma a la colección devuelta por [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/es/cpp/aspose.slides/ipresentation/get_digitalsignatures/) antes de guardar. Durante la validación, inspecciona cada firma y confirma que todos los firmantes requeridos estén presentes.

**¿Qué formatos de presentación admiten estas operaciones?**

Aspose.Slides solo admite las operaciones de firma digital descritas aquí para PPTX. Los formatos PPT y OpenDocument no están soportados por este flujo de trabajo de API.

**¿Puedo eliminar una firma sin afectar las diapositivas?**

Sí. Puedes eliminar una firma o vaciar toda la colección y luego guardar la presentación. El contenido de las diapositivas queda disponible, pero el archivo guardado ya no contiene la evidencia de la firma eliminada.