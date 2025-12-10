---
title: C++ におけるプレゼンテーションからの高度なテキスト抽出
linktitle: テキスト抽出
type: docs
weight: 90
url: /ja/cpp/extract-text-from-presentation/
keywords:
- テキスト抽出
- スライドからのテキスト抽出
- プレゼンテーションからのテキスト抽出
- PowerPoint からのテキスト抽出
- OpenDocument からのテキスト抽出
- PPT からのテキスト抽出
- PPTX からのテキスト抽出
- ODP からのテキスト抽出
- テキスト取得
- スライドからのテキスト取得
- プレゼンテーションからのテキスト取得
- PowerPoint からのテキスト取得
- OpenDocument からのテキスト取得
- PPT からのテキスト取得
- PPTX からのテキスト取得
- ODP からのテキスト取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument のプレゼンテーションからテキストを迅速に抽出します。シンプルでステップバイステップのガイドに従い、時間を節約しましょう。"
---

{{% alert color="primary" %}} 

開発者がプレゼンテーションからテキストを抽出する必要があることは珍しくありません。そのためには、プレゼンテーション内のすべてのスライドのすべてのシェイプからテキストを抽出する必要があります。この記事では、Aspose.Slides を使用して Microsoft PowerPoint PPTX プレゼンテーションからテキストを抽出する方法を説明します。テキストは以下の方法で抽出できます:

- [1 つのスライドからテキストを抽出する](/slides/ja/cpp/extracting-text-from-the-presentation/)
- [GetAllTextBoxes メソッドを使用してテキストを抽出する](/slides/ja/cpp/extracting-text-from-the-presentation/)
- [分類された高速テキスト抽出](/slides/ja/cpp/extracting-text-from-the-presentation/)

{{% /alert %}} 
## **スライドからテキストを抽出する**
Aspose.Slides for C++ は Aspose.Slides.Util 名前空間を提供し、その中に SlideUtil クラスがあります。このクラスはプレゼンテーションまたはスライドからテキスト全体を抽出するための多数のオーバーロードされた静的メソッドを公開しています。PPTX プレゼンテーションのスライドからテキストを抽出するには、SlideUtil クラスが公開するオーバーロードされた静的メソッド [GetAllTextBoxes](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a97da94e3fc5230cdfc0e30b444c127df) を使用します。このメソッドは Slide オブジェクトをパラメータとして受け取ります。実行すると、Slide メソッドはパラメータとして渡されたスライドのテキスト全体をスキャンし、TextFrame オブジェクトの配列を返します。これにより、テキストに関連付けられた書式情報も取得できます。以下のコードはプレゼンテーションの最初のスライド上のすべてのテキストを抽出します:
``` cpp
// ドキュメントディレクトリへのパス。
System::String dataDir = GetDataPath();

// PPTX ファイルを表す Presentation クラスのインスタンス化
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// TextFrame 配列をループ
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// 現在の ITextFrame の段落をループ
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// 現在の IParagraph の各ポーションをループ
		for (const auto& port : para->get_Portions())
		{
			// 現在のポーションのテキストを表示
			Console::WriteLine(port->get_Text());

			// テキストのフォント高さを表示
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
プレゼンテーション全体のテキストをスキャンするには、SlideUtil クラスが公開する静的メソッド [GetAllTextFrames](https://reference.aspose.com/slides/cpp/class/aspose.slides.util.slide_util#a5a0aebdc520e5258c8a1f665fdb8be12) を使用します。このメソッドは 2 つのパラメータを受け取ります。

1. 最初に、テキストを抽出する対象となる PPTX プレゼンテーションを表す Presentation オブジェクト。
1. 次に、プレゼンテーションからテキストをスキャンする際にマスタースライドを含めるかどうかを決定する Boolean 値。
   このメソッドはテキスト書式情報を含む TextFrame オブジェクトの配列を返します。以下のコードはマスタースライドを含むプレゼンテーションのテキストと書式情報をスキャンします。
``` cpp
// ドキュメントディレクトリへのパス。
System::String dataDir = GetDataPath();

