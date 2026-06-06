---
title: Android の Java を使用してプレゼンテーション形状から画像を抽出
linktitle: 形状からの画像
type: docs
weight: 100
url: /ja/androidjava/extracting-images-from-presentation-shapes/
keywords:
- 画像抽出
- 画像取得
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を Java で使用して、PowerPoint および OpenDocument プレゼンテーションの形状から画像を抽出する - 手軽でコードに優しいソリューション."
---
## **概要**

プレゼンテーションの画像は、さまざまな形状タイプで表示されます：普通の画像フレームとして、形状に適用された画像塗りつぶしとして、OLE オブジェクトのプレビュー画像として、ビデオまたはオーディオフレームのサムネイルとして、ズーム画像として、またはテーブル、チャート、SmartArt 形状の内部に入れ子になった画像として。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに保存し、[IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimagecollection/) と [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトを介して公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートしたいだけの場合は、`presentation.getImages()` を反復処理します。本稿では別のタスクに焦点を当てます：スライド上で画像がどこで使用されているかを形状を走査して見つけ、保存したファイルにスライド番号、形状の位置、ソースタイプ（画像フレーム、塗りつぶし画像、メディアプレビュー、OLE プレビュー、またはズーム画像）などの有用なコンテキストを保持できるようにします。

{{% alert title="Tip" color="primary" %}}
元のエンコードされた画像データとファイルタイプを保持するには、[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getBinaryData--) を使用します。PNG などの特定の形式に出力を正規化したい場合は、[IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) と組み合わせて [IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getImage--) を使用します。
{{% /alert %}}

## **共有ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保ちます。`saveOriginalImage` は元の埋め込みバイトを書き込み、MIME タイプから安全な拡張子を選択し、SHA-256 ハッシュで重複する画像バイナリをスキップします。

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

## **画像フレームから画像を抽出する**

このアプローチは、単体オブジェクトとして挿入された画像に使用します。[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ipictureframe/) は `getPictureFormat().getPicture().getImage()` で画像を保持し、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトを返します。

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

## **画像塗りつぶし形状から画像を抽出する**

形状は画像を塗りつぶしとして使用できます。まず形状の塗りつぶしタイプを確認してください: それが [FillType.Picture](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) でない場合、その塗りつぶしから抽出できる画像はありません。以下の例は [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iautoshape/) オブジェクトを処理し、[IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getImage--) を使用して各画像を PNG として保存します。

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

## **OLE オブジェクトフレームからプレビュー画像を抽出する**

[IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioleobjectframe/) には、PowerPoint がスライド上のオブジェクトのプレビューとして使用する代替画像が設定されている場合があります。この画像は `getSubstitutePictureFormat().getPicture().getImage()` で取得できます。この画像を抽出すると、プレビュー画像が得られますが、埋め込まれた OLE パッケージの内容ではありません。

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

## **ビデオフレームからプレビュー画像を抽出する**

[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/) も `getPictureFormat().getPicture().getImage()` でプレビュー画像を保持できます。これはスライド上に表示されるポスターまたはサムネイルであり、動画ストリームからデコードされたフレームではありません。

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

## **オーディオフレームからプレビュー画像を抽出する**

[IAudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudioframe/) は `getPictureFormat().getPicture().getImage()` でサムネイルを保持できます。これはスライド上のオーディオオブジェクトに表示される画像です。

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

## **ズームオブジェクトから画像を抽出する**

[IZoomFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/izoomframe/) および [ISectionZoomFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isectionzoomframe/) 形状はカスタム画像を使用できます。ズームフレームから `getZoomImage()` を取得してください。

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

## **サマリーズームフレームから画像を抽出する**

[ISummaryZoomFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/isummaryzoomframe/) も形状です。そのセクション項目はカスタム画像を使用でき、各サマリーズームセクションの `getZoomImage()` メソッドで取得できます。

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

## **テーブル形状から画像を抽出する**

[ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/itable/) は形状です。テーブル内の画像は通常、セルの画像塗りつぶしとして保存されます。

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

## **チャート形状から画像を抽出する**

[IChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ichart/) は形状です。以下の例はチャート領域の画像塗りつぶしから画像を抽出します。

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

## **SmartArt 形状から画像を抽出する**

[ISmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ismartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、画像がノードの箇条書き塗りつぶしやノード形状の塗りつぶし形式に保存されていることがあります。

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

グループ化された形状は独自の形状コレクションを持ちます。共有ヘルパー `enumerateShapes` には `includeGroupedShapes` オプションがあります。 [IGroupShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igroupshape/) オブジェクト内の形状を検査したい場合は、これを `true` に設定してください。以下の例では、画像フレーム、画像塗りつぶし形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、チャート、SmartArt、サマリーズーム画像も含めるには、前述のセクションの専門的抽出ロジックを再利用し、同じ再帰的形状走査を維持してください。

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

## **エッジケースと実践的な注意点**

- **重複画像:** 複数の形状が同じ画像を参照することや、バイトが同一の別画像があることがあります。ユニークな画像ごとに 1 つの出力ファイルにしたい場合は、ファイルを書き込む前に [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getBinaryData--) のハッシュを取得してください。
- **元データと変換出力:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getBinaryData--) を保存すると、埋め込まれた JPEG、PNG、GIF、SVG、EMF、WMF データが保持されます。[IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) を介して [IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getImage--) を保存すると、一定の形式（例: PNG）に統一された出力が得られます。
- **サポートされていない塗りつぶしタイプ:** 単色、グラデーション、パターン、無塗りつぶしの形状は画像塗りつぶしを持ちません。`getPictureFillFormat()` を読む前に [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/filltype/) を確認してください。
- **グループ化された形状:** 上位レベルのスライド形状コレクションはグループをフラット化しません。グループ化されたコンテンツが重要な場合は、[IGroupShape.getShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/igroupshape/#getShapes--) を再帰的に検査してください。
- **OLE オブジェクトプレビュー:** [IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioleobjectframe/) は `getSubstitutePictureFormat()` を通じてプレビュー画像を提供することがありますが、その画像はスライド上のプレビューであり、OLE オブジェクト内部の埋め込みファイルではありません。
- **ビデオフレームサムネイル:** [IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/) は `getPictureFormat()` を通じてプレビュー画像を提供することがありますが、その画像はスライド上に表示されるポスターであり、動画ストリームから抽出されたものではありません。
- **オーディオフレームサムネイル:** [IAudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iaudioframe/) は `getPictureFormat()` を通じてアイコンまたはサムネイルを提供することがありますが、埋め込まれたオーディオデータではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズーム形状は `getZoomImage()` を介してカスタム [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトを使用することがあります。
- **入れ子になった形状モデル:** テーブル、チャート、SmartArt オブジェクトは [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ishape/) を実装しますが、画像はしばしば入れ子になったテーブルセル、チャート要素、または SmartArt ノードの書式設定オブジェクトに保存されています。
- **クロップや変形された画像:** [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) にアクセスすると保存されている画像リソースが得られますが、形状が適用したクロップ、透明度、再着色、回転、その他のビジュアル効果は反映されません。

## **FAQ**

**形状のクロップ、エフェクト、変換を加えずに元の画像を抽出できますか？**

はい。[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) オブジェクトにアクセスし、[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getBinaryData--) をディスクに書き込んでください。これにより、プレゼンテーションに保存されている元のエンコード画像が保持され、スライド上でのレンダリング方法は反映されません。

**抽出したすべての画像を PNG としてエクスポートできますか？**

はい。[IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getImage--) を使用して [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/) オブジェクトを取得し、[ImageFormat.Png](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/imageformat/) を指定して [IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) を呼び出してください。これにより出力が PNG に変換され、元のファイルタイプやベクターデータは保持されない可能性があります。

**同じ画像を複数回保存しないようにするには？**

[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/#getBinaryData--) のハッシュを使用し、ハッシュ集合に保持します。新しい画像のハッシュが既に存在する場合は、保存をスキップするか、既存の出力ファイルへの別の参照を記録してください。

**なぜ一部の形状から画像が取得できないのですか？**

画像フレーム、画像塗りつぶし形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、チャート、SmartArt オブジェクトは画像を参照できます。一部の形状タイプは入れ子になった書式オブジェクトを介して画像を公開するため、単純な `getPictureFormat()` または形状の `getFillFormat()` のチェックだけでは不十分なことがあります。

**ビデオフレームに表示されるサムネイルを抽出できますか？**

はい。[IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ivideoframe/#getPictureFormat--) を使用し、`getPictureFormat().getPicture().getImage()` を読み取ります。これにより、ビデオフレームに保存されたポスター画像が抽出され、動画ファイルから生成されたフレームではありません。

**プレゼンテーションの画像コレクションから特定の画像を使用している形状をどのように特定できますか？**

Aspose.Slides は [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ippimage/) から形状への逆リンクを保持していません。走査中にマッピングを構築してください。画像参照を見つけたら、スライド番号、形状パス、画像ハッシュまたはコレクション項目を記録します。

**OLE オブジェクト内部（添付ドキュメントなど）に埋め込まれた画像を抽出できますか？**

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ioleobjectframe/#getSubstitutePictureFormat--) から OLE オブジェクトのスライドプレビューを抽出できますが、そのプレビューは埋め込まれたドキュメントそのものではありません。埋め込みファイル内部の画像を抽出するには、OLE データを抽出し、該当ファイルタイプ用のツールで検査してください。