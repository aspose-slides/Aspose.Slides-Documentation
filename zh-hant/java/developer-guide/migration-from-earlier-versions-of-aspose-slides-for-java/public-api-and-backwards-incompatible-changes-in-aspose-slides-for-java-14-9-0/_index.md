---
title: Aspose.Slides for Java 14.9.0 的公共 API 與向後不相容變更
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- 遷移
- 舊版程式碼
- 現代程式碼
- 舊版方法
- 現代方法
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "檢視 Aspose.Slides for Java 的公共 API 更新與重大變更，以順利遷移您的 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="primary" %}} 

此頁面列出所有 [已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) 類別、方法、屬性等，以及在 Aspose.Slides for Java 14.9.0 API 中引入的任何新限制和其他 [變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)。

{{% /alert %}} 
## **公共 API 變更**
### **已加入用於將圖像替換為 PPImage、IPPImage 的方法**
新增的方法如下：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//第一種方式

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//第二種方式

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **已加入保留頁碼的投影片儲存方法**
已加入以下方法：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

這些方法允許將指定的投影片儲存為 PDF、XPS、TIFF、HTML 等格式。'slides' 陣列可用於指定頁碼，起始值為 1。

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //投影片位置陣列

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **已加入 SmartArtLayoutType.Custom 列舉值**
此類型的 SmartArt 版面配置代表使用自訂範本的圖表。自訂圖表只能從投影片檔案載入，且無法透過方法 ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 建立。
### **已加入 SmartArtShape 類別與 ISmartArtShape 介面**
Aspose.Slides.SmartArt.SmartArtShape 類別（以及其介面 Aspose.Slides.SmartArt.ISmartArtShape）提供對 SmartArt 圖表內部個別形狀的存取。SmartArtShape 可用於變更 FillFormat、LineFormat、加入超連結等。

{{% alert color="primary" %}} 

SmartArtShape 不支援 IShape 屬性 RawFrame、Frame、Rotation、X、Y、Width、Height，且在嘗試存取時會拋出 System.NotSupportedException。

{{% /alert %}} 

使用範例：

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **已加入 SmartArtShapeCollection 類別、ISmartArtShapeCollection 介面與 ISmartArtNode.getShapes() 方法**
Aspose.Slides.SmartArt.SmartArtShapeCollection 類別（以及其介面 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供對 SmartArt 圖表內個別形狀的存取。此集合包含與 SmartArtNode 相關聯的形狀。屬性 SmartArtNode.Shapes 回傳該節點所關聯的所有形狀集合。

{{% alert color="primary" %}} 

根據 SmartArtLayoutType 的不同，一個 SmartArtShape 可能會被多個節點共享。

{{% /alert %}} 

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```