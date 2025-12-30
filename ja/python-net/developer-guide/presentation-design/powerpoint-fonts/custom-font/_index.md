---
title: PythonでPowerPointフォントをカスタマイズ
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
description: "Aspose.Slides for Python を .NET 経由で使用し、PowerPoint スライドにカスタムフォントを埋め込み、どのデバイスでもプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---

## **概要**

Aspose.Slides for Python は、実行時にカスタム フォントを提供できるため、必要なフォントがホスト システムにインストールされていなくてもプレゼンテーションが正しくレンダリングされます。PDF や画像へのエクスポート時に、フォント フォルダーやメモリ内フォント データを指定して、テキストのレイアウト、グリフ メトリック、タイポグラフィを保持できます。これにより、サーバー側のレンダリングが環境ごとに予測可能になり、OS レベルのフォント依存が排除され、不要なフォールバックやリフローが防止されます。本記事ではフォント ソースの登録方法を示します。

Aspose.Slides では、[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスの `load_external_font` および `load_external_fonts` メソッドを使用して次のフォントを読み込むことができます。

- TrueType (.ttf) と TrueType Collection (.ttc) フォント。 詳細は [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。
- OpenType (.otf) フォント。 詳細は [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

## **カスタム フォントの読み込み**

Aspose.Slides は、システムにインストールせずにプレゼンテーションで使用されるフォントを読み込むことができます。これにより、PDF、画像、その他のサポート形式へのエクスポート結果が環境間で一貫した外観になります。フォントはカスタム ディレクトリから読み込まれます。

1. フォント ファイルが格納された 1 つ以上のフォルダーを指定します。  
2. 静的メソッド [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) を呼び出し、これらのフォルダーからフォントを読み込みます。  
3. プレゼンテーションを読み込み、レンダリング/エクスポートします。  
4. [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォント 読み込みプロセスを示しています。
```py
import aspose.slides as slides

# カスタムフォントファイルが含まれるフォルダーを定義します。
font_folders = [ external_font_folder1, external_font_folder2 ]

# 指定されたフォルダーからカスタムフォントを読み込みます。
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # 読み込んだフォントを使用してプレゼンテーションをレンダリング/エクスポートします（例: PDF、画像、その他の形式）。
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# 作業が完了したらフォントキャッシュをクリアします。
slides.FontsLoader.clear_cache()
```


{{% alert color="info" title="注" %}}

[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) はフォント検索パスにフォルダーを追加しますが、フォントの初期化順序は変更しません。  
フォントは次の順序で初期化されます。

1. デフォルトのオペレーティング システム フォント パス。  
1. [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) によりロードされたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**

Aspose.Slides は `get_font_folders` メソッドを提供し、フォント フォルダーを取得できます。`load_external_fonts` で追加されたフォルダーとシステム フォント フォルダーの両方が返されます。

以下の Python コードは `get_font_folders` の使用例です。
```python
import aspose.slides as slides

# この呼び出しはフォントファイルがチェックされるフォルダーを返します。
# これらには load_external_fonts メソッドで追加されたフォルダーとシステムのフォントフォルダーが含まれます。
font_folders = slides.FontsLoader.get_font_folders()
```


## **プレゼンテーションにカスタム フォントを指定する**

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
    # CustomFont1、CustomFont2、および assets\\fonts と global\\fonts フォルダー（およびそのサブフォルダー）からのフォントがプレゼンテーションで使用可能です。
    # ...
    print(len(presentation.slides))
```


## **バイナリ データから外部フォントを読み込む**

Aspose.Slides は `load_external_font` メソッドを提供し、バイナリ データから外部フォントを読み込むことができます。

以下の Python 例はバイト配列からフォントを読み込む方法を示しています。
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


## **FAQ**

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラーによって使用されます。

**カスタム フォントは自動的に生成された PPTX に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイル内にフォントを保持したい場合は、明示的な [埋め込み機能](/slides/ja/python-net/embedded-font/) を使用する必要があります。

**カスタム フォントに特定のグリフがない場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/python-net/font-substitution/)、[置換ルール](/slides/ja/python-net/font-replacement/)、および [フォールバックセット](/slides/ja/python-net/fallback-font/) を構成して、要求されたグリフが欠落しているときに使用するフォントを正確に定義できます。

**Linux/Docker コンテナー内でシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォント フォルダーを指すか、バイト配列からフォントをロードします。これにより、コンテナー イメージ内のシステム フォント ディレクトリへの依存が排除されます。

**ライセンスについて—カスタム フォントを制限なく埋め込むことはできますか？**

フォントのライセンス遵守は利用者の責任です。ライセンスにより埋め込みや商用利用が禁止されている場合があります。出力物を配布する前に必ずフォントの EULA を確認してください。