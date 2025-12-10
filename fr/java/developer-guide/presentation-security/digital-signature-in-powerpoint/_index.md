---
title: Ajouter des signatures numériques aux présentations en Java
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/java/digital-signature-in-powerpoint/
keywords:
- signature numérique
- certificat numérique
- autorité de certification
- certificat PFX
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment signer numériquement les fichiers PowerPoint & OpenDocument avec Aspose.Slides pour Java. Sécurisez vos diapositives en quelques secondes grâce à des exemples de code clairs."
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Infos -> Protéger la présentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La présentation peut contenir plusieurs signatures numériques. Après qu’une signature numérique a été ajoutée à la présentation, un message spécial apparaîtra dans PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l'authenticité des signatures d'une présentation, **Aspose.Slides API** fournit l'interface [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature), l'interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) et la méthode [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX.

## **Ajouter une signature numérique à partir d'un certificat PFX**
L'exemple de code ci‑dessous montre comment ajouter une signature numérique à partir d'un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l'objet [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature).
2. Ajoutez la signature créée à l'objet présentation.
```java
// Ouverture du fichier de présentation
Presentation pres = new Presentation();
try {
    // Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Commenter la nouvelle signature numérique
    signature.setComments("Aspose.Slides digital signing test.");

    // Ajouter la signature numérique à la présentation
    pres.getDigitalSignatures().add(signature);

    // Enregistrer la présentation
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Il est maintenant possible de vérifier si la présentation a été signée numériquement et n'a pas été modifiée :
```java
// Ouvrir la présentation
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Vérifier si toutes les signatures numériques sont valides
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je supprimer les signatures existantes d'un fichier ?**

Oui. La collection de signatures numériques prend en charge la [suppression d'éléments individuels](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) et le [effacement complet](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#clear--) ; après avoir enregistré le fichier, la présentation n’aura aucune signature.

**Le fichier devient‑il « lecture‑seule » après la signature ?**

Non. Une signature préserve l'intégrité et l'attribution mais ne bloque pas les modifications. Pour restreindre l'édition, combinez‑la avec ["Lecture‑seule" ou un mot de passe](/slides/fr/java/password-protected-presentation/).

**La signature s'affichera‑t‑elle correctement dans différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions modernes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l'état de ces signatures.