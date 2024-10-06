---
title: Marqueur de Données de Graphique
type: docs
url: /cpp/chart-data-marker/
---

## **Définir le Marqueur de Graphique**
Aspose.Slides pour C++ offre une API simple pour définir automatiquement le marqueur de série de graphique. Dans la fonctionnalité suivante, chaque série de graphique obtiendra automatiquement un symbole de marqueur par défaut différent.

L'exemple de code ci-dessous montre comment définir automatiquement le marqueur de série de graphique.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}


## **Définir les Options de Marqueur de Graphique**
Les marqueurs peuvent être définis sur les points de données de graphique à l'intérieur d'une série particulière. Pour définir les options de marqueur de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Écrire une présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini les options de marqueur de graphique au niveau des points de données.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}


## **Définir le Marqueur de Graphique au Niveau des Points de Données de Série**
Maintenant, les marqueurs peuvent être définis sur les points de données de graphique à l'intérieur d'une série particulière. Pour définir les options de marqueur de graphique, veuillez suivre les étapes ci-dessous :

- Instancier la classe Presentation.
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série de graphique.
- Ajouter un nouveau point de données.
- Écrire une présentation sur le disque.

Dans l'exemple donné ci-dessous, nous avons défini les options de marqueur de graphique au niveau des points de données.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instancier la classe Presentation qui représente le fichier PPTX
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Accéder à la première diapositive
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Ajouter un graphique avec des données par défaut
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Définir l'index de la feuille de données du graphique
int defaultWorksheetIndex = 0;

// Obtenir la feuille de données du graphique
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Supprimer les séries et catégories générées par défaut
chart->get_ChartData()->get_Series()->Clear();

// Maintenant, ajouter une nouvelle série
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Série 1")), chart->get_Type());

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

// Changer le marqueur de série du graphique
series->get_Marker()->set_Size(15);

// Écrire le fichier de présentation sur le disque
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Appliquer une Couleur aux Points de Données**
Vous pouvez appliquer une couleur aux points de données dans le graphique en utilisant Aspose.Slides pour C++. La classe **[IChartDataPointLevelsManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_levels_manager)** et **[IChartDataPointLevel](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_point_level)** ont été ajoutées pour accéder aux propriétés des niveaux de points de données. Cet article démontre comment vous pouvez accéder et appliquer une couleur aux points de données dans un graphique.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}