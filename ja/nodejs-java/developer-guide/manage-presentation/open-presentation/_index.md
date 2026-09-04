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
description: "JavaScript で PowerPoint と OpenDocument のプレゼンテーションを開く方法、開くためのパスワードを指定する方法、リソースの読み込みを制御する方法、そして Aspose.Slides for Node.js via Java を使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/ja/nodejs-java/) は、ファイルやストリームから PowerPoint および OpenDocument のプレゼンテーションをロードできます。プレゼンテーションをロードした後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされている形式で保存したりできます。

ロード動作は [LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) クラスでカスタマイズできます。たとえば、開くためのパスワードを指定したり、大きなバイナリオブジェクトを Node.js のメモリ外に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドルや一時データ、その他のリソースが速やかに解放されるようにします。

以下の JavaScript の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **パスワードで保護されたプレゼンテーションを開く**

開くためのパスワードはプレゼンテーションのコンテンツを暗号化します。完全なプレゼンテーションをロードするには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) コンストラクタに提供します。パスワードがないか誤っている場合、ロードは失敗します。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

パスワード検出、検証、暗号化のワークフローについては、[Password-Protect Presentations](/slides/ja/nodejs-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティとともに保存されている場合、パスワードなしでこれらのプロパティを読み取ることができます。[Manage Presentation Properties](/slides/ja/nodejs-java/presentation-properties/) を参照してください。

## **大きなプレゼンテーションを開く**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリ大規模オブジェクト（BLOB）を Aspose.Slides がどのように扱うかを制御するオプションを返します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データの量を制限したりできます。

以下の JavaScript コードは、大きなプレゼンテーション（例として 2 GB）をロードする方法を示しています。

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="注" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルがロックされたままになります。そのインスタンスが存続している間は、ソースファイルを移動、上書き、または削除しないでください。

Aspose.Slides はロード時に入力ストリームの内容をコピーすることがあります。大きなプレゼンテーションの場合、ファイルパスの方が通常はストリームよりも効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/nodejs-java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iresourceloadingcallback/) の実装を受け取ります。このコールバックは、置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。アプリケーション固有のセキュリティやストレージ規則に従って解決する必要がある外部画像を含むプレゼンテーションに便利です。

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれている場合があります。例としては、以下が挙げられます。

- VBA プロジェクト（[Presentation.getVbaProject](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getVbaProject) で取得可能）;
- 埋め込み OLE データ（[OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得可能）;
- ActiveX コントロールデータ（[Control.getActiveXControlBinary](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/control/#getActiveXControlBinary) で取得可能）。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `true` に設定すると、ロード中にこのバイナリデータを削除できます。サニタイズされた結果を保持するために、ロードしたプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**ファイルが破損していて開けないことはどうやって判断できますか？**

Aspose.Slides はロード中にパースエラーまたは形式例外をスローします。この失敗をパスワードが間違っているエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにします。

**必要なフォントが見つからない場合はどうなりますか？**

プレゼンテーションは依然としてロードできますが、レンダリングやエクスポート時にフォントが置き換えられることがあります。出力をより予測可能にするために、[configure font substitution](/slides/ja/nodejs-java/font-substitution/) または [provide custom fonts](/slides/ja/nodejs-java/custom-font/) を使用できます。

**プレゼンテーションのロード時に埋め込まれたメディアもロードされますか？**

埋め込みの音声および動画はプレゼンテーションのオブジェクトモデルを通じて利用可能になります。外部リソースは設定されたリソースロード動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。