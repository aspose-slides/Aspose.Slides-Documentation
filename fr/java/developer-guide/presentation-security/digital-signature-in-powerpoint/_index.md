---
title: Ajouter des signatures numériques aux présentations en Java
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/java/digital-signature-in-powerpoint/
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
- Java
- Aspose.Slides
description: "Apprenez comment signer des présentations PPTX existantes avec des certificats PFX et utiliser Aspose.Slides pour Java afin de valider ou de supprimer des signatures numériques."
---
## **Vue d'ensemble**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a changé. Trois concepts de sécurité liés sont importants ici :

- Un **certificat numérique** est un justificatif électronique qui associe une identité à une clé publique. Une autorité de certification (CA) de confiance peut délivrer un certificat, ou une organisation peut utiliser un certificat auto‑signé pour les flux de travail internes.
- Une **signature numérique** est créée à partir du contenu de la présentation et de la clé privée du titulaire du certificat. La clé publique du certificat peut ensuite être utilisée pour vérifier la signature. Une signature fournit une preuve d'origine et d'intégrité ; elle ne chiffre pas la présentation.
- La **protection par mot de passe** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Présentations protégées par mot de passe](/slides/fr/java/password-protected-presentation/).

PowerPoint propose la commande **Ajouter une signature numérique** sous **Fichier > Infos > Protéger la présentation**.

![Menu Protéger la présentation de PowerPoint avec Ajouter une signature numérique mis en surbrillance](add-digital-signature-in-powerpoint.png)

Après l'ouverture d'une présentation signée, PowerPoint peut afficher une notification d’état de la signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--), qui renvoie une [IDigitalSignatureCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignaturecollection/) dont les éléments implémentent [IDigitalSignature](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement nommé avec l'extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée est ce qui permet au titulaire de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le package du certificat et la clé privée. Ce n’est **pas** un mot de passe pour ouvrir ou modifier la présentation. Ne pas valider les fichiers PFX ou leurs mots de passe dans le contrôle de version. En production, limitez l’accès au fichier de certificat et récupérez son mot de passe depuis un magasin de secrets ou une autre source de configuration protégée. Les exemples ci‑dessous utilisent uniquement une variable d’environnement pour éviter d’incorporer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer le flux de travail d’une présentation réelle, chargez un fichier PPTX existant, créez un [DigitalSignature](https://reference.aspose.com/slides/fr/java/com.aspose.slides/digitalsignature/) à partir d’un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez le fichier au format PPTX.

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En enregistrant le résultat sous un nouveau nom, vous conservez le fichier source non signé. La valeur définie par [IDigitalSignature.setComments](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) décrit le but de la signature ; ce n’est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, inspectez chaque élément renvoyé par [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--). La méthode [IDigitalSignature.isValid](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignature/#isValid--) indique si la signature intégrée est valide pour le contenu actuel de la présentation.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

Un résultat invalide signifie généralement que le contenu signé de la présentation ou les données de la signature ont été modifiés après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, ainsi vérifier uniquement la validité des éléments n’est pas suffisant : un flux de travail sensible à la sécurité doit également vérifier que le nombre attendu de signatures et les identités des signataires attendues sont présentes.

Ce résultat de validité ne doit pas être considéré comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également devoir construire et valider la chaîne de certificats X.509, vérifier les dates de validité du certificat et son statut de révocation, confirmer le sujet ou l’empreinte attendus, vérifier l’usage de la clé et évaluer un horodatage de confiance. La valeur de [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignature/#getSignTime--) n’est pas, à elle seule, une preuve d’une autorité d’horodatage de confiance.

## **Supprimer les signatures numériques**

Supprimer les signatures modifie l’état de sécurité de la présentation. L’exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignaturecollection/#clear--), et enregistre une copie non signée.

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour ne supprimer qu’une seule signature, appelez [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-) avec son indice zéro‑base. Enregistrez dans un nouveau fichier sauf si l’écrasement du fichier signé original fait partie explicite de votre flux de travail.

## **Considérations de modification et de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les changements du contenu signé invalident généralement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la version révisée et signez à nouveau cette révision.
- Conservez le résultat final au format PPTX. Convertir une présentation signée dans un autre format ne transfère pas la signature PPTX originale comme une signature valide pour le fichier converti.
- Considérez la clé privée du certificat comme sensible. Toute personne qui obtient la clé privée et son mot de passe peut créer des signatures qui semblent provenir du titulaire du certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de conservation des documents l’exige.

## **FAQ**

**Une signature numérique chiffre‑t‑elle la présentation ?**  

Non. Une signature numérique fournit une preuve d’origine et d’intégrité, mais le contenu de la présentation reste lisible sauf si un chiffrement distinct est appliqué. Utilisez [protection par mot de passe](/slides/fr/java/password-protected-presentation/) lorsque l’accès au contenu doit être restreint.

**Le mot de passe PFX est‑il identique au mot de passe d’une présentation ?**  

Non. Le mot de passe PFX déverrouille la clé privée stockée dans le package du certificat. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**  

Techniquement, un certificat auto‑signé peut être utilisé lorsqu’il inclut une clé privée accessible. Les destinataires ne le feront pas automatiquement confiance, sauf s’il a été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisations utilisent généralement un certificat délivré par une CA de confiance.

**Qu’est‑ce qui rend une signature invalide ?**  

Modifier le contenu signé de la présentation ou les données de la signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de validation. Si toutes les signatures sont supprimées, la présentation est non signée plutôt que contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**  

Pas uniquement. L’intégrité de la signature et la confiance envers le signataire sont des décisions séparées. Une politique de validation en production doit également vérifier la chaîne de certificats, la période de validité, le statut de révocation, l’identité attendue, l’usage de la clé et les exigences éventuelles d’un horodatage de confiance.

**Que se passe‑t‑il lorsque le certificat expire ?**  

L’expiration du certificat n’altère pas les octets de la présentation, mais elle affecte l’évaluation de la confiance du certificat. La pertinence d’une signature dépend de votre politique et du fait qu’un horodatage de confiance valide prouve que la signature a été apposée alors que le certificat était encore valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage de confiance.

**Une présentation signée peut‑elle encore être modifiée ?**  

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, il faut donc terminer la présentation avant de signer la version finale.

**Une présentation peut‑elle contenir plusieurs signatures ?**  

Oui. Ajoutez chaque signature à la collection renvoyée par [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) avant d’enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**  

Aspose.Slides prend en charge les opérations de signature numérique décrites ici uniquement pour le format PPTX. Les formats PPT et OpenDocument ne sont pas pris en charge par ce flux de travail API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**  

Oui. Vous pouvez supprimer une seule signature ou vider toute la collection, puis enregistrer la présentation. Le contenu des diapositives reste présent, mais le fichier enregistré ne contient plus la preuve de la signature supprimée.