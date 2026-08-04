---
title: Présentations sécurisées par mot de passe avec Python
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/python-net/password-protected-presentation/
keywords:
- verrouiller PowerPoint
- verrouiller présentation
- déverrouiller PowerPoint
- déverrouiller présentation
- protéger PowerPoint
- protéger présentation
- définir mot de passe
- ajouter mot de passe
- chiffrer PowerPoint
- chiffrer présentation
- déchiffrer PowerPoint
- déchiffrer présentation
- protection en écriture
- sécurité PowerPoint
- sécurité présentation
- supprimer mot de passe
- supprimer protection
- supprimer chiffrement
- désactiver mot de passe
- désactiver protection
- supprimer protection en écriture
- présentation PowerPoint
- Python
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour Python via .NET. Boostez votre productivité et sécurisez vos présentations grâce à notre guide étape par étape."
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, cela signifie que vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (sauf si elles fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut consulter le contenu ou les éléments - liens hypertexte, animations, effets, etc - de votre présentation, mais il ne peut pas copier les éléments ni enregistrer la présentation.

- **Opening**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. Cette restriction empêche les personnes de même visualiser le contenu de votre présentation (sauf si elles fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu'une personne ne peut pas ouvrir une présentation, elle ne peut pas la modifier ni apporter de changements.

  **Remarque** que lorsque vous protégez une présentation par mot de passe pour empêcher son ouverture, le fichier de présentation devient chiffré.

## Comment protéger une présentation par mot de passe en ligne

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/fr/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléversez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe de votre choix pour la protection en écriture ; saisissez le mot de passe de votre choix pour la protection en lecture.

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la version finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT - Présentation Microsoft PowerPoint
- ODP - Présentation OpenDocument
- OTP - Modèle de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches concernant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrement d’une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l'utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/)) pour définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation maintenant chiffrée.

Ce morceau de code montre comment chiffrer une présentation :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.encrypt("123123")
    pres.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir une protection en écriture sur une présentation**

Vous pouvez ajouter une mention "Do not modify" à une présentation. Ainsi, vous informez les utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications à la présentation.

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Ainsi, les utilisateurs—s'ils le souhaitent—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation sous un autre nom.

Pour définir une protection en écriture, vous devez utiliser la méthode setWriteProtection. Ce morceau de code montre comment appliquer une protection en écriture à une présentation :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.protection_manager.set_write_protection("123123")
    pres.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Déchiffrement d’une présentation ; ouverture d’une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/) sans paramètres. Vous devrez ensuite saisir le mot de passe correct pour charger la présentation.

Ce morceau de code montre comment déchiffrer une présentation :
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    print(pres.document_properties.author)
```

## **Suppression du chiffrement ; désactivation de la protection par mot de passe**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder à la présentation ou la modifier sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [remove_encryption](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/). Ce morceau de code montre comment supprimer le chiffrement d’une présentation :
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.password = "123123"
with slides.Presentation("encrypted-pres.pptx", loadOptions) as pres:
    pres.protection_manager.remove_encryption()
    pres.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Suppression de la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise—sans avertissement lorsqu'ils effectuent ces opérations.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [remove_write_protection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/). Ce morceau de code montre comment retirer la protection en écriture d’une présentation :
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    pres.protection_manager.remove_write_protection()
    pres.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs ont du mal à récupérer les propriétés d’un document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides propose un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la capacité des utilisateurs à accéder à ses propriétés.

**Remarque** : par défaut, lorsqu’Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire.

Si vous souhaitez que les utilisateurs conservent la possibilité d’accéder aux propriétés d’une présentation chiffrée, définissez la propriété `encrypt_document_properties` de [ProtectionManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/) sur `False`. Ce morceau de code montre comment chiffrer une présentation tout en offrant aux utilisateurs l’accès à ses propriétés de document :
```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("123123")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Charger uniquement les propriétés du document d’une présentation chiffrée**

Pour examiner les métadonnées d’une présentation chiffrée sans charger ses diapositives ou autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/) et définissez [only_load_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/only_load_document_properties/) sur `True`. Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document qui sont accessibles publiquement.

L’exemple de code suivant lit les propriétés de document intégrées et répertorie les propriétés de document personnalisées via [Presentation.document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/document_properties/) :
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    document_properties = presentation.document_properties

    # Lire les propriétés de document intégrées.
    print("Title: " + document_properties.title)
    print("Author: " + document_properties.author)

    # Lister les propriétés de document personnalisées.
    custom_property_count = document_properties.count_of_custom_properties

    for property_index in range(custom_property_count):
        property_name = document_properties.get_custom_property_name(property_index)
        print(property_name)
```

Ce flux de travail fonctionne uniquement lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement de la présentation. Si les propriétés du document sont chiffrées, définir `only_load_document_properties` sur `True` entraîne une exception, car le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés chiffrées du document ou charger la présentation complète, y compris ses diapositives et autre contenu, fournissez la valeur correcte de `password` dans [LoadOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadoptions/).

## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous pouvez souhaiter vérifier et confirmer que la présentation n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code Python montre comment examiner une présentation pour déterminer si elle est protégée par mot de passe (sans charger la présentation elle‑même) :
```python
import aspose.slides as slides

presentationInfo = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print("The presentation is password protected: " + str(presentationInfo.is_password_protected))
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour ce faire, vous pouvez utiliser la propriété [is_encrypted](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/) qui renvoie `True` si la présentation est chiffrée ou `False` si elle ne l’est pas.

Ce morceau de code montre comment vérifier si une présentation est chiffrée :
```py
import aspose.slides as slides

with slides.Presentation() as pres:
    print(str(pres.protection_manager.is_encrypted))
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour ce faire, vous pouvez utiliser la propriété [is_write_protected](https://reference.aspose.com/slides/fr/python-net/aspose.slides/protectionmanager/) qui renvoie `True` si la présentation est protégée en écriture ou `False` sinon.

Ce morceau de code montre comment vérifier si une présentation est protégée en écriture :
```py
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as pres:
    print(str(pres.protection_manager.is_write_protected))
```

## **Valider ou confirmer qu’un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous pouvez souhaiter vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce morceau de code montre comment valider un mot de passe :
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

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris des algorithmes basés sur AES, assurant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous avertissant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des implications de performance lors de la manipulation de présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut engendrer une légère surcharge lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de façon significative le temps de traitement global de vos tâches de présentation.