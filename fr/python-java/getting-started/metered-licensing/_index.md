---
title: Licence à consommation
type: docs
weight: 100
url: /fr/python-java/metered-licensing/
keywords:
- licence
- licence à consommation
- clés de licence
- clé publique
- clé privée
- quantité de consommation
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Découvrez comment la licence à consommation d'Aspose.Slides pour Python via Java vous permet de traiter les fichiers PowerPoint et OpenDocument de manière flexible, en ne payant que ce que vous utilisez."
---
## **Introduction**

La licence à consommation est un mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, choisissez la licence à consommation.

## **Appliquer les clés à consommation**

{{% alert color="info" title="Note" %}}

La licence à consommation est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, choisissez la licence à consommation.

Lorsque vous achetez une licence à consommation, vous recevez des clés (et non un fichier de licence). Cette clé à consommation peut être appliquée à l'aide de la classe [Metered](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [FAQ sur la licence à consommation](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}}

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/).

1. Passez vos clés publiques et privées à la méthode [setMeteredKey](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/#setMeteredKey).

1. Effectuez un traitement (exécutez des tâches).

1. Appelez la méthode [getConsumptionQuantity](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/#getConsumptionQuantity) de la classe [Metered](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/).

Vous devriez voir le nombre/quantité de requêtes API que vous avez consommées jusqu'à présent.

Ce code d'exemple vous montre comment utiliser la licence à consommation :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Metered

# Créez une instance de la classe Metered.
metered = Metered()

try:
    # Passez les clés publiques et privées à l'objet Metered.
    metered.setMeteredKey("<valid public key>", "<valid private key>")

    # Obtenez la quantité consommée avant les appels API.
    amount_before = Metered.getConsumptionQuantity()
    print("Amount consumed before:", amount_before)

    # Faites quelque chose avec l'API Aspose.Slides ici.
    # ...

    # Obtenez la quantité consommée après les appels API.
    amount_after = Metered.getConsumptionQuantity()
    print("Amount consumed after:", amount_after)
except Exception as error:
    print(error)
```

{{% alert color="warning" title="Warning"  %}}

Pour utiliser la licence à consommation, vous avez besoin d'une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer des calculs.

{{% /alert %}}

## **FAQ**

**Puis-je utiliser une licence à consommation conjointement avec une licence normale (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à consommation est un mécanisme de licence supplémentaire qui peut être utilisé en parallèle avec les [méthodes de licence](/slides/fr/python-java/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l'application.

**Qu'est-ce qui est exactement compté comme consommation avec une licence à consommation : les opérations ou les fichiers ?**

Le métrage se base sur l'utilisation de l'API, c’est‑à‑dire le nombre de requêtes ou d'opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de consommation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/).

**La licence à consommation convient‑elle aux micro‑services et aux environnements sans serveur où les instances redémarrent fréquemment ?**

Oui. Comme la facturation se fait au niveau de chaque appel API, les scénarios avec des démarrages à froid fréquents sont compatibles, à condition d'avoir un accès réseau stable pour les calculs de licence à consommation.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à consommation par rapport à une licence perpétuelle ?**

Non. Cela ne concerne que le mécanisme de licence et de facturation ; les capacités du produit restent les mêmes.

**Comment la licence à consommation se compare‑t‑elle à la version d'essai et à la licence temporaire ?**

La version d'essai comporte des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à consommation supprime les limitations et facture en fonction de l'utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu'un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/fr/python-java/aspose.slides/metered/) et à implémenter vos propres limites ou alertes au niveau de l'application ou de la surveillance.