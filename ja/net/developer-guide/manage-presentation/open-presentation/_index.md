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
- プレゼンテーションをロードする
- PPTX をロードする
- PPT をロードする
- ODP をロードする
- 保護されたプレゼンテーション
- 大きなプレゼンテーション
- 外部リソース
- バイナリオブジェクト
- .NET
- C#
- Aspose.Slides
description: "C# で PowerPoint および OpenDocument プレゼンテーションを開く方法、開く際のパスワードを指定する方法、リソースの読み込みを制御する方法、そして Aspose.Slides for .NET を使用したメモリ使用量の削減方法を学びます。"
---
## **導入**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ja/net/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションをロードできます。プレゼンテーションがロードされた後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または他のサポートされている形式で保存したりできます。

ロード動作は、[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) クラスを使用してカスタマイズできます。たとえば、開く際のパスワードを指定したり、大きなバイナリオブジェクトを管理メモリの外部に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄して、ファイルハンドルや一時データ、その他のリソースが速やかに解放されるようにします。

次の C# の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **パスワードで保護されたプレゼンテーションを開く**

開く際のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションをロードするには、正しいパスワードを [LoadOptions.Password](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/password/) に設定し、オプションを [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) コンストラクタに渡します。パスワードが無い、または正しくない場合、ロードは失敗します。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

パスワードの検出、検証、暗号化フローについては、[Password-Protect Presentations](/slides/ja/net/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開文書プロパティと共に保存されている場合、そのプロパティはパスワードなしで読み取れます；[Manage Presentation Properties](/slides/ja/net/presentation-properties/) を参照してください。

## **大きなプレゼンテーションを開く**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/blobmanagementoptions/) は、画像、音声、動画などのバイナリラージオブジェクト（BLOB）の Aspose.Slides における処理方法を制御します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持される BLOB データ量を制限したりできます。

次の C# コードは、大きなプレゼンテーション（例として 2 GB）をロードする方法を示しています。

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
`PresentationLockingBehavior.KeepLocked` を使用すると、`Presentation` オブジェクトが破棄されるまでソースファイルはロックされたままになります。オブジェクトが存続している間、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides はロード時に入力ストリームの内容をコピーすることがあります。大きなプレゼンテーションの場合、ファイルパスの方がストリームより一般的に効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/net/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/resourceloadingcallback/) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/net/aspose.slides/iresourceloadingcallback/) の実装を受け取ります。このコールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージルールに従って解決する必要がある場合に便利です。

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

## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれていることがあります。例としては以下があります。

- VBA プロジェクトは [IPresentation.VbaProject](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/vbaproject/) で取得できます；
- 埋め込み OLE データは [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/ja/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) で取得できます；
- ActiveX コントロールデータは [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/ja/net/aspose.slides/icontrol/activexcontrolbinary/) で取得できます。

[LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) を `true` に設定すると、ロード時にこのバイナリデータが削除されます。サニタイズされた結果を保持するために、ロードしたプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出またはコンテンツサニタイズシステムではありません。

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

## **よくある質問**

**ファイルが破損していて開けないことをどのように判断できますか？**

Aspose.Slides はロード時に解析エラーまたは形式エラーの例外をスローします。この失敗をパスワードが正しくないエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが見つからない場合はどうなりますか？**

プレゼンテーションはロードは可能ですが、レンダリングやエクスポート時にフォントが代替されることがあります。出力をより予測可能にするために、[フォント置換の構成](/slides/ja/net/font-substitution/) や [カスタムフォントの提供](/slides/ja/net/custom-font/) を使用できます。

**プレゼンテーションのロード時に埋め込みメディアもロードされますか？**

埋め込みの音声および動画はプレゼンテーションオブジェクトモデルを通じて利用可能になります。外部リソースは設定されたリソースロード動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。