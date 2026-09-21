---
title: JavaでPowerPointプレゼンテーションのテキストフィールドを管理する
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/java/text-fields/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint プレゼンテーションのテキストフィールドを作成、検査、変更、削除します。書式を保持し、保存された PPTX および PPT ファイルを検証します。"
---
## **概要**

テキスト段落は複数の部分で構成されます。通常の[IPortion](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/)はリテラルテキストを含みますが、フィールド部分は自動的に更新される値（スライド番号や日付など）を示す[IField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifield/)を持ちます。2 つの部分が同じ文字列を表示していても、フィールドを持つのは 1 つだけです。

それらを区別するには[IPortion.getField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getField--)を使用します。通常のテキストでは `null` が返ります。[IPortion.addField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) は既存の部分をフィールドに変換します。ラベルと動的な値を別々の部分に保持すると、値をフィールドに変換してもラベルが置き換えられません。

本ガイドではテキスト内のフィールド、その書式設定、PPTX と PPT での保存方法について説明します。テキストフレームや段落の管理については[Manage Text](/slides/ja/java/manage-text/)をご覧ください。

## **スライド番号フィールドの作成**

以下の完全なサンプルは、リテラルの `Slide ` ラベルに続いて自動更新される番号を含むテキストボックスを作成します。番号のサイズ、太さ、色を設定した後にフィールドを追加し、保存したプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式を確認します。入力ファイルは不要です。

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

新しいプレゼンテーションはスライド番号 1 で開始するため、テキストは `Slide 1` となり、両方のチェックは `true` を出力します。再度開いた後も番号はフィールドのままで、リテラルの `1` ではありません。検証で使用しているキャストとインデックスは、このサンプルで作成されたシェイプと部分を指しています。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/) は[IFieldType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifieldtype/) を実装し、事前定義された値を取得するための以下のメソッドを提供します。適切な値を[addField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-)に渡してください。

| Method | Purpose |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getSlideNumber--) | 現在のスライド番号 |
| [getDateTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getDateTime--) | 描画アプリケーションの既定形式での日付/時刻 |
| [getDateTime1](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getDateTime9--) | 事前定義された日付または日付/時刻の組み合わせ形式 |
| [getDateTime10](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getDateTime13--) | 秒や 12 時間制を含む事前定義の時刻形式 |
| [getHeader](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getHeader--) | ヘッダー フィールド（下記のプレースホルダーと書式制限を参照） |
| [getFooter](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getFooter--) | フッター フィールド |

