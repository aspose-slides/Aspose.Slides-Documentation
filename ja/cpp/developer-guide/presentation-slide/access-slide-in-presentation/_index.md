---
title: プレゼンテーションのスライドにアクセス
type: docs
weight: 20
url: /cpp/access-slide-in-presentation/
keywords: "PowerPointプレゼンテーションにアクセス, スライドにアクセス, スライドのプロパティを編集, スライドの位置を変更, スライド番号を設定, インデックス, ID, 位置 C++, CPP, Aspose.Slides"
description: "C++でインデックス、ID、または位置によってPowerPointスライドにアクセスします。スライドのプロパティを編集"
---

Aspose.Slidesを使用すると、スライドに2つの方法でアクセスできます: インデックスおよびIDによるアクセスです。

## **インデックスによるスライドへのアクセス**

プレゼンテーション内のすべてのスライドは、スライドの位置に基づいて0から始まる数字で配置されています。最初のスライドはインデックス0でアクセス可能であり、2番目のスライドはインデックス1でアクセス可能です。

Presentationクラスは、プレゼンテーションファイルを表し、すべてのスライドを[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)コレクション（[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)オブジェクトのコレクション）として公開します。このC++コードは、インデックスを介してスライドにアクセスする方法を示しています:

```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentationクラスのインスタンスを生成
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// インデックスを介してスライドの参照を取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **IDによるスライドへのアクセス**

プレゼンテーション内の各スライドには、関連付けられたユニークなIDがあります。[GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/)メソッド（[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスによって公開）を使用して、そのIDをターゲットにできます。このC++コードは、スライドIDを提供して[GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/)メソッドを介してスライドにアクセスする方法を示しています:

```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentationクラスのインスタンスを生成
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライドIDを取得
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// IDを介してスライドにアクセス
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **スライドの位置を変更**

Aspose.Slidesを使用すると、スライドの位置を変更できます。たとえば、最初のスライドを2番目のスライドにするように指定できます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを生成します。
2. 位置を変更したいスライドの参照をインデックスを介して取得します。
3. [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/)プロパティを介してスライドの新しい位置を設定します。
4. 修正したプレゼンテーションを保存します。

このC++コードは、位置1のスライドを位置2に移動する操作を示しています:

```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Presentationクラスのインスタンスを生成
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 位置が変更されるスライドを取得
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライドの新しい位置を設定
	slide->set_SlideNumber(2);

	// 修正したプレゼンテーションを保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

最初のスライドは2番目のスライドになり、2番目のスライドは最初のスライドになりました。スライドの位置を変更すると、他のスライドも自動的に調整されます。

## **スライド番号を設定**

[set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/)プロパティを使用すると（[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスによって公開）、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを生成します。
2. スライド番号を取得します。
3. スライド番号を設定します。
4. 修正したプレゼンテーションを保存します。

このC++コードは、最初のスライド番号を10に設定する操作を示しています:

```c++
	// ドキュメントディレクトリへのパス
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	// Presentationクラスのインスタンスを生成
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライド番号を取得
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// スライド番号を設定
	pres->set_FirstSlideNumber(2);
	
	// 修正したプレゼンテーションを保存
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

最初のスライドをスキップしたい場合は、以下のようにして2番目のスライドから番号を開始できます（最初のスライドの番号表示を非表示にします）:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// プレゼンテーションスライドの最初の番号を設定
presentation->set_FirstSlideNumber(0);

// すべてのスライドのスライド番号を表示
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// 最初のスライドのスライド番号を非表示にします
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// 修正したプレゼンテーションを保存
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```