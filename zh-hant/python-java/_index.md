---
title: Aspose.Slides for Python via Java
second_title: Aspose.Slides for Python
type: docs
weight: 47
url: /zh-hant/python-java/
is_root: true
keywords:
- Aspose.Slides for Python via Java
- Python PowerPoint 函式庫
- 在 Python 中管理 PowerPoint 簡報
- 在 Python 中讀寫 PowerPoint
- 在 Python 中編輯 PowerPoint 投影片
- 在 Python 中將 PowerPoint 匯出為 PDF
- 在 Python 中將 PowerPoint 匯出為 SVG
- 在 Python 中預覽投影片
- 在 Python 中為投影片加入音訊和影片
- 無需 Microsoft Office 的 PowerPoint
- Python
- Java
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for Python via Java，建立第一個簡報，並查找常見任務指南、API 參考文件與支援資訊。"
---
<img src="aspose_slides-for-python-via-java.png" alt="Aspose.Slides for Python via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Python via Java 是一個用於在 Python 應用程式中建立、讀取、編輯和轉換 PowerPoint 與 OpenDocument 簡報的函式庫，無需 Microsoft PowerPoint；它透過 JPype 在您的 Python 程序中執行 Aspose.Slides Java 引擎。

它可載入與保存 PPT、PPTX、PPS、POT 與 ODP，包括含巨集與範本的變體，並匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 與圖像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>快速入門</p>
<ul>
<li><a href="/slides/zh-hant/python-java/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/python-java/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/python-java/getting-started/">快速入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/python-java/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/python-java/evaluate-aspose-slides/">試用限制</a></li>
<li><a href="/slides/zh-hant/python-java/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/python-java/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/python-java/save-presentation/">保存簡報</a></li>
<li><a href="/slides/zh-hant/python-java/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/python-java/convert-slide/">將投影片渲染為影像</a></li>
<li><a href="/slides/zh-hant/python-java/manage-text/">編輯文字與圖形</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/python-java/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/python-java/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/python-java/manage-media-files/">音訊與影片</a></li>
<li><a href="/slides/zh-hant/python-java/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/python-java/merge-presentation/">合併簡報</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/python-java/examples/">依投影片元素分類的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>參考</p>
<ul>
<li><a href="https://reference.aspose.com/slides/python-java/">API 參考文件</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/release-notes/">發行說明</a></li>
<li><a href="/slides/zh-hant/python-java/known-issues/">已知問題</a></li>
<li><a href="https://products.aspose.com/slides/python-java/">產品頁面</a></li>
<li><a href="https://releases.aspose.com/slides/python-java/">下載</a></li>
</ul>
<p>支援</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">免費支援論壇</a></li>
<li><a href="https://helpdesk.aspose.com/">付費支援服務台</a></li>
</ul>
</div>
</div>

------

## **您的第一個簡報**

安裝 Python 和 JDK，設定 `JAVA_HOME`，並依照 [安裝](/slides/zh-hant/python-java/installation/) 所述建立並啟用虛擬環境。然後從 PyPI 安裝 JPype 和 Aspose.Slides：

```sh
python -m pip install JPype1 aspose-slides-java
```

將此程式碼儲存為 *hello.py*。它會啟動 Java 虛擬機器，於新簡報的第一張投影片加入帶文字的雲形狀，並保存簡報：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# 建立一個只有一張空白投影片的簡報。
presentation = Presentation()
try:
    # 取得第一張投影片。
    slide = presentation.getSlides().get_Item(0)

    # 新增雲形狀並設定其文字。
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

此腳本會將 *new_presentation.pptx* 保存為一張投影片，該投影片包含帶有文字「Hello, Aspose!」的雲形狀。若未取得授權，儲存的檔案會加上評估水印 — 請參閱 [授權](/slides/zh-hant/python-java/licensing/)。欲了解更多建立與填充簡報的方式，請參閱 [建立簡報](/slides/zh-hant/python-java/create-presentation/)。