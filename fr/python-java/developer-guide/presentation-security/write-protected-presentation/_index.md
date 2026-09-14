---
title: Protection en écriture des présentations en Python
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/python-java/write-protected-presentation/
keywords:
- protection en écriture
- protection en écriture PowerPoint
- mot de passe de modification
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l’aide d’Aspose.Slides pour Python via Java."
---
## **Introduction**

Un mot de passe de protection en écriture restreint la modification d’une présentation mais n’en chiffre pas le contenu. Les utilisateurs peuvent charger et visualiser une présentation protégée en écriture sans le mot de passe. Selon l’application, ils peuvent également modifier le contenu et l’enregistrer sous un autre nom, ainsi la protection en écriture ne doit pas être considérée comme un mécanisme de confidentialité.

Un mot de passe d’ouverture a un objectif différent : il chiffre la présentation et est requis pour charger son contenu. Pour chiffrer une présentation ou valider un mot de passe d’ouverture, voir [Password-Protect Presentations](/slides/fr/python-java/password-protected-presentation/).

Les flux de travail décrits dans cet article s’appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX ; lors de l’enregistrement au format PPT, utilisez l’extension `.ppt` et le format d’enregistrement PPT correspondant.

## **Set Write Protection on a Presentation**

Utilisez [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#setWriteProtection) pour attribuer un mot de passe de modification d’une présentation. L’enregistrement de la présentation persiste le paramètre de protection.

L’exemple suivant définit la protection en écriture sur une présentation PPTX :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Load a Write-Protected Presentation**

Comme la protection en écriture ne chiffre pas le contenu de la présentation, aucun mot de passe n’est requis pour charger la présentation. Le mot de passe n’est pertinent que lors de la validation de l’autorisation de modifier la présentation protégée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Ne transmettez pas de mot de passe de protection en écriture à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword). Cette méthode accepte un mot de passe d’ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d’ouverture pour la charger et traitez séparément le mot de passe de protection en écriture.

## **Remove Write Protection from a Presentation**

Utilisez [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#removeWriteProtection) pour supprimer la restriction de modification, puis enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Check Whether a Presentation Is Write Protected**

Pour inspecter un fichier sans créer une instance complète de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), appelez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) et examinez [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#isWriteProtected). La méthode utilise [NullableBool](https://reference.aspose.com/slides/fr/python-java/aspose.slides/nullablebool/) et renvoie `NullableBool.True_` lorsqu’une protection en écriture est détectée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

La surcharge de flux de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) fournit les mêmes informations pour une présentation fournie sous forme de flux.

## **Validate a Write-Protection Password**

Utilisez [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#checkWriteProtection) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d’abord [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#isWriteProtected) afin que l’application ne demande ou ne valide un mot de passe que lorsque la protection en écriture est présente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#checkWriteProtection) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d’ouverture ni ne détermine si le contenu chiffré peut être chargé. Inversement, [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#checkPassword) ne valide que le mot de passe d’ouverture. Si une présentation complète a déjà été chargée, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#checkWriteProtection) fournit la vérification équivalente via son gestionnaire de protection.

Dans les applications de production, ne consignez pas les mots de passe ni ne les incluez dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles et ne conservez les mots de passe en mémoire que le temps strictement nécessaire.

{{% alert color="info" title="See also" %}}
- [Password-Protect Presentations](/slides/fr/python-java/password-protected-presentation/)
- [Read-Only Presentations](/slides/fr/python-java/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/fr/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre-t‑elle une présentation ?**

Non. Elle restreint la modification mais laisse le contenu de la présentation disponible pour le chargement et la visualisation.

**Le mot de passe de protection en écriture est‑il requis pour ouvrir une présentation ?**

Non. Seul un mot de passe d’ouverture est requis pour charger le contenu chiffré d’une présentation.

**Une présentation peut‑elle avoir à la fois un mot de passe d’ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d’ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l’autorisation de modification est nécessaire.