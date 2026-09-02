---
title: Agregar firmas digitales a presentaciones en JavaScript
linktitle: Firma digital
type: docs
weight: 10
url: /es/nodejs-java/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad certificadora
- certificado PFX
- PKCS#12
- validar firma
- PowerPoint
- PPTX
- seguridad de la presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a firmar presentaciones PPTX existentes con certificados PFX y use Aspose.Slides para Node.js a través de Java para validar o eliminar firmas digitales."
---
## **Visión general**

Una firma digital ayuda al destinatario a determinar quién firmó una presentación y si el contenido firmado ha cambiado. Tres conceptos de seguridad relacionados son importantes aquí:

- Un **certificado digital** es una credencial electrónica que asocia una identidad con una clave pública. Una autoridad de certificación (CA) de confianza puede emitir un certificado, o una organización puede usar un certificado autofirmado para flujos de trabajo internos.
- Una **firma digital** se crea a partir del contenido de la presentación y la clave privada del titular del certificado. La clave pública del certificado puede entonces usarse para verificar la firma. Una firma proporciona evidencia de origen e integridad; no cifra la presentación.
- La **protección con contraseña** controla si un usuario puede abrir o modificar una presentación. Es independiente de la firma digital y se describe en [Presentaciones protegidas con contraseña](/nodejs-java/password-protected-presentation/).

PowerPoint ofrece el comando **Agregar una firma digital** bajo **Archivo > Información > Proteger presentación**.

![Menú Proteger presentación de PowerPoint con Agregar una firma digital resaltado](add-digital-signature-in-powerpoint.png)

Después de abrir una presentación firmada, PowerPoint puede mostrar una notificación del estado de la firma.

