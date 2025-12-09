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
- プレゼンテーションをロード
- PPTX をロード
- PPT をロード
- ODP をロード
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを手軽に開く—高速、信頼性が高く、完全な機能を備えています。"
---

## **概要**

最初からPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slidesでは既存のプレゼンテーションを開くこともできます。プレゼンテーションをロードした後は、情報の取得、スライド内容の編集、新しいスライドの追加、既存スライドの削除などが可能です。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

以下の C# の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```cs
// Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // プレゼンテーションのスライド総数を出力します。
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) プロパティにパスワードを設定して復号・ロードします。以下の C# コードがこの操作を示しています。
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 復号化されたプレゼンテーションに対して操作を実行します。
}
```


## **大容量プレゼンテーションを開く**

Aspose.Slides では、特に [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) クラスの [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) プロパティを使用して、大容量のプレゼンテーションの読み込みを支援するオプションが用意されています。

以下の C# コードは、たとえば 2 GB の大容量プレゼンテーションをロードする例です。
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // KeepLocked 動作を選択します—プレゼンテーションファイルはインスタンスの存続期間中ロックされたままになります
        // Presentation インスタンスがロックされたままですが、メモリに読み込んだり一時ファイルにコピーしたりする必要はありません。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 大容量のプレゼンテーションが読み込まれ、使用可能です。メモリ使用量は低く抑えられます。

    // プレゼンテーションを変更します。
    presentation.Slides[0].Name = "Large presentation";

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く保たれます。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これをしないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    File.Delete(filePath);
}

// ここで実行しても問題ありません。ソースファイルはプレゼンテーションオブジェクトによりロックされていません。
File.Delete(filePath);
```


{{% alert color="info" title="情報" %}}
ストリームで作業する際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロード速度が低下する可能性があります。したがって、大容量プレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強くお勧めします。

大きなオブジェクト（動画、音声、高解像度画像など）を含むプレゼンテーションを作成する際は、[BLOB 管理](/slides/ja/net/manage-blob/) を利用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下の C# コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。
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

        // その他の画像はすべてスキップする。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/) でアクセス可能）;
- OLE 埋め込みデータ（[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/) でアクセス可能）。

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) プロパティを使用すると、埋め込みバイナリオブジェクトを含まない状態でプレゼンテーションをロードできます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを除去する際に便利です。以下の C# コードは、埋め込みバイナリコンテンツなしでプレゼンテーションをロードする方法を示しています。
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

**ファイルが破損していて開けないことをどのように判断できますか？**

ロード中にパース/フォーマット検証例外が発生します。この種のエラーは、無効な ZIP 構造や壊れた PowerPoint レコードに言及することが多いです。

**開く際に必須フォントが欠如している場合はどうなりますか？**

ファイルは開きますが、後の [レンダリング/エクスポート](/slides/ja/net/convert-presentation/) 時にフォントが代替される可能性があります。ランタイム環境に [フォント置換を構成](/slides/ja/net/font-substitution/) するか、必要なフォントを [追加](/slides/ja/net/custom-font/)してください。

**開く際の埋め込みメディア（動画/音声）についてはどうですか？**

メディアはプレゼンテーションリソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。そうでない場合、[レンダリング/エクスポート](/slides/ja/net/convert-presentation/) 時にメディアが省略されることがあります。