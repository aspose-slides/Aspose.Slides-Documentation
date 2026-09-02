---
title: Ajouter des signatures numériques aux présentations en JavaScript
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez comment signer des présentations PPTX existantes avec des certificats PFX et utiliser Aspose.Slides pour Node.js via Java pour valider ou supprimer des signatures numériques."
---
## **Aperçu**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a été modifié. Trois concepts de sécurité liés sont importants ici :

- Un **certificat numérique** est un justificatif électronique qui associe une identité à une clé publique. Une autorité de certification (CA) fiable peut délivrer un certificat, ou une organisation peut utiliser un certificat auto‑signé pour des flux de travail internes.
- Une **signature numérique** est créée à partir du contenu de la présentation et de la clé privée du détenteur du certificat. La clé publique du certificat peut alors être utilisée pour vérifier la signature. Une signature fournit la preuve d’origine et d’intégrité ; elle n’encrypte pas la présentation.
- **Protection par mot de passe** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Présentations protégées par mot de passe](/slides/fr/nodejs-java/password-protected-presentation/).

PowerPoint propose la commande **Add a Digital Signature** sous **File > Info > Protect Presentation**.

![Menu Protéger la présentation de PowerPoint avec Ajouter une signature numérique mis en évidence](add-digital-signature-in-powerpoint.png)

Après l’ouverture d’une présentation signée, PowerPoint peut afficher une notification d’état de signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), qui renvoie une [DigitalSignatureCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignaturecollection/) contenant des objets [DigitalSignature](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement doté de l’extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée est ce qui permet au détenteur de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le paquet du certificat et la clé privée. Ce n’est **pas** un mot de passe pour ouvrir ou modifier la présentation. Ne validez pas les fichiers PFX ou leurs mots de passe dans le contrôle de version. En production, limitez l’accès au fichier de certificat et récupérez son mot de passe depuis un magasin de secrets ou une autre source de configuration protégée. Les exemples ci‑dessous utilisent une variable d’environnement uniquement pour éviter d’insérer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer un flux de travail de présentation réel, chargez un fichier PPTX existant, créez une [DigitalSignature](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) à partir d’un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez‑la dans un fichier PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En enregistrant le résultat sous un nouveau nom, le fichier source non signé est conservé. La valeur définie par [DigitalSignature.setComments](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) décrit le but de la signature ; ce n’est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, examinez chaque élément renvoyé par [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). La méthode [DigitalSignature.isValid](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) indique si la signature incorporée est valide pour le contenu actuel de la présentation.

L’exemple suivant utilise également la classe Node.js `X509Certificate` pour lire le nom du sujet de chaque certificat incorporé.

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Un résultat invalide signifie généralement que le contenu signé de la présentation ou les données de la signature ont été modifiés après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, de sorte que vérifier uniquement la validité des éléments n’est pas suffisant : un flux de travail sensible à la sécurité doit aussi vérifier que le nombre attendu de signatures et les identités des signataires attendus sont présents.

Ce résultat de validité ne doit pas être traité comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également devoir construire et valider la chaîne de certificats X.509, vérifier les dates de validité et le statut de révocation du certificat, confirmer le sujet ou l’empreinte attendu·e, vérifier l’usage de la clé et évaluer un horodatage de confiance. La valeur [DigitalSignature.getSignTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) seule n’est pas une preuve provenant d’une autorité d’horodatage de confiance.

## **Supprimer les signatures numériques**

Supprimer des signatures modifie l’état de sécurité de la présentation. L’exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), puis enregistre une copie non signée.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour ne supprimer qu’une seule signature, appelez [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) avec son index basé sur zéro. Enregistrez dans un nouveau fichier, sauf si l’écrasement du fichier signé original fait explicitement partie de votre flux de travail.

## **Édition et considérations de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les changements apportés au contenu signé invalident normalement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la version révisée et signez à nouveau cette révision.
- Conservez le résultat final au format PPTX. Convertir une présentation signée vers un autre format ne transfère pas la signature PPTX d’origine en tant que signature valide pour le fichier converti.
- Traitez la clé privée du certificat comme sensible. Toute personne qui obtient la clé privée et son mot de passe pourra créer des signatures qui semblent provenir du détenteur du certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de conservation des documents l’exige.

## **FAQ**

**Une signature numérique chiffre‑t‑elle la présentation ?**

Non. Une signature numérique fournit des preuves d’origine et d’intégrité, mais le contenu de la présentation reste lisible à moins qu’un chiffrement distinct ne soit appliqué. Utilisez la [protection par mot de passe](/slides/fr/nodejs-java/password-protected-presentation/) lorsque l’accès au contenu doit être restreint.

**Le mot de passe PFX est‑il identique au mot de passe de la présentation ?**

Non. Le mot de passe PFX déverrouille la clé privée stockée dans le paquet du certificat. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**

Techniquement, un certificat auto‑signé peut être utilisé lorsqu’il inclut une clé privée accessible. Les destinataires ne le feront pas automatiquement confiance, cependant, à moins que ce certificat n’ait été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisations utilisent généralement un certificat émis par une CA de confiance.

**Qu’est‑ce qui rend une signature invalide ?**

Modifier le contenu signé de la présentation ou les données de la signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de validation. Si toutes les signatures sont supprimées, la présentation devient non signée plutôt que contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**

Pas uniquement. L’intégrité de la signature et la confiance envers le signataire sont des décisions distinctes. Une politique de validation en production doit également vérifier la chaîne de certificats, la période de validité, le statut de révocation, l’identité attendue, l’usage de la clé et toute exigence d’horodatage de confiance.

**Que se passe‑t‑il lorsque le certificat expire ?**

L’expiration du certificat n’altère pas les octets de la présentation, mais elle affecte l’évaluation de la confiance du certificat. Le fait qu’une signature reste acceptable dépend de votre politique et du fait qu’un horodatage de confiance valide prouve que la signature a eu lieu alors que le certificat était valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage de confiance.

**Une présentation signée peut‑elle encore être modifiée ?**

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, il faut donc terminer la présentation avant de la signer.

**Une présentation peut‑elle contenir plusieurs signatures ?**

Oui. Ajoutez chaque signature à la collection renvoyée par [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) avant d’enregistrer. Lors de la validation, examinez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**

Aspose.Slides prend en charge les opérations de signature numérique décrites ici uniquement pour le format PPTX. Les formats PPT et OpenDocument ne sont pas pris en charge par ce flux de travail API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**

Oui. Vous pouvez supprimer une signature ou nettoyer toute la collection, puis enregistrer la présentation. Le contenu des diapositives reste disponible, mais le fichier enregistré ne comporte plus la preuve de signature supprimée.