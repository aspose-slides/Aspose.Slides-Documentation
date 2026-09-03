---
title: .NET でプレゼンテーションにフォントを埋め込む
linktitle: 埋め込みフォント
type: docs
weight: 40
url: /ja/net/embedded-font/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint の埋め込みフォントを管理します。C# を使ってフォントを追加、取得、削除、圧縮し、テキストの外観を保持しながらファイルサイズを削減します。"
---
## **概要**

フォントを埋め込むと、フォントデータが PowerPoint プレゼンテーション内に格納されます。ビューアが埋め込みフォントに対応していれば、対象システムにフォントがインストールされていなくても、そのフォントでテキストを表示できます。これにより、改行、文字間隔、スライドレイアウトが保持されます。

Aspose.Slides for .NET は、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) の [FontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/fontsmanager/) プロパティを介して、埋め込みフォントの取得、追加、削除ができます。また、プレゼンテーションで使用されていない文字を除去することで、埋め込みフォントデータのサイズを縮小することも可能です。

以下のサンプルは PPTX ファイルを対象としています。フォントを埋め込む前に、フォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[GetEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getembeddedfonts/) を使用して、プレゼンテーションに保存されているフォントの一覧を取得できます。削除する場合は、一覧から取得したフォントを [RemoveEmbeddedFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/removeembeddedfont/) に渡してからプレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` の埋め込みフォントを列挙し、存在すれば Calibri を削除します。

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("EmbeddedFonts.pptx");
var fontsManager = presentation.FontsManager;
var embeddedFonts = fontsManager.GetEmbeddedFonts();

foreach (var font in embeddedFonts)
{
    Console.WriteLine(font.FontName);
}

var fontToRemove = Array.Find(embeddedFonts, font => string.Equals(font.FontName, "Calibri", StringComparison.OrdinalIgnoreCase));
if (fontToRemove != null)
{
    fontsManager.RemoveEmbeddedFont(fontToRemove);
    presentation.Save("WithoutEmbeddedCalibri.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Calibri is not embedded. No output file was created.");
}
```

埋め込みフォントを削除すると、保存されていたフォントデータが取り除かれますが、テキストに割り当てられたフォント自体は変更されません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントで表示されます。インストールされていない場合は、[フォント置換](/slides/ja/net/font-substitution/) が行われ、レイアウトが変わる可能性があります。

## **フォントデータと埋め込み許可の確認**

埋め込む前にフォントを検査するには、[IFontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/) インターフェイスを使用します。まず [IFontsManager.GetFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getfonts/) でプレゼンテーションで使用されているフォントを取得します。各フォントについて、[IFontData](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/ja/net/aspose.slides/fontstyletype/) 値を渡して [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getfontbytes/) を呼び出します。このメソッドは該当フォントスタイルのバイナリデータを返すか、利用できない場合は `null` を返します。`null` が返った場合に [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) を呼び出さないでください。このメソッドはバイト配列が必須です。

