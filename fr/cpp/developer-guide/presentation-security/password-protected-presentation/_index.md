---
title: Sécuriser les présentations avec des mots de passe en C++
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/cpp/password-protected-presentation/
keywords:
- verrouiller PowerPoint
- verrouiller la présentation
- déverrouiller PowerPoint
- déverrouiller la présentation
- protéger PowerPoint
- protéger la présentation
- définir le mot de passe
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
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour C++. Sécurisez vos présentations."
---

## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour les présentations ?**
Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer les restrictions, il faut saisir le mot de passe. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions à une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation (sauf si elles fournissent le mot de passe).

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut consulter le contenu – hyperliens, animations, effets, etc. – à l’intérieur de votre présentation, mais il ne peut pas copier d’éléments ni enregistrer la présentation.

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même voir le contenu de votre présentation (sauf si elles fournissent le mot de passe).

  Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations : lorsqu’ils ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier.

  **Remarque** : lorsque vous protégez une présentation par mot de passe afin d’empêcher l’ouverture, le fichier de présentation devient chiffré.

## **Comment protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Drop or upload your files**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.

4. Saisissez le mot de passe que vous désirez pour la protection en écriture ; saisissez le mot de passe que vous désirez pour la protection en lecture.

5. Si vous voulez que les utilisateurs voient votre présentation comme copie finale, cochez la case **Mark as final**.

6. Cliquez sur **PROTECT NOW.**

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe des présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans les formats suivants :

- PPTX et PPT – Microsoft PowerPoint Presentation
- ODP – OpenDocument Presentation
- OTP – OpenDocument Presentation Template

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Appliquer une protection en écriture à une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches impliquant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Obtenir les propriétés d’une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode **encrypt** (à partir de [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) pour définir un mot de passe pour la présentation. Vous transmettez le mot de passe à la méthode **encrypt** et utilisez la méthode **save** pour enregistrer la présentation maintenant chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```


## **Appliquer une protection en écriture à une présentation** 

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils modifient la présentation.

**Remarque** : le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs – s’ils le souhaitent – peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation avec un nom différent.

Pour appliquer une protection en écriture, vous devez utiliser la méthode **setWriteProtection**. Ce code d’exemple montre comment appliquer une protection en écriture à une présentation :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```


## **Charger une présentation chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en fournissant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sans paramètres. Vous devrez alors saisir le mot de passe correct pour charger la présentation.

Ce code d’exemple montre comment déchiffrer une présentation : 
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// Travailler avec la présentation déchiffrée
```


## **Supprimer le chiffrement d’une présentation**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation. Ainsi, les utilisateurs peuvent accéder à la présentation ou la modifier sans restriction.

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```


## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture d’un fichier de présentation. Ainsi, les utilisateurs peuvent modifier à leur guise et n’obtiennent aucun avertissement lors de ces actions.

Vous pouvez supprimer la protection en écriture d’une présentation en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```


## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs éprouvent des difficultés à obtenir les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Aspose.Slides propose toutefois un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder aux propriétés de cette présentation.

**Remarque** : lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous avez besoin de rendre les propriétés accessibles (même après le chiffrement), Aspose.Slides vous le permet.

Si vous souhaitez que les utilisateurs conservent la possibilité d’accéder aux propriétés d’une présentation que vous avez chiffrée, vous pouvez passer `true` à la méthode [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Ce code d’exemple montre comment chiffrer une présentation tout en permettant aux utilisateurs d’accéder à ses propriétés de document :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```


## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vouloir vérifier que celle‑ci n’est pas protégée par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code C++ montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle‑même) :
```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```


## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour réaliser cette tâche, vous pouvez utiliser la méthode [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```


## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour réaliser cette tâche, vous pouvez utiliser la méthode [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```


## **Vérifier l’utilisation du mot de passe d’une présentation**

Vous pouvez vouloir vérifier qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// vérifier si "pass" correspond
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```


Il renvoie `true` si la présentation a été chiffrée avec le mot de passe indiqué. Sinon, il renvoie `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de l’ouverture d’une présentation ?**

Une exception est levée si le mot de passe est incorrect, indiquant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des impacts sur les performances lors de la manipulation de présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire une légère surcharge lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps global de traitement de vos tâches de présentation.