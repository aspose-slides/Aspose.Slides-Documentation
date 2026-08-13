---
title: Android の Java でプレゼンテーションの形状から画像を抽出
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
description: "Aspose.Slides for Android via Java を使用して、PowerPoint と OpenDocument プレゼンテーションの形状から画像を抽出する - 手軽でコードに優しいソリューション。"
---
## **概要**

プレゼンテーション内の画像は、普通の画像フレーム、図形に適用された画像塗り、OLE オブジェクトのプレビュー画像、ビデオやオーディオフレームのサムネイル、ズーム画像、または表・グラフ・SmartArt 図形内に埋め込まれた画像など、さまざまな形状タイプで表示されます。Aspose.Slides はこれらの画像をプレゼンテーションの画像コレクションに保存し、[IImageCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iimagecollection/) と [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/) オブジェクトを介して公開します。

プレゼンテーションに埋め込まれたすべての画像リソースをエクスポートするだけでよければ `presentation.getImages()` を反復処理します。本記事では別のタスクに焦点を当てます。すなわち、スライド上で画像が使用されている場所を形状ごとにたどり、保存するファイルにスライド番号、形状の位置、画像の種類（画像フレーム、塗り画像、メディアプレビュー、OLE プレビュー、ズーム画像）といった有用なコンテキストを保持できるようにすることです。

{{% alert title="ヒント" color="info" %}}
元のエンコードされた画像データとファイルタイプを保持したい場合は [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getBinaryData--) を使用します。特定のフォーマット（例: PNG）に正規化した出力が必要な場合は、[IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getImage--) と [IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iimage/#save-java.lang.String-int-) を組み合わせて使用してください。
{{% /alert %}}

## **共通ヘルパーメソッド**

以下のヘルパーメソッドはサンプルを簡潔に保つためのものです。`saveOriginalImage` は埋め込みバイトをそのまま書き込み、MIME タイプから安全な拡張子を選択し、SHA‑256 ハッシュで重複画像バイナリをスキップします。

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

単体オブジェクトとして挿入された画像に使用します。[IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ipictureframe/) は `getPictureFormat().getPicture().getImage()` で画像を保持し、[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/) オブジェクトを返します。なお、[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ivideoframe/) と [IAudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iaudioframe/) は [IPictureFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ipictureframe/) を継承しているため、この `instanceof` 判定はメディアフレームにも一致し、プレビュー画像をエクスポートします。メディアフレームを別処理したい場合は、先にそれらの型をチェックしてください（このページの最後の例を参照）。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util.Set;

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

## **画像塗りの形状から画像を抽出する**

形状は画像を塗りとして使用できます。まず形状の塗りタイプを確認してください：`FillType.Picture` でない場合、その塗りから抽出できる画像はありません。以下の例は [IAutoShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iautoshape/) オブジェクトを扱い、[IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getImage--) を使って PNG として保存します。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;

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

[IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ioleobjectframe/) は、PowerPoint がスライド上のオブジェクトのプレビューとして使用する代替画像を持つことがあります。この画像は `getSubstitutePictureFormat().getPicture().getImage()` で取得できます。取得できるのはプレビュー画像であり、埋め込まれた OLE パッケージの内容ではありません。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ivideoframe/) も `getPictureFormat().getPicture().getImage()` でプレビュー画像を保持します。これはスライド上に表示されるポスターやサムネイルであり、ビデオストリームからデコードされたフレームではありません。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[IAudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iaudioframe/) は `getPictureFormat().getPicture().getImage()` でサムネイルを保持できます。これがスライド上でオーディオオブジェクトに表示される画像です。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[IZoomFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.izoomframe/) と [ISectionZoomFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.isectionzoomframe/) の形状はカスタム画像を使用できます。ズームフレームの `getZoomImage()` を読み取ってください。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[ISummaryZoomFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.isummaryzoomframe/) も形状の一種です。そのセクション項目は各サマリーズームセクションの `getZoomImage()` メソッドでカスタム画像を取得できます。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[ITable](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.itable/) は形状です。テーブル内の画像は通常、セルの画像塗りとして保存されています。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **グラフ形状から画像を抽出する**

[IChart](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ichart/) は形状です。以下の例はグラフ領域の画像塗りから画像を抽出します。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

[ISmartArt](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ismartart/) オブジェクトは形状です。SmartArt のレイアウトによっては、ノードの箇条書き塗りやノード形状の塗りフォーマットに画像が保存されていることがあります。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

グループ化された形状は独自の形状コレクションを保持します。共通の `enumerateShapes` ヘルパーには `includeGroupedShapes` オプションがあります。`IGroupShape` オブジェクト内部の形状も調査したい場合は `true` に設定してください。以下の例は画像フレーム、画像塗りの形状、OLE オブジェクトプレビュー、ビデオフレームサムネイル、オーディオフレームサムネイルから画像を抽出します。テーブル、グラフ、SmartArt、サマリーズームの画像も含めるには、前述のセクションの専用抽出ロジックを再利用しつつ、同じ再帰的形状走査を維持してください。

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.List;
import java.util Set;

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

