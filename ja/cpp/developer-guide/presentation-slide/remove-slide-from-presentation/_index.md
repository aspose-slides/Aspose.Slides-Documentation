---
title: C++でプレゼンテーションからスライドを削除
linktitle: スライドの削除
type: docs
weight: 30
url: /ja/cpp/remove-slide-from-presentation/
keywords:
- スライドを削除
- スライドを削除
- 未使用スライドを削除
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument プレゼンテーションからスライドを簡単に削除できます。明確なコード例を取得し、ワークフローを向上させましょう。"
---

スライド（またはその内容）が冗長になった場合、削除できます。Aspose.Slides は、プレゼンテーション内のすべてのスライドのリポジトリである[ISlideCollection](https://reference.aspose.com/slides/cpp/aspose.slides/islidecollection/)をカプセル化する[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスを提供します。既知の[ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/)オブジェクトに対してポインタ（参照またはインデックス）を使用すると、削除したいスライドを指定できます。

## **参照によるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. 削除したいスライドを ID またはインデックスで参照取得します。
1. 参照されたスライドをプレゼンテーションから削除します。
1. 変更されたプレゼンテーションを保存します。

この C++ コードは、参照を使用してスライドを削除する方法を示しています。 
```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライド コレクション内のインデックスを使用してスライドにアクセスします
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// 参照を使用してスライドを削除します
	pres->get_Slides()->Remove(slide);

	// 変更されたプレゼンテーションを保存します
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **インデックスによるスライドの削除**

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックス位置でスライドをプレゼンテーションから削除します。
1. 変更されたプレゼンテーションを保存します。

この C++ コードは、インデックスを使用してスライドを削除する方法を示しています。 
```c++
	// ドキュメントディレクトリへのパス
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// プレゼンテーションファイルを表す Presentation オブジェクトをインスタンス化します
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// スライドインデックスを使用してスライドを削除します
	pres->get_Slides()->RemoveAt(0);

	// 変更されたプレゼンテーションを保存します
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **未使用のレイアウトスライドの削除**

Aspose.Slides は、不要で未使用のレイアウトスライドを削除できるように、[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスの[RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)メソッドを提供します。この C++ コードは、PowerPoint プレゼンテーションからレイアウトスライドを削除する方法を示しています:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **未使用のマスタースライドの削除**

Aspose.Slides は、不要で未使用のマスタースライドを削除できるように、[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスの[RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)メソッドを提供します。この C++ コードは、PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**スライドを削除した後、スライドインデックスはどうなりますか？**  
削除後、[collection](https://reference.aspose.com/slides/cpp/aspose.slides/slidecollection/) は再インデックス化され、後続のすべてのスライドが一つ左にシフトするため、以前のインデックス番号は無効になります。安定した参照が必要な場合は、インデックスではなく各スライドの永続的な ID を使用してください。

**スライドの ID はインデックスと異なりますか？また、隣接するスライドが削除されたときに変わりますか？**  
はい。インデックスはスライドの位置であり、スライドが追加または削除されると変わります。スライド ID は永続的な識別子であり、他のスライドが削除されても変わりません。

**スライドを削除するとスライドセクションにどのような影響がありますか？**  
スライドがセクションに属していた場合、そのセクションのスライド数は1つ減ります。セクションの構造は残り、セクションが空になる場合は、必要に応じて[remove or reorganize sections](/slides/ja/cpp/slide-section/) を実行できます。

**スライドが削除されたとき、添付されたノートやコメントはどうなりますか？**  
[Notes](/slides/ja/cpp/presentation-notes/) と[comments](/slides/ja/cpp/presentation-comments/) はそのスライドに紐付いており、スライドとともに削除されます。他のスライドのコンテンツには影響しません。

**スライドの削除は、未使用のレイアウト/マスターのクリーンアップとどう違いますか？**  
削除はデッキから特定の通常スライドを取り除きます。未使用のレイアウト/マスターのクリーンアップは、参照されていないレイアウトスライドやマスタースライドを削除し、残りのスライド内容を変更せずにファイルサイズを削減します。これらの操作は補完的であり、通常は先に削除を行い、その後クリーンアップを実行します。