---
title: 在 C++ 中管理簡報 BLOB 以有效利用記憶體
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/cpp/manage-blob/
keywords:
- 大型物件
- 大型項目
- 大型檔案
- 加入 BLOB
- 匯出 BLOB
- 將影像加入為 BLOB
- 減少記憶體
- 記憶體消耗
- 大型簡報
- 暫存檔
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案操作，提升簡報處理效能。"
---
## **概觀**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，以減少處理大型影像、音訊、視訊及簡報檔案時的記憶體使用量。

本文件說明如何使用基於 BLOB 的處理方式將大型媒體加入簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。也會說明在處理過程中如何使用暫存檔，以及如何變更儲存暫存檔的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常指以二進位格式儲存的大型項目（相片、簡報、文件或媒體）。

Aspose.Slides for C++ 允許您以降低記憶體消耗的方式，對大型檔案使用 BLOB 物件。

## **使用 BLOB 減少記憶體消耗**

### **透過 BLOB 將大型檔案新增至簡報**

[Aspose.Slides](/slides/zh-hant/cpp/) for C++ 允許您透過 BLOB 流程將大型檔案（此處為大型視訊檔）加入簡報，以降低記憶體消耗。

以下 C++ 程式碼示範如何透過 BLOB 流程將大型視訊檔新增至簡報：

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// 建立一個將加入影片的新簡報
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// 我們將影片加入簡報 - 我們選擇 KeepLocked 行為因為我們
// 不打算存取 "veryLargeVideo.avi" 檔案。
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// 儲存簡報。當輸出大型簡報時，記憶體消耗
// 在 pres 物件的生命週期中保持低水平 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **透過 BLOB 從簡報匯出大型檔案**
Aspose.Slides for C++ 允許您透過 BLOB 流程從簡報匯出大型檔案（例如音訊或視訊檔）。例如，您可能需要從簡報中擷取大型媒體檔案，但不希望該檔案載入電腦記憶體。透過 BLOB 匯出可讓記憶體使用維持在低水平。

以下 C++ 程式碼示範此操作：

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// 建立 Presentation 實例，鎖定 "hugePresentationWithAudiosAndVideos.pptx" 檔案。

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 讓我們將每個影片儲存到檔案。為了防止高記憶體使用，我們需要一個
// 用於將簡報影片串流的資料傳輸到新建立的影片檔案串流的緩衝區。
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// Iterates through the videos
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// 開啟簡報的影片串流。請注意，我們刻意避免存取方法
	// 如 video->get_BinaryData - 因為此方法會回傳包含完整影片的位元組陣列，進而
	// 導致位元組被載入記憶體。我們使用 video->GetStream，會回傳 Stream - 且不會
	// 需要我們將整個影片載入記憶體。
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// 無論影片或簡報的大小，記憶體消耗都會保持低。
}

// 如有需要，您可以對音訊檔案套用相同的步驟。
```

### **將影像以 BLOB 形式加入簡報**
使用 [**IImageCollection**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_image_collection) 介面與 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.image_collection) 類別，您可以將大型影像以串流方式加入，讓其被視為 BLOB。

以下 C++ 程式碼示範如何透過 BLOB 流程加入大型影像：

```cpp
const String pathToLargeImage = u"large_image.jpg";

// 建立一個將加入影像的新簡報。
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// 我們將影像加入簡報 - 我們選擇 KeepLocked 行為因為我們
// 不打算存取 "largeImage.png" 檔案。
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// 儲存簡報。當輸出大型簡報時，記憶體消耗 
// 在 pres 物件的生命週期中保持低水平
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **記憶體與大型簡報**

一般而言，載入大型簡報時，電腦需要大量暫存記憶體。整個簡報的內容會被載入記憶體，且載入來源的檔案不再被使用。

以包含 1.5 GB 影片檔的大型 PowerPoint 簡報 (large.pptx) 為例，以下 C++ 程式碼示範標準載入方法：

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

此方法會消耗約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**

透過 BLOB 流程，您可以在使用極少記憶體的情況下載入大型簡報。以下 C++ 程式碼說明使用 BLOB 流程載入 large.pptx 的實作：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **變更暫存檔資料夾**

使用 BLOB 流程時，系統會在預設的暫存檔資料夾中建立暫存檔。如果想將暫存檔存放於其他資料夾，可透過 `TempFilesRootPath` 變更儲存設定：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 時，Aspose.Slides 不會自動建立暫存檔資料夾，您必須自行先建立該資料夾。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**

處理大型簡報時，務必正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。完成簡報操作後呼叫 `Dispose()`，即可釋放非受控資源。

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ... 處理簡報 ...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// 明確釋放資源。
presentation->Dispose();
```

## **常見問題**

**在 Aspose.Slides 簡報中，哪些資料會被視為 BLOB 並受 BLOB 選項控制？**

影像、音訊與視訊等大型二進位物件會被視為 BLOB。整份簡報檔在載入或儲存時也會涉及 BLOB 處理。這些物件受 BLOB 政策管理，讓您在需要時將資料寫入暫存檔以控制記憶體使用。

**如何在載入簡報時設定 BLOB 處理規則？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/blobmanagementoptions/)。在此您可以設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔根目錄路徑以及來源鎖定行為。

**BLOB 設定會影響效能嗎？要如何在速度與記憶體之間取得平衡？**

會影響。將 BLOB 完全保留於記憶體可提升速度，但會增加 RAM 使用；降低記憶體上限會將更多資料寫入暫存檔，降低 RAM 需求但會產生額外 I/O。使用 [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) 方法調整至適合您工作負載與環境的平衡點。

**在開啟極大型簡報（例如數 GB）時，BLOB 選項是否有幫助？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/blobmanagementoptions/) 為此類情境設計：啟用暫存檔與來源鎖定可大幅降低峰值 RAM 使用，並使極大型簡報的處理更為穩定。

**在從串流而非磁碟檔載入時，能否使用 BLOB 政策？**

能。相同的規則同樣適用於串流；簡報實例可根據所選的鎖定模式擁有並鎖定輸入串流，且在允許的情況下會使用暫存檔，確保處理期間的記憶體使用可預測。