---
title: 使用 Python 管理簡報中的圖片框架
linktitle: 圖片框架
type: docs
weight: 10
url: /zh-hant/python-java/picture-frame/
keywords:
- 圖片框架
- 新增圖片框架
- 建立圖片框架
- 嵌入圖像
- 連結圖像
- 擷取圖像
- 點陣圖像
- SVG 圖像
- 裁剪圖像
- 刪除裁剪區域
- 壓縮圖像
- StretchOffset
- 圖片框架格式化
- 相對比例
- 圖像效果
- 長寬比
- PowerPoint
- OpenDocument
- 簡報
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Python via Java 在簡報中建立、格式化、連結、裁剪、擷取與壓縮圖片框架。"
---
## **概觀**

圖片框架是一種顯示圖像的投影片形狀。在 Aspose.Slides 中，圖像資源與顯示它的形狀是分開的物件：一個 [Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 透過其 [ImageCollection](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imagecollection/) 持有嵌入的圖像資源，而 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 負責圖像的位置、大小、線條格式、旋轉、裁剪、圖片效果以及其他框架層級的設定。

這種分離在相同圖像要顯示多次時非常有用。將圖像加入簡報一次，保留回傳的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/)，然後在建立圖片框架時使用該圖像資源。

圖片框架可以包含 PNG 或 JPEG 等點陣圖，也可以包含 SVG 向量圖。它們也可以指向連結圖像，而不是將圖像位元組儲存在簡報中。此選擇會影響可攜性、檔案大小、擷取與匯出行為，因此在套用格式或最佳化之前，先決定圖像應如何儲存是很有幫助的。

## **新增與格式化嵌入圖像**

