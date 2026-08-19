---
title: 使用 C++ 優化簡報中的影像管理
linktitle: 管理影像
type: docs
weight: 10
url: /zh-hant/cpp/image/
keywords:
- 新增影像
- 新增圖片
- 取代影像
- 影像集合
- 圖片框
- 連結影像
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- SVG 轉形狀
- 外部 SVG 資源
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 在 PowerPoint 與 OpenDocument 簡報中新增、重複使用、連結、取代與管理點陣圖與 SVG 影像。"
---
## **簡介**

Aspose.Slides for C++ 提供多種處理圖片的方式，且每種方式都有其特定用途。您可以將圖片儲存在簡報中、在圖片框中顯示、作為投影片背景、連結至外部圖片、取代共享圖片資源，或將 SVG 內容轉換為可編輯的形狀。

本文著重於圖片資源以及它們在簡報中的使用方式。若要了解裁切、透明度、效果、拉伸以及套用於單一圖片框的其他格式設定，請參閱[Picture Frame](/slides/zh-hant/cpp/picture-frame/)。

## **了解影像模型**

以下 API 概念密切相關，但並不互換：

- [簡報影像集合](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimagecollection/) 儲存簡報使用的圖片資源。使用[IImageCollection::AddImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimagecollection/addimage/) 可新增圖片資料並取得[IPPImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/)資源。
- [圖片框](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipictureframe/) 是在投影片、版面配置或母片上顯示圖片的形狀。使用[IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addpictureframe/) 可將圖片資源放置於投影片上。
- 投影片背景使用圖片作為投影片填色的一部分，而非形狀。因而它的行為不同於圖片框。
- [IPPImage::ReplaceImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ippimage/replaceimage/) 可取代圖片資源。若多個簡報元素使用該資源，全部都會使用新的圖片。
- 將 SVG 轉換為形狀會產生可編輯的投影片形狀。轉換後，內容不再作為單一圖片資源來管理。

因此，一般的工作流程為：將圖片資料新增至影像集合，取得[IPPImage]，然後在一或多個圖片框或填色中使用該資源。

## **新增嵌入式圖片**

要插入本機圖片，先讀取檔案，將其資料新增至影像集合，並建立使用回傳的[IPPImage]資源的圖片框。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

以此方式加入的圖片會嵌入於簡報中，故產生的檔案不會依賴原始圖片檔仍然可用。

### **從網路新增圖片**

當圖片可透過 HTTP 或 HTTPS 取得時，下載其位元組、將其加入簡報影像集合，並以與本機圖片相同的方式使用回傳的圖片資源。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Net;

auto imageUri = MakeObject<Uri>(u"https://example.com/image.png");
auto webClient = MakeObject<WebClient>();
auto imageData = webClient->DownloadData(imageUri);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(imageData);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, image);

presentation->Save(u"presentation-from-web.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

在來源不受信任時，請驗證遠端 URL、回應大小與內容類型。若您的應用程式已使用其他 HTTP 用戶端，也可以使用該用戶端下載圖片，然後將取得的位元組或串流傳遞給[IImageCollection::AddImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iimagecollection/addimage/)。

## **在投影片間重複使用圖片**

如果同一張圖片需要多次使用，只需在簡報中加入一次，然後在建立其他圖片框時重複使用回傳的[IPPImage]。這樣可避免重複載入相同來源資料，並讓共享圖片資源與其使用關係更加明確。

對於應自動出現在許多投影片上的圖形（例如公司標誌），建議將圖片框放在[slide master](/slides/zh-hant/cpp/slide-master/)或版面配置上，而不是在每張投影片中各新增等效形狀。

## **將圖片作為投影片背景**

背景圖片是指派給投影片填色的，並非以圖片框形狀加入。當圖片需要覆蓋整個投影片背景且不應被視為普通投影片物件操作時，這種方式非常有用。

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"background.jpg");
auto image = presentation->get_Images()->AddImage(imageData);

slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);

