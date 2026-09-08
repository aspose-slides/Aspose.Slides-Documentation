---
title: 在 Python via Java 中儲存簡報
linktitle: 儲存簡報
type: docs
weight: 80
url: /zh-hant/python-java/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存簡報
- 儲存投影片
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 簡報至檔案
- 簡報至串流
- 預先定義的檢視類型
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Python
- Java
- Aspose.Slides
description: "在 Python via Java 中使用 Aspose.Slides 將 PowerPoint 與 OpenDocument 簡報儲存至檔案或串流，並設定 PPTX 輸出與進度回報。"
---
## **概觀**

在您建立簡報或[開啟現有簡報](/slides/zh-hant/python-java/open-presentation/)之後，使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法寫入結果。Aspose.Slides for Python via Java 可以將簡報儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 等多種格式。以下各節說明標準儲存操作以及 PPTX 輸出的可用選項。

## **將簡報儲存為檔案**

要將簡報儲存為檔案，將輸出路徑和一個[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法。格式值決定 Aspose.Slides 產生的檔案類型。

以下範例建立簡報並將其儲存為 PPTX 檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 在此加入或修改簡報內容。

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以原始格式儲存簡報**

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，從[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSourceFormat) 方法讀取其原始格式。將取得的[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/) 值傳遞給[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#toSaveFormat) 以取得對應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 值，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 寫入修改後的簡報。

以下完整範例處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存至輸出目錄：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#toSaveFormat) 會將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到相應的簡報儲存格式。它僅映射簡報來源格式；不適用於選擇 PDF、HTML、TIFF 或影像等匯出格式。傳入不支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/) 會導致[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

舊版 PPT、PPS 與 POT 檔案使用相同的二進位容器。若此類簡報從沒有副檔名的串流載入，PPS 或 POT 檔案可能會被辨識為 PPT。若需要保留這些舊版子類型，請保留原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它們。

## **將簡報儲存為串流**

若不想依賴最終檔案路徑寫入簡報，將可寫入的串流和一個[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/) 值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法。此方式在需要將輸出從 Web 服務回傳、儲存至資料庫或在記憶體中處理時非常有用。

以下範例將新簡報儲存至檔案串流：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **以預先定義的檢視類型儲存簡報**

您可以指定 PowerPoint 開啟已儲存簡報時的預設檢視。於儲存前使用[ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setLastView) 方法並傳入[ViewType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewtype/) 值。

以下範例將母片檢視設為初始檢視：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以嚴格的 Office Open XML 格式儲存簡報**

若要建立符合 Office Open XML 嚴格規範的 PPTX 檔案，請建立[PptxOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/) 例項，並使用其[setConformance](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setConformance) 方法傳入[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/conformance/#Iso29500_2008_Strict)。之後將該選項傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save) 方法。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **以 Zip64 模式儲存 Office Open XML 格式**

標準 ZIP 壓縮檔會限制每個條目的壓縮與未壓縮大小、整體檔案大小以及條目數量。因為 PPTX 本質上是 ZIP 壓縮檔，極大型的簡報可能會超過這些限制。Zip64 擴充可提升上述限制。

使用[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setZip64Mode) 方法控制 Aspose.Slides 是否寫入 Zip64 擴充：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#IfNecessary) 只在簡報超過標準 ZIP 限制時使用 Zip64，為預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#Never) 停用 Zip64。
- [Always](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#Always) 總是寫入 Zip64。

以下範例在輸出簡報時始終啟用 Zip64：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
如果使用[Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#Never) 且簡報無法符合標準 ZIP 限制，儲存操作會拋出 [PptxException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式**

對於 PPTX 輸出，您可以透過[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setCompressionLevel) 方法在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/) 類別提供以下值：

- [None](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#None) 不進行壓縮。
- [Level1](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level1) 壓縮最快，產生最大壓縮後檔案。
- [Level2](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level2) 至 [Level5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level5) 逐步偏好較小輸出，而犧牲儲存速度。
- [Level6](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level6) 在儲存速度與檔案大小間取得平衡，為預設等級。
- [Level7](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level7) 與 [Level8](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level8) 進一步偏好較小輸出。
- [Level9](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level9) 提供最強壓縮，但需最長的處理時間。

以下範例以無壓縮方式儲存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

以下範例使用最大壓縮等級：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **儲存簡報時不重新整理縮圖**

當簡報以 PPTX 格式儲存時，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) 方法控制文件縮圖：

- `True` 於儲存作業期間重新產生縮圖，為預設值。
- `False` 保留現有縮圖。若簡報本身沒有縮圖，Aspose.Slides 不會生成。

以下範例在儲存簡報時不重新整理縮圖：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
停用縮圖刷新可以縮短 PPTX 檔案的儲存時間。
{{% /alert %}}

## **以百分比更新儲存進度**

若要監控儲存作業，可透過 `jpype.JProxy` 註冊 Python 進度處理程序，並將其傳遞給[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setProgressCallback) 方法。Aspose.Slides 會在匯出期間呼叫處理程序的 `reporting` 方法，傳回進度值。

以下範例在主控台報告 PDF 匯出的進度：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose 提供免費的[PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter)，使用 Aspose.Slides API 建置，可將簡報中的選定投影片另存為獨立的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援增量或「快速儲存」？**

不支援。每次儲存皆會寫入完整的輸出檔，而非只更新變更的部分。

**多執行緒可以同時儲存同一個 Presentation 實例嗎？**

不行。[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/) 實例 **不是執行緒安全**的。每次只能由單一執行緒存取與儲存。

**儲存簡報時，超連結與外部連結檔案會怎樣？**

[超連結](/slides/zh-hant/python-java/manage-hyperlinks/) 會保留於簡報中。Aspose.Slides 不會複製外部連結的檔案，因此儲存後的簡報仍需能存取原始位置。

**我可以儲存文件的作者、標題、公司與建立日期等中繼資料嗎？**

可以。儲存前設定相應的[文件屬性](/slides/zh-hant/python-java/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔案。