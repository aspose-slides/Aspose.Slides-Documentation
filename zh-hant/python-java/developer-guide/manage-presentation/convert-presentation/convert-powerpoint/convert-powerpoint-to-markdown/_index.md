---
title: 透過 Java 的 Python 將 PowerPoint 簡報轉換為 Markdown
linktitle: PowerPoint 轉 Markdown
type: docs
weight: 140
url: /zh-hant/python-java/convert-powerpoint-to-markdown/
keywords:
- 轉換 PowerPoint
- 轉換簡報
- 轉換投影片
- 轉換 PPT
- 轉換 PPTX
- PowerPoint 轉 MD
- 簡報 轉 MD
- 投影片 轉 MD
- PPT 轉 MD
- PPTX 轉 MD
- 將 PowerPoint 儲存為 Markdown
- 將簡報儲存為 Markdown
- 將投影片儲存為 Markdown
- 將 PPT 儲存為 MD
- 將 PPTX 儲存為 MD
- 匯出 PPT 為 MD
- 匯出 PPTX 為 MD
- Markdown 影像匯出
- CDN 影像連結
- PowerPoint
- 簡報
- Markdown
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中將 PPT 與 PPTX 簡報轉換為 Markdown，並控制匯出之點陣圖、圖形檔與 SVG 影像的儲存位置與參照方式。"
---
## **概觀**

Aspose.Slides for Python via Java 可以將 PPT 與 PPTX 簡報轉換為 Markdown，以用於文件編寫、靜態網站、內容遷移和版本控制工作流程。您可以選擇 Markdown 風格、控制投影片內容的呈現方式，並決定匯出影像的儲存位置以及產生的 Markdown 如何引用它們。

預設情況下，Markdown 匯出僅使用文字輸出。若要匯出視覺內容，請使用[MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setExportType) 方法，將匯出類型設定為[MarkdownExportType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownexporttype/) 列舉中的 `Sequential` 或 `Visual` 值。`Sequential` 會分別且依序呈現投影片項目，而 `Visual` 則將分組的項目保留在一起，以維持它們的視覺關係。`TextOnly` 值不會產生影像資源，因此在此模式下不會呼叫影像儲存回呼。

## **將簡報轉換為 Markdown**

