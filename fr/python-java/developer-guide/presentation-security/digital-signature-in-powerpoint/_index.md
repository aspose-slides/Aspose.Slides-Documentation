---
title: Ajouter des signatures numériques aux présentations en Python
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/python-java/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Apprenez comment signer des présentations PPTX existantes avec des certificats PFX et utiliser Aspose.Slides pour Python via Java afin de valider ou de supprimer des signatures numériques."
---
## **Vue d'ensemble**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a été modifié. Trois concepts de sécurité associés sont importants ici :

- Un **certificat numérique** est un justificatif électronique qui associe une identité à une clé publique. Une autorité de certification (CA) de confiance peut délivrer un certificat, ou une organisation peut utiliser un certificat auto-signé pour les flux de travail internes.
- Une **signature numérique** est créée à partir du contenu de la présentation et de la clé privée du détenteur du certificat. La clé publique du certificat peut ensuite être utilisée pour vérifier la signature. Une signature fournit une preuve d'origine et d'intégrité; elle n'encrypte pas la présentation.
- **Protection par mot de passe** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Password-Protected Presentations](/slides/fr/python-java/password-protected-presentation/).

PowerPoint propose la commande **Add a Digital Signature** sous **File > Info > Protect Presentation**.

![Menu PowerPoint Protéger la présentation avec Ajouter une signature numérique mis en évidence](add-digital-signature-in-powerpoint.png)

Après l'ouverture d'une présentation signée, PowerPoint peut afficher une notification d'état de signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDigitalSignatures), qui renvoie une [DigitalSignatureCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignaturecollection/) dont les éléments sont des instances de [DigitalSignature](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement doté d’une extension `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée est ce qui permet au détenteur de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le paquet de certificat et la clé privée. Ce n’est **pas** un mot de passe pour ouvrir ou modifier la présentation. Ne validez pas les fichiers PFX ni leurs mots de passe dans le contrôle de source. En production, limitez l’accès au fichier de certificat et récupérez son mot de passe à partir d’un magasin de secrets ou d’une autre source de configuration protégée. Les exemples ci-dessous utilisent une variable d’environnement uniquement pour éviter d’intégrer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer une présentation réelle, chargez un fichier PPTX existant, créez une [DigitalSignature](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignature/) à partir d’un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez le fichier au format PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Enregistrer le résultat sous un nouveau nom préserve le fichier source non signé. La valeur définie par [DigitalSignature.setComments](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignature/#setComments) décrit le but de la signature ; ce n’est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, inspectez chaque élément renvoyé par [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDigitalSignatures). La méthode [DigitalSignature.isValid](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignature/#isValid) indique si la signature intégrée est valide pour le contenu actuel de la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

Un résultat invalide signifie généralement que le contenu signé de la présentation ou les données de la signature ont changé après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, ainsi vérifier uniquement la validité des éléments n’est pas suffisant : un flux de travail sensible à la sécurité doit également vérifier que le nombre attendu de signatures et les identités des signataires attendues sont présentes.

Ce résultat de validité ne doit pas être considéré comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également devoir construire et valider la chaîne de certificats X.509, vérifier les dates de validité du certificat et son statut de révocation, confirmer le sujet ou l’empreinte attendus, vérifier l’usage de la clé, et évaluer un horodatage fiable. La valeur [DigitalSignature.getSignTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignature/#getSignTime) à elle seule ne constitue pas une preuve provenant d’une autorité d’horodatage fiable.

## **Supprimer les signatures numériques**

Supprimer des signatures modifie l’état de sécurité de la présentation. L’exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignaturecollection/#clear), puis enregistre une copie non signée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour supprimer une seule signature, appelez [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/digitalsignaturecollection/#removeAt) avec son indice basé à zéro. Enregistrez dans un nouveau fichier sauf si l’écrasement du original signé fait partie explicite de votre flux de travail.

## **Considérations de modification et de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les changements du contenu signé invalident généralement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la présentation révisée et signez à nouveau cette révision.
- Conservez le résultat final au format PPTX. Convertir une présentation signée vers un autre format ne transfère pas la signature PPTX originale en tant que signature valide pour le fichier converti.
- Traitez la clé privée du certificat comme sensible. Toute personne qui obtient la clé privée et son mot de passe peut créer des signatures qui semblent provenir du titulaire du certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de conservation des documents l’exige.

## **FAQ**

**Une signature numérique chiffre‑t‑elle la présentation ?**

Non. Une signature numérique fournit une preuve d'origine et d'intégrité, mais le contenu de la présentation reste lisible à moins qu'un chiffrement séparé ne soit appliqué. Utilisez la [protection par mot de passe](/slides/fr/python-java/password-protected-presentation/) lorsque l'accès au contenu doit être restreint.

**Le mot de passe PFX est‑il le même que le mot de passe de la présentation ?**

Non. Le mot de passe PFX débloque la clé privée stockée dans le paquet de certificat. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**

Techniquement, un certificat auto-signé peut être utilisé s’il inclut une clé privée accessible. Les destinataires ne le feront pas automatiquement confiance, cependant, sauf si ce certificat a été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisationnels utilisent généralement un certificat délivré par une autorité de certification de confiance.

**Qu’est‑ce qui rend une signature invalide ?**

Modifier le contenu signé de la présentation ou les données de la signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de validation. Si toutes les signatures sont supprimées, la présentation est non signée plutôt que contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**

Pas uniquement. L’intégrité de la signature et la confiance envers le signataire sont des décisions séparées. Une politique de validation en production doit également vérifier la chaîne de certificat, la période de validité, le statut de révocation, l’identité attendue, l’usage de la clé, et toute exigence d’horodatage fiable.

**Que se passe‑t‑il lorsque le certificat expire ?**

L’expiration du certificat n’altère pas les octets de la présentation, mais elle affecte l’évaluation de la confiance du certificat. Le fait qu’une signature reste acceptable dépend de votre politique et de la présence d’un horodatage fiable prouvant que la signature a eu lieu alors que le certificat était valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage fiable.

**Une présentation signée peut‑elle encore être modifiée ?**

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, donc terminez d’abord la présentation et signez la version finale.

**Une présentation peut‑elle contenir plusieurs signatures ?**

Oui. Ajoutez chaque signature à la collection renvoyée par [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDigitalSignatures) avant d’enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**

Aspose.Slides prend en charge les opérations de signature numérique décrites ici uniquement pour PPTX. Les formats PPT et OpenDocument ne sont pas supportés par ce flux de travail API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**

Oui. Vous pouvez supprimer une signature ou vider l’ensemble de la collection, puis enregistrer la présentation. Le contenu des diapositives reste disponible, mais le fichier enregistré ne contient plus la preuve de signature supprimée.