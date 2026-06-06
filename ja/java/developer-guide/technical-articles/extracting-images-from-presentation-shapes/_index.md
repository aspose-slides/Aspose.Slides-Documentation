---
title: Java でプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 100
url: /ja/java/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用して、PowerPoint および OpenDocument プレゼンテーションの形状から画像を抽出します - 手早く、コードに優しいソリューション。"
---
## **概要**

プレゼンテーション内の画像は、普通の画像フレーム、図形に適用された画像塗りつぶし、OLE オブジェクトのプレビュー画像、ビデオやオーディオフレームのサムネイル、ズーム画像、テーブル・チャート・SmartArt 図形に埋め込まれた画像など、さまざまな形状タイプで表示されます。Aspose.Slides はこれらの画像をプレゼンテーション画像コレクションに保存し、[IImageCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimagecollection/) および [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) オブジェクトで公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation.getImages()` を反復処理します。本記事は別のタスク、すなわちスライド上で画像が使用されている場所を形状をたどって特定し、保存したファイルにスライド番号、形状の位置、元の種別（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、ズーム画像）といった有用なコンテキストを保持できるようにすることに焦点を当てています。

{{% alert title="Tip" color="primary" %}}
[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getBinaryData--) を使用すると、元のエンコード済み画像データとファイルタイプをそのまま保持できます。特定の形式（例: PNG）に正規化した出力が必要な場合は、[IPPImage.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getImage--) と [IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimage/#save-java.lang.String-int-) を併用してください。
{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`saveOriginalImage` は埋め込まれたバイト列を書き出し、MIME タイプから安全な拡張子を選択し、SHA‑256 ハッシュで重複する画像バイナリをスキップします。

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.security.MessageDigest;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Set;

private static final class ShapeReference
{
    private final IShape shape;
    private final String namePart;

    private ShapeReference(IShape shape, String namePart)
    {
        this.shape = shape;
        this.namePart = namePart;
    }
}

private static boolean saveOriginalImage(
    IPPImage image,
    String outputDirectory,
    String fileNameBase,
    Set<String> savedImageHashes) throws Exception
{
    byte[] imageData = image.getBinaryData();
    String imageHash = getSha256Hash(imageData);
    if (!savedImageHashes.add(imageHash))
    {
        return false;
    }

    String extension = getExtensionFromContentType(image.getContentType());
    String fileName = fileNameBase + "." + extension;
    File outputFile = new File(outputDirectory, fileName);

    FileOutputStream outputStream = new FileOutputStream(outputFile);
    try
    {
        outputStream.write(imageData);
    }
    finally
    {
        outputStream.close();
    }

    return true;
}

private static void saveImageAsPng(IPPImage image, String outputDirectory, String fileNameBase)
{
    String fileName = fileNameBase + ".png";
    File outputFile = new File(outputDirectory, fileName);
    String outputPath = outputFile.getPath();

    IImage outputImage = image.getImage();
    try
    {
        outputImage.save(outputPath, ImageFormat.Png);
    }
    finally
    {
        if (outputImage != null)
        {
            outputImage.dispose();
        }
    }
}

private static IPPImage getPictureFillImage(IFillFormat fillFormat)
{
    if (fillFormat == null || fillFormat.getFillType() != FillType.Picture)
    {
        return null;
    }

    return fillFormat.getPictureFillFormat().getPicture().getImage();
}

private static List<ShapeReference> enumerateShapes(
    IShapeCollection shapes,
    String prefix,
    boolean includeGroupedShapes)
{
    List<ShapeReference> shapeReferences = new ArrayList<ShapeReference>();
    int shapeCount = shapes.size();
    for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++)
    {
        IShape shape = shapes.get_Item(shapeIndex);
        int displayIndex = shapeIndex + 1;
        String shapeNamePart = prefix + "_shape_" + displayIndex;
        ShapeReference shapeReference = new ShapeReference(shape, shapeNamePart);
        shapeReferences.add(shapeReference);

        if (includeGroupedShapes && shape instanceof IGroupShape)
        {
            IGroupShape groupShape = (IGroupShape)shape;
            IShapeCollection childShapes = groupShape.getShapes();
            List<ShapeReference> childReferences = enumerateShapes(
                childShapes,
                shapeNamePart,
                includeGroupedShapes);
            shapeReferences.addAll(childReferences);
        }
    }

    return shapeReferences;
}

private static String getSha256Hash(byte[] data) throws Exception
{
    MessageDigest messageDigest = MessageDigest.getInstance("SHA-256");
    byte[] hashBytes = messageDigest.digest(data);
    StringBuilder hashBuilder = new StringBuilder();
    for (byte hashByte : hashBytes)
    {
        String hexValue = Integer.toHexString(hashByte & 0xff);
        if (hexValue.length() == 1)
        {
            hashBuilder.append('0');
        }

        hashBuilder.append(hexValue);
    }

    return hashBuilder.toString();
}

private static String getExtensionFromContentType(String contentType)
{
    if (contentType == null || contentType.trim().length() == 0)
    {
        return "bin";
    }

    String mediaType = contentType.split(";")[0].trim().toLowerCase(Locale.ROOT);
    if ("image/jpeg".equals(mediaType))
    {
        return "jpg";
    }

    if ("image/png".equals(mediaType))
    {
        return "png";
    }

    if ("image/gif".equals(mediaType))
    {
        return "gif";
    }

    if ("image/bmp".equals(mediaType))
    {
        return "bmp";
    }

    if ("image/tiff".equals(mediaType))
    {
        return "tiff";
    }

    if ("image/x-emf".equals(mediaType) || "image/emf".equals(mediaType))
    {
        return "emf";
    }

    if ("image/x-wmf".equals(mediaType) || "image/wmf".equals(mediaType))
    {
        return "wmf";
    }

    if ("image/svg+xml".equals(mediaType))
    {
        return "svg";
    }

    if (mediaType.startsWith("image/"))
    {
        String extension = mediaType.substring("image/".length());
        return makeSafeFileNamePart(extension);
    }

    return "bin";
}

private static String makeSafeFileNamePart(String value)
{
    return value.replaceAll("[^A-Za-z0-9._-]", "_");
}
```

