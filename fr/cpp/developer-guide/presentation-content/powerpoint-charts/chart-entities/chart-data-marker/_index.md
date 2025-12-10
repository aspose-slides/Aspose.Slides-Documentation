---
title: Gérer les marqueurs de données de graphique dans les présentations en utilisant C++
linktitle: Marqueur de données
type: docs
url: /fr/cpp/chart-data-marker/
keywords:
- graphique
- point de données
- marqueur
- options de marqueur
- taille du marqueur
- type de remplissage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à personnaliser les marqueurs de données de graphique dans Aspose.Slides pour C++, en renforçant l'impact des présentations aux formats PPT et PPTX avec des exemples de code C++ clairs."
---

## **Définir les marqueurs du graphique**
Aspose.Slides for C++ fournit une API simple pour définir automatiquement le marqueur de séries de graphique. Dans la fonctionnalité suivante, chaque série de graphique recevra automatiquement un symbole de marqueur par défaut différent.

L'exemple de code ci‑dessous montre comment définir automatiquement le marqueur de série de graphique.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Définir les options du marqueur de graphique**
Les marqueurs peuvent être définis sur les points de données du graphique à l'intérieur d'une série particulière. Pour définir les options du marqueur de graphique, veuillez suivre les étapes ci‑dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini les options du marqueur de graphique au niveau des points de données.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Définir les marqueurs du graphique au niveau des points de données de la série**
Désormais, les marqueurs peuvent être définis sur les points de données du graphique à l'intérieur d'une série particulière. Pour définir les options du marqueur de graphique, veuillez suivre les étapes ci‑dessous :

- Instancier la classe Presentation.
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Enregistrer la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini les options du marqueur de graphique au niveau des points de données.
```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instancier la classe Presentation qui représente le fichier PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Accéder à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Ajouter un graphique avec les données par défaut
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Définir l'indice de la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Récupérer la feuille de données du graphique
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Supprimer les séries et catégories générées par défaut
chart->get_ChartData()->get_Series()->Clear();

// Maintenant, ajouter une nouvelle série
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Obtenir l'image
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Ajouter l'image à la collection d'images de la présentation
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Ajouter un nouveau point (1:3) ici.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```


## **Appliquer une couleur aux points de données**
Vous pouvez appliquer une couleur aux points de données du graphique en utilisant Aspose.Slides for C++. Les classes [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager) et **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** ont été ajoutées pour accéder aux propriétés des niveaux de points de données. Cet article montre comment accéder et appliquer une couleur aux points de données d'un graphique.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Quelles formes de marqueur sont disponibles immédiatement ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par l'énumération [MarkerStyleType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un marqueur avec un remplissage d'image pour émuler des visuels personnalisés.

**Les marqueurs sont-ils conservés lors de l'exportation d'un graphique en image ou SVG ?**

Oui. Lors du rendu des graphiques vers des [raster formats](/slides/fr/cpp/convert-powerpoint-to-png/) ou de l'enregistrement des [shapes as SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), les marqueurs conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.