presentation->Save(u"background-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

更多背景選項（含母片與版面配置背景），請參閱[Presentation Background](/slides/zh-hant/cpp/presentation-background/)。

## **嵌入式圖片與連結圖片**

嵌入式圖片與連結圖片在可攜性與檔案大小上各有取捨：

- **嵌入式圖片**：圖片資料儲存在簡報內。簡報是自包含的，但檔案大小會包含圖片資料。
- **連結圖片**：簡報僅儲存指向外部圖片的路徑或 URL。這可以減少簡報大小，但在開啟或渲染簡報時必須能存取該外部資源。

可透過[ISlidesPicture::set_LinkPathLong](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/islidespicture/set_linkpathlong/) 指定外部路徑或 URL，建立連結圖片，而非嵌入圖片資料。

```cpp
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 320.0f, 180.0f, nullptr);
pictureFrame->get_PictureFormat()->get_Picture()->set_LinkPathLong(u"https://example.com/image.png");

presentation->Save(u"linked-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

僅在部署環境能可靠存取外部資源時才使用連結圖片。對於必須離線使用或在系統之間搬移的簡報，嵌入式圖片通常較安全。

## **處理 SVG 圖片**

SVG 為向量格式，適合用於圖示、圖表與其他需要在放大縮小時仍保有細節的圖形。Aspose.Slides 同時支援將 SVG 當作圖片資源以及作為可編輯投影片形狀的來源。

### **將 SVG 作為圖片新增**

建立[SvgImage]，將其加入影像集合，然後在圖片框中放置得到的圖片資源。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"icon.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto image = presentation->get_Images()->AddImage(svgImage);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 200.0f, image);

presentation->Save(u"svg-image.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **含外部資源的 SVG 檔案**

SVG 可以參照外部圖片、樣式表或字型。對於此類情況，[SvgImage] 提供接受[IExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.import/iexternalresourceresolver/) 與基礎 URI 的建構函式。解析器可將相對 URI 對映至允許的絕對 URI，並回傳所請求資源的串流。

解析器會在 Aspose.Slides 處理 SVG 時提供外部資源，但不會將 SVG 重寫為自包含文件。若 SVG 必須保持可攜，請將所需資源嵌入 SVG 本身，例如使用 `data:` URI 連結圖片。

當 SVG 檔案來自不受信任的來源時，應限制解析器可存取的協定、檔案位置與主機。網路解析器亦應套用逾時、回應大小上限與內容驗證。

### **將 SVG 轉換為可編輯形狀**

Aspose.Slides 可將 SVG 轉換為一組可編輯的投影片形狀，類似 PowerPoint 對應的指令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受[ISvgImage]的[IShapeCollection::AddGroupShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/addgroupshape/) 重載來執行轉換。

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto svgContent = File::ReadAllText(u"diagram.svg");
auto svgImage = MakeObject<SvgImage>(svgContent);

auto presentation = MakeObject<Presentation>();

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddGroupShape(svgImage, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height());

presentation->Save(u"editable-svg-shapes.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

當需要將個別向量元素編輯為 PowerPoint 形狀時，使用 SVG 轉形狀的方式。若 SVG 只需顯示，保留為圖片較為簡單，且可避免產生許多獨立形狀。

## **取代現有圖片資源**

當需要取代現有圖片資源時，請使用[IPPImage::ReplaceImage]。此功能特別適合取代共享圖形（例如標誌）。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"input.pptx");

auto imageToReplace = presentation->get_Image(0);
auto imageData = File::ReadAllBytes(u"new-logo.png");
imageToReplace->ReplaceImage(imageData);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若多個圖片框、背景、母片或版面配置使用同一圖片資源，取代該資源會同步更新所有使用處。若僅要變更單一圖片框，請為該框指定不同的圖片，而非取代共享資源。

[IPPImage::ReplaceImage] 亦提供接受[IImage]或其他[IPPImage]的重載。

## **實務圖片管理指引**

### **控制簡報大小**

大量點陣圖會使簡報體積過大。請使用符合實際顯示尺寸的來源圖片、盡可能重複利用共享圖片資源，並避免嵌入多份相同的高解析度圖檔。

對於已放入圖片框的點陣圖，可使用[IPictureFillFormat::CompressImage](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipicturefillformat/compressimage/) 依選取的解析度與裁切設定壓縮圖像資料。這屬於圖片框的處理而非影像集合管理，相關格式操作請參閱[Picture Frame](/slides/zh-hant/cpp/picture-frame/)。

### **在嵌入與連結內容之間選擇**

嵌入使簡報具備可攜性，因為所有必要的圖片資料都隨檔案一起搬移。連結可減少檔案大小，但會產生外部依賴。僅在該依賴可接受且穩定時才使用連結。

### **重複使用共享品牌資源**

對於重複出現的標誌、浮水印或裝飾圖形，請使用單一圖片資源並重複使用。若圖形屬於簡報設計而非投影片內容，建議將其放在母片或版面配置上，以便被相應投影片繼承。

### **保持 SVG 資源可攜**

自包含的 SVG 較易搬移且渲染一致，避免依賴外部檔案或網路資源。若可能，請在匯入前將所需資源嵌入 SVG。僅在需要編輯個別向量元素時才將 SVG 轉為形狀。

### **使用 Aspose.Slides 影像 API**

對於 C++ 影像工作流程，當需要影像物件時，請使用 Aspose.Slides 的[IImage]與[Images] API；當需要將影像資料註冊為簡報資源時，請使用[IImageCollection::AddImage]。集合的重載同樣支援位元組陣列與串流，這在影像資料來源於檔案、網路客戶端、資料庫或其他函式庫時相當便利。

從試算表或其他產品產生 EMF 內容屬於獨立的整合工作流程，本文不予討論。若已有 WMF 或 EMF 檔案僅需插入簡報，請將其資料傳遞給適當的[IImageCollection::AddImage]重載，而不必為影像管理流程額外加入第二個產品的相依性。

## **常見問答**

**圖片集合與圖片框有何差異？**  
圖片集合儲存可重複使用的圖片資源。圖片框是投影片形狀，用於顯示其中一項資源，並提供裁切、特效等圖片專屬格式設定。

**如何一次替換所有相同的標誌？**  
若標誌已作為單一圖片資源共享，使用[IPPImage::ReplaceImage]取代該資源即可。若需全簡報品牌統一，也可將標誌放在母片或版面配置上，以減少重複內容。

**為何連結圖片在其他電腦上會消失？**  
連結圖片依賴外部檔案或 URL。若該資源在其他電腦上無法存取，連結圖片便無法顯示。需要自包含的簡報時，請嵌入圖片。

**插入的 SVG 能否編輯為 PowerPoint 形狀？**  
可以。使用[IShapeCollection::AddGroupShape]將 SVG 轉換為可編輯的投影片形狀，轉換後的群組包含可編輯的形狀，而非單一 SVG 圖片。

**如何讓大量圖片的簡報保持較小體積？**  
重複使用共享圖片資源、避免使用過大的點陣圖來源、在適當時壓縮點陣圖、將重複的品牌圖形放在母片或版面配置上，且僅在外部依賴可接受時才使用連結圖片。