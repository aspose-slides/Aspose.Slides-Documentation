---
title: 外部リンク画像でプレゼンテーションを HTML にエクスポート
type: docs
weight: 100
url: /ja/androidjava/exporting-presentations-to-html-with-externally-linked-images/
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
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- リンクされた画像
- 外部リンク画像
- リンクされたリソース
- 外部リソース
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用し、画像やその他のリソースを外部リンクファイルとして保存しながら、Android の Java で PowerPoint と OpenDocument のプレゼンテーションを HTML にエクスポートします。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを単一の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接書き込まれます。1 つのポータブルなファイルが必要な場合には便利ですが、Web ビューや CMS、後で出力を公開するサーバー側の変換パイプラインにとって常に最適な形式とは限りません。

外部リンクされたリソースを使用したい場合は次のときです:
- HTML ドキュメントのサイズを削減する;
- 画像、フォント、オーディオ、ビデオをブラウザーや CDN で個別にキャッシュする;
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理する;
- 出力構造を Web アプリケーションが期待する形に近づける。

一般的な HTML 変換ワークフローについては、[PowerPoint プレゼンテーションを HTML に変換](/slides/ja/androidjava/convert-powerpoint-to-html/) を参照してください。この記事はエクスポート時のリソースリンク部分に焦点を当てています。

## **リンクリソースエクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) を使用すると、アプリケーションはリソース単位で、エクスポーターがデータを HTML に埋め込むか、外部に保存してリンクを書き込むかを決定できます。

このインターフェイスには 3 つのメソッドがあります:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) はリソースをリンクするか埋め込むかを決定します。
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) は生成された HTML または別のリンクリソースに書き込まれる URL を返します。
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) はリンクされたリソースデータをディスクまたは別の保存先に書き込みます。

ファイルシステムのパスとブラウザーの URL は別々の概念です。たとえば、以下のサンプルではリソースファイルをアプリケーションのファイルストレージの `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルを基準にこれらの URL を解決します。したがって、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、その SVG ファイルから同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` を使用します。

## **リンクリソース付き HTML のエクスポート**

以下の Android Java の例は出力ディレクトリを作成し、HTML ファイルをそこに保存し、リンクされたリソースを `assets` サブディレクトリに格納します。`applicationFilesDirectory` には `context.getFilesDir()` のようなアプリ所有のディレクトリを渡してください。コードは `java.nio.file` API を使用しないため、Android の `minSdk` 19 と互換性があります。

コントローラーは、Aspose.Slides が安全なファイル拡張子を提供または推測できる場合に、一般的な画像、フォント、オーディオ、ビデオ、CSS リソースをリンクします。認識できないリソースは埋め込まれたままです。

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
        }
    }
}
```

エクスポート後、出力フォルダーは次の構造になります:

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

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえば、ラスター画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、ソースプレゼンテーションで使用されたものとは異なる画像コーデックを選択することがあり、より小さいまたは適切なファイルになる場合があります。透過性を持つ画像は PNG としてエクスポートされます。

## **デプロイ時の URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

リンクされたリソースが別のリンクリソースを参照する場合、サンプルは [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) の `referrer` パラメーターを使用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が両方とも `assets` フォルダーにある場合、SVG ファイルは `assets/resource-4.jpg` ではなく `resource-4.jpg` を参照すべきです。

ファイルが別の場所にデプロイされる場合は、異なる URL プレフィックスを使用します:
- `assets/` を使用するのは、アセットディレクトリが HTML ファイルの隣にある場合です。
- `../assets/` を使用するのは、アセットディレクトリが HTML ファイルの 1 レベル上にある場合です。
- ファイルが CDN や静的ファイルサーバーにアップロードされる場合は、`https://cdn.example.com/presentations/job-123/assets/` を使用します。

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) が返す URL は、[ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) によって書き込まれたファイルの最終デプロイ先と一致しなければなりません。Android アプリケーションでは、パブリッシュワークフローに応じてアプリ固有のストレージ、キャッシュディレクトリ、または Storage Access Framework で取得したディレクトリを使用してください。サーバーアプリケーションでは、別のエクスポートのファイルが上書きされるのを防ぐため、変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージのプレフィックスを使用します。

## **埋め込みにすべき場合**

Base64 埋め込み HTML は、出力がメール添付やオフラインプレビュー、アセットフォルダーがなくても移動できるドキュメントなど、単一ファイルである必要がある場合に依然として有用です。HTML が Web アプリケーションで提供されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザーが HTML とは別にキャッシュする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。 [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ilinkembedcontroller/) では、別々のファイルとして保存したいコンテンツタイプに対してのみ [LinkEmbedDecision](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/linkembeddecision/) の `Link` を返し、その他はすべて `Embed` を返してください。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は、サイズやブラウザー互換性を向上させるために HTML エクスポート時にラスター画像を再エンコードすることがあります。たとえば、元ファイルの画像はレンダリング結果に応じて JPEG または PNG として書き込まれることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持されている場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残す必要があります。別の URL プレフィックスを生成しない限りです。

**Android でリソースを公開外部ストレージに書き込むことはできますか？**

はい、対象の Android バージョンに対して有効な保存先と権限モデルがアプリにある場合は可能です。生成された HTML がアプリ内でのみ使用される場合は、アプリ固有のファイルやキャッシュディレクトリが通常は簡単です。ユーザーに見える出力の場合は、ユーザーが選択した場所やアプリに適した別のストレージ方式を使用してください。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名の衝突を防ぎ、あるエクスポートが別のエクスポートで生成されたリソースを上書きすることを防止できます。