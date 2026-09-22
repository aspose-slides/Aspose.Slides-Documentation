---
title: PHPでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/php-java/open-presentation/
keywords:
- PowerPointを開く
- プレゼンテーションを開く
- PPTXを開く
- PPTを開く
- ODPを開く
- プレゼンテーションを読み込む
- PPTXを読み込む
- PPTを読み込む
- ODPを読み込む
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- PHP
- Aspose.Slides
description: "PHPでPowerPointおよびOpenDocumentプレゼンテーションを開く方法、オープン時のパスワードを提供する方法、リソース読み込みを制御する方法、そしてAspose.Slides for PHP via Javaを使用したメモリ使用量の削減方法を学びます。"
---
## **概要**

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/ja/php-java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションが読み込まれた後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされた形式で保存したりできます。

読み込み動作は、[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) クラスを使用してカスタマイズできます。たとえば、オープン時のパスワードを指定したり、大きなバイナリオブジェクトを Java ヒープメモリの外に保持したり、外部リソースを制御したり、埋め込まれたバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

ファイルまたはストリームを読み込んだ後、[元のプレゼンテーション形式を判別](/slides/ja/php-java/detect-presentation-source-format/) して、アプリケーションがどのように処理するか選択できます。

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにします。

次の PHP サンプルは、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    echo("Slide count: " . java_values($presentation->getSlides()->size()) . "\n");
} finally {
    $presentation->dispose();
}
```

## **パスワードで保護されたプレゼンテーションを開く**

オープン時のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) コンストラクタに提供します。パスワードが欠如しているか誤っている場合、読み込みは失敗します。

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

パスワード検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/php-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティと共に保存されている場合、パスワードなしでそのプロパティを読み取ることができます。詳細は [Manage Presentation Properties](/slides/ja/php-java/presentation-properties/) をご覧ください。

## **大容量プレゼンテーションを開く**

[LoadOptions::getBlobManagementOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリ ラージオブジェクト (BLOB) の取り扱いを制御するオプションを返します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

次の PHP コードは、大容量のプレゼンテーション（たとえば 2 GB）を読み込む例を示しています。

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
[PresentationLockingBehavior::KeepLocked](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルがロックされたままになります。そのインスタンスが存続している間、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides は、読み込み中に入力ストリームの内容をコピーすることがあります。大容量のプレゼンテーションでは、通常、ストリームよりもファイルパスの方が効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/php-java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions::setResourceLoadingCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、PHP/Java Bridge を介して Java の [IResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iresourceloadingcallback/) インターフェイスの実装を受け取ります。コールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。これは、プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティまたはストレージルールに従って解決する必要がある場合に有用です。

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

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれている場合があります。例としては、

- VBA プロジェクトは、[Presentation::getVbaProject](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getVbaProject) を使用して取得できます；
- 埋め込み OLE データは、[OleEmbeddedDataInfo::getEmbeddedFileData](https://reference.aspose.com/slides/ja/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) を使用して取得できます；
- ActiveX コントロールデータは、[Control::getActiveXControlBinary](https://reference.aspose.com/slides/ja/php-java/aspose.slides/control/#getActiveXControlBinary) を使用して取得できます。

[LoadOptions::setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `true` に設定すると、読み込み時にこのバイナリデータが削除されます。サニタイズされた結果を保持するために、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出やコンテンツサニタイズのシステムではありません。

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

## **よくある質問**

**ファイルが破損していて開けないことをどう判断できますか？**

Aspose.Slides は読み込み中にパース例外または形式例外をスローします。この失敗は、パスワードが間違っているエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにします。

**必要なフォントが欠如している場合はどうなりますか？**

プレゼンテーションは依然として読み込まれますが、レンダリングやエクスポート時にフォントが代替される可能性があります。出力をより予測可能にするために、[configure font substitution](/slides/ja/php-java/font-substitution/) または [provide custom fonts](/slides/ja/php-java/custom-font/) を使用できます。

**プレゼンテーションの読み込み時に埋め込みメディアも読み込まれますか？**

埋め込みの音声や動画はプレゼンテーションのオブジェクトモデルを通じて利用可能になります。外部リソースは設定されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。