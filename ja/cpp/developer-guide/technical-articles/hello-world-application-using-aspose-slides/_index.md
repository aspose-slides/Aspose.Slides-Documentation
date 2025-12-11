---
title: Aspose.Slides for C++ を使用した Hello World アプリケーション
type: docs
weight: 80
url: /ja/cpp/hello-world-application-using-aspose-slides/
keywords:
- ハローワールド
- アプリケーション
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して最初の C++ アプリを作成します。PPT、PPTX、ODP プレゼンテーションを自動化する準備ができるシンプルな Hello World の例です。"
---

## **Hello World アプリケーションの作成手順**
このシンプルなアプリケーションでは、スライドの指定位置に **Hello World** テキストを持つ PowerPoint プレゼンテーションを作成します。以下の手順に従って、Aspose.Slides for C++ API を使用して **Hello World** アプリケーションを作成してください。

- Presentation クラスのインスタンスを作成する
- Presentation のインスタンス化時に作成されるプレゼンテーションの最初のスライドの参照を取得する
- スライドの指定位置に ShapeType が Rectangle の AutoShape を追加する
- デフォルトテキストとして Hello World を含む TextFrame を AutoShape に追加する
- テキスト色を黒に変更する（デフォルトは白で、白背景のスライドでは見えないため）
- 形状の線の色を白に変更して枠線を非表示にする
- 形状のデフォルトの塗りつぶし形式を削除する
- 最後に、Presentation オブジェクトを使用してプレゼンテーションを希望のファイル形式で書き出す

上記手順の実装は、以下のサンプルで示しています。
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

    // 矩形タイプの AutoShape を追加
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // 矩形に TextFrame を追加
    shape->AddTextFrame(u"Hello World");

    // テキストの色を黒に変更（デフォルトは白）
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // 矩形の線の色を白に変更
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // 形状の塗りつぶし設定をすべて削除
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // プレゼンテーションをディスクに保存
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```
