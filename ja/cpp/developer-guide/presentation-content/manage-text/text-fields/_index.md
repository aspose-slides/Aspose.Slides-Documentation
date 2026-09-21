---
title: C++ で PowerPoint プレゼンテーションのテキストフィールドを管理する
linktitle: テキストフィールド
type: docs
weight: 52
url: /ja/cpp/text-fields/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint プレゼンテーションのテキストフィールドを作成、検査、変更、削除します。書式を保持し、保存した PPTX および PPT ファイルを確認します。"
---
## **概要**

テキスト段落はポーションで構成されます。通常の[IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/)はリテラルテキストを含み、フィールドポーションは[IField](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifield/)も持ち、そのタイプはスライド番号や日付など自動的に更新される値を識別します。2つのポーションは同じ文字を表示できますが、フィールドを持つのは一方だけです。

既存のテキストとフィールドを区別するには[IPortion::get_Field](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/get_field/)を使用します: 通常のテキストの場合は `nullptr` を返します。[IPortion::AddField](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/addfield/)は既存のポーションをフィールドに変換します。ラベルとその動的な値は別々のポーションに保持し、値を変換してもラベルが置き換えられないようにします。

このガイドではテキスト内のフィールド、フィールドの書式設定、PPTX および PPT への保存について説明します。テキストフレームや段落については[Manage Text](/slides/ja/cpp/manage-text/)をご覧ください。

## **スライド番号フィールドの作成**

以下の例では、リテラルの `Slide ` ラベルの後に自動的に更新される番号を含むテキストボックスを作成します。フィールドを追加する前に番号のサイズ、太さ、色を設定し、保存されたプレゼンテーションを再度開いてフィールドのタイプ、テキスト、書式を確認します。入力ファイルは必要ありません。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
shape->AddTextFrame(u"Slide ");
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);

auto numberPortion = System::MakeObject<Portion>();
numberPortion->get_PortionFormat()->set_FontHeight(24);
numberPortion->get_PortionFormat()->set_FontBold(NullableBool::True);
numberPortion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
numberPortion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_DarkBlue());
paragraph->get_Portions()->Add(numberPortion);
numberPortion->AddField(FieldType::get_SlideNumber());

