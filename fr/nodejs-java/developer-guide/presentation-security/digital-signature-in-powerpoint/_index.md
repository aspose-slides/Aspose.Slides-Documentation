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
## **Vue d'ensemble**

Une signature numérique aide le destinataire à determiner qui a signe une presentation et si le contenu signe a change. Trois concepts de securite lies sont importants ici :

- Un **certificat numerique** est un document d'identite electronique qui associe une identite a une cle publique. Une autorite de certification (CA) de confiance peut delivrer un certificat, ou une organisation peut utiliser un certificat auto-signe pour les flux de travail internes.
- Une **signature numerique** est creee a partir du contenu de la presentation et de la cle privee du titulaire du certificat. La cle publique du certificat peut alors etre utilisee pour verifier la signature. Une signature fournit une preuve d'origine et d'integrite ; elle n'encrypte pas la presentation.
- La **protection par mot de passe** controle si un utilisateur peut ouvrir ou modifier une presentation. Elle est distincte de la signature numerique et est describee dans [Presentations protegees par mot de passe](/nodejs-java/password-protected-presentation/).

PowerPoint propose la commande **Ajouter une signature numerique** sous **Fichier > Infos > Proteger la presentation**.

![Menu Proteger la presentation de PowerPoint avec Ajouter une signature numerique mis en évidence](add-digital-signature-in-powerpoint.png)

Apres l'ouverture d'une presentation signe, PowerPoint peut afficher une notification d'etat de la signature.

![Notification PowerPoint indiquant que la presentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--), qui renvoie une [DigitalSignatureCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignaturecollection/) contenant des objets [DigitalSignature](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/). Une presentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, egalement appele fichier PKCS#12 et généralement doté d'une extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa cle privee et la chaine de certificats. La cle privee permet au titulaire de creer une signature. Un certificat sans cle privee accessible ne peut pas etre utilise pour signer une presentation.

Le mot de passe PFX protege le paquet de certificat et la cle privee. Il n'est **pas** un mot de passe pour ouvrir ou modifier la presentation. Ne pas commettre les fichiers PFX ni leurs mots de passe dans le controle de source. En production, limitez l'acces au fichier de certificat et recuperer son mot de passe depuis un magasin de secrets ou une autre source de configuration protegee. Les exemples ci-dessous utilisent une variable d'environnement uniquement pour eviter d'embedder le mot de passe dans le code.

## **Ajouter une signature numerique a une presentation**

Pour signer une presentation reale, chargez un fichier PPTX existant, creez un [DigitalSignature](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) a partir d'un certificat PFX et de son mot de passe, ajoutez la signature a la collection de la presentation, puis enregistrez dans un fichier PPTX.

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

Enregistrer le resultat sous un nouveau nom preserve le fichier source non signe. La valeur definie par [DigitalSignature.setComments](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) décrit le but de la signature ; ce n'est pas un controle de securite.

## **Valider les signatures numeriques**

Lorsque vous chargez un fichier PPTX signe, inspectez chaque element renvoye par [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--). La methode [DigitalSignature.isValid](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) indique si la signature integree est valide pour le contenu actuel de la presentation.

L'exemple suivant utilise egalement la classe Node.js `X509Certificate` pour lire le nom du sujet de chaque certificat integre.

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

Un resultat invalide signifie généralement que le contenu signe de la presentation ou les donnees de la signature ont change après la signature, ou que le fichier est endommage. Supprimer chaque signature produit une presentation non signe, donc verifier uniquement la validite des elements n'est pas suffisant : un flux de travail sensible a la securite doit egalement verifier que le nombre attendu de signatures et les identities des signataires attends sont presentes.

Ce resultat de validite ne doit pas etre considere comme une decision complete de confiance du certificat. Selon votre politique de securite, votre application peut egalement devoir construire et valider la chaine de certificats X.509, verifier les dates de validite et le statut de revocation du certificat, confirmer le sujet ou l'empreinte attends, verifier l'usage de la cle, et evaluer un horodatage de confiance. La valeur [DigitalSignature.getSignTime](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignature/) a elle seule n'est pas une preuve d'une autorite d'horodatage de confiance.

## **Supprimer les signatures numeriques**

