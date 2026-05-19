---
title: Android で PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/androidjava/manage-smartart/
keywords:
- スマートアート
- スマートアート テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像 組織図
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides を使用して PowerPoint の SmartArt を構築および編集する方法を学び、スライドのデザインと自動化を高速化する分かりやすい Java コードサンプルを提供します。"
---
## **概要**

SmartArt は、ノード、ノード シェイプ、レイアウトで構成された PowerPoint 図です。Aspose.Slides for Android via Java を使用すると、SmartArt の作成、ノードからのテキスト読み取り、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、および画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得**

SmartArt のノードは 1 つ以上のシェイプを含むことがあります。表示テキストを取得するには、[ISmartArt.getAllNodes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartart/#getAllNodes--) を反復処理し、[ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) が返す [ITextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itextframe/) を読み取ります。

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

## **SmartArt オブジェクトのレイアウト タイプを変更**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtLayoutType) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

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

## **SmartArt ノードが非表示かどうかを確認**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartartnode/#isHidden--) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択されたレイアウトが可視的な図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtLayoutType) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、ノードの非表示状態を確認します。

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

組織図レイアウトを使用する SmartArt 図の場合、[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) と [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) は、親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OrganizationChartLayoutType) に応じて、子ノードを左側、右側、または両側から吊り下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/OrganizationChartLayoutType) の `LeftHanging` 値に設定します。

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

画像組織図は、画像プレースホルダーを含む階層図向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/SmartArtLayoutType) の `PictureOrganizationChart` 値を使用します。

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

**SmartArt は RTL 言語向けにミラーリングまたは反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[ISmartArt.setReversed](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) メソッドは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

SmartArt が含まれるスライド上の [ShapeCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) を使用して [SmartArt シェイプをクローン](/slides/ja/androidjava/shape-manipulations/) するか、[SmartArt を含むスライド全体をクローン](/slides/ja/androidjava/clone-slides/) できます。どちらの方法もサイズ、位置、書式を保持します。

**SmartArt をプレビューや Web エクスポート用にラスター画像としてレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/androidjava/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt オブジェクトがある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の [Shape.getAlternativeText](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getAlternativeText--) または [Shape.getName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/shape/#getName--) の値を設定し、[BaseSlide.getShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseslide/#getShapes--) でその値を検索し、該当するシェイプが [ISmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartart/) であることを確認します。