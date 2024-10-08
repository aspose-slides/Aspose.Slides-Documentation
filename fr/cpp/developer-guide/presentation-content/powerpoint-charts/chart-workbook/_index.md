---
title: Classeur de graphique
type: docs
weight: 70
url: /fr/cpp/chart-workbook/
keywords: "Classeur de graphique, données de graphique, présentation PowerPoint, C++, CPP, Aspose.Slides pour C++"
description: "Classeur de graphique dans une présentation PowerPoint en C++"
---

## **Définir les données de graphique depuis le classeur**

Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e) et [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e) qui vous permettent de lire et d'écrire des classeurs de données de graphique (contenant des données de graphique éditées avec Aspose.Cells). **Remarque** : les données du graphique doivent être organisées de la même manière ou avoir une structure similaire à la source.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Ce code C++ démontre l'opération pour définir un classeur de données de graphique :

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Définir la cellule du classeur comme DataLabel de graphique**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).
1. Obtenez la référence d'une diapositive via son index.
1. Ajoutez un graphique en bulles avec des données.
1. Accédez aux séries de graphique.
1. Définissez la cellule du classeur comme une étiquette de données.
1. Enregistrez la présentation.

Ce code C++ montre comment définir une cellule du classeur comme une étiquette de données de graphique :

``` cpp
System::String lbl0 = u"Valeur de la cellule Étiquette 0";
System::String lbl1 = u"Valeur de la cellule Étiquette 1";
System::String lbl2 = u"Valeur de la cellule Étiquette 2";

// Instantiates a Presentation class that represents a presentation file 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Gérer les feuilles de calcul**

Ce code C++ démontre une opération où la propriété [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928) est utilisée pour accéder à une collection de feuilles de calcul :

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Spécifier le type de source de données**

Ce code C++ montre comment spécifier un type pour une source de données :

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"Chaîne Littérale"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NouvelleCellule")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4, nous avons implémenté le support des classeurs externes en tant que source de données pour des graphiques.
{{% /alert %}} 

### **Créer un classeur externe**

En utilisant les méthodes **`ReadWorkbookStream`** et **`SetExternalWorkbook`**, vous pouvez soit créer un classeur externe de zéro, soit rendre un classeur interne externe.

Ce code C++ démontre le processus de création de classeur externe :

```c++
auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Définir un classeur externe**

En utilisant la méthode **`IChartData.SetExternalWorkbook`**, vous pouvez assigner un classeur externe à un graphique comme sa source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin vers le classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données dans les classeurs stockés dans des emplacements ou ressources distants, vous pouvez toujours utiliser ces classeurs comme source de données externe. Si le chemin relatif d'un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code C++ montre comment définir un classeur externe :

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

Le paramètre `updateChartData` (sous la méthode `SetExternalWorkbook`) est utilisé pour spécifier si un classeur Excel sera chargé ou non. 

* Lorsque la valeur de `updateChartData` est définie sur `false`, seul le chemin du classeur est mis à jour - les données du graphique ne seront pas chargées ou mises à jour à partir du classeur cible. Vous pouvez vouloir utiliser ce réglage lorsqu'une situation se présente où le classeur cible n'existe pas ou n'est pas disponible. 
* Lorsque la valeur de `updateChartData` est définie sur `true`, les données du graphique sont mises à jour à partir du classeur cible.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Obtenir le chemin du classeur de source de données externe du graphique**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. Obtenez la référence d'une diapositive via son index.
3. Créez un objet pour la forme de graphique.
4. Créez un objet pour le type de source (`ChartDataSourceType`) qui représente la source de données du graphique.
5. Spécifiez la condition pertinente basée sur le type de source étant le même que le type de source de données de classeur externe.

Ce code C++ démontre l'opération :

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Enregistre la présentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Modifier les données du graphique**

Vous pouvez modifier les données dans les classeurs externes de la même manière que vous apportez des modifications au contenu des classeurs internes. Lorsqu'un classeur externe ne peut pas être chargé, une exception est levée.

Ce code C++ est une implémentation du processus décrit :

```c++
const String templatePath = u"../templates/presentation.pptx";
const String outPath = u"../out/presentation-out.pptx";
    

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
    

chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```