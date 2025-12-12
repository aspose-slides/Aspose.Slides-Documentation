---
title: Android でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/androidjava/open-presentation/
keywords:
- PowerPoint を開く
- OpenDocument を開く
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを手軽に開くことができます—高速で信頼性が高く、機能が充実しています。"
---

## **概要**

PowerPoint プレゼンテーションをゼロから作成するだけでなく、Aspose.Slides は既存のプレゼンテーションを開くことも可能です。プレゼンテーションを読み込んだ後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他様々な操作ができます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

```java
// Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // プレゼンテーション内のスライド総数を出力します。
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) クラスの [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) メソッドにパスワードを渡して復号し、ロードします。以下の Java コードがこの操作を示しています。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションで操作を実行します。
} finally {
    presentation.dispose();
}
```


## **大容量プレゼンテーションを開く**

Aspose.Slides は、特に [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) クラスの [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) メソッドなど、大容量のプレゼンテーションを読み込むためのオプションを提供します。

以下の Java コードは、大容量プレゼンテーション（例えば 2 GB）を読み込む方法を示しています。

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked 動作を選択します—プレゼンテーション ファイルは存続期間中ロックされたままです
// Presentation インスタンスですが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // 大容量プレゼンテーションが読み込まれ、使用可能です。メモリ使用量は低いままです。

    // プレゼンテーションに変更を加えます。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く保たれます。
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これを実行しないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// ここで実行しても問題ありません。ソースファイルはプレゼンテーションオブジェクトによってロックされなくなっています。
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際のいくつかの制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量のプレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込み速度が低下する可能性があります。したがって、大容量のプレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

大きなオブジェクト（ビデオ、オーディオ、高解像度画像など）を含むプレゼンテーションを作成する際は、[BLOB management](/slides/ja/androidjava/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下の Java コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 代替画像をロードします。
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // 任意の方法でバイトを取得してください
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 代替URLを設定します。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 他のすべての画像をスキップします。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、以下の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) でアクセス可能）.

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) メソッドを使用すると、埋め込みバイナリオブジェクトを含まないプレゼンテーションを読み込むことができます。

このメソッドは、潜在的に悪意のあるバイナリコンテンツを除去するのに有用です。以下の Java コードは、埋め込みバイナリコンテンツを含まないプレゼンテーションの読み込み方法を示しています。

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // プレゼンテーションに対して操作を行います。
} finally {
    presentation.dispose();
}
```


## **よくある質問**

**ファイルが破損していて開けないことはどのように判断できますか？**

読み込み時に解析/形式検証例外がスローされます。このようなエラーは、無効な ZIP 構造や破損した PowerPoint レコードに言及することが多いです。

**開く際に必要なフォントが欠落している場合はどうなりますか？**

ファイルは開かれますが、後の[レンダリング/エクスポート](/slides/ja/androidjava/convert-presentation/)時にフォントが置き換えられる可能性があります。ランタイム環境に[フォント置き換えを構成](/slides/ja/androidjava/font-substitution/)するか、[必要なフォントを追加](/slides/ja/androidjava/custom-font/)してください。

**開く際の埋め込みメディア（動画/音声）はどうなりますか？**

それらはプレゼンテーションのリソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。そうでない場合、[レンダリング/エクスポート](/slides/ja/androidjava/convert-presentation/)でメディアが省略される可能性があります。