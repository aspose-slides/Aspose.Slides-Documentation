---
title: Python で PowerPoint スライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 80
url: /ja/python-net/slide-master/
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
- マスタースライドの重複
- 未使用のマスタースライド
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint および OpenDocument のスライドマスターを自動化し、開発効率を最大化します。初心者から上級者までの完全ガイドです。"
---

## **概要**

**Slide Master** は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、およびその他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートで会社のプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、Slide Master を使用できます。

Slide Master は、すべてのプレゼンテーションスライドの外観を一度に設定および変更できるため便利です。Aspose.Slides は PowerPoint の Slide Master 機構をサポートしています。

VBA でも Slide Master を操作でき、PowerPoint でサポートされている操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides は柔軟な API を提供し、Slide Master を扱い、一般的なタスクを実行できます。

基本的な Slide Master 操作は次のとおりです：

- Slide Master を作成する。
- スライドに Slide Master を適用する。
- Slide Master の背景を変更する。
- 画像、プレースホルダー、SmartArt などを Slide Master に追加する。

Slide Master に関する高度な操作は次のとおりです：

- Slide Master を比較する。
- Slide Master をマージする。
- 複数の Slide Master を適用する。
- スライドとその Slide Master を別のプレゼンテーションにコピーする。
- プレゼンテーション内の重複する Slide Master を特定する。
- Slide Master をプレゼンテーションのデフォルト表示に設定する。

{{% alert color="primary" %}}
Aspose の[オンライン PowerPoint ビューア](https://products.aspose.app/slides/viewer)は、ここで説明する主要なプロセスのライブ実装です。ぜひご確認ください。
{{% /alert %}}

## **スライドマスターの適用方法**

Slide Master を操作する前に、プレゼンテーションで Slide Master がどのように使用され、スライドに適用されるかを理解するとよいでしょう。

- すべてのプレゼンテーションには、デフォルトで少なくとも 1 つの Slide Master が存在します。
- プレゼンテーションには複数の Slide Master を含めることができ、複数の Slide Master を追加して、プレゼンテーションの異なる部分を異なるスタイルで装飾できます。

Aspose.Slides では、Slide Master は [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトは、[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) 型の [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) コレクションを保持し、プレゼンテーションで定義されたすべてのマスタースライドが格納されます。

CRUD 操作に加えて、[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) クラスは [add_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/add_clone/) や [insert_clone](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/insert_clone/) といった便利なメソッドを提供します。これらは基本的なスライド複製機能を拡張し、Slide Master を扱う際により複雑な構成を実装できるようにします。

新しいスライドがプレゼンテーションに追加されると、Slide Master が自動的に適用されます。デフォルトでは、前のスライドの Slide Master が選択されます。

**注意:** プレゼンテーションのスライドは [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) コレクションに格納され、新しいスライドはデフォルトでそのコレクションの末尾に追加されます。プレゼンテーションに単一の Slide Master が含まれている場合、すべての新しいスライドはその Slide Master が選択されます。そのため、各新規スライドで Slide Master を個別に指定する必要はありません。

この原則は PowerPoint と Aspose.Slides の両方に当てはまります。たとえば、PowerPoint で新しいスライドを追加するとき、最後のスライドの下部をクリックすると、前のスライドの Slide Master を使用した新しいスライドが作成されます。

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) クラスの [add_clone(ISlide)](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_clone/) メソッドを使用して同等の操作を実行できます。

## **Slides 階層における Slide Master**

**Slide Layout** と **Slide Master** を組み合わせて使用すると、最大の柔軟性が得られます。Slide Layout は Slide Master と同様のスタイル（背景、フォント、図形など）を定義できます。Slide Master の下に複数の Slide Layout が定義されている場合、これらは一体となったスタイルシステムを構成します。個々のスライドに Slide Layout を適用すると、Slide Master が提供するスタイルに対して相対的に調整できます。

優先順位は **Slide Master** → **Slide Layout** → **Slide** です。

![todo:image_alt_text](slide-master_2.jpg)

各 [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) オブジェクトは、スライドレイアウトのリストを保持する [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/layout_slides/) プロパティを持ちます。[Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) は、適用されたスライドレイアウトを参照する [layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) プロパティを持ちます。スライドと Slide Master との相互作用は、スライドレイアウトを介して行われます。

{{% alert color="info" title="Note" %}}
- Aspose.Slides では、すべてのスライド構成要素（Slide Master、Slide Layout、スライド自体）は [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) クラスを継承したスライドオブジェクトです。
- Slide Master と Slide Layout は多くの同一プロパティを公開しているため、これらの値が [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) オブジェクトにどのように適用されるかを理解する必要があります。Slide Master が先に適用され、次に Slide Layout が適用されます。たとえば、Slide Master と Slide Layout の両方で背景が定義されている場合、スライドは Slide Layout の背景を使用します。
{{% /alert %}}

## **Slide Master の構成要素**

Slide Master を変更する方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) の主要プロパティです：

