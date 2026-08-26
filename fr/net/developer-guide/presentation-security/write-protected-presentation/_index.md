---
title: Protection en écriture des présentations en .NET
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/net/write-protected-presentation/
keywords:
- protection en écriture
- protection en écriture PowerPoint
- mot de passe de modification
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l'aide d'Aspose.Slides pour .NET."
---
## **Introduction**

Un mot de passe de protection en écriture restreint la modification d'une présentation mais n'encrypte pas son contenu. Les utilisateurs peuvent charger et visualiser une présentation protegee en écriture sans le mot de passe. Selon l'application, ils peuvent egalement modifier le contenu et l'enregistrer sous un autre nom, ainsi la protection en ecriture ne doit pas etre consideree comme un mecanisme de confidentialite.

Un mot de passe d'ouverture a un objectif different : il chiffre la presentation et est requis pour charger son contenu. Pour chiffrer une presentation ou valider un mot de passe d'ouverture, consultez [Présentations protégées par mot de passe](/slides/fr/net/password-protected-presentation/).

Les flux de travail de cet article s'appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX; lors de l'enregistrement au format PPT, utilisez l'extension `.ppt` et le format d'enregistrement PPT correspondant.

## **Définir la protection en écriture sur une présentation**

Utilisez [IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/setwriteprotection/) pour attribuer un mot de passe de modification d'une présentation. L'enregistrement de la présentation conserve le paramètre de protection.

L'exemple suivant définit la protection en écriture sur une présentation PPTX :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **Charger une présentation protégée en écriture**

Étant donné que la protection en écriture n'encrypte pas le contenu de la présentation, aucun mot de passe n'est requis pour charger la présentation. Le mot de passe n'est pertinent que lors de la validation de l'autorisation de modifier la présentation protégée.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Ne transmettez pas de mot de passe de protection en écriture à [LoadOptions.Password](https://reference.aspose.com/slides/fr/net/aspose.slides/loadoptions/password/). Cette propriété accepte un mot de passe d'ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d'ouverture pour la charger et gérez séparément le mot de passe de protection en écriture.

## **Supprimer la protection en écriture d'une présentation**

Utilisez [IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/removewriteprotection/) pour supprimer la restriction de modification, puis enregistrez la présentation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **Vérifier si une présentation est protégée en écriture**

Pour inspecter un fichier sans créer une instance complète de [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), appelez [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) et examinez [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/iswriteprotected/). La propriété utilise [NullableBool](https://reference.aspose.com/slides/fr/net/aspose.slides/nullablebool/) et renvoie `NullableBool.True` lorsqu'une protection en écriture est détectée.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

La surcharge par flux de [IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationfactory/getpresentationinfo/) fournit la même information pour une présentation fournie sous forme de flux.

## **Valider un mot de passe de protection en écriture**

Utilisez [IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/checkwriteprotection/) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d'abord [IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/iswriteprotected/) afin que l'application ne demande ou ne valide un mot de passe que lorsque la protection en écriture est présente.

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/checkwriteprotection/) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d'ouverture ni ne détermine si le contenu chiffré peut être chargé. Inversement, [IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/fr/net/aspose.slides/ipresentationinfo/checkpassword/) ne valide qu'un mot de passe d'ouverture. Si une présentation complète a déjà été chargée, [IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/fr/net/aspose.slides/iprotectionmanager/checkwriteprotection/) fournit la même vérification de protection en écriture via son gestionnaire de protection.

Dans les applications de production, ne consignez pas les mots de passe et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées et inutiles, et conservez les mots de passe en mémoire uniquement pendant la durée nécessaire.

{{% alert color="info" title="Voir aussi" %}}
- [Présentations protégées par mot de passe](/slides/fr/net/password-protected-presentation/)
- [Présentations en lecture seule](/slides/fr/net/read-only-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre-t-elle une présentation ?**

Non. Elle restreint la modification mais laisse le contenu de la présentation disponible pour le chargement et la visualisation.

**Le mot de passe de protection en écriture est-il requis pour ouvrir une présentation ?**

Non. Seul un mot de passe d'ouverture est requis pour charger le contenu chiffré d'une présentation.

**Une présentation peut-elle avoir à la fois un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d'ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l'autorisation de modification est requise.