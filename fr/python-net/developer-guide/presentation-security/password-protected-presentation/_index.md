---
title: Sécuriser les présentations avec des mots de passe en Python
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/python-net/password-protected-presentation/
keywords:
- verrouiller PowerPoint
- verrouiller la présentation
- déverrouiller PowerPoint
- déverrouiller la présentation
- protéger PowerPoint
- protéger la présentation
- définir un mot de passe
- ajouter un mot de passe
- chiffrer PowerPoint
- chiffrer la présentation
- déchiffrer PowerPoint
- déchiffrer la présentation
- protection en écriture
- sécurité PowerPoint
- sécurité de la présentation
- supprimer le mot de passe
- supprimer la protection
- supprimer le chiffrement
- désactiver le mot de passe
- désactiver la protection
- supprimer la protection en écriture
- présentation PowerPoint
- Python
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour Python via .NET. Augmentez votre productivité et sécurisez vos présentations grâce à notre guide étape par étape."
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour une présentation ?**
Lorsque vous protégez une présentation par mot de passe, cela signifie que vous définissez un mot de passe qui applique certaines restrictions sur la présentation. Pour lever ces restrictions, il faut saisir le mot de passe. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour appliquer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (sauf si elles fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut visualiser le contenu ou les éléments — hyperliens, animations, effets, etc. — dans votre présentation, mais il ne peut pas copier d’éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous voulez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même voir le contenu de votre présentation (sauf si elles fournissent le mot de passe).

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’ils ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ni y apporter des changements.  

  **Note** que lorsque vous protégez une présentation par mot de passe pour empêcher son ouverture, le fichier de présentation devient chiffré.

## Comment protéger une présentation par mot de passe en ligne

1. Rendez‑vous sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Drop or upload your files**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe de protection en écriture ; saisissez le mot de passe de protection en lecture.

5. Si vous voulez que les utilisateurs voient votre présentation comme copie finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe pour les présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans les formats suivants :

- PPTX et PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de ces manières :

- Chiffrement d’une présentation
- Définition d’une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces manières :

- Déchiffrement d’une présentation ; ouverture d’une présentation chiffrée
- Suppression du chiffrement ; désactivation de la protection par mot de passe
- Suppression de la protection en écriture d’une présentation
- Obtention des propriétés d’une présentation chiffrée
- Vérification si une présentation est chiffrée
- Vérification si une présentation est protégée par mot de passe.

## **Chiffrement d’une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) pour définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Définition d’une protection en écriture sur une présentation** 

Vous pouvez ajouter une marque indiquant « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils apportent des modifications à la présentation.

**Note** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs — s’ils le souhaitent vraiment — peuvent modifier la présentation, mais pour enregistrer les changements, ils devront créer une présentation sous un autre nom.

Pour définir une protection en écriture, vous devez utiliser la méthode setWriteProtection. Ce code d’exemple montre comment définir une protection en écriture sur une présentation :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```


## **Déchiffrement d’une présentation ; ouverture d’une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sans paramètres. Vous devrez ensuite saisir le mot de passe correct pour charger la présentation.

Ce code d’exemple montre comment déchiffrer une présentation : 
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```


## **Suppression du chiffrement ; désactivation de la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```


## **Suppression de la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise et ne reçoivent aucun avertissement lors de ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```


## **Obtention des propriétés d’une présentation chiffrée**

Typiquement, les utilisateurs ont du mal à obtenir les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Aspose.Slides propose toutefois un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder aux propriétés de cette présentation.

**Note** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après le chiffrement), Aspose.Slides vous permet de le faire précisément.

Si vous souhaitez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation que vous avez chiffrée, vous pouvez définir la propriété [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sur `True`. Ce code d’exemple montre comment chiffrer une présentation tout en permettant aux utilisateurs d’accéder à ses propriétés de document :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```


## **Vérification si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée est chargée sans son mot de passe.

Ce code Python montre comment examiner une présentation pour savoir si elle est protégée par mot de passe (sans charger la présentation elle‑même) :
```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```


## **Vérification si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour réaliser cette tâche, vous pouvez utiliser la propriété [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), qui renvoie `True` si la présentation est chiffrée ou `False` sinon.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```


## **Vérification si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour réaliser cette tâche, vous pouvez utiliser la propriété [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), qui renvoie `True` si la présentation est protégée en écriture ou `False` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```


## **Validation ou confirmation qu’un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # vérifier si "pass" correspond
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```


Il renvoie `True` si la présentation a été chiffrée avec le mot de passe indiqué. Sinon, il renvoie `False`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge les méthodes de chiffrement modernes, notamment les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe‑t‑il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, indiquant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des répercussions sur les performances lorsqu’on travaille avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de façon significative le temps de traitement global de vos tâches de présentation.