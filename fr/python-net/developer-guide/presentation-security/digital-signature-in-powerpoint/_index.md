---
title: Add Digital Signatures to Presentations with Python
linktitle: Digital Signature
type: docs
weight: 10
url: /fr/python-net/digital-signature-in-powerpoint/
keywords:
- digital signature
- digital certificate
- certificate authority
- PFX certificate
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to digitally sign PowerPoint & OpenDocument files with Aspose.Slides for Python via .NET. Secure your slides in seconds with clear code examples."
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via **Fichier → Info → Protéger la présentation** :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Une présentation peut contenir plusieurs signatures numériques. Après qu'une signature numérique a été ajoutée à la présentation, un message spécial apparaît dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l'authenticité des signatures de la présentation, **Aspose.Slides API** fournit l'interface [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/), l'interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) et la propriété [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/). Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX.

## **Ajouter une signature numérique à partir d'un certificat PFX**
L’exemple de code ci‑dessous montre comment ajouter une signature numérique à partir d’un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l’objet [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
2. Ajoutez la signature créée à l’objet présentation.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Create DigitalSignature object with PFX file and PFX password 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comment new digital signature
    signature.comments = "Aspose.Slides digital signing test."

    # Add digital signature to presentation
    pres.digital_signatures.add(signature)

    # save presentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Il est maintenant possible de vérifier si la présentation a été signée numériquement et n'a pas été modifiée :

```py
# Open presentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Check if all digital signatures are valid
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Puis‑je supprimer les signatures existantes d’un fichier ?**

Oui. La collection de signatures numériques prend en charge la [suppression d’éléments individuels](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) et le [vidage complet](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/) ; après avoir enregistré le fichier, la présentation ne contiendra plus aucune signature.

**Le fichier devient‑il « lecture seule » après la signature ?**

Non. Une signature préserve l’intégrité et l’attribution, mais n’empêche pas les modifications. Pour restreindre l’édition, combinez‑la avec le mode ["Lecture seule" ou un mot de passe](/slides/fr/python-net/password-protected-presentation/).

**La signature s’affichera‑t‑elle correctement dans les différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions modernes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l’état de ces signatures.