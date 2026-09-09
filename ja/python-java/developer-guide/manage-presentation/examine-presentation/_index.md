---
title: Python（Java 経由）でプレゼンテーション情報を取得および更新
linktitle: プレゼンテーション情報
type: docs
weight: 30
url: /ja/python-java/examine-presentation/
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
- Java
- Aspose.Slides
description: "Python（Java 経由）を使用して PowerPoint と OpenDocument のプレゼンテーションのスライド、構造、メタデータを調査し、迅速な洞察とスマートなコンテンツ監査を実現します。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの形式を識別し、完全なプレゼンテーション オブジェクト モデルを作成せずにドキュメント メタデータを読み取ることができます。これは、ファイルを分類したり、インベントリを構築したり、プレゼンテーションの内容を読み込んで処理するかどうかを判断する前にプロパティを検査したりする場合に便利です。

この例では、Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。各例は、JVM が起動していない場合に起動します。例で使用されているパスに既存のプレゼンテーション ファイルを配置してください。

この記事では、[PresentationFactory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/) と [PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) を使用した軽量な検査、および [DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) を使用したターゲット更新を示します。

## **プレゼンテーション形式の確認**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査します。 [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#getLoadFormat) メソッドは、PPTX、PPT、ODP など検出された形式を報告します。

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

## **軽量プレゼンテーションインベントリの構築**

多数のプレゼンテーション ファイルを処理する場合、検証、インデックス作成、または文書管理システム用のコンパクトなインベントリが必要になることがあります。このシナリオでは、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して [PresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/) オブジェクトを取得し、次に [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出してドキュメント メタデータを読み取ります。このアプローチは、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成したり、完全なプレゼンテーション オブジェクト モデルを走査したりする必要がありません。

[DocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/) が提供する拡張プロパティは、次のインベントリ値を返します。

| メソッド | インベントリ値 |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getSlides) | スライドの総数。 |
| [getHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getHiddenSlides) | 非表示スライドの数。 |
| [getNotes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getNotes) | ノートが含まれるスライドの数。 |
| [getParagraphs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getParagraphs) | 利用可能な場合の段落の総数。 |
| [getWords](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getWords) | 単語の総数。 |
| [getMultimediaClips](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getMultimediaClips) | 音声およびビデオクリップの総数。 |

以下の例は、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) オブジェクトを作成せずにこれらの値を読み取り、コンパクトなインベントリを出力します。また、[getHeadingPairs](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getHeadingPairs) と [getTitlesOfParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getTitlesOfParts) を組み合わせて、フォント、テーマ、スライド タイトルなどのコンテンツ グループを表示します。

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

