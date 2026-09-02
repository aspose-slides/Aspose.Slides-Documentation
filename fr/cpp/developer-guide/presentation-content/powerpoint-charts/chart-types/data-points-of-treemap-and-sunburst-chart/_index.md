---
title: Personnaliser les points de données dans les graphiques Treemap et Sunburst en C++
linktitle: Points de données dans les graphiques Treemap et Sunburst
type: docs
url: /fr/cpp/data-points-of-treemap-and-sunburst-chart/
keywords:
- graphique Treemap
- graphique Sunburst
- graphique hiérarchique
- point de données
- étiquette de données
- couleur de branche
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à créer des données hiérarchiques et à personnaliser les niveaux, les étiquettes et les couleurs dans les graphiques Treemap et Sunburst avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Les graphiques Treemap et Sunburst affichent le même type de données hiérarchiques, mais ils utilisent des dispositions différentes. Un Treemap représente la hiérarchie sous forme de rectangles imbriqués dont les surfaces représentent les valeurs des feuilles. Un Sunburst la représente sous forme d'anneaux concentriques : les groupes de premier niveau sont proches du centre, et les catégories de feuilles se trouvent sur l'anneau extérieur.

Dans Aspose.Slides for C++, chaque valeur numérique est un [IChartDataPoint](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/). Sa méthode [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) fournit l’accès à la feuille et à ses groupes parents. Cet article explique ce mappage et montre comment créer et formater les deux types de graphiques à partir des mêmes données d’exemple.

![Un graphique Treemap avec les branches Consommateur et Entreprise](treemap-hierarchy.png)

![Un graphique Sunburst avec la même hiérarchie Consommateur et Entreprise](sunburst-hierarchy.png)

## **Comprendre les catégories, les points de données et les niveaux**

L’exemple ci‑dessous comporte trois niveaux de catégorie et une série numérique :

| Branche | Tronc | Feuille | Revenu |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Chaque ligne crée une catégorie feuille et un point de données. Les niveaux de regroupement de catégorie décrivent le chemin de cette feuille vers ses parents. Pour la première ligne, le chemin est `Consumer > Computers > Laptops`.

Les index renvoyés par [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/) partent de la feuille vers le haut :

| Index `get_DataPointLevels()` | Niveau logique | Représentation Treemap | Représentation Sunburst |
| ---: | --- | --- | --- |
| `0` | Feuille | Rectangle valeur | Segment anneau extérieur |
| `1` | Tronc | Rectangle ou en‑tête parent | Segment anneau moyen |
| `2` | Branche | Rectangle ou en‑tête de niveau supérieur | Segment anneau intérieur |

Cet ordre est identique pour les deux types de graphiques même si leurs dispositions visuelles diffèrent. Un segment parent est partagé par plusieurs feuilles. Pour le formater, utilisez le niveau correspondant du premier point de données du groupe. Par exemple, la branche `Consumer` commence avec le point `Laptops`, tandis que le tronc `Software` commence avec le point `Licenses`. Conserver des références à ces points est plus clair et plus sûr que d’utiliser des expressions non explicites comme `dataPoints->idx_get(0)` ou `dataPoints->idx_get(6)`.

## **Créer et personnaliser les deux types de graphiques**

L’exemple complet suivant crée un Treemap sur la première diapositive et un Sunburst sur la deuxième diapositive. Il construit la hiérarchie, affiche la valeur pour `Tablets`, applique des couleurs fixes aux niveaux sélectionnés, formate une étiquette de branche et enregistre la présentation.

