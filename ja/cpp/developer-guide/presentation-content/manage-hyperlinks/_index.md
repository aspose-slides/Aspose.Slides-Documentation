---
title: C++ でプレゼンテーション ハイパーリンクを管理する
linktitle: ハイパーリンクの管理
type: docs
weight: 20
url: /ja/cpp/manage-hyperlinks/
keywords:
- URL を追加
- ハイパーリンクを追加
- ハイパーリンクを作成
- ハイパーリンクの書式設定
- ハイパーリンクを削除
- ハイパーリンクを更新
- テキスト ハイパーリンク
- スライド ハイパーリンク
- シェイプ ハイパーリンク
- 画像 ハイパーリンク
- ビデオ ハイパーリンク
- 可変ハイパーリンク
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションのハイパーリンクを手軽に管理し、数分でインタラクティブ性とワークフローを向上させます。"
---

ハイパーリンクは、オブジェクトやデータ、または何かの場所への参照です。これらは PowerPoint プレゼンテーションで一般的に使用されるハイパーリンクです:

* テキスト、図形、またはメディア内のウェブサイトへのリンク
* スライドへのリンク

Aspose.Slides for C++ は、プレゼンテーション内のハイパーリンクに関するさまざまなタスクを実行できます。 

{{% alert color="primary" %}} 

Aspose のシンプルで無料のオンライン PowerPoint エディターをご覧ください、[無料オンライン PowerPoint エディター](https://products.aspose.app/slides/editor)

{{% /alert %}} 

## **URLハイパーリンクの追加**

### **テキストへのURLハイパーリンクの追加**

この C++ コードは、テキストにウェブサイトのハイパーリンクを追加する方法を示します。
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);
shape->AddTextFrame(u"Aspose: File Format APIs");

auto portionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
portionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```


### **図形またはフレームへのURLハイパーリンクの追加**

この C++ のサンプルコードは、図形にウェブサイトのハイパーリンクを追加する方法を示します。
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


### **メディアへのURLハイパーリンクの追加**

Aspose.Slides では、画像、音声、ビデオ ファイルにハイパーリンクを追加できます。 

このサンプルコードは、**画像** にハイパーリンクを追加する方法を示します。
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
// プレゼンテーションに画像を追加
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
// Creates picture frame on slide 1 based on previously added image
auto pictureFrame = shapes->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pictureFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
pictureFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


このサンプルコードは、**音声ファイル** にハイパーリンクを追加する方法を示します。
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto audio = pres->get_Audios()->AddAudio(File::ReadAllBytes(u"audio.mp3"));
auto audioFrame = shapes->AddAudioFrameEmbedded(10.0f, 10.0f, 100.0f, 100.0f, audio);

audioFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
audioFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


このサンプルコードは、**ビデオ** にハイパーリンクを追加する方法を示します。
``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto video = pres->get_Videos()->AddVideo(File::ReadAllBytes(u"video.avi"));
auto videoFrame = shapes->AddVideoFrame(10.0f, 10.0f, 100.0f, 100.0f, video);

videoFrame->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
videoFrame->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


{{%  alert  title="Tip"  color="primary"  %}} 

* [OLE の管理](https://docs.aspose.com/slides/cpp/manage-ole/)

{{% /alert %}}



## **ハイパーリンクを使用して目次を作成する**

ハイパーリンクはオブジェクトや場所への参照を追加できるため、目次の作成に利用できます。 

このサンプルコードは、ハイパーリンクを使用した目次の作成方法を示します。
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto firstSlide = presentation->get_Slides()->idx_get(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto contentTable = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 300.0f, 100.0f);
contentTable->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
contentTable->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
auto paragraphFillFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
paragraphFillFormat->set_FillType(FillType::Solid);
paragraphFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
contentTable->get_TextFrame()->get_Paragraphs()->Add(paragraph);
```



## **ハイパーリンクの書式設定**

### **色**

[IHyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink) インターフェイスの [set_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ab739ae21025485366d44a3b72e0d7dac) および [get_ColorSource()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af5370af1ba9fba7b22fcc8a7ce344494) メソッドを使用すると、ハイパーリンクの色を設定したり、ハイパーリンクから色情報を取得したりできます。この機能は PowerPoint 2019 で初めて導入されたため、プロパティに関する変更は古い PowerPoint バージョンには適用されません。

