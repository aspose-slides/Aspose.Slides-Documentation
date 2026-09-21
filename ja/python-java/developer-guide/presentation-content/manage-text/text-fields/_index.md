---
title: Python via Java で PowerPoint プレゼンテーションのテキストフィールドを管理
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/python-java/text-fields/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint プレゼンテーションのテキストフィールドを作成、検査、変更、削除します。書式を保持し、保存された PPTX および PPT ファイルを検証します。"
---
## **概要**

テキスト段落はポーションで構成されます。通常の[Portion](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/)はリテラルテキストを含みます。フィールドポーションは additionally a [Field](https://reference.aspose.com/slides/ja/python-java/aspose.slides/field/) を持ち、そのタイプはスライド番号や日付など自動更新される値を識別します。2つのポーションは同じ文字を表示できますが、フィールドを含むのは1つだけです。

[Portion.getField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getField) を使用してそれらを区別します。通常のテキストの場合は `None` が返ります。[Portion.addField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#addField) は既存のポーションをフィールドに変換します。ラベルと動的な値を別々のポーションに保持し、値を変換してもラベルが置き換えられないようにします。

このガイドでは、テキスト内のフィールド、その書式設定、および PPTX と PPT への保存方法を説明します。テキストフレームや段落については、[Manage Text](/slides/ja/python-java/manage-text/) を参照してください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの `Slide ` ラベルに続いて自動更新される番号を含むテキスト ボックスを作成します。フィールドを追加する前に番号のサイズ、太さ、色を設定し、保存したプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式設定をチェックします。入力ファイルは不要です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

新しいプレゼンテーションはスライド番号 1 から開始するため、テキストは `Slide 1` となり、両方のチェックは `True` を出力します。番号は再度開いた後もフィールドのままで、リテラルの `1` にはなりません。検証で使用したインデックスは、このサンプルで作成されたシェイプとポーションを指しています。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/) は、事前定義された値を取得するための次のメソッドを提供します。適切な値を [addField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#addField) に渡してください。

| メソッド | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getSlideNumber) | 現在のスライド番号。 |
| [getDateTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getDateTime) | 描画アプリケーションの既定形式での日付/時刻。 |
| [getDateTime1](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getDateTime9) | 事前定義された日付または結合日付/時刻フォーマット。 |
| [getDateTime10](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getDateTime13) | 事前定義された時刻フォーマット（秒や 12 時間制のオプションあり）。 |
| [getHeader](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getHeader) | ヘッダー フィールド。下記のプレースホルダーと書式制限を参照。 |
| [getFooter](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getFooter) | フッター フィールド。 |

たとえば、[getDateTime3](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getDateTime3) は英語で「日、月のフルネーム、年」を表します。これらは事前定義されたフィールド書式であり、任意の Python 日付フォーマット文字列ではありません。[setLanguageId](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseportionformat/#setLanguageId) で設定された言語や、プレゼンテーションを処理するアプリケーションが表示結果に影響を与える可能性があります。

## **内部文字列からフィールドを作成する**

[addField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#addField) の文字列オーバーロードは内部フィールド識別子を受け取ります。別アプリケーションから提供された識別子を保持したい場合に使用します。識別子から [FieldType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#FieldType) を構築することもできます。[FieldType.getInternalString](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fieldtype/#getInternalString) はその識別子を検査用に公開します。

このサンプルはアプリケーション固有の `custom-report-id` フィールドをフォールバック テキスト `Report-042` と共に保存します。識別子は計算を登録しません：Aspose.Slides は未知のタイプのレポート ID を生成しません。この識別子の意味と更新は、その識別子を理解できるアプリケーションが提供する必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

この PPTX 往復後、タイプは `custom-report-id`、テキストは `Report-042` のままです。`yyyy-MM-dd` のような文字列を渡すとフィールドタイプの名前になり、カスタム日付フォーマットは構成されません。任意の形式で固定日付を使用したい場合は、通常のテキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

既存のフィールドは [Field.setType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/field/#setType) で変更できます。フィールドが存在することを確認してからタイプにアクセスしてください。自動更新を停止するには [Portion.removeField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#removeField) を呼び出します。これによりポーションと現在のテキストは保持され、フィールドの関連付けだけが削除されます。固定値が必要な場合は、フィールドを削除した後にそのテキストを割り当ててください。

日付/時刻フィールド処理に関する API 設定は、[Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#setCurrentDateTime) を参照してください。以下のサンプルは、フィールドを通常のテキストに変換する際に明示的な承認日を使用します。

[sample.pptx](sample.pptx) をダウンロードし、作業ディレクトリに配置してください。サンプルには `UpdatedAt` と `ApprovedDate` という名前のテキスト シェイプが2つあり、各シェイプは日付/時刻フィールドと通常テキストのラベルを持ちます。以下の例は、通常スライド上のトップレベルのテキスト シェイプを走査し、日付/時刻フィールドをロングデート形式に変換してイタリック体にし、他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

組み込みの内部識別子 `datetime` および `datetime1` から `datetime13` はサンプルで認識されます。グループ、テーブル、ノート、レイアウト、マスタは独自のテキスト コンテナの走査が必要であり、このサンプルの対象外です。

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # システムロケールに依存せず英語の月名を使用する。
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

再度開いた後、`UpdatedAt` のタイプは `datetime3` で動的なままです。`ApprovedDate` にはフィールドがなく `05 April 2030` が含まれます。両方の日付ポーションはイタリック体で、元のフォントサイズ、太字設定、色はそのままです。普通のテキスト ラベルは変更されていません。検証は、提供されたサンプル内の2つの既知シェイプの最初のポーションを読み取ります。

## **テキスト書式の保持**

フィールドを追加、タイプ変更、または削除する際は既存のポーションを使用してください。これらの操作はそのポーションの書式を保持します。[Portion.getPortionFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getPortionFormat) を使用して、色やイタリック体など必要なプロパティだけを変更します。

1 つのフィールドだけを更新するためにテキスト フレーム全体を再構築しないでください。再構築すると元のポーション境界や個別の書式が失われる可能性があります。また、段落、レイアウト、テーマから継承された書式と明示的に設定された書式を区別してください。詳細な書式オプションは [Text Formatting](/slides/ja/python-java/text-formatting/) を参照してください。

## **フィールドとヘッダー/フッター プレースホルダー**

フィールドはテキスト ポーションの一部です。プレースホルダーはフッターやスライド番号など、プレゼンテーションの役割を持つシェイプです。通常のテキスト ボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッター マネージャーは、スライド、レイアウト、マスタ上のプレースホルダー テキストと可視性を制御し、依存スライドへ伝播させます。カスタム テキスト ボックス内の番号フィールドは、スライド番号プレースホルダーを使用しない場合でも有用です。逆に、プレースホルダーの可視性を変更しても、無関係なテキスト ボックスからフィールドは削除されません。

事前定義されたヘッダーとフッターのタイプは、対応するプレースホルダーやその内容を自動的に作成しません。特に、通常の PowerPoint スライドにはヘッダー プレースホルダーがなく、ヘッダーはノート ページや配布資料に属します。任意のシェイプ内のヘッダーまたはフッターフィールドが、プレースホルダー マネージャーで設定されたテキストを自動的に取得すると想定しないでください。そのワークフローについては、[Presentation Headers and Footers](/slides/ja/python-java/presentation-header-and-footer/) を参照してください。

## **PPTX と PPT の制限事項**

保存と再オープンの後で、フィールドタイプと実際のテキストの両方を確認してください。識別子を保持したからといって、アプリケーションがその値を計算または表示できることを保証するわけではありません。

| フォーマット | フィールドの挙動と制限 |
|---|---|
| PPTX | フィールド識別子をフィールドテキストと共に保存します。往復チェックでは、事前定義されたタイプと上記のカスタム識別子の両方が保存・再オープン後も残存しました。未知のカスタムタイプはフォールバック テキストを保持しましたが、自動計算ロジックは取得しませんでした。他のアプリケーションはサポート外の識別子を異なる方法で処理する可能性があります。 |
| PPT | 従来のフィールド表現を使用し、互換性がより制限されます。往復チェックでは、スライド番号と事前定義された日付/時刻フィールドが保存・再オープン後も残存しました。通常のスライド テキスト ボックス内のカスタムフィールドは識別子は残りますがテキストは `*` になり、同じコンテキストのヘッダーフィールドも `*` を生成しました。カスタムフィールドやサポート外フィールド コンテキストが可視テキストを保持することは期待しないでください。 |

ポータブルで固定された出力が必要な場合は、サポート外フィールドを普通のテキストに変換し、保存前に希望する値を明示的に割り当ててください。これにより選択したテキストは保持されますが、自動更新は意図的に停止します。フィールド再計算がワークフローに含まれる場合は、対象アプリケーションでもテストを行ってください。

## **FAQ**

**表示された番号や日付がフィールドかどうかはどう判断できますか？**  
[Portion.getField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#getField) を確認してください。`None` 以外の値が返ればフィールドです。表示テキストだけでは判断できません。

**フィールドを削除するとテキストや書式も削除されますか？**  
いいえ。[removeField](https://reference.aspose.com/slides/ja/python-java/aspose.slides/portion/#removeField) は既存のポーションを普通のテキストに変換します。特定の固定日付やフォールバック値が必要な場合は、削除後に明示的に値を割り当ててください。

**内部文字列で新しい日付フォーマットや数式を定義できますか？**  
できません。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや Python の日付フォーマットパターンを提供しません。サポートされている事前定義タイプを使用するか、値を普通のテキストとして自分で書式設定してください。

**保存後にプレゼンテーションを再度チェックする理由は何ですか？**  
フィールド識別子、計算テキスト、書式は別々に検証すべき項目です。フォーマット変換により、フィールド識別子は残っていても表示結果が変わることがあります。