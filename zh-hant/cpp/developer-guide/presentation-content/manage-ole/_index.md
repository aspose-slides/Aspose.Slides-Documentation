---
title: 使用 C++ 在簡報中管理 OLE
linktitle: 管理 OLE
type: docs
weight: 40
url: /zh-hant/cpp/manage-ole/
keywords:
- OLE 物件
- 物件鏈結與嵌入
- 新增 OLE
- 嵌入 OLE
- 新增 物件
- 嵌入 物件
- 新增 檔案
- 嵌入 檔案
- 連結 物件
- 連結 檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 提取 OLE
- 提取 物件
- 提取 檔案
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 優化 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新與匯出 OLE 內容。"
---
## **簡介**

{{% alert title="Info" color="info" %}}

OLE（Object Linking & Embedding）是 Microsoft 的一項技術，可讓在一個應用程式中建立的資料和物件透過連結或嵌入的方式放置在另一個應用程式中。

{{% /alert %}} 

想像在 MS Excel 中建立的圖表，之後將該圖表放入 PowerPoint 投影片中。這個 Excel 圖表即被視為 OLE 物件。

- OLE 物件可能會顯示為圖示。此時，當您雙擊圖示時，圖表會在其關聯的應用程式（Excel）中開啟，或系統會要求您選擇用於開啟或編輯物件的應用程式。
- OLE 物件也可以直接顯示實際內容，例如圖表本身。此時，圖表會在 PowerPoint 中被激活，圖表介面會載入，您可以在 PowerPoint 內修改圖表資料。

[Aspose.Slides for C++](https://products.aspose.com/slides/zh-hant/cpp/) 允許您將 OLE 物件作為 OLE 物件框（[OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/)）插入投影片。

## **將 OLE 物件框加入投影片**

假設您已在 Microsoft Excel 中建立圖表，並希望使用 Aspose.Slides for C++ 以 OLE 物件框的方式嵌入至投影片，您可以這樣做：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 透過索引取得投影片的參考。
3. 將 Excel 檔案讀取為位元組陣列。
4. 將包含位元組陣列與其他 OLE 物件資訊的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 新增至投影片。
5. 將修改後的簡報寫出為 PPTX 檔案。

在下方範例中，我們使用 Aspose.Slides for C++ 將來自 Excel 檔案的圖表新增為 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/)。

**注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 建構函式接受可嵌入物件副檔名作為第二個參數。此副檔名可讓 PowerPoint 正確辨識檔案類型，並選擇正確的應用程式開啟此 OLE 物件。

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

### **新增連結的 OLE 物件框**

Aspose.Slides for C++ 允許您新增一個 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) ，但不嵌入資料，只提供檔案的連結。

下列 C++ 程式碼示範如何將連結至 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 新增至投影片：

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// 新增一個連結至 Excel 檔案的 OLE 物件框。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **存取 OLE 物件框**

如果投影片中已嵌入 OLE 物件，您可以這樣輕鬆找出或存取它：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例方式載入含有嵌入 OLE 物件的簡報。
2. 透過索引取得投影片的參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形狀。  
   在我們的範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *轉型* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/)。這就是要存取的目標 OLE 物件框。
4. 取得 OLE 物件框之後，您可以對其執行任何操作。

下方範例示範如何存取嵌入於投影片中的 OLE 物件框（Excel 圖表物件）及其檔案資料。

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // 取得嵌入檔案的資料。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **存取連結 OLE 物件框屬性**

Aspose.Slides 讓您能夠存取連結 OLE 物件框的屬性。

下列 C++ 程式碼示範如何檢查 OLE 物件是否為連結，並取得連結檔案的路徑：

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

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

        // 若存在，輸出連結檔案的相對路徑。
        // 只有 PPT 簡報會包含相對路徑。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **變更 OLE 物件資料**

{{% alert color="info" %}} 

本節中的程式碼範例使用 [Aspose.Cells for C++](/cells/cpp/)。

{{% /alert %}}

如果投影片已嵌入 OLE 物件，您可以這樣輕鬆存取該物件並修改其資料：

