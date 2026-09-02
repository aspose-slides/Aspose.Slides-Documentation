---
title: 在 .NET 中優化簡報的圖像管理
linktitle: 管理圖像
type: docs
weight: 10
url: /zh-hant/net/image/
keywords:
- 新增圖像
- 新增圖片
- 取代圖像
- 圖像集合
- 圖片框
- 連結圖像
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- SVG 轉形狀
- 外部 SVG 資源
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 在 PowerPoint 與 OpenDocument 簡報中新增、重複使用、連結、取代與管理點陣圖與 SVG 圖像。"
---
## **簡介**

Aspose.Slides for .NET 提供多種處理圖像的方法，每種方法都有不同的用途。您可以將圖像儲存在簡報中、在圖片框中顯示、用作投影片背景、連結到外部圖像、取代共用圖像資源，或將 SVG 內容轉換為可編輯的形狀。

本文聚焦於圖像資源以及它們在整個簡報中的使用方式。關於對個別圖片框套用的裁切、透明度、效果、拉伸及其他格式設定，請參閱[圖片框](/slides/zh-hant/net/picture-frame/)。

## **了解圖像模型**

以下 API 概念密切相關，但不可互換：

- [簡報圖像集合](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/iimagecollection/) 儲存簡報使用的圖像資源。使用 [ImageCollection.AddImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/imagecollection/addimage/) 新增圖像資料並取得 [IPPImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/) 資源。
- [圖片框](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ipictureframe/) 是一個在投影片、版面配置或母片上顯示圖像的形狀。使用 [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ishapecollection/addpictureframe/) 在投影片上放置圖像資源。
- 投影片背景使用圖像作為投影片填充的一部分，而不是作為形狀。因此其行為不同於圖片框。
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/ippimage/replaceimage/) 取代圖像資源。如果多個簡報元素使用該資源，皆會使用已取代的圖像。
- 將 SVG 轉換為形狀會產生可編輯的投影片形狀。轉換後，內容不再作為單一圖片資源管理。

因此，一般的工作流程如下：將圖像資料新增至圖像集合，取得 IPPImage，然後在一個或多個圖片框或填充中使用該資源。

## **新增嵌入式圖像**

要插入本機圖像，先讀取檔案，將其資料新增至圖像集合，然後建立使用返回的 `IPPImage` 的圖片框。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

以此方式新增的圖像會嵌入至簡報中，因此產生的檔案不依賴原始圖像檔案的可用性。

### **從網路新增圖像**

當圖像可透過 HTTP 或 HTTPS 取得時，使用 `HttpClient` 下載其位元組，將其加入簡報圖像集合，並以與本機圖像相同的方式使用返回的圖像資源。

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

在長時間執行的應用程式中，請重複使用 `HttpClient`，而非為每個請求建立新實例。當來源不可信時，也要驗證遠端 URL、回應大小與內容類型。

## **在投影片間重複使用圖像**

如果同一圖像需要多次使用，只需在簡報中新增一次，並在建立其他圖片框時重複使用返回的 [IPPImage]。如此可避免重複載入相同來源資料，並明確展現共享圖像資源與其使用之間的關係。

對於應自動出現在多張投影片上的圖形（例如公司標誌），請考慮將圖片框放置於[投影片母片](/slides/zh-hant/net/slide-master/)或版面配置上，而不是在每張投影片中加入相同的形狀。

## **將圖像作為投影片背景**

背景圖像會指定給投影片填充，而不是以圖片框形狀加入。當圖像需要覆蓋整個投影片背景且不應被視為一般投影片物件進行操作時，此方式很有用。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

若需其他背景選項（包括母片與版面配置背景），請參閱[簡報背景](/slides/zh-hant/net/presentation-background/)。

## **嵌入式圖像與連結圖像**

嵌入式圖像與連結圖像在可移植性與檔案大小上有不同的取捨：

- **嵌入式圖像：** 圖像資料儲存在簡報內。簡報是自包含的，但檔案大小會包含圖像資料。
- **連結圖像：** 簡報僅儲存外部圖像的路徑或 URL。此方式可減少簡報大小，但在開啟或呈現簡報時，必須能存取外部資源。

可透過 [ISlidesPicture.LinkPathLong] 指定外部路徑或 URL，建立連結圖片，而非嵌入圖像資料。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

僅在部署環境能可靠存取外部資源時才使用連結圖像。對於必須離線使用或在系統間搬移的簡報，嵌入式圖像通常較安全。

## **處理 SVG 圖像**

SVG 是向量格式，可用於圖示、圖表及其他需要在放大縮小時仍保持細節的圖形。Aspose.Slides 同時支援將 SVG 作為圖像資源以及可編輯投影片形狀的來源。

### **將 SVG 新增為圖像**

建立 [SvgImage]，將其加入圖像集合，並將產生的圖像資源放入圖片框中。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **含外部資源的 SVG 檔案**

