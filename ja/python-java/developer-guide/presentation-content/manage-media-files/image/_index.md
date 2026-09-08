---
title: Python を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/python-java/image/
keywords:
- 画像を追加
- 画像を挿入
- 画像を置き換える
- 画像コレクション
- 画像フレーム
- リンク画像
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- SVG をシェイプに変換
- 外部 SVG リソース
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションでラスタ画像と SVG 画像を追加、再利用、リンク、置き換え、管理する方法を学びます。"
---
## **導入**

Aspose.Slides for Python via Java は画像を操作するためのさまざまな方法を提供しており、目的に応じて使い分けることができます。画像をプレゼンテーションに格納したり、ピクチャーフレームで表示したり、スライドの背景として使用したり、外部画像へのリンクを設定したり、共有画像リソースを置き換えたり、SVG コンテンツを編集可能な図形に変換したりできます。

本記事では画像リソースとプレゼンテーション全体での使用方法に焦点を当てます。個々のピクチャーフレームに対して行うトリミング、透過、エフェクト、伸縮、その他の書式設定については、[Picture Frame](/slides/ja/python-java/picture-frame/) を参照してください。

## **画像モデルの理解**

以下の API 概念は密接に関連していますが、置き換え可能ではありません。

- プレゼンテーションで使用される画像リソースを保持する[プレゼンテーション画像コレクション](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/)です。画像データを追加して[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/)リソースを取得するには、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) を使用します。
- [picture frame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pictureframe/) は、スライド、レイアウト、またはマスター上に画像を表示するシェイプです。スライド上に画像リソースを配置するには、[ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addPictureFrame) を使用します。
- スライドの背景は画像をシェイプではなくスライドの塗りつぶしの一部として使用します。そのため、picture frame のように動作しません。
- [PPImage.replaceImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#replaceImage) は画像リソースを置き換えます。そのリソースを複数のプレゼンテーション要素が使用している場合、すべてが置き換え後の画像を使用します。
- SVG を図形に変換すると、編集可能なスライドシェイプが生成されます。変換後は、コンテンツは単一の画像リソースとして管理されなくなります。

典型的なワークフローは次のとおりです。画像データを画像コレクションに追加し、[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) を取得し、そのリソースを1つまたは複数のピクチャーフレームや塗りつぶしで使用します。

## **埋め込み画像の追加**

ローカル画像を挿入するには、ファイルを読み込み、画像コレクションに追加し、取得した[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) を使用するピクチャーフレームを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この方法で追加された画像はプレゼンテーションに埋め込まれるため、生成されたファイルは元の画像ファイルが利用可能であることに依存しません。

### **Web から画像を追加**

画像が HTTP または HTTPS 経由で取得できる場合、そのバイト列をダウンロードし、プレゼンテーションの画像コレクションに追加し、ローカル画像と同様に取得した画像リソースを使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from urllib.request import urlopen
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    with urlopen("https://example.com/image.png", timeout=10) as response:
        image_data = response.read()

    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

長時間実行されるアプリケーションでは、不要なネットワークインフラの作成を繰り返すのではなく、アプリケーションに適した HTTP クライアントまたは接続管理戦略を再利用してください。また、ソースが信頼できない場合は、リモート URL、レスポンスサイズ、コンテンツタイプを検証してください。

## **スライド間で画像を再利用**

同じ画像が複数回必要な場合、プレゼンテーションに一度だけ画像を追加し、追加のピクチャーフレームを作成する際に取得した[PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) を再利用します。これにより同一ソースデータの繰り返し読み込みを防ぎ、共有画像リソースとその使用箇所との関係が明示的になります。

多くのスライドで自動的に表示させたいグラフィック（例: 会社ロゴ）の場合、各スライドに同等のシェイプを追加するのではなく、[slide master](/slides/ja/python-java/slide-master/) またはレイアウト上にピクチャーフレームを配置することを検討してください。

## **画像をスライドの背景として使用**

背景画像はスライドの塗りつぶしに割り当てられ、ピクチャーフレームのシェイプとして追加されません。画像がスライド全体の背景を覆い、通常のスライドオブジェクトとして操作されるべきでない場合に便利です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, PictureFillMode, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("background.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Picture)
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image)

    presentation.save("background-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

マスターやレイアウトの背景を含むその他の背景オプションについては、[Presentation Background](/slides/ja/python-java/presentation-background/) を参照してください。

## **埋め込み画像とリンク画像**

埋め込み画像とリンク画像では、可搬性とファイルサイズに異なるトレードオフがあります。

- **埋め込み画像:** 画像データがプレゼンテーション内に保存されます。プレゼンテーションは単体で完結しますが、ファイルサイズには画像データが含まれます。
- **リンク画像:** プレゼンテーションは外部画像へのパスまたは URL を保持します。これによりプレゼンテーションのサイズは小さくなりますが、表示またはレンダリング時に外部リソースがアクセス可能である必要があります。

リンク画像は、画像データを埋め込む代わりに、[Picture.setLinkPathLong](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picture/#setLinkPathLong) を使用して外部パスまたは URL を設定することで作成できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, None)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png")

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

リンク画像は、デプロイ環境が外部リソースに確実にアクセスできる場合にのみ使用してください。オフラインでの利用やシステム間での移動が必要なプレゼンテーションでは、埋め込み画像の方が通常は安全です。

## **SVG 画像の取り扱い**

SVG はベクターフォーマットであるため、アイコンや図、ラスター画像と比べて詳細が失われにくく拡大縮小できるグラフィックに適しています。Aspose.Slides は SVG を画像リソースとして、また編集可能なスライドシェイプのソースとしてサポートします。

### **SVG を画像として追加**

[SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) を作成し、画像コレクションに追加し、結果の画像リソースをピクチャーフレームに配置します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType, SvgImage

presentation = Presentation()
try:
    svg_content = Path("icon.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    image = presentation.getImages().addImage(svg_image)
    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **外部リソースを含む SVG ファイル**

SVG は外部画像、スタイルシート、フォントを参照できる場合があります。このようなケースでは、[SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) が [ExternalResourceResolver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/externalresourceresolver/) とベース URI を受け取るコンストラクタを提供します。リゾルバーは相対 URI を許可された絶対 URI にマッピングし、要求されたリソースのストリームを返します。

リゾルバーは Aspose.Slides が SVG を処理する間、外部リソースへのアクセスを可能にしますが、SVG を自己完結型ドキュメントに書き換えることはしません。SVG を可搬性のままにしたい場合は、必要なリソースを SVG 内に埋め込む必要があります。例えば、リンク画像に対して `data:` URI を使用する方法があります。

SVG ファイルが信頼できないソースから来る場合、リゾルバーがアクセスできるスキーム、ファイル位置、ホストを制限してください。ネットワークリゾルバーはタイムアウト、レスポンスサイズの上限、コンテンツ検証も適用すべきです。

### **SVG を編集可能なシェイプに変換**

Aspose.Slides は SVG を編集可能なスライドシェイプのグループに変換でき、PowerPoint の対応コマンドと同様です。

![PowerPoint Popup Menu](img_01_01.png)

変換を実行するには、[SvgImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/svgimage/) を受け取る [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addGroupShape) のオーバーロードを使用します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, SvgImage

presentation = Presentation()
try:
    svg_content = Path("diagram.svg").read_text(encoding="utf-8")
    svg_image = SvgImage(svg_content)

    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)
    slide_width = jpype.JFloat(slide_size.getWidth())
    slide_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addGroupShape(svg_image, 0, 0, slide_width, slide_height)

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

個々のベクター要素を PowerPoint のシェイプとして編集する必要がある場合に SVG からシェイプへの変換を使用してください。SVG を単に表示するだけで良い場合は、画像として保持した方がシンプルで、多数の個別シェイプを作成する手間が省けます。

## **既存の画像リソースを置き換える**

既存の画像リソースを置き換える場合は、[PPImage.replaceImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#replaceImage) を使用します。ロゴなどの共有グラフィックに特に便利です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    image_to_replace = presentation.getImages().get_Item(0)

    replacement_image = Images.fromFile("new-logo.png")
    try:
        image_to_replace.replaceImage(replacement_image)
    finally:
        replacement_image.dispose()

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

複数のピクチャーフレーム、背景、マスター、レイアウトが同一画像リソースを使用している場合、そのリソースを置き換えるとすべての使用箇所が更新されます。1つのピクチャーフレームだけを変更したい場合は、共有リソースを置き換えるのではなく、そのフレームに別の画像を割り当ててください。

[PPImage.replaceImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#replaceImage) には、バイト配列や別の [PPImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/) を受け取るオーバーロードも用意されています。

## **実践的な画像管理ガイダンス**

### **プレゼンテーションサイズの管理**

大きなラスタ画像はプレゼンテーションを不必要に大きくします。表示サイズに見合った寸法のソース画像を使用し、可能な限り共有画像リソースを再利用し、同一のフル解像度グラフィックの重複埋め込みは避けてください。

すでにピクチャーフレームに配置されたラスタ画像については、[PictureFillFormat.compressImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/picturefillformat/#compressImage) を使用して、選択した解像度やトリミング設定に基づき画像データを圧縮できます。これは画像コレクションの管理ではなくピクチャーフレームの処理ですので、関連する書式設定操作については [Picture Frame](/slides/ja/python-java/picture-frame/) を参照してください。

### **埋め込みコンテンツとリンクコンテンツの選択**

埋め込みは、必要なすべての画像データがファイルに同梱されるため、プレゼンテーションを可搬にします。リンクはファイルサイズを削減できますが、外部依存性が生じます。依存性が許容でき、かつ安定している場合にのみリンクを使用してください。

### **共有ブランディングの再利用**

ロゴ、透かし、装飾グラフィックなどを繰り返し使用する場合は、単一の画像リソースを使用し再利用してください。グラフィックがスライド内容ではなくプレゼンテーションデザインに属する場合は、マスターやレイアウト上に配置し、対象スライドに継承させます。

### **SVG リソースを可搬に保つ**

自己完結型の SVG は、外部ファイルやネットワークリソースに依存する SVG よりも移動や一貫したレンダリングが容易です。可能な限り、SVG をインポートする前に必要なリソースを埋め込んでください。個々のベクター要素を編集する必要がある場合にのみ、SVG をシェイプに変換してください。

### **最新のクロスプラットフォーム画像 API を使用**

新規の Python via Java のコードでは、`java.awt.image.BufferedImage` をベースとした旧来のパブリック API の代わりに、Aspose.Slides のクロスプラットフォーム画像オブジェクトと [Images](https://reference.aspose.com/slides/ja/python-java/aspose.slides/images/) API を使用してください。移行ガイダンスについては [Modern API](/slides/ja/python-java/modern-api/) を参照してください。

WMF と EMF には特別な考慮が必要です。これらの形式をクロスプラットフォーム画像オブジェクトに渡すと、[ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) はメタファイルをラスタ PNG 表現に変換してから挿入します。メタファイルデータを保持することが重要な場合は、ストリームベースの [ImageCollection.addImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/#addImage) オーバーロードを使用してください。スプレッドシートや他製品から EMF コンテンツを生成することは別の統合ワークフローであり、本記事の範囲外です。

## **FAQ**

**画像コレクションとピクチャーフレームの違いは何ですか？**

画像コレクションは再利用可能な画像リソースを保持します。ピクチャーフレームは、これらのリソースの一つを表示し、トリミングやエフェクトなど画像固有の書式設定を提供するスライドシェイプです。

**同じロゴをすべての場所で置き換える最適な方法は何ですか？**

ロゴがすでに単一の画像リソースとして共有されている場合は、[PPImage.replaceImage](https://reference.aspose.com/slides/ja/python-java/aspose.slides/ppimage/#replaceImage) でそのリソースを置き換えます。プレゼンテーション全体のブランディングの場合、マスターやレイアウトにロゴを配置することでスライド内容の重複を減らすこともできます。

**リンク画像が別のコンピューターで消えるのはなぜですか？**

リンク画像は外部ファイルや URL に依存しています。別のコンピューターからそのリソースにアクセスできない場合、リンク画像は利用できなくなります。プレゼンテーションを自己完結させる必要がある場合は、画像を埋め込んでください。

**挿入した SVG を PowerPoint のシェイプとして編集できますか？**

はい。SVG を [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/ja/python-java/aspose.slides/shapecollection/#addGroupShape) で変換すると、結果のグループは単一の SVG 画像ではなく、編集可能なスライドシェイプを含みます。

**画像が多いプレゼンテーションを小さく保つにはどうすればよいですか？**

共有画像リソースを再利用し、不必要に大きなラスタソースを避け、適切な場合はラスタ画像を圧縮し、繰り返し使用するブランディングはマスターやレイアウトに配置し、外部依存が許容できる場合にのみリンク画像を使用してください。