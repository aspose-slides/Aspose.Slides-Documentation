---
title: Agregar firmas digitales a presentaciones con Python
linktitle: Firma digital
type: docs
weight: 10
url: /es/python-net/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad de certificación
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprende cómo firmar digitalmente archivos de PowerPoint y OpenDocument con Aspose.Slides for Python via .NET. Asegura tus diapositivas en segundos con claros ejemplos de código."
---


**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida por contraseña, marcada como creada por una organización o persona en particular. El certificado digital se puede obtener contactando a una organización autorizada - una autoridad de certificación. Después de instalar el certificado digital en el sistema, se puede utilizar para agregar una firma digital a la presentación a través de Archivo -> Información -> Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



La presentación puede contener más de una firma digital. Después de que se agrega la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Para firmar la presentación o verificar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/), la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) y la propiedad [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/). Actualmente, las firmas digitales son compatibles solo con el formato PPTX.

## **Agregar firma digital desde certificado PFX**
El siguiente ejemplo de código demuestra cómo agregar una firma digital desde un certificado PFX:

1. Abrir archivo PFX y pasar la contraseña PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
1. Agregar la firma creada al objeto de presentación.

```py

#[TODO:Exception] RuntimeError: Error de proxy(FileNotFoundException): No se pudo cargar el archivo o ensamblado 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Archivo no encontrado.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comentar nueva firma digital
    signature.comments = "Prueba de firma digital de Aspose.Slides."

    # Agregar firma digital a la presentación
    pres.digital_signatures.add(signature)

    # guardar presentación
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



Ahora es posible verificar si la presentación fue firmada digitalmente y no ha sido modificada:



```py
# Abrir presentación
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Firmas utilizadas para firmar la presentación: ")
        # Verificar si todas las firmas digitales son válidas
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VÁLIDO" if signature.is_valid else "INVALIDO")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("La presentación es genuina, todas las firmas son válidas.")
        else:
            print("La presentación ha sido modificada desde la firma.")
```