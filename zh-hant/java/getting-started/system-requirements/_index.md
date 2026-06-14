---
title: 系統需求
type: docs
weight: 80
url: /zh-hant/java/system-requirements/
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
- Java
- Aspose.Slides
description: "探索 Aspose.Slides for Java 的系統需求。確保在 Windows、Linux 與 macOS 上無縫支援 PowerPoint 與 OpenDocument。"
---
## **概覽**
Aspose.Slides for Java 不需要安裝 Microsoft PowerPoint，因為 Aspose.Slides 本身即為 Microsoft PowerPoint 文件的建立、轉換、版面配置與呈現引擎。
## **支援的作業系統**
Aspose.Slides for Java 支援任何執行 Java 執行環境的 32 位元或 64 位元作業系統，包括但不限於：
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
- Linux (Ubuntu、OpenSUSE、CentOS 等)

### **Mac**
- Mac OS X

## **支援的 Java 版本**
Aspose.Slides for Java 支援 J2SE 6.0（Java 1.6）及更高版本。

## **常見問與答**

**是否需要安裝 Microsoft PowerPoint 才能進行轉換與呈現？**

不需要，PowerPoint 並非必要；Aspose.Slides 是一個獨立的引擎，用於[建立](/slides/zh-hant/java/create-presentation/)、修改、[轉換](/slides/zh-hant/java/convert-presentation/)以及[呈現](/slides/zh-hant/java/convert-powerpoint-to-png/)簡報。

**正確呈現需要哪些字型？**

實際上，需要簡報中使用的字型或適當的[替代字型](/slides/zh-hant/java/font-substitution/)才能正確呈現。為確保在 Linux/macOS 上渲染一致，建議安裝常見的字型套件。

**為何自訂字型在 Linux 上會以備援字型或缺字顯示？**

如果字型檔的名稱表 (name-table) 條目不一致或損壞，Linux 的字型匹配堆疊 (FreeType/fontconfig) 可能選取到無效記錄，導致字型無法解析。使用名稱表已修正的字型版本或安裝一致的替代字型即可解決此問題。