たとえば[getDateTime3](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#getDateTime3--) は、英語で「日 月名（フル） 年」を表す形式です。これらは任意の Java 日付フォーマット文字列ではなく、事前定義されたフィールド形式です。[setLanguageId](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) で設定した言語や、プレゼンテーションを処理するアプリケーションによって表示結果が変わることがあります。

## **内部文字列からフィールドを作成する**

[addField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#addField-java.lang.String-) の文字列オーバーロードは、内部フィールド識別子を受け取ります。他アプリケーションが提供した識別子を保持したい場合に使用します。識別子から[FieldType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) を構築することもできます。[IFieldType.getInternalString](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifieldtype/#getInternalString--) はその識別子を取得するために公開されています。

この例では、フォールバックテキスト `Report-042` を持つアプリケーション固有の `custom-report-id` フィールドを保存します。識別子自体は計算を登録しません。Aspose.Slides は未知のタイプに対してレポート ID を生成しないため、意味と値の更新はその識別子を理解するアプリケーション側で行う必要があります。

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

この PPTX の往復後、タイプは `custom-report-id`、テキストは `Report-042` のままです。`yyyy-MM-dd` のような文字列を渡すとフィールドタイプが作成されますが、カスタム日付形式は設定されません。任意の形式で固定日付を表示したい場合は、普通のテキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

既存のフィールドは[IField.setType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-)で変更できます。フィールドが存在するか確認してからタイプにアクセスしてください。自動更新を止めるには[IPortion.removeField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#removeField--)を呼び出します。これにより部分と現在のテキストは残りますが、フィールドの関連付けが解除されます。固定値が必要な場合は、フィールドを削除した後にそのテキストを設定してください。

日付/時刻フィールドの処理に関する API 設定は[Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-)をご参照ください。以下のサンプルは、フィールドを普通のテキストに変換する際に明示的な承認日付を使用しています。

`sample.pptx` をダウンロードし、作業ディレクトリに配置してください。サンプルには `UpdatedAt` と `ApprovedDate` という名前のテキストシェイプが 2 つあり、どちらも日付/時刻フィールドと普通のラベルテキストを持ちます。以下の例は通常スライド上のトップレベルテキストシェイプを走査し、日付/時刻フィールドをロング日付形式に変換してイタリック体にし、他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

組み込みの内部識別子 `datetime` および `datetime1` から `datetime13` が認識されます。グループ、テーブル、ノート、レイアウト、マスタはそれぞれのテキストコンテナを走査する必要があり、本サンプルの対象外です。

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

再度開くと、`UpdatedAt` のタイプは `datetime3` で動的なままです。`ApprovedDate` にはフィールドがなく `05 April 2030` がテキストとして残ります。両方の日付部分はイタリック体で、元のフォントサイズ、太字設定、色はそのままです。普通のラベルテキストは変更されていません。検証はサンプルに含まれる 2 つの既知シェイプの最初の部分を読み取ります。

## **テキスト書式の保持**

フィールドを追加、タイプ変更、削除する際は既存の部分を使用してください。これらの操作はその部分の書式を保持します。[IPortion.getPortionFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getPortionFormat--) を使って必要なプロパティだけを変更すれば、サンプルが示すように色やイタリック体だけを変更できます。

1 つのフィールドだけを更新するためにテキストフレーム全体を再構築しないでください。そうすると元の部分境界や個別の書式が失われる可能性があります。また、段落・レイアウト・テーマから継承された書式と、明示的に設定された書式を区別してください。より広範な書式オプションについては[Text Formatting](/slides/ja/java/text-formatting/)をご参照ください。

## **フィールドとヘッダー/フッタープレースホルダー**

フィールドはテキスト部分の一部です。プレースホルダーはフッターやスライド番号などのプレゼンテーションロールを持つシェイプです。普通のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッターマネージャはスライド、レイアウト、マスタ上のプレースホルダー文字列と表示状態を管理し、依存スライドへ伝播させます。カスタムテキストボックス内の番号フィールドは、スライド番号プレースホルダーを使用しない場合でも有用です。逆に、プレースホルダーの可視性を変更しても、無関係なテキストボックス内のフィールドは削除されません。

事前定義されたヘッダーとフッターのタイプは、対応するプレースホルダーやその内容を自動生成しません。特に、通常の PowerPoint スライドにはヘッダー プレースホルダーがなく、ヘッダーはノートページや配布資料に属します。任意のシェイプにあるヘッダー/フッターフィールドがプレースホルダー マネージャで設定されたテキストを自動的に取得すると想定しないでください。そのワークフローについては[Presentation Headers and Footers](/slides/ja/java/presentation-header-and-footer/)をご覧ください。

## **PPTX と PPT の制限**

保存後と再度開いた後の両方で、フィールドタイプと生成されたテキストをチェックしてください。識別子を保持したからといって、アプリケーションがその値を計算・表示できるとは限りません。

| Format | Field behavior and limitations |
|---|---|
| PPTX | フィールド識別子とテキストを共に保存します。往復チェックでは、事前定義タイプと上記のカスタム識別子の両方が保存・再読込後も残っていることが確認できました。未知のカスタムタイプはフォールバックテキストを保持しますが、自動計算ロジックは取得しません。他アプリケーションが未サポートの識別子をどのように扱うかは保証できません。 |
| PPT | 従来のフィールド表現を使用し、互換性がさらに制限されます。往復チェックでは、スライド番号および事前定義の日付/時刻フィールドが保存・再読込後も残っていました。普通のスライドテキストボックス内のカスタムフィールドは識別子は残るもののテキストは `*` になり、同じコンテキストのヘッダーフィールドも `*` を出力しました。カスタムフィールドや未サポートのフィールドコンテキストが可視テキストを保持すると期待しないでください。 |

移植性のある固定出力が必要な場合は、未サポートのフィールドを普通のテキストに変換し、保存前に目的の値を明示的に割り当ててください。これにより選択したテキストは保持されますが、自動更新は意図的に停止します。対象アプリケーションが独自にフィールド再計算を行う場合は、そちらのテストも併せて実施してください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかはどうやって判断しますか？**  
[IPortion.getField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#getField--) を調べます。非 null の値がフィールドであることを示し、表示テキストだけでは判別できません。

**フィールドを削除するとテキストや書式も削除されますか？**  
いいえ。[removeField](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iportion/#removeField--) は既存の部分を普通のテキストに変換します。特定の固定日付やフォールバック値が必要な場合は、削除後に明示的に値を割り当ててください。

**内部文字列で新しい日付形式や数式を定義できますか？**  
できません。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや Java の日付形式パターンを提供しません。サポートされている事前定義タイプを使用するか、値を普通のテキストとしてフォーマットしてください。

**保存後にプレゼンテーションを再度チェックする理由は何ですか？**  
フィールド識別子、計算テキスト、書式は別々に検証すべき項目です。フォーマット変換により、フィールド識別子は残っていても可視結果が変わることがあります。