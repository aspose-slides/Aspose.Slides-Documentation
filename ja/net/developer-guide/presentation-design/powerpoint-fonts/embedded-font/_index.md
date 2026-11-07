---
title: .NET でのプレゼンテーションへのフォント埋め込み
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
description: "Aspose.Slides for .NET を使用して PowerPoint の埋め込みフォントを管理します。C# を使ってフォントを追加、取得、削除、圧縮し、テキストの外観を保ちつつファイルサイズを削減します。"
---
## **はじめに**

埋め込みフォントはフォントデータを PowerPoint プレゼンテーション内に保存します。ビューアーが埋め込みフォントに対応していれば、対象システムにフォントがインストールされていなくてもそのフォントでテキストを表示できます。これにより改行、文字間隔、スライドレイアウトが保持されます。

Aspose.Slides for .NET は、[FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) プロパティを介して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) の埋め込みフォントを取得、追加、削除できます。また、プレゼンテーションで使用されていない文字を削除することで埋め込みフォントデータのサイズを縮小できます。

以下の例は PPTX ファイルを対象としています。フォントを埋め込む前に、フォントデータが Aspose.Slides で利用可能であり、ライセンスが埋め込みを許可していることを確認してください。

## **埋め込みフォントの取得と削除**

[GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts/) を使用して、プレゼンテーションに格納されているフォントの一覧を取得します。削除する場合は、その一覧からフォントを渡して [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont/) を呼び出し、プレゼンテーションを保存します。

次の例は `EmbeddedFonts.pptx` に埋め込まれているフォントを一覧表示し、Calibri が存在すれば削除します:

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

埋め込みフォントを削除すると、保存されていたフォントデータが削除されますが、テキストに割り当てられているフォント自体は変更されません。対象システムにフォントがインストールされていれば、テキストは引き続きそのフォントを使用します。インストールされていない場合、レンダリング時に [font substitution](/slides/ja/net/font-substitution/) が必要になることがあり、レイアウトに影響を与える可能性があります。

## **フォントデータと埋め込み権限の検査**

