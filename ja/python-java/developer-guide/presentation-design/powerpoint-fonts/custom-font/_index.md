---
title: Python を介した Java で PowerPoint フォントをカスタマイズ
linktitle: カスタムフォント
type: docs
weight: 20
url: /ja/python-java/custom-font/
keywords:
- フォント
- カスタムフォント
- 外部フォント
- フォント読み込み
- フォント管理
- フォントフォルダー
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して PowerPoint スライドのフォントをカスタマイズし、プレゼンテーションをどのデバイスでも鮮明で一貫性のあるものにします。"
---
## **概要**

Aspose.Slides を使用すると、オペレーティングシステムにインストールせずにプレゼンテーションでカスタムフォントを使用できます。カスタムフォルダーからフォントをロードしたり、ドキュメントレベルのフォント ソースを介して特定のプレゼンテーション用にフォントを提供したり、バイナリ データから直接外部フォントをロードしたりできます。

ロードされたフォントは、プレゼンテーションがレンダリングまたはエクスポートされる際に使用されます。たとえば PDF、画像、その他のサポートされている形式へのエクスポートです。これにより、異なる環境間でプレゼンテーションの出力が一貫します。この記事では、Aspose.Slides が使用するフォント フォルダーの確認方法と、外部フォント使用後にフォント キャッシュをクリアする方法も説明します。

レンダリング用にカスタムフォントを登録することは、フォントを PPTX ファイルに埋め込むこととは別です。フォントをプレゼンテーション内部に保存する必要がある場合は、埋め込み機能を明示的に使用してください。

プレゼンテーションのテーマは、個々の筆記体系ごとに異なるフォント ファミリを参照できます。これらのマッピングはフォント名を格納しますが、フォント ファイルをインストールまたはロードしません。[Script-Specific Theme Fonts](/slides/ja/python-java/script-specific-font-mappings/) を参照してマッピングを管理し、以下のロード オプションを使用して参照されたフォントを利用可能にし、一貫したレンダリングを実現してください。

{{% alert color="info" title="Note" %}}

Aspose.Slides は、[loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadExternalFonts) メソッドを使用して次のフォントをロードできます。

* TrueType（.ttf）および TrueType Collection（.ttc）フォント。詳しくは [TrueType](https://en.wikipedia.org/wiki/TrueType) を参照してください。

* OpenType（.otf）フォント。詳しくは [OpenType](https://en.wikipedia.org/wiki/OpenType) を参照してください。

{{% /alert %}}

## **カスタム フォントのロード**

Aspose.Slides を使うと、システムにインストールせずにプレゼンテーションで使用されるフォントをロードできます。これにより、PDF、画像、その他のサポート形式へのエクスポート結果が環境間で一貫します。フォントはカスタム ディレクトリからロードされます。

1. フォント ファイルが格納されたフォルダーを 1 つ以上指定します。  
2. 静的メソッド [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadExternalFonts) を呼び出し、これらのフォルダーからフォントをロードします。  
3. プレゼンテーションをロードしてレンダリング/エクスポートします。  
4. [FontsLoader.clearCache](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#clearCache) を呼び出してフォント キャッシュをクリアします。

以下のコード例はフォント ロードの手順を示しています。

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# カスタムフォント ファイルが格納されたフォルダーを定義します。
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# 指定されたフォルダーからカスタムフォントをロードします。
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # ロードされたフォントを使用してプレゼンテーションをレンダリング/エクスポートします。
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # 作業が完了した後にフォントキャッシュをクリアします。
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadExternalFonts) はフォント検索パスに追加フォルダーを加えますが、フォントの初期化順序は変更しません。フォントは次の順序で初期化されます。

1. デフォルトのオペレーティングシステム フォント パス。  
1. [FontsLoader](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/) を介してロードされたパス。

{{%/alert %}}

## **カスタム フォント フォルダーの取得**

Aspose.Slides は、[getFontFolders](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#getFontFolders) メソッドを提供し、フォント フォルダーを取得できます。このメソッドは、[loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadExternalFonts) によって追加されたフォルダーとシステム フォント フォルダーを返します。

以下の Python コードは、[getFontFolders](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#getFontFolders) の使用例を示しています。

```python
from asposeslides.api import FontsLoader

# loadExternalFonts で追加されたフォルダーとシステム フォント フォルダーを取得します。
font_folders = FontsLoader.getFontFolders()
```

## **プレゼンテーションで使用するカスタム フォントの指定**

Aspose.Slides は、[getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) メソッドを提供し、プレゼンテーションで使用する外部フォントを指定できます。

以下の Python コードは、[getDocumentLevelFontSources](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) の使用例を示しています。

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # プレゼンテーションを操作します。
    # CustomFont1、CustomFont2、および assets/fonts と global/fonts からのフォント
    # それらのサブフォルダーもプレゼンテーションで利用可能です。
    pass
finally:
    presentation.dispose()
```

## **外部フォントの管理**

Aspose.Slides は、[loadExternalFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadExternalFont) メソッドを提供し、バイナリ データから外部フォントをロードできます。

以下の Python コードは、バイト配列からフォントをロードする手順を示しています。

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # 外部フォントはプレゼンテーションの実行中にロードされます。
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**カスタム フォントはすべての形式（PDF、PNG、SVG、HTML）へのエクスポートに影響しますか？**

はい。接続されたフォントは、すべてのエクスポート形式でレンダラーによって使用されます。

**カスタム フォントは自動的に生成された PPTX に埋め込まれますか？**

いいえ。レンダリング用にフォントを登録することは、PPTX に埋め込むこととは異なります。プレゼンテーション ファイル内にフォントを保持する必要がある場合は、明示的な [埋め込み機能](/slides/ja/python-java/embedded-font/) を使用してください。

**カスタム フォントに特定のグリフが欠けている場合のフォールバック動作を制御できますか？**

はい。[フォント置換](/slides/ja/python-java/font-substitution/)、[置換ルール](/slides/ja/python-java/font-replacement/)、および [フォールバック セット](/slides/ja/python-java/fallback-font/) を構成して、要求されたグリフが存在しないときに使用するフォントを正確に定義できます。

**Linux/Docker コンテナー内でシステム全体にインストールせずにフォントを使用できますか？**

はい。独自のフォント フォルダーを指定するか、バイト配列からフォントをロードしてください。これにより、コンテナー イメージ内のシステム フォント ディレクトリへの依存がなくなります。

**ライセンスについて—制限なしに任意のカスタム フォントを埋め込めますか？**

フォントのライセンス遵守は利用者の責任です。ライセンス条件はさまざまで、埋め込みや商用利用を禁止するものもあります。出力物を配布する前に必ずフォントの EULA を確認してください。