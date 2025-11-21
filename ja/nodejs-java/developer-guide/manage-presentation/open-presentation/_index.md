---
title: JavaScript でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを簡単に開くことができます—高速で信頼性が高く、フル機能を備えています。"
---

## **概要**

ゼロから PowerPoint プレゼンテーションを作成するだけでなく、Aspose.Slides では既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後は、情報の取得、スライド内容の編集、新規スライドの追加、既存スライドの削除などが行えます。

## **プレゼンテーションの開封**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

以下の JavaScript サンプルは、プレゼンテーションを開いてスライド数を取得する方法を示しています:
```js
// Presentation クラスをインスタンス化し、コンストラクタにファイルパスを渡します。
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // プレゼンテーションの総スライド数を出力します。
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```


## **パスワード保護されたプレゼンテーションの開封**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) クラスの [setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setPassword) メソッドでパスワードを指定して復号・読み込みます。以下の JavaScript コードがこの操作を示しています:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // 復号されたプレゼンテーションに対して操作を実行します。
} finally {
    presentation.dispose();
}
```


## **大容量プレゼンテーションの開封**

Aspose.Slides では、特に [LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) クラスの [getBlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) メソッドなど、サイズの大きいプレゼンテーションを読み込むためのオプションが提供されています。

以下の JavaScript コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む方法を示しています:
```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// KeepLocked 動作を選択します—プレゼンテーション ファイルはインスタンスの存続期間中ロックされたままになります
// プレゼンテーション インスタンスですが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // 大容量のプレゼンテーションが読み込まれ、使用可能です。メモリ消費は低く抑えられます。
    
    // プレゼンテーションに変更を加えます。
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // プレゼンテーションを別ファイルに保存します。この操作中もメモリ消費は低く保たれます。
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // これを実行しないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// ここで実行しても問題ありません。ソースファイルはプレゼンテーションオブジェクトによってロックされていません。
fs.unlinkSync(filePath);
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の一部制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーション全体がコピーされ、読み込み速度が低下する可能性があります。そのため、大容量プレゼンテーションを読み込む場合は、ストリームではなくファイルパスを使用することを強く推奨します。

動画、音声、高解像度画像などの大きなオブジェクトを含むプレゼンテーションを作成する際は、[BLOB 管理](/slides/ja/nodejs-java/manage-blob/) を利用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースの管理を可能にする [IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/) インターフェイスを提供しています。以下の JavaScript コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています:
```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // 代替画像をロードします。
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // 代替URLを設定します。
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // 他のすべての画像をスキップします。
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```


## **埋め込みバイナリオブジェクトなしでのプレゼンテーションの読み込み**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[Presentation.getVbaProject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getVbaProject) で取得可能）
- OLE 埋め込みデータ（[OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得可能）
- ActiveX コントロールのバイナリデータ（[Control.getActiveXControlBinary](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getActiveXControlBinary) で取得可能）

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) メソッドを使用すると、埋め込みバイナリオブジェクトを一切含まない状態でプレゼンテーションを読み込むことができます。

このメソッドは、潜在的に悪意のあるバイナリコンテンツを除去する際に有用です。以下の JavaScript コードは、埋め込みバイナリコンテンツを持たないプレゼンテーションを読み込む方法を示しています:
```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // プレゼンテーションに対して操作を実行します。
} finally {
    presentation.dispose();
}
```


## **FAQ**

**ファイルが破損していて開けないことはどう判断すればよいですか？**

読み込み時に解析/フォーマット検証例外がスローされます。エラーはしばしば ZIP 構造の破損や PowerPoint レコードの破損を指摘します。

**開く際に必須フォントが欠如しているとどうなりますか？**

ファイルは開くことができますが、後続の [レンダリング/エクスポート](/slides/ja/nodejs-java/convert-presentation/) 時にフォントが代替される可能性があります。ランタイム環境にフォント代替を構成するか、必須フォントを追加してください（[フォント代替の構成](/slides/ja/nodejs-java/font-substitution/) / [カスタムフォントの追加](/slides/ja/nodejs-java/custom-font/)）。

**開く際の埋め込みメディア（動画/音声）はどう扱われますか？**

メディアはプレゼンテーションリソースとして利用可能になります。外部パスで参照されているメディアの場合、環境でそのパスにアクセスできることを確認してください。アクセスできない場合、[レンダリング/エクスポート](/slides/ja/nodejs-java/convert-presentation/) 時にメディアが省かれる可能性があります。