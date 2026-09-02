---
title: Python でプレゼンテーションを効率的にマージする
linktitle: プレゼンテーションのマージ
type: docs
weight: 40
url: /ja/python-net/merge-presentation/
keywords:
- PowerPoint をマージ
- プレゼンテーションをマージ
- スライドをマージ
- PPT をマージ
- PPTX をマージ
- ODP をマージ
- PowerPoint を結合
- プレゼンテーションを結合
- スライドを結合
- PPT を結合
- PPTX を結合
- ODP を結合
- Python
- Aspose.Slides
description: "Python でスライドをクローンし、マスターとレイアウトを制御し、スライドコンテンツのサイズ変更やセクションの保持、保護されたファイルや大容量ファイルの取り扱いなどを行いながら、PowerPoint および OpenDocument プレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、スライドをクローンしてあるプレゼンテーションから別のプレゼンテーションへマージします。主な操作は[SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/)で、元のスライドの書式設定を保持したり、クローンしたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付したりできます。

この項目では、最も一般的なマージ ワークフローを取り上げます。

- すべてのスライドを元の書式を保持したままマージする
- 選択したスライドだけをマージする
- 宛先プレゼンテーションのマスターを適用する
- 宛先プレゼンテーションの特定のレイアウトを適用する
- マージ前に異なるスライドサイズを正規化する
- クローンしたスライドをセクションに追加する
- 複数のプレゼンテーションをエンドツーエンドのワークフローでマージする
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、巨大ファイル、マルチスレッドに関する問題を処理する

## **スライド クローンがマスターとレイアウトに与える影響**

スライドはレイアウトとマスターから多くの外観を継承します。そのため、選択するクローンのオーバーロードにより、マージされたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

[SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) を以下のいずれかの方法で使用します。

- `add_clone(source_slide)` — 元のスライドのレイアウトと書式設定を保持します。必要に応じて、元のマスターが自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動的にクローンされたマスターを追跡し、同じ元マスターを使用するスライドが繰り返しクローンされてもマスターが重複してクローンされないようにします。
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — クローンしたスライドを特定の宛先[IMasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterslide/) に添付します。Aspose.Slides はそのマスター下でレイアウトの種類または名前で一致するレイアウトを検索します。
- `add_clone(source_slide, destination_layout)` — クローンしたスライドを特定の宛先[ILayoutSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilayoutslide/) に直接添付します。

`add_clone` のオーバーロードに渡すマスターまたはレイアウトは、**宛先** プレゼンテーションに属している必要があり、元のプレゼンテーションには属していてはいけません。

## **プレゼンテーション全体をマージし、元の書式を保持する**

最も簡単なマージは、元のプレゼンテーションからすべてのスライドを宛先プレゼンテーションにコピーすることです。これは、インポートされたスライドが元のテーマ、マスター、レイアウトの関係を維持すべき場合に適した選択肢です。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

元と宛先でデザインが異なる場合、結果のプレゼンテーションには複数のマスターが含まれることがあります。これは、元の書式が意図的に保持されているため、期待通りの動作です。

## **選択したスライドをマージする**

すべてのスライドをクローンする必要はありません。次の例は、元のプレゼンテーションから選択したスライドインデックスだけをインポートします。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

ユーザー入力や外部設定から取得したスライドインデックスは、クローンする前に検証してください。

## **宛先マスターを使用してスライドをマージする**

インポートしたスライドがすでに宛先プレゼンテーションに存在するマスターに従うべき場合は、[add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) オーバーロードを使用します。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides は、指定されたマスター下で元レイアウトの種類または名前に一致する適切なレイアウトを選択します。一致するレイアウトが存在せず、`allow_clone_missing_layout` が `True` の場合、元レイアウトがクローンされてスライドを追加できるようにします。`False` の場合は、[PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) がスローされます。

追加のレイアウトを宛先マスターに導入したくない場合は、マージが失敗するように `False` を使用してください。

## **特定の宛先レイアウトを使用してスライドをマージする**

インポートしたスライドが使用すべき宛先レイアウトが正確に分かっている場合は、[add_clone(source_slide, destination_layout)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) オーバーロードを使用します。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_layout = destination.layout_slides[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_layout)

        destination.save("merged-with-destination-layout.pptx", slides.export.SaveFormat.PPTX)
