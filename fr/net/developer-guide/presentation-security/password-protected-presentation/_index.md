---
title: Présentation protégée par mot de passe
type: docs
weight: 20
url: /fr/net/password-protected-presentation/
keywords: "Verrouiller PowerPoint, déverrouiller PowerPoint, protéger PowerPoint, définir un mot de passe, ajouter un mot de passe, crypter PowerPoint, déchiffrer PowerPoint, protection en écriture, sécurité PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Protection par mot de passe de PowerPoint, cryptage et sécurité en C# ou .NET"

---


## **À propos de la protection par mot de passe**
### **Comment fonctionne la protection par mot de passe pour une présentation ?**
Lorsque vous protégez par mot de passe une présentation, cela signifie que vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour supprimer les restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

Typiquement, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

  Si vous souhaitez que seuls certains utilisateurs modifient votre présentation, vous pouvez définir une restriction de modification. La restriction ici empêche les personnes de modifier, changer ou copier des éléments de votre présentation (à moins qu'elles fournissent le mot de passe). 

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. Dans ce mode de lecture seule, l'utilisateur peut voir le contenu ou les éléments—hyperliens, animations, effets et autres—dans votre présentation, mais il ne peut pas copier des éléments ou enregistrer la présentation. 

- **Ouverture**

  Si vous souhaitez que seuls certains utilisateurs ouvrent votre présentation, vous pouvez définir une restriction d'ouverture. La restriction ici empêche les personnes de même voir le contenu de votre présentation (à moins qu'elles fournissent le mot de passe).

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos présentations : Lorsque les personnes ne peuvent pas ouvrir une présentation, elles ne peuvent pas la modifier ou y apporter des changements. 
  
  **Remarque** que lorsque vous protégez par mot de passe une présentation pour empêcher l'ouverture, le fichier de présentation devient crypté.

## Comment protéger par mot de passe une présentation en ligne

1. Allez sur notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock). 

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléchargez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 

4. Saisissez votre mot de passe préféré pour la protection de modification ; Saisissez votre mot de passe préféré pour la protection de visualisation. 

5. Si vous souhaitez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTÉGER MAINTENANT.** 

7. Cliquez sur **TÉLÉCHARGER MAINTENANT.**

### **Protection par mot de passe pour les présentations dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le cryptage et des opérations similaires pour les présentations dans ces formats : 

- PPTX et PPT - Présentation Microsoft PowerPoint 
- ODP - Présentation OpenDocument 
- OTP - Modèle de présentation OpenDocument 

**Opérations prises en charge**

Aspose.Slides vous permet d'utiliser la protection par mot de passe sur des présentations pour empêcher les modifications de ces manières :

- Crypter une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d'effectuer d'autres tâches impliquant la protection par mot de passe et le cryptage de ces manières :

- Décrypter une présentation ; ouvrir une présentation cryptée
- Supprimer le cryptage ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d'une présentation
- Obtenir les propriétés d'une présentation cryptée
- Vérifier si une présentation est protégée par mot de passe avant de la charger
- Vérifier si une présentation est cryptée
- Vérifier si une présentation est protégée par mot de passe.

## Crypter une présentation

Vous pouvez crypter une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe. 

Pour crypter ou protéger par mot de passe une présentation, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager)) pour définir un mot de passe pour la présentation. Vous passez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer la présentation désormais cryptée. 

Cet exemple de code vous montre comment crypter une présentation :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## Définir une protection en écriture sur une présentation 

Vous pouvez ajouter une marque indiquant "Ne pas modifier" à une présentation. De cette manière, vous indiquez aux utilisateurs que vous ne souhaitez pas qu'ils apportent des modifications à la présentation.  

**Remarque** que le processus de protection en écriture ne crypte pas la présentation. Par conséquent, les utilisateurs—s'ils le souhaitent réellement—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront créer une présentation avec un nom différent. 

Pour définir une protection en écriture, vous devez utiliser la méthode setWriteProtection. Cet exemple de code vous montre comment définir une protection en écriture sur une présentation :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## Décrypter une présentation ; Ouvrir une présentation cryptée

