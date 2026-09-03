---
title: Python でプレゼンテーションにフォントを埋め込む
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/python-net/embedded-font/
keywords:
- フォントを追加
- フォントを埋め込む
- フォント埋め込み
- 埋め込みフォントを取得
- 埋め込みフォントを追加
- 埋め込みフォントを削除
- 埋め込みフォントを圧縮
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して PowerPoint の埋め込みフォントを管理します。Python でフォントを追加、取得、削除、圧縮し、テキストの外観を保ちつつファイルサイズを削減できます。"
---
## **概要**

フォントの埋め込みは、フォントデータを PowerPoint プレゼンテーション内に格納します。ビューアが埋め込みフォントに対応している場合、対象システムにフォントがインストールされていなくても、そのフォントを使用してテキストを表示できます。これにより、改行、文字間隔、スライドレイアウトが保たれます。

Aspose.Slides for Python via .NET を使用すると、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) オブジェクトの [fonts_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/fonts_manager/) プロパティを介して埋め込みフォントの取得、追加、削除が行えます。また、プレゼンテーションで使用されていない文字を削除することで、埋め込みフォントデータのサイズを縮小できます。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、そのフォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[get_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) を使用してプレゼンテーションに格納されているフォントの一覧を取得します。フォントを削除するには、その一覧からフォントを [remove_embedded_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/remove_embedded_font/) に渡し、プレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` の埋め込みフォントを列挙し、存在すれば Calibri を削除します：

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    embedded_fonts = fonts_manager.get_embedded_fonts()

    for font in embedded_fonts:
        print(font.font_name)

    font_to_remove = next((font for font in embedded_fonts if font.font_name.casefold() == "calibri"), None)
    if font_to_remove is not None:
        fonts_manager.remove_embedded_font(font_to_remove)
        presentation.save("WithoutEmbeddedCalibri.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Calibri is not embedded. No output file was created.")
```

埋め込みフォントを削除すると、その格納されたフォントデータが削除されますが、テキストに割り当てられたフォント自体は変更されません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントを使用できます。インストールされていない場合、レンダリング時に [font substitution](/slides/ja/python-net/font-substitution/) が必要になることがあり、レイアウトに影響を与える可能性があります。

## **フォントデータと埋め込み権限の検査**

[FontsManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/) クラスを使用して、フォントを埋め込む前に検査できます。[get_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_fonts/) を呼び出すと、プレゼンテーションで使用されているフォントを取得します。各フォントについて、[FontData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontstyletype/) の値を [get_font_bytes](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_font_bytes/) に渡します。このメソッドはそのフォントスタイルのバイナリデータを返し、要求されたフォントまたはスタイルが利用できない場合は `None` を返します。`None` の結果を [get_font_embedding_level](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_font_embedding_level/) に渡さないでください。このメソッドはバイト配列を必要とします。

EmbeddingLevel はフラグ列挙型で、フォントに格納された埋め込み制限を報告します:

- `INSTALLABLE` は埋め込みと別システムへの永続的インストールを許可します（フォントライセンスに従う）。
- `RESTRICTED` は、使用許可フラグがこれだけの場合、フォントの権利所有者から許可を得ない限り埋め込みを禁止します。
- `PREVIEW_PRINT` は閲覧および印刷の一時使用を許可します。フォントを含む文書は読み取り専用である必要があります。
- `EDITABLE` は一時使用を許可し、文書の編集・保存を可能にします。
- `NO_SUBSETTING` は、グリフのサブセット埋め込みを禁止する追加制限です。このフラグがある場合、すべての文字を埋め込む必要があります。
- `BITMAP_ONLY` は、アウトラインデータではなくビットマップストライクのみの埋め込みを許可する追加制限です。フォントにビットマップストライクが無い場合、埋め込みはできません。

最初の 4 つの値は使用許可を示し、`NO_SUBSETTING` と `BITMAP_ONLY` はそれらと組み合わせて使用できます。修飾子はビット演算で確認してください。`INSTALLABLE` が 0 であるため、使用許可ビットをマスクし、結果を `INSTALLABLE` と比較します。現在のフォントは使用許可ビットを最大 1 つだけ設定すべきです。複数設定されている古いフォントとの互換性のため、以下のヘルパーは最も制限の少ない許可を選択します：`EDITABLE`、次に `PREVIEW_PRINT`、その次に `RESTRICTED`。

次の例は `get_fonts` が返す各フォントについて、レギュラー、ボールド、イタリック、ボールドイタリックのデータを監査します。利用できないスタイル、制限付きフォント、ビットマップのみフォント、プレビュー・印刷限定のフォント（出力が編集可能なままであるため）および既に埋め込まれているフォントはスキップします。利用可能なスタイルのいずれかに `NO_SUBSETTING` がある場合、そのフォントファミリのすべての文字を埋め込みます。

