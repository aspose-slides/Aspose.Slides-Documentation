---
title: スライドマスター
type: docs
weight: 80
url: /cpp/slide-master/
keywords: "スライドマスターの追加, PPTマスタースライド, スライドマスターパワーポイント, スライドマスターへの画像, プレースホルダー, 複数のスライドマスター, スライドマスターを比較, C++, CPP, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションのスライドマスターを追加または編集する"
---

## **PowerPointのスライドマスターとは何ですか**

**スライドマスター**とは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、およびその他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートで会社のプレゼンテーション（または一連のプレゼンテーション）を作成したい場合、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの外観を一度に設定および変更できるため、便利です。Aspose.Slidesは、PowerPointのスライドマスター機構をサポートしています。

VBAもスライドマスターを操作し、背景の変更、形状の追加、レイアウトのカスタマイズなど、PowerPointでサポートされている同じ操作を実行することを許可します。Aspose.Slidesは、スライドマスターを使用し、それらを使用して基本的なタスクを実行するための柔軟なメカニズムを提供します。

基本的なスライドマスター操作は次のとおりです：

- スライドマスターを作成または追加します。
- プレゼンテーションスライドにスライドマスターを適用します。
- スライドマスターの背景を変更します。
- スライドマスターに画像、プレースホルダー、スマートアートなどを追加します。

スライドマスターに関するより高度な操作は次のとおりです：

- スライドマスターを比較します。
- スライドマスターをマージします。
- 複数のスライドマスターを適用します。
- スライドマスター付きのスライドを別のプレゼンテーションにコピーします。
- プレゼンテーション内の重複したスライドマスターを見つけます。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定します。

{{% alert color="primary" %}} 

Asposeの[**オンラインPowerPointビューワー**](https://products.aspose.app/slides/viewer)をご覧になることをお勧めします。これは、ここで説明するいくつかの主要なプロセスのライブ実装です。

{{% /alert %}} 

## **スライドマスターはどのように適用されますか**

スライドマスターを使用する前に、プレゼンテーション内での使用方法やスライドへの適用方法を理解しておくと良いでしょう。

* プレゼンテーションには、デフォルトで少なくとも1つのスライドマスターがあります。
* プレゼンテーションには、複数のスライドマスターを含むことができます。複数のスライドマスターを追加し、プレゼンテーションの異なる部分を異なる方法でスタイリングするために使用できます。

**Aspose.Slides**では、スライドマスターは[**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)型で表されます。

Aspose.Slidesの[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)オブジェクトには、プレゼンテーション内に定義されたすべてのマスタースライドのリストを含む[**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29)の[**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)型があります。

CRUD操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)インターフェースには、[**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1)および[**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311)などの便利なメソッドが含まれています。これらのメソッドは、基本的なスライドのクローン機能から継承されています。しかし、スライドマスターを扱う場合、これらのメソッドを使用すると複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、自動的にスライドマスターが適用されます。前のスライドのスライドマスターがデフォルトで選択されます。

**注意**: プレゼンテーションスライドは[get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)リストに格納されており、各新しいスライドはデフォルトでコレクションの最後に追加されます。プレゼンテーションに単一のスライドマスターが含まれている場合、そのスライドマスターがすべての新しいスライドに選択されます。これが、新しいスライドを作成するたびにスライドマスターを定義する必要がない理由です。

原則として、PowerPointとAspose.Slidesは同じです。たとえば、PowerPointでは、新しいプレゼンテーションを追加すると、最後のスライドの下の一番下の行を押すだけで、新しいスライド（最後のプレゼンテーションのスライドマスター付き）が作成されます。

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slidesでは、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)クラスの[AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48)メソッドを使用して同等のタスクを実行できます。

## **スライドの階層におけるスライドマスター**

スライドマスターを使用したスライドレイアウトは、最大限の柔軟性を提供します。スライドレイアウトでは、スライドマスターと同じスタイル（背景、フォント、形状など）を設定できます。ただし、スライドマスターに複数のスライドレイアウトを組み合わせると、新しいスタイルが作成されます。特定のスライドにスライドレイアウトを適用すると、スライドマスターによって適用されたスタイルから変更できます。

スライドマスターはすべての設定項目を上回ります：スライドマスター -> スライドレイアウト -> スライド：

![todo:image_alt_text](slide-master_2)

各[IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)オブジェクトには、スライドレイアウトのリストを持つ[**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37)プロパティがあります。[Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)型には、スライドに適用されたスライドレイアウトへのリンクを持つ[**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8)プロパティがあります。スライドとスライドマスター間の相互作用は、スライドレイアウトを介して行われます。

{{% alert color="info" title="注意" %}}

* Aspose.Slidesでは、すべてのスライドセットアップ（スライドマスター、スライドレイアウト、およびスライド自体）は、実際に[**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide)インターフェースを実装するスライドオブジェクトです。
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装している場合があり、それらの値が[Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide)オブジェクトにどのように適用されるかを知っておく必要があります。スライドマスターがスライドに最初に適用され、その後スライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方に背景値がある場合、スライドはスライドレイアウトからの背景を受け取ります。

{{% /alert %}}

## **スライドマスターが含むもの**

スライドマスターがどのように変更できるかを理解するためには、その構成要素を知っておく必要があります。これらは[MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/)のコアプロパティです。

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - スライドの背景を取得/設定します。
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - スライドの本文スタイルを取得/設定します。
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - スライドマスターのすべての形状（プレースホルダー、画像枠など）を取得/設定します。
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - ActiveXコントロールを取得/設定します。
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - テーママネージャーを取得します。
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - ヘッダーとフッターマネージャーを取得します。

