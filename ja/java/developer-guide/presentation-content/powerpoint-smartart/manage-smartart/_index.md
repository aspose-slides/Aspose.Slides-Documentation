---
title: Java を使用して PowerPoint プレゼンテーションで SmartArt を管理する
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
description: "明確なコード例を使用して、Java 用 Aspose.Slides で PowerPoint の SmartArt を作成および編集し、スライドのデザインと自動化を高速化する方法を学びます。"
---
## **概要**

SmartArt は、ノード、ノードの形状、およびレイアウトで構成された PowerPoint の図です。Aspose.Slides for Java を使用すると、SmartArt を作成し、ノードからテキストを読み取り、レイアウトを変更し、非表示ノードを調査し、組織図レイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt のノードは 1 つ以上の形状を含むことができます。表示テキストを取得するには、[ISmartArt.getAllNodes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartart/#getAllNodes--) を反復処理し、次に [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartartshape/#getTextFrame--) が返す [ITextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/itextframe/) を読み取ります。

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt オブジェクトのレイアウト タイプを変更する**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtLayoutType) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt ノードが非表示かどうかを確認する**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartartnode/#isHidden--) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択されたレイアウトが可視的な図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

以下の例は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtLayoutType) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、そのノードの非表示状態を確認します。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt ダイアグラムの場合、[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) と [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、親ノード下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OrganizationChartLayoutType) に応じて、子ノードを左側、右側、または両側から吊り下げるように設定できます。

以下の例は、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/OrganizationChartLayoutType) の `LeftHanging` 値に設定します。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図用に設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/SmartArtLayoutType) の `PictureOrganizationChart` 値を使用します。

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt は RTL 言語に対してミラーリングまたは反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[ISmartArt.setReversed](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartart/#setReversed-boolean-) メソッドは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

SmartArt を含むスライド上で、[ShapeCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) を使用して [SmartArt シェイプをクローン](/slides/ja/java/shape-manipulations/) するか、[SmartArt を含むスライド全体をクローン](/slides/ja/java/clone-slides/) することができます。どちらの方法もサイズ、位置、書式を保持します。

**プレビューやウェブエクスポートのために SmartArt をラスタ画像にレンダリングするにはどうすればよいですか？**

スライド全体またはプレゼンテーション全体を PNG または JPEG に [レンダリング](/slides/ja/java/convert-powerpoint-to-png/) してください。SmartArt はスライドの一部としてレンダリングされます。

**複数の SmartArt がある場合、スライド上で特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape.getAlternativeText](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getAlternativeText--) または [Shape.getName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/shape/#getName--) の値を設定し、[BaseSlide.getShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseslide/#getShapes--) でその値を検索し、該当するシェイプが [ISmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ismartart/) であることを確認します。