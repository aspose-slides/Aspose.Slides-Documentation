---
title: Aspose.Slides for Java 14.9.0 的公共 API 及向後不相容變更
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
description: "檢視 Aspose.Slides for Java 的公共 API 更新與破壞性變更，協助您順利遷移 PowerPoint PPT、PPTX 與 ODP 簡報解決方案。"
---
{{% alert color="info" %}} 
此頁面列出所有[已新增](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)的類別、方法、屬性等，以及隨 Aspose.Slides for Java 14.9.0 API 引入的任何新限制和其他[變更](/slides/zh-hant/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)。
{{% /alert %}} 
## **公共 API 變更**
### **已新增將圖像替換為 PPImage、IPPImage的方法**
已新增以下方法：

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // 第一種方式
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // 第二種方式
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **已新增保持頁碼保存投影片的方法**
已新增以下方法：

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

這些方法允許將指定的簡報投影片儲存為 PDF、XPS、TIFF、HTML 格式。'slides' 陣列可用於指定頁碼，起始值為 1。

``` java
// 已新增至 IPresentation 的多載（SaveFormat 值在 Java 中為 int 常數）:
// 
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // 投影片位置的陣列

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **已新增 SmartArtLayoutType.Custom 列舉值**
此類型的 SmartArt 版面配置代表具有自訂範本的圖表。自訂圖表只能從簡報檔載入，且無法透過 ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 方法建立。
### **已新增 SmartArtShape 類別與 ISmartArtShape 介面**
Aspose.Slides.SmartArt.SmartArtShape 類別（以及其介面 Aspose.Slides.SmartArt.ISmartArtShape）提供對 SmartArt 圖表中個別圖形的存取。SmartArtShape 可用於變更 FillFormat、LineFormat、加入超連結等。

{{% alert color="info" %}} 
SmartArtShape 不支援 IShape 的屬性 RawFrame、Frame、Rotation、X、Y、Width、Height，且在嘗試存取時會拋出 System.NotSupportedException。
{{% /alert %}} 

使用範例：

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **已新增 SmartArtShapeCollection 類別、ISmartArtShapeCollection 介面與 ISmartArtNode.getShapes() 方法**
Aspose.Slides.SmartArt.SmartArtShapeCollection 類別（以及其介面 Aspose.Slides.SmartArt.ISmartArtShapeCollection）提供對 SmartArt 圖表中個別 **圖形** 的存取。此集合包含與 SmartArtNode 相關聯的 **圖形**。屬性 SmartArtNode.Shapes 會回傳與該節點相關的所有圖形集合。

{{% alert color="info" %}} 
根據 SmartArtLayoutType，單一 SmartArtShape 可能會在多個節點之間共享。
{{% /alert %}} 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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