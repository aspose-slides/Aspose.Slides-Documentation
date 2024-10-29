---
title: プレゼンテーションのヘッダーとフッター
type: docs
weight: 140
url: /ja/cpp/presentation-header-and-footer/
keywords: "PowerPointのヘッダーとフッター"
description: "Aspose.Slidesを使用したPowerPointのヘッダーとフッター。"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ja/cpp/) は、スライドマスターレベルで実際に管理されるスライドのヘッダーとフッターテキストを操作するためのサポートを提供します。

{{% /alert %}} 

[Aspose.Slides for C++](/slides/ja/cpp/) は、プレゼンテーションスライド内のヘッダーとフッターを管理する機能を提供します。これらは実際にはプレゼンテーションマスターレベルで管理されています。
## **ヘッダーとフッターテキストの管理**
特定のスライドのノートは、以下の例に示すように更新できます：

``` cpp
// ヘッダー/フッターテキストを設定する関数
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"こんにちは新しいヘッダー");
            }
        }
    }
}
```

``` cpp
// プレゼンテーションを読み込む
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// フッターを設定する
pres->get_HeaderFooterManager()->SetAllFootersText(u"私のフッターテキスト");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// ヘッダーにアクセスして更新する
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// プレゼンテーションを保存する
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **ハンドアウトとノートスライドのヘッダーとフッターの管理**
Aspose.Slides for C++ は、ハンドアウトとノートスライドのヘッダーとフッターをサポートしています。以下の手順に従ってください：

- ビデオを含む[プレゼンテーション](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)を読み込みます。
- ノートマスターおよびすべてのノートスライドのヘッダーとフッターの設定を変更します。
- マスターノートスライドおよびすべての子フッタープレースホルダーを表示します。
- マスターノートスライドおよびすべての子日付と時刻プレースホルダーを表示します。
- 最初のノートスライドのみのヘッダーとフッターの設定を変更します。
- ノートスライドヘッダープレースホルダーを表示します。
- ノートスライドヘッダープレースホルダーにテキストを設定します。
- ノートスライド日付時刻プレースホルダーにテキストを設定します。
- 修正されたプレゼンテーションファイルを書き込みます。

下記の例に提供されたコードスニペット。

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// ノートマスターとすべてのノートスライドのヘッダーとフッターの設定を変更する
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// マスターノートスライドおよびすべての子フッタープレースホルダーを表示
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// マスターノートスライドおよびすべての子ヘッダープレースホルダーを表示
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// マスターノートスライドおよびすべての子スライド番号プレースホルダーを表示
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// マスターノートスライドおよびすべての子日付および時刻プレースホルダーを表示
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// マスターノートスライドおよびすべての子ヘッダープレースホルダーにテキストを設定
	headerFooterManager->SetHeaderAndChildHeadersText(u"ヘッダーテキスト");
	// マスターノートスライドおよびすべての子フッタープレースホルダーにテキストを設定
	headerFooterManager->SetFooterAndChildFootersText(u"フッターテキスト");
	// マスターノートスライドおよびすべての子日付および時刻プレースホルダーにテキストを設定
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"日付および時刻テキスト");
}

// 最初のノートスライドのみのヘッダーとフッターの設定を変更する
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// このノートスライドヘッダープレースホルダーを表示
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// このノートスライドフッタープレースホルダーを表示
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// このノートスライドスライド番号プレースホルダーを表示
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// このノートスライド日付時刻プレースホルダーを表示
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// ノートスライドヘッダープレースホルダーにテキストを設定
	headerFooterManager->SetHeaderText(u"新しいヘッダーテキスト");
	// ノートスライドフッタープレースホルダーにテキストを設定
	headerFooterManager->SetFooterText(u"新しいフッターテキスト");
	// ノートスライド日付時刻プレースホルダーにテキストを設定
	headerFooterManager->SetDateTimeText(u"新しい日付および時刻テキスト");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```