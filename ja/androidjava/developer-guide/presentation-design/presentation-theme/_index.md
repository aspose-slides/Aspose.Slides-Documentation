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
- テーマの設定
- テーマの変更
- テーマの管理
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
description: "Aspose.Slides for Android の Java を使用して、プレゼンテーションテーマをマスターし、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果という調和したセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/)で取得できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることも可能です。マスターは[MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterthememanager/)でプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは[BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/)で継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンを通じて解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、効果](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。これらのコレクションを変更前に検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイルエントリの数と内容は変わり得るためです。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数をレポートします。

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

ファイルが複数のマスターを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスターを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、この記事後半に示す有効テーマフローを使用してください。

## **テーマカラーの変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) の対応エントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、そして有効な塗りつぶし色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色が赤になります。シェイプ上でスキームカラーを直接の色に置き換えると、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーから明るいバリエーションや暗いバリエーションをカラー変換で生成します。Aspose.Slides はこれらの変換を[ColorTransformOperation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい・暗いカラー](additional-palette-colors.png)

**1** – メインテーマカラー。  
**2** – メインテーマカラーから生成された明るい・暗いバリエーション。

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換されたカラーは新しい `Accent4` の値から再計算されます。

### **`SchemeColor` の値を `IColorScheme` のスロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。対応は固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマフォントの変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナー フォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン (Minor Latin Font)
* `+mj-lt` – 見出しフォント ラテン (Major Latin Font)
* `+mn-ea` – 本文フォント 東アジア (Minor East Asian Font)
* `+mj-ea` – 見出しフォント 東アジア (Major East Asian Font)

次の例は、メジャー ラテンテーマフォントを使用した見出しと、マイナー ラテンテーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的にフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細情報は、[PowerPoint Fonts](/slides/ja/androidjava/powerpoint-fonts/) を参照してください。
{{% /alert %}}

## **テーマのコピーまたは適用**

一般的なワークフローは 2 つあり、解決すべき問題が異なります。

### **スライドを移動する際にソーステーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスターをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) でスライドとクローンしたマスターをクローンします。これにより、マスター、レイアウト、関連テーマが一緒に持ち込まれます。

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

ソーススライドが宛先で同じ外観になる必要がある場合に推奨されるワークフローです。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドが現在のマスターとレイアウトに留まる必要がある場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/) メソッドで 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

これにより、他のスライドが継承しているテーマは変えずに、そのスライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/) を呼び出します。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（個別スライドが独自オーバーライドを持たない限り）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslidethememanager/) を通じて使用できます。

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

多くのレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけ異なるスタイリングが必要な場合はレイアウトオーバーライドを、例外的なケースだけはスライドオーバーライドを使用してください。スライドレベルのオーバーライドが過剰になると、後のグローバルテーマ変更の予測が困難になります。

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/) に格納されています。PowerPoint の UI では、実際にコレクションに格納されている塗りつぶし定義の数以上の背景選択肢が提示されることがあります。これは UI がテーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせて表示できるためです。

![プレゼンテーションテーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、格納されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイル参照です。これは Java コレクションのインデックス (`get_Item(0)` が最初の項目) とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

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

表示結果は、マスターが参照するテーマエントリとレイアウトやスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスターの背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは [Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスと見なさないでください。また、あるファイルでハードコードしたスタイル番号を別のファイルで同じ外観と仮定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定および背景継承については、[Presentation Background](/slides/ja/androidjava/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/) を通じてそれぞれ塗りつぶし、線、効果スタイルのコレクションを公開します。典型的な Office テーマには、微妙、標準、強調という 3 つの主要スタイルエントリが含まれることが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![同一シェイプに適用された微妙、標準、強調のテーマ効果](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapestyle/) を通じて取得します。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側の影（距離 10 ポイント）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが濃い森林緑（実線）に、3 番目の効果スタイルが外側の影を持つようになります。最終的な視覚結果は、各シェイプが参照しているスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![線、塗りつぶし、影設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。 有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している値を示します。 スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を呼び出します。 背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) を使用します。

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

有効データは、レンダリング診断、検証、比較に使用してください。 [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドで最終的な外観が変わっているケースを見逃すことがあります。

## **FAQ**

**スライド単体にテーマを適用し、マスターを変更せずに済む方法はありますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。変更はそのスライドだけにローカルに適用され、他のスライドは既存のテーマを継承し続けます。

**あるプレゼンテーションから別のプレゼンテーションへテーマを確実に持ち込む最安全な方法は？**

スライドを移動して元の外観を保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスターを宛先にクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) でそのマスターを使用してスライドをクローンします。これにより、マスター、レイアウト、テーマが一体となって保持されます。

**継承とオーバーライドの後の有効値はどのように確認できますか？**

スライドまたはレイアウトテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を、フォーマットオブジェクト（例: 背景や塗りつぶし）にはそれぞれ [Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) と [FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) を使用してください。これらの API は、継承とオーバーライドが適用された後の解決済み値を返します。