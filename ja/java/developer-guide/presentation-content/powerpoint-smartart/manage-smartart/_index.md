---
title: Java を使用して PowerPoint プレゼンテーションの SmartArt を管理する
linktitle: SmartArt を管理
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
description: "Aspose.Slides for Java を使用して PowerPoint SmartArt を作成・編集する方法を、スライドのデザインと自動化を迅速に行える分かりやすいコードサンプルで学びます。"
---
## **概要**

SmartArt はノード、ノード シェイプ、レイアウトから構成された PowerPoint の図です。Aspose.Slides for Java を使用すると、SmartArt を作成し、ノードからテキストを読み取り、レイアウトを変更し、非表示ノードを検査し、組織図のレイアウトを構成し、画像組織図を作成できます。

## **SmartArt オブジェクトからテキストを取得する**

SmartArt ノードは 1 つ以上のシェイプを含むことができます。ノードシェイプからテキストを取得するには、[ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--) を反復処理し、次に [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--) が返す [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) を読み取ります。

この例では、少なくとも 1 枚のスライドが含まれ、スライド上の最初のシェイプとして SmartArt オブジェクトが配置されたプレゼンテーションが必要です。利用可能なすべてのテキスト フレームをコンソールに出力します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **SmartArt オブジェクトのレイアウト タイプを変更する**

SmartArt のレイアウトはノードの配置と接続方法を制御します。次の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) に渡す位置とサイズはポイント単位で測定されます。レイアウトを変更するには [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) を使用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **SmartArt ノードが非表示かどうかを確認する**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) は、ノードが SmartArt データモデルで非表示かどうかを示します。選択されたレイアウトがそれらを可視の図要素として表示しなくても、非表示ノードは構造内に存在する可能性があります。

次の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) の `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加されたノードの非表示状態を確認します。ノードが非表示の場合はメッセージを出力し、図を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **組織図レイアウトの取得または設定**

組織図レイアウトを使用する SmartArt ダイアグラムについては、[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) と [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) が、親ノードの下で子ノードがどのように配置されるかを定義します。たとえば、選択された [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側から吊るすように設定できます。

次の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) の `LeftHanging` 値に設定します。0 から始まるインデックス `0` が最上位ノードの最初を選択し、その子ノードは選択された配置を使用します。変更されたプレゼンテーションは保存されます。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **画像組織図を作成する**

画像組織図は、画像プレースホルダーを含む階層ダイアグラム用に設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加するときは、[SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) の `PictureOrganizationChart` 値を使用します。この例では、画像プレースホルダーを含む図を保存しますが、プレースホルダーに画像は設定しません。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **レガシーダイアグラムをシェイプのグループに変換する**

既存のプレゼンテーションをモダナイズする際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシーダイアグラムを [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/) オブジェクトとして表します。ダイアグラムをシェイプのグループに変換して個々のビジュアル要素を編集できるようにするには、[LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) を使用します。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) を参照してください。

変換は元のダイアグラムを削除せずにシェイプ コレクションに新しいグループを追加します。変換が成功したら、[IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) を使用して元のダイアグラムを削除し、重複コンテンツを防止します。シェイプの追加や削除がイテレーションを妨げないよう、変換前にレガシーダイアグラムをリストに収集してください。

次の例では、プレゼンテーションを開き、すべてのスライドを検索し、ダイアグラムをシェイプのグループに変換し、更新されたプレゼンテーションを PPTX として保存します。

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

保存されたプレゼンテーションには、変換されたレガシーダイアグラムの代わりに編集可能なシェイプのグループが含まれ、元のダイアグラムは残っていません。PowerPoint で PPTX を開き、各グループ内のテキスト、塗り、位置などの個々の要素を編集できます。

## **よくある質問**

**SmartArt は RTL 言語向けにミラーリングまたは反転をサポートしていますか？**

はい。選択された SmartArt レイアウトが反転に対応している場合、[ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) メソッドは図の方向を左から右へから右から左へ、またはその逆に切り替えます。

**SmartArt を同じスライドまたは別のプレゼンテーションにコピーして書式を保持するにはどうすればよいですか？**

SmartArt シェイプを[SmartArt シェイプをクローン](/slides/ja/java/shape-manipulations/)（[ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) を使用）でクローンするか、SmartArt を含むスライド全体を[スライド全体をクローン](/slides/ja/java/clone-slides/)でクローンできます。どちらの方法もサイズ、位置、書式を保持します。

**SmartArt をプレビューまたは Web エクスポート用にラスター画像としてレンダリングするにはどうすればよいですか？**

[スライドをレンダリング](/slides/ja/java/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換します。SmartArt はスライドの一部としてレンダリングされます。

**スライドに複数の SmartArt オブジェクトがある場合、特定の SmartArt オブジェクトを見つけるにはどうすればよいですか？**

SmartArt シェイプに固有の代替テキストまたは名前を割り当てるには、[Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) または [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) を使用し、[BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) でその値を検索し、該当するシェイプが [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/) であることを確認します。