---
title: 為何不使用自動化
type: docs
weight: 50
url: /zh-hant/java/why-not-automation/
keywords:
- 自動化
- 微軟 Office
- 比較
- 安全性
- 穩定性
- 可擴展性
- 功能
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解為何 Office 自動化對伺服器與服務風險高，並看看 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

有幾個原因使 Aspose 元件成為自動化的更佳替代方案。主要原因包括：

- 安全性
- 穩定性
- 可擴展性/速度
- 價格
- 功能

以下針對每個重點作更詳細的說明。

## **重要問題**

我們在 Aspose 常常聽到兩個問題：

- 您的產品是否需要安裝 Microsoft Office 才能運行？

簡短且明確的答案是 **NO**。

- 為什麼我們應該使用 Aspose 產品而非 Microsoft Office Automation？

首先，使用 Aspose.Slides 時會有許多[您可享受的好處](/slides/zh-hant/java/product-overview/)。

其次，Microsoft 本身強烈**建議避免**在軟體解決方案中使用 Office Automation。

## **安全性**
以下為 Microsoft 文章的直接引用：

*"Office 應用程式從未設計用於伺服器端使用，因此未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也無法防止您在伺服器端程式碼中不小心執行巨集，或啟動可能執行巨集的其他伺服器。不要開啟從匿名網站上傳至伺服器的檔案！根據最後設定的安全性設定，伺服器可能在 Administrator 或 System 上下文中以完整權限執行巨集，進而危害您的網路！此外，Office 使用許多用戶端元件（例如 Simple MAPI、WinInet、MSDAIPP），這些元件會快取用戶端驗證資訊以加速處理。如果 Office 在伺服器端被自動化，一個執行個體可能服務多個用戶端，且由於該會話已快取驗證資訊，可能導致某個用戶端使用另一用戶端的快取憑證，從而以冒充其他使用者的方式取得未授予的存取權限。"*

Aspose 產品非常安全。Aspose 元件不會對關鍵系統資源構成潛在風險。此外，當文件由 Aspose 元件開啟時，巨集不會自動執行。Aspose 元件的設計目標是讓開發人員能建立、操作與儲存 Office 檔案，且不會承襲 Microsoft Office 套件的風險。

## **穩定性**
以下為 Microsoft 文章的直接引用：

*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術讓最終使用者的安裝與自我修復變得更簡單。MSI 引入「首次使用時安裝」的概念，允許在執行時動態安裝或設定功能（對系統或特定使用者）。在伺服器端環境中，這會降低效能且增加出現對話方塊要求使用者批准安裝或提供安裝光碟的機率。雖然此設計旨在提升 Office 作為最終使用者產品的彈性，但 Office 在伺服器端環境中的 MSI 功能實作適得其反。此外，Office 整體的穩定性無法在伺服器端保證，因為它並未為此類使用情境設計或測試。將 Office 作為服務元件在網路伺服器上使用可能會降低該機器的穩定性，進而影響整個網路。如果您計畫在伺服器端自動化 Office，請盡量將程式隔離在不會影響關鍵功能的專用電腦上，並在需要時重新啟動。"*

Aspose 元件已經過徹底測試，極為穩定。Aspose 元件被包括 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 在內的[公司](https://about.aspose.com/customers)廣泛使用，且遠不止此。

## **可擴展性/速度**
以下為 Microsoft 文章的直接引用：

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*"*

Aspose 元件高度可擴展且速度極快。Office 應用程式並未設計給數百乃至數千使用者同時使用。然而，Aspose 元件就是為此而生。無論是在單一伺服器上為單一應用程式供電，或是在負載平衡的 Web Form 中為整個企業級應用程式供能，我們的元件都能完美運作。

## **價格**
當應用程式使用 Microsoft Office Automation 時，必須為每一台執行該應用程式的機器購買 Microsoft Office 授權。許多情況下，應用程式只需要建立或操作 Office 檔案，卻不需要使用者安裝 Microsoft Office。Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版稅的再散佈授權，允許無限制的使用者部署，無需擔憂授權問題。

在建立 Web 應用程式時，必須了解 Microsoft Office Automation 元件並未為伺服器端解決方案定價或授權；因此，沒有合適的授權方案可用於部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 同樣提供非常具成本效益的伺服器端應用程式解決方案。

## **功能**
Aspose 元件提供管理 Office 檔案所需的一切，且遠超此範圍。它們的設計哲學是讓開發人員以最少的工作量達成最大的成果。與 Office Automation 不同，Aspose 元件提供許多強大且省時的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/java/) 讓開發人員能直接將 **DataTable** 或 **DataView** 的資料匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/java/) 提供類似功能，可將資料填入 Word（即 Mail Merge）文件。Aspose 系列中的[每個元件](https://products.aspose.com/total/java/)皆擁有其獨特且強大的功能。

購買 Aspose 元件（或如[Aspose.Total](https://products.aspose.com/total/java/)等元件套件）最大的好處，就是可以取得我們開發團隊的支援。我們的開發團隊了解，如果您的公司需要某項功能，其他公司很可能也有相同需求。雖然不是每個功能請求都能被加入，但我們的團隊在提供協助時相當開放且具彈性。正是這種心態，使 Aspose 元件變得如此強大。若您希望從 Office Automation 物件中取得其他功能，實現的機會非常、非常低。

## **結論**
{{% alert color="primary" %}} 

雖然本文已涵蓋許多 Aspose 元件相較於 Office Automation 更佳選擇的關鍵要點，實際上還有更多因素未盡述。本文僅針對最核心的要點作說明。所有不同的 Aspose 元件皆提供免風險、無義務的[評估版本](https://downloads.aspose.com/slides/zh-hant/java)。我們鼓勵您利用此評估版，親自體驗 Aspose 為您的應用程式帶來的價值。 

{{% /alert %}}