SVG 可以參照外部圖像、樣式表或字型。對於這類情況，[SvgImage] 提供接受 [IExternalResourceResolver] 與基礎 URI 的建構函式。解析器可將相對 URI 映射為允許的絕對 URI，並回傳請求資源的串流。

解析器在 Aspose.Slides 處理 SVG 時使外部資源可用，但不會將 SVG 重新寫成自包含的文件。若 SVG 必須保持可移植，請將所需資源直接嵌入 SVG，例如使用 `data:` URI 來連結圖像。

當 SVG 檔案來源不可信時，請限制解析器可存取的協議、檔案位置與主機。網路解析器亦應設定逾時、回應大小上限與內容驗證。

### **將 SVG 轉換為可編輯形狀**

Aspose.Slides 可以將 SVG 轉換為一組可編輯的投影片形狀，類似 PowerPoint 的對應指令。

![PowerPoint Popup Menu](img_01_01.png)

使用接受 [ISvgImage] 的 [IShapeCollection.AddGroupShape] 重載來執行轉換。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

當需要將個別向量元素編輯為 PowerPoint 形狀時，使用 SVG 轉形狀的轉換。如果 SVG 只需顯示，保留為圖像較為簡單，且可避免建立大量獨立形狀。

## **取代現有圖像資源**

當需要取代現有圖像資源時，使用 [IPPImage.ReplaceImage]。這對於共用圖形（例如標誌）特別有用。

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

如果多個圖片框、背景、母片或版面配置使用相同的圖像資源，取代該資源會更新所有使用處。若僅需更改單一圖片框，請為該框指派不同圖像，而非取代共享資源。

`ReplaceImage` 也提供接受 [IImage] 或其他 [IPPImage] 的重載。

## **實務圖像管理指引**

### **控制簡報大小**

大型點陣圖會使簡報過於龐大。請使用符合預期顯示尺寸的來源圖像，盡可能重複使用共享圖像資源，並避免嵌入相同全解析度圖形的多個副本。

對於已放入圖片框的點陣圖，可使用 [IPictureFillFormat.CompressImage] 根據選取的解析度與裁切設定壓縮圖像資料。這屬於圖片框處理而非圖像集合管理，相關格式操作請參閱[圖片框](/slides/zh-hant/net/picture-frame/)。

### **在嵌入與連結內容之間選擇**

嵌入可使簡報具可移植性，因為所有必要的圖像資料隨檔案一起攜帶。連結可減小檔案大小，但會產生外部依賴。僅在該依賴可接受且穩定時才使用連結。

### **重複使用共享品牌資源**

對於重複使用的標誌、水印或裝飾圖形，請使用單一圖像資源並重複使用。若圖形屬於簡報設計而非投影片內容，請將其放置於母片或版面配置，以便被相應投影片繼承。

### **保持 SVG 資源可移植**

自包含的 SVG 較易搬移且能一致渲染，較不依賴外部檔案或網路資源。盡可能在匯入 SVG 前嵌入必要資源。僅在需要編輯個別向量元素時才將 SVG 轉換為形狀。

### **使用現代跨平台圖像 API**

對於新的 .NET 程式碼，請使用 Aspose.Slides 的 [IImage] 與 [Images] API，而非依賴 `System.Drawing.Image` 或 `Bitmap`。遷移指引請參閱[現代 API](/slides/zh-hant/net/modern-api/)。

WMF 與 EMF 需要特別注意。當這些格式透過 [IImage] 傳遞時，[ImageCollection.AddImage] 會在插入前將中繼檔轉換為點陣 PNG 表示。若需保留中繼檔資料，請改用基於串流的 [ImageCollection.AddImage] 重載。從試算表或其他產品產生 EMF 內容屬於另一個整合工作流程，超出本文範圍。

## **常見問題**

**圖像集合與圖片框有何不同？**

圖像集合儲存可重複使用的圖像資源。圖片框則是投影片形狀，用於顯示其中一項資源，並提供裁切、效果等圖片專屬的格式設定。

**在所有位置取代相同標誌的最佳方法是什麼？**

如果標誌已作為單一圖像資源共享，請使用 [IPPImage.ReplaceImage] 取代該資源。若需全簡報的品牌統一，也可將標誌放置於母片或版面配置上，以減少投影片內容的重複。

**為什麼連結圖像在其他電腦上會消失？**

連結圖片依賴外部檔案或 URL。若其他電腦無法存取該資源，連結圖像就會失效。當簡報必須自包含時，請嵌入圖像。

**插入的 SVG 能否編輯為 PowerPoint 形狀？**

可以。使用 [IShapeCollection.AddGroupShape] 轉換 SVG；產生的群組包含可編輯的投影片形狀，而非單一 SVG 圖片。

**如何讓含有大量圖像的簡報保持較小尺寸？**

重複使用共享圖像資源、避免使用過大的點陣來源、在適當時壓縮相應的點陣圖、將重複的品牌圖放在母片或版面配置上，僅在外部依賴可接受時才使用連結圖像。