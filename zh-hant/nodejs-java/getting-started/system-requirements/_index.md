---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/nodejs-java/system-requirements/
keywords:
- 系統需求
- 作業系統
- 安裝
- 相依性
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- Node.js
- JavaScript
- Aspose.Slides
description: "探索 Aspose.Slides for Node.js via Java 的系統需求。確保在 Windows、Linux 和 macOS 上順暢支援 PowerPoint 和 OpenDocument。"
---
## **簡介**

Aspose.Slides for Node.js via Java 不需要安裝任何第三方產品，例如 Microsoft PowerPoint。Aspose.Slides 本身是一個用於建立、修改、轉換和渲染各種格式文件的引擎，包含 Microsoft PowerPoint 簡報格式。

## **支援的作業系統**

Aspose.Slides for Node.js via Java 支援任何執行 Java 執行環境的 32 位元或 64 位元作業系統，包括但不限於：

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu, CentOS 等)

### **Mac**
- Mac OS X

## **常見問答**

**我需要安裝 Microsoft PowerPoint 以進行轉換和渲染嗎？**

不需要，PowerPoint 並非必須；Aspose.Slides 是一個獨立的引擎，用於[creating](/slides/zh-hant/nodejs-java/create-presentation/)、修改、[converting](/slides/zh-hant/nodejs-java/convert-presentation/)、以及[rendering](/slides/zh-hant/nodejs-java/convert-powerpoint-to-png/) 簡報。

**正確渲染需要哪些字型？**

實務上，簡報中使用的字型或適當的[替代字型](/slides/zh-hant/nodejs-java/font-substitution/) 必須可取得。為確保在 Linux/macOS 上的渲染一致，建議安裝常見的字型套件。

**為什麼自訂字型在 Linux 上會顯示為備援字型或缺少文字？**

如果字型檔的名稱表條目不一致或受損，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效的記錄，導致字型無法解析。使用已修正名稱表的字型版本或安裝一致的替代字型即可解決此問題。