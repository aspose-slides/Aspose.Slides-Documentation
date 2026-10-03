---
title: 入門指南
type: docs
weight: 10
url: /zh-hant/java/getting-started/
keywords:
- 入門
- 系統需求
- 安裝
- 第一個簡報
- Maven
- PPT 處理
- PPTX 處理
- ODP 處理
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "從新建的 Java 專案到使用 Aspose.Slides 儲存的第一個簡報的完整流程：檢查需求、從 Aspose 的 Maven 儲存庫加入函式庫、執行第一個程式，然後繼續執行常見任務。"
---
## **概觀**

依序完成以下四個步驟。每個步驟都說明要執行的動作，並提供連結至詳細說明的文章。評估、授權與支援的說明則放在步驟之後。

## **步驟 1：檢查系統需求**

Aspose.Slides for Java 為單一 JAR 檔，未含原生程式碼，因此只要有支援的 Java 執行環境即可在任何作業系統上執行。[系統需求](/slides/zh-hant/java/system-requirements/) 列出了支援的作業系統與 Java 版本。接下來步驟中的專案與指令需要 JDK 11 以上，若採用 Maven 方式，還需[Apache Maven] (https://maven.apache.org/install.html)。

## **步驟 2：將函式庫加入您的專案**

Aspose.Slides for Java 於 Aspose 自家的 Maven 儲存庫發布，未在 Maven Central 上提供。請選擇以下其中一種方式：

- 使用 Maven：在 *pom.xml* 中宣告儲存庫 `https://releases.aspose.com/java/repo/`，並加入 `com.aspose:aspose-slides`（使用 `jdk16` classifier）的相依性。
- 不使用 Maven：從儲存庫下載檔名以 *-jdk16.jar* 結尾的 JAR，並放入類別路徑。

在 Linux 上，還必須安裝 fontconfig 函式庫以及至少一種字型。若缺少這些，儲存簡報時會出現錯誤「Fontconfig head is null, check your fonts or fonts configuration」。

[安裝](/slides/zh-hant/java/installation/) 內提供 *pom.xml* 的設定範例、JAR 下載位置與 Linux 指令。

## **步驟 3：建立您的第一個簡報**

[Aspose.Slides for Java 首頁的快速入門](/slides/zh-hant/java/#your-first-presentation) 是一個完整的 Maven 專案：包含 *pom.xml* 檔與一段程式碼，會在投影片上加入文字雲形狀，並將簡報儲存為 PPTX 檔。您可以使用 `mvn compile exec:java` 執行。[建立簡報](/slides/zh-hant/java/create-presentation/) 逐步說明相同程式的每個步驟。若要開啟現有簡報並另存為其他格式，請參閱[開啟簡報](/slides/zh-hant/java/open-presentation/)與[儲存簡報](/slides/zh-hant/java/save-presentation/)。

## **步驟 4：進行常見任務**

- [開啟簡報](/slides/zh-hant/java/open-presentation/)
- [儲存簡報](/slides/zh-hant/java/save-presentation/)
- [將簡報轉換為 PDF](/slides/zh-hant/java/convert-powerpoint-to-pdf/)
- [將投影片轉為影像](/slides/zh-hant/java/convert-slide/)
- [編輯簡報文字](/slides/zh-hant/java/manage-text/)
- [依投影片元素的範例](/slides/zh-hant/java/examples/)

## **評估與授權**

若未購買授權，Aspose.Slides 會以評估模式執行：會在所有輸出的投影片加上浮水印，且會截斷程式讀取的文字內容。

- [評估 Aspose.Slides](/slides/zh-hant/java/evaluate-aspose-slides/) 說明評估限制與如何申請臨時授權。
- [授權](/slides/zh-hant/java/licensing/) 說明如何從檔案或串流套用授權。
- [計量授權](/slides/zh-hant/java/metered-licensing/) 介紹依使用量計費的授權方式。
- [支援的檔案格式](/slides/zh-hant/java/supported-file-formats/) 列出 Aspose.Slides 可讀寫的格式。

## **取得協助**

[技術支援](/slides/zh-hant/java/technical-support/) 說明如何在[免費支援論壇] (https://forum.aspose.com/c/slides/zh-hant/11) 提問，以及回報問題時需要提供哪些資訊。

## **常見問題**

**是否需要安裝 Microsoft PowerPoint？**

不需要。Aspose.Slides 自行讀寫簡報檔案，並不使用 PowerPoint，因此可在伺服器與 Linux 上執行。

**為何 Maven 找不到 Aspose.Slides for Java？**

此函式庫不在 Maven Central。請如同[安裝](/slides/zh-hant/java/installation/) 所示，在 *pom.xml* 中宣告 Aspose 的儲存庫，Maven 便會從該位置下載函式庫。

**`jdk16` classifier 是否表示需要 Java 16？**

不是。此 classifier 代表選擇 Java SE 版的函式庫，另一版則是給 Android 使用。相同的組建可在目前的 JDK（例如 JDK 21）上執行。