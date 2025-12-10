---
title: Personnaliser les légendes de graphiques dans les présentations avec C++
linktitle: Légende du graphique
type: docs
url: /fr/cpp/chart-legend/
keywords:
- légende de graphique
- position de légende
- taille de police
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les légendes de graphiques avec Aspose.Slides pour C++ afin d'optimiser les présentations PowerPoint grâce à un formatage de légende adapté."
---

## **Positionnement de la légende**
Afin de définir les propriétés de la légende, veuillez suivre les étapes ci‑dessous :

- Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
- Obtenir la référence de la diapositive.
- Ajouter un graphique à la diapositive.
- Définir les propriétés de la légende.
- Enregistrer la présentation au format PPTX.

Dans l’exemple ci‑dessous, nous avons défini la position et la taille de la légende du graphique.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetlegendCustomOptions-SetlegendCustomOptions.cpp" >}}

## **Définir la taille de police d’une légende**
Aspose.Slides for C++ permet aux développeurs de définir la taille de police de la légende. Veuillez suivre les étapes ci‑dessous :

- Instancier la classe Presentation.
- Créer le graphique par défaut.
- Définir la taille de police.
- Définir la valeur minimale de l’axe.
- Définir la valeur maximale de l’axe.
- Enregistrer la présentation sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfLegend-SettingFontSizeOfLegend.cpp" >}}

## **Définir la taille de police d’une légende individuelle**
Aspose.Slides for C++ permet aux développeurs de définir la taille de police des entrées de légende individuelles. Veuillez suivre les étapes ci‑dessous :

- Instancier la classe Presentation.
- Créer le graphique par défaut.
- Accéder à l’entrée de légende.
- Définir la taille de police.
- Définir la valeur minimale de l’axe.
- Définir la valeur maximale de l’axe.
- Enregistrer la présentation sur le disque.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontSizeOfIndividualLegend-SettingFontSizeOfIndividualLegend.cpp" >}}

## **FAQ**

**Puis-je activer la légende de façon que le graphique alloue automatiquement de l’espace pour elle au lieu de la superposer ?**

Oui. Utilisez le mode sans superposition ([set_Overlay(false)](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/)); dans ce cas, la zone de tracé se réduira pour accueillir la légende.

**Puis-je créer des libellés de légende sur plusieurs lignes ?**

Oui. Les libellés longs passent automatiquement à la ligne lorsqu’il n’y a pas assez d’espace ; les sauts de ligne forcés sont pris en charge via les caractères de nouvelle ligne dans le nom de la série.

**Comment faire en sorte que la légende suive le schéma de couleurs du thème de la présentation ?**

Ne définissez pas de couleurs, remplissages ou polices explicites pour la légende ou son texte. Ils hériteront alors du thème et se mettront à jour correctement lorsque le design changera.