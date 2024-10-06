---
title: スライドマスター
type: docs
weight: 80
url: /ja/python-net/slide-master/
keywords: "スライドマスターの追加, PPTマスタースライド, スライドマスターパワーポイント, スライドマスターへの画像, プレースホルダー, 複数のスライドマスター, スライドマスターの比較, Python, Aspose.Slides"
description: "PythonでPowerPointプレゼンテーションにスライドマスターを追加または編集する"
---

## **PowerPointにおけるスライドマスターとは**

**スライドマスター**は、プレゼンテーションのスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートを使用して会社向けのプレゼンテーション（または一連のプレゼンテーション）を作成したい場合、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの見た目を一度に設定および変更できるため、便利です。Aspose.SlidesはPowerPointのスライドマスターメカニズムをサポートしています。

VBAでもスライドマスターを操作し、背景の変更、図形の追加、レイアウトのカスタマイズなど、PowerPointでサポートされている同じ操作を実行できます。Aspose.Slidesは、スライドマスターを使用し、基本的な操作を行うための柔軟なメカニズムを提供します。

基本的なスライドマスターの操作は以下の通りです：

- スライドマスターの作成または編集。
- プレゼンテーションスライドへのスライドマスターの適用。
- スライドマスターの背景を変更。 
- スライドマスターに画像、プレースホルダー、スマートアートなどを追加。

スライドマスターに関するより高度な操作は以下の通りです：

- スライドマスターの比較。
- スライドマスターのマージ。
- 複数のスライドマスターの適用。
- スライドをスライドマスターとともに別のプレゼンテーションにコピー。
- プレゼンテーションでの重複スライドマスターを見つける。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定。

{{% alert color="primary" %}} 

