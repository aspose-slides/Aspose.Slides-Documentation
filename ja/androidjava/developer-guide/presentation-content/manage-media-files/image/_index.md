---
title: Android でのプレゼンテーションにおける画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/androidjava/image/
keywords:
- 画像を追加
- 写真を追加
- ビットマップを追加
- 画像を置換
- 写真を置換
- Web から
- 背景
- PNG を追加
- JPG を追加
- SVG を追加
- 外部 SVG リソース
- SVG リゾルバ
- リンクされた SVG 画像
- SVG フォント
- EMF を追加
- WMF を追加
- TIFF を追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java を使用して、PowerPoint と OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---
## **イントロダクション**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイルやインターネット、その他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides ではプレゼンテーションのスライドに画像を追加するさまざまな方法が用意されています。

{{% alert  title="Tip" color="primary" %}} 
Aspose は、画像からプレゼンテーションをすばやく作成できる無料コンバータ―[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt)―を提供しています。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像をピクチャーフレームとして追加したい場合—特にサイズ変更やエフェクトの適用、その他の標準的な書式設定オプションを使用する予定がある場合—は、[Picture Frame](/slides/ja/androidjava/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像をある形式から別の形式に変換できます。以下のページをご覧ください: [image to JPG](https://products.aspose.com/slides/ja/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/ja/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/ja/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/ja/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/ja/androidjava/conversion/png-to-svg/), および [SVG to PNG](https://products.aspose.com/slides/ja/androidjava/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides は、JPEG、PNG、BMP、GIF などの一般的な形式の画像をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピューターに保存されている画像を 1 つまたは複数、プレゼンテーションのスライドに追加できます。以下の Java サンプルコードは、画像をスライドに追加する方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピューターに保存されていない場合は、Web から直接追加できます。 

以下の Java サンプルコードは、Web から画像を取得してスライドに追加する方法を示しています：

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **スライドマスターに画像を追加**

スライドマスターは、使用するスライドのテーマやレイアウトなどの情報を保持および制御します。スライドマスターに画像を追加すると、そのマスターを基にしたすべてのスライドに画像が表示されます。 

以下の Javaサンプルコードは、スライドマスターに画像を追加する方法を示しています：

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **画像をスライドの背景として追加**

1 つまたは複数のスライドの背景として画像を使用できます。詳細については、*[Setting Images as Backgrounds for Slides](/slides/ja/androidjava/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。生成された [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isvgimage/) オブジェクトは、プレゼンテーションの画像コレクションに追加でき、ピクチャーフレームの作成に使用できます。 

以下の Java 例は、自己完結型の SVG 文字列をインポートします。この SVG で使用されるすべての画像、スタイル、およびその他のリソースは、SVG コンテンツに直接埋め込まれています。

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **外部リソースを含む SVG コンテンツのインポート**

デザインツール、図表エディタ、アイコンシステム、Web パイプラインからエクスポートされた SVG ファイルは、SVG 文書の外部に保存されたリソースを参照することがあります。たとえば、SVG は `images/photo.png` のような画像リンクや、CSS の `url(...)` 値、フォントの URL を含むことがあります。 

このような SVG コンテンツをインポートするには、[IExternalResourceResolver](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iexternalresourceresolver/) 実装を作成し、ベース URI とともに適切な [SvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/svgimage/) コンストラクタに渡します。ベース URI は SVG 文書の所在を示し、相対リンクの解決に使用されます。 

[ISvgImage] インターフェイスは、インポートされた SVG に関する情報へのアクセスを提供します：

- `getSvgContent()` は SVG のマークアップを文字列として返します。
- `getSvgData()` は SVG コンテンツをバイト配列として返します。
- `getBaseUri()` は相対リンクに使用されるベース URI を返します。
- `getExternalResourceResolver()` は SVG 画像に割り当てられたリソースリゾルバを返します。

### **外部リソースリゾルバの実装**

リゾルバには 2 つのメソッドがあります：

- `resolveUri` はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクが解決できない、または許可されていない場合は `null` を返します。
- `getEntity` は絶対リソース URI の読み取り可能なストリームを返します。リソースが存在しない、ブロックされている、または利用できない場合は `null` を返します。適切な場合はフォールバックストリームを返すこともできます。

以下のリゾルバは、許可されたローカルディレクトリからのみリンクされたリソースを読み込みます。ネットワークリソースや許可ディレクトリ外のパスはブロックされます。解決できない画像リンクに対しては、オプションでフォールバック画像が返されます。

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // このリゾルバは意図的にローカルファイルのみを許可します。
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // 画像リソースの場合にのみフォールバックを使用します。画像ストリームを返す
            // 欠損したフォントやスタイルシートに対しては有効ではありません。
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **SVG インポート時のリンクリソースの解決**

`assets/diagram.svg` が次のような相対参照を含んでいるとします：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下の Java 例は、SVG ファイルの URI をベース URI として渡し、カスタムリゾルバを提供します。リゾルバは相対画像リンクを絶対 URI に変換し、Aspose.Slides が SVG を処理している間にリンクされたリソースを含むストリームを返します。

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// ベース URI は SVG ドキュメントの場所を表します。
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`SvgImage` クラスは、SVG データをバイト配列または入力ストリームとして受け取るオーバーロードに加えて、外部リソースリゾルバとベース URI を受け取るオーバーロードも提供します。

{{% alert title="Important" color="warning" %}}
リソースリゾルバは、Aspose.Slides が SVG を処理およびレンダリングする間に外部リソースを利用可能にします。元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。 

`ISvgImage` がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルには元の SVG 表現とラスターフォールバック画像の両方が含まれる可能性があります。リンクされたリソースは生成されたフォールバック画像に表示される一方で、`images/photo.png` のような相対リンクは保存された SVG 内で変更されません。ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合、リンクされたコンテンツを省略することがあります。 
{{% /alert %}}

### **ポータブル SVG 画像の作成**

外部ファイルに依存しない SVG 画像を作成するには、`SvgImage` を作成する前に SVG を自己完結型にします。たとえば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なすべてのリソースが SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前述の例のようにピクチャーフレームに挿入します。

### **不足またはブロックされたリソースの処理**

リソース URI が無効、禁止、または解決できない場合は、`resolveUri` から `null` を返します。リソースが読めない場合は、`getEntity` から `null` を返します。可能な限り、Aspose.Slides はそのリソースなしで SVG の処理を続行します。 

欠損リソースに対してはフォールバックストリームを返すことができますが、その内容は要求されたリソースタイプと互換性がある必要があります。たとえば、フォントやスタイルシートではなく、欠損した画像に対してのみ画像ストリームを返してください。 

{{% alert title="Security" color="warning" %}}
信頼できない SVG ファイルから任意のファイルパスや無制限のネットワーク URL を解決しないでください。許可されるスキーム、ディレクトリ、ホストを制限します。ネットワークリソースについては、接続タイムアウト、レスポンスサイズ上限、コンテンツ検証も適用してください。 
{{% /alert %}}

## **SVG を形状のセットに変換**

Aspose.Slides は、PowerPoint の同様の機能と同様に、SVG を形状のセットに変換できます：

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection) インターフェイスの [addGroupShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードによって提供され、最初の引数として [ISvgImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISvgImage) オブジェクトを受け取ります。 

以下の Java サンプルコードは、このメソッドを使用して SVG ファイルを形状のセットに変換する方法を示しています：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// ソース SVG ファイル名。
String svgFileName = "sample.svg";

// 出力プレゼンテーション ファイル名。
String outPptxPath = "presentation.pptx";

// 新しいプレゼンテーションを作成。
IPresentation presentation = new Presentation();
try {
    // SVG ファイルの内容を読み取ります。
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // SvgImage オブジェクトを作成。
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得。
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG 画像をシェイプのグループに変換し、スライドサイズに合わせてスケールします。
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // プレゼンテーションを PPTX 形式で保存。
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **画像を EMF としてスライドに追加**

Java 用 Aspose.Slides for Android を使用すると、Aspose.Cells で Excel ワークシートから EMF 画像を生成し、プレゼンテーションのスライドに追加できます。 

以下の Java サンプルコードは、その手順を示しています：

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// ワークブックをストリームに保存します。
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // ファイルをそのまま追加し、画像がラスタライズされずベクター EMF のままになるようにします。
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **画像コレクション内の画像を置換**

Aspose.Slides を使用すると、プレゼンテーションの画像コレクションに保存されている画像（スライドのシェイプで使用されている画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を説明します。生のバイト データ、[IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換できます。 

以下の手順に従ってください：

1. 画像を含むプレゼンテーション ファイルを、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスでロードします。
2. ファイルから新しい画像を読み込み、バイト配列に格納します。
3. バイト配列を使用して対象画像を新しい画像に置換します。
4. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
5. 3 番目の方法では、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
6. 変更されたプレゼンテーションを PPTX ファイルとして書き込みます。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 最初の方法。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 二番目の方法。
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // 三番目の方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化し、テキストから GIF を作成できます。 
{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な外観はスライド上で [picture](/slides/ja/androidjava/picture-frame/) がどのようにスケーリングされるか、および保存時に適用される圧縮に依存します。

**多数のスライドで同じロゴを一度に置換するベストな方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換します。これにより、そのリソースを使用しているすべての要素に更新が反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々のパーツは標準的なシェイプ プロパティで編集可能になります。

**複数のスライドに一括で画像を背景として設定するにはどうすればよいですか？**

マスタースライドまたは該当レイアウトで画像を [背景として割り当て](/slides/ja/androidjava/presentation-background/) すると、そのマスター／レイアウトを使用しているすべてのスライドが背景を継承します。

**多数の画像が原因でプレゼンテーションが大きくなりすぎるのを防ぐにはどうすればよいですか？**

重複した画像の代わりに単一の画像リソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じて繰り返し使用するグラフィックはマスターに配置してください。