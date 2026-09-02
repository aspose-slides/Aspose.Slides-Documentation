---
title: Protection en écriture des présentations avec Python
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/python-net/write-protected-presentation/
keywords:
- protection en écriture
- Protection en écriture PowerPoint
- mot de passe pour modifier
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l'aide d'Aspose.Slides pour Python."
---
## **Introduction**

Un mot de passe de protection en écriture limite la modification d'une présentation mais ne chiffre pas son contenu. Les utilisateurs peuvent charger et afficher une présentation protégée en écriture sans le mot de passe. Selon l'application, ils peuvent également modifier le contenu et l'enregistrer sous un autre nom, ainsi la protection en écriture ne doit pas être considérée comme un mécanisme de confidentialité.

Un mot de passe d'ouverture a un objectif différent : il chiffre la présentation et est requis pour charger son contenu. Pour chiffrer une présentation ou valider un mot de passe d'ouverture, voir [Password-Protect Presentations](/slides/fr/python-net/password-protected-presentation/).

Les flux de travail de cet article s'appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX ; lors de l'enregistrement au format PPT, utilisez l'extension `.ppt` et le format d'enregistrement PPT correspondant.

## **Définir la protection en écriture sur une présentation**

Utilisez [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/set_write_protection/) pour assigner un mot de passe de modification d'une présentation. Enregistrez la présentation pour conserver le paramètre de protection.

L'exemple suivant applique la protection en écriture à une présentation PPTX :
```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Charger une présentation protégée en écriture**

Comme la protection en écriture ne chiffre pas le contenu de la présentation, aucun mot de passe n'est requis pour charger la présentation. Le mot de passe n'est pertinent que lors de la validation de l'autorisation de modifier la présentation protégée.
```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Ne transmettez pas un mot de passe de protection en écriture à [LoadOptions.password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/password/). Cette propriété accepte un mot de passe d'ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d'ouverture pour la charger et gérez séparément le mot de passe de protection en écriture.

## **Supprimer la protection en écriture d'une présentation**

Utilisez [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/remove_write_protection/) pour supprimer la restriction de modification, puis enregistrez la présentation.
```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Vérifier si une présentation est protégée en écriture**

Pour examiner un fichier sans créer une instance complète de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/), appelez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) et inspectez [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/is_write_protected/). La propriété utilise [NullableBool](https://reference.aspose.com/slides/fr/python-net/aspose.slides/nullablebool/) et renvoie `NullableBool.TRUE` lorsqu'une protection en écriture est détectée.
```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

La surcharge de flux de [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) fournit les mêmes informations pour une présentation fournie sous forme de flux.

## **Valider un mot de passe de protection en écriture**

Utilisez [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/check_write_protection/) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d'abord [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/is_write_protected/) afin que l'application ne demande ou ne valide un mot de passe que lorsque la protection en écriture est présente.
```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/check_write_protection/) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d'ouverture ni ne détermine si le contenu chiffré peut être chargé. Inversement, [PresentationInfo.check_password](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/check_password/) ne valide que le mot de passe d'ouverture. Si une présentation complète a déjà été chargée, [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/check_write_protection/) fournit la vérification équivalente de la protection en écriture via son gestionnaire de protection.

Dans les applications de production, ne consignez pas les mots de passe et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles et conservez les mots de passe en mémoire uniquement pendant la durée nécessaire.

{{% alert color="info" title="Voir aussi" %}}
- [Password-Protect Presentations](/slides/fr/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/fr/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/fr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre-t-elle une présentation ?**

Non. Elle limite la modification mais laisse le contenu de la présentation disponible pour le chargement et la visualisation.

**Le mot de passe de protection en écriture est-il requis pour ouvrir une présentation ?**

Non. seul un mot de passe d'ouverture est requis pour charger le contenu chiffré d'une présentation.

**Une présentation peut-elle avoir à la fois un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d'ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l'autorisation de modification est requise.