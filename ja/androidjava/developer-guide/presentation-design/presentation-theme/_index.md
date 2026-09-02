---
title: Android でプレゼンテーションテーマを管理する
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
description: "Aspose.Slides for Android のマスタープレゼンテーションテーマを Java 経由で作成、カスタマイズ、変換し、一貫したブランドイメージを持つ PowerPoint ファイルを扱う。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の調和の取れたセットを定義します。テーマ対応オブジェクトは、各視覚プロパティを固定値として格納する代わりに、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) で利用できます。プレゼンテーションは下位レベルでもテーマのオーバーライドを保持できます。マスタは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/masterthememanager/) を使用してプレゼンテーションテーマをオーバーライドでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を使用して継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンを通じて解決されます：プレゼンテーションテーマ → マスターオーバーライド → レイアウトオーバーライド → スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作フローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/mastertheme/) を通じてテーマのカラー スキーム、フォント スキーム、フォーマット スキームを公開します。変更前にこれらのコレクションを検査すると、外部ソースから取得したプレゼンテーションでエントリ数や内容が異なる可能性があるため特に有用です。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、効果スタイルの数を報告します。

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

ファイルが複数のマスタを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスタを検査し、レイアウトまたはスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマフローを使用してください。

## **テーマの色を変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。対応するエントリを [IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) で変更すると、まだそのテーマ色を参照しているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマ色の更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存、再度開いて有効な塗りつぶし色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマが変更された後に表示色が赤になります。シェイプ上で直接色に置き換えた場合、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットから色を使用する**

PowerPoint はテーマ色から明るい・暗いバリエーションを色変換により生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** – メインテーマカラー。

**2** – メインテーマカラーから生成された明るい・暗いバリエーション。

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

### **`SchemeColor` の値を `IColorScheme` のスロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントを変更**

