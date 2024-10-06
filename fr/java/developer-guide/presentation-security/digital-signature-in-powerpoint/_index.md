---
title: Signature numérique dans PowerPoint
type: docs
weight: 10
url: /java/digital-signature-in-powerpoint/
keywords: "Certificat de signature numérique, autorité de certification"
description: "Ajouter un certificat de signature numérique, une autorité de certification dans une présentation PowerPoint avec Aspose.Slides."
---

**Le certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée - une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Info -> Protéger la présentation :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La présentation peut contenir plus d'une signature numérique. Après que la signature numérique ait été ajoutée à la présentation, un message spécial apparaîtra dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer la présentation ou vérifier l'authenticité des signatures de présentation, **l'API Aspose.Slides** fournit l'interface [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature), l'interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) et la méthode [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--). Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX.
## **Ajouter une signature numérique à partir d'un certificat PFX**
L'exemple de code ci-dessous démontre comment ajouter une signature numérique à partir d'un certificat PFX :

1. Ouvrir le fichier PFX et passer le mot de passe PFX à l'objet [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature).
1. Ajouter la signature créée à l'objet présentation.

```java
// Ouverture du fichier de présentation
Presentation pres = new Presentation();
try {
    // Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Commenter la nouvelle signature numérique
    signature.setComments("Test de signature numérique Aspose.Slides.");

    // Ajouter la signature numérique à la présentation
    pres.getDigitalSignatures().add(signature);

    // Sauvegarder la présentation
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

        System.out.println("Signatures utilisées pour signer la présentation : ");

        // Vérifier si toutes les signatures numériques sont valides
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALIDE" : "INVALIDE"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("La présentation est authentique, toutes les signatures sont valides.");
        else
            System.out.println("La présentation a été modifiée depuis la signature.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```