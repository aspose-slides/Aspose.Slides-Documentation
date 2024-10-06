---
title: プレゼンテーション画像コレクション内の画像の置き換え
type: docs
weight: 80
url: /ja/java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for Javaはスライドシェイプ内の画像を置き換えることを可能にします。この記事では、さまざまなアプローチを使用してプレゼンテーション画像コレクションに追加された画像を置き換える方法について説明します。

{{% /alert %}} 
## **プレゼンテーション画像コレクション内の画像の置き換え**
Aspose.Slides for Javaは、プレゼンテーション画像コレクション内の画像を置き換えるためのシンプルなAPIメソッドを提供します。以下の手順に従ってください。

1. Presentationクラスを使用して画像を含むプレゼンテーションファイルを読み込みます。
1. バイト配列からファイルの画像を読み込みます。
1. 対象の画像を新しいバイト配列の画像に置き換えます。
1. 2番目のアプローチでは、画像をImageオブジェクトに読み込み、対象の画像を読み込んだ画像に置き換えます。
1. 3番目のアプローチでは、プレゼンテーション画像コレクションにすでに追加された画像で画像を置き換えます。
1. 修正されたプレゼンテーションをPPTXファイルとして保存します。

```java
//プレゼンテーションをインスタンス化
Presentation presentation = new Presentation("presentation.pptx");

//最初の方法
byte[] data = Files.readAllBytes(Paths.get("image0.jpeg"));
IPPImage oldImage = presentation.getImages().get_Item(0);
oldImage.replaceImage(data);

//2番目の方法
IImage newImage = Images.fromFile("image1.png");
oldImage = presentation.getImages().get_Item(1);
oldImage.replaceImage(newImage);
newImage.dispose();

//3番目の方法
oldImage = presentation.getImages().get_Item(2);
oldImage.replaceImage(presentation.getImages().get_Item(3));

//プレゼンテーションを保存
presentation.save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
presentation.dispose();
```