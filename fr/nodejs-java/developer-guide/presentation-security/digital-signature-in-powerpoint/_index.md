---
title: Signature numérique dans PowerPoint
type: docs
weight: 10
url: /fr/nodejs-java/digital-signature-in-powerpoint/
keywords: "Certificat de signature numérique, autorité de certification"
description: "Ajoutez le certificat de signature numérique et l'autorité de certification à la présentation PowerPoint avec Aspose.Slides."
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée - une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Infos -> Protéger la présentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Une présentation peut contenir plusieurs signatures numériques. Après l’ajout de la signature numérique à la présentation, un message spécial apparaît dans PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l’authenticité des signatures de la présentation, **Aspose.Slides API** fournit la classe [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature), la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignatureCollection) et la méthode [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX uniquement.

## **Ajouter une signature numérique à partir d’un certificat PFX**
L’exemple de code ci‑dessous montre comment ajouter une signature numérique à partir d’un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l’objet [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature) .
2. Ajoutez la signature créée à l’objet présentation.
```javascript
// Ouverture du fichier de présentation
var pres = new aspose.slides.Presentation();
try {
    // Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Commentaire de la nouvelle signature numérique
    signature.setComments("Aspose.Slides digital signing test.");
    // Ajouter la signature numérique à la présentation
    pres.getDigitalSignatures().add(signature);
    // Enregistrer la présentation
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Il est maintenant possible de vérifier si la présentation a été signée numériquement et n’a pas été modifiée :
```javascript
// Ouvrir la présentation
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Vérifier si toutes les signatures numériques sont valides
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis‑je supprimer les signatures existantes d’un fichier ?**

Oui. La collection de signatures numériques prend en charge la [suppression d’éléments individuels](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) et le [vidage complet](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) ; après avoir enregistré le fichier, la présentation n’aura aucune signature.

**Le fichier devient‑il « lecture‑seule » après la signature ?**

Non. Une signature préserve l’intégrité et l’attribution, mais ne bloque pas les modifications. Pour restreindre l’édition, combinez‑la avec ["Read-only" or a password](/slides/fr/nodejs-java/password-protected-presentation/).

**La signature s’affichera‑t‑elle correctement dans différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions modernes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l’état de ces signatures.