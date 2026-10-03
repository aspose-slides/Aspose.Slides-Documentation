---
title: 安全性
type: docs
weight: 160
url: /zh-hant/java/security/
keywords:
- 安全性
- 相依性
- 第三方元件
- Maven
- JAR 簽名
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "瞭解 Aspose.Slides for Java 如何處理簡報、它對專案的相依性會加入什麼、如何驗證 JAR 檔案，以及它包含哪些第三方元件。"
---
## **簡介**

本文彙整使用 Aspose.Slides for Java 的應用程式在安全性評估時通常需要的資訊：函式庫如何處理簡報、它對專案的相依性會加入什麼、如何檢查 JAR 檔案是否來自 Aspose，以及 JAR 檔案中包含了哪些第三方元件。

## **Aspose.Slides 的安全性**

Aspose 在開發其產品時遵循最佳實踐。

* Aspose.Slides for Java 用於建立、修改與轉換簡報。它不會在簡報中執行腳本。Aspose.Slides 會解析簡報結構，讓您的程式碼可以操作物件模型。
* Aspose.Slides 以函式庫的形式解析與解讀文件，且不會執行遠端程式碼。所有 Aspose 產品皆在您的機器上執行，且不會將任何資料傳送至 Aspose。唯一例外是[metered licensing](/slides/zh-hant/java/metered-licensing/)：若您使用此功能，只有您的 API 使用資訊會被處理。
* Aspose 元件在與一般應用程式相同的使用者上下文中執行。因此，Aspose 元件不會對關鍵系統資源構成風險。另外，當 Aspose 元件開啟文件時，巨集不會自動執行。

## **Maven 依賴項**

Aspose.Slides for Java 的 Maven 套件 `com.aspose:aspose-slides` 不宣告任何相依性：其 POM 檔案僅包含套件本身的坐標。將其加入專案時，Maven 只會下載此單一 JAR 檔案，並不會帶入其他檔案。若要列出專案解析的所有套件（含傳遞性相依性），請在專案資料夾中執行以下指令：

```bash
mvn dependency:tree
```

在[安裝](/slides/zh-hant/java/installation/) 範例專案中，輸出僅顯示 Aspose.Slides 為唯一相依性：

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **驗證 JAR 檔案**

Aspose 為 JAR 檔案簽名。要檢查簽名，請在包含該 JAR 檔案的資料夾中使用 JDK 的 `jarsigner` 工具：

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

若簽名有效且自簽署以來未有任何項目變更，指令會顯示 `jar verified.`。此訊息不會顯示簽署者名稱。若要確認簽署者為 Aspose，請加入 `-verbose` 與 `-certs` 參數，並檢查簽署者憑證的發行對象為 `CN=ASPOSE PTY LTD`。當 Maven 下載 JAR 檔案時，也會檢查儲存庫於檔案旁公布的 SHA-1 雜湊值。

## **第三方元件**

Aspose.Slides for Java 包含來自第三方元件的程式碼與資料。它們是 JAR 檔案的一部分，而非獨立的 Maven 套件，因此 `mvn dependency:tree` 及其他讀取 Maven 相依性的工具不會列出它們。JAR 檔案內含有 *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf* 通知文件，列出了這些元件與其授權條款：

| 元件 | 聲明中的授權 |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

若要從 JAR 檔案中擷取此通知文件，請在包含該 JAR 檔案的資料夾中使用 JDK 的 `jar` 工具：

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **常見問題**

**Aspose.Slides for Java 是否使用外部套件？**

如 [Maven 依賴項](#maven-dependencies) 所示，它沒有 Maven 相依性，但仍包含在 [第三方元件](#third-party-components) 中列出的第三方組件。請在安全性評估時同時檢視 JAR 檔案與這些元件。

**Aspose.Slides for Java 是否需要網路存取？**

不需要。建立、儲存與渲染簡報均可在完全沒有網路連線的環境中執行。唯一會向 Aspose 傳送資料的功能是[metered licensing](/slides/zh-hant/java/metered-licensing/)，它會回報 API 使用情形。

**Aspose.Slides for Java 是否包含本機程式碼？**

不包含。JAR 檔案僅包含 Java 類別與資源，並不會向您的應用程式加入本機函式庫。在 Linux 環境下，Java 執行時的字型支援需要 fontconfig 函式庫與作業系統提供的字型；請參閱[系統需求](/slides/zh-hant/java/system-requirements/#linux)。