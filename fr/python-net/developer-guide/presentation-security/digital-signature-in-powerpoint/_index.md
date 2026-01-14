---
title: Ajouter des signatures numériques aux présentations avec Python
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/python-net/digital-signature-in-powerpoint/
keywords:
- signature numérique
- certificat numérique
- autorité de certification
- certificat PFX
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Apprenez à signer numériquement les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Sécurisez vos diapositives en quelques secondes grâce à des exemples de code clairs."
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, indiquée comme créée par une organisation ou une personne spécifique. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier → Infos → Protéger la présentation :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La présentation peut contenir plusieurs signatures numériques. Après l’ajout de la signature numérique à la présentation, un message spécial apparaîtra dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l’authenticité des signatures de la présentation, **Aspose.Slides API** fournit la classe [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/), la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/DigitalSignatureCollection/) et la propriété [**Presentation.digital_signatures**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/digital_signatures/). Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX.

## **Ajouter une signature numérique à partir d'un certificat PFX**
L’exemple de code ci‑dessous montre comment ajouter une signature numérique à partir d’un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l’objet [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/).
1. Ajoutez la signature créée à l’objet présentation.
```py
#[TODO:Exception] RuntimeError : Erreur de proxy (FileNotFoundException) : Impossible de charger le fichier ou l'assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. Le fichier est introuvable.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Créer l'objet DigitalSignature avec le fichier PFX et le mot de passe PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Commenter la nouvelle signature numérique
    signature.comments = "Aspose.Slides digital signing test."

    # Ajouter la signature numérique à la présentation
    pres.digital_signatures.add(signature)

    # Enregistrer la présentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```


Il est maintenant possible de vérifier si la présentation a été signée numériquement et n’a pas été modifiée :
```py
# Ouvrir la présentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Vérifier si toutes les signatures numériques sont valides
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

**Puis‑je supprimer les signatures existantes d’un fichier ?**

Oui. La collection de signatures numériques prend en charge la [suppression d’éléments individuels](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) et le [vidage complet](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/) ; après avoir enregistré le fichier, la présentation ne contiendra aucune signature.

**Le fichier devient‑il « lecture‑seule » après la signature ?**

Non. Une signature préserve l’intégrité et l’auteur, mais ne bloque pas les modifications. Pour restreindre l’édition, combinez‑la avec le mode [« Lecture‑seule » ou un mot de passe](/slides/fr/python-net/password-protected-presentation/).

**La signature s’affichera‑t‑elle correctement dans différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions modernes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l’état de ces signatures.