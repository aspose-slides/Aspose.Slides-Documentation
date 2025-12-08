---
title: C#でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/net/open-presentation/
keywords:
- PowerPointを開く
- プレゼンテーションを開く
- PPTXを開く
- PPTを開く
- ODPを開く
- プレゼンテーションを読み込む
- PPTXを読み込む
- PPTを読み込む
- ODPを読み込む
- 保護されたプレゼンテーション
- 大きなプレゼンテーション
- 外部リソース
- バイナリオブジェクト
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを簡単に開く—高速、信頼性が高く、機能が豊富です。"
---

## **概要**

ゼロからPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slidesは既存のプレゼンテーションを開くこともできます。プレゼンテーションをロードした後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他さまざまな操作が可能です。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、ファイルパスをコンストラクタに渡します。

次のC#の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```cs
// Presentation クラスのインスタンスを作成し、コンストラクタにファイル パスを渡します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // プレゼンテーション内のスライド総数を出力します。
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) プロパティにパスワードを渡して復号し、ロードします。次のC#コードはこの操作を示しています。
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションで操作を実行します。
}
```


## **大きなプレゼンテーションを開く**

Aspose.Slidesは、大きなプレゼンテーションをロードするためのオプションを提供します。特に、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) プロパティが役立ちます。

次のC#コードは、大きなプレゼンテーション（例: 2 GB）をロードする方法を示しています。
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked 動作を選択します—プレゼンテーション ファイルはインスタンスの存続期間中ロックされたままです。
        // ただし、メモリにロードしたり一時ファイルにコピーする必要はありません。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 大きなプレゼンテーションがロードされ、使用可能です。メモリ使用量は低く抑えられます。

    // プレゼンテーションを変更します。
    presentation.Slides[0].Name = "Large presentation";

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く抑えられます。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これを行わないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    File.Delete(filePath);
}

// ここで実行しても問題ありません。プレゼンテーションオブジェクトによるロックが解除されているため、ソースファイルはロックされていません。
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際のいくつかの制限を回避するために、Aspose.Slidesはストリームの内容をコピーすることがあります。ストリームから大きなプレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロードが遅くなる可能性があります。したがって、大きなプレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

大きなオブジェクト（ビデオ、オーディオ、高解像度画像など）を含むプレゼンテーションを作成する場合は、メモリ使用量を削減するために [BLOB management](/slides/ja/net/manage-blob/) を使用できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slidesは、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。次のC#コードは `IResourceLoadingCallback` インターフェイスの使用方法を示しています。
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
                // 代替画像を読み込む。
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
            // 代替 URL を設定する。
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // 他のすべての画像をスキップする。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

PowerPointプレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれることがあります：

- VBAプロジェクト（[IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/) でアクセス可能）;
- OLEオブジェクトの埋め込みデータ（[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) でアクセス可能）;
- ActiveXコントロールのバイナリデータ（[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/) でアクセス可能）。

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) プロパティを使用すると、埋め込みバイナリオブジェクトがないプレゼンテーションをロードできます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを除去するのに役立ちます。次のC#コードは、埋め込みバイナリコンテンツなしでプレゼンテーションをロードする方法を示しています。
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

**ファイルが破損していて開けないことはどう判断できますか？**

ロード時にパース/フォーマット検証例外がスローされます。この種のエラーは、ZIP構造が無効であるか、PowerPointのレコードが壊れていることを示すことが多いです。

**開く際に必要なフォントが欠落している場合はどうなりますか？**

ファイルは開かれますが、後の [rendering/export](/slides/ja/net/convert-presentation/) 時にフォントが置き換えられる可能性があります。ランタイム環境に [フォント置換の構成](/slides/ja/net/font-substitution/) または [必要なフォントの追加](/slides/ja/net/custom-font/) を行ってください。

**開く際の埋め込みメディア（ビデオ/オーディオ）はどう扱われますか？**

それらはプレゼンテーションのリソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。そうでない場合、[rendering/export](/slides/ja/net/convert-presentation/) でメディアが省略される可能性があります。