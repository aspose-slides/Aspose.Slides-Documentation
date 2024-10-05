---
title: C#でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /net/open-presentation/
keywords: "PowerPointを開く, PPTX, PPT, プレゼンテーションを開く, プレゼンテーションを読み込む, C#, Csharp, .NET"
description: "C#または.NETでプレゼンテーションPPT、PPTX、ODPを開くまたは読み込む"
---

ゼロからPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slidesを使用すると、既存のプレゼンテーションを開くことができます。プレゼンテーションを読み込んだ後、プレゼンテーションに関する情報を取得したり（スライドの内容）、プレゼンテーションを編集したり、新しいスライドを追加したり、既存のスライドを削除したりすることができます。

## プレゼンテーションを開く

既存のプレゼンテーションを開くには、単に[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスをインスタンス化し、ファイルパス（開きたいプレゼンテーションへのパス）をそのコンストラクタに渡す必要があります。

このC#コードは、プレゼンテーションを開く方法と、スライドの数を調べる方法を示しています：

```c#
// Presentationクラスをインスタンス化し、ファイルパスをコンストラクタに渡します
Presentation pres = new Presentation("OpenPresentation.pptx");

// プレゼンテーションに含まれるスライドの総数を出力します
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)クラスの[Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/)プロパティを通じてパスワードを渡すことで、プレゼンテーションを復号化して読み込むことができます。このC#コードはその操作を示しています：

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // 復号化されたプレゼンテーションで作業を行う
	}
```

## 大きなプレゼンテーションを開く

Aspose.Slidesは、[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)クラスの下に、[BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/)プロパティなどのオプションを提供し、大きなプレゼンテーションを読み込むことができます。

このC#コードは、大きなプレゼンテーション（例えば2GBのサイズ）を読み込む操作を示します：

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // KeepLocked動作を選択します - "veryLargePresentation.pptx"は
        // プレゼンテーションインスタンスのライフタイムのためにロックされますが、メモリに
        // 読み込む必要はなく、一時ファイルにコピーする必要はありません
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // 大きなプレゼンテーションが読み込まれ、使用可能ですが、メモリ使用量は依然として低いです。

    // プレゼンテーションに変更を加えます。
    pres.Slides[0].Name = "非常に大きなプレゼンテーション";

    // プレゼンテーションは別のファイルに保存されます。 操作中のメモリ使用量は低いまま保たれます。
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // それはできません! IO例外がスローされます。なぜならファイルはロックされており、presオブジェクトは
    // 解放されません。
    File.Delete(pathToVeryLargePresentationFile);
}

// ここで行うのは問題ありません。ソースファイルはpresオブジェクトによってロックされていません。
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="情報" %}}

ストリームとのやり取りにおける特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む予定がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強くお勧めします。

大きなオブジェクト（ビデオ、音声、大きな画像など）を含むプレゼンテーションを作成する場合は、[Blob機能](https://docs.aspose.com/slides/net/manage-blob/)を使用してメモリ使用量を減らすことができます。

{{%/alert %}} 

## プレゼンテーションを読み込む
Aspose.Slidesは、外部リソースを管理するために単一のメソッドを持つ[IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/)を提供します。このC#コードは、`IResourceLoadingCallback`インターフェースを使用する方法を示しています：

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // 代替画像をロードします
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // 代替URLを設定します
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // その他の画像はすべてスキップします
        return ResourceLoadingAction.Skip;
    }
}
```

## 埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む

PowerPointプレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれる場合があります：

- VBAプロジェクト ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- OLEオブジェクト埋め込みデータ ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveXコントロールバイナリデータ ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/)プロパティを使用すると、埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを削除するのに役立ちます。

このC#コードは、悪意のあるコンテンツなしでプレゼンテーションを読み込んで保存する方法を示しています：

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>プレゼンテーションを開いて保存する</h2>

<a name="csharp-open-save-presentation"><strong>手順: C#でプレゼンテーションを開いて保存する</strong></a>

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスを作成し、開きたいファイルを渡します。
2. プレゼンテーションを保存します。

```c#
// サポートされている任意のプレゼンテーションを読み込みます。例えばppt、pptx、odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```