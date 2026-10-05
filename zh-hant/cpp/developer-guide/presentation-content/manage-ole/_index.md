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
- 已連結物件
- 已連結檔案
- 變更 OLE
- OLE 圖示
- OLE 標題
- 抽取 OLE
- 抽取物件
- 抽取檔案
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "使用 Aspose.Slides for C++ 優化 PowerPoint 與 OpenDocument 檔案中的 OLE 物件管理。無縫地嵌入、更新和匯出 OLE 內容。"
---
## **簡介**

{{% alert color="info" title="Note" %}}
OLE（Object Linking & Embedding）是 Microsoft 的一項技術，可允許在一個應用程式中建立的資料和物件，透過連結或嵌入的方式放置於另一個應用程式中。 
{{% /alert %}} 

假設在 Microsoft Excel 中建立了一個圖表，然後將該圖表放入 PowerPoint 投影片中。該 Excel 圖表即被視為 OLE 物件。 

- OLE 物件可能以圖示的形式顯示。在此情況下，雙擊圖示會在其關聯的應用程式（Excel）中開啟圖表，或會要求您選擇用於開啟或編輯物件的應用程式。 
- OLE 物件也可能直接顯示其實際內容，例如圖表的內容。在此情況下，圖表在 PowerPoint 中被啟用，圖表介面載入，您可以在 PowerPoint 內修改圖表資料。

[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) 允許您將 OLE 物件插入投影片作為 OLE 物件框架（[OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)）。

## **將 OLE 物件框架新增至投影片**

假設您已在 Microsoft Excel 中建立了圖表，並想使用 Aspose.Slides for C++ 將其嵌入為投影片中的 OLE 物件框架，您可以按以下方式進行：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別的實例。
2. 透過索引取得投影片的參考。
3. 將 Excel 檔案讀取為位元組陣列。
4. 將 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 加入投影片，並提供位元組陣列及其他 OLE 物件資訊。
5. 將修改後的簡報寫入為 PPTX 檔案。

在以下範例中，我們使用 Aspose.Slides for C++ 將 Excel 檔案中的圖表新增為投影片上的 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)。 **注意**，[OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) 建構函式接受可嵌入物件的副檔名作為第二個參數。此副檔名讓 PowerPoint 能正確辨識檔案類型並選擇適當的應用程式開啟此 OLE 物件。

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

### **新增已連結 OLE 物件框架**

Aspose.Slides for C++ 允許您新增 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)，不嵌入資料，而僅以檔案的連結方式。  
以下 C++ 程式碼示範如何將帶有已連結 Excel 檔案的 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 新增至投影片：

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

// 新增一個連結至 Excel 檔案的 OLE 物件框架。
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **存取 OLE 物件框架**

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆找到或存取它：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別的實例，以載入含有嵌入 OLE 物件的簡報。
2. 使用索引取得投影片的參考。
3. 存取 [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 形狀。  
   在本範例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。我們接著將該物件 *型別轉換* 為 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)。這就是我們想要存取的 OLE 物件框架。
4. 存取 OLE 物件框架後，您即可對其執行任何操作。

以下範例示範如何存取 OLE 物件框架（嵌入於投影片中的 Excel 圖表物件）及其檔案資料。

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

    // 取得嵌入檔案資料。
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // 取得嵌入檔案的副檔名。
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **存取已連結 OLE 物件框架屬性**

