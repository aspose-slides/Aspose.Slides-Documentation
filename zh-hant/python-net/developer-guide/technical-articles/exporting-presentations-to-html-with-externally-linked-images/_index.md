---
title: 在 Python 中使用外部連結影像將簡報匯出為 HTML
linktitle: 使用外部連結影像將簡報匯出為 HTML
type: docs
weight: 100
url: /zh-hant/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- 已連結影像
- 外部連結影像
- 已連結資源
- 外部資源
- Python
- Aspose.Slides
description: 在 Python 中使用 Aspose.Slides，將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，並將影像儲存為外部連結檔案。
---
## **概觀**

預設情況下，Aspose.Slides 會將簡報匯出為單一的 HTML 檔案。影像與其他資源會直接寫入 HTML，通常以 Base64 資料形式呈現。這在需要單一可攜檔案時很方便，但對於網站、CMS 或伺服器端轉換管線而言，並不總是最佳格式。

當您希望：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中單獨快取影像；
- 在匯出後檢查、取代、壓縮或後處理產生的影像；
- 讓輸出結構更貼近 Web 應用程式的預期；

請使用外部連結的影像。

一般的 HTML 轉換工作流程請參考 [Convert PowerPoint Presentations to HTML](/slides/zh-hant/python-net/convert-powerpoint-to-html/)。本文重點說明匯出時影像連結的部分。

## **連結影像匯出運作方式**

在 .NET 與 Java 中，[ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/ilinkembedcontroller/) 代表匯出程式用來決定資源是內嵌還是連結的回呼介面。透過 .NET 的 Python 端，目前無法直接實作此 .NET 回呼介面，因此實務上會採取以下工作流程：

1. 使用 [HtmlOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/htmloptions/) 將簡報匯出為 HTML。  
2. 結合 [SlideImageFormat](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/slideimageformat/) 與 [SVGOptions](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides.export/svgoptions/) 讓投影片在 HTML 中以 SVG 形式呈現。  
3. 將 HTML 中 `data:` URL 的 Base64 影像資料移至獨立檔案。  
4. 將原本的 `data:` URL 替換為相對連結，例如 `assets/resource-1.jpg`。

檔案系統路徑與瀏覽器 URL 是兩件不同的事。例如，以下範例會將影像檔寫入磁碟上的 `html-output/assets`，而 HTML 內則包含像 `assets/resource-1.jpg` 這樣的相對 URL。瀏覽器會以包含連結的 HTML 檔案所在位置為基礎，解析這些相對路徑。

## **匯出帶連結影像的 HTML**

以下 Python 範例會建立輸出目錄，將 HTML 檔儲存在該目錄下，並將擷取出的影像放入 `assets` 子目錄，同時將 Base64 影像 URL 重新寫成相對連結。範例會在 Aspose.Slides 提供安全副檔名時，擷取一般的 Base64 影像格式。未被辨識的 Data URL 仍會保持內嵌。

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

匯出完成後，輸出資料夾可能會呈現以下結構：

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

實際產生的檔案取決於簡報內容與匯出選項。例如，點陣圖通常會以 JPEG 或 PNG 匯出。Aspose.Slides 可能會選擇與來源簡報不同的影像編碼方式，以取得較小或較合適的檔案。具有透明度的影像則會以 PNG 匯出。

## **部署時的 URL 選擇**

範例使用相對 URL 前綴：`assets/`。若 `presentation.html` 從 `html-output/presentation.html` 開啟，瀏覽器會載入 `html-output/assets/resource-1.jpg`。

當檔案部署到其他位置時，請使用不同的資產目錄名稱或重新寫入產生的連結：

- 資產目錄與 HTML 檔案位於同一層時，使用 `assets/`。  
- 資產目錄位於 HTML 檔案上一層時，使用 `../assets/`。  
- 檔案上傳至 CDN 或靜態檔案伺服器時，使用 `https://cdn.example.com/presentations/job-123/assets/`。

在伺服器端應用程式中，請為每一次轉換工作使用唯一的輸出目錄或物件儲存前綴，以免覆寫其他匯出的檔案。

## **何時改為內嵌**

當輸出必須是單一檔案（例如電子郵件附件、離線預覽，或需搬移而不附帶資產資料夾的文件）時，內嵌 Base64 HTML 仍然很實用。若 HTML 會由 Web 應用程式提供、儲存在 CMS 中、經過建置管線最佳化，或需要讓瀏覽器獨立快取，則使用連結影像較為合適。

## **常見問題**

**我可以只將影像外部化，其他資源仍保持內嵌嗎？**

可以。範例僅會擷取 `image/*` 類型的 Base64 Data URL，這些類型列於 `EXTENSIONS_BY_CONTENT_TYPE`。其他 Data URL 仍會保持內嵌。

**為什麼匯出的影像副檔名與來源簡報不同？**

Aspose.Slides 可能會在 HTML 匯出時重新編碼點陣圖，以縮小檔案或提升瀏覽器相容性。例如，來源檔案中的影像可能會依渲染結果以 JPEG 或 PNG 形式寫出。

**移動 HTML 檔後相對 URL 還能正常運作嗎？**

相對 URL 只能在保持相同的相對資料夾結構時才有效。若 HTML 仍然引用 `assets/resource-1.png`，則 `assets` 資料夾必須與 HTML 檔案同層，除非您改寫為不同的 URL 前綴。

**伺服器端應用程式可以重複使用同一個輸出資料夾嗎？**

不要。請為每一次轉換工作使用唯一的輸出目錄或儲存前綴，以避免檔名衝突並防止一個匯出覆寫另一個匯出的資源。