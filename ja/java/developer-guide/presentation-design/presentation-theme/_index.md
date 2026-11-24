---
title: Java でプレゼンテーションテーマを管理
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
description: "Aspose.Slides for Java のマスタープレゼンテーションテーマを使用して、PowerPoint ファイルを一貫したブランディングで作成、カスタマイズ、変換します。"
---
## **概要**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、エフェクトの調和したセットを定義します。テーマ対応オブジェクトは、各ビジュアルプロパティを固定値として保存する代わりに、これらの共有定義を参照するため、テーマを変更すると多数のオブジェクトが一度に更新されます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) で利用できます。プレゼンテーションには、下位レベルでテーマのオーバーライドを含めることもできます。マスタは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/) を使用してプレゼンテーションテーマをオーバーライドでき、レイアウトまたは個々のスライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) を使用して継承されたテーマをオーバーライドできます。実際には、スライドの有効なテーマは次の継承チェーンで解決されます：プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![テーマ構成要素: 色、フォント、背景スタイル、エフェクト](theme-constituents.png)

以下のセクションでは、最も一般的なテーマのワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景およびエフェクトスタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) オブジェクトは、[MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) を通じて、テーマのカラースキーム、フォントスキーム、フォーマットスキームを公開します。変更する前にこれらのコレクションを検査することは、プレゼンテーションが外部ソースから来た場合に特に有用です。スタイルエントリの数や内容が変わる可能性があるためです。

以下の例は、メインテーマのプロパティを読み取り、テーマに格納されている背景、塗りつぶし、線、エフェクトスタイルの数を報告します。

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

ファイルが複数のマスタを使用している場合、すべてのスライドが同じ有効テーマを持つとは限りません。スライドに関連付けられたマスタを検査し、レイアウトやスライドのオーバーライドが存在する可能性がある場合は、この記事後半に示す有効テーマのワークフローを使用してください。

## **テーマの色を変更**

テーマ対応の塗りつぶし、線、テキストは、[SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) 列挙から論理カラーを参照できます。[IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) の対応エントリを変更すると、まだそのテーマカラーを参照しているすべてのオブジェクトが新しい値で解決されます。直接 RGB カラーを使用しているオブジェクトは、テーマカラーの更新によって変更されません。

