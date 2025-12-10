---
title: Javaでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint (.pptx, .ppt) および OpenDocument (.odp) プレゼンテーションを手軽に開く—高速で信頼性が高く、機能が充実しています。"
---

## **概要**

ゼロからPowerPointプレゼンテーションを作成するだけでなく、Aspose.Slidesは既存のプレゼンテーションを開くことも可能です。プレゼンテーションをロードした後は、情報の取得、スライド内容の編集、新しいスライドの追加、既存スライドの削除などが行えます。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

次の Java サンプルは、プレゼンテーションを開いてスライド数を取得する方法を示しています。
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


## **パスワード保護されたプレゼンテーションのオープン**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) クラスの [setPassword](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) メソッドでパスワードを渡して復号し、ロードします。次の Java コードがこの操作を示しています。
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


## **大容量プレゼンテーションのオープン**

Aspose.Slides は、特に [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) クラスの [getBlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) メソッドなどのオプションを提供し、大容量プレゼンテーションのロードを支援します。

次の Java コードは、大容量プレゼンテーション（例: 2 GB）をロードする方法を示しています。
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked 動作を選択します—プレゼンテーション ファイルはインスタンスの存続期間中ロックされたままになりますが
// Presentation インスタンスですが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // 大容量のプレゼンテーションがロードされ、使用可能です。メモリ使用量は低く抑えられます。

    // プレゼンテーションを変更します。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く抑えられます。
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これを行わないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// ここで実行しても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによってロックされていません。
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="情報" %}}
ストリームで作業する際の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロードが遅くなる可能性があります。したがって、大容量プレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

大きなオブジェクト（ビデオ、オーディオ、高解像度画像など）を含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/java/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。次の Java コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。
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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 代替 URL を設定します。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // 他のすべての画像をスキップします。
        return ResourceLoadingAction.Skip;
    }
}
```


## **埋め込みバイナリオブジェクトなしでのプレゼンテーションのロード**

PowerPoint プレゼンテーションには、以下の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[IPresentation.getVbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getVbaProject--) でアクセス可能）;
- OLE 埋め込みデータ（[IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[IControl.getActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) でアクセス可能）。

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) メソッドを使用すると、埋め込みバイナリオブジェクトを一切含まない状態でプレゼンテーションをロードできます。

このメソッドは、潜在的に悪意のあるバイナリコンテンツを除去する際に有用です。次の Java コードは、埋め込みバイナリコンテンツなしでプレゼンテーションをロードする方法を示しています。
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // プレゼンテーションで操作を実行します。
} finally {
    presentation.dispose();
}
```


## **FAQ**

**ファイルが破損していて開けないことをどのように判断できますか？**

ロード時にパース/フォーマット検証例外が発生します。このエラーは、無効な ZIP 構造や破損した PowerPoint レコードに言及することが多いです。

**開く際に必須フォントが欠落している場合はどうなりますか？**

ファイルは開きますが、後の[レンダリング/エクスポート](/slides/ja/java/convert-presentation/)でフォントが置き換えられる可能性があります。[フォント置換の構成](/slides/ja/java/font-substitution/)または[必須フォントの追加](/slides/ja/java/custom-font/)をランタイム環境に行ってください。

**開く際の埋め込みメディア（ビデオ/オーディオ）はどう扱われますか？**

メディアはプレゼンテーションリソースとして利用可能になります。メディアが外部パスで参照されている場合、そのパスが環境でアクセス可能であることを確認してください。そうでないと[レンダリング/エクスポート](/slides/ja/java/convert-presentation/)でメディアが省略されることがあります。