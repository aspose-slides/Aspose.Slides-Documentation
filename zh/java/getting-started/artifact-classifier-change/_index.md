---
title: 声明
type: docs
weight: 60
url: /zh/java/artifact-classifier-change/
keywords:
- Aspose.Slides 分类器
- 制品分类器
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
description: "Aspose.Slides for Java 现在使用 jdk8 分类器，而不再使用 jdk16。了解原因以及如何更新您的依赖项。"
---
## **Artifact 分类器从 `jdk16` 更改为 `jdk8`**

从版本 **26.10** 开始，我们已将已发布制品中使用的分类器从 **`jdk16`**（Java 6）更改为 **`jdk8`**（Java 8）。

### **变更内容**

| | 之前 | 之后 |
|---|---|---|
| 分类器 | `jdk16` | `jdk8` |
| 最低 Java 版本 | Java 1.6 | Java 8 |

**之前：**
```
com.aspose:aspose-slides:26.10:jdk16
```

**之后：**
```
com.aspose:aspose-slides:26.10:jdk8
```

### **为何进行此更改**

在内部审查后，我们决定**停止对较旧 Java 版本的支持**，因为这些版本已不再提供价值且对维护造成阻碍。Java 8 被选为所有用户的新安全基准。

因此，分类器已更新以反映实际的最低支持版本。我们还遵循了当前 Oracle 的命名约定，产品官方称为 **JDK 8**（而非传统的 `1.8` 格式）。

### **您需要做的操作**

1. **更新分类器**，在依赖声明中将 `jdk16` 更改为 `jdk8`。

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

2. **验证运行时环境**为 Java 8 或更高。

3. **刷新所有锁定文件**或依赖缓存，以解除对旧分类器的锁定。

### **迁移说明：jdk16 与 jdk8**

从 26.10 版本开始，jdk16 和 jdk8 两个分类器都将提供兼容 Java 8 的 JAR（构建时源/目标兼容性设为 Java 8）。

- `jdk16` → 继续发布以保持向后兼容（现有集成）。
- `jdk8` → 作为面向 Java 8 环境的新首选分类器推出。

⚠️ 注：此双发布阶段计划于 2027 年 3 月 31 日结束。此日期之后，jdk16 分类器将被淘汰，仅支持 jdk8。

### **兼容性说明**

- `jdk16` 分类器在 **2027 年 3 月 31 日** 之后 **不再发布**。
- 如果仍需 Java 1.6 支持，请继续使用先前的主要版本线路，直至能够迁移。

### **需要帮助吗？**

如果在迁移过程中遇到问题，请联系 [Aspose 支持](https://forum.aspose.com/) 获取进一步帮助。