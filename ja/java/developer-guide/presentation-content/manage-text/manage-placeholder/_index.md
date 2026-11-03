---
title: Java でプレゼンテーション プレースホルダーを管理する
linktitle: プレースホルダーを管理する
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
description: "Java 用 Aspose.Slides を使用して、テキスト、画像、チャート、コンテンツ プレースホルダーの検査と編集方法を学び、プレースホルダー継承を理解します。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を予約するシェイプです。代表的な例として、タイトル、本文、画像、グラフ、汎用コンテンツのプレースホルダーがあります。普通のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slides はプレースホルダー情報を [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) メソッドで提供します。このメソッドは通常のシェイプの場合は `null`、プレースホルダーの場合は [IPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) オブジェクトを返します。プレースホルダーが何を保持することを想定しているかは [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) で判定します。

プレースホルダーの種類が分かった後でも、シェイプ インターフェイスは重要です：

- 空のテキスト、画像、グラフ、またはコンテンツ プレースホルダーは一般的に [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) で表されます。
- 内容が設定された画像プレースホルダーは [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) で表されます。
- 内容が設定されたグラフプレースホルダーは [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) で表されます。
- コンテンツ プレースホルダーはさまざまな種類のコンテンツを保持できます。すべてのプレースホルダーが [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) であると仮定せず、[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) と実行時のシェイプ インターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) はプレースホルダーの役割を示しますが、シェイプの実行時型を保証するものではありません。テキスト、画像、グラフ、テーブル、またはメディア固有のメンバーにアクセスする前に必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスター レベルのプレースホルダーも定義します。
2. レイアウトスライドは 1 つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) を呼び出すと、階層を 1 レベル上に移動できます。スライドのプレースホルダーは通常、レイアウト プレースホルダーを返し、レイアウト プレースホルダーはマスター プレースホルダーを返すことがあります。シェイプにベース プレースホルダーが存在しない場合、このメソッドは `null` を返します。

以下の例は最初のスライド上のプレースホルダーを列挙し、ベース プレースホルダーを報告します：

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

通常スライドのプレースホルダーを編集すると、そのスライド用のローカル上書きが作成または変更されます。関連するレイアウトやマスターを編集すると、まだその設定を継承しているすべてのスライドに影響します。ローカルの普通シェイプはベース プレースホルダーを持たず、同じ座標にあるだけで継承が開始されるわけではありません。

## **プレースホルダーのステータスを削除する**

