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
description: "Apprenez à signer numériquement des fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Sécurisez vos diapositives en quelques secondes avec des exemples de code clairs."
---
## **Introduction**

**certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, indiquant qu'elle a été créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Info -> Protéger la présentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Une présentation peut contenir plusieurs signatures numériques. Après qu'une signature numérique a été ajoutée à la présentation, un message spécial apparaît dans PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l'authenticité des signatures de présentation, **Aspose.Slides API** fournit la classe [**DigitalSignature**](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/), la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/fr/python-net/aspose.slides/DigitalSignatureCollection/) et la propriété [**Presentation.digital_signatures**](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/digital_signatures/). Actuellement, les signatures numériques sont prises en charge uniquement pour le format PPTX.

## **Ajouter