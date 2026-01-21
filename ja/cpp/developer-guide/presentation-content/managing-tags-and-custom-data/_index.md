---
title: C++ を使用したプレゼンテーションでのタグとカスタム データの管理
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
description: "Aspose.Slides for C++ におけるタグとカスタム データの追加、読み取り、更新、削除方法を学び、PowerPoint と OpenDocument プレゼンテーションの例を示します。"
---

## **プレゼンテーション ファイルのデータ ストレージ**

PPTX ファイル（拡張子 .pptx のアイテム）は、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーションの要素のひとつである*スライド*に対し、*スライド パート*は単一のスライドのコンテンツを保持します。スライド パートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、多くのパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）またはユーザーはタグ（[ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは IDocumentProperties.Keywords プロパティに対応します。以下のサンプル コードは、Aspose.Slides for C++ の [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) でタグの値を取得する方法を示しています。
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 – `MyTag`
- カスタム プロパティの値 – `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、該当する国（米国、メキシコ、カナダ）を値として設定できます。

以下のサンプル コードは、Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) にタグを追加する方法を示しています。
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


タグは [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/) にも設定できます。
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


または個々の [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/) にも設定できます。
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) は、すべてのキー‑バリュー ペアを一度に削除する [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体をループせずに、名前で単一のタグを削除する方法は？**

[TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除できます。

**分析やフィルタリングのためにタグ名の完全なリストを取得するには？**

[tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) の [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) を使用します。すべてのタグ名を含む配列が返されます。