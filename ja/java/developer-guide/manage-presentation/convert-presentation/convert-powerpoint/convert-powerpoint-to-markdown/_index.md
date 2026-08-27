---
title: JavaでPowerPointプレゼンテーションをMarkdownに変換する
linktitle: PowerPointからMarkdownへ
type: docs
weight: 140
url: /ja/java/convert-powerpoint-to-markdown/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTXを変換
- PowerPointをMDに変換
- プレゼンテーションをMDに変換
- スライドをMDに変換
- PPTをMDに変換
- PPTXをMDに変換
- PowerPointをMarkdownとして保存
- プレゼンテーションをMarkdownとして保存
- スライドをMarkdownとして保存
- PPTをMDとして保存
- PPTXをMDとして保存
- PPTをMDにエクスポート
- PPTXをMDにエクスポート
- Markdown画像エクスポート
- CDN画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- Java
- Aspose.Slides
description: "JavaでPPTおよびPPTXプレゼンテーションをMarkdownに変換し、エクスポートされたビットマップ、メタファイル、SVG画像の保存場所と参照先を制御します。"
---
## **概要**

Aspose.Slides for Java は PPT および PPTX プレゼンテーションを Markdown に変換でき、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理ワークフローで利用できます。Markdown のフレーバーを選択し、スライド コンテンツのレンダリング方法を制御し、エクスポートされた画像の保存場所と生成された Markdown がそれらを参照する方法を決定できます。

デフォルトでは、Markdown エクスポートはテキストのみの出力になります。ビジュアル コンテンツをエクスポートするには、[MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) メソッドでエクスポート タイプを [MarkdownExportType](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownexporttype/) 列挙体の `Sequential` または `Visual` 値に設定します。`Sequential` はスライド アイテムを個別かつ順番にレンダリングし、`Visual` はグループ化されたアイテムを一緒に保持して視覚的関係を保ちます。`TextOnly` 値は画像リソースを出力しないため、そのモードでは画像保存コールバックは呼び出されません。

## **プレゼンテーションを Markdown に変換する**

[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスでソース ファイルをロードし、次に [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) メソッドを呼び出して、[SaveFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/) 列挙体の `Md` 値を指定します。

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

## **Markdown フレーバーの選択**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) メソッドは出力に使用する Markdown 仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/java/com.aspose.slides/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされるバリアントが含まれます。

以下の例はプレゼンテーションを CommonMark としてエクスポートします。

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

## **デフォルトのローカル保存動作で画像をエクスポートする**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) クラスはローカルに保存される画像を構成するための 2 つのメソッドを提供します。

- [setBasePath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) は Markdown ドキュメントとそのリソースのベース ディレクトリを指定します。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) は画像サブディレクトリを指定します。既定値は `Images` です。

以下の例はビジュアル コンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対画像参照を作成します。

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

この動作はカスタム画像保存ハンドラが `false` を返した場合のフォールバックとしても機能します。

## **画像保存と Markdown リンクのカスタマイズ**

[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) メソッドを使用して、Markdown エクスポート中に出力される非 SVG ビットマップおよびメタファイル リソース用のコールバックを登録します。その `MarkdownImageSavingHandler` コールバックは [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) オブジェクト、[ImageFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) 値、および生成された Markdown リンクを 1 要素の `String[]` パラメーターとして受け取ります。提供されたフォーマットで画像を保存またはアップロードし、`link[0]` を Markdown 出力に記載すべき参照に置き換えます。

SVG 形式で出力されるリソースは別途扱われます。[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) メソッドでコールバックを登録してください。その `MarkdownSvgImageSavingHandler` は [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) オブジェクトと 1 要素の `String[] link` パラメーターを受け取ります。SVG には `ImageFormat` 引数がないため、代わりに [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) メソッドから XML データを書き込むかアップロードします。エクスポート モードやビジュアル グルーピングに応じて、元のプレゼンテーション内の SVG がラスタライズされたり他のコンテンツと結合されたりすることがあり、その結果得られた非 SVG リソースは画像保存コールバックに渡されます。すべてのエクスポートされたビジュアル リソースがカスタム処理を必要とする場合は、両方のコールバックを登録してください。

