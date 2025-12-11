---
title: C++ でプレゼンテーション スライドにアクセス
linktitle: スライドにアクセス
type: docs
weight: 20
url: /ja/cpp/access-slide-in-presentation/
keywords:
- スライドにアクセス
- スライド インデックス
- スライド ID
- スライド 位置
- 位置を変更
- スライド プロパティ
- スライド番号
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint と OpenDocument のプレゼンテーションでスライドにアクセスおよび管理する方法を学びます。コード例で生産性を向上させましょう。"
---

Aspose.Slides では、スライドにインデックスまたは ID の 2 つの方法でアクセスできます。

## **インデックスでスライドにアクセス**

プレゼンテーション内のすべてのスライドは、スライドの位置に基づいて 0 から始まる数値で配置されます。最初のスライドはインデックス 0 でアクセスでき、2 番目のスライドはインデックス 1 でアクセスできます。etc.

プレゼンテーション ファイルを表す Presentation クラスは、すべてのスライドを [ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/) コレクション（[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) オブジェクトのコレクション）として公開します。この C++ コードは、インデックスを使用してスライドにアクセスする方法を示しています: 
```c++
	// ドキュメントディレクトリへのパスです。
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation クラスのインスタンスを作成します。
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// インデックスでスライドの参照を取得します。
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```


## **IDでスライドにアクセス**

プレゼンテーション内の各スライドには、固有の ID が割り当てられています。その ID を対象にするには、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスで公開されている [GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) メソッドを使用できます。この C++ コードは、有効なスライド ID を指定し、[GetSlideById()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/getslidebyid/) メソッドでそのスライドにアクセスする方法を示しています:
```c++
	// ドキュメントディレクトリへのパスです。
	const String templatePath = u"../templates/AddSlides.pptx";

	// Presentation クラスのインスタンスを作成します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライド ID を取得します
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// ID を使用してスライドにアクセスします
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```


## **スライドの位置を変更**

Aspose.Slides では、スライドの位置を変更できます。たとえば、最初のスライドを 2 番目のスライドにすることができます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. インデックスを使用して、位置を変更したいスライドの参照を取得します。
1. [set_SlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/set_slidenumber/) プロパティを使用して、スライドの新しい位置を設定します。 
1. 変更されたプレゼンテーションを保存します。

この C++ コードは、位置 1 のスライドを位置 2 に移動する操作を示しています:
```c++
	// ドキュメントディレクトリへのパスです。
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Presentation クラスのインスタンスを作成します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// 位置を変更するスライドを取得します
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// スライドの新しい位置を設定します
	slide->set_SlideNumber(2);

	// 変更されたプレゼンテーションを保存します
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


最初のスライドが 2 番目になり、2 番目のスライドが最初になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号を設定**

[set_FirstSlideNumber()](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) プロパティ（[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスで公開）を使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により、他のスライド番号が再計算されます。

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) クラスのインスタンスを作成します。
1. スライド番号を取得します。
1. スライド番号を設定します。
1. 変更されたプレゼンテーションを保存します。

この C++ コードは、最初のスライド番号を 10 に設定する操作を示しています: 
```c++
	// ドキュメントディレクトリへのパスです。
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Presentation クラスのインスタンスを作成します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライド番号を取得します
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// スライド番号を設定します
	pres->set_FirstSlideNumber(2);
	
	// 変更されたプレゼンテーションを保存します
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号は非表示に）以下のように設定できます:
```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```


## **FAQ**

**ユーザーが見るスライド番号は、コレクションのゼロベース インデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。この関係は、プレゼンテーションの [first slide number](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/set_firstslidenumber/) 設定で制御されます。

**非表示のスライドはインデックスに影響しますか？**

はい。非表示のスライドはコレクションに残り、インデックスの計算に含まれます。「非表示」は表示上の状態を指し、コレクション内での位置には影響しません。

**他のスライドが追加または削除されたときに、スライドのインデックスは変わりますか？**

はい。インデックスは常にスライドの現在の順序を反映し、挿入、削除、移動操作が行われるたびに再計算されます。