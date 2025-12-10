---
title: "Personnaliser les tableaux de données de graphiques dans les présentations en utilisant С++"
linktitle: "Table de données"
type: docs
url: /fr/cpp/chart-data-table/
keywords:
- "données de graphique"
- "tableau de données"
- "propriétés de police"
- "PowerPoint"
- "présentation"
- "С++"
- "Aspose.Slides"
description: "Personnalisez les tableaux de données de graphiques en С++ pour PPT et PPTX avec Aspose.Slides afin d'améliorer l'efficacité et l'attrait des présentations."
---

## **Définir les propriétés de police pour le tableau de données d'un graphique**
Aspose.Slides for C++ permet de modifier les propriétés de police d'un tableau de données de graphique.  

1. Instancier l'objet de classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Ajouter un graphique à la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Enregistrer la présentation modifiée.

L'exemple d'échantillon ci-dessous est fourni.  
``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Puis-je afficher de petites légendes à côté des valeurs dans le tableau de données du graphique ?**

Oui. Le tableau de données prend en charge les [clés de légende](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datatable/set_showlegendkey/), et vous pouvez les activer ou les désactiver.

**Le tableau de données sera‑t‑il conservé lors de l'exportation de la présentation vers PDF, HTML ou images ?**

Oui. Aspose.Slides rend le graphique dans le cadre de la diapositive, de sorte que le [PDF](/slides/fr/cpp/convert-powerpoint-to-pdf/)/[HTML](/slides/fr/cpp/convert-powerpoint-to-html/)/[image](/slides/fr/cpp/convert-powerpoint-to-png/) exporté inclut le graphique avec son tableau de données.

**Les tableaux de données sont‑ils pris en charge pour les graphiques provenant d'un fichier de modèle ?**

Oui. Pour tout graphique chargé à partir d'une présentation ou d'un modèle existant, vous pouvez vérifier et modifier si un tableau de données [est affiché](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/set_hasdatatable/) en utilisant les propriétés du graphique.

**Comment puis-je rapidement identifier quels graphiques d'un fichier ont le tableau de données activé ?**

Inspectez la propriété de chaque graphique qui indique si le tableau de données [est affiché](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/get_hasdatatable/) et parcourez les diapositives pour identifier les graphiques où il est activé.