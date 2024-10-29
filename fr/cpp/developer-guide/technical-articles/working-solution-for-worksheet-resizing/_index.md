---  
title: Solution efficace pour le redimensionnement des feuilles de calcul  
type: docs  
weight: 130  
url: /fr/cpp/solution-efficace-pour-le-redimensionnement-des-feuilles-de-calcul/  
---  

{{% alert color="primary" %}}  

Il a été observé que les feuilles de calcul Excel intégrées en tant qu'objet OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle non identifiée après la première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. Nous avons examiné ce problème en détail et trouvé la solution à ce problème abordé dans cet article.  

{{% /alert %}}  
## **Contexte**  
Dans l'article Ajouter des cadres OLE, nous avons expliqué comment ajouter un cadre OLE dans une présentation d'une présentation PowerPoint en utilisant Aspose.Slides pour C++. Afin de résoudre le problème de l'objet modifié, nous avons assigné l'image de la feuille de calcul de la zone sélectionnée au cadre d'objet OLE du graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur le cadre d'objet OLE affichant l'image de la feuille de calcul, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées dans le classeur Excel réel et revenir ensuite à la diapositive concernée en cliquant en dehors du classeur Excel activé. La taille du cadre d'objet OLE changera lorsque l'utilisateur retournera à la diapositive. Le facteur de redimensionnement sera différent selon les différentes tailles du cadre d'objet OLE et du classeur Excel intégré.  
## **Cause du redimensionnement**  
Étant donné que le classeur Excel a sa propre taille de fenêtre, il essaie de maintenir sa taille d'origine lors de la première activation. D'autre part, le cadre d'objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. En fonction des différences de taille de fenêtres Excel et de taille / position du cadre d'objet OLE, le redimensionnement a lieu.  
## **Solution fonctionnelle**  
Il existe deux solutions possibles pour éviter l'effet de redimensionnement.  

- Redimensionner la taille du cadre OLE dans PPT pour correspondre à la taille en termes de hauteur/largeur du nombre souhaité de lignes/colonnes dans le cadre OLE  
- Garder la taille du cadre OLE constante et redimensionner la taille des lignes/colonnes participantes pour s'adapter à la taille du cadre OLE sélectionné  
## **Redimensionner la taille du cadre OLE à la taille des lignes/colonnes sélectionnées de la feuille de calcul**  
Dans cette approche, nous apprendrons comment définir la taille du cadre OLE du classeur Excel intégré équivalente à la taille cumulée du nombre de lignes et de colonnes participantes dans la feuille de calcul Excel.  
## **Exemple**  
Supposons que nous ayons défini une feuille de calcul Excel modèle et que nous souhaitions l'ajouter à la présentation en tant que cadre OLE. Dans ce scénario, la taille du cadre d'objet OLE sera d'abord calculée en fonction de la hauteur cumulée des lignes et des largeurs des colonnes des lignes et colonnes du classeur participantes, respectivement. Ensuite, nous fixerons la taille du cadre OLE à cette valeur calculée. Afin d'éviter le message rouge **Objet intégré** pour le cadre OLE dans PowerPoint, nous obtiendrons également l'image des portions souhaitées des lignes et des colonnes dans le classeur et définirons cela comme image du cadre OLE.  

``` cpp  
auto workbookDesigner = Aspose::Cells::Factory::CreateIWorkbookDesigner();  
workbookDesigner->SetIWorkbook(Aspose::Cells::Factory::CreateIWorkbook(new Aspose::Cells::Systems::String("d:/AsposeTest.xls")));  

System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>(u"d:/AsposeTest.ppt");  
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);  

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);  

System::String fileName = u"d:/AsposeTest_Ole.ppt";  
presentation->Save(fileName, Export::SaveFormat::Pptx);  
```  

