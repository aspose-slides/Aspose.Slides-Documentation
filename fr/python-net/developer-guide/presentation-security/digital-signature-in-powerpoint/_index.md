---
title: Ajouter des signatures numériques aux présentations en Python
linktitle: Signature numérique
type: docs
weight: 10
url: /fr/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "Découvrez comment signer des présentations PPTX existantes avec des certificats PFX et utiliser Aspose.Slides pour Python via .NET afin de valider ou de supprimer des signatures numériques."
---
## **Vue d'ensemble**

Une signature numérique aide le destinataire à déterminer qui a signé une présentation et si le contenu signé a été modifié. Trois concepts de sécurité liés sont importants ici :

- Un **certificat numérique** est un justificatif électronique qui associe une identité à une clé publique. Une autorité de certification (CA) de confiance peut délivrer un certificat, ou une organisation peut utiliser un certificat auto‑signé pour des flux de travail internes.
- Une **signature numérique** est créée à partir du contenu de la présentation et de la clé privée du détenteur du certificat. La clé publique du certificat peut ensuite être utilisée pour vérifier la signature. Une signature fournit une preuve d'origine et d'intégrité ; elle n'encrypte pas la présentation.
- **La protection par mot de passe** contrôle si un utilisateur peut ouvrir ou modifier une présentation. Elle est distincte de la signature numérique et est décrite dans [Presentations protégées par mot de passe](/python-net/password-protected-presentation/).

PowerPoint propose la commande **Ajouter une signature numérique** sous **Fichier > Infos > Protéger la présentation**.

![Menu Protéger la présentation PowerPoint avec Ajouter une signature numérique mis en évidence](add-digital-signature-in-powerpoint.png)

Après l'ouverture d'une présentation signée, PowerPoint peut afficher une notification d'état de la signature.

![Notification PowerPoint indiquant que la présentation contient des signatures valides](digital-signature-status-in-powerpoint.png)

Aspose.Slides expose les signatures via [Presentation.digital_signatures](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/digital_signatures/), une [DigitalSignatureCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignaturecollection/) dont les éléments sont des objets [DigitalSignature](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/). Une présentation peut contenir plusieurs signatures.

## **Comprendre les certificats PFX et les mots de passe**

Un fichier PFX, également appelé fichier PKCS#12 et généralement porté les extensions `.pfx` ou `.p12`, peut contenir un certificat X.509, sa clé privée et la chaîne de certificats. La clé privée est ce qui permet au détenteur de créer une signature. Un certificat sans clé privée accessible ne peut pas être utilisé pour signer une présentation.

Le mot de passe PFX protège le paquet de certificat et la clé privée. Ce n'est **pas** un mot de passe pour ouvrir ou modifier la présentation. Ne validez pas les fichiers PFX ou leurs mots de passe dans le contrôle de version. En production, limitez l'accès au fichier de certificat et récupérez son mot de passe à partir d'un gestionnaire de secrets ou d'une autre source de configuration protégée. Les exemples ci-dessous utilisent une variable d'environnement uniquement pour éviter d'intégrer le mot de passe dans le code.

## **Ajouter une signature numérique à une présentation**

Pour signer un flux de travail de présentation réel, chargez un fichier PPTX existant, créez un [DigitalSignature](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/) à partir d'un certificat PFX et de son mot de passe, ajoutez la signature à la collection de la présentation, puis enregistrez le fichier au format PPTX.

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

Enregistrer le résultat sous un nouveau nom préserve le fichier source non signé. La valeur [DigitalSignature.comments](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/comments/) décrit le but de la signature ; ce n'est pas un contrôle de sécurité.

## **Valider les signatures numériques**

Lorsque vous chargez un fichier PPTX signé, inspectez chaque élément dans [Presentation.digital_signatures](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/digital_signatures/). La propriété [DigitalSignature.is_valid](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/is_valid/) indique si la signature intégrée est valide pour le contenu actuel de la présentation.

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

Un résultat invalide signifie généralement que le contenu signé de la présentation ou les données de la signature ont été modifiés après la signature, ou que le fichier est endommagé. Supprimer toutes les signatures produit une présentation non signée, ainsi vérifier uniquement la validité des éléments n'est pas suffisant : un flux de travail sensible à la sécurité doit également vérifier que le nombre attendu de signatures et les identités des signataires attendues sont présentes.

La propriété [DigitalSignature.certificate](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/certificate/) fournit les données du certificat sous forme de tableau d’octets. L'exemple calcule son empreinte SHA‑256 afin qu'une application puisse la comparer à l'empreinte d'un certificat de signataire attendu.

Ce résultat de validité ne doit pas être considéré comme une décision complète de confiance du certificat. Selon votre politique de sécurité, votre application peut également devoir construire et valider la chaîne de certificats X.509, vérifier les dates de validité et l'état de révocation du certificat, confirmer le sujet ou l'empreinte attendu, vérifier l'usage de la clé et évaluer un horodatage de confiance. La valeur [DigitalSignature.sign_time](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignature/sign_time/) à elle seule n'est pas une preuve provenant d'une autorité d'horodatage de confiance.

