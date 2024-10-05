---
title: OLEアイコンにキャプションを設定する
type: docs
weight: 130
url: /java/set-caption-to-ole-icon/
---

新しいメソッド**getSubstitutePictureTitle**と**setSubstitutePictureTitle**が**IOleObjectFrame**インターフェイスおよび**OleObjectFrame**クラスに追加されました。これにより、OLEアイコンのキャプションを取得、設定、または変更することができます。以下のコードスニペットは、Excelオブジェクトを作成し、そのキャプションを設定するサンプルを示しています。

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// スライドにOLEオブジェクトを追加
byte[] allBytes = Files.readAllBytes(Paths.get("oleSourceFile.xlsx"));
OleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(allBytes, "xlsx");

IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(20, 20, 50, 50, dataInfo);

// プレゼンテーションの画像コレクションに画像を追加
IImage image = Images.fromFile("oleIconFile.ico");
IPPImage ppImage = presentation.getImages().addImage(image);
image.dispose();

// OLEオブジェクトのアイコンとして画像を設定
oleFrame.setObjectIcon(true);
oleFrame.getSubstitutePictureFormat().getPicture().setImage(ppImage);

// OLEアイコンにキャプションを設定
oleFrame.setSubstitutePictureTitle("キャプションの例");
```