---
title: Android でのプレゼンテーションの開き方
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
description: "Aspose.Slides for Android を Java で使用し、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを手軽に開きます—高速、信頼性が高く、機能が充実しています。"
---

## **概要**

最初から PowerPoint プレゼンテーションを作成するだけでなく、Aspose.Slides では既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他様々な操作が可能です。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスのインスタンスを作成し、コンストラクタにファイル パスを渡します。

以下の Java の例は、プレゼンテーションを開きスライド数を取得する方法を示しています：
```java
// Presentation クラスのインスタンスを生成し、そのコンストラクタにファイル パスを渡します。
Presentation presentation = new Presentation("Sample.pptx");
try {
    // プレゼンテーション内のスライド総数を出力します。
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **パスワードで保護されたプレゼンテーションを開く**

パスワードで保護されたプレゼンテーションを開く必要がある場合、[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) クラスの [setPassword](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) メソッドでパスワードを指定して復号し、読み込みます。以下の Java コードがこの操作を示しています：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // 復号化されたプレゼンテーションに対して操作を実行します。
} finally {
    presentation.dispose();
}
```


## **大容量プレゼンテーションを開く**

Aspose.Slides は、特に [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) クラスの [getBlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) メソッドなどのオプションを提供し、大容量のプレゼンテーションの読み込みを支援します。

以下の Java コードは、大容量プレゼンテーション（例: 2 GB）を読み込む方法を示しています：
```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// KeepLocked 動作を選択します—プレゼンテーション ファイルはその存続期間中ロックされたままです。
// the Presentation インスタンスですが、メモリに読み込む必要も一時ファイルにコピーする必要もありません。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // 大容量のプレゼンテーションが読み込まれ、使用可能です。メモリ使用量は低く抑えられます。

    // プレゼンテーションに変更を加えます。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ使用量は低く保たれます。
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // これを実行しないでください！ファイルはプレゼンテーション オブジェクトが破棄されるまでロックされているため、I/O 例外がスローされます。
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// ここで実行しても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによるロックが解除されています。
Files.delete(Paths.get(filePath));
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量のプレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。したがって、大容量のプレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーションのファイル パスを使用することを強く推奨します。

動画、音声、高解像度画像などの大きなオブジェクトを含むプレゼンテーションを作成する場合、[BLOB management](/slides/ja/androidjava/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下の Java コードは `IResourceLoadingCallback` インターフェイスの使用方法を示しています：
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
                // 代替画像を読み込む。
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // 任意の方法でバイトを取得します
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


## **埋め込みバイナリ オブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリ オブジェクトが含まれる場合があります。

- VBA プロジェクト（[IPresentation.getVbaProject](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getVbaProject--) で取得可能）；
- OLE オブジェクトの埋め込みデータ（[IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) で取得可能）；
- ActiveX コントロールのバイナリ データ（[IControl.getActiveXControlBinary](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--) で取得可能）。

[ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) メソッドを使用すると、埋め込みバイナリ オブジェクトを一切含まない状態でプレゼンテーションを読み込むことができます。

このメソッドは、潜在的に悪意のあるバイナリ コンテンツを除去するのに有用です。以下の Java コードは、埋め込みバイナリ コンテンツなしでプレゼンテーションを読み込む方法を示しています：
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // プレゼンテーションに対して操作を実行します。
} finally {
    presentation.dispose();
}
```


## **FAQ**

**ファイルが破損していて開けないことはどのように判断できますか？**

読み込み時にパース/フォーマット検証例外がスローされます。このようなエラーは、ZIP 構造が無効である、または PowerPoint のレコードが破損していることを示すことが多いです。

**開く際に必須フォントが欠如している場合はどうなりますか？**

ファイルは開かれますが、後続の [rendering/export](/slides/ja/androidjava/convert-presentation/) 時にフォントが置き換えられる可能性があります。ランタイム環境に [フォント置換の構成](/slides/ja/androidjava/font-substitution/) を行うか、[必要なフォントを追加](/slides/ja/androidjava/custom-font/)してください。

**開く際に埋め込みメディア（動画/音声）はどう扱われますか？**

これらはプレゼンテーションのリソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。そうでないと、[rendering/export](/slides/ja/androidjava/convert-presentation/) 時にメディアが省略される可能性があります。