## **エッジケースと実用的な注意点**

- **重複画像:** 複数の形状が同一画像を参照したり、バイト列が同じ別画像を持つことがあります。ユニークな画像ごとに 1 つの出力ファイルにしたい場合は、ファイルを書き込む前に [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getBinaryData--) のハッシュを取って比較してください。
- **元データと変換後出力:** [IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getBinaryData--) を保存すると JPEG、PNG、GIF、SVG、EMF、WMF などの埋め込みデータがそのまま保持されます。[IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getImage--) と [IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iimage/#save-java.lang.String-int-) を組み合わせると、PNG など統一フォーマットへの変換が容易です。
- **未サポートの塗りタイプ:** 単色、グラデーション、パターン、無塗りの形状は画像塗りを含みません。`getPictureFillFormat()` を読む前に [FillType](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.filltype/) を確認してください。
- **グループ化された形状:** 上位スライドの形状コレクションはグループをフラット化しません。グループ化されたコンテンツが重要な場合は、[IGroupShape.getShapes](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.igroupshape/#getShapes--) を再帰的に調べてください。
- **OLE オブジェクトプレビュー:** [IOleObjectFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ioleobjectframe/) が `getSubstitutePictureFormat()` を通してプレビュー画像を公開することがありますが、これはスライド上のプレビューであり、OLE オブジェクト内部の埋め込みファイルそのものではありません。
- **ビデオフレームサムネイル:** [IVideoFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ivideoframe/) が `getPictureFormat()` でプレビュー画像を公開することがありますが、これはスライド上に表示されるポスターであり、ビデオストリームから抽出したフレームではありません。
- **オーディオフレームサムネイル:** [IAudioFrame](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iaudioframe/) が `getPictureFormat()` でアイコンやサムネイルを公開しますが、埋め込まれたオーディオデータそのものではありません。
- **ズーム画像:** スライドズーム、セクションズーム、サマリーズームの形状は `getZoomImage()` を介してカスタム [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/) オブジェクトを使用できることがあります。
- **入れ子になった形状モデル:** テーブル、グラフ、SmartArt オブジェクトはすべて [IShape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ishape/) を実装しますが、画像はしばしば入れ子のセル、グラフ要素、または SmartArt ノードの書式オブジェクトに格納されています。
- **トリミングや変形が施された画像:** [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/) にアクセスすると保存された画像リソースそのものが取得できます。形状が適用したトリミング、透明度、再着色、回転、その他の視覚効果は反映されません。

## **FAQ**

### 元の画像をトリミングやエフェクト、形状変換なしで取得できますか？

はい。[IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/) オブジェクトにアクセスし、[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getBinaryData--) をディスクに書き込んでください。これにより、プレゼンテーションに保存された元のエンコード画像が保持され、スライド上の描画方法は影響を受けません。

### 抽出したすべての画像を PNG でエクスポートできますか？

はい。[IPPImage.getImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getImage--) で [IImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iimage/) オブジェクトを取得し、[IImage.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.iimage/#save-java.lang.String-int-) に [ImageFormat.Png](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.imageformat/) を指定して保存してください。これにより出力が PNG に変換され、元のファイルタイプやベクターデータは保持されない可能性があります。

### 同じ画像を複数回保存しないようにするには？

[IPPImage.getBinaryData](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/#getBinaryData--) のハッシュを計算し、セットに保持します。新しい画像のハッシュが既に存在する場合は保存をスキップするか、既存の出力ファイルへの参照を記録してください。

### なぜ一部の形状から画像が取得できないのですか？

画像フレーム、画像塗りの形状、OLE オブジェクトフレーム、メディアフレーム、ズームフレーム、テーブル、グラフ、SmartArt オブジェクトは画像を参照できますが、画像は入れ子の書式オブジェクトに格納されていることがあります。そのため単純な `getPictureFormat()` や形状の `getFillFormat()` のみでは検出できないケースがあります。

### ビデオフレームのサムネイル画像を取得できますか？

はい。[IVideoFrame.getPictureFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ivideoframe/#getPictureFormat--) を使用し、`getPictureFormat().getPicture().getImage()` を読むことで、ビデオフレームに保存されたポスター画像を取得できます。これはビデオファイルから生成されたフレームではなく、フレームに付属するプレビュー画像です。

### プレゼンテーション画像コレクションから特定の画像を使用している形状を特定するには？

Aspose.Slides は [IPPImage](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ippimage/) から形状への逆リンクを保持していません。走査中にマッピングを構築してください。画像参照が見つかったら、スライド番号、形状パス、画像のハッシュまたはコレクションアイテムを記録します。

### OLE オブジェクト内部に埋め込まれた画像（例: 添付文書）を抽出できますか？

[IOleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides.ioleobjectframe/#getSubstitutePictureFormat--) で取得できるのは OLE オブジェクトのスライドプレビューです。これは埋め込まれたドキュメントそのものではありません。埋め込まれたファイル内部の画像を抽出するには、OLE データを取り出して対象ファイルタイプ用のツールで解析してください。