---
title: 使用外部連結圖像匯出簡報為 HTML
type: docs
weight: 100
url: /zh-hant/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 匯出投影片
- 匯出 PPT
- 匯出 PPTX
- 匯出 ODP
- PowerPoint 轉 HTML
- OpenDocument 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- ODP 轉 HTML
- 已連結圖像
- 外部連結圖像
- 已連結資源
- 外部資源
- Python
- Java
- Aspose.Slides
description: "使用 Aspose.Slides 在 Python 中將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，並將圖像與其他資源儲存為外部連結檔案。"
---
## **概述**

預設情況下，Aspose.Slides 會將簡報匯出為單一的 HTML 檔案，所有影像與其他資源會直接寫入 HTML，通常以 Base64 資料形式嵌入。這在需要單一可攜檔案時相當方便，但對於網站、CMS 或伺服器端轉換流程來說，並不一定是最佳格式。

當您希望：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中分別快取影像、字型、音訊或影片；
- 在匯出後檢查、取代、壓縮或後處理產生的資源；
- 讓輸出結構更貼近 Web 應用程式的預期；

就應使用外部連結資源。

一般的 HTML 轉換流程請參考[將 PowerPoint 簡報轉換為 HTML](/slides/zh-hant/python-java/convert-powerpoint-to-html/)。本文聚焦於匯出時的資源連結部分。

## **連結資源匯出運作方式**

`ILinkEmbedController` 讓您的應用程式針對每個資源決定是將資料嵌入 HTML，還是另存為外部檔案並寫入連結。

此介面有三個方法：

- `ILinkEmbedController.getObjectStoringLocation` 決定資源應該被連結或嵌入。
- `ILinkEmbedController.getUrl` 回傳將寫入產生的 HTML 或其他連結資源的 URL。
- `ILinkEmbedController.saveExternal` 將連結資源資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是分開考量的。例如，下列範例會將資源檔案寫入磁碟上的 `html-output/assets`，而 HTML 內則使用類似 `assets/resource-1.svg` 的相對 URL。瀏覽器會以包含連結的檔案為基準解析這些 URL。因此，`presentation.html` 到 SVG 檔的連結使用 `assets/resource-1.svg`，而該 SVG 檔再連結同一 `assets` 資料夾內的影像時，則使用 `resource-4.jpg`。

## **使用連結資源匯出 HTML**

以下 Python 範例會建立輸出目錄，將 HTML 檔儲存在該目錄，並將連結資源存放於 `assets` 子目錄。控制器會在 Aspose.Slides 提供或能推斷安全副檔名時，將常見的影像、字型、音訊、影片與 CSS 資源以連結方式處理；未被辨識的資源則仍會嵌入。

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

匯出完成後，輸出資料夾的結構如下：

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

實際產生的檔案取決於簡報內容與匯出選項。例如，點陣影像通常會匯出為 JPEG 或 PNG。Aspose.Slides 可能會選擇與來源簡報不同的影像編解碼器，以產生較小或更適合的檔案。具有透明度的影像會匯出為 PNG。

## **部署時的 URL 選擇**

範例使用相對 URL 前綴：`assets/`。若 `presentation.html` 從 `html-output/presentation.html` 開啟，瀏覽器會載入 `html-output/assets/resource-1.svg`。

當一個連結資源需要參照另一個連結資源時，範例會在 `ILinkEmbedController.getUrl` 的 `referrer` 參數中只回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 同在 `assets` 資料夾，SVG 檔應該參照 `resource-4.jpg`，而不是 `assets/resource-4.jpg`。

若檔案部署於其他位置，請使用不同的 URL 前綴：

- 當資產目錄與 HTML 檔位於同一層級時，使用 `assets/`。
- 當資產目錄位於 HTML 檔上一層時，使用 `../assets/`。
- 當檔案上傳至 CDN 或靜態檔案伺服器時，使用 `https://cdn.example.com/presentations/job-123/assets/`。

`ILinkEmbedController.getUrl` 回傳的 URL 必須與 `ILinkEmbedController.saveExternal` 所寫入檔案的最終部署位置相符。在伺服器應用程式中，請為每個轉換工作使用唯一的輸出目錄或物件儲存前綴，以避免覆寫其他匯出的資源。

## **何時改為嵌入**

當輸出必須為單一檔案時（如電子郵件附件、離線預覽，或需移動且無支援資產資料夾的文件），嵌入 Base64 的 HTML 仍然有其價值。若 HTML 將由 Web 應用程式提供、儲存在 CMS 中、經過建置管線最佳化，或需讓瀏覽器獨立快取，則使用連結資源較為適合。

## **常見問題**

**我可以只將影像外部化，其他資源仍保持嵌入嗎？**

可以。在 `ILinkEmbedController.getObjectStoringLocation` 中，對想要另存為獨立檔案的內容類型回傳[LinkEmbedDecision.Link](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linkembeddecision/#Link)，對其他全部回傳[LinkEmbedDecision.Embed](https://reference.aspose.com/slides/zh-hant/python-java/aspose.slides/linkembeddecision/#Embed)。

**為什麼匯出的影像副檔名與來源簡報不同？**

Aspose.Slides 可能在 HTML 匯出時重新編碼點陣影像，以提升檔案大小或瀏覽器相容性。例如，來源檔案中的影像可能會依照最終渲染結果寫入為 JPEG 或 PNG。

**搬移 HTML 檔後相對 URL 還能正常運作嗎？**

相對 URL 僅在保持相同的相對資料夾結構時才有效。若 HTML 參照 `assets/resource-1.png`，則 `assets` 資料夾必須與 HTML 檔同層，除非您產生了不同的 URL 前綴。

**伺服器應用程式是否可以重複使用同一輸出資料夾？**

不能。請為每個轉換工作使用唯一的輸出目錄或儲存前綴，以避免檔名衝突，防止一次匯出覆寫另一個匯出的資源。