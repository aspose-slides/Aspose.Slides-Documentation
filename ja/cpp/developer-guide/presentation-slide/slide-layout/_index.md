---
title: スライドレイアウト
type: docs
weight: 60
url: /cpp/slide-layout/
keyword: "スライドサイズの設定、スライドオプションの設定、スライドサイズの指定、フッターの表示、子フッター、コンテンツのスケーリング、ページサイズ、C++、CPP、Aspose.Slides"
description: "C++でPowerPointスライドのサイズとオプションを設定する"
---

スライドレイアウトには、スライド上に表示されるすべてのコンテンツのためのプレースホルダーのボックスと書式設定情報が含まれています。レイアウトは、利用可能なコンテンツプレースホルダーとそれらの配置場所を決定します。

スライドレイアウトを使用すると、プレゼンテーションを迅速に作成およびデザインできます（単純なものでも複雑なものでも）。これらは、PowerPointプレゼンテーションで使用される最も一般的なスライドレイアウトのいくつかです：

* **タイトルスライドレイアウト**。このレイアウトは、2つのテキストプレースホルダーで構成されています。1つのプレースホルダーはタイトル用、もう1つはサブタイトル用です。
* **タイトルとコンテンツレイアウト**。このレイアウトは、上部にタイトル用の比較的小さなプレースホルダーと、コアコンテンツ（チャート、段落、箇条書きリスト、番号付きリスト、画像など）用のより大きなプレースホルダーが含まれています。
* **空白のレイアウト**。このレイアウトはプレースホルダーがなく、ゼロから要素を作成することができます。

スライドマスターは、スライドレイアウトに関する情報を格納する最上位の階層スライドであるため、マスタースライドを使用してスライドレイアウトにアクセスし、変更を加えることができます。レイアウトスライドは、そのタイプまたは名前によってアクセスできます。同様に、すべてのスライドには一意のIDがあり、それを使用してアクセスできます。

あるいは、プレゼンテーション内の特定のスライドレイアウトに直接変更を加えることもできます。

