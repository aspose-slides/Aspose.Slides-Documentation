---
title: JavaScript で PowerPoint プレゼンテーションのテキストフィールドを管理する
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/nodejs-java/text-fields/
keywords:
- テキストフィールド
- 自動テキスト
- スライド番号
- 日付と時刻
- ヘッダー
- フッター
- テキスト部分
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint プレゼンテーション内のテキストフィールドを作成、検査、修正、削除します。書式を保持し、保存された PPTX および PPT ファイルを検証します。"
---
## **概要**

テキスト段落は部分で構成されます。通常の[Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/)はリテラルテキストを含み、フィールド部分は[Field](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/field/)も持ち、そのタイプはスライド番号や日付など自動的に更新される値を識別します。2つの部分は同じ文字を表示できますが、フィールドを持つのは1つだけです。

それらを区別するには[Portion.getField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#getField)を使用します。通常のテキストの場合は `null` です。[Portion.addField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#addField)は既存の部分をフィールドに変換します。ラベルとその動的な値は別々の部分に保持し、値を変換してもラベルが置き換えられないようにします。

このガイドではテキスト内のフィールド、その書式設定、および PPTX と PPT への保存について説明します。テキストフレームと段落については[Manage Text](/slides/ja/nodejs-java/manage-text/)をご覧ください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの `Slide ` ラベルに自動更新される番号を続けたテキストボックスを作成します。フィールドを追加する前に番号のサイズ、太さ、色を設定し、保存したプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式を確認します。入力ファイルは不要です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

新しいプレゼンテーションはスライド番号 1 から開始するため、テキストは `Slide 1` となり、両方のチェックは `true` を出力します。再度開いた後も番号はフィールドのままで、リテラルの `1` ではありません。検証で使用されるインデックスは、この例で作成されたシェイプと部分を指します。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/)は、事前定義された値を取得するための以下のメソッドを提供します。適切な値を[addField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#addField)に渡してください。

| メソッド | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | 現在のスライド番号。 |
| [getDateTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getDateTime) | レンダリング アプリケーションのデフォルト形式の日付/時刻。 |
| [getDateTime1](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | 事前定義された日付または結合された日付/時刻形式。 |
| [getDateTime10](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | 事前定義された時刻形式で、秒や12時間制のオプションがあります。 |
| [getHeader](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getHeader) | ヘッダー フィールド。以下のプレースホルダーと書式の制限を参照してください。 |
| [getFooter](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getFooter) | フッター フィールド。 |

例えば、[getDateTime3](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getDateTime3)は英語で「日、フル月名、年」を表します。これらは事前定義されたフィールド書式であり、任意の日付書式文字列ではありません。[setLanguageId](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)で設定された言語やプレゼンテーションを処理するアプリケーションが表示結果に影響する可能性があります。

## **内部文字列からフィールドを作成する**

[addField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#addField)の文字列オーバーロードは内部フィールド識別子を受け取ります。事前定義された値がない他のアプリケーションから提供された識別子を保持したい場合に使用します。識別子から[FieldType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/)を作成することも可能です。[FieldType.getInternalString](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fieldtype/#getInternalString)はその識別子を検査用に公開します。

この例では、アプリケーション固有の `custom-report-id` フィールドをフォールバックテキスト `Report-042` と共に保存します。この識別子は計算を登録しません。Aspose.Slides は不明なタイプのレポート ID を生成しません。この識別子を理解するアプリケーションが意味を提供し、値を更新する必要があります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

この PPTX の往復後、タイプは `custom-report-id` でテキストは `Report-042` です。`yyyy-MM-dd` のような文字列を渡すとフィールドタイプの名前になるだけで、カスタム日付書式は設定されません。任意の書式で固定日付を使用する場合は、通常のテキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

[Field.setType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/field/#setType)で既存のフィールドを変更します。タイプにアクセスする前にフィールドが存在することを確認してください。自動更新を停止するには[Portion.removeField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#removeField)を呼び出します。これによりフィールドの関連付けが削除され、部分と現在のテキストは保持されます。特定の固定値が必要な場合は、フィールドを削除した後にそのテキストを割り当ててください。

日付/時刻フィールドの処理に関連する API 設定については[Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#setCurrentDateTime)をご覧ください。以下の例は、フィールドを通常テキストに変換する際に明示的な承認日付を使用します。

[sample.pptx](sample.pptx) をダウンロードし、作業ディレクトリに配置してください。これには、`UpdatedAt` と `ApprovedDate` の 2 つの名前付きテキストシェイプが含まれ、それぞれに日付/時刻フィールドと普通のテキストラベルがあります。以下の例は通常スライド上のトップレベルテキストシェイプを走査します。日付/時刻フィールドを長い日付形式に変更し、イタリック体にしますが、他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

承認日付は 2030 年 4 月 5 日です。JavaScript の月インデックスは0から始まるため、4 月は `3` です。日付の生成と書式設定の両方で UTC を使用し、ローカルタイムゾーンに依存しないようにしています。

サンプルは組み込みの内部識別子 `datetime` および `datetime1` から `datetime13` を認識します。グループ、テーブル、ノート、レイアウト、マスターはそれぞれのテキストコンテナの走査が必要であり、この例の対象外です。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

再度開くと、`UpdatedAt` のタイプは `datetime3` で動的なままです。`ApprovedDate` にはフィールドがなく、`05 April 2030` が含まれます。両方の日付部分はイタリック体で、元のフォントサイズ、太字設定、色はそのままです。普通のテキストラベルは変更されていません。検証は提供されたサンプル内の 2 つの既知シェイプの最初の部分を読み取ります。

## **テキスト書式の保持**

フィールドを追加、タイプ変更、削除する際は既存の部分を使用してください。これらの操作はその部分の書式を保持します。[Portion.getPortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#getPortionFormat) を使用して、例が示すように色やイタリック体など必要なプロパティだけを変更します。

1つのフィールドを更新するだけのためにテキストフレーム全体を再構築しないでください。そうすると元の部分境界や個別の書式が失われる可能性があります。また、段落、レイアウト、テーマから継承された書式と明示的に設定された書式を区別してください。より広範な書式オプションについては[Text Formatting](/slides/ja/nodejs-java/text-formatting/)をご覧ください。

## **フィールドとヘッダー/フッタープレースホルダー**

フィールドはテキスト部分の一部です。プレースホルダーはフッターやスライド番号など、プレゼンテーション上の役割を持つシェイプです。通常のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッターマネージャーはスライド、レイアウト、マスター上のプレースホルダーのテキストと表示状態を制御し、派生スライドへも伝播します。スライド番号プレースホルダーを使用しなくても、カスタムテキストボックス内の番号フィールドは有用です。逆に、プレースホルダーの可視性を変更しても、無関係なテキストボックスからフィールドは削除されません。

事前定義されたヘッダーおよびフッタータイプは、対応するプレースホルダーを作成したりその内容を提供したりしません。特に、通常の PowerPoint スライドにはヘッダープレースホルダーがなく、ヘッダーはノートページや配布資料に属します。任意のシェイプ内のヘッダーまたはフッターフィールドがプレースホルダー管理で設定されたテキストを自動的に取得すると期待しないでください。そのワークフローについては[Presentation Headers and Footers](/slides/ja/nodejs-java/presentation-header-and-footer/)をご覧ください。

## **PPTX と PPT の制限**

保存後と再オープン後にフィールドタイプとその結果テキストの両方を確認してください。識別子を保持しても、アプリケーションがその値を計算または表示できることを証明するものではありません。

| 形式 | フィールドの動作と制限 |
|---|---|
| PPTX | 内部フィールド識別子をフィールドテキストと共に保存します。往復チェックでは、事前定義されたタイプと上記で使用したカスタム識別子が保存と再オープンを通過しました。未知のカスタムタイプはフォールバックテキストを保持しましたが、自動計算ロジックは取得しませんでした。別のアプリケーションはサポートされていない識別子を異なる方法で処理する可能性があります。 |
| PPT | レガシーなフィールド表現を使用し、互換性がより限定的です。往復チェックでは、スライド番号と事前定義された日付/時刻フィールドが保存と再オープンを通過しました。通常のスライドテキストボックス内のカスタムフィールドは識別子は保持されましたがテキストは `*` になりました。同様のコンテキストのヘッダーフィールドも `*` を出力しました。カスタムフィールドやサポートされていないフィールドコンテキストが表示テキストを保持することに依存しないでください。 |

ポータブルで固定された出力を得るには、サポートされていないフィールドを通常テキストに変換し、保存前に目的の値を明示的に割り当ててください。これにより選択したテキストは保持されますが、自動更新は意図的に停止します。ワークフローに対象アプリケーションのフィールド再計算が含まれる場合は、そちらでもテストしてください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかはどうやって判断できますか？**

[Portion.getField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#getField) を調べます。null でない値がフィールドを示し、表示テキストだけでは判断できません。

**フィールドを削除するとテキストや書式も削除されますか？**

いいえ。[removeField](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/#removeField) は既存の部分を普通のテキストに変換します。特定の固定日付やフォールバック値が必要な場合は、フィールド削除後に明示的に値を割り当ててください。

**内部文字列で新しい日付フォーマットや数式を定義できますか？**

できません。内部文字列はフィールドタイプを識別するだけで、評価ロジックや日付書式パターンは提供されません。サポートされている事前定義タイプを使用するか、値を普通のテキストとして自分で書式設定してください。

**保存後にプレゼンテーションを再度確認するのはなぜですか？**

フィールド識別子、計算されたテキスト、書式は別々に検証すべき項目です。形式変換により表示結果が変わることがあり、フィールド識別子が残っていても結果が異なる場合があります。