---
title: Android でプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/androidjava/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマ設定
- テーマ変更
- テーマ管理
- 外部テーマ
- THMX
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマ効果
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用し、PowerPoint ファイルを作成、カスタマイズ、変換し、一貫したブランディングを実現するためにプレゼンテーションのマスターテーマを管理します。"
---
## **概要**

プレゼンテーションテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の調和したセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) から取得できます。プレゼンテーションは下位レベルでテーマのオーバーライドを保持することもできます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterthememanager/) によってプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) によって継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの確認、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの確認**

[MasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを確認することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイルエントリの数や内容は変わり得るからです。

次の例は、主要なテーマプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに紐づくマスターを確認し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色を変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。対応するエントリを [IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) で変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用したシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

矩形が `Accent4` にリンクされたままなので、テーマが変更された後は表示色が赤になります。シェイプ上でスキームカラーを直接の色に置き換えた場合、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用**

PowerPoint はテーマカラーに対して色変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗い色](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るい・暗いバリエーション。

次の例は、`Accent4` に基づく 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` 値から再計算されます。

### **`SchemeColor` の値を `IColorScheme` スロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これは同一テーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントを変更**

テーマフォントスキームは、見出し用の主要フォントセットと本文用の副フォントセットを含みます。`[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/)` と `[IFontScheme.getMinor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/)` がそれぞれのセットを公開します。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン文字 (Minor Latin Font)
* `+mj-lt` – 見出しフォント ラテン文字 (Major Latin Font)
* `+mn-ea` – 本文フォント 東アジア文字 (Minor East Asian Font)
* `+mj-ea` – 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、主要ラテンテーマフォントを使用した見出しと、副ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

見出しは主要フォントに従い、本文は副フォントに従います。明示的にフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

主要・副フォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、ターナ文字など、個々の表記体系向けのフォントマッピングを含めることもできます。これらのマッピングの確認、追加、置換、削除については、[スクリプト固有のテーマフォント](/slides/ja/androidjava/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/androidjava/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用**

PowerPoint テーマファイル（`.thmx`）を使用して、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) を使用します。対象マスターは [Presentation.getMasters](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) コレクション（`IMasterSlideCollection` 実装）から取得し、テーマファイルへのパスをメソッドに渡します。

メソッドが実行する操作は次のとおりです。

1. 選択したマスターを基に新しいマスタースライドを作成します。  
1. 外部テーマを新しいマスターに適用します。  
1. 選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
1. 作成された `[IMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/)` を返します。

次の例は、最初のマスターに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

無効、破損、またはサポート外のテーマは `[PptxReadException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxreadexception/)` をスローする可能性があります。ユーザーが指定したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマの適用が正常に完了した後でのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに紐づくスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに基づいて解決されますが、直接割り当てられた色やフォントなどの明示的書式は変更されないことがあります。レイアウトレベルやスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先される場合があります。

テーマが実行環境に存在しないフォントを参照していることがあります。安定した描画とエクスポートのために、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/androidjava/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/androidjava/font-substitution/) を構成してください。

これはマスターレベルの直接フローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **複数マスター プレゼンテーションで異なる外部テーマを適用**

事前に対象マスターが分からない場合は、[ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) と [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/) で代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保持してください。呼び出しごとにプレゼンテーションに新しいマスターが作成されます。

次の例は、2 つのセクションからスライドを取得し、それぞれのマスターに別々の外部テーマを適用します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

最初の呼び出しは `firstGroupMaster` に依存するスライドだけに影響し、2 回目は `secondGroupMaster` に依存するスライドだけに影響します。他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時に元テーマを保持**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて `[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/)` でスライドとクローンされたマスターをクローンしてください。これにより、マスター、レイアウト、および関連テーマが一緒にコピーされます。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

このフローは、コピー先でも元スライドと同一の外観を保つ必要がある場合に推奨されます。目的のマスターと無関係にコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまうことがあります。

### **既存スライドにテーマ値を適用**

対象スライドを現在のマスターとレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。`[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)`、`[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)`、`[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)` メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

これにより、他のスライドが継承するテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、`[OverrideTheme.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)` を呼び出してください。

### **レイアウトにテーマオーバーライドを適用**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（ただし、個別スライドに独自のオーバーライドがある場合はそちらが優先されます）。同じ初期化メソッドは `[LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslidethememanager/)` を通じても使用できます。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイリングを必要とする場合はレイアウトオーバーライドを、例外的なケースのみを対象にするならスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後の全体テーマ変更の予測を困難にします。

## **テーマの背景スタイルを更新**

テーマの背景塗りつぶしは `[IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)` に格納されています。PowerPoint の UI では、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせて、実際に格納されている塗りつぶし定義以上の背景選択肢を提示できます。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の `[Background.getStyleIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/)` を確認してください。インデックスが `0` の場合はテーマ塗りつぶしが無いことを意味し、正の値はテーマ背景スタイル参照です。これは Java コレクションのインデックス (`get_Item(0)` が最初の項目) とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

最終的に表示される結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドは変わりません。継承適用後の最終背景が必要なときは `[Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/)` を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルでのスタイル番号をハードコーディングして別ファイルで同じ見た目になると想定しないでください。テーマスタイル定義はプレゼンテーションごとに固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/androidjava/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果を更新**

テーマフォーマットスキームは、塗りつぶし、線、効果の個別コレクションを `[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)`、`[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)`、`[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)` で公開します。一般的な Office テーマは、微妙、標準、強調の 3 つの主要スタイルエントリを持つことが多いですが、コード側では固定数を想定せず各コレクションを走査してください。

![同一シェイプに適用された微妙・標準・強調のテーマ効果](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、インデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、`[IShapeStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapestyle/)` で取得します。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変わらないことがあります。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側のシャドウ（距離 10 ポイント）を有効にして結果を保存します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑に、3 番目の効果スタイルに外側シャドウが追加されます。最終的なビジュアルは、各シェイプがどのスロットを参照しているか、また直接書式がテーマを上書きしているかによって変わります。

![線、塗りつぶし、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効な単色塗りつぶしがテーマカラーを使用しているか判定する**

塗りつぶしはオブジェクトに直接設定されるか、段落、レイアウト、マスター、テーマスタイル、または他の書式レベルから継承されます。`[IFillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformat/)` を呼び出すと、階層が解決されて不変の `[IFillFormatEffectiveData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/)` が取得できます。まず `[IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/)` を確認し、`FillType.Solid` の場合にのみ単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、`[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/)` は継承・テーマ参照・色変換が適用された最終的な RGB 値を返します。`[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifillformateffectivedata/)` は `Text1` や `Accent6` などの論理的な `[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/)` スロットを返します。`SchemeColor.NotDefined` は有効な単色塗りつぶしがスキームカラーに基づいていないことを示します。テーマカラーか直接 RGB 色かで分けるワークフローでは、この値が直接 RGB 塗りつぶしを識別します。

ローカルの `[IColorFormat.getSchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorformat/)` のみで塗りつぶしを分類しないでください。たとえば、テキストの一部はローカルにスキームカラーが未定義（`NotDefined`）でも、有効塗りつぶしはテーマカラーを継承して `Text1` や `Accent6` に解決されることがあります。逆に `getSolidFillSchemeColor` はどの論理テーマスロットが最終色を生成したかを示しますが、オブジェクト・段落・レイアウト・マスター・その他のどのレベルから取得したかは示しません。

次の例はプレゼンテーションを読み込み、シェイプ塗りつぶしとテキスト部分塗りつぶしの両方を監査し、最終的な RGB 値と対応するスキームカラーを出力し、テーマカラーの変更に追従しない単色塗りつぶしをフラグ付けします。

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` の分岐は、テーマカラー スロットの変更に応答しない単色塗りつぶしの監査リストを提供します。新しいブランドパレットに合わせてプレゼンテーションを調整する際にこれらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

有効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出し、新しい `IFillFormatEffectiveData` を取得してから比較や報告を行ってください。

## **有効なテーマ値を読み取る**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/)` を呼び出します。背景の場合は `[Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/)`、塗りつぶしの場合は `[FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/)` を使用します。

次の例はスライドから有効テーマ、背景、最初のシェイプ塗りつぶしを取得します。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

有効データはレンダリング診断、検証、比較に利用してください。`[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/)` だけを確認すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドが影響を受けますか？**

いいえ。`[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/)` は選択したマスターに依存するスライドだけを再割り当てします。別のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの `[SlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidethememanager/)` を使用し、オーバーライドテーマを初期化してください。変更はそのスライドにのみ適用され、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションへ安全に持ち込む方法は？**

スライドを移動し元の外観を保持したい場合は、`[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/)` でソースマスターを宛先にクローンし、`[ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/)` でそのマスターを使用してスライドをクローンしてください。これにより、マスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値を確認するには？**

スライドまたはレイアウトテーマには `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/)` を、背景や塗りつぶしなどのフォーマットオブジェクトにはそれぞれ `[Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/)`、`[FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/)` を使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。