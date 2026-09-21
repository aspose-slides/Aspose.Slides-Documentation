---
title: .NET で PowerPoint プレゼンテーションのテキストフィールドを管理する
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/net/text-fields/
keywords:
- テキストフィールド
- 自動テキスト
- スライド番号
- 日付と時刻
- ヘッダー
- フッター
- テキストポーション
- PowerPoint
- PPT
- PPTX
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint プレゼンテーションのテキストフィールドを作成、検査、変更、削除します。書式設定を保持し、保存された PPTX と PPT ファイルを検証します。"
---
## **概要**

テキスト段落はポーションで構成されます。通常の[IPortion](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/) はリテラルテキストを含みます。フィールドポーションは[IField](https://reference.aspose.com/slides/ja/net/aspose.slides/ifield/) を持ち、そのタイプはスライド番号や日付など自動的に更新される値を識別します。2 つのポーションは同じ文字を表示できますが、フィールドを含むのは片方だけです。

それらを区別するには[IPortion.Field](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/field/) を使用します。通常のテキストでは `null` です。[IPortion.AddField](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/addfield/) は既存のポーションをフィールドに変換します。ラベルとその動的な値は別々のポーションに保持し、値を変換してもラベルが置き換えられないようにします。

このガイドではテキスト内のフィールド、その書式設定、および PPTX と PPT への保存について説明します。テキストフレームや段落については[テキストの管理](/slides/ja/net/manage-text/)をご覧ください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの `Slide ` ラベルに続いて自動的に更新される番号を含むテキストボックスを作成します。フィールドを追加する前に番号のサイズ、太さ、色を設定し、保存したプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式設定を確認します。入力ファイルは不要です。

```cs
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
shape.AddTextFrame("Slide ");
var paragraph = shape.TextFrame.Paragraphs[0];

var numberPortion = new Portion();
numberPortion.PortionFormat.FontHeight = 24;
numberPortion.PortionFormat.FontBold = NullableBool.True;
numberPortion.PortionFormat.FillFormat.FillType = FillType.Solid;
numberPortion.PortionFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
paragraph.Portions.Add(numberPortion);
numberPortion.AddField(FieldType.SlideNumber);

presentation.Save("slide_number.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("slide_number.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedNumber = savedShape.TextFrame.Paragraphs[0].Portions[1];
var hasNumberField = savedNumber.Field?.Type.InternalString == FieldType.SlideNumber.InternalString;
var format = savedNumber.PortionFormat;
var formattingPreserved = format.FontHeight == 24 && format.FontBold == NullableBool.True;
formattingPreserved &= format.FillFormat.SolidFillColor.Color.ToArgb() == Color.DarkBlue.ToArgb();

Console.WriteLine($"Text: {savedShape.TextFrame.Text}");
Console.WriteLine($"Slide number field: {hasNumberField}");
Console.WriteLine($"Formatting preserved: {formattingPreserved}");
```

新しいプレゼンテーションはスライド番号 1 から開始するので、テキストは `Slide 1` となり、両方のチェックは `True` を出力します。再度開いた後も番号はフィールドのままで、リテラルの `1` ではありません。検証で使用されるキャストやインデックスは、この例で作成されたシェイプおよびポーションを指しています。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/) は[IFieldType](https://reference.aspose.com/slides/ja/net/aspose.slides/ifieldtype/) を実装し、以下の事前定義された値を提供します。適切な値を[AddField](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/addfield/) に渡してください。

| 値 | 目的 |
|---|---|
| [SlideNumber](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/slidenumber/) | 現在のスライド番号。 |
| [DateTime](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/datetime/) | レンダリングアプリケーションのデフォルト形式の日付/時刻。 |
| [DateTime1](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/datetime1/)–[DateTime9](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/datetime9/) | 事前定義された日付または日付/時刻の組み合わせ形式。 |
| [DateTime10](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/datetime10/)–[DateTime13](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/datetime13/) | 秒や12時間制のオプションを含む事前定義された時刻形式。 |
| [Header](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/header/) | ヘッダー フィールドです。下記のプレースホルダーと書式の制限を参照してください。 |
| [Footer](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/footer/) | フッター フィールドです。 |

例として、[DateTime3](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/datetime3/) は英語で日、月のフルネーム、年を表します。これは任意の .NET 日付形式文字列ではなく、事前定義されたフィールド書式です。ポーションの[LanguageId](https://reference.aspose.com/slides/ja/net/aspose.slides/ibaseportionformat/languageid/) およびプレゼンテーションを処理するアプリケーションが表示結果に影響を与える可能性があります。

## **内部文字列からフィールドを作成**

[AddField](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/addfield/) の文字列オーバーロードは内部フィールド識別子を受け取ります。事前定義された値がない他のアプリケーションから提供された識別子を保持したい場合に使用します。識別子から[FieldType](https://reference.aspose.com/slides/ja/net/aspose.slides/fieldtype/fieldtype/) を作成することもできます。[IFieldType.InternalString](https://reference.aspose.com/slides/ja/net/aspose.slides/ifieldtype/internalstring/) はその識別子を検査用に公開します。

この例では、アプリケーション固有の `custom-report-id` フィールドをフォールバックテキスト `Report-042` と共に保存します。識別子は計算を登録しません：Aspose.Slides は未知のタイプのレポート ID を生成しません。この識別子を理解できるアプリケーションが意味を提供し、値を更新する必要があります。

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
shape.AddTextFrame("Report-042");
var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.AddField("custom-report-id");

presentation.Save("custom_field.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom_field.pptx");
var savedShape = (IAutoShape)reopened.Slides[0].Shapes[0];
var savedPortion = savedShape.TextFrame.Paragraphs[0].Portions[0];
Console.WriteLine($"Type: {savedPortion.Field?.Type.InternalString}");
Console.WriteLine($"Text: {savedPortion.Text}");
```

この PPTX の往復後、タイプは `custom-report-id`、テキストは `Report-042` です。`yyyy-MM-dd` のような文字列を渡すとフィールドタイプの名前となり、カスタム日付形式は設定されません。任意の形式で固定日付を使用したい場合は、通常のテキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

[IField.Type](https://reference.aspose.com/slides/ja/net/aspose.slides/ifield/type/) を使用して既存のフィールドを読み取り、変更します。タイプにアクセスする前にフィールドが存在することを確認してください。自動更新を停止するには[IPortion.RemoveField](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/removefield/) を呼び出します。これによりフィールドの関連付けが削除され、ポーションとその現在のテキストは保持されます。特定の固定値が必要な場合は、フィールドを削除した後にそのテキストを割り当ててください。

日付/時刻フィールド処理に関連する API 設定については[Presentation.CurrentDateTime](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/currentdatetime/) を参照してください。以下の例では、フィールドを普通のテキストに変換する際に明示的な承認日を使用しています。

[サンプル.pptx](sample.pptx) をダウンロードし、作業ディレクトリに配置します。これは `UpdatedAt` と `ApprovedDate` の 2 つの名前付きテキストシェイプを含み、各シェイプに日付/時刻フィールドと通常のテキストラベルがあります。以下の例は通常スライドのトップレベルテキストシェイプを走査します。日付/時刻フィールドを長い日付形式に変更し、斜体にしますが、他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

サンプルは組み込みの内部識別子 `datetime` および `datetime1`〜`datetime13` を認識します。グループ、テーブル、ノート、レイアウト、マスターはそれぞれのテキストコンテナの走査が必要であり、この例の範囲外です。

```cs
using System;
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var approvalDate = new DateTime(2030, 4, 5);
var culture = CultureInfo.GetCultureInfo("en-US");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape textShape || textShape.TextFrame == null)
            continue;

        foreach (var paragraph in textShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                var field = portion.Field;
                if (field == null)
                    continue;

                var typeName = field.Type.InternalString;
                var isDateTime = typeName == "datetime";
                if (typeName.StartsWith("datetime", StringComparison.Ordinal))
                {
                    var hasFormatNumber = int.TryParse(typeName.Substring(8), out var formatNumber);
                    isDateTime |= hasFormatNumber && formatNumber >= 1 && formatNumber <= 13;
                }
                if (!isDateTime)
                    continue;

                field.Type = FieldType.DateTime3;
                portion.PortionFormat.LanguageId = "en-US";
                portion.PortionFormat.FontItalic = NullableBool.True;

                if (textShape.Name == "ApprovedDate")
                {
                    portion.RemoveField();
                    portion.Text = approvalDate.ToString("dd MMMM yyyy", culture);
                }
            }
        }
    }
}

