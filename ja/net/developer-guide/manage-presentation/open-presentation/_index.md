---
title: ".NET でプレゼンテーションを開く"
linktitle: "プレゼンテーションを開く"
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
description: "Aspose.Slides for .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを手軽に開く—高速、信頼性が高く、フル機能。"
---

## **概要**

最初から PowerPoint プレゼンテーションを作成するだけでなく、Aspose.Slides では既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後は、情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのインスタンスを作成し、コンストラクタにファイル パスを渡します。

次の C# の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```cs
// Presentation クラスをインスタンス化し、コンストラクタにファイルパスを渡します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // プレゼンテーションのスライド総数を出力します。
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) プロパティにパスワードを設定して復号し、読み込みます。次の C# コードがこの操作を示しています。
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションに対して操作を実行します。
}
```


## **大容量プレゼンテーションを開く**

Aspose.Slides では、特に [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) プロパティを使用して、大容量プレゼンテーションの読み込みを支援するオプションが用意されています。

次の C# コードは、大容量プレゼンテーション（例: 2 GB）を読み込む方法を示しています。
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked 動作を選択します—プレゼンテーション ファイルは Presentation インスタンスの存続期間中ロックされたままになりますが、
        // メモリに読み込んだり一時ファイルにコピーしたりする必要はありません。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 大容量のプレゼンテーションが読み込まれ、使用できますが、メモリ使用量は低く抑えられます。

    // プレゼンテーションを変更します。
    presentation.Slides[0].Name = "Large presentation";

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く抑えられます。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これをしないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    File.Delete(filePath);
}

// ここで実行しても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによってロックされなくなっています。
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の一部の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。そのため、大容量プレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーション ファイル パスの使用を強く推奨します。

大きなオブジェクト（動画、音声、高解像度画像など）を含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/net/manage-blob/) を使用してメモリ使用量を削減できます。
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

        // 他のすべての画像をスキップします。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリ オブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、以下の種類の埋め込みバイナリ オブジェクトが含まれることがあります。

- VBA プロジェクト（[IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) でアクセス可能）;
- ActiveX コントロール バイナリ データ（[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/) でアクセス可能）。

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) プロパティを使用すると、埋め込みバイナリ オブジェクトを含まない状態でプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に危険なバイナリ コンテンツを除去する際に便利です。次の C# コードは、埋め込みバイナリ コンテンツなしでプレゼンテーションを読み込む方法を示しています。
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

**ファイルが破損していて開けないことを検知するにはどうすればよいですか？**

読み込み時にパース/フォーマット検証例外がスローされます。この種のエラーは、ZIP 構造が無効であるか PowerPoint レコードが破損していることを示すことが多いです。

**開く際に必須フォントが欠落している場合はどうなりますか？**

ファイルは開きますが、後の[レンダリング/エクスポート](/slides/ja/net/convert-presentation/)時にフォントが置き換えられる可能性があります。[フォント置換の構成](/slides/ja/net/font-substitution/)または[必須フォントの追加](/slides/ja/net/custom-font/)を実行環境に行ってください。

**開く際の埋め込みメディア（動画/音声）についてはどうなりますか？**

メディアはプレゼンテーション リソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。アクセスできない場合、[レンダリング/エクスポート](/slides/ja/net/convert-presentation/)でメディアが省略されることがあります。