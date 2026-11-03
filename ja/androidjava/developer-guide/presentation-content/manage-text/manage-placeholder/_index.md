---
title: Androidでプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダーを管理
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
description: "Aspose.Slides for Android via Java を使用して、テキスト、画像、チャート、コンテンツのプレースホルダーを検査および編集し、プレースホルダー継承を理解する方法を学びます。"
---
## **概要**

プレースホルダーは、プレゼンテーションテンプレート内で特定の種類のコンテンツの位置を確保するシェイプです。一般的な例として、タイトル、本文、画像、チャート、汎用コンテンツのプレースホルダーがあります。通常のシェイプとは異なり、プレースホルダーはレイアウトスライドまたはマスタースライドから位置、サイズ、書式設定、その他の設定を継承できます。

Aspose.Slidesはプレースホルダー情報を[IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)メソッドで提供します。このメソッドは通常のシェイプの場合は`null`、それ以外の場合は[IPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)オブジェクトを返します。[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)を使用して、プレースホルダーが何を含むことを意図しているかを判断します。

シェイプインターフェイスはプレースホルダーの型を把握した後も重要です:

- 空のテキスト、画像、チャート、またはコンテンツプレースホルダーは、通常[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)で表されます。
- 画像が設定されたプレースホルダーは[IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)で表されます。
- チャートが設定されたプレースホルダーは[IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/)で表されます。
- コンテンツプレースホルダーは複数の種類のコンテンツを含むことができます。すべてのプレースホルダーが[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)であると仮定せず、[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)とランタイムのシェイプインターフェイスの両方を確認してください。

{{% alert color="warning" title="Warning" %}}
[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)はプレースホルダーの役割を示しますが、シェイプのランタイム型を保証するものではありません。テキスト、画像、チャート、テーブル、メディア固有のメンバーにアクセスする前に、必ず型チェックを行ってください。
{{% /alert %}}

## **プレースホルダー継承の理解**

プレースホルダーは階層を形成します：

1. マスタースライドは再利用可能なスタイルを定義し、場合によってはマスターレベルのプレースホルダーも定義します。
2. レイアウトスライドは1つまたは複数の通常スライドで使用される配置を定義し、マスターから継承できます。
3. 通常スライドはそのスライド用のプレースホルダーを保持し、レイアウトから継承できます。

[IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)を呼び出すと、この階層で1レベル上のプレースホルダーに移動できます。スライドのプレースホルダーは通常、レイアウトプレースホルダーを返し、レイアウトプレースホルダーはマスタープレースホルダーを返すことがあります。シェイプにベースプレースホルダーがない場合、このメソッドは`null`を返します。

以下の例は、最初のスライドのプレースホルダーを列挙し、それらのベースプレースホルダーを報告します：

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

通常スライド上でプレースホルダーを編集すると、そのスライド用のローカルオーバーライドが作成または変更されます。関連するレイアウトやマスターを編集すると、その設定を継承しているすべてのスライドに影響を及ぼす可能性があります。ローカルの通常シェイプはベースプレースホルダーを持たず、同じ座標にあるだけで継承が開始されることはありません。

## **プレースホルダーのステータスを削除する**

