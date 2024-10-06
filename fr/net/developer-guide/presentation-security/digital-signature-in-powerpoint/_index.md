---
title: Signature numérique dans PowerPoint
type: docs
weight: 10
url: /net/digital-signature-in-powerpoint/
keywords: "Certificat de signature numérique, autorité de certification, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter une signature numérique ou un certificat dans PowerPoint. Autorité de certification en C# ou .NET"
---

**Certificat numérique** est utilisé pour créer une présentation PowerPoint protégée par un mot de passe, marquée comme créée par une organisation ou une personne particulière. Le certificat numérique peut être obtenu en contactant une organisation autorisée - une autorité de certification. Après l'installation du certificat numérique dans le système, il peut être utilisé pour ajouter une signature numérique à la présentation via Fichier -> Informations -> Protéger la présentation :

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La présentation peut contenir plus d'une signature numérique. Après l'ajout de la signature numérique à la présentation, un message spécial apparaîtra dans PowerPoint :

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Pour signer une présentation ou vérifier l'authenticité des signatures de la présentation, **Aspose.Slides API** fournit [**IDigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)interface, [**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)interface et[ **IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) propriété. Actuellement, les signatures numériques ne sont prises en charge que pour le format PPTX.

## **Ajouter une signature numérique à partir d'un certificat PFX**
L'exemple de code ci-dessous démontre comment ajouter une signature numérique à partir d'un certificat PFX :

1. Ouvrir le fichier PFX et passer le mot de passe PFX à l'objet [**DigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature).
1. Ajouter la signature créée à l'objet présentation.

```c#
using (Presentation pres = new Presentation())
{
    // Créer un objet DigitalSignature avec le fichier PFX et le mot de passe PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Commenter la nouvelle signature numérique
    signature.Comments = "Test de signature numérique Aspose.Slides.";

    // Ajouter la signature numérique à la présentation
    pres.DigitalSignatures.Add(signature);

    // Sauvegarder la présentation
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```

Il est maintenant possible de vérifier si la présentation a été signée numériquement et n'a pas été modifiée :

```c#
// Ouvrir la présentation
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures utilisées pour signer la présentation : ");

        // Vérifier si toutes les signatures numériques sont valides
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("La présentation est authentique, toutes les signatures sont valides.");
        else
            Console.WriteLine("La présentation a été modifiée depuis la signature.");
    }
}
```