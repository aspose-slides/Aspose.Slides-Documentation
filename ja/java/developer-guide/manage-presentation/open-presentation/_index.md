---
title: Java でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Java で PowerPoint および OpenDocument プレゼンテーションを開く方法、オープン パスワードの指定、リソース読み込みの制御、そして Aspose.Slides for Java を使用したメモリ使用量の削減方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Java](https://products.aspose.com/slides/ja/java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションをロードできます。プレゼンテーションがロードされた後は、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポートされている形式で保存したりできます。

ロード動作は [LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) クラスでカスタマイズできます。たとえば、開く際のパスワードを指定したり、大きなバイナリオブジェクトを Java ヒープメモリの外部に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションを開く**

ファイルまたはストリームをロードした後、[元のプレゼンテーション形式を判別](/slides/ja/java/detect-presentation-source-format/) して、アプリケーションがどのように処理するかを選択できます。

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにします。

次の Java の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **パスワード保護されたプレゼンテーションを開く**

オープン パスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションをロードするには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) に渡し、そのオプションを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コンストラクタに提供します。パスワードが未設定または誤っている場合、ロードは失敗します。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

パスワードの検出、検証、暗号化ワークフローについては、[パスワード保護されたプレゼンテーション](/slides/ja/java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが公開ドキュメントプロパティとともに意図的に保存された場合、パスワードなしでこれらのプロパティを読み取ることができます；[プレゼンテーション プロパティの管理](/slides/ja/java/presentation-properties/) を参照してください。

## **大容量プレゼンテーションを開く**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) は、画像、音声、動画などのバイナリ大規模オブジェクト (BLOB) を Aspose.Slides がどのように処理するかを制御するオプションを返します。ソースファイルをロックしたままにしたり、テンポラリファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

次の Java コードは、大容量のプレゼンテーション（例: 2 GB）をロードする方法を示しています。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーション インスタンスが破棄されるまでソースファイルはロックされたままになります。そのインスタンスが存続している間、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides はロード時に入力ストリームの内容をコピーすることがあります。大容量プレゼンテーションの場合、ファイルパスの方がストリームよりも一般的に効率的です。追加のストレージおよびメモリ管理オプションについては、[BLOB の管理](/slides/ja/java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iresourceloadingcallback/) 実装を受け取ります。コールバックは代替データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。これは、プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティまたはストレージルールに従って解決する必要がある場合に便利です。

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロードする**

プレゼンテーションには、アプリケーションが必要としない、または保持したくない埋め込みバイナリデータが含まれることがあります。例としては、以下があります：

- VBA プロジェクトは、[IPresentation.getVbaProject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getVbaProject--) で取得できます；
- 埋め込み OLE データは、[IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) で取得できます；
- ActiveX コントロールデータは、[IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) で取得できます。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) を `true` に設定すると、ロード時にこのバイナリデータが削除されます。ロードされたプレゼンテーションを保存して、サニタイズされた結果を永続化してください。

このオプションは不要な埋め込みペイロードへの曝露を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**ファイルが破損していて開けないことはどうやって判断できますか？**

Aspose.Slides はロード中に解析エラーまたはフォーマット例外をスローします。この失敗をパスワードが間違っているエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが欠落している場合はどうなりますか？**

プレゼンテーションは仍ロードできますが、レンダリングやエクスポート時にフォントが置換されることがあります。出力をより予測可能にするために、[フォント置換の設定](/slides/ja/java/font-substitution/) または [カスタムフォントの提供](/slides/ja/java/custom-font/) を行うことができます。

**プレゼンテーションをロードすると埋め込みメディアもロードされますか？**

埋め込みの音声や動画はプレゼンテーション オブジェクト モデルを通じて利用可能になります。外部リソースは設定されたリソースロード動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。