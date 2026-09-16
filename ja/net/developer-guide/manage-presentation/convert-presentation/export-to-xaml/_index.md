---
title: .NET でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションから XAML へ
type: docs
weight: 30
url: /ja/net/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションから XAML へ
- PPT から XAML へ
- PPTX から XAML へ
- ODP から XAML へ
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して、.NET で PowerPoint および OpenDocument スライドを XAML に変換します—高速で Office が不要、レイアウトをそのまま保持できるソリューションです。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要を含み、デフォルト設定でプレゼンテーションを XAML に保存する方法を示し、[XamlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/) を使用したエクスポートのカスタマイズ方法（非表示スライドのエクスポートを含む）をデモンストレーションします。また、フォールバックフォント、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも回答します。

## **XAML について**

XAML は、WPF (Windows Presentation Foundation)、UWP (Universal Windows Platform)、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用される XML ベースのマークアップ言語です。

XAML ファイルはビジュアル デザイナーで操作することも、マークアップを直接記述・編集することもできます。

## **デフォルト オプションでプレゼンテーションを XAML にエクスポートする**

次の C# サンプルは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

既定では、エクスポートされたスライドはプロセスの現在の作業ディレクトリ ( [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory) が返す) の `pres` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同じ場所に保存されます。

出力フォルダー名は、拡張子を除いたソース ファイル名から取得されます。`pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` などとなります。入力プレゼンテーションに絶対パスを渡した場合でも、出力フォルダーは現在の作業ディレクトリを基準に作成され、入力ファイルと同じ場所には作成されません。

## **カスタム オプションでプレゼンテーションを XAML にエクスポートする**

[IXamlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/ixamloptions/) インターフェイスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御できます。

出力先をカスタム位置にするには、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/ixamloutputsaver/) を実装し、そのインスタンスを [XamlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/) の [OutputSaver](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/outputsaver/) プロパティに割り当てます。

非表示スライドを XAML 出力に含めるには、[ExportHiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) プロパティを `true` に設定します。以下の C# サンプルを参照してください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **生成されたすべての XAML アーティファクトを取得する**

XAML エクスポートは、エクスポートされたスライドごとに XAML ドキュメントを生成し、画像やサポート リソースを別ファイルとして出力します。デフォルトのファイルシステム セーバーではなく、カスタム [IXamlOutputSaver](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/ixamloutputsaver/) を [XamlOptions.OutputSaver](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/outputsaver/) に割り当てることで、これらのアーティファクトを受け取れます。エクスポートは、XAML オプションを受け取る [Presentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) のオーバーロードで開始します。

### **コールバック ライフサイクルの理解**

エクスポーターは生成された各アーティファクトに対して [IXamlOutputSaver.Save](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/ixamloutputsaver/save/) を個別に呼び出します。

- `path` はアーティファクトを識別し、相対ディレクトリーを含むことがあります。XAML が相対パスでリソースを参照する可能性があるため、この情報は保持してください。
- `data` はアーティファクトのバイト配列です。画像やその他のバイナリ リソースはテキストとしてデコードしないでください。
- セーバーはデータを保持または永続化した上で戻り値を返す責任があります。サンプルでは各バイト配列をアプリケーション所有のメモリにコピーしています。
- プレゼンテーションの保存操作が完了し、すべてのコールバックが正常に完了したときのみエクスポートを成功とみなしてください。保存エラーを無視したり、バックグラウンド書き込みを観測しないままにしないでください。永続化が後で行われる場合は、そのステップが成功した後に全体の成功を報告してください。

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) はカスタム セーバーにも適用されます。デフォルトは `false` で、非表示スライドの XAML ドキュメントは除外されます。`true` に設定すると、非表示スライドとそれらのエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドごとに 1 コールバックがある、または固定順序で呼び出されると想定しないでください。

### **メモリ上でエクスポートし、アーティファクトを検査する**

以下の完全例は `pres.pptx` を読み込み、すべてのアーティファクトを [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) に収集し、名前、型、バイト数を出力します。提供された名前はそのまま保持します。重複名前があるとコレクションは失敗し、アーティファクトが静かに上書きされることはありません。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // XAML のみをデコードし、テキスト検査が必要な場合にのみ行います。
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

