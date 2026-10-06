---
title: PowerPoint プレゼンテーションで PHP を使用して SmartArt を管理する
linktitle: SmartArt の管理
type: docs
weight: 10
url: /ja/php-java/manage-smartart/
keywords:
- SmartArt
- SmartArt テキスト
- レイアウト タイプ
- 非表示プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、スライドのデザインと自動化を迅速にする明確なコードサンプルで、PowerPoint SmartArt の作成と編集を学びましょう。"
---
## **概要**

SmartArt はノード、ノード シェイプ、レイアウトで構成された PowerPoint の図です。Aspose.Slides for PHP via Java を使用すると、SmartArt の作成、ノードからのテキスト読み取り、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt ノードは 1 つ以上のシェイプを含むことができます。ノード シェイプからテキストを読み取るには、[SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/) を反復処理し、次に [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/) が返す [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) を読み取ります。

この例では、少なくとも 1 枚のスライドがあり、そのスライドの最初のシェイプとして SmartArt オブジェクトが配置されたプレゼンテーションが必要です。利用可能な各テキスト フレームをコンソールに出力します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **SmartArt オブジェクトのレイアウト タイプを変更する**

SmartArt のレイアウトはノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) に渡す位置とサイズはポイント単位です。レイアウトを変更するには [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) を使用します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **SmartArt ノードが非表示かどうかを確認する**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択されたレイアウトがノードを可視的な図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加されたノードの非表示状態を確認します。ノードが非表示の場合はメッセージを出力し、図を保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt 図では、[SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) と [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) が親ノード配下の子ノードの配置方法を定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側にぶら下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) の `LeftHanging` 値に設定します。ゼロベースのインデックス `0` が最上位ノードを選択し、その子ノードは選択された配置を使用します。変更されたプレゼンテーションは保存されます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層図用に設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に、[SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。この例では、画像プレースホルダーを含む図を保存しますが、プレースホルダーに画像は設定しません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **レガシー図をシェイプのグループに変換する**

既存のプレゼンテーションを最新化する際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシー図を [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) オブジェクトとして表現します。[LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) を使用して、図をシェイプのグループに変換し、個々のビジュアル要素を編集できるようにします。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) を参照してください。

変換は元の図を削除せずにシェイプ コレクションに新しいグループを追加します。変換が成功したら、重複コンテンツを防ぐために [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) で元の図を削除します。シェイプの追加・削除がイテレーションを妨げないよう、変換前にレガシー図をリストに収集します。

以下の例では、プレゼンテーションを開き、すべてのスライドを検索し、図をシェイプのグループに変換して、更新されたプレゼンテーションを PPTX として保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

保存されたプレゼンテーションには、変換されたレガシー図の代わりに編集可能なシェイプ グループが含まれ、元の図は残っていません。PowerPoint で PPTX を開き、各グループ内のテキスト、塗りつぶし、位置などの個別要素を編集できます。

## **よくある質問**

**SmartArt は RTL 言語のミラーリングまたは反転をサポートしますか？**

はい。選択された SmartArt レイアウトが反転をサポートしている場合、[SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) メソッドは図の方向を左から右 (LTR) から右から左 (RTL) に、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式設定を保持したい場合は？**

SmartArt の形状をクローンするには、[SmartArtの形状をクローンする](/slides/ja/php-java/shape-manipulations/) を [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) で、または SmartArt を含むスライド全体をクローンするには [スライド全体をクローンする](/slides/ja/php-java/clone-slides/) を使用できます。どちらの方法もサイズ、位置、書式設定を保持します。

**SmartArt をプレビューや Web エクスポート用にラスタ画像にレンダリングするには？**

[スライドをレンダリングする](/slides/ja/php-java/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライド上に複数の SmartArt がある場合、特定の SmartArt オブジェクトを見つけるには？**

SmartArt の形状に固有の代替テキストまたは名前を割り当てるには、[Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) または [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) を使用し、[BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes) でその値を検索し、該当するシェイプが [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) であることを確認します。