* スライドレイアウト（マスタースライド内のものを含む）を操作できるように、Aspose.Slidesは、[get_LayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_layoutslides/)や[get_Masters()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/)などのプロパティを[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスの下で提供します。
* 関連するタスクを実行するために、Aspose.Slidesは[MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/cpp/aspose.slides/baseslideheaderfootermanager/)など、他の多くのタイプを提供します。

{{% alert title="情報" color="info" %}}

特にマスタースライドでの操作に関する詳細は、[Slide Master](https://docs.aspose.com/slides/cpp/slide-master/)の記事を参照してください。

{{% /alert %}}

## **プレゼンテーションにスライドレイアウトを追加**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [MasterSlideコレクション](https://reference.aspose.com/slides/cpp/aspose.slides/imasterlayoutslidecollection/)にアクセスします。
1. 既存のレイアウトスライドを確認し、必要なレイアウトスライドがレイアウトスライドコレクション内に存在することを確認します。存在しない場合は、追加したいレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

このC++コードは、PowerPointプレゼンテーションにスライドレイアウトを追加する方法を示しています：

```c++
// ドキュメントディレクトリへのパス
const String templatePath = u"../templates/AddSlides.pptx";
const String outPath = u"../out/AddLayoutSlides.pptx";

// プレゼンテーションファイルを表すPresentationクラスのインスタンスを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// レイアウトスライドタイプを通過する
SharedPtr<IMasterLayoutSlideCollection> layoutSlides = pres->get_Masters()->idx_get(0)->get_LayoutSlides();

SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != NULL)
{
	layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != NULL)
{
	layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == NULL)
{
	// プレゼンテーションに特定のレイアウトタイプが含まれていない状況
	// プレゼンテーションファイルには空白とカスタムレイアウトタイプのみが含まれています。
	// しかし、カスタムタイプのレイアウトスライドには異なるスライド名があります、
	// 例えば「タイトル」「タイトルとコンテンツ」など。これらの
	// 名前を使用してレイアウトスライドを選択することができます。
	// プレースホルダーのシェイプタイプのセットを使用することもできます。例えば、
	// タイトルスライドには、タイトルプレースホルダータイプのみが必要です。

	for (int i = 0; i < layoutSlides->get_Count(); i++)
	{
		SharedPtr<ILayoutSlide> titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

		if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
		{
			layoutSlide = titleAndObjectLayoutSlide;
			break;
		}
	}

	if (layoutSlide == NULL)
	{
		for (int i = 0; i < layoutSlides->get_Count(); i++)
		{
			SharedPtr<ILayoutSlide> titleLayoutSlide = layoutSlides->idx_get(i);

			if (titleLayoutSlide->get_Name().Equals(u"Title"))
			{
				layoutSlide = titleLayoutSlide;
				break;
			}
		}

		if (layoutSlide == NULL)
		{
			layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
			if (layoutSlide == NULL)
			{
				layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
			}
		}
	}
}

// 追加されたレイアウトスライドを持つ空白のスライドを追加  
pres->get_Slides()->InsertEmptySlide(0, layoutSlide);

// プレゼンテーションをディスクに保存
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **未使用レイアウトスライドを削除**

Aspose.Slidesは、[RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)メソッドを[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスから提供し、不要で未使用のレイアウトスライドを削除できるようにします。このC++コードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **スライドレイアウトのサイズとタイプを設定**

特定のレイアウトスライドのサイズとタイプを設定できるように、Aspose.Slidesは[get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/)および[get_Size()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_size/)プロパティ（[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスから）を提供します。このC++は操作を示します：

```c++
// ドキュメントディレクトリへのパス
const String templatePath = u"../templates/AddSlides.pptx";
const String outPath = u"../out/CloneToAnotherPresentationWithSetSizeAndType.pptx";
// プレゼンテーションファイルを表すPresentationオブジェクトを作成
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

SharedPtr<Presentation> destPres = MakeObject<Presentation>();

// コレクションからIDでスライドにアクセス
SharedPtr<ISlideCollection> slideCollection = destPres->get_Slides();

// 生成したプレゼンテーションのスライドサイズをソースのものに設定
destPres->get_SlideSize()->SetSize(pres->get_SlideSize()->get_Type(), Aspose::Slides::SlideSizeScaleType::DoNotScale);

slideCollection->InsertClone(1, pres->get_Slides()->idx_get(0));

// プレゼンテーションをディスクに保存
destPres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **スライド内のフッターの表示を設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを介してスライドの参照を取得します。
1. スライドフッタープレースホルダーを表示に設定します。
1. 日付時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

このC++コードは、スライドフッターの表示状態を設定する方法（および関連するタスクを実行する）を示しています：

```c++
// ドキュメントディレクトリへのパス
const String outPath = u"../out/HeaderFooterManager_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// SlideCollectionクラスのインスタンスを作成
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

//	SharedPtr<IBaseSlideHeaderFooterManager> headerFooterManager = presentation->get_Slides()->idx_get(0)->get_HeaderFooterManager();
SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
if (!headerFooterManager->get_IsFooterVisible()) // プロパティIsFooterVisibleは、スライドフッタープレースホルダーが欠けていることを指定します
{
	headerFooterManager->SetFooterVisibility(true); // メソッドSetFooterVisibilityは、スライドフッタープレースホルダーを表示に設定します
}
if (!headerFooterManager->get_IsSlideNumberVisible()) // プロパティIsSlideNumberVisibleは、スライドページ番号プレースホルダーが欠けていることを指定します
{
	headerFooterManager->SetSlideNumberVisibility(true); // メソッドSetSlideNumberVisibilityは、スライドページ番号プレースホルダーを表示に設定します
}
if (!headerFooterManager->get_IsDateTimeVisible()) // プロパティIsDateTimeVisibleは、スライド日付時刻プレースホルダーが欠けていることを指定します
{
	headerFooterManager->SetDateTimeVisibility(true); // メソッドSetDateTimeVisibilityは、スライド日付時刻プレースホルダーを表示に設定します
}
headerFooterManager->SetFooterText(u"フッターのテキスト"); // メソッドSetFooterTextは、スライドフッタープレースホルダーのテキストを設定します
headerFooterManager->SetDateTimeText(u"日付と時刻のテキスト"); // メソッドSetDateTimeTextは、スライド日付時刻プレースホルダーのテキストを設定します。

// プレゼンテーションをディスクに保存
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **スライド内の子フッターの表示を設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを介してマスタースライドの参照を取得します。
1. マスタースライドおよびすべての子フッタープレースホルダーを表示に設定します。
1. マスタースライドおよびすべての子フッタープレースホルダーのテキストを設定します。
1. マスタースライドおよびすべての子日付時刻プレースホルダーのテキストを設定します。
1. プレゼンテーションを保存します。

このC++コードは、操作を示しています：

```c++
// ドキュメントディレクトリへのパス
const String outPath = u"../out/SetChildFooter_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>();

// SlideCollectionクラスのインスタンスを作成
SharedPtr<ISlideCollection> slds = presentation->get_Slides();

SharedPtr<IMasterSlideHeaderFooterManager> headerFooterManager = presentation->get_Masters()->idx_get(0)->get_HeaderFooterManager();
headerFooterManager->SetFooterAndChildFootersVisibility(true); // メソッドSetFooterAndChildFootersVisibilityは、マスタースライドおよびすべての子フッタープレースホルダーを表示に設定します
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true); // メソッドSetSlideNumberAndChildSlideNumbersVisibilityは、マスタースライドおよびすべての子ページ番号プレースホルダーを表示に設定します
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true); // メソッドSetDateTimeAndChildDateTimesVisibilityは、マスタースライドおよびすべての子日付時刻プレースホルダーを表示に設定します

