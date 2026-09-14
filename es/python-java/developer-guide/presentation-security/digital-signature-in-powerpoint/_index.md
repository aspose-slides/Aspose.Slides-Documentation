---
title: Añadir firmas digitales a presentaciones en Python
linktitle: Firma digital
type: docs
weight: 10
url: /es/python-java/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Aprenda cómo firmar presentaciones PPTX existentes con certificados PFX y usar Aspose.Slides para Python mediante Java para validar o eliminar firmas digitales."
---
## **Visión general**

Una firma digital ayuda al destinatario a determinar quién firmó una presentación y si el contenido firmado ha cambiado. Tres conceptos de seguridad relacionados son importantes aquí:

- Un **certificado digital** es una credencial electrónica que asocia una identidad con una clave pública. Una autoridad de certificación (CA) de confianza puede emitir un certificado, o una organización puede usar un certificado autofirmado para flujos de trabajo internos.
- Una **firma digital** se crea a partir del contenido de la presentación y la clave privada del titular del certificado. La clave pública del certificado puede usarse luego para verificar la firma. Una firma proporciona evidencia de origen e integridad; no cifra la presentación.
- **Protección con contraseña** controla si un usuario puede abrir o modificar una presentación. Es independiente de la firma digital y se describe en [Presentaciones protegidas con contraseña](/slides/es/python-java/password-protected-presentation/).

PowerPoint ofrece el comando **Add a Digital Signature** bajo **File > Info > Protect Presentation**.

![Menú Proteger presentación de PowerPoint con Añadir una firma digital resaltada](add-digital-signature-in-powerpoint.png)

Tras abrir una presentación firmada, PowerPoint puede mostrar una notificación del estado de la firma.