presentation.Save("updated_dates.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("updated_dates.pptx");
foreach (var shape in reopened.Slides[0].Shapes)
{
    if (shape is not IAutoShape textShape || textShape.TextFrame == null)
        continue;
    if (textShape.Name != "UpdatedAt" && textShape.Name != "ApprovedDate")
        continue;

    var portion = textShape.TextFrame.Paragraphs[0].Portions[0];
    var typeName = portion.Field?.Type.InternalString ?? "ordinary text";
    Console.WriteLine($"{textShape.Name}: {typeName}; {portion.Text}");
    Console.WriteLine($"Italic: {portion.PortionFormat.FontItalic}");
}
```

再度開くと、`UpdatedAt` はタイプ `datetime3` で動的なままです。`ApprovedDate` にはフィールドがなく、`05 April 2030` が含まれています。両方の日付ポーションは斜体で、元のフォントサイズ、太字設定、色はそのままです。普通のテキストラベルは変更されません。検証は提供されたサンプル内の 2 つの既知シェイプの最初のポーションを読み取ります。

## **テキスト書式設定の保持**

フィールドの追加、タイプ変更、または削除を行う際は既存のポーションを使用します。これらの操作はポーションの書式設定を保持します。必要なプロパティだけを変更するには[IPortion.PortionFormat](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/portionformat/) を使用します。例では色や斜体の変更に使用しています。

1 つのフィールドを更新するだけでテキストフレーム全体を再構築しないでください。再構築すると元のポーション境界や個別の書式設定が失われる可能性があります。また、段落、レイアウト、テーマから継承された書式設定と明示的に設定された書式設定を区別してください。より広範な書式設定オプションについては[Text Formatting](/slides/ja/net/text-formatting/) を参照してください。

## **フィールドとヘッダー/フッタープレースホルダー**

フィールドはテキストポーションの一部です。プレースホルダーはフッターやスライド番号などのプレゼンテーション上の役割を持つシェイプです。通常のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッターマネージャーはスライド、レイアウト、マスター上のプレースホルダーのテキストと表示状態を制御し、依存スライドへ伝搬します。カスタムテキストボックス内の番号フィールドは、スライド番号プレースホルダーを使用していない場合でも有用です。逆に、プレースホルダーの表示状態を変更しても、無関係なテキストボックスからフィールドは削除されません。

事前定義されたヘッダー・フッタータイプは対応するプレースホルダーを作成したり、内容を提供したりしません。特に、通常の PowerPoint スライドにはヘッダー プレースホルダーがなく、ヘッダーはノートページや配布資料に属します。任意のシェイプ内のヘッダーまたはフッターフィールドがプレースホルダー管理者で設定されたテキストを自動的に取得すると想定しないでください。そのワークフローについては[Presentation Headers and Footers](/slides/ja/net/presentation-header-and-footer/)をご覧ください。

## **PPTX と PPT の制限**

保存して再度開いた後に、フィールドタイプと生成されたテキストの両方を確認してください。識別子を保持しただけでは、アプリケーションがその値を計算または表示できることを保証しません。

| フォーマット | フィールドの動作と制限 |
|---|---|
| PPTX | 内部フィールド識別子とフィールドテキストを共に保存します。往復チェックでは、事前定義されたタイプと上記のカスタム識別子が保存と再オープンを経ても残りました。未知のカスタムタイプはフォールバックテキストを保持しましたが、自動計算ロジックは取得しませんでした。別のアプリケーションは未サポートの識別子を異なる方法で扱う可能性があります。 |
| PPT | レガシーなフィールド表現を使用し、互換性が制限されます。往復チェックでは、スライド番号と事前定義された日付/時刻フィールドが保存と再オープンを経ても残りました。通常のスライドテキストボックス内のカスタムフィールドは識別子は残りますがテキストは `*` となり、同様のコンテキストのヘッダーフィールドも `*` を出力しました。カスタムフィールドや未サポートのフィールドコンテキストが表示テキストを保持することに依存しないでください。 |

ポータブルで固定された出力を得るには、未サポートのフィールドを普通のテキストに変換し、保存前に必要な値を明示的に割り当ててください。これにより選択したテキストは保持されますが、自動更新は意図的に停止します。ワークフローに対象アプリケーション自身のフィールド再計算が含まれる場合は、対象アプリケーションでもテストしてください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかは、どのように判別できますか？**

[IPortion.Field](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/field/) を調べます。非 null の値がフィールドであることを示し、表示テキストだけでは判別できません。

**フィールドを削除するとテキストや書式設定も削除されますか？**

いいえ。[RemoveField](https://reference.aspose.com/slides/ja/net/aspose.slides/iportion/removefield/) は既存のポーションを普通のテキストに変換します。特定の固定された日付やフォールバック値が必要な場合は、フィールド削除後に明示的に値を設定してください。

**内部文字列で新しい日付形式や数式を定義できますか？**

いいえ。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや .NET の日付形式パターンを提供しません。サポートされている事前定義タイプを使用するか、値を普通のテキストとして書式設定してください。

**保存後にプレゼンテーションを再度確認するのはなぜですか？**

フィールド識別子、計算されたテキスト、書式設定は別々に検証すべき項目です。形式変換によりフィールド識別子が残っていても表示結果が変わることがあります。