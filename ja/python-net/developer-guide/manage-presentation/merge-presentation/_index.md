---
title: Python でプレゼンテーションを効率的にマージ
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
- PowerPoint を統合
- プレゼンテーションを統合
- スライドを統合
- PPT を統合
- PPTX を統合
- ODP を統合
- Python
- Aspose.Slides
description: "Python でスライドをクローンし、マスターやレイアウトを制御し、スライド コンテンツのサイズ変更、セクションの保持、保護されたファイルや大容量ファイルの処理を行いながら、PowerPoint および OpenDocument のプレゼンテーションをマージする方法を学びます。"
---
## **概要**

Aspose.Slides for Python via .NET は、ある [Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) から別のプレゼンテーションへスライドをクローンすることでプレゼンテーションをマージします。主な操作は [SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) で、元のスライドの書式設定を保持したり、クローンしたスライドを宛先プレゼンテーションのマスターまたはレイアウトに添付したりできます。

この記事では、最も一般的なマージ ワークフローを取り上げます。

- 元の書式設定を保持しながらすべてのスライドをマージする；
- 選択したスライドをマージする；
- 宛先プレゼンテーションのマスターを適用する；
- 宛先プレゼンテーションの特定のレイアウトを適用する；
- マージ前に異なるスライドサイズを正規化する；
- クローンしたスライドをセクションに追加する；
- 複数のプレゼンテーションを1つのエンドツーエンド ワークフローでマージする；
- マスター、リソース、ノート、コメント、メディア、フォント、パスワード、大きなファイル、マルチスレッドに関する問題を処理する。

## **スライド クローンがマスターとレイアウトに与える影響**

スライドは、その外観の多くをレイアウトとマスターから継承します。そのため、選択するクローン オーバーロードにより、マージされたスライドが宛先プレゼンテーションにどのように統合されるかが決まります。

以下のいずれかの方法で [SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) を使用します。

- `add_clone(source_slide)` — 元のスライドのレイアウトと書式設定を保持します。必要に応じて、元のマスターは自動的に宛先プレゼンテーションにクローンされます。Aspose.Slides は自動クローンされたマスターを追跡し、同じ元マスターを使用するスライドが繰り返しクローンされてもマスターが重複してクローンされないようにします。
- `add_clone(source_slide, destination_master, allow_clone_missing_layout)` — クローンしたスライドを特定の宛先 [IMasterSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imasterslide/) に添付します。Aspose.Slides は、そのマスターの下でレイアウトのタイプまたは名前で一致するレイアウトを探します。
- `add_clone(source_slide, destination_layout)` — クローンしたスライドを特定の宛先 [ILayoutSlide](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ilayoutslide/) に直接添付します。

`add_clone` オーバーロードに渡すマスターまたはレイアウトは、ソース プレゼンテーションではなく **宛先** プレゼンテーションに属している必要があります。

## **プレゼンテーション全体をマージし、元の書式設定を保持する**

最も簡単なマージは、ソース プレゼンテーションのすべてのスライドを宛先プレゼンテーションにコピーすることです。インポートしたスライドが元のテーマ、マスター、レイアウトの関係を保持すべき場合に適した選択です。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        for slide in source.slides:
            destination.slides.add_clone(slide)

        destination.save("merged.pptx", slides.export.SaveFormat.PPTX)
```

ソースと宛先が異なるデザインを使用している場合、結果として得られるプレゼンテーションには複数のマスターが含まれることがあります。これは、元の書式設定を意図的に保持している場合に期待される動作です。

## **選択したスライドをマージする**

すべてのスライドをクローンする必要はありません。以下の例は、ソース プレゼンテーションから選択したスライド インデックスのみをインポートします。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        slide_indexes = [0, 2, 4]

        for index in slide_indexes:
            destination.slides.add_clone(source.slides[index])

        destination.save("merged-selected-slides.pptx", slides.export.SaveFormat.PPTX)
```

ユーザー入力や外部設定から取得したスライド インデックスは、クローンする前に検証してください。

## **宛先マスターを使用してスライドをマージする**

