---
title: Tableau de données de graphique
type: docs
url: /cpp/chart-data-table/
---

## **Définir les propriétés de police pour le tableau de données du graphique**
Aspose.Slides pour C++ permet de changer les propriétés de police pour un tableau de données de graphique.

1. Instancier un objet de classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Ajouter un graphique à la diapositive.
1. Définir le tableau du graphique.
1. Définir la hauteur de la police.
1. Sauvegarder la présentation modifiée.

Un exemple de code est donné ci-dessous.

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);

chart->set_HasDataTable(true);

chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontBold(NullableBool::True);
chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20.0f);

pres->Save(u"output.pptx", SaveFormat::Pptx);
```