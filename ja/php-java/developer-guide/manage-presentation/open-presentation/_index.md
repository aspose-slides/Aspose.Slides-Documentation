---
title: PHPでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "PHPでPowerPointおよびOpenDocumentプレゼンテーションを開く方法、開くパスワードを提供する方法、リソースの読み込みを制御する方法、そしてAspose.Slides for PHP via Java を使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ja/php-java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションを読み込んだ後は、構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされている形式で保存したりできます。

読み込みの動作は [LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) クラスでカスタマイズできます。たとえば、開くパスワードを指定したり、巨大なバイナリオブジェクトを Java ヒープメモリ外に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにします。

以下の PHP の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **パスワードで保護されたプレゼンテーションのオープン**

開くパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) に渡し、そのオプションを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コンストラクタに提供します。パスワードが欠如しているか誤っている場合、読み込みは失敗します。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-presentation.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

パスワードの検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/php-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティと共に保存されている場合、パスワードなしでこれらのプロパティを読むことができます。詳細は [Manage Presentation Properties](/slides/ja/php-java/presentation-properties/) を参照してください。

## **大容量プレゼンテーションのオープン**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリ大規模オブジェクト（BLOB）を Aspose.Slides がどのように処理するかを制御するオプションを返します。ソースファイルをロックしたままにしたり、一時ファイルの使用を許可したり、メモリに保持する BLOB データ量を制限したりできます。

以下の PHP コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む例です。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationLockingBehavior;
use aspose\slides\SaveFormat;

$filePath = "large-presentation.pptx";

$loadOptions = new LoadOptions();
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024);

$presentation = new Presentation($filePath, $loadOptions);
try {
    $presentation->getSlides()->get_Item(0)->setName("Large presentation");
    $presentation->save("large-presentation-copy.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}

[PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルはロックされたままです。そのインスタンスが存続している間は、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides は読み込み時に入力ストリームの内容をコピーすることがあります。大容量プレゼンテーションの場合、ストリームよりもファイルパスの方が一般的に効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/php-java/manage-blob/) を参照してください。

{{% /alert %}}

## **外部リソースの制御**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、PHP/Java Bridge を通じて Java の [IResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iresourceloadingcallback/) インタフェースの実装を受け取ります。コールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。これは、プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージルールに従って解決する必要がある場合に便利です。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ResourceLoadingAction;

class ImageLoadingHandler {
    function resourceLoading($args) {
        $originalUri = strtolower(java_values($args->getOriginalUri()));
        $approvedImagePath = "approved-image.jpg";
        $isJpeg = substr($originalUri, -4) === ".jpg";

        if (!$isJpeg || !file_exists($approvedImagePath)) {
            return ResourceLoadingAction::Skip;
        }

        $imageData = file_get_contents($approvedImagePath);
        if ($imageData === false) {
            echo("The approved replacement image could not be read.\n");
            return ResourceLoadingAction::Skip;
        }

        $args->setData(java_values($imageData));
        return ResourceLoadingAction::UserProvided;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("presentation-with-external-images.pptx", $loadOptions);
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれることがあります。例としては次のものがあります。

- [Presentation::getVbaProject](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getVbaProject) で取得できる VBA プロジェクト;
- [OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得できる埋め込み OLE データ;
- [Control::getActiveXControlBinary](https://reference.aspose.com/slides/ja/php-java/aspose.slides/control/#getActiveXControlBinary) で取得できる ActiveX コントロールデータ。

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `true` に設定すると、読み込み時にこれらのバイナリデータが削除されます。サニタイズされた結果を永続化するには、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの露出を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("presentation-with-embedded-data.pptx", $loadOptions);
try {
    $presentation->save("presentation-without-embedded-data.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**ファイルが破損していて開けないことをどう判別すればよいですか？**

Aspose.Slides は読み込み中にパース例外または形式例外をスローします。パスワードが間違っているエラーとは別にこの失敗をハンドルし、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが欠如している場合はどうなりますか？**

プレゼンテーションは依然として読み込まれますが、レンダリングおよびエクスポート時にフォントが置き換えられることがあります。出力を予測可能にするために、[フォント置換の構成](/slides/ja/php-java/font-substitution/) または [カスタムフォントの提供](/slides/ja/php-java/custom-font/) を行ってください。

**プレゼンテーションの読み込みは埋め込みメディアも読み込みますか？**

埋め込みの音声や動画はプレゼンテーションオブジェクトモデルを通じて利用可能になります。外部リソースは設定されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。