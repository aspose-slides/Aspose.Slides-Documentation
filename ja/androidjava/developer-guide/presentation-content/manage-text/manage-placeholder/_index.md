---
title: Android でのプレゼンテーション プレースホルダー管理
linktitle: プレースホルダーの管理
type: docs
weight: 10
url: /ja/androidjava/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- チャート プレースホルダー
- コンテンツ プレースホルダー
- プロンプト テキスト
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android (Java) を使用して、テキスト、画像、チャート、コンテンツ プレースホルダーの検査と編集方法や、プレースホルダーの継承について学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウト スライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides は、[IShape.getPlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) メソッドを通じてプレースホルダー情報を提供します。このメソッドは、通常のシェイプの場合は `null`、それ以外の場合は [IPlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholder/) オブジェクトを返します。[IPlaceholder.getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholder/) を使用して、プレースホルダーが何を保持することを意図しているかを判断します。

プレースホルダーのタイプが分かった後でも、シェイプ インターフェイスは重要です。

- 空のテキスト、画像、チャート、またはコンテンツ プレースホルダーは、通常 [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) で表されます。
- 内容が設定された画像プレースホルダーは、[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) で表されます。
- 内容が設定されたチャートプレースホルダーは、[IChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/) で表されます。
- コンテンツ プレースホルダーは複数の種類のコンテンツを保持できます。すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であると仮定せず、[IPlaceholder.getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholder/) と実行時のシェイプ インターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholder/) はプレースホルダーの役割を示しますが、シェイプの実行時タイプを保証するものではありません。テキスト、画像、チャート、テーブル、またはメディア固有のメンバーにアクセスする前に、常にタイプチェックを行ってください。
{{% /alert %}}

## **プレースホルダーの継承を理解する**

プレースホルダーは階層構造を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスター レベルのプレースホルダーも定義します。
2. レイアウト スライドは、1 つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライドのプレースホルダーを含み、レイアウトから継承できます。

[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) を呼び出すと、この階層で一つ上のレベルに移動します。スライド プレースホルダーは通常、そのレイアウト プレースホルダーを返し、レイアウト プレースホルダーはマスター プレースホルダーを返すことができます。シェイプにベース プレースホルダーがない場合、メソッドは `null` を返します。

次の例は、最初のスライド上のプレースホルダーを列挙し、それらのベース プレースホルダーを報告します：

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

通常スライド上のプレースホルダーを編集すると、そのスライド用のローカルオーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、その設定を継承しているすべてのスライドに影響を及ぼす可能性があります。ローカルの通常シェイプにはベース プレースホルダーがなく、単に同じ座標にあるだけで継承が開始されるわけではありません。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストのプレースホルダーは通常テキストをサポートします。使用する前に、シェイプが [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) であるか確認し、[getTextFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) メソッドを呼び出します。

この例は、最初のスライド上の最初のタイトル プレースホルダーを更新し、結果を保存します：

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

このパターンは、画像、チャート、テーブル、メディアのプレースホルダーを [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) にキャストすることを回避します。また、壊れやすいシェイプ インデックスに依存するのではなく、目的によってプレースホルダーを識別します。

## **レイアウト上でプロンプト テキストを設定する**

プロンプト テキストは、空のプレースホルダーに表示されるデザイン時の指示で、たとえば *Click to add title*（タイトルを追加してください）などがあります。通常スライドのシェイプ コレクションを介して取得しようとせず、レイアウト プレースホルダーにカスタム プロンプト テキストを設定してください。レイアウトは [ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) で取得し、[ILayoutSlide.getShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseslide/) が返すコレクションを反復処理します。

次の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します：

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

プロンプト テキストは通常のスライドコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに表示されることを意図しています。ユーザーやプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存のテキストが置き換えられることはありません。

## **画像プレースホルダーを更新する**

処理すべきケースは 2 つあります：

- 画像プレースホルダーがすでに内容を持ち、[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) で表されている場合は、[IPictureFillFormat.getPicture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipicturefillformat/) と [ISlidesPicture.setImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidespicture/) を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合は、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapecollection/) を使用してプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースに対応し、プレゼンテーションを保存します：

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

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

空のプレースホルダーに対して作成された置き換えは、新しいプレースホルダーではなくローカルの画像フレームです。これは、[IShape.getPlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) に setter がないためです。予約された位置は保持されますが、プレースホルダー固有の動作は継承されなくなります。プレースホルダーとの関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを作成・内容を設定し、その後 Aspose.Slides で生成された [IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) を更新してください。

画像の透過、クロップ、その他の画像固有の効果については、[Manage Picture Frames](/slides/ja/androidjava/picture-frame/) を参照してください。これらの操作はプレースホルダーのメタデータではなく、画像フレームまたは画像塗りつぶしに属します。

## **チャートおよびコンテンツ プレースホルダーの操作**

内容が設定されたチャート プレースホルダーは、[IChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/) で表されます。この例は、プレースホルダーのタイプと実行時インターフェイスの両方でチャートを検索し、タイトルを変更してファイルを保存します：

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

一般的なコンテンツ プレースホルダーは通常、[PlaceholderType.Object](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholdertype/) を持ちます。PowerPoint では、チャート、テーブル、ダイアグラム、画像、メディアなど複数のコンテンツタイプの起動装置として機能します。内容が設定された後は、実際のシェイプ インターフェイスを調べて何が含まれているかを確認してください。特殊なレイアウトでは、[PlaceholderType.Chart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholdertype/)、または [PlaceholderType.Diagram](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholdertype/) を公開することもあります。

Aspose.Slides は、[IPlaceholder.getType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/placeholder/) を変更しただけで空の [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) プレースホルダーを [IChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/) に変換することはできません。インターフェイスを通じてタイプを変更することはできません。空のチャートまたはコンテンツ領域にプログラムでデータを入れるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを行います：

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

追加されたチャートは通常のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウト プレースホルダーから継承はしません。カテゴリ、系列、またはブックデータを置き換える必要がある場合は、専用の [chart management articles](/slides/ja/androidjava/powerpoint-charts/) を使用してください。

## **完全な例：テキストまたは画像コンテンツの更新**

次のエンドツーエンドの例は、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプのタイプを確認し、適切なコンテンツを更新して出力を保存します。この例は、シェイプ インデックスを仮定したり、すべてのプレースホルダーを同じインターフェイスにキャストしたりすることを意図的に回避しています。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

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
            IPPImage image;
            try (FileInputStream imageStream = new FileInputStream("replacement.png")) {
                image = presentation.getImages().addImage(imageStream);
            }

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

**ベース プレースホルダーとは何ですか？**

ベース プレースホルダーは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプです。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) を使用して取得します。通常のローカルシェイプはプレースホルダー階層の一部ではないため、`null` を返します。

**レイアウト プレースホルダーを編集してすべてのスライドのタイトルを変更できますか？**

レイアウトを介して継承された書式設定やプロンプト テキストは変更できますが、既存のタイトル コンテンツは通常のスライドに保存されています。プレゼンテーション全体の実際のタイトル テキストを置き換えるには、スライドを走査して各タイトル プレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、または配布資料のスコープでヘッダーおよびフッター管理機能を使用します。完全な例については、[Manage Presentation Header and Footer](/slides/ja/androidjava/presentation-header-and-footer/) を参照してください。