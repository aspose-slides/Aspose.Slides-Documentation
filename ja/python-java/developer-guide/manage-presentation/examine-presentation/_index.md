---
title: Python via Java でプレゼンテーション情報を取得および更新する
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/python-java/examine-presentation/
keywords:
- プレゼンテーション形式
- プレゼンテーションプロパティ
- ドキュメントプロパティ
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
- Java
- Aspose.Slides
description: "Python via Java を使用して PowerPoint および OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、より迅速な洞察とスマートなコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides はプレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを作成したり、コンテンツを読み込んで処理するかどうかを決定する前にプロパティを確認したりする場合に便利です。

例は Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。各例は JVM が起動していない場合に起動します。例で使用されているパスに既存のプレゼンテーション ファイルを配置してください。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/) と [PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) を使用した軽量検査、および [DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) を使用したターゲット更新を示します。

## **プレゼンテーション形式の確認**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査できます。[PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#getLoadFormat) メソッドは、PPTX、PPT、ODP など検出された形式を返します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **軽量プレゼンテーション インベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、またはドキュメント管理システム向けにコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して [PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) オブジェクトを取得し、続いて [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出してドキュメント メタデータを読み取ります。この方法では [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せず、完全なプレゼンテーション オブジェクト モデルを走査する必要もありません。

[DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) が提供する拡張プロパティは、次のインベントリ値を取得できます。

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getSlides) | スライドの総数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getHiddenSlides) | 非表示スライドの数。 |
| [getNotes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getNotes) | ノートを含むスライドの数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getParagraphs) | 利用可能な場合の段落の総数。 |
| [getWords](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getWords) | 単語の総数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getMultimediaClips) | オーディオとビデオクリップの総数。 |

次の例は、これらの値を [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトを作成せずに取得し、コンパクトなインベントリとして出力します。また、[getHeadingPairs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getHeadingPairs) と [getTitlesOfParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getTitlesOfParts) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
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

各 [HeadingPair](https://reference.aspose.com/slides/ja/python-java/aspose.slides/headingpair/) はグループ名とそのグループ内アイテム数を提供します。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getTitlesOfParts) は平坦で順序付けされた配列を返すため、各ヘッディング ペアで指定された連続タイトル数だけを取得して使用します。

### **保存されたメタデータと形式の制限**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) が返すインベントリ プロパティは、ソース ドキュメントに存在するメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードして走査し、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新しなかった場合、保存された値は古い可能性があります。

- **PPTX:** スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウントに加え、ヘッディング ペアとパート タイトルの拡張ドキュメント プロパティが提供されます。利用可否はドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを格納できます。プロパティが存在しない、または作成者が更新していない場合、Aspose.Slides はスライドから計算するのではなく、保存された値またはデフォルト値を返します。
- **ODP:** OpenDocument のメタデータはページ、段落、単語数といった一般的な統計情報を提供しますが、これらは PowerPoint 固有の拡張プロパティすべてに対応しているわけではありません。非表示スライド、ノートスライド、マルチメディア、ヘッディング ペア、パート タイトルのメタデータは利用できないことがあり、インベントリ プロパティはデフォルト値を返す場合があります。ゼロ値や空配列が存在するからといって、対応するコンテンツが実際に存在しないという決定的な証拠とはみなさないでください。

軽量メタデータ アプローチはインベントリ作成や事前チェックに使用し、結果がメモリ上の変更を反映する必要がある場合や、実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーション プロパティの更新**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せずに変更できます。[PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) で変更を適用し、続いて [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) でバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![Original document properties of the PowerPoint presentation](input_properties.png)

次の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

以下の画像は更新されたドキュメント プロパティを示しています。

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **便利なリンク**

関連するセキュリティ チェックと保護設定については、次の記事をご参照ください。

- [Password-Protect Presentations](/slides/ja/python-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ja/python-java/write-protected-presentation/)

## **FAQ**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認するにはどうすればよいですか？**

プレゼンテーションをロードし、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getFontsManager) を使用します。[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) で埋め込みフォントを取得し、[FontsManager.getFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFonts) でプレゼンテーションで使用されているフォントを取得します。両者を比較して、レンダリングに必要だが埋め込まれていないフォントを特定してください。

**ファイルに非表示スライドが含まれているか、またその数をすばやく確認する方法はありますか？**

保存されたドキュメント メタデータが十分であれば、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) と [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を通じて [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getHiddenSlides) を読み取ります。これは軽量インベントリに適しています。プレゼンテーションがメモリ上で変更されている場合や、保存されたメタデータが欠落または古い可能性がある場合は、[Presentation.getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) を走査し、各スライドの [Slide.getHidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getHidden) メソッドで確認してください。

**カスタムスライド サイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlideSize) を呼び出します。[SlideSize.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#getType)、[SlideSize.getSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#getSize)、[SlideSize.getOrientation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#getOrientation) を使用して現在の設定を期待されるプリセットや寸法と比較してください。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法はありますか？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) を探し、[ChartData.getDataSourceType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getDataSourceType) を呼び出します。外部ブックの場合は、[ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を呼び出してください。データ ソースの種類とパスが外部参照を示しますが、対象が利用可能かどうかは別途リソース チェックが必要です。

**レンダリングや PDF エクスポートを遅くする「重い」スライドを評価するにはどうすればよいですか？**

単一の複雑度プロパティは存在しません。[Presentation.getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) と各スライドの [BaseSlide.getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getShapes) コレクションを走査します。形状数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング指標として使用し、代表的なレンダリングまたはエクスポートでパフォーマンスを測定してから、スライドを確実なボトルネックとして扱うようにしてください。