```python
import aspose.slides as slides


def get_usage_permission(level):
    permission_mask = slides.EmbeddingLevel.RESTRICTED | slides.EmbeddingLevel.PREVIEW_PRINT | slides.EmbeddingLevel.EDITABLE
    permissions = level & permission_mask

    if permissions & slides.EmbeddingLevel.EDITABLE:
        return slides.EmbeddingLevel.EDITABLE

    if permissions & slides.EmbeddingLevel.PREVIEW_PRINT:
        return slides.EmbeddingLevel.PREVIEW_PRINT

    if permissions & slides.EmbeddingLevel.RESTRICTED:
        return slides.EmbeddingLevel.RESTRICTED

    return slides.EmbeddingLevel.INSTALLABLE


with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    font_styles = [slides.FontStyleType.REGULAR, slides.FontStyleType.BOLD, slides.FontStyleType.ITALIC, slides.FontStyleType.BOLD | slides.FontStyleType.ITALIC]

    embedded_font_names = {font.font_name.casefold() for font in fonts_manager.get_embedded_fonts()}

    embedding_plan = []
    for font in fonts_manager.get_fonts():
        if font.font_name.casefold() in embedded_font_names:
            print(f"{font.font_name}: already embedded.")
            continue

        has_available_data = False
        all_available_styles_can_be_embedded = True
        preview_print_only = False
        requires_full_font = False

        for font_style in font_styles:
            font_bytes = fonts_manager.get_font_bytes(font, font_style)
            if font_bytes is None:
                print(f"{font.font_name} ({font_style}): font data is unavailable.")
                continue

            has_available_data = True
            embedding_level = fonts_manager.get_font_embedding_level(font_bytes, font.font_name)
            usage_permission = get_usage_permission(embedding_level)
            no_subsetting = bool(embedding_level & slides.EmbeddingLevel.NO_SUBSETTING)
            bitmap_only = bool(embedding_level & slides.EmbeddingLevel.BITMAP_ONLY)

            requires_full_font |= no_subsetting
            preview_print_only |= usage_permission == slides.EmbeddingLevel.PREVIEW_PRINT
            all_available_styles_can_be_embedded &= usage_permission != slides.EmbeddingLevel.RESTRICTED and not bitmap_only

            print(f"{font.font_name} ({font_style}): {embedding_level}.")

        if not has_available_data:
            print(f"{font.font_name}: skipped because no requested style is available.")
        elif not all_available_styles_can_be_embedded:
            print(f"{font.font_name}: skipped because at least one available style does not permit outline embedding.")
        elif preview_print_only:
            print(f"{font.font_name}: skipped because this example produces an editable presentation.")
        else:
            rule = slides.export.EmbedFontCharacters.ALL if requires_full_font else slides.export.EmbedFontCharacters.ONLY_USED
            embedding_plan.append((font, rule))

    for font, rule in embedding_plan:
        fonts_manager.add_embedded_font(font, rule)

    presentation.save("WithAuditedFonts.pptx", slides.export.SaveFormat.PPTX)
```

この検査は各フォントファイルにエンコードされた制限を報告します。ライセンスを付与したり、フォントを合法的に取得したことを証明したり、埋め込みコピーを配布する前にフォントのライセンス契約を確認することの代わりにはなりません。

## **埋め込みフォントの追加**

[add_embedded_font](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/add_embedded_font/) を使用してフォントを埋め込みます。そのオーバーロードは [FontData](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/embedfontcharacters/) 列挙型で、埋め込む文字を制御します:

- [ALL](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/embedfontcharacters/) はフォントのすべての文字を埋め込みます。受信者がプレゼンテーションを編集し、新しいテキストを入力できる必要がある場合に使用します。
- [ONLY_USED](https://reference.aspose.com/slides/ja/python-net/aspose.slides.export/embedfontcharacters/) はプレゼンテーションで使用された文字のみを埋め込み、ファイルサイズを削減します。主に閲覧用の完成したプレゼンテーションに適しています。

次の例は [get_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_fonts/) を使用して `Fonts.pptx` で使用されているフォントを取得し、まだ埋め込まれていないフォントを埋め込みます。追加するフォントはコードを実行するマシンに存在している必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    fonts_manager = presentation.fonts_manager
    all_fonts = fonts_manager.get_fonts()
    embedded_fonts = fonts_manager.get_embedded_fonts()
    embedded_names = {font.font_name.casefold() for font in embedded_fonts}

    for font in all_fonts:
        normalized_name = font.font_name.casefold()
        if normalized_name not in embedded_names:
            fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)
            embedded_names.add(normalized_name)

    presentation.save("WithEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

## **埋め込みフォントの圧縮**

[compress_embedded_fonts](https://reference.aspose.com/slides/ja/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) は未使用文字を削除して埋め込みフォントデータを縮小します。既に埋め込まれているフォントに対して動作するため、サイズ削減はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

次の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します：

```python
import aspose.slides as slides

with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("CompressedEmbeddedFonts.pptx", slides.export.SaveFormat.PPTX)
```

受信者が後でテキストを追加する可能性がある場合は、元のファイルを保持してください。圧縮中に削除された文字は、元々すべての文字を埋め込んでいた場合でも、埋め込みフォントからは利用できなくなります。

## **FAQ**

**埋め込みフォントがレンダリング時に置換されるかどうかを確認するにはどうすればよいですか？**

[get_substitutions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_substitutions/) を、プレゼンテーションをレンダリングする環境で呼び出すと、Aspose.Slides が置換するフォントを確認できます。また、[font substitution](/slides/ja/python-net/font-substitution/) の設定と [font fallback](/slides/ja/python-net/fallback-font/) のルールも確認してください。フォールバックは欠落した文字を処理するため、フォント自体に含まれない文字は埋め込みだけでは解決できません。

**Arial や Calibri などの一般的なフォントを埋め込むべきでしょうか？**

対象環境に基づいて判断してください。必要なフォントがプレゼンテーションを開くすべてのマシンに存在する場合、埋め込みは不要なファイルサイズ増加につながります。受信者やサーバーにそれらのフォントが無い可能性がある場合、ライセンスが許可していれば埋め込むことで意図した外観を維持できます。