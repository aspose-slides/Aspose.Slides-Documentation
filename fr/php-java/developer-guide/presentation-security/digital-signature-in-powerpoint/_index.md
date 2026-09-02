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
- PKCS#12
- validation de la signature
- PowerPoint
- PPTX
- sécurité des présentations
- PHP
- Aspose.Slides
description: "Apprenez à signer des présentations PPTX existantes avec des certificats PFX et à utiliser Aspose.Slides pour PHP via Java afin de valider ou de supprimer des signatures numériques."
---
## **Vue d'ensemble**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a été modifié. Trois concepts de sécurité connexes sont importants ici :

- Un **certificat numérique** est un credential électronique qui associe une identité à une clé publique. Une autorité de certification (CA) de confiance peut délivrer un certificat, ou une organisation peut utiliser un certificat auto‑signé pour les flux de travail internes.
- Une **signature numérique** est créée à partir du contenu de la présentation et de la clé privée du titulaire du certificat. La clé publique du certificat peut ensuite être utilisée pour vérifier la signature. Une signature fournit une preuve d’origine et d’intégrité ; elle n’encrypte pas la présentation.
- **Protection par mot de passe** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Présentations protégées par mot de passe](/php-java/password-protected-presentation/).

PowerPoint propose la commande **Ajouter une signature numérique** sous **Fichier > Info > Protéger la présentation**.

![Menu Protéger la présentation de PowerPoint avec Ajouter une signature numérique mis en évidence](add-digital-signature-in-powerpoint.png)

Après l’ouverture d’une présentation signée, PowerPoint peut afficher une notification d’état de la signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDigitalSignatures), qui renvoie une [DigitalSignatureCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignaturecollection/) dont les éléments sont représentés par des objets [DigitalSignature](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement doté de l’extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée est ce qui permet au titulaire de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le package de certificat et la clé privée. Il n’est **pas** un mot de passe pour ouvrir ou modifier la présentation. Ne commettez pas les fichiers PFX ni leurs mots de passe dans le contrôle de version. En production, limitez l’accès au fichier certificat et récupérez son mot de passe depuis un magasin secret ou une autre source de configuration protégée. Les exemples ci‑dessous utilisent une variable d’environnement uniquement pour éviter d’insérer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer un flux de travail de présentation réel, chargez un fichier PPTX existant, créez une [DigitalSignature](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignature/) à partir d’un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez‑la dans un fichier PPTX.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Enregistrez le résultat sous un nouveau nom afin de conserver le fichier source non signé. La valeur définie par [DigitalSignature::setComments](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignature/setcomments/) décrit le but de la signature ; ce n’est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, inspectez chaque élément renvoyé par [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDigitalSignatures). La méthode [DigitalSignature::isValid](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignature/isvalid/) indique si la signature intégrée est valide pour le contenu actuel de la présentation.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Un résultat invalide signifie généralement que le contenu signé de la présentation ou les données de la signature ont changé après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, donc vérifier uniquement la validité des éléments n’est pas suffisant : un flux de travail sensible à la sécurité doit aussi vérifier que le nombre attendu de signatures et les identités des signataires attendues sont présentes.

Ce résultat de validité ne doit pas être considéré comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également devoir construire et valider la chaîne de certificats X.509, vérifier les dates de validité et l’état de révocation du certificat, confirmer le sujet ou l’empreinte attendu·e, vérifier l’usage de la clé, et évaluer un horodatage de confiance. La valeur retournée par [DigitalSignature::getSignTime](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignature/getsigntime/) à elle seule n’est pas une preuve provenant d’une autorité d’horodatage de confiance.

## **Supprimer les signatures numériques**

Supprimer des signatures modifie l’état de sécurité de la présentation. L’exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignaturecollection/clear/), puis enregistre une copie non signée.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pour ne supprimer qu’une seule signature, appelez [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/digitalsignaturecollection/removeat/) en indiquant son indice basé sur zéro. Enregistrez dans un nouveau fichier sauf si l’écrasement de l’original signé fait partie explicite de votre flux de travail.

## **Considérations d'édition et de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les modifications du contenu signé invalidant généralement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la version révisée et signez à nouveau cette révision.
- Conservez la sortie finale au format PPTX. Convertir une présentation signée vers un autre format ne transfère pas la signature PPTX d’origine comme signature valide pour le fichier converti.
- Traitez la clé privée du certificat comme sensible. Toute personne qui obtient la clé privée et son mot de passe peut créer des signatures semblant provenir du titulaire du certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de rétention de documents l’exige.

## **FAQ**

**Une signature numérique chiffre-t-elle la présentation ?**

Non. Une signature numérique fournit une preuve d’origine et d’intégrité, mais le contenu de la présentation reste lisible à moins qu’un chiffrement séparé ne soit appliqué. Utilisez [protection par mot de passe](/php-java/password-protected-presentation/) lorsque l’accès au contenu doit être restreint.

**Le mot de passe PFX est‑il le même que le mot de passe d’une présentation ?**

Non. Le mot de passe PFX déverrouille la clé privée stockée dans le package de certificat. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**

Techniquement, un certificat auto‑signé peut être utilisé s’il comprend une clé privée accessible. Les destinataires ne le feront pas automatiquement confiance, sauf si ce certificat a été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisationnels utilisent généralement un certificat délivré par une CA de confiance.

**Qu’est‑ce qui rend une signature invalide ?**

Modifier le contenu signé de la présentation ou les données de la signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de validation. Si toutes les signatures sont supprimées, la présentation est non signée plutôt que contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**

Pas uniquement. L’intégrité de la signature et la confiance envers le signataire sont des décisions séparées. Une politique de validation en production doit également vérifier la chaîne de certificats, la période de validité, l’état de révocation, l’identité attendue, l’usage de la clé et toute exigence d’horodatage de confiance.

**Que se passe‑t‑il lorsque le certificat expire ?**

L’expiration du certificat n’altère pas les octets de la présentation, mais elle affecte l’évaluation de confiance du certificat. La continuité de la validité d’une signature dépend de votre politique et de la présence d’un horodatage de confiance prouvant que la signature a été apposée alors que le certificat était valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage de confiance.

**Une présentation signée peut‑elle encore être modifiée ?**

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, il faut donc terminer la présentation avant de la signer.

**Une présentation peut‑elle contenir plusieurs signatures ?**

Oui. Ajoutez chaque signature à la collection renvoyée par [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#getDigitalSignatures) avant d’enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**

Aspose.Slides prend en charge les opérations de signature numérique décrites ici uniquement pour PPTX. Les formats PPT et OpenDocument ne sont pas pris en charge par ce flux de travail d’API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**

Oui. Vous pouvez supprimer une signature ou vider toute la collection, puis enregistrer la présentation. Le contenu des diapositives reste disponible, mais le fichier enregistré ne contient plus la preuve de signature supprimée.