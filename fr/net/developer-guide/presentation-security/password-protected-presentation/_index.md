---
title: Sécuriser les présentations avec des mots de passe en .NET
linktitle: Protection par mot de passe
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
- définir un mot de passe
- ajouter un mot de passe
- chiffrer PowerPoint
- chiffrer présentation
- déchiffrer PowerPoint
- déchiffrer présentation
- protection en écriture
- sécurité PowerPoint
- sécurité présentation
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
description: Apprenez comment verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour .NET. Sécurisez vos présentations.
---
## **Introduction**

Lorsque vous protégez une présentation par mot de passe, vous définissez un mot de passe qui impose certaines restrictions sur la présentation. Pour lever ces restrictions, le mot de passe doit être saisi. Une présentation protégée par mot de passe est considérée comme une présentation verrouillée.

En général, vous pouvez définir un mot de passe pour imposer ces restrictions sur une présentation :

- **Modification**

Si vous voulez que seuls certains utilisateurs puissent modifier votre présentation, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre présentation à moins de fournir le mot de passe.

Cependant, même sans le mot de passe, un utilisateur pourra toujours accéder à votre document et l’ouvrir. En mode lecture seule, il pourra voir le contenu — y compris les hyperliens, animations, effets et autres éléments — mais il ne pourra ni copier les éléments ni enregistrer la présentation.

- **Ouverture**

Si vous voulez que seuls certains utilisateurs puissent ouvrir votre présentation, vous pouvez définir une restriction d’ouverture. Cette restriction empêche les personnes de voir le contenu de votre présentation à moins de fournir le mot de passe.

Techniquement, la restriction d’ouverture empêche également les utilisateurs de modifier vos présentations — si quelqu’un ne peut pas ouvrir une présentation, il ne peut pas la modifier ni y apporter de changements.

**Remarque :** lorsque vous protégez une présentation par mot de passe pour empêcher son ouverture, le fichier de présentation devient chiffré.

## **Protection par mot de passe dans Aspose.Slides**

**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les présentations aux formats suivants :

- PPTX et PPT – Présentations Microsoft PowerPoint
- ODP – Présentations OpenDocument
- OTP – Modèles de présentation OpenDocument

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les présentations afin d’empêcher les modifications de la manière suivante :

- Chiffrer une présentation
- Définir une protection en écriture sur une présentation

**Autres opérations**

Aspose.Slides vous permet d’effectuer des tâches supplémentaires liées à la protection par mot de passe et au chiffrement de la façon suivante :

- Déchiffrer une présentation ; ouvrir une présentation chiffrée
- Supprimer le chiffrement ; désactiver la protection par mot de passe
- Supprimer la protection en écriture d’une présentation
- Récupérer les propriétés d’une présentation chiffrée
- Vérifier si une présentation est protégée par mot de passe avant de la charger
- Vérifier si une présentation est chiffrée
- Vérifier si une présentation est protégée par mot de passe

## **Protéger une présentation avec un mot de passe**

Vous pouvez chiffrer une présentation en définissant un mot de passe. Ensuite, pour modifier la présentation verrouillée, un utilisateur doit fournir le mot de passe.

Pour chiffrer (ou protéger par mot de passe) une présentation, utilisez la méthode `Encrypt` de [ProtectionManager](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager) pour définir un mot de passe. Transmettez le mot de passe à la méthode `Encrypt`, puis utilisez la méthode `Save` pour enregistrer la présentation désormais chiffrée.

Cet exemple de code montre comment chiffrer une présentation :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **Définir une protection en écriture sur une présentation** 

Vous pouvez ajouter une mention « Ne pas modifier » à une présentation. Cela informe les utilisateurs que vous ne souhaitez pas qu’ils apportent des modifications à la présentation.

**Remarque :** le processus de protection en écriture ne chiffre pas la présentation. Par conséquent, les utilisateurs—s’ils le souhaitent—peuvent modifier la présentation, mais pour enregistrer les modifications, ils devront l’enregistrer sous un autre nom.

Pour définir la protection en écriture, utilisez la méthode `SetWriteProtection`. Cet exemple de code montre comment définir la protection en écriture sur une présentation :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **Charger une présentation chiffrée**

