---
title: Android の PowerPoint プレゼンテーションにおけるテキストフィールドの管理
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/androidjava/text-fields/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint プレゼンテーション内のテキストフィールドを作成、検査、変更、削除します。書式を保持し、保存された PPTX と PPT ファイルを検証します。"
---
## **概要**

テキスト段落は「ポーション」で構成されます。通常の[IPortion](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/)はリテラルテキストを含みますが、フィールドポーションは自動更新される値（スライド番号や日付など）を示す[IField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifield/)も持ちます。2 つのポーションが同じ文字列を表示していても、フィールドを持つのは片方だけです。

[IPortion.getField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#getField--) を使って判別できます。通常のテキストの場合は `null` です。[IPortion.addField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) は既存のポーションをフィールドに変換します。ラベルと動的な値を別々のポーションに保持すれば、値をフィールドに変換してもラベルが置き換えられることはありません。

このガイドではテキスト内のフィールド、その書式設定、PPTX と PPT での保存方法を説明します。テキストフレームや段落に関しては[テキストの管理](/slides/ja/androidjava/manage-text/)をご参照ください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの `Slide ` ラベルに自動更新される番号を続けたテキストボックスを作成します。番号のサイズ、太さ、色を設定した後にフィールドを追加し、保存したプレゼンテーションを再度開いてフィールドの種類、テキスト、書式を確認します。入力ファイルは不要です。

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

新しいプレゼンテーションはスライド番号 1 から始まるため、テキストは `Slide 1` となり、両方のチェックは `true` を出力します。再度開いても番号はフィールドのままで、リテラルの `1` にはなりません。検証で使用しているキャストとインデックスは、このサンプルで作成されたシェイプとポーションを指しています。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/) は [IFieldType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifieldtype/) を実装し、事前定義された値を取得するための以下のメソッドを提供します。適切な値を [addField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) に渡してください。

