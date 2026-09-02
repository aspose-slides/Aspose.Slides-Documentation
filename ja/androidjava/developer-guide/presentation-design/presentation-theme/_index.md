---
title: Androidでプレゼンテーションテーマを管理
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
description: "Aspose.Slides for Android を Java で使用し、PowerPoint ファイルを作成、カスタマイズ、変換し、一貫したブランディングを実現するためのプレゼンテーションテーマの管理。"
---
## **概要**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の統一されたセットを定義します。テーマ対応オブジェクトは、すべての視覚プロパティを固定値として保存する代わりに、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) から取得できます。プレゼンテーションには下位レベルでテーマのオーバーライドを含めることもできます。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterthememanager/) によってプレゼンテーションテーマを上書きでき、レイアウトまたは個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) によって継承されたテーマを上書きできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマの構成要素：色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の読み取りです。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) および [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) を介してテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合、スタイルエントリの数と内容が異なる可能性があるため特に有用です。

次の例は、メインテーマプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマワークフローを使用してください。

## **テーマカラーの変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。対応するエントリを [IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) で変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存、再オープンし、有効な塗りつぶし色を出力します。

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

四角形は `Accent4` にリンクされたままなので、テーマが変更されると表示色は赤になります。シェイプ上でスキームカラーを直接色に置き換えると、その後の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーから色変換を適用して明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗いカラー](additional-palette-colors.png)

**1** - メインテーマカラー。

**2** - メインテーマカラーから生成された明るい・暗いバリエーション。

次の例は、`Accent4` を基にした 6 つの矩形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn‑lt` - 本文フォント Latin（Minor Latin Font）
* `+mj‑lt` - 見出しフォント Latin（Major Latin Font）
* `+mn‑ea` - 本文フォント East Asian（Minor East Asian Font）
* `+mj‑ea` - 見出しフォント East Asian（Major East Asian Font）

次の例は、メジャー Latin テーマフォントを使用する見出しと、マイナー Latin テーマフォントを使用する本文行をそれぞれ作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的には切り替わりません。

メジャーおよびマイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、サーナ文字など、個別の書字システム用のフォントマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法については、[Script‑Specific Theme Fonts](/slides/ja/androidjava/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="ヒント" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/androidjava/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

2 つの一般的なワークフローがあり、解決すべき問題が異なります。

### **スライド移動時に元のテーマを保持**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) でそのクローンマスターを使用してスライドをクローンします。これにより、マスター、レイアウト、および関連するテーマが一緒にコピーされます。

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

この方法は、ソーススライドが宛先でも同じ外観である必要がある場合に推奨されます。無関係な宛先マスターにコンテンツのみをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまうことがあります。

### **既存スライドにテーマ値を適用**

対象スライドが現在のマスターとレイアウトにとどまる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、そのスライドだけのテーマが変更され、他のスライドが継承しているテーマはそのままです。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されます。ただし、特定のスライドが独自のオーバーライドを持つ場合は例外です。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslidethememanager/) を通じて使用できます。

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

多数のレイアウトやスライドが同じ基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、あるレイアウトファミリーだけが異なるスタイリングを必要とする場合はレイアウトオーバーライドを、真の例外に対してのみスライドオーバーライドを使用してください。過度なスライドレベルのオーバーライドは、後の全体テーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/) に格納されます。PowerPoint の UI では、このコレクションに実際に保存されている塗りつぶし定義の数以上の背景選択肢を提示できるのは、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせることができるからです。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を検査してください。スタイルインデックスが `0` の場合はテーマ塗りつぶしが無いことを示し、正の値はテーマ背景スタイル参照です。これは Java コレクションのインデックスとは異なり、`get_Item(0)` が最初の保存アイテムを意味します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

次の例は利用可能な背景塗りつぶし数を報告し、最初のマスターにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を持つ場合、マスター背景だけを変更してもそのスライドは変わらないことがあります。継承後の最終背景が必要なときは、[Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="警告" %}}
スタイルインデックスをゼロベースのコレクションインデックスとみなさないでください。また、あるファイルから取得したスタイル番号をハードコードして別のファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="ヒント" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/androidjava/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/) を通じて個別の塗りつぶし、線、効果スタイルコレクションを公開します。典型的な Office テーマは、微妙、標準、強調という視覚的に異なる 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を想定せず各コレクションを検査すべきです。

![同一シェイプに適用された微妙・標準・強調のテーマ効果](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスは zero‑based です。`get_Item(0)` が最初の保存スタイル、`get_Item(2)` が 3 番目のスタイルを指します。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapestyle/) を通じて取得できます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外部シャドウ（距離 10 ポイント）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプに対しては、最初のテーマ線スタイルが赤、3 番目のテーマ塗りつぶしスタイルがソリッドの森林緑、3 番目の効果スタイルが距離 10 ポイントの外部シャドウを持ちます。最終的な見た目は、各シェイプが参照しているスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効テーマ値の読み取り**

生のテーマオブジェクトは特定レベルで定義された内容を示しますが、有効値は継承とローカルオーバーライドが解決された後にスライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/)、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプの塗りつぶしを読み取ります。

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

有効データはレンダリング診断、検証、比較に使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終的な外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**単一スライドにテーマを適用し、マスターを変更せずに済む方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化してください。この変更はそのスライドだけにローカルに適用され、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを安全に持ち込む最善の方法は何ですか？**

スライドを移動して元の外観を保持する場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスターを宛先にクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) でそのマスターを使用してスライドをクローンしてください。これにより、マスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効値はどのように確認できますか？**

スライドまたはレイアウトテーマに対しては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を使用し、背景や塗りつぶしなどのフォーマットオブジェクトに対してはそれぞれ [Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) と [FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) を使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。