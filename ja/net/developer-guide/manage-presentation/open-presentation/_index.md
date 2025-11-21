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
description: "Aspose.Slides for .NET を使用して、PowerPoint (.pptx, .ppt) および OpenDocument (.odp) プレゼンテーションを簡単に開くことができます—高速で信頼性が高く、機能が豊富です。"
---

## **概要**

PowerPoint プレゼンテーションをゼロから作成するだけでなく、Aspose.Slides は既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したりできます。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイル パスを渡します。

次の C# の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```cs
// Presentation クラスをインスタンス化し、コンストラクタにファイル パスを渡します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // プレゼンテーション内のスライド総数を表示します。
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **パスワード保護されたプレゼンテーションのオープン**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) プロパティにパスワードを設定して復号し、読み込みます。次の C# コードはこの操作を示しています。
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションに対して操作を実行します。
}
```


## **大容量プレゼンテーションのオープン**

Aspose.Slides は、特に [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) プロパティを使用して、大容量プレゼンテーションの読み込みを支援するオプションを提供します。

次の C# コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む方法を示しています。
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked 動作を選択します—プレゼンテーションファイルはインスタンス存続期間中ロックされたままになりますが、
        // プレゼンテーション インスタンスです。ただし、メモリにロードされたり一時ファイルへコピーされたりする必要はありません。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 大容量プレゼンテーションがロードされ、使用可能です。メモリ消費は低く抑えられます。

    // プレゼンテーションを変更します。
    presentation.Slides[0].Name = "Large presentation";

    // プレゼンテーションを別ファイルに保存します。この操作中もメモリ消費は低く抑えられます。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これをしないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    File.Delete(filePath);
}

// ここで行うのは問題ありません。ソース ファイルはプレゼンテーション オブジェクトによってロックされなくなっています。
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。したがって、大容量プレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーション ファイル パスの使用を強く推奨します。

大きなオブジェクト（動画、音声、高解像度画像など）を含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/net/manage-blob/) を利用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。次の C# コードは `IResourceLoadingCallback` インターフェイスの使用方法を示しています。
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
            // 代替URLを設定する。
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // 他のすべての画像をスキップする。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリ オブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリ オブジェクトが含まれることがあります。

- VBA プロジェクト（[IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/) でアクセス可能）;
- OLE 埋め込みデータ（[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) でアクセス可能）;
- ActiveX コントロール バイナリ データ（[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/) でアクセス可能）.

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) プロパティを使用すると、埋め込みバイナリ オブジェクトを含まない状態でプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に危険なバイナリ コンテンツを除去する際に有用です。次の C# コードは、埋め込みバイナリ コンテンツを含まないプレゼンテーションを読み込む方法を示しています。
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // プレゼンテーションに対して操作を実行します。
}
```


## **FAQ**

**ファイルが破損していて開けないことをどう判断できますか？**

読み込み時にパース/フォーマット検証例外がスローされます。このエラーは、無効な ZIP 構造や壊れた PowerPoint レコードに言及することが多いです。

**開く際に必要なフォントが欠落している場合はどうなりますか？**

ファイルは開かれますが、後の[レンダリング/エクスポート](/slides/ja/net/convert-presentation/)でフォントが置き換えられる可能性があります。ランタイム環境に[フォント置換を構成](/slides/ja/net/font-substitution/)するか、[必要なフォントを追加](/slides/ja/net/custom-font/)してください。

**開く際の埋め込みメディア（動画/音声）については？**

メディアはプレゼンテーション リソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。そうでないと、[レンダリング/エクスポート](/slides/ja/net/convert-presentation/)でメディアが省略されることがあります。