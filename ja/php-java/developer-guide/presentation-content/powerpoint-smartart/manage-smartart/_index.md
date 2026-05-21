---
title: PHP を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用し、スライドのデザインと自動化を迅速化する明確なコードサンプルで、PowerPoint の SmartArt を作成および編集する方法を学びます。"
---
## **概要**

SmartArt は、ノード、ノードシェイプ、およびレイアウトで構成された PowerPoint 図です。Aspose.Slides for PHP via Java を使用すると、SmartArt を作成し、ノードからテキストを読み取り、レイアウトを変更し、非表示ノードを検査し、組織図のレイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得**

SmartArt ノードは 1 つ以上のシェイプを含むことができます。表示テキストを取得するには、[SmartArt::getAllNodes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartart/#getAllNodes) を反復処理し、次に [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartshape/#getTextFrame) が返す [TextFrame](https://reference.aspose.com/slides/ja/php-java/aspose.slides/textframe/) を読み取ります。

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SmartArt オブジェクトのレイアウト タイプの変更**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SmartArt ノードが非表示かどうかの確認**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartnode/ishidden/) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択したレイアウトがノードを可視的な図要素として表示しなくても、非表示ノードは構造内に存在する場合があります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、ノードの非表示状態を確認します。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt ダイアグラムでは、[SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) と [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) が、親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側から吊り下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/organizationchartlayouttype/) の `LeftHanging` 値に設定します。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図用に設計された SmartArt レイアウトです。SmartArt オブジェクトをスライドに追加する際は、[SmartArtLayoutType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **よくある質問**

**SmartArt は RTL 言語のミラーリングまたは反転をサポートしていますか？**

はい。選択した SmartArt レイアウトが反転に対応している場合、[SmartArt::setReversed](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartart/setreversed/) メソッドにより、図の方向を左から右へから右から左へ、またはその逆に切り替えることができます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

[ShapeCollection::addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addclone/) を使用して[SmartArt のシェイプをクローン](/slides/ja/php-java/shape-manipulations/)するか、SmartArt を含むスライド全体を[クローン](/slides/ja/php-java/clone-slides/)できます。どちらの方法でも、サイズ、位置、書式が保持されます。

**SmartArt をプレビューまたはウェブエクスポート用のラスター画像にレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/php-java/convert-powerpoint-to-png/)するか、プレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt オブジェクトがある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の[Shape::getAlternativeText](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getalternativetext/)または[Shape::getName](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/getname/)の値を設定し、[BaseSlide::getShapes](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseslide/#getShapes)でその値を検索し、マッチするシェイプが[SmartArt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/smartart/)であることを確認します。