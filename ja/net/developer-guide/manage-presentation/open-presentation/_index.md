---
title: .NET でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/net/open-presentation/
keywords:
- PowerPoint を開く
- プレゼンテーションを開く
- PPTX を開く
- PPT を開く
- ODP を開く
- プレゼンテーションを読み込む
- PPTX を読み込む
- PPT を読み込む
- ODP を読み込む
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- .NET
- C#
- Aspose.Slides
description: "C# で PowerPoint および OpenDocument プレゼンテーションを開く方法、開くためのパスワードを指定する方法、リソース読み込みを制御する方法、そして Aspose.Slides for .NET を使用したメモリ使用量の削減方法を学びます。"
---
## **はじめに**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ja/net/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションが読み込まれた後は、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポート形式で保存したりできます。

読み込みの動作は、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) クラスを使用してカスタマイズできます。たとえば、開くためのパスワードを指定したり、大きなバイナリオブジェクトを管理メモリ外に保持したり、外部リソースを制御したり、埋め込みバイナリ データを省略したりできます。

## **プレゼンテーションを開く**

ファイルまたはストリームを読み込んだ後、[元のプレゼンテーション形式を判別する](/slides/ja/net/detect-presentation-source-format/)ことで、アプリケーションがそれをどのように処理するかを選択できます。

既存のプレゼンテーションを開くには、そのファイル パスを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドルや一時データ、その他のリソースが速やかに解放されるようにします。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **パスワードで保護されたプレゼンテーションを開く**

開くためのパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) に設定し、オプションを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) コンストラクタに渡します。パスワードが不足または誤っている場合、読み込みは失敗します。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

パスワード検出、検証、暗号化のワークフローについては、[Password‑Protect Presentations](/slides/ja/net/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメント プロパティとともに保存されている場合、パスワードなしでそれらのプロパティを読み取ることができます。詳しくは [Manage Presentation Properties](/slides/ja/net/presentation-properties/) をご覧ください。

## **大容量プレゼンテーションを開く**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/blobmanagementoptions/) は、画像、音声、ビデオなどのバイナリ 大規模オブジェクト (BLOB) を Aspose.Slides がどのように処理するかを制御します。ソース ファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

以下の C# コードは、大きなプレゼンテーション（例として 2 GB）を読み込む方法を示しています：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
`PresentationLockingBehavior.KeepLocked` を使用すると、`Presentation` オブジェクトが破棄されるまでソース ファイルはロックされたままになります。そのオブジェクトが存続している間は、ソース ファイルを移動、上書き、削除しないでください。

Aspose.Slides は読み込み時に入力ストリームの内容をコピーすることがあります。大きなプレゼンテーションの場合、ファイル パスの方が一般にストリームよりも効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/net/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースを制御する**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/resourceloadingcallback/) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iresourceloadingcallback/) の実装を受け付けます。コールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。これは、プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージ ルールに従って解決する必要がある場合に便利です。

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **埋め込みバイナリ オブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが不要または保持したくない埋め込みバイナリ データが含まれることがあります。例としては：

- VBA プロジェクトは、[IPresentation.VbaProject](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/vbaproject/) で利用できます；
- 埋め込み OLE データは、[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) で利用できます；
- ActiveX コントロール データは、[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ja/net/aspose.slides/icontrol/activexcontrolbinary/) で利用できます。

[LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) を `true` に設定すると、読み込み時にこのバイナリ データが削除されます。サニタイズされた結果を保持するために、読み込んだプレゼンテーションを保存します。

このオプションは不要な埋め込みペイロードへの露出を減らしますが、完全なマルウェア検出やコンテンツサニタイズ システムではありません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **FAQ**

**ファイルが破損していて開けないことはどう判断できますか？**

Aspose.Slides は読み込み中に解析エラーまたは形式エラーの例外をスローします。この失敗をパスワードが正しくないエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにします。

**必要なフォントが見つからない場合はどうなりますか？**

プレゼンテーションは依然として読み込めますが、レンダリングやエクスポート時にフォントが置き換えられる可能性があります。出力をより予測可能にするために、[フォント置換を構成する](/slides/ja/net/font-substitution/)か、[カスタム フォントを提供する](/slides/ja/net/custom-font/)ことができます。

**プレゼンテーションの読み込みは埋め込みメディアも読み込みますか？**

埋め込みの音声や動画は、プレゼンテーション オブジェクト モデルを通じて利用可能になります。外部リソースは設定されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。