埋め込む前にフォントを検査するには、[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) インターフェイスを使用します。[IFontsManager.GetFonts](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfonts/) でプレゼンテーションで使用されているフォントを取得し、各フォントについて [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) オブジェクトと必要な [FontStyleType](https://reference.aspose.com/slides/net/aspose.slides/fontstyletype/) の値を渡して [IFontsManager.GetFontBytes](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontbytes/) を呼び出します。このメソッドは該当フォントスタイルのバイナリデータを返すか、利用できない場合は `null` を返します。`null` の結果を [IFontsManager.GetFontEmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getfontembeddinglevel/) に渡さないでください。こちらのメソッドはバイト配列が必須です。

[EmbeddingLevel](https://reference.aspose.com/slides/net/aspose.slides/embeddinglevel/) はフォントに保存された埋め込み制限を示すフラグ列挙体です。

- `Installable` は埋め込みおよび別システムへの永続的インストールを許可します（フォントライセンスに従う）。
- `Restricted` は唯一の使用許可フラグがこれである場合、フォント所有者の許可なく埋め込みを禁止します。
- `PreviewPrint` は閲覧と印刷の一時的使用を許可します。文書は読み取り専用である必要があります。
- `Editable` は一時的使用を許可し、文書の編集と保存を可能にします。
- `NoSubsetting` は追加の制限で、グリフのサブセット埋め込みを禁止します。このフラグがある場合はすべての文字を埋め込んでください。
- `BitmapOnly` は追加の制限で、アウトラインデータではなくビットマップストライクのみの埋め込みを許可します。フォントにビットマップストライクが無い場合は埋め込みできません。

最初の 4 つの値は使用許可を表し、`NoSubsetting` と `BitmapOnly` はそれらと組み合わせて使用できます。ビット演算でフラグをチェックしてください。`Installable` の値は 0 なので、`HasFlag` で判定せず、使用許可ビットをマスクして `Installable` と比較します。現在のフォントは最大で 1 つの使用許可ビットだけを設定すべきです。複数設定されている古いフォントに対応するため、以下のヘルパーは最も制限の緩い権限を選択します：`Editable` → `PreviewPrint` → `Restricted`。

次の例は `GetFonts` で取得したすべてのフォントに対し、通常、太字、斜体、太字斜体のデータを監査します。利用できないスタイル、制限フォント、ビットマップのみフォント、プレビュー/印刷限定フォント（出力は編集可能になるため）および既に埋め込まれているフォントはスキップします。利用可能なスタイルに `NoSubsetting` が含まれる場合は、そのフォントファミリ全体の文字をすべて埋め込みます。

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

この検査は各フォントファイルにエンコードされた制限を報告しますが、ライセンスを付与したり、合法的に取得したことを証明したり、埋め込みコピーを配布する前にフォントのライセンス契約を確認する義務を免除するものではありません。

## **埋め込みフォントの追加**

[AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) を使用してフォントを埋め込みます。オーバーロードは [IFontData](https://reference.aspose.com/slides/net/aspose.slides/ifontdata/) オブジェクトまたはフォントデータを含むバイト配列のいずれかを受け取ります。[EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) 列挙体で含める文字を制御します。

- [All](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) はフォント内のすべての文字を埋め込みます。受取人がプレゼンテーションを編集し、新しいテキストを入力できるようにしたい場合に使用します。
- [OnlyUsed](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) はプレゼンテーションで使用されている文字だけを埋め込み、ファイルサイズを削減します。主に閲覧用の完成版プレゼンテーションに適しています。

次の例は `Fonts.pptx` で使用されているフォントを [GetFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getfonts/) で取得し、まだ埋め込まれていないものを埋め込みます。追加するフォントはコードを実行するマシンにインストールされている必要があります。既存の埋め込みフォントは現在の文字セットを保持します。

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

[CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) は使用されていない文字を削除して埋め込みフォントデータを縮小します。既に埋め込まれているフォントに対して動作するため、サイズ削減率はプレゼンテーションに含まれる未使用フォントデータの量に依存します。

次の例は `EmbeddedFonts.pptx` のフォントを圧縮し、結果を別ファイルとして保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("EmbeddedFonts.pptx");
Compress.CompressEmbeddedFonts(presentation);
presentation.Save("CompressedEmbeddedFonts.pptx", SaveFormat.Pptx);
```

受取人が後でテキストを追加する可能性がある場合は、元のファイルを残しておいてください。圧縮時に削除された文字は埋め込みフォントからは利用できなくなります（最初にすべての文字を埋め込んでいた場合でも）。

エクスポート時に埋め込みフォントを削除せずに、登録済みフォントに優先権を与えたい場合は、[Prefer Registered Fonts over Embedded Fonts](/slides/ja/net/font-selection-sequence/#prefer-registered-fonts-over-embedded-fonts) (.NET 26.11 以降) を参照してください。

## **FAQ**

**埋め込みフォントがレンダリング時に置き換えられるかどうか、どうやって確認できますか？**

プレゼンテーションをレンダリングする環境で [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getsubstitutions/) を呼び出し、Aspose.Slides が置き換えるフォントを確認してください。また、[font substitution](/slides/ja/net/font-substitution/) の設定と [font fallback](/slides/ja/net/fallback-font/) ルールも確認しましょう。フォールバックは欠損文字を処理するため、フォントに含まれていない文字は埋め込みだけでは解決できません。

**Arial や Calibri などの一般的なフォントは埋め込むべきでしょうか？**

対象環境に基づいて判断してください。必要なフォントがプレゼンテーションを開くすべてのマシンに既にインストールされている場合、埋め込みは不要なファイルサイズ増加につながります。受取人やサーバーにこれらのフォントが無い可能性がある場合は、ライセンスが許可している限り埋め込むことで意図した外観を保つのに役立ちます。