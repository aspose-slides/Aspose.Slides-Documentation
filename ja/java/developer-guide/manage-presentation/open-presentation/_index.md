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
description: "Java で PowerPoint および OpenDocument プレゼンテーションを開く方法、開くためのパスワードを設定する方法、リソースの読み込みを制御する方法、そして Aspose.Slides for Java を使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Java](https://products.aspose.com/slides/ja/java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションが読み込まれた後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または別のサポート形式で保存したりできます。

読み込み動作は [LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) クラスを使用してカスタマイズできます。たとえば、開くためのパスワードを指定したり、巨大なバイナリオブジェクトを Java ヒープメモリ外に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにしてください。

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

## **パスワード保護されたプレゼンテーションのオープン**

開くためのパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) コンストラクタに提供します。パスワードが不足または間違っている場合、読み込みは失敗します。

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

パスワードの検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティと共に保存されている場合、パスワードなしでこれらのプロパティを読み取ることができます。詳細は [Manage Presentation Properties](/slides/ja/java/presentation-properties/) をご覧ください。

## **大容量プレゼンテーションのオープン**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) は、画像、音声、動画などのバイナリ大規模オブジェクト（BLOB）を Aspose.Slides がどのように扱うかを制御するオプションを返します。ソースファイルをロックしたままにしたり、一時ファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

次の Java コードは、大容量プレゼンテーション（例: 2 GB）を読み込む方法を示しています。

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
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルはロックされたままです。そのインスタンスが存続している間は、ソースファイルを移動、上書き、または削除しないでください。

Aspose.Slides は読み込み時に入力ストリームの内容をコピーすることがあります。大容量プレゼンテーションの場合、ストリームよりもファイルパスを使用した方が一般的に効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) は、[IResourceLoadingCallback](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iresourceloadingcallback/) の実装を受け取ります。このコールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージルールに従って解決する必要がある場合に便利です。

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

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが不要または保持したくない埋め込みバイナリデータが含まれることがあります。例としては以下があります。

- VBA プロジェクト（[IPresentation.getVbaProject](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ipresentation/#getVbaProject--) で取得可能）;
- 埋め込み OLE データ（[IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--) で取得可能）;
- ActiveX コントロールデータ（[IControl.getActiveXControlBinary](https://reference.aspose.com/slides/ja/java/com.aspose.slides/icontrol/#getActiveXControlBinary--) で取得可能）。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) を `true` に設定すると、読み込み時にこれらのバイナリデータが削除されます。サニタイズされた結果を永続化するには、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの露出を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

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

## **FAQ**

**ファイルが破損していて開けないことをどのように判断できますか？**

Aspose.Slides はロード時にパース例外またはフォーマット例外をスローします。パスワードが間違っているエラーとは別にこの失敗を処理し、原因を正確に報告できるようにしてください。

**必要なフォントが欠落している場合はどうなりますか？**

プレゼンテーションはまだロードできますが、レンダリングやエクスポート時にフォントが置き換えられることがあります。[フォント置換の構成](/slides/ja/java/font-substitution/) または [カスタムフォントの提供](/slides/ja/java/custom-font/) を行うことで、出力をより予測可能にできます。

**プレゼンテーションをロードすると埋め込みメディアもロードされますか？**

埋め込みの音声や動画はプレゼンテーションオブジェクトモデルを通じて利用可能になります。外部リソースは構成されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できません。