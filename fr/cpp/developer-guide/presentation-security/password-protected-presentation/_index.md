---
title: Présentation Protégée par Mot de Passe
type: docs
weight: 20
url: /fr/cpp/password-protected-presentation/
keywords: "Verrouiller la présentation PowerPoint"
description: "Verrouiller la présentation PowerPoint. Présentation PowerPoint protégée par mot de passe avec Aspose.Slides."
---

## **À Propos de la Protection par Mot de Passe**
### **Comment fonctionne la protection par mot de passe pour une présentation ?**
Lorsque vous protégez par mot de passe une présentation, cela signifie que vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer les restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. La restriction ici empêche les personnes de modifier, changer ou copier des éléments dans votre présentation (à moins qu'elles ne fournissent le mot de passe). 

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut voir le contenu ou des éléments—hyperliens, animations, effets, et autres—dans votre présentation, mais il ne peut pas copier des éléments ni enregistrer la présentation. 

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. La restriction ici empêche les personnes de même voir le contenu de votre présentation (à moins qu'elles ne fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : Lorsque les personnes ne peuvent pas ouvrir une présentation, elles ne peuvent pas modifier ni apporter de changements à celle-ci. 
  
  **Remarque** qu'en protégeant par mot de passe une présentation pour empêcher son ouverture, le fichier de présentation devient chiffré.

## **Comment Protéger par Mot de Passe une Présentation en Ligne**

1. Allez sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléchargez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 

4. Saisissez votre mot de passe préféré pour la protection en écriture ; saisissez votre mot de passe préféré pour la protection en lecture. 

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTÉGER MAINTENANT.** 

7. Cliquez sur **TÉLÉCHARGER MAINTENANT.**

## **Protection par Mot de Passe pour les Présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour des présentations dans ces formats : 

- PPTX et PPT - Présentation Microsoft PowerPoint 
- ODP - Présentation OpenDocument 
- OTP -  Modèle de Présentation OpenDocument 

**Opérations prises en charge**

Aspose.Slides vous permet d'utiliser la protection par mot de passe sur des présentations pour empêcher les modifications de ces manières :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet de réaliser d'autres tâches impliquant la protection par mot de passe et le chiffrement de ces manières :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Retirer le chiffrement ; désactiver la protection par mot de passe
- Retirer la protection en écriture d'une présentation
- Obtenir les propriétés d'une présentation chiffrée
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe.

## **Chiffrer une Présentation**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe. 

Pour chiffrer ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (du [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) pour définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation maintenant chiffrée. 

Ce code d'exemple vous montre comment chiffrer une présentation :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Définir une Protection en Écriture sur une Présentation** 

Vous pouvez ajouter une marque indiquant "Ne pas modifier" à une présentation. De cette façon, vous informez les utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications à la présentation.  

**Remarque** que le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s'ils le souhaitent vraiment—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation avec un nom différent. 

Pour définir une protection en écriture, vous devez utiliser la méthode setWriteProtection. Ce code d'exemple vous montre comment définir une protection en écriture sur une présentation :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Déchiffrer une Présentation; Ouvrir une Présentation Chiffrée**

Aspose.Slides vous permet de charger un fichier chiffré en passant son mot de passe. Pour déchiffrer une présentation, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sans paramètres. Vous devrez ensuite entrer le mot de passe correct pour charger la présentation. 

Ce code d'exemple vous montre comment déchiffrer une présentation : 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// travailler avec la présentation déchiffrée
```

## **Retirer le Chiffrement ; Désactiver la Protection par Mot de Passe**

Vous pouvez retirer le chiffrement ou la protection par mot de passe sur une présentation. De cette manière, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions. 

Pour retirer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Ce code d'exemple vous montre comment retirer le chiffrement d'une présentation :

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Retirer la Protection en Écriture d'une Présentation**

Vous pouvez utiliser Aspose.Slides pour retirer la protection en écriture appliquée à un fichier de présentation. De cette manière, les utilisateurs peuvent modifier à leur guise—et ils ne reçoivent aucune alerte lorsqu'ils effectuent de telles tâches.

Vous pouvez retirer la protection en écriture d'une présentation en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Ce code d'exemple vous montre comment retirer la protection en écriture d'une présentation :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Obtenir les Propriétés d'une Présentation Chiffrée**

Typiquement, les utilisateurs ont du mal à obtenir les propriétés du document d'une présentation chiffrée ou protégée par mot de passe. Aspose.Slides, cependant, offre un mécanisme qui vous permet de protéger par mot de passe une présentation tout en conservant la possibilité pour les utilisateurs d'accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides chiffre une présentation, les propriétés du document de celle-ci sont également protégées par mot de passe par défaut. Mais si vous avez besoin de rendre les propriétés de la présentation accessibles (même après que la présentation soit chiffrée), Aspose.Slides vous permet de faire cela précisément. 

Si vous souhaitez que les utilisateurs conservent la possibilité d'accéder aux propriétés d'une présentation que vous avez chiffrée, vous pouvez passer `true` à la méthode [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d). Ce code d'exemple vous montre comment chiffrer une présentation tout en fournissant aux utilisateurs les moyens d'accéder à ses propriétés de document :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Vérifier si une Présentation est Protégée par Mot de Passe Avant de la Charger**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n'est pas protégée par un mot de passe. De cette façon, vous évitez les erreurs et les problèmes similaires, qui surviennent lorsque l'on tente de charger une présentation protégée par mot de passe sans son mot de passe.

Ce code C++ vous montre comment examiner une présentation pour vérifier si elle est protégée par mot de passe (sans charger la présentation elle-même) :

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"La présentation est protégée par mot de passe : ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Vérifier si une Présentation est Chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la méthode [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), qui retourne `true` si la présentation est chiffrée ou `false` si la présentation n'est pas chiffrée. 

Ce code d'exemple vous montre comment vérifier si une présentation est chiffrée :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Vérifier si une Présentation est Protégée en Écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la méthode [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), qui retourne `true` si la présentation est protégée en écriture ou `false` si la présentation n'est pas protégée en écriture. 

Ce code d'exemple vous montre comment vérifier si une présentation est protégée en écriture :

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isWriteProtected = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Valider ou Confirmer qu'un Mot de Passe Spécifique a été Utilisé pour Protéger une Présentation**

Vous pouvez vouloir vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides offre les moyens de valider un mot de passe. 

Ce code d'exemple vous montre comment valider un mot de passe :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// vérifier si "pass" correspond à
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Cela retourne `true` si la présentation a été chiffrée avec le mot de passe spécifié. Sinon, cela retourne `false`. 

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature Numérique dans PowerPoint](/slides/fr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}