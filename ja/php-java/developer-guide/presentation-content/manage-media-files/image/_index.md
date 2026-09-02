---
title: PHP を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/php-java/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置換
- 画像を置換
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
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用し、PowerPoint と OpenDocument の画像管理を効率化してパフォーマンスを最適化し、ワークフローを自動化します。"
---
## **はじめに**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides を使用すると、さまざまな方法でプレゼンテーション スライドに画像を追加できます。

{{% alert  title="Tip" color="primary" %}} 
Aspose は無料のコンバータ、[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しており、画像からすばやくプレゼンテーションを作成できます。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
画像を画像フレームとして追加したい場合—特にサイズ変更や効果の適用、その他の標準的な書式設定オプションを使用する予定がある場合—は、[Picture Frame](/slides/ja/php-java/picture-frame/) を参照してください。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
画像をある形式から別の形式に変換できます。以下のページを参照してください: [image to JPG](https://products.aspose.com/slides/ja/php-java/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/ja/php-java/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/ja/php-java/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/ja/php-java/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/ja/php-java/conversion/png-to-svg/)、[SVG to PNG](https://products.aspose.com/slides/ja/php-java/conversion/svg-to-png/)。
{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的な形式の画像をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピューターに保存された 1 つまたは複数の画像をプレゼンテーション スライドに追加できます。以下の PHP サンプルコードは、画像をスライドに追加する方法を示しています:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピューターに保存されていない場合、Web から直接追加できます。 

以下の PHP サンプルコードは、Web から画像をスライドに追加する方法を示しています:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **スライド マスターに画像を追加**

スライド マスターは、そのマスターを使用するスライドのテーマやレイアウトなどの情報を保存および制御します。スライド マスターに画像を追加すると、そのマスターに基づくすべてのスライドに画像が表示されます。 

以下の PHP サンプルコードは、スライド マスターに画像を追加する方法を示しています:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **画像をスライドの背景として追加**

画像を 1 枚以上のスライドの背景として使用できます。詳細については、*[スライドの背景として画像を設定](/slides/ja/php-java/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。生成された SVG 画像オブジェクトは、プレゼンテーションの画像コレクションに追加でき、画像フレームの作成に使用できます。

以下の PHP 例は、自己完結型 SVG 文字列をインポートします。使用されているすべての画像、スタイル、その他のリソースは SVG コンテンツに直接埋め込まれています。

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **外部リソースを含む SVG コンテンツのインポート**

デザインツール、ダイアグラム エディタ、アイコン システム、Web パイプラインからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されたリソースを参照することがあります。たとえば、`images/photo.png` のような画像リンク、CSS の `url(...)` 値、またはフォント URL が含まれることがあります。

このような SVG コンテンツをインポートするには、[ExternalResourceResolver](https://reference.aspose.com/slides/ja/php-java/aspose.slides/externalresourceresolver/) の実装を作成し、ベース URI と共に適切な [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) コンストラクタに渡します。ベース URI は SVG ドキュメントの位置を示し、相対リンクの解決に使用されます。

SVG 画像オブジェクトは、インポートされた SVG に関する情報へのアクセスを提供します:

- `getSvgContent()` は SVG マークアップを文字列として返します。
- `getSvgData()` は SVG コンテンツをバイト配列として返します。
- `getBaseUri()` は相対リンクに使用されたベース URI を返します。
- `getExternalResourceResolver()` は SVG 画像に割り当てられたリゾルバを返します。

### **外部リソースリゾルバの実装**

リゾルバには 2 つのメソッドがあります:

- `resolveUri` はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクを解決できない、または許可されていない場合は `null` を返します。
- `getEntity` は絶対リソース URI に対する読み取り可能なストリームを返します。リソースが存在しない、ブロックされている、または利用できない場合は `null` を返します。適切な場合はフォールバック ストリームを返すこともできます。

以下のリゾルバは、許可されたローカル ディレクトリからのみリンクされたリソースを読み込みます。ネットワーク リソースおよび許可されたディレクトリ外のパスはブロックされます。解決できない画像リンクにはオプションのフォールバック画像が返されます。

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // このリゾルバは意図的にローカルファイルのみを許可します。
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // フォールバックは画像リソースに対してのみ使用します。画像ストリームを返す
            // 欠損したフォントやスタイルシートに対しては無効です。
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **SVG インポート時にリンクされたリソースを解決**

`assets/diagram.svg` に次のような相対参照が含まれているとします:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下の PHP 例は、SVG ファイル URI をベース URI として渡し、カスタム リゾルバを提供します。リゾルバは相対画像リンクを絶対 URI に変換し、Aspose.Slides が SVG を処理する間にリンクされたリソースを含むストリームを返します。

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// ベースURIはSVGドキュメントの場所を表します。
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// SVG画像オブジェクトはソースコンテンツ、バイナリデータ、ベースURI、リゾルバを公開します。
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`SvgImage` クラスは、バイト配列または入力ストリームとして SVG データを受け取り、外部リソースリゾルバとベース URI を指定できるオーバーロードも提供します。

{{% alert title="Important" color="warning" %}}
リソースリゾルバは、Aspose.Slides が SVG を処理およびレンダリングする間に外部リソースを利用可能にしますが、元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。

SVG 画像がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルは元の SVG 表現とラスタ ランタイム画像の両方を含むことがあります。リンクされたリソースは生成されたフォールバック画像に現れることがありますが、`images/photo.png` のような相対リンクは保存された SVG 内では変更されません。ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略する可能性があります。
{{% /alert %}}

### **ポータブル SVG 画像の作成**

外部ファイルに依存しない SVG 画像を作成するには、`SvgImage` を作成する前に SVG を自己完結型にします。たとえば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なリソースがすべて SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前の例と同様に画像フレームに挿入します。

### **欠落またはブロックされたリソースの処理**

`resolveUri` でリソース URI が無効、禁止、または解決できない場合は `null` を返します。`getEntity` でリソースを読み取れない場合も `null` を返します。可能な限り、Aspose.Slides はそのリソースなしで SVG の処理を続行します。

欠落したリソースに対してフォールバック ストリームを返すことはできますが、その内容は要求されたリソースの種類と互換性がある必要があります。たとえば、画像が欠落している場合にのみ画像ストリームを返し、フォントやスタイルシートに対しては返さないでください。

{{% alert title="Security" color="warning" %}}
信頼できない SVG ファイルから任意のファイル パスや無制限のネットワーク URL を解決しないでください。許可されたスキーム、ディレクトリ、ホストを制限します。ネットワーク リソースの場合は、接続タイムアウト、応答サイズ制限、コンテンツ検証も適用してください。
{{% /alert %}}

## **SVG を一連の形状に変換**

Aspose.Slides は、PowerPoint の対応機能に似た方法で SVG を形状の集合に変換できます:

![PowerPoint ポップアップ メニュー](img_01_01.png)

この機能は、[ShapeCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/) クラスの [addGroupShape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shapecollection/addgroupshape/) メソッドのオーバーロードで提供され、最初の引数として [SvgImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/svgimage/) オブジェクトを受け取ります。

以下の PHP サンプルコードは、このメソッドを使用して SVG ファイルを形状の集合に変換する方法を示しています:

```php
// ソースSVGファイル名。
$svgFileName = "sample.svg";

// 出力プレゼンテーションファイル名。
$outPptxPath = "presentation.pptx";

// 新しいプレゼンテーションを作成します。
$presentation = new Presentation();
try {
    // SVGファイルの内容を読み取ります。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // SvgImageオブジェクトを作成します。
    $svgImage = new SvgImage($svgContent);

    // スライドのサイズを取得します。
    $slideSize = $presentation->getSlideSize()->getSize();

    // SVG画像を形状のグループに変換し、スライドサイズに合わせてスケーリングします。
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // プレゼンテーションをPPTX形式で保存します。
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **画像を EMF としてスライドに追加**

Aspose.Slides for PHP via Java を使用すると、Aspose.Cells で Excel ワークシートから EMF 画像を生成し、プレゼンテーション スライドに追加できます。

以下の PHP サンプルコードは、その方法を示しています:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// ワークブックをストリームに保存します。
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // ファイルをそのまま追加するので、画像はラスタライズされずベクトル EMF のままです。
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **画像コレクション内の画像を置換**

Aspose.Slides では、プレゼンテーションの画像コレクションに保存されている画像（スライド形状で使用されている画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を説明します。画像は、生のバイト データ、[IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して置換できます。

以下の手順に従ってください:

1. [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) クラスを使用して、画像が含まれるプレゼンテーション ファイルをロードします。
1. ファイルから新しい画像をバイト配列にロードします。
1. バイト配列を使用して対象画像を新しい画像に置換します。
1. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/ja/php-java/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。
1. 3 番目の方法では、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
1. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

```php
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("sample.pptx");
try {
    // 最初の方法。
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // 2 番目の方法。
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // 3 番目の方法。
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // プレゼンテーションをファイルに保存します。
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すると、テキストを簡単にアニメーション化し、テキストから GIF を作成できます。 
{{% /alert %}}

## **よくある質問**

**挿入後も元の画像解像度は維持されますか？**

はい。元のピクセルは保持されますが、最終的な見た目はスライド上で [picture](/slides/ja/php-java/picture-frame/) がどのようにスケーリングされるか、保存時に適用された圧縮に依存します。

**数十枚のスライドで同じロゴを一括で置換する最適な方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すると、リソースを使用するすべての要素に変更が反映されます。

**挿入された SVG を編集可能な形状に変換できますか？**

はい。SVG を形状のグループに変換でき、個々のパーツは標準の形状プロパティで編集可能になります。

**画像を複数のスライドの背景として一括で設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てれば、そのマスター/レイアウトを使用するすべてのスライドが背景を継承します。

**画像が多数あるためプレゼンテーションが大きくなりすぎるのを防ぐには？**

画像の重複を避けて単一のリソースを再利用し、適切な解像度を選択し、保存時に圧縮を適用し、必要に応じてマスターにグラフィックを配置してください。