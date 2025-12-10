---
title: PowerPoint プレゼンテーションで Java を使用して SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint の SmartArt を作成・編集する方法を学び、スライドデザインと自動化を高速化する明確なコードサンプルをご紹介します。"
---

## **SmartArt オブジェクトからテキストを取得する**
現在、TextFrame メソッドが [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) インターフェイスと [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) クラスにそれぞれ追加されました。このプロパティを使用すると、ノードのテキストだけでなく [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) からすべてのテキストを取得できます。以下のサンプルコードは SmartArt ノードからテキストを取得するのに役立ちます。
```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    ISmartArt smartArt = (ISmartArt)slide.getShapes().get_Item(0);

    ISmartArtNodeCollection smartArtNodes = smartArt.getAllNodes();
    for (ISmartArtNode smartArtNode : smartArtNodes)
    {
        for (ISmartArtShape nodeShape : smartArtNode.getShapes())
        {
            if (nodeShape.getTextFrame() != null)
                System.out.println(nodeShape.getTextFrame().getText());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt オブジェクトのレイアウトタイプを変更する**
[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) のレイアウトタイプを変更するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- BasicBlockList の [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) を BasicProcess に変更します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、二つの図形の間にコネクタを追加しています。
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess を追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    // LayoutType を BasicProcess に変更
    smart.setLayout(SmartArtLayoutType.BasicProcess);

    // プレゼンテーションを保存
    pres.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt オブジェクトの Hidden プロパティを確認する**
注意: メソッド [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--)) は、データモデルでこのノードが非表示ノードの場合に true を返します。任意の [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) のノードの hidden プロパティを確認するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- RadialCycle の [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- SmartArt にノードを追加します。
- [isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#isHidden--) プロパティを確認します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、二つの図形の間にコネクタを追加しています。
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess を追加 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArt にノードを追加 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // isHidden プロパティを確認
    boolean hidden = node.isHidden(); // true を返す

    if (hidden)
    {
        // いくつかのアクションまたは通知を実行
    }
    // プレゼンテーションを保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **組織図のタイプを取得または設定する**
メソッド [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、現在のノードに関連付けられた組織図のタイプを取得または設定できるようにします。組織図のタイプを取得または設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライド上に [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- 組織図のタイプを取得または [set the organization chart type](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、二つの図形の間にコネクタを追加しています。
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess を追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図のタイプを取得または設定
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // プレゼンテーションを保存
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ピクチャー組織図を作成する**
Aspose.Slides for Java は、ピクチャー組織図を簡単に作成できるシンプルな API を提供します。スライド上にチャートを作成するには、以下の手順を実行します：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと desired type (ChartType.PictureOrganizationChart) を指定してチャートを追加します。
1. 変更したプレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャートを作成するために使用されます。
```java
Presentation pres = new Presentation("test.pptx");
try {
    ISmartArt smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **SmartArt の状態を取得または設定する**
SmartArt のレイアウトタイプを変更するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライド上に [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
1. SmartArt ダイアグラムの状態を [Get](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) または [Set](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) します。
1. プレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャートを作成するために使用されます。
```java
// PPTX ファイルを表す Presentation クラスのインスタンスを作成
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess を追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);
    
    // SmartArt ダイアグラムの状態を取得または設定
    smart.setReversed(true);
    boolean flag = smart.isReversed();
    
    // プレゼンテーションを保存
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**SmartArt は RTL 言語向けのミラーリング/反転をサポートしていますか？**

はい。選択した SmartArt タイプが反転に対応している場合、[setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) メソッドはダイアグラムの方向 (LTR/RTL) を切り替えます。

**同じスライドまたは別のプレゼンテーションに SmartArt をコピーして書式を保持するにはどうすればよいですか？**

シェイプコレクションから [clone the SmartArt shape](/slides/ja/java/shape-manipulations/)（[ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) を使用するか、[clone the entire slide](/slides/ja/java/clone-slides/) を使用してこのシェイプを含むスライド全体を複製できます。どちらの方法でもサイズ、位置、スタイルが保持されます。

**SmartArt をプレビューや Web エクスポート用にラスタ画像としてレンダリングするには？**

[Render the slide](/slides/ja/java/convert-powerpoint-to-png/)（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用して、SmartArt をスライドの一部として描画できます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[alternative text](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--)（Alt Text）や [name](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) を使用し、[slide shapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) 内でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/) であることを確認することです。ドキュメントにはシェイプの検索や操作の典型的な手法が記載されています。