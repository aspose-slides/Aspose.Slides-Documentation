---
title: Android で PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウトタイプ
- 非表示プロパティ
- 組織図
- ピクチャー組織図
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、スライドのデザインと自動化を高速化する明確な Java コードサンプルで、PowerPoint の SmartArt を作成および編集する方法を学びます。"
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


## **SmartArt オブジェクトのレイアウトタイプを変更する**
[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) のレイアウトタイプを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) BasicBlockList を追加します。
- [LayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setLayout-int-) を BasicProcess に変更します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、2つの図形の間にコネクタを追加しています。
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
ご注意: メソッド [ISmartArtNode.isHidden()]((https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--)) は、データモデルでこのノードが非表示ノードである場合に true を返します。[SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) の任意のノードの Hidden プロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) RadialCycle を追加します。
- SmartArt にノードを追加します。
- [isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#isHidden--) プロパティを確認します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、2つの図形の間にコネクタを追加しています。
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
        // いくつかのアクションまたは通知を実行
    }
    // プレゼンテーションを保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **組織図タイプの取得または設定**
メソッド [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) と [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、現在のノードに関連付けられた組織図タイプの取得および設定を可能にします。組織図タイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドに [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) を追加します。
- 組織図タイプを取得または [set the organization chart type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) します。
- プレゼンテーションを PPTX ファイルとして保存します。

以下の例では、2つの図形の間にコネクタを追加しています。
```java
Presentation pres = new Presentation();
try {
    // SmartArt BasicProcess を追加
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    // 組織図タイプを取得または設定
    smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    // プレゼンテーションを保存
    pres.save("OrganizeChartLayoutType_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **ピクチャー組織図の作成**
Aspose.Slides for Android via Java は、簡単に PictureOrganization チャートを作成できるシンプルな API を提供します。スライド上にチャートを作成する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
2. インデックスでスライドの参照を取得します。
3. デフォルトデータと目的のタイプ (ChartType.PictureOrganizationChart) を使用してチャートを追加します。
4. 変更したプレゼンテーションを PPTX ファイルとして保存します。

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


## **SmartArt の状態の取得または設定**
SmartArt の状態を取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドに [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SmartArt) を追加します。
- SmartArt ダイアグラムの状態を [Get](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#isReversed--) または [Set](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISmartArt#setReversed-boolean-) します。
- プレゼンテーションを PPTX ファイルとして保存します。

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

はい。メソッド [setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/#setReversed-boolean-) は、選択した SmartArt タイプが反転をサポートしている場合、ダイアグラムの方向 (LTR/RTL) を切り替えます。

**同じスライドまたは別のプレゼンテーションに SmartArt をコピーし、書式を保持するにはどうすればよいですか？**

シェイプコレクションの [clone the SmartArt shape](/slides/ja/androidjava/shape-manipulations/) (ShapeCollection.addClone) またはこのシェイプを含むスライド全体を [clone the entire slide](/slides/ja/androidjava/clone-slides/) できます。どちらの方法でもサイズ、位置、スタイリングが保持されます。

**プレビューやウェブエクスポートのために SmartArt をラスタ画像にレンダリングする方法は？**

[Render the slide](/slides/ja/androidjava/convert-powerpoint-to-png/) (またはプレゼンテーション全体) して PNG/JPEG に変換する API を使用します。SmartArt はスライドの一部として描画されます。

**スライド上に複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[alternative text](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) または [name](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getName--) を使用して、[slide shapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) 内でその属性でシェイプを検索し、タイプが [SmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartart/) であることを確認します。ドキュメントに典型的なテクニックが記載されています。