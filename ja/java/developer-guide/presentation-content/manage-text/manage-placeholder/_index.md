---
title: Java でのプレゼンテーション プレースホルダーの管理
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/java/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- チャート プレースホルダー
- コンテンツ プレースホルダー
- プロンプト テキスト
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、テキスト、画像、チャート、コンテンツ プレースホルダーの検査と編集方法を学び、プレースホルダーの継承を理解します。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。代表的な例として、タイトル、本文、画像、グラフ、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウト スライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[IShape.getPlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) メソッドを通じてプレースホルダー情報を提供します。このメソッドは、通常のシェイプの場合は `null`、プレースホルダーの場合は [IPlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholder/) オブジェクトを返します。プレースホルダーが何を保持することを意図しているかは、[IPlaceholder.getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholder/) で確認してください。

プレースホルダーのタイプが分かった後でもシェイプ インターフェイスは重要です。

- 空のテキスト、画像、グラフ、コンテンツのプレースホルダーは通常、[IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) で表されます。
- 画像が設定されたプレースホルダーは [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) で表されます。
- グラフが設定されたプレースホルダーは [IChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/) で表されます。
- コンテンツ プレースホルダーはさまざまな種類のコンテンツを保持できます。すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) であると想定せず、[IPlaceholder.getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholder/) と実行時シェイプ インターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholder/) はプレースホルダーの役割を示しますが、シェイプの実行時型を保証するものではありません。テキスト、画像、グラフ、テーブル、メディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー 継承の理解**

プレースホルダーは階層構造を持ちます。

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは 1 つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) を呼び出すと、階層の1つ上のプレースホルダーに移動できます。スライドのプレースホルダーは通常、レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返す可能性があります。シェイプに基底プレースホルダーがない場合は `null` が返ります。

次の例は、最初のスライドのプレースホルダーを列挙し、それらの基底プレースホルダーを報告します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        String typeName = shape.getClass().getSimpleName();
        String slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape interface: " + typeName;
        System.out.println(slidePlaceholderMessage);

        IShape layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            IPlaceholder layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            Byte layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            String layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            System.out.println(layoutPlaceholderMessage);

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                IPlaceholder masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                Byte masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                String masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                System.out.println(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

通常スライド上のプレースホルダーを編集すると、そのスライド固有のローカル上書きが作成または変更されます。関連するレイアウトまたはマスターを編集すると、まだ継承設定を持つすべてのスライドに影響を与えます。通常のローカル シェイプは基底プレースホルダーを持たず、同じ座標に配置されただけで継承が開始されることはありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタードタイトル、サブタイトル、本文、テキスト プレースホルダーは通常テキストをサポートします。テキストを取得する前に、シェイプが [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) であるか確認し、[getTextFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) メソッドを使用してください。

この例は、最初のスライドの最初のタイトル プレースホルダーを更新し、結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape titleShape = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            titleShape = autoShape;
            break;
        }
    }

    if (titleShape == null) {
        throw new IllegalStateException("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

このパターンは、画像、グラフ、テーブル、メディア プレースホルダーを [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) にキャストすることを回避します。また、脆弱なシェイプ インデックスに依存せず、目的別にプレースホルダーを識別します。

## **レイアウト上のプロンプト テキストを設定する**

プロンプト テキストは、空のプレースホルダーに表示されるデザイン時の指示です（例: *Click to add title*）。通常スライドのシェイプ コレクションを介して取得しようとせず、レイアウト プレースホルダーにカスタム プロンプト テキストを設定してください。[ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) でレイアウトにアクセスし、[ILayoutSlide.getShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseslide/) が返すコレクションを走査します。

次の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getSlides().get_Item(0).getLayoutSlide();

    for (IShape shape : layoutSlide.getShapes()) {
        if (!(shape instanceof IAutoShape)) {
            continue;
        }

        IAutoShape autoShape = (IAutoShape) shape;
        IPlaceholder placeholder = autoShape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if (placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) {
            autoShape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType == PlaceholderType.Subtitle) {
            autoShape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

プロンプト テキストは通常スライドのコンテンツではなく、PowerPoint などの編集アプリケーションで空のプレースホルダーに表示されるものです。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、そのレイアウトを使用しているスライド上の既存テキストは置き換わりません。

## **画像プレースホルダーを更新する**

処理すべきケースは 2 つあります。

- 画像プレースホルダーがすでに設定されていて [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) で表されている場合は、[IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipicturefillformat/) と [ISlidesPicture.setImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidespicture/) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapecollection/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("picture-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape picturePlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a picture placeholder.");
    }

    Path imagePath = Paths.get("replacement.png");
    byte[] imageBytes = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageBytes);

    if (picturePlaceholder instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) picturePlaceholder;
        pictureFrame.getPictureFormat().getPicture().setImage(image);
    } else {
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, picturePlaceholder.getX(), picturePlaceholder.getY(), picturePlaceholder.getWidth(), picturePlaceholder.getHeight(), image);
        slide.getShapes().remove(picturePlaceholder);
    }

    presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

