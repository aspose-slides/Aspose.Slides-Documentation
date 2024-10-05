---
title: ActiveX
type: docs
weight: 80
url: /cpp/activex/
---

ActiveXコントロールはプレゼンテーションで使用されます。Aspose.Slides for C++を使うと、ActiveXコントロールを管理できますが、それらを管理するのは通常のプレゼンテーションシェイプとは少し異なります。Aspose.Slides for C++ 18.1から、このコンポーネントはActiveXコントロールの管理をサポートしています。現在、プレゼンテーションに追加されたActiveXコントロールにアクセスして、そのさまざまなプロパティを使用して変更または削除できます。ActiveXコントロールはシェイプではなく、プレゼンテーションのIShapeCollectionの一部ではなく、別のIControlCollectionに含まれています。この記事では、それらを扱う方法を示します。

## **ActiveXコントロールの変更**
スライド上のテキストボックスやシンプルなコマンドボタンなどの簡単なActiveXコントロールを管理するには：

1. Presentationクラスのインスタンスを作成し、ActiveXコントロールが含まれているプレゼンテーションを読み込みます。
1. インデックスを使用してスライドの参照を取得します。
1. IControlCollectionにアクセスしてスライド内のActiveXコントロールにアクセスします。
1. ControlExオブジェクトを使用してTextBox1 ActiveXコントロールにアクセスします。
1. TextBox1 ActiveXコントロールのさまざまなプロパティ（テキスト、フォント、フォントサイズ、フレームの位置）を変更します。
1. CommandButton1という第二のアクセスコントロールにアクセスします。
1. ボタンのキャプション、フォント、位置を変更します。
1. ActiveXコントロールのフレームの位置をシフトします。
1. 修正されたプレゼンテーションをPPTXファイルに書き込みます。

以下のコードスニペットは、ActiveXコントロールをプレゼンテーションのスライドに更新します。

``` cpp
// ActiveXコントロールを持つプレゼンテーションにアクセス
auto presentation = System::MakeObject<Presentation>(u"ActiveX.pptm");

// プレゼンテーションの最初のスライドにアクセス
auto slide = presentation->get_Slides()->idx_get(0);

// TextBoxテキストの変更
auto control = slide->get_Controls()->idx_get(0);

if (control->get_Name() == u"TextBox1" && control->get_Properties() != nullptr)
{
    String newText = u"変更されたテキスト";
    control->get_Properties()->idx_set(u"Value", newText);

    // 代替画像の変更。PowerpointはActiveXアクティベーション中にこの画像を置き換えるため、時には画像を変更しないのも良いでしょう。
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

// ボタンのキャプションの変更
control = slide->get_Controls()->idx_get(1);

if (control->get_Name() == u"CommandButton1" && control->get_Properties() != nullptr)
{
    String newCaption = u"メッセージボックス";
    control->get_Properties()->idx_set(u"Caption", newCaption);

    // 代替の変更
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

// ActiveXフレームを100ポイント下に移動
for (const auto& ctl : System::IterateOver<Control>(slide->get_Controls()))
{
    SharedPtr<IShapeFrame> frame = control->get_Frame();
    control->set_Frame(System::MakeObject<ShapeFrame>(frame->get_X(), frame->get_Y() + 100, frame->get_Width(), frame->get_Height(), frame->get_FlipH(), frame->get_FlipV(), frame->get_Rotation()));
}

// 編集されたActiveXコントロールを持つプレゼンテーションを保存
presentation->Save(u"withActiveX-edited_out.pptm", SaveFormat::Pptm);

// コントロールを削除
slide->get_Controls()->Clear();

// クリーンアップしたActiveXコントロールを持つプレゼンテーションを保存
presentation->Save(u"withActiveX.cleared_out.pptm", SaveFormat::Pptm);
```

## **メディアプレーヤーActiveXコントロールの追加**
ActiveXコントロールはプレゼンテーションで使用されます。Aspose.Slides for C++を使うと、ActiveXコントロールを追加および管理できますが、それらを管理するのは通常のプレゼンテーションシェイプとは少し異なります。Aspose.Slides for C++ 18.1から、メディアプレーヤーActiveXコントロールを追加するサポートが追加されました。ActiveXコントロールはシェイプではなく、プレゼンテーションのIShapeCollectionの一部ではなく、別のIControlExCollectionに含まれていることを覚えておいてください。この記事では、メディアプレーヤーActiveXコントロールを管理する方法を示します。メディアプレーヤーActiveXコントロールを管理するには、次の手順を実行してください：

1. Presentationクラスのインスタンスを作成し、メディアプレーヤーActiveXコントロールが含まれているサンプルプレゼンテーションを読み込みます。
1. 対象のPresentationクラスのインスタンスを作成し、空のプレゼンテーションインスタンスを生成します。
1. テンプレートプレゼンテーション内のメディアプレーヤーActiveXコントロールを含むスライドを対象のPresentationにクローンします。
1. 対象のPresentation内のクローンしたスライドにアクセスします。
1. IControlCollectionにアクセスしてスライド内のActiveXコントロールにアクセスします。
1. メディアプレーヤーActiveXコントロールにアクセスし、そのプロパティを使用してビデオパスを設定します。
1. プレゼンテーションをPPTXファイルに保存します。

``` cpp
// PPTXファイルを表すPresentationクラスをインスタンス化
auto presentation = System::MakeObject<Presentation>(u"template.pptx");

// 空のプレゼンテーションインスタンスを作成
auto newPresentation = System::MakeObject<Presentation>();

// デフォルトスライドを削除
newPresentation->get_Slides()->RemoveAt(0);

// メディアプレーヤーActiveXコントロールを含むスライドをクローン
newPresentation->get_Slides()->InsertClone(0, presentation->get_Slides()->idx_get(0));

// メディアプレーヤーActiveXコントロールにアクセスし、ビデオパスを設定
newPresentation->get_Slides()->idx_get(0)->get_Controls()->idx_get(0)->get_Properties()->idx_set(u"URL", u"Wildlife.mp4");

// プレゼンテーションを保存
newPresentation->Save(u"LinkingVideoActiveXControl_out.pptx", SaveFormat::Pptx);
```