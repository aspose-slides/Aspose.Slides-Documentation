---
title: C++ を使用したプレゼンテーションでのタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/cpp/managing-tags-and-custom-data/
keywords:
- 文書プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ でタグとカスタム データを追加、読み取り、更新、削除する方法を、PowerPoint と OpenDocument プレゼンテーションの例と共に学びます。"
---

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル—.pptx 拡張子のアイテム—は PresentationML 形式で保存されており、これは Office Open XML 仕様の一部です。Office Open XML 形式はプレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素のひとつで、*スライド パート* は単一スライドのコンテンツを保持します。スライド パートは ISO/IEC 29500 で定義された User Defined Tags など、多くのパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション 固有）やユーザーはタグ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) および CustomXmlParts([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)) として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは `IDocumentProperties.Keywords` プロパティに対応します。このサンプルコードは Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) のタグ値を取得する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは Aspose.Slides for C++ を使用して [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) にタグを追加する方法を示しています:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


タグは [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) に対しても設定できます:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


また、個々の [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape) に対しても設定できます:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) は、すべてのキー–バリュー ペアを一度に削除する [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除できます。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) 上で [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。