Aspose.Slides 允許您存取已連結 OLE 物件框架的屬性。  
以下 C++ 程式碼示範如何檢查 OLE 物件是否已連結，並取得連結檔案的路徑：

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

    // 檢查 OLE 物件是否已連結。
    if (oleFrame->get_IsObjectLink())
    {
        // 列印連結檔案的完整路徑。
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // 若有，列印連結檔案的相對路徑。
        // 僅 PPT 簡報能包含相對路徑。
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **變更 OLE 物件資料**

{{% alert color="info" title="Note" %}}
在本節中，以下程式碼範例使用 [Aspose.Cells for C++](https://docs.aspose.com/cells/cpp/)。
{{% /alert %}}

如果投影片中已嵌入 OLE 物件，您可以透過以下方式輕鬆存取該物件並修改其資料：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別的實例，以載入含有嵌入 OLE 物件的簡報。  
2. 透過索引取得投影片的參考。  
3. 存取 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 形狀。  
   在本範例中，我們使用先前建立的 PPTX，該檔案在第一張投影片上僅有一個形狀。我們接著將該物件 *型別轉換* 為 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/)。這就是我們想要存取的 OLE 物件框架。  
4. 存取 OLE 物件框架後，您即可對其執行任何操作。  
5. 建立一個 `Workbook` 物件並存取 OLE 資料。  
6. 存取目標 `Worksheet` 並修改資料。  
7. 將更新後的 `Workbook` 儲存至串流中。  
8. 從串流變更 OLE 物件資料。

以下範例示範如何存取 OLE 物件框架（嵌入於投影片中的 Excel 圖表物件），並修改其檔案資料以更新圖表資料。

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

    // 修改工作簿資料。
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

    // 變更 OLE 框架物件資料。
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **在投影片中嵌入其他檔案類型**

除了 Excel 圖表外，Aspose.Slides for C++ 還允許您將其他類型的檔案嵌入投影片。例如，您可以將 HTML、PDF 與 ZIP 檔案插入為物件。當使用者雙擊插入的物件時，會自動在相關程式中開啟，或提示使用者選擇適當的程式來開啟它。  
以下 C++ 程式碼示範如何將 HTML 與 ZIP 嵌入投影片：

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

在處理簡報時，您可能需要將舊的 OLE 物件取代為新物件，或將不支援的 OLE 物件換成受支援的。Aspose.Slides for C++ 允許您設定嵌入物件的檔案類型，從而更新 OLE 框架資料或其副檔名。  
以下 C++ 程式碼示範如何將嵌入 OLE 物件的檔案類型設定為 `zip`：

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

## **設定嵌入物件的圖示影像與標題**

在嵌入 OLE 物件後，系統會自動新增由圖示影像組成的預覽。此預覽即是使用者在存取或開啟 OLE 物件前所看到的畫面。如果您想在預覽中使用特定的影像與文字作為元素，可使用 Aspose.Slides for C++ 設定圖示影像與標題。  
以下 C++ 程式碼示範如何為嵌入的物件設定圖示影像與標題：

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

## **防止 OLE 物件框架被重新調整大小和重新定位**

在投影片中新增已連結 OLE 物件後，若在 PowerPoint 中開啟簡報，可能會看到要求更新連結的訊息。點選「Update Links」按鈕可能會改變 OLE 物件框架的大小與位置，因為 PowerPoint 會從已連結的 OLE 物件更新資料並重新整理物件預覽。為避免 PowerPoint 提示更新物件資料，請以 `false` 呼叫 [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) 介面的 [set_UpdateAutomatic](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/set_updateautomatic/) 方法：

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

## **擷取嵌入檔案**

Aspose.Slides for C++ 允許您透過以下方式擷取投影片中作為 OLE 物件嵌入的檔案：

1. 建立一個包含欲擷取之 OLE 物件的 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 類別實例。  
2. 遍歷簡報中的所有形狀，並存取 [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) 形狀。  
3. 從 OLE 物件框架取得嵌入檔案的資料，並寫入磁碟。

以下 C++ 程式碼示範如何將投影片中嵌入的檔案以 OLE 物件形式擷取出來：

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

## **常見問題**

**匯出投影片為 PDF/影像時，會呈現 OLE 內容嗎？**  
投影片上可見的部分會被呈現——圖示/替代圖像（預覽）。在渲染過程中不會執行「即時」的 OLE 內容。如有需要，請自行設定預覽圖像，以確保匯出 PDF 後的外觀如預期。  
若要同時將嵌入檔案保留為 PDF 附件，請以 `true` 呼叫 [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/)。此選項預設為關閉。欲查閱範例與檢查附件的說明，請參考 [Preserve Embedded OLE Files as PDF Attachments](/slides/zh-hant/cpp/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments)。

**如何在投影片上鎖定 OLE 物件，使使用者無法在 PowerPoint 中移動或編輯它？**  
鎖定形狀：Aspose.Slides 提供 [shape-level locks](/slides/zh-hant/cpp/applying-protection-to-presentation/)。此方式並非加密，但能有效防止意外的編輯與移動。

**為何已連結的 Excel 物件在開啟簡報時會「跳動」或變更大小？**  
PowerPoint 可能會重新整理已連結 OLE 的預覽。為取得穩定的外觀，請遵循 [Working Solution for Worksheet Resizing](/slides/zh-hant/cpp/working-solution-for-worksheet-resizing/) 的做法——將框架調整至符合範圍，或將範圍縮放至固定框架，並設定適當的替代圖像。

**在 PPTX 格式中，已連結 OLE 物件的相對路徑會被保留嗎？**  
在 PPTX 中，沒有「相對路徑」資訊——僅保留完整路徑。相對路徑僅存在於較舊的 PPT 格式。為確保可攜性，建議使用可靠的絕對路徑、可存取的 URI，或直接嵌入。