Aspose.Slides vous permet de charger un fichier crypté en passant son mot de passe. Pour décrypter une présentation, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) sans paramètres. Vous devrez alors entrer le mot de passe correct pour charger la présentation. 

Cet exemple de code vous montre comment décrypter une présentation : 

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
  // travaillez avec la présentation décryptée
}
```

## Supprimer le cryptage ; Désactiver la protection par mot de passe

Vous pouvez supprimer le cryptage ou la protection par mot de passe d'une présentation. De cette manière, les utilisateurs peuvent accéder ou modifier la présentation sans restrictions. 

Pour supprimer le cryptage ou la protection par mot de passe, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption). Cet exemple de code vous montre comment supprimer le cryptage d'une présentation :

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## Supprimer la protection en écriture d'une présentation

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture utilisée sur un fichier de présentation. De cette manière, les utilisateurs peuvent modifier comme ils le souhaitent—et ils ne reçoivent aucun avertissement lorsqu'ils effectuent de telles tâches.

Vous pouvez supprimer la protection en écriture d'une présentation en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection). Cet exemple de code vous montre comment supprimer la protection en écriture d'une présentation :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## Obtenir les propriétés d'une présentation cryptée

En général, les utilisateurs ont du mal à obtenir les propriétés du document d'une présentation cryptée ou protégée par mot de passe. Aspose.Slides, cependant, offre un mécanisme qui vous permet de protéger par mot de passe une présentation tout en conservant les moyens pour les utilisateurs d'accéder aux propriétés de cette présentation.

**Remarque** que lorsque Aspose.Slides crypte une présentation, les propriétés du document de la présentation sont également protégées par mot de passe par défaut. Mais si vous devez rendre les propriétés de la présentation accessibles (même après que la présentation soit cryptée), Aspose.Slides vous permet de le faire précisément. 

Si vous souhaitez que les utilisateurs conservent la capacité d'accéder aux propriétés d'une présentation que vous avez cryptée, vous pouvez définir la propriété [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) sur `true`. Cet exemple de code vous montre comment crypter une présentation tout en fournissant les moyens aux utilisateurs d'accéder à ses propriétés de document :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **Vérifier si une présentation est protégée par mot de passe avant de la charger**

Avant de charger une présentation, vous pouvez vouloir vérifier et confirmer que la présentation n'a pas été protégée par un mot de passe. De cette manière, vous évitez les erreurs et les problèmes similaires, qui surviennent lorsqu'une présentation protégée par mot de passe est chargée sans son mot de passe.

Ce code C# vous montre comment examiner une présentation pour voir si elle est protégée par mot de passe (sans charger la présentation elle-même) :

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("La présentation est protégée par mot de passe : " + presentationInfo.IsPasswordProtected);
```



## Vérifier si une présentation est cryptée

Aspose.Slides vous permet de vérifier si une présentation est cryptée. Pour effectuer cette tâche, vous pouvez utiliser la propriété [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted), qui retourne `true` si la présentation est cryptée ou `false` si la présentation n'est pas cryptée. 

Cet exemple de code vous montre comment vérifier si une présentation est cryptée :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## Vérifier si une présentation est protégée en écriture

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour effectuer cette tâche, vous pouvez utiliser la propriété [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected), qui retourne `true` si la présentation est protégée en écriture ou `false` si la présentation n'est pas protégée en écriture. 

Cet exemple de code vous montre comment vérifier si une présentation est protégée en écriture :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Valider ou confirmer qu'un mot de passe spécifique a été utilisé pour protéger une présentation**

Vous pouvez vouloir vérifier et confirmer qu'un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides vous fournit les moyens de valider un mot de passe. 

Cet exemple de code vous montre comment valider un mot de passe :

```c#
using (IPresentation pres = new Presentation("pres.pptx"))
{
    // vérifier si "pass" correspond à
    bool isWriteProtected = pres.ProtectionManager.CheckWriteProtection("my_password");
}
```

Cela retourne `true` si la présentation a été cryptée avec le mot de passe spécifié. Sinon, cela retourne `false`. 

{{% alert color="primary" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}