![Notificación de PowerPoint que indica que la presentación contiene firmas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expone las firmas mediante [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), que devuelve una [DigitalSignatureCollection](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignaturecollection/) que contiene objetos [DigitalSignature](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignature/). Una presentación puede contener varias firmas.

## **Comprender los certificados PFX y las contraseñas**

Un archivo PFX, también conocido como archivo PKCS#12 y habitualmente con extensión `.pfx` o `.p12`, puede contener un certificado X.509, su clave privada y la cadena de certificados. La clave privada es la que permite al titular crear una firma. Un certificado sin una clave privada accesible no puede usarse para firmar una presentación.

La contraseña del PFX protege el paquete del certificado y la clave privada. **No** es una contraseña para abrir o editar la presentación. No incluya archivos PFX ni sus contraseñas en el control de versiones. En producción, limite el acceso al archivo del certificado y obtenga su contraseña de un almacén de secretos u otra fuente de configuración protegida. Los ejemplos a continuación usan una variable de entorno solo para evitar incrustar la contraseña en el código.

## **Agregar una firma digital a una presentación**

Para firmar el flujo de trabajo de una presentación real, cargue un archivo PPTX existente, cree una [DigitalSignature](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignature/) a partir de un certificado PFX y su contraseña, añada la firma a la colección de la presentación y guarde en un archivo PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Guardar el resultado con un nombre nuevo conserva el archivo fuente sin firmar. El valor establecido mediante [DigitalSignature.setComments](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignature/) describe el propósito de la firma; no es un control de seguridad.

## **Validar firmas digitales**

Cuando cargue un archivo PPTX firmado, inspeccione cada elemento devuelto por [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). El método [DigitalSignature.isValid](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignature/) indica si la firma incrustada es válida para el contenido actual de la presentación.

El siguiente ejemplo también usa la clase `X509Certificate` de Node.js para leer el nombre del sujeto de cada certificado incrustado.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Un resultado inválido suele significar que el contenido firmado de la presentación o los datos de la firma cambiaron después de la firma, o que el archivo está dañado. Eliminar todas las firmas produce una presentación sin firmar, por lo que comprobar solo la validez de los elementos no es suficiente: un flujo de trabajo sensible a la seguridad también debe verificar que el número esperado de firmas y las identidades de los firmantes esperados estén presentes.

Este resultado de validez no debe considerarse una decisión completa de confianza del certificado. Dependiendo de su política de seguridad, su aplicación también puede necesitar construir y validar la cadena de certificados X.509, comprobar las fechas de validez y el estado de revocación del certificado, confirmar el sujeto o la huella esperados, verificar el uso de la clave y evaluar una marca de tiempo de confianza. El valor devuelto por [DigitalSignature.getSignTime](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignature/) por sí solo no constituye prueba de una autoridad de sellado de tiempo confiable.

## **Eliminar firmas digitales**

Eliminar firmas cambia el estado de seguridad de la presentación. El siguiente ejemplo carga un archivo PPTX firmado, elimina todas las firmas con [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), y guarda una copia sin firmar.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para eliminar solo una firma, llame a [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) con su índice basado en cero. Guarde en un archivo nuevo salvo que sobrescribir el original firmado sea una parte explícita de su flujo de trabajo.

## **Consideraciones de edición y formato**

- Una firma no hace que una presentación sea de solo lectura. Los usuarios y las aplicaciones pueden seguir editando el archivo, pero los cambios en el contenido firmado normalmente invalidan la firma existente.
- Realice todas las ediciones previstas antes de firmar. Si la presentación debe modificarse, guarde la versión revisada y vuelva a firmar esa revisión.
- Mantenga la salida final en formato PPTX. Convertir una presentación firmada a otro formato no transfiere la firma original del PPTX como una firma válida para el archivo convertido.
- Trate la clave privada del certificado como un dato sensible. Cualquier persona que obtenga la clave privada y su contraseña podría crear firmas que parezcan procedentes de ese titular del certificado.
- Conserve el origen sin firmar o una copia controlada cuando su política de retención de documentos lo requiera.

## **Preguntas frecuentes**

**¿Una firma digital cifra la presentación?**

No. Una firma digital aporta evidencia sobre el origen y la integridad, pero el contenido de la presentación sigue siendo legible a menos que se aplique un cifrado separado. Use [protección con contraseña](/nodejs-java/password-protected-presentation/) cuando sea necesario restringir el acceso al contenido.

**¿La contraseña del PFX es la misma que la contraseña de la presentación?**

No. La contraseña del PFX desbloquea la clave privada almacenada en el paquete del certificado. No controla quién puede abrir o editar el archivo PPTX.

**¿Puedo usar un certificado autofirmado?**

Técnicamente, un certificado autofirmado puede usarse siempre que incluya una clave privada accesible. Sin embargo, los destinatarios no lo confiarán automáticamente, a menos que ese certificado se haya añadido explícitamente a su entorno de confianza. Los flujos de trabajo públicos o inter‑organizaciones suelen usar un certificado emitido por una CA de confianza.

**¿Qué hace que una firma sea inválida?**

Cambiar el contenido firmado de la presentación o los datos de la firma después de firmar puede invalidar la firma. La corrupción del archivo también puede provocar fallos en la validación. Si se eliminan todas las firmas, la presentación queda sin firmar en lugar de contener una firma inválida.

**¿Una firma válida significa que debo confiar en el firmante?**

No por sí sola. La integridad de la firma y la confianza en el firmante son decisiones separadas. Una política de validación en producción debe también comprobar la cadena de certificados, el periodo de validez, el estado de revocación, la identidad esperada, el uso de la clave y cualquier requisito de marca de tiempo confiable.

**¿Qué ocurre cuando el certificado expira?**

La expiración del certificado no altera los bytes de la presentación, pero afecta la evaluación de confianza del certificado. Si una firma sigue siendo aceptable dependerá de su política y de si una marca de tiempo confiable valida que la firma se realizó mientras el certificado estaba vigente. No confíe únicamente en la hora de firma mostrada como marca de tiempo confiable.

**¿Una presentación firmada puede seguir editándose?**

Sí. Firmar no bloquea el archivo. Editar el contenido firmado generalmente invalida la firma existente, por lo que debe terminar la presentación antes de firmar la versión final.

**¿Una presentación puede contener más de una firma?**

Sí. Añada cada firma a la colección devuelta por [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) antes de guardar. Durante la validación, inspeccione cada firma y confirme que todos los firmantes requeridos estén presentes.

**¿Qué formatos de presentación admiten estas operaciones?**

Aspose.Slides admite las operaciones de firma digital descritas aquí solo para PPTX. Los formatos PPT y OpenDocument no son compatibles con este flujo de trabajo de API.

**¿Puedo eliminar una firma sin afectar las diapositivas?**

Sí. Puede eliminar una firma o vaciar la colección completa y luego guardar la presentación. El contenido de las diapositivas permanece disponible, pero el archivo guardado ya no lleva la evidencia de la firma eliminada.