``` cpp  
System::Drawing::Size SetOleAccordingToSelectedRowsColumns(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t startRow, int32_t endRow, int32_t startCol, int32_t endCol, int32_t dataSheetIdx)  
{  
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  

    double actualHeight = 0, actualWidth = 0;  

    for (int32_t i = startRow; i <= endRow; i++)  
    {  
        actualHeight += work->GetICells()->GetRowHeightInch(i);  
    }  

    for (int32_t i = startCol; i <= endCol; i++)  
    {  
        actualWidth += work->GetICells()->GetColumnWidthInch(i);  
    }  

    // Réglage de la nouvelle hauteur des lignes et de la largeur des colonnes  
    return System::Drawing::Size((int32_t)(System::Math::Round(actualWidth, 2) * 576), (int32_t)(System::Math::Round(actualHeight, 2) * 576));  
}  
```  

``` cpp  
void AddOleFrame(System::SharedPtr<ISlide> slide, int32_t startRow, int32_t endRow,  
    int32_t startCol, int32_t endCol, int32_t dataSheetIdx, int32_t x, int32_t y,  
    double OleWidth, double OleHeight, System::SharedPtr<IPresentation> presentation,  
    intrusive_ptr<Aspose::Cells::IWorkbookDesigner> workbookDesigner,  
    bool onePagePerSheet, int32_t outputWidth, int32_t outputHeight)  
{  
    std::wstring tempFileName = System::IO::Path::GetTempFileName_().ToWCS();  
    if (startRow == 0)  
    {  
        startRow++;  
        endRow++;  
    }  

    // Définir l'index de la feuille active du classeur  
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);  

    // Obtention du classeur et de la feuille de calcul sélectionnée  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();  
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  

    // Réglage de la taille du cadre OLE selon les lignes et colonnes sélectionnées  
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);  
    OleWidth = SlideOleSize.get_Width();  
    OleHeight = SlideOleSize.get_Height();  

    // Définir la taille OLE dans le classeur  
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);  

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);  

    // Définir les options d'image pour prendre l'image de la feuille de calcul  
    intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> imageOrPrintOptions = Aspose::Cells::Factory::CreateIImageOrPrintOptions();  
    imageOrPrintOptions->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());  
    imageOrPrintOptions->SetOnePagePerSheet(onePagePerSheet);  

    intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> render = Aspose::Cells::Factory::CreateISheetRender(workbookDesigner->GetIWorkbook()->GetIWorksheets()->GetObjectByIndex(dataSheetIdx), imageOrPrintOptions);  
    tempFileName.append(L".bmp");  
    render->ToImage(0, new String(tempFileName.c_str()));  

    System::String slidesTempFileName = System::String::FromWCS(tempFileName);  
    System::SharedPtr<System::Drawing::Image> image = ScaleImage(System::Drawing::Image::FromFile(slidesTempFileName), outputWidth, outputHeight);  
    System::String newTempFileName = slidesTempFileName.Replace(u".tmp", u".tmp1");  
    image->Save(newTempFileName, System::Drawing::Imaging::ImageFormat::get_Bmp());  

    // Ajout d'Image à la collection d'images de la diapositive  
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));  

    // Sauvegarde du classeur dans le flux et copie dans un tableau d'octets  
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());  
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);  
    mstream->set_Position(0);  
    mstream->Read(chartOleData, 0, chartOleData->get_Length());  

    // Ajout du cadre d'objet Ole  
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");  
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);  

    // Réglage de l'image du cadre ole et du texte alternatif    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);  
    oleObjectFrame->set_AlternativeText(System::String(u"image") + ppImage);  
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
System::SharedPtr<System::Drawing::Image> ScaleImage(System::SharedPtr<System::Drawing::Image> image, int32_t outputWidth, int32_t outputHeight)  
{  
    if (outputWidth == 0 && outputHeight == 0)  
    {  
        outputWidth = image->get_Width();  
        outputHeight = image->get_Height();  
    }  
    System::SharedPtr<System::Drawing::Bitmap> outputImage = System::MakeObject<System::Drawing::Bitmap>(outputWidth, outputHeight, image->get_PixelFormat());  
    outputImage->SetResolution(image->get_HorizontalResolution(), image->get_VerticalResolution());  
    System::SharedPtr<System::Drawing::Graphics> graphics = System::Drawing::Graphics::FromImage(outputImage);  
    graphics->set_InterpolationMode(System::Drawing::Drawing2D::InterpolationMode::HighQualityBicubic);  
    System::Drawing::Rectangle srcDestRect(0, 0, outputWidth, outputHeight);  
    graphics->DrawImage(image, srcDestRect, srcDestRect, System::Drawing::GraphicsUnit::Pixel);  
    graphics->Dispose();  

    return outputImage;  
}  
```  

