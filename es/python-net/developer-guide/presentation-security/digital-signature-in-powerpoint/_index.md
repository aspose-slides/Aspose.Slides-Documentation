---
title: Añadir firmas digitales a presentaciones en Python
linktitle: Firma digital
type: docs
weight: 10
url: /es/python-net/digital-signature-in-powerpoint/
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
description: "Aprenda cómo firmar presentaciones PPTX existentes con certificados PFX y usar Aspose.Slides para Python a través de .NET para validar o eliminar firmas digitales."
---
## **Descripción general**

Una firma digital ayuda al destinatario a determinar quién ha firmado una presentación y si el contenido firmado ha cambiado. Aquí son importantes tres conceptos de seguridad relacionados:

- Un **certificado digital** es una credencial electrónica que asocia una identidad con una clave pública. Una autoridad certificadora de confianza (CA) puede emitir un certificado, o una organización puede usar un certificado autofirmado para flujos de trabajo internos.
- Una **firma digital** se crea a partir del contenido de la presentación y la clave privada del titular del certificado. La clave pública del certificado puede entonces usarse para verificar la firma. Una firma proporciona evidencia de origen e integridad; no cifra la presentación.
- La **protección con contraseña** controla si un usuario puede abrir o modificar una presentación. Es independiente de la firma digital y se describe en [Presentaciones protegidas con contraseña](/python-net/password-protected-presentation/).

PowerPoint ofrece el comando **Add a Digital Signature** bajo **File > Info > Protect Presentation**.

![Menú Proteger presentación de PowerPoint con Añadir una firma digital resaltado](add-digital-signature-in-powerpoint.png)

Después de abrir una presentación firmada, PowerPoint puede mostrar una notificación del estado de la firma.

![Notificación de PowerPoint que indica que la presentación contiene firmas válidas](digital-signature-status-in-powerpoint.png)

Aspose.Slides expone las firmas a través de [Presentation.digital_signatures](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/digital_signatures/), una [DigitalSignatureCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignaturecollection/) cuyos elementos son objetos [DigitalSignature](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/). Una presentación puede contener varias firmas.

## **Comprender los certificados PFX y las contraseñas**

Un archivo PFX, también conocido como archivo PKCS#12 y normalmente con la extensión `.pfx` o `.p12`, puede contener un certificado X.509, su clave privada y la cadena de certificados. La clave privada es la que permite al titular crear una firma. Un certificado sin una clave privada accesible no puede usarse para firmar una presentación.

La contraseña del PFX protege el paquete del certificado y la clave privada. **No** es una contraseña para abrir o editar la presentación. No incluya archivos PFX ni sus contraseñas en el control de versiones. En producción, limite el acceso al archivo del certificado y obtenga su contraseña de un almacén de secretos o de otra fuente de configuración protegida. Los ejemplos a continuación usan una variable de entorno solo para evitar incrustar la contraseña en el código.

## **Añadir una firma digital a una presentación**

Para firmar el flujo de trabajo de una presentación real, cargue un archivo PPTX existente, cree una [DigitalSignature](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/) a partir de un certificado PFX y su contraseña, añada la firma a la colección de la presentación y guarde el archivo PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Guardar el resultado con un nombre nuevo preserva el archivo fuente sin firmar. El valor de [DigitalSignature.comments](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/comments/) describe el propósito de la firma; no es un control de seguridad.

## **Validar firmas digitales**

Al cargar un archivo PPTX firmado, inspeccione cada elemento en [Presentation.digital_signatures](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/digital_signatures/). La propiedad [DigitalSignature.is_valid](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/is_valid/) indica si la firma incrustada es válida para el contenido actual de la presentación.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Un resultado inválido suele significar que el contenido firmado de la presentación o los datos de la firma cambiaron después de la firma, o que el archivo está dañado. Eliminar todas las firmas produce una presentación sin firmar, por lo que comprobar solo la validez de los elementos no es suficiente: un flujo de trabajo sensible a la seguridad también debe verificar que el número esperado de firmas y las identidades de los firmantes esperados estén presentes.

La propiedad [DigitalSignature.certificate](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/certificate/) proporciona los datos del certificado como una matriz de bytes. El ejemplo calcula su huella SHA-256 para que una aplicación pueda compararla con la huella de un certificado de firmante esperado.