[EmbeddingLevel](https://reference.aspose.com/slides/ja/net/aspose.slides/embeddinglevel/) はフォントに格納された埋め込み制限を示すフラグ列挙型です。

- `Installable` は埋め込みと別システムへの永久インストールを許可します（フォント ライセンスに従う）。
- `Restricted` は唯一の使用許可フラグが `Restricted` の場合、フォントの権利者から許可を得ない限り埋め込みを禁止します。
- `PreviewPrint` は閲覧と印刷の一時使用を許可します。フォントを含む文書は読み取り専用である必要があります。
- `Editable` は一時使用を許可し、文書の編集と保存を可能にします。
- `NoSubsetting` はサブセット埋め込みを禁止する追加制限です。このフラグが付いている場合は、すべての文字を埋め込む必要があります。
- `BitmapOnly` はアウトラインデータではなくビットマップストライクのみの埋め込みを許可する追加制限です。ビットマップストライクが存在しないフォントは埋め込めません。

最初の 4 つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット単位の演算で修飾子を確認してください。`Installable` の値は 0 であるため、`HasFlag` で判定せず、使用許可ビットをマスクして `Installable` と比較します。現在のフォントは最大で 1 つの使用許可ビットしか設定しませんが、複数設定されている古いフォントに互換性を持たせるため、以下のヘルパーは最も制限の緩い許可を選択します：`Editable` → `PreviewPrint` → `Restricted`.

次の例は `GetFonts` が返すすべてのフォントについて、通常、太字、イタリック、太字イタリックのデータを監査します。利用できないスタイル、制限付きフォント、ビットマップ専用フォント、プレビュー/印刷限定フォント（出力は編集可能になるため）およびすでに埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` が含まれる場合は、そのフォントファミリのすべての文字を埋め込みます。

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

static EmbeddingLevel GetUsagePermission(EmbeddingLevel level)
{
    const EmbeddingLevel permissionMask = EmbeddingLevel.Restricted | EmbeddingLevel.PreviewPrint | EmbeddingLevel.Editable;
    var permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel.Editable) != 0)
    {
        return EmbeddingLevel.Editable;
    }

    if ((permissions & EmbeddingLevel.PreviewPrint) != 0)
    {
        return EmbeddingLevel.PreviewPrint;
    }

    if ((permissions & EmbeddingLevel.Restricted) != 0)
    {
        return EmbeddingLevel.Restricted;
    }

    return EmbeddingLevel.Installable;
}

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var fontStyles = new[]
{
    FontStyleType.Regular,
    FontStyleType.Bold,
    FontStyleType.Italic,
    FontStyleType.Bold | FontStyleType.Italic
};

var embeddedFontNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var embeddedFont in fontsManager.GetEmbeddedFonts())
{
    embeddedFontNames.Add(embeddedFont.FontName);
}

var embeddingPlan = new List<(IFontData Font, EmbedFontCharacters Rule)>();
foreach (var font in fontsManager.GetFonts())
{
    if (embeddedFontNames.Contains(font.FontName))
    {
        Console.WriteLine($"{font.FontName}: already embedded.");
        continue;
    }

    var hasAvailableData = false;
    var allAvailableStylesCanBeEmbedded = true;
    var previewPrintOnly = false;
    var requiresFullFont = false;

    foreach (var fontStyle in fontStyles)
    {
        var fontBytes = fontsManager.GetFontBytes(font, fontStyle);
        if (fontBytes == null)
        {
            Console.WriteLine($"{font.FontName} ({fontStyle}): font data is unavailable.");
            continue;
        }

        hasAvailableData = true;
        var embeddingLevel = fontsManager.GetFontEmbeddingLevel(fontBytes, font.FontName);
        var usagePermission = GetUsagePermission(embeddingLevel);
        var noSubsetting = (embeddingLevel & EmbeddingLevel.NoSubsetting) != 0;
        var bitmapOnly = (embeddingLevel & EmbeddingLevel.BitmapOnly) != 0;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel.PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel.Restricted && !bitmapOnly;

        Console.WriteLine($"{font.FontName} ({fontStyle}): {embeddingLevel}.");
    }

    if (!hasAvailableData)
    {
        Console.WriteLine($"{font.FontName}: skipped because no requested style is available.");
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console.WriteLine($"{font.FontName}: skipped because at least one available style does not permit outline embedding.");
    }
    else if (previewPrintOnly)
    {
        Console.WriteLine($"{font.FontName}: skipped because this example produces an editable presentation.");
    }
    else
    {
        var rule = requiresFullFont ? EmbedFontCharacters.All : EmbedFontCharacters.OnlyUsed;
        embeddingPlan.Add((font, rule));
    }
}

foreach (var item in embeddingPlan)
{
    fontsManager.AddEmbeddedFont(item.Font, item.Rule);
}

presentation.Save("WithAuditedFonts.pptx", SaveFormat.Pptx);
```

この検査は各フォントファイルにエンコードされた制限を報告します。ライセンスを付与したり、フォントを合法的に取得したことを証明したり、埋め込みコピーを配布する前にフォントの使用許諾契約を確認する代わりにはなりません。

## **埋め込みフォントの追加**

[AddEmbeddedFont](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/addembeddedfont/) を使用してフォントを埋め込めます。オーバーロードは [IFontData](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/ja/net/aspose.slides.export/embedfontcharacters/) 列挙型で、埋め込む文字の範囲を制御します。

- [All](https://reference.aspose.com/slides/ja/net/aspose.slides.export/embedfontcharacters/) はフォント内のすべての文字を埋め込みます。受信者がプレゼンテーションを編集し、新しいテキストを入力できるようにしたい場合に使用します。
- [OnlyUsed](https://reference.aspose.com/slides/ja/net/aspose.slides.export/embedfontcharacters/) はプレゼンテーションで実際に使用された文字だけを埋め込み、ファイルサイズを削減します。主に閲覧用の完成したプレゼンテーションに適しています。

次の例は `Fonts.pptx` で使用されているフォントを [GetFonts](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getfonts/) で取得し、まだ埋め込まれていないフォントを埋め込みます。追加するフォントはコード実行マシンにインストールされている必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Fonts.pptx");
var fontsManager = presentation.FontsManager;
var allFonts = fontsManager.GetFonts();
var embeddedFonts = fontsManager.GetEmbeddedFonts();
var embeddedFontNames = embeddedFonts.Select(font => font.FontName);
var embeddedNames = new HashSet<string>(embeddedFontNames, StringComparer.OrdinalIgnoreCase);

foreach (var font in allFonts)
{
    if (!embeddedNames.Contains(font.FontName))
    {
        fontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
        embeddedNames.Add(font.FontName);
    }
}

presentation.Save("WithEmbeddedFonts.pptx", SaveFormat.Pptx);
```

## **埋め込みフォントの圧縮**

[CompressEmbeddedFonts](https://reference.aspose.com/slides/ja/net/aspose.slides.lowcode/compress/compressembeddedfonts/) は、未使用文字を除去することで埋め込みフォントデータを縮小します。既に埋め込まれているフォントに対して動作するため、サイズ削減効果はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

次の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

受信者が後でテキストを追加する可能性がある場合は、元のファイルを保持してください。圧縮時に削除された文字は、元々すべての文字を埋め込んでいた場合でも、埋め込みフォントからは利用できなくなります。

## **FAQ**

**埋め込みフォントがレンダリング時に置換されるかどうかを確認する方法はありますか？**

プレゼンテーションをレンダリングする環境で [GetSubstitutions](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/getsubstitutions/) を呼び出し、Aspose.Slides が置換するフォントを確認してください。また、[フォント置換](/slides/ja/net/font-substitution/) 設定や [フォントフォールバック](/slides/ja/net/fallback-font/) ルールも併せて確認してください。フォールバックは欠落文字を処理するため、フォント自体に含まれない文字は埋め込みだけでは解決できません。

**Arial や Calibri などの一般的なフォントを埋め込むべきでしょうか？**

対象環境に基づいて判断してください。すべてのマシンでフォントが利用可能であれば、埋め込みは不要なファイルサイズ増加につながります。受信者やサーバーにフォントがない可能性がある場合は、ライセンスが許可している限り埋め込むことで意図した外観を保持できます。