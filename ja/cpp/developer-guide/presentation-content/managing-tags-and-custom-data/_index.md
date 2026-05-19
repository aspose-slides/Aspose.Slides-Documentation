---
title: C++を使用したプレゼンテーションのタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/cpp/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ におけるタグとカスタム データの追加、読み取り、更新、削除方法について、PowerPoint と OpenDocument プレゼンテーションの例とともに学びます。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタム データを扱う方法を説明します。PPTX ファイルにデータがどのように保存されるかを簡単に概説し、プレゼンテーション固有のデータがタグやカスタム XML パーツとして存在できることに言及し、タグをキーと値の文字列ペアとして説明します。

また、タグの値を取得する方法や、プレゼンテーション、個々のスライド、またはシェイプにタグを追加する方法も示します。さらに、すべてのタグをクリアする、名前でタグを削除する、タグ名の一覧を取得するなど、一般的なタグ管理タスクについても取り上げています。

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（拡張子 .pptx のアイテム）は、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素の一つであり、*スライド パート* は単一のスライドの内容を保持します。スライド パートは、ISO/IEC 29500 に定義されたユーザー定義タグなど、複数のパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/itagcollection/)）や CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/icustomxmlpartcollection/)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは `IDocumentProperties.Keywords` プロパティに対応します。このサンプル コードは、Aspose.Slides for C++ で [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) のタグ値を取得する方法を示しています。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプル コードは、Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) にタグを追加する方法を示しています。

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

タグは [Slide](https://reference.aspose.com/slides/ja/cpp/aspose.slides/slide/) にも設定できます。

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

または個々の [Shape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/shape/) に対しても設定できます。

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **制限事項**

`get_CustomData()->get_Tags()` を使用してカスタム データ タグコレクションに追加されたタグは、PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際、これらのタグは PDF のタグ構造に **転送されません**。したがって、タグとして割り当てられたカスタム識別子は、タグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例: `shape->set_AlternativeText(u"MyId")`）にカスタム識別子を保存できます。PDF にエクスポートした後、Alt Text が PDF のタグ構造に表示される可能性があります。

## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する [clear](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全な一覧を取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/) で [GetNamesOfTags](https://reference.aspose.com/slides/ja/cpp/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。