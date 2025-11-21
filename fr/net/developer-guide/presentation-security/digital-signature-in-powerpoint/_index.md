---
title: Signature numérique dans PowerPoint
type: docs
weight: 10
url: /fr/net/digital-signature-in-powerpoint/
keywords: "Certificat de signature numérique, autorité de certification, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter une signature numérique ou un certificat dans PowerPoint. Autorité de certification en C# ou .NET"
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée – une autorité de certification. Après avoir installé le certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Infos -> Protéger la présentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Une présentation peut contenir plusieurs signatures numériques. Après qu’une signature numérique a été ajoutée à la présentation, un message spécial apparaîtra dans PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l’authenticité des signatures de la présentation, l’**API Aspose.Slides** fournit l’interface [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) , l’interface [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) et la propriété [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) . Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX uniquement.
## **Ajouter une signature numérique à partir d’un certificat PFX**
L’exemple de code ci‑dessous montre comment ajouter une signature numérique à partir d’un certificat PFX :

1. Ouvrez le fichier PFX et transmettez le mot de passe PFX à l’objet [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature) .
1. Ajoutez la signature créée à l’objet présentation.
```c#
using (Presentation pres = new Presentation())
{
    // Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Commenter la nouvelle signature numérique
    signature.Comments = "Aspose.Slides digital signing test.";

    // Ajouter la signature numérique à la présentation
    pres.DigitalSignatures.Add(signature);

    // Enregistrer la présentation
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


Il est maintenant possible de vérifier si la présentation a été signée numériquement et n’a pas été modifiée :
```c#
// Ouvrir la présentation
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Vérifier si toutes les signatures numériques sont valides
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**Puis‑je supprimer les signatures existantes d’un fichier ?**

Oui. La collection de signatures numériques prend en charge [la suppression d’éléments individuels](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) et [son vidage complet](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/) ; après avoir enregistré le fichier, la présentation ne contiendra aucune signature.

**Le fichier devient‑il « lecture seule » après la signature ?**

Non. Une signature préserve l’intégrité et la paternité mais ne bloque pas les modifications. Pour restreindre l’édition, combinez‑la avec [« Lecture seule » ou un mot de passe](/slides/fr/net/password-protected-presentation/).

**La signature s’affichera‑t‑elle correctement dans différentes versions de PowerPoint ?**

La signature est créée pour le conteneur OOXML (PPTX). Les versions récentes de PowerPoint qui prennent en charge les signatures OOXML affichent correctement l’état de ces signatures.