このサンプルコードは、同じスライドに異なる色のハイパーリンクが追加された操作を示します。
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 450.0f, 50.0f, false);
shape1->AddTextFrame(u"This is a sample of colored hyperlink.");
auto shape1PortionFormat = shape1->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape1PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape1PortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
shape1PortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
shape1PortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 450.0f, 50.0f, false);
shape2->AddTextFrame(u"This is a sample of usual hyperlink.");
auto shape2PortionFormat = shape2->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shape2PortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```



## **プレゼンテーションからハイパーリンクを削除する**

### **テキストからハイパーリンクを削除する**

この C++ コードは、プレゼンテーション スライドのテキストからハイパーリンクを削除する方法を示します。
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);
    if (autoShape != nullptr)
    {
        for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
        {
            for (const auto& portion : paragraph->get_Portions())
            {
                auto hyperlinkManager = portion->get_PortionFormat()->get_HyperlinkManager();
                hyperlinkManager->RemoveHyperlinkClick();
            }
        }
    }
}

pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```


### **図形またはフレームからハイパーリンクを削除する**

この C++ コードは、プレゼンテーション スライドの図形からハイパーリンクを削除する方法を示します。 
``` cpp
auto pres = System::MakeObject<Presentation>(u"demo.pptx");
auto slide = pres->get_Slides()->idx_get(0);
for (const auto& shape : slide->get_Shapes())
{
    shape->get_HyperlinkManager()->RemoveHyperlinkClick();
}
pres->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
```




## **可変ハイパーリンク**

[Hyperlink](https://reference.aspose.com/slides/cpp/class/aspose.slides.hyperlink) クラスは可変です。このクラスを使用すると、以下のメソッドの値を変更できます。

- [IHyperlink::set_TargetFrame()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#af2d9c5672517d98afe5868903a5a637f)
- [IHyperlink::set_Tooltip()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#adf1c8eee89bd292292293e58da79a6f2)
- [IHyperlink.set_History()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#a1a4a96d280f54b641e3ada3557b6688d)
- [IHyperlink.set_HighlightClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ac48a0fa4106cff14cb5772269399587e)
- [IHyperlink.set_StopSoundOnClick()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink#ad0db04da8009b329d2c79019642aaa43)

このコード スニペットは、スライドにハイパーリンクを追加し、後でツールチップを編集する方法を示します。
``` cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();
auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 600.0f, 50.0f, false);

shape->AddTextFrame(u"Aspose: File Format APIs");

auto shapePortionFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat();
shapePortionFormat->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shapePortionFormat->get_HyperlinkClick()->set_Tooltip(u"More than 70% Fortune 100 companies trust Aspose APIs");
shapePortionFormat->set_FontHeight(32.0f);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```





## **IHyperlinkQueries でサポートされているメソッド**

ハイパーリンクが定義されているプレゼンテーション、スライド、またはテキストから IHyperlinkQueries にアクセスできます。 

- [IPresentation::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a7e84086f34ddc742ea9124ab11727691)
- [IBaseSlide::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#a8593a5a5f6b7e051aa859ec373c66421)
- [ITextFrame::get_HyperlinkQueries()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_text_frame#a1303ef71d3c50d471e35434dcaaa2e4e)

IHyperlinkQueries クラスは以下のメソッドをサポートしています。 

- [IHyperlinkQueries::GetHyperlinkClicks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#aaea0b1b68ff2e65240612fb1f08361c1)
- [IHyperlinkQueries::GetHyperlinkMouseOvers()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#ac68ac55d183323f11e604b40760b0e4b)
- [IHyperlinkQueries::GetAnyHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#acaf9ded3920056054e0e70c24129d73a)
- [IHyperlinkQueries::RemoveAllHyperlinks()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_hyperlink_queries#a289f52c992f939fe46282536cec7222d)

## **よくある質問**

**スライドだけでなく「セクション」やセクションの最初のスライドへの内部ナビゲーションを作成するにはどうすればよいですか？**

PowerPoint のセクションはスライドのグループ化です。ナビゲーションは技術的に特定のスライドを対象とします。「セクションへ移動」するには、通常その最初のスライドへのリンクを作成します。

**マスタースライドの要素にハイパーリンクを付けて、すべてのスライドで機能させることはできますか？**

はい。マスタースライドやレイアウト要素はハイパーリンクをサポートしています。そのリンクは子スライドに表示され、スライドショー中にクリック可能です。

**PDF、HTML、画像、またはビデオにエクスポートする際にハイパーリンクは維持されますか？**

PDF（[PDF](/slides/ja/cpp/convert-powerpoint-to-pdf/)）や HTML（[HTML](/slides/ja/cpp/convert-powerpoint-to-html/)）では、リンクは通常保持されます。画像（[images](/slides/ja/cpp/convert-powerpoint-to-png/)）やビデオ（[video](/slides/ja/cpp/convert-powerpoint-to-video/)）へのエクスポートでは、ラスターフレームやビデオはハイパーリンクをサポートしないため、クリック可能性は引き継がれません。