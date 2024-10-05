---
title: プレースホルダーの管理
type: docs
weight: 10
url: /cpp/manage-placeholder/
keywords: "プレースホルダー, プレースホルダーのテキスト, プロンプトテキスト, PowerPoint プレゼンテーション, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションのプレースホルダーのテキストとプロンプトテキストを変更する"
---

## **プレースホルダーのテキストを変更する**
[Aspose.Slides for C++](/slides/cpp/)を使用すると、プレゼンテーションのスライド上のプレースホルダーを見つけて修正できます。Aspose.Slidesを使用すると、プレースホルダーのテキストを変更できます。

**前提条件**: プレースホルダーが含まれるプレゼンテーションが必要です。このようなプレゼンテーションは、標準のMicrosoft PowerPointアプリで作成できます。

以下は、Aspose.Slidesを使用してそのプレゼンテーション内のプレースホルダーのテキストを置き換える手順です。

1. [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスをインスタンス化し、プレゼンテーションを引数として渡します。
2. インデックスを通じてスライドの参照を取得します。
3. 形状を反復処理してプレースホルダーを見つけます。
4. プレースホルダーの形状を[`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/)にキャストし、[`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/)に関連付けられた[`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/)を使用してテキストを変更します。
5. 修正したプレゼンテーションを保存します。

以下のC++コードは、プレースホルダー内のテキストを変更する方法を示しています：

```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// 希望するプレゼンテーションをロードします
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// スライド内の最初と二番目のプレースホルダーにアクセスし、AutoShapeとしてキャストします
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// プレゼンテーションをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **プレースホルダーのプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***タイトルを追加するにはクリック***や***サブタイトルを追加するにはクリック***などのプレースホルダーのプロンプトテキストが含まれています。Aspose.Slidesを使用して、好みのプロンプトテキストをプレースホルダーのレイアウトに挿入できます。

以下のC++コードは、プレースホルダーにプロンプトテキストを設定する方法を示しています：

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // テキストがない場合、PowerPointは「タイトルを追加するにはクリック」と表示します。 
        {
            text = u"タイトルを追加するにはクリック";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // サブタイトルに対して同様のことを行います。
        {
            text = u"サブタイトルを追加するにはクリック";
        }
        System::Console::WriteLine(u"プレースホルダー : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **プレースホルダーの画像の透明度を設定する**

Aspose.Slidesを使用すると、テキストプレースホルダー内の背景画像の透明度を設定できます。フレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色に応じて）。

以下のC++コードは、図形内の背景画像の透明度を設定する方法を示しています：

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```