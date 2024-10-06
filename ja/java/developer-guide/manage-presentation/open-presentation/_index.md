---
title: Javaでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/java/open-presentation/
keywords: "PowerPointを開く, PPTX, PPT, プレゼンテーションを開く, プレゼンテーションを読み込む, Java"
description: "JavaでプレゼンテーションPPT、PPTX、ODPを開くまたは読み込む"
---

ゼロからPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slidesを使用して既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、プレゼンテーションに関する情報を取得したり、プレゼンテーション（スライドの内容）を編集したり、新しいスライドを追加したり、既存のスライドを削除したりすることができます。

## プレゼンテーションを開く

既存のプレゼンテーションを開くには、まず[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)クラスのインスタンスを作成し、そのコンストラクターにファイルパス（開きたいプレゼンテーションの）を渡します。

このJavaコードは、プレゼンテーションを開き、その中に含まれるスライドの数を取得する方法を示しています：

```java
// Presentationクラスのインスタンスを作成し、ファイルパスをコンストラクターに渡す
Presentation pres = new Presentation("Presentation.pptx");
try {
    // プレゼンテーションに存在するスライドの合計数を印刷します
    System.out.println(pres.getSlides().size());
} finally {
    if (pres != null) pres.dispose();
}
```

## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/)クラスの[Password](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getPassword--)プロパティを通じてパスワードを渡すことで、プレゼンテーションを復号化し、読み込むことができます。このJavaコードはその操作を示しています：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");
Presentation pres = new Presentation("pres.pptx", loadOptions);
try {
// 復号化されたプレゼンテーションで作業を行う
} finally {
    if (pres != null) pres.dispose();
}
```

## 大きなプレゼンテーションを開く

Aspose.Slidesは、大きなプレゼンテーションを読み込むために、[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/LoadOptions)クラスの[BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-)プロパティを特に利用してオプションを提供しています。

このJavaコードは、2GBサイズの大きなプレゼンテーションを読み込む操作を示しています：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(0L);

Presentation pres = new Presentation("veryLargePresentation.pptx", loadOptions);
try {
// 大きなプレゼンテーションが読み込まれ、使用できるが、メモリ消費は依然として低い。
// プレゼンテーションを変更します。
pres.getSlides().get_Item(0).setName("非常に大きなプレゼンテーション");

// プレゼンテーションは別のファイルに保存されます。操作中のメモリ消費は低いままです
pres.save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```

{{% alert color="info" title="情報" %}}

ストリームとやりとりする際の特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーする場合があります。ストリームを通じて大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、ロードが遅くなります。したがって、大きなプレゼンテーションを読み込むつもりの場合は、ストリームではなくプレゼンテーションファイルのパスを使用することを強くお勧めします。

大きなオブジェクト（ビデオ、オーディオ、大きな画像など）を含むプレゼンテーションを作成したい場合は、メモリ消費を削減するために[Blob機能](https://docs.aspose.com/slides/java/manage-blob/)を使用できます。

{{%/alert %}} 

## プレゼンテーションを読み込む

Aspose.Slidesは、外部リソースを管理するための単一メソッドを持つ[IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/)を提供しています。このJavaコードは、`IResourceLoadingCallback`インターフェースを使用する方法を示しています：

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
            try // 代替画像を読み込む
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
            // 代替URLを設定する
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // その他の画像はすべてスキップ
        return ResourceLoadingAction.Skip;
    }
}
```

## 埋め込まれたバイナリオブジェクトなしでプレゼンテーションを読み込む

PowerPointプレゼンテーションは、次のタイプの埋め込まれたバイナリオブジェクトを含むことができます：

- VBAプロジェクト ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- OLEオブジェクト埋め込まれたデータ ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveXコントロールのバイナリデータ ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)プロパティを使用すると、埋め込まれたバイナリオブジェクトなしでプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを削除するのに役立ちます。

コードは、マルウェアコンテンツなしでプレゼンテーションを読み込んで保存する方法を示しています：

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

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)クラスのインスタンスを作成し、開きたいファイルを渡します。 
2. プレゼンテーションを保存します。  

```java
// PPTファイルを表すPresentationオブジェクトをインスタンス化する
Presentation pres = new Presentation();
try {
    // ...ここでいくつかの作業を行う...
    
    // プレゼンテーションをファイルに保存する
    pres.save("demoPass.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    if(pres != null) pres.dispose();
}
```