---
title: Ajouter des signatures numériques aux présentations en C++
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/cpp/digital-signature-in-powerpoint/
keywords:
- signature numérique
- certificat numérique
- autorité de certification
- certificat PFX
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à signer numériquement les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour C++. Sécurisez vos diapositives en quelques secondes grâce à des exemples de code clairs."
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, indiquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier → Informations → Protéger la présentation :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Une présentation peut contenir plusieurs signatures numériques. Après qu’une signature numérique a été ajoutée à la présentation, un message spécial apparaît dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l’authenticité des signatures de la présentation, l’**Aspose.Slides API** fournit l’interface [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature), l’interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) et la méthode [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX uniquement.

## **Ajouter une signature numérique à partir d’un certificat PFX**
L’exemple de code ci‑dessous montre comment ajouter une signature numérique à partir d’un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l’objet [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
2. Ajoutez la signature créée à l’objet présentation.
``` cpp
auto pres = System::MakeObject<Presentation>();

// Créer l'objet DigitalSignature avec le fichier PFX et le mot de passe PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Commenter la nouvelle signature numérique
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Ajouter la signature numérique à la présentation
pres->get_DigitalSignatures()->Add(signature);

// Enregistrer la présentation
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```


Il est maintenant possible de vérifier si la présentation a été signée numériquement et n’a pas été modifiée :
``` cpp
// Ouvrir la présentation
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Vérifier si toutes les signatures numériques sont valides
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**Puis‑je supprimer les signatures existantes d’un fichier ?**

Oui. La collection de signatures numériques prend en charge [la suppression d’éléments individuels](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/) et [son vidage complet](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/); après avoir enregistré le fichier, la présentation n’aura aucune signature.

**Le fichier devient‑il « lecture seule » après la signature ?**

Non. Une signature préserve l’intégrité et la paternité mais ne bloque pas les modifications. Pour restreindre l’édition, combinez‑la avec [« lecture seule » ou un mot de passe](/slides/fr/cpp/password-protected-presentation/).

**La signature s’affichera‑t‑elle correctement dans différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions récentes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l’état de ces signatures.