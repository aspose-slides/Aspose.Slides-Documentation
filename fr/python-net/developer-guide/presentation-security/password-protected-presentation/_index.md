---
title: "Présentations sécurisées avec des mots de passe en Python"
linktitle: "Protection par mot de passe"
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
- décrypter PowerPoint
- décrypter la présentation
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
description: "Apprenez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour Python via .NET. Augmentez votre productivité et sécurisez vos présentations grâce à notre guide étape par étape."
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour une présentation ?**
Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer ces restrictions, il faut saisir le mot de passe. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (à moins de fournir le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut visualiser le contenu ou les éléments — hyperliens, animations, effets, etc. — dans votre présentation, mais il ne peut pas copier d’éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même visualiser le contenu de votre présentation (à moins de fournir le mot de passe).

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’ils ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ou y apporter des changements.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher l’ouverture, le fichier de présentation devient chiffré.

## Comment protéger une présentation par mot de passe en ligne

1. Allez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléversez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez votre mot de passe préféré pour la protection en édition ; saisissez votre mot de passe préféré pour la protection en lecture.

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats supportés**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT - Présentation Microsoft PowerPoint
- ODP - Présentation OpenDocument
- OTP - Modèle de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces façons :

- Chiffrement d’une présentation
- Définition d’une protection en écriture pour une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces façons :

- Décryptage d’une présentation ; ouverture d’une présentation chiffrée
- Suppression du chiffrement ; désactivation de la protection par mot de passe
- Suppression de la protection en écriture d’une présentation
- Obtention des propriétés d’une présentation chiffrée
- Vérification si une présentation est chiffrée
- Vérification si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode `encrypt` (de [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) afin de définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode `encrypt` et utilisez la méthode `save` pour sauvegarder la présentation désormais chiffrée.

Cet exemple de code montre comment chiffrer une présentation :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir une protection en écriture pour une présentation**

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous signalez aux utilisateurs que vous ne voulez pas qu’ils apportent des modifications à la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s’ils le souhaitent—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation sous un autre nom.

Pour définir une protection en écriture, vous devez utiliser la méthode `setWriteProtection`. Cet exemple de code montre comment définir une protection en écriture pour une présentation :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Décrypter une présentation ; ouvrir une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour décrypter une présentation, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sans paramètres. Vous devrez ensuite saisir le mot de passe correct pour charger la présentation.

Cet exemple de code montre comment décrypter une présentation :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Supprimer le chiffrement ; désactiver la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Cet exemple de code montre comment supprimer le chiffrement d’une présentation :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise—et ils ne reçoivent aucun avertissement lorsqu’ils effectuent de telles actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Cet exemple de code montre comment supprimer la protection en écriture d’une présentation :

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs ont du mal à obtenir les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Aspose.Slides, cependant, propose un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après le chiffrement de la présentation), Aspose.Slides vous permet de le faire précisément.

Si vous souhaitez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation que vous avez chiffrée, vous pouvez définir la propriété [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sur `True`. Cet exemple de code montre comment chiffrer une présentation tout en offrant aux utilisateurs les moyens d’accéder à ses propriétés de document :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et les problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code Python montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle‑même) :

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), qui renvoie `True` si la présentation est chiffrée ou `False` si elle ne l’est pas.

Cet exemple de code montre comment vérifier si une présentation est chiffrée :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), qui renvoie `True` si la présentation est protégée en écriture ou `False` sinon.

Cet exemple de code montre comment vérifier si une présentation est protégée en écriture :

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Cet exemple de code montre comment valider un mot de passe :

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # vérifier si "pass" correspond à
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Il renvoie `True` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, il renvoie `False`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge les méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous avertissant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a-t-il des implications de performance lors du travail avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.