空のプレースホルダーに対して作成された置き換えはローカルの画像フレームであり、新しいプレースホルダーではありません。これは、[IShape.getPlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) にセッターがないためです。位置は確保されたままですが、プレースホルダー固有の継承動作は失われます。プレースホルダーとの関係を保持する必要がある場合は、まず PowerPoint でプレースホルダーを用意してから、Aspose.Slides で生成された [IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipictureframe/) を更新してください。

画像の透過、トリミング、その他画像固有の効果については、[Manage Picture Frames](/slides/ja/java/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像塗りつぶしに対して行い、プレースホルダーのメタデータには関係しません。

## **グラフおよびコンテンツ プレースホルダーの操作**

設定済みのグラフプレースホルダーは [IChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/) で表されます。この例は、プレースホルダータイプと実行時インターフェイスの両方でグラフを検索し、タイトルを変更してファイルを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart placeholderChart = null;

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IPlaceholder placeholder = chart.getPlaceholder();
        if (placeholder != null && placeholder.getType() == PlaceholderType.Chart) {
            placeholderChart = chart;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new IllegalStateException("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

汎用コンテンツ プレースホルダーは通常、[PlaceholderType.Object](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholdertype/) を持ちます。PowerPoint では、グラフ、テーブル、ダイアグラム、画像、メディアなど、複数のコンテンツ タイプのランチャーとして機能します。コンテンツが設定された後は、実際のシェイプ インターフェイスを調べて何が含まれているかを判断してください。専用レイアウトは [PlaceholderType.Chart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholdertype/) も公開できます。

Aspose.Slides は、[IPlaceholder.getType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/placeholder/) を変更しただけで、空の [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iautoshape/) プレースホルダーを [IChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ichart/) に変換しません。インターフェイスを通して型を変更することはできません。空のグラフやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はグラフに対してそれを行います。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("content-template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape targetPlaceholder = null;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();
        if (placeholderType == PlaceholderType.Chart || placeholderType == PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new IllegalStateException("The first slide does not contain a chart or content placeholder.");
    }

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, targetPlaceholder.getX(), targetPlaceholder.getY(), targetPlaceholder.getWidth(), targetPlaceholder.getHeight());
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    slide.getShapes().remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

追加されたグラフはローカルの通常グラフであり、プレースホルダー領域を占有しますが、レイアウト プレースホルダーからは継承しません。カテゴリ、系列、ブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/java/powerpoint-charts/) を参照してください。

## **完全例: テキストまたは画像コンテンツの更新**

次のエンドツーエンド例は、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプの型を確認して適切なコンテンツを更新し、出力を保存します。この例はシェイプ インデックスに依存したり、すべてのプレースホルダーを同じインターフェイスにキャストしたりしないよう意図的に設計されています。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean updated = false;

    for (IShape shape : slide.getShapes()) {
        IPlaceholder placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        byte placeholderType = placeholder.getType();

        if ((placeholderType == PlaceholderType.Title || placeholderType == PlaceholderType.CenteredTitle) && shape instanceof IAutoShape) {
            IAutoShape titleShape = (IAutoShape) shape;
            titleShape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType == PlaceholderType.Picture) {
            Path imagePath = Paths.get("replacement.png");
            byte[] imageBytes = Files.readAllBytes(imagePath);
            IPPImage image = presentation.getImages().addImage(imageBytes);

            if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                pictureFrame.getPictureFormat().getPicture().setImage(image);
            } else {
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image);
                slide.getShapes().remove(shape);
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new IllegalStateException("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**基底プレースホルダーとは何ですか？**

基底プレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応シェイプです。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishape/) を使用して取得します。通常のローカル シェイプはプレースホルダー階層の一部ではないため、`null` が返ります。

**レイアウト プレースホルダーを編集してすべてのスライドのタイトルを変更できますか？**

レイアウトを介して継承された書式やプロンプトテキストは変更できますが、実際のタイトル コンテンツは通常スライドに保存されています。プレゼンテーション全体のタイトル テキストを置き換えるには、スライドを走査して各タイトル プレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどう管理しますか？**

適切なスライド、レイアウト、マスター、ノート、ハンドアウトのスコープでヘッダーおよびフッター マネージャーを使用します。完全なサンプルは [Manage Presentation Header and Footer](/slides/ja/java/presentation-header-and-footer/) を参照してください。