## **Redimensionner la hauteur des lignes et la largeur des colonnes de la feuille de calcul selon la taille du cadre OLE**  
Dans cette approche, nous apprendrons comment redimensionner les hauteurs des lignes participantes et les largeurs des colonnes participantes en fonction de la taille du cadre OLE définie sur mesure.  
## **Exemple**  
Supposons que nous ayons défini une feuille de calcul Excel modèle et que nous souhaitions l'ajouter à la présentation en tant que cadre OLE. Dans ce scénario, nous définirons la taille du cadre OLE et redimensionnerons la taille des lignes et des colonnes participant à la zone du cadre OLE. Nous sauvegarderons ensuite le classeur dans le flux pour enregistrer les modifications et le convertir en tableau d'octets afin de l'ajouter dans le cadre OLE. Afin d'éviter le message rouge **Objet intégré** pour le cadre OLE dans PowerPoint, nous obtiendrons également l'image des portions souhaitées des lignes et des colonnes dans le classeur et définirons cela comme image du cadre OLE.  

``` cpp  
auto workbookDesigner = Aspose::Cells::Factory::CreateIWorkbookDesigner();  
workbookDesigner->SetIWorkbook(Aspose::Cells::Factory::CreateIWorkbook(new Aspose::Cells::Systems::String("d:/AsposeTest.xls")));  

System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>(u"d:/AsposeTest.ppt");  
System::SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);  

AddOleFrame(slide, 0, 15, 0, 3, 0, 300, 1100, 0, 0, presentation, workbookDesigner, true, 0, 0);  

System::String fileName = u"d:/AsposeTest_Ole.ppt";  
presentation->Save(fileName, Export::SaveFormat::Pptx);  
```  

``` cpp  
void SetOleAccordingToCustomHeightWidth(intrusive_ptr<Aspose::Cells::IWorkbook> workbook, int32_t startRow, int32_t endRow, int32_t startCol, int32_t endCol, double slideWidth, double slideHeight, int32_t dataSheetIdx)  
{  
    auto work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  

    double actualHeight = 0, actualWidth = 0;  

    double newHeight = slideHeight;  
    double newWidth = slideWidth;  
    double tem = 0;  
    double newTem = 0;  

    for (int32_t i = startRow; i <= endRow; i++)  
    {  
        actualHeight += work->GetICells()->GetRowHeightInch(i);  
    }  

    for (int32_t i = startCol; i <= endCol; i++)  
    {  
        actualWidth += work->GetICells()->GetColumnWidthInch(i);  
    }  

    // Réglage de la nouvelle hauteur des lignes et de la largeur des colonnes  
    for (int32_t i = startRow; i <= endRow; i++)  
    {  
        tem = work->GetICells()->GetRowHeightInch(i);  
        newTem = (tem / actualHeight) * newHeight;  
        work->GetICells()->SetRowHeightInch(i, newTem);  
    }  

    for (int32_t i = startCol; i <= endCol; i++)  
    {  
        tem = work->GetICells()->GetColumnWidthInch(i);  
        newTem = (tem / actualWidth) * newWidth;  
        work->GetICells()->SetColumnWidthInch(i, newTem);  
    }  
}  
```  

