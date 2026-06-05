---
title: 外部リンク画像でプレゼンテーションを HTML にエクスポート
type: docs
weight: 100
url: /ja/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- スライドをエクスポート
- PPT をエクスポート
- PPTX をエクスポート
- ODP をエクスポート
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
description: "Aspose.Slides を使用し、画像やその他のリソースを外部リンクファイルとして保存しながら、PHP（Java 経由）で PowerPoint および OpenDocument のプレゼンテーションを HTML にエクスポートします。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを自己完結型 HTML ファイルにエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接埋め込まれます。これは単一のポータブルファイルが必要な場合に便利ですが、Web サイトや CMS、サーバー側の変換パイプラインにとって常に最適な形式とは限りません。

外部参照リソースを使用したい場合:

- HTML 文書のサイズを削減する  
- 画像、フォント、音声、動画をブラウザーや CDN で個別にキャッシュする  
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理する  
- 出力構造を Web アプリケーションが期待する形に近づける  

汎用的な HTML 変換フローについては、[PowerPoint プレゼンテーションを HTML に変換](/slides/ja/php-java/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時のリソースリンク付け部分に焦点を当てています。

## **リンクリソースエクスポートの仕組み**

[HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/) は、Aspose.Slides がプレゼンテーションを HTML にエクスポートする際にカスタムのリンク/埋め込みコントローラーを使用できます。PHP から Java を介して利用するシナリオは、通常小さな Java ヘルパークラスで実装されます。そのヘルパーをコンパイルし、PHP Java Bridge のクラスパスに追加し、`new Java(...)` で PHP からインスタンス化します。

ヘルパークラスはリソースごとに、データを HTML に埋め込むか外部に保存してリンクを書き込むかを判断します。必要なコールバックメソッドは次の 3 つです。

- `ExternalResourceController.getObjectStoringLocation` はリソースをリンク化すべきか埋め込むべきかを決定します。  
- `ExternalResourceController.getUrl` は生成された HTML または別のリンクリソースに書き込まれる URL を返します。  
- `ExternalResourceController.saveExternal` はリンクリソースのデータをディスクまたは他の保存先に書き込みます。

ファイルシステム上のパスとブラウザーが参照する URL は別物です。たとえば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き込みますが、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルを基準に URL を解決するため、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` となり、同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` となります。

## **Java ヘルパークラスの作成**

`com.example.slides.ExternalResourceController` のような Java クラスを作成し、Aspose.Slides for Java をクラスパスに置いた状態でコンパイルし、コンパイル済みクラスまたは JAR を PHP Java Bridge で利用できるようにします。

以下のヘルパーは、Aspose.Slides が安全なファイル拡張子を提供または推測できる場合に、一般的な画像、フォント、音声、動画、CSS リソースにリンクを付与します。認識できないリソースは埋め込まれたままです。

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

## **リンクリソース付き HTML のエクスポート**

次の PHP コードは出力ディレクトリを作成し、HTML ファイルをその中に保存し、リンクリソースを `assets` サブディレクトリに格納します。エクスポートには [HtmlOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/htmloptions/)、[SVGOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgoptions/)、[SlideImageFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slideimageformat/)、[SaveFormat](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveformat/) を組み合わせています。

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

エクスポート後、出力フォルダーは次のような構造になります。

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

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえばラスタ画像は通常 JPEG または PNG でエクスポートされます。Aspose.Slides は、元のプレゼンテーションで使用された画像コーデックと異なるものを選択することがあり、サイズが小さくなるか、より適した形式になる場合があります。透過を含む画像は PNG としてエクスポートされます。

## **デプロイ時の URL 設定**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

あるリンクリソースが別のリンクリソースを参照する場合、サンプルは `ExternalResourceController.getUrl` の `referrer` パラメーターを利用し、ファイル名だけを返します。たとえば `resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきで、`assets/resource-4.jpg` ではありません。

ファイルを別の場所に配置する場合は、URL プレフィックスを変更してください。

- HTML ファイルの隣にアセットディレクトリがある場合は `assets/` を使用  
- HTML ファイルの一つ上の階層にアセットディレクトリがある場合は `../assets/` を使用  
- CDN や静的ファイルサーバーにアップロードする場合は `https://cdn.example.com/presentations/job-123/assets/` を使用  

`ExternalResourceController.getUrl` が返す URL は、`ExternalResourceController.saveExternal` が実際に書き込むファイルの最終デプロイ先と一致しなければなりません。サーバーアプリケーションでは、各変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用し、別ジョブのエクスポートがファイルを上書きしないようにしてください。

## **埋め込みを選択すべきケース**

Base64 で埋め込まれた HTML は、出力が単一ファイルである必要があるシナリオ（メール添付、オフラインプレビュー、資産フォルダーなしで移動されるドキュメントなど）で依然有用です。Web アプリケーションが HTML を配信する、CMS に保存する、ビルドパイプラインで最適化する、またはブラウザーが HTML とは別にキャッシュする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込みのままにできますか？**

はい。`ExternalResourceController.getObjectStoringLocation` で、別ファイルとして保存したいコンテンツタイプに対してだけ [LinkEmbedDecision](https://reference.aspose.com/slides/ja/php-java/aspose.slides/linkembeddecision/) の `Link` 値を返し、その他は `Embed` 値を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

HTML エクスポート時にサイズやブラウザー互換性を向上させるため、Aspose.Slides はラスタ画像を再エンコードすることがあります。その結果、元ファイルの画像が JPEG や PNG に変換されることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL が機能するのは、同じ相対フォルダー構造が維持されている場合だけです。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残すか、別の URL プレフィックスを生成する必要があります。

**サーバーアプリケーションで同じ出力フォルダーを再利用すべきですか？**

いいえ。各変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名の衝突を防ぎ、あるエクスポートが別のエクスポートのリソースを上書きすることを防止できます。