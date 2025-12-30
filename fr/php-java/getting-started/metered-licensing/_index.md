---
title: Licence à compteurs
type: docs
weight: 100
url: /fr/php-java/metered-licensing/
keywords:
- licence
- licence à compteurs
- clés de licence
- clé publique
- clé privée
- quantité de consommation
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Découvrez comment Aspose.Slides pour PHP via la licence à compteurs Java vous permet de traiter les fichiers PowerPoint et OpenDocument de manière flexible, en ne payant que ce que vous utilisez."
---

## **Appliquer des clés mesurées**

{{% alert color="primary" %}} 

La licence à compteurs est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, choisissez la licence à compteurs.

Lorsque vous achetez une licence à compteurs, vous obtenez des clés (et non un fichier de licence). Cette clé à compteurs peut être appliquée en utilisant la classe [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

1. Passez vos clés publiques et privées à la méthode [setMeteredKey](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#setMeteredKey-java.lang.String-java.lang.String-) .

1. Effectuez un traitement (exécutez des tâches).

1. Appelez la méthode [getConsumptionQuantity](https://reference.aspose.com/slides/php-java/aspose.slides/metered/#getConsumptionQuantity--) de la classe `Metered`.

Vous devriez voir le nombre/quantité de requêtes API que vous avez consommées jusqu’à présent.

Ce code d’exemple montre comment utiliser la licence à compteurs :
```php
// Crée une instance de la classe Metered
$metered = new Metered();

try {
    // Transmet les clés publique et privée à l'objet Metered
    $metered->setMeteredKey("<valid pablic key>", "<valid private key>");

    // Obtient la valeur de la quantité consommée avant les appels API
    $amountBefore = Metered::getConsumptionQuantity();
    echo("Amount consumed before: " . $amountBefore);

    // Effectuez une opération avec l'API Aspose.Slides ici
    // ...

    // Obtient la valeur de la quantité consommée après les appels API
    $amountAfter = Metered::getConsumptionQuantity();
    echo("Amount consumed after: " . $amountAfter);
} catch (JavaException $ex) {
  $ex->printStackTrace();
}
```


{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à compteurs, vous avez besoin d’une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer les calculs.

{{% /alert %}} 

## **FAQ**

**Puis‑je utiliser une licence à compteurs avec une licence classique (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à compteurs est un mécanisme de licence supplémentaire qui peut être utilisé en parallèle avec les [méthodes de licence](/slides/fr/php-java/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l’application.

**Qu’est‑ce qui compte exactement comme consommation avec une licence à compteurs : les opérations ou les fichiers ?**

La consommation se mesure en utilisation d’API, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de la consommation](https://reference.aspose.com/slides/php-java/aspose.slides/metered/).

**La licence à compteurs convient‑elle aux micro‑services et aux environnements sans serveur où les instances redémarrent fréquemment ?**

Oui. Étant donné que la facturation se fait au niveau de chaque appel d’API, les scénarios avec des démarrages à froid fréquents sont compatibles, à condition d’avoir un accès réseau stable pour les calculs de licence à compteurs.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à compteurs par rapport à une licence perpétuelle ?**

Non. Il s’agit uniquement du mécanisme de licence et de facturation ; les capacités du produit restent les mêmes.

**Comment la licence à compteurs se compare‑t‑elle à la version d’essai et à la licence temporaire ?**

La version d’essai comporte des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à compteurs supprime les limitations et facture en fonction de l’utilisation réelle.

**Puis‑je maîtriser le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/php-java/aspose.slides/metered/) et à mettre en œuvre vos propres limites ou alertes au niveau de l’application ou de la surveillance.