---
title: Licence à la consommation
type: docs
weight: 90
url: /fr/python-net/metered-licensing/
keywords:
- licence
- licence à la consommation
- clés de licence
- clé publique
- clé privée
- quantité de consommation
- Python
- Aspose.Slides
description: "Apprenez comment la licence à la consommation d’Aspose.Slides pour Python via .NET vous permet de traiter des fichiers PowerPoint et OpenDocument de manière flexible, en ne payant que ce que vous utilisez."
---

## **Appliquer les clés à la consommation**

{{% alert color="primary" %}} 

La licence à la consommation est un nouveau mécanisme de licence qui peut être utilisé en parallèle des méthodes de licence existantes. Si vous souhaitez être facturé en fonction de votre utilisation des fonctionnalités de l'API Aspose.Slides, choisissez la licence à la consommation.

Lorsque vous achetez une licence à la consommation, vous obtenez des clés (et non un fichier de licence). Cette clé à la consommation peut être appliquée à l'aide de la classe [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) fournie par Aspose pour les opérations de comptage. Pour plus de détails, consultez la [Metered Licensing FAQ](https://purchase.aspose.com/faqs/licensing/metered).

{{% /alert %}} 

1. Créer une instance de la classe [Metered](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).
2. Transmettre vos clés publique et privée à la méthode [set_metered_key](https://reference.aspose.com/slides/python-net/aspose.slides/metered/set_metered_key/#str-str).
3. Effectuer un traitement (exécuter des tâches).
4. Appeler la méthode [get_consumption_quantity](https://reference.aspose.com/slides/python-net/aspose.slides/metered/get_consumption_quantity/#) de la classe `Metered`.

Vous devriez voir la quantité de requêtes API que vous avez consommée jusqu'à présent.

Ce code d'exemple montre comment utiliser la licence à la consommation :

```python
import aspose.slides as slides

# Crée une instance de la classe Metered
metered = slides.Metered()

# Transmet les clés publique et privée à l'objet Metered
metered.set_metered_key("<valid public key>", "<valid private key>")

# Obtient la valeur de la quantité consommée avant les appels API
amount_before = slides.Metered.get_consumption_quantity()
print("Amount consumed before:", amount_before)

# Effectuer des opérations avec l'API Aspose.Slides ici
# ...

# Obtient la valeur de la quantité consommée après les appels API
amount_after = slides.Metered.get_consumption_quantity()
print("Amount consumed after:", amount_after)
```

{{% alert color="warning" title="NOTE"  %}} 

Pour utiliser la licence à la consommation, vous avez besoin d'une connexion Internet stable car le mécanisme de licence utilise Internet pour interagir continuellement avec nos services et effectuer les calculs.

{{% /alert %}} 

## **FAQ**

**Puis‑je utiliser une licence à la consommation conjointement avec une licence classique (perpétuelle ou temporaire) dans la même application ?**

Oui. La licence à la consommation est un mécanisme supplémentaire qui peut être utilisé en parallèle des [méthodes de licence](/slides/fr/python-net/licensing/). Vous choisissez le mécanisme à appliquer au démarrage de l'application.

**Qu’est‑ce qui est exactement comptabilisé comme consommation sous une licence à la consommation : opérations ou fichiers ?**

L’utilisation de l’API est comptée, c’est‑à‑dire le nombre de requêtes ou d’opérations. Vous pouvez obtenir la consommation actuelle via les [méthodes de suivi de la consommation](https://reference.aspose.com/slides/python-net/aspose.slides/metered/).

**La licence à la consommation convient‑elle aux micro‑services et aux environnements serverless où les instances redémarrent fréquemment ?**

Oui. Comme la facturation se fait au niveau des appels d’API, les scénarios avec des démarrages à froid fréquents sont compatibles, à condition d’avoir un accès réseau stable pour les calculs de licence à la consommation.

**Les fonctionnalités de la bibliothèque diffèrent‑elles lorsqu’on utilise une licence à la consommation comparée à une licence perpétuelle ?**

Non. Cela ne concerne que le mécanisme de licence et de facturation ; les capacités du produit restent les mêmes.

**Comment la licence à la consommation se compare‑t‑elle à la version d’essai et à la licence temporaire ?**

La version d’essai possède des limitations et des filigranes, la [licence temporaire](https://purchase.aspose.com/temporary-license/) supprime les limitations pendant 30 jours, et la licence à la consommation supprime les limitations et facture en fonction de l’utilisation réelle.

**Puis‑je contrôler le budget en réagissant automatiquement lorsqu’un seuil de consommation est dépassé ?**

Oui. Une pratique courante consiste à lire périodiquement la consommation actuelle via les [méthodes de suivi](https://reference.aspose.com/slides/python-net/aspose.slides/metered/) et à mettre en œuvre vos propres limites ou alertes au niveau de l’application ou de la surveillance.