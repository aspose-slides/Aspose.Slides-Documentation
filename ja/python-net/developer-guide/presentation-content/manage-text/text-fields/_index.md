---
title: Python で PowerPoint プレゼンテーションのテキストフィールドを管理する
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/python-net/text-fields/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint プレゼンテーションのテキストフィールドを作成、検査、変更、削除します。書式設定を保持し、保存した PPTX および PPT ファイルを検証します。"
---
## **概要**

テキスト段落はポーションで構成されます。普通の[Portion](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/)はリテラルテキストを含みますが、フィールドポーションは[Field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/field/)を持ち、そのタイプによってスライド番号や日付などの自動更新値が識別されます。2つのポーションが同じ文字列を表示していても、フィールドを持つのは片方だけです。

それらを区別するには[Portion.field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/field/)を使用します。普通のテキストの場合は`None`です。[Portion.add_field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/add_field/)は既存のポーションをフィールドに変換します。ラベルと動的値を別々のポーションに保持すると、値を変換してもラベルが置き換えられません。

本ガイドではテキスト内のフィールド、その書式設定、PPTX および PPT への保存方法を扱います。テキストフレームや段落については[Manage Text](/slides/ja/python-net/manage-text/)をご覧ください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの`Slide `ラベルに続く自動更新番号を含むテキストボックスを作成します。番号のサイズ、太さ、色を設定してからフィールドを追加し、保存したプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式を確認します。入力ファイルは不要です。

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

新しいプレゼンテーションはスライド番号 1 から始まるため、テキストは`Slide 1`となり、両方のチェックは`True`を出力します。再度開いた後も番号はフィールドのままで、リテラルの`1`ではありません。検証で使用するインデックスは、この例で作成されたシェイプとポーションを指します。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/)は以下の事前定義値を提供します。適切な値を[add_field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/add_field/)に渡してください。

| 値 | 用途 |
|---|---|
| [slide_number](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/slide_number/) | 現在のスライド番号。 |
| [date_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/date_time/) | 描画アプリケーションのデフォルト形式での日付/時刻。 |
| [date_time1](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/date_time9/) | 事前定義された日付または日付/時刻の組み合わせ形式。 |
| [date_time10](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/date_time13/) | 秒や 12 時間制時計オプションを含む事前定義時刻形式。 |
| [header](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/header/) | ヘッダー フィールド。下記のプレースホルダーと書式制限を参照してください。 |
| [footer](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/footer/) | フッター フィールド。 |

たとえば、[date_time3](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/date_time3/)は英語で「日 月名（フル） 年」を表します。これらは事前定義されたフィールド書式であり、任意の Python 日付書式文字列ではありません。ポーションの[language_id](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseportionformat/language_id/)やプレゼンテーションを処理するアプリケーションが表示結果に影響を与えることがあります。

## **内部文字列からフィールドを作成する**

[add_field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/add_field/)の文字列オーバーロードは内部フィールド識別子を受け取ります。別アプリケーションが提供した識別子を保持したい場合に使用します。識別子から[FieldType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/__init__/)を構築することもできます。[FieldType.internal_string](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fieldtype/internal_string/)はその識別子を検査用に公開します。

この例は、フォールバックテキスト`Report-042`を持つアプリケーション固有の`custom-report-id`フィールドを保存します。識別子は計算を登録しません。Aspose.Slides は未知のタイプに対してレポート ID を生成しません。この識別子の意味と値の更新は、識別子を理解するアプリケーションが提供する必要があります。

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

この PPTX の往復後、タイプは`custom-report-id`、テキストは`Report-042`のままです。`%Y-%m-%d` のような文字列を渡すとフィールドタイプが命名されますが、カスタム日付書式は構成されません。任意の書式で固定日付を使用したい場合は、普通のテキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

