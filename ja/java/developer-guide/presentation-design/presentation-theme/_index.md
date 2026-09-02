---
title: Javaでプレゼンテーションテーマを管理
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
- 外部テーマ
- THMX
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
description: "Aspose.Slides for Java でマスタープレゼンテーションテーマを使用し、ブランド一貫性のある PowerPoint ファイルの作成、カスタマイズ、変換を行います。"
---
## **はじめに**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗り、線、効果の調整されたセットです。テーマに対応したオブジェクトは、各ビジュアルプロパティを固定値として保持するのではなく、これらの共有定義を参照します。そのため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーション レベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) で取得できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることもできます。マスタは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/masterthememanager/) によってプレゼンテーション テーマをオーバーライドでき、レイアウトや個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) によって継承されたテーマをオーバーライドできます。実際には、スライドの有効テーマは次の継承チェーンで解決されます。プレゼンテーション テーマ → マスタ オーバーライド → レイアウト オーバーライド → スライド オーバーライド。

![テーマの構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ ワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景および効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/mastertheme/) を通じてテーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更前にこれらのコレクションを検査することは、外部ソースから取得したプレゼンテーションの場合に特に有用です。スタイル エントリの数や内容は変わる可能性があります。

次の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗り、線、効果スタイルの数をレポートします。

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

ファイルが複数のマスタを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスタを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、後述の有効テーマ ワークフローを使用してください。

## **テーマの色の変更**

テーマ対応の塗り、線、テキストは [SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。[IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) の該当エントリを変更すると、そのテーマ色を参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトは、テーマ色の更新の影響を受けません。

次のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存、再度開いて有効な塗りの色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマを変更すると表示色が赤になります。シェイプ上で直接色を設定すると、以降の `Accent4` の変更はその塗りに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーに対して色変換を適用し、明るいバリエーションや暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/colortransformoperation/) 列挙体で公開しています。

![メインテーマカラーと追加パレットから生成された明るい色・暗い色](additional-palette-colors.png)

**1** – メインテーマカラー  
**2** – メインテーマカラーから生成された明るいバリエーションと暗いバリエーション

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

これらのバリエーションはテーマカラーに基づいたままです。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` の値を `IColorScheme` のスロットにマッピングする**

[SchemeColor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。対応は固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマのフォントの変更**

テーマのフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifontscheme/) メソッドでそれぞれのセットにアクセスできます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` – 本文フォント ラテン語 (Minor Latin Font)
* `+mj-lt` – 見出しフォント ラテン語 (Major Latin Font)
* `+mn-ea` – 本文フォント 東アジア語 (Minor East Asian Font)
* `+mj-ea` – 見出しフォント 東アジア語 (Major East Asian Font)

次の例は、メジャー ラテン語テーマフォントを使用した見出しと、マイナー ラテン語テーマフォントを使用した本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が指定されているテキストは、テーマフォントスキームが変更されても自動的には切り替わりません。

メジャーとマイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、タナー文字など、個別の書字システム向けのフォントマッピングも含められます。これらのマッピングを検査、追加、置換、削除する方法は、[Script-Specific Theme Fonts](/slides/ja/java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションのフォントに関する詳細は、[PowerPoint Fonts](/slides/ja/java/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスタ依存スライドに適用する**

PowerPoint のテーマ ファイル (`.thmx`) があり、特定のマスタに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) を使用します。まず [Presentation.getMasters](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コレクションからマスタを選択し（このコレクションは [IMasterSlideCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) を実装）、テーマ ファイルのパスをメソッドに渡します。

このメソッドは次の操作を行います。

1. 選択したマスタを基に新しいマスタ スライドを作成します。
1. 外部テーマを新しいマスタに適用します。
1. 以前に選択したマスタに依存していたすべてのスライドに新しいマスタを割り当てます。
1. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) を返します。

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

無効、破損、またはサポートされていないテーマは [PptxReadException](https://reference.aspose.com/slides/ja/java/com.aspose.slides/pptxreadexception/) をスローする可能性があります。ユーザーが提供したパスを検証し、ファイルシステムへのアクセス失敗を処理し、テーマが正常に適用された後にのみプレゼンテーションを保存してください。

選択したマスタに依存していたスライドだけが再割り当てされます。他のマスタに関連付けられたスライドは既存のマスタとテーマを保持します。テーマ対応の色、フォント、塗り、線、背景、効果は外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りなどの明示的書式は変更されない場合があります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスタから継承された値よりも優先されることがあります。

テーマは実行環境に存在しないフォントを参照することがあります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[カスタム フォント ソース](/slides/ja/java/custom-font/) を通じて提供するか、[フォント置換](/slides/ja/java/font-substitution/) を構成してください。

これは直接的なマスタ レベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルやレイアウトレベルのテーマ オーバーライドを手動で作成する必要はありません。

### **マルチマスタ プレゼンテーションで異なる外部テーマを適用する**

対象のマスタが事前に分からない場合は、[ISlide.getLayoutSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islide/) と [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilayoutslide/) を通じて代表的なスライドから取得します。テーマを適用する前に元のマスタ参照を保存してください。各呼び出しはプレゼンテーションに新しいマスタを作成します。

次の例は、2 つのセクションのスライドからそれぞれのマスタを特定し、各グループに異なる外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドのみ、2 番目は `secondGroupMaster` に依存するスライドのみを対象とします。他のマスタに属するスライドは再スタイリングされません。

### **スライド移動時に元のテーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) でソースマスタをターゲットにクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) でスライドとクローンされたマスタをクローンします。これによりマスタ、レイアウト、および関連テーマが一緒にコピーされます。

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

この方法は、ソース スライドを宛先で同一に見せる必要がある場合に推奨されます。無関係な宛先マスタにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わる可能性があります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスタとレイアウトのままにしておき、ソーステーマからスライド レベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/) メソッドは、3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

この操作により、他のスライドが継承しているテーマは変更せずに、そのスライドだけのテーマが変更されます。ローカル オーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマ オーバーライドを適用する**

レイアウト レベルのオーバーライドは、そのレイアウトを使用するスライドすべてに適用されます（個別のスライドが独自のオーバーライドを持たない限り）。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/layoutslidethememanager/) を通じて使用できます。

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

