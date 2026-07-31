---
title: Gérer les repères de données de graphiques dans les présentations en C++
linktitle: Repère de données
type: docs
url: /fr/cpp/chart-data-marker/
keywords:
- graphique
- point de données
- repère
- options de repère
- taille du repère
- type de remplissage
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Apprenez à personnaliser les repères de données des graphiques dans Aspose.Slides pour C++, améliorant l'impact des présentations aux formats PPT et PPTX grâce à des exemples de code C++ clairs."
---
## **Vue d'ensemble**

Cet article explique comment travailler avec les repères de données de graphiques dans Aspose.Slides. Il montre comment créer un graphique, accéder à une série et à ses points de données, appliquer des remplissages d'image aux repères au niveau du point de données, ajuster la taille du repère et enregistrer la présentation mise à jour. Il indique également que les formes de repères standard sont disponibles via l'énumération `MarkerStyleType` et que l'apparence des repères est conservée lors de l'exportation des graphiques vers des formats raster ou SVG.

## **Définir les repères du graphique**
Aspose.Slides for C++ fournit une API simple pour définir automatiquement le repère de chaque série de graphique. Dans la fonctionnalité suivante, chaque série de graphique obtiendra automatiquement un symbole de repère par défaut différent.

L'exemple de code ci‑dessous montre comment définir automatiquement le repère de la série du graphique.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Définir les options de repère du graphique**
Les repères peuvent être définis sur les points de données du graphique au sein d'une série particulière. Pour définir les options de repère du graphique, suivez les étapes ci‑dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini les options de repère du graphique au niveau des points de données.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Définir les repères du graphique au niveau du point de données de la série**
Désormais, les repères peuvent être définis sur les points de données du graphique au sein d'une série particulière. Pour définir les options de repère du graphique, suivez les étapes ci‑dessous :

- Instancier la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) .
- Créer le graphique par défaut.
- Définir l'image.
- Prendre la première série du graphique.
- Ajouter un nouveau point de données.
- Écrire la présentation sur le disque.

Dans l'exemple ci‑dessous, nous avons défini les options de repère du graphique au niveau des points de données.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//Access first slide
// Add chart with default data
// Setting the index of chart data sheet
// Getting the chart data worksheet
// Delete default generated series and categories
// Now, Adding a new series
// Get the picture
// Add image to presentation's images collection
// Add new point (1:3) there.
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
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
Vous pouvez appliquer une couleur aux points de données du graphique à l'aide d'Aspose.Slides for C++. Les classes [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) et **[IChartDataPointLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/ichartdatapointlevel/)** ont été ajoutées pour accéder aux propriétés des niveaux de points de données. Cet article montre comment accéder et appliquer une couleur aux points de données d'un graphique.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **FAQ**

**Quelles formes de repère sont disponibles immédiatement ?**

Des formes standard sont disponibles (cercle, carré, losange, triangle, etc.) ; la liste est définie par l'énumération [MarkerStyleType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/markerstyletype/). Si vous avez besoin d'une forme non standard, utilisez un repère avec un remplissage d'image pour reproduire des visuels personnalisés.

**Les repères sont-ils conservés lors de l'exportation d'un graphique vers une image ou du SVG ?**

Oui. Lors du rendu des graphiques vers des [formats raster](/slides/fr/cpp/convert-powerpoint-to-png/) ou de l'enregistrement des [formes au format SVG](/slides/fr/cpp/render-a-slide-as-an-svg-image/), les repères conservent leur apparence et leurs paramètres, y compris la taille, le remplissage et le contour.