對於嵌入圖像，將圖像資料加入簡報，並使用 [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/shapecollection/#addPictureFrame) 建立圖片框架。圖像會成為簡報套件的一部份，因而在移動到其他電腦時仍保持自包含。

以下範例加入 JPEG 圖像、以圖像本身的原始尺寸建立框架，並套用線條格式與旋轉：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.awt import Color
from asposeslides.api import FillType, Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    picture_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    picture_frame.getLineFormat().setWidth(3)
    picture_frame.setRotation(15)

    presentation.save("picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

圖片框架控制顯示的幾何形狀；變更框架大小不會改變嵌入圖像資源中儲存的原始像素尺寸。此差異在之後裁剪或壓縮圖像時變得重要。

## **使用相對比例**

[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 透過 [setRelativeScaleWidth](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#setRelativeScaleWidth) 與 [setRelativeScaleHeight](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/#setRelativeScaleHeight) 提供框架的相對寬度與高度縮放。值為 `1.0` 代表原始圖片大小的 100%。相對縮放在工作流程需要保留與來源圖像尺寸的關係，而不是手動計算最終尺寸時相當有用。

```python
import jpade
import asposeslides

if not jpade.isJVMStarted():
    jpade.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image)
    picture_frame.setRelativeScaleWidth(1.35)
    picture_frame.setRelativeScaleHeight(0.8)

    presentation.save("relative-scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

相對縮放會變更框架的縮放設定；它不會重新取樣或壓縮嵌入的圖像。

## **嵌入與連結圖像**

嵌入圖片將圖像資料儲存在簡報內，因此是最安全的可攜性與可預測呈現選擇。連結圖片則透過 [Picture.setLinkPathLong](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picture/#setLinkPathLong) 方法儲存外部位置，而不是將圖像資料嵌入。

連結圖像可以減少 PPTX 中儲存的圖像資料量，但會引入外部相依性。連結的檔案必須保持可供開啟或呈現簡報的應用程式存取。若路徑變更、檔案搬移或資源無法取得，連結圖片可能不會如預期顯示。對於必須以電子郵件傳送、封存或在隔離環境中呈現的簡報，嵌入圖像通常較為可靠。

### **新增連結圖像**

以下範例建立圖片框架，並指向本機圖像檔案。此範例僅處理圖像連結；影片連結屬於其他媒體工作流程，特意未混入此範例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, None)
    linked_image_file = Path("linked-image.jpg").resolve()
    link_path = str(linked_image_file)
    picture_frame.getPictureFormat().getPicture().setLinkPathLong(link_path)

    presentation.save("linked-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在外部檔案管理是刻意的情況下才使用連結。不要僅將其當作壓縮的替代方案：一個帶有破損圖像相依性的 PPTX 即使檔案較小，也通常不如一個較大且自包含的簡報有用。

## **從圖片框架擷取圖像**

在從現有簡報擷取圖像之前，先確認形狀實際上是 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 且包含嵌入圖像。連結圖片框架可能不含可直接擷取的圖像位元組。

### **擷取點陣圖像**

現代圖像 API 直接支援點陣圖像，且不需要較舊的 Java 圖像包裝器。以下範例在投影片上找到第一個嵌入的點陣圖片，並將其儲存為 PNG：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        if embedded_image is None or embedded_image.getSvgImage() is not None:
            continue

        raster_image = embedded_image.getImage()
        try:
            raster_image.save("extracted-image.png", ImageFormat.Png)
        finally:
            raster_image.dispose()
        break
finally:
    presentation.dispose()
```

儲存點陣圖像會將擷取的圖像轉換為指定的輸出格式。若需要的是儲存在簡報中的編碼位元組，而不是已轉換的點陣檔，請使用圖像資源的二進位資料。

### **擷取 SVG 圖像**

對於 SVG 圖片，[PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 會公開一個 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/) 物件。這讓您能直接取得 SVG 資料，而不必先將圖片光柵化。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, PictureFrame):
            continue

        picture_frame = shape
        embedded_image = picture_frame.getPictureFormat().getPicture().getImage()
        svg_image = embedded_image.getSvgImage() if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = svg_image.getSvgData()
        Path("extracted-image.svg").write_bytes(bytes(svg_data))
        break
finally:
    presentation.dispose()
```

將 SVG 內容保留為 SVG 可在簡報內保持向量來源。PNG 或 JPEG 等點陣匯出必然會將向量內容渲染為像素。PDF 或 SVG 投影片匯出同樣是一種渲染操作，因此匯出的圖形不應被視為原始嵌入 SVG 的逐位元副本；在需要原始向量資源時，請使用嵌入的 [SvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/#getSvgData) 資料。

## **裁剪圖像**

裁剪會變更框架內可見的圖像區域。[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/) 上的裁剪值以來源圖像尺寸的百分比表示。裁剪最初不會從嵌入圖像中刪除隱藏的像素；它僅改變可見區域。

以下範例安全地找到圖片框架並套用裁剪值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.getPictureFormat().setCropLeft(23.6)
        picture_frame.getPictureFormat().setCropRight(21.5)
        picture_frame.getPictureFormat().setCropTop(3)
        picture_frame.getPictureFormat().setCropBottom(31)
        presentation.save("cropped-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

因為隱藏的圖像資料仍然存在，之後可以變更裁剪而不會遺失原始像素。若檔案大小比可逆性更重要，則可如下一節所述，實際移除裁剪區域。

## **移除裁剪圖像資料**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 會移除當前裁剪矩形之外的圖像資料，並回傳結果圖像資源。這可以減少檔案大小，但屬於破壞性最佳化：簡報儲存後，被移除的像素將無法再進行解除裁剪。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PictureFrame

presentation = Presentation("cropped-image.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.getPictureFormat().deletePictureCroppedAreas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此方法可能會在簡報中新增圖像資源。若原始圖像同時被其他圖片框架使用，這些框架仍需要其現有資源，因此刪除裁剪區域不一定會減少總圖像數量。使用此方法裁剪 WMF 或 EMF 內容會將裁剪結果光柵化為 PNG。

## **壓縮點陣圖像**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#compressImage) 會根據圖片顯示的尺寸降低點陣圖像解析度。它也可以在同一次操作中移除裁剪區域。當圖像被重新調整大小或裁剪時，方法回傳 `True`；若不需要變更則回傳 `False`。

在標準目標解析度足以應付時，可使用預先定義的 [PicturesCompression](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturescompression/) 值：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SaveFormat, PictureFrame

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_frame = None

    for shape in slide.getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.getPictureFormat().compressImage(True, PicturesCompression.Dpi150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若需要特定目標，亦可傳入自訂的正數 DPI 值。

壓縮僅針對點陣圖像。SVG 與中繼檔內容不會因此光柵壓縮工作流程而減少。另外，請記住，較低解析度與已刪除的裁剪區域無法從最佳化後的簡報中復原。應根據圖像實際檢視或匯出的最大尺寸來選擇目標解析度，而非全域套用最低 DPI。

## **管理圖像變換效果**

欲取得涵蓋亮度、對比度、顏色變換、模糊、Alpha 效果、順序鏈、檢查、移除與往返驗證的完整工作流程，請參閱 [Image Transform Effects](/slides/zh-hant/python-java/image-transform-effects/)。

## **鎖定圖片框架幾何形狀**

[PictureFrameLock](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframelock/) 設定控制哪些編輯操作會被停用。例如，[setAspectRatioLocked](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframelock/#setAspectRatioLocked) 會在調整大小時保留形狀的比例。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.jpg")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image)
    picture_frame.getPictureFrameLock().setAspectRatioLocked(True)

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

此鎖定套用於圖片框架形狀本身，並不會強迫來源圖像重新取樣或永久改變為相同的長寬比。

## **調整 StretchOffset 值**

當圖片填充模式為 stretch 時，[PictureFillFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/) 上的 stretch‑offset 值定義相對於圖片框架邊界框的填充矩形。正百分比會從邊緣向內縮進，負百分比則向外延伸。

這與裁剪不同。裁剪值決定來源圖像的哪一部分可見；stretch offset 則改變可見圖片填充被拉伸進入的矩形。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, PictureFillMode, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    source_image = Images.fromFile("photo.png")
    try:
        image = presentation.getImages().addImage(source_image)
    finally:
        source_image.dispose()

    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image)
    picture_frame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch)
    picture_frame.getPictureFormat().setStretchOffsetLeft(12)
    picture_frame.getPictureFormat().setStretchOffsetRight(12)
    picture_frame.getPictureFormat().setStretchOffsetTop(8)
    picture_frame.getPictureFormat().setStretchOffsetBottom(8)

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

使用 stretch offset 進行填充定位。若目標是隱藏來源圖像的邊緣，請使用裁剪屬性。

## **儲存、檔案大小與匯出考量**

當圖像儲存與圖片框架格式分別處理時，主要的取捨較容易管理：

- **嵌入圖像** 使簡報自包含，且在共享與伺服器端渲染時最可靠，但大型點陣圖會增加 PPTX 大小與記憶體使用。
- **連結圖像** 能讓套件保持較小，但簡報依賴於外部檔案在指定路徑或位置仍可取得。
- **裁剪** 初始為非破壞性。隱藏的像素仍保留，直到明確刪除裁剪區域或在壓縮時移除為止。
- **壓縮** 可大幅減少過大點陣圖的檔案大小，但會犧牲來源解析度。應在確定投影片上最終顯示尺寸後才套用。
- **SVG 圖像** 在需要向量保真度時應保持為 SVG。當需要向量資源本身時，直接擷取嵌入的 SVG。點陣投影片匯出始終會將渲染後的投影片轉換為像素。
- **重複圖像** 應盡可能重複使用現有的 [PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 資源，而不是在簡報工作流程中多次載入相同檔案。

對於大型簡報，圖像最佳化通常在選擇性執行時最有效：將標誌與圖表保留為向量內容，依實際顯示尺寸壓縮照片，僅在不需要日後編輯時移除裁剪像素，除非相依性管理已納入部署設計，否則避免使用外部連結。

## **常見問與答**

**圖片框架與圖像資源有何不同？**

[PPImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/ppimage/) 代表與簡報關聯的圖像資源。[PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 則是投影片上的形狀，用來顯示圖像並儲存框架層級的幾何與格式資訊，例如大小、旋轉、裁剪值、效果與鎖定。

**我應該嵌入還是連結圖像？**

當簡報必須可攜、封存或在無法存取外部資源的情況下渲染時，請嵌入圖像。僅在刻意將圖像檔案保留在 PPTX 之外且外部位置能可靠維護時才使用連結。

**裁剪會降低 PPTX 檔案大小嗎？**

單獨裁剪不會。一般的裁剪設定會隱藏來源圖像的部分，但仍保留底層像素。若要永久移除這些像素，請使用 [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas) 或在壓縮時同時刪除裁剪區域。

**壓縮後可以恢復圖像品質嗎？**

不能。壓縮可能會降低儲存的點陣解析度，且移除裁剪區域會丟棄圖像資料。如果日後需要高解析度編輯，請將原始來源圖像保留在簡報之外。

**SVG 圖像應如何處理？**

當向量完整度重要時，保留 SVG 內容為 SVG。嵌入的 [SvgImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/) 可直接擷取。將投影片渲染為 PNG 或 JPEG 之類的點陣格式會將 SVG 光柵化。

**如何避免在讀取現有投影片時產生不安全的型別轉換？**

在使用圖片框架特定成員之前，先檢查形狀類型。對 [PictureFrame](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pictureframe/) 進行 `isinstance` 檢查，可避免無效的型別轉換，並讓程式碼能正確處理不含圖片框架的投影片。