``` cpp  
void AddOleFrame(System::SharedPtr<ISlide> slide, int32_t startRow, int32_t endRow,  
        int32_t startCol, int32_t endCol, int32_t dataSheetIdx, int32_t x, int32_t y,  
        double OleWidth, double OleHeight, System::SharedPtr<IPresentation> presentation,  
        intrusive_ptr<Aspose::Cells::IWorkbookDesigner> workbookDesigner,  
        bool onePagePerSheet, int32_t outputWidth, int32_t outputHeight)  
{  
    std::wstring tempFileName = System::IO::Path::GetTempFileName_().ToWCS();  
    if (startRow == 0)  
    {  
        startRow++;  
        endRow++;  
    }  

    // Définir l'index de la feuille active du classeur  
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);  

    // Obtention du classeur et de la feuille de calcul sélectionnée  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();  
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);  

    // Mise à l'échelle de la hauteur des lignes et de la largeur des colonnes selon la taille OLE personnalisée  
    double height = OleHeight / 576.0f;  
    double width = OleWidth / 576.0f;  

    // Réglage de la taille OLE selon les lignes et colonnes sélectionnées  
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);  

    // Définir la taille OLE dans le classeur  
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);  
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);  

    // Définir les options d'image pour prendre l'image de la feuille de calcul  
    intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> imageOrPrintOptions = Aspose::Cells::Factory::CreateIImageOrPrintOptions();  
    imageOrPrintOptions->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetBmp());  
    imageOrPrintOptions->SetOnePagePerSheet(onePagePerSheet);  

    intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> render = Aspose::Cells::Factory::CreateISheetRender(workbookDesigner->GetIWorkbook()->GetIWorksheets()->GetObjectByIndex(dataSheetIdx), imageOrPrintOptions);  
    tempFileName.append(L".bmp");  
    render->ToImage(0, new String(tempFileName.c_str()));  

    System::String slidesTempFileName = System::String::FromWCS(tempFileName);  
    System::SharedPtr<System::Drawing::Image> image = ScaleImage(System::Drawing::Image::FromFile(slidesTempFileName), outputWidth, outputHeight);  
    System::String newTempFileName = slidesTempFileName.Replace(u".tmp", u".tmp1");  
    image->Save(newTempFileName, System::Drawing::Imaging::ImageFormat::get_Bmp());  

    // Ajout d'Image à la collection d'images de la diapositive  
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));  

    // Sauvegarde du classeur dans le flux et copie dans un tableau d'octets  
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());  
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);  
    mstream->set_Position(0);  
    mstream->Read(chartOleData, 0, chartOleData->get_Length());  

    // Ajout du cadre d'objet Ole  
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");  
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);  

    // Réglage de l'image du cadre ole et du texte alternatif    
    oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(ppImage);  
    oleObjectFrame->set_AlternativeText(System::String(u"image") + ppImage);  
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
System::SharedPtr<System::Drawing::Image> ScaleImage(System::SharedPtr<System::Drawing::Image> image, int32_t outputWidth, int32_t outputHeight)  
{  
    if (outputWidth == 0 && outputHeight == 0)  
    {  
        outputWidth = image->get_Width();  
        outputHeight = image->get_Height();  
    }  
    System::SharedPtr<System::Drawing::Bitmap> outputImage = System::MakeObject<System::Drawing::Bitmap>(outputWidth, outputHeight, image->get_PixelFormat());  
    outputImage->SetResolution(image->get_HorizontalResolution(), image->get_VerticalResolution());  
    System::SharedPtr<System::Drawing::Graphics> graphics = System::Drawing::Graphics::FromImage(outputImage);  
    graphics->set_InterpolationMode(System::Drawing::Drawing2D::InterpolationMode::HighQualityBicubic);  
    System::Drawing::Rectangle srcDestRect(0, 0, outputWidth, outputHeight);  
    graphics->DrawImage(image, srcDestRect, srcDestRect, System::Drawing::GraphicsUnit::Pixel);  
    graphics->Dispose();  

    return outputImage;  
}  
```  

## **Conclusion**  

{{% alert color="primary" %}}   {{% /alert %}}  

Il existe deux approches pour résoudre le problème de redimensionnement des feuilles de calcul. Le choix de l'approche appropriée dépend des besoins et du cas d'utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d'un modèle ou créées de toutes pièces. De plus, il n'y a pas de limite de taille pour le cadre d'objet OLE dans la solution.  

h4. {_}Sections connexes  
{_}  

[Créer et intégrer un graphique Excel en tant qu'objet OLE dans la présentation](/slides/fr/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)  