Supprimer les signatures modifie l'etat de securite de la presentation. L'exemple suivant charge un fichier PPTX signe, supprime toutes les signatures avec [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignaturecollection/clear/), et enregistre une copie non signe.

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

Pour ne supprimer qu'une signature, appelez [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) avec son indice base sur zero. Enregistrez dans un nouveau fichier sauf si l'ecrasement du fichier signe original fait explicitement partie de votre flux de travail.

## **Considerations d'edition et de format**

- Une signature ne rend pas une presentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les modifications du contenu signe invalident généralement la signature existante.
- Effectuez toutes les modifications prevues avant de signer. Si une presentation doit etre modifiee, enregistrez la version revisee et signez a nouveau cette revision.
- Conservez la sortie finale au format PPTX. Convertir une presentation signe vers un autre format ne transfere pas la signature PPTX originale comme signature valide pour le fichier converti.
- Traitez la cle privee du certificat comme sensible. Toute personne qui obtient la cle privee et son mot de passe peut creer des signatures semblant provenir du titulaire du certificat.
- Conservez la source non signe ou une autre copie controlee lorsque votre politique de retention de documents l'exige.

## **FAQ**

**Une signature numerique chiffre-t-elle la presentation?**

Non. Une signature numerique fournit une preuve d'origine et d'integrite, mais le contenu de la presentation reste lisible sauf si un chiffrement separe est applique. Utilisez [protection par mot de passe](/nodejs-java/password-protected-presentation/) lorsque l'acces au contenu doit etre restreint.

**Le mot de passe PFX est-il le meme que le mot de passe d'une presentation?**

Non. Le mot de passe PFX deverrouille la cle privee contenue dans le paquet de certificat. Il ne controle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis-je utiliser un certificat auto-signe?**

Techniquement, un certificat auto-signe peut etre utilise lorsqu'il inclut une cle privee accessible. Cependant, les destinataires ne le feront pas automatiquement confiance, sauf si ce certificat a ete explicitement ajoute a leur environnement de confiance. Les flux de travail publics ou inter-organisationnels utilisent généralement un certificat delivre par une autorite de certification de confiance.

**Qu’est-ce qui rend une signature invalide?**

Modifier le contenu signe de la presentation ou les donnees de la signature apres la signature peut invalider la signature. La corruption du fichier peut egalement entraîner un echec de validation. Si toutes les signatures sont supprimees, la presentation est non signe plutot qu'un fichier contenant une signature invalide.

**Une signature valide signifie-t-elle que je devrais faire confiance au signataire?**

Pas uniquement. L'integrite de la signature et la confiance envers le signataire sont des decisions separees. Une politique de validation en production doit egalement verifier la chaine de certificats, la periode de validite, le statut de revocation, l'identite attendue, l'usage de la cle et toute exigence d'horodatage de confiance.

**Que se passe-t-il lorsque le certificat expire?**

L'expiration du certificat n'altere pas les octets de la presentation, mais elle affecte l'evaluation de la confiance du certificat. La validite d'une signature depend de votre politique et du fait qu'un horodatage de confiance valide prouve que la signature a ete effectuee alors que le certificat etait valide. Ne vous fiez pas uniquement a l'heure de signature affichee comme horodatage de confiance.

**Une presentation signe peut-elle encore etre modifiee?**

Oui. La signature ne verouille pas le fichier. Modifier le contenu signe rend généralement la signature existante invalide, il faut donc terminer la presentation d'abord et signer la version finale.

**Une presentation peut-elle contenir plusieurs signatures?**

Oui. Ajoutez chaque signature a la collection renvoyee par [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) avant d'enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont presents.

**Quels formats de presentation prennent en charge ces operations?**

Aspose.Slides ne prend en charge les operations de signature numerique décrites ici que pour le format PPTX. Les formats PPT et OpenDocument ne sont pas supports par ce flux de travail API.

**Puis-je supprimer une signature sans affecter les diapositives?**

Oui. Vous pouvez supprimer une signature ou vider toute la collection, puis enregistrer la presentation. Le contenu des diapositives reste disponible, mais le fichier enregistre ne contient plus la preuve de la signature supprimee.