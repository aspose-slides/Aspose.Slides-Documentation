---
title: Gérer les classeurs de graphiques dans les présentations avec C++
linktitle: Classeur de graphique
type: docs
weight: 70
url: /fr/cpp/chart-workbook/
keywords:
- classeur de graphique
- données de graphique
- cellule de classeur
- étiquette de donnée
- feuille de calcul
- source de données
- classeur externe
- données externes
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Découvrez Aspose.Slides pour C++ : gérez facilement les classeurs de graphiques dans les formats PowerPoint et OpenDocument pour rationaliser les données de votre présentation."
---

## **Lire et écrire des données de graphique à partir d’un classeur**

Aspose.Slides fournit les méthodes [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) et [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) qui vous permettent de lire et d’écrire des classeurs de données de graphique (contenant des données de graphique modifiées avec Aspose.Cells). **Note** que les données de graphique doivent être organisées de la même manière ou doivent avoir une structure similaire à celle de la source.
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


Ce code C++ montre l’opération pour définir un classeur de données de graphique :
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


## **Définir une cellule de WorkBook comme libellé de données de graphique**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Obtenez la référence d’une diapositive via son index.
1. Ajoutez un diagramme à bulles avec quelques données.
1. Accédez aux séries du diagramme.
1. Définissez la cellule du classeur comme libellé de données.
1. Enregistrez la présentation.

Ce code C++ vous montre comment définir une cellule de classeur comme libellé de données de graphique :
``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Instancie une classe Presentation qui représente un fichier de présentation 
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

Ce code C++ montre une opération où la méthode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) est utilisée pour accéder à une collection de feuilles de calcul :
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

Ce code C++ vous montre comment spécifier un type pour une source de données :
```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


## **Classeur externe**

{{% alert color="primary" %}} 
Dans [Aspose.Slides](https://releases.aspose.com/slides/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, nous avons implémenté la prise en charge des classeurs externes comme source de données pour les diagrammes.
{{% /alert %}} 

### **Créer un classeur externe**

En utilisant les méthodes **`ReadWorkbookStream`** et **`SetExternalWorkbook`**, vous pouvez soit créer un classeur externe à partir de zéro, soit rendre un classeur interne externe.

Ce code C++ montre le processus de création d’un classeur externe :
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

En utilisant la méthode **`IChartData::SetExternalWorkbook`**, vous pouvez affecter un classeur externe à un diagramme comme source de données. Cette méthode peut également être utilisée pour mettre à jour le chemin vers le classeur externe (si ce dernier a été déplacé).

Bien que vous ne puissiez pas modifier les données des classeurs stockés dans des emplacements ou des ressources distants, vous pouvez toujours les utiliser comme source de données externe. Si un chemin relatif pour un classeur externe est fourni, il est automatiquement converti en chemin complet.

Ce code C++ vous montre comment définir un classeur externe :
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


Le paramètre `updateChartData` (dans la méthode `SetExternalWorkbook`) sert à spécifier si un classeur Excel sera chargé ou non. 

* Lorsque la valeur de `updateChartData` est `false`, seul le chemin du classeur est mis à jour — les données du diagramme ne seront pas chargées ou mises à jour à partir du classeur cible. Vous pouvez utiliser ce paramètre lorsqu’il n’existe pas ou n’est pas disponible. 
* Lorsque la valeur de `updateChartData` est `true`, les données du diagramme sont mises à jour à partir du classeur cible.
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```


### **Obtenir le chemin du classeur source de données externe d’un diagramme**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) .
1. Obtenez la référence d’une diapositive via son index.
1. Créez un objet pour la forme du diagramme.
1. Créez un objet pour le type source (`ChartDataSourceType`) qui représente la source de données du diagramme.
1. Spécifiez la condition pertinente en fonction du fait que le type de source correspond au type de source de données du classeur externe.

Ce code C++ montre l’opération :
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


### **Modifier les données du diagramme**

Vous pouvez modifier les données des classeurs externes de la même manière que vous modifiez le contenu des classeurs internes. Lorsqu’un classeur externe ne peut pas être chargé, une exception est levée.

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


## **FAQ**

**Puis-je déterminer si un diagramme spécifique est lié à un classeur externe ou intégré ?**

Oui. Un diagramme possède un [type de source de données](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) et un [chemin vers un classeur externe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); si la source est un classeur externe, vous pouvez lire le chemin complet pour vous assurer qu’un fichier externe est utilisé.

**Les chemins relatifs vers des classeurs externes sont-ils pris en charge, et comment sont-ils stockés ?**

Oui. Si vous indiquez un chemin relatif, il est automatiquement converti en chemin absolu. Cela facilite la portabilité du projet ; toutefois, notez que la présentation stockera le chemin absolu dans le fichier PPTX.

**Puis-je utiliser des classeurs situés sur des ressources/partages réseau ?**

Oui, ces classeurs peuvent être utilisés comme source de données externe. Cependant, la modification directe de classeurs distants depuis Aspose.Slides n’est pas prise en charge — ils ne peuvent être utilisés que comme source.

**Aspose.Slides écrase-t-il le XLSX externe lors de l’enregistrement de la présentation ?**

Non. La présentation stocke un [lien vers le fichier externe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) et l’utilise pour lire les données. Le fichier externe lui‑même n’est pas modifié lors de l’enregistrement de la présentation.

**Que faire si le fichier externe est protégé par mot de passe ?**

Aspose.Slides n’accepte pas de mot de passe lors de la liaison. Une approche courante consiste à retirer la protection au préalable ou à préparer une copie décryptée (par exemple, en utilisant [Aspose.Cells](/cells/cpp/)) et à la lier.

**Plusieurs diagrammes peuvent-ils faire référence au même classeur externe ?**

Oui. Chaque diagramme stocke son propre lien. S’ils pointent tous vers le même fichier, la mise à jour de ce fichier sera reflétée dans chaque diagramme lors du prochain chargement des données.