テンプレートを調整する際は、[IShape.removePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#removePlaceholder--) を使用して既存オブジェクトを普通のシェイプとして保持します。その [getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getPlaceholder--) メソッドは `null` を返しますが、シェイプはスライドのコレクションに残ります。これに対し、[IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) はコレクションからシェイプ自体を削除します。

以下の例は、少なくとも 1 枚のスライドと最初のスライドに空でないテキスト プレースホルダーがある `template.pptx` を前提としています。レイアウトまたはマスターから継承された書式設定を持つプレースホルダーを使用して、プレースホルダー関係を削除したときの効果を確認します。例は同じシェイプが残ることを確認し、普通シェイプになった後に再度メソッドを呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例は意図的に設定を変更せずに残しているため、出力が異なる場合があります。位置とサイズが完全に継承されているシェイプは、呼び出し後に座標と寸法が 0 になることがあり、コレクションに残っていても見えなくなります。
{{% /alert %}}

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    boolean found = false;

    for (int index = 0; index < slide.getShapes().size(); index++) {
        IShape candidate = slide.getShapes().get_Item(index);
        if (!(candidate instanceof IAutoShape)) {
            continue;
        }

        IAutoShape shape = (IAutoShape) candidate;
        ITextFrame textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || 
            textFrame == null || 
            textFrame.getText() == null || 
            textFrame.getText().isEmpty()) {
            continue;
        }

        int shapeCount = slide.getShapes().size();
        shape.removePlaceholder();

        System.out.println("Placeholder removed: " + (shape.getPlaceholder() == null));
        System.out.println("Same shape retained: " + (slide.getShapes().get_Item(index) == shape));
        System.out.println("Shape count unchanged: " + (slide.getShapes().size() == shapeCount));

        // 通常のシェイプに対してメソッドを呼び出しても効果はありません。
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

一致するプレースホルダーについては、3 つのチェックすべてが `true` を出力します。テキストは残りますが、継承された位置、サイズ、回転、フォント、段落の配置、テキスト フレームの余白、垂直アンカー、塗りつぶし、線の設定はプレースホルダー関係が削除されると変わる可能性があります。たとえば、継承されたタイトル書式は普通のテキスト書式にフォールバックします。レイアウトの詳細は [スライド レイアウト](/slides/ja/java/slide-layout/) を参照してください。

意図した外観を保持するには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な有効書式値を別の変数にコピーします。これらの値は [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--)、[IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--)、[ITextFrameFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getEffective--)、[IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getEffective--)、[ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--) から取得してください。有効書式オブジェクトだけに依存しないでください。関係が削除された後にテキスト書式の値が変わる可能性があります。取得したフォントファミリ、サイズ、スタイル、カラー、段落設定、テキスト フレーム設定、塗りつぶし、線の設定などを普通シェイプに明示的に適用します。

継承されたシェイプのジオメトリも [IGeometryShape.setShapeType](https://reference.aspose.com/slides/java/com.aspose.slides/igeometryshape/#setShapeType-int-) を使用して明示的に設定する必要があります。矩形テキスト プレースホルダーの場合、[ShapeType.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/shapetype/#Rectangle) を設定します。塗りつぶしと線だけを復元しても、見える矩形が復元されないことがあります。追加エフェクトや複雑な書式設定を持つテンプレートでは、これらの設定も同様に処理する必要があります。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキスト プレースホルダーは通常テキストをサポートします。使用前に [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) であることを確認し、[getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) メソッドを使用してください。

この例は最初のスライド上の最初のタイトル プレースホルダーを更新し、結果を保存します：

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

このパターンは画像、グラフ、テーブル、メディア プレースホルダーを [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) にキャストすることを回避します。また、脆弱なシェイプインデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウトにプロンプトテキストを設定する**

プロンプトテキストは、*クリックしてタイトルを追加* のように空のプレースホルダーに表示されるデザイン時の指示です。通常スライドのシェイプ コレクションを介さず、レイアウト プレースホルダーにカスタム プロンプトテキストを設定してください。[ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) でレイアウトを取得し、[ILayoutSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/) が返すコレクションを走査します。

以下の例は、最初のスライドで使用されているレイアウトのタイトルとサブタイトルのプロンプトを変更します：

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

プロンプトテキストは通常スライドのコンテンツではありません。PowerPoint などの編集アプリケーションで空のプレースホルダーに対して表示される指示です。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、そのレイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

処理すべきケースは 2 つあります：

- 画像プレースホルダーがすでに内容を持ち、[IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) で表されている場合は、[IPictureFillFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) と [ISlidesPicture.setImage](https://reference.aspose.com/slides/java/com.aspose.slides/islidespicture/) で画像を置き換えます。
- まだ空のプレースホルダーである場合は、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/) でプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

次の例は両方のケースをサポートし、プレゼンテーションを保存します：

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

空のプレースホルダー用に作成された置き換えはローカルの画像フレームであり、新しいプレースホルダーではありません。これは [IShape.getPlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) にセッターがないためです。位置は予約されたままですが、プレースホルダー固有の動作は継承されなくなります。プレースホルダー関係を保持することが重要な場合は、まず PowerPoint でプレースホルダーを用意・設定し、Aspose.Slides で生成された [IPictureFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframe/) を更新してください。

画像の透過、トリミング、その他の画像固有効果については [画像フレームの管理](/slides/ja/java/picture-frame/) を参照してください。これらの操作は画像フレームまたは画像塗りつぶしに対して行われ、プレースホルダーのメタデータには関係しません。

## **チャートとコンテンツプレースホルダーの操作**

内容が設定されたチャート プレースホルダーは [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) で表されます。この例はプレースホルダーの種類と実行時インターフェイスの両方でチャートを検索し、タイトルを変更してファイルを保存します：

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

汎用コンテンツ プレースホルダーは通常 [PlaceholderType.Object](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) を持ちます。PowerPoint では、チャート、テーブル、ダイアグラム、画像、メディアなど複数のコンテンツタイプの起動点として機能します。内容が設定された後は、実際のシェイプ インターフェイスを調べて何が含まれているかを判断してください。特化したレイアウトは [PlaceholderType.Chart](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/java/com.aspose.slides/placeholdertype/) を公開することがあります。

Aspose.Slides は [IPlaceholder.getType](https://reference.aspose.com/slides/java/com.aspose.slides/placeholder/) を変更しただけで、空の [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) プレースホルダーを [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) に変換しません。インターフェイスを通して型を変更することはできません。空のチャートやコンテンツ領域をプログラムで埋めるには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートについてそれを実行します：

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

追加されたチャートは普通のローカルチャートです。プレースホルダーの領域を占有しますが、レイアウトプレースホルダーからは継承しません。カテゴリ、系列、ブックデータの置き換えが必要な場合は、専用の [チャート管理記事](/slides/ja/java/powerpoint-charts/) を参照してください。

## **完全な例: テキストまたは画像コンテンツを更新する**

次のエンドツーエンド例はテンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプの種類を確認して、適切なコンテンツを更新し、出力を保存します。この例はシェイプインデックスに依存したり、すべてのプレースホルダーを同じインターフェイスにキャストしたりしないように意図的に設計されています：

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

**ベースプレースホルダーとは何ですか？**

ベースプレースホルダーとは、別のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプです。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) で取得できます。普通のローカルシェイプはプレースホルダー階層の一部ではないため `null` を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを介して継承された書式設定やプロンプトテキストは変更できますが、実際のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体のタイトルテキストを置き換えるには、スライドを走査して各タイトル プレースホルダーを更新する必要があります。

**日付、スライド番号、ヘッダー、フッタープレースホルダーはどのように管理しますか？**

適切なスライド、レイアウト、マスター、ノート、ハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用します。完全な例については [プレゼンテーションのヘッダーとフッターの管理](/slides/ja/java/presentation-header-and-footer/) を参照してください。