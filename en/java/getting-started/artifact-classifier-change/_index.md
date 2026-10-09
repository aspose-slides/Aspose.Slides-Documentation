---
title: Artifact Classifier Change
type: docs
weight: 60
url: /java/artifact-classifier-change/
keywords:
- classifier Aspose.Slides
- artifact cassifier
- use Aspose.Slides
- Aspose.Slides installation
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java now uses the jdk8 classifier instead of jdk16. Learn why and how to update your dependencies."
---


## **Artifact Classifier Change from `jdk16` to `jdk8`**

Starting with version **26.10**, we have changed the classifier used in our published artifacts from **`jdk16`** (Java 6) to **`jdk8`** (Java 8).

### **What changed**

| | Before | After |
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

### **Why we made this change**

After internal review, we decided to **drop support for older Java versions** that were no longer providing value and were actively hindering maintenance. Java 8 was selected as the new, safe baseline for all consumers.

As part of this, the classifier was updated to reflect the actual minimum supported version. We also aligned with the current Oracle naming convention, where the product is officially referred to as **JDK 8** (rather than the legacy `1.8` format).

### **What you need to do**

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

### **Migration Note: jdk16 and jdk8**

Starting version 26.10​, both the jdk16 and jdk8 classifiers will provide Java 8–compatible JARs (built with source/target compatibility set to Java 8).

 - `jdk16` → continues to be published for backward compatibility (existing integrations).
 - `jdk8` → introduced as the new preferred classifier for Java 8 environments.

⚠️ Note: This dual-publishing phase is scheduled to end on March 31, 2027​. After this date, the jdk16 classifier will be retired, and only jdk8 will be supported.

### **Compatibility notes**

- The `jdk16` classifier is **no longer published** after **March 31, 2027**.
- If you still require Java 1.6 support, please remain on the previous major version line until you can migrate.

### **Need help?**

If you encounter issues during migration, please contact [Aspose support](https://forum.aspose.com/) for further assistance.
