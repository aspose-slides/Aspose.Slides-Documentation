---
title: プレゼンテーション画像コレクション内の画像の置き換え
type: docs
weight: 110
url: /net/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for .NETを使用すると、スライドシェイプに追加された画像を置き換えることができます。この記事では、さまざまなアプローチを使用してプレゼンテーション画像コレクションに追加された画像を置き換える方法を説明します。

{{% /alert %}} 
## **プレゼンテーション画像コレクション内の画像の置き換え**
Aspose.Slides for .NETは、プレゼンテーション画像コレクション内の画像を置き換えるためのシンプルなAPIメソッドを提供します。以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスを使用して、画像を含むプレゼンテーションファイルをロードします。
1. バイト配列としてファイルから画像をロードします。
1. ターゲット画像を、新しい画像のバイト配列で置き換えます。
1. 2番目のアプローチでは、Imageオブジェクトに画像をロードし、ターゲット画像をロードした画像で置き換えます。
1. 3番目のアプローチでは、プレゼンテーション画像コレクションにすでに追加された画像で画像を置き換えます。
1. 変更されたプレゼンテーションをPPTXファイルとして書き込みます。

```c#
//プレゼンテーションをインスタンス化する
using Presentation presentation = new Presentation("presentation.pptx");

//最初の方法
byte[] data = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(data);

//2番目の方法
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

//3番目の方法
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

//プレゼンテーションを保存する
presentation.Save("c:\\Presentations\\TestSmart.pptx", SaveFormat.Pptx);
```