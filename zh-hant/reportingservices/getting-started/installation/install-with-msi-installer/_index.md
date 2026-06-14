---
title: 使用 MSI 安裝程式安裝
type: docs
weight: 20
url: /zh-hant/reportingservices/install-with-msi-installer/
---
## **安裝**
您可以透過 MSI 安裝程式安裝 Aspose.Slides for Reporting Services。

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** 需要在主機上安裝 **.NET Framework 3.5**。

{{% /alert %}}

執行 ***Aspose.Slides.ReportingServices.msi***，並依照安裝程式提供的步驟操作。

安裝程式會將組件及其他檔案複製到指定目錄，並在預設的 Reporting Services 實例上安裝產品。除非您想加入特殊的組態參數，否則不需要手動複製或修改任何檔案。

在大多數情況下，使用 MSI 安裝程式進行安裝是最佳選擇。但在某些情況下，您可能需要手動安裝產品：

- 由於安全性問題或其他原因導致自動安裝失敗。 
- 必須將產品安裝在具名（非預設）的 Reporting Services 實例或多個實例上。 
- 升級至最新版本後，只想取代組件，而不是使用 MSI 安裝程式解除舊版安裝再安裝新版。**注意**：此情況下可能會留下其他檔案。