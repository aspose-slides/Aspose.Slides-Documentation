---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /zh-hant/cpp/
keywords:
- 文件說明
- 簡報處理
- 簡報轉換
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "從此開始：安裝 Aspose.Slides for C++、建立第一個簡報，並找到常見任務的指南、API 參考與支援。"
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ 是一個原生 C++ 函式庫，用於建立、讀取、編輯與轉換 PowerPoint 與 OpenDocument 簡報，無需 Microsoft PowerPoint 或 Office Automation。

它可載入與儲存 PPT、PPTX、PPS、POT 以及 ODP，包括巨集啟用與範本變體，並可匯出為 PDF、XPS、HTML、SVG、TIFF、Markdown 與影像。

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>開始使用</b></p>
<hr>
<p>開始使用</p>
<ul>
<li><a href="/slides/zh-hant/cpp/installation/">安裝</a></li>
<li><a href="/slides/zh-hant/cpp/create-presentation/">建立您的第一個簡報</a></li>
<li><a href="/slides/zh-hant/cpp/getting-started/">入門指南</a></li>
</ul>
<p>評估</p>
<ul>
<li><a href="/slides/zh-hant/cpp/supported-file-formats/">支援的檔案格式</a></li>
<li><a href="/slides/zh-hant/cpp/evaluate-aspose-slides/">試用版限制</a></li>
<li><a href="/slides/zh-hant/cpp/licensing/">授權</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>使用 Slides 建置</b></p>
<hr>
<p>常見任務</p>
<ul>
<li><a href="/slides/zh-hant/cpp/open-presentation/">開啟簡報</a></li>
<li><a href="/slides/zh-hant/cpp/save-presentation/">儲存簡報</a></li>
<li><a href="/slides/zh-hant/cpp/convert-powerpoint-to-pdf/">轉換為 PDF</a></li>
<li><a href="/slides/zh-hant/cpp/convert-slide/">將投影片渲染為影像</a></li>
<li><a href="/slides/zh-hant/cpp/manage-text/">編輯文字與圖形</a></li>
</ul>
<p>Slides 工作流程</p>
<ul>
<li><a href="/slides/zh-hant/cpp/powerpoint-charts/">圖表</a></li>
<li><a href="/slides/zh-hant/cpp/powerpoint-animation/">動畫</a></li>
<li><a href="/slides/zh-hant/cpp/manage-media-files/">音訊與視訊</a></li>
<li><a href="/slides/zh-hant/cpp/presentation-design/">投影片設計</a></li>
<li><a href="/slides/zh-hant/cpp/merge-presentation/">合併簡報</a></li>
</ul>
<p>範例</p>
<ul>
<li><a href="/slides/zh-hant/cpp/examples/">依投影片元素的範例</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">GitHub 上的範例</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>參考與支援</b></p>
<hr>
<p>參考文件</p>
<ul>
<li><a href="https://reference.aspose.com/slides/cpp/">API 參考</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/release-notes/">發行說明</a></li>
<li><a href="/slides/zh-hant/cpp/known-issues/">已知問題</a></li>
<li><a href="https://products.aspose.com/slides/cpp/">產品頁面</a></li>
<li><a href="https://releases.aspose.com/slides/cpp/">下載</a></li>
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

在 Windows 上，於 Visual Studio 中建立 C++ **Console App** 專案，並在套件管理員主控台 (**Tools** > **NuGet Package Manager** > **Package Manager Console**) 安裝 NuGet 套件：

```powershell
Install-Package Aspose.Slides.Cpp
```

在 Linux 上，下載 Linux ZIP 套件，並依照 [安裝](/slides/zh-hant/cpp/installation/#linux) 中描述的方式設定 CMake 專案。

然後將此程式碼作為您的程式主要來源檔。它會建立一個包含文字方塊的簡報並儲存：

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

在 Windows 上執行時，於工具列選取 **x64** 平台並按下 **Ctrl+F5**。在 Linux 上，將其儲存為專案資料夾中的 *main.cpp*，然後在該處建置並執行：

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

此程式會儲存含有一個文字方塊之投影片的 *hello.pptx*。若未取得授權，儲存的檔案會帶有評估浮水印 — 請參閱 [授權](/slides/zh-hant/cpp/licensing/)。欲了解更多建立與填寫簡報的方法，請參閱 [建立簡報](/slides/zh-hant/cpp/create-presentation/).