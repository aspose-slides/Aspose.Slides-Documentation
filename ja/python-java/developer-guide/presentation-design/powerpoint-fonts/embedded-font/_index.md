---
title: Python via Java でプレゼンテーションにフォントを埋め込む
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/python-java/embedded-font/
keywords:
- フォント追加
- フォント埋め込み
- フォントの埋め込み
- 埋め込みフォント取得
- 埋め込みフォント追加
- 埋め込みフォント削除
- 埋め込みフォント圧縮
- PowerPoint
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python via Java 用 Aspose.Slides で PowerPoint の埋め込みフォントを管理します。フォントを追加、取得、削除、圧縮してテキストの外観を保持し、ファイルサイズを削減します。"
---
## **はじめに**

フォントの埋め込みは、フォントデータを PowerPoint プレゼンテーション内に保存します。ビューアが埋め込みフォントに対応している場合、対象システムにフォントがインストールされていなくても、そのフォントでテキストを表示できます。これにより、改行、文字間隔、スライドのレイアウトが保持されます。

Aspose.Slides for Python via Java は、[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) クラス（[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getFontsManager) が返す）を通じて、埋め込みフォントの取得、追加、削除を行うことができます。また、プレゼンテーションで使用されていない文字を除外することで、埋め込みフォントデータのサイズを縮小することも可能です。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、フォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[getEmbeddedFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) を使用して、プレゼンテーションに格納されているフォントの一覧を取得できます。削除する場合は、その一覧からフォントを取得し、[removeEmbeddedFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#removeEmbeddedFont) に渡してからプレゼンテーションを保存します。

以下の例は `EmbeddedFonts.pptx` に埋め込まれているフォントを一覧表示し、存在すれば Calibri を削除します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    embedded_fonts = fonts_manager.getEmbeddedFonts()

    for font in embedded_fonts:
        print(font.getFontName())

    font_to_remove = None
    for font in embedded_fonts:
        if str(font.getFontName()).casefold() == "calibri":
            font_to_remove = font
            break

    if font_to_remove is not None:
        fonts_manager.removeEmbeddedFont(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx)
    else:
        print("Calibri is not embedded. No output file was created.")
finally:
    presentation.dispose()
```

埋め込みフォントを削除すると、そのフォントデータ自体が削除されますが、テキストに割り当てられているフォントは変わりません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントで表示されます。インストールされていない場合、レンダリング時にフォント代替が行われ、レイアウトに影響する可能性があります。

## **フォントデータと埋め込み許可の確認**

[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) クラスを使用して、埋め込み前にフォントを検査できます。[FontsManager.getFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFonts) を呼び出してプレゼンテーションで使用されているフォントを取得し、各フォントについて [FontData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontstyletype/) を [FontsManager.getFontBytes](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFontBytes) に渡します。このメソッドは指定されたフォントスタイルのバイナリデータを返すか、フォントまたはスタイルが利用できない場合は `None` を返します。`None` が返った結果を [FontsManager.getFontEmbeddingLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel) に渡さないでください。このメソッドはバイト配列が必須です。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/embeddinglevel/) は、フォントに保存されている埋め込み制限を示すフラグ列挙です。

- `Installable` は、フォントライセンスの条件に従い、埋め込みと別システムへの永続的インストールを許可します。
- `Restricted` は、唯一の使用許可フラグがこれである場合、フォント権利者からの許可なく埋め込みを禁止します。
- `PreviewPrint` は、閲覧と印刷の一時的使用を許可します。フォントを含む文書は読み取り専用でなければなりません。
- `Editable` は、一時的使用を許可し、文書の編集と保存を可能にします。
- `NoSubsetting` は、文字のサブセット埋め込みを禁止する追加制限です。このフラグがある場合はすべての文字を埋め込んでください。
- `BitmapOnly` は、アウトラインデータではなくビットマップストライクのみの埋め込みを許可する追加制限です。ビットマップストライクが存在しないフォントは埋め込めません。

最初の 4 つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット演算で修飾子を確認してください。`Installable` の値は 0 になるため、使用許可ビットだけをマスクし、結果が `Installable` と等しいかで判定します。現在のフォントは最大で 1 つの使用許可ビットのみ設定すべきです。複数設定されている古いフォントに対しては、以下のヘルパーが最も制限の緩い許可を選択します：`Editable` → `PreviewPrint` → `Restricted`。

以下の例は、`getFonts` が返すすべてのフォントについて、通常・太字・斜体・太字斜体のデータを監査します。利用できないスタイル、制限付きフォント、ビットマップ専用フォント、プレビュー/印刷限定フォント（出力は編集可能になるため）および既に埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` が含まれる場合は、そのフォントファミリのすべての文字を埋め込みます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, EmbeddingLevel, FontStyleType, Presentation, SaveFormat

def get_usage_permission(level):
    permission_mask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable
    permissions = level & permission_mask

    if permissions & EmbeddingLevel.Editable:
        return EmbeddingLevel.Editable

    if permissions & EmbeddingLevel.PreviewPrint:
        return EmbeddingLevel.PreviewPrint

    if permissions & EmbeddingLevel.Restricted:
        return EmbeddingLevel.Restricted

    return EmbeddingLevel.Installable

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    font_styles = [
        FontStyleType.Regular,
        FontStyleType.Bold,
        FontStyleType.Italic,
        FontStyleType.Bold | FontStyleType.Italic,
    ]

    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in fonts_manager.getEmbeddedFonts()}

    fonts_to_embed = []
    embedding_rules = []
    for font in fonts_manager.getFonts():
        font_name = str(font.getFontName())
        if font_name.casefold() in embedded_font_names:
            print(f"{font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.getFontBytes(font, font_style)
            if font_bytes is None:
                print(f"{font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.getFontEmbeddingLevel(font_bytes, font.getFontName())
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & EmbeddingLevel.NoSubsetting)
            bitmap_only = bool(embedding_level & EmbeddingLevel.BitmapOnly)

            requires_full_font = requires_full_font or no_subsetting
            preview_print_only = preview_print_only or usage_permission == EmbeddingLevel.PreviewPrint
            usage_permits_embedding = usage_permission != EmbeddingLevel.Restricted and not bitmap_only
            all_available_styles_can_be_embedded = all_available_styles_can_be_embedded and usage_permits_embedding

            print(f"{font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = EmbedFontCharacters.All if requires_full_font else EmbedFontCharacters.OnlyUsed
            fonts_to_embed.append(font)
            embedding_rules.append(rule)

    for font, rule in zip(fonts_to_embed, embedding_rules):
        fonts_manager.addEmbeddedFont(font, rule)

    presentation.save("WithAuditedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

この検査は各フォントファイルにエンコードされている制限を報告しますが、ライセンスを付与したり、フォントを合法的に取得したことを証明したり、埋め込みコピーを配布する前にフォントのライセンス契約を確認する代わりにはなりません。

## **埋め込みフォントの追加**

[addEmbeddedFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#addEmbeddedFont) を使用してフォントを埋め込むことができます。オーバーロードにより、[FontData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/python-java/aspose.slides/embedfontcharacters/) 列挙は、どの文字を含めるかを制御します。

- [All](https://reference.aspose.com/slides/ja/python-java/aspose.slides/embedfontcharacters/) はフォントのすべての文字を埋め込みます。受信者がプレゼンテーションを編集し、新しいテキストを入力できるようにしたい場合に使用してください。
- [OnlyUsed](https://reference.aspose.com/slides/ja/python-java/aspose.slides/embedfontcharacters/) はプレゼンテーションで使用されている文字だけを埋め込み、ファイルサイズを削減します。閲覧中心の完成したプレゼンテーションに適しています。

以下の例は `Fonts.pptx` で使用されているフォントを [getFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getFonts) で取得し、まだ埋め込まれていないものを埋め込みます。追加するフォントはコードを実行するマシンにインストールされている必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EmbedFontCharacters, Presentation, SaveFormat

presentation = Presentation("Fonts.pptx")
try:
    fonts_manager = presentation.getFontsManager()
    all_fonts = fonts_manager.getFonts()
    embedded_fonts = fonts_manager.getEmbeddedFonts()
    embedded_font_names = {str(embedded_font.getFontName()).casefold() for embedded_font in embedded_fonts}

    for font in all_fonts:
        font_name = str(font.getFontName()).casefold()
        if font_name not in embedded_font_names:
            fonts_manager.addEmbeddedFont(font, EmbedFontCharacters.All)
            embedded_font_names.add(font_name)

    presentation.save("WithEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **埋め込みフォントの圧縮**

[Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compress/#compressEmbeddedFonts) は、未使用文字を除去することで埋め込みフォントデータを縮小します。既に埋め込まれているフォントに対して動作するため、サイズ削減はプレゼンテーションにどれだけ未使用フォントデータが含まれているかに依存します。

以下の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("EmbeddedFonts.pptx")
try:
    Compress.compressEmbeddedFonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

受信者が後でテキストを追加する可能性がある場合は、元のファイルを保持してください。圧縮で削除された文字は、元々すべての文字を埋め込んでいた場合でも、埋め込みフォントからは利用できなくなります。

## **FAQ**

**埋め込みフォントがレンダリング時に置換されるかどうかを確認する方法はありますか？**

プレゼンテーションをレンダリングする環境で [getSubstitutions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions) を呼び出し、Aspose.Slides が置換するフォントを確認してください。また、フォント置換設定やフォントフォールバックルールも確認しましょう。フォールバックは欠落文字を処理するため、フォント自体に含まれていない文字は埋め込みだけでは解決できません。

**Arial や Calibri などの一般的なフォントを埋め込むべきですか？**

対象環境に基づいて判断してください。必要なフォントがプレゼンテーションを開くすべてのマシンに既に存在する場合、埋め込みは不要なファイルサイズ増加につながります。受信者やサーバーにフォントが不足している可能性がある場合は、ライセンスが許可する限り埋め込むことで意図した外観を保持できます。