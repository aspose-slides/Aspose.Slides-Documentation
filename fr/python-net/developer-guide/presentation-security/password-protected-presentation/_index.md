---
title: Protéger les présentations par mot de passe en Python
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/python-net/password-protected-presentation/
keywords:
- présentation protégée par mot de passe
- mot de passe d'ouverture
- chiffrer PowerPoint
- déchiffrer PowerPoint
- valider le mot de passe de la présentation
- vérifier le mot de passe de la présentation
- ouvrir une présentation chiffrée
- supprimer le chiffrement
- PowerPoint
- PPT
- PPTX
- présentation
- Python
- Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et déchiffrer des présentations PowerPoint PPT et PPTX protégées par mot de passe en Python avec Aspose.Slides."
---
## **Vue d'ensemble**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est nécessaire pour charger et afficher le contenu de la présentation, ce qui assure la confidentialité.

Un mot de passe d'ouverture est différent d'un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu et n'empêche pas le chargement de la présentation. Pour gérer les mots de passe de modification des présentations, voir [Write-Protect Presentations](/slides/fr/python-net/write-protected-presentation/).

Les flux de travail ci‑dessous s’appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque leur comportement basé sur des fichiers ou des flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [ProtectionManager.encrypt](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/encrypt/) pour attribuer un mot de passe d'ouverture. Puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation chiffrée.

L’exemple suivant chiffre une présentation PPTX :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Charger une présentation chiffrée**

Définissez [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/) sur le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu’un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Travaillez avec la présentation déchiffrée.
    pass
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/remove_encryption/), puis enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) pour obtenir un [PresentationInfo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/) sans créer d’instance complète de présentation. Vérifiez [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/is_password_protected/) avant de demander ou de valider un mot de passe. Lorsque la protection est présente, validez la valeur fournie avec [PresentationInfo.check_password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/check_password/).

### **Flux de travail par chemin de fichier**

L’exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/), puis charge la présentation complète :

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Flux de travail par flux**

La surcharge flux de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) fournit le même flux de travail. Réinitialisez la position d’un flux recherchable avant de charger la présentation complète depuis ce flux.

L’exemple suivant utilise un fichier PPT :

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Valeurs de retour de CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/check_password/) renvoie `True` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Il renvoie `False` dans chacun des cas suivants :

- Le mot de passe est incorrect.
- La présentation ne possède pas de mot de passe d'ouverture.
- Le mot de passe fourni est `None` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le bon mot de passe, inspectez [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/is_encrypted/) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez `PresentationInfo.is_password_protected` comme indiqué ci‑dessus.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
Ne consignez pas les mots de passe d'ouverture et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.
{{% /alert %}}

## **Protéger par mot de passe une présentation en ligne**

1. Ouvrez l’application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléversez la présentation.
1. Saisissez un mot de passe pour la protection en lecture.
1. Saisissez éventuellement un mot de passe distinct pour la protection en écriture.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="À voir aussi" %}}
- [Write-Protect Presentations](/slides/fr/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est requis pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis‑je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez la présence d’une protection par mot de passe d'ouverture, puis validez le mot de passe avant de créer une instance complète de présentation.

**Les flux de travail de vérification du mot de passe prennent‑ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation du mot de passe basées sur le chemin de fichier ou le flux se comportent de la même manière pour les présentations PPT et PPTX.