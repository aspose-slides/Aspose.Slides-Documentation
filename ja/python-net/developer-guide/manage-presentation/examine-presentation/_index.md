---
title: Python でプレゼンテーション情報の取得と更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/python-net/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーション プロパティ
- ドキュメント プロパティ
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
description: "Python を使用して PowerPoint および OpenDocument プレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察と賢明なコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、プレゼンテーションのコンテンツをロードして処理するかどうかを決定する前にプロパティを検査したりする際に便利です。

この記事では、PresentationFactory と PresentationInfo を使用した軽量な検査、および DocumentProperties を使用した対象を絞った更新方法を示します。

## **プレゼンテーション形式の確認**

既にプレゼンテーションをロードしている場合は、ロード後の検出とレガシー PPT、PPS、POT ストリームの制限については[元のプレゼンテーション形式の判定](/slides/ja/python-net/detect-presentation-source-format/) を参照してください。

PresentationFactory.get_presentation_info を使用して、Presentation インスタンスを作成せずにファイルを検査できます。PresentationInfo.load_format プロパティは、PPTX、PPT、ODP など検出された形式を報告します。

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **軽量プレゼンテーションインベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム用のコンパクトなインベントリが必要になることがあります。このシナリオでは、PresentationFactory.get_presentation_info を使用して PresentationInfo オブジェクトを取得し、続いて PresentationInfo.read_document_properties を呼び出してドキュメント メタデータを読み取ります。この方法では Presentation インスタンスを作成せず、完全なプレゼンテーション オブジェクト モデルを走査する必要もありません。

DocumentProperties が提供する拡張プロパティは、以下のインベントリ値を提供します:

| プロパティ | インベントリ値 |
| --- | --- |
| [slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/slides/ja/) | スライドの総数。 |
| [hidden_slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/hidden_slides/) | 非表示スライドの数。 |
| [notes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/notes/) | ノートが含まれるスライドの数。 |
| [paragraphs](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/paragraphs/) | 利用可能な場合の段落の総数。 |
| [words](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/words/) | 単語の総数。 |
| [multimedia_clips](https://reference.aspose.com/slides/ja/python-net/aspose.slides/documentproperties/multimedia_clips/) | 音声とビデオのクリップの総数。 |

以下の例は、Presentation オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、heading_pairs と titles_of_parts を組み合わせて、フォント、テーマ、スライドタイトルなどのコンテンツ グループを表示します。

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

各 HeadingPair はグループ名とそのグループ内の項目数を提供します。DocumentProperties.titles_of_parts は平坦で順序付けされたコレクションであるため、各 HeadingPair が指定する連続したタイトル数だけ取得します。

### **保存されたメタデータと形式の制限**

PresentationInfo.read_document_properties が返すインベントリ プロパティは、ソース ドキュメントで利用可能なメタデータを反映しています。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードして走査し、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していない場合、保存された値は古くなる可能性があります。

- **PPTX:** 形式はスライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、および heading pair と part title 用の拡張ドキュメント プロパティを提供します。利用可能性は、ドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを保存できます。プロパティが存在しない、またはドキュメント作成者によって更新されていない場合、Aspose.Slides はスライドから計算するのではなく、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument のメタデータはページ、段落、単語のカウントなど一般的なドキュメント統計情報を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティにマッピングされません。非表示スライド、ノートスライド、マルチメディア、heading pair、part title のメタデータは利用できない場合があり、インベントリ プロパティはデフォルト値を返すことがあります。ゼロ値または空のコレクションを、対応するコンテンツが存在しないことの決定的な証拠として扱わないでください。

インベントリや事前チェックには軽量メタデータ アプローチを使用してください。結果がメモリ内の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査します。

## **プレゼンテーション プロパティの更新**

PresentationInfo.read_document_properties が返すプロパティは、Presentation インスタンスを作成せずに変更することもできます。変更は PresentationInfo.update_document_properties で適用し、その後 PresentationInfo.write_binded_presentation でバインドされたプレゼンテーションを書き込みます。

以下の画像は元のドキュメント プロパティを示しています。

![Original document properties of the PowerPoint presentation](input_properties.png)

以下の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き込みます。

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

以下の画像は更新されたドキュメント プロパティを示しています。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **便利なリンク**

関連するセキュリティチェックや保護設定については、以下の記事をご覧ください:

- [プレゼンテーションのパスワード保護](/slides/ja/python-net/password-protected-presentation/)
- [プレゼンテーションの書き込み保護](/slides/ja/python-net/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、Presentation.fonts_manager を使用します。FontsManager.get_embedded_fonts を呼び出して埋め込まれたフォントを取得し、FontsManager.get_fonts を呼び出してプレゼンテーションで使用されているフォントを取得します。両者の結果を比較して、レンダリングに必要だが埋め込まれていないフォントを見つけます。

**ファイルに非表示スライドがあるかどうか、そしてその数をすばやく確認する方法はありますか？**

保存されたドキュメント メタデータが十分である場合は、PresentationFactory.get_presentation_info と PresentationInfo.read_document_properties を介して DocumentProperties.hidden_slides を読み取ります。これは軽量インベントリに適しています。プレゼンテーションがメモリ上で変更されている場合、保存されたメタデータが不足または古くなる可能性がある、またはライブ値を検証する必要がある場合は、Presentation.slides を反復し、各スライドの Slide.hidden プロパティを確認してください。

**カスタム スライド サイズや向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、Presentation.slide_size を読み取ります。SlideSize.type、SlideSize.size、SlideSize.orientation を調べて、現在の設定が期待されるプリセットや寸法と一致しているか比較します。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。各 Chart を見つけ、ChartData.data_source_type を確認します。外部ワークブックの場合は ChartData.external_workbook_path を読み取ります。データ ソースの種類とパスで外部参照かどうかが判別できますが、対象が利用可能かどうかの確認は別途リソースチェックが必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価するにはどうすればよいですか？**

単一の複雑度プロパティは存在しません。Presentation.slides と各スライドの BaseSlide.shapes コレクションを走査します。シェイプの数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング指標として使用し、スライドを確実なパフォーマンス ボトルネックとみなす前に、代表的なレンダリングまたはエクスポートを測定してください。