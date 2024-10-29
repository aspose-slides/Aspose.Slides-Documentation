---
title: Signature numérique dans PowerPoint
type: docs
weight: 10
url: /fr/python-net/digital-signature-in-powerpoint/
keywords: "Certificat de signature numérique, autorité de certification, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Ajouter une signature numérique ou un certificat dans PowerPoint. Autorité de certification en Python"
---

**Le certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée - une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Informations -> Protéger la présentation :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La présentation peut contenir plus d'une signature numérique. Après l'ajout de la signature numérique à la présentation, un message spécial apparaîtra dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer la présentation ou vérifier l'authenticité des signatures de présentation, **l'API Aspose.Slides** fournit [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)interface et[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) propriété. Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX.
## **Ajouter une signature numérique depuis un certificat PFX**
L'exemple de code ci-dessous démontre comment ajouter une signature numérique à partir d'un certificat PFX :

1. Ouvrez le fichier PFX et passez le mot de passe PFX à [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)objet.
1. Ajoutez la signature créée à l'objet présentation.

```py

#[TODO:Exception] RuntimeError: Proxy error(FichierNonTrouvéException): Impossible de charger le fichier ou l'assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Le fichier est introuvable.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Commenter la nouvelle signature numérique
    signature.comments = "Test de signature numérique Aspose.Slides."

    # Ajouter la signature numérique à la présentation
    pres.digital_signatures.add(signature)

    # sauvegarder la présentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Il est maintenant possible de vérifier si la présentation a été signée numériquement et n'a pas été modifiée :

```py
# Ouvrir la présentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures utilisées pour signer la présentation : ")
        # Vérifier si toutes les signatures numériques sont valides
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("La présentation est authentique, toutes les signatures sont valides.")
        else:
            print("La présentation a été modifiée depuis la signature.")
```