// PPTX ファイルを表す Presentation クラスのインスタンス化
auto pptxPresentation = System::MakeObject<Presentation>(dataDir + u"demo.pptx");

// PPTX のすべてのスライドから ITextFrame オブジェクトの配列を取得
auto textFramesPPTX = Util::SlideUtil::GetAllTextFrames(pptxPresentation, true);

// TextFrame 配列をループ
for (int32_t i = 0; i < textFramesPPTX->get_Length(); i++)
{
	// 現在の ITextFrame の段落をループ
	for (const auto& para : textFramesPPTX[i]->get_Paragraphs())
	{
		// 現在の IParagraph の各ポーションをループ
		for (const auto& port : para->get_Portions())
		{
			// 現在のポーションのテキストを表示
			Console::WriteLine(port->get_Text());

			// テキストのフォント高さを表示
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


## **分類された高速テキスト抽出**
Presentation クラスに新しい静的メソッド GetPresentationText が追加されました。このメソッドには 2 つのオーバーロードがあります:
``` cpp
System::SharedPtr<IPresentationText> GetPresentationText(System::String file, TextExtractionArrangingMode mode) override
 
System::SharedPtr<IPresentationText> GetPresentationText(System::SharedPtr<System::IO::Stream> stream, TextExtractionArrangingMode mode) override
```


The TextExtractionArrangingMode 列挙体の引数はテキスト結果の出力を整理するモードを示し、次の値に設定できます:
Unarranged - スライド上の位置を考慮しない生テキスト
Arranged - スライド上の順序と同じ位置にテキストが配置される

速度が重要な場合は Unarranged モードを使用できます。Arranged モードよりも高速です。

PresentationText はプレゼンテーションから抽出された生テキストを表します。Aspose.Slides.Util 名前空間の get_SlidesText() メソッドを含み、ISlideText オブジェクトの配列を返します。各オブジェクトは対応するスライド上のテキストを表します。ISlideText オブジェクトは次のメソッドを持ちます:

get_Text() - スライドのシェイプ上のテキスト。  
get_MasterText() - このスライドのマスターページのシェイプ上のテキスト。  
get_LayoutText() - このスライドのレイアウトページのシェイプ上のテキスト。  
get_NotesText() - このスライドのノートページのシェイプ上のテキスト。

また、ISlideText インターフェイスを実装する SlideText クラスもあります。

新しい API は以下のように使用できます:
``` cpp
auto text = System::MakeObject<PresentationFactory>()->GetPresentationText(u"presentation.ppt", TextExtractionArrangingMode::Unarranged);
Console::WriteLine(text->get_SlidesText()[0]->get_Text());
Console::WriteLine(text->get_SlidesText()[0]->get_LayoutText());
Console::WriteLine(text->get_SlidesText()[0]->get_MasterText());
Console::WriteLine(text->get_SlidesText()[0]->get_NotesText());
```


## **FAQ**

**テキスト抽出時に Aspose.Slides は大規模なプレゼンテーションをどの程度高速に処理しますか？**

Aspose.Slides は高性能に最適化されており、非常に大きなプレゼンテーションでも効率的に処理でき、リアルタイムまたはバルク処理シナリオに適しています。

**Aspose.Slides はプレゼンテーション内の表やチャートからテキストを抽出できますか？**

はい、Aspose.Slides は表、チャート、その他の複雑なスライド要素からのテキスト抽出を完全にサポートしており、すべてのテキストコンテンツに簡単にアクセスして分析できます。

**プレゼンテーションからテキストを抽出するために特別な Aspose.Slides ライセンスが必要ですか？**

Aspose.Slides の無料トライアル版でもテキストの抽出は可能ですが、スライド数に制限があるなどの制約があります。制限なく利用し、大規模なプレゼンテーションを扱うにはフルライセンスの購入が推奨されます。