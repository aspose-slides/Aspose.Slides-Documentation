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
- フォントの読み込み
- フォントの管理
- フォントフォルダー
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: ".NET を介して Python 用 Aspose.Slides で PowerPoint スライドにカスタムフォントを埋め込み、あらゆるデバイスでプレゼンテーションを鮮明かつ一貫性のある状態に保ちます。"
---

## **概要**

Aspose.Slides for Python は、実行時にカスタム フォントを提供できるため、ホスト システムに必要なフォントがインストールされていなくてもプレゼンテーションが正しく表示されます。PDF や画像へのエクスポート時に、フォント フォルダーやメモリ内フォント データを指定して、テキストのレイアウト、グリフ メトリクス、タイポグラフィを保持できます。これにより、サーバー側のレンダリングが環境ごとに予測可能になり、OS レベルのフォント依存が排除され、不要なフォールバックや再フローが防止されます。本記事ではフォント ソースの登録方法を示します。

Aspose.Slides は、以下のフォントを [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスの `load_external_font` および `load_external_fonts` メソッドで読み込むことができます。

- TrueType (.ttf) と TrueType Collection (.ttc) フォント。詳細は[TrueType](https://en.wikipedia.org/wiki/TrueType)をご参照ください。  
- OpenType (.otf) フォント。詳細は[OpenType](https://en.wikipedia.org/wiki/OpenType)をご参照ください。

## **カスタムフォントのロード**

Aspose.Slides は、インストールせずにプレゼンテーションのレンダリング用フォントをロードできます。フォントはカスタム ディレクトリから読み込まれます。

1. [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) の `load_external_fonts` メソッドを呼び出します。  
2. レンダリング対象のプレゼンテーションをロードします。  
3. [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスでキャッシュをクリアします。

以下の Python コードがフォントロードの手順を示しています:
```python
import aspose.slides as slides

# フォントを検索するフォルダー。
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# カスタムディレクトリからフォントをロードします。
slides.FontsLoader.load_external_fonts(font_folders)

# プレゼンテーションをレンダリングします。
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# フォントキャッシュをクリアします。
slides.FontsLoader.clear_cache()
```


## **カスタム フォント フォルダーの取得**

Aspose.Slides は `get_font_folders` メソッドを提供し、フォント フォルダーを取得できます。`load_external_fonts` で追加したフォルダーとシステム フォント フォルダーの両方が返されます。

この Python コードは `get_font_folders` の使用例です:
```python
import aspose.slides as slides

# この呼び出しはフォントファイルがチェックされるフォルダーを返します。
# これには load_external_fonts メソッドで追加されたフォルダーとシステムフォントフォルダーが含まれます。
font_folders = slides.FontsLoader.get_font_folders()
```


## **プレゼンテーションごとのカスタム フォント指定**

Aspose.Slides は `document_level_font_sources` プロパティを提供し、プレゼンテーションで使用する外部フォントを指定できます。

以下の Python 例は `document_level_font_sources` の使用方法を示します:
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
    # CustomFont1、CustomFont2、および assets\fonts と global\fonts フォルダー（およびそのサブフォルダー）からのフォントはプレゼンテーションで使用できます。
    # ...
    print(len(presentation.slides))
```


## **バイナリ データから外部フォントをロード**

Aspose.Slides は `load_external_font` メソッドでバイナリ データから外部フォントをロードできます。

以下の Python 例はバイト配列からフォントをロードする方法を示します:
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

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントはすべてのエクスポート形式でレンダラーによって使用されます。

**カスタム フォントは自動的に生成された PPTX に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイル内にフォントを含める必要がある場合は、明示的な[埋め込み機能](/slides/ja/python-net/embedded-font/)を使用してください。

**カスタム フォントに特定のグリフが欠如している場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/python-net/font-substitution/)、[置換ルール](/slides/ja/python-net/font-replacement/)、および[フォールバックセット](/slides/ja/python-net/fallback-font/) を構成して、要求されたグリフが欠如している場合に使用するフォントを正確に定義できます。

**Linux/Docker コンテナー内でフォントをシステム全体にインストールせずに使用できますか？**

はい。独自のフォント フォルダーを指すか、バイト配列からフォントをロードしてください。これにより、コンテナ イメージ内のシステム フォント ディレクトリへの依存が排除されます。

**ライセンスに関して—カスタム フォントを制限なく埋め込むことはできますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件はさまざまで、一部のライセンスは埋め込みや商用利用を禁じています。出力物を配布する前に必ずフォントの EULA を確認してください。