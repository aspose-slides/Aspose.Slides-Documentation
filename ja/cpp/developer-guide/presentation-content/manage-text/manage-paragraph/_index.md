---
title: C++ で PowerPoint テキスト段落を管理する
linktitle: 段落の管理
type: docs
weight: 40
url: /ja/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- テキストの追加
- 段落の追加
- テキストの管理
- 段落の管理
- 箇条書きの管理
- 段落インデント
- ハンギングインデント
- 段落箇条書き
- 番号付きリスト
- 箇条書きリスト
- 段落プロパティ
- HTML のインポート
- テキストから HTML へ
- 段落から HTML へ
- 段落から画像へ
- テキストから画像へ
- 段落のエクスポート
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、段落、ポーション、箇条書き、番号付きリスト、インデント、HTML コンテンツ、段落画像の作成と書式設定方法を学びます。"
---
## **概要**

Aspose.Slides for C++ はテキストをテキストフレーム、段落、ポーションの階層として表現します:

* [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) はシェイプ内のテキストコンテナを表し、その段落コレクションへのアクセスを提供します。
* [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) はテキストフレーム内の 1 つの段落を表し、ポーションと段落レベルの書式設定へのアクセスを提供します。
* [IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/) は段落内のテキストランを表します。各ポーションは独自のテキストと文字レベルの書式設定を持つことができます。

したがって、段落は複数のポーションを使用することで、フォント、色、サイズ、その他の書式が異なるテキストを含めることができます。

## **段落の作成と書式設定**

### **複数のポーションを持つ段落の作成**

以下の手順は、3 つの段落を持ち、各段落に 3 つのポーションを含むテキストフレームを作成します:

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用して目的のスライドへの参照にアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. デフォルトの段落を使用し、テキストフレームにさらに 2 つの [IParagraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/) オブジェクトを追加します。
6. 各段落に 3 つのポーションを含めるのに十分な [IPortion](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/) オブジェクトを追加します。デフォルトの段落にはすでに空のポーションが 1 つ含まれています。
7. 各ポーションのテキストを設定します。
8. [IPortion::get_PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/get_portionformat/) を使用して文字レベルの書式設定を適用します。
9. 変更したプレゼンテーションを保存します。

この C++ の例は手順を実装しています：
```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **箇条書きと番号付きリストの作成**

### **箇条書きまたは番号付きリストの作成**

箇条書きと番号付けは関連項目をスキャンしやすくします。Aspose.Slides では、リスト設定は [IBulletFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/) を通じて定義されます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用して目的のスライドへの参照にアクセスします。
3. 選択したスライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
5. テキストフレームからデフォルトの段落を削除します。
6. シンボル箇条書き用に [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) を作成します。
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_type/) を [BulletType::Symbol](https://reference.aspose.com/slides/ja/cpp/aspose.slides/bullettype/) に設定し、箇条書き文字を指定します。
8. 段落テキスト、インデント、箇条書きの色、高さを設定します。
9. 段落をテキストフレームに追加します。
10. 2 番目の段落を作成し、[IBulletFormat::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_type/) を [BulletType::Numbered](https://reference.aspose.com/slides/ja/cpp/aspose.slides/bullettype/) に設定します。
11. 番号付き箇条書きスタイルを構成し、段落をテキストフレームに追加します。
12. プレゼンテーションを保存します。

この C++ の例はシンボル箇条書きと番号付き箇条書きを作成します：
```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **画像箇条書きの使用**

画像箇条書きを使用すると、シンボルや数字の代わりにカスタム画像を使用できます。

