---
title: 外部リンク画像でプレゼンテーションをHTMLにエクスポート
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
- PowerPoint から HTML へ
- OpenDocument から HTML へ
- プレゼンテーションを HTML に
- スライドを HTML に
- PPT を HTML に
- PPTX を HTML に
- ODP を HTML に
- リンク画像
- 外部リンク画像
- リンクリソース
- 外部リソース
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java で PowerPoint および OpenDocument のプレゼンテーションを HTML にエクスポートし、画像やその他のリソースを外部リンクファイルとして保存します。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを自己完結型 HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接埋め込まれます。これは 1 つのポータブルファイルが必要な場合に便利ですが、Web サイトや CMS、サーバー側の変換パイプラインにとって必ずしも最適な形式とは限りません。

以下のような目的で外部リンクリソースを使用してください。

- HTML ドキュメントのサイズを削減する  
- 画像、フォント、音声、動画をブラウザーまたは CDN に個別にキャッシュする  
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理する  
- 出力構造を Web アプリケーションが期待する形に近づける  

一般的な HTML 変換ワークフローについては、[PowerPointプレゼンテーションをHTMLに変換](/slides/ja/java/convert-powerpoint-to-html/) を参照してください。本稿はエクスポート時のリソースリンク付け部分に焦点を当てます。

## **リンクリソースエクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リソース単位でデータを HTML に埋め込むか外部に保存してリンクを書くかをアプリケーションに判断させます。

インターフェイスには次の 3 つのメソッドがあります。

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リソースをリンクするか埋め込むかを決定します。  
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、生成された HTML または別のリンクリソースに書き込まれる URL を返します。  
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) は、リンクリソースのデータをディスクまたは別の保存先に書き込みます。

ファイルシステム上のパスとブラウザー URL は別々に考慮します。例えば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き出し、HTML には `assets/resource-1.svg` のような相対 URL が記述されます。ブラウザーはリンクを含むファイルを基準に URL を解決するため、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` となり、同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` となります。

## **リンクリソース付きで HTML をエクスポートする**

以下の Java サンプルは出力ディレクトリを作成し、HTML ファイルをその中に保存し、リンクリソースを `assets` サブディレクトリに格納します。コントローラーは、Aspose.Slides が提供または推測できる安全な拡張子がある場合に、一般的な画像、フォント、音声、動画、CSS リソースをリンクします。認識されないリソースは埋め込まれたままです。

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

エクスポート後、出力フォルダーは次のような構成になります。

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

正確なファイルはプレゼンテーションの内容とエクスポートオプションによります。例えば、ラスター画像は通常 JPEG または PNG としてエクスポートされます。Aspose.Slides は、サイズが小さくなる、あるいはより適切になる場合に、元のプレゼンテーションで使用されていたものとは異なる画像コーデックを選択することがあります。透過情報を含む画像は PNG としてエクスポートされます。

## **デプロイ用 URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` が `html-output/presentation.html` から開かれた場合、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

あるリンクリソースが別のリンクリソースを参照する場合、サンプルは [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) の `referrer` パラメーターを利用し、ファイル名だけを返します。例えば、`resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルを別の場所にデプロイする場合は、URL プレフィックスを変更してください。

- HTML ファイルと同じディレクトリにアセットディレクトリがある場合は `assets/` を使用  
- アセットディレクトリが HTML ファイルの 1 つ上の階層にある場合は `../assets/` を使用  
- CDN や静的ファイルサーバーにアップロードする場合は `https://cdn.example.com/presentations/job-123/assets/` を使用  

[ILinkEmbedController.getUrl](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) が返す URL は、[ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) が書き込むファイルの最終的な配置先と一致しなければなりません。サーバーアプリケーションでは、変換ジョブごとに一意の出力ディレクトリまたはオブジェクトストレージプレフィックスを使用し、別のエクスポートによる上書きを防止してください。

## **埋め込みを選択すべきケース**

埋め込み Base64 HTML は、出力が単一ファイルである必要がある場合（メール添付、オフラインプレビュー、アセットフォルダーを伴わないドキュメントの移動など）に依然有用です。HTML が Web アプリケーションで配信される、CMS に保存される、ビルドパイプラインで最適化される、あるいはブラウザーが HTML とは別にキャッシュするようなシナリオでは、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。[ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ilinkembedcontroller/) で、別ファイルとして保存したいコンテンツタイプに対して `LinkEmbedDecision.Link` を返し、その他は `LinkEmbedDecision.Embed` を返すようにしてください。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は HTML エクスポート時にサイズやブラウザー互換性を向上させるため、ラスター画像を再エンコードすることがあります。例えば、元ファイルの画像が JPEG または PNG のいずれかに変換される場合があります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は同じ相対フォルダー構造が保持されている場合にのみ機能します。`assets/resource-1.png` を参照している HTML を別の場所に移す場合は、`assets` フォルダーも同じ位置に置くか、別の URL プレフィックスを生成してください。

**サーバーアプリケーションで同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリまたはストレージプレフィックスを使用してください。これによりファイル名衝突を防ぎ、あるエクスポートが別のエクスポートのリソースを上書きすることを防止できます。