既存のフィールドは[Field.type](https://reference.aspose.com/slides/ja/python-net/aspose.slides/field/type/)で取得・変更できます。フィールドが存在するか確認してからタイプにアクセスしてください。自動更新を止めるには[Portion.remove_field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/remove_field/)を呼びます。これによりポーションと現在のテキストは保持され、フィールドの関連付けだけが削除されます。特定の固定値が必要な場合は、フィールド削除後にそのテキストを割り当てます。

日付/時刻フィールドの処理に関する API 設定は[Presentation.current_date_time](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/current_date_time/)をご参照ください。以下の例は、フィールドを普通のテキストに変換する際に明示的な承認日を使用しています。英語の月名タプルにより、システムロケールに依存しない固定日付を実現しています。

`sample.pptx` をダウンロードし、作業ディレクトリに配置してください。これには `UpdatedAt` と `ApprovedDate` という名前のテキストシェイプがそれぞれ日付/時刻フィールドと普通テキストラベルを持っています。下記の例は通常スライド上のトップレベルテキストシェイプを走査し、日付/時刻フィールドを長い日付形式に変更しイタリック体にしますが、その他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

組み込みの内部識別子 `datetime` と `datetime1` から `datetime13` までが認識されます。グループ、テーブル、ノート、レイアウト、マスターは独自のテキストコンテナを走査する必要があり、本例の範囲外です。

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

再度開くと、`UpdatedAt` のタイプは`datetime3`で動的なままです。`ApprovedDate` にはフィールドがなく`05 April 2030`というテキストが入ります。両方の日付ポーションはイタリック体で、元のフォントサイズ、太字設定、色はそのままです。普通テキストラベルは変更されません。検証はサンプルに含まれる2つの既知シェイプの最初のポーションを読み取ります。

## **テキスト書式の保持**

フィールドの追加、タイプ変更、削除を行う際は既存のポーションを使用します。これらの操作はそのポーションの書式を保持します。色やイタリック体のみを変更したい場合は、[Portion.portion_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/portion_format/)を使用してください。

1 つのフィールドだけを更新するためにテキストフレーム全体を再構築しないでください。再構築すると元のポーション境界や個別の書式が失われる可能性があります。また、段落・レイアウト・テーマから継承された書式と明示的に設定された書式を区別してください。より広範な書式オプションについては[Text Formatting](/slides/ja/python-net/text-formatting/)をご参照ください。

## **フィールドとヘッダー/フッタープレースホルダー**

フィールドはテキストポーションの一部です。プレースホルダーはフッターやスライド番号などのプレゼンテーションロールを持つシェイプです。普通のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッターマネージャーはスライド、レイアウト、マスター上のプレースホルダーのテキストと表示状態を制御し、依存スライドへ伝播します。カスタムテキストボックス内の番号フィールドは、スライド番号プレースホルダーを使用しない場合でも有用です。逆に、プレースホルダーの可視性を変更しても、無関係なテキストボックスからフィールドが削除されることはありません。

事前定義されたヘッダーやフッターのタイプは、対応するプレースホルダーやその内容を自動生成しません。特に、通常の PowerPoint スライドにはヘッダー プレースホルダーがなく、ヘッダーはノートページや配布資料に属します。任意のシェイプにあるヘッダーまたはフッターフィールドが、プレースホルダー マネージャーで設定されたテキストを自動的に取得するとは限りません。そのようなワークフローについては[Presentation Headers and Footers](/slides/ja/python-net/presentation-header-and-footer/)をご覧ください。

## **PPTX と PPT の制限事項**

保存と再読込みの後で、フィールドタイプとその結果テキストの両方を確認してください。識別子を保持しただけでは、アプリケーションがその値を計算・表示できることを証明しません。

| フォーマット | フィールドの動作と制限 |
|---|---|
| PPTX | フィールドテキストと共に内部フィールド識別子を保存します。往復チェックでは、事前定義タイプと上記のカスタム識別子の両方が保存・再読込みに耐えました。未知のカスタムタイプはフォールバックテキストを保持しましたが、自動計算ロジックは取得できませんでした。他のアプリケーションが未サポート識別子をどのように扱うかは保証できません。 |
| PPT | 従来のフィールド表現を使用し、互換性がより制限されます。往復チェックでは、スライド番号と事前定義日付/時刻フィールドが保存・再読込みに耐えました。普通のスライドテキストボックス内のカスタムフィールドは識別子は残ったもののテキストは`*`になり、同じコンテキストのヘッダーフィールドも`*`が出力されました。カスタムフィールドや未サポートのフィールドコンテキストが可視テキストを保持することは期待しないでください。 |

固定出力が必要な場合は、未サポートのフィールドを普通のテキストに変換し、保存前に希望する値を明示的に割り当ててください。これによりテキストは保持されますが、自動更新は意図的に停止します。フィールド再計算がワークフローに含まれる場合は、対象アプリケーションでもテストしてください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかを判別する方法は？**

[Portion.field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/field/) を確認してください。`None` 以外の値がフィールドを示します。表示テキストだけでは判別できません。

**フィールドを削除するとテキストや書式も削除されますか？**

いいえ。[remove_field](https://reference.aspose.com/slides/ja/python-net/aspose.slides/portion/remove_field/) は既存のポーションを普通のテキストに変換します。特定の固定日付やフォールバック値が必要な場合は、削除後に明示的に値を割り当ててください。

**内部文字列で新しい日付書式や数式を定義できますか？**

できません。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや Python の日付書式パターンを提供しません。サポートされている事前定義タイプを使用するか、値を普通のテキストとして自分で書式設定してください。

**保存後にプレゼンテーションを再度チェックする理由は？**

フィールド識別子、計算されたテキスト、書式はそれぞれ別個に検証すべき要素です。形式変換により、フィールド識別子は残っていても表示結果が変わることがあります。