多くのレイアウトとスライドが同一の基本デザインを共有すべき場合はマスタまたはプレゼンテーション レベルのテーマを使用し、特定のレイアウト ファミリに異なるスタイリングが必要な場合はレイアウト オーバーライドを、例外的なケースだけはスライド オーバーライドを使用してください。過度のスライド レベル オーバーライドは、後の全体テーマ変更を予測しにくくします。

## **テーマ背景スタイルの更新**

テーマの背景塗りは [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/) に格納されています。PowerPoint の UI では、実際にコレクションに格納されている塗り定義の数より多くの背景選択肢が提示されることがあります。これは、テーマ塗りとテーマカラーや他のスタイル参照を組み合わせて表示できるためです。

![プレゼンテーション テーマの背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されているコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) を検査してください。`0` のスタイルインデックスはテーマ塗りが無いことを意味し、正の値はテーマ背景スタイル参照です。これは Java コレクションのインデックスと異なり、`get_Item(0)` は最初に格納された項目を指します。すべてのプレゼンテーションが同じ数の背景塗りスタイルを持つとは限りません。

次の例は、利用可能な背景塗り数をレポートし、最初のマスタにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果は、マスタが参照しているテーマエントリと、レイアウトまたはスライド レベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスタ背景だけを変更してもそのスライドは変わりません。継承後の最終背景が必要なときは、[Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号を別のファイルでハードコーディングして同じ外観になると期待しないでください。テーマ スタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景継承については、[Presentation Background](/slides/ja/java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマのフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iformatscheme/) を通じて個別の塗り、線、効果スタイル コレクションを公開します。一般的な Office テーマは、微妙、標準、強調の 3 つの主要スタイルエントリを持つことが多いですが、コード側ではコレクションの要素数を固定とせずに検査してください。

![同一シェイプに適用された微妙・標準・強調のテーマ効果](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです。`get_Item(0)` が最初の格納スタイル、`get_Item(2)` が3番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ishapestyle/) に公開されています。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変更されません。

次の例は、必要なスタイルエントリが存在するか確認し、最初の線スタイル、3 番目の塗りスタイルを変更し、3 番目の効果スタイルに外側のシャドウ（距離 10pt）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りスタイルが濃い森緑に、3 番目の効果スタイルに外側シャドウが追加されます。最終的な視覚結果は、各シェイプがどのスロットを参照しているか、直接書式がテーマを上書きしているかに依存します。

![線・塗り・シャドウ設定変更後のテーマ効果スタイル](presentation-design_11.png)

## **有効テーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカル オーバーライドが解決された後にスライドやシェイプが実際に使用している値を示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/)、塗りの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/) を使用します。

次の例は、スライドから有効テーマ、背景、最初のシェイプの塗りを読み取ります。

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

レンダリング診断、検証、比較のために有効データを使用してください。単に [Presentation.getMasterTheme](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) を検査するだけでは、マスタ、レイアウト、スライド、シェイプのオーバーライドにより最終的な外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション全体のスライドが変更されますか？**

いいえ。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslide/) は選択したマスタに依存するスライドのみを再割り当てします。他のマスタを使用しているスライドは既存のテーマを保持します。

**マスタを変更せずに単一のスライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/ja/java/com.aspose.slides/slidethememanager/) を使用し、オーバーライドテーマを初期化します。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションへ安全に持ち込む方法は？**

スライドを移動して元の外観を保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imasterslidecollection/) でソースマスタを宛先にクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/ja/java/com.aspose.slides/islidecollection/) でスライドとそのマスタをクローンしてください。これによりマスタ、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値を確認する方法は？**

スライドまたはレイアウトのテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/baseoverridethememanager/) を、フォーマットオブジェクト（例: [Background.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/background/)、[FillFormat.getEffective](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fillformat/)）には対応する有効データ取得メソッドを使用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。