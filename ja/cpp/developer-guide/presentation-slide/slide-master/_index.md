---
title: C++でプレゼンテーションのスライドマスターを管理
linktitle: スライドマスター
type: docs
weight: 80
url: /ja/cpp/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPTマスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++でスライドマスターを管理: PPT、PPTX、ODPに対して、レイアウト、テーマ、プレースホルダーを作成、編集、適用する簡潔なC++サンプル付き。"
---

## **PowerPoint のスライドマスターとは**

**Slide Master** は、プレゼンテーションのスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートを会社で使用するプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、スライドマスターを使用できます。 

スライドマスターは、すべてのプレゼンテーションスライドの外観を一度に設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライドマスター機構をサポートしています。 

VBA でもスライドマスターを操作し、PowerPoint でサポートされている同じ操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides はスライドマスターを使用し、基本的なタスクを実行するための柔軟なメカニズムを提供します。 

以下は基本的なスライドマスター操作です：

- スライドマスターを作成する。
- スライドマスターをプレゼンテーションスライドに適用する。
- スライドマスターの背景を変更する。 
- 画像、プレースホルダー、Smart Art などをスライドマスターに追加する。

以下はスライドマスターに関する高度な操作です： 

- スライドマスターを比較する。
- スライドマスターをマージする。
- 複数のスライドマスターを適用する。
- スライドマスター付きのスライドを別のプレゼンテーションにコピーする。
- プレゼンテーション内の重複するスライドマスターを検出する。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定する。

{{% alert color="primary" %}} 

ここで説明した主要なプロセスのライブ実装である Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) を確認したいかもしれません。

{{% /alert %}} 

## **スライドマスターはどのように適用されるか**

スライドマスターを使用する前に、プレゼンテーションでどのように使用され、スライドに適用されるかを理解したいでしょう。 

* すべてのプレゼンテーションはデフォルトで少なくとも 1 つのスライドマスターを持ちます。 
* プレゼンテーションには複数のスライドマスターを含めることができます。複数のスライドマスターを追加し、プレゼンテーションの異なる部分をさまざまな方法でスタイル設定できます。 

**Aspose.Slides** では、スライドマスターは [**IMasterSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) 型で表されます。 

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) オブジェクトは、[**get_Masters()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) リストを保持しており、これは [**IMasterSlideCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) 型で、プレゼンテーションで定義されたすべてのマスタースライドのリストを含みます。 

CRUD 操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) インターフェイスは、[**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#aaf86ba9a1c55969e7d5f4dbc8cb233a1) および [**InsertClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection#af297b1c8e31fbcef821f1554b1fbc311) メソッドを提供します。これらのメソッドは基本的なスライドクローン機能から継承されていますが、スライドマスターを扱う場合、複雑な設定を実装することができます。 

プレゼンテーションに新しいスライドが追加されると、スライドマスターが自動的に適用されます。デフォルトでは、前のスライドのスライドマスターが選択されます。 

**Note**: プレゼンテーションのスライドは [get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) リストに格納され、すべての新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションに単一のスライドマスターが含まれている場合、そのスライドマスターがすべての新しいスライドに選択されます。これが、作成するすべての新しいスライドに対してスライドマスターを個別に定義する必要がない理由です。 

PowerPoint と Aspose.Slides の原理は同じです。例えば、PowerPoint では新しいスライドを追加するとき、最後のスライドの下の行をクリックするだけで、（前のプレゼンテーションのスライドマスターを使用した）新しいスライドが作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) クラスの [AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) メソッドを使用して同等の操作を実行できます。 

## **スライド階層におけるスライドマスター**

スライドレイアウトとスライドマスターを組み合わせて使用すると、最大の柔軟性が得られます。スライドレイアウトは、スライドマスターと同じスタイル（背景、フォント、図形など）を設定できます。ただし、複数のスライドレイアウトがスライドマスター上に組み合わさると、新しいスタイルが作成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスターで適用されたスタイルから変更できます。 

スライドマスターはすべての設定項目の上位にあります: スライドマスター → スライドレイアウト → スライド: 

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) オブジェクトは [**get_LayoutSlides()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a200db12188121c969627e4c4c0253a37) プロパティを持ち、スライドレイアウトのリストを保持します。[Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) 型は [**get_LayoutSlide()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide#a56b36c32cb9e5db97cdbc7e8248f6fa8) プロパティを持ち、スライドに適用されたスライドレイアウトへのリンクを保持します。スライドとスライドマスター間の相互作用はスライドレイアウトを介して行われます。 

{{% alert color="info" title="Note" %}}

* Aspose.Slides では、すべてのスライド設定（スライドマスター、スライドレイアウト、およびスライド自体）は、実際には [**IBaseSlide**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) インターフェイスを実装するスライドオブジェクトです。  
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装する可能性があり、それらの値が [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide) オブジェクトにどのように適用されるかを理解する必要があります。スライドマスターが最初にスライドに適用され、次にスライドレイアウトが適用されます。例えば、スライドマスターとスライドレイアウトの両方に背景が設定されている場合、最終的なスライドの背景はスライドレイアウトのものになります。

{{% /alert %}}

## **スライドマスターの構成要素**

スライドマスターを変更する方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/masterslide/) のコアプロパティです。 