テーマフォント スキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifontscheme/) メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` – 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` – 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` – 見出しフォント East Asian（メジャー East Asian フォント）

次の例は、メジャー Latin テーマフォントを使用した見出しと、マイナー Latin テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォント スキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーフォント コレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、タナ文字など個別の書字システム向けのフォントマッピングも含めることができます。これらのマッピングを検査、追加、置換、削除する方法については、[Script-Specific Theme Fonts](/slides/ja/androidjava/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}

プレゼンテーション フォントの詳細については、[PowerPoint Fonts](/slides/ja/androidjava/powerpoint-fonts/) をご覧ください。

{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマを特定のマスタに依存するスライドに適用する**

PowerPoint テーマ ファイル（`.thmx`）があり、特定のマスタに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) を使用します。対象のマスタは [Presentation.getMasters](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) コレクション（[IMasterSlideCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) 実装）から取得し、テーマファイルのパスをメソッドに渡します。

メソッドは次の操作を行います。

1. 選択したマスタを基に新しいマスタスライドを作成します。
1. 外部テーマを新しいマスタに適用します。
1. 以前に選択したマスタに依存していたすべてのスライドに新しいマスタを割り当てます。
1. 作成された [IMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) を返します。

次の例は、最初のマスタに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

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

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが提供したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

選択したマスタに依存していたスライドだけが再割り当てされます。他のマスタに関連付けられたスライドは既存のマスタとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されます。直接指定された色、フォント、塗りつぶしなどの明示的な書式は変更されない場合があります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスタから継承された値よりも優先されることがあります。

テーマが実行環境に存在しないフォントを参照している可能性があります。一貫したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/androidjava/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/androidjava/font-substitution/) を構成してください。

これはマスタレベルの直接ワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタ プレゼンテーションで異なる外部テーマを適用する**

対象マスタが事前に分からない場合は、[ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islide/) と [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilayoutslide/) で代表的なスライドから取得します。テーマを適用する前に元のマスタ参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスタが作成されます。

次の例は、2 つのセクションのスライドからそれぞれのマスタを取得し、各グループに別々の外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドだけに影響し、2 回目の呼び出しは `secondGroupMaster` に依存するスライドだけに影響します。他のマスタに属するスライドは再スタイル化されません。

### **スライドを移動するときに元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスタをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) でスライドとクローンされたマスタをクローンします。これによりマスタ、レイアウト、テーマが一緒に転送されます。

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

この手順は、スライドの外観を宛先でも同一に保つ推奨ワークフローです。無関係な宛先マスタにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変更される可能性があります。

### **既存のスライドにテーマ値を適用する**

対象スライドを現在のマスタやレイアウトのままにしたい場合は、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により他のスライドが継承しているテーマは変わらず、対象スライドだけのテーマが変更されます。ローカルのオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライド全体に適用されます（個別スライドが独自のオーバーライドを持たない限り）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/layoutslidethememanager/) 経由でも使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスタまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが別スタイルを必要とする場合はレイアウトオーバーライドを、例外的なケースだけはスライドオーバーライドを使用してください。スライドレベルのオーバーライドが過剰になると、後続のグローバルテーマ変更の予測が難しくなります。

## **テーマの背景スタイルを更新する**

テーマの背景塗りつぶしは [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/) に格納されています。PowerPoint の UI では、テーマ塗りつぶしとテーマカラーや他のスタイル参照を組み合わせて、実際に格納されている定義数以上の背景選択肢を提示できます。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、格納されているコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を確認してください。インデックス `0` はテーマ塗りつぶしなしを意味し、正の値はテーマ背景スタイルへの参照です。これは Java コレクションのインデックスとは異なり、`get_Item(0)` が最初の格納アイテムを指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

次の例は、利用可能な背景塗りつぶし数を報告し、最初のマスタにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

最終的な見た目は、マスタが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスタの背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは、[Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}

スタイルインデックスをゼロベースのコレクションインデックスとみなさないでください。また、あるファイルから取得したスタイル番号を別のファイルでハードコーディングして同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/androidjava/presentation-background/) を参照してください。

{{% /alert %}}

## **テーマ効果を更新する**

テーマフォーマット スキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iformatscheme/) を通じてそれぞれの塗りつぶし、線、効果スタイル コレクションを公開します。一般的な Office テーマは、微妙、適度、強烈なフォーマットに視覚的に対応する 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を前提にせず各コレクションを検査すべきです。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです。`get_Item(0)` が最初の格納スタイル、`get_Item(2)` が 3 番目です。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishapestyle/) で公開されます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変わりません。

次の例は、必要なスタイルエントリが存在することを確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側シャドウを有効化して結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが実線のフォレストグリーンに、3 番目の効果スタイルに距離 10 ポイントの外側シャドウが追加されます。最終的な視覚結果は、各シェイプが参照しているスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **有効なテーマ値を取得する**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。継承とローカルオーバーライドが解決された後にスライドやシェイプが実際に使用している値は「有効」値です。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/)、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプの塗りつぶしを取得します。

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

有効データはレンダリング診断、検証、比較に使用します。[Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) のみを検査すると、マスタ、レイアウト、スライド、シェイプのオーバーライドによって最終外観が変わるケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション全体のスライドが変更されますか？**

いいえ。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslide/) は選択したマスタに依存しているスライドだけを再割り当てします。別のマスタを使用しているスライドは既存のテーマを保持します。

**マスタを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更は対象スライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は何ですか？**

スライドを移動して元の外観を保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imasterslidecollection/) でソースマスタを宛先にクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/islidecollection/) でそのマスタを使用してスライドをクローンします。これによりマスタ、レイアウト、テーマが一体となって転送されます。

**継承とオーバーライド後の有効値はどうやって確認できますか？**

スライドまたはレイアウトテーマについては [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/baseoverridethememanager/) を使用し、[Background.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/background/) や [FillFormat.getEffective](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fillformat/) といったフォーマットオブジェクトの対応する有効データメソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。