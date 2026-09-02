---
title: 如何在 Docker 中執行 Aspose.Slides
linktitle: Docker 中的 Aspose.Slides
type: docs
weight: 150
url: /zh-hant/python-net/how-to-run-aspose-slides-in-docker/
keywords:
- Docker 中的 Aspose.Slides
- Docker 容器
- Dockerfile
- Linux
- libgdiplus
- ICU
- OpenSSL
- 字型
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "在 Docker 中執行 Aspose.Slides for Python via .NET：可用的 Dockerfile、套件所需的原生函式庫、字型設定，以及容器內的授權方式。"
---
## **概觀**

Aspose.Slides for Python via .NET 在 Linux 容器中執行，但此套件是包裹在 .NET Core 3.1 執行時的 Python 包裝器。該執行時需要三個原生程式庫，而精簡版 Python 映像檔並未提供，且對版本有特定要求。本文提供可用的 Dockerfile，說明每個相依性的來源，並示範如何加入字型與授權。

## **可工作的 Dockerfile**

```dockerfile
FROM python:3.11-slim-bullseye

RUN apt-get update && apt-get install -y --no-install-recommends \
        libgdiplus \
        libicu67 \
        libfontconfig1 \
        fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*

RUN pip install --no-cache-dir aspose.slides

WORKDIR /app
COPY app.py .
CMD ["python", "app.py"]
```

`app.py`：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    shape.text_frame.text = "Created inside a Docker container"
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)
```

建置與執行：

```bash
docker build -t aspose-slides-python .
docker run --rm aspose-slides-python
```

## **為何基礎映像是 Debian 11**

`aspose.slides` 的 wheel 內含 **.NET Core 3.1** 執行時，而該執行時早於目前 Debian 版本所提供的函式庫版本。於 Debian 12 與 13 中容器能成功建置，卻在首次呼叫 `Presentation()` 時失敗：

```
Process terminated. Couldn't find a valid ICU package installed on the system.
```

訊息具有誤導性——ICU 確實已安裝於這些映像，但版本為 ICU 72 或 76，而 .NET Core 3.1 只識別較舊的主版本。Debian 12 另有 OpenSSL 3，導致第二個失敗：

```
No usable version of libssl was found
```

`python:3.11-slim-bullseye` 為 Debian 11，提供了捆綁執行時所需的兩個版本：

| 套件 | Debian 11 上的版本 | 為何需要 |
|---|---|---|
| `libgdiplus` | 6.0.4 | 用於呈現圖形、文字與影像的 GDI+ 實作 |
| `libicu67` | 67.1 | 全球化資料。較新主版本不被 .NET Core 3.1 辨識 |
| `libssl1.1` | 1.1.1w | 加密功能。預先安裝於 Debian 11；Debian 12 以上不存在 |
| `libfontconfig1` | — | 字型偵測 |

`libssl1.1` 已在基礎映像中存在，故不需在 `apt-get install` 中列出。

若必須使用較新的基礎映像，可設定 `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=1` 以繞過 ICU 要求。此設定會停用文化特定格式化，但 **不會** 解決 OpenSSL 的問題，因此 Debian 11 仍是較簡單的選擇。

## **字型**

精簡映像根本不包括任何字型。若未安裝至少一種字型，文字會在 PDF、影像與 HTML 輸出中呈現為空白方框。`fonts-dejavu-core` 是一個小型、通用的起點。

若要符合投影片的預期外觀，請將投影片使用的字型複製到映像中，並指向 Aspose.Slides：

```dockerfile
COPY fonts/ /usr/share/fonts/truetype/custom/
RUN fc-cache -f
```

```py
import aspose.slides as slides

slides.FontsLoader.load_external_fonts(["/usr/share/fonts/truetype/custom/"])
```

## **容器內的授權**

不要將授權檔案建入映像——任何拉取映像的人都會取得授權。應在執行時掛載：

```bash
docker run --rm -v /path/on/host:/license aspose-slides-python
```

```py
import aspose.slides as slides

license = slides.License()
license.set_license("/license/Aspose.Slides.Python.NET.lic")
```

若未提供授權，函式庫會以評估模式執行，會加上浮水印並限制可處理的投影片數量。詳情請參閱[Licensing](/slides/zh-hant/python-net/licensing/)。

## **記憶體**

將內容渲染為 PDF 或影像比讀取檔案更耗記憶體。記憶體限制嚴格的容器可能在轉換過程中被 OOM killer 終止，通常會表現在程式未出現 Python 堆疊追蹤而直接結束。若發生此情況，請先提升容器的記憶體限制，再進一步檢查程式碼。