![Notificación de PowerPoint indicando que la presentación contiene firmas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expone las firmas a través de [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDigitalSignatures), que devuelve una [DigitalSignatureCollection](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignaturecollection/) cuyos elementos son instancias de [DigitalSignature](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignature/). Una presentación puede contener varias firmas.

## **Comprender los certificados PFX y las contraseñas**

Un archivo PFX, también conocido como archivo PKCS#12 y comúnmente con extensión `.pfx` o `.p12`, puede contener un certificado X.509, su clave privada y la cadena de certificados. La clave privada es la que permite al titular crear una firma. Un certificado sin una clave privada accesible no puede usarse para firmar una presentación.

La contraseña PFX protege el paquete del certificado y la clave privada. **No** es una contraseña para abrir o editar la presentación. No añada archivos PFX ni sus contraseñas al control de versiones. En producción, limite el acceso al archivo del certificado y obtenga su contraseña desde un almacén de secretos u otra fuente de configuración protegida. Los ejemplos a continuación usan una variable de entorno solo para evitar incrustar la contraseña en el código.

## **Añadir una firma digital a una presentación**

Para firmar un flujo de trabajo real, cargue un archivo PPTX existente, cree una [DigitalSignature](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignature/) a partir de un certificado PFX y su contraseña, añada la firma a la colección de la presentación y guarde en un archivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Guardar el resultado con un nombre nuevo conserva el archivo fuente sin firmar. El valor establecido mediante [DigitalSignature.setComments](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignature/#setComments) describe el propósito de la firma; no es un control de seguridad.

## **Validar firmas digitales**

Al cargar un archivo PPTX firmado, inspeccione cada elemento devuelto por [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDigitalSignatures). El método [DigitalSignature.isValid](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignature/#isValid) indica si la firma incrustada es válida para el contenido actual de la presentación.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Un resultado inválido suele significar que el contenido firmado de la presentación o los datos de la firma cambiaron después de la firma, o que el archivo está dañado. Eliminar todas las firmas produce una presentación sin firmar, por lo que comprobar solo la validez de los elementos no es suficiente: un flujo de trabajo sensible a la seguridad también debe verificar que el número esperado de firmas y las identidades esperadas de los firmantes están presentes.

Este resultado de validez no debe considerarse como una decisión completa de confianza en el certificado. Según su política de seguridad, su aplicación también puede necesitar construir y validar la cadena de certificados X.509, comprobar las fechas de validez y el estado de revocación, confirmar el sujeto o la huella esperada, verificar el uso de la clave y evaluar una marca de tiempo de confianza. El valor devuelto por [DigitalSignature.getSignTime](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignature/#getSignTime) por sí solo no constituye prueba de una autoridad de marca de tiempo confiable.

## **Eliminar firmas digitales**

Eliminar firmas modifica el estado de seguridad de la presentación. El siguiente ejemplo carga un archivo PPTX firmado, elimina todas las firmas con [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignaturecollection/#clear) y guarda una copia sin firmar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para eliminar solo una firma, llame a [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/es/python-java/aspose.slides/digitalsignaturecollection/#removeAt) con su índice basado en cero. Guarde en un archivo nuevo a menos que sobrescribir el original firmado sea una parte explícita de su flujo de trabajo.

## **Consideraciones de edición y formato**

- Una firma no hace que la presentación sea de solo lectura. Los usuarios y aplicaciones pueden seguir editando el archivo, pero los cambios en el contenido firmado normalmente invalidan la firma existente.
- Complete todas las ediciones previstas antes de firmar. Si la presentación debe modificarse, guarde la versión revisada y firme esa revisión nuevamente.
- Mantenga la salida final en formato PPTX. Convertir una presentación firmada a otro formato no transfiere la firma original de PPTX como una firma válida para el archivo convertido.
- Trate la clave privada del certificado como información sensible. Cualquier persona que obtenga la clave privada y su contraseña podría crear firmas que parezcan provenir de ese titular del certificado.
- Conserve la fuente sin firmar u otra copia controlada cuando su política de retención de documentos lo requiera.

## **Preguntas frecuentes**

**¿Una firma digital cifra la presentación?**

No. Una firma digital proporciona evidencia sobre el origen y la integridad, pero el contenido de la presentación sigue siendo legible a menos que se aplique un cifrado separado. Use [protección con contraseña](/slides/es/python-java/password-protected-presentation/) cuando sea necesario restringir el acceso al contenido.

**¿La contraseña PFX es la misma que la contraseña de la presentación?**

No. La contraseña PFX desbloquea la clave privada almacenada en el paquete del certificado. No controla quién puede abrir o editar el archivo PPTX.

**¿Puedo usar un certificado autofirmado?**

Técnicamente, un certificado autofirmado puede usarse cuando incluye una clave privada accesible. Sin embargo, los destinatarios no lo confiarán automáticamente, a menos que ese certificado se haya añadido explícitamente a su entorno de confianza. Los flujos de trabajo públicos o entre organizaciones generalmente utilizan un certificado emitido por una CA de confianza.

**¿Qué hace que una firma sea inválida?**

Modificar el contenido firmado de la presentación o los datos de la firma después de la firma puede invalidar la firma. La corrupción del archivo también puede provocar que la validación falle. Si se eliminan todas las firmas, la presentación queda sin firmar, en lugar de contener una firma inválida.

**¿Una firma válida implica que debo confiar en el firmante?**

No por sí sola. La integridad de la firma y la confianza en el firmante son decisiones separadas. Una política de validación en producción también debe comprobar la cadena de certificados, el período de validez, el estado de revocación, la identidad esperada, el uso de la clave y cualquier requisito de marca de tiempo confiable.

**¿Qué ocurre cuando el certificado expira?**

La expiración del certificado no altera los bytes de la presentación, pero afecta la evaluación de confianza del certificado. Si una firma sigue siendo aceptable depende de su política y de si una marca de tiempo de confianza válida demuestra que la firma se realizó mientras el certificado estaba vigente. No confíe únicamente en la hora de firma mostrada como marca de tiempo confiable.

**¿Una presentación firmada aún puede editarse?**

Sí. Firmar no bloquea el archivo. Editar contenido firmado generalmente invalida la firma existente, por lo que debe terminar la presentación primero y firmar la revisión final.

**¿Una presentación puede contener más de una firma?**

Sí. Añada cada firma a la colección devuelta por [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#getDigitalSignatures) antes de guardar. Durante la validación, inspeccione cada firma y confirme que todos los firmantes requeridos estén presentes.

**¿Qué formatos de presentación admiten estas operaciones?**

Aspose.Slides admite las operaciones de firma digital descritas aquí solo para PPTX. Los formatos PPT y OpenDocument no son compatibles con este flujo de trabajo de la API.

**¿Puedo eliminar una firma sin afectar a las diapositivas?**

Sí. Puede eliminar una firma o vaciar toda la colección y luego guardar la presentación. El contenido de las diapositivas permanece disponible, pero el archivo guardado ya no lleva la evidencia de la firma eliminada.