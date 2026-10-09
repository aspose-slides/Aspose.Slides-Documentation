---
title: 声明
type: docs
weight: 60
url: /zh/java/artifact-classifier-change/
keywords:
- 分类器 Aspose.Slides
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
description: "Aspose.Slides for Java 现已使用 jdk8 分类器取代 jdk16。了解原因以及如何更新您的依赖项。"
---
## Artifact Classifier Change from `jdk16` to `jdk8`

自 **26.10** 版本起，我们已将已发布制品中使用的分类器从 **`jdk16`**（Java 6）更改为 **`jdk8`**（Java 8）。

### What changed

| | 之前 | 之后 |
|---|---|---|
| Classifier | `jdk16` | `jdk8` |
| Minimum Java version | Java 1.6 | Java 8 |

**Before:**
```
com.aspose:aspose-slides:26.10:jdk16
```

**After:**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Why we made this change

经过内部评审后，我们决定 **放弃对已不再提供价值且阻碍维护的旧 Java 版本的支持**。Java 8 被选为所有使用者的新安全基准。

因此，分类器已更新以反映实际的最低受支持版本。我们还遵循了当前 Oracle 的命名约定，产品正式称为 **JDK 8**（而非旧的 `1.8` 形式）。

### What you need to do

1. **Update the classifier** in your dependency declarations from `jdk16` to `jdk8`.

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

2. **Verify your runtime environment** is Java 8 or higher.

3. **Refresh any lock files** or dependency caches that pin the old classifier.

### Migration Note: jdk16 and jdk8

自 26.10 版本起，jdk16 与 jdk8 分类器均会提供兼容 Java 8 的 JAR（使用 Java 8 的 source/target 兼容性构建）。

 - `jdk16` → 继续发布，以保持向后兼容（现有集成）。
 - `jdk8` → 作为 Java 8 环境的首选分类器推出。

⚠️ Note: This dual‑publishing phase is scheduled to end on March 31, 2027. After this date, the jdk16 classifier will be retired, and only jdk8 will be supported.

### Compatibility notes

- `jdk16` 分类器在 **2027 年 3 月 31 日** 之后 **不再发布**。
- 如果仍需 Java 1.6 支持，请保持使用之前的主要版本线，直至能够迁移。

### Need help?

如果在迁移过程中遇到问题，请联系 [Aspose 支持](https://forum.aspose.com/) 获取进一步帮助。