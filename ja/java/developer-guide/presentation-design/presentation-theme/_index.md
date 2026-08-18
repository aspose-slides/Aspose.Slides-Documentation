---
title: Java でプレゼンテーションテーマを管理する
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/java/presentation-theme/
keywords:
- PowerPoint テーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマの設定
- テーマの変更
- テーマの管理
- テーマカラー
- 追加パレット
- テーマフォント
- テーマスタイル
- テーマエフェクト
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java でマスタープレゼンテーションテーマを使用し、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗り、線、エフェクトなどの調和したセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保存する代わりに、これらの共有定義を参照するため、テーマを変更すると多くのオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) で取得できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスタは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/masterthememanager/) を介してプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を介して継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます。プレゼンテーションテーマ、マスタオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景とエフェクトスタイルの更新、継承とオーバーライドが解決された後の有効値の読み取りです。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイルエントリの数や内容はファイルごとに異なる可能性があります。

次の例は、メインテーマのプロパティを読み取り、テーマに保存されている背景、塗り、線、エフェクトスタイルの数を報告します。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
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

ファイルが複数のマスタを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスタを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマワークフローを使用してください。

## **テーマの色を変更する**

テーマ対応の塗り、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) の対応エントリを変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りの色を出力します。

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色が赤になります。シェイプ上で直接色を設定してスキームカラーを置き換えると、以後の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマカラーから明るい色と暗い色のバリエーションを色変換で導出します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい色・暗い色](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るい色と暗い色のバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用して結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。後で `Accent4` が変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントを変更する**

テーマのフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/) メソッドでこれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン文字 (Minor Latin Font)
* `+mj-lt` - 見出しフォント ラテン文字 (Major Latin Font)
* `+mn-ea` - 本文フォント 東アジア文字 (Minor East Asian Font)
* `+mj-ea` - 見出しフォント 東アジア文字 (Major East Asian Font)

次の例は、メジャーラテンテーマフォントを使用した見出しと、マイナーラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変わっても自動的に切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーション フォントの詳細については、[PowerPoint Fonts](/slides/ja/java/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

2 つの一般的なワークフローがあり、解決する課題が異なります。

### **スライド移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) でソースマスタをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) でスライドとクローンしたマスタをクローンします。これによりマスタ、レイアウト、関連テーマが一緒にコピーされます。

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

この方法は、ソーススライドが宛先でも同じ外観になる必要がある場合に推奨されます。無関係な宛先マスタにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わる可能性があります。

### **既存スライドにテーマの値を適用する**

対象スライドが現在のマスタとレイアウトに留まる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/) メソッドで 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

この操作により、そのスライドだけのテーマが変更され、他のスライドが継承しているテーマは変わりません。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されます（ただし、個別スライドに独自のオーバーライドがある場合は例外）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslidethememanager/) 経由でも利用できます。

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスタまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ異なるスタイルが必要な場合はレイアウトオーバーライドを、例外的なケースだけはスライドオーバーライドを使用します。過度なスライドレベルのオーバーライドは、後からの全体テーマ変更を予測しにくくします。

## **テーマの背景スタイルを更新する**

テーマの背景塗りは [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/) に格納されています。PowerPoint の UI は、このコレクションに物理的に格納されている塗り定義の数以上の背景選択肢を提示できます。これは UI がテーマ塗りとテーマカラー、他のスタイル参照を組み合わせられるためです。

![プレゼンテーションテーマの PowerPoint 背景スタイルギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りなしを意味し、正の値はテーマ背景スタイル参照です。これは Java コレクションを直接インデックス付けした場合の `get_Item(0)`（最初の項目）とは異なります。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限りません。

次の例は利用可能な背景塗りの数を報告し、最初のマスタにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果はマスタが参照しているテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスタ背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは [Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスを 0 ベースのコレクションインデックスとして扱わないでください。また、あるファイルでのスタイル番号をハードコーディングして別のファイルで同じ見た目になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承の詳細は、[Presentation Background](/slides/ja/java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマのエフェクトを更新する**

テーマのフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/) を通じて個別の塗り、線、エフェクトスタイルコレクションを公開します。一般的な Office テーマは、微妙、適度、強烈な 3 つの主要スタイルエントリを視覚的に持つことが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![同じ形状に適用された微妙、適度、強烈なテーマエフェクト](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスは 0 ベースです。`get_Item(0)` が最初の格納スタイル、`get_Item(2)` が3番目のスタイルを指します。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapestyle/) に公開されています。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されないままです。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りスタイルを変更し、3 番目のエフェクトスタイルに外側の影（距離 10 ポイント）を有効にして結果を保存します。

これらのスロットを参照しているシェイプに対しては、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森林緑に、3 番目のエフェクトスタイルに外側の影が追加されます。最終的な見た目は、各シェイプが参照しているスタイルスロットや直接書式設定の有無に依存します。

![線、塗り、影設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **有効なテーマ値を読み取る**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/)、塗りの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/) を使用します。

```java
import com.aspose.slides.*;

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
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

レンダリング診断、検証、比較のために有効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) だけを検査すると、マスタ、レイアウト、スライド、シェイプのオーバーライドによって最終的な外観が変わっているケースを見逃す可能性があります。

## **よくある質問**

**単一のスライドにだけテーマを適用し、マスタを変更しない方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidethememanager/) を使用し、そのオーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む方法は？**

スライドを移動して元の外観を保持する場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) でソースマスタを宛先にクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) でそのマスタを使ってスライドをクローンします。これによりマスタ、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値を確認するには？**

スライドまたはレイアウトテーマに対しては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を使用し、[Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/) などのフォーマットオブジェクト向けの対応する有効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。