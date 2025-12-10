---
title: "C++ を使用したプレゼンテーションでの ActiveX コントロールの管理"
linktitle: "ActiveX"
type: docs
weight: 80
url: /ja/cpp/activex/
keywords:
- "ActiveX"
- "ActiveX コントロール"
- "ActiveX の管理"
- "ActiveX の追加"
- "ActiveX の変更"
- "メディア プレーヤー"
- "PowerPoint"
- "プレゼンテーション"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ が ActiveX を活用して PowerPoint プレゼンテーションを自動化および強化し、開発者にスライドの強力な制御を提供する方法を学びます。"
---

ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for C++ は ActiveX コントロールの管理を可能にしますが、管理はやや複雑で通常のプレゼンテーション シェイプとは異なります。Aspose.Slides for C++ 18.1 以降、このコンポーネントは ActiveX コントロールの管理をサポートします。現在、プレゼンテーションに既に追加された ActiveX コントロールにアクセスし、さまざまなプロパティを使用して変更または削除できます。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部でもなく、別個の IControlCollection に属していることを忘れないでください。この記事では、それらの操作方法を示します。

## **ActiveX コントロールの変更**
1. Presentation クラスのインスタンスを作成し、ActiveX コントロールが含まれるプレゼンテーションを読み込みます。
1. インデックスでスライド参照を取得します。
1. IControlCollection にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. ControlEx オブジェクトを使用して TextBox1 ActiveX コントロールにアクセスします。
1. テキスト、フォント、フォント高さ、フレーム位置など、TextBox1 ActiveX コントロールのさまざまなプロパティを変更します。
1. CommandButton1 と呼ばれる二番目のコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveX コントロールのフレーム位置をシフトします。
1. 変更されたプレゼンテーションを PPTX ファイルに書き込みます。

以下のコードスニペットは、プレゼンテーション スライド上の ActiveX コントロールを下記のスライドのように更新します。
``` cpp
// ActiveX コントロールを使用したプレゼンテーションにアクセス
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// プレゼンテーションの最初のスライドにアクセス
auto slide = presentation->get_Slides()->idx_get(0);

// テキストボックスのテキストを変更
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"Changed text";
    control->get_Properties()->idx_set(u"Value", newText);

    // 代替画像を変更します。PowerPoint は ActiveX の有効化時にこの画像を置き換えるため、場合によっては画像を変更せずにそのままにしておいても問題ありません。
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Window));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    graphics->DrawString(newText, font, brush, 10.0f, 4.0f);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);

    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ボタンのキャプションを変更
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"MessageBox";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // 代替画像を変更
    auto image = System::MakeObject<Bitmap>((int32_t)control->get_Frame()->get_Width(), (int32_t)control->get_Frame()->get_Height());
    auto graphics = Graphics::FromImage(image);
    auto brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::Control));
    graphics->FillRectangle(brush, 0, 0, image->get_Width(), image->get_Height());

    auto font = System::MakeObject<Font>(control->get_Properties()->idx_get(u"FontName"), 14.0f);
    brush = System::MakeObject<SolidBrush>(Color::FromKnownColor(KnownColor::WindowText));
    SizeF textSize = graphics->MeasureString(newCaption, font, std::numeric_limits<int32_t>::max());
    graphics->DrawString(newCaption, font, brush, (image->get_Width() - textSize.get_Width()) / 2, (image->get_Height() - textSize.get_Height()) / 2);

    auto pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLightLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height() - 1), Point(0, 0), System::Drawing::Point(image->get_Width() - 1, 0) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlLight), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 2), Point(1, 1), System::Drawing::Point(image->get_Width() - 2, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, image->get_Height() - 1), System::Drawing::Point(image->get_Width() - 1, 1) }));

    pen = System::MakeObject<Pen>(Color::FromKnownColor(KnownColor::ControlDarkDark), 1.0f);
    graphics->DrawLines(pen, System::MakeArray<Point>({ System::Drawing::Point(0, image->get_Height()), System::Drawing::Point(image->get_Width(), image->get_Height()), System::Drawing::Point(image->get_Width(), 0) }));

    System::SharedPtr<System::IO::MemoryStream> ms = System::MakeObject<System::IO::MemoryStream>();
    image->Save(ms, System::Drawing::Imaging::ImageFormat::get_Png());
    ms->Seek(0, System::IO::SeekOrigin::Begin);
    control->get_SubstitutePictureFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(ms));
}

// ActiveX フレームを 100 ポイント下に移動
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// 編集された ActiveX コントロール付きでプレゼンテーションを保存
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// 現在、コントロールを削除しています
slide->get_Controls()->Clear();

// ActiveX コントロールをクリアした状態でプレゼンテーションを保存
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```


## **Media Player ActiveX コントロールの追加**
ActiveX コントロールはプレゼンテーションで使用されます。Aspose.Slides for C++ は ActiveX コントロールの追加と管理を可能にしますが、管理はやや複雑で通常のプレゼンテーション シェイプとは異なります。Aspose.Slides for C++ 18.1 以降、Media Player ActiveX コントロールの追加サポートが Aspose.Slides に追加されました。ActiveX コントロールはシェイプではなく、プレゼンテーションの IShapeCollection の一部でもなく、別個の IControlExCollection に属していることを覚えておいてください。この記事では、それらの操作方法を示します。Media Player ActiveX コントロールを管理するには、以下の手順を実行してください。

1. Presentation クラスのインスタンスを作成し、Media Player ActiveX コントロールが含まれるサンプル プレゼンテーションを読み込みます。
1. ターゲットの Presentation クラスのインスタンスを作成し、空のプレゼンテーション インスタンスを生成します。
1. テンプレート プレゼンテーション内の Media Player ActiveX コントロールがあるスライドをターゲットの Presentation にクローンします。
1. ターゲットの Presentation でクローンされたスライドにアクセスします。
1. IControlCollection にアクセスして、スライド内の ActiveX コントロールにアクセスします。
1. Media Player ActiveX コントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションを PPTX ファイルに保存します。
``` cpp
// PPTX ファイルを表す Presentation クラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// 空のプレゼンテーション インスタンスを作成
auto newPresentation = System::MakeObject<Presentation>();

// デフォルトのスライドを削除
newPresentation->get_Slides()->RemoveAt(0);

// Media Player ActiveX コントロールを含むスライドをクローン
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// Media Player ActiveX コントロールにアクセスし、ビデオのパスを設定
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// プレゼンテーションを保存
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**Aspose.Slides は C++ ランタイムで実行できなくても、読み取りと再保存時に ActiveX コントロールを保持しますか？**  
はい。Aspose.Slides はそれらをプレゼンテーションの一部として扱い、プロパティやフレームを読み取り/変更できます。コントロール自体を実行する必要はありません。

**プレゼンテーションにおける ActiveX コントロールは OLE オブジェクトとどう異なりますか？**  
ActiveX コントロールはインタラクティブな管理コントロール（ボタン、テキスト ボックス、メディアプレーヤー）です。一方、[OLE](/slides/ja/cpp/manage-ole/) は埋め込みアプリケーション オブジェクト（例: Excel ワークシート）を指します。これらは保存・処理方法が異なり、プロパティ モデルも異なります。

**ファイルが Aspose.Slides によって変更された場合、ActiveX のイベントや VBA マクロは機能しますか？**  
Aspose.Slides は既存のマークアップとメタデータを保持しますが、イベントやマクロは Windows 上の PowerPoint でセキュリティが許可された場合にのみ実行されます。ライブラリ自体は VBA を実行しません。