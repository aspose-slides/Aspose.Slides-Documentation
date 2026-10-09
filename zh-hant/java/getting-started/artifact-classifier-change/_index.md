---
title: Artifact 分類器變更
type: docs
weight: 60
url: /zh-hant/java/artifact-classifier-change/
keywords:
- 分類器 Aspose.Slides
- artifact 分類器
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 現在使用 jdk8 分類器取代 jdk16。了解原因及如何更新您的相依性。"
---
## **Artifact 分類器從 `jdk16` 變更為 `jdk8`**

從 **26.10** 版開始，我們將已發布 artifact 中使用的分類器從 **`jdk16`**（Java 6）變更為 **`jdk8`**（Java 8）。

### **變更內容**

| | 之前 | 之後 |
|---|---|---|
| 分類器 | `jdk16` | `jdk8` |
| 最低 Java 版本 | Java 1.6 | Java 8 |

**之前:**  
```
com.aspose:aspose-slides:26.10:jdk16
```

**之後:**  
```
com.aspose:aspose-slides:26.10:jdk8
```

### **為何做此變更**

經過內部審查後，我們決定**停止支援較舊的 Java 版本**，因為這些版本已不再提供價值且阻礙維護。Java 8 被選為所有使用者的新安全基礎版。

因此，我們更新了分類器以反映實際的最低支援版本。我們同時遵循目前 Oracle 的命名慣例，產品正式稱為 **JDK 8**（而非舊式的 `1.8` 格式）。

### **您需要執行的步驟**

1. **更新分類器**，在您的相依性聲明中將 `jdk16` 改為 `jdk8`。

   **Maven:**  
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle:**  
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **驗證您的執行環境**為 Java 8 或更高版本。

3. **刷新所有鎖定檔案**或相依性快取，以解除舊分類器的固定。

### **遷移說明：jdk16 與 jdk8**

自 26.10 版起，jdk16 與 jdk8 兩個分類器皆會提供相容 Java 8 的 JAR（以 Java 8 為 source/target 兼容性編譯）。

- `jdk16` → 繼續發布以維持向下相容性（現有整合）。
- `jdk8` → 作為 Java 8 環境的新首選分類器推出。

⚠️ 注意：此雙重發布階段預計於 2027 年 3 月 31 日結束。此日期之後，jdk16 分類器將被淘汰，僅支援 jdk8。

### **相容性說明**

- `jdk16` 分類器在 **2027 年 3 月 31 日**之後**不再發布**。
- 如果您仍需支援 Java 1.6，請保持使用先前的主要版本系列，直至能夠遷移。

### **需要協助嗎？**

如果在遷移過程中遇到問題，請聯絡 [Aspose 支援](https://forum.aspose.com/) 以取得進一步協助。