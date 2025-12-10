---
title: C++でプレゼンテーションのプレースホルダーを管理する
linktitle: プレースホルダー管理
type: docs
weight: 10
url: /ja/cpp/manage-placeholder/
keywords:
- プレースホルダー
- テキスト プレースホルダー
- 画像 プレースホルダー
- チャート プレースホルダー
- プロンプト テキスト
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++でプレースホルダーを簡単に管理：テキスト置換、プロンプトカスタマイズ、画像の透明度設定をPowerPointおよびOpenDocumentで実行。"
---

## **プレースホルダーのテキストを変更する**
[Aspose.Slides for C++](/slides/ja/cpp/) を使用すると、プレゼンテーションのスライド上のプレースホルダーを検索および変更できます。Aspose.Slides を使用すると、プレースホルダー内のテキストを変更できます。

**Prerequisite**: プレースホルダーを含むプレゼンテーションが必要です。そのようなプレゼンテーションは標準の Microsoft PowerPoint アプリで作成できます。

以下は、Aspose.Slides を使用してそのプレゼンテーションのプレースホルダーのテキストを置換する手順です：

1. [`Presentation`](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) クラスのインスタンスを作成し、プレゼンテーションを引数として渡します。
2. インデックスを使用してスライド参照を取得します。
3. 形状を反復処理してプレースホルダーを見つけます。
4. プレースホルダーの形状を [`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) に型キャストし、[`AutoShape`](https://reference.aspose.com/slides/cpp/class/aspose.slides.auto_shape/) に関連付けられた [`TextFrame`](https://reference.aspose.com/slides/cpp/class/aspose.slides.text_frame/) を使用してテキストを変更します。
5. 変更されたプレゼンテーションを保存します。

この C++ コードは、プレースホルダーのテキストを変更する方法を示しています：
```c++
// ドキュメントディレクトリへのパス。
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// プレゼンテーションを読み込みます
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// 最初のスライドにアクセスします
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// スライド内の最初と二番目のプレースホルダーにアクセスし、AutoShape に型キャストします
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// プレゼンテーションをディスクに保存します
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **プレースホルダーにプロンプトテキストを設定する**
標準および事前構築されたレイアウトには、***Click to add a title*** や ***Click to add a subtitle*** のようなプレースホルダーのプロンプトテキストが含まれています。Aspose.Slides を使用すると、プレースホルダー レイアウトに好きなプロンプトテキストを挿入できます。

この C++ コードは、プレースホルダーにプロンプトテキストを設定する方法を示しています：
```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // テキストがない場合、PowerPoint は "Click to add title" を表示します。
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // サブタイトルでも同様に動作します。
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


## **プレースホルダー画像の透明度を設定する**
Aspose.Slides を使用すると、テキスト プレースホルダー内の背景画像の透明度を設定できます。そのフレーム内の画像の透明度を調整することで、テキストまたは画像を際立たせることができます（テキストと画像の色に応じて）。

この C++ コードは、（シェイプ内の）画像背景の透明度を設定する方法を示しています：
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


## **よくある質問**

**ベース プレースホルダーとは何ですか、スライド上のローカル シェイプとはどのように異なりますか？**

ベース プレースホルダーは、レイアウトまたはマスター上の元のシェイプで、スライドのシェイプがそれから継承します。タイプ、位置、および一部の書式設定がそこから引き継がれます。ローカル シェイプは独立しており、ベース プレースホルダーが存在しない場合は継承が適用されません。

**プレゼンテーション全体のすべてのタイトルやキャプションを、各スライドを反復せずに更新するにはどうすればよいですか？**

レイアウトまたはマスター上の該当するプレースホルダーを編集します。これらのレイアウト/マスターに基づくスライドは、自動的に変更を継承します。

**標準のヘッダー/フッター プレースホルダー（日付と時刻、スライド番号、フッターテキスト）をどのように制御できますか？**

適切なスコープ（通常スライド、レイアウト、マスター、ノート/配布資料）で HeaderFooter マネージャーを使用して、これらのプレースホルダーをオンまたはオフにし、内容を設定します。