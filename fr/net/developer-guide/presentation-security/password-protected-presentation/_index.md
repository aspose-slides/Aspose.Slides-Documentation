---
title: Sécuriser les présentations PowerPoint avec des mots de passe en C#
linktitle: Présentation protégée par mot de passe
type: docs
weight: 20
url: /fr/net/password-protected-presentation/
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
- sécurité de la présentation
- supprimer mot de passe
- supprimer protection
- supprimer chiffrement
- désactiver mot de passe
- désactiver protection
- supprimer protection en écriture
- présentation PowerPoint
- C#
- Aspose.Slides
description: "Découvrez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour .NET. Augmentez votre productivité et sécurisez vos présentations grâce à notre guide pas à pas."
---

## **Vue d'ensemble**

Lorsque vous protégez une présentation par mot de passe, cela signifie que vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour appliquer ces restrictions à une présentation :

- **Modification**

Si vous souhaitez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation à moins de fournir le mot de passe.  

Cependant, même sans le mot de passe, un utilisateur pourra toujours accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut visualiser le contenu — y compris les hyperliens, les animations, les effets et d’autres éléments — de votre présentation, mais il ne peut pas copier les éléments ni enregistrer la présentation.

- **Ouverture**

Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d'ouverture. Cette restriction empêche les personnes de même visualiser le contenu de votre présentation à moins de fournir le mot de passe.  

Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations — si les personnes ne peuvent pas ouvrir une présentation, elles ne peuvent pas la modifier ou y apporter des changements.

**Note :** Lorsque vous protégez une présentation par mot de passe pour empêcher son ouverture, le fichier de la présentation devient chiffré.

## **Protection par mot de passe dans Aspose.Slides**

**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations dans ces formats :

- PPTX et PPT – Présentations Microsoft PowerPoint
- ODP – Présentations OpenDocument
- OTP – Modèles de présentations OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations pour empêcher les modifications de les manières suivantes :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer des tâches supplémentaires impliquant la protection par mot de passe et le chiffrement de la manière suivante :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Récupérer les propriétés d’une présentation chiffrée
- Vérifier si une présentation est protégée par mot de passe avant de la charger
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe

## **Protéger une présentation avec un mot de passe**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l'utilisateur doit fournir le mot de passe.

Pour chiffrer (ou protéger par mot de passe) une présentation, utilisez la méthode `Encrypt` de [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) pour définir un mot de passe. Transmettez le mot de passe à la méthode `Encrypt`, puis utilisez la méthode `Save` pour enregistrer la présentation désormais chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **Définir une protection en écriture sur une présentation**

Vous pouvez ajouter une marque indiquant « Ne pas modifier » à une présentation. Cela informe les utilisateurs que vous ne souhaitez pas qu’ils apportent des modifications à la présentation.

**Note :** Le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs — s’ils le souhaitent — peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront la sauvegarder sous un autre nom.

Pour définir la protection en écriture, utilisez la méthode `SetWriteProtection`. Ce code d’exemple montre comment définir la protection en écriture sur une présentation :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **Charger une présentation chiffrée**

Aspose.Slides vous permet de charger une présentation chiffrée en transmettant le mot de passe correct. Ce code d’exemple montre comment charger une présentation chiffrée :
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Travailler avec la présentation déchiffrée.
}
```


## **Supprimer le chiffrement d’une présentation**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation, permettant aux utilisateurs d’y accéder ou de la modifier sans restrictions.

Pour supprimer le chiffrement ou la protection par mot de passe, appelez la méthode [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture d’un fichier de présentation. De cette façon, les utilisateurs peuvent le modifier comme ils le souhaitent — et ils ne recevront aucun avertissement lors de ces opérations.

Vous pouvez supprimer la protection en écriture en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **Obtenir les propriétés d’une présentation chiffrée**

Typiquement, les utilisateurs ont du mal à récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides offre un mécanisme qui permet de protéger une présentation par mot de passe tout en conservant la capacité des utilisateurs à accéder à ses propriétés.

**Note :** Par défaut, lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire précisément.

Si vous souhaitez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation chiffrée, vous pouvez définir la propriété [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) sur `true`. Ce code d’exemple montre comment chiffrer une présentation tout en offrant aux utilisateurs l’accès à ses propriétés de document :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vouloir vérifier qu’elle n’a pas été protégée par un mot de passe. Cela vous aide à éviter les erreurs et les problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans le bon mot de passe.

Ce code C# montre comment examiner une présentation pour voir si elle est protégée par mot de passe sans réellement la charger :
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted), qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected), qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **Vérifier l’utilisation du mot de passe d’une présentation**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Vérifier si le mot de passe correspond.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


Il renvoie `true` si la présentation a été chiffrée avec le mot de passe spécifié ; sinon, il renvoie `false`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock).
2. Cliquez sur **Déposez ou téléversez vos fichiers**.
3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.
4. Saisissez le mot de passe de votre choix pour la protection en modification et le mot de passe de votre choix pour la protection en lecture.
5. Si vous voulez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Mark as final**.
6. Cliquez sur **PROTECT NOW.**
7. Cliquez sur **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**  
Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**  
Une exception est levée si un mot de passe incorrect est utilisé, vous alertant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a-t-il des implications de performance lors du travail avec des présentations protégées par mot de passe ?**  
Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.