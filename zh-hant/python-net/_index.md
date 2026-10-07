---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /zh-hant/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- PowerPoint 自動化 Python
- Python PPT 函式庫
- Python 匯出 PowerPoint 為 PDF
- Python 匯出 PowerPoint 為 SVG
- 在 Python 中編輯 PowerPoint
- Python PowerPoint（無需 Microsoft Office）
- 使用 Python 管理 PPTX
- Python 投影片預覽
- Python 為投影片新增音訊
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for Python via .NET，建立第一個投影片，並找到常見任務指南、API 參考與支援。"
---
<img src="aspose_slides-for-python.png" alt="Aspose.Slides for Python via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via .NET 是一個 Python 函式庫，用於建立、讀取、編輯和轉換 PowerPoint 與 OpenDocument 投影片，無需 Microsoft PowerPoint 或 Microsoft Office。

它可以載入與儲存 PPT、PPTX、PPS、POT 以及 ODP，包含支援巨集與範本的變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 與圖片。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>快速入門</p>
<ul>
<li><a href="/slides/zh-hant/python-net/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/python-net/create-presentation/">建立您的第一個投影片</a></li>
<li><a href="/slides/zh-hant/python-net/getting-started/">開始使用指南</a></li>
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
<li><a href="/slides/zh-hant/python-net/open-presentation/">開啟投影片</a></li>
<li><a href="/slides/zh-hant/python-net/save-presentation/">儲存投影片</a></li>
<li><a href="/slides/zh-hant/python-net/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/python-net/convert-slide/">將投影片渲染為圖片</a></li>
<li><a href="/slides/zh-hant/python-net/manage-text/">編輯文字與形狀</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/python-net/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/python-net/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/python-net/manage-media-files/">音訊與視訊</a></li>
<li><a href="/slides/zh-hant/python-net/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/python-net/merge-presentation/">合併投影片</a></li>
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
<li><a href="https://reference.aspose.com/slides/python-net/">API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/release-notes/">版本說明</a></li>
<li><a href="https://products.aspose.com/slides/python-net/">產品頁面</a></li>
<li><a href="https://releases.aspose.com/slides/python-net/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個投影片**

從 PyPI 安裝套件：

```bash
pip install aspose.slides
```

此套件已包含它所使用的 .NET 執行時，無需自行安裝 .NET。於 Linux 上，還需安裝 libgdiplus 與 ICU 函式庫，若使用 Debian 或 Ubuntu 的系統 Python，請在虛擬環境中執行指令。macOS 還有其他前置需求，我們尚未驗證該平台的安裝方式。請參考[安裝](/slides/zh-hant/python-net/installation/)了解指令、macOS 前置需求與支援的 Python 版本。

將此程式碼儲存為 *hello.py*：

```py
import aspose.slides as slides

# 實例化代表投影片檔的 Presentation 類別。
with slides.Presentation() as presentation:
    # 取得第一張投影片。
    slide = presentation.slides[0]

    # 新增類型為 CLOUD 的自動形狀。
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # 將投影片儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

使用 `python hello.py` 執行。此腳本會在當前資料夾中儲存 *new_presentation.pptx*，其中包含一張投影片，內有雲形狀文字「Hello, Aspose!」。若未授權，儲存的檔案會帶有評估水印——請參見[授權](/slides/zh-hant/python-net/licensing/)。欲了解更多建立與填充投影片的方法，請參考[建立投影片](/slides/zh-hant/python-net/create-presentation/)。