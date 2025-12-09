---
title: Licence à comptage
type: docs
weight: 90
url: /fr/net/metered-licensing/
keywords:
- licence
- licence à comptage
- clés de licence
- clé publique
- clé privée
- quantité de consommation
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment la licence à comptage d’Aspose.Slides pour .NET vous permet de traiter les fichiers PowerPoint et OpenDocument de manière flexible, en ne payant que ce que vous utilisez."
---

## **Appliquer des clés mesurées**

{{% alert color="primary" %}} 

La licence à comptage est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l’API Aspose.Slides, vous choisissez la licence à comptage.

Lorsque vous achetez une licence à comptage, vous recevez des clés (et non un fichier de licence). Cette clé à comptage peut être appliquée à l’aide de la classe [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Transmettez vos clés publiques et privées à la méthode [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Effectuez un traitement (exécutez des tâches).
1. Appelez la méthode [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) de la classe `Metered`.

Vous devriez voir la quantité de requêtes API que vous avez consommées jusqu’à présent.

Ce code d’exemple montre comment utiliser la licence à comptage :

```cs
// Creates an instance of the Metered class
Aspose.Slides.Metered metered = new Aspose.Slides.Metered();

// Passes the public and private keys to the Metered object
metered.SetMeteredKey("<valid public key>", "<valid private key>");

// Gets the metered data quantity before API call
decimal amountBefore = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed before: " + amountBefore.ToString());

// Do something with Aspose.Slides API here
// ...

// Gets the metered data amount after API call
decimal amountAfter = Aspose.Slides.Metered.GetConsumptionQuantity();
Console.WriteLine("Amount consumed after: " + amountAfter.ToString());
```

{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à comptage, vous avez besoin d’une connexion Internet stable, car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et réaliser les calculs.

{{% /alert %}} 

## **FAQ**

**Puis‑je utiliser une licence à comptage en même temps qu’une licence ordinaire (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à comptage est un mécanisme supplémentaire qui peut être utilisé en parallèle avec les [méthodes de licence](/slides/fr/net/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l’application.

**Qu’est‑ce qui est compté exactement sous une licence à comptage : les opérations ou les fichiers ?**

C’est l’utilisation de l’API qui est comptée, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de consommation](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**La licence à comptage convient‑elle aux micro‑services et aux environnements serverless où les instances redémarrent fréquemment ?**

Oui. Étant donné que la facturation se fait au niveau des appels API, les scénarios avec de fréquents démarrages à froid sont compatibles, à condition qu’un accès réseau stable soit disponible pour les calculs à comptage.

**Les fonctionnalités de la bibliothèque diffèrent‑elles quand on utilise une licence à comptage par rapport à une licence perpétuelle ?**

Non. Cela ne concerne que le mécanisme de licence et de facturation ; les capacités du produit restent les mêmes.

**Comment la licence à comptage se compare‑t‑elle à la version d’essai et à la licence temporaire ?**

La version d’essai possède des limites et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limites pendant 30 jours, et la licence à comptage supprime les limites tout en facturant en fonction de l’utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/net/aspose.slides/metered/) et à implémenter vos propres limites ou alertes au niveau de l’application ou de la surveillance.