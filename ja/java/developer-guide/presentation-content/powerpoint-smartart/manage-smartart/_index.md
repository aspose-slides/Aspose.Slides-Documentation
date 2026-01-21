---
title: Java を使用した PowerPoint プレゼンテーションでの SmartArt の管理
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
description: "Aspose.Slides for Java を使用して、明確なコードサンプルで PowerPoint の SmartArt を構築および編集し、スライドのデザインと自動化を迅速化する方法を学びます。"
---

## **SmartArt オブジェクトからテキストを取得する**
現在、TextFrame メソッドがそれぞれ [ISmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtShape) インターフェイスと [SmartArtShape](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArtShape) クラスに追加されました。このプロパティを使用すると、ノードのテキストだけでなく [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) からすべてのテキストを取得できます。以下のサンプルコードは SmartArt ノードからテキストを取得するのに役立ちます。
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
[SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) のレイアウト タイプを変更するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) の BasicBlockList を追加します。
- [LayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setLayout-int-) を BasicProcess に変更します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形間にコネクタを追加しています。
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
注意: メソッド [ISmartArtNode.isHidden()](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) は、このノードがデータモデルで非表示ノードである場合に true を返します。任意の [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/SmartArt) ノードの非表示プロパティを確認するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) の RadialCycle を追加します。
- SmartArt にノードを追加します。
- [visibility](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) プロパティを確認します。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形間にコネクタを追加しています。
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
        // 何らかの処理や通知を行う
    }
    // プレゼンテーションを保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **組織図タイプの取得または設定**
メソッド [ISmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--)、[setOrganizationChartLayout(int)](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、現在のノードに関連付けられた組織図タイプの取得または設定を行います。組織図タイプを取得または設定するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドに [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
- 組織図タイプを取得または [set the organization chart type](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-)。
- プレゼンテーションを書き出して PPTX ファイルにします。

以下の例では、2 つの図形間にコネクタを追加しています。
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


## **画像組織図の作成**
Aspose.Slides for Java は、PictureOrganization チャートを簡単に作成できるシンプルな API を提供します。スライドにチャートを作成する手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと希望のタイプ (ChartType.PictureOrganizationChart) のチャートを追加します。
1. 修正したプレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャートを作成するためのものです。
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
SmartArt の状態を取得または設定するには、以下の手順に従ってください：

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドに [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
1. [Get](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#isReversed--) または [Set](https://reference.aspose.com/slides/java/com.aspose.slides/ISmartArt#setReversed-boolean-) して SmartArt ダイアグラムの状態を取得または設定します。
1. プレゼンテーションを書き出して PPTX ファイルにします。

以下のコードはチャートを作成するためのものです。
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

はい。選択した SmartArt タイプが反転をサポートしている場合、[setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/#setReversed-boolean-) メソッドはダイアグラムの方向 (LTR/RTL) を切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして、書式設定を保持するにはどうすればよいですか？**

シェイプ コレクションを介して [SmartArt シェイプをクローン](/slides/ja/java/shape-manipulations/) するか、（[ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)) またはこのシェイプを含むスライド全体を [クローン](/slides/ja/java/clone-slides/) することができます。どちらの方法でもサイズ、位置、スタイルが保持されます。

**プレビューやウェブエクスポートのために SmartArt をラスター画像にレンダリングするにはどうすればよいですか？**

スライド（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用して、[スライドをレンダリング](/slides/ja/java/convert-powerpoint-to-png/) します。SmartArt はスライドの一部として描画されます。

**スライドに複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getAlternativeText--) (Alt Text) または [名前](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getName--) を使用し、その属性で [スライドシェイプ](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) 内のシェイプを検索し、タイプを確認してそれが [SmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/smartart/) であることを確認することです。ドキュメントではシェイプの検索と操作に関する典型的な手法が説明されています。