Asposeの[**オンラインPowerPointビューア**](https://products.aspose.app/slides/viewer)をぜひご確認ください。ここで説明したコアプロセスのいくつかのライブ実装です。

{{% /alert %}} 

## **スライドマスターの適用方法**

スライドマスターを使用する前に、プレゼンテーションでどのように使用され、スライドに適用されるかを理解しておくと良いでしょう。

* すべてのプレゼンテーションにはデフォルトで少なくとも1つのスライドマスターがあります。 
* プレゼンテーションには複数のスライドマスターを含めることができます。複数のスライドマスターを追加して、プレゼンテーションの異なる部分に異なるスタイルを適用できます。

**Aspose.Slides**では、スライドマスターは[**IMasterSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)タイプで表されます。

Aspose.Slidesの[プレゼンテーション](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)オブジェクトには、プレゼンテーションに定義されているすべてのマスタースライドのリストを含む[**masters**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)の[**IMasterSlideCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)が含まれています。

CRUD操作に加えて、 [IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)インターフェイスには、 [**add_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)および[**insert_clone**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)メソッドが含まれています。これらのメソッドは基本的なスライドクローン機能から継承されていますが、スライドマスターの処理を行う際には、複雑な設定を実装することができます。

新しいスライドがプレゼンテーションに追加されると、自動的にスライドマスターが適用されます。デフォルトでは、前のスライドのスライドマスターが選択されます。

**注意**：プレゼンテーションスライドは[Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)リストに格納され、すべての新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションが単一のスライドマスターを含む場合、そのスライドマスターは新しいスライドすべてに選択されます。このため、作成する新しいスライドごとにスライドマスターを定義する必要はありません。

この原則はPowerPointとAspose.Slidesで同じです。たとえば、PowerPointでは新しいプレゼンテーションを追加するとき、最後のスライドの下の下部にある行をクリックするだけで、新しいスライド（最後のプレゼンテーションのスライドマスターを使用）が作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slidesを使用すると、[add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/)メソッドを使用して同等のタスクを実行できます。

## **スライドの階層におけるスライドマスター**

スライドレイアウトをスライドマスターと一緒に使用することで、最大限の柔軟性が得られます。スライドレイアウトでは、スライドマスターと同様のスタイル（背景、フォント、図形など）を設定できます。ただし、複数のスライドレイアウトがスライドマスターに組み合わされると、新しいスタイルが作成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスターが適用したスタイルから変更できます。

スライドマスターはすべての設定項目を優先します：スライドマスター -> スライドレイアウト -> スライド：

![todo:image_alt_text](slide-master_2)

各[IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)オブジェクトには、スライドレイアウトのリストを持つ[**LayoutSlides**](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)プロパティがあります。[スライド](https://reference.aspose.com/slides/python-net/aspose.slides/slide)タイプは、スライドに適用されるスライドレイアウトへのリンクを持つ[**LayoutSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/)プロパティを持っています。スライドとスライドマスターの相互作用は、スライドレイアウトを通じて行われます。

{{% alert color="info" title="注意" %}}

* Aspose.Slidesでは、すべてのスライド設定（スライドマスター、スライドレイアウト、およびスライド自体）はすべて、 [**IBaseSlide**](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)インターフェイスを実装するスライドオブジェクトです。
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装でき、その値が[スライド](https://reference.aspose.com/slides/python-net/aspose.slides/slide/)オブジェクトにどのように適用されるかを理解しておく必要があります。スライドマスターが最初にスライドに適用され、その後スライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方に背景値がある場合、スライドはスライドレイアウトからの背景を持つことになります。

{{% /alert %}}

## **スライドマスターの構成要素**

スライドマスターがどのように変更できるかを理解するには、その構成要素を知る必要があります。これらは[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)のコアプロパティです。

- `background` スライドの背景を取得/設定。
- `body_style` スライド本文のテキストスタイルを取得/設定。
- `shapes` スライドマスターのすべての形状を取得/設定（プレースホルダー、画像フレームなど）。
- `controls` - ActiveXコントロールを取得/設定。
- `theme_manager` - テーママネージャを取得。
- `header_footer_manager` - ヘッダーとフッターマネージャを取得。

スライドマスターのメソッド：

- `get_depending_slides()` - スライドマスターに依存するすべてのスライドを取得。
- `apply_external_theme_to_depending_slides(fname)` - 現在のスライドマスターと新しいテーマに基づいて新しいスライドマスターを作成することを可能にします。新しいスライドマスターは、すべての依存スライドに適用されます。

## **スライドマスターの取得**

PowerPointでは、スライドマスターにView -> スライドマスターのメニューからアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slidesを使用すると、次のようにスライドマスターにアクセスできます：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    # プレゼンテーションのマスタースライドへのアクセスを提供
    masterSlide = pres.masters[0]
```

[IMasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslide/)インターフェイスはスライドマスターを表します。`masters`プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/imasterslidecollection/)タイプに関連）には、プレゼンテーションに定義されているすべてのスライドマスターのリストが含まれています。

## **スライドマスターに画像を追加**

スライドマスターに画像を追加すると、その画像はそのスライドマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴやいくつかの画像をスライドマスターに配置した後、スライド編集モードに戻ると、すべてのスライドに画像が表示されるはずです。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slidesを使用してスライドマスターに画像を追加できます：

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    image = pres.images.add_image(open("image.png", "rb").read())
    pres.masters[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    pres.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" title="関連情報" %}} 

スライドに画像を追加するための詳細については、[画像フレーム](/slides/ja/python-net/picture-frame/#create-picture-frame)の記事を参照してください。
{{% /alert %}}

## **スライドマスターにプレースホルダーを追加**

これらのテキストフィールドは、スライドマスターの標準的なプレースホルダーです：

* マスタータイトルスタイルを編集するにはクリック

* マスターテキストスタイルを編集

* 第2レベル

* 第3レベル 

これらはスライドマスターに基づいているスライドにも表示されます。スライドマスター上でこれらのプレースホルダーを編集すると、変更がスライドに自動的に適用されます。

PowerPointでは、スライドマスター -> プレースホルダーの挿入経路を通じてプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slidesを使用して、プレースホルダーを持つスライドのより複雑な例を考えてみましょう：

![todo:image_alt_text](slide-master_6.png)

スライドマスターでタイトルとサブタイトルの書式設定を次のように変更したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーのコンテンツを取得し、次に`PlaceHolder.FillFormat`フィールドを使用します：

```python
# マスターのタイトルプレースホルダーへの参照を取得
titlePlaceholder = masterSlide.shapes[0]

# フォーマットフィルをグラデーションフィルとして設定
titlePlaceholder.fill_format.fill_type = slides.FillType.GRADIENT
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
titlePlaceholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```

タイトルスタイルと書式設定は、スライドマスターに基づくすべてのスライドに変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="関連情報" %}} 

* [プレースホルダーにプロンプトテキストを設定](https://docs.aspose.com/slides/python-net/manage-placeholder/)
* [テキストの書式設定](https://docs.aspose.com/slides/python-net/text-formatting/)

{{% /alert %}}

## **スライドマスターの背景を変更**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドに新しい色が適用されます。このPythonコードは、その操作を示しています：

```python
masterSlide.background.type = slides.BackgroundType.OWN_BACKGROUND
masterSlide.background.fill_format.fill_type = slides.FillType.SOLID
masterSlide.background.fill_format.solid_fill_color.color = draw.Color.gray
```

{{% alert color="primary" title="関連情報" %}} 

- [プレゼンテーションの背景](https://docs.aspose.com/slides/python-net/presentation-background/)

- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/python-net/presentation-theme/)

{{% /alert %}}

## **スライドマスターを別のプレゼンテーションにクローンする**

スライドマスターを別のプレゼンテーションにクローンするには、目的のプレゼンテーションから`add_clone(source_slide, dest_master, allow_clone_missing_layout)`メソッドを呼び出し、そこにスライドマスターを渡します。このPythonコードは、スライドマスターを別のプレゼンテーションにクローンする方法を示しています：

```python
# 新しいマスタースライドを追加 
pres1MasterSlide = pres.masters.add_clone(masterSlide)
```

## **プレゼンテーションに複数のスライドマスターを追加**

Aspose.Slidesを使用すると、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドのスタイル、レイアウト、および書式設定オプションをさまざまな方法で設定できます。

PowerPointでは、新しいスライドマスターやレイアウト（「スライドマスター」メニューから）を次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slidesを使用すると、`add_clone`メソッドを呼び出して新しいスライドマスターを追加できます：

```python
# 新しいマスタースライドを追加
secondMasterSlide = pres.masters.add_clone(masterSlide)
```

## **スライドマスターを比較**

マスタースライドは、`equals(slide)`メソッドを含む[IBaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/ibaseslide/)インターフェイスを実装しており、このメソッドを使用してスライドを比較できます。構造と静的コンテンツが同一のマスタースライドには`true`が返されます。

2つのマスタースライドが等しいのは、形状、スタイル、テキスト、アニメーション、その他の設定が等しい場合です。比較は、一意の識別子値（例：SlideId）や動的コンテンツ（例：日付プレースホルダーの現在の日付値）を考慮しません。

## **スライドマスターをプレゼンテーションのデフォルトビューとして設定する**

Aspose.Slidesを使用すると、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるものです。

このコードは、Pythonでプレゼンテーションのデフォルトビューとしてスライドマスターを設定する方法を示しています：

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationクラスをインスタンス化
with slides.Presentation() as presentation:
    # デフォルトビューをスライドマスタービューに設定
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # プレゼンテーションを保存
    presentation.save("PresView.pptx", slides.export.SaveFormat.PPTX)
```

## **未使用のマスタースライドを削除する**

Aspose.Slidesは、不要で未使用のマスタースライドを削除できる`remove_unused_master_slides`メソッド（[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/)クラスから）を提供しています。このPythonコードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_master_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```