以下のエンドツーエンド例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` カラーを赤に変更し、プレゼンテーションを保存して再度開き、実効塗りつぶしカラーを出力します。

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

長方形は `Accent4` にリンクしたままなので、テーマが変更された後は表示色が赤になります。シェイプ上でスキームカラーを直接のカラーに置き換えると、以降の `Accent4` の変更はその塗りつぶしに影響しません。

### **追加パレットから色を使用**

PowerPoint はテーマカラーに対してカラー変換を適用し、より明るいバリエーションと暗いバリエーションを導き出します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/) 列挙で公開しています。

![メインテーマカラーと追加パレットから生成された明るい色および暗い色](additional-palette-colors.png)

**1** - メインテーマカラー。  
**2** - 追加パレットから生成された明るいバリエーションと暗いバリエーション。

以下の例は、`Accent4` を基にした 6 つの長方形を作成し、そのうち 5 つに輝度変換を適用し、結果を保存します。

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

これらのバリエーションはテーマカラーを基にしています。`Accent4` が後で変更されると、変換された色は新しい `Accent4` の値から再計算されます。

### **`SchemeColor` 値を `IColorScheme` スロットにマッピング**

[SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) 列挙は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同じテーマスロットの別名であり、動的に変換される値ではありません。

## **テーマフォントを変更**

テーマフォントスキームは、見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。[IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) と [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) メソッドがそれらのセットを公開します。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント ラテン (マイナー ラテン フォント)
* `+mj-lt` - 見出しフォント ラテン (メジャー ラテン フォント)
* `+mn-ea` - 本文フォント 東アジア (マイナー 東アジア フォント)
* `+mj-ea` - 見出しフォント 東アジア (メジャー 東アジア フォント)
* `+mn-cs` - 本文フォント 複合文字 (マイナー 複合文字 フォント)
* `+mj-cs` - 見出しフォント 複合文字 (メジャー 複合文字 フォント)

以下の例は、メジャー ラテンテーマフォントを使用する見出しと、マイナー ラテンテーマフォントを使用する本文行を作成し、テーマフォントを変更して結果を保存します。

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

見出しはメジャーフォントに従い、本文テキストはマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が設定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーとマイナーのフォントコレクションには、キリル文字、アラビア文字、日本語、ジョージア文字、タアナ文字など個別の書記体系向けのフォントマッピングを含めることもできます。これらのマッピングを検査、追加、置換、または削除するには、[Script-Specific Theme Fonts](/slides/ja/java/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/java/powerpoint-fonts/) を参照してください。
{{% /alert %}}

### **テーマフォント参照の解決**

テキストを検査する際、[IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) はフォントファミリ名の代わりに `+mn-lt` のようなテーマ参照を返すことがあります。適切な [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) を使用して [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) を呼び出し、その参照を解決してください。`+mj` と `+mn` プレフィックスはメジャーとマイナーフォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれラテン、東アジア、複合文字フォントを選択します。

テーマが適用されているテキストのオブジェクトで [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) を取得します。スライド上の通常テキストの場合は、スライド自体でこのメソッドを呼び出すと、スライドの継承テーマとローカルオーバーライドがコンテキストに含まれます。レイアウトやマスタ自体を検査する場合は、そのオブジェクトの有効テーマを使用してください。最初のマスタのテーマがすべてのスライドに適用されると推測しないでください。

以下の例は、マイナー ラテンフォントを明示的に参照するテキスト部分を作成し、[IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) でスライドのフォントスキームを初期化し、メジャーとマイナーのラテンファミリを `Arial` と `Calibri` に設定して、入力ファイルなしでも再現可能にします。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

出力は `+mn-lt -> Calibri` の後に `Verdana -> Verdana` となります。格納された参照は変更されず、明示的なファミリ名はそのまま返されます。部分が `+mj-lt` を使用していた場合、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマが指定したフォントファミリを特定しますが、フォントの利用可否や置換・グリフフォールバック後に実際に使用されるフォントファイルを判断しません。これらの別ステップについては、[Font Selection Sequence](/slides/ja/java/font-selection-sequence/) と [Font Substitution](/slides/ja/java/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用**

PowerPoint テーマファイル (`.thmx`) があり、特定のマスタに依存するすべてのスライドのスタイルを変更したい場合は、[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) を使用します。[Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) コレクションからマスタを選択し（このコレクションは [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) を実装）、テーマファイルのパスをメソッドに渡します。

このメソッドは以下の操作を実行します。

1. 選択したマスタを基に新しいマスタスライドを作成します。
1. 外部テーマを新しいマスタに適用します。
1. 以前に選択したマスタに依存していたすべてのスライドに新しいマスタを割り当てます。
1. 新しく作成された [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) を返します。

以下の例は、最初のマスタに依存するスライドに外部テーマを適用し、プレゼンテーションを保存します。

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

無効・破損・未対応のテーマは [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/) をスローすることがあります。ユーザーが指定したパスを検証し、ファイルシステムアクセスの失敗を処理し、テーマが正常に適用されたことを確認してからプレゼンテーションを保存してください。

選択したマスタに依存していたスライドだけが再割り当てされます。他のマスタに関連付けられたスライドは既存のマスタとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、エフェクトは外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りつぶし、その他の明示的書式は変更されないまま残ることがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスタから継承された値よりも優先される場合があります。

テーマは実行環境に存在しないフォントを参照することがあります。安定したレンダリングとエクスポートのために、必要なフォントをインストールするか、[custom font sources](/slides/ja/java/custom-font/) で提供するか、[font substitution](/slides/ja/java/font-substitution/) を構成してください。

この手順は直接的なマスタレベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取りますが、スライドレベルまたはレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスタプレゼンテーションで異なる外部テーマを適用**

対象のマスタが事前に分からない場合は、[ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) と [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/) で代表的なスライドから取得します。テーマ適用前に元のマスタ参照を保存してください。呼び出しごとにプレゼンテーションに新しいマスタが作成されます。

以下の例は、2 つのセクションのスライドを使用してそれぞれのマスタを特定し、各グループに別々の外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドだけに影響し、2 番目の呼び出しは `secondGroupMaster` に依存するスライドだけに影響します。他のマスタに属するスライドは再スタイル化されません。

### **スライド移動時に元のテーマを保持**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) でソースマスタをターゲットプレゼンテーションにクローンし、続いて [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) とクローンしたマスタでスライドをクローンします。これによりマスタ、レイアウト、関連テーマが一緒に持ち込まれます。

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

これは、ソーススライドが宛先でも同じ外観である必要がある場合に推奨されるワークフローです。無関係な宛先マスタにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、エフェクトが変わることがあります。

### **既存スライドにテーマ値を適用**

対象スライドが現在のマスタとレイアウトを保持したままである必要がある場合、ソーステーマからスライドレベルのオーバーライドを初期化します。[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/)、[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

これによりそのスライドで使用されるテーマが変更され、他のスライドが継承するテーマは変わりません。ローカルオーバーライドを削除して継承値に戻すには、[OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) を呼び出してください。

### **レイアウトにテーマオーバーライドを適用**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するスライドに適用されますが、特定のスライドが独自のオーバーライドを持っている場合は除外されます。同じ初期化メソッドは [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/) を介して使用できます。

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

多くのレイアウトとスライドが同一の基本デザインを共有すべき場合はマスタまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイルを必要とする場合はレイアウトオーバーライドを、真の例外のみの場合はスライドオーバーライドを使用してください。過剰なスライドレベルのオーバーライドは、後のグローバルテーマ変更を予測しにくくします。

<!-- visual-explanation:presentation-theme:start -->
[![マスターテーマが2つのレイアウトに供給され、レイアウトのオーバーライドはそれらのスライドに影響しますが、ローカルオーバーライドがあるスライドは除外されます。](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*レイアウトのオーバーライドは、そのレイアウトを使用するスライドに適用されますが、スライドが独自のオーバーライドを提供している場合は除外されます。テーマベースの値は解決されたスキーマに従い、明示的に書式設定されたオブジェクトはローカルの外観を保持できます。オーバーライドは意図したデザイン例外の範囲に限定してください。*
<!-- visual-explanation:presentation-theme:end -->

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) に格納されています。PowerPoint の UI はこのコレクションに実際に保存されている塗りつぶし定義の数よりも多くの背景選択肢を提示できます。UI はテーマ塗りつぶしとテーマカラー、その他のスタイル参照を組み合わせることができるためです。

![プレゼンテーションテーマの PowerPoint 背景スタイル ギャラリー](presentation-design_8.png)

背景スタイルを使用する前に、保存されたコレクションと現在の [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/) を検査してください。インデックス `0` はテーマ塗りつぶしがないことを意味し、正の値はテーマ背景スタイル参照です。これは Java コレクションを直接インデックス指定する場合の `get_Item(0)`（最初の項目）とは異なります。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限らないことに注意してください。

以下の例は、利用可能な背景塗りつぶし数を報告し、最初のマスタにテーマ背景参照を割り当て、プレゼンテーションを保存します。

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

表示結果はマスタが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスタの背景だけを変更してもそのスライドは変化しないことがあります。継承が適用された後の最終背景を知りたい場合は、[Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) を使用してください。

{{% alert color="warning" title="Warning" %}}
スタイルインデックスをゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルからハードコードしたスタイル番号を別のファイルで同じ外観になると想定しないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定と背景継承については、[Presentation Background](/slides/ja/java/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマエフェクトの更新**

テーマフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) を通じて個別の塗りつぶし、線、エフェクトスタイル コレクションを公開します。典型的な Office テーマは、視覚的に微妙、適度、強烈な書式設定に対応する 3 つの主要スタイルエントリを含むことが多いですが、コード側では固定数を想定せず各コレクションを検査すべきです。

![同じシェイプに適用された微妙、適度、強烈なテーマエフェクト](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、インデックスはゼロベースです。`get_Item(0)` が最初のスタイル、`get_Item(2)` が 3 番目のスタイルです。シェイプのスタイル参照インデックスは別概念で、[IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/) を通じて取得できます。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響し、直接書式設定されたシェイプは変更されないままです。

以下の例は、必要なスタイルエントリが存在するか確認し、最初の線スタイルを変更し、3 番目の塗りつぶしスタイルを変更し、3 番目のエフェクトスタイルに外側の影（距離 10pt）を有効にして結果を保存します。

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

これらのスロットを参照しているシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが実線のフォレストグリーンに、3 番目のエフェクトスタイルに距離 10pt の外側シャドウが付与されます。最終的な視覚結果は各シェイプが参照しているスタイルスロットと、直接書式設定がテーマを上書きしているかどうかに依存します。

![線、塗りつぶし、シャドウ設定変更後のテーマエフェクトスタイル](presentation-design_11.png)

## **シェイプのテーマ塗りつぶしと線スタイルの選択**

シェイプは [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) と [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) を使用して、塗りつぶしとアウトラインを個別に選択できます。どちらのメソッドでも、インデックス `1` は対応するテーマコレクションの最初のエントリ（`get_Item(0)`）を、インデックス `2` は二番目（`get_Item(1)`）を選択します。

以下の例は、新しいプレゼンテーションの既定テーマで 2 つの塗りつぶしスタイル（金と空色）と 2 つの線スタイル（6pt の濃い青、12pt の濃い赤）を設定し、3 段階でスライドを保存して PowerPoint で結果を比較できるようにします。

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初期スタイル | 右側のアウトラインを変更 | 最初のテーマ塗りつぶしを編集 |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

別の線スタイルを選択すると、右側の長方形のアウトラインだけが変わります。最初のテーマ塗りつぶしを編集すると、それを使用しているすべてのシェイプが更新されます。この例では左側の長方形だけが緑に変わります。

既存のシェイプでは、ローカルの塗りつぶしカラー、線カラー、線幅がテーマスタイルの該当部分を上書きできます。スタイルインデックスを変更しても視覚的に影響が出ない場合は、シェイプの [direct formatting](/slides/ja/java/shape-formatting/) を確認してください。

## **有効な単色塗りつぶしがテーマカラーを使用しているかの判定**

塗りつぶしはオブジェクトに直接保存されるか、段落、レイアウト、マスタ、テーマスタイル、または別の書式レベルから継承されます。[IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) を呼び出して、この階層を不変の [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) に変換します。まず [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) を確認してください。`FillType.Solid` の場合にのみ、単色塗りつぶしのプロパティを読み取ります。

単色塗りつぶしの場合、[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) は継承、テーマ参照、カラー変換が適用された後の最終 RGB 値を返します。[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) は対応する論理 [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) スロット（例: `Text1` や `Accent6`）を返します。`SchemeColor.NotDefined` は有効な単色塗りつぶしがスキームカラーに基づいていないことを意味します。テーマカラーまたは直接 RGB カラーのいずれかだけを使用するワークフローでは、この値は直接 RGB 塗りつぶしを識別します。

ローカルの [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) のみで塗りつぶしを分類しないでください。たとえば、テキスト部分にローカルでスキームカラーが定義されていない場合、ローカル値は `NotDefined` ですが、実効塗りつぶしはテーマカラーを継承し `Text1` や `Accent6` に解決されます。逆に、`getSolidFillSchemeColor` は実効カラーを生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスタ、または他の書式階層のどこから来たかは示しません。

以下の例はプレゼンテーションをロードし、シェイプ塗りつぶしとテキスト部分塗りつぶしの両方を監査し、最終 RGB 値と関連スキームカラーを出力し、テーマカラー変更に追従しない単色塗りつぶしにフラグを付けます。

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

`NotDefined` の分岐は、テーマカラー スロットの変更に応答しない単色塗りつぶしの監査リストを提供します。新しいブランドパレットに従う必要があるプレゼンテーションでは、これらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに接続されているかどうかを説明します。

有効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出し、新しい `IFillFormatEffectiveData` オブジェクトを取得してから色を比較または報告してください。

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用しているものを示します。スライドの場合は [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) を呼び出します。背景の場合は [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) を、塗りつぶしの場合は [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) を使用してください。

以下の例は、スライドから有効テーマ、背景、最初のシェイプ塗りつぶしを取得します。

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

レンダリング診断、検証、比較には有効データを使用してください。[Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) だけを検査すると、マスタ、レイアウト、スライド、またはシェイプのオーバーライドで最終外観が変わっているケースを見逃す可能性があります。

## **FAQ**

**外部テーマを適用すると、プレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) は選択したマスタに依存するスライドだけを再割り当てします。他のマスタを使用しているスライドは既存のテーマを保持します。

**マスタを変更せずに単一のスライドにテーマを適用できますか？**

はい。スライドの [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) を使用してオーバーライドテーマを初期化してください。この変更はそのスライドにローカルに留まり、他のスライドは既存のテーマを継承し続けます。

**テーマを別のプレゼンテーションに持ち込む最も安全な方法は何ですか？**

スライドを移動して元の外観を保持する場合、[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) と [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) を使用してソースマスタを宛先にクローンし、そのマスタでスライドをクローンします。これによりマスタ、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライドの後の有効な値を確認するにはどうすればよいですか？**

スライドまたはレイアウトテーマには [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) を、背景や塗りつぶしなどのフォーマットオブジェクトにはそれぞれの有効データ取得メソッド（例: [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) と [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/)）を使用してください。これらの API は継承とオーバーライドが適用された後の解決された値を返します。