使用[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 類別載入來源檔案，然後呼叫[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法，並傳入[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 列舉中的 `Md` 值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

每個範例皆從目前工作目錄讀取 `presentation.pptx`。在執行範例之前，請先安裝 Aspose.Slides for Python via Java 以及相容的 Java 執行環境。每個 Python 行程只能啟動一次 JVM。

## **選擇 Markdown 風格**

[MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setFlavor) 方法控制輸出所使用的 Markdown 規範。[Flavor](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/flavor/) 列舉包含 CommonMark、GitHub Flavored Markdown 以及其他支援的變體。

以下範例將簡報匯出為 CommonMark：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **使用預設本機儲存行為匯出影像**

[MarkdownSaveOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/) 類別提供兩個方法，用於設定本機儲存的影像：

- [setBasePath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setBasePath) 指定 Markdown 文件及其資源的基礎目錄。
- [setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) 指定影像子目錄。其預設值為 `Images`。

以下範例會呈現視覺內容，將影像寫入 `output/assets`，並在 Markdown 文件中建立相對影像參照：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

當自訂的影像儲存處理程序回傳 `False` 時，此行為亦作為備援。

## **自訂影像儲存與 Markdown 連結**

使用[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/) 方法，為 Markdown 匯出期間產生的非 SVG 點陣圖和中繼檔資源註冊回呼。其 `MarkdownImageSavingHandler` 回呼會接收影像物件、其[ImageFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/) 值，以及以單一元素 `String[]` 參數傳遞的產生的 Markdown 連結。請使用提供的格式儲存或上傳影像，並以必須出現在 Markdown 輸出中的參考取代 `link[0]`。

以 SVG 格式產生的資源會另外處理。請使用[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/) 方法註冊回呼。其 `MarkdownSvgImageSavingHandler` 回呼會接收一個[SvgImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/) 物件與單一元素 `String[] link` 參數。SVG 沒有 `ImageFormat` 參數；請改以[SvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/#getSvgData) 方法取得其 XML 資料並寫入或上傳。依據匯出模式與視覺分組，來源簡報中的 SVG 可能會被光柵化或與其他內容合併；產生的非 SVG 資源隨後會傳遞給影像儲存回呼。當每個匯出的視覺資源都需要自訂處理時，請同時註冊這兩個回呼。

回呼的返回值決定由誰處理影像：

- 在處理程序已儲存、上傳、轉換或以其他方式處理影像，且已為 `link[0]` 指定有效值之後，回傳 `True`。Aspose.Slides 會將該值寫入 Markdown 文件，並不執行預設的本機儲存。
- 回傳 `False`，則讓 Aspose.Slides 依照透過[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setBasePath) 與[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) 所設定的值本機儲存影像並產生連結。

{{% alert color="danger" title="Important" %}}
回傳 `True` 的處理程序即負責影像。如果它在未指派有效且非空的連結時回傳 `True`，則匯出會因 `InvalidOperationException` 而失敗。
{{% /alert %}}

在 Python 中，使用 `jpype.JProxy` 註冊這些回呼，並透過其 `invoke` 方法實作 Java 回呼介面。`link` 參數是一個可變的 Java 字串陣列：在處理之前先將 `link[0]` 轉換為 Python 字串，處理完畢後再將取代的 URL 賦值回 `link[0]`。

### **將影像儲存至 CDN 原始目錄並使用外部 URL**

以下範例將 `cdn-origin/presentations/quarterly-report` 視為已掛載或同步的 CDN 原始目錄。每個處理程序會提取產生的檔名，將影像儲存至該自訂目錄，並以公開的 CDN URL 取代產生的本機參照。此範例本身不執行網路上傳：只有在該目錄已掛載為 CDN 原始或其檔案已發佈至 CDN 後，URL 才會生效。若使用物件儲存，請將檔案系統寫入改為儲存 SDK 的上傳操作，並在上傳成功後才為 `link[0]` 賦值。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

此位圖處理程序刻意對小於 128 × 128 像素的影像回傳 `False`，因此 Aspose.Slides 會使用預設行為將這些影像儲存至 `output/fallback-images`。較大的位圖與中繼檔資源，以及 SVG 資源，則由自訂程式碼處理。例如，產生的本機參照 `fallback-images/image1.png` 會變為 `https://cdn.example.com/presentations/quarterly-report/image1.png`。處理程序在寫入檔案時僅使用作業系統路徑；寫入 Markdown 的連結則使用正斜線且對檔名進行 URL 編碼。建構相對連結時亦遵循相同規則：使用 `/`，而非平台特定的目錄分隔符。

## **常見問題**

**一個處理程序能同時處理點陣圖與 SVG 影像嗎？**

否。使用[MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/) 處理匯出時產生的位圖與中繼檔資源，使用[MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/) 處理以 SVG 形式產生的資源。前者提供影像物件與[ImageFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/imageformat/) 值；後者提供[SvgImage](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/) 物件，可透過[SvgImage.getSvgData](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/svgimage/#getSvgData) 讀取其 SVG 資料。於匯出期間被光柵化的來源 SVG 會改由影像儲存回呼處理。

**當影像儲存處理程序回傳 `False` 時會發生什麼？**

Aspose.Slides 會使用預設的本機儲存行為。影像的儲存位置與產生的參照由[MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setBasePath) 與[MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) 所設定的值控制。

**處理程序能在不本機儲存影像的情況下提供 URL 嗎？**

可以。處理程序可以將影像上傳至物件儲存或傳遞給其他服務，將產生的 URL 指派給 `link[0]`，並回傳 `True`。處理程序必須自行完成所有處理；回傳 `True` 會阻止預設的本機儲存。

**為什麼 Markdown 匯出會因處理程序拋出 `InvalidOperationException`？**

當處理程序回傳 `True` 卻未提供有效連結時，就會拋出此例外。請在回傳 `True` 前先指派應寫入 Markdown 的相對路徑或外部 URL。

**影像連結應使用哪種路徑分隔符號？**

在 Markdown 連結與 URL 中請使用正斜線。`pathlib.Path` 僅用於檔案系統路徑，Markdown 參照則另外建立或正規化。

**在 Markdown 匯出期間，超連結會被保留嗎？**

會。文字[hyperlinks](/slides/zh-hant/python-java/manage-hyperlinks/) 會被保留為標準的 Markdown 連結。投影片的[transitions](/slides/zh-hant/python-java/slide-transition/) 與[animations](/slides/zh-hant/python-java/powerpoint-animation/) 則不會被轉換。

**簡報能平行轉換為 Markdown 嗎？**

您可以平行處理不同的簡報檔案，但不可在執行緒間共享同一個[Presentation]實例。請遵循[multithreading guidelines](/slides/zh-hant/python-java/multithreading/)，為每個檔案使用獨立的實例。