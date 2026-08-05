---
title: Añadir firmas digitales a presentaciones en Android
linktitle: Firma digital
type: docs
weight: 10
url: /es/androidjava/digital-signature-in-powerpoint/
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
- Android
- Java
- Aspose.Slides
description: "Aprenda a firmar presentaciones PPTX existentes con certificados PFX y a utilizar Aspose.Slides para Android mediante Java para validar o eliminar firmas digitales."
---
## **Descripción general**

Una firma digital ayuda al destinatario a determinar quién ha firmado una presentación y si el contenido firmado ha cambiado. Tres conceptos de seguridad relacionados son importantes aquí:

- Un **certificado digital** es una credencial electrónica que asocia una identidad con una clave pública. Una autoridad certificadora (CA) de confianza puede emitir un certificado, o una organización puede usar un certificado autofirmado para flujos de trabajo internos.
- Una **firma digital** se crea a partir del contenido de la presentación y de la clave privada del titular del certificado. La clave pública del certificado puede entonces usarse para verificar la firma. Una firma aporta evidencia de origen e integridad; no cifra la presentación.
- **Protección con contraseña** controla si un usuario puede abrir o modificar una presentación. Es independiente de la firma digital y se describe en [Presentaciones protegidas con contraseña](/androidjava/password-protected-presentation/).

PowerPoint ofrece el comando **Add a Digital Signature** bajo **File > Info > Protect Presentation**.

![Menú Proteger presentación de PowerPoint con Añadir una firma digital resaltado](add-digital-signature-in-powerpoint.png)

Después de abrir una presentación firmada, PowerPoint puede mostrar una notificación del estado de la firma.

