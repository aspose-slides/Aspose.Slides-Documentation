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
description: "JavaScript で PowerPoint および OpenDocument プレゼンテーションを開く方法、開く際のパスワードの指定、リソース読み込みの制御、そして Aspose.Slides for Node.js via Java を使用したメモリ使用量の削減方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/ja/nodejs-java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションが読み込まれた後、その構造を調査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされている形式で保存したりできます。

読み込み動作は、[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) クラスを通じてカスタマイズできます。たとえば、開く際のパスワードを指定したり、大きなバイナリオブジェクトを Node.js のメモリ外に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

ファイルまたはストリームを読み込んだ後、[元のプレゼンテーション形式を判別](/slides/ja/nodejs-java/detect-presentation-source-format/) して、アプリケーションがどのように処理するかを選択できます。

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) コンストラクタに渡します。使用後にプレゼンテーションを破棄して、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにしてください。

次の JavaScript の例は、プレゼンテーションを開き、スライド数を取得する方法を示しています。

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

開く際のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setPassword) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) コンストラクタに提供します。パスワードが欠如しているか正しくない場合、読み込みは失敗します。

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

パスワードの検出、検証、および暗号化フローについては、[Password-Protect Presentations](/slides/ja/nodejs-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティと共に保存されている場合、そのプロパティはパスワードなしで読み取ることができます。詳しくは [Manage Presentation Properties](/slides/ja/nodejs-java/presentation-properties/) をご覧ください。

## **大容量プレゼンテーションを開く**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリラージオブジェクト（BLOB）の扱いを制御するオプションを返します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データの量を制限したりできます。

次の JavaScript コードは、大容量のプレゼンテーション（例: 2 GB）を読み込む方法を示しています。

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

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルはロックされたままになります。そのインスタンスが存在する間、ソースファイルを移動、上書き、または削除しないでください。

Aspose.Slides は、読み込み中に入力ストリームの内容をコピーすることがあります。大容量のプレゼンテーションの場合、ファイルパスの方が一般的にストリームよりも効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/nodejs-java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースを制御する**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iresourceloadingcallback/) 実装を受け取ります。コールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。アプリケーション固有のセキュリティやストレージ規則に従って外部画像を解決する必要がある場合に便利です。

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

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれることがあります。例としては、

- VBA プロジェクトは、[Presentation.getVbaProject](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#getVbaProject) で取得できます。
- 埋め込み OLE データは、[OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得できます。
- ActiveX コントロールデータは、[Control.getActiveXControlBinary](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/control/#getActiveXControlBinary) で取得できます。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `true` に設定すると、読み込み時にこのバイナリデータが削除されます。サニタイズされた結果を保持するために、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの露出を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

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

## **FAQ**

**ファイルが破損していて開けないことはどうやって判断できますか？**

Aspose.Slides は読み込み中にパースエラーまたはフォーマット例外をスローします。この失敗は、パスワードが正しくないエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが欠如している場合はどうなりますか？**

プレゼンテーションは依然として読み込むことができますが、レンダリングやエクスポート時にフォントが代替されることがあります。出力をより予測可能にするために、[フォント置換の構成](/slides/ja/nodejs-java/font-substitution/) または [カスタムフォントの提供](/slides/ja/nodejs-java/custom-font/) を実行できます。

**プレゼンテーションを読み込むと、埋め込みメディアも読み込まれますか？**

埋め込みの音声および動画は、プレゼンテーションのオブジェクトモデルを通じて利用可能になります。外部リソースは、設定されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。