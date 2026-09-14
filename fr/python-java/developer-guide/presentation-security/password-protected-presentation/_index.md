---
title: Protéger les présentations par mot de passe en Python
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/python-java/password-protected-presentation/
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
description: "Chiffrer, détecter, valider, ouvrir et déchiffrer les présentations PowerPoint PPT et PPTX protégées par mot de passe avec Aspose.Slides pour Python via Java."
---
## **Aperçu**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est requis pour charger et afficher le contenu de la présentation, cette protection assure la confidentialité.

Un mot de passe d'ouverture est différent d'un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu ni n'empêche le chargement de la présentation. Pour gérer les mots de passe permettant de modifier les présentations, voir [Protéger les présentations en écriture](/slides/fr/python-java/write-protected-presentation/).

Les flux de travail ci-dessous s'appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque leur comportement basé sur fichier et sur flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [ProtectionManager.encrypt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#encrypt) pour assigner un mot de passe d'ouverture. Puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour sauvegarder la présentation chiffrée.

L'exemple suivant chiffre une présentation PPTX :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Conserver les propriétés du document publiques**

Par défaut, Aspose.Slides inclut les propriétés du document dans le chiffrement de la présentation. La méthode [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) contrôle ce comportement indépendamment du chiffrement du contenu des diapositives. Passez `False` avant d'appeler [ProtectionManager.encrypt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#encrypt) lorsqu'un système d'indexation, de classification, de recherche ou de gestion de documents doit lire les métadonnées sans le mot de passe d'ouverture.

L'exemple suivant crée une présentation PPTX chiffrée tout en laissant ses propriétés intégrées publiques :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Passer `False` à [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) ne rend pas publiques les diapositives, les maîtres, les dispositions, les formes, les médias ou tout autre contenu de la présentation. Cela affecte uniquement les propriétés du document. Pour lire ces propriétés sans charger le contenu chiffré, voir [Gérer les propriétés de la présentation](/slides/fr/python-java/presentation-properties/).

## **Charger une présentation chiffrée**

Définissez [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword) avec le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu'un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Travailler avec la présentation déchiffrée.
    pass
finally:
    presentation.dispose()
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#removeEncryption), puis enregistrez le résultat. La présentation enregistrée peut ensuite être chargée sans mot de passe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) pour obtenir [PresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/) sans créer une instance complète de présentation. Vérifiez [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#isPasswordProtected) avant de demander ou de valider un mot de passe. Lorsque la protection est présente, validez la valeur fournie avec [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Flux de travail basé sur le chemin de fichier**

L'exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword), puis charge la présentation complète :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Flux de travail en flux**

Le surchargé de flux de [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) fournit le même flux de travail. Réinitialisez la position d'un flux recherchable avant de charger la présentation complète à partir de ce flux.

L'exemple suivant utilise un fichier PPT :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Valeurs de retour de checkPassword**

La méthode [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#checkPassword) renvoie `True` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Elle renvoie `False` dans chacun de ces cas :

- Le mot de passe est incorrect.
- La présentation n'a pas de mot de passe d'ouverture.
- Le mot de passe fourni est `None` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, inspectez [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isEncrypted) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#isPasswordProtected) comme indiqué ci‑dessus.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
Ne consignez pas les mots de passe d'ouverture ni ne les incluez dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.

Les propriétés publiques du document peuvent divulguer les noms d'auteur, titres, sujets, mots-clés, informations d'entreprise, commentaires et valeurs personnalisées même si le contenu de la présentation est chiffré. Chiffrez les métadonnées sensibles avec la présentation. Laisser les propriétés publiques doit être une décision explicite prise uniquement lorsque les systèmes doivent indexer, classifier, rechercher ou gérer le fichier sans mot de passe d'ouverture.
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Ouvrez l'application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléversez la présentation.
1. Saisissez un mot de passe pour la protection en lecture.
1. Optionnellement, saisissez un mot de passe distinct pour la protection en écriture.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger les présentations en écriture](/slides/fr/python-java/write-protected-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est nécessaire pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis-je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez si une protection par mot de passe d'ouverture est présente, et validez le mot de passe avant de créer une instance complète de présentation.

**Une application peut‑elle lire les métadonnées sans le mot de passe d'ouverture ?**

Oui, mais uniquement lorsque la présentation a été chiffrée avec le chiffrement des propriétés du document désactivé. L'application doit alors utiliser le mode de chargement uniquement des propriétés du document décrit dans [Gérer les propriétés de la présentation](/slides/fr/python-java/presentation-properties/).

**Les flux de travail de vérification du mot de passe prennent‑ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation des mots de passe basées sur le chemin de fichier et sur le flux se comportent de la même manière pour les présentations PPT et PPTX.