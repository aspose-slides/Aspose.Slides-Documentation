---
title: C++ でプレゼンテーションのヘッダーとフッターを管理する
linktitle: ヘッダーとフッター
type: docs
weight: 140
url: /ja/cpp/presentation-header-and-footer/
keywords:
- ヘッダー
- ヘッダーテキスト
- フッター
- フッターテキスト
- ヘッダー設定
- フッター設定
- ハンドアウト
- ノート
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "プロフェッショナルな外観を実現するために、C++ 用 Aspose.Slides を使用して PowerPoint および OpenDocument のプレゼンテーションにヘッダーとフッターを追加・カスタマイズできます。"
---

{{% alert color="primary" %}} 
[Aspose.Slides](/slides/ja/cpp/) は、スライドのヘッダーとフッターのテキストを操作する機能を提供します。これらは実際にはスライド マスター レベルで管理されています。
{{% /alert %}} 

[Aspose.Slides for C++](/slides/ja/cpp/) は、プレゼンテーション スライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーション マスター レベルで管理されています。
## **ヘッダーとフッターのテキストを管理する**
特定のスライドのノートは、以下の例のように更新できます。
``` cpp
// ヘッダー/フッターのテキストを設定する関数
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// プレゼンテーションの読み込み
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// フッターの設定
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// ヘッダーへのアクセスと更新
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// プレゼンテーションの保存
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```


## **ハンドアウトとノートスライドのヘッダーとフッターを管理する**
Aspose.Slides for C++ は、ハンドアウトとノートスライドでヘッダーとフッターをサポートします。以下の手順に従ってください：
- ビデオを含む[プレゼンテーション](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)を読み込みます。
- ノート マスターとすべてのノート スライドのヘッダーとフッター設定を変更します。
- マスターノートスライドとすべての子フッタープレースホルダーを表示に設定します。
- マスターノートスライドとすべての子日付と時刻プレースホルダーを表示に設定します。
- 最初のノートスライドのみのヘッダーとフッター設定を変更します。
- ノートスライドのヘッダープレースホルダーを表示に設定します。
- ノートスライドのヘッダープレースホルダーにテキストを設定します。
- ノートスライドの日付時刻プレースホルダーにテキストを設定します。
- 変更されたプレゼンテーションファイルを書き込みます。

以下の例にコードスニペットが提供されています。
``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// ノートマスターとすべてのノートスライドのヘッダーとフッター設定を変更する
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// マスターノートスライドとすべての子フッタープレースホルダーを表示にする
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// マスターノートスライドとすべての子ヘッダープレースホルダーを表示にする
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// マスターノートスライドとすべての子スライド番号プレースホルダーを表示にする
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// マスターノートスライドとすべての子日付と時刻プレースホルダーを表示にする
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// マスターノートスライドとすべての子ヘッダープレースホルダーにテキストを設定する
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// マスターノートスライドとすべての子フッタープレースホルダーにテキストを設定する
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// マスターノートスライドとすべての子日付と時刻プレースホルダーにテキストを設定する
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// 最初のノートスライドのみのヘッダーとフッター設定を変更する
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// このノートスライドのヘッダープレースホルダーを表示にする
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// このノートスライドのフッタープレースホルダーを表示にする
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// このノートスライドのスライド番号プレースホルダーを表示にする
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// このノートスライドの日付時刻プレースホルダーを表示にする
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// ノートスライドのヘッダープレースホルダーにテキストを設定する
	headerFooterManager->SetHeaderText(u"New header text");
	// ノートスライドのフッタープレースホルダーにテキストを設定する
	headerFooterManager->SetFooterText(u"New footer text");
	// ノートスライドの日付時刻プレースホルダーにテキストを設定する
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```


## **よくある質問**

**通常のスライドに「ヘッダー」を追加できますか？**

PowerPoint では、"Header" はノートとハンドアウトにのみ存在し、通常のスライドではサポートされる要素はフッター、日付/時刻、スライド番号です。Aspose.Slides でも同じ制限が適用され、ヘッダーはノート/ハンドアウトにのみ、スライドではフッター/日付時刻/スライド番号が使用できます。

**レイアウトにフッター領域が含まれていない場合、表示を「オン」にできますか？**

はい。ヘッダー/フッターマネージャーで可視性を確認し、必要に応じて有効にしてください。これらの API 指標とメソッドは、プレースホルダーが存在しない、または非表示の場合に対応するよう設計されています。

**スライド番号を 1 以外の値から開始させるにはどうすればよいですか？**

プレゼンテーションの[最初のスライド番号](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/)を設定します。その後、すべての番号付けが再計算されます。例えば、0 や 10 から開始でき、タイトルスライドの番号を非表示にすることも可能です。

**PDF/画像/HTML にエクスポートするとき、ヘッダー/フッターはどうなりますか？**

ヘッダーとフッターは、プレゼンテーションの通常のテキスト要素としてレンダリングされます。つまり、スライドやノートページで要素が表示されていれば、出力形式でも他のコンテンツと同様に表示されます。