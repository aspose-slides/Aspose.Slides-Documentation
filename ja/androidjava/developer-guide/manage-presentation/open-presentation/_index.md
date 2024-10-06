---
title: Javaでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/androidjava/open-presentation/
keywords: "PowerPointを開く, PPTX, PPT, プレゼンテーションを開く, プレゼンテーションを読み込む, Java"
description: "Javaでプレゼンテーション PPT、PPTX、ODPを開くまたは読み込む"
---

ゼロからPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slidesを使用すると、既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、その情報を取得したり、プレゼンテーションを編集したり（スライド上のコンテンツ）、新しいスライドを追加したり、既存のスライドを削除したりすることができます。

## プレゼンテーションを開く

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスをインスタンス化し、開きたいプレゼンテーションのファイルパスをそのコンストラクタに渡すだけです。

このJavaコードは、プレゼンテーションを開く方法と、その中に含まれるスライドの数を取得する方法を示しています：

```java
// Presentationクラスをインスタンス化し、ファイルパスをコンストラクタに渡します
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに含まれるスライドの総数を出力します
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/)クラスの[Password](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getPassword--)プロパティを通じてパスワードを渡して、プレゼンテーションを復号化して読み込むことができます。このJavaコードは、その操作を示しています：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");
Presentation pres = new Presentation("pres.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションでいくつかの作業を行います
} finally {
    if (pres != null) pres.dispose();
}
```

## 大きなプレゼンテーションを開く

Aspose.Slidesは、[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/LoadOptions)クラスの下に、巨大なプレゼンテーションをロードするためのオプションを提供しています（特に[BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-)プロパティ）。

このJavaは、大きなプレゼンテーション（たとえば、サイズが2GB）のロード操作を示します：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
    // 大きなプレゼンテーションがロードされ、使用可能ですが、メモリ消費はまだ低いです。
    // プレゼンテーションに変更を加えます。
    pres.getSlides().get_Item(0).setName("非常に大きなプレゼンテーション");

    // プレゼンテーションは別のファイルに保存されます。操作中のメモリ消費は低いままです
    pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="情報" %}}

ストリームと対話する際の特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む際には、ストリームではなく、プレゼンテーションのファイルパスを使用することを強くお勧めします。

大きなオブジェクト（ビデオ、オーディオ、大きな画像など）を含むプレゼンテーションを作成したい場合は、[Blob機能](https://docs.aspose.com/slides/androidjava/manage-blob/)を使用してメモリ消費を削減できます。

{{%/alert %}} 

## プレゼンテーションを読み込む

Aspose.Slidesは、外部リソースを管理するための単一メソッドを持つ[IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/)を提供しています。このJavaコードは、`IResourceLoadingCallback`インターフェースを使用する方法を示しています：

```java
LoadOptions opts = new LoadOptions();
opts.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation pres = new Presentation("presentation.pptx", opts);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback 
{
    public int resourceLoading(IResourceLoadingArgs args) 
    {
        if (args.getOriginalUri().endsWith(".jpg")) 
        {
            try // 代替画像を読み込みます
            {
                byte[] imageBytes = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 代替URLを設定します
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 他のすべての画像をスキップします
        return ResourceLoadingAction.Skip;
    }
}
```

## 埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む

PowerPointプレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれている可能性があります：

- VBAプロジェクト ([IPresentation.VbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/vbaproject/));
- OLEオブジェクト埋め込みデータ ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveXコントロールのバイナリデータ ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--));

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)プロパティを使用すると、埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを削除するのに役立ちます。

以下は、マルウェアのない状態でプレゼンテーションを読み込み、保存する方法を示すコードです：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation pres = new Presentation("malware.ppt", loadOptions);
try {
    pres.save("clean.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーションを開いて保存する

プレゼンテーションを開いて保存する手順：

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスのインスタンスを作成し、開きたいファイルを渡します。
2. プレゼンテーションを保存します。

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化します
Presentation pres = new Presentation();
try {
    // ...ここでいくつかの作業を行います...
    
    // プレゼンテーションをファイルに保存します
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```