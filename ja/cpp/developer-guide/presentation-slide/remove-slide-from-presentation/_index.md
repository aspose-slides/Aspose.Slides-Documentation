---
title: プレゼンテーションからスライドを削除する
type: docs
weight: 30
url: /cpp/remove-slide-from-presentation/
keywords: "スライドを削除, スライドを消去, PowerPoint, プレゼンテーション, C++, Aspose.Slides"
description: "C++で参照またはインデックスによってPowerPointからスライドを削除"

---

スライド（またはその内容）が冗長になった場合は、削除できます。Aspose.Slidesは、プレゼンテーション内のすべてのスライドのリポジトリである[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)をカプセル化する[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスを提供します。既知の[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)オブジェクトに対してポインタ（参照またはインデックス）を使用することで、削除したいスライドを指定できます。

## **参照によるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. IDまたはインデックスを介して削除したいスライドの参照を取得します。
1. プレゼンテーションから参照されたスライドを削除します。
1. 修正されたプレゼンテーションを保存します。

このC++コードは、参照を通じてスライドを削除する方法を示しています：

```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライドコレクション内のインデックスを介してスライドにアクセスします
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 参照を通じてスライドを削除します
	pres->get_Slides()->Remove(slide);

	// 修正されたプレゼンテーションを保存します
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **インデックスによるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックス位置を介してプレゼンテーションからスライドを削除します。
1. 修正されたプレゼンテーションを保存します。

このC++コードは、インデックスを通じてスライドを削除する方法を示しています：

```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライドインデックスを通じてスライドを削除します
	pres->get_Slides()->RemoveAt(0);

	// 修正されたプレゼンテーションを保存します
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **未使用のレイアウトスライドを削除**

Aspose.Slidesは、不要で未使用のレイアウトスライドを削除できる[RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)メソッド（[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスから）を提供します。このC++コードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **未使用のマスタースライドを削除**

Aspose.Slidesは、不要で未使用のマスタースライドを削除できる[RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)メソッド（[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスから）を提供します。このC++コードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```