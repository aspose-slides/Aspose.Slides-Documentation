---
title: Présentation protégée par mot de passe
type: docs
weight: 20
url: /python-net/presentation-protegee-par-mot-de-passe/
keywords: "Verrouiller PowerPoint, déverrouiller PowerPoint, protéger PowerPoint, définir un mot de passe, ajouter un mot de passe, chiffrer PowerPoint, déchiffrer PowerPoint, Protection en écriture, sécurité PowerPoint, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Protection par mot de passe de PowerPoint, cryptage et sécurité en Python"

---

## **À propos de la Protection par Mot de Passe**
### **Comment fonctionne la protection par mot de passe pour une présentation?**
Lorsque vous protégez par mot de passe une présentation, cela signifie que vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer les restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. La restriction ici empêche les personnes de modifier, changer ou copier des éléments dans votre présentation (à moins qu'elles fournissent le mot de passe). 

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut voir le contenu ou d'autres éléments—hyperliens, animations, effets, etc.—à l'intérieur de votre présentation, mais il ne peut pas copier d'éléments ou enregistrer la présentation. 

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. La restriction ici empêche les personnes de même voir le contenu de votre présentation (à moins qu'elles fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : Lorsque les personnes ne peuvent pas ouvrir une présentation, elles ne peuvent pas la modifier ni y apporter des changements. 
  
  **Remarque** que lorsque vous protégez par mot de passe une présentation pour empêcher son ouverture, le fichier de présentation devient chiffré.

## Comment Protéger une Présentation par Mot de Passe en Ligne

1. Allez sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Glisser ou télécharger vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 

4. Entrez votre mot de passe préféré pour la protection de l'édition ; entrez votre mot de passe préféré pour la protection de la vue. 

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTÉGER MAINTENANT.**

7. Cliquez sur **TÉLÉCHARGER MAINTENANT.**

## **Protection par Mot de Passe pour les Présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le cryptage et des opérations similaires pour les présentations dans ces formats : 

- PPTX et PPT - Présentation Microsoft PowerPoint 
- ODP - Présentation OpenDocument 
- OTP - Modèle de Présentation OpenDocument 

**Opérations prises en charge**

Aspose.Slides vous permet d'utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture pour une présentation

**Autres opérations**

Aspose.Slides vous permet d'effectuer d'autres tâches impliquant la protection par mot de passe et le cryptage de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le cryptage ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d'une présentation
- Obtenir les propriétés d'une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une Présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe. 

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/)) pour définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais chiffrée. 

Cet exemple de code vous montre comment chiffrer une présentation :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir une Protection en Écriture pour une Présentation** 

Vous pouvez ajouter une mention indiquant "Ne pas modifier" à une présentation. De cette manière, vous indiquez aux utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications à la présentation.  

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s'ils le souhaitent vraiment—peuvent modifier la présentation, mais pour enregistrer les changements, ils devront créer une présentation avec un nom différent. 

Pour définir une protection en écriture, vous devez utiliser la méthode setWriteProtection. Cet exemple de code vous montre comment définir une protection en écriture pour une présentation :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Déchiffrer une Présentation ; Ouvrir une Présentation Chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en passant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sans paramètres. Vous devrez ensuite entrer le mot de passe correct pour charger la présentation. 

Cet exemple de code vous montre comment déchiffrer une présentation : 

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Supprimer le Cryptage ; Désactiver la Protection par Mot de Passe**

Vous pouvez supprimer le cryptage ou la protection par mot de passe d'une présentation. De cette manière, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions. 

Pour supprimer le cryptage ou la protection par mot de passe, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Cet exemple de code vous montre comment supprimer le cryptage d'une présentation :

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer la Protection en Écriture d'une Présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture utilisée sur un fichier de présentation. De cette manière, les utilisateurs peuvent modifier à leur guise—et ils ne reçoivent aucun avertissement lorsqu'ils effectuent de telles tâches.

Vous pouvez supprimer la protection en écriture d'une présentation en utilisant la méthode [remove_write_protection](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/). Cet exemple de code vous montre comment supprimer la protection en écriture d'une présentation :

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les Propriétés d'une Présentation Chiffrée**

En général, les utilisateurs ont des difficultés à obtenir les propriétés du document d'une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides propose un mécanisme qui vous permet de protéger par mot de passe une présentation tout en permettant aux utilisateurs d'accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous avez besoin de rendre les propriétés de la présentation accessibles (même après que la présentation ait été chiffrée), Aspose.Slides vous permet de le faire précisément. 

Si vous souhaitez que les utilisateurs conservent la possibilité d'accéder aux propriétés d'une présentation que vous avez chiffrée, vous pouvez définir la propriété [EncryptDocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/) sur `True`. Cet exemple de code vous montre comment chiffrer une présentation tout en fournissant aux utilisateurs la possibilité d'accéder à ses propriétés de document :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt_document_properties = True
    pres.protection_manager.encrypt("123123")
```

## **Vérifier si une Présentation est Protégée par Mot de Passe Avant de la Charger**

Avant de charger une présentation, vous souhaiterez peut-être vérifier et confirmer que la présentation n'a pas été protégée par mot de passe. De cette manière, vous évitez les erreurs et les problèmes similaires qui surviennent lorsque une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code Python vous montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle-même) :

```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("La présentation est protégée par mot de passe : " + str(presentationInfo.is_password_protected))
```

## **Vérifier si une Présentation est Chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), qui renvoie `True` si la présentation est chiffrée ou `False` si la présentation n'est pas chiffrée. 

Cet exemple de code vous montre comment vérifier si une présentation est chiffrée :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Vérifier si une Présentation est Protégé en Écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [is_write_protected](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/), qui renvoie `True` si la présentation est protégée en écriture ou `False` si la présentation ne l'est pas. 

Cet exemple de code vous montre comment vérifier si une présentation est protégée en écriture :

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Valider ou Confirmer qu'un Mot de Passe Spécifique a été Utilisé pour Protéger une Présentation**

Vous souhaiterez peut-être vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides vous fournit les moyens de valider un mot de passe. 

Cet exemple de code vous montre comment valider un mot de passe :

```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    # vérifier si "pass" correspond
    matched = pres.protection_manager.check_write_protection("my_password")
    print(str(matched))
```

Cela renvoie `True` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, cela renvoie `False`. 

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature Numérique dans PowerPoint](/slides/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}