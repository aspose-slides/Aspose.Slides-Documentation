---
title: HTMLへの外部リンク画像付きプレゼンテーションエクスポート
type: docs
weight: 100
url: /ja/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint のエクスポート
- OpenDocument のエクスポート
- プレゼンテーションのエクスポート
- スライドのエクスポート
- PPT のエクスポート
- PPTX のエクスポート
- ODP のエクスポート
- PowerPoint から HTML へ
- OpenDocument から HTML へ
- プレゼンテーションから HTML へ
- スライドから HTML へ
- PPT から HTML へ
- PPTX から HTML へ
- ODP から HTML へ
- リンク画像
- 外部リンク画像
- リンクリソース
- 外部リソース
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用し、画像やその他のリソースを外部リンクファイルとして保存しながら、PHP から Java 経由で PowerPoint および OpenDocument プレゼンテーションを HTML にエクスポートします。"
---
## **概要**

既定では、Aspose.Slides はプレゼンテーションを単一の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接書き込まれます。1つのポータブルなファイルが必要な場合には便利ですが、Web サイトや CMS、サーバー側の変換パイプラインにとって常に最適な形式とは限りません。

外部リンクされたリソースを使用したい場合は次のとおりです:

- HTML ドキュメントのサイズを削減する;
- 画像、フォント、音声、動画をブラウザーや CDN で個別にキャッシュする;
- エクスポート後に生成されたリソースを検査、置換、圧縮、またはポストプロセスする;
- 出力構造を Web アプリケーションが期待する形に近づける。

一般的な HTML 変換ワークフローについては、[Convert PowerPoint Presentations to HTML](/slides/ja/php-java/convert-powerpoint-to-html/) を参照してください。この記事はエクスポート時のリソースリンク部分に焦点を当てています。

## **リンクリソースエクスポートの仕組み**

[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) は、Aspose.Slides がプレゼンテーションを HTML にエクスポートする際に、カスタムのリンク/埋め込みコントローラーを使用できます。PHP から Java を介してこのシナリオは、通常小さな Java ヘルパークラスで実装されます。そのヘルパーをコンパイルし、PHP Java Bridge のクラスパスに追加し、PHP から `new Java(...)` でインスタンス化します。

ヘルパークラスはリソースごとに、エクスポーターがデータを HTML に埋め込むか外部に保存してリンクを書き込むかを判断します。3つのコールバックメソッドが必要です：

- `ExternalResourceController.getObjectStoringLocation` は、リソースをリンクするか埋め込むかを決定します。
- `ExternalResourceController.getUrl` は、生成された HTML または別のリンクリソースに書き込まれる URL を返します。
- `ExternalResourceController.saveExternal` は、リンクされたリソースのデータをディスクまたは別の保存先に書き込みます。

ファイルシステムのパスとブラウザーの URL は別々に考慮すべきです。たとえば、以下のサンプルではリソースファイルをディスク上の `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルを基準にこれらの URL を解決します。したがって、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、その SVG ファイルから同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` を使用します。

## **Javaヘルパークラスの作成**

`com.example.slides.ExternalResourceController` のような Java クラスを作成し、クラスパスに Aspose.Slides for Java を含めてコンパイルし、コンパイル済みクラスまたは JAR を PHP Java Bridge で利用できるようにします。

以下のヘルパーは、Aspose.Slides が安全なファイル拡張子を提供または推測できる場合に、一般的な画像、フォント、音声、動画、CSS リソースをリンクします。認識できないリソースは埋め込まれたままになります。

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **リンクリソース付きHTMLのエクスポート**

以下の PHP コードは出力ディレクトリを作成し、HTML ファイルをそこに保存し、リンクされたリソースを `assets` サブディレクトリに格納します。エクスポートには [HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/)、[SVGOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/)、[SlideImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideimageformat/)、[SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) を組み合わせています。

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

エクスポート後、出力フォルダーは以下の構成になります：

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、元のプレゼンテーションで使用されたものとは異なる画像コーデックを選択することがあり、結果としてサイズが小さくなるか、より適切なファイルになる場合があります。透過を含む画像は PNG としてエクスポートされます。

## **デプロイ時の URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

あるリンクリソースが別のリンクリソースを参照する場合、サンプルは `ExternalResourceController.getUrl` の `referrer` パラメーターを使用し、ファイル名のみを返します。例えば、`resource-1.svg` と `resource-4.jpg` が両方とも `assets` フォルダーにある場合、SVG ファイルは `assets/resource-4.jpg` ではなく `resource-4.jpg` を参照すべきです。

ファイルが別の場所にデプロイされる場合は、異なる URL プレフィックスを使用してください：

- `assets/` を使用します（アセットディレクトリが HTML ファイルと同じ場所にある場合）。
- `../assets/` を使用します（アセットディレクトリが HTML ファイルの 1 階層上にある場合）。
- `https://cdn.example.com/presentations/job-123/assets/` を使用します（ファイルが CDN や静的ファイルサーバーにアップロードされる場合）。

`ExternalResourceController.getUrl` が返す URL は、`ExternalResourceController.saveExternal` が書き込むファイルの最終的な配置先と一致する必要があります。サーバーアプリケーションでは、別のエクスポートによるファイル上書きを防ぐため、変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用してください。

## **埋め込みにすべき場合**

Base64 埋め込みの HTML は、出力が単一ファイルである必要がある場合（例えばメール添付、オフラインプレビュー、資産フォルダーなしで移動されるドキュメントなど）に依然として有用です。一方、HTML が Web アプリケーションで配信されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザーが HTML とは独立してキャッシュする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。`ExternalResourceController.getObjectStoringLocation` では、別ファイルとして保存したいコンテンツタイプに対してのみ [LinkEmbedDecision](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linkembeddecision/) の `Link` 値を返し、その他はすべて `Embed` 値を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は、HTML エクスポート時にサイズやブラウザー互換性を向上させるため、ラスタ画像を再エンコードすることがあります。例えば、元ファイルの画像がレンダー結果に応じて JPEG や PNG として書き込まれることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持されている場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残す必要があります。別の URL プレフィックスを生成しない限りです。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名の衝突を防ぎ、別のエクスポートが生成したリソースを上書きすることを防止できます。