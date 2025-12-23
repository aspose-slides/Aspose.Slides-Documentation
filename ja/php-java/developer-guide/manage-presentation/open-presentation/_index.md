---
title: PHP でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/php-java/open-presentation/
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
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを手軽に開く — 高速で信頼性が高く、機能が充実しています。"
---

## **概要**

PowerPoint のプレゼンテーションをゼロから作成するだけでなく、Aspose.Slides では既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他さまざまな操作が可能です。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクタにファイルパスを渡します。

次の PHP の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています:
```php
// Presentation クラスをインスタンス化し、コンストラクタにファイルパスを渡します。
$presentation = new Presentation("Sample.pptx");
try {
    // プレゼンテーション内のスライド総数を出力します。
    echo($presentation->getSlides()->size());
} finally {
    $presentation->dispose();
}
```


## **パスワード保護されたプレゼンテーションのオープン**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) クラスの[setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setPassword)メソッドにパスワードを渡して復号し、読み込みます。以下の PHP コードがこの操作を示しています:
```php
$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$presentation = new Presentation("Sample.pptx", $loadOptions);
try {
    // 復号化されたプレゼンテーションに対して操作を実行します。
} finally {
    $presentation->dispose();
}
```


## **大容量プレゼンテーションのオープン**

Aspose.Slides では、特に[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) クラスの[getBlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getBlobManagementOptions)メソッドなど、大容量プレゼンテーションの読み込みを支援するオプションが用意されています。

次の PHP コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む例です:
```php
$filePath = "LargePresentation.pptx";

$loadOptions = new LoadOptions();
// KeepLocked 動作を選択します—プレゼンテーション ファイルは存続期間中ロックされたままです
// プレゼンテーション インスタンスですが、メモリに読み込んだり一時ファイルにコピーする必要はありません。
$loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
$loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
$loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

$presentation = new Presentation($filePath, $loadOptions);
try {
    // 大容量のプレゼンテーションが読み込まれ、使用できますが、メモリ消費は低く抑えられます。

    // プレゼンテーションを変更します。
    $presentation->getSlides()->get_Item(0)->setName("Very large presentation");

    // プレゼンテーションを別のファイルに保存します。この操作中もメモリ消費は低く抑えられます。
    $presentation->save("LargePresentation-copy.pptx", SaveFormat::Pptx);
	
	// これを実行しないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
	//unlink($filePath);
} finally {
    $presentation->dispose();
}
// ここで実行しても問題ありません。ソースファイルはプレゼンテーション オブジェクトによってロックされていません。
unlink($filePath);
```


{{% alert color="info" title="Info" %}}

ストリームを使用する際の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。したがって、大容量プレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

大きなオブジェクト（ビデオ、オーディオ、高解像度画像など）を含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/php-java/manage-blob/) を使用してメモリ消費を削減できます。

{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる[IResourceLoadingCallback](https://reference.aspose.com/slides/java/com.aspose.slides/iresourceloadingcallback/)インターフェイスを提供します。次の PHP コードは、`IResourceLoadingCallback`インターフェイスの使用方法を示しています:
```php
class ImageLoadingHandler {
    function resourceLoading($args) {
        if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
            // 代替画像をロードします。
			$bytes = file_get_contents("aspose-logo.jpg");
			$javaByteArray = java_values($bytes);
            $args->setData($javaByteArray);
            return ResourceLoadingAction::UserProvided;
        } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
            // 代替URLを設定します。
            $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }
        // 他のすべての画像をスキップします。
        return ResourceLoadingAction::Skip;
    }
}

$loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));

$loadOptions = new LoadOptions();
$loadOptions->setResourceLoadingCallback($loadingHandler);

$presentation = new Presentation("Sample.pptx", $loadOptions);
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト（[Presentation.getVbaProject](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getVbaProject) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[Control.getActiveXControlBinary](https://reference.aspose.com/slides/php-java/aspose.slides/control/#getActiveXControlBinary) でアクセス可能）。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects)メソッドを使用すると、埋め込みバイナリオブジェクトを一切含まない状態でプレゼンテーションを読み込むことができます。

このメソッドは、潜在的に悪意のあるバイナリコンテンツを除去する際に有用です。以下の PHP コードは、埋め込みバイナリコンテンツを含まないプレゼンテーションの読み込み方法を示しています:
```php
$loadOptions = new LoadOptions();
$loadOptions->setDeleteEmbeddedBinaryObjects(true);

$presentation = new Presentation("malware.ppt", $loadOptions);
try {
    // プレゼンテーションに対して操作を実行します。
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**ファイルが破損していて開けないことをどう判断できますか？**

読み込み中に解析/フォーマットの検証例外がスローされます。このようなエラーは、無効な ZIP 構造や壊れた PowerPoint レコードに言及することが多いです。

**開く際に必須フォントが欠落している場合はどうなりますか？**

ファイルは開かれますが、後の[レンダリング/エクスポート](/slides/ja/php-java/convert-presentation/)時にフォントが置き換えられる可能性があります。[フォント置換の構成](/slides/ja/php-java/font-substitution/)または[必須フォントの追加](/slides/ja/php-java/custom-font/)を実行環境に設定してください。

**開く際の埋め込みメディア（ビデオ/オーディオ）はどう扱われますか？**

メディアはプレゼンテーションリソースとして利用可能になります。メディアが外部パスで参照されている場合、そのパスが環境でアクセス可能であることを確認してください。そうでない場合、[レンダリング/エクスポート](/slides/ja/php-java/convert-presentation/)でメディアが省略されることがあります。