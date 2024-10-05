---
title: ワークシートのサイズ変更に関する作業ソリューション
type: docs
weight: 130
url: /cpp/working-solution-for-worksheet-resizing/
---

{{% alert color="primary" %}} 

Aspose コンポーネントを介して PowerPoint プレゼンテーションに OLE として埋め込まれた Excel ワークシートが、初回アクティベーション後に特定できないスケールにリサイズされることが観察されました。この動作は、チャートのアクティベーション前後のプレゼンテーションにかなりの視覚的な違いを作り出します。この問題を詳細に調査し、この記事で取り上げられている解決策を見つけました。

{{% /alert %}} 
## **背景**
「OLE フレームの追加」記事では、Aspose.Slides for C++を使用して PowerPoint プレゼンテーションに OLE フレームを追加する方法を説明しました。オブジェクト変更の問題に対処するために、選択した範囲のワークシート画像をチャート OLE オブジェクトフレームに割り当てました。出力プレゼンテーションでは、ワークシート画像を表示する OLE オブジェクトフレームをダブルクリックすると、Excel チャートがアクティベートされます。エンドユーザーは、実際の Excel ワークブックで任意の変更を行い、アクティブな Excel ワークブックの外をクリックすることで関連するスライドに戻ることができます。ユーザーがスライドに戻ると、OLE オブジェクトフレームのサイズが変更されます。リサイズ係数は、OLE オブジェクトフレームや埋め込まれた Excel ワークブックの異なるサイズに応じて異なります。
## **リサイズの原因**
Excel ワークブックには独自のウィンドウサイズがあるため、初回アクティベーション時に元のサイズを保持しようとします。一方で、OLE オブジェクトフレームは独自のサイズを持っています。Microsoft によると、Excel ワークブックのアクティベーション時に、Excel と PowerPoint がサイズを交渉し、埋め込み操作の一部として正しい比率であることを確認します。Excel ウィンドウサイズと OLE オブジェクトフレームサイズ/位置の違いに基づいてリサイズが行われます。
## **作業ソリューション**
リサイズ効果を回避するための 2 つの可能な解決策があります。

- OLE フレームのサイズを PPT でスケーリングして、OLE フレームの希望する行/列の高さ/幅に一致させる
- OLE フレームのサイズを一定に保ち、参加する行/列のサイズをスケーリングして、選択した OLE フレームのサイズに収める
## **OLE フレームサイズをワークシートの選択行/列サイズにスケーリング**
このアプローチでは、埋め込まれた Excel ワークブックの OLE フレームサイズを Excel ワークシートの参加行および列の累積サイズに等しく設定する方法を学びます。
## **例**
テンプレート Excel シートを定義し、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、まず参加ワークブックの行および列の累積高さと幅に基づいて OLE オブジェクトフレームのサイズが計算されます。次に、その計算された値に OLE フレームのサイズを設定します。PowerPoint で OLE フレームに対して赤い **埋め込みオブジェクト** メッセージを避けるために、ワークブック内の行と列の希望する部分の画像も取得し、それを OLE フレーム画像として設定します。 

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

    // 新しい行と列の高さを設定
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

    // ワークブックのアクティブシートインデックスを設定
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // ワークブックと選択したワークシートを取得  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // 選択した行と列に応じた Ole サイズを設定
    System::Drawing::Size SlideOleSize = SetOleAccordingToSelectedRowsColumns(workbook, startRow, endRow, startCol, endCol, dataSheetIdx);
    OleWidth = SlideOleSize.get_Width();
    OleHeight = SlideOleSize.get_Height();

    // ワークブックで Ole サイズを設定
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);

    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // ワークシート画像を取得するための画像オプションを設定
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

    // スライドの画像コレクションに画像を追加
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // ワークブックをストリームに保存し、バイト配列にコピー
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // OLE オブジェクトフレームを追加
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // ole フレームの画像と代替テキストを設定    
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

## **OLE フレームサイズに基づいてワークシートの行の高さと列の幅をスケーリング**
このアプローチでは、カスタム設定された OLE フレームサイズに応じて参加する行の高さと列の幅をスケーリングする方法を学びます。
## **例**
テンプレート Excel シートを定義し、それを OLE フレームとしてプレゼンテーションに追加したいとします。このシナリオでは、OLE フレームのサイズを設定し、OLE フレーム領域に参加する行と列のサイズをスケーリングします。その後、ワークブックをストリームに保存して変更を保存し、それをバイト配列に変換して OLE フレームに追加します。PowerPoint で OLE フレームに対して赤い **埋め込みオブジェクト** メッセージを避けるために、ワークブック内の行と列の希望する部分の画像も取得し、それを OLE フレーム画像として設定します。 

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

    // 新しい行と列の高さを設定
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

    // ワークブックのアクティブシートインデックスを設定
    workbookDesigner->GetIWorkbook()->GetIWorksheets()->SetActiveSheetIndex(dataSheetIdx);

    // ワークブックと選択したワークシートを取得  
    intrusive_ptr<Aspose::Cells::IWorkbook> workbook = workbookDesigner->GetIWorkbook();
    intrusive_ptr<Aspose::Cells::IWorksheet> work = workbook->GetIWorksheets()->GetObjectByIndex(dataSheetIdx);

    // カスタム Ole サイズに応じて行の高さと列の幅をスケーリング
    double height = OleHeight / 576.0f;
    double width = OleWidth / 576.0f;

    // 選択した行と列に応じた Ole サイズを設定
    SetOleAccordingToCustomHeightWidth(workbook, startRow, endRow, startCol, endCol, width, height, dataSheetIdx);

    // ワークブックで Ole サイズを設定
    workbook->GetIWorksheets()->SetOleSize(startRow, endRow, startCol, endCol);
    workbook->GetIWorksheets()->GetObjectByIndex(0)->SetGridlinesVisible(false);

    // ワークシート画像を取得するための画像オプションを設定
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

    // スライドの画像コレクションに画像を追加
    auto ppImage = presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(newTempFileName));

    // ワークブックをストリームに保存し、バイト配列にコピー
    System::SharedPtr<System::IO::Stream> mstream = ToSlidesMemoryStream(workbook->SaveToStream());
    System::ArrayPtr<uint8_t> chartOleData = System::MakeArray<uint8_t>(mstream->get_Length(), 0);
    mstream->set_Position(0);
    mstream->Read(chartOleData, 0, chartOleData->get_Length());

    // OLE オブジェクトフレームを追加
    System::SharedPtr<OleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(chartOleData, u"xls");
    System::SharedPtr<IOleObjectFrame> oleObjectFrame = slide->get_Shapes()->AddOleObjectFrame(x, y, OleWidth, OleHeight, dataInfo);

    // ole フレームの画像と代替テキストを設定    
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

## **結論**

{{% alert color="primary" %}}   {{% /alert %}} 

ワークシートのリサイズの問題を修正するための 2 つのアプローチがあります。適切なアプローチの選択は、要件と使用ケースによって異なります。プレゼンテーションがテンプレートから作成されるか、最初から作成されるかに関わらず、両方のアプローチは同様に機能します。また、解決策には OLE オブジェクトフレームサイズの制限はありません。 

h4. {_}関連セクション 
{_}

[プレゼンテーションに Excel チャートを OLE オブジェクトとして作成および埋め込む](/slides/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)