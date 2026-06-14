---
title: 使用 C++ 管理簡報中的 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/cpp/manage-ole/
keywords:
- OLE 物件
- 物件連結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增物件
- 嵌入物件
- 新增檔案
- 嵌入檔案
- 連結物件
- 連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 提取 OLE
- 提取物件
- 提取檔案
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 檔案中最佳化 OLE 物件管理。無縫嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert title="Info" color="info" %}}
OLE（Object Linking & Embedding）是微軟的一項技術，允許在一個應用程式中建立的資料與物件透過連結或嵌入方式放置到另一個應用程式中。
{{% /alert %}} 

考慮在 Microsoft Excel 中建立的圖表，該圖表被放入 PowerPoint 投影片中。此 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能以圖示形式顯示。此時雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選擇用於開啟或編輯物件的應用程式。  
- OLE 物件也可能直接顯示實際內容，例如圖表本身。此情況下圖表在 PowerPoint 中被啟動，圖表介面載入，您可以在 PowerPoint 內修改圖表資料。

[Aspose.Slides for C++](https://products.aspose.com/slides/zh-hant/cpp/) 允許您將 OLE 物件以 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/)）插入投影片中。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for C++ 以 OLE 物件框架方式嵌入投影片，可依照以下步驟進行：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實體。  
2. 透過索引取得投影片的參考。  
3. 以位元組陣列方式讀取 Excel 檔案。  
4. 將包含位元組陣列及 OLE 物件其他資訊的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 加入投影片。  
5. 將修改後的簡報寫入為 PPTX 檔案。

以下範例示範如何使用 Aspose.Slides for C++，將 Excel 檔案中的圖表以 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形式加入投影片。  
**Note**： [OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 建構子接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型，並選擇正確的應用程式開啟此 OLE 物件。

``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **新增連結的 OLE 物件框架**

Aspose.Slides for C++ 允許您在不嵌入資料、僅透過連結檔案的方式新增 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/)。

下列 C++ 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 加入投影片：

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 新增具連結 Excel 檔案的 OLE 物件框架。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **存取 OLE 物件框架**

如果投影片中已嵌入 OLE 物件，您可以使用以下方式輕鬆找到或存取它：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實體方式載入含有嵌入式 OLE 物件的簡報。  
2. 透過索引取得投影片的參考。  
3. 取得 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形狀。  
   在本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/)，即為欲存取的 OLE 物件框架。  
4. 取得 OLE 物件框架後，您即可對其執行任何操作。

以下範例示範如何存取 OLE 物件框架（嵌入於投影片的 Excel 圖表物件）及其檔案資料。

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 取得嵌入的檔案資料。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **存取連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取連結 OLE 物件框架的屬性。

以下 C++ 程式碼示範如何檢查 OLE 物件是否為連結狀態，並取得連結檔案的路徑：

```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 檢查 OLE 物件是否為連結。
    if (oleFrame->get_IsObjectLink())
    {
        // 輸出連結檔案的完整路徑。
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 如有則輸出連結檔案的相對路徑。
        // 僅 PPT 簡報可以包含相對路徑。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **變更 OLE 物件資料**

{{% alert color="primary" %}} 
在本節中，以下程式碼範例使用 [Aspose.Cells for C++](/cells/cpp/)。
{{% /alert %}}

如果投影片中已嵌入 OLE 物件，您可以依以下步驟輕鬆存取該物件並修改其資料：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實體方式載入含有嵌入式 OLE 物件的簡報。  
2. 透過索引取得投影片的參考。  
3. 取得 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形狀。  
   在本範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *cast* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/)，即為欲存取的 OLE 物件框架。  
4. 取得 OLE 物件框架後，您即可對其執行任何操作。  
5. 建立 `Workbook` 物件並存取 OLE 資料。  
6. 取得目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流。  
8. 從串流中變更 OLE 物件資料。

以下範例示範如何存取 OLE 物件框架（嵌入於投影片的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// 取得第一個形狀作為 OLE 物件框架。
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // 將 OLE 物件資料讀取為 Workbook 物件。
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // 修改 Workbook 資料。
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // 變更 OLE 框架的物件資料。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表，Aspose.Slides for C++ 亦允許您將其他類型的檔案嵌入投影片，例如 HTML、PDF 與 ZIP 檔。使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選擇適當的程式開啟。

以下 C++ 程式碼示範如何將 HTML 與 ZIP 檔嵌入投影片：

``` cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **設定嵌入式物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不受支援的 OLE 物件換成受支援的。Aspose.Slides for C++ 允許您為嵌入式物件設定檔案類型，從而更新 OLE 框架的資料或副檔名。

以下 C++ 程式碼示範如何將嵌入式 OLE 物件的檔案類型設定為 `zip`：

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// 將檔案類型變更為 ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **為嵌入式物件設定圖示影像與標題**

在嵌入 OLE 物件後，系統會自動加入包含圖示影像的預覽。此預覽即為使用者在存取或開啟 OLE 物件前所看到的畫面。若您想使用特定影像與文字作為預覽元素，可使用 Aspose.Slides for C++ 設定圖示影像與標題。

以下 C++ 程式碼示範如何為嵌入式物件設定圖示影像與標題：

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// 將影像新增至簡報的資源中。
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// 設定 OLE 預覽的標題與影像。
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **防止 OLE 物件框架被重新調整大小與重新定位**

將連結 OLE 物件加入簡報投影片後，於 PowerPoint 開啟簡報時可能會出現要求更新連結的訊息。點選「Update Links」按鈕會因 PowerPoint 從連結 OLE 物件更新資料並重新整理預覽，而導致 OLE 物件框架的大小與位置變更。若要阻止 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/) 介面的 `set_UpdateAutomatic` 方法設為 `false`：

```cpp
oleFrame->set_UpdateAutomatic(false);
```

## **擷取嵌入的檔案**

Aspose.Slides for C++ 允許您以以下方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別實體。  
2. 迭代簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 C++ 程式碼示範如何擷取投影片中作為 OLE 物件嵌入的檔案：

``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **常見問題**

**將 OLE 內容匯出為 PDF／影像時會被渲染嗎？**

投影片上可見的部分會被渲染——即圖示/替代影像（預覽）。「即時」的 OLE 內容在渲染過程中不會執行。若有需要，請自行設定預覽影像，以確保匯出 PDF 時的外觀符合預期。

**如何鎖定投影片上的 OLE 物件，使使用者在 PowerPoint 中無法移動或編輯？**

鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/cpp/applying-protection-to-presentation/)。這不是加密，但可有效防止意外編輯與移動。

**為何連結的 Excel 物件在開啟簡報時會「跳動」或尺寸改變？**

PowerPoint 可能會重新整理連結 OLE 的預覽。若需穩定外觀，請遵循 [Working Solution for Worksheet Resizing](/slides/zh-hant/cpp/working-solution-for-worksheet-resizing/) 的做法——要麼將框架調整至符合範圍，要麼將範圍縮放至固定框架並設定適當的替代影像。

**PPTX 格式會保留連結 OLE 物件的相對路徑嗎？**

在 PPTX 中不提供「相對路徑」資訊——僅儲存完整路徑。相對路徑僅存在於較舊的 PPT 格式。為提升可移植性，建議使用可靠的絕對路徑／可存取的 URI，或直接嵌入檔案。