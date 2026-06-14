---
title: 使用 C++ 優化簡報中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/cpp/image/
keywords:
- 加入影像
- 加入圖片
- 加入點陣圖
- 取代影像
- 取代圖片
- 來自網路
- 背景
- 加入 PNG
- 加入 JPG
- 加入 SVG
- 加入 EMF
- 加入 WMF
- 加入 TIFF
- PowerPoint
- OpenDocument
- 簡報
- EMF
- SVG
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 簡化 PowerPoint 與 OpenDocument 中的影像管理，提升效能並自動化工作流程。"
---
## **簡介**

影像讓簡報更具吸引力和趣味性。在 Microsoft PowerPoint 中，您可以從檔案、網際網路或其他位置將圖片插入投影片中。同樣地，Aspose.Slides 允許您透過各種方式在簡報的投影片上加入影像。 

{{% alert title="Tip" color="primary" %}} 

Aspose 提供免費的轉換器—[JPEG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 和 [PNG 轉 PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—讓使用者能夠快速從影像建立簡報。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

如果您想將影像作為框架物件加入——尤其是您計畫使用標準格式設定選項來調整大小、添加效果等——請參閱 [圖片框架](/slides/zh-hant/cpp/picture-frame/)。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

您可以操作涉及影像與 PowerPoint 簡報的輸入/輸出，以將影像從一種格式轉換為另一種格式。請參閱以下頁面：轉換 [影像至 JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/image-to-jpg/); 轉換 [JPG 至影像](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-image/); 轉換 [JPG 至 PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/jpg-to-png/)、轉換 [PNG 至 JPG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-jpg/); 轉換 [PNG 至 SVG](https://products.aspose.com/slides/zh-hant/cpp/conversion/png-to-svg/)、轉換 [SVG 至 PNG](https://products.aspose.com/slides/zh-hant/cpp/conversion/svg-to-png/)。 

{{% /alert %}}

Aspose.Slides 支援這些常見格式的影像操作：JPEG、PNG、GIF 等。 

## **在投影片中加入本機儲存的影像**

您可以將電腦上的一張或多張影像加入簡報的投影片中。以下 C++ 範例程式碼示範如何將影像加入投影片：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **從網路加入影像至投影片**

如果您想加入投影片的影像在電腦上不存在，您可以直接從網路加入影像。 

以下範例程式碼示範如何在 C++ 中從網路加入影像至投影片：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
    
auto webClient = System::MakeObject<WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **將影像加入投影片母片**

投影片母片是一個位於最上層的投影片，儲存並控制其下所有投影片的資訊（佈景主題、版面配置等）。因此，當您將影像加入投影片母片時，該影像會出現在該母片所屬的每張投影片上。 

以下 C++ 範例程式碼示範如何將影像加入投影片母片：

``` cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **將影像作為投影片背景**

您可能會決定將圖片作為特定投影片或多張投影片的背景。此時，請參閱 *[將影像設定為投影片背景](https://docs.aspose.com/slides/zh-hant/cpp/presentation-background/#setting-images-as-background-for-slides)*。

## **在簡報中加入 SVG**

您可以使用屬於 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection) 介面的 [AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection#ab55ae8c24dd32665637725a26ca1c1a9) 方法，將任何影像加入或插入至簡報中。 

若要根據 SVG 影像建立影像物件，您可以這樣做：

1. 建立 SvgImage 物件並將其插入 ImageShapeCollection  
2. 從 ISvgImage 建立 PPImage 物件  
3. 使用 IPPImage 介面建立 PictureFrame 物件  

以下範例程式碼示範如何實作上述步驟，將 SVG 影像加入簡報：

``` cpp 
// 文件目錄的路徑
System::String dataDir = u"D:\\Documents\\";

// 來源 SVG 檔案名稱
System::String svgFileName = dataDir + u"sample.svg";

// 輸出簡報檔案名稱
System::String outPptxPath = dataDir + u"presentation.pptx";

// 建立新簡報
auto p = System::MakeObject<Presentation>();

// 讀取 SVG 檔案內容
System::String svgContent = File::ReadAllText(svgFileName);

// 建立 SvgImage 物件
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 建立 PPImage 物件
System::SharedPtr<IPPImage> ppImage = p->get_Images()->AddImage(svgImage);

// 建立新的 PictureFrame 
p->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 200.0f, 100.0f, static_cast<float>(ppImage->get_Width()), static_cast<float>(ppImage->get_Height()), ppImage);

// 以 PPTX 格式儲存簡報
p->Save(outPptxPath, SaveFormat::Pptx);
```

## **將 SVG 轉換為形狀集合**

Aspose.Slides 將 SVG 轉換為形狀集合的功能類似於 PowerPoint 用於處理 SVG 影像的功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection) 介面的 [AddGroupShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape_collection#a07def8851fe87a8f73a1621d2375d13b) 方法其中一個重載提供，該重載以 [ISvgImage](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_svg_image) 物件作為第一個參數。 

以下範例程式碼示範如何使用上述方法，將 SVG 檔案轉換為形狀集合：

``` cpp 
// 文件目錄的路徑
System::String dataDir = u"D:\\Documents\\";

// 來源 SVG 檔案名稱
System::String svgFileName = dataDir + u"sample.svg";

// 輸出簡報檔案名稱
System::String outPptxPath = dataDir + u"presentation.pptx";

// 建立新簡報
System::SharedPtr<IPresentation> presentation = System::MakeObject<Presentation>();

// 讀取 SVG 檔案內容
System::String svgContent = File::ReadAllText(svgFileName);

// 建立 SvgImage 物件
System::SharedPtr<ISvgImage> svgImage = System::MakeObject<SvgImage>(svgContent);

// 取得投影片尺寸
System::Drawing::SizeF slideSize = presentation->get_SlideSize()->get_Size();

// 將 SVG 影像轉換為形狀群組，並縮放至投影片大小
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// 以 PPTX 格式儲存簡報
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **將影像以 EMF 形式加入投影片**

Aspose.Slides for C++ 允許您從 Excel 工作表產生 EMF 影像，並使用 Aspose.Cells 將這些影像以 EMF 形式加入投影片中。 

以下範例程式碼示範如何執行上述任務：

``` cpp 
System::String dataDir = u"D:\\Documents\\";

StringPtr cellsXls = new String(dataDir.ToWCS().c_str());
cellsXls->Append(L"chart.xls");
intrusive_ptr<Aspose::Cells::IWorkbook> book = Aspose::Cells::Factory::CreateIWorkbook(cellsXls);

intrusive_ptr<Aspose::Cells::IWorksheet> sheet = book->GetIWorksheets()->GetObjectByIndex(0);
intrusive_ptr<Aspose::Cells::Rendering::IImageOrPrintOptions> options = Aspose::Cells::Factory::CreateIImageOrPrintOptions();
options->SetHorizontalResolution(200);
options->SetVerticalResolution(200);
options->SetImageFormat(Aspose::Cells::Systems::Drawing::Imaging::ImageFormat::GetEmf());

// 將工作簿儲存至串流
intrusive_ptr<Aspose::Cells::Rendering::ISheetRender> sr = Aspose::Cells::Factory::CreateISheetRender(sheet, options);

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

pres->get_Slides()->RemoveAt(0);

System::String EmfSheetName;
for (int32_t j = 0; j < sr->GetPageCount(); j++)
{
    EmfSheetName = dataDir + u"test" + System::String::FromWCS(sheet->GetName()->value()) + u" Page" + (j + 1) + u".out.emf";
    sr->ToImage(j, new String(EmfSheetName.ToWCS().c_str()));

    auto bytes = System::IO::File::ReadAllBytes(EmfSheetName);
    auto emfImage = pres->get_Images()->AddImage(bytes);

    System::SharedPtr<ISlide> slide = pres->get_Slides()->AddEmptySlide(pres->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = pres->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

pres->Save(dataDir + u"Saved.pptx", SaveFormat::Pptx);
```

## **取代影像集合中的影像**

Aspose.Slides 允許您取代儲存在簡報影像集合中的影像（包括投影片形狀使用的影像）。本節展示了更新集合中影像的多種方法。API 提供直接的方式，以原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 實例，或集合中已存在的其他影像來取代影像。 

請依照以下步驟執行：

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 類別載入包含影像的簡報檔案。  
1. 從檔案載入新影像至位元組陣列。  
1. 使用該位元組陣列將目標影像取代為新影像。  
1. 在第二種方法中，將影像載入 [IImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimage/) 物件，並以該物件取代目標影像。  
1. 在第三種方法中，使用簡報影像集合中已存在的影像取代目標影像。  
1. 將修改後的簡報寫入為 PPTX 檔案。  

```cpp
// 實例化代表簡報檔案的 Presentation 類別。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 第一種方式。
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 第二種方式。
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 第三種方式。
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// 將簡報儲存至檔案。
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆將文字動態化、從文字建立 GIF 等。 

{{% /alert %}}

## **常見問答**

**插入後原始影像解析度是否保持完整？**

是。會保留原始像素，但最終外觀取決於投影片上 [圖片](/slides/zh-hant/cpp/picture-frame/) 的縮放方式以及儲存時是否有套用壓縮。  

**一次性於多張投影片取代相同標誌的最佳方法是什麼？**

將標誌放置於母片或版面配置上，並在簡報的影像集合中取代它——更新會傳播到所有使用該資源的元素。  

**插入的 SVG 是否能轉換為可編輯的形狀？**

是。您可以將 SVG 轉換為形狀群組，之後各個部件即可使用標準形狀屬性進行編輯。  

**如何一次性為多張投影片設定圖片背景？**

[將影像指定為背景](/slides/zh-hant/cpp/presentation-background/) 放在母片或相關版面配置上——使用該母片/版面的投影片皆會繼承此背景。  

**如何防止因大量圖片導致簡報檔案尺寸「膨脹」？**

重複使用單一影像資源而非多個副本，選擇合理的解析度，儲存時使用壓縮，並在適當時將重複圖形放在母片上。