## **画像フレームからの画像抽出**

単独オブジェクトとして挿入された画像に対してこの方法を使用します。[IPictureFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ipictureframe/) は `getPictureFormat().getPicture().getImage()` で画像を保持し、[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) オブジェクトを返します。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "extracted-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **画像塗りつぶし形状からの画像抽出**

形状は画像で塗りつぶすことができます。まず形状の塗りつぶしタイプを確認してください。`FillType.Picture` でない場合、その塗りつぶしから抽出できる画像はありません。以下のサンプルは [IAutoShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iautoshape/) オブジェクトを扱い、[IPPImage.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getImage--) を使用して各画像を PNG として保存します。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "shape-fill-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveImageAsPng(image, outputDirectory, shapeReference.namePart);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **OLE オブジェクトフレームからのプレビュー画像抽出**

[IOleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ioleobjectframe/) には、PowerPoint がスライド上でオブジェクトのプレビューとして使用する代替画像が設定されている場合があります。この画像は `getSubstitutePictureFormat().getPicture().getImage()` で取得できます。抽出されるのはプレビュー画像であり、埋め込まれた OLE パッケージの内容ではありません。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "ole-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **ビデオフレームからのプレビュー画像抽出**

[IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ivideoframe/) も `getPictureFormat().getPicture().getImage()` にプレビュー画像を保持できます。これはスライド上に表示されるポスターやサムネイルであり、ビデオストリームからデコードされたフレームではありません。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "video-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **オーディオフレームからのプレビュー画像抽出**

[IAudioFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iaudioframe/) は `getPictureFormat().getPicture().getImage()` でサムネイルを保持できます。これはオーディオオブジェクトのスライド上に表示される画像です。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "audio-preview-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **ズームオブジェクトからの画像抽出**

[IZoomFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.izoomframe/) および [ISectionZoomFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.isectionzoomframe/) 形状はカスタム画像を使用できます。ズームフレームの `getZoomImage()` を読み取ります。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IZoomFrame)
            {
                IZoomFrame zoomFrame = (IZoomFrame)shapeReference.shape;
                IPPImage image = zoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }

            if (shapeReference.shape instanceof ISectionZoomFrame)
            {
                ISectionZoomFrame sectionZoomFrame = (ISectionZoomFrame)shapeReference.shape;
                IPPImage image = sectionZoomFrame.getZoomImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_section_zoom";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    continue;
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **サマリーズームフレームからの画像抽出**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.isummaryzoomframe/) も形状の一種です。そのセクション項目はそれぞれカスタム画像を持つことができ、各サマリーズームセクションの `getZoomImage()` メソッドで取得できます。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "summary-zoom-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, false);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISummaryZoomFrame)
            {
                ISummaryZoomFrame summaryZoomFrame = (ISummaryZoomFrame)shapeReference.shape;
                int sectionCount = summaryZoomFrame.getSummaryZoomCollection().size();
                for (int sectionIndex = 0; sectionIndex < sectionCount; sectionIndex++)
                {
                    ISummaryZoomSection section = summaryZoomFrame.getSummaryZoomCollection().get_Item(sectionIndex);
                    IPPImage image = section.getZoomImage();
                    if (image != null)
                    {
                        int displayIndex = sectionIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_summary_zoom_" + displayIndex;
                        saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **テーブル形状からの画像抽出**

[ITable](https://reference.aspose.com/slides/ja/java/com.aspose.slides.itable/) は形状です。テーブル内の画像は通常、セルの画像塗りつぶしとして保存されています。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "table-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ITable)
            {
                ITable table = (ITable)shapeReference.shape;
                int rowCount = table.getRows().size();
                int columnCount = table.getColumns().size();
                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                    {
                        ICell cell = table.get_Item(columnIndex, rowIndex);
                        IFillFormat fillFormat = cell.getCellFormat().getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayRow = rowIndex + 1;
                            int displayColumn = columnIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_cell_" + displayRow + "_" + displayColumn;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **チャート形状からの画像抽出**

[IChart](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ichart/) は形状です。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "chart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IChart)
            {
                IChart chart = (IChart)shapeReference.shape;
                IFillFormat fillFormat = chart.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_chart_area";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **SmartArt 形状からの画像抽出**

[ISmartArt](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ismartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、ノードの箇条書き塗りつぶしやノード形状の塗りつぶしフォーマットに画像が格納されます。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "smartart-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof ISmartArt)
            {
                ISmartArt smartArt = (ISmartArt)shapeReference.shape;
                int nodeCount = smartArt.getAllNodes().size();
                for (int nodeIndex = 0; nodeIndex < nodeCount; nodeIndex++)
                {
                    ISmartArtNode node = smartArt.getAllNodes().get_Item(nodeIndex);
                    IFillFormat bulletFillFormat = node.getBulletFillFormat();
                    IPPImage bulletImage = getPictureFillImage(bulletFillFormat);
                    if (bulletImage != null)
                    {
                        int displayNode = nodeIndex + 1;
                        String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_bullet";
                        saveOriginalImage(bulletImage, outputDirectory, fileNameBase, savedImageHashes);
                    }

                    int nodeShapeCount = node.getShapes().size();
                    for (int nodeShapeIndex = 0; nodeShapeIndex < nodeShapeCount; nodeShapeIndex++)
                    {
                        ISmartArtShape nodeShape = node.getShapes().get_Item(nodeShapeIndex);
                        IFillFormat fillFormat = nodeShape.getFillFormat();
                        IPPImage image = getPictureFillImage(fillFormat);
                        if (image != null)
                        {
                            int displayNode = nodeIndex + 1;
                            int displayNodeShape = nodeShapeIndex + 1;
                            String fileNameBase = shapeReference.namePart + "_smartart_node_" + displayNode + "_shape_" + displayNodeShape;
                            saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                        }
                    }
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **グループ化された形状内の画像を含める**

グループ化された形状は独自の形状コレクションを持ちます。共有 `enumerateShapes` ヘルパーには `includeGroupedShapes` オプションがあります。`true` に設定すると、[IGroupShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides.igroupshape/) オブジェクト内の形状も検査できます。以下の例は画像フレーム、画像塗りつぶし形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めたい場合は、前述の専門的抽出ロジックを再利用しながら同じ再帰的形状走査を行ってください。

```java
String inputPath = "sample.pptx";
String currentDirectory = System.getProperty("user.dir");
File outputFolder = new File(currentDirectory, "all-shape-images");
outputFolder.mkdirs();
String outputDirectory = outputFolder.getPath();

Set<String> savedImageHashes = new java.util.HashSet<String>();

Presentation presentation = new Presentation(inputPath);
try
{
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
    {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slide.getSlideNumber();
        String slidePrefix = "slide_" + slideNumber;
        IShapeCollection shapes = slide.getShapes();
        List<ShapeReference> shapeReferences = enumerateShapes(shapes, slidePrefix, true);
        for (ShapeReference shapeReference : shapeReferences)
        {
            if (shapeReference.shape instanceof IOleObjectFrame)
            {
                IOleObjectFrame oleObjectFrame = (IOleObjectFrame)shapeReference.shape;
                IPPImage image = oleObjectFrame.getSubstitutePictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_ole_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IVideoFrame)
            {
                IVideoFrame videoFrame = (IVideoFrame)shapeReference.shape;
                IPPImage image = videoFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_video_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IAudioFrame)
            {
                IAudioFrame audioFrame = (IAudioFrame)shapeReference.shape;
                IPPImage image = audioFrame.getPictureFormat().getPicture().getImage();
                if (image != null)
                {
                    String fileNameBase = shapeReference.namePart + "_audio_preview";
                    saveOriginalImage(image, outputDirectory, fileNameBase, savedImageHashes);
                }

                continue;
            }

            if (shapeReference.shape instanceof IPictureFrame)
            {
                IPictureFrame pictureFrame = (IPictureFrame)shapeReference.shape;
                IPPImage image = pictureFrame.getPictureFormat().getPicture().getImage();
                saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                continue;
            }

            if (shapeReference.shape instanceof IAutoShape)
            {
                IAutoShape autoShape = (IAutoShape)shapeReference.shape;
                IFillFormat fillFormat = autoShape.getFillFormat();
                IPPImage image = getPictureFillImage(fillFormat);
                if (image != null)
                {
                    saveOriginalImage(image, outputDirectory, shapeReference.namePart, savedImageHashes);
                }
            }
        }
    }
}
finally
{
    if (presentation != null)
    {
        presentation.dispose();
    }
}
```

## **エッジケースと実務上の注意点**

- **重複画像:** 複数の形状が同じ画像を参照したり、バイト列が同一の別画像を参照したりすることがあります。ユニークな画像ごとに 1 ファイルだけ出力したい場合は、ファイルを書き込む前に [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getBinaryData--) のハッシュを取得してください。
- **元データと変換後出力:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getBinaryData--) を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データがそのまま保持されます。[IPPImage.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getImage--) を [IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimage/#save-java.lang.String-int-) と組み合わせると、PNG など統一フォーマットでの出力が可能です。
- **未サポートの塗りつぶしタイプ:** 単色、グラデーション、パターン、無塗りつぶしの形状は画像塗りつぶしを保持しません。`getPictureFillFormat()` を呼び出す前に [FillType](https://reference.aspose.com/slides/ja/java/com.aspose.slides.filltype/) を確認してください。
- **グループ化された形状:** 上位レベルのスライド形状コレクションはグループを平坦化しません。グループ化されたコンテンツが重要な場合は、[IGroupShape.getShapes](https://reference.aspose.com/slides/ja/java/com.aspose.slides.igroupshape/#getShapes--) を再帰的に検査してください。
- **OLE オブジェクトプレビュー:** [IOleObjectFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ioleobjectframe/) は `getSubstitutePictureFormat()` を通じてプレビュー画像を提供することがありますが、これはスライド上のプレビューであり、OLE オブジェクト内部に埋め込まれたファイルそのものではありません。
- **ビデオフレームサムネイル:** [IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ivideoframe/) は `getPictureFormat()` でプレビュー画像を提供しますが、これはスライド上に表示されるポスターであり、ビデオストリームから抽出されたフレームではありません。
- **オーディオフレームサムネイル:** [IAudioFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iaudioframe/) は `getPictureFormat()` でアイコンまたはサムネイルを提供しますが、埋め込まれたオーディオデータそのものではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームの形状は `getZoomImage()` を通じてカスタム [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) オブジェクトを使用できます。
- **入れ子になった形状モデル:** テーブル、チャート、SmartArt オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ishape/) を実装しますが、画像はしばしばテーブルセル、チャート要素、または SmartArt ノードのフォーマットオブジェクトに格納されています。
- **切り抜きまたは変形された画像:** [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) にアクセスすると、保存されている画像リソースそのものが取得できます。形状が適用した切り抜き、透明度、再着色、回転、その他の視覚効果は反映されません。

## **FAQ**

**元の画像をトリミングやエフェクト、形状変換なしで抽出できますか？**

はい。[IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) オブジェクトにアクセスし、[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getBinaryData--) をディスクに書き出してください。これにより、プレゼンテーションに埋め込まれた元のエンコード画像が保持され、スライド上での描画方法は影響しません。

**抽出したすべての画像を PNG としてエクスポートできますか？**

はい。[IPPImage.getImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getImage--) で [IImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimage/) オブジェクトを取得し、[IImage.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides.iimage/#save-java.lang.String-int-) に [ImageFormat.Png](https://reference.aspose.com/slides/ja/java/com.aspose.slides.imageformat/) を指定して保存してください。これにより出力が PNG に変換されますが、元のファイルタイプやベクターデータは保持されません。

**同じ画像を複数回保存しないようにするには？**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/#getBinaryData--) のハッシュを計算し、ハッシュ集合に保持します。新しい画像のハッシュが既に存在する場合は、その画像の保存をスキップするか、既存の出力ファイルへの参照を記録してください。

**一部の形状が画像を生成しないのはなぜですか？**

画像フレーム、画像塗りつぶし形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できますが、形状の種類によっては画像が入れ子のフォーマットオブジェクトに格納されていることがあります。そのため、単純に `getPictureFormat()` や `getFillFormat()` をチェックするだけでは画像が検出できない場合があります。

**ビデオフレームのサムネイルを抽出できますか？**

はい。[IVideoFrame](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ivideoframe/) を使用し、`getPictureFormat().getPicture().getImage()` を読むことで、ビデオフレームに格納されたポスター画像を抽出できます。これはビデオファイルから生成されたフレームではなく、ビデオフレームに添付されたプレビュー画像です。

**プレゼンテーション画像コレクション内の特定画像を使用している形状を特定するには？**

Aspose.Slides は [IPPImage](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ippimage/) から形状への逆リンクを保持していません。走査中にマッピングを構築してください。画像参照が見つかったら、スライド番号、形状パス、画像ハッシュまたはコレクション項目を記録します。

**OLE オブジェクト内に埋め込まれた画像（例: 添付文書）を抽出できますか？**

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ja/java/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) でスライドプレビュー画像は取得できますが、これは埋め込まれた文書そのものではありません。埋め込まれたファイル内部の画像を抽出したい場合は、OLE データを取り出して、そのファイルタイプに対応したツールで解析してください。