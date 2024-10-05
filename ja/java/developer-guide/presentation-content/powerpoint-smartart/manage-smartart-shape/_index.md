---
title: SmartArt シェイプの管理
type: docs
weight: 20
url: /java/manage-smartart-shape/
---

## **SmartArt シェイプの作成**
Aspose.Slides for Java には、SmartArt シェイプを作成するための API が用意されています。スライドに SmartArt シェイプを作成するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスを使用してスライドの参照を取得します。
1. [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtLayoutType) を設定して [SmartArt シェイプを追加します](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-)。
1. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```java
// Presentation クラスのインスタンスを作成
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

## **スライド内の SmartArt シェイプにアクセス**
以下のコードは、プレゼンテーションスライドに追加された SmartArt シェイプにアクセスするために使用されます。サンプルコードでは、スライド内の各シェイプをトラバースし、それが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) シェイプであるかどうかを確認します。シェイプが SmartArt 型の場合、そのインスタンスを [**SmartArt**](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) に型キャストします。

```java
// 希望のプレゼンテーションをロード
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内の各シェイプをトラバース
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプが SmartArt 型であるか確認
        if (shape instanceof ISmartArt)
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("シェイプ名:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **特定の LayoutType での SmartArt シェイプへのアクセス**
以下のサンプルコードは、特定の LayoutType を持つ [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) シェイプにアクセスするのに役立ちます。注意してください。SmartArt の LayoutType は読み取り専用であり、[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) シェイプが追加されたときのみ設定されます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを持つプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内の各シェイプをトラバースします。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを型キャストします。
1. 特定の LayoutType を持つ SmartArt シェイプを確認し、その後必要な操作を実行します。

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // 最初のスライド内の各シェイプをトラバース
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // シェイプが SmartArt 型であるか確認
        if (shape instanceof ISmartArt)
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt) shape;

            // SmartArt レイアウトの確認
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("ここで何かを実行します....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **SmartArt シェイプのスタイルを変更**
この例では、任意の SmartArt シェイプのクイックスタイルを変更する方法を学びます。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを持つプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内の各シェイプをトラバースします。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを型キャストします。
1. 特定のスタイルを持つ SmartArt シェイプを見つけます。
1. SmartArt シェイプに新しいスタイルを設定します。
1. プレゼンテーションを保存します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内の各シェイプをトラバース
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt 型であるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt スタイルの確認
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // SmartArt スタイルの変更
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

## **SmartArt シェイプのカラー スタイルを変更**
この例では、任意の SmartArt シェイプのカラー スタイルを変更する方法を学びます。以下のサンプルコードでは、特定のカラースタイルを持つ SmartArt シェイプにアクセスし、そのスタイルを変更します。

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成し、SmartArt シェイプを持つプレゼンテーションをロードします。
1. インデックスを使用して最初のスライドの参照を取得します。
1. 最初のスライド内の各シェイプをトラバースします。
1. シェイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) 型であるか確認し、SmartArt であれば選択したシェイプを型キャストします。
1. 特定のカラー スタイルを持つ SmartArt シェイプを見つけます。
1. SmartArt シェイプに新しいカラー スタイルを設定します。
1. プレゼンテーションを保存します。

```java
// Presentation クラスのインスタンスを作成
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // 最初のスライドを取得
    ISlide slide = pres.getSlides().get_Item(0);
    
    // 最初のスライド内の各シェイプをトラバース
    for (IShape shape : slide.getShapes()) 
    {
        // シェイプが SmartArt 型であるか確認
        if (shape instanceof ISmartArt) 
        {
            // シェイプを SmartArtEx に型キャスト
            ISmartArt smart = (ISmartArt) shape;
    
            // SmartArt カラータイプの確認
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // SmartArt カラータイプの変更
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