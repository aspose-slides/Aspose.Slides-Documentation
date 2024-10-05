---
title: Aspose.Slidesを使用したHello Worldアプリケーション
type: docs
weight: 80
url: /cpp/hello-world-application-using-aspose-slides/
---

## **Hello Worldアプリケーションを作成する手順**
このシンプルなアプリケーションでは、スライドの指定された位置に**Hello World**のテキストを持つPowerPointプレゼンテーションを作成します。以下の手順に従って、C++ API用のAspose.Slidesを使用して**Hello World**アプリケーションを作成してください：

- Presentationクラスのインスタンスを作成する
- Presentationのインスタンス化時に作成されるプレゼンテーションの最初のスライドの参照を取得する
- 指定された位置にShapeTypeを矩形とするAutoShapeを追加する
- デフォルトのテキストとしてHello Worldを含むTextFrameをAutoShapeに追加する
- テキストの色を黒に変更する（デフォルトでは白で、白い背景のスライドでは見えないため）
- 形状の線の色を白に変更し、形状の境界線を隠す
- 形状のデフォルトの塗りつぶし形式を削除する
- 最後に、Presentationオブジェクトを使用して、希望のファイル形式でプレゼンテーションを保存する

上記の手順の実装は、以下の例で示されています。

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // 最初のスライドを取得
    auto slide = pres->get_Slides()->idx_get(0);

    // 矩形タイプのAutoShapeを追加
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // 矩形にTextFrameを追加
    shape->AddTextFrame(u"Hello World");

    // テキストの色を黒に変更する（デフォルトは白である）
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // 矩形の線の色を白に変更
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // 形状の塗りつぶし形式を削除
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // プレゼンテーションをディスクに保存
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```