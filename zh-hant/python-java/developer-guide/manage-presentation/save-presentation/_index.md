---
title: 在 Python via Java 中儲存投影片
linktitle: 儲存投影片
type: docs
weight: 80
url: /zh-hant/python-java/save-presentation/
keywords:
- 儲存 PowerPoint
- 儲存 OpenDocument
- 儲存投影片
- 儲存投影片頁面
- 儲存 PPT
- 儲存 PPTX
- 儲存 ODP
- 投影片至檔案
- 投影片至串流
- 預先定義的檢視類型
- 嚴格的 Office Open XML 格式
- Zip64 模式
- 重新整理縮圖
- 儲存進度
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python via Java 中將 PowerPoint 和 OpenDocument 投影片儲存至檔案或串流，並設定 PPTX 輸出與進度回報。"
---
## **概览**

建立投影片或[開啟現有投影片](/slides/zh-hant/python-java/open-presentation/)，請使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)方法寫入結果。Aspose.Slides for Python via Java 可將投影片儲存為檔案或串流，支援 PowerPoint、OpenDocument、PDF 以及其他格式。以下章節說明標準的儲存操作以及 PPTX 輸出的可用選項。

## **將投影片儲存為檔案**

若要將投影片儲存為檔案，請將輸出路徑與一個[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)方法。格式值決定 Aspose.Slides 所建立檔案的類型。

以下範例建立投影片並將其儲存為 PPTX 檔案：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 在此新增或修改投影片內容。

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **以原始格式儲存投影片**

有關檔案與串流偵測範例、新建立投影片的行為，以及來源與輸出格式之區別，請參閱[確定原始投影片格式](/slides/zh-hant/python-java/detect-presentation-source-format/)。

在批次處理應用程式中，輸入格式可能事先未知。載入檔案後，請從[Presentation.getSourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#getSourceFormat)方法讀取其原始格式。將得到的[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/)值傳遞給[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#toSaveFormat)以取得相對應的[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)值，然後使用[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)寫入已修改的投影片。

以下完整範例處理輸入目錄中的每個檔案，更新其標題，並以載入時的格式儲存到輸出目錄：

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/slideutil/#toSaveFormat)會將 PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP 以及 PowerPoint XML 映射到它們相對應的投影片儲存格式。它僅映射投影片來源格式；並非用於選擇 PDF、HTML、TIFF 或圖像等匯出格式。傳遞不受支援或無效的[SourceFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/sourceformat/)值會導致[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html)。

舊版 PPT、PPS 與 POT 檔案使用相同的二進位容器。若此類投影片從沒有副檔名的串流載入，PPS 或 POT 檔可能因此被辨識為 PPT。若需要保留這些舊版子類型，請另行保存原始檔名或格式中繼資料，並在選擇輸出檔名與格式時使用它們。

## **將投影片儲存至串流**

若要在不依賴最終檔案路徑的情況下寫入投影片，請將可寫入的串流以及一個[SaveFormat](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveformat/)值傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)方法。此方式在需要將輸出回傳自 Web 服務、儲存至資料庫或於記憶體中處理時特別有用。

以下範例將新投影片儲存至檔案串流：

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

## **以預定義檢視類型儲存投影片**