```

宛先レイアウトを適用すると、継承されるレイアウトの関係が変更されますが、元スライドのコンテンツ自体が再設計されるわけではありません。元と宛先のレイアウトでプレースホルダーの構造が異なる場合は、継承された書式とプレースホルダーの動作が適切かどうか、結果を確認してください。

## **異なるスライドサイズのプレゼンテーションをマージする**

スライドサイズが異なるプレゼンテーションでもマージは可能ですが、別サイズのプレゼンテーションにスライドをクローンしただけでは、コンテンツが新しいキャンバスに合わせて自動的に再設計されません。そのため、形状がずれたり、スケールが予期せず変わったり、スライド領域外に出てしまうことがあります。

実用的なアプローチは、クローンする前に元プレゼンテーションのサイズを変更することです。[SlideSize.set_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesize/set_size/) メソッドは、スライドサイズを変更しながら既存のコンテンツをスケーリングできます。[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesizescaletype/) は、要求されたサイズに合わせてコンテンツを収めるようスケールします。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        if (
            source.slide_size.size.width != destination.slide_size.size.width
            or source.slide_size.size.height != destination.slide_size.size.height
        ):
            source.slide_size.set_size(
                destination.slide_size.size.width,
                destination.slide_size.size.height,
                slides.SlideSizeScaleType.ENSURE_FIT)

        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged-same-slide-size.pptx", slides.export.SaveFormat.PPTX)
```

サイズ変更はメモリ内の元プレゼンテーションオブジェクトを変更します。元プレゼンテーションを他の操作でそのまま残しておく必要がある場合は、マージ用に別インスタンスを開いてください。

## **スライドをプレゼンテーションのセクションにマージする**

基本的なスライド クローン ループは、元プレゼンテーションのセクション階層を再現しません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) を使用してスライドを明示的にそのセクションにクローンします。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

クローンされたスライドは指定された宛先セクションに追加されます。複数の元セクションを保持したい場合は、[Presentation.sections](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/sections/) を列挙し、各元セクションの現在のスライドを[Section.get_slides_list_of_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/section/get_slides_list_of_section/)で取得し、宛先でセクションを再作成し、返された各スライドを対応する宛先セクションにクローンしてください。[Manage Slide Sections](/slides/ja/python-net/slide-section/) には、空セクションや構造変更を含む完全なセクション列挙例が掲載されています。

## **複数のプレゼンテーションを安全にマージする**

以下のエンドツーエンド例では、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライドサイズを正規化し、コピー中のみ各ソースを開いたままにし、最後にファイルを保存します。

