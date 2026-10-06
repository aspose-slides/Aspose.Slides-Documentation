---
title: Android上のPowerPointプレゼンテーションでSmartArtを管理する
linktitle: SmartArtの管理
type: docs
weight: 10
url: /ja/androidjava/manage-smartart/
keywords:
- スマートアート
- スマートアート テキスト
- レイアウト タイプ
- 非表示 プロパティ
- 組織図
- 画像組織図
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用し、明確な Java コードサンプルで PowerPoint の SmartArt を作成および編集する方法を学び、スライドのデザインと自動化を高速化します。"
---
## **概要**

SmartArt は、ノード、ノード シェイプ、レイアウトで構成された PowerPoint の図です。Aspose.Slides for Android via Java を使用すると、SmartArt の作成、ノードからのテキストの取得、レイアウトの変更、非表示ノードの検査、組織図レイアウトの構成、画像組織図の作成ができます。

## **SmartArt オブジェクトからテキストを取得**

SmartArt のノードは 1 つ以上のシェイプを含むことができます。ノード シェイプからテキストを取得するには、[ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--) を反復処理し、次に [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) が返す [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) を読み取ります。

この例では、少なくとも 1 枚のスライドが含まれ、該当スライドの最初のシェイプとして SmartArt オブジェクトが配置されたプレゼンテーションが必要です。利用可能な各テキスト フレームをコンソールに出力します。

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

## **SmartArt オブジェクトのレイアウト タイプを変更**

SmartArt のレイアウトは、ノードの配置と接続方法を制御します。以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) の `BasicBlockList` 値で SmartArt オブジェクトを作成し、`BasicProcess` 値に変更してプレゼンテーションを保存します。[IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) に渡す位置とサイズはポイント単位で測定されます。レイアウトを変更するには [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) を使用します。

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

## **SmartArt ノードが非表示かどうかを確認**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) は、SmartArt データモデル内でノードが非表示かどうかを示します。選択したレイアウトで可視的な図要素として表示されなくても、非表示ノードは構造内に存在する可能性があります。

以下の例では、[SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` 値を使用する SmartArt オブジェクトにノードを追加し、追加されたノードの非表示状態をチェックします。ノードが非表示の場合はメッセージをコンソールに出力し、図を保存します。

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

組織図レイアウトを使用する SmartArt ダイアグラムでは、[ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) と [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) が、親ノード下の子ノードの配置方法を定義します。たとえば、選択した [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) に応じて、子ノードを左側、右側、または両側に吊り下げるように設定できます。

以下の例では、組織図を作成し、最初のノードのレイアウトを [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` に設定します。ゼロベースのインデックス `0` が最上位ノードを指し、その子ノードは選択された配置を使用します。変更後のプレゼンテーションを保存します。

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

## **画像組織図の作成**

画像組織図は、画像プレースホルダーを含む階層ダイアグラム向けに設計された SmartArt レイアウトです。スライドに SmartArt オブジェクトを追加する際に、[SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` 値を使用します。この例は画像プレースホルダーを含む図を保存しますが、プレースホルダーに画像は設定しません。

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

## **レガシー ダイアグラムをシェイプ グループに変換**

既存のプレゼンテーションを最新化する際、PowerPoint 97–2003 で作成された組織図を更新する必要がある場合があります。Aspose.Slides はこれらのレガシー ダイアグラムを [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) オブジェクトとして表します。[LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) を使用してダイアグラムをシェイプのグループに変換し、個別のビジュアル要素を編集できるようにします。詳細は [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) を参照してください。

変換は元のダイアグラムを削除せずにシェイプコレクションに新しいグループを追加します。変換に成功したら、[IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) で元のダイアグラムを削除し、重複コンテンツを防ぎます。シェイプの追加・削除がイテレーションを乱さないよう、変換前にレガシー ダイアグラムをリストに収集しておきます。

以下の例はプレゼンテーションを開き、すべてのスライドを検索してダイアグラムをシェイプ グループに変換し、更新されたプレゼンテーションを PPTX として保存します。

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

保存されたプレゼンテーションには、変換されたレガシー ダイアグラムの代わりに編集可能なシェイプ グループが含まれ、元のダイアグラムは残りません。PowerPoint で PPTX を開き、各グループ内のテキスト、塗りつぶし、位置などの個別要素を編集できます。

## **よくある質問**

**Does SmartArt support mirroring or reversing for RTL languages?**  
はい。選択した SmartArt レイアウトが反転に対応している場合、[ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) メソッドにより、図の方向を左から右へ、または右から左へ（逆も可）に切り替えることができます。

**How can I copy SmartArt to the same slide or to another presentation while preserving formatting?**  
[ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) を使用して [clone the SmartArt shape](/slides/ja/androidjava/shape-manipulations/) するか、SmartArt を含むスライド全体を [clone the whole slide](/slides/ja/androidjava/clone-slides/) してコピーできます。どちらの方法でもサイズ、位置、書式が保持されます。

**How do I render SmartArt to a raster image for preview or web export?**  
[Render the slide](/slides/ja/androidjava/convert-powerpoint-to-png/) またはプレゼンテーション全体を PNG または JPEG に変換してください。SmartArt はスライドの一部としてレンダリングされます。

**How can I find a specific SmartArt object on a slide if there are several?**  
[Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) または [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) を使用して SmartArt シェイプに固有の代替テキストまたは名前を設定し、[BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) でその値を検索します。その後、該当シェイプが [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/) であることを確認します。