テンプレートを調整する際は、[IShape.removePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#removePlaceholder--)を使用して既存のオブジェクトを通常のシェイプとして保持します。その[getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getPlaceholder--)メソッドは`null`を返しますが、シェイプはスライドのコレクションに残ります。対照的に、[IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)はそのコレクションからシェイプを削除します。

次の例は、少なくとも1枚のスライドと最初のスライドに空でないテキストプレースホルダーが含まれる`template.pptx`を必要とします。レイアウトまたはマスターから書式設定を継承したプレースホルダーを使用して、関係を削除したときの効果を確認してください。例は同一のシェイプが残っていることをチェックし、普通のシェイプになった後に再度メソッドを呼び出し、結果を保存します。

{{% alert color="warning" title="Warning" %}}
プレースホルダーのステータスを削除しても、継承された外観設定が自動的に保持されるわけではありません。以下の例では設定を意図的に変更せずに残すため、出力が異なる場合があります。位置とサイズが完全に継承されたシェイプは、呼び出し後に座標とサイズがゼロになることがあり、コレクションに残っていても見えなくなることがあります。
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

        // 通常のシェイプに対してメソッドを呼び出しても効果がありません。
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

一致するプレースホルダーの場合、3つのチェックはすべて`true`を出力します。テキストは残りますが、プレースホルダーの関係が削除されると、継承された位置、サイズ、回転、フォント、段落配置、テキストフレームの余白、垂直アンカリング、塗りつぶし、線の設定が変わることがあります。例えば、継承されたタイトルの書式設定は通常のテキスト書式にフォールバックすることがあります。レイアウトの詳細については[スライド レイアウト](/slides/ja/androidjava/slide-layout/)をご参照ください。

意図した外観を保つには、呼び出し前に解決された位置、サイズ、回転を取得し、必要な実効書式設定値を個別の変数にコピーします。これらの値は[IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--)、[IParagraphFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getEffective--)、[ITextFrameFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#getEffective--)、[IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getEffective--)、[ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--)を通じて取得します。実効書式オブジェクトだけに依存しないでください。関係が削除された後にテキスト書式設定が変わる可能性があります。取得した値を普通のシェイプに明示的に適用します。フォントファミリ、サイズ、スタイル、色、段落設定、テキストフレーム設定、塗りつぶし、線など、テンプレートで使用されている設定をすべて適用してください。

継承されたシェイプのジオメトリも、[IGeometryShape.setShapeType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igeometryshape/#setShapeType-int-)で明示的に設定する必要があります。矩形テキストプレースホルダーの場合、[ShapeType.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapetype/#Rectangle)を設定することを意味します。塗りつぶしと線だけを復元しても、見える矩形が復元されないことがあります。追加効果やより複雑な書式設定を持つテンプレートでは、これらの設定も同様に処理する必要があります。

## **プレースホルダー内のテキストを変更する**

タイトル、センタリングタイトル、サブタイトル、本文、テキストのプレースホルダーは通常テキストをサポートします。[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)かどうかを確認してから、その[getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)メソッドを使用してください。

この例は、最初のスライドの最初のタイトルプレースホルダーを更新し、結果を保存します：

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

このパターンは、画像、チャート、テーブル、メディアのプレースホルダーを[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)にキャストすることを回避します。また、脆弱なシェイプインデックスに依存せず、目的でプレースホルダーを識別します。

## **レイアウト上でプロンプトテキストを設定する**

プロンプトテキストは、空のプレースホルダーに表示されるデザイン時の指示で、例えば *Click to add title* のようなものです。通常スライドのシェイプコレクションから取得しようとせず、レイアウトプレースホルダーにカスタムプロンプトテキストを設定してください。レイアウトは[ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)で取得し、[ILayoutSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/)が返すコレクションを反復処理します。

以下の例は、最初のスライドで使用されるレイアウトのタイトルとサブタイトルのプロンプトを変更します：

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

プロンプトテキストは通常のスライドコンテンツではありません。PowerPointなどの編集アプリケーションで空のプレースホルダーに表示されることを意図しています。ユーザーまたはプログラムが実際のコンテンツを提供すると、プロンプトは表示されなくなります。プロンプトを変更しても、レイアウトを使用しているスライド上の既存テキストは置き換えられません。

## **画像プレースホルダーを更新する**

扱うべきケースは2つあります：

- 画像プレースホルダーが既に設定されていて[IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)で表されている場合、[IPictureFillFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/)と[ISlidesPicture.setImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/)を使用して画像を置き換えます。
- まだ空のプレースホルダーである場合、[IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/)を使用してプレースホルダーの座標に画像フレームを追加し、空のプレースホルダーを削除します。

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

空のプレースホルダー向けに作成された置き換えは、新しいプレースホルダーではなくローカルの画像フレームです。[IShape.getPlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)にセッターがないためです。予約された位置は保持しますが、プレースホルダー固有の動作は継承しなくなります。プレースホルダーの関係を保持することが重要な場合は、まずPowerPointでプレースホルダーを用意して設定し、その後Aspose.Slidesで生成された[IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/)を更新してください。

画像の透過、トリミング、その他画像固有の効果については[画像フレームの管理](/slides/ja/androidjava/picture-frame/)をご参照ください。これらの操作は画像フレームまたは画像塗りつぶしに対するもので、プレースホルダーメタデータには関係しません。

## **チャートとコンテンツプレースホルダーの操作**

設定されたチャートプレースホルダーは[IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/)で表されます。この例はプレースホルダータイプとランタイムインターフェイスの両方でチャートを見つけ、タイトルを変更し、ファイルを保存します：

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

一般的なコンテンツプレースホルダーは通常[PlaceholderType.Object](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)を持ちます。PowerPointでは、チャート、テーブル、図、画像、メディアなど複数のコンテンツタイプの起動点として機能します。コンテンツが設定された後は、実際のシェイプインターフェイスを調べて何が含まれているかを確認してください。特化したレイアウトでは[PlaceholderType.Chart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Picture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Media](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)、[PlaceholderType.Diagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholdertype/)も公開されることがあります。

Aspose.Slidesは、[IPlaceholder.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/placeholder/)を変更しただけで空の[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/)プレースホルダーを[IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/)に変換することはできません。型はインターフェイスを通じて変更できません。空のチャートまたはコンテンツ領域にプログラムで内容を設定するには、プレースホルダーの座標に必要なオブジェクトを追加し、空のプレースホルダーを削除します。次の例はチャートに対してそれを行います：

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

追加されたチャートは普通のローカルチャートです。プレースホルダーの領域を占めますが、レイアウトプレースホルダーからは継承しません。カテゴリ、シリーズ、またはワークブックデータを置き換える必要がある場合は、専用の[チャート管理記事](/slides/ja/androidjava/powerpoint-charts/)をご利用ください。

## **完全例: テキストまたは画像コンテンツの更新**

以下のエンドツーエンドの例は、テンプレートを開き、最初のスライドでタイトルまたは画像プレースホルダーを検索し、プレースホルダーとシェイプの型を確認して適切なコンテンツを更新し、出力を保存します。この例はシェイプインデックスを仮定したり、すべてのプレースホルダーを同じインターフェイスにキャストしたりすることを意図的に回避しています。

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

## **よくある質問**

**ベースプレースホルダーとは何ですか？**

ベースプレースホルダーとは、他のプレースホルダーが継承するレイアウトまたはマスター上の対応するシェイプです。[IShape.getBasePlaceholder](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/)を使用して取得します。通常のローカルシェイプはプレースホルダー階層の一部ではないため`null`を返します。

**レイアウトプレースホルダーを編集してすべてのスライドタイトルを変更できますか？**

レイアウトを通じて継承された書式設定やプロンプトテキストは変更できますが、既存のタイトルコンテンツは通常のスライドに保存されています。プレゼンテーション全体の実際のタイトルテキストを置き換えるには、スライドを反復処理し、各タイトルプレースホルダーを更新してください。

**日付、スライド番号、ヘッダー、フッターのプレースホルダーはどう管理しますか？**

適切なスライド、レイアウト、マスター、ノート、またはハンドアウトのスコープでヘッダーおよびフッターマネージャーを使用します。完全な例については[プレゼンテーション ヘッダーとフッターの管理](/slides/ja/androidjava/presentation-header-and-footer/)をご参照ください。