ハンドラの戻り値は画像を処理する側を決定します。

- ハンドラが画像を保存、アップロード、変換、またはその他の方法で処理し、`link[0]` に有効な値を設定した後に `true` を返します。Aspose.Slides はその値を Markdown ドキュメントに書き込み、既定のローカル保存は行いません。
- `false` を返すと、Aspose.Slides が画像をローカルに保存し、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) および [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) で設定された値に従ってリンクを生成します。

{{% alert color="warning" title="重要" %}}
`true` を返すハンドラは画像の責任を負います。`true` を返したにもかかわらず有効な非空リンクを割り当てない場合、エクスポートは `InvalidOperationException` で失敗します。
{{% /alert %}}

### **画像を CDN のオリジン ディレクトリに保存し、外部 URL を使用する**

以下の例は `cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジン ディレクトリとして扱います。各ハンドラは生成されたファイル名を取得し、画像をそのカスタム ディレクトリに保存し、生成されたローカル参照を公開 CDN URL に置き換えます。サンプル自体はネットワークアップロードを行いません。ディレクトリが CDN オリジンとしてマウントされるか、ファイルが CDN に公開された後にのみ URL が有効になります。オブジェクト ストレージの場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後にのみ `link[0]` を設定してください。

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

ビットマップ ハンドラは 128 × 128 ピクセル未満の画像に対して意図的に `false` を返すため、Aspose.Slides はそれらの画像を既定の動作で `output/fallback-images` に保存します。より大きなビットマップやメタファイル、SVG リソースはカスタム コードで処理されます。たとえば、生成されたローカル参照 `fallback-images/image1.png` は `https://cdn.example.com/presentations/quarterly-report/image1.png` に変換されます。ハンドラはファイルを書き込むときに OS 固有のパスを使用しますが、Markdown に書き込むリンクはスラッシュ `/` と URL エスケープされたファイル名を使用します。相対リンクを構築するときも同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しないでください。

## **FAQ**

**1つのハンドラでラスタ画像と SVG 画像の両方を処理できますか？**

いいえ。ビットマップおよびメタファイル リソースには [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) を、SVG として出力されるリソースには [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) を使用します。前者は [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides/imageformat/) 値を提供し、後者は [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) オブジェクトとその SVG データを取得できる [ISvgImage.getSvgData](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) メソッドを提供します。エクスポート中にラスタライズされたソース SVG は画像保存コールバックで処理されます。

**画像保存ハンドラが `false` を返した場合はどうなりますか？**

Aspose.Slides は既定のローカル保存動作を使用します。画像の保存場所と生成された参照は、[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) と [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/ja/java/com.aspose.slides/markdownsaveoptions/) で設定された値によって制御されます。

**ハンドラは画像をローカルに保存せずに URL を提供できますか？**

はい。ハンドラは画像をオブジェクト ストレージにアップロードするか別のサービスに渡し、生成された URL を `link[0]` に割り当てて `true` を返すことができます。ハンドラが自ら処理を完了し、`true` を返すと既定のローカル保存は行われません。

**なぜ Markdown エクスポートがハンドラから `InvalidOperationException` をスローするのですか？**

ハンドラが `true` を返したにもかかわらず有効なリンクを提供しなかったときにこの例外が発生します。`true` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を `link[0]` に設定してください。

**画像リンクはどのパス区切り文字を使用すべきですか？**

Markdown リンクおよび URL ではスラッシュ `/` を使用します。ファイルシステム パスを組み立てる場合は `Path.resolve` などを使用し、Markdown 参照は別途正規化してください。

**Markdown エクスポート時にハイパーリンクは保持されますか？**

はい。テキストの [hyperlinks](/slides/ja/java/manage-hyperlinks/) は標準的な Markdown リンクとして保持されます。スライドの [transitions](/slides/ja/java/slide-transition/) や [animations](/slides/ja/java/powerpoint-animation/) は変換されません。

**プレゼンテーションを並列に Markdown に変換できますか？**

異なるプレゼンテーション ファイルを並列に処理できますが、同じ [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスをスレッド間で共有しないでください。[multithreading guidelines](/slides/ja/java/multithreading/) に従い、ファイルごとに別々のインスタンスを使用してください。