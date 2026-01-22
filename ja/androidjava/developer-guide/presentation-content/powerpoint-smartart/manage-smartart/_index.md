---
title: Android 上の PowerPoint プレゼンテーションで SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、スライドの設計と自動化を高速化する明確な Java コードサンプルで、PowerPoint の SmartArt の作成と編集を学びましょう。"
---

## **SmartArt オブジェクトからテキストを取得する**
現在、TextFrame メソッドが [ISmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtShape) インターフェイスと [SmartArtShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArtShape) クラスにそれぞれ追加されました。このプロパティを使用すると、ノードのテキストだけでなく、[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) からすべてのテキストを取得できます。以下のサンプルコードは、SmartArt ノードからテキストを取得する方法を示しています。
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


## **SmartArt オブジェクトのレイアウト タイプを変更する**
[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) のレイアウト タイプを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- BasicBlockList の [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) を BasicProcess に変更します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、2 つの図形の間にコネクタを追加しています。
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


## **SmartArt オブジェクトの Visibility プロパティを確認する**
注意: メソッド [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden) は、データモデルでこのノードが非表示ノードである場合に true を返します。[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) の任意のノードの非表示プロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) の RadialCycle を追加します。
- SmartArt にノードを追加します。
- [visibility](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden) プロパティを確認します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、2 つの図形の間にコネクタを追加しています。
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess を追加 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    // SmartArt にノードを追加 
    ISmartArtNode node = smart.getAllNodes().addNode();

    // isHidden プロパティを確認
    boolean hidden = node.isHidden(); // true を返します

    if (hidden)
    {
        // 何らかのアクションまたは通知を実行
    }
    // プレゼンテーションを保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **組織図のタイプを取得または設定する**
メソッド [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、現在のノードに関連付けられた組織図タイプの取得または設定を行います。組織図タイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライド上に [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- 組織図タイプを取得または [set the organization chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、2 つの図形の間にコネクタを追加しています。
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


## **画像組織図の作成**
Aspose.Slides for Android via Java は、PictureOrganization チャートを簡単に作成するためのシンプルな API を提供します。スライド上にチャートを作成する手順は以下の通りです。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと希望のタイプ (ChartType.PictureOrganizationChart) のチャートを追加します。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードはチャート作成に使用されます。
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
SmartArt のレイアウト タイプを変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライド上に [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
1. [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) または [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) で SmartArt ダイアグラムの状態を取得または設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下のコードは SmartArt の状態を取得または設定するために使用されます。
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

**SmartArt は RTL 言語のミラーリング/反転をサポートしていますか？**

はい。選択された SmartArt タイプが反転をサポートしている場合、[setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) メソッドはダイアグラムの方向 (LTR/RTL) を切り替えます。

**同じスライドまたは別のプレゼンテーションに SmartArt をコピーして書式を保持するにはどうすればよいですか？**

Shapes コレクションの [SmartArt シェイプをクローンする](/slides/ja/androidjava/shape-manipulations/)（[ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) またはこのシェイプを含むスライド全体を [スライド全体をクローンする](/slides/ja/androidjava/clone-slides/) することでコピーできます。どちらの方法もサイズ、位置、スタイリングを保持します。

**プレビューやウェブエクスポートのために SmartArt をラスタ画像にレンダリングするには？**

スライド (/slides/ja/androidjava/convert-powerpoint-to-png/)（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用してレンダリングすると、SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[代替テキスト](/slides/ja/androidjava/alternative-text/)（Alt Text）や [名前](/slides/ja/androidjava/name/) を使用して属性でシェイプを検索し、[スライド シェープ](/slides/ja/androidjava/slide-shapes/) 内でその属性でシェイプを探し、タイプが [SmartArt] であることを確認することです。ドキュメントはシェイプの検索と操作の典型的な手法を説明しています。