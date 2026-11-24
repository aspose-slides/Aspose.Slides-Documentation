---
title: Androidでプレゼンテーションテーマを管理
linktitle: プレゼンテーションテーマ
type: docs
weight: 10
url: /ja/androidjava/presentation-theme/
keywords:
- PowerPointテーマ
- プレゼンテーションテーマ
- スライドテーマ
- テーマを設定
- テーマを変更
- テーマを管理
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
description: "Aspose.Slides for Android（Java）でプレゼンテーションのテーマをマスターし、一貫したブランディングでPowerPointファイルを作成、カスタマイズ、変換します。"
---
## **導入**

プレゼンテーションのテーマは、色、フォント、背景スタイル、塗りつぶし、線、効果の調整されたセットを定義します。テーマ対応オブジェクトは、これらの共有定義を参照し、すべての視覚プロパティを固定値として保持しないため、テーマの変更により多数のオブジェクトを一度に更新できます。

Aspose.Slides では、プレゼンテーションレベルのテーマは [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) で取得できます。プレゼンテーションは下位レベルでテーマのオーバーライドを保持することも可能です。マスターは [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/) を通じてプレゼンテーションテーマをオーバーライドでき、レイアウトや個別スライドは [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) を通じて継承されたテーマをオーバーライドできます。実際には、スライドの有効なテーマは次の継承チェーンで解決されます: プレゼンテーションテーマ、マスターオーバーライド、レイアウトオーバーライド、スライドオーバーライド。

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

以下のセクションでは、最も一般的なテーマ操作ワークフローを示します。テーマの検査、色とフォントの変更、テーマのコピーまたは適用、背景と効果スタイルの更新、継承とオーバーライドが解決された後の有効値の取得です。

## **テーマの検査**

[MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) オブジェクトは、テーマのカラースキーム、フォントスキーム、フォーマットスキームをそれぞれ [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/)、[MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) で公開します。変更前にこれらのコレクションを検査すると、外部ソースから取得したプレゼンテーションのスタイルエントリ数や内容が変わる可能性があるため特に有用です。

次の例は、メインテーマのプロパティを読み取り、背景、塗りつぶし、線、効果スタイルがテーマに何件格納されているかを報告します。

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

## **テーマの色の変更**

