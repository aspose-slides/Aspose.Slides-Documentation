---
title: スマートアートシェイプの管理
type: docs
weight: 20
url: /ja/androidjava/manage-smartart-shape/
---


## **スマートアートシェイプの作成**
Aspose.Slides for Android via Javaは、スマートアートシェイプを作成するためのAPIを提供しています。スライドにスマートアートシェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtLayoutType)を設定して[スマートアートシェイプを追加](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)します。
1. 修正したプレゼンテーションをPPTXファイルとして保存します。

```java
// Presentationクラスのインスタンスを生成
Presentation pres = new Presentation();
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // スマートアートシェイプを追加
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // プレゼンテーションを保存
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**図: スライドに追加されたスマートアートシェイプ**|

## **スライド内のスマートアートシェイプへのアクセス**
以下のコードを使用して、プレゼンテーションスライドに追加されたスマートアートシェイプにアクセスします。サンプルコードでは、スライド内のすべてのシェイプをループ処理し、それが[スマートアート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)シェイプであるかどうかを確認します。シェイプがスマートアートタイプであれば、それを[**SmartArt**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)インスタンスに型キャストします。

```java
// 必要なプレゼンテーションをロード
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプをループ処理
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプがスマートアートタイプであるか確認
        if (shape instanceof ISmartArt)
        {
            // シェイプをSmartArtExに型キャスト
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("シェイプ名:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定のレイアウトタイプを持つスマートアートシェイプへのアクセス**
以下のサンプルコードでは、特定のLayoutTypeを持つ[スマートアート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)シェイプにアクセスする方法を示します。スマートアートのLayoutTypeは読み取り専用で、[スマートアート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)シェイプが追加されたときにのみ設定されるため、変更することはできません。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成し、スマートアートシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをループ処理します。
1. シェイプが[スマートアート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)タイプであるか確認し、スマートアートであれば選択したシェイプを型キャストします。
1. 特定のLayoutTypeを持つスマートアートシェイプを確認し、その後に行う必要がある処理を実行します。

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内のすべてのシェイプをループ処理
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプがスマートアートタイプであるか確認
        if (shape instanceof ISmartArt)
        {
            // シェイプをSmartArtExに型キャスト
            ISmartArt smart = (ISmartArt) shape;

            // スマートアートレイアウトを確認
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("ここに何かをする....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **スマートアートシェイプスタイルの変更**
この例では、任意のスマートアートシェイプのクイックスタイルを変更する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成し、スマートアートシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをループ処理します。
1. シェイプが[スマートアート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)タイプであるか確認し、スマートアートであれば選択したシェイプを型キャストします。
1. 特定のスタイルを持つスマートアートシェイプを見つけます。
1. スマートアートシェイプの新しいスタイルを設定します。
1. プレゼンテーションを保存します。

```java
// Presentationクラスのインスタンスを生成
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプをループ処理
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプがスマートアートタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプをSmartArtExに型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // スマートアートスタイルを確認
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // スマートアートスタイルを変更
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
|**図: スタイルが変更されたスマートアートシェイプ**|

## **スマートアートシェイプのカラースタイルの変更**
この例では、任意のスマートアートシェイプのカラースタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラースタイルを持つスマートアートシェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成し、スマートアートシェイプを含むプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内のすべてのシェイプをループ処理します。
1. シェイプが[スマートアート](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt)タイプであるか確認し、スマートアートであれば選択したシェイプを型キャストします。
1. 特定のカラースタイルを持つスマートアートシェイプを見つけます。
1. スマートアートシェイプの新しいカラースタイルを設定します。
1. プレゼンテーションを保存します。

```java
// Presentationクラスのインスタンスを生成
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内のすべてのシェイプをループ処理
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプがスマートアートタイプであるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプをSmartArtExに型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // スマートアートのカラースタイルを確認
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // スマートアートカラースタイルを変更
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
|**図: カラースタイルが変更されたスマートアートシェイプ**|