headerFooterManager->SetFooterAndChildFootersText(u"フッターのテキスト"); // メソッドSetFooterAndChildFootersTextは、マスタースライドおよびすべての子フッタープレースホルダーのテキストを設定します
headerFooterManager->SetDateTimeAndChildDateTimesText(u"日付と時刻のテキスト"); // メソッドSetDateTimeAndChildDateTimesTextは、マスタースライドおよびすべての子日付時刻プレースホルダーのテキストを設定します

presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **コンテンツスケーリングに応じてスライドサイズを設定**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成し、サイズを設定したいスライドが含まれたプレゼンテーションを読み込む。
1. 生成する新しいプレゼンテーションのために、別の[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを介してスライドの参照を取得します（最初のプレゼンテーションから）。
1. スライドフッタープレースホルダーを表示に設定します。
1. 日付時刻プレースホルダーを表示に設定します。
1. プレゼンテーションを保存します。

このC++コードは、操作を示しています：

```c++
// ドキュメントディレクトリへのパス
const String templatePath = u"../templates/AccessSlides.pptx";
const String outPath = u"../out/SetSlideSizeScale_out.pptx";

SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);
SharedPtr<Presentation> auxPresentation = MakeObject<Presentation>();

// SlideCollectionクラスのインスタンスを作成
SharedPtr<ISlide> slide = presentation->get_Slides()->idx_get(0);

// 生成されたプレゼンテーションのスライドサイズをソースのものに設定
auxPresentation->get_SlideSize()->SetSize(540, 720, SlideSizeScaleType::EnsureFit); // メソッドSetSizeは、スライドサイズを設定し、コンテンツをフィットさせるためにスケーリングを保証します
auxPresentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // メソッドSetSizeは、スライドサイズを設定し、コンテンツの最大サイズを設定します

auxPresentation->get_Slides()->InsertClone(0, slide);
auxPresentation->get_Slides()->RemoveAt(0);

// プレゼンテーション保存
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **PDF生成時のページサイズを設定**

特定のプレゼンテーション（ポスターなど）は、しばしばPDFドキュメントに変換されます。PowerPointをPDFに変換して最適な印刷およびアクセシビリティオプションにアクセスすることを考えている場合は、スライドをPDFドキュメントに適したサイズ（例：A4）に設定したいでしょう。

Aspose.Slidesは、スライドの設定を指定するために[SlideSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/)クラスを提供します。このC++コードは、[get_Type()](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/get_type/)プロパティ（`SlideSize`クラスから）を使用して、プレゼンテーション内のスライドに特定の用紙サイズを設定する方法を示しています：

```c++
// ドキュメントディレクトリへのパス
	const String outPath = u"../out/SetPDFPageSize_out.pptx";

	// プレゼンテーションファイルを表すPresentationオブジェクトを作成 
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// SlideSize.Typeプロパティを設定
	pres->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);

	// PDFオプションの異なるプロパティを設定
	Aspose::Slides::Export::PdfOptions opts = Aspose::Slides::Export::PdfOptions();
	opts.set_SufficientResolution(600);

	// プレゼンテーションを保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pdf, &opts);
```