---
title: SmartArt の管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-smartart/
---

## **SmartArt からテキストを取得**
Now TextFrame method has been added to [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) class and [SmartArtShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtShape) class respectively. This property allows you to get all text from [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt) if it has not only nodes text. The following sample code will help you to get text from SmartArt node.
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
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Obtain the reference of a slide by using its Index.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) BasicBlockList.
- Change [LayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setLayout-int-) to BasicProcess.
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.
```javascript
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    // レイアウトタイプを BasicProcess に変更
    smart.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);
    // プレゼンテーションを保存
    pres.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **SmartArt の非表示プロパティをチェック**
Please note: method [SmartArtNode.isHidden()]((https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--)) returns true if this node is a hidden node in the data model. In order to check the hidden property of any node of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) RadialCycle.
- Add node on SmartArt.
- Check [isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#isHidden--) property.
- Write the presentation as a PPTX file.

In the example given below, we have added a connector between two shapes.
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
        // 何らかのアクションや通知を行う
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
Methods [SmartArtNode.getOrganizationChartLayout()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#getOrganizationChartLayout--) , [setOrganizationChartLayout(int)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-) allow get or sets organization chart type associated with current node. In order to get or set organization chart type. Please follow the steps below:

- Create an instance of [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
- Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
- Get or [set the organization chart type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArtNode#setOrganizationChartLayout-int-).
- Write the presentation as a PPTX file.
  In the example given below, we have added a connector between two shapes.
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
Aspose.Slides for Node.js via Java provides a simple API for creating and PictureOrganization charts in an easy way. To create a chart on a slide:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Obtain a slide's reference by its index.
1. Add a chart with default data along with the desired type (ChartType.PictureOrganizationChart).
1. Write the modified presentation to a PPTX file

The following code is used to create a chart.
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
In order to change the layout type of [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt). Please follow the steps below:

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) class.
1. Add [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ShapeCollection#addSmartArt-float-float-float-float-int-) on slide.
1. [Get](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#isReversed--) or [Set](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SmartArt#setReversed-boolean-) the state of SmartArt Diagram.
1. Write the presentation as a PPTX file.

The following code is used to create a chart.
```javascript
// PPTX ファイルを表す Presentation クラスをインスタンス化
var pres = new aspose.slides.Presentation();
try {
    // SmartArt BasicProcess を追加
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicProcess);
    // SmartArt ダイアグラムの状態を取得または設定
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

**SmartArt は RTL 言語のミラーリング/反転をサポートしていますか？**

Yes. The [setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) method switches the diagram direction (LTR/RTL) if the selected SmartArt type supports reversal.

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

You can [clone the SmartArt shape](/slides/ja/nodejs-java/shape-manipulations/) via the shapes collection ([ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/)) or [clone the entire slide](/slides/ja/nodejs-java/clone-slides/) containing this shape. Both approaches preserve size, position, and styling.

**SmartArt をプレビューや Web エクスポート用にラスター画像としてレンダリングするにはどうすればよいですか？**

[Render the slide](/slides/ja/nodejs-java/convert-powerpoint-to-png/) (or the whole presentation) to PNG/JPEG through the API that converts slides/presentations to images—SmartArt will be drawn as part of the slide.

**複数の SmartArt がある場合、特定の SmartArt をプログラムで選択するにはどうすればよいですか？**

A common practice is to use [alternative text](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) (Alt Text) or [setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) and search for the shape by that attribute using [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), then check the type to confirm it’s [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/). The documentation describes typical techniques for finding and working with shapes.