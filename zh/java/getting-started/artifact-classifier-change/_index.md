---
title: 构件分类器更改
type: docs
weight: 60
url: /zh/java/artifact-classifier-change/
keywords:
- 分类器 Aspose.Slides
- 构件分类器
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "Aspose.Slides for Java 现在使用 jdk8 分类器，而不是 jdk16。了解原因以及如何更新您的依赖项。"
---
## **构件分类器从 `jdk16` 更改为 `jdk8`**

从版本 **26.10** 开始，我们已将已发布构件中使用的分类器从 **`jdk16`**（Java 6）更改为 **`jdk8`**（Java 8）。

### **更改内容**

| | 之前 | 之后 |
|---|---|---|
| 分类器 | `jdk16` | `jdk8` |
| 最低 Java 版本 | Java 1.6 | Java 8 |

**之前:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**之后:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **为什么进行此更改**

经过内部评审，我们决定**停止支持不再提供价值且严重影响维护的旧版 Java**。Java 8 被选为所有用户的新安全基线。  
因此，分类器已更新为反映实际的最低支持版本。我们还遵循了当前 Oracle 的命名约定，产品正式称为 **JDK 8**（而非旧的 `1.8` 格式）。

### **您需要执行的操作**

1. 在依赖声明中将 **分类器** 从 `jdk16` 更新为 `jdk8`。

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

2. 确保您的运行环境为 Java 8 或更高版本。

3. 刷新任何锁定文件或依赖缓存，以去除旧分类器的引用。

### **迁移说明：jdk16 与 jdk8**

从 26.10 版本开始，jdk16 与 jdk8 两个分类器均会提供兼容 Java 8 的 JAR（使用源/目标兼容性设为 Java 8 构建）。

- `jdk16` → 仍继续发布，以保持向后兼容（现有集成）。
- `jdk8` → 作为面向 Java 8 环境的新首选分类器引入。

⚠️ 注：此双重发布阶段计划于 2027 年 3 月 31 日结束。此后，jdk16 分类器将被淘汰，仅支持 jdk8。

### **兼容性说明**

- `jdk16` 分类器将在 **2027 年 3 月 31 日**之后 **不再发布**。
- 如果仍需 Java 1.6 支持，请保持使用之前的主要版本线，直至完成迁移。

### **需要帮助吗？**

如果在迁移过程中遇到问题，请联系 [Aspose 支持](https://forum.aspose.com/) 获取进一步帮助。