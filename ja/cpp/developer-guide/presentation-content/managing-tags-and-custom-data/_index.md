---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /ja/cpp/managing-tags-and-custom-data

---

## プレゼンテーションファイルにおけるデータストレージ

PPTXファイル（拡張子が.pptxのアイテム）は、Office Open XML仕様の一部であるPresentationML形式で保存されています。Office Open XML形式は、プレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーション内の要素の一つとして*スライド*があり、*スライドパート*は1つのスライドの内容を含みます。スライドパートは、ISO/IEC 29500によって定義された多くのパート（ユーザー定義タグなど）に明示的な関係を持つことが許可されています。

カスタムデータ（プレゼンテーションに特有）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)）およびCustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)）として存在することができます。

{{% alert color="primary" %}} 

タグは本質的に文字列キーのペア値です。

{{% /alert %}} 

## タグの値を取得する

スライドでは、タグはIDocumentProperties.Keywordsプロパティに対応します。このサンプルコードは、Aspose.Slides for C++を使用してタグの値を取得する方法を示しています：[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## プレゼンテーションにタグを追加する

Aspose.Slidesを使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の2つのアイテムで構成されます：

- カスタムプロパティの名前 - `MyTag` 
- カスタムプロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいて一部のプレゼンテーションを分類する必要がある場合、これらのプレゼンテーションにタグを追加することで利益を得ることができます。例えば、北米の国々からのすべてのプレゼンテーションを分類したい場合、北米タグを作成し、関連する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for C++を使用して[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)にタグを追加する方法を示しています：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

タグは[Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)にも設定できます：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

また、個々の[Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape)にも設定できます：

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```