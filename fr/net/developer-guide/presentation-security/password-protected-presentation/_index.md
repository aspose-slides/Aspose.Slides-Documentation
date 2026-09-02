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
description: "Découvrez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour .NET. Sécurisez vos présentations."
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions à la présentation. Pour supprimer ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions à une présentation :

- **Modification**

Si vous voulez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation, à moins qu’elles ne fournissent le mot de passe.  

Cependant, même sans le mot de passe, un utilisateur pourra toujours accéder à votre document et l’ouvrir. En mode lecture seule, l’utilisateur peut consulter le contenu — y compris les hyperliens, animations, effets et autres éléments — de votre présentation, mais il ne peut ni copier d’éléments ni enregistrer la présentation.

- **Ouverture**

Si vous voulez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de même voir le contenu de votre présentation, à moins qu’elles ne fournissent le mot de passe.

Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations — si les gens ne peuvent pas ouvrir une présentation, ils ne peuvent pas la modifier ni y apporter de changements.

**Remarque :** Lorsque vous protégez une présentation par mot de passe pour empêcher l’ouverture, le fichier de présentation devient chiffré.

## **Protection par mot de passe dans Aspose.Slides**

**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations aux formats suivants :

- PPTX et PPT – Présentations Microsoft PowerPoint
- ODP – Présentations OpenDocument
- OTP – Modèles de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de la manière suivante :

- Chiffrer une présentation
- Appliquer une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer des tâches supplémentaires liées à la protection par mot de passe et au chiffrement de la manière suivante :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Récupérer les propriétés d’une présentation chiffrée
- Vérifier si une présentation est protégée par mot de passe avant de la charger
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe

## **Protéger une présentation avec un mot de passe**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, l’utilisateur doit fournir le mot de passe.

Pour chiffrer (ou protéger par mot de passe) une présentation, utilisez la méthode `Encrypt` de [ProtectionManager](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager) pour définir un mot de passe. Passez le mot de passe à la méthode `Encrypt`, puis utilisez la méthode `Save` pour enregistrer la présentation maintenant chiffrée.

Ce code d’exemple montre comment chiffrer une présentation :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Appliquer une protection en écriture sur une présentation** 

Vous pouvez ajouter une mention « Do not modify » à une présentation. Cela informe les utilisateurs que vous ne voulez pas qu’ils modifient la présentation.

**Remarque :** Le processus de protection en écriture ne chiffre pas la présentation. Ainsi, les utilisateurs—s’ils le souhaitent—peuvent modifier la présentation, mais pour enregistrer les changements, ils devront l’enregistrer sous un autre nom.

Pour appliquer une protection en écriture, utilisez la méthode `SetWriteProtection`. Ce code d’exemple montre comment appliquer une protection en écriture sur une présentation :

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

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation, permettant aux utilisateurs d’y accéder ou de la modifier sans restriction.

Pour supprimer le chiffrement ou la protection par mot de passe, appelez la méthode [RemoveEncryption](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/methods/removeencryption). Ce code d’exemple montre comment supprimer le chiffrement d’une présentation :

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture d’un fichier de présentation. Ainsi, les utilisateurs peuvent la modifier à leur guise et ne recevront aucun avertissement lors de ces opérations.

Vous pouvez supprimer la protection en écriture en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/methods/removewriteprotection). Ce code d’exemple montre comment supprimer la protection en écriture d’une présentation :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs ont du mal à récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides offre un mécanisme qui permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder à ses propriétés.

**Remarque :** Par défaut, lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après chiffrement, Aspose.Slides vous le permet.

Si vous souhaitez que les utilisateurs conservent la capacité d’accéder aux propriétés d’une présentation chiffrée, définissez la propriété `EncryptDocumentProperties` de [IProtectionManager](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/) sur `false`. Ce code d’exemple montre comment chiffrer une présentation tout en permettant aux utilisateurs d’accéder à ses propriétés de document :

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Charger uniquement les propriétés du document d’une présentation chiffrée**

Pour inspecter les métadonnées d’une présentation chiffrée sans charger ses diapositives ou autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/) et définissez [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) sur `true`. Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document accessibles publiquement.

L’exemple de code suivant lit les propriétés intégrées et personnalisées du document via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/documentproperties/) :

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

Ce flux de travail ne fonctionne que lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement de la présentation. Si les propriétés du document sont chiffrées, définir `OnlyLoadDocumentProperties` sur `true` entraîne une exception, car le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés du document chiffrées ou charger la présentation complète, y compris ses diapositives et autre contenu, fournissez la valeur correcte `Password` dans [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/) .

## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vérifier qu’elle n’a pas été protégée par un mot de passe. Cela vous aide à éviter les erreurs et problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans le bon mot de passe.

Ce code C# montre comment examiner une présentation pour savoir si elle est protégée par mot de passe sans réellement la charger :

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides vous permet de vérifier si une présentation est chiffrée. Pour cela, vous pouvez utiliser la propriété [IsEncrypted](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/properties/isencrypted), qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est chiffrée :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides vous permet de vérifier si une présentation est protégée en écriture. Pour cela, vous pouvez utiliser la propriété [IsWriteProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/properties/iswriteprotected), qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Ce code d’exemple montre comment vérifier si une présentation est protégée en écriture :

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Vérifier l’utilisation d’un mot de passe de présentation**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Ce code d’exemple montre comment valider un mot de passe :

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Vérifier si le mot de passe correspond.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Il renvoie `true` si la présentation a été chiffrée avec le mot de passe indiqué ; sinon, il renvoie `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/fr/lock). 
1. Cliquez sur **Drop or upload your files**. 
1. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 
1. Saisissez le mot de passe souhaité pour la protection en modification et le mot de passe souhaité pour la protection en visualisation. 
1. Si vous voulez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Mark as final**. 
1. Cliquez sur **PROTECT NOW.** 
1. Cliquez sur **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous signalant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des impacts sur les performances lorsqu’on travaille avec des présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.