1. 以建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例方式載入含有嵌入 OLE 物件的簡報。
2. 透過索引取得投影片的參考。 
3. 存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形狀。  
   在我們的範例中，我們使用先前建立的僅在第一張投影片上有一個形狀的 PPTX，然後將該物件 *轉型* 為 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/)。這就是要存取的目標 OLE 物件框。
4. 取得 OLE 物件框之後，您可以對其執行任何操作。
5. 建立 `Workbook` 物件並存取 OLE 資料。
6. 存取目標 `Worksheet` 並修改資料。
7. 將更新後的 `Workbook` 儲存至串流。
8. 從串流變更 OLE 物件資料。

下方範例示範如何存取嵌入於投影片中的 OLE 物件框（Excel 圖表物件），並修改其檔案資料以更新圖表資料。

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Aspose.Cells for C++ 必須在使用任何其類型之前啟動。
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
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

    // 變更 OLE 框物件資料。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for C++ 亦支援將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案作為物件插入。使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選擇適當的程式。

下列 C++ 程式碼示範如何將 HTML 與 ZIP 檔案嵌入投影片：

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

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

## **設定嵌入物件的檔案類型**

在處理簡報時，您可能需要將舊的 OLE 物件取代為新的，或將不受支援的 OLE 物件換成受支援的類型。Aspose.Slides for C++ 允許您設定嵌入物件的檔案類型，從而更新 OLE 框的資料或副檔名。

下列 C++ 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// Change the file type to ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **設定嵌入物件的圖示與標題**

嵌入 OLE 物件後，系統會自動加入一個由圖示圖片組成的預覽畫面，這是使用者在存取或開啟 OLE 物件之前所看到的。如果您想使用特定的圖片與文字作為預覽元素，可以透過 Aspose.Slides for C++ 設定圖示圖片與標題。

下列 C++ 程式碼示範如何為嵌入物件設定圖示圖片與標題：

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **防止 OLE 物件框被調整大小與重新定位**

當您將連結的 OLE 物件加入簡報投影片後，開啟 PowerPoint 時可能會出現要求「更新連結」的訊息。點選「更新連結」按鈕可能會因 PowerPoint 重新取得連結 OLE 物件的資料並刷新預覽，而導致 OLE 物件框的大小與位置發生變化。為避免 PowerPoint 提示更新物件資料，請將 [IOleObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ioleobjectframe/) 介面的 `set_UpdateAutomatic` 方法設為 `false`：

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **擷取嵌入的檔案**

Aspose.Slides for C++ 允許您以以下方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立一個包含欲擷取 OLE 物件之 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 逐一遍歷簡報中的所有形狀，存取 [OLEObjectFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/oleobjectframe/) 形狀。
3. 從 OLE 物件框取得嵌入檔案的資料，並寫入磁碟。

下列 C++ 程式碼示範如何將投影片中以 OLE 物件形式嵌入的檔案擷取出來：

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

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

## **常見問題集**

### 在將投影片匯出為 PDF／影像時，OLE 內容會被渲染嗎？

投影片上可見的部分會被渲染——即圖示/替代圖片（預覽）。「即時」的 OLE 內容在渲染過程中不會被執行。如有需要，請自行設定預覽圖片，以確保匯出 PDF 時呈現預期外觀。

### 如何將投影片上的 OLE 物件鎖定，避免使用者在 PowerPoint 中移動或編輯？

鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/cpp/applying-protection-to-presentation/)。這不是加密，但可有效防止意外的編輯與移動。

### 為何在開啟簡報時，連結的 Excel 物件會「跳動」或變更大小？

PowerPoint 可能會重新整理連結 OLE 的預覽。若需穩定外觀，請遵循 [Worksheet Resizing 的工作解決方案](/slides/zh-hant/cpp/working-solution-for-worksheet-resizing/)，例如將框架調整至範圍大小，或將範圍縮放至固定框架並設定適當的替代圖片。

### PPTX 格式中是否會保留連結 OLE 物件的相對路徑？

在 PPTX 中不會存放「相對路徑」資訊——僅有完整路徑。相對路徑僅出現在較舊的 PPT 格式。為提升可攜性，建議使用可靠的絕對路徑或可存取的 URI，或改採嵌入方式。