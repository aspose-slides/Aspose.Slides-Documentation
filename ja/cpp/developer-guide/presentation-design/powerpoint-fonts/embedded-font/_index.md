---
title: C++でプレゼンテーションにフォントを埋め込む
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/cpp/embedded-font/
keywords:
- フォントの追加
- フォントの埋め込み
- フォント埋め込み
- 埋め込みフォントの取得
- 埋め込みフォントの追加
- 埋め込みフォントの削除
- 埋め込みフォントの圧縮
- PowerPoint
- プレゼンテーション
- C++
- Aspose.Slides
description: "C++ 用 Aspose.Slides を使用して PowerPoint の埋め込みフォントを管理します。フォントを追加、取得、削除、圧縮してテキストの外観を保ち、ファイルサイズを削減します。"
---
## **はじめに**

フォントの埋め込みは、フォントデータを PowerPoint プレゼンテーション内に保存します。ビューアが埋め込みフォントに対応している場合、対象システムにフォントがインストールされていなくても、そのフォントでテキストを表示できます。これにより、改行や文字間隔、スライドのレイアウトが保たれます。

Aspose.Slides for C++ は、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) の [Presentation::get_FontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/get_fontsmanager/) メソッドを使用して、埋め込みフォントの取得、追加、削除ができます。また、プレゼンテーションで使用されていない文字を削除することで、埋め込みフォントデータのサイズを削減することも可能です。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、フォントデータが Aspose.Slides で利用可能であり、かつライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) を使用して、プレゼンテーションに格納されているフォントの一覧を取得します。削除するには、その一覧からフォントを取得し、[IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) に渡してからプレゼンテーションを保存します。

以下の例は `EmbeddedFonts.pptx` に埋め込まれたフォントを一覧表示し、存在すれば Calibri を削除します:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

埋め込みフォントを削除すると、そのフォントデータが失われますが、テキストに割り当てられたフォント自体は変更されません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントで表示されます。インストールされていない場合、レンダリング時に [フォント置換](/slides/ja/cpp/font-substitution/) が必要になることがあり、レイアウトに影響する可能性があります。

## **フォントデータと埋め込み許可の検査**

埋め込む前にフォントを検査するには、[IFontsManager](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/) インターフェイスを使用します。[IFontsManager::GetFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/getfonts/) を呼び出してプレゼンテーションで使用されているフォントを取得します。各フォントについて、[IFontData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/cpp/aspose.slides/fontstyletype/) の値を [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/getfontbytes/) に渡します。このメソッドは指定されたフォントスタイルのバイナリデータを返すか、要求されたフォントまたはスタイルが利用できない場合は `nullptr` を返します。バイト配列が必要な [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) には `nullptr` を渡さないでください。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/cpp/aspose.slides/embeddinglevel/) は、フォントに保存された埋め込み制限を報告するフラグ列挙型です。

- `Installable` は、フォントライセンスの許可のもと、他システムへの埋め込みおよび永続的インストールを許可します。
- `Restricted` は、唯一の使用許可フラグがこれである場合、フォントの権利者から許可を得ない限り埋め込みを禁止します。
- `PreviewPrint` は、閲覧と印刷の一時的な使用を許可します。フォントを含むドキュメントは読み取り専用である必要があります。
- `Editable` は、一時的な使用を許可し、ドキュメントの編集と保存を可能にします。
- `NoSubsetting` は、グリフのサブセットのみの埋め込みを禁止する追加制限です。このフラグがある場合はすべての文字を埋め込んでください。
- `BitmapOnly` は、アウトラインデータではなくビットマップストライクのみの埋め込みを許可する追加制限です。フォントにビットマップストライクがない場合、埋め込むことはできません。

最初の4つの値は使用許可を示し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット単位の演算で修飾子を確認します。`Installable` は 0 であるため、使用許可ビットをマスクして結果を `Installable` と比較します。現在のフォントは最大で1つの使用許可ビットのみ設定すべきです。複数設定されている古いフォントとの互換性のため、以下のヘルパーは最も制限の緩い許可を選択します: `Editable`、次に `PreviewPrint`、最後に `Restricted`。

以下の例は `GetFonts` で返されたすべてのフォントについて、標準・太字・斜体・太字斜体のデータを監査します。利用できないスタイル、制限付きフォント、ビットマップのみフォント、プレビューと印刷のみ許可されたフォント（出力は編集可能なまま）、既に埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` がある場合、そのフォントファミリのすべての文字を埋め込みます。

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

この検査は各フォントファイルにエンコードされた制限を報告しますが、ライセンスの付与やフォントを合法的に取得したことの証明、埋め込みコピーを配布する前のフォントライセンス契約の確認に代わるものではありません。

## **埋め込みフォントの追加**

[IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/addembeddedfont/) を使用してフォントを埋め込みます。オーバーロードは、[IFontData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/embedfontcharacters/) 列挙体が含める文字を制御します。

- [All](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/embedfontcharacters/) はフォント内のすべての文字を埋め込みます。受信者がプレゼンテーションを編集し、新しいテキストを入力できるようにする必要がある場合に使用します。
- [OnlyUsed](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/embedfontcharacters/) はプレゼンテーションで使用されている文字だけを埋め込み、ファイルサイズを削減します。主に閲覧用の完成したプレゼンテーションに適しています。

以下の例は `Fonts.pptx` で使用されているフォントを [IFontsManager::GetFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/getfonts/) で取得し、まだ埋め込まれていないものを埋め込みます。追加するフォントはコードを実行するマシンに存在している必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **埋め込みフォントの圧縮**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/ja/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) は未使用文字を削除して埋め込みフォントデータを圧縮します。既に埋め込まれているフォントに対して動作するため、サイズ削減はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

以下の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

受信者が後でテキストを追加する可能性がある場合は、元のファイルを保持してください。圧縮中に削除された文字は、元々すべての文字を埋め込んでいた場合でも、埋め込みフォントからは利用できなくなります。

## **よくある質問**

**埋め込みフォントがレンダリング時に置換されるかどうかを確認するにはどうすればよいですか？**

プレゼンテーションをレンダリングする環境で [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ifontsmanager/getsubstitutions/) を呼び出し、Aspose.Slides が置換するフォントを確認します。また、[フォント置換](/slides/ja/cpp/font-substitution/) 設定と [フォントフォールバック](/slides/ja/cpp/fallback-font/) ルールも確認してください。フォールバックは欠損文字を処理するため、フォント自体に含まれていない文字は埋め込みだけでは解決できません。

**Arial や Calibri のような一般的なフォントを埋め込むべきですか？**

対象環境に基づいて判断してください。必要なフォントがプレゼンテーションを開くすべてのマシンに既にインストールされている場合、埋め込みは不要なファイルサイズ増加につながります。受信者やサーバーにそれらのフォントがない可能性がある場合、ライセンスが埋め込みを許可していれば、意図した外観を保つために埋め込むことが有益です。