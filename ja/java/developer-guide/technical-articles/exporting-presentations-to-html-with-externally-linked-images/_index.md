---
title: 外部リンクされた画像でプレゼンテーションをHTMLにエクスポート
type: docs
weight: 100
url: /ja/java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- スライドをエクスポート
- PPT をエクスポート
- PPTX をエクスポート
- ODP をエクスポート
- PowerPoint を HTML に変換
- OpenDocument を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- リンクされた画像
- 外部リンクされた画像
- リンクされたリソース
- 外部リソース
- Java
- Aspose.Slides
description: "JavaでAspose.Slidesを使用し、画像やその他のリソースを外部リンクファイルとして保存して、PowerPoint および OpenDocument プレゼンテーションを HTML にエクスポートします。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを単一の HTML ファイルにエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接書き込まれます。1 つのポータブルファイルが必要な場合には便利ですが、Web サイトや CMS、サーバーサイドの変換パイプラインにとって常に最適な形式とは限りません。

外部リソースへのリンクを使用したい場合は次のとおりです。

- HTML ドキュメントのサイズを削減したいとき
- 画像、フォント、音声、動画をブラウザーや CDN で個別にキャッシュしたいとき
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理したいとき
- Web アプリケーションが期待する出力構造に近づけたいとき

一般的な HTML 変換ワークフローについては、[PowerPointプレゼンテーションをHTMLに変換](/slides/ja/java/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時のリソースリンク付けに焦点を当てています。

## **リンクされたリソースのエクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) を使用すると、アプリケーションはリソース単位で、エクスポーターがデータを HTML に埋め込むか外部に保存してリンクを書くかを決定できます。

このインターフェイスには 3 つのメソッドがあります。

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リソースをリンクするか埋め込むかを決めます。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、生成された HTML または別のリンク済みリソースに書き込まれる URL を返します。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リンクされたリソースのデータをディスクまたは別のストレージ先に書き込みます。

ファイルシステム上のパスとブラウザー URL は別個の概念です。たとえば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルを基準にこれらの URL を解決します。そのため、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` となります。

## **リンクされたリソース付きで HTML をエクスポート**

次の Java サンプルは出力ディレクトリを作成し、HTML ファイルをそこに保存し、リンクされたリソースを `assets` サブディレクトリに格納します。コントローラーは、Aspose.Slides が提供するか安全な拡張子を推測できる一般的な画像、フォント、音声、動画、CSS リソースをリンクします。認識されないリソースは埋め込まれたままです。

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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

正確なファイルはプレゼンテーションの内容やエクスポートオプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、サイズが小さくなる、または適切になる場合に、元のプレゼンテーションで使用されていたものとは異なる画像コーデックを選択することがあります。透明度を含む画像は PNG としてエクスポートされます。

## **デプロイ時の URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` が `html-output/presentation.html` から開かれると、ブラウザーは `html-output/assets/resource-1.svg` をロードします。

1 つのリンクされたリソースが別のリンクされたリソースを参照する場合、サンプルは [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) の `referrer` パラメーターを使用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルを別の場所にデプロイする場合は、URL プレフィックスを変更してください。

- HTML ファイルと同じディレクトリにアセットディレクトリがある場合は `assets/`
