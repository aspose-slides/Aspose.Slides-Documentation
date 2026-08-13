---
title: Java を使用したプレゼンテーションにおける画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/java/image/
keywords:
- 画像の追加
- 写真の追加
- ビットマップの追加
- 画像の置換
- 写真の置換
- Web から
- 背景
- PNG の追加
- JPG の追加
- SVG の追加
- 外部 SVG リソース
- SVG リゾルバー
- リンクされた SVG 画像
- SVG フォント
- EMF の追加
- WMF の追加
- TIFF の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---
## **はじめに**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides でもさまざまな方法でプレゼンテーション スライドに画像を追加できます。

{{% alert  title="ヒント" color="info" %}} 

Aspose は無料コンバータ― — [JPEG から PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG から PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) — を提供しており、画像から迅速にプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="情報" color="info" %}}

画像を「画像フレーム」として追加したい場合（特にサイズ変更、効果の適用、その他標準の書式設定オプションを使用する場合）は、[画像フレーム](/slides/ja/java/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="注" color="warning" %}}

画像を別の形式に変換できます。以下のページをご覧ください: 画像を [JPG に変換] (https://products.aspose.com/slides/ja/java/conversion/image-to-jpg/)、[JPG から画像へ] (https://products.aspose.com/slides/ja/java/conversion/jpg-to-image/)、[JPG から PNG へ] (https://products.aspose.com/slides/ja/java/conversion/jpg-to-png/)、[PNG から JPG へ] (https://products.aspose.com/slides/ja/java/conversion/png-to-jpg/)、[PNG から SVG へ] (https://products.aspose.com/slides/ja/java/conversion/png-to-svg/)、および [SVG から PNG へ] (https://products.aspose.com/slides/ja/java/conversion/svg-to-png/)。

{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的な形式の画像をサポートします。 

## **ローカルに保存された画像をスライドに追加する**

コンピューターに保存されている 1 つまたは複数の画像をプレゼンテーション スライドに追加できます。以下の Java サンプルコードは、画像をスライドに追加する方法を示しています。

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

## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターに保存されていない場合は、Web から直接追加できます。

以下の Java サンプルコードは、Web から画像を取得してスライドに追加する方法を示しています。

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

## **スライド マスターに画像を追加する**

スライド マスターは、テーマやレイアウトなどの情報を保持し、当該マスターを使用するスライドに適用されます。スライド マスターに画像を追加すると、その画像はマスターに基づくすべてのスライドに表示されます。

以下の Java サンプルコードは、スライド マスターに画像を追加する方法を示しています。

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

## **スライドの背景として画像を追加する**

1 つまたは複数のスライドの背景として画像を使用できます。詳細は *[スライドの背景として画像を設定する](/slides/ja/java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **SVG をプレゼンテーションに追加する**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。得られる [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) オブジェクトは、プレゼンテーションの画像コレクションに追加でき、画像フレームの作成に使用できます。

以下の Java 例は、自己完結型 SVG 文字列をインポートします。すべての画像、スタイル、その他のリソースは SVG コンテンツ内に直接埋め込まれています。

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

## **外部リソースを含む SVG コンテンツをインポートする**

デザインツール、図表エディタ、アイコンシステム、Web パイプラインからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されたリソースを参照することがあります。たとえば、`images/photo.png` のような画像リンク、CSS の `url(...)` 値、またはフォント URL が含まれる場合があります。

このような SVG コンテンツをインポートするには、[IExternalResourceResolver](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iexternalresourceresolver/) 実装を作成し、ベース URI とともに適切な [SvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/svgimage/) コンストラクタに渡します。ベース URI は SVG ドキュメントの位置を示し、相対リンクの解決に使用されます。

[ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/isvgimage/) インターフェイスは、インポートされた SVG に関する情報へのアクセスを提供します。

- `getSvgContent()` は SVG マークアップを文字列として返します。
- `getSvgData()` は SVG コンテンツをバイト配列として返します。
- `getBaseUri()` は相対リンクに使用されたベース URI を返します。
- `getExternalResourceResolver()` は SVG 画像に割り当てられたリソルバーを返します。

### **外部リソースリゾルバーを実装する**

リゾルバーには次の 2 つのメソッドがあります。

- `resolveUri` はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクが解決できない場合や許可されていない場合は `null` を返します。
- `getEntity` は絶対リソース URI 用の読み取り可能ストリームを返します。リソースが存在しない、ブロックされている、または利用できない場合は `null` を返します。必要に応じてフォールバックストリームを返すこともできます。

以下のリゾルバーは、許可されたローカル ディレクトリからのみリンクされたリソースを読み込みます。ネットワーク リソースや許可ディレクトリ外のパスはブロックされます。解決できない画像リンクにはオプションでフォールバック画像が返されます。

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

            // このリゾルバーは意図的にローカルファイルのみを許可します。
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

            // 画像リソースに対してのみフォールバックを使用します。
            // 欠落したフォントやスタイルシートに対して画像ストリームを返すことは無効です。
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

### **SVG インポート時にリンクされたリソースを解決する**

たとえば、`assets/diagram.svg` に次のような相対参照が含まれているとします。

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下の Java 例は、SVG ファイルの URI をベース URI として渡し、カスタム リゾルバーを提供します。リゾルバーは相対画像リンクを絶対 URI に変換し、リンクされたリソースを含むストリームを返しながら Aspose.Slides が SVG を処理します。

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

// ISvgImage はソース コンテンツ、バイナリ データ、ベース URI、リゾルバーを提供します。
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

`SvgImage` クラスは、バイト配列または入力ストリームとして SVG データを受け取り、外部リソースリゾルバーとベース URI を指定できるオーバーロードも提供します。

{{% alert title="重要" color="warning" %}}

リソースリゾルバーは、Aspose.Slides が SVG を処理およびレンダリングする間に外部リソースを利用可能にしますが、元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。

`ISvgImage` がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルは元の SVG 表現とラスタ ランタイム画像の両方を含む可能性があります。リンクされたリソースは生成されたフォールバック画像に現れることがありますが、`images/photo.png` のような相対リンクは保存された SVG 内では変更されません。ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略することがあります。

{{% /alert %}}

### **ポータブルな SVG 画像を作成する**

外部ファイルに依存しない SVG 画像を作成するには、`SvgImage` を作成する前に SVG を自己完結型にします。たとえば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます。

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なすべてのリソースが SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前述の例と同様に画像フレームに挿入します。

### **欠落またはブロックされたリソースを処理する**

`resolveUri` が無効、禁止、または解決不能なリソース URI に対しては `null` を返します。`getEntity` がリソースを読み取れない場合も `null` を返します。可能な限り Aspose.Slides はそのリソースがなくても SVG の処理を続行します。

欠落したリソースに対してフォールバックストリームを返すことは可能ですが、その内容は要求されたリソースの種類と互換性がある必要があります。たとえば、画像が欠落している場合にのみ画像ストリームを返し、フォントやスタイルシートの場合は返さないでください。

{{% alert title="セキュリティ" color="warning" %}}

信頼できない SVG ファイルから任意のファイル パスや無制限のネットワーク URL を解決しないでください。許可されるスキーム、ディレクトリ、ホストを制限します。ネットワークリソースの場合は、接続タイムアウト、応答サイズ制限、コンテンツ検証も適用してください。

{{% /alert %}}

## **SVG をシェイプのセットに変換する**

Aspose.Slides は、PowerPoint の同等機能と同様に、SVG をシェイプのセットに変換できます。

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection) インターフェイスの [addGroupShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) メソッドのオーバーロードで提供され、最初の引数に [ISvgImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISvgImage) オブジェクトを受け取ります。

以下の Java サンプルコードは、このメソッドを使用して SVG ファイルをシェイプのセットに変換する方法を示しています。

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
    // SVG ファイル内容を読み込む。
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // SvgImage オブジェクトを作成。
    ISvgImage svgImage = new SvgImage(svgContent);

    // スライドサイズを取得。
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // SVG 画像をシェイプのグループに変換し、スライドサイズに合わせてスケール。
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

## **EMF 画像をスライドに追加する**

Aspose.Slides for Java は、Aspose.Cells を使用して Excel ワークシートから EMF 画像を生成し、プレゼンテーション スライドに追加できます。

以下の Java サンプルコードは、その手順を示しています。

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

        // ファイルをそのまま追加し、画像がラスター化されずベクター EMF のままになるようにします。
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

## **画像コレクション内の画像を置換する**

Aspose.Slides では、プレゼンテーションの画像コレクションに保存されている画像（スライド シェイプで使用されている画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新する複数の方法を説明します。画像は、生のバイト データ、[IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像で置換できます。

以下の手順に従ってください。

1. [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスを使用して、画像を含むプレゼンテーション ファイルを読み込みます。
2. ファイルから新しい画像をバイト配列に読み込みます。
3. バイト配列を使用して対象画像を新しい画像に置換します。
4. 2 番目のアプローチでは、画像を [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置換します。
5. 3 番目のアプローチでは、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
6. 変更したプレゼンテーションを PPTX ファイルとして保存します。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 1 番目の方法。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 2 番目の方法。
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // 3 番目の方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // プレゼンテーションをファイルに保存します。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="情報" color="info" %}}

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化し、GIF に変換できます。 

{{% /alert %}}

## **FAQ**

**挿入後も元の画像解像度は保持されますか？**

はい。元のピクセルは保持されますが、最終的な表示はスライド上での [picture](/slides/ja/java/picture-frame/) のスケーリング方法や保存時に適用される圧縮に依存します。

**多数のスライドにわたって同じロゴを一括で置換する最適な方法は何ですか？**

ロゴをマスター スライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すれば、該当リソースを使用しているすべての要素に変更が反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々のパーツは標準のシェイプ プロパティで編集可能になります。

**複数のスライドに同時に画像を背景として設定するにはどうすればよいですか？**

マスター スライドまたは該当レイアウトで [画像を背景として割り当て](/slides/ja/java/presentation-background/) すれば、そのマスター/レイアウトを使用するすべてのスライドが背景を継承します。

**多くの画像が原因でプレゼンテーションが大きくなりすぎるのを防ぐには？**

画像を重複せずに単一のリソースとして再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置してください。