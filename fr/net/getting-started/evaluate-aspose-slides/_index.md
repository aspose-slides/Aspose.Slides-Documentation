---
title: Évaluer Aspose.Slides
type: docs
weight: 75
url: /fr/net/evaluate-aspose-slides/
keywords:
- évaluer Aspose.Slides
- évaluation Aspose.Slides
- version d'évaluation
- fonctionnalité complète
- filigrane d'évaluation
- acheter Aspose.Slides
- limitation
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Évaluez Aspose.Slides pour .NET et explorez les fonctionnalités de l'API pour les présentations PowerPoint (PPT, PPTX) et OpenDocument (ODP) — commencez votre essai gratuit."
---
## **Évaluation d'Aspose.Slides**

Vous pouvez télécharger Aspose.Slides pour l'évaluation. Le package d'évaluation est identique au package acheté ; il devient sous licence après que vous ajoutiez quelques lignes de code pour appliquer la licence.

Sans licence, Aspose.Slides offre toutes ses fonctionnalités en mode d'évaluation, avec deux limitations : il ajoute une zone de texte de filigrane d'évaluation à chaque diapositive de chaque présentation qu'il enregistre, et le texte que votre code lit d'une présentation est tronqué à ses premiers caractères, suivi d'un avis sur la limitation d'évaluation. Le texte que votre code écrit est enregistré en entier.

![Une diapositive avec le filigrane d'évaluation](evaluate-aspose-slides_1.png)

{{% alert color="info" title="Note" %}}
Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **Licence Temporaire de 30 jours**. Veuillez vous référer à [Comment obtenir une licence temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.
{{% /alert %}}

## **Installer le package d'évaluation**

```bash
dotnet add package Aspose.Slides.NET
```

Sur Linux et macOS, vous pouvez utiliser le package Aspose.Slides.NET6.CrossPlatform à la place ; voir [Installation](/slides/fr/net/installation/).

## **Appliquer une licence**

Voici les « quelques lignes de code » qui transforment le package d'évaluation en un package sous licence. Appliquez la licence une fois au démarrage de l'application, avant la création de tout objet `Presentation` — une présentation construite auparavant conserve le filigrane d'évaluation.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepte également un `Stream`, qui est la meilleure option lorsque la licence est fournie comme ressource intégrée plutôt que comme fichier sur le disque. Si le chemin est incorrect ou que le fichier a expiré, l'appel lève une exception, de sorte que les échecs apparaissent immédiatement au démarrage au lieu de revenir silencieusement au mode d'évaluation.

Une fois la licence appliquée, les présentations enregistrées ne contiennent plus le filigrane, et le texte est lu en entier.

## **FAQ**

### Puis-je tester plusieurs présentations en parallèle sur différents threads en mode d'évaluation ?
Oui. Vous pouvez traiter différents documents en parallèle ; vous ne devez pas partager le même objet présentation [entre les threads](/slides/fr/net/multithreading/). Le mode d'évaluation n'affecte pas cela.

### Dois-je installer Microsoft PowerPoint pour évaluer la bibliothèque sur un serveur ou en CI ?
Non. Aspose.Slides est un moteur autonome et ne nécessite pas l'installation de PowerPoint, que ce soit pour l'évaluation ou pour la production.

### Puis-je tester complètement la conversion de PPT/PPTX en PDF et en images en mode d'évaluation ?
Oui. Les [convertisseurs](/slides/fr/net/convert-presentation/) fonctionnent ; la sortie comprendra un filigrane.

### Puis-je utiliser une licence temporaire pour les tests de charge sans filigrane ?
Oui. Une licence temporaire de 30 jours supprime les limitations du mode d'évaluation et permet de tester sans filigrane.