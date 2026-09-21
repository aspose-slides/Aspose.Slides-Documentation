---
title: PHPでPowerPointプレゼンテーションのテキストフィールドを管理する
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/php-java/text-fields/
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
- PHP
- Aspose.Slides
description: "Java経由でPHP用Aspose.Slidesを使用してPowerPointプレゼンテーションのテキストフィールドを作成、検査、変更、削除します。書式を保持し、保存されたPPTXおよびPPTファイルを検証します。"
---
## **概要**

テキスト段落はポーションで構成されます。通常の[Portion](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/)はリテラルテキストを含みます；フィールドポーションは[Field](https://reference.aspose.com/slides/ja/php-java/aspose.slides/field/)も持ち、そのタイプはスライド番号や日付など自動更新される値を識別します。2つのポーションが同じ文字を表示しても、フィールドを含むのは片方だけです。

[Portion::getField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getField) を使って区別できます：通常のテキストの場合は `null` です。[Portion::addField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#addField) は既存のポーションをフィールドに変換します。ラベルと動的な値は別々のポーションに保持し、値を変換してもラベルが置き換わらないようにしてください。

このガイドではテキスト内のフィールド、書式設定、および PPTX と PPT への保存について説明します。テキストフレームや段落については [Manage Text](/slides/ja/php-java/manage-text/) を参照してください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの `Slide ` ラベルに自動更新される番号を続けたテキストボックスを作成します。フィールドを追加する前に番号のサイズ、太さ、色を設定し、保存したプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式を確認します。入力ファイルは不要です。

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

新しいプレゼンテーションはスライド番号 1 から開始するため、テキストは `Slide 1` となり、両方のチェックは `true` を出力します。再度開いた後も番号はフィールドのままで、リテラルの `1` ではありません。検証で使用されているインデックスは、このサンプルで作成されたシェイプとポーションを指します。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/) は事前定義された値を取得するための以下のメソッドを提供します。適切な値を [addField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#addField) に渡してください。

| メソッド | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getSlideNumber) | 現在のスライド番号 |
| [getDateTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getDateTime) | 描画アプリケーションのデフォルト形式による日付/時刻 |
| [getDateTime1](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getDateTime9) | 事前定義された日付または結合日付/時刻形式 |
| [getDateTime10](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getDateTime13) | 秒数や 12 時間制を含む事前定義時刻形式 |
| [getHeader](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getHeader) | ヘッダー フィールド（下記のプレースホルダーと書式制限を参照） |
| [getFooter](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getFooter) | フッター フィールド |

例として、[getDateTime3](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getDateTime3) は英語で「日 月名（完全） 年」を表します。これらは事前定義されたフィールド形式であり、任意の PHP 日付フォーマット文字列ではありません。[setLanguageId](https://reference.aspose.com/slides/ja/php-java/aspose.slides/baseportionformat/#setLanguageId) で設定した言語やプレゼンテーションを処理するアプリケーションが表示結果に影響を与えることがあります。

## **内部文字列からフィールドを作成する**

[addField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#addField) の文字列オーバーロードは内部フィールド識別子を受け取ります。事前定義された値がない他アプリケーションから提供された識別子を保持したい場合に使用します。識別子から [FieldType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#FieldType) を構築することも可能です。[FieldType::getInternalString](https://reference.aspose.com/slides/ja/php-java/aspose.slides/fieldtype/#getInternalString) でその識別子を確認できます。

この例はアプリケーション固有の `custom-report-id` フィールドをフォールバックテキスト `Report-042` と共に保存します。識別子は計算を登録しません：Aspose.Slides は未知のタイプに対してレポート ID を生成しません。この識別子の意味と値の更新は、識別子を理解できるアプリケーションが行う必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

この PPTX ラウンドトリップ後、タイプは `custom-report-id`、テキストは `Report-042` のままです。`Y-m-d` のような文字列を渡すとフィールドタイプの名前になり、カスタム日付形式は設定されません。任意の形式で固定日付を表示したい場合は、普通のテキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

既存のフィールドは [Field::setType](https://reference.aspose.com/slides/ja/php-java/aspose.slides/field/#setType) で変更できます。タイプにアクセスする前にフィールドが存在することを確認してください。自動更新を止めるには [Portion::removeField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#removeField) を呼び出します。これによりポーション自体と現在のテキストは保持され、フィールドの関連付けだけが削除されます。固定した特定の値が必要な場合は、フィールド削除後にそのテキストを割り当ててください。

日付/時刻フィールド処理に関する API 設定は [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#setCurrentDateTime) を参照してください。以下のサンプルは、フィールドを普通のテキストに変換する際に明示的な承認日を使用しています。

[sample.pptx](sample.pptx) をダウンロードし、JavaBridge の作業ディレクトリに配置するか、絶対パスをプレゼンテーション コンストラクタに渡します。サンプルには `UpdatedAt` と `ApprovedDate` という 2 つの名前付きテキストシェイプが含まれ、それぞれに日付/時刻フィールドと普通のテキスト ラベルがあります。以下の例は通常スライド上のトップレベルテキストシェイプを走査し、日付/時刻フィールドをロングデート形式に変更して斜体にし、他の書式はそのまま保持します。`ApprovedDate` にあるフィールドだけが固定テキストになります。

サンプルは組み込みの内部識別子 `datetime` および `datetime1` から `datetime13` を認識します。グループ、テーブル、ノート、レイアウト、マスタはそれぞれのテキスト コンテナを走査する必要があり、本例の対象外です。

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

再度開くと、`UpdatedAt` のタイプは `datetime3` で動的なままです。`ApprovedDate` にはフィールドがなく、テキストは `05 April 2030` です。両方の日付ポーションは斜体で、元のフォントサイズ、太字設定、色はそのままです。普通のテキスト ラベルは変更されていません。検証は提供されたサンプル内の 2 つの既知シェイプの最初のポーションを読み取ります。

## **テキスト書式の保持**

フィールドを追加、タイプ変更、または削除する際は既存のポーションを直接操作してください。これらの操作はポーションの書式を保持します。例が示すように、色や斜体のみを変更したい場合は [Portion::getPortionFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getPortionFormat) を使って必要なプロパティだけを変更します。

1 つのフィールドだけを更新するためにテキストフレーム全体を再構築しないでください。再構築すると元のポーション区切りや個別の書式が失われる可能性があります。また、段落・レイアウト・テーマから継承された書式と明示的に設定された書式を区別することが重要です。より広範な書式オプションについては [Text Formatting](/slides/ja/php-java/text-formatting/) を参照してください。

## **フィールドとヘッダー/フッタープレースホルダー**

フィールドはテキストポーションの一部です。プレースホルダーはフッターやスライド番号などプレゼンテーション上の役割を持つシェイプです。普通のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになることはありません。

ヘッダー/フッターマネージャはスライド、レイアウト、マスタ上のプレースホルダー テキストと可視性を制御し、依存スライドへ伝搬します。カスタムテキストボックス内の番号フィールドは、スライド番号プレースホルダーを使用していなくても有用です。逆に、プレースホルダーの可視性を変更しても、無関係なテキストボックス内のフィールドは削除されません。

事前定義されたヘッダーおよびフッタータイプは対応するプレースホルダーを作成したり、コンテンツを供給したりしません。特に、通常の PowerPoint スライドにはヘッダー プレースホルダーがありません。ヘッダーはノートページや配布資料に属します。任意のシェイプにあるヘッダーまたはフッター フィールドが、プレースホルダー マネージャで設定されたテキストを自動的に取得すると想定しないでください。そのワークフローについては [Presentation Headers and Footers](/slides/ja/php-java/presentation-header-and-footer/) を参照してください。

## **PPTX と PPT の制限事項**

保存後と再読み込み後の両方でフィールドタイプと生成されたテキストを確認してください。識別子を保持したからといって、アプリケーションがその値を計算または表示できることを証明するわけではありません。

| 形式 | フィールドの動作と制限 |
|---|---|
| PPTX | フィールドテキストと共に内部識別子を保存します。ラウンドトリップ検証では、事前定義されたタイプと上記のカスタム識別子の両方が保存・再読み込みに耐えました。未知のカスタムタイプはフォールバックテキストを保持しましたが、自動計算ロジックは取得できません。他のアプリケーションは未サポートの識別子を別の方法で処理する可能性があります。 |
| PPT | 従来のフィールド表現を使用し、互換性が限定的です。ラウンドトリップ検証では、スライド番号と事前定義された日付/時刻フィールドは保存・再読み込みに耐えました。普通のスライドテキストボックス内のカスタムフィールドは識別子は保持されましたがテキストは `*` となり、同様にヘッダーフィールドも `*` になりました。カスタムフィールドや未サポートのコンテキストが可視テキストを保持することは期待しないでください。 |

ポータブルで固定された出力が必要な場合は、サポートされていないフィールドを普通のテキストに変換し、保存前に目的の値を明示的に割り当ててください。これによりテキストは保持されますが、自動更新は意図的に停止します。自動再計算がワークフローの一部である場合は、対象アプリケーションでもテストしてください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかを判別するにはどうすればよいですか？**  
[Portion::getField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#getField) を確認します。null でない値がフィールドを示し、表示テキストだけでは判別できません。

**フィールドを削除するとテキストや書式も削除されますか？**  
いいえ。[removeField](https://reference.aspose.com/slides/ja/php-java/aspose.slides/portion/#removeField) は既存のポーションを普通のテキストに変換します。特定の固定日付やフォールバック値が必要な場合は、削除後に明示的に値を割り当ててください。

**内部文字列で新しい日付形式や数式を定義できますか？**  
いいえ。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや PHP の日付フォーマットパターンを提供しません。サポートされている事前定義タイプを使用するか、普通のテキストとして値をフォーマットしてください。

**保存後にプレゼンテーションを再度チェックするのはなぜですか？**  
フィールド識別子、計算テキスト、書式は別個に検証すべき項目です。形式変換により、フィールド識別子が残っていても可視結果が変わることがあります。