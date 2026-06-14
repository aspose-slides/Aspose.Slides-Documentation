---
title: Aspose.Slides for .NET 14.9.0 的公開 API 與向後不相容變更
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- 遷移
- 傳統程式碼
- 現代程式碼
- 傳統方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "檢視 Aspose.Slides for .NET 的公開 API 更新與重大變更，協助您順利遷移 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}}

此頁面列出所有[已新增](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)或[已移除](/slides/zh-hant/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/)的類別、方法、屬性等，以及隨 Aspose.Slides for .NET 14.9.0 API 引入的其他變更。

{{% /alert %}} 
## **公開 API 變更**
#### **已將 ICollection 與泛型 IEnumerable 介面繼承加入至 ISmartArtNodeCollection**
類別 Aspose.Slides.SmartArt.SmartArtNodeCollection（以及相關介面 Aspose.Slides.SmartArt.ISmartArtNodeCollection）繼承泛型介面 IEnumerable<ISmartArtNode> 與介面 ICollection。
#### **已新增 SmartArtLayoutType.Custom 列舉值**
Custom SmartArt 版面類型代表使用自訂範本的圖表。自訂圖表只能從簡報檔案載入，且無法透過 ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 方法建立。
#### **已新增 SmartArtShape 類別與 ISmartArtShape 介面**
Aspose.Slides.SmartArt.SmartArtShape 類別（以及其介面 Aspose.Slides.SmartArt.ISmartArtShape）提供對 SmartArt 圖表中個別形狀的存取。可使用 SmartArtShape 變更 FillFormat、LineFormat、加入超連結及其他操作。

{{% alert color="primary" %}} 

**注意**：SmartArtShape 不支援 IShape 屬性 RawFrame、Frame、Rotation、X、Y、Width、Height，若嘗試存取會拋出 System.NotSupportedException。

使用範例：

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **已新增 SmartArtShapeCollection 類別、ISmartArtShapeCollection 介面與 ISmartArtNode.Shapes 屬性**
Aspose.Slides.SmartArt.SmartArtShapeCollection 類別（以及其介面 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供對 SmartArt 圖表中個別形狀的存取。此集合包含與 SmartArtNode 相關聯的形狀。SmartArtNode.Shapes 屬性會回傳與該節點相關的所有形狀集合。

{{% alert color="primary" %}} 

**注意**：根據 SmartArtLayoutType，單一 SmartArtShape 可能在多個節點之間共享。

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **已新增 用於保留頁碼儲存投影片的方法**
已加入以下方法：

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

這些方法允許開發人員將指定的簡報投影片儲存為 PDF、XPS、TIFF、HTML 等格式。'slides' 陣列用於指定頁碼，起始值為 1。 Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);
int[] slides = new int[] { 2, 3, 5 }; //投影片位置陣列
presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **已新增 用於取代影像的 PPImage、IPPImage 方法**
新增以下方法：

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);
//第一種方法

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);
//第二種方法

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);
//第三種方法

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);
```