presentation->Save(u"slide_number.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"slide_number.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedNumber = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(1);
auto field = savedNumber->get_Field();
auto hasNumberField = field != nullptr && field->get_Type()->get_InternalString() == FieldType::get_SlideNumber()->get_InternalString();
auto format = savedNumber->get_PortionFormat();
auto formattingPreserved = format->get_FontHeight() == 24 && format->get_FontBold() == NullableBool::True;
formattingPreserved &= format->get_FillFormat()->get_SolidFillColor()->get_Color().ToArgb() == System::Drawing::Color::get_DarkBlue().ToArgb();

System::Console::WriteLine(u"Text: {0}", savedShape->get_TextFrame()->get_Text());
System::Console::WriteLine(u"Slide number field: {0}", hasNumberField);
System::Console::WriteLine(u"Formatting preserved: {0}", formattingPreserved);
reopened->Dispose();
```

新しいプレゼンテーションはスライド番号 1 から開始するため、期待されるテキストは `Slide 1` で、両方のチェックは `True` を出力するはずです。再度開いた後も番号はフィールドのままで、リテラルの `1` ではありません。検証でのキャストとインデックスは、この例で作成されたシェイプとポーションを指しています。

## **フィールドタイプの選択**

[FieldType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/) は[IFieldType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifieldtype/)を実装し、以下の事前定義値を提供します。[AddField](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/addfield/)に適切な値を渡してください。

| アクセサ | 目的 |
|---|---|
| [get_SlideNumber](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_slidenumber/) | 現在のスライド番号。 |
| [get_DateTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_datetime/) | レンダリング アプリケーションのデフォルト形式での日付/時刻。 |
| [get_DateTime1](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_datetime1/)–[get_DateTime9](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_datetime9/) | 事前定義された日付または日付/時刻の組み合わせ形式。 |
| [get_DateTime10](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_datetime10/)–[get_DateTime13](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_datetime13/) | 事前定義された時刻形式、秒や12時間制のオプションを含む。 |
| [get_Header](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_header/) | ヘッダー フィールド; 以下のプレースホルダーと書式制限をご参照ください。 |
| [get_Footer](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_footer/) | フッター フィールド。 |

例えば、[get_DateTime3](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/get_datetime3/) は英語で日、フル月名、年を提供します。これらは事前定義されたフィールド書式であり、任意の日付書式文字列ではありません。ポーションの言語は[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/)で設定でき、プレゼンテーションを処理するアプリケーションが表示結果に影響を与えることがあります。

## **内部文字列からフィールドを作成**

[AddField](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/addfield/) の文字列オーバーロードは内部フィールド識別子を受け取ります。他のアプリケーションが提供した識別子を保持したい場合に使用します。識別子から[FieldType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fieldtype/fieldtype/) を構築することもできます。[IFieldType::get_InternalString](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifieldtype/get_internalstring/) はその識別子を取得できます。

この例では、アプリケーション固有の `custom-report-id` フィールドを、フォールバックテキスト `Report-042` と共に保存します。入力ファイルは必要ありません。識別子は計算を登録しません: Aspose.Slides は未知のタイプのレポート ID を生成しません。この識別子の意味と値の更新は、識別子を理解するアプリケーションが提供する必要があります。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ShapeType.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
shape->AddTextFrame(u"Report-042");
auto portion = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
portion->AddField(u"custom-report-id");
presentation->Save(u"custom_field.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"custom_field.pptx");
auto savedShape = System::ExplicitCast<IAutoShape>(reopened->get_Slide(0)->get_Shape(0));
auto savedPortion = savedShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
auto field = savedPortion->get_Field();
auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
System::Console::WriteLine(u"Type: {0}", typeName);
System::Console::WriteLine(u"Text: {0}", savedPortion->get_Text());
reopened->Dispose();
```

この PPTX の往復後、期待されるタイプは `custom-report-id` で、期待されるテキストは `Report-042` です。`yyyy-MM-dd` のような文字列を渡すとフィールドタイプの名前になり、カスタム日付形式は設定されません。任意の形式で固定日付を使用したい場合は、通常テキストを使用してください。

## **日付/時刻フィールドの検査、変更、削除**

既存のフィールドタイプは[IField::get_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifield/get_type/)で取得し、[IField::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifield/set_type/)で変更できます。フィールドが存在することを確認してからタイプにアクセスしてください。自動更新を停止するには[IPortion::RemoveField](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/removefield/)を呼び出します。これによりポーションは残り、その現在のテキストが保持されますが、フィールドの関連付けが削除されます。特定の固定値が必要な場合は、フィールドを削除した後にそのテキストを割り当てます。

日付/時刻フィールド処理に関連する API 設定については[Presentation::set_CurrentDateTime](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/set_currentdatetime/)をご覧ください。以下の例では、フィールドを通常のテキストに変換する際に明示的な承認日付を使用しています。

[sample.pptx](sample.pptx) をダウンロードし、作業ディレクトリに配置します。このファイルには、2 つの名前付きテキストシェイプ `UpdatedAt` と `ApprovedDate` があり、それぞれに日付/時刻フィールドと通常テキストラベルが含まれています。以下の例は通常スライド上のトップレベルテキストシェイプを走査し、日付/時刻フィールドを長い日付形式に変更してイタリック体にし、他の書式は保持します。`ApprovedDate` のフィールドだけが固定テキストになります。

サンプルは組み込みの内部識別子 `datetime` および `datetime1` から `datetime13` を認識します。グループ、テーブル、ノート、レイアウト、マスタはそれぞれのテキストコンテナを走査する必要があり、この例の範囲外です。

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IField.h>
#include <DOM/IFieldType.h>
#include <DOM/FieldType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/date_time.h>
#include <system/globalization/culture_info.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto approvalDate = System::DateTime(2030, 4, 5);
auto culture = System::Globalization::CultureInfo::GetCultureInfo(u"en-US");

for (auto slide : presentation->get_Slides())
{
    for (auto shape : slide->get_Shapes())
    {
        auto textShape = System::DynamicCast<IAutoShape>(shape);
        if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
            continue;

        for (auto paragraph : textShape->get_TextFrame()->get_Paragraphs())
        {
            for (auto portion : paragraph->get_Portions())
            {
                auto field = portion->get_Field();
                if (field == nullptr)
                    continue;

                auto typeName = field->get_Type()->get_InternalString();
                auto isDateTime = typeName == u"datetime";
                for (auto formatNumber = 1; formatNumber <= 13; ++formatNumber)
                {
                    auto identifier = System::String::Format(u"datetime{0}", formatNumber);
                    isDateTime |= typeName == identifier;
                }
                if (!isDateTime)
                    continue;

                field->set_Type(FieldType::get_DateTime3());
                portion->get_PortionFormat()->set_LanguageId(u"en-US");
                portion->get_PortionFormat()->set_FontItalic(NullableBool::True);

                if (textShape->get_Name() == u"ApprovedDate")
                {
                    portion->RemoveField();
                    auto fixedDate = approvalDate.ToString(u"dd MMMM yyyy", culture);
                    portion->set_Text(fixedDate);
                }
            }
        }
    }
}

presentation->Save(u"updated_dates.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopened = System::MakeObject<Presentation>(u"updated_dates.pptx");
for (auto shape : reopened->get_Slide(0)->get_Shapes())
{
    auto textShape = System::DynamicCast<IAutoShape>(shape);
    if (textShape == nullptr || textShape->get_TextFrame() == nullptr)
        continue;
    if (textShape->get_Name() != u"UpdatedAt" && textShape->get_Name() != u"ApprovedDate")
        continue;

    auto portion = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
    auto field = portion->get_Field();
    auto typeName = field != nullptr ? field->get_Type()->get_InternalString() : u"ordinary text";
    System::Console::WriteLine(u"{0}: {1}; {2}", textShape->get_Name(), typeName, portion->get_Text());
    auto isItalic = portion->get_PortionFormat()->get_FontItalic() == NullableBool::True;
    System::Console::WriteLine(u"Italic: {0}", isItalic);
}
reopened->Dispose();
```

再度開くと、`UpdatedAt` はタイプ `datetime3` で動的なままです。`ApprovedDate` はフィールドがなくなり、`05 April 2030` を含みます。両方の日付ポーションはイタリック体で、元のフォントサイズ、太字設定、色はそのままです。通常のテキストラベルは変更されません。検証は、提供されたサンプル内の 2 つの既知シェイプの最初のポーションを読み取ります。

## **テキスト書式の保持**

フィールドを追加、タイプ変更、または削除する際は、既存のポーションを使用してください。これらの操作はそのポーションの書式を保持します。[IPortion::get_PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/get_portionformat/) を使用して必要なプロパティだけを変更します。例では色やイタリック体の変更を行っています。

1 つのフィールドを更新するだけのためにテキストフレーム全体を再構築しないでください。そうすると元のポーション境界や個別の書式が失われる可能性があります。また、段落、レイアウト、テーマから継承された書式と明示的に設定された書式を区別してください。詳細な書式オプションについては[Text Formatting](/slides/ja/cpp/text-formatting/)をご覧ください。

## **フィールドとヘッダー/フッタープレースホルダー**

フィールドはテキストポーションの一部です。プレースホルダーはフッターやスライド番号などのプレゼンテーション上の役割を持つシェイプです。通常のテキストボックスにフィールドを追加しても、そのシェイプがプレースホルダーになるわけではありません。

ヘッダー/フッターマネージャーは、スライド、レイアウト、マスタ上のプレースホルダー テキストと可視性を制御し、依存スライドへ伝搬します。カスタムテキストボックス内の番号フィールドは、スライド番号プレースホルダーを使用しない場合でも有用です。逆に、プレースホルダーの可視性を変更しても、無関係なテキストボックスからフィールドが削除されることはありません。

事前定義されたヘッダーとフッタのタイプは、対応するプレースホルダーを作成したり、コンテンツを供給したりしません。特に、通常の PowerPoint スライドにはヘッダープレースホルダーがなく、ヘッダーはノートページや配布資料に属します。任意のシェイプ内のヘッダーまたはフッターフィールドがプレースホルダー マネージャーで設定されたテキストを自動的に取得すると想定しないでください。そのワークフローについては[Presentation Headers and Footers](/slides/ja/cpp/presentation-header-and-footer/)をご覧ください。

## **PPTX および PPT の制限**

保存して再度開いた後、フィールドタイプとその結果のテキストの両方を確認してください。識別子を保持しただけでは、アプリケーションがその値を計算または表示できることを証明しません。

| 形式 | フィールドの動作と制限 |
|---|---|
| PPTX | フィールドテキストと共に内部フィールド識別子を保存します。上記の例を使用して、保存・再オープン後に事前定義タイプとカスタム識別子を確認してください。未知のカスタムタイプは自動計算ロジックを取得しません。他のアプリケーションは未サポートの識別子を異なる方法で扱う可能性があります。 |
| PPT | レガシーフィールド表現を使用し、互換性が限定的です。スライド番号や事前定義日付/時刻フィールドはレガシー表現です。未サポートのカスタムフィールドや通常スライドテキストボックス内のヘッダーフィールドはテキストとして `*` を出力することがあります。カスタムフィールドや未サポートのフィールドコンテキストが可視テキストを保持すると期待しないでください。 |

ポータブルで固定された出力が必要な場合は、未サポートのフィールドを通常テキストに変換し、保存前に希望の値を明示的に割り当ててください。これによりテキストは保持されますが、自動更新は意図的に停止します。フィールドの再計算がワークフローの一部である場合は、対象アプリケーションでもテストしてください。

## **FAQ**

**表示されている番号や日付がフィールドかどうかを判別するには？**  
[IPortion::get_Field](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/get_field/) をチェックします。null でない値はフィールドを示します; 表示されているテキストだけでは判別できません。

**フィールドを削除するとテキストや書式も削除されますか？**  
いいえ。[RemoveField](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/removefield/) は既存のポーションを通常テキストに変換します。特定の固定日付やフォールバックテキストが必要な場合は、後で明示的に値を割り当ててください。

**内部文字列で新しい日付形式や数式を定義できますか？**  
いいえ。内部文字列はフィールドタイプを識別するだけです。未知の識別子は評価ロジックや日付書式パターンを提供しません。サポートされた事前定義タイプを使用するか、値を普通テキストとして書式設定してください。

**保存後にプレゼンテーションを再度チェックするのはなぜですか？**  
フィールド識別子、計算テキスト、書式は別々に検証すべき項目です。フォーマット変換により、フィールド識別子は残っていても表示結果が変わることがあります。