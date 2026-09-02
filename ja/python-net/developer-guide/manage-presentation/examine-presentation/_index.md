---
title: Python でプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/python-net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- 文書プロパティ
- プロパティ取得
- プロパティ読み取り
- プロパティ変更
- プロパティ修正
- プロパティ更新
- PPTX の検査
- PPT の検査
- ODP の検査
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Python を使用して PowerPoint と OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察とスマートなコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずに文書メタデータを読み取ることができます。これにより、ファイルを分類したり、インベントリを作成したり、プレゼンテーションのコンテンツをロードして処理するかどうかを判断する前にプロパティを検査したりする際に便利です。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/) と [PresentationInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/) を使用した軽量検査と、[DocumentProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/) を使用したターゲットを絞った更新について示します。

## **プレゼンテーション形式の確認**

ファイルを検査する際に、[Presentation] インスタンスを作成せずに、[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用します。[PresentationInfo.load_format](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/load_format/) プロパティは、PPTX、PPT、ODP など検出された形式を報告します。

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **軽量プレゼンテーション インベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証やインデックス作成、文書管理システムのためにコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) を使用して [PresentationInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/) オブジェクトを取得し、次に [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/read_document_properties/) を呼び出して文書メタデータを読み取ります。このアプローチでは、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを作成したり、完全なプレゼンテーション オブジェクト モデルを走査したりする必要はありません。

[DocumentProperties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/) が公開する拡張プロパティは、以下のインベントリ値を提供します。

| プロパティ | インベントリ値 |
| --- | --- |
| [slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/slides/ja/) | スライドの総数。 |
| [hidden_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/hidden_slides/) | 非表示スライドの数。 |
| [notes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/notes/) | ノートを含むスライドの数。 |
| [paragraphs](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/paragraphs/) | 利用可能な場合の段落総数。 |
| [words](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/words/) | 単語総数。 |
| [multimedia_clips](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/multimedia_clips/) | オーディオおよびビデオクリップの総数。 |

以下の例は、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、[heading_pairs](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/heading_pairs/) と [titles_of_parts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/titles_of_parts/) を組み合わせて、フォント、テーマ、スライドタイトルなどのコンテンツ グループを表示します。

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
            if part_index >= len(titles_of_parts):
                break

            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

各 [HeadingPair](https://reference.aspose.com/slides/ja/python-net/aspose.slides/headingpair/) はグループ名とそのグループ内の項目数を提供します。[DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/titles_of_parts/) は一次元の順序付けされたコレクションであるため、各 heading pair が指定する連続したタイトルの数だけ取得します。

### **格納されたメタデータとフォーマットの制限**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/read_document_properties/) が返すインベントリ プロパティは、ソース文書に存在するメタデータを反映しています。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードおよび走査してこれらの値を再計算しません。欠落しているプロパティは既定値で表され、最後にファイルを保存したアプリケーションが文書プロパティを更新していない場合、格納された値は古くなっている可能性があります。

- **PPTX:** この形式は、スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、および heading pairs と part titles の拡張文書プロパティを提供します。利用可能性は文書作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応する文書サマリー プロパティを格納できます。プロパティが存在しない、または文書作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、格納された値または既定値を返します。
- **ODP:** OpenDocument のメタデータは、ページ、段落、単語数などの一般的な文書統計を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティに対応しているわけではありません。非表示スライド、ノートスライド、マルチメディア、heading‑pair、part‑title のメタデータは利用できない場合があり、インベントリ プロパティは既定値を返すことがあります。ゼロ値や空のコレクションを、対応するコンテンツが存在しない決定的な証拠として扱わないでください。

インベントリや事前チェックには軽量メタデータ アプローチを使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーション プロパティの更新**

[PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/read_document_properties/) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスを作成せずに変更することもできます。[PresentationInfo.update_document_properties] で変更を適用し、次に [PresentationInfo.write_binded_presentation] を使用してバインドされたプレゼンテーションを書き込みます。

以下の画像は、元の文書プロパティを示しています。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下の例は、タイトルと最終保存時刻を変更し、結果を新しいファイルに書き込みます。

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

以下の画像は、更新された文書プロパティを示しています。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックや保護設定については、以下の記事をご覧ください。

- [パスワードで保護されたプレゼンテーション](/slides/ja/python-net/password-protected-presentation/)
- [書き込み保護されたプレゼンテーション](/slides/ja/python-net/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation.fonts_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/fonts_manager/) を使用します。[FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) を呼び出して埋め込まれたフォントを取得し、[FontsManager.get_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_fonts/) でプレゼンテーションで使用されているフォントを取得します。これら二つの結果を比較して、レンダリングに必要だが埋め込まれていないフォントを見つけます。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく確認するには？**

保存された文書メタデータが十分であれば、[PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationfactory/get_presentation_info/) と [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentationinfo/read_document_properties/) を介して [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/hidden_slides/) を読み取ります。これは軽量インベントリに適しています。メモリ上でプレゼンテーションが変更されている場合、保存されたメタデータが欠落または古くなっている可能性がある、あるいはライブ値を検証する必要がある場合は、[Presentation.slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slides/ja/) を走査し、各スライドの [Slide.hidden](https://reference.aspose.com/slides/ja/python-net/aspose.slides/slide/hidden/) プロパティを確認してください。

**カスタムスライドサイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.slide_size](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slide_size/) を読み取ります。[SlideSize.type]、[SlideSize.size]、[SlideSize.orientation] を確認して、現在の設定が期待されるプリセットや寸法と一致しているか比較します。

**チャートが外部データ ソースを参照しているかどうか、すぐに確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chart/) を見つけ、[ChartData.data_source_type](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/data_source_type/) を確認します。外部のワークブックの場合は、[ChartData.external_workbook_path](https://reference.aspose.com/slides/ja/python-net/aspose.slides.charts/chartdata/external_workbook_path/) を読み取ります。データ ソースの種類とパスが外部参照であることを示しますが、対象が利用可能かどうかを確認するには別途リソースチェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

単一の複雑度プロパティは存在しません。[Presentation.slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slides/ja/) と各スライドの [BaseSlide.shapes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/baseslide/shapes/) コレクションを走査します。シェイプ数や大きな画像、エフェクト、アニメーション、マルチメディアの有無を指標として使用し、スライドを確実なパフォーマンスボトルネックとみなす前に、代表的なレンダリングまたはエクスポートを測定してください。