Aspose.Slides vous permet de charger une présentation chiffrée en transmettant le mot de passe correct. Cet exemple de code montre comment charger une présentation chiffrée :

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // Travailler avec la présentation déchiffrée.
}
```

## **Supprimer le chiffrement d’une présentation**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’une présentation, permettant ainsi aux utilisateurs d’y accéder ou de la modifier sans restriction.

Pour supprimer le chiffrement ou la protection par mot de passe, appelez la méthode [RemoveEncryption](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/methods/removeencryption). Cet exemple de code montre comment supprimer le chiffrement d’une présentation :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **Supprimer la protection en écriture d’une présentation**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture d’un fichier de présentation. Ainsi, les utilisateurs peuvent le modifier à leur guise—et ils ne recevront aucun avertissement lors de ces opérations.

Vous pouvez supprimer la protection en écriture en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/methods/removewriteprotection). Cet exemple de code montre comment supprimer la protection en écriture d’une présentation :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **Obtenir les propriétés d’une présentation chiffrée**

En général, les utilisateurs rencontrent des difficultés pour récupérer les propriétés du document d’une présentation chiffrée ou protégée par mot de passe. Cependant, Aspose.Slides offre un mécanisme qui vous permet de protéger une présentation par mot de passe tout en conservant la possibilité pour les utilisateurs d’accéder à ses propriétés.

**Remarque :** par défaut, lorsque Aspose.Slides chiffre une présentation, les propriétés du document de la présentation sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire précisément.

Si vous souhaitez que les utilisateurs puissent toujours accéder aux propriétés d’une présentation chiffrée, définissez la propriété `EncryptDocumentProperties` de [IProtectionManager](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/) sur `false`. Cet exemple de code montre comment chiffrer une présentation tout en laissant les utilisateurs accéder à ses propriétés de document :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Charger uniquement les propriétés du document d’une présentation chiffrée**

Pour examiner les métadonnées d’une présentation chiffrée sans charger ses diapositives ni son autre contenu, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/) et définissez [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) sur `true`. Dans ce mode, Aspose.Slides ignore le mot de passe et ne charge que les propriétés du document qui sont publiquement accessibles.

Le code suivant lit les propriétés de document intégrées et personnalisées via [IPresentation.DocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/documentproperties/) :

```c#
using Aspose.Slides;

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

Ce flux de travail ne fonctionne que lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement de la présentation. Si les propriétés du document sont chiffrées, définir `OnlyLoadDocumentProperties` sur `true` entraîne une exception parce que le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés du document chiffrées ou charger l’intégralité de la présentation, y compris ses diapositives et son autre contenu, fournissez la valeur correcte de `Password` dans [LoadOptions](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/).

## **Vérifier si une présentation est protégée par mot de passe**

Avant de charger une présentation, vous pouvez vérifier qu’elle n’est pas protégée par un mot de passe. Cela vous aide à éviter les erreurs et les problèmes similaires qui surviennent lorsqu’une présentation protégée par mot de passe est chargée sans le bon mot de passe.

Ce code C# montre comment examiner une présentation pour déterminer si elle est protégée par mot de passe sans réellement la charger :

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **Vérifier si une présentation est chiffrée**

Aspose.Slides permet de vérifier si une présentation est chiffrée. Pour réaliser cette tâche, vous pouvez utiliser la propriété [IsEncrypted](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/properties/isencrypted), qui renvoie `true` si la présentation est chiffrée ou `false` sinon.

Cet exemple de code montre comment vérifier si une présentation est chiffrée :

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **Vérifier si une présentation est protégée en écriture**

Aspose.Slides permet de vérifier si une présentation est protégée en écriture. Pour réaliser cette tâche, vous pouvez utiliser la propriété [IsWriteProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/protectionmanager/properties/iswriteprotected), qui renvoie `true` si la présentation est protégée en écriture ou `false` sinon.

Cet exemple de code montre comment vérifier si une présentation est protégée en écriture :

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **Vérifier l’utilisation du mot de passe d’une présentation**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de présentation. Aspose.Slides fournit les moyens de valider un mot de passe.

Cet exemple de code montre comment valider un mot de passe :

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // Vérifier si le mot de passe correspond.
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

Il renvoie `true` si la présentation a été chiffrée avec le mot de passe indiqué ; sinon, il renvoie `false`.

{{% alert color="info" title="Voir aussi" %}} 
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Accédez à notre page [**Aspose.Slides Lock**](https://products.aspose.app/slides/fr/lock). 
1. Cliquez sur **Déposez ou téléchargez vos fichiers**.
1. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 
1. Saisissez votre mot de passe préféré pour la protection en modification et votre mot de passe préféré pour la protection en visualisation.
1. Si vous voulez que les utilisateurs voient votre présentation comme la copie finale, cochez la case **Marquer comme final**.
1. Cliquez sur **PROTECT NOW.** 
1. Cliquez sur **DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, notamment les algorithmes basés sur AES, garantissant un niveau élevé de sécurité des données pour vos présentations.

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’une présentation ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous alertant que l’accès à la présentation est refusé. Cela aide à prévenir les accès non autorisés et protège le contenu de la présentation.

**Y a‑t‑il des implications de performance lors de la manipulation de présentations protégées par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire un léger surcoût lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de présentation.