- `background` — スライドの背景を取得/設定します。
- `body_style` — スライド本体のテキストスタイルを取得/設定します。
- `shapes` — Slide Master 上のすべての図形（プレースホルダー、画像フレームなど）を取得/設定します。
- `controls` — ActiveX コントロールを取得/設定します。
- `theme_manager` — テーママネージャーを取得します。
- `header_footer_manager` — ヘッダーとフッターのマネージャーを取得します。

Slide Master のメソッド：

- `get_depending_slides()` — Slide Master に依存するすべてのスライドを取得します。
- `apply_external_theme_to_depending_slides(fname)` — 現在の Slide Master と外部テーマから新しい Slide Master を作成し、すべての依存スライドに適用します。

## **Slide Master の取得方法**

PowerPoint では、**ビュー** → **スライドマスター** から Slide Master にアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、次のように Slide Master にアクセスできます：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # プレゼンテーション内の最初のマスタースライドを取得します。
    master_slide = presentation.masters[0]
```


[MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) クラスが Slide Master を表します。[masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) プロパティ（[MasterSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterslidecollection/) 型）は、プレゼンテーションで定義されたすべての Slide Master を保持します。

## **Slide Master に画像を追加する**

Slide Master に画像を追加すると、その画像はマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴやその他の画像を Slide Master に配置し、通常表示に戻すと、すべての依存スライドに画像が表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides で Slide Master に画像を追加するには次のコードをご使用ください：
```python
import aspose.slides as slides

with slides.Presentation() as presentation:

    with open("image.png", "rb") as image_stream:
        image = presentation.images.add_image(image_stream.read())

    master_slide = presentation.masters[0]
    master_slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" title="See also" %}}
スライドに画像を追加する方法の詳細は、[Add Picture Frames to Presentations with Python](/slides/ja/python-net/picture-frame/) 記事をご参照ください。
{{% /alert %}}

## **Slide Master にプレースホルダーを追加する**

以下は Slide Master 上の標準プレースホルダーです：

- Master タイトルスタイルを編集するにはクリック
- Master テキストスタイルを編集する
- 第 2 レベル
- 第 3 レベル

これらのプレースホルダーは、Slide Master を基にしたスライドにも表示されます。Slide Master 上でプレースホルダーを編集すると、変更が自動的にスライドに適用されます。

PowerPoint では、**スライドマスター** → **プレースホルダーの挿入** でプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

以下は Aspose.Slides におけるプレースホルダーのより複雑な例です。Slide Master から継承されたプレースホルダーを持つスライドを考えてみます：

![todo:image_alt_text](slide-master_6.png)

次のように Slide Master のタイトルとサブタイトルの書式を更新したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、Slide Master からタイトルプレースホルダーを取得し、`PlaceHolder.fill_format` プロパティを使用します：
```python
# マスタースライドのタイトルプレースホルダーへの参照を取得します。
title_placeholder = master_slide.shapes[0]

# 塗りつぶし形式をグラデーションに設定します。
title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
title_placeholder.fill_format.gradient_format.gradient_stops.add(0, draw.Color.red)
title_placeholder.fill_format.gradient_format.gradient_stops.add(50, draw.Color.green)
title_placeholder.fill_format.gradient_format.gradient_stops.add(100, draw.Color.blue)
```