インポートしたスライドが、すでに宛先プレゼンテーションに属しているマスターに従うべき場合は、[add_clone(source_slide, destination_master, allow_clone_missing_layout)](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) オーバーロードを使用します。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        destination_master = destination.masters[0]

        for slide in source.slides:
            destination.slides.add_clone(slide, destination_master, True)

        destination.save("merged-with-destination-master.pptx", slides.export.SaveFormat.PPTX)
```

Aspose.Slides は、指定されたマスターの下でソース レイアウトのタイプまたは名前と一致する適切なレイアウトを選択します。適切なレイアウトが存在しない場合で `allow_clone_missing_layout` が `True` のときは、ソース レイアウトがクローンされスライドを追加できるようになります。`False` の場合は、[PptxEditException](https://reference.aspose.com/slides/ja/python-net/aspose.slides/pptxeditexception/) がスローされます。

宛先マスターに余分なレイアウトを追加したくなく、マージを失敗させたい場合は `False` を使用してください。

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

宛先レイアウトを適用すると、継承されたレイアウトの関係が変更されますが、ソース スライドのコンテンツは再設計されません。ソースと宛先のレイアウトでプレースホルダー構造が異なる場合、継承された書式設定とプレースホルダーの動作が適切かどうか結果を確認してください。

## **異なるスライドサイズのプレゼンテーションをマージする**

スライド サイズが異なるプレゼンテーションでもマージできますが、別サイズのプレゼンテーションにスライドをクローンしただけでは、コンテンツが自動的に新しいキャンバスに合わせて再設計されません。そのため、図形が位置ずれしたり、予期せず拡大縮小されたり、表示領域外に出てしまうことがあります。

実用的なアプローチは、クローンする前にソース プレゼンテーションのサイズを変更することです。[SlideSize.set_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesize/set_size/) メソッドは、スライドの寸法を変更しながら既存のコンテンツをスケーリングできます。[SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesizescaletype/) は、要求されたサイズに収まるようにコンテンツをスケーリングします。

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

リサイズはメモリ内のソース プレゼンテーション オブジェクトを変更します。別の操作で元のソース プレゼンテーションを変更せずに使用する必要がある場合は、マージ用に別のインスタンスを開いてください。

## **スライドをプレゼンテーションのセクションにマージする**

基本的なスライド クローン ループでは、ソース プレゼンテーションのセクション階層は再現されません。出力でセクションが重要な場合は、宛先プレゼンテーションでセクションを作成または選択し、[SlideCollection.add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) を使用してスライドを明示的にそのセクションにクローンしてください。

```python
import aspose.slides as slides

with slides.Presentation("destination.pptx") as destination:
    with slides.Presentation("source.pptx") as source:
        imported_section = destination.sections.append_empty_section("Imported slides")

        for slide in source.slides:
            destination.slides.add_clone(slide, imported_section)

        destination.save("merged-with-section.pptx", slides.export.SaveFormat.PPTX)
