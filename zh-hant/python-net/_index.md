---
title: 適用於 .NET 的 Python 版 Aspose.Slides
second_title: 適用於 Python 的 Aspose.Slides
type: docs
weight: 35
url: /zh-hant/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint 自動化 Python
- Python PPT 函式庫
- 使用 Python 將 PowerPoint 匯出為 PDF
- 使用 Python 將 PowerPoint 匯出為 SVG
- 在 Python 中編輯 PowerPoint
- 無需 Microsoft Office 的 Python PowerPoint
- 使用 Python 管理 PPTX
- Python 簡報預覽
- Python 為簡報加入音訊
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for Python via .NET，建立第一個簡報，並尋找常見任務指南、API 參考文件與支援資訊。"
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET 是一個用於建立、讀取、編輯及轉換 PowerPoint 與 OpenDocument 簡報的 Python 函式庫，無需 Microsoft PowerPoint 或 Microsoft Office。

它可載入與儲存 PPT、PPTX、PPS、POT 以及 ODP，包含支援巨集與範本的變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 以及影像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>快速入門</p>
<ul>
<li><a href="/slides/zh-hant/python-net/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/python-net/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/python-net/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/python-net/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/python-net/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/python-net/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/python-net/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/python-net/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/python-net/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/python-net/convert-slide/">將投影片渲染為影像</a></li>
<li><a href="/slides/zh-hant/python-net/manage-text/">編輯文字與圖形</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/python-net/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/python-net/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/python-net/manage-media-files/">音訊與影片</a></li>
<li><a href="/slides/zh-hant/python-net/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/python-net/merge-presentation/">合併簡報</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/python-net/examples/">依投影片元素的範例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Python-via-.NET">GitHub 上的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>參考文件</p>
<ul>
<li><a href="https://reference.aspose.com/slides/zh-hant/python-net/">API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/zh-hant/python-net/release-notes/">發行說明</a></li>
<li><a href="https://releases.aspose.com/slides/zh-hant/python-net/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/zh-hant/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

Install the package from PyPI:

```bash
pip install aspose.slides
```

此套件已包含它所使用的 .NET 執行環境，因此您無需自行安裝 .NET。在 Linux 上，還需要安裝 libgdiplus 與 ICU 函式庫，若使用 Debian 或 Ubuntu 的系統 Python，請在虛擬環境中執行指令。macOS 有其他先決條件，我們尚未驗證該平台的安裝。請參閱[Installation](/slides/zh-hant/python-net/installation/) 了解指令、macOS 先決條件以及支援的 Python 版本。

Save this code as *hello.py*:

```py
import aspose.slides as slides

# 實例化表示簡報檔案的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 加入類型為 CLOUD 的自動圖形。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

使用 `python hello.py` 執行它。此腳本會在目前資料夾中儲存 *new_presentation.pptx*，其中包含一張帶有雲狀圖形且文字為「Hello, Aspose!」的投影片。未取得授權時，儲存的檔案會帶有評估浮水印——請參閱[Licensing](/slides/zh-hant/python-net/licensing/)。欲了解更多建立與填充簡報的方法，請參閱[Create Presentations](/slides/zh-hant/python-net/create-presentation/)。