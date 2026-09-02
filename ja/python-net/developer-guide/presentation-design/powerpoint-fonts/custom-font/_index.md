---
title: Python で PowerPoint フォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/python-net/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォント読み込み
- フォント管理
- フォントフォルダー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET を介して Python 用 Aspose.Slides で PowerPoint スライドにカスタムフォントを埋め込み、あらゆるデバイスでプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---
## **概要**

Aspose.Slides for Python を使用すると、実行時にカスタムフォントを提供できるため、必要なフォントがホストシステムにインストールされていなくてもプレゼンテーションが正しく表示されます。PDF や画像へのエクスポート時にフォントフォルダーやメモリ内フォントデータを指定することで、テキストのレイアウト、グリフのメトリクス、タイポグラフィを維持できます。これにより、サーバー側のレンダリングが異なる環境でも予測可能になり、OS レベルのフォント依存が削除され、不要なフォールバックやリフローを防止できます。本記事ではフォント ソースの登録方法を示します。

プレゼンテーションのテーマは、個々の表記体系に対して異なるフォント ファミリーを参照できます。これらのマッピングはフォント名を保存しますが、フォント ファイルをインストールまたはロードしません。[Script-Specific Theme Fonts](/slides/ja/python-net/script-specific-font-mappings/) を参照してマッピングを管理し、下記のロードオプションを使用して参照されたフォントを利用可能にし、一貫したレンダリングを実現してください。

Aspose.Slides では、[FontsLoader](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsloader/) クラスの `load_external_font` および `load_external_fonts` メソッドを使用して次のフォントをロードできます。

- TrueType (.ttf) および TrueType Collection (.ttc) フォント。 詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照。
- OpenType (.otf) フォント。 詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照。

## **カスタムフォントのロード**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用するフォントをロードできるようにします。これにより、PDF や画像、その他サポートされている形式へのエクスポート出力が環境間で一貫した見た目になります。フォントはカスタムディレクトリからロードされます。

1. フォント ファイルが含まれるフォルダーを 1 つ以上指定します。
2. 静的メソッド [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsloader/load_external_fonts/) を呼び出し、これらのフォルダーからフォントをロードします。
3. プレゼンテーションをロードしてレンダリング/エクスポートします。
4. [FontsLoader.clear_cache](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsloader/clear_cache/) を呼び出してフォントキャッシュをクリアします。

以下のコード例はフォントのロード手順を示しています。

```py
import aspose.slides as slides

# カスタムフォントファイルを含むフォルダーを定義します。
font_folders = ["fonts", "external_fonts"]

# 指定したフォルダーからカスタムフォントをロードします。
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # ロードしたフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# 作業が完了したらフォントキャッシュをクリアします。
slides.FontsLoader.clear_cache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsloader/load_external_fonts/) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます。

1. デフォルトのオペレーティングシステム フォント パス。  
1. [FontsLoader](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsloader/) 経由でロードされたパス。  
{{%/alert %}}

## **カスタムフォント フォルダーの取得**

Aspose.Slides は `get_font_folders` メソッドを提供し、フォント フォルダーを取得できます。このメソッドは `load_external_fonts` で追加されたフォルダーとシステム フォント フォルダーの両方を返します。

以下の Python コードは `get_font_folders` の使用例です。

```python
import aspose.slides as slides

# この呼び出しはフォントファイルがチェックされるフォルダーを返します。
# これらには load_external_fonts メソッドで追加されたフォルダーとシステムフォントフォルダーが含まれます。
font_folders = slides.FontsLoader.get_font_folders()
```

## **プレゼンテーション用カスタムフォントの指定**

Aspose.Slides は `document_level_font_sources` プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

以下の Python 例は `document_level_font_sources` の使用方法を示しています。

```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # プレゼンテーションを操作します。
    # CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダー（およびそのサブフォルダー）からのフォントは、プレゼンテーションで利用可能です。
    # ...
    print(len(presentation.slides))
```

## **バイナリ データから外部フォントをロード**

Aspose.Slides は `load_external_font` メソッドを提供し、バイナリ データから外部フォントをロードできます。

以下の Python 例はバイト配列からフォントをロードする方法を示しています。

```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# バイト配列から外部フォントをロードします。
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # 外部フォントはこのプレゼンテーション インスタンスの存続期間中利用可能です。
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```

## **よくある質問**

### カスタムフォントはすべての形式 (PDF、PNG、SVG、HTML) へのエクスポートに影響しますか？

はい。接続されたフォントはすべてのエクスポート形式でレンダラによって使用されます。

### カスタムフォントは自動的に生成された PPTX に埋め込まれますか？

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは別です。プレゼンテーション ファイルにフォントを埋め込む必要がある場合は、明示的な [embedding features](/slides/ja/python-net/embedded-font/) を使用してください。

### カスタムフォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？

はい。[font substitution](/slides/ja/python-net/font-substitution/)、[replacement rules](/slides/ja/python-net/font-replacement/) および [fallback sets](/slides/ja/python-net/fallback-font/) を構成して、要求されたグリフが存在しないときに使用するフォントを正確に定義できます。

### Linux/Docker コンテナー内でシステム全体にインストールせずにフォントを使用できますか？

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードしてください。これにより、コンテナー イメージ内のシステム フォント ディレクトリへの依存がなくなります。

### ライセンスに関して—制限なしに任意のカスタムフォントを埋め込めますか？

フォントのライセンス遵守は利用者の責任です。ライセンス条件はフォントごとに異なり、埋め込みや商用利用を禁止するものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。