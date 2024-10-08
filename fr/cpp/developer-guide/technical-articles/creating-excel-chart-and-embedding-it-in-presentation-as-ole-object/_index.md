---
title: Création d'un graphique Excel et son intégration dans une présentation en tant qu'objet OLE
type: docs
weight: 40
url: /fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

Dans les diapositives PowerPoint, l'utilisation de graphiques modifiables pour l'affichage graphique des données est une activité courante. Aspose fournit le support de la création de graphiques Excel avec l'utilisation d'Aspose.Cells pour C++ et ces graphiques peuvent ensuite être intégrés en tant qu'objet OLE dans la diapositive PowerPoint via Aspose.Slides pour C++. Cet article couvre les étapes requises ainsi que l'implémentation en C++ pour créer et intégrer un graphique MS Excel en tant qu'objet OLE dans une présentation PowerPoint en utilisant Aspose.Cells pour C++ et Aspose.Slides pour C++.

{{% /alert %}} 
## **Étapes requises**
La séquence suivante d'étapes est requise pour créer et intégrer un graphique Excel en tant qu'objet OLE dans la diapositive PowerPoint :

1. Créer un graphique Excel en utilisant Aspose.Cells pour C++.
2. Définir la taille OLE du graphique Excel en utilisant Aspose.Cells pour C++. 
3. Obtenir l'image du graphique Excel avec Aspose.Cells pour C++. 
4. Intégrer le graphique Excel en tant qu'objet OLE à l'intérieur de la présentation PPTX en utilisant Aspose.Slides pour C++. 
5. Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour résoudre le problème de l'objet modifié.
6. Écrire la présentation de sortie sur le disque au format PPTX.

## **Implémentation des étapes requises**
L'implémentation des étapes ci-dessus en C++ est la suivante :

``` cpp
//Étape - 1 : Créer un graphique Excel en utilisant Aspose.Cells
//--------------------------------------------------
//Créer un classeur
intrusive_ptr<Aspose::Cells::IWorkbook> wb = Aspose::Cells::Factory::CreateIWorkbook();
//Ajouter un graphique Excel
int32_t chartRows = 55;
int32_t chartCols = 25;
int32_t chartSheetIndex = AddExcelChartInWorkbook(wb, chartRows, chartCols);
//Étape - 2 : Définir la taille OLE du graphique. utilisant Aspose.Cells
//----------------------------------------------------------- 
wb->GetIWorksheets()->SetOleSize(0, chartRows, 0, chartCols);
//Étape - 3 : Obtenir l'image du graphique avec Aspose.Cells
//-----------------------------------------------------------
//System::SharedPtr<System::Drawing::Bitmap>
auto imgChart = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIndex)->GetICharts()->GetObjectByIndex(0)->ToImage();
//Sauvegarder le classeur dans un flux
System::SharedPtr<System::IO::MemoryStream> wbStream = ToSlidesMemoryStream(wb->SaveToStream());
//Étape - 4  ET 5
//-----------------------------------------------------------
//Étape - 4 : Intégrer le graphique en tant qu'objet OLE à l'intérieur de la présentation .ppt en utilisant Aspose.Slides
//-----------------------------------------------------------
//Étape - 5 : Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour résoudre le problème de l'objet modifié
//-----------------------------------------------------------
//Créer une présentation
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Ajouter le classeur sur la diapositive
AddExcelChartInPresentation(pres, slide, wbStream, imgChart);

//Étape - 6 : Écrire la présentation de sortie sur le disque
//----------------------------------------------------------- 
pres->Save(u"d:/OutputChart.pptx", SaveFormat::Pptx);
```

``` cpp
void AddExcelChartInPresentation(System::SharedPtr<Presentation> pres, System::SharedPtr<ISlide> sld, 
                                    System::SharedPtr<System::IO::Stream> wbStream, 
                                    intrusive_ptr<Aspose::Cells::Systems::Drawing::Bitmap> imgChart)
{
    float oleWidth = pres->get_SlideSize()->get_Size().get_Width();
    float oleHeight = pres->get_SlideSize()->get_Size().get_Height();
    int32_t x = 0;
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(wbStream->get_Length(), 0);
    wbStream->set_Position(0);
    wbStream->Read(chartOleData, 0, chartOleData->get_Length());

    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oof;
    oof = sld->get_Shapes()->AddOleObjectFrame(static_cast<float>(x), 0.0f, oleWidth, oleHeight, dataInfo);

    intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
    imgChart->Save(cellsOutputStream, Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());

    auto imgChartSlides = Images::FromStream(ToSlidesMemoryStream(cellsOutputStream));
    oof->get_SubstitutePictureFormat()->get_Picture()->set_Image(pres->get_Images()->AddImage(imgChartSlides));
}
```

``` cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

``` cpp
int32_t AddExcelChartInWorkbook(intrusive_ptr<Aspose::Cells::IWorkbook> wb, int32_t chartRows, int32_t chartCols)
{
    // Tableau des noms de cellules
    System::ArrayPtr<System::String> cellsName = System::MakeArray<System::String>(
        { u"A1", u"A2", u"A3", u"A4", 
            u"B1", u"B2", u"B3", u"B4",
            u"C1", u"C2", u"C3", u"C4",
            u"D1", u"D2", u"D3", u"D4",
            u"E1", u"E2", u"E3", u"E4" });
    
    // Tableau des données des cellules
    System::ArrayPtr<int32_t> cellsValue = System::MakeArray<int32_t>(
        { 67, 86, 68, 91,
            44, 64, 89, 48,
            46, 97, 78, 60,
            43, 29, 69, 26,
            24, 40, 38, 25 });

    // Ajouter une nouvelle feuille de calcul pour peupler les cellules avec des données
    int32_t dataSheetIdx = wb->GetIWorksheets()->Add();
    intrusive_ptr<Aspose::Cells::IWorksheet> dataSheet = wb->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);
    intrusive_ptr<Aspose::Cells::Systems::String> sheetName = new Aspose::Cells::Systems::String("DataSheet");
    dataSheet->SetName(sheetName);

    // Peupler la DataSheet avec des données
    for (int32_t i = 0; i < cellsName->get_Length(); i++)
    {
        System::String cellName = cellsName[i];
        int32_t cellValue = cellsValue[i];
        dataSheet->GetICells()->GetObjectByIndex(new String(cellName.ToWCS().c_str()))->PutValue(cellValue);
    }

    // Ajouter une feuille de graphique
    int32_t chartSheetIdx = wb->GetIWorksheets()->Add(Aspose::Cells::SheetType::SheetType_Chart);
    intrusive_ptr<Aspose::Cells::IWorksheet> chartSheet = wb->GetIWorksheets()->GetObjectByIndex(chartSheetIdx);
    chartSheet->SetName(new String("ChartSheet"));

    // Ajouter un graphique dans ChartSheet avec des séries de données de DataSheet
    int32_t chartIdx = chartSheet->GetICharts()->Add(Aspose::Cells::Charts::ChartType::ChartType_Column, 0, chartRows, 0, chartCols);
    intrusive_ptr<Aspose::Cells::Charts::IChart> chart = chartSheet->GetICharts()->GetObjectByIndex(chartIdx);
    chart->GetNISeries()->Add(sheetName + "!A1:E1", false);
    chart->GetNISeries()->Add(sheetName + "!A2:E2", false);
    chart->GetNISeries()->Add(sheetName + "!A3:E3", false);
    chart->GetNISeries()->Add(sheetName + "!A4:E4", false);

    // Définir ChartSheet comme feuille active
    wb->GetIWorksheets()->SetActiveSheetIndex(chartSheetIdx);

    return chartSheetIdx;
}
```

{{% alert color="primary" %}} 

La présentation créée par la méthode ci-dessus contiendra le graphique Excel en tant qu'objet OLE qui peut être activé en double-cliquant sur le cadre de l'objet OLE.

{{% /alert %}} 
## **Conclusion**
{{% alert color="primary" %}} 

En utilisant Aspose.Cells pour C++ ainsi qu'Aspose.Slides pour C++, nous pouvons créer l'un des graphiques Excel pris en charge par Aspose.Cells pour C++ et intégrer le graphique créé en tant qu'objet OLE dans une diapositive PowerPoint. La taille OLE du graphique Excel peut également être définie. Les utilisateurs finaux peuvent de plus éditer le graphique Excel comme n'importe quel autre objet OLE.

{{% /alert %}} 
## **Sections connexes**
[Solution fonctionnelle pour le redimensionnement des graphiques](https://docs.aspose.com/slides/cpp/working-solution-for-chart-resizing-in-pptx/)