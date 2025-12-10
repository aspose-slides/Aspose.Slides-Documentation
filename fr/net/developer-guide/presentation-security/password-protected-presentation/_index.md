---
title: Sécuriser les présentations avec des mots de passe en .NET
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/net/password-protected-presentation/
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
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: Découvrez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour .NET. Sécurisez vos présentations.
---

## **Aperçu**

Lorsque vous protégez un diaporama par mot de passe, cela signifie que vous définissez un mot de passe qui impose certaines restrictions au diaporama. Pour supprimer ces restrictions, le mot de passe doit être saisi. Un diaporama protégé par mot de passe est considéré comme un diaporama verrouillé.

Typiquement, vous pouvez définir un mot de passe pour appliquer ces restrictions à un diaporama :

- **Modification**

Si vous souhaitez que seuls certains utilisateurs puissent modifier votre diaporama, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre diaporama à moins qu'elles ne fournissent le mot de passe.  

Cependant, même sans le mot de passe, un utilisateur pourra toujours accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut visualiser le contenu—y compris les hyperliens, les animations, les effets et d'autres éléments—dans votre diaporama, mais il ne peut pas copier d'éléments ni enregistrer le diaporama.

- **Ouverture**

Si vous souhaitez que seuls certains utilisateurs puissent ouvrir votre diaporama, vous pouvez définir une restriction d'ouverture. Cette restriction empêche les personnes de même visualiser le contenu de votre diaporama à moins qu'elles ne fournissent le mot de passe.  

Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos diaporamas — si les personnes ne peuvent pas ouvrir un diaporama, elles ne peuvent pas le modifier ni y apporter des changements.

**Note :** Lorsque vous protégez un diaporama par mot de passe pour en empêcher l'ouverture, le fichier du diaporama devient chiffré.

## **Protection par mot de passe dans Aspose.Slides**

**Formats pris en charge**  
Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les diaporamas dans ces formats :

- PPTX et PPT – Présentations Microsoft PowerPoint
- ODP – Présentations OpenDocument
- OTP – Modèles de présentation OpenDocument

**Opérations prises en charge**  
Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les diaporamas afin d’empêcher les modifications de la manière suivante :

- Chiffrer un diaporama
- Définir la protection en écriture sur un diaporama

**Autres opérations**  
Aspose.Slides vous permet d’exécuter des tâches supplémentaires impliquant la protection par mot de passe et le chiffrement de la manière suivante :

- Déchiffrer un diaporama ; ouvrir un diaporama chiffré
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d'un diaporama
- Récupérer les propriétés d'un diaporama chiffré
- Vérifier si un diaporama est protégé par mot de passe avant de le charger
- Vérifier si un diaporama est chiffré
- Vérifier si un diaporama est protégé par mot de passe

## **Protéger un diaporama avec un mot de passe**

Vous pouvez chiffrer un diaporama en définissant un mot de passe. Ensuite, pour modifier le diaporama verrouillé, l'utilisateur doit fournir le mot de passe.  

Pour chiffrer (ou protéger par mot de passe) un diaporama, utilisez la méthode `Encrypt` de [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) pour définir un mot de passe. Transmettez le mot de passe à la méthode `Encrypt`, puis utilisez la méthode `Save` pour enregistrer le diaporama maintenant chiffré.  

Ce code d'exemple montre comment chiffrer un diaporama :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **Définir la protection en écriture sur un diaporama**

Vous pouvez ajouter une mention « Ne pas modifier » à un diaporama. Cela informe les utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications au diaporama.  

**Note :** Le processus de protection en écriture ne chiffre pas le diaporama. Ainsi, les utilisateurs—s'ils le souhaitent—peuvent modifier le diaporama, mais pour enregistrer les changements, ils devront le sauvegarder sous un autre nom.  

Pour définir la protection en écriture, utilisez la méthode `SetWriteProtection`. Ce code d'exemple montre comment appliquer la protection en écriture à un diaporama :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **Charger un diaporama chiffré**

