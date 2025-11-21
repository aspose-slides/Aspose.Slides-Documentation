---
title: Licence à comptage
type: docs
weight: 100
url: /fr/nodejs-java/metered-licensing/
keywords:
- licence
- licence à comptage
- Node.js
- Java
- Aspose.Slides pour Node.js via Java
---

## **Appliquer les clés mesurées**

{{% alert color="primary" %}} 

La licence à comptage est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l’API Aspose.Slides, choisissez la licence à comptage.

Lorsque vous achetez une licence à comptage, vous recevez des clés (et non un fichier de licence). Cette clé à comptage peut être appliquée à l’aide de la classe [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [FAQ sur la licence à comptage](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

1. Transmettez vos clés publiques et privées à la méthode [setMeteredKey](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#setMeteredKey).

1. Effectuez un traitement (exécutez des tâches).

1. Appelez la méthode [getConsumptionQuantity](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/#getConsumptionQuantity) de la classe `Metered`.

Vous devriez voir le nombre/quantité de requêtes API que vous avez consommées jusqu’à présent.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Crée une instance de la classe Metered
var metered = new aspose.slides.Metered();

// Transmet les clés publiques et privées à l'objet Metered
metered.setMeteredKey("<valid public key>", "<valid private key>");

// Obtient la valeur de quantité consommée avant les appels API
var amountBefore = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed before:", amountBefore);

// Faites quelque chose avec l'API Aspose.Slides ici
// ...

// Obtient la valeur de quantité consommée après les appels API
var amountAfter = aspose.slides.Metered.getConsumptionQuantity();
console.log("Amount consumed after:", amountAfter);
```


{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à comptage, vous avez besoin d’une connexion Internet stable parce que le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer des calculs.

{{% /alert %}} 

## **FAQ**

**Puis-je utiliser une licence à comptage en même temps qu’une licence classique (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à comptage est un mécanisme de licence supplémentaire qui peut être utilisé en parallèle avec les [méthodes de licence](/slides/fr/nodejs-java/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l’application.

**Qu’est-ce qui compte exactement comme consommation avec une licence à comptage : les opérations ou les fichiers ?**

L’utilisation de l’API est comptabilisée, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de la consommation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/).

**La licence à comptage convient‑elle aux micro‑services et aux environnements sans serveur où les instances redémarrent fréquemment ?**

Oui. Comme la facturation se fait au niveau des appels API, les scénarios avec des démarrages à froid fréquents sont compatibles, à condition de disposer d’un accès réseau stable pour les calculs de licence à comptage.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à comptage par rapport à une licence perpétuelle ?**

Non. Il s’agit uniquement du mécanisme de licence et de facturation ; les capacités du produit restent les mêmes.

**Comment la licence à comptage se compare‑t‑elle à la version d’essai et à la licence temporaire ?**

La version d’essai comporte des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à comptage supprime les limitations et facture en fonction de l’utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/nodejs-java/aspose.slides/metered/) et à mettre en œuvre vos propres limites ou alertes au niveau de l’application ou de la surveillance.