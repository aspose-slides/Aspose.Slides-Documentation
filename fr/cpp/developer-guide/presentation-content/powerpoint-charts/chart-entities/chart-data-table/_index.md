---
title: Personnaliser les tableaux de données des graphiques dans les présentations en C++
linktitle: Tableau de données
type: docs
url: /fr/cpp/chart-data-table/
keywords:
- données de graphique
- tableau de données
- propriétés de police
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Personnalisez les tableaux de données des graphiques en C++ pour PPT et PPTX avec Aspose.Slides afin d'améliorer l'efficacité et l'attrait des présentations."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les tableaux de données des graphiques dans Aspose.Slides. Il montre comment afficher un tableau de données pour un graphique et personnaliser son formatage de texte en définissant des propriétés de police telles que le style gras et la hauteur de police. L'exemple montre le chargement d'une présentation, l'ajout d'un graphique, l'activation du tableau de données du graphique, l'application des paramètres de police et l'enregistrement de la présentation mise à jour.

## **Définir les propriétés de police pour un tableau de données de graphique**
Aspose.Slides for C++ permet de modifier les propriétés de police pour un tableau de données de graphique.  

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation).
1. Ajouter un graphique sur la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

L'exemple de code ci-dessous est fourni.  

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Puis-je afficher de petites clés de légende à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/datatable/set_showlegendkey/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera-t-il conservé lors de l'exportation de la présentation en PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique comme partie de la diapositive, ainsi l'[PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/cpp/convert-powerpoint-to-html/)/[image](/slides/fr/cpp/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont-ils pris en charge pour les graphiques provenant d'un fichier modèle ?**

Oui. Pour tout graphique chargé à partir d'une présentation ou d'un modèle existant, vous pouvez vérifier et modifier si un tableau de données [est affiché](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chart/set_hasdatatable/) à l'aide des propriétés du graphique.

**Comment puis-je rapidement déterminer quels graphiques d'un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique indiquant si le tableau de données [est affiché](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chart/get_hasdatatable/) est activé et parcourez les diapositives pour identifier les graphiques où il est activé.