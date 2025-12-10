---
title: Licence à comptage
type: docs
weight: 100
url: /fr/java/metered-licensing/
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
- Java
- Aspose.Slides
description: "Découvrez comment la licence à comptage d'Aspose.Slides pour Java vous permet de traiter les fichiers PowerPoint et OpenDocument de manière flexible, en ne payant que ce que vous utilisez."
---

## **Appliquer les clés mesurées**

{{% alert color="primary" %}} 

La licence à comptage est un nouveau mécanisme de licence qui peut être utilisé parallèlement aux méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l’API Aspose.Slides, choisissez la licence à comptage.

Lorsque vous achetez une licence à comptage, vous recevez des clés (et non un fichier de licence). Cette clé à comptage peut être appliquée à l’aide de la classe [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [FAQ sur la licence à comptage](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

1. Transmettez vos clés publiques et privées à la méthode [setMeteredKey](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Effectuez un traitement (exécutez des tâches).

1. Appelez la méthode [getConsumptionQuantity](https://reference.aspose.com/slides/java/com.aspose.slides/metered/#getConsumptionQuantity--) de la classe `Metered`.

Vous devriez voir le nombre/quantité de requêtes API que vous avez consommées jusqu’à présent.

Ce code d’exemple montre comment utiliser la licence à comptage :

```java
// Crée une instance de la classe Metered
com.aspose.slides.Metered metered = new com.aspose.slides.Metered();

try {
    // Transmet les clés publiques et privées à l’objet Metered
    metered.setMeteredKey("<valid public key>", "<valid private key>");

    // Obtient la valeur de quantité consommée avant les appels API
    double amountBefore = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed before: " + amountBefore);

    // Effectue des opérations avec l’API Aspose.Slides ici
    // ...

    // Obtient la valeur de quantité consommée après les appels API
    double amountAfter = com.aspose.slides.Metered.getConsumptionQuantity();
    System.out.println("Amount consumed after: " + amountAfter);
} catch (Exception ex) {
    ex.printStackTrace();
}
```

{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à comptage, vous avez besoin d’une connexion Internet stable, car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer les calculs.

{{% /alert %}} 

## **FAQ**

**Puis-je utiliser une licence à comptage en même temps qu’une licence classique (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à comptage est un mécanisme supplémentaire qui peut être utilisé parallèlement aux [méthodes de licence](/slides/fr/java/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l’application.

**Que compte exactement comme consommation avec une licence à comptage : des opérations ou des fichiers ?**

L’utilisation de l’API est comptabilisée, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de consommation](https://reference.aspose.com/slides/java/com.aspose.slides/metered/).

**La licence à comptage convient‑elle aux micro‑services et aux environnements serverless où les instances redémarrent fréquemment ?**

Oui. Comme la comptabilisation se fait au niveau des appels API, les scénarios avec de fréquents démarrages à froid sont compatibles, à condition qu’il y ait un accès réseau stable pour les calculs à comptage.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à comptage par rapport à une licence perpétuelle ?**

Non. Cela ne concerne que le mécanisme de licence et de facturation ; les capacités du produit restent identiques.

**Comment la licence à comptage se rapporte‑elle à la version d’essai et à la licence temporaire ?**

La version d’essai comporte des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à comptage supprime les limitations tout en facturant en fonction de l’utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/java/com.aspose.slides/metered/) et à implémenter vos propres limites ou alertes au niveau de l’application ou du monitoring.