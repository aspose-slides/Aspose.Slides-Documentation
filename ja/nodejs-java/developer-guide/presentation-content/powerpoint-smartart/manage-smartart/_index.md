---
title: JavaScript を使用した PowerPoint プレゼンテーションの SmartArt 管理
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-smartart/
keywords:
- スマートアート
- スマートアートのテキスト
- レイアウトタイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- パワーポイント
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用し、明快な JavaScript コードサンプルで PowerPoint の SmartArt を構築・編集し、スライドデザインと自動化を迅速に行う方法を学びます。"
---

## **SmartArt からテキストを取得**
現在、TextFrame メソッドが [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) クラスおよび [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) クラスに追加されました。このプロパティを使用すると、ノードのテキストだけでなく、[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) からすべてのテキストを取得できます。以下のサンプルコードは、SmartArt ノードからテキストを取得するのに役立ちます。
```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var smartArt = slide.getShapes().get_Item(0);
    var smartArtNodes = smartArt.getAllNodes();
    
    for (let i = 0; i < smartArtNodes.size(); i++) {
        const smartArtNode = smartArtNodes.get_Item(i);
        for (let j = 0; j < smartArtNode.getShapes().size(); j++) {
            const nodeShape = smartArtNode.getShapes().get_Item(j);
            if (nodeShape.getTextFrame() != null) {
                console.log(nodeShape.getTextFrame().getText());
            }
        }
    }
    
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt のレイアウト タイプを変更**
SmartArt のレイアウト タイプを変更するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) の BasicBlockList を追加します。
- [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) を BasicProcess に変更します。
- プレゼンテーションを PPTX ファイルとして保存します。
以下の例では、2 つの図形の間にコネクタを追加しています。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // LayoutType を BasicProcess に変更
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // プレゼンテーションを保存
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt の可視性プロパティを確認**
注意: メソッド [SmartArtNode.isHidden()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) は、データモデルでこのノードが非表示の場合に true を返します。[SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) の任意のノードの非表示プロパティを確認するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) の RadialCycle を追加します。
- SmartArt にノードを追加します。
- [visibility](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) プロパティを確認します。
- プレゼンテーションを PPTX ファイルとして保存します。
以下の例では、2 つの図形の間にコネクタを追加しています。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    // SmartArt にノードを追加
    var node = smart.getAllNodes().addNode();
    // isHidden プロパティを確認
    var hidden = node.isHidden();// true を返す
    if (hidden) {
        // いくつかの処理や通知を行う
    }
    // プレゼンテーションを保存
    pres.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **組織図のタイプを取得または設定**
メソッド [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) と [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) を使用すると、現在のノードに関連付けられた組織図のタイプを取得または設定できます。組織図のタイプを取得または設定するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
- スライドに [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) を追加します。
- 組織図のタイプを取得または [set the organization chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) します。
- プレゼンテーションを PPTX ファイルとして保存します。
以下の例では、2 つの図形の間にコネクタを追加しています。
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // 組織図のタイプを取得または設定
    smart.getNodes().get_Item(0).setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);
    // プレゼンテーションを保存
    pres.save("OrganizeChartLayoutType_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **ピクチャー組織図の作成**
Aspose.Slides for Node.js via Java は、ピクチャー組織図を簡単に作成できるシンプルな API を提供します。スライドにチャートを作成するには、以下の手順を実行します。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. インデックスでスライドの参照を取得します。
1. デフォルトデータと目的のタイプ (ChartType.PictureOrganizationChart) を使用してチャートを追加します。
1. 変更したプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードはチャートを作成するために使用されます。
```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var smartArt = pres.getSlides().get_Item(0).getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);
    pres.save("OrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt の状態を取得または設定**
SmartArt のレイアウト タイプを変更するには、以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドに [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) を追加します。
1. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) または [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) で SmartArt 図の状態を取得または設定します。
1. プレゼンテーションを PPTX ファイルとして保存します。

以下のコードはチャートを作成するために使用されます。
```javascript
// PPTX ファイルを表す Presentation クラスのインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // SmartArt 図の状態を取得または設定
    smart.setReversed(true);
    var flag = smart.isReversed();
    // プレゼンテーションを保存
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**SmartArt は RTL 言語向けのミラーリング/反転をサポートしますか？**

はい。[setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) メソッドは、選択した SmartArt タイプが反転をサポートしている場合、図の方向（LTR/RTL）を切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーし、書式設定を保持するにはどうすればよいですか？**

形状コレクション（[ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)）を使用して [SmartArt の形状をクローン](/slides/ja/nodejs-java/shape-manipulations/) するか、またはこの形状が含まれるスライド全体を [クローン](/slides/ja/nodejs-java/clone-slides/) できます。どちらの方法でもサイズ、位置、スタイルが保持されます。

**SmartArt をプレビューやウェブエクスポート用のラスタ画像にレンダリングするにはどうすればよいですか？**

スライド（またはプレゼンテーション全体）を PNG/JPEG に変換する API を使用して、[スライドをレンダリング](/slides/ja/nodejs-java/convert-powerpoint-to-png/) します。SmartArt はスライドの一部として描画されます。

**スライド上に複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

一般的な方法は、[代替テキスト](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/)（Alt Text）または [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) を使用し、その属性で形状を検索するために [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) を使用することです。その後、タイプを確認してそれが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) であることを確認します。ドキュメントでは、形状の検索と操作のための一般的なテクニックが説明されています。