タイトルのスタイルと書式が、Slide Master を基にしたすべてのスライドで変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}}
* [Manage Placeholders in Presentations with Python](/slides/ja/python-net/manage-placeholder/)
* [Format PowerPoint Text in Python](/slides/ja/python-net/text-formatting/)
{{% /alert %}}

## **Slide Master の背景を変更する**

Slide Master の背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色を継承します。以下の Python コードで実演できます：
```python
master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
master_slide.background.fill_format.fill_type = slides.FillType.SOLID
master_slide.background.fill_format.solid_fill_color.color = draw.Color.gray
```


{{% alert color="primary" title="See also" %}}
- [Manage Presentation Backgrounds in Python](/slides/ja/python-net/presentation-background/)
- [Manage PowerPoint Presentation Themes in Python](/slides/ja/python-net/presentation-theme/)
{{% /alert %}}

## **プレゼンテーションに複数の Slide Master を追加する**

Aspose.Slides を使用すると、任意のプレゼンテーションに複数の Slide Master と Slide Layout を追加できます。これにより、スライドのスタイル、レイアウト、書式設定オプションをさまざまな方法で構成できます。

PowerPoint では、**スライドマスター** メニューから新しい Slide Master と Slide Layout を次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、`add_clone` メソッドを呼び出すことで新しい Slide Master を追加できます：
```python
# 新しいマスタースライドを追加します。
master_slide2 = presentation.masters.add_clone(master_slide1)
```


## **Slide Master の比較**

Slide Master は [BaseSlide](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/) クラスを継承しており、`equals(slide)` メソッドでスライドを比較できます。このメソッドは、構造と静的コンテンツが同一の場合に true を返します。

2 つの Slide Master は、形状、スタイル、テキスト、アニメーション、その他の設定が同一である場合に等しいと見なされます。比較は一意の識別子（例：`slide_id`）や動的コンテンツ（例：日付プレースホルダー内の現在の日付）を無視します。

## **Slide Master をプレゼンテーションのデフォルトビューに設定する**

Aspose.Slides では、Slide Master をプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるビューです。以下の Python 例で設定方法を示します：
```py
import aspose.slides as slides

# プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します。
with slides.Presentation() as presentation:
    # デフォルトビューをスライドマスタービューに設定します。
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW

    # プレゼンテーションを保存します。
    presentation.save("presentation_view.pptx", slides.export.SaveFormat.PPTX)
```


## **未使用のマスタースライドを削除する**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) クラスの `remove_unused_master_slides` メソッドを提供し、不要な未使用マスタースライドを削除できます。次の Python コードは、PowerPoint プレゼンテーションから未使用マスタースライドを削除する方法を示します：
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**PowerPoint の Slide Master とは何ですか？**

Slide Master は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。これにより、すべてのプレゼンテーションスライドの外観を一度に設定および変更できます。

**Slide Master と Slide Layout の関係は？**

Slide Layout は Slide Master と連携してスライドデザインに柔軟性を提供します。Slide Master が全体的なスタイルとテーマを定義するのに対し、[Slide Layout](/slides/ja/python-net/slide-layout/) はコンテンツ配置のバリエーションを可能にします。階層は次のとおりです：

- **Slide Master** → グローバルスタイルを定義
- **Slide Layout** → コンテンツ配置のバリエーションを提供
- **Slide** → Slide Layout からデザインを継承

**1 つのプレゼンテーションに複数の Slide Master を持てますか？**

はい。プレゼンテーションには複数の Slide Master を含めることができ、プレゼンテーションの異なるセクションをさまざまな方法で装飾でき、デザインの柔軟性が向上します。

**Aspose.Slides で Slide Master にアクセスし、変更するにはどうすればよいですか？**

Aspose.Slides では、Slide Master は [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/) クラスで表されます。[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) オブジェクトの [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) プロパティを使用して Slide Master にアクセスできます。