| メソッド | 目的 |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | 現在のスライド番号。 |
| [getDateTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | 描画アプリケーションのデフォルト形式での日付/時刻。 |
| [getDateTime1](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | 事前定義された日付または結合日付/時刻形式。 |
| [getDateTime10](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | 秒や 12 時間制のオプションを含む事前定義された時刻形式。 |
| [getHeader](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getHeader--) | ヘッダー フィールド（下記のプレースホルダーと書式制限を参照）。 |
| [getFooter](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getFooter--) | フッター フィールド。 |

たとえば [getDateTime3](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) は「英語での日、完全な月名、年」を表します。これらは事前定義されたフィールド書式であり、任意の Java 日付書式文字列ではありません。`setLanguageId`(https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) で設定した言語や、プレゼンテーションを処理するアプリケーションにより表示結果が変わることがあります。

## **内部文字列からフィールドを作成**

[addField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) の文字列オーバーロードは内部フィールド識別子を受け取ります。別アプリケーションが提供した識別子を保持したい場合に使用します。識別子から [FieldType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) を構築することもできます。[IFieldType.getInternalString](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) はその識別子を取得します。

このサンプルはアプリケーション固有の `custom-report-id` フィールドをフォールバックテキスト `Report-042` と共に格納します。識別子自体は計算を登録しません：Aspose.Slides は未知のタイプに対してレポート ID を生成しません。この識別子を理解できるアプリケーションが意味付けと値の更新を行う必要があります。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

この PPTX ラウンドトリップ後、タイプは `custom-report-id`、テキストは `Report-042` のままです。`yyyy-MM-dd` のような文字列を渡すとフィールドタイプの名前になり、カスタムの日付書式は設定されません。任意の形式で固定日付を入れたい場合は通常のテキストを使用してください。

## **日付/時刻フィールドの検査・変更・削除**

既存のフィールドは [IField.setType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-) で変更できます。フィールドが存在するか確認してから型にアクセスしてください。自動更新を止めたい場合は [IPortion.removeField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#removeField--) を呼び出します。これによりポーションと現在のテキストは残りますが、フィールドの関連付けが解除されます。固定値が必要な場合は、フィールド削除後にそのテキストを割り当ててください。

日付/時刻フィールド処理に関する API 設定は [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-) を参照してください。以下のサンプルは、フィールドを通常テキストに変換する際に明示的な承認日を使用しています。

`sample.pptx` をダウンロードし、作業ディレクトリに配置してください。スライド上の 2 つの名前付きテキストシェイプ `UpdatedAt` と `ApprovedDate` があり、どちらも日付/時刻フィールドと通常テキストラベルを持ちます。以下の例は通常スライド上のトップレベルテキストシェイプを走査し、日付/時刻フィールドをロングデート形式に変更し斜体にしますが、他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

組み込みの内部識別子 `datetime` と `datetime1`〜`datetime13` が認識されます。グループ、テーブル、ノート、レイアウト、マスターはそれぞれ独自のテキストコンテナを走査する必要があり、このサンプルの対象外です。

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

再度開くと `UpdatedAt` はタイプ `datetime3` で動的なままです。`ApprovedDate` にはフィールドがなく `05 April 2030` がテキストとして残ります。両方の日付ポーションは斜体で、元のフォントサイズ、太字設定、色はそのままです。通常テキストラベルは変更されていません。検証はサンプルに含まれる 2 つの既知シェイプの最初のポーションを読み取ります。

## **テキスト書式の保持**

フィールドを追加、型を変更、または削除する際は既存のポーションを操作してください。これらの操作はそのポーションの書式を保持します。[IPortion.getPortionFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#getPortionFormat--) を使って必要なプロパティだけを変更します（サンプルは色や斜体の変更を示しています）。

フィールド 1 つだけを更新するためにテキストフレーム全体を再構築しないでください。再構築すると元のポーション境界や個別の書式が失われる可能性があります。また、段落・レイアウト・テーマから継承された書式と明示的に設定した書式を区別することが重要です。より広範な書式オプションについては[テキスト書式](/slides/ja/androidjava/text-formatting/)をご覧ください。

## **フィールドとヘッダー/フッター プレースホルダー**

フィールドはテキストポーションの一部です。プレースホルダーはフッターやスライド番号などのプレゼンテーション上の役割を持つシェイプです。通常のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッターマネージャーはスライド、レイアウト、マスター上のプレースホルダー文字列と表示設定を制御し、依存スライドへ伝播させます。カスタムテキストボックス内の番号フィールドは、スライド番号プレースホルダーを使用していなくても便利です。逆にプレースホルダーの表示状態を変更しても、無関係なテキストボックス内のフィールドは削除されません。

事前定義されたヘッダーとフッターのタイプは、対応するプレースホルダーやその内容を自動的に作成しません。特に、通常の PowerPoint スライドにはヘッダー プレースホルダーはありません。ヘッダーはノートページやハンドアウトに属します。任意のシェイプに配置したヘッダー/フッター フィールドが、プレースホルダー マネージャーで設定したテキストを自動取得すると期待しないでください。そのワークフローについては[プレゼンテーションのヘッダーとフッター](/slides/ja/androidjava/presentation-header-and-footer/)をご参照ください。

## **PPTX と PPT の制限事項**

保存・再オープン後にフィールドタイプと実際のテキストの両方を確認してください。識別子を保持しただけでは、アプリケーションが値を計算・表示できることを証明しません。

| フォーマット | フィールドの動作と制限 |
|---|---|
| PPTX | フィールドテキストとともに内部識別子が保存されます。ラウンドトリップテストでは、事前定義されたタイプと上記カスタム識別子の両方が保存・再オープン後も残ります。未知のカスタムタイプはフォールバックテキストを保持しますが、自動計算ロジックは付加されません。他アプリケーションは未サポートの識別子を別の方法で扱う可能性があります。 |
| PPT | 従来のフィールド表現を使用し、互換性がさらに制限されます。ラウンドトリップテストでは、スライド番号と事前定義された日付/時刻フィールドは保存・再オープン後も残ります。通常のスライドテキストボックス内のカスタムフィールドは識別子は残りますがテキストは `*` となり、同様にヘッダーフィールドも `*` が表示されます。カスタムフィールドや未サポートのフィールドコンテキストが可視テキストを保持すると期待しないでください。 |

可搬性のある固定出力が必要な場合は、未サポートフィールドを普通のテキストに変換し、保存前に目的の値を明示的に設定してください。これにより選択したテキストは保持されますが、以降の自動更新は意図的に停止します。対象アプリケーションがフィールド再計算を行う場合は、そちらでもテストを行ってください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかはどうやって判別できますか？**

[IPortion.getField](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iportion/#getField--) を確認してください。null でない場合はフィールドであり、表示テキストだけでは判別できません。

**フィールドを削除するとテキストや書式も削除されますか？**

いいえ。`removeField` は既存のポーションを普通のテキストに変換します。特定の固定日付やフォールバック値が必要な場合は、削除後に明示的にテキストを設定してください。

**内部文字列で新しい日付形式や数式を定義できますか？**

できません。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや Java の日付書式パターンを提供しません。サポートされている事前定義タイプを使用するか、値を普通のテキストとしてフォーマットしてください。

**保存後にプレゼンテーションを再度チェックするのはなぜですか？**

フィールド識別子、計算されたテキスト、書式は別々に検証すべき項目です。フォーマット変換により、フィールド識別子は残っていても可視テキストが変わることがあります。