---
title: 外部リンクされた画像でプレゼンテーションを HTML にエクスポート
type: docs
weight: 100
url: /ja/java/exporting-presentations-to-html-with-externally-linked-images/
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
- リンクされた画像
- 外部リンクされた画像
- リンクされたリソース
- 外部リソース
- Java
- Aspose.Slides
description: "Java で Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションを HTML にエクスポートし、画像やその他のリソースを外部リンクファイルとして保存します。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを単一の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接埋め込まれます。1 つのポータブルファイルが必要なときには便利ですが、Web サイトや CMS、サーバー側の変換パイプラインにとって常に最適な形式とは限りません。

外部リンクされたリソースを使用したい場合は、次のことが挙げられます：
- HTML 文書のサイズを削減する
- 画像、フォント、音声、ビデオをブラウザーまたは CDN で個別にキャッシュする
- エクスポート後に生成されたリソースを検査、置換、圧縮、またはポストプロセスする
- 出力構造を Web アプリケーションが期待する形に近づける

一般的な HTML 変換ワークフローについては、[Convert PowerPoint Presentations to HTML](/slides/ja/java/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時のリソースリンク部分に焦点を当てています。

## **リンクリソースエクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) を使用すると、アプリケーションはリソース単位で、エクスポーターがデータを HTML に埋め込むか、外部に保存してリンクを書き込むかを判断できます。

このインターフェイスには 3 つのメソッドがあります：
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リソースをリンクするか埋め込むかを決定します。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、生成された HTML または他のリンクリソースに書き込まれる URL を返します。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リンクされたリソースデータをディスクまたは別のストレージ先に書き込みます。

ファイルシステムのパスとブラウザーの URL は別々の概念です。たとえば、以下のサンプルではリソースファイルをディスク上の `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルを基準にこれらの URL を解決します。したがって、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、同じ `assets` フォルダーに保存された画像へのリンクは SVG ファイル内で `resource-4.jpg` と記述します。

## **リンクリソース付き HTML のエクスポート**

以下の Java の例では、出力ディレクトリを作成し、その中に HTML ファイルを保存し、リンクされたリソースを `assets` サブディレクトリに格納します。コントローラーは、Aspose.Slides が安全なファイル拡張子を提供または推測できる場合に、一般的な画像、フォント、音声、ビデオ、CSS リソースへのリンクを作成します。認識されないリソースは埋め込まれたままになります。

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

エクスポート後、出力フォルダーは以下の構造になります：

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

実際のファイルはプレゼンテーションの内容とエクスポートオプションによって異なります。たとえば、ラスタ画像は通常 JPEG または PNG としてエクスポートされます。Aspose.Slides は、ソースのプレゼンテーションで使用されたものとは異なる画像コーデックを選択することがあり、より小さいまたは適切なファイルになる場合があります。透過を含む画像は PNG としてエクスポートされます。

## **デプロイ時の URL 選択**

サンプルでは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

リンクリソースが別のリンクリソースを参照する場合、サンプルは [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) の `referrer` パラメーターを使用し、ファイル名のみを返します。たとえば、`resource-1.svg` と `resource-4.jpg` がともに `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルが別の場所にデプロイされる場合は、異なる URL プレフィックスを使用します：
- `assets/` を使用するのは、アセットディレクトリが HTML ファイルと同じ場所にある場合です。
- `../assets/` を使用するのは、アセットディレクトリが HTML ファイルの 1 つ上の階層にある場合です。
- `https://cdn.example.com/presentations/job-123/assets/` を使用するのは、ファイルが CDN や静的ファイルサーバーにアップロードされる場合です。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) が返す URL は、[ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) が書き込むファイルの最終的なデプロイ先と一致する必要があります。サーバーアプリケーションでは、エクスポート間でファイルが上書きされるのを防ぐため、変換ジョブごとに固有の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用してください。

## **埋め込みにすべき場合**

Base64 埋め込みの HTML は、出力がメール添付やオフラインプレビュー、アセットフォルダーがなくても移動できるドキュメントなど、単一ファイルである必要がある場合に依然として有用です。HTML が Web アプリケーションで配信されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザーが HTML とは別にキャッシュしたりする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) では、別ファイルとして保存したいコンテンツタイプに対してのみ `LinkEmbedDecision.Link` を返し、その他はすべて `LinkEmbedDecision.Embed` を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は、サイズやブラウザー互換性を向上させるために、HTML エクスポート時にラスタ画像を再エンコードすることがあります。たとえば、元ファイルの画像がレンダリング結果に応じて JPEG または PNG として書き込まれることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持されている場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残す必要があります。別の URL プレフィックスを生成しない限りです。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに固有の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名の衝突を防ぎ、あるエクスポートが別のエクスポートで生成されたリソースを上書きすることを防止できます。