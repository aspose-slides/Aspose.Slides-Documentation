---
title: Personnaliser les légendes de graphiques dans les présentations avec C++
linktitle: Légende du graphique
type: docs
url: /fr/cpp/chart-legend/
keywords:
- légende de graphique
- position de la légende
- taille de police
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour C++ afin d’optimiser les présentations PowerPoint avec un formatage de légende sur mesure."
---
## **Vue d'ensemble**

Aspose.Slides propose des options pour personnaliser les légendes de graphiques dans les présentations PowerPoint. Cet article montre comment positionner et dimensionner une légende, définir la taille de police pour l’ensemble de la légende et appliquer un formatage à une entrée de légende individuelle.

Il couvre également plusieurs comportements associés dans la FAQ, notamment l’utilisation du mode non superposé afin que la zone de tracé laisse de l’espace à la légende, permettre aux libellés de légende longs de s’enrouler ou d’utiliser des sauts de ligne, et laisser le formatage de la légende hériter du thème de la présentation lorsqu’aucun texte ou remplissage explicite n’est appliqué.

## **Positionnement de la légende**
Pour définir les propriétés de la légende, suivez les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/).
- Obtenir la référence de la diapositive.
- Ajouter un graphique à la diapositive.
- Définir les propriétés de la légende.
- Enregistrer la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous avons défini la position et la taille de la légende du graphique.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Définir la taille de police d’une légende**
Aspose.Slides pour C++ permet aux développeurs de définir la taille de police de la légende. Suivez les étapes ci‑dessous :

- Instancier la classe Presentation.
- Créer le graphique par défaut.
- Définir la taille de police.
- Définir la valeur minimale de l’axe.
- Définir la valeur maximale de l’axe.
- Enregistrer la présentation sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Définir la taille de police d’une entrée de légende individuelle**
Aspose.Slides pour C++ permet aux développeurs de définir la taille de police des entrées de légende individuelles. Suivez les étapes ci‑dessous :

- Instancier la classe Presentation.
- Créer le graphique par défaut.
- Accéder à l’entrée de légende.
- Définir la taille de police.
- Définir la valeur minimale de l’axe.
- Définir la valeur maximale de l’axe.
- Enregistrer la présentation sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Puis‑je activer la légende afin que le graphique réserve automatiquement de l’espace pour celle‑ci au lieu de la superposer ?**

Oui. Utilisez le mode non superposé ([set_Overlay(false)](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/legend/set_overlay/)) ; dans ce cas, la zone du graphique se réduira pour accueillir la légende.

**Puis‑je créer des libellés de légende multi‑lignes ?**

Oui. Les libellés longs se renvoient automatiquement lorsque l’espace est insuffisant ; les sauts de ligne forcés sont pris en charge via des caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le schéma de couleurs du thème de la présentation ?**

N’appliquez pas de couleurs, remplissages ou polices explicites à la légende ou à son texte. Ils hériteront alors du thème et se mettront à jour correctement lorsque le design changera.