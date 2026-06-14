---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/php-java/system-requirements/
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
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP via Java 的系統需求。確保在 Windows、Linux 與 macOS 上順暢支援 PowerPoint 與 OpenDocument。"
---
## **介紹**

Aspose.Slides for PHP via Java 不需要安裝任何第三方產品，例如 Microsoft PowerPoint。Aspose.Slides 本身是一個用於建立、修改、轉換與渲染各種格式文件（包括 Microsoft PowerPoint 簡報格式）的引擎。

## **支援的作業系統**

Aspose.Slides for Java 支援執行 Java 執行環境的任何 32 位元或 64 位元作業系統，包括但不限於：

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
- Linux (Ubuntu, OpenSUSE, CentOS 及其他)

### **Mac**
- Mac OS X

## **常見問題**

**轉換與呈現時是否需要安裝 Microsoft PowerPoint？**

不，PowerPoint 不是必要的；Aspose.Slides 是一個獨立的引擎，用於[建立](/slides/zh-hant/php-java/create-presentation/)、修改、[轉換](/slides/zh-hant/php-java/convert-presentation/)、以及[轉譯](/slides/zh-hant/php-java/convert-powerpoint-to-png/)投影片。

**正確呈現需要哪些字型？**

實際上，投影片中使用的字型或適當的[替代字型](/slides/zh-hant/php-java/font-substitution/)必須可用。為確保在 Linux/macOS 上的呈現一致，建議安裝常見的字型套件。

**為什麼在 Linux 上自訂字型會以備用或遺失文字呈現？**

如果字型檔的名稱表條目不一致或已損壞，Linux 的字型匹配堆疊（FreeType/fontconfig）可能會選取無效的記錄，導致字型無法解析。使用已修正名稱表的字型版本或安裝一致的替代字型即可解決此問題。