![Notificación de PowerPoint indicando que la presentación contiene firmas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expone firmas a través de [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--), que devuelve una [IDigitalSignatureCollection](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignaturecollection/) cuyos elementos implementan [IDigitalSignature](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignature/). Una presentación puede contener varias firmas.

## **Entender los certificados PFX y las contraseñas**

Un archivo PFX, también conocido como archivo PKCS#12 y comúnmente con extensión `.pfx` o `.p12`, puede contener un certificado X.509, su clave privada y la cadena de certificados. La clave privada es lo que permite al titular crear una firma. Un certificado sin una clave privada accesible no puede usarse para firmar una presentación.

La contraseña del PFX protege el paquete del certificado y la clave privada. **No** es una contraseña para abrir o editar la presentación. No incluya archivos PFX ni sus contraseñas en el control de versiones. En producción, limite el acceso al archivo del certificado y obtenga su contraseña de un almacén de secretos u otra fuente de configuración protegida. Los ejemplos a continuación usan una variable de entorno solo para evitar incrustar la contraseña en el código.

## **Añadir una firma digital a una presentación**

Para firmar un flujo de trabajo real de presentación, cargue un archivo PPTX existente, cree una [DigitalSignature](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/digitalsignature/) a partir de un certificado PFX y su contraseña, añada la firma a la colección de la presentación y guarde en un archivo PPTX.

```java
import com.aspose.slides.*;

String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Guardar el resultado con un nombre nuevo conserva el archivo fuente sin firmar. El valor establecido por [IDigitalSignature.setComments](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) describe el propósito de la firma; no es un control de seguridad.

## **Validar firmas digitales**

Al cargar un archivo PPTX firmado, inspeccione cada elemento devuelto por [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--). El método [IDigitalSignature.isValid](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignature/#isValid--) indica si la firma incrustada es válida para el contenido actual de la presentación.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Un resultado inválido suele significar que el contenido firmado de la presentación o los datos de la firma se modificaron después de la firma, o que el archivo está dañado. Eliminar todas las firmas produce una presentación sin firmar, por lo que comprobar solo la validez de los elementos no es suficiente: un flujo de trabajo sensible a la seguridad también debe verificar que el número esperado de firmas y las identidades de los firmantes esperados estén presentes.

Este resultado de validez no debe considerarse una decisión completa de confianza en el certificado. Dependiendo de su política de seguridad, su aplicación también puede necesitar construir y validar la cadena de certificados X.509, comprobar las fechas de validez y el estado de revocación del certificado, confirmar el sujeto o huella esperada, verificar el uso de la clave y evaluar una marca de tiempo de confianza. El valor de [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignature/#getSignTime--) por sí solo no es prueba de una autoridad de sello de tiempo de confianza.

## **Eliminar firmas digitales**

Eliminar firmas cambia el estado de seguridad de la presentación. El siguiente ejemplo carga un archivo PPTX firmado, elimina todas las firmas con [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignaturecollection/#clear--), y guarda una copia sin firmar.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para eliminar solo una firma, llame a [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) con su índice basado en cero. Guarde en un nuevo archivo a menos que sobrescribir el original firmado sea una parte explícita de su flujo de trabajo.

## **Consideraciones de edición y formato**

- Una firma no hace que una presentación sea de solo lectura. Los usuarios y aplicaciones aún pueden editar el archivo, pero los cambios en el contenido firmado normalmente invalidan la firma existente.
- Realice todas las ediciones previstas antes de firmar. Si una presentación debe modificarse, guarde la presentación revisada y firme esa revisión nuevamente.
- Mantenga la salida final en formato PPTX. Convertir una presentación firmada a otro formato no transfiere la firma original del PPTX como una firma válida para el archivo convertido.
- Trate la clave privada del certificado como información sensible. Cualquiera que obtenga la clave privada y su contraseña puede crear firmas que parezcan provenir de ese titular del certificado.
- Conserve la fuente sin firmar o otra copia controlada cuando su política de retención de documentos lo requiera.

## **Preguntas frecuentes**

**¿Una firma digital cifra la presentación?**

No. Una firma digital aporta evidencia sobre el origen y la integridad, pero el contenido de la presentación sigue siendo legible a menos que se aplique un cifrado separado. Use [protección con contraseña](/androidjava/password-protected-presentation/) cuando se deba restringir el acceso al contenido.

**¿La contraseña del PFX es la misma que la contraseña de la presentación?**

No. La contraseña del PFX desbloquea la clave privada almacenada en el paquete del certificado. No controla quién puede abrir o editar el archivo PPTX.

**¿Puedo usar un certificado autofirmado?**

Técnicamente, un certificado autofirmado puede usarse cuando incluye una clave privada accesible. Sin embargo, los destinatarios no lo confiarán automáticamente, a menos que ese certificado se haya añadido explícitamente a su entorno de confianza. Los flujos de trabajo públicos o interorganizacionales normalmente usan un certificado emitido por una CA de confianza.

**¿Qué hace que una firma sea inválida?**

Modificar el contenido firmado de la presentación o los datos de la firma después de la firma puede invalidar la firma. La corrupción del archivo también puede hacer que la validación falle. Si se eliminan todas las firmas, la presentación queda sin firmar en lugar de contener una firma inválida.

**¿Una firma válida significa que debo confiar en el firmante?**

No por sí sola. La integridad de la firma y la confianza en el firmante son decisiones separadas. Una política de validación en producción también debe comprobar la cadena de certificados, el período de validez, el estado de revocación, la identidad esperada, el uso de la clave y cualquier requisito de marca de tiempo de confianza.

**¿Qué ocurre cuando el certificado expira?**

La expiración del certificado no altera los bytes de la presentación, pero afecta la evaluación de confianza del certificado. Si una firma sigue siendo aceptable depende de su política y de si una marca de tiempo de confianza válida demuestra que la firma se realizó mientras el certificado era válido. No confíe sólo en la hora de firma mostrada como una marca de tiempo de confianza.

**¿Se puede seguir editando una presentación firmada?**

Sí. Firmar no bloquea el archivo. Editar el contenido firmado generalmente invalida la firma existente, por lo que debe terminar la presentación primero y firmar la revisión final.

**¿Una presentación puede contener más de una firma?**

Sí. Añada cada firma a la colección devuelta por [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/#getDigitalSignatures--) antes de guardar. Durante la validación, inspeccione cada firma y confirme que todos los firmantes requeridos estén presentes.

**¿Qué formatos de presentación admiten estas operaciones?**

Aspose.Slides admite las operaciones de firma digital descritas aquí solo para PPTX. Los formatos PPT y OpenDocument no son compatibles con este flujo de trabajo de la API.

**¿Puedo eliminar una firma sin afectar a las diapositivas?**

Sí. Puede eliminar una firma o borrar toda la colección y luego guardar la presentación. El contenido de las diapositivas sigue disponible, pero el archivo guardado ya no contiene la evidencia de la firma eliminada.