## **Supprimer les signatures numériques**

Supprimer les signatures modifie l'état de sécurité de la présentation. L'exemple suivant charge un fichier PPTX signé, supprime toutes les signatures avec [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignaturecollection/clear/), puis enregistre une copie non signée.

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

Pour supprimer une seule signature, appelez [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides/digitalsignaturecollection/remove_at/) avec son index basé sur zéro. Enregistrez dans un nouveau fichier sauf si l'écrasement de l'original signé fait explicitement partie de votre flux de travail.

## **Considérations de modification et de format**

- Une signature ne rend pas une présentation en lecture seule. Les utilisateurs et les applications peuvent toujours modifier le fichier, mais les changements apportés au contenu signé invalident généralement la signature existante.
- Effectuez toutes les modifications prévues avant de signer. Si une présentation doit être modifiée, enregistrez la version révisée et signez à nouveau cette révision.
- Conservez la sortie finale au format PPTX. Convertir une présentation signée vers un autre format ne transfère pas la signature PPTX originale comme une signature valide pour le fichier converti.
- Traitez la clé privée du certificat comme sensible. Quiconque obtient la clé privée et son mot de passe peut être capable de créer des signatures semblant provenir du détenteur de ce certificat.
- Conservez la source non signée ou une autre copie contrôlée lorsque votre politique de conservation des documents l'exige.

## **FAQ**

**Une signature numérique chiffre-t-elle la présentation ?**

Non. Une signature numérique fournit une preuve d'origine et d'intégrité, mais le contenu de la présentation reste lisible sauf si un chiffrement séparé est appliqué. Utilisez la [protection par mot de passe](/python-net/password-protected-presentation/) lorsque l'accès au contenu doit être restreint.

**Le mot de passe PFX est‑il le même que le mot de passe de la présentation ?**

Non. Le mot de passe PFX déverrouille la clé privée stockée dans le paquet de certificat. Il ne contrôle pas qui peut ouvrir ou modifier le fichier PPTX.

**Puis‑je utiliser un certificat auto‑signé ?**

Techniquement, un certificat auto‑signé peut être utilisé lorsqu'il comprend une clé privée accessible. Cependant, les destinataires ne le feront pas automatiquement confiance, sauf si ce certificat a été explicitement ajouté à leur environnement de confiance. Les flux de travail publics ou inter‑organisations utilisent généralement un certificat délivré par une CA de confiance.

**Qu'est‑ce qui rend une signature invalide ?**

Modifier le contenu signé de la présentation ou les données de la signature après la signature peut invalider la signature. La corruption du fichier peut également entraîner un échec de la validation. Si toutes les signatures sont supprimées, la présentation devient non signée plutôt qu'un fichier contenant une signature invalide.

**Une signature valide signifie‑t‑elle que je dois faire confiance au signataire ?**

Pas à elle seule. L'intégrité de la signature et la confiance envers le signataire sont des décisions séparées. Une politique de validation en production doit également vérifier la chaîne de certificats, la période de validité, l'état de révocation, l'identité attendue, l'usage de la clé et toute exigence d'horodatage de confiance.

**Que se passe‑t‑il lorsque le certificat expire ?**

L’expiration du certificat ne modifie pas les octets de la présentation, mais elle affecte l’évaluation de la confiance du certificat. La poursuite de la validité d’une signature dépend de votre politique et du fait qu’un horodatage de confiance valide prouve que la signature a eu lieu alors que le certificat était valide. Ne vous fiez pas uniquement à l’heure de signature affichée comme horodatage de confiance.

**Une présentation signée peut‑elle encore être modifiée ?**

Oui. La signature ne verrouille pas le fichier. Modifier le contenu signé rend généralement la signature existante invalide, il faut donc terminer la présentation d'abord et signer la révision finale.

**Une présentation peut‑elle contenir plusieurs signatures ?**

Oui. Ajoutez chaque signature à [Presentation.digital_signatures](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/digital_signatures/) avant d’enregistrer. Lors de la validation, inspectez chaque signature et confirmez que tous les signataires requis sont présents.

**Quels formats de présentation prennent en charge ces opérations ?**

Aspose.Slides prend en charge les opérations de signature numérique décrites ici uniquement pour le format PPTX. Les formats de présentation PPT et OpenDocument ne sont pas pris en charge par ce flux de travail d’API.

**Puis‑je supprimer une signature sans affecter les diapositives ?**

Oui. Vous pouvez supprimer une signature ou vider toute la collection, puis enregistrer la présentation. Le contenu des diapositives reste disponible, mais le fichier enregistré ne porte plus la preuve de la signature supprimée.