```

クローンされたスライドは、指定された宛先セクションに追加されます。複数のソース セクションを保持したい場合は、[SectionCollection.append_empty_section](https://reference.aspose.com/slides/ja/python-net/aspose.slides/sectioncollection/append_empty_section/) で宛先にそれらのセクションを再作成し、各ソース スライドを対応する宛先セクションにマップしてください。

## **複数のプレゼンテーションを安全にマージする**

以下のエンドツーエンド例では、最初のプレゼンテーションを宛先として使用し、追加の各ソースのスライド サイズを正規化し、コピー中のみ各ソースを開いたままにし、最終的に一度だけファイルを保存します。

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

これは、インポートしたスライドの元の書式設定を保持するための有用なベースラインです。出力で単一の宛先テーマを使用する必要がある場合は、シンプルな `add_clone(slide)` 呼び出しを、前述の適切な宛先マスターまたは宛先レイアウトのオーバーロードに置き換えてください。

## **実務的な考慮事項**

### **マスター、レイアウト、および書式忠実度**

デフォルトのスライド クローンでは、必要なソース マスターを自動的に宛先プレゼンテーションに持ち込むことができます。Aspose.Slides は自動クローンされたマスターの内部レジストリを保持し、同じマスターが繰り返しクローンされるのを防ぎます。手動でクローンしたマスターはそのレジストリで追跡されないため、マスター構造を明示的に制御する必要がない限り、事前にマスターをクローンしないでください。

同名のマスターやレイアウトが視覚的に同等であると想定しないでください。企業テンプレートが最終的な外観を制御する必要がある場合は、宛先マスターまたはレイアウトを明示的に選択し、マージ後に結果を検証してください。

### **ノートとコメント**

スピーカーノートとスライドコメントはスライド コンテンツに関連付けられており、スライドがクローンされるとコピーされます。Aspose.Slides は [presentation notes](https://docs.aspose.com/slides/ja/python-net/presentation-notes/) と [presentation comments](https://docs.aspose.com/slides/ja/python-net/presentation-comments/) 用の専用 API も提供しています。

ノートページの書式設定が重要な場合は、ノートマスターがプレゼンテーション レベルのオブジェクトであり、ソース ファイル間で異なる可能性があるため、マージされたプレゼンテーションを確認してください。レビュー ワークフローでは、異なる作者やテンプレートからのファイルを結合した後、コメントの作者やスレッド化されたコメントも検証してください。

### **画像、オーディオ、ビデオ、OLE オブジェクト、外部リンク**

スライドは、画像、埋め込みオーディオ、埋め込みビデオ、OLE データなどのプレゼンテーション レベルのリソースを参照できます。可視形状だけをコピーせずにスライド自体をクローンすることで、Aspose.Slides はスライドとリソース間の関係を維持できます。

埋め込みリソースとリンクリソースは区別して取り扱う必要があります。リンクされたオーディオ、ビデオ、OLE オブジェクト、ハイパーリンクは外部ターゲットに依存したままであり、スライドをクローンしても外部リンクが埋め込みコンテンツに変換されません。マージされたプレゼンテーションが開かれる環境で、リンクリソースのパスや URL をテストしてください。

Aspose.Slides は自動クローンされたマスターを明示的に追跡しますが、これは無関係なソース プレゼンテーションからの同一バイナリ リソースが常に重複除去されるという一般的な保証とはみなさないでください。出力ファイルのサイズが重要な場合は、暗黙的な重複除去に依存せず、マージされたパッケージを検査し、結果を測定してください。

### **埋め込みフォントとフォントの利用可能性**

フォントはプレゼンテーション レベルで管理されます。タイポグラフィをマシン間で一貫させる必要がある場合、スライドのクローンだけで必ずすべての必要フォントが宛先環境で利用可能になるとは想定しないでください。[FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) で埋め込みフォントを確認でき、[Embed Fonts in Presentations](https://docs.aspose.com/slides/ja/python-net/embedded-font/) に記載されているように埋め込みを明示的に管理できます。

また、ソース ファイルで使用されているフォントを埋め込むことが許可されているか確認してください。フォント ライセンスにより埋め込みが制限される場合があります。

### **パスワード保護されたプレゼンテーション**

パスワードで保護されたソースは、スライドをクローンする前に正常に開く必要があります。パスワードは [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) で指定します。

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("protected.pptx", load_options) as source:
    print(len(source.slides))
```

暗号化されたソースを開いても、同じ保護が自動的に宛先プレゼンテーションに適用されるわけではありません。必要に応じて、出力の保護は別途設定してください。

### **大規模プレゼンテーションとメモリ使用量**

