---
title: Protéger les présentations par mot de passe dans .NET
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/net/password-protected-presentation/
keywords:
- présentation protégée par mot de passe
- mot de passe d'ouverture
- chiffrer PowerPoint
- déchiffrer PowerPoint
- valider le mot de passe de la présentation
- vérifier le mot de passe de la présentation
- ouvrir une présentation chiffrée
- supprimer le chiffrement
- PowerPoint
- PPT
- PPTX
- présentation
- .NET
- C#
- Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et déchiffrer des présentations PowerPoint PPT et PPTX protégées par mot de passe en C# avec Aspose.Slides pour .NET."
---
## **Aperçu**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est requis pour charger et afficher le contenu de la présentation, ainsi cette protection assure la confidentialité.

Un mot de passe d'ouverture est différent d'un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu et n'empêche pas le chargement de la présentation. Pour gérer les mots de passe de modification des présentations, voir [Protéger les présentations en écriture](/slides/fr/net/write-protected-presentation/).

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [IProtectionManager.Encrypt](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/encrypt/) pour attribuer un mot de passe d'ouverture. Ensuite, utilisez [IPresentation.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentation/save/) pour enregistrer la présentation chiffrée.

L'exemple suivant chiffre une présentation PPTX :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **Conserver les propriétés du document publiques**

Par défaut, Aspose.Slides inclut les propriétés du document dans le chiffrement de la présentation. La propriété [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) contrôle ce comportement indépendamment du chiffrement du contenu des diapositives. Réglez‑la sur `false` avant d’appeler [IProtectionManager.Encrypt](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/encrypt/) lorsqu'un système d’indexation, de classification, de recherche ou de gestion de documents doit lire les métadonnées sans le mot de passe d'ouverture.

L'exemple suivant crée une présentation PPTX chiffrée tout en laissant ses propriétés intégrées du document publiques :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

Définir `EncryptDocumentProperties` sur `false` ne rend pas publiques les diapositives, les maîtres, les dispositions, les formes, les médias ou tout autre contenu de la présentation. Cela n'affecte que les propriétés du document. Pour lire ces propriétés sans charger le contenu chiffré, voir [Gérer les propriétés de la présentation](/slides/fr/net/presentation-properties/).

## **Charger une présentation chiffrée**

Définissez [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/) sur le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu'un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// Travailler avec la présentation déchiffrée.
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/removeencryption/), puis enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) pour obtenir [IPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/) sans créer une instance complète de présentation. Vérifiez [IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/ispasswordprotected/) avant de demander ou de valider un mot de passe. Lorsqu'une protection est présente, validez la valeur fournie avec [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/checkpassword/).

### **Flux de travail avec un chemin de fichier**

L'exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/), puis charge la présentation complète :

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Flux de travail avec un flux**

La surcharge de flux de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fournit le même flux de travail. Réinitialisez la position d'un flux positionnable avant de charger la présentation complète depuis ce flux.

L'exemple suivant utilise un fichier PPT :

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **Valeurs de retour de CheckPassword**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/checkpassword/) renvoie `true` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Elle renvoie `false` dans chacun de ces cas :

- Le mot de passe est incorrect.
- La présentation ne possède pas de mot de passe d'ouverture.
- Le mot de passe fourni est `null` ou vide.

Le comportement est identique pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, inspectez [IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/isencrypted/) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez `IPresentationInfo.IsPasswordProtected` comme indiqué ci‑dessus.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
Ne consignez pas les mots de passe d'ouverture ni ne les incluez dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.

Les propriétés publiques du document peuvent révéler les noms d'auteur, les titres, les sujets, les mots‑clés, les informations d'entreprise, les commentaires et les valeurs personnalisées même si le contenu de la présentation est chiffré. Chiffrez les métadonnées sensibles avec la présentation. Laisser les propriétés publiques doit être une décision explicite prise uniquement lorsque les systèmes doivent indexer, classifier, rechercher ou gérer le fichier sans mot de passe d'ouverture.
{{% /alert %}}

## **Protéger par mot de passe une présentation en ligne**

1. Ouvrez l'application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléversez la présentation.
1. Saisissez un mot de passe pour la protection de visualisation.
1. Optionnellement, saisissez un mot de passe distinct pour la protection en écriture.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger les présentations en écriture](/slides/fr/net/write-protected-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est requis pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis-je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez si une protection par mot de passe d'ouverture est présente, et validez le mot de passe avant de créer une instance complète de présentation.

**Une application peut‑elle lire les métadonnées sans le mot de passe d'ouverture ?**

Oui, mais uniquement lorsque la présentation a été chiffrée avec `EncryptDocumentProperties` défini sur `false`. L'application doit alors utiliser le mode de chargement uniquement des propriétés du document décrit dans [Gérer les propriétés de la présentation](/slides/fr/net/presentation-properties/).

**Les flux de travail de vérification du mot de passe prennent‑ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation des mots de passe basées sur le chemin de fichier ou le flux se comportent de la même manière pour les présentations PPT et PPTX.