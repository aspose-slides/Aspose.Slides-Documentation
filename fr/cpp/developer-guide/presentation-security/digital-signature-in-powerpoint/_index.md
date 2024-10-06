---
title: Signature numérique dans PowerPoint
type: docs
weight: 10
url: /cpp/digital-signature-in-powerpoint/
keywords: "Certificat de signature numérique, autorité de certification"
description: "Ajoutez un certificat de signature numérique, une autorité de certification dans une présentation PowerPoint avec Aspose.Slides."
---


**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée - une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Informations -> Protéger la présentation :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



La présentation peut contenir plus d'une signature numérique. Après qu'une signature numérique soit ajoutée à la présentation, un message spécial apparaîtra dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Pour signer la présentation ou vérifier l'authenticité des signatures de la présentation, **Aspose.Slides API** fournit [**IDigitalSignature** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature)interface, [**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection)interface et[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1) méthode. Actuellement, les signatures numériques sont prises en charge uniquement pour le format PPTX.
## **Ajouter une signature numérique à partir du certificat PFX**
L'exemple de code ci-dessous démontre comment ajouter une signature numérique à partir d'un certificat PFX :

1. Ouvrez le fichier PFX et passez le mot de passe PFX au [**DigitalSignature** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature)object.
1. Ajoutez la signature créée à l'objet présentation.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Commentaire sur la nouvelle signature numérique
signature->set_Comments(u"Test de signature numérique Aspose.Slides.");

// Ajouter la signature numérique à la présentation
pres->get_DigitalSignatures()->Add(signature);

// Enregistrer la présentation
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Maintenant, il est possible de vérifier si la présentation a été signée numériquement et n'a pas été modifiée :

``` cpp
// Ouvrir la présentation
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures utilisées pour signer la présentation : ");

    // Vérifiez si toutes les signatures numériques sont valides
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALIDE") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"La présentation est authentique, toutes les signatures sont valides.");
    }
    else
    {
        Console::WriteLine(u"La présentation a été modifiée depuis la signature.");
    }
}
```