スライドマスターのメソッド：

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - スライドマスターに依存するすべてのスライドを取得します。
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - 現在のスライドマスターと新しいテーマに基づいて新しいスライドマスターを作成することを許可します。新しいスライドマスターは、すべての依存スライドに適用されます。

## **スライドマスターを取得する**

PowerPointでは、スライドマスターは表示 -> スライドマスターのメニューからアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slidesを使用すると、スライドマスターに次の方法でアクセスできます：

```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```

[IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide)インターフェースはスライドマスターを表します。[get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29)プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection)型に関連）は、プレゼンテーション内に定義されたすべてのスライドマスターのリストを含んでいます。

## **スライドマスターに画像を追加する**

スライドマスターに画像を追加すると、その画像はそのスライドマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴやいくつかの画像をスライドマスターに配置し、その後スライド編集モードに戻ることができます。すべてのスライドに画像が表示されるはずです。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slidesを使用してスライドマスターに画像を追加できます：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

{{% alert color="primary" title="関連情報" %}} 

スライドに画像を追加する方法についての詳細は、[ピクチャーフレーム](/slides/cpp/picture-frame/#create-picture-frame)の記事をご覧ください。
{{% /alert %}}

## **スライドマスターにプレースホルダーを追加する**

これらのテキストフィールドは、スライドマスター上の標準的なプレースホルダーです：

* マスタのタイトルスタイルを編集するにはクリックします

* マスタのテキストスタイルを編集します

* 第二レベル

* 第三レベル 

これらは、スライドマスターに基づくスライドにも表示されます。スライドマスターのプレースホルダーを編集すると、変更が自動的にスライドに適用されます。

PowerPointでは、スライドマスター -> プレースホルダーの挿入パスを通じてプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slidesを使用したプレースホルダーのより複雑な例を見てみましょう。スライドマスターからテンプレート化されたプレースホルダーのあるスライドを考えてみてください：

![todo:image_alt_text](slide-master_6.png)

スライドマスター上でタイトルとサブタイトルの書式をこのように変更したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、その後`PlaceHolder.FillFormat`フィールドを使用します：

```c++
System::SharedPtr<IAutoShape> FindPlaceholder(System::SharedPtr<IMasterSlide> master, PlaceholderType type)
{
    for (auto& shape : master->get_Shapes())
    {
        System::SharedPtr<IAutoShape> autoShape = System::AsCast<Aspose::Slides::IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            if (autoShape->get_Placeholder()->get_Type() == type)
            {
                return autoShape;
            }
        }
    }
    return nullptr;
}

void Main()
{
    auto pres = System::MakeObject<Presentation>();
    System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
    System::SharedPtr<IAutoShape> placeHolder = FindPlaceholder(master, Aspose::Slides::PlaceholderType::Title);
    auto fillFormat = placeHolder->get_FillFormat();
    fillFormat->set_FillType(Aspose::Slides::FillType::Gradient);
    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(Aspose::Slides::GradientShape::Linear);
    gradientFormat->get_GradientStops()->Add(0.0f, System::Drawing::Color::FromArgb(255, 0, 0));
    gradientFormat->get_GradientStops()->Add(255.0f, System::Drawing::Color::FromArgb(128, 0, 128));
    
    pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
}
```

タイトルスタイルと書式が、スライドマスターに基づくすべてのスライドに変更が適用されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="関連情報" %}} 

* [プレースホルダーにプロンプトテキストを設定する](https://docs.aspose.com/slides/cpp/manage-placeholder/)
* [テキストの書式設定](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **スライドマスターの背景を変更する**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常のスライドが新しい色になります。このC++コードはその操作を示しています：

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{% alert color="primary" title="関連情報" %}} 

- [プレゼンテーションの背景](https://docs.aspose.com/slides/cpp/presentation-background/)

- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/cpp/presentation-theme/)

{{% /alert %}}

## **スライドマスターを別のプレゼンテーションにクローンする**

スライドマスターを別のプレゼンテーションにクローンするには、宛先プレゼンテーションから[**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48)メソッドを呼び出し、スライドマスターを引数として渡します。このC++コードは、スライドマスターを別のプレゼンテーションにクローンする方法を示しています：

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```

## **プレゼンテーションに複数のスライドマスターを追加する**

Aspose.Slidesでは、複数のスライドマスターやスライドレイアウトを任意のプレゼンテーションに追加することができます。これにより、さまざまな方法でプレゼンテーションスライドのスタイル、レイアウト、および書式設定オプションを設定できます。

PowerPointでは、「スライドマスターメニュー」から新しいスライドマスターやレイアウトを追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slidesを使用すると、[AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48)メソッドを呼び出して新しいスライドマスターを追加できます：

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```

## **スライドマスターを比較する**

マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide)インターフェースを実装しており、[**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f)メソッドを含んでいます。このメソッドを使用してスライドを比較できます。同じ構造と静的コンテンツのマスタースライドに対して`true`を返します。

2つのマスタースライドは、それらの形状、スタイル、テキスト、アニメーションおよびその他の設定が等しい場合に等しいと見なされます。比較は、ユニークな識別子の値（例：SlideId）や動的コンテンツ（例：日付プレースホルダーの現在の日付値）を考慮しません。

## **スライドマスターをプレゼンテーションのデフォルトビューとして設定する**

Aspose.Slidesでは、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるものです。

このコードは、C++でスライドマスターをプレゼンテーションのデフォルトビューとして設定する方法を示しています：

```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```

## **未使用のマスタースライドを削除する**

Aspose.Slidesは、不要で未使用のマスタースライドを削除するために[RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)メソッド（[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/)クラスから）を提供しています。このC++コードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```