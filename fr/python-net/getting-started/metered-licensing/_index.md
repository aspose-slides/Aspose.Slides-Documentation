---
title: Licence à mesure
type: docs
weight: 90
url: /fr/python-net/metered-licensing/
keywords:
- licence
- licence à mesure
- clés de licence
- clé publique
- clé privée
- quantité de consommation
- Python
- Aspose.Slides
description: "Découvrez comment la licence à mesure Aspose.Slides pour Python via .NET vous permet de traiter les fichiers PowerPoint et OpenDocument de manière flexible, en ne payant que ce que vous utilisez."
---

## **Appliquer les clés mesurées**

{{% alert color="primary" %}} 

La licence à mesure est un nouveau mécanisme de licence qui peut être utilisé en parallèle avec les méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, choisissez la licence à mesure.

Lorsque vous achetez une licence à mesure, vous obtenez des clés (et non un fichier de licence). Cette clé à mesure peut être appliquée à l’aide de la classe [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) fournie par Aspose pour les opérations de métrologie. Pour plus de détails, consultez la [FAQ sur les licences à mesure](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créez une instance de la classe [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
1. Transmettez vos clés publiques et privées à la méthode [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
1. Effectuez un traitement (exécutez des tâches).
1. Appelez la méthode [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) de la classe `Metered`.

Vous devez voir la quantité de requêtes API que vous avez consommées jusqu’à présent.

Cet exemple de code montre comment utiliser la licence à mesure :
```python
import aspose.slides as slides

# Crée une instance de la classe Metered
metered = slides.Metered()

# Passe les clés publiques et privées à l'objet Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Obtient la valeur de quantité consommée avant les appels API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Faites quelque chose avec l'API Aspose.Slides ici
# ...

# Obtient la valeur de quantité consommée après les appels API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```


{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à mesure, vous avez besoin d’une connexion Internet stable, car le mécanisme de licence utilise Internet pour interagir constamment avec nos services et effectuer les calculs.

{{% /alert %}} 

## **FAQ**

**Puis‑je utiliser une licence à mesure conjointement avec une licence ordinaire (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à mesure est un mécanisme de licence supplémentaire qui peut être utilisé parallèlement aux [méthodes de licence](/slides/fr/python-net/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l’application.

**Qu’est‑ce qui est exactement comptabilisé comme consommation sous une licence à mesure : les opérations ou les fichiers ?**

C’est l’utilisation de l’API qui est comptée, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de consommation](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**La licence à mesure convient‑elle aux micro‑services et aux environnements serverless où les instances redémarrent fréquemment ?**

Oui. Comme la facturation s’effectue au niveau de chaque appel d’API, les scénarios avec des démarrages à froid fréquents sont compatibles, à condition qu’un accès réseau stable soit disponible pour les calculs à mesure.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à mesure par rapport à une licence perpétuelle ?**

Non. Il s’agit uniquement du mécanisme de licence et de facturation ; les capacités du produit restent identiques.

**Comment la licence à mesure se compare‑t‑elle à la version d’essai et à la licence temporaire ?**

La version d’essai impose des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à mesure supprime les limitations tout en facturant en fonction de l’utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) et à implémenter vos propres limites ou alertes au niveau de l’application ou du système de surveillance.