```python
import aspose.slides as slides

input_files = ["part1.pptx", "part2.pptx", "part3.pptx"]

with slides.Presentation(input_files[0]) as merged:
    for file_index in range(1, len(input_files)):
        with slides.Presentation(input_files[file_index]) as source:
            if (
                source.slide_size.size.width != merged.slide_size.size.width
                or source.slide_size.size.height != merged.slide_size.size.height
            ):
                source.slide_size.set_size(
                    merged.slide_size.size.width,
                    merged.slide_size.size.height,
                    slides.SlideSizeScaleType.ENSURE_FIT)

            for slide in source.slides:
                merged.slides.add_clone(slide)

    merged.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

これは、インポートされたスライドの元書式を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、シンプルな `add_clone(slide)` 呼び出しを、前述の宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実践的な考慮事項**

### **マスター、レイアウト、および書式忠実度**

デフォルトのスライド クローンは、必要な元マスターを自動的に宛先プレゼンテーションに持ち込みます。Aspose.Slides は自動クローンされたマスターを内部レジストリで管理し、同じマスターの重複クローンを防ぎます。手動でクローンしたマスターはこのレジストリで追跡されないため、マスター構造を明示的に制御する必要がない限り、事前にマスターをクローンしないでください。

同じ名前のマスターやレイアウトが視覚的に同等であると推測しないでください。企業テンプレートで最終的な外観を制御する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライドコンテンツに紐付いており、スライドをクローンするとコピーされます。Aspose.Slides は[プレゼンテーション ノート](/slides/ja/python-net/presentation-notes/) および[プレゼンテーション コメント](/slides/ja/python-net/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式が重要な場合、ノートマスターはプレゼンテーションレベルのオブジェクトであり、ソースファイル間で異なることがあるため、マージされたプレゼンテーションを確認してください。レビュー ワークフローでは、異なる著者やテンプレートからのファイルを結合した後に、コメントの作者やスレッド コメントも検証してください。

### **画像、音声、動画、OLE オブジェクト、外部リンク**

スライドは画像、埋め込み音声、埋め込み動画、OLE データなど、プレゼンテーションレベルのリソースを参照できます。スライド自体をクローンし、可視形状だけをコピーしないことで、Aspose.Slides がリソースとの関係を保持できます。

埋め込みリソースとリンクリソースは別々に扱う必要があります。リンクされた音声、動画、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されることはありません。マージされたプレゼンテーションが開かれる環境で、リンクリソースのパスや URL をテストしてください。

Aspose.Slides は自動クローンされたマスターを明示的に追跡しますが、これは無関係なソースプレゼンテーション間で同一バイナリリソースが常に重複除去されるという一般的な保証ではありません。出力ファイルサイズが重要な場合は、マージされたパッケージを検査し、結果を測定して暗黙の重複除去に依存しないでください。

### **埋め込みフォントとフォントの利用可能性**

フォントはプレゼンテーションレベルで管理されます。タイポグラフィをマシン間で一貫させる必要がある場合、スライドをクローンするだけでは目的のフォントが宛先環境に存在することは保証されません。[FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) で埋め込みフォントを確認し、[プレゼンテーションへのフォント埋め込み](/slides/ja/python-net/embedded-font/) に記載の方法で明示的に管理してください。

また、ソースファイルで使用されているフォントを埋め込む権限があるか確認してください。フォントライセンスにより埋め込みが制限されることがあります。

### **パスワードで保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正常に開く必要があります。[LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) でパスワードを指定してください。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて、出力の保護を別途設定してください。

### **大規模プレゼンテーションとメモリ使用量**

高解像度画像、音声、動画、その他の大容量バイナリオブジェクトを含む大規模プレゼンテーションは、かなりのメモリを消費する可能性があります。[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/blob_management_options/) は BLOB の取り扱いと一時ファイル使用を制御するオプションを提供します。大容量ファイルの戦略については[プレゼンテーション BLOB の管理](/slides/ja/python-net/manage-blob/) を参照してください。

大容量ファイルの場合は、可能な限りファイルパスから読み込み、各ソースプレゼンテーションをマージが完了したらすぐに閉じ、チェックポイントが必要でない限り中間結果を繰り返し保存しないでください。`with slides.Presentation(...)` を使用すると、コンテキスト終了時にプレゼンテーションリソースが解放されます。

### **スレッド安全性**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを複数スレッドから同時にロード、保存、またはクローンしないでください。各マージ操作はシングルスレッドで実行してください。独立したマージジョブを並列化する場合は、別々のシングルスレッドプロセスと独立したプレゼンテーションインスタンスを使用し、[Aspose.Slides のマルチスレッドガイダンス](/slides/ja/python-net/multithreading/) に従ってください。

## **FAQ**

**各ソースプレゼンテーションの元デザインを保持するにはどうすればよいですか？**

宛先マスターやレイアウトを指定せずに[add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) を使用します。インポートされたスライドに必要な場合、Aspose.Slides が元マスターを自動的にクローンします。

**インポートしたスライドに宛先テーマを適用するには？**

宛先マスターを受け取るオーバーロードを使用します。元ではなく宛先プレゼンテーションのマスターを渡してください。Aspose.Slides はそのマスター下で各元スライドに適切なレイアウトをマッピングしようとします。

**特定の宛先レイアウトを使用すべきタイミングは？**

すべてのインポートスライドが同一の既知レイアウトを使用すべき場合に使用します。レイアウトを指定したい場合は、元レイアウトの種類や名前に基づいてマスターのレイアウトを自動選択させたいときはマスターを使用します。

**スライドサイズが異なるプレゼンテーションはマージ可能ですか？**

はい。ただし、スライドコンテンツは宛先の寸法に自動的に再設計されません。予測可能な配置が必要な場合は、[SlideSize.set_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesize/set_size/) と[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesizescaletype/) を使用して、まず元プレゼンテーションのサイズを変更してください。

**PPT、PPTX、ODP のプレゼンテーションを 1 つのファイルにマージできますか？**

はい。各ソースプレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。プレゼンテーション形式間で機能セットが完全に一致しないため、クロスフォーマットマージ後は複雑なコンテンツを検証してください。[Supported File Formats](/slides/ja/python-net/supported-file-formats/) を参照してください。

**元セクションは自動的に保持されますか？**

基本的なスライドのみをクローンするループでは保持されません。必要なセクションを宛先に再作成し、[add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) のセクションオーバーロードを使用してセクション構造を保持してください。

**スピーカー ノートやコメントは保持されますか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリングやコメントの作者、スレッドレビュー データに依存するワークフローでは、プレゼンテーションレベルの構造とスライドレベルのコンテンツの両方を考慮して、マージ結果を検証してください。

**音声、動画、OLE オブジェクト、ハイパーリンクはどうなりますか？**

埋め込みコンテンツはクローンされたスライドのリソース関係として保持されます。外部リンクは外部のままであり、ターゲットファイルや URL がマージ後も利用可能であることを確認してください。

**すべてのソースからの埋め込みフォントはマージされたプレゼンテーションで利用可能ですか？**

スライドクローンだけではフォント展開は保証できません。目的地の埋め込みフォントを確認し、必要に応じてフォント埋め込みや外部フォントの利用を明示的に管理してください。

**パスワード保護されたファイルをマージするには？**

正しい[LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) を使用して開き、通常どおりスライドをクローンします。出力の保護は別途設定してください。

**大容量プレゼンテーションの取り扱いは？**

BLOB 管理を使用し、大容量バイナリがメモリ使用量を支配する場合に対応してください。非常に大きなファイルはファイルパスからのロードを優先し、ソースプレゼンテーションを速やかに閉じ、最終結果のみを保存してください。

**スライドを複数のスレッドでマージできますか？**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを複数スレッドで同時にロード、保存、またはクローンしないでください。各マージ操作はシングルスレッドで実行し、別々のシングルスレッドプロセスで独立したマージジョブを並列化してください。