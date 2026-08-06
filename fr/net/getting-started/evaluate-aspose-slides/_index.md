---
title: Évaluer Aspose.Slides
type: docs
weight: 120
url: /fr/net/evaluate-aspose-slides/
keywords:
- évaluer Aspose.Slides
- évaluation Aspose.Slides
- version d'évaluation
- fonctionnalités complètes
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
## **Évaluation Aspose.Slides**

Vous pouvez facilement télécharger Aspose.Slides pour l'évaluation. Le paquet d'évaluation est identique au paquet acheté. La version d'évaluation devient simplement sous licence après que vous ayez ajouté quelques lignes de code pour appliquer la licence. 

La version d'évaluation d'Aspose.Slides (sans licence spécifiée) offre toutes les fonctionnalités du produit, mais elle insère un filigrane d'évaluation en haut du document à l'ouverture et à l'enregistrement. Vous êtes également limité à une diapositive lors de l'extraction de texte depuis les diapositives de présentation.


![todo:image_alt_text](evaluate-aspose-slides_1.png)

{{% alert color="primary" %}} 

Si vous souhaitez tester Aspose.Slides sans les limitations de la version d'évaluation, vous pouvez demander une **Licence temporaire de 30 jours**. Veuillez consulter [Comment obtenir une licence temporaire ?](https://purchase.aspose.com/temporary-license) pour plus d'informations.

{{% /alert %}}

## **Installer le paquet d'évaluation**

```bash
dotnet add package Aspose.Slides.NET
```

## **Appliquer une licence**

Voici les « quelques lignes de code » qui transforment le paquet d'évaluation en paquet sous licence. Appliquez la
licence une fois au démarrage de l'application, avant la création de tout objet `Presentation` — une présentation
créée auparavant conserve le filigrane d'évaluation.

```csharp
using Aspose.Slides;

var license = new License();
license.SetLicense("Aspose.Slides.NET.lic");
```

`SetLicense` accepte également un `Stream`, qui est l'option préférable lorsque la licence est fournie en tant que ressource intégrée plutôt qu'en fichier sur le disque. Si le chemin est incorrect ou que le fichier a expiré, l'appel lève une exception, de sorte que les échecs apparaissent immédiatement au démarrage au lieu de revenir silencieusement en mode évaluation.

Une fois la licence appliquée, le filigrane disparaît et la limitation d'extraction de texte à une diapositive est levée.

## **FAQ**

### Puis-je tester plusieurs présentations en parallèle sur différents threads en mode d'évaluation ?

Oui. Vous pouvez traiter différents documents en parallèle ; vous ne devez pas partager le même objet de présentation [entre threads](/slides/fr/net/multithreading/). Le mode d'évaluation n'affecte pas cela.

### Dois‑je installer Microsoft PowerPoint pour évaluer la bibliothèque sur un serveur ou en CI ?

Non. Aspose.Slides est un moteur autonome et ne nécessite pas l'installation de PowerPoint, que ce soit pour l'évaluation ou la production.

### Puis‑je tester pleinement la conversion de PPT/PPTX en PDF et images en mode d'évaluation ?

Oui. Les [convertisseurs](/slides/fr/net/convert-presentation/) fonctionnent ; la sortie comprendra un filigrane.

### Puis‑je utiliser une licence temporaire pour des tests de charge sans filigrane ?

Oui. Une licence temporaire de 30 jours supprime les limitations du mode d'évaluation et permet de tester sans filigrane.