高解像度画像、オーディオ、ビデオ、その他の大きなバイナリ オブジェクトを含む大規模なプレゼンテーションは、かなりのメモリを消費する可能性があります。[LoadOptions.blob_management_options](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/blob_management_options/) は BLOB の処理と一時ファイルの使用を制御します。大きなファイルに対する戦略については、[Manage Presentation BLOBs](https://docs.aspose.com/slides/ja/python-net/manage-blob/) を参照してください。

大きなファイルの場合は、可能な限りファイル パスから読み込むことを優先し、マージが完了したらすぐに各ソース プレゼンテーションを閉じ、ワークフローでチェックポイントが必要な場合を除き、中間結果を繰り返し保存しないでください。`with slides.Presentation(...)` を使用すれば、コンテキストが終了したときにプレゼンテーション リソースが解放されます。

### **スレッド安全性**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを複数のスレッドから同時にロード、保存、クローンしないでください。各マージ操作はシングルスレッドで実行します。独立したマージ ジョブを並列化する場合は、別々のシングルスレッド プロセスと独立したプレゼンテーション インスタンスを使用してください。[Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/ja/python-net/multithreading/) に記載されています。

## **FAQ**

**各ソース プレゼンテーションの元のデザインを保持するには？**

`add_clone(source_slide)` を、宛先マスターやレイアウトを指定せずに使用します。インポートされたスライドが必要とする場合、Aspose.Slides が自動的にソース マスターをクローンできます。

**インポートしたスライドに宛先テーマを使用させるには？**

宛先マスターを受け取るオーバーロードを使用します。ソースではなく、宛先プレゼンテーションのマスターを渡してください。Aspose.Slides は各ソース スライドをそのマスターの適切なレイアウトにマッピングしようとします。

**宛先マスターではなく特定の宛先レイアウトを使用すべき場合は？**

すべてのインポートスライドが既知のレイアウトを使用すべき場合は、特定のレイアウトを使用します。ソースのレイアウトタイプや名前に基づいて Aspose.Slides にマスター内のレイアウトを選択させたい場合は、マスターを使用してください。

**異なるスライドサイズのプレゼンテーションはマージできますか？**

はい、可能ですが、スライド コンテンツは宛先の寸法に自動的に再設計されません。配置を予測可能にしたい場合は、ソース プレゼンテーションを先にリサイズしてください。例として [SlideSize.set_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesize/set_size/) と [SlideSizeScaleType.ENSURE_FIT](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidesizescaletype/) を使用します。

**PPT、PPTX、ODP のプレゼンテーションを 1 つのファイルにマージできますか？**

はい。各ソース プレゼンテーションを読み込み、必要なスライドを 1 つの宛先にクローンし、サポートされている出力形式で保存します。プレゼンテーション形式は完全に同じ機能セットをサポートしていないため、クロスフォーマットのマージ後に複雑なコンテンツを検証してください。[Supported File Formats](https://docs.aspose.com/slides/ja/python-net/supported-file-formats/) を参照してください。

**ソースのセクションは自動的に保持されますか？**

スライドだけをクローンする基本的なループでは保持されません。必要なセクションを宛先に再作成し、セクション構造を保持する必要がある場合は、[add_clone](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slidecollection/add_clone/) のセクション オーバーロードを使用してください。

**スピーカーノートとコメントは保持されますか？**

クローンされたスライドと共にコピーされます。ノートマスターのスタイリング、コメント作者、スレッド化されたレビューデータに依存するワークフローの場合、これらはプレゼンテーション レベルの構造とスライド レベルのコンテンツの両方を含むため、マージ結果を検証してください。

**オーディオ、ビデオ、OLE オブジェクト、ハイパーリンクはどうなりますか？**

埋め込みコンテンツはクローンされたスライドのリソース関係の一部として保持されます。外部リンクは外部のままであるため、マージ後もターゲット ファイルや URL が利用可能である必要があります。

**すべてのソースからの埋め込みフォントは、マージされたプレゼンテーションで利用できることが保証されていますか？**

フォント配布のためにスライドのクローンだけに依存しないでください。タイポグラフィが重要な場合は、宛先の埋め込みフォントを確認し、フォント埋め込みや外部フォントの利用可能性を明示的に管理してください。

**パスワード保護されたファイルをマージするには？**

正しい [LoadOptions.password](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/password/) で開き、通常通りスライドをクローンしてください。出力の保護は別途設定します。

**非常に大きなプレゼンテーションはどのように扱うべきですか？**

大きなバイナリ オブジェクトがメモリ使用量の大部分を占める場合は BLOB 管理を使用し、非常に大きなファイルはファイル パスからの読み込みを優先し、ソース プレゼンテーションは速やかに閉じ、最終結果は必要なときにだけ保存してください。

**複数のスレッドからスライドをマージできますか？**

[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを複数のスレッドでロード、保存、クローンしないでください。各マージ操作はシングルスレッドで行い、別々のマージ ジョブを並列化する必要がある場合は、独立したシングルスレッド プロセスを使用してください。