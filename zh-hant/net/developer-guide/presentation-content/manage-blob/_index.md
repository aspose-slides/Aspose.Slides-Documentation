---
title: 在 .NET 中管理簡報 BLOB 以提高記憶體使用效率
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh-hant/net/manage-blob/
keywords:
- 大型物件
- 大型項目
- 大型檔案
- 新增 BLOB
- 匯出 BLOB
- 將影像作為 BLOB 新增
- 減少記憶體
- 記憶體消耗
- 大型簡報
- 暫存檔
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理 BLOB 資料，以簡化 PowerPoint 與 OpenDocument 檔案的操作，提升簡報處理的效率。"
---
## **概覽**

Aspose.Slides 提供基於 BLOB 的大型二進位資料處理，能在處理大型圖片、音訊、視訊及簡報檔案時減少記憶體消耗。

本文說明如何使用基於 BLOB 的處理方式將大型媒體加入簡報、從簡報匯出大型媒體，以及更有效率地載入大型簡報。也說明了在處理過程中如何使用暫存檔，以及如何變更用於儲存暫存檔的資料夾。

## **關於 BLOB**

**BLOB**（**Binary Large Object**）通常是以二進位格式儲存的大型項目（照片、簡報、文件或媒體）。

Aspose.Slides for .NET 允許您以降低記憶體消耗的方式，對大型檔案使用 BLOB 物件。

## **使用 BLOB 減少記憶體消耗**

### **透過 BLOB 將大型檔案加入簡報**

[Aspose.Slides](/slides/zh-hant/net/) for .NET 允許您透過涉及 BLOB 的流程加入大型檔案（此處為大型視訊檔），以減少記憶體消耗。

以下 C# 程式碼示範如何透過 BLOB 流程將大型視訊檔加入簡報：

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// 建立一個新的簡報，將在其中加入影片
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // 讓我們將影片加入簡報 - 我們選擇 KeepLocked 行為，因為我們會
        // 不打算存取 "veryLargeVideo.avi" 檔案。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // 儲存簡報。當輸出大型簡報時，記憶體消耗
        // 在整個 pres 物件的生命週期中保持低消耗
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **透過 BLOB 從簡報匯出大型檔案**

Aspose.Slides for .NET 允許您透過涉及 BLOB 的流程，從簡報匯出大型檔案（此處為音訊或視訊檔）。例如，您可能需要從簡報中擷取大型媒體檔案，但不想將其載入電腦記憶體。透過 BLOB 流程匯出檔案，可保持低記憶體消耗。

以下 C# 程式碼示範上述操作：

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// 鎖定來源檔案且不會將其載入記憶體
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// 建立 Presentation 實例，並鎖定 "hugePresentationWithAudiosAndVideos.pptx" 檔案。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 讓我們將每個影片儲存為檔案。為了防止記憶體使用過高，我們需要一個緩衝區來使用
	// 將簡報的影片串流資料傳輸至新建立的影片檔案的串流中。
	byte[] buffer = new byte[8 * 1024];

	// 遍歷所有影片
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// 開啟簡報的影片串流。請注意，我們刻意避免存取屬性
		// 如 video.BinaryData - 因為此屬性會回傳包含完整影片的位元組陣列，這會
		// 導致位元組被載入記憶體。我們使用 video.GetStream，該方法會回傳 Stream，而且不會
		//  需要我們將整段影片載入記憶體。
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// 無論影片或簡報的大小如何，記憶體消耗都會保持低水平，
	}

	// 如有需要，您可以對音訊檔使用相同的步驟。 
}
```

### **將影像作為 BLOB 加入簡報**

使用 [**IImageCollection**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection) 介面與 [**ImageCollection**](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imagecollection) 類別的方法，您可以將大型影像以串流方式加入，讓其被視為 BLOB。

以下 C# 程式碼示範如何透過 BLOB 流程加入大型影像：

```c#
string pathToLargeImage = "large_image.jpg";

// 建立一個新的簡報，將在其中加入影像。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 讓我們將影像加入簡報 - 我們選擇 KeepLocked 行為，因為我們會
		// 不打算存取 "largeImage.png" 檔案。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 儲存簡報。當輸出大型簡報時，記憶體消耗 
		// 在整個 pres 物件的生命週期中保持低消耗
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **記憶體與大型簡報**

一般而言，載入大型簡報時，電腦需要大量暫存記憶體。簡報的全部內容會被載入記憶體，而載入來源的檔案則不再被使用。

以包含 1.5 GB 視訊檔的大型 PowerPoint 簡報 (large.pptx) 為例。載入此簡報的標準方法如以下 C# 程式碼所示：

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

但是此方法會佔用約 1.6 GB 的暫存記憶體。

### **以 BLOB 載入大型簡報**

透過 BLOB 流程，您可在使用極少記憶體的情況下載入大型簡報。以下 C# 程式碼說明使用 BLOB 流程載入大型簡報檔案 (large.pptx) 的實作方式：

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **變更暫存檔資料夾**

使用 BLOB 流程時，電腦會在預設的暫存資料夾中建立暫存檔。如果想將暫存檔儲存在其他資料夾，可使用 `TempFilesRootPath` 變更儲存設定：

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 時，Aspose.Slides 不會自動建立暫存檔資料夾，必須自行手動建立。
{{% /alert %}}

### **釋放簡報物件以釋放記憶體**

處理大型簡報時，請確保正確釋放 [Presentation](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 實例，以釋放其佔用的記憶體。建議使用 `using` 陳述式或宣告（如上例所示）——在區塊結束時會自動釋放簡報並釋放非受控資源。

如果在未使用 `using` 區塊的情況下建立簡報，請在使用完畢後明確呼叫 `Dispose()`。

```cs
Presentation presentation = new Presentation("large.pptx");

// ...處理簡報...
presentation.Save("large.pdf", SaveFormat.Pdf);

// 明確釋放資源。
presentation.Dispose();
```

## **常見問題**

**在 Aspose.Slides 簡報中，哪些資料會被視為 BLOB 並受 BLOB 選項控制？**

大型二進位物件，如影像、音訊與視訊，會被視為 BLOB。整個簡報檔案在載入或儲存時也會涉及 BLOB 處理。這些物件受 BLOB 原則管控，讓您能管理記憶體使用量，並在需要時將資料寫入暫存檔。

**在載入簡報時，應於何處設定 BLOB 處理規則？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/blobmanagementoptions/)。在此可設定 BLOB 的記憶體上限、是否允許暫存檔、暫存檔根目錄路徑，以及來源鎖定行為。

**BLOB 設定會影響效能嗎？該如何在速度與記憶體之間取得平衡？**

會的。將 BLOB 保留於記憶體可獲得最高速度，但會增加 RAM 使用量；降低記憶體上限會將更多工作轉至暫存檔，減少 RAM 使用，但會增加 I/O。請調整 [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) 閾值，以在您的工作負載與環境中取得適當平衡。

**在開啟極大型簡報（例如數 GB）時，BLOB 選項有幫助嗎？**

會的。[BlobManagementOptions](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/blobmanagementoptions/) 正是為此類情境設計：啟用暫存檔與使用來源鎖定可顯著降低峰值 RAM 使用，並使處理極大型簡報更為穩定。

**在從串流而非磁碟檔載入時，是否也能使用 BLOB 原則？**

會的。相同的規則同樣適用於串流：簡報實例可以擁有並鎖定輸入串流（視所選的鎖定模式而定），且在允許的情況下會使用暫存檔，使處理過程中的記憶體使用保持可預測。