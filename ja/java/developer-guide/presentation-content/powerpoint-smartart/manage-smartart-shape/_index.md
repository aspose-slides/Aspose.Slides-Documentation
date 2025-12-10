---
title: Java を使用したプレゼンテーションの SmartArt グラフィックの管理
linktitle: SmartArt グラフィック
type: docs
weight: 20
url: /ja/java/manage-smartart-shape/
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
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java で PowerPoint の SmartArt の作成、編集、スタイリングを自動化し、簡潔なコード例とパフォーマンス重視のガイダンスを提供します。"
---

## **SmartArt シェイプの作成**
Aspose.Slides for Java は SmartArt シェイプを作成するための API を提供しています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [Add a SmartArt shape](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) にて [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType) を設定します。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。
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
以下のコードは、プレゼンテーション スライドに追加された SmartArt シェイプにアクセスするために使用します。サンプルコードでは、スライド内のすべてのシェイプを走査し、[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) シェイプかどうかをチェックします。シェイプが SmartArt タイプであれば、[**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) インスタンスに型変換します。
```java
// 必要なプレゼンテーションを読み込む
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプが SmartArt タイプかどうかを確認
        if (shape instanceof ISmartArt)
        {
            // シェイプを SmartArtEx に型変換
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **特定の Layout Type を持つ SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) シェイプにアクセスするのに役立ちます。SmartArt の LayoutType は読み取り専用であり、SmartArt シェイプが追加されたときにのみ設定されるため、変更できないことに注意してください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば型変換します。
1. 特定の LayoutType を持つ SmartArt シェイプを確認し、その後に必要な処理を実行します。
```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプを走査
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプが SmartArt タイプかどうかを確認
        if (shape instanceof ISmartArt)
        {
            // シェイプを SmartArtEx に型変換
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt のレイアウトをチェック
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

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば型変換します。
1. 特定のスタイルを持つ SmartArt シェイプを見つけます。
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
            // シェイプを SmartArtEx に型変換
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt のスタイルをチェック
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt のスタイルを変更
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

## **SmartArt シェイプのカラースタイル変更**
この例では、任意の SmartArt シェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードは、特定のカラースタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプを走査します。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) タイプかどうかを確認し、SmartArt であれば型変換します。
1. 特定のカラースタイルを持つ SmartArt シェイプを見つけます。
1. SmartArt シェイプに新しいカラースタイルを設定します。
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
            // シェイプを SmartArtEx に型変換
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt のカラータイプをチェック
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
|**図: カラースタイルが変更された SmartArt シェイプ**|

## **FAQ**

**SmartArt を単一オブジェクトとしてアニメーションさせることはできますか？**

はい。SmartArt はシェイプなので、他のシェイプと同様にアニメーション API を使用して[標準アニメーション](/slides/ja/java/powerpoint-animation/)（出入り、強調、モーション パス）を適用できます。

**内部 ID がわからない場合、スライド上の特定の SmartArt をどうやって見つけますか？**

代替テキスト（AltText）を設定し、その値でシェイプを検索します。これが推奨される方法です。

**SmartArt を他のシェイプとグループ化できますか？**

はい。SmartArt を画像や表などの他のシェイプとグループ化し、[グループを操作](/slides/ja/java/group/)できます。

**特定の SmartArt の画像（プレビューやレポート用）を取得するには？**

シェイプのサムネイル/画像をエクスポートできます。ライブラリは個々のシェイプを[ラスターファイル (PNG/JPG/TIFF) にレンダリング](/slides/ja/java/create-shape-thumbnails/)できます。

**プレゼンテーション全体を PDF に変換したとき、SmartArt の外観は保持されますか？**

はい。レンダリングエンジンは[PDF エクスポート](/slides/ja/java/convert-powerpoint-to-pdf/)で高忠実度を目指しており、品質や互換性のオプションが用意されています。