Aspose.Slides vous permet de charger un diaporama chiffré en fournissant le mot de passe correct. Ce code d'exemple montre comment charger un diaporama chiffré :
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Travaillez avec la présentation déchiffrée.
}
```


## **Supprimer le chiffrement d'un diaporama**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d'un diaporama, permettant aux utilisateurs d'y accéder ou de le modifier sans restrictions.  

Pour supprimer le chiffrement ou la protection par mot de passe, appelez la méthode [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption). Ce code d'exemple montre comment supprimer le chiffrement d'un diaporama :
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **Supprimer la protection en écriture d'un diaporama**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture d'un fichier de diaporama. Ainsi, les utilisateurs peuvent le modifier à leur guise—et ils ne recevront aucun avertissement lors de ces actions.  

Vous pouvez supprimer la protection en écriture en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection). Ce code d'exemple montre comment enlever la protection en écriture d'un diaporama :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **Obtenir les propriétés d'un diaporama chiffré**

Typiquement, les utilisateurs rencontrent des difficultés à récupérer les propriétés du document d'un diaporama chiffré ou protégé par mot de passe. Cependant, Aspose.Slides propose un mécanisme qui permet de protéger un diaporama par mot de passe tout en conservant la possibilité pour les utilisateurs d'accéder à ses propriétés.  

**Note :** Par défaut, lorsque Aspose.Slides chiffre un diaporama, les propriétés du document du diaporama sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire.  

Si vous souhaitez que les utilisateurs conservent la capacité d'accéder aux propriétés d'un diaporama chiffré, vous pouvez définir la propriété [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) sur `true`. Ce code d'exemple montre comment chiffrer un diaporama tout en offrant aux utilisateurs l'accès à ses propriétés de document :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **Vérifier si un diaporama est protégé par mot de passe**

Avant de charger un diaporama, il peut être utile de vérifier qu'il n'est pas protégé par un mot de passe. Cela vous évite les erreurs et les problèmes similaires qui surviennent lorsqu'un diaporama protégé par mot de passe est chargé sans le bon mot de passe.  

Ce code C# montre comment examiner un diaporama pour voir s'il est protégé par mot de passe sans réellement le charger :
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **Vérifier si un diaporama est chiffré**

Aspose.Slides vous permet de vérifier si un diaporama est chiffré. Pour accomplir cette tâche, vous pouvez utiliser la propriété [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted), qui renvoie `true` si le diaporama est chiffré ou `false` sinon.  

Ce code d'exemple montre comment vérifier si un diaporama est chiffré :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **Vérifier si un diaporama est protégé en écriture**

Aspose.Slides vous permet de vérifier si un diaporama est protégé en écriture. Pour accomplir cette tâche, vous pouvez utiliser la propriété [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected), qui renvoie `true` si le diaporama est protégé en écriture ou `false` sinon.  

Ce code d'exemple montre comment vérifier si un diaporama est protégé en écriture :
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **Vérifier l'utilisation du mot de passe du diaporama**

Vous pouvez souhaiter vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de diaporama. Aspose.Slides fournit les moyens de valider un mot de passe.  

Ce code d'exemple montre comment valider un mot de passe :
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Vérifier si le mot de passe correspond.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


Il renvoie `true` si le diaporama a été chiffré avec le mot de passe spécifié ; sinon, il renvoie `false`.

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Protéger un diaporama par mot de passe en ligne**

1. Allez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 
2. Cliquez sur **Déposez ou téléchargez vos fichiers**.
3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur.
4. Saisissez votre mot de passe préféré pour la protection en modification et votre mot de passe préféré pour la protection en lecture.
5. Si vous voulez que les utilisateurs voient votre diaporama comme la copie finale, cochez la case **Mark as final**.
6. Cliquez sur **PROTECT NOW.** 
7. Cliquez sur **DOWNLOAD NOW.**

![Protéger les présentations PowerPoint](slides-lock.png)

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**  
Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d'ouverture d'un diaporama ?**  
Une exception est levée si un mot de passe incorrect est utilisé, vous avertissant que l'accès au diaporama est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu du diaporama.

**Y a-t-il des impacts sur les performances lors du travail avec des diaporamas protégés par mot de passe ?**  
Le processus de chiffrement et de déchiffrement peut introduire une légère surcharge lors des opérations d'ouverture et d'enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n'affecte pas de manière significative le temps de traitement global de vos tâches de diaporama.