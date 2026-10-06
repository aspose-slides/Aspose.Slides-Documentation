---
title: PowerPoint プレゼンテーションで JavaScript を使用して SmartArt を管理
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用した PowerPoint SmartArt の構築と編集を学び、スライド デザインと自動化を高速化する明確な JavaScript コード サンプルをご紹介します。"
---
## **概要**

SmartArt は、ノード、ノード シェイプ、およびレイアウトで構成される PowerPoint の図です。Aspose.Slides for Node.js via Java を使用すると、SmartArt を作成し、ノードからテキストを取得し、レイアウトを変更し、非表示ノードを検査し、組織図レイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得**

SmartArt ノードは 1 つ以上のシェイプを含むことができます。ノード シェイプからテキストを読み取るには、[SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/) を列挙し、[SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/) が返す [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) を読み取ります。

この例は、少なくとも 1 枚のスライドと、そのスライドの最初のシェイプとして SmartArt オブジェクトが配置されたプレゼンテーションが必要です。利用可能な各テキスト フレームをコンソールに出力します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt オブジェクトのレイアウト タイプを変更**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) に渡す位置とサイズはポイント単位です。[SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) を使用してレイアウトを変更します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt ノードが非表示かどうかを確認**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) は、ノードが SmartArt データ モデルで非表示かどうかを示します。非表示ノードは、選択したレイアウトがそれらを可視の図要素として表示しなくても、構造内に存在する可能性があります。

次の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加されたノードの非表示状態を確認します。ノードが非表示の場合はメッセージを出力し、図を保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図の場合、[SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) と [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) によって、子ノードが親ノードの下にどのように配置されるかが決まります。たとえば、選択した [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側にぶら下げるよう設定できます。

次の例は組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging` 値に設定します。0 から始まるインデックス `0` が最上位ノードを選択し、その子ノードは選択された配置を使用します。変更後のプレゼンテーションを保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に、[SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 値を使用します。この例は画像プレースホルダー付きの図を保存しますが、プレースホルダーに画像を配置することはありません。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **レガシーダイアグラムをシェイプ グループに変換**

既存のプレゼンテーションを最新化する際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシーダイアグラムを [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) オブジェクトとして表現します。[LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) を使用して、ダイアグラムをシェイプ グループに変換し、個々のビジュアル要素を編集できるようにします。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) を参照してください。

変換はシェイプ コレクションに新しいグループを追加し、元のダイアグラムは削除しません。変換が成功したら、[ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) で元のダイアグラムを削除し、重複コンテンツを防ぎます。シェイプの追加と削除がイテレーションを妨げないよう、変換前にレガシーダイアグラムをリストに収集してください。

次の例はプレゼンテーションを開き、すべてのスライドを検索し、ダイアグラムをシェイプ グループに変換し、更新されたプレゼンテーションを PPTX として保存します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたプレゼンテーションには、変換されたレガシーダイアグラムの代わりに編集可能なシェイプ グループが配置されており、元のダイアグラムは残っていません。PPTX を PowerPoint で開くと、各グループ内のテキスト、塗りつぶし、位置などの個別要素を編集できます。

## **FAQ**

**SmartArt は RTL 言語向けにミラーリングまたは反転をサポートしていますか？**

はい。選択した SmartArt レイアウトが反転に対応している場合、[SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) メソッドにより、図の方向を左から右へ、または右から左へ切り替えることができます。

**書式を保持したまま、同じスライドまたは別のプレゼンテーションに SmartArt をコピーするにはどうすればよいですか？**

[SmartArt シェイプをクローン](/slides/ja/nodejs-java/shape-manipulations/) するには [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) を使用するか、SmartArt を含むスライド全体を[クローン](/slides/ja/nodejs-java/clone-slides/) してください。どちらの方法でもサイズ、位置、書式が保持されます。

**プレビューや Web エクスポートのために SmartArt をラスター画像にレンダリングするにはどうすればよいですか？**

スライド全体またはプレゼンテーション全体を PNG または JPEG に[変換](/slides/ja/nodejs-java/convert-powerpoint-to-png/) してください。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt オブジェクトがある場合、特定のオブジェクトをどうやって見つけますか？**

[Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) または [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) を使用して SmartArt シェイプに固有の代替テキストまたは名前を割り当て、[BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) でその値を検索し、該当シェイプが [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/) であることを確認してください。