- [get(set)_Background()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aeac7142751858f0a68de92f259eb8d35) - スライドの背景を取得/設定します。  
- [get(set)_BodyStyle](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a51b96aee050a04e6d36b9d08b85dcf55) - スライド本文のテキストスタイルを取得/設定します。  
- [get(set)_Shapes](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#aa6b93a3863b7516d4a1a751a0ca885c7) - スライドマスター上のすべての図形（プレースホルダー、画像フレームなど）を取得/設定します。  
- [get(set)_Controls](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#ae05f1e1b686a52728ae94e47f308ff08) - ActiveX コントロールを取得/設定します。  
- [get_ThemeManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.theme.i_master_themeable#a70c68d34412e96f3cc24273fde826ecf) - テーママネージャーを取得します。  
- [get_HeaderFooterManager()](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a755d0d7cc3c677e746499f2a4e33a5cc) - ヘッダーとフッターのマネージャーを取得します。  

スライドマスターのメソッド:  

- [GetDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a9026e22b68087238cc73348e303c6d90) - スライドマスターに依存するすべてのスライドを取得します。  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide#a8d519dd31014fcbb2be0ab72061f94dc) - 現在のスライドマスターと新しいテーマに基づいて新しいスライドマスターを作成し、すべての依存スライドに適用できます。  

## **スライドマスターの取得**

PowerPoint では、ビュー → スライドマスター メニューからスライドマスターにアクセスできます。 

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、以下の方法でスライドマスターにアクセスできます: ```c++
System::SharedPtr<IMasterSlide> master = pres->get_Masters()->idx_get(0);
```


[IMasterSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide) インターフェイスはスライドマスターを表します。[get_Masters()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a8fda502eacdf2fe4ccfc1ab0bf185d29) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_master_slide_collection) 型に関連）は、プレゼンテーションで定義されたすべてのスライドマスターのリストを含みます。  

## **スライドマスターへの画像の追加**

スライドマスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。 

例えば、会社のロゴやいくつかの画像をスライドマスターに配置し、スライド編集モードに戻すと、すべてのスライドに画像が表示されます。 

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides を使用してスライドマスターに画像を追加できます: ```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png"));
pres->get_Master(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 

スライドへの画像追加に関する詳細は、[Picture Frame](/slides/ja/cpp/picture-frame/#create-picture-frame) 記事をご参照ください。

{{% /alert %}}

## **スライドマスターへのプレースホルダーの追加**

これらのテキストフィールドはスライドマスター上の標準プレースホルダーです: 

* マスタータイトルスタイルを編集するにはクリック  
* マスターテキストスタイルを編集  
* 第2レベル  
* 第3レベル  

これらはスライドマスターに基づくスライドにも表示されます。スライドマスター上でプレースホルダーを編集すると、変更が自動的にスライドに適用されます。 

PowerPoint では、スライドマスター → プレースホルダーの挿入 パスを使用してプレースホルダーを追加できます。 

![todo:image_alt_text](slide-master_5.png)

次に、Aspose.Slides を使用したプレースホルダーのより複雑な例を見てみましょう。スライドマスターからテンプレート化されたプレースホルダーを含むスライドです。 

![todo:image_alt_text](slide-master_6.png)

スライドマスター上でタイトルとサブタイトルの書式を次のように変更したいとします： 

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、次に `PlaceHolder.FillFormat` フィールドを使用します: ```c++
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


タイトルのスタイルと書式は、スライドマスターに基づくすべてのスライドで変更されます。 

{{% alert color="primary" title="See also" %}} 

* [プレースホルダーでプロンプトテキストを設定](https://docs.aspose.com/slides/cpp/manage-placeholder/) 
* [テキスト書式設定](https://docs.aspose.com/slides/cpp/text-formatting/)

{{% /alert %}}

## **スライドマスターの背景を変更する**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。この C++ コードはその操作を示しています: 

```c++
auto pres = System::MakeObject<Presentation>();

auto master = pres->get_Masters()->idx_get(0);
auto background = master->get_Background();
background->set_Type(Aspose::Slides::BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(Aspose::Slides::FillType::Solid);
background->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Green());
    
pres->Save(u"pres.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```


{{% alert color="primary" title="See also" %}} 

- [プレゼンテーションの背景](https://docs.aspose.com/slides/cpp/presentation-background/) 
- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/cpp/presentation-theme/) 

{{% /alert %}}

## **スライドマスターを別のプレゼンテーションにクローンする**

スライドマスターを別のプレゼンテーションにクローンするには、対象プレゼンテーションの [**AddClone()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) メソッドを呼び出し、スライドマスターを引数として渡します。この C++ コードはスライドマスターを別のプレゼンテーションにクローンする方法を示しています: 

```c++
auto presSource = System::MakeObject<Presentation>();
auto presTarget = System::MakeObject<Presentation>();
    
auto master = presTarget->get_Masters()->AddClone(presSource->get_Masters()->idx_get(0));
```


## **プレゼンテーションに複数のスライドマスターを追加する**

Aspose.Slides を使用すると、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドのスタイル、レイアウト、書式設定オプションを多様な方法で設定できます。 

PowerPoint では、[スライドマスター] メニューから新しいスライドマスターとレイアウトを次のように追加できます: 

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[AddClone()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a4c03a2193e89401782bf690bc5e22b48) メソッドを呼び出すことで新しいスライドマスターを追加できます: 

```c++
pres->get_Masters()->AddClone(pres->get_Masters()->idx_get(0));
```


## **スライドマスターの比較**

マスタースライドは [IBaseSlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide) インターフェイスを実装しており、[**Equals()**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_base_slide#afb1febe7cf3991c06f4d96e017c22b6f) メソッドが使用可能です。このメソッドは、構造と静的コンテンツが同一であるマスタースライドを比較するために使用され、`true` を返します。 

2 つのマスタースライドは、図形、スタイル、テキスト、アニメーション、その他の設定などがすべて同じであれば等しいとみなされます。比較では、スライド ID などの一意識別子や、日付プレースホルダーの現在の日付などの動的コンテンツは考慮されません。 

## **スライドマスターをプレゼンテーションのデフォルトビューに設定する**

Aspose.Slides では、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるビューです。 

このコードは、C++ でスライドマスターをプレゼンテーションのデフォルトビューに設定する方法を示しています: ```c++
pres->get_ViewProperties()->set_LastView(Aspose::Slides::ViewType::SlideMasterView);
```


## **未使用のマスタースライドの削除**

Aspose.Slides は、[RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッド（[Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) クラス）を提供し、不要で未使用のマスタースライドを削除できます。この C++ コードは、PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています: 

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```


## **FAQ**

**PowerPoint のスライドマスターとは何ですか？**  

スライドマスターは、プレゼンテーションのスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。すべてのプレゼンテーションスライドの外観を一度に設定および変更できます。  

**プレゼンテーションでスライドマスターはどのように適用されますか？**  

すべてのプレゼンテーションはデフォルトで少なくとも 1 つのスライドマスターを持ちます。新しいスライドが追加されると、スライドマスターが自動的に適用され、通常は前のスライドのマスターが継承されます。プレゼンテーションは複数のスライドマスターを含めて、異なる部分を個別にスタイル設定できます。  

**スライドマスターでカスタマイズできる要素は何ですか？**  

スライドマスターは、以下の主要プロパティをカスタマイズできます：  

- **Background**: スライドの背景を設定します。  
- **BodyStyle**: スライド本文のテキストスタイルを定義します。  
- **Shapes**: プレースホルダーや画像フレームなど、スライドマスター上のすべての図形を管理します。  
- **Controls**: ActiveX コントロールを処理します。  
- **ThemeManager**: テーママネージャーにアクセスします。  
- **HeaderFooterManager**: ヘッダーとフッターを管理します。  

**スライドマスターに画像を追加するにはどうすればよいですか？**  

スライドマスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。例えば、会社のロゴをスライドマスターに配置すると、プレゼンテーション内のすべてのスライドにロゴが表示されます。  

**スライドマスターはスライドレイアウトとどのように関係していますか？**  

スライドレイアウトはスライドマスターと連携してスライドデザインの柔軟性を提供します。スライドマスターは全体的なスタイルとテーマを定義し、スライドレイアウトはコンテンツ配置のバリエーションを可能にします。階層は次の通りです：  

- **Slide Master** → 全体的なスタイルを定義。  
- **Slide Layout** → 異なるコンテンツ配置を提供。  
- **Slide** → そのスライドレイアウトからデザインを継承。  

**単一のプレゼンテーションに複数のスライドマスターを持つことはできますか？**  

はい、プレゼンテーションには複数のスライドマスターを含めることができます。これにより、プレゼンテーションの異なるセクションをさまざまな方法でスタイル設定でき、デザインの柔軟性が向上します。  

**Aspose.Slides を使用してスライドマスターにアクセスし、変更するにはどうすればよいですか？**  

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーションオブジェクトの [get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) メソッドを使用してスライドマスターにアクセスできます。