テーマ対応の塗りつぶし、線、テキストは [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 列挙体の論理色を参照できます。対応するエントリを [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) で変更すると、そのテーマカラーを参照し続けているすべてのオブジェクトが新しい値に解決されます。直接 RGB 色を使用しているオブジェクトはテーマカラーの更新の影響を受けません。

次のエンドツーエンドの例は、`Accent4` を使用するシェイプを作成し、テーマの `Accent4` 色を赤に変更し、プレゼンテーションを保存して再度開き、実際の塗りつぶし色を出力します。

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

矩形は `Accent4` にリンクされたままであるため、テーマが変更されると表示色が赤になります。シェイプ上で直接色を設定すると、以降の `Accent4` の変更はその塗りつぶしに影響しなくなります。

### **追加パレットからの色の使用**

PowerPoint はテーマカラーから明度変換を適用して明るいバリエーションと暗いバリエーションを生成します。Aspose.Slides はこれらの変換を [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/) 列挙体で公開します。

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - メインテーマカラー。  
**2** - メインテーマカラーから生成された明るいバリエーションと暗いバリエーション。

次の例は `Accent4` を基にした 6 つの矩形を作成し、うち 5 つに明度変換を適用して結果を保存します。

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

### **`SchemeColor` 値を `IColorScheme` スロットにマップする**

[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) 列挙体は `Text1`、`Background1`、`Text2`、`Background2` を使用し、[IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) は同じテーマスロットを `Dark1`、`Light1`、`Dark2`、`Light2` として公開します。マッピングは固定です。

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

これらは同一テーマスロットの別名であり、動的に相互変換される値ではありません。

## **テーマのフォントの変更**

テーマフォントスキームは見出し用のメジャーフォントセットと本文用のマイナーフォントセットを含みます。`[IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/)` と `[IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/)` メソッドでそれらのセットを取得できます。

PowerPoint 互換のテーマフォント識別子はテキスト書式設定で使用できます。

* `+mn-lt` - 本文フォント Latin（マイナー Latin フォント）
* `+mj-lt` - 見出しフォント Latin（メジャー Latin フォント）
* `+mn-ea` - 本文フォント East Asian（マイナー East Asian フォント）
* `+mj-ea` - 見出しフォント East Asian（メジャー East Asian フォント）
* `+mn-cs` - 本文フォント Complex Script（マイナー Complex Script フォント）
* `+mj-cs` - 見出しフォント Complex Script（メジャー Complex Script フォント）

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

見出しはメジャーフォントに従い、本文はマイナーフォントに従います。テーマ識別子ではなく明示的なフォント名が設定されているテキストは、テーマフォントスキームが変更されても自動的に切り替わりません。

メジャーおよびマイナーフォントコレクションは、キリル文字、アラビア文字、日本語、ジョージア文字、サーナ文字など個別の書字システム向けのマッピングも保持できます。これらのマッピングの検査、追加、置換、削除については [Script-Specific Theme Fonts](/slides/ja/androidjava/script-specific-font-mappings/) を参照してください。

{{% alert color="info" title="Tip" %}}
プレゼンテーションフォントの詳細については、[PowerPoint Fonts](/slides/ja/androidjava/powerpoint-fonts/) をご覧ください。
{{% /alert %}}

### **テーマフォント参照の解決**

テキストを検査する際、[IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) は `+mn-lt` のようなテーマ参照を返すことがあります。適切な [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) を渡して [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) を呼び出すと、その参照を解決できます。`+mj` と `+mn` プレフィックスはメジャーとマイナーのフォントセットを選択し、`-lt`、`-ea`、`-cs` サフィックスはそれぞれ Latin、East Asian、Complex Script フォントを選択します。

対象テキストに適用されているテーマを取得するには、テーマが適用されるオブジェクトに対して `[IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--)` を呼び出します。スライド上の普通テキストの場合はスライド自体で呼び出すと、そのスライドの継承テーマとローカルオーバーライドが含まれます。レイアウトやマスター自体を検査する場合はそれ自身の有効テーマを使用してください。最初のマスターのテーマがすべてのスライドに適用されると想定しないでください。

次の例は、マイナー Latin フォントを明示的に参照するテキスト部分を作成し、`[IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--)` でスライドのフォントスキームを初期化し、メジャーとマイナーの Latin ファミリをそれぞれ `Arial` と `Calibri` に設定して、入力ファイルなしでも再現可能にしています。

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

出力は `+mn-lt -> Calibri` の後に `Verdana -> Verdana` となります。保存された参照はそのまま残り、明示的なファミリ名はそのまま返されます。もし `+mj-lt` を使用していれば、このテーマでは `Arial` に解決されます。

テーマ参照の解決は、テーマが指定したフォントファミリを特定しますが、フォントの可用性チェックやレンダリング時の代替・グリフフォールバックまでを判断しません。これらの別工程については [Font Selection Sequence](/slides/ja/androidjava/font-selection-sequence/) と [Font Substitution](/slides/ja/androidjava/font-substitution/) を参照してください。

## **テーマのコピーまたは適用**

以下のワークフローは、さまざまなテーマ関連の課題を解決します。

### **外部テーマをマスター依存スライドに適用する**

PowerPoint テーマファイル (`.thmx`) があり、特定のマスターに依存するすべてのスライドのスタイルを変更したい場合は、`[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)` を使用します。対象マスターは `[Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)` コレクション（`[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)` を実装）から選択し、テーマファイルパスをメソッドに渡します。

このメソッドは次の操作を行います。

1. 選択したマスターを元に新しいマスタースライドを作成します。  
1. 外部テーマを新しいマスターに適用します。  
1. 以前に選択したマスターに依存していたすべてのスライドに新しいマスターを割り当てます。  
1. 新しく作成された `[IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)` を返します。

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

無効、破損、またはサポートされていないテーマは `[PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/)` を引き起こす可能性があります。ユーザーが提供したパスは検証し、ファイルシステムアクセスエラーを処理し、テーマの適用が成功した後にのみプレゼンテーションを保存してください。

選択したマスターに依存していたスライドだけが再割り当てされます。他のマスターに関連付けられたスライドは既存のマスターとテーマを保持します。テーマ対応の色、フォント、塗りつぶし、線、背景、効果は外部テーマに対して解決されます。直接割り当てられた色、フォント、塗りつぶし、その他の明示的書式設定は変更されないまま残ることがあります。レイアウトレベルおよびスライドレベルのオーバーライドは、新しいマスターから継承された値よりも優先される場合があります。

テーマは実行環境に存在しないフォントを参照することがあります。レンダリングとエクスポートの一貫性を保つために、必要なフォントをインストールするか、[カスタムフォント ソース](/slides/ja/androidjava/custom-font/) を通じて提供するか、[フォント代替](/slides/ja/androidjava/font-substitution/) を構成してください。

これは直接的なマスターレベルのワークフローです。メソッドは `.thmx` ファイルへのパスを受け取り、スライドレベルまたはレイアウトレベルのテーマオーバーライドを手動で作成する必要はありません。

### **マルチマスター プレゼンテーションで異なる外部テーマを適用する**

対象マスターが事前に分からない場合は、`[ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/)` と `[ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/)` で代表的なスライドから取得します。テーマを適用する前に元のマスター参照を保存してください。各呼び出しはプレゼンテーションに新しいマスターを作成します。

次の例は、2 つのセクションのスライドからマスターを特定し、各グループに別々の外部テーマを適用します。

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

最初の呼び出しは `firstGroupMaster` に依存するスライドだけに影響し、2 番目の呼び出しは `secondGroupMaster` に依存するスライドだけに影響します。他のマスターに属するスライドは再スタイル化されません。

### **スライド移動時にソーステーマを保持する**

スライドを別のプレゼンテーションに移動し、元のデザインを保持したい場合は、`[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)` でソースマスターをターゲットプレゼンテーションにクローンし、続いて `[ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/)` とクローンしたマスターでスライドをクローンします。これによりマスター、レイアウト、および関連テーマが一緒にコピーされます。

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

この方法は、ソーススライドが宛先で同一に見えることが最重要な場合に推奨されます。無関係な宛先マスターにコンテンツだけをクローンすると、テーマ駆動の色、フォント、背景、効果が変わってしまうことがあります。

### **既存スライドにテーマ値を適用する**

対象スライドを現在のマスターとレイアウトのままに保ちつつ、ソーステーマからスライドレベルのオーバーライドを初期化します。`[OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)`、`[OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)`、`[OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)` メソッドが 3 つの主要テーマコンポーネントをオーバーライドにコピーします。

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

これにより、他のスライドが継承しているテーマは変更せずに、対象スライドだけのテーマが変更されます。ローカルオーバーライドを削除して継承値に戻すには `[OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)` を呼び出してください。

### **レイアウトにテーマオーバーライドを適用する**

レイアウトレベルのオーバーライドは、そのレイアウトを使用するすべてのスライドに適用されます（ただし、個別スライドに独自のオーバーライドがある場合は例外です）。同じ初期化メソッドは `[LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/)` を通じても使用できます。

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

多数のレイアウトやスライドが同一の基本デザインを共有すべき場合はマスターまたはプレゼンテーションレベルのテーマを使用し、特定のレイアウトファミリだけが異なるスタイルを必要とする場合はレイアウトオーバーライドを、例外的なケースだけはスライドオーバーライドを使用してください。過度のスライドレベルオーバーライドは、後のグローバルテーマ変更の予測を困難にします。

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*レイアウトオーバーライドはそのレイアウトを使用するスライドに適用されますが、スライドが独自のオーバーライドを持つ場合は除外されます。テーマベースの値は解決されたスキームに従い、明示的に書式設定されたオブジェクトはローカルの外観を保持できます。オーバーライドは意図したデザイン例外の範囲に限定してください。*
<!-- visual-explanation:presentation-theme:end -->

## **テーマ背景スタイルの更新**

テーマの背景塗りつぶしは `[IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)` に格納されています。PowerPoint の UI では、コレクションに実際に保存されている塗りつぶし定義の数よりも多くの背景選択肢が提示されることがあります。これは UI がテーマ塗りつぶしをテーマカラーやその他のスタイル参照と組み合わせられるためです。

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

背景スタイルを使用する前に、保存されたコレクションと現在の `[Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)` を検査してください。インデックス `0` はテーマ塗りつぶしがないことを意味し、正の値はテーマ背景スタイル参照です。これは Java コレクションのインデックスとは異なり、`get_Item(0)` が最初の格納項目を指します。すべてのプレゼンテーションが同じ数の背景塗りつぶしスタイルを持つとは限りません。

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

見た目はマスターが参照するテーマエントリと、レイアウトまたはスライドレベルでの背景オーバーライドの有無に依存します。スライドが独自の背景を使用している場合、マスター背景のみを変更してもそのスライドの表示は変わりません。継承後の最終背景を知りたいときは `[Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)` を使用してください。

{{% alert color="warning" title="Warning" %}}
インデックスはゼロベースのコレクションインデックスとして扱わないでください。また、あるファイルで使用したスタイル番号を別のファイルで同じ外観と想定してハードコーディングしないでください。テーマスタイル定義はプレゼンテーション固有です。
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
直接的な背景書式設定や背景継承については、[Presentation Background](/slides/ja/androidjava/presentation-background/) を参照してください。
{{% /alert %}}

## **テーマ効果の更新**

テーマフォーマットスキームは、[IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/)、[IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) で公開される個別の塗りつぶし、線、効果スタイルコレクションを含みます。一般的な Office テーマは、微妙、標準、強調の 3 つの主要スタイルエントリを視覚的に持つことが多いですが、コード側では固定数を想定せず各コレクションを検査してください。

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Java でこれらのコレクションにアクセスする場合、コレクションインデックスはゼロベースです：`get_Item(0)` が最初の格納スタイル、`get_Item(2)` が 3 番目です。シェイプのスタイル参照インデックスは別概念で、`[IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/)` で公開されています。テーマスタイルを変更すると、そのテーマスタイルを参照しているシェイプに影響しますが、直接書式設定されたシェイプは変わらないことがあります。

次の例は、必要なスタイルエントリが存在することを確認し、1 番目の線スタイル、3 番目の塗りつぶしスタイルを変更し、3 番目の効果スタイルに外側の影を有効にして結果を保存します。

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

これらのスロットを参照するシェイプでは、最初のテーマ線スタイルが赤に、3 番目のテーマ塗りつぶしスタイルが実線のフォレストグリーンに、3 番目の効果スタイルに距離 10 ポイントの外側の影が追加されます。最終的な視覚結果は、各シェイプが参照するスロットと直接書式設定がテーマを上書きしているかどうかに依存します。

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **シェイプのテーマ塗りつぶしと線スタイルの選択**

シェイプは `[IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-)` と `[IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-)` で塗りつぶしとアウトラインを独立して選択できます。両メソッド共に、インデックス `1` が対応するテーマコレクションの最初のエントリ (`get_Item(0)`) を、インデックス `2` が 2 番目 (`get_Item(1)`) を選択します。

次の例は、新規プレゼンテーションのデフォルトテーマに 2 つの塗りつぶしスタイル（金色と空色）と 2 つの線スタイル（6 pt の濃い青と 12 pt の濃い赤）を設定し、3 段階でスライドを保存して PowerPoint で結果を比較できるようにします。

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| 初期スタイル | 右側のアウトラインを変更 | 最初のテーマ塗りつぶしを編集 |
|:---:|:---:|:---:|
| ![Gold and sky-blue rectangles with matching thin dark blue outlines](theme-style-initial.png) | ![The sky-blue rectangle now has a thick dark red outline](theme-style-line-changed.png) | ![The left rectangle is now green and both outlines are unchanged](theme-style-fill-changed.png) |

異なる線スタイルを選択すると右側矩形のアウトラインだけが変わります。最初のテーマ塗りつぶしを編集すると、その塗りつぶしを使用しているすべてのシェイプが更新され、ここでは左側矩形が緑に変わります。

既存シェイプにローカルな塗りつぶし色、線色、線幅が設定されている場合、テーマスタイルのその部分を上書きします。スタイルインデックスを変更しても視覚効果がない場合は、シェイプの [direct formatting](/slides/ja/androidjava/shape-formatting/) を確認してください。

## **有効な単色塗りつぶしがテーマカラーを使用しているかの判定**

塗りつぶしはオブジェクトに直接格納されるか、段落、レイアウト、マスター、テーマスタイル、または別の書式レベルから継承されます。`[IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/)` を呼び出すと、階層が不変の `[IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)` に解決されます。まず `[IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)` を確認してください。`FillType.Solid` の場合にのみ、単色塗りつぶしプロパティを読み取ります。

単色塗りつぶしの場合、`[IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)` は継承、テーマ参照、カラー変換が適用された後の最終 RGB 値を返します。`[IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/)` は対応する論理 `[SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/)` スロット（例: `Text1`、`Accent6`）を返します。`SchemeColor.NotDefined` は有効な単色塗りつぶしがスキームカラーに基づかないことを意味します。テーマカラーか直接 RGB 色かを判定したいワークフローでは、この値が直接 RGB 塗りつぶしを識別します。

ローカルの `[IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/)` のみを使用して塗りつぶしを分類しないでください。たとえば、テキスト部分がローカルでスキームカラーを持たない場合、ローカル値は `NotDefined` ですが、継承されたテーマカラーにより有効塗りつぶしは `Text1` や `Accent6` に解決されます。逆に `getSolidFillSchemeColor` は有効色を生成した論理テーマスロットを示しますが、そのスロットがオブジェクト、段落、レイアウト、マスター、または別のレベルから来たかは示しません。

次の例はプレゼンテーションを読み込み、シェイプ塗りつぶしとテキスト部分塗りつぶしの両方を監査し、最終的な RGB 値と関連スキームカラーを出力し、テーマカラーの追従が効かない単色塗りつぶしをフラグ付けします。

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

`NotDefined` の分岐は、テーマカラー変更に追随しない単色塗りつぶしの監査リストを提供します。ブランド新パレットに合わせてプレゼンテーションを調整する際にこれらのオブジェクトを確認してください。報告された RGB 値は現在の外観を示し、スキーム値はその外観がテーマに結びついているかどうかを説明します。

有効フォーマットオブジェクトはスナップショットです。プレゼンテーションテーマ、テーマオーバーライド、または任意の継承書式を変更した後は、再度 `getEffective` を呼び出して新しい `IFillFormatEffectiveData` を取得し、色を比較または報告してください。

## **有効なテーマ値の取得**

生のテーマオブジェクトは特定レベルで定義されている内容を示します。有効値は、継承とローカルオーバーライドが解決された後、スライドやシェイプが実際に使用している内容を示します。スライドの場合は `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/)` を呼び出します。背景の場合は `[Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)`、塗りつぶしの場合は `[FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)` を使用します。

次の例はスライドから有効テーマ、背景、最初のシェイプ塗りつぶしを読み取ります。

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

レンダリング診断、検証、比較には有効データを使用してください。`[Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)` だけを検査すると、マスター、レイアウト、スライド、シェイプのオーバーライドによって最終外観が変化しているケースを見落とす可能性があります。

## **FAQ**

**外部テーマを適用するとプレゼンテーション内のすべてのスライドに影響しますか？**

いいえ。`[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)` は選択されたマスターに依存するスライドだけを再割り当てします。他のマスターを使用しているスライドは既存のテーマを保持します。

**マスターを変更せずに単一スライドにテーマを適用できますか？**

はい。スライドの `[SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/)` を使用してオーバーライドテーマを初期化します。変更はそのスライドにローカルに留まり、他のスライドは既存テーマを継承し続けます。

**テーマを別のプレゼンテーションに安全に持ち込む方法は？**

スライドを移動して元の外観を保持する場合は、`[IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/)` でソースマスターを宛先にクローンし、続いて `[ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/)` でそのマスターを使用してスライドをクローンします。これによりマスター、レイアウト、テーマが一緒に保持されます。

**継承とオーバーライド後の有効値はどうやって確認できますか？**

スライドやレイアウトのテーマについては `[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/)` を使用し、`[Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)` や `[FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)` などの対応する有効データメソッドを利用してください。これらの API は継承とオーバーライドが適用された後の解決済み値を返します。