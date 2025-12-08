---
title: Licence à consommation
type: docs
weight: 90
url: /fr/net/metered-licensing/
keywords:
- licence
- licence à consommation
- C#
- Aspose.Slides pour .NET
---

## **Appliquer les clés mesurées**

{{% alert color="primary" %}} 

La licence à consommation est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l’API Aspose.Slides, choisissez la licence à consommation.

Lorsque vous achetez une licence à consommation, vous recevez des clés (et non un fichier de licence). Cette clé à consommation peut être appliquée à l’aide de la classe [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [FAQ sur la licence à consommation](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/net/aspose.slides/metered/).
1. Transmettez vos clés publiques et privées à la méthode [SetMeteredKey](https://reference.aspose.com/slides/net/aspose.slides/metered/setmeteredkey/).
1. Effectuez un traitement (exécutez des tâches).
1. Appelez la méthode [GetConsumptionQuantity](https://reference.aspose.com/slides/net/aspose.slides/metered/getconsumptionquantity/) de la classe `Metered`.

Vous devriez voir le montant/quantité de requêtes API que vous avez consommées jusqu’à présent.

Ce code d’exemple montre comment utiliser la licence à consommation :

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

Pour utiliser la licence à consommation, vous avez besoin d’une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir en permanence avec nos services et effectuer les calculs.

{{% /alert %}} 

## **FAQ**

**Puis-je utiliser une licence à consommation conjointement avec une licence ordinaire (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à consommation est un mécanisme supplémentaire qui peut être utilisé en parallèle avec les [méthodes de licence](/slides/fr/net/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l’application.

**Qu’est‑ce qui est exactement comptabilisé comme consommation avec une licence à consommation : les opérations ou les fichiers ?**

L’utilisation de l’API est comptabilisée, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de la consommation](https://reference.aspose.com/slides/net/aspose.slides/metered/).

**La licence à consommation convient‑elle aux micro‑services et aux environnements serverless où les instances redémarrent fréquemment ?**

Oui. Comme la facturation se fait au niveau des appels d’API, les scénarios avec des démarrages à froid fréquents sont compatibles, à condition qu’un accès réseau stable soit disponible pour les calculs de consommation.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à consommation par rapport à une licence perpétuelle ?**

Non. Il s’agit uniquement du mécanisme de licence et de facturation ; les capacités du produit restent les mêmes.

**Comment la licence à consommation se compare‑t‑elle à la version d’évaluation et à la licence temporaire ?**

La version d’évaluation comporte des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à consommation supprime les limitations tout en facturant en fonction de l’utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/net/aspose.slides/metered/) et à mettre en œuvre vos propres limites ou alertes au niveau de l’application ou de la surveillance.