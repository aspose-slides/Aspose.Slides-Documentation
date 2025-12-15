---
title: Android でのプレゼンテーションにおける SmartArt グラフィックの管理
linktitle: SmartArt グラフィック
type: docs
weight: 20
url: /ja/androidjava/manage-smartart-shape/
keywords:
- SmartArt オブジェクト
- SmartArt グラフィック
- SmartArt スタイル
- SmartArt カラー
- SmartArt の作成
- SmartArt の追加
- SmartArt の編集
- SmartArt の変更
- SmartArt へのアクセス
- SmartArt レイアウト タイプ
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔な Java コード例とパフォーマンス重視のガイダンスを提供します。"
---

## **SmartArt シェイプの作成**
Aspose.Slides for Android via Java は SmartArt シェイプを作成するための API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [SmartArt シェイプを追加](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)し、[LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType) を設定します。
1. 変更されたプレゼンテーションを PPTX ファイルとして保存します。
```java
// Presentation クラスをインスタンス化
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Smart Art シェイプを追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // プレゼンテーションを保存
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スライドに追加された SmartArt シェイプ**|

## **スライド上の SmartArt シェイプへのアクセス**
以下のコードは、プレゼンテーションスライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内のすべてのシェイプを走査し、それが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) シェイプかどうかを確認します。シェイプが SmartArt タイプの場合は、[**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) インスタンスに型キャストします。
```java
// 目的のプレゼンテーションを読み込む
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプが SmartArt タイプかどうかを確認
        if (shape instanceof ISmartArt)
        {
            // シェイプを SmartArt に型キャスト
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **特定の LayoutType を持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) シェイプにアクセスするのに役立ちます。SmartArt の LayoutType は読み取り専用で、[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) シェイプが追加されたときにのみ設定されるため、変更できないことに注意してください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
1. 特定の LayoutType を持つ SmartArt シェイプを確認し、必要な処理を実行します。
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプが SmartArt タイプかどうかを確認
        if (shape instanceof ISmartArt)
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt のレイアウトを確認
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt シェイプのスタイル変更**
この例では、任意の SmartArt シェイプのクイックスタイルを変更する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
1. 特定のスタイルを持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しいスタイルを設定します。
1. プレゼンテーションを保存します。
```java
// Presentation クラスをインスタンス化
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプかどうかを確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt スタイルを確認
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt スタイルを変更
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スタイルが変更された SmartArt シェイプ**|

## **SmartArt シェイプのカラー スタイル変更**
この例では、任意の SmartArt シェイプのカラー スタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラー スタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば選択したシェイプを SmartArt に型キャストします。
1. 特定のカラー スタイルを持つ SmartArt シェイプを検索します。
1. SmartArt シェイプに新しいカラー スタイルを設定します。
1. プレゼンテーションを保存します。
```java
// Presentation クラスをインスタンス化
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt タイプかどうかを確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt のカラータイプを確認
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt のカラータイプを変更
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // プレゼンテーションを保存
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**図: カラー スタイルが変更された SmartArt シェイプ**|

## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーション化できますか？**

はい。SmartArt はシェイプですので、他のシェイプと同様に、アニメーション API を使用して [standard animations](/slides/ja/androidjava/powerpoint-animation/)（入場、退出、強調、移動パス）を適用できます。

**スライド上の特定の SmartArt を内部 ID が分からない場合、どうやって見つけられますか？**

代替テキスト（AltText）を設定して使用し、その値でシェイプを検索します—これが対象シェイプを見つける推奨方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を他のシェイプ（画像、表など）とグループ化でき、その後 [グループを操作](/slides/ja/androidjava/group/) できます。

**特定の SmartArt の画像（プレビューやレポート用など）を取得するにはどうすればよいですか？**

シェイプのサムネイル/画像をエクスポートします。ライブラリは個々のシェイプを [render individual shapes](/slides/ja/androidjava/create-shape-thumbnails/) してラスターファイル（PNG/JPG/TIFF）に出力できます。

**プレゼンテーション全体を PDF に変換する際、SmartArt の外観は保持されますか？**

はい。レンダリングエンジンは [PDF export](/slides/ja/androidjava/convert-powerpoint-to-pdf/) において高忠実度を目指しており、さまざまな品質と互換性オプションが用意されています。