您可以指定 PowerPoint 開啟已儲存投影片時的檢視類型。於儲存前使用[ViewProperties.setLastView](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewproperties/#setLastView)方法並傳入[ViewType](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/viewtype/)值。

以下範例將投影片主題檢視 (Slide Master) 設為初始檢視：

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

## **以 Strict Office Open XML 格式儲存投影片**

若要建立符合 Office Open XML Strict 檔案規範的 PPTX，請建立[PptxOptions](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/)實例，並以[Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/conformance/#Iso29500_2008_Strict)呼叫其[setConformance](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setConformance)方法。然後將此選項傳遞給[Presentation.save](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/#save)方法。

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

## **以 Zip64 模式儲存 Office Open XML 格式的投影片**

標準 ZIP 壓縮檔對每個條目的壓縮與未壓縮大小、整體檔案大小以及條目數量都有上限。由於 PPTX 本質上是 ZIP 檔，極大型的投影片可能會超過這些限制。ZIP64 擴充可提升相關的大小與條目數上限。

使用[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setZip64Mode)方法來控制 Aspose.Slides 是否寫入 ZIP64 擴充：

- [IfNecessary](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#IfNecessary) 只在投影片超過標準 ZIP 限制時使用 ZIP64，為預設模式。
- [Never](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#Never) 停用 ZIP64 擴充。
- [Always](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#Always) 總是寫入 ZIP64 擴充。

以下範例在輸出投影片時始終啟用 ZIP64 擴充：

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
如果使用[Zip64Mode.Never](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/zip64mode/#Never)且投影片無法符合標準 ZIP 限制，儲存作業將拋出[PptxException](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxexception/)。
{{% /alert %}}

## **以壓縮等級儲存 Office Open XML 格式的投影片**

對於 PPTX 輸出，您可以透過[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setCompressionLevel)方法在儲存速度與檔案大小之間取得平衡。[CompressionLevel](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/)類別提供以下值：

- [None](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#None) 不進行壓縮直接儲存資料。
- [Level1](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level1) 提供最快的壓縮速度與最大壓縮後檔案。
- [Level2](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level2)至[Level5](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level5) 逐漸偏好較小的輸出而犧牲儲存速度。
- [Level6](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level6) 在儲存速度與檔案大小之間取得平衡，為預設等級。
- [Level7](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level7)與[Level8](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level8) 更加偏好較小的輸出。
- [Level9](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/compressionlevel/#Level9) 提供最強的壓縮，且需要最長的處理時間。

以下範例於不使用壓縮的情況下儲存投影片：

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

以下範例使用最高壓縮等級：

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

## **儲存投影片時不重新整理縮圖**

當投影片以 PPTX 格式儲存時，[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail)方法決定其文件縮圖的處理方式：

- `True` 在儲存過程中重新產生縮圖，為預設值。
- `False` 保留現有縮圖。若投影片沒有縮圖，Aspose.Slides 不會產生新的縮圖。

以下範例在儲存投影片時不刷新縮圖：

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
停用縮圖刷新可減少儲存 PPTX 檔案所需的時間。
{{% /alert %}}

## **以百分比報告儲存進度**

若要監控儲存作業，可透過 `jpype.JProxy` 註冊 Python 進度處理器，並將其傳遞給[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/saveoptions/#setProgressCallback)方法。Aspose.Slides 會在匯出期間呼叫處理器的 `reporting` 方法，傳回進度值。

以下範例將 PDF 匯出的進度報告至主控台：

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
Aspose 提供免費的[PowerPoint Splitter](https://products.aspose.app/slides/zh-hant/splitter)工具，該工具基於 Aspose.Slides API，能將投影片中的選取頁面另存為獨立的 PPT 或 PPTX 檔案。
{{% /alert %}}

## **常見問題**

**Aspose.Slides 是否支援增量或「快速儲存」？**

不支援。每次儲存操作都會寫入完整的輸出檔案，而非僅更新變更部分。

**多個執行緒能同時儲存同一個 Presentation 實例嗎？**

不能。[Presentation](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/presentation/)實例**不是執行緒安全**的。每次只能由單一執行緒存取與儲存該實例。

**儲存投影片時，超連結與外部連結檔案會發生什麼事？**

[超連結](/slides/zh-hant/python-java/manage-hyperlinks/)會保留在投影片中。Aspose.Slides 不會複製外部連結的檔案，儲存後的投影片仍須能存取其原始位置。

**我可以儲存文件的作者、標題、公司與建立日期等中繼資料嗎？**

可以。於儲存前設定相應的[文件屬性](/slides/zh-hant/python-java/presentation-properties/)，Aspose.Slides 會將它們寫入輸出檔案。