---
title: 在 Android 上優化簡報中的圖片管理
linktitle: 管理圖片
type: docs
weight: 10
url: /zh-hant/androidjava/image/
keywords:
- 新增圖片
- 新增圖片
- 新增位圖
- 取代圖片
- 取代圖片
- 來自網路
- 背景
- 新增 PNG
- 新增 JPG
- 新增 SVG
- 外部 SVG 資源
- SVG 解析器
- 連結的 SVG 圖片
- SVG 字型
- 新增 EMF
- 新增 WMF
- 新增 TIFF
- PowerPoint
- OpenDocument
- 簡報
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java，簡化 PowerPoint 和 OpenDocument 的圖片管理，優化效能並自動化工作流程。"
---
## **簡介**

圖片使簡報更具吸引力且視覺上更令人愉悅。於 Microsoft PowerPoint 中，您可以從檔案、網路或其他來源將照片插入投影片。類似地，Aspose.Slides 允許您以多種方式將圖片新增至簡報投影片。

{{% alert  title="Tip" color="info" %}} 
Aspose 提供免費的轉換器—[JPEG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/jpg-to-ppt) 與 [PNG to PowerPoint](https://products.aspose.app/slides/zh-hant/import/png-to-ppt)—可讓您快速從圖片建立簡報。 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
如果您想將圖片作為圖片框新增—尤其是想調整大小、套用效果或使用其他標準格式化選項—請參閱 [Picture Frame](/slides/zh-hant/androidjava/picture-frame/)。 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
您可以將圖片從一種格式轉換為另一種格式。請參閱以下頁面：convert [image to JPG](https://products.aspose.com/slides/zh-hant/androidjava/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/zh-hant/androidjava/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/zh-hant/androidjava/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/zh-hant/androidjava/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/zh-hant/androidjava/conversion/png-to-svg/)，以及 [SVG to PNG](https://products.aspose.com/slides/zh-hant/androidjava/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides 支援 JPEG、PNG、BMP、GIF 等常見格式的圖片。 

## **將本機儲存的圖片新增至投影片**

您可以將儲存在電腦上的一張或多張圖片新增至簡報投影片。以下 Java 範例程式碼示範如何將圖片新增至投影片：

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

## **從網路將圖片新增至投影片**

如果您想新增至投影片的圖片未儲存在電腦上，您可以直接從網路加入。 

以下 Java 範例程式碼示範如何從網路將圖片新增至投影片：

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

## **將圖片新增至投影片母片**

投影片母片儲存並控制使用該母片之投影片的主題與版面配置等資訊。當您將圖片新增至投影片母片時，該圖片會出現在所有以該母片為基礎的投影片上。 

以下 Java 範例程式碼示範如何將圖片新增至投影片母片：

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

## **將圖片設為投影片背景**

您可以將圖片作為一或多張投影片的背景。詳細資訊請參閱 *[Setting Images as Backgrounds for Slides](/slides/zh-hant/androidjava/presentation-background/#setting-images-as-background-for-slides)*。

## **將 SVG 新增至簡報**

可使用 [SvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/svgimage/) 類別將 SVG 內容加入簡報。產生的 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 物件隨後可加入簡報的圖片集合，並用於建立圖片框。 

以下 Java 範例匯入一個自包含的 SVG 字串。此 SVG 所使用的所有圖片、樣式及其他資源皆直接嵌入於 SVG 內容中。

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

## **匯入含外部資源的 SVG 內容**

從設計工具、圖表編輯器、圖示系統與 Web 管線匯出的 SVG 檔案可能會參考儲存在 SVG 文件之外的資源。例如，SVG 可能包含如 `images/photo.png` 的圖片連結、CSS `url(...)` 值，或字型 URL。 

若要匯入此類 SVG 內容，請建立一個 [IExternalResourceResolver](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iexternalresourceresolver/) 實作，並與基礎 URI 一起傳遞給相應的 [SvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/svgimage/) 建構函式。基礎 URI 用於識別 SVG 文件的位置，並用來解析相對連結。 

[ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/isvgimage/) 介面提供取得匯入 SVG 資訊的功能：

- `getSvgContent()` 回傳 SVG 標記的字串。 
- `getSvgData()` 回傳 SVG 內容的位元組陣列。 
- `getBaseUri()` 回傳用於相對連結的基礎 URI。 
- `getExternalResourceResolver()` 回傳指派給 SVG 圖片的資源解析器。 

### **實作外部資源解析器**

解析器有兩個方法：

- `resolveUri` 結合基礎 URI 與相對資源連結，並回傳絕對 URI。若連結無法解析或不允許，回傳 `null`。 
- `getEntity` 為絕對資源 URI 回傳可讀取的串流。若資源缺失、被阻止或不可用，回傳 `null`。在適當情況下亦可回傳備用串流。 

以下解析器僅從允許的本機目錄載入連結資源。網路資源與超出允許目錄的路徑皆會被阻止。對於無法解析的圖片連結，會回傳可選的備用圖片。

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

            // 此解析器特意僅允許本機檔案。
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

            // 僅在圖像資源時使用備援。返回圖像串流
            // 對缺失的字型或樣式表則不適用。
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

### **在 SVG 匯入期間解析連結資源**

假設 `assets/diagram.svg` 包含相對參考，如：

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下 Java 範例將 SVG 檔案的 URI 作為基礎 URI，並提供自訂解析器。該解析器將相對圖片連結轉換為絕對 URI，並在 Aspose.Slides 處理 SVG 時回傳包含該連結資源的串流。

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// 基礎 URI 代表 SVG 文件的位置。
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

`SvgImage` 類別亦提供接受 SVG 資料的位元組陣列或輸入串流，並同時接受外部資源解析器與基礎 URI 的多載方法。

{{% alert title="Important" color="warning" %}}
資源解析器在 Aspose.Slides 處理與呈現 SVG 時，使外部資源可用。它不會修改原始 SVG 標記，也不會自動將已解析的資源嵌入其中。

當 `ISvgImage` 被加入簡報圖片集合時，PPTX 檔案可同時包含原始 SVG 表示以及點陣備援圖片。已連結的資源可能會出現在產生的備援圖片中，而相對連結如 `images/photo.png` 在存儲的 SVG 中仍保持不變。因而，渲染原生 SVG 表示的應用程式在原始外部資源不可用時可能會省略連結內容。
{{% /alert %}}

### **建立可攜帶的 SVG 圖片**

若要建立不依賴外部檔案的 SVG 圖片，請在建立 `SvgImage` 前先使 SVG 成為自包含。比如，將連結的圖片 URL 替換為包含圖片資料的 `data:` URI：

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

在將所有必要資源嵌入 SVG 內容後，建立 `SvgImage`，將其加入簡報的圖片集合，並如前例所示插入圖片框。

### **處理缺少或被阻止的資源**

當資源 URI 無效、被禁止或無法解析時，於 `resolveUri` 回傳 `null`。當資源無法讀取時，於 `getEntity` 回傳 `null`。在可能的情況下，Aspose.Slides 會在缺少該資源的情況下繼續處理 SVG。 

對於缺少的資源可以回傳備用串流，但其內容必須與請求的資源類型相容。例如，僅對缺少的圖片回傳圖片串流，而非字型或樣式表。 

{{% alert title="Security" color="warning" %}}
切勿從不受信任的 SVG 檔案解析任意檔案路徑或不受限制的網路 URL。應限制允許的協議、目錄與主機。對於網路資源，亦需套用連線逾時、回應大小限制與內容驗證。
{{% /alert %}}

## **將 SVG 轉換為形狀集合**

Aspose.Slides 可以將 SVG 轉換為形狀集合，類似 PowerPoint 中的相應功能：

![PowerPoint Popup Menu](img_01_01.png)

此功能由 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection) 介面的 [addGroupShape](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) 方法的多載提供，該方法的第一個參數接受 [ISvgImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/ISvgImage) 物件。 

以下 Java 範例程式碼示範如何使用此方法將 SVG 檔案轉換為形狀集合：

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// 原始 SVG 檔案名稱。
String svgFileName = "sample.svg";

// 輸出簡報檔案名稱。
String outPptxPath = "presentation.pptx";

// 建立新簡報。
IPresentation presentation = new Presentation();
try {
    // 讀取 SVG 檔案內容。
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // 建立 SvgImage 物件。
    ISvgImage svgImage = new SvgImage(svgContent);

    // 取得投影片尺寸。
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // 將 SVG 圖片轉換為形狀群組並依投影片尺寸縮放。
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // 以 PPTX 格式儲存簡報。
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **將圖片以 EMF 形式新增至投影片**

Aspose.Slides for Android via Java 可使用 Aspose.Cells 從 Excel 工作表產生 EMF 圖片，並將其新增至簡報投影片。 

以下 Java 範例程式碼示範如何執行此操作：

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

// 將活頁簿儲存至串流。
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // 將檔案原樣加入，以使圖片保持向量 EMF 而不被點陣化。
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

## **取代圖片集合中的圖片**

Aspose.Slides 讓您取代儲存在簡報圖片集合中的圖片，包括投影片形狀所使用的圖片。本節說明了更新集合中圖片的多種方式。您可以使用原始位元組資料、[IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 實例，或集合中已存在的其他圖片來取代圖片。 

1. 使用 [Presentation](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/presentation/) 類別載入包含圖片的簡報檔案。  
2. 從檔案載入新圖片至位元組陣列。  
3. 使用位元組陣列將目標圖片取代為新圖片。  
4. 在第二種方法中，將圖片載入 [IImage](https://reference.aspose.com/slides/zh-hant/androidjava/com.aspose.slides/iimage/) 物件，並以該物件取代目標圖片。  
5. 在第三種方法中，使用簡報圖片集合中已存在的圖片取代目標圖片。  
6. 將修改後的簡報寫入為 PPTX 檔案。 

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// 建立代表簡報檔案的 Presentation 類別實例。
Presentation presentation = new Presentation("sample.pptx");
try {
    // 第一種方法。
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // 第二種方法。
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // 第三種方法。
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // 將簡報儲存至檔案。
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
使用 Aspose 免費的 [Text to GIF](https://products.aspose.app/slides/zh-hant/text-to-gif) 轉換器，您可以輕鬆將文字動畫化，並從文字建立 GIF。
{{% /alert %}}

## **常見問題**

**插入後原始圖片的解析度是否保持不變？**  
是。來源像素會被保留，但最終外觀取決於投影片上 [picture](/slides/zh-hant/androidjava/picture-frame/) 的縮放方式以及儲存時的壓縮情況。

**一次性取代數十張投影片中相同的標誌的最佳方法是什麼？**  
將標誌放在母片或版面配置上，並在簡報的圖片集合中取代它——更新會傳播至所有使用該資源的元件。

**插入的 SVG 是否可以轉換為可編輯的形狀？**  
是。您可以將 SVG 轉換為形狀群組，之後各個部件即可使用標準形狀屬性進行編輯。

**如何一次性將圖片設定為多張投影片的背景？**  
[將圖片指定為背景](/slides/zh-hant/androidjava/presentation-background/)於母片或相關版面配置——使用該母片/版面配置的所有投影片皆會繼承此背景。

**如何防止因為大量圖片而導致簡報檔案過大？**  
重複使用單一圖片資源而非複製，選擇合理的解析度，儲存時套用壓縮，並在適當時將重複的圖形放在母片上。