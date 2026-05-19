---
title: JavaScript を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt を管理する
type: docs
weight: 10
url: /ja/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "明確な JavaScript コードサンプルを使用して、Node.js 用 Aspose.Slides で PowerPoint の SmartArt を作成・編集し、スライドのデザインと自動化を高速化する方法を学びます。"
---
## **概要**

SmartArt はノード、ノードシェイプ、レイアウトで構成された PowerPoint の図です。Aspose.Slides for Node.js via Java を使用すると、SmartArt の作成、ノードからのテキストの取得、レイアウトの変更、非表示ノードの検査、組織図レイアウトの設定、画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt のノードは 1 つ以上のシェイプを含むことができます。表示されているテキストを取得するには、[SmartArt.getAllNodes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartart/#getAllNodes--) を列挙し、続いて [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartshape/#getTextFrame--) が返す [TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/) を読み取ります。

```javascript
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt オブジェクトのレイアウト タイプを変更する**

SmartArt のレイアウトはノードの配置と接続方法を制御します。次の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt ノードが非表示かどうかをチェックする**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartnode/ishidden/) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択したレイアウトで表示要素として描画されなくても、構造内に非表示ノードが存在する可能性があります。

次の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartlayouttype/) の `RadialCycle` 値を使用した SmartArt オブジェクトにノードを追加し、そのノードの非表示状態をチェックします。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図の場合、[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) と [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) は、親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択した [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側から吊り下げるように設定できます。

次の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/organizationchartlayouttype/) の `LeftHanging` 値に設定します。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt は RTL 言語向けにミラーリングまたは反転をサポートしていますか？**

はい。選択した SmartArt レイアウトが反転に対応している場合、[SmartArt.setReversed](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartart/setreversed/) メソッドは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーし、書式を保持するにはどうすればよいですか？**

SmartArt シェイプは [ShapeCollection.addClone](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shapecollection/addclone/) を使用して [SmartArt シェイプをクローン](/slides/ja/nodejs-java/shape-manipulations/) できます。または、SmartArt を含むスライド全体を [スライドをクローン](/slides/ja/nodejs-java/clone-slides/) でクローンすることも可能です。どちらの方法でもサイズ、位置、書式が保持されます。

**SmartArt をプレビューや Web エクスポート用のラスタ画像にレンダリングするには？**

[スライドをレンダリング](/slides/ja/nodejs-java/convert-powerpoint-to-png/) するか、プレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt がある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape.setAlternativeText](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/setalternativetext/) または [Shape.setName](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/shape/setname/) の値を設定し、[BaseSlide.getShapes](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseslide/#getShapes) でその値を検索し、該当するシェイプが [SmartArt](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/smartart/) であることを確認します。