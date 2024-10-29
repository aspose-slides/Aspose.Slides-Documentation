---
title: プレゼンテーションからテキストを抽出する
type: docs
weight: 90
url: /ja/cpp/extract-text-from-presentation/
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。それを行うには、プレゼンテーション内のすべてのスライドのすべての図形からテキストを抽出する必要があります。本記事では、Aspose.Slidesを使用してMicrosoft PowerPoint PPTXプレゼンテーションからテキストを抽出する方法を説明します。テキストは以下の方法で抽出できます：

- [1つのスライドからテキストを抽出する](/slides/ja/cpp/extracting-text-from-the-presentation/)
- [GetAllTextBoxesメソッドを使用してテキストを抽出する](/slides/ja/cpp/extracting-text-from-the-presentation/)
- [カテゴリー化された迅速なテキスト抽出](/slides/ja/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for C++は、SlideUtilクラスを含むAspose.Slides.Util名前空間を提供します。このクラスは、プレゼンテーションまたはスライドから全テキストを抽出するための複数のオーバーロードされた静的メソッドを公開しています。PPTXプレゼンテーション内のスライドからテキストを抽出するには、SlideUtilクラスによって公開されている[GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df)オーバーロード静的メソッドを使用します。このメソッドは、Slideオブジェクトをパラメータとして受け取ります。
実行すると、Slideメソッドは、パラメータとして渡されたスライド内のすべてのテキストをスキャンし、TextFrameオブジェクトの配列を返します。これは、テキストに関連するフォーマットは利用可能であることを意味します。次のコード片は、プレゼンテーションの最初のスライド上のすべてのテキストを抽出します：

``` cpp
// ドキュメントディレクトリへのパス
System::String dataDir = GetDataPath();

// PPTXファイルを表すPresentationクラスをインスタンス化
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// TextFramesの配列をループ
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// 現在のITextFrame内の段落をループ
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// 現在のIParagraph内のポーションをループ
		for (const auto& port : para->get_Portions())
		{
			// 現在のポーション内のテキストを表示
			Console::WriteLine(port->get_Text());

			// テキストのフォントの高さを表示
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// テキストのフォント名を表示
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **プレゼンテーションからテキストを抽出する**
全体のプレゼンテーションからテキストをスキャンするには、SlideUtilクラスによって公開されている[GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12)静的メソッドを使用します。これには2つのパラメータが必要です：

1. 最初は、テキストを抽出するPPTXプレゼンテーションを表すPresentationオブジェクト。
2. 2番目は、プレゼンテーションからテキストをスキャンするときにマスター スライドを含めるかどうかを決定するブール値。
   このメソッドは、テキストフォーマット情報を含むTextFrameオブジェクトの配列を返します。以下のコードは、マスター スライドを含むプレゼンテーションからテキストとフォーマット情報をスキャンします。

``` cpp
// ドキュメントディレクトリへのパス
System::String dataDir = GetDataPath();

// PPTXファイルを表すPresentationクラスをインスタンス化
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// PPTX内のすべてのスライドからITextFrameオブジェクトの配列を取得
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// TextFramesの配列をループ
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// 現在のITextFrame内の段落をループ
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// 現在のIParagraph内のポーションをループ
		for (const auto& port : para->get_Portions())
		{
			// 現在のポーション内のテキストを表示
			Console::WriteLine(port->get_Text());

			// テキストのフォントの高さを表示
			Console::WriteLine(port->get_PortionFormat()->get_FontHeight());

			// テキストのフォント名を表示
			if (port->get_PortionFormat()->get_LatinFont() != nullptr)
			{
				Console::WriteLine(port->get_PortionFormat()->get_LatinFont()->get_FontName());
			}
		}
	}
}
```

## **カテゴリー化された迅速なテキスト抽出**
Presentationクラスに新しい静的メソッドGetPresentationTextが追加されました。このメソッドには2つのオーバーロードがあります：

``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```

TextExtractionArrangingMode列挙体の引数は、テキスト結果の出力を整理するモードを示し、以下の値に設定できます：  
Unarranged - スライド上の位置を考慮しない生のテキスト  
Arranged - スライドと同じ順序で配置されたテキスト

Unarrangedモードは、速度が重要な場合に使用でき、Arrangedモードよりも速くなります。

PresentationTextは、プレゼンテーションから抽出された生のテキストを表します。これは、Aspose.Slides.Util名前空間のget_SlidesText()メソッドを含み、ISlideTextオブジェクトの配列を返します。各オブジェクトは、対応するスライド内のテキストを表します。ISlideTextオブジェクトには以下のメソッドがあります：

get_Text() - スライドの図形内のテキスト。  
get_MasterText() - このスライドのマスターページの図形内のテキスト。  
get_LayoutText() - このスライドのレイアウトページの図形内のテキスト。  
get_NotesText() - このスライドのノートページの図形内のテキスト。

ISlideTextインターフェースを実装するSlideTextクラスもあります。

新しいAPIはこのように使用できます：

``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```