---
title: Java を使用してプレゼンテーションの画像フレームを管理する
linktitle: 画像フレーム
type: docs
weight: 10
url: /ja/java/picture-frame/
keywords:
- 画像フレーム
- 画像フレームの追加
- 画像フレームの作成
- 画像の追加
- 画像の作成
- 画像の抽出
- ラスタ画像
- ベクター画像
- 画像のトリミング
- トリミング領域
- StretchOff プロパティ
- 画像フレームの書式設定
- 画像フレームのプロパティ
- 相対スケール
- 画像効果
- アスペクト比
- 画像の透明度
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint と OpenDocument のプレゼンテーションに画像フレームを追加します。ワークフローを効率化し、スライドデザインを向上させましょう。"
---
## **はじめに**

画像フレームは画像を含む形状で、フレーム内の写真のようなものです。

画像フレームを使用してスライドに画像を追加できます。この方法では、画像フレームの書式設定を行うことで画像をフォーマットできます。

{{% alert  title="Tip" color="primary" %}} 

Aspose は無料コンバータ―、[JPEG から PowerPoint へ](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/ja/import/png-to-ppt) — を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

## **画像フレームの作成**

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。  
2. インデックスを使用してスライドの参照を取得します。  
3. プレゼンテーションオブジェクトに関連付けられた [IImagescollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) に画像を追加して [IPPImage]() オブジェクトを作成し、シェイプの塗りつぶしに使用します。  
4. 画像の幅と高さを指定します。  
5. 参照されたスライドに関連付けられたシェイプオブジェクトが提供する `AddPictureFrame` メソッドを使用して、画像の幅と高さに基づく [PictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/PictureFrame) を作成します。  
6. スライドに画像フレーム（画像を含む）を追加します。  
7. 変更されたプレゼンテーションを PPTX ファイルとして保存します。

この Java コードは画像フレームの作成方法を示しています：

```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成します
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得します
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Image クラスのインスタンスを作成します
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // 画像と同じ高さと幅で画像フレームを追加します
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // PPTX ファイルをディスクに保存します
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

画像フレームを使用すると、画像に基づいたプレゼンテーションスライドを迅速に作成できます。画像フレームと Aspose.Slides の保存オプションを組み合わせることで、入力/出力操作を操作して画像を別の形式に変換できます。次のページも参照してください: 変換 [image to JPG](https://products.aspose.com/slides/ja/java/conversion/image-to-jpg/); 変換 [JPG to image](https://products.aspose.com/slides/ja/java/conversion/jpg-to-image/); 変換 [JPG to PNG](https://products.aspose.com/slides/ja/java/con