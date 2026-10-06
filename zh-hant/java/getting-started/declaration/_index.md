---
title: 安全管理員需求
type: docs
weight: 190
url: /zh-hant/java/declaration/
keywords:
- 安全管理員
- 安全原則
- AllPermission
- 權限
- 沙箱
- JDK 24
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "在 Java 23 及以前版本，Aspose.Slides for Java 以及呼叫它的程式碼需要哪些安全管理員權限，以及為何在 Java 24 及之後不需要任何設定。"
---
## **概觀**

Java Security Manager 會根據安全原則限制程式碼的執行行為。Java 17 已將其標示為過時以供未來移除 ([JEP 411](https://openjdk.org/jeps/411))，而 Java 24 則永久停用它 ([JEP 486](https://openjdk.org/jeps/486))。本文說明當應用程式仍在使用 Security Manager 時，Aspose.Slides for Java 所需的設定。如果您的應用程式未啟用 Security Manager（這是預設情況），則無需進行任何設定。

## **Java 23 及以前版本**

啟用 Security Manager 時，必須將以下權限授予 Aspose.Slides JAR 檔案以及呼叫它的應用程式程式碼：

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides 讀取系統屬性。
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides 讀取字型檔案及其他檔案。
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides 會啟動作業系統程式，例如 Windows 上的 `reg` 與 Linux 上的 `fc-match`。
- `java.io.FilePermission` 並具備 `write` 動作，針對您的應用程式儲存檔案的資料夾。

僅將權限授予 JAR 檔案不夠：呼叫 Aspose.Slides 的程式碼也必須擁有相同權限。將 `java.security.AllPermission` 同時授予兩者亦可行。

若未取得讀取系統屬性或啟動程式的權限，Aspose.Slides 會在首次使用時失敗：建立 [Presentation](https://reference.aspose.com/slides/zh-hant/java/com.aspose.slides/presentation/) 物件會拋出 `ExceptionInInitializerError`。若未能讀取字型檔，將簡報另存為 PDF 時會出現錯誤「Cannot find any fonts installed on the system」。

## **Java 24 及之後版本**

在 Java 24 及之後的版本中無法啟用 Security Manager，因此不需要授予任何權限。Aspose.Slides 會以執行您應用程式之帳戶的權限執行。若需限制應用程式的存取範圍，OpenJDK 專案建議使用 JDK 之外的技術，例如容器、虛擬化管理程式，以及作業系統的 sandbox 功能。參見 [JEP 486](https://openjdk.org/jeps/486)。

## **常見問題**

**我可以在採用嚴格 Security Manager 原則的環境中使用 Aspose.Slides 嗎？**

只能在原則同時授予上述權限給 Aspose.Slides 與呼叫它的程式碼時使用。這些權限包括讀取所有檔案以及啟動任何程式。