1. Presentation クラスのインスタンスを作成します。
2. インデックスを使用して目的のスライドへの参照にアクセスします。
3. [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加し、その [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
4. テキストフレームからデフォルトの段落を削除します。
5. 箇条書き画像をロードし、[IPPImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ippimage/) としてプレゼンテーションの画像コレクションに追加します。
6. [Paragraph](https://reference.aspose.com/slides/ja/cpp/aspose.slides/paragraph/) を作成し、テキストを設定します。
7. [IBulletFormat::set_Type](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_type/) を [BulletType::Picture](https://reference.aspose.com/slides/ja/cpp/aspose.slides/bullettype/) に設定します。
8. [ISlidesPicture::set_Image](https://reference.aspose.com/slides/ja/cpp/aspose.slides/islidespicture/set_image/) で画像を割り当て、箇条書きの高さを設定します。
9. 段落をテキストフレームに追加します。
10. 変更したプレゼンテーションを保存します。

この C++ の例は画像箇条書きを作成します：
```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **階層付きリストの作成**

[IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_depth/) を設定して、リスト内の段落を異なるレベルに配置します。最上位レベルの深さは `0` です。

1. Presentation を作成し、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加し、そのテキストフレームからデフォルトの段落をクリアします。
3. 4 つの段落を作成し、箇条書き記号を構成します。
4. それらの [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_depth/) 値をそれぞれ `0`、`1`、`2`、`3` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この C++ の例は 4 レベルの箇条書きリストを作成します：
```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **番号付きリスト項目の開始番号をカスタム値に設定**

[IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) を使用して、番号付き段落の開始番号を設定します。

1. Presentation を作成し、スライドに [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
2. シェイプのテキストフレームからデフォルトの段落をクリアします。
3. 3 つの番号付き段落を作成します。
4. それぞれの段落に対して [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) を `2`、`3`、`7` に設定します。
5. 段落をテキストフレームに追加し、プレゼンテーションを保存します。

この C++ の例は各段落にカスタム開始番号を割り当てます：
```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **段落のレイアウトと終了プロパティの制御**

### **最初の行インデントの設定**

[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) を使用して段落の最初の行インデントを制御します。このメソッドは段落本体の左余白に対して最初の行だけを移動させます。正の値は最初の行を右へシフトし、残りの行は段落本文に揃ったままです。

全体の段落を移動したい場合は [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginleft/) を使用し、最初の行だけを移動したい場合は [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) を使用します。

以下の例は複数の段落を作成し、異なる [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) 値を適用して最初の行インデントが段落レイアウトに与える影響を示しています。

1. Presentation クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 複数の段落を作成し、各段落に異なる [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) 値を設定します。
6. 段落をテキストフレームに追加します。
7. 変更したプレゼンテーションを保存します。

このコードは段落インデントの設定方法を示します：
```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The first-line indent of the paragraphs](first_line_indent.png)

### **ハンギングインデントの設定**

ハンギングインデントは、最初の行が残りの行の左側から開始する段落レイアウトです。Aspose.Slides では [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) に負の値を設定して、最初の行を段落本文の左側にシフトさせます。

実際には、[IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginleft/) が段落本文の左位置を定義し、[IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) がその余白に対する最初の行の位置を定義します。ハンギングインデントを作成するには、正の margin-left 値と負の indent 値を組み合わせます。

この書式設定は、文献目録、参考文献、用語集エントリなど、折り返し行が段落本文の下に揃う必要がある場合に便利です。

1. Presentation クラスのインスタンスを作成します。
2. 対象スライドにアクセスします。
3. スライドに矩形の [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
4. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスし、デフォルトの段落を削除します。
5. 各段落に対して正の [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_marginleft/) 値を設定します。
6. ハンギングインデント効果を作成するために負の [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_indent/) 値を設定します。
7. 段落をテキストフレームに追加します。
8. 変更したプレゼンテーションを保存します。

このコードは段落のハンギングインデント設定方法を示します：
```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：

![The hanging indent of the paragraphs](hanging_indent.png)

### **段落末端の実行プロパティの設定**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) は段落終了マークの書式設定を制御します。以下の例は第 2 段落の終了マークにフォントサイズとラテンフォントを割り当てます。

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) を読み込み、スライドにアクセスします。
2. [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加し、デフォルトの段落をクリアします。
3. 2 つの段落を作成し、テキストポーションを追加します。
4. 第 2 段落の終了マーク用に [PortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/portionformat/) を作成します。
5. [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_fontheight/) と [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_latinfont/) を設定します。
6. [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) で書式を割り当て、プレゼンテーションを保存します。

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **レンダリングされた行数のカウント**

[IParagraph::GetLinesCount](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getlinescount/) を使用して、テキストレイアウト後に段落が占める行数（自動折り返しを含む）をカウントします。これはプレゼンテーションテンプレートでテキストの長さやレイアウトを確認する際に便利です。

段落は [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/get_paragraphs/) の 1 項目であり、複数のレンダリング行を占めることがあります。段落内の明示的な改行は新しい行を強制しますが、別の段落は作成しません。自動折り返しは利用可能な幅に基づいて行を生成し、テキストに明示的な改行文字は挿入しません。そのため、段落数や改行文字だけでレンダリング行数を求めることはできません。

以下の例はテキストシェイプを作成し、行数をカウントし、シェイプを狭めてからテキストを短い文字列に置き換えます。折り返しは有効で autofit は無効にしているため、シェイプ幅が折り返しを制御し、テキストやシェイプが自動で縮小されません。シェイプのサイズはポイント単位です。最後に別の段落を追加し、テキストフレーム全体の行数を合計します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

このテキストとサイズの場合、シェイプを狭めると行数が増え、短い文字列に置き換えると減ります。正確なカウントはフォントの可用性と置換、フォントサイズ、余白、インデント、折り返し、autofit 設定に依存します。テンプレートを確認する際は、対象環境で使用するフォントとレイアウト設定を使用してください。

行数だけではテキストがコンテナを超えているかは判断できません。利用可能な高さ、行の高さ、段落および行間隔、autofit の動作も重要です。折り返しが無効の場合、1 行でも利用可能な幅を超えることがあります。

## **段落コンテンツのインポートとエクスポート**

### **HTML テキストを段落にインポート**

[IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphcollection/addfromhtml/) を使用して、HTML マークアップをテキストフレーム内の段落とポーションに変換します。

1. Presentation クラスのインスタンスを作成します。
2. スライドにアクセスし、[IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を追加します。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスし、デフォルトの段落をクリアします。
4. ソース HTML ファイルを読み取ります。
5. HTML 文字列を [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphcollection/addfromhtml/) に渡します。
6. 変更したプレゼンテーションを保存します。

この C++ の例は HTML をテキストフレームにインポートします：
```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **段落テキストを HTML にエクスポート**

[IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphcollection/exporttohtml/) を使用して、選択した範囲の段落を HTML としてエクスポートします。

1. Presentation クラスのインスタンスを作成し、目的のプレゼンテーションをロードします。
2. スライドにアクセスし、テキストを含む [IAutoShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iautoshape/) を見つけます。
3. シェイプの [ITextFrame](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframe/) にアクセスします。
4. 開始段落インデックスとエクスポートする段落数を指定して、[IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphcollection/exporttohtml/) を呼び出します。
5. 返された HTML 文字列をファイルに書き込みます。

この C++ の例は最初のテキストシェイプからすべての段落をエクスポートします：
```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **段落を画像としてレンダリング**

[IParagraph::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getimage/) は個々の段落を直接レンダリングし、[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) を返します。結果は [IImage::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/save/) でファイルまたはストリームに保存できます。包含シェイプ全体をレンダリングしたり、ビットマップを手動で切り取る必要はありません。

段落が親コレクションに存在しない、または有効なレンダリング境界がない、あるいはレンダリングできない場合、[IParagraph::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getimage/) は `nullptr` を返すことがあります。保存前に結果を確認し、使用後は返された画像を破棄してください。

#### **デフォルトスケールで段落をレンダリング**

sample.pptx というプレゼンテーションファイルに 1 枚のスライドがあり、最初のシェイプが 3 つの段落を含むテキストボックスであると仮定します。

![The text box with three paragraphs](paragraph_to_image_input.png)

以下の例は通常のテキストシェイプ内の第 2 段落をデフォルトスケールでレンダリングし、PNG 形式で画像を保存します。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

結果：

![The paragraph image](paragraph_to_image_output.png)

#### **テーブルセル内の段落をスケーリングしてレンダリング**

`float scaleX` と `float scaleY` パラメーターを受け取る [IParagraph::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getimage/) のオーバーロードを使用して、水平および垂直のスケール係数を設定します。以下の例はテーブルを作成し、最初のセルの段落をデフォルト幅と高さの 2 倍でレンダリングし、PNG 画像として保存します。

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

スケール係数 `1` はその軸をデフォルトのピクセルサイズのままにします。たとえば、両方の係数を `2` にすると、幅と高さがほぼ 2 倍になり、ピクセル数は 4 倍になります。大きな係数はズームや高解像度出力でテキストをより鮮明にしますが、メモリ使用量とファイルサイズも増加します。`1` 未満の係数は詳細が少ない小さな画像を生成します。段落のアスペクト比を保つには同じ係数を使用し、水平と垂直で異なる係数を使用すると出力がそれぞれ伸びます。

[IShape::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishape/getimage/) でシェイプ全体をレンダリングすることは、シェイプの塗りつぶし、枠線、その他の視覚的コンテキストを含める必要がある場合に有用です。段落だけの画像が必要な場合は [IParagraph::GetImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getimage/) を使用してください。

## **よくある質問**

**テキストフレーム内の行折り返しを完全に無効にできますか？**

はい。`[ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itextframeformat/set_wraptext/)` を使用して折り返しを無効にすると、行はテキストフレームの端で改行されなくなります。

**特定の段落のスライド上の正確な境界を取得するにはどうすればよいですか？**

`[IParagraph::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraph/getrect/)` を使用して段落の境界矩形を取得できます。`[IPortion::GetRect](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iportion/getrect/)` は個々のポーションの境界を提供します。

**段落の配置（左寄せ、右寄せ、中央揃え、均等割り付け）はどこで制御しますか？**

`[IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iparagraphformat/set_alignment/)` は段落レベルの設定であり、個々のポーションの書式設定に関係なく段落全体に適用されます。

**段落の一部に校正言語を設定できますか？**

はい。`[IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ibaseportionformat/set_languageid/)` を個々のポーションに使用すれば、1 つの段落内に複数言語のテキストを含めることができます。