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
description: "Aspose.Slides for .NET を使用して、PowerPoint (.pptx, .ppt) および OpenDocument (.odp) プレゼンテーションを簡単に開くことができます—高速、信頼性が高く、機能が充実しています。"
---

## **概要**

PowerPointプレゼンテーションをゼロから作成するだけでなく、Aspose.Slidesは既存のプレゼンテーションを開くこともできます。プレゼンテーションをロードした後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他様々な操作が可能です。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

以下のC#例は、プレゼンテーションを開きスライド数を取得する方法を示しています。
```cs
// Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // プレゼンテーションのスライド総数を出力します。
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **パスワードで保護されたプレゼンテーションを開く**

パスワードで保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) プロパティにパスワードを設定して復号し、ロードします。以下のC#コードはこの操作を示しています。
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションで操作を実行します。
}
```


## **大容量プレゼンテーションを開く**

Aspose.Slidesは、大容量のプレゼンテーションをロードするためのオプションを提供します。特に、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) プロパティが役立ちます。

以下のC#コードは、大容量のプレゼンテーション（例：2 GB）をロードする方法を示しています。
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked 動作を選択します—プレゼンテーション ファイルはライフタイム中ロックされたままです
        // Presentation インスタンスですが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 大容量プレゼンテーションがロードされ、使用できます。メモリ消費は低く抑えられます。

    // プレゼンテーションを変更します。
    presentation.Slides[0].Name = "Large presentation";

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ消費は低く抑えられます。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これを行わないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    File.Delete(filePath);
}

// ここで実行しても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによるロックが解除されています。
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーすることがあります。ストリームから大容量のプレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロードが遅くなる可能性があります。したがって、大容量のプレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

ビデオ、オーディオ、高解像度画像などの大きなオブジェクトを含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/net/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slidesは、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下のC#コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // 代替画像を読み込みます。
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // 代替 URL を設定します。
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // それ以外のすべての画像をスキップします。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

PowerPoint プレゼンテーションは、次の種類の埋め込みバイナリオブジェクトを含むことがあります。

- VBA プロジェクト（[IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/) でアクセス可能）。

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) プロパティを使用すると、埋め込みバイナリオブジェクトがまったく含まれないプレゼンテーションをロードできます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを除去するのに便利です。以下のC#コードは、埋め込みバイナリコンテンツが全くないプレゼンテーションをロードする方法を示しています。
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // プレゼンテーションで操作を実行します。
}
```


## **FAQ**

**ファイルが破損していて開けないことをどのように判断できますか？**

ロード時に解析/形式検証例外が発生します。このようなエラーは、ZIP 構造が無効であるか、PowerPoint のレコードが壊れていることを示すことが多いです。

**開く際に必要なフォントが欠如している場合はどうなりますか？**

ファイルは開かれますが、その後の [レンダリング/エクスポート](/slides/ja/net/convert-presentation/) 時にフォントが置き換えられる可能性があります。ランタイム環境に [フォント置換の構成](/slides/ja/net/font-substitution/) を行うか、[必要なフォントを追加](/slides/ja/net/custom-font/)してください。

**開く際の埋め込みメディア（ビデオ/オーディオ）はどう扱われますか？**

それらはプレゼンテーションのリソースとして利用可能になります。メディアが外部パスで参照されている場合は、環境内でそのパスにアクセスできることを確認してください。そうでないと、[レンダリング/エクスポート](/slides/ja/net/convert-presentation/) 時にメディアが省略されることがあります。