---
title: "Aspose.Slides for Python via Java"
second_title: "Aspose.Slides for Python"
type: docs
weight: 47
url: /zh-hant/python-java/
is_root: true
keywords:
- "Aspose.Slides for Python via Java"
- "Python PowerPoint 函式庫"
- "在 Python 中管理 PowerPoint 簡報"
- "在 Python 中讀取與寫入 PowerPoint"
- "在 Python 中編輯 PowerPoint 投影片"
- "在 Python 中將 PowerPoint 匯出為 PDF"
- "在 Python 中將 PowerPoint 匯出為 SVG"
- "在 Python 中預覽投影片"
- "在 Python 中為投影片新增音訊與視訊"
- "無需 Microsoft Office 的 PowerPoint"
- "Python"
- "Java"
- "Aspose.Slides"
description: "從這裡開始：安裝 Aspose.Slides for Python via Java，建立第一個簡報，並尋找常見任務指南、API 參考與支援資訊。"
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java 是一個用於在 Python 應用程式中建立、讀取、編輯和轉換 PowerPoint 與 OpenDocument 簡報的函式庫，無需 Microsoft PowerPoint；它透過 JPype 在您的 Python 程序中執行 Aspose.Slides Java 引擎。

它可載入並儲存 PPT、PPTX、PPS、POT 與 ODP，包括支援巨集的檔案與範本變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 以及影像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>入門</p>
<ul>
<li><a href="/slides/zh-hant/python-java/installation/">Installation</a></li>
<li><a href="/slides/zh-hant/python-java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/zh-hant/python-java/getting-started/">Getting started guide</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/python-java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/zh-hant/python-java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/zh-hant/python-java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 構建</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/python-java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/zh-hant/python-java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/zh-hant/python-java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/zh-hant/python-java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/zh-hant/python-java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>簡報工作流程</p>
<ul>
<li><a href="/slides/zh-hant/python-java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/zh-hant/python-java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/zh-hant/python-java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/zh-hant/python-java/presentation-design/">Slide design</a></li>
<li><a href="/slides/zh-hant/python-java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/python-java/examples/">Examples by slide element</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>參考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">Release notes</a></li>
<li><a href="/slides/zh-hant/python-java/known-issues/">Known issues</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">Download</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

安裝 Python 與 JDK，設定 `JAVA_HOME`，並依照 [Installation](/slides/zh-hant/python-java/installation/) 中的說明建立並啟用虛擬環境。然後從 PyPI 安裝 JPype 與 Aspose.Slides：

```sh
python -m pip install JPype1 aspose-slides-java
```

將此程式碼儲存為 *hello.py*。它會啟動 Java 虛擬機器，於新簡報的第一張投影片加入帶文字的雲狀圖形，並儲存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立一個包含單一空白投影片的簡報。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增雲形圖案並設定其文字。
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # 將簡報儲存為 PPTX 檔案。
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

在相同的虛擬環境中執行它：

```sh
python hello.py
```

此腳本會儲存 *new_presentation.pptx*，其中包含一張投影片，內有帶文字「Hello, Aspose!」的雲狀圖形。若未取得授權，儲存的檔案會帶有評估水印 — 請參閱 [Licensing](/slides/zh-hant/python-java/licensing/)。想了解更多建立與填充簡報的方法，請參考 [Create Presentations](/slides/zh-hant/python-java/create-presentation/).