アプリケーションから `InMemoryXamlExample.Run` を呼び出してください。拡張子チェックは検査に有用です。すべてのアーティファクト（慣れないリソースタイプも含む）を保持し、バイトは保存または転送時に変更しないでください。テキスト処理が必要な XAML のみ、[Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) を使用してください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化する**

この独立した例はエクスポートを収集し、名前を検証した上で元のバイトを ZIP アーカイブに書き込みます。ユニークなアーカイブ名は同時実行エクスポート ジョブを分離します。ZIP エントリはスラッシュ (/) を使用し、相対ディレクトリーを保持します。正規化後に衝突する危険な名前は、書き込み前にパッケージ全体を破棄します。

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // ZIP ディレクトリは、成功を報告する前に破棄によって確定されました。
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

アプリケーションから `ZipXamlExample.Run` を呼び出してください。例は [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) を使用してローカル アーカイブを書き込みます。エクスポーター自体は緩く配置された XAML や画像ファイルを書き込みません。リモート ストレージの場合は、アーカイブ書き込み段階を収集したバイト配列のアップロードに置き換えてください。エクスポート ジョブ ID と完全な相対アーティファクト名をブロブキーとして使用するか、ジョブ ID、相対名、バイナリ データをデータベース行に保存します。すべてのアップロードが完了またはトランザクションがコミットされた後にジョブを公開し、永続化に失敗した場合は部分的な出力をクリーンアップしてください。

大規模なプレゼンテーションでは、カスタム セーバーが各アーティファクトを直接アプリケーション ストレージに永続化することで、全エクスポートの追加コピーをメモリに保持せずに済みます。エクスポーターは依然としてすべての生成アーティファクトをメモリに集めてからセーバーを呼び出します。エクスポーターの観点からは各コールバックを同期的に扱い、バイトが宛先に受け入れられた後にのみ戻り、失敗を呼び出し元に伝搬させてください。

### **リソース名を保持し、参照を検証する**

- 宛先が要求する場合はパス区切り文字を正規化しつつ、相対ディレクトリーは保持してください。すべての生成名が一意でリソース参照が有効であると確信できない限り、[Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) のみは使用しないでください。
- 宛先固有の名前検証を適用します。緩いファイルを書き込む場合は、ルート パスや上位ディレクトリ参照を除外し、[Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) で宛先を解決し、エクスポート ディレクトリ以下に収まっていることを確認してください。シンボリック リンクが書き込み先をリダイレクトしないよう、アプリケーション制御のディレクトリを使用してください。
- 各エクスポート ジョブごとに別々のセーバーとストレージ 名前空間を使用します。区切り文字正規化後および宛先の大小文字区別規則に従って衝突を検出してください。
- 発行前に各 XAML ドキュメントを XML として解析し、`Source` や `ImageSource` 属性などのファイルベースのリソース参照を検査してください。各相対 URI を含む XAML アーティファクトのディレクトリーに対して解決し、結果のストレージ名を正規化して、対応する辞書キー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI と XAML マークアップ式は相対ファイル名とは別に扱ってください。

例として、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能でなければなりません。`image1.png` のみを保存すると関係が壊れます。オブジェクト ストレージの場合はジョブ プレフィックス配下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマがアクセスできるようにしてください。完了した ZIP を再度開き、エントリ名とリソース バイトを検証し、対象 XAML 環境で代表的なスライドをロードして画像が正しく解決されることを確認してください。

## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/) の [DefaultRegularFont](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveoptions/defaultregularfont/) を設定します。エクスポート時に元のフォントが見つからないときのフォールバック フォントとして使用されます。ただし、生成された XAML が必ずフォールバック フォントを参照するか、対象マシンにフォントが存在することを保証するものではありません。XAML が参照するフォントが表示環境に存在することを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか？他の XAML スタックでも使用できますか？**

Aspose.Slides はパブリック API を通じて WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms など他の XAML スタックとの互換性は保証されません。対象環境で生成されたマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。[ExportHiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) を使用してこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。