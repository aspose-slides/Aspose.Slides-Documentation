---
title: Ajouter des signatures numériques aux présentations en .NET
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/net/digital-signature-in-powerpoint/
keywords:
- signature numérique
- certificat numérique
- autorité de certification
- certificat PFX
- PKCS#12
- valider la signature
- PowerPoint
- PPTX
- sécurité de la présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à signer des présentations PPTX existantes avec des certificats PFX et à utiliser Aspose.Slides pour .NET afin de valider ou de supprimer des signatures numériques."
---
## **Vue d'ensemble**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a changé. Trois concepts de sécurité liés sont importants ici :

- Un **digital certificate** est un justificatif électronique qui associe une identité à une clé publique. Une autorité de certification (CA) de confiance peut émettre un certificat, ou une organisation peut utiliser un certificat auto‑signé pour les flux de travail internes.
- Une **digital signature** est créée à partir du contenu de la présentation et de la clé privée du titulaire du certificat. La clé publique du certificat peut alors être utilisée pour vérifier la signature. Une signature fournit une preuve d’origine et d’intégrité ; elle n’encrypte pas la présentation.
- **Password protection** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Password-Protected Presentations](/slides/fr/net/password-protected-presentation/).

PowerPoint propose la commande **Add a Digital Signature** sous **File > Info > Protect Presentation**.

![Menu Protéger la présentation de PowerPoint avec Ajouter une signature numérique en surbrillance](add-digital-signature-in-powerpoint.png)

Après l’ouverture d’une présentation signée, PowerPoint peut afficher une notification d’état de signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/digitalsignatures/), une [IDigitalSignatureCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/idigitalsignaturecollection/) dont les éléments implémentent [IDigitalSignature](https://reference.aspose.com/slides/fr/net/aspose.slides/idigitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement doté d’une extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée permet au titulaire de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le package de certificat et la clé privée. Il ne s’agit **pas** d’un mot de passe pour ouvrir ou modifier la présentation. Ne commettez pas les fichiers PFX ni leurs mots de passe dans le contrôle de source. En production, limitez l’accès au fichier de certificat et récupérez son mot de passe à partir d’un magasin de secrets ou d’une autre source de configuration protégée. Les exemples ci‑dessous utilisent une variable d’environnement uniquement pour éviter d’insérer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer une présentation réelle, chargez un fichier PPTX existant, créez un [DigitalSignature](https://reference.aspose.com/slides/fr/net/aspose.slides/digitalsignature/) à partir d’un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez‑la dans un fichier PPTX.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

En enregistrant le résultat sous un nouveau nom, vous conservez le fichier source non signé. La valeur [DigitalSignature.Comments](https://reference.aspose.com/slides/fr/net/aspose.slides/digitalsignature/comments/) décrit le but de la signature ; ce n’est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, inspectez chaque élément de [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/digitalsignatures/). La propriété [IDigitalSignature.IsValid](https://reference.aspose.com/slides/fr/net/aspose.slides/idigitalsignature/isvalid/) indique si la signature intégrée est valide pour le contenu actuel de la présentation.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

Un résultat invalide signifie généralement que le contenu signé de la présentation ou les données de signature ont été modifiés après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, donc vérifier uniquement la validité des éléments n’est pas suffisant : un flux de travail sensible à la sécurité doit également vérifier que le nombre attendu de signatures et les identités des signataires attendus sont présents.

Ce résultat de validité ne doit pas être considéré comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également avoir besoin de construire et valider la chaîne de certificats X.509, de vérifier les dates de validité et le statut de révocation du certificat, de confirmer le sujet ou l’empreinte attendus, de vérifier l’usage de la clé, et d’évaluer un horodatage de confiance. La valeur [IDigitalSignature.SignTime](https://reference.aspose.com/slides/fr/net/aspose.slides/idigitalsignature/signtime/) à elle seule n’est pas une preuve provenant d’une autorité d’horodatage de confiance.

## **Supprimer les signatures numériques**

Supprimer les signatures modifie l’état de sécurité de la présentation. L’exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/idigitalsignaturecollection/clear/), puis enregistre une copie non signée.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

Pour supprimer une seule signature, appelez [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides/idigitalsignaturecollection/removeat/) avec son indice basé sur zéro. Enregistrez dans un nouveau fichier sauf si l’écrasement du fichier signé original fait partie explicite de votre flux de travail.

## **Considérations de modification et de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les changements apportés au contenu signé invalident normalement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la version révisée et signez cette révision à nouveau.
- Conservez la sortie finale au format PPTX. Convertir une présentation signée dans un autre format ne transfère pas la signature PPTX originale comme une signature valide pour le fichier converti.
- Traitez la clé privée du certificat comme sensible. Toute personne qui obtient la clé privée et son mot de passe peut créer des signatures semblant provenir du titulaire du certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de conservation des documents l’exige.

## **FAQ**

**Une signature numérique chiffre‑t‑elle la présentation ?**

Non. Une signature numérique fournit une preuve d’origine et d’intégrité, mais le contenu de la présentation reste lisible à moins qu’un chiffrement séparé ne soit appliqué. Utilisez la [password protection](/slides/fr/net/password-protected-presentation/) lorsque l’accès au contenu doit être restreint.

**Le mot de passe PFX est‑il identique au mot de passe d’une présentation ?**

Non. Le mot de passe PFX déverrouille la clé privée stockée dans le package de certificat. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**

Techniquement, un certificat auto‑signé peut être utilisé lorsqu’il comprend une clé privée accessible. Les destinataires ne le feront pas automatiquement confiance, toutefois, sauf si ce certificat a été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisationnels utilisent généralement un certificat émis par une CA de confiance.

**Qu’est‑ce qui rend une signature invalide ?**

Modifier le contenu signé de la présentation ou les données de signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de validation. Si toutes les signatures sont supprimées, la présentation est non signée plutôt que contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**

Pas uniquement. L’intégrité de la signature et la confiance envers le signataire sont des décisions séparées. Une politique de validation en production doit également vérifier la chaîne de certificats, la période de validité, le statut de révocation, l’identité attendue, l’usage de la clé, et toute exigence d’horodatage de confiance.

**Que se passe‑t‑il lorsque le certificat expire ?**

L’expiration du certificat n’altère pas les octets de la présentation, mais elle affecte l’évaluation de la confiance du certificat. Le maintien de la validité d’une signature dépend de votre politique et du fait qu’un horodatage de confiance valide prouve que la signature a eu lieu alors que le certificat était valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage de confiance.

**Une présentation signée peut‑elle encore être modifiée ?**

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, il faut donc terminer la présentation avant de la signer.

**Une présentation peut‑elle contenir plusieurs signatures ?**

Oui. Ajoutez chaque signature à [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/digitalsignatures/) avant d’enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**

Aspose.Slides supporte les opérations de signature numérique décrites ici uniquement pour le format PPTX. Les formats PPT et OpenDocument ne sont pas pris en charge par ce flux de travail API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**

Oui. Vous pouvez supprimer une signature ou vider la collection entière, puis enregistrer la présentation. Le contenu des diapositives demeure accessible, mais le fichier enregistré ne comporte plus la preuve de la signature supprimée.