```cpp
auto presentation = MakeObject<Presentation>();

auto addHierarchyChart = [](SharedPtr<ISlide> slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    auto chart = slide->get_Shapes()->AddChart(chartType, 40, 40, 640, 440);
    chart->set_HasTitle(false);
    chart->set_HasLegend(false);
    chart->get_ChartData()->get_Categories()->Clear();
    chart->get_ChartData()->get_Series()->Clear();

    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    workbook->Clear(worksheetIndex);

    auto addCategory = [&](int rowIndex, const String& leafName)
    {
        auto leafNameValue = ObjectExt::Box<String>(leafName);
        auto categoryCell = workbook->GetCell(worksheetIndex, rowIndex, 2, leafNameValue);
        return chart->get_ChartData()->get_Categories()->Add(categoryCell);
    };

    auto setGroupingItem = [](SharedPtr<IChartCategory> category, int levelIndex,
                              const String& groupName)
    {
        auto groupNameValue = ObjectExt::Box<String>(groupName);
        category->get_GroupingLevels()->SetGroupingItem(levelIndex, groupNameValue);
    };

    // Ajoutez les catégories feuilles. Un élément de regroupement n'est défini que lorsqu'un nouveau groupe commence;
    // les catégories suivantes restent dans ce groupe jusqu'à ce qu'un autre élément soit défini.
    auto laptopsCategory = addCategory(1, u"Laptops");
    setGroupingItem(laptopsCategory, stemLevelIndex, u"Computers");
    setGroupingItem(laptopsCategory, branchLevelIndex, u"Consumer");

    addCategory(2, u"Desktops");

    auto phonesCategory = addCategory(3, u"Phones");
    setGroupingItem(phonesCategory, stemLevelIndex, u"Mobile");

    addCategory(4, u"Tablets");

    auto consultingCategory = addCategory(5, u"Consulting");
    setGroupingItem(consultingCategory, stemLevelIndex, u"Services");
    setGroupingItem(consultingCategory, branchLevelIndex, u"Business");

    addCategory(6, u"Support");

    auto licensesCategory = addCategory(7, u"Licenses");
    setGroupingItem(licensesCategory, stemLevelIndex, u"Software");

    addCategory(8, u"Subscriptions");

    auto seriesNameValue = ObjectExt::Box<String>(u"Revenue");
    auto seriesNameCell = workbook->GetCell(worksheetIndex, 0, 3, seriesNameValue);
    auto series = chart->get_ChartData()->get_Series()->Add(seriesNameCell, chartType);
    series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowCategoryName(true);

    auto addDataPoint = [&](int rowIndex, double value)
    {
        auto valueObject = ObjectExt::Box<double>(value);
        auto valueCell = workbook->GetCell(worksheetIndex, rowIndex, 3, valueObject);

        if (chartType == ChartType::Treemap)
        {
            return series->get_DataPoints()->AddDataPointForTreemapSeries(valueCell);
        }

        return series->get_DataPoints()->AddDataPointForSunburstSeries(valueCell);
    };

    auto laptopsDataPoint = addDataPoint(1, 12);
    addDataPoint(2, 8);
    addDataPoint(3, 15);
    auto tabletsDataPoint = addDataPoint(4, 6);
    addDataPoint(5, 10);
    addDataPoint(6, 7);
    auto licensesDataPoint = addDataPoint(7, 11);
    addDataPoint(8, 14);

    auto setSolidFill = [](SharedPtr<IFillFormat> fillFormat, Color color)
    {
        fillFormat->set_FillType(FillType::Solid);
        fillFormat->get_SolidFillColor()->set_Color(color);
    };

    // Afficher la catégorie et la valeur sur la feuille Tablettes.
    auto tabletsLeafLevel = tabletsDataPoint->get_DataPointLevels()->idx_get(leafLevelIndex);
    auto tabletsLabelFormat = tabletsLeafLevel->get_Label()->get_DataLabelFormat();
    tabletsLabelFormat->set_ShowCategoryName(true);
    tabletsLabelFormat->set_ShowValue(true);
    tabletsLabelFormat->set_Separator(u"\n");
    tabletsLabelFormat->set_NumberFormat(u"$0");

    // Formater la branche Consumer via la première feuille de cette branche.
    auto consumerBranchLevel = laptopsDataPoint->get_DataPointLevels()->idx_get(branchLevelIndex);
    auto consumerBranchFill = consumerBranchLevel->get_Format()->get_Fill();
    auto consumerBranchColor = Color::FromArgb(31, 78, 121);
    setSolidFill(consumerBranchFill, consumerBranchColor);

    auto consumerLabelFormat = consumerBranchLevel->get_Label()->get_DataLabelFormat();
    consumerLabelFormat->set_ShowCategoryName(true);
    consumerLabelFormat->set_ShowSeriesName(false);
    auto consumerLabelTextFill = consumerLabelFormat->get_TextFormat()
        - >get_PortionFormat()->get_FillFormat();
    setSolidFill(consumerLabelTextFill, Color::get_White());

    // Formater le tronc Software via la première feuille de ce tronc.
    auto softwareStemLevel = licensesDataPoint->get_DataPointLevels()->idx_get(stemLevelIndex);
    auto softwareStemFill = softwareStemLevel->get_Format()->get_Fill();
    auto softwareStemColor = Color::FromArgb(112, 173, 71);
    setSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout affecte les étiquettes parent du Treemap; Sunburst utilise les segments d'anneau.
    if (chartType == ChartType::Treemap)
    {
        series->set_ParentLabelLayout(ParentLabelLayoutType::Overlapping);
    }
};

auto treemapSlide = presentation->get_Slide(0);
addHierarchyChart(treemapSlide, ChartType::Treemap);

auto layoutSlide = presentation->get_LayoutSlide(0);
auto sunburstSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
addHierarchyChart(sunburstSlide, ChartType::Sunburst);

presentation->Save(u"hierarchical-charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Les cellules de catégorie et les cellules de valeur utilisent la même ligne de feuille de calcul, de sorte que leurs positions dans la collection restent alignées. Lorsque vous travaillez avec un graphique existant plutôt que d’en créer un, examinez d’abord les lignes de catégorie et stockez des références nommées aux points de données et aux niveaux que vous prévoyez de formater.

## **Comportement et considérations pratiques**

### **Différences entre Treemap et Sunburst**

- Un Treemap utilise la surface pour communiquer la valeur et des rectangles imbriqués pour communiquer la hiérarchie. La méthode [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) contrôle l’apparence des étiquettes parent dans ce type de graphique.
- Un Sunburst utilise l’angle pour communiquer la valeur et la profondeur de l’anneau pour communiquer la hiérarchie. [IChartSeries::get_ParentLabelLayout()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartseries/get_parentlabellayout/) ne contrôle pas les étiquettes d’anneau.
- Les deux types de graphiques utilisent les mêmes niveaux de regroupement de catégorie et le même ordre feuille‑vers‑parent renvoyé par [IChartDataPoint::get_DataPointLevels()](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapoint/get_datapointlevels/), de sorte que le code de création de données et de formatage des niveaux peut être partagé.
- Les valeurs parent sont calculées à partir de leurs feuilles descendantes. N’ajoutez pas de points numériques séparés pour les branches ou les troncs.

### **Tri et ordre des segments**

Le moteur de disposition du graphique détermine le placement final des rectangles et des segments d’anneau. Regroupez les lignes de catégorie liées avant de les ajouter, mais ne comptez pas sur une position de rectangle ou un angle de départ spécifiques. Si la séquence a une signification, incluez‑la dans les étiquettes ou utilisez un type de graphique avec un axe de catégorie explicite.

### **Thème et couleurs fixes**

Les niveaux de graphique non formatés héritent des couleurs du thème de la présentation. L’exemple utilise des remplissages RVB explicites pour un résultat prévisible. Si le graphique doit suivre les changements de thème, utilisez des couleurs de jeu plutôt que des valeurs RVB fixes et évitez de remplacer chaque niveau. Vérifiez également le contraste des étiquettes après avoir modifié le remplissage d’une branche ou d’un tronc.

### **Étiquettes et espace disponible**

PowerPoint peut masquer ou tronquer les étiquettes lorsqu’un segment est trop petit. Augmenter la taille du graphique, raccourcir les noms de catégorie ou afficher moins de champs d’étiquette produit généralement un résultat plus lisible. Une étiquette peut combiner le nom de catégorie, le nom de série et la valeur via [IDataLabelFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatalabelformat/), mais activer tous les champs rend souvent les graphiques hiérarchiques difficiles à lire.

### **Exportation et rendu**

Enregistrer au format PPTX conserve le graphique modifiable. Lorsque Aspose.Slides rend la présentation en PDF ou en image, les remplissages et paramètres d’étiquette pris en charge sont rendus avec le graphique. La substitution de police et les petites différences d’espace de mise en page disponible peuvent modifier le retour à la ligne ou la visibilité des étiquettes, il faut donc installer les polices requises et vérifier les cibles d’exportation importantes.

## **FAQ**

**Pourquoi la modification d’un niveau parent affecte‑t‑elle plusieurs feuilles ?**

Une branche ou un tronc est un segment visuel partagé. Son [IChartDataPointLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapointlevel/) est accessible via une feuille descendante, mais le formatage appartient au segment parent partagé plutôt qu’à cette seule feuille.

**Pourquoi une étiquette de données est‑elle absente ?**

Activez d’abord les champs requis sur l’objet [IDataLabelFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/idatalabelformat/) de l’étiquette. Vérifiez ensuite que le segment dispose de suffisamment d’espace. La disposition des étiquettes parent du Treemap, les dimensions du graphique, la longueur de l’étiquette, la taille de police et le nombre de champs activés influencent tous la possibilité d’afficher une étiquette.

**Puis‑je définir l’ordre exact ou les coordonnées des segments ?**

Vous pouvez contrôler l’ordre des lignes source et garder chaque groupe contigu, mais vous ne pouvez pas attribuer des rectangles Treemap ou des angles Sunburst exacts. Le moteur de disposition du graphique les calcule à partir de la hiérarchie, des valeurs et de l’espace disponible.

**Pourquoi les couleurs changent‑elles après une modification du thème de la présentation ?**

Les remplissages basés sur le thème sont conçus pour suivre la palette de la présentation. Appliquez des couleurs RVB explicites aux niveaux qui doivent rester fixes, ou conservez les couleurs de jeu lorsque le maintien d’un nouveau thème est préféré.

**Le formatage personnalisé sera‑t‑il conservé dans les exportations PDF et image ?**

Oui, les remplissages de graphique et les paramètres d’étiquette pris en charge sont inclus lors du rendu. Pour des résultats cohérents entre les systèmes, assurez‑vous que les polices requises sont disponibles et testez la taille d’exportation finale, car l’ajustement des étiquettes dépend de la mise en page.

## **Voir aussi**

- [Créer des graphiques Treemap](/slides/fr/cpp/create-chart/#create-tree-map-charts)
- [Créer des graphiques Sunburst](/slides/fr/cpp/create-chart/#create-sunburst-charts)
- [Exporter les graphiques de présentation](/slides/fr/cpp/export-chart/)
- [Gérer les thèmes de présentation](/slides/fr/cpp/presentation-theme/)