Este resultado de validez no debe considerarse una decisión completa de confianza en el certificado. Dependiendo de su política de seguridad, su aplicación también puede necesitar construir y validar la cadena de certificados X.509, comprobar las fechas de validez y el estado de revocación del certificado, confirmar el sujeto o la huella esperada, verificar el uso de la clave y evaluar una marca de tiempo confiable. El valor de [DigitalSignature.sign_time](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/sign_time/) por sí solo no constituye prueba de una autoridad de sellado de tiempo confiable.

## **Eliminar firmas digitales**

Eliminar firmas cambia el estado de seguridad de la presentación. El siguiente ejemplo carga un archivo PPTX firmado, elimina todas las firmas con [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignaturecollection/clear/), y guarda una copia sin firmas.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Para eliminar solo una firma, llame a [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignaturecollection/remove_at/) con su índice basado en cero. Guarde en un archivo nuevo a menos que sobrescribir el original firmado sea una parte explícita de su flujo de trabajo.

## **Consideraciones de edición y formato**

- Una firma no hace que una presentación sea de solo lectura. Los usuarios y las aplicaciones pueden seguir editando el archivo, pero los cambios en el contenido firmado normalmente invalidan la firma existente.
- Complete todas las ediciones previstas antes de firmar. Si la presentación debe modificarse, guarde la versión revisada y firme esa revisión nuevamente.
- Mantenga el resultado final en formato PPTX. Convertir una presentación firmada a otro formato no transfiere la firma PPTX original como una firma válida para el archivo convertido.
- Trate la clave privada del certificado como información sensible. Cualquier persona que obtenga la clave privada y su contraseña podría crear firmas que parezcan proceder del titular del certificado.
- Conserve el origen sin firmar o una copia controlada cuando su política de retención de documentos lo requiera.

## **Preguntas frecuentes**

**¿Una firma digital cifra la presentación?**

No. Una firma digital aporta evidencia sobre el origen y la integridad, pero el contenido de la presentación sigue siendo legible a menos que se aplique un cifrado separado. Use [protección con contraseña](/python-net/password-protected-presentation/) cuando sea necesario restringir el acceso al contenido.

**¿La contraseña del PFX es la misma que la de la presentación?**

No. La contraseña del PFX desbloquea la clave privada almacenada en el paquete del certificado. No controla quién puede abrir o editar el archivo PPTX.

**¿Puedo usar un certificado autofirmado?**

Técnicamente, un certificado autofirmado puede usarse siempre que incluya una clave privada accesible. Sin embargo, los destinatarios no lo confiarán automáticamente, a menos que ese certificado se haya añadido explícitamente a su entorno de confianza. Los flujos de trabajo públicos o interorganizacionales generalmente usan un certificado emitido por una CA de confianza.

**¿Qué hace que una firma sea inválida?**

Cambiar el contenido firmado de la presentación o los datos de la firma después de la firma puede invalidar la firma. La corrupción del archivo también puede provocar que la validación falle. Si se eliminan todas las firmas, la presentación queda sin firmar en lugar de contener una firma inválida.

**¿Una firma válida implica que debo confiar en el firmante?**

No por sí sola. La integridad de la firma y la confianza en el firmante son decisiones separadas. Una política de validación en producción también debe comprobar la cadena de certificados, el período de validez, el estado de revocación, la identidad esperada, el uso de la clave y cualquier requisito de sello de tiempo confiable.

**¿Qué ocurre cuando el certificado caduca?**

La expiración del certificado no altera los bytes de la presentación, pero afecta la evaluación de confianza del certificado. Si una firma sigue siendo aceptable depende de su política y de si una marca de tiempo confiable demuestra que la firma se realizó mientras el certificado estaba vigente. No confíe solo en la hora mostrada de la firma como sello de tiempo confiable.

**¿Se puede seguir editando una presentación firmada?**

Sí. Firmar no bloquea el archivo. Editar el contenido firmado generalmente invalida la firma existente, por lo que se debe terminar la presentación primero y firmar la revisión final.

**¿Una presentación puede contener más de una firma?**

Sí. Añada cada firma a [Presentation.digital_signatures](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/digital_signatures/) antes de guardar. Durante la validación, inspeccione cada firma y confirme que todos los firmantes requeridos estén presentes.

**¿Qué formatos de presentación admiten estas operaciones?**

Aspose.Slides admite las operaciones de firma digital descritas aquí solo para PPTX. Los formatos PPT y OpenDocument no son compatibles con este flujo de trabajo de la API.

**¿Puedo eliminar una firma sin afectar las diapositivas?**

Sí. Puede eliminar una firma o vaciar toda la colección y luego guardar la presentación. El contenido de las diapositivas sigue disponible, pero el archivo guardado ya no contiene la evidencia de la firma eliminada.