各 [HeadingPair](https://reference.aspose.com/slides/ja/python-java/aspose.slides/headingpair/) はグループ名とそのグループ内の項目数を提供します。[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getTitlesOfParts) はフラットで順序付けられた配列を返すため、各ヘディング ペアで指定された連続したタイトル数だけを消費します。

### **保存されたメタデータと形式の制限**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) が返すインベントリ プロパティは、ソース ドキュメントに存在するメタデータを反映します。Aspose.Slides はこの呼び出しのためにプレゼンテーション オブジェクト モデルをロードして走査し、これらの値を再計算しません。欠落しているプロパティはデフォルト値で表され、最後にファイルを保存したアプリケーションがドキュメント プロパティを更新していない場合、格納された値は古くなる可能性があります。

- **PPTX:** スライド、ノート、非表示スライド、段落、単語、マルチメディアのカウント、およびヘディング ペアとパート タイトルの拡張ドキュメント プロパティが提供されます。利用可能性は、ドキュメント作成者が書き込んだプロパティに依存します。
- **PPT:** バイナリ形式は対応するドキュメント要約プロパティを格納できます。プロパティが存在しない、または作成者によって更新されていない場合、Aspose.Slides はスライドから計算せずに格納された値またはデフォルト値を返します。
- **ODP:** OpenDocument メタデータはページ、段落、単語数などの一般的な統計情報を提供しますが、これらの値はすべての PowerPoint 固有の拡張プロパティに対応しているわけではありません。非表示スライド、ノートスライド、マルチメディア、ヘディング ペア、パート タイトルのメタデータが利用できないことがあり、インベントリ プロパティはデフォルト値を返す可能性があります。ゼロ値や空配列を、対応するコンテンツが存在しないことの権威ある証拠として扱わないでください。

軽量メタデータ アプローチはインベントリ作成や事前チェックに使用し、結果がメモリ内の変更を反映する必要がある場合や実際のプレゼンテーション コンテンツを検証する必要がある場合は、プレゼンテーションをロードしてライブ オブジェクト モデルを検査してください。

## **プレゼンテーションプロパティの更新**

[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) が返すプロパティは、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを作成せずに変更することもできます。変更は [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) で適用し、[PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) でバインドされたプレゼンテーションを書き出します。

以下の画像は元のドキュメント プロパティを示しています。

![PowerPoint プレゼンテーションの元のドキュメント プロパティ](input_properties.png)

以下の例はタイトルと最終保存時刻を変更し、結果を新しいファイルに書き出します。

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

![PowerPoint プレゼンテーションの変更後のドキュメント プロパティ](output_properties.png)

## **便利なリンク**

関連するセキュリティ チェックや保護設定については、以下の記事をご参照ください。

- [パスワードで保護されたプレゼンテーション](/slides/ja/python-java/password-protected-presentation/)
- [書き込み保護されたプレゼンテーション](/slides/ja/python-java/write-protected-presentation/)

## **よくある質問**

**フォントが埋め込まれているか、どのフォントが埋め込まれているかを確認する方法は？**

プレゼンテーションをロードし、[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getFontsManager) を使用します。[FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) で埋め込みフォントを取得し、[FontsManager.getFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFonts) でプレゼンテーションで使用されているフォントを取得します。両方の結果を比較して、描画に必要だが埋め込まれていないフォントを特定します。

**ファイルに非表示スライドがあるかどうか、またその数をすばやく確認する方法は？**

保存されたドキュメント メタデータが十分であれば、[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationfactory/#getPresentationInfo) と [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationinfo/#readDocumentProperties) を通じて [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/documentproperties/#getHiddenSlides) を読み取ります。これは軽量インベントリに適しています。プレゼンテーションがメモリ上で変更されている場合、保存されたメタデータが欠落または古くなる可能性があるため、[Presentation.getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) を走査し、各スライドの [Slide.getHidden](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slide/#getHidden) メソッドで確認してください。

**カスタム スライド サイズと向きが使用されているか、デフォルトと異なるかを検出できますか？**

はい。プレゼンテーションをロードし、[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlideSize) を呼び出します。[SlideSize.getType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#getType)、[SlideSize.getSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#getSize)、[SlideSize.getOrientation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#getOrientation) を使用して現在の設定を期待されるプリセットや寸法と比較します。

**チャートが外部データ ソースを参照しているかどうかをすばやく確認する方法は？**

はい。各 [Chart](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chart/) を見つけ、[ChartData.getDataSourceType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getDataSourceType) を呼び出します。外部ブックの場合は、[ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) を呼び出します。データ ソースのタイプとパスが外部参照を示しますが、対象が利用可能かどうかは別途リソース確認が必要です。

**レンダリングや PDF エクスポートを遅くする可能性のある「重い」スライドを評価する方法は？**

単一の複雑度プロパティは存在しません。[Presentation.getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) と各スライドの [BaseSlide.getShapes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/baseslide/#getShapes) コレクションを走査します。シェイプ数や大きな画像、エフェクト、アニメーション、マルチメディアの有無をスクリーニング シグナルとして使用し、代表的なレンダリングまたはエクスポートを計測してスライドを実際のパフォーマンス ボトルネックとして確定してください。