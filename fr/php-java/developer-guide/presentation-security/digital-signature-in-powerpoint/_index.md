---
title: Ajouter des signatures numériques aux présentations en PHP
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/php-java/digital-signature-in-powerpoint/
keywords:
- signature numérique
- certificat numérique
- autorité de certification
- certificat PFX
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment signer numériquement des fichiers PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java. Sécurisez vos diapositives en quelques secondes avec des exemples de code clairs."
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, indiquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Info -> Protéger la présentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Une présentation peut contenir plusieurs signatures numériques. Après qu’une signature numérique a été ajoutée à la présentation, un message spécial apparaîtra dans PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l'authenticité des signatures de la présentation, **Aspose.Slides API** fournit la classe [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature), la classe [**DigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignatureCollection) et la méthode [**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getDigitalSignatures). Actuellement, les signatures numériques sont prises en charge uniquement pour le format PPTX.
## **Ajouter une signature numérique à partir d'un certificat PFX**
Le fragment de code ci‑dessous montre comment ajouter une signature numérique à partir d'un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l'objet [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature).
2. Ajoutez la signature créée à l'objet présentation.
```php
  # Ouverture du fichier de présentation
  $pres = new Presentation();
  try {
    # Créer l'objet DigitalSignature avec le fichier PFX et le mot de passe PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Commenter la nouvelle signature numérique
    $signature->setComments("Aspose.Slides digital signing test.");
    # Ajouter la signature numérique à la présentation
    $pres->getDigitalSignatures()->add($signature);
    # Enregistrer la présentation
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Il est maintenant possible de vérifier si la présentation a été signée numériquement et n'a pas été modifiée :
```php
  # Ouvrir la présentation
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Vérifier si toutes les signatures numériques sont valides
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Puis-je supprimer les signatures existantes d'un fichier ?**

Oui. La collection de signatures numériques prend en charge la suppression d'éléments individuels et son effacement complet ; après avoir enregistré le fichier, la présentation n'aura aucune signature.

**Le fichier devient‑t‑il « lecture‑seule » après la signature ?**

Non. Une signature préserve l'intégrité et la paternité mais ne bloque pas les modifications. Pour restreindre l'édition, combinez‑la avec ["Lecture‑seule" ou un mot de passe](/slides/fr/php-java/password-protected-presentation/).

**La signature s'affichera‑t‑elle correctement dans différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions récentes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l'état de ces signatures.