---
title: Aspose.Slides for Java 14.9.0 の公開 API と下位互換性のない変更
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- 移行
- レガシーコード
- モダンコード
- レガシーアプローチ
- モダンアプローチ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のパブリック API の更新と破壊的変更を確認し、PowerPoint の PPT、PPTX、ODP プレゼンテーション ソリューションを円滑に移行できるようにします。"
---
{{% alert color="info" %}}

このページでは、Aspose.Slides for Java 14.9.0 APIで導入された、すべての[追加された](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) クラス、メソッド、プロパティなど、新しい制限やその他の[変更](/slides/ja/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) を一覧表示します。

{{% /alert %}}
## **Public API Changes**
### **Added Methods for Replacing Image to PPImage, IPPImage**
新しく追加されたメソッド:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // 最初の方法
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // 二番目の方法
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Added Methods for Saving Slides Keeping Page Numbers**
以下のメソッドが追加されました:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

これらのメソッドにより、指定したプレゼンテーションスライドを PDF、XPS、TIFF、HTML 形式で保存できます。`slides` 配列は 1 から始まるページ番号を指定するために使用します。

``` java
// IPresentation に追加されたオーバーロード（SaveFormat の値は Java の int 定数です）:
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
    int[] slides = new int[] { 2, 3, 5 }; // スライド位置の配列

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Added the SmartArtLayoutType.Custom Enum Value**
この SmartArt レイアウトタイプはカスタムテンプレートの図を表します。カスタム図はプレゼンテーションファイルからのみ読み込むことができ、`ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)` メソッドでは作成できません。
### **Added the SmartArtShape Class and ISmartArtShape Interface**
`Aspose.Slides.SmartArt.SmartArtShape` クラス（およびそのインターフェイス `Aspose.Slides.SmartArt.ISmartArtShape`）は SmartArt 図内の個々の形状へのアクセスを提供します。`SmartArtShape` は FillFormat、LineFormat の変更やハイパーリンクの追加などに使用できます。

{{% alert color="info" %}}

`SmartArtShape` は IShape のプロパティ RawFrame、Frame、Rotation、X、Y、Width、Height をサポートしておらず、これらにアクセスしようとすると `System.NotSupportedException` がスローされます。

{{% /alert %}}

使用例:

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
### **SmartArtShapeCollection class, ISmartArtShapeCollection interface and ISmartArtNode.getShapes() method have been added**
`Aspose.Slides.SmartArt.SmartArtShapeCollection` クラス（およびそのインターフェイス `Aspose.Slides.SmartArt.ISmartArtShapeCollection`）は SmartArt 図内の個々の形状へのアクセスを提供します。コレクションには `SmartArtNode` に関連付けられた形状が含まれます。`SmartArtNode.Shapes` プロパティはそのノードに関連付けられたすべての形状のコレクションを返します。

{{% alert color="info" %}}

`SmartArtLayoutType` によっては、1 つの `SmartArtShape` が複数のノード間で共有されることがあります。

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