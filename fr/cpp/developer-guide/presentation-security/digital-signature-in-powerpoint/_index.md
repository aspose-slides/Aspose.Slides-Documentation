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
- PKCS#12
- valider la signature
- PowerPoint
- PPTX
- sécurité des présentations
- C++
- Aspose.Slides
description: "Apprenez comment signer des présentations PPTX existantes avec des certificats PFX et utiliser Aspose.Slides pour C++ afin de valider ou de supprimer des signatures numériques."
---
## **Vue d'ensemble**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a été modifié. Trois concepts de sécurité liés sont importants ici :

- Un **certificat numérique** est une pièce d’identité électronique qui associe une identité à une clé publique. Une autorité de certification (CA) de confiance peut délivrer un certificat, ou une organisation peut utiliser un certificat auto‑signé pour des flux de travail internes.
- Une **signature numérique** est créée à partir du contenu de la présentation et de la clé privée du titulaire du certificat. La clé publique du certificat peut ensuite être utilisée pour vérifier la signature. Une signature fournit une preuve d’origine et d’intégrité ; elle ne chiffre pas la présentation.
- La **protection par mot de passe** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Présentations protégées par mot de passe](/slides/fr/cpp/password-protected-presentation/).

PowerPoint propose la commande **Ajouter une signature numérique** sous **Fichier > Informations > Protéger la présentation**.

![Menu Protéger la présentation de PowerPoint avec Ajouter une signature numérique mis en évidence](add-digital-signature-in-powerpoint.png)

Après l’ouverture d’une présentation signée, PowerPoint peut afficher une notification d’état de la signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_digitalsignatures/), qui renvoie une [IDigitalSignatureCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignaturecollection/) dont les éléments implémentent [IDigitalSignature](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement doté d’une extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée est ce qui permet au titulaire de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le paquet de certificats et la clé privée. Il n’est **pas** un mot de passe d’ouverture ou de modification de la présentation. Ne **committez** pas les fichiers PFX ni leurs mots de passe dans le contrôle de source. En production, limitez l’accès au fichier de certificat et récupérez son mot de passe depuis un magasin de secrets ou une autre source de configuration protégée. Les exemples ci‑dessous utilisent une variable d’environnement uniquement pour éviter d’embarquer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer un flux de travail de présentation réel, chargez un fichier PPTX existant, créez un [DigitalSignature](https://reference.aspose.com/slides/fr/cpp/aspose.slides/digitalsignature/) à partir d’un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez dans un fichier PPTX.

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Enregistrez le résultat sous un nouveau nom afin de conserver le fichier source non signé. La valeur [IDigitalSignature::set_Comments](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignature/set_comments/) décrit le but de la signature ; ce n’est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, inspectez chaque élément renvoyé par [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_digitalsignatures/). La méthode [IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignature/get_isvalid/) indique si la signature intégrée est valide pour le contenu actuel de la présentation.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

Un résultat invalide signifie généralement que le contenu de la présentation signée ou les données de la signature ont changé après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, donc vérifier uniquement la validité des éléments n’est pas suffisant : un flux de travail sensible à la sécurité doit également vérifier que le nombre attendu de signatures et les identités des signataires attendues sont présents.

Ce résultat de validité ne doit pas être considéré comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également devoir construire et valider la chaîne de certificats X.509, vérifier les dates de validité et l’état de révocation du certificat, confirmer le sujet ou l’empreinte attendus, vérifier l’usage de la clé, et évaluer un horodatage de confiance. La valeur [IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignature/get_signtime/) à elle seule n’est pas une preuve provenant d’une autorité d’horodatage de confiance.

## **Supprimer les signatures numériques**

Supprimer les signatures modifie l’état de sécurité de la présentation. L’exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignaturecollection/clear/), puis enregistre une copie non signée.

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pour supprimer une seule signature, appelez [IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idigitalsignaturecollection/removeat/) avec son indice zéro‑based. Enregistrez dans un nouveau fichier sauf si l’écrasement du fichier signé original fait explicitement partie de votre flux de travail.

## **Considérations de modification et de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les changements apportés au contenu signé invalident normalement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la version révisée et signez cette révision à nouveau.
- Conservez le résultat final au format PPTX. Convertir une présentation signée vers un autre format ne transfère pas la signature PPTX d’origine comme signature valide pour le fichier converti.
- Traitez la clé privée du certificat comme sensible. Toute personne qui obtient la clé privée et son mot de passe peut créer des signatures qui semblent provenir du titulaire du certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de rétention de documents l’exige.

## **FAQ**

**Une signature numérique chiffre‑t‑elle la présentation ?**

Non. Une signature numérique fournit une preuve d’origine et d’intégrité, mais le contenu de la présentation demeure lisible sauf si un chiffrement séparé est appliqué. Utilisez [protection par mot de passe](/slides/fr/cpp/password-protected-presentation/) lorsque l’accès au contenu doit être restreint.

**Le mot de passe PFX est‑il le même que le mot de passe d’une présentation ?**

Non. Le mot de passe PFX déverrouille la clé privée stockée dans le paquet de certificats. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**

Techniquement, un certificat auto‑signé peut être utilisé lorsqu’il inclut une clé privée accessible. Les destinataires ne le feront pas automatiquement confiance, sauf s’il a été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisationnels utilisent généralement un certificat délivré par une CA de confiance.

**Qu’est‑ce qui rend une signature invalide ?**

Modifier le contenu de la présentation signé ou les données de la signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de validation. Si toutes les signatures sont supprimées, la présentation est non signée plutôt que contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**

Pas uniquement. L’intégrité de la signature et la confiance envers le signataire sont des décisions séparées. Une politique de validation en production doit également vérifier la chaîne de certificats, la période de validité, le statut de révocation, l’identité attendue, l’usage de la clé et toute exigence d’horodatage de confiance.

**Que se passe‑t‑il lorsque le certificat expire ?**

L’expiration du certificat n’altère pas les octets de la présentation, mais elle affecte l’évaluation de la confiance du certificat. La persistance d’une signature dépend de votre politique et du fait qu’un horodatage de confiance valide montre que la signature a eu lieu alors que le certificat était valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage de confiance.

**Une présentation signée peut‑elle encore être modifiée ?**

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, donc terminez d’abord la présentation et signez la version finale.

**Une présentation peut‑elle contenir plusieurs signatures ?**

Oui. Ajoutez chaque signature à la collection renvoyée par [IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_digitalsignatures/) avant d’enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**

Aspose.Slides prend en charge les opérations de signature numérique décrites ici uniquement pour PPTX. Les formats PPT et OpenDocument ne sont pas pris en charge par ce flux de travail d’API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**

Oui. Vous pouvez supprimer une signature ou vider toute la collection, puis enregistrer la présentation. Le contenu des diapositives reste disponible, mais le fichier enregistré ne porte plus la preuve de signature supprimée.