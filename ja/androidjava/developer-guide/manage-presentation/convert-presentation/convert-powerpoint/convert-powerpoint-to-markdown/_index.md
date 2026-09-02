---
title: Android で PowerPoint プレゼンテーションを Markdown に変換
linktitle: PowerPoint から Markdown へ
type: docs
weight: 140
url: /ja/androidjava/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- Markdown 画像エクスポート
- CDN 画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- Android
- Java
- Aspose.Slides
description: "Android で Java を使用して PPT および PPTX プレゼンテーションを Markdown に変換し、エクスポートされたビットマップ、メタファイル、SVG 画像の保存先と参照先を制御します。"
---
## **概要**

Aspose.Slides for Android via Java は、PPT および PPTX プレゼンテーションを Markdown に変換でき、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理ワークフローに利用できます。Markdown のフレーバーを選択し、スライドコンテンツのレンダリング方法を制御し、エクスポートされた画像の保存先と生成された Markdown が画像を参照する方法を決定できます。

デフォルトでは、Markdown エクスポートはテキストのみの出力を使用します。ビジュアルコンテンツをエクスポートするには、[MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) メソッドでエクスポートタイプを [MarkdownExportType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownexporttype/) 列挙体の `Sequential` または `Visual` 値に設定します。`Sequential` はスライド項目を個別かつ順番通りにレンダリングし、`Visual` はグループ化された項目を一緒に保持して視覚的関係を保ちます。`TextOnly` 値は画像リソースを出力しないため、そのモードでは画像保存コールバックは呼び出されません。

## **プレゼンテーションを Markdown に変換する**

[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスでソースファイルをロードし、次に [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) メソッドを呼び出して、[SaveFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/) 列挙体の `Md` 値を指定します。

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Markdown フレーバーを選択する**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) メソッドは出力に使用される Markdown の仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされているバリアントが含まれます。

次の例はプレゼンテーションを CommonMark としてエクスポートします。

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **デフォルトのローカル保存動作を使用して画像をエクスポートする**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) クラスは、ローカルに保存される画像を構成するための 2 つのメソッドを提供します。

- [setBasePath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) は、Markdown ドキュメントとそのリソースのベースディレクトリを指定します。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) は画像のサブディレクトリを指定します。既定値は `Images` です。

次の例はビジュアルコンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対画像参照を作成します。

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

この動作は、カスタム画像保存ハンドラが `false` を返した場合のフォールバックとしても機能します。

## **画像保存と Markdown リンクをカスタマイズする**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) メソッドを使用して、Markdown エクスポート中に出力される非 SVG ビットマップおよびメタファイルリソースのコールバックを登録します。その `MarkdownImageSavingHandler` コールバックは、[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) オブジェクト、その [ImageFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/) 値、そして生成された Markdown リンクを 1 要素の `String[]` パラメータとして受け取ります。提供された形式で画像を保存またはアップロードし、`link[0]` を Markdown 出力に表示すべき参照に置き換えます。

SVG 形式で出力されるリソースは別途処理されます。[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) メソッドでコールバックを登録します。その `MarkdownSvgImageSavingHandler` コールバックは、[ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) オブジェクトと 1 要素の `String[] link` パラメータを受け取ります。SVG には `ImageFormat` 引数がないため、代わりに [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) メソッドから XML データを書き込むかアップロードします。エクスポートモードとビジュアルのグルーピングに応じて、元のプレゼンテーション内の SVG がラスタライズされたり他のコンテンツと結合されたりすることがあり、結果として得られる非 SVG リソースが画像保存コールバックに渡されます。すべてのエクスポートされたビジュアルリソースがカスタム処理を必要とする場合は、両方のコールバックを登録してください。

ハンドラの戻り値は、画像を処理する主体を決定します。

- `true` を返すと、ハンドラが画像を保存、アップロード、変換、またはその他の方法で処理し、`link[0]` に有効な値を設定したことを示します。Aspose.Slides はその値を書き込み、デフォルトのローカル保存は行いません。
- `false` を返すと、Aspose.Slides が画像をローカルに保存し、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) で設定された値に従ってリンクを生成します。

{{% alert color="warning" title="Important" %}}
`true` を返すハンドラは画像の責任を負います。有効で空でないリンクを割り当てずに `true` を返すと、`InvalidOperationException` がスローされ、エクスポートが失敗します。
{{% /alert %}}

### **画像を CDN オリジンディレクトリに保存し、外部 URL を使用する**

次の例では、`cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジンディレクトリとして扱います。各ハンドラは生成されたファイル名を抽出し、画像をそのカスタムディレクトリに保存し、生成されたローカル参照をパブリック CDN URL に置き換えます。このサンプル自体はネットワークアップロードを行いません。URL はディレクトリが CDN オリジンとしてマウントされるか、ファイルが CDN に公開された後に有効になります。オブジェクトストレージを使用する場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後にのみ `link[0]` を割り当てます。

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

ビットマップハンドラは意図的に 128 × 128 ピクセル未満の画像に対して `false` を返すため、Aspose.Slides はそれらの画像を既定の動作で `output/fallback-images` に保存します。サイズが大きいビットマップやメタファイル、SVG リソースはカスタムコードで処理されます。例えば、`fallback-images/image1.png` という生成されたローカル参照は `https://cdn.example.com/presentations/quarterly-report/image1.png` に変換されます。ハンドラはファイルを書き込むときのみ OS のパスを使用し、Markdown に書き込まれるリンクはスラッシュ（/）と URL エスケープされたファイル名を使用します。相対リンクを構築する際も同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しないでください。

## **FAQ**

**ハンドラはラスタ画像と SVG 画像の両方を処理できますか？**

いいえ。出力されるビットマップおよびメタファイルリソースには [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) を、SVG として出力されるリソースには [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) を使用します。前者は [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/) 値を提供し、後者は SVG データを取得できる [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) オブジェクトを提供します。エクスポート中にラスタライズされたソース SVG は画像保存コールバックで処理されます。

**画像保存ハンドラが `false` を返した場合はどうなりますか？**

Aspose.Slides はデフォルトのローカル保存動作を使用します。画像の保存場所と生成された参照は、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/markdownsaveoptions/) で設定された値によって制御されます。

**ハンドラは画像をローカルに保存せずに URL を提供できますか？**

はい。ハンドラは画像をオブジェクトストレージにアップロードするか、別のサービスに渡し、得られた URL を `link[0]` に割り当てて `true` を返すことができます。ハンドラが処理を自ら完了し、`true` を返すとデフォルトのローカル保存は行われません。

**なぜ Markdown エクスポートがハンドラから `InvalidOperationException` をスローするのですか？**

この例外は、ハンドラが `true` を返したものの有効なリンクを提供しなかった場合に発生します。`true` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を割り当ててください。

**画像リンクはどのパス区切り文字を使用すべきですか？**

Markdown のリンクや URL ではスラッシュ（/）を使用してください。ファイルシステムパスの操作には `Path.resolve` を使用し、Markdown の参照は別途構築または正規化します。

**Markdown エクスポート時にハイパーリンクは保持されますか？**

はい。テキストの [hyperlinks](/slides/ja/androidjava/manage-hyperlinks/) は標準の Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/androidjava/slide-transition/) と [animations](/slides/ja/androidjava/powerpoint-animation/) は変換されません。

**プレゼンテーションを並列に Markdown に変換できますか？**

異なるプレゼンテーションファイルを並列に処理することは可能ですが、同じ [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。[multithreading guidelines](/slides/ja/androidjava/multithreading/) に従い、ファイルごとに別々のインスタンスを使用します。