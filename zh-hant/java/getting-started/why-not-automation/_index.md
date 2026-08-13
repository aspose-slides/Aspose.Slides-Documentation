---
title: 為何不使用自動化
type: docs
weight: 50
url: /zh-hant/java/why-not-automation/
keywords:
- 自動化
- Microsoft Office
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
description: "了解為何 Office 自動化對伺服器與服務具有風險，並看看 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

Aspose 元件是比自動化更好的替代方案，有多項原因。主要原因包括：

- 安全性
- 穩定性
- 可擴展性／速度
- 價格
- 功能

以下對每個重點進行更詳細說明。

## **重要問題**

在 Aspose，我們常被問到兩個問題：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

簡短且明確的答案是 **否**。

Aspose 元件完全獨立，且與 Microsoft Corporation 無關，未經授權、未受贊助或未獲批准。

- 為什麼要使用 Aspose 產品而非 Microsoft Office Automation？

首先，使用 Aspose.Slides 時您可享有許多[benefits you enjoy when you use Aspose.Slides](/slides/zh-hant/java/product-overview/)。

其次，微軟本身強烈**建議不要**在軟體解決方案中使用 Office Automation。

## **安全性**

以下引用自 Microsoft 文章：

*"Office 應用程式從未設計用於伺服器端，因此未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也無法防止意外執行巨集，或因您的伺服器端程式碼而啟動其他可能執行巨集的伺服器。請勿在匿名 Web 中開啟上傳至伺服器的檔案！根據最後設定的安全性設定，伺服器可能在 Administrator 或 System 身分下以完整權限執行巨集，進而危害您的網路！此外，Office 使用許多用戶端元件（例如 Simple MAPI、WinInet、MSDAIPP）來快取用戶端驗證資訊以加速處理。如果 Office 在伺服器端自動化，單一執行個體可能服務多個用戶端，且因該工作階段已快取驗證資訊，可能導致一個用戶端使用另一用戶端的快取憑證，從而以冒充其他使用者的方式取得未授權的存取權限。"* 

Aspose 產品極具安全性。Aspose 元件不會對關鍵系統資源構成潛在風險。而且，當文件由 Aspose 元件開啟時，巨集不會自動執行。Aspose 元件的設計目的是讓開發人員建立、操作與儲存 Office 檔案，與 Microsoft Office 套件相關的風險並非 Aspose 元件所固有。

## **穩定性**

以下引用自 Microsoft 文章：

*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，以簡化安裝與自行修復。MSI 引入「首次使用時安裝」的概念，允許在執行時動態安裝或設定功能（對系統或特定使用者）。在伺服器端環境中，此機制會降低效能，且可能出現對話方塊要求使用者批准安裝或提供安裝光碟。雖然此設計旨在提升 Office 作為終端使用者產品的韌性，但 Office 在伺服器端環境中的 MSI 實作卻適得其反。此外，Office 在伺服器端執行時，無法保證其一般穩定性，因為它未被設計或測試於此類使用情境。將 Office 作為網路伺服器上的服務元件可能降低該機器的穩定性，進而影響整個網路。若計畫在伺服器端自動化 Office，請嘗試將程式隔離至無法影響關鍵功能的專用電腦，且可依需求重新啟動。"* 

Aspose 元件已經過徹底測試，極為穩定。Aspose 元件已被[Companies](https://about.aspose.com/customers) 如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等眾多企業使用。

## **可擴展性／速度**

以下引用自 Microsoft 文章：

*"伺服器端元件需要高度可重入、具多執行緒的 COM 元件，具最小開銷與高吞吐量，以支援多個用戶端。Office 應用程式在幾乎所有方面恰恰相反。它們是非可重入、基於 STA 的 Automation 伺服器，設計上只能為單一用戶端提供多樣且資源密集的功能。作為伺服器端解決方案，它們的可擴展性極低，且在記憶體等重要資源上有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（如記憶體映射檔、全域外掛或範本、共享 Automation 伺服器），可能限制同時執行的實例數量，且在多用戶端環境下若配置不當，會導致競爭條件。開發人員若計畫同時執行多個 Office 應用程式實例，需考慮* ***Pooling*** *或* ***Serializing Access*** *至 Office 應用程式，以避免潛在的* ***Deadlocks*** *或* ***Data Corruption*** *。"* 

Aspose 元件具高度可擴展性且速度極快。Office 應用程式並非為同時服務數百甚至上千使用者而設計，而 Aspose 元件正是為此而生。無論是單一伺服器、單一應用程式，或是負載平衡的 Web Form 供應全企業級應用，我們的元件都能無縫運作。

## **價格**

若應用程式使用 Microsoft Office Automation，則每台執行該應用程式的機器都必須購買一套 Microsoft Office。許多情況下，應用程式需要建立或操作 Office 檔案，但並不需要使用者安裝 Microsoft Office。Aspose 提供非常[Cost Effective](https://purchase.aspose.com/)且免版稅的重新分發授權，允許無限制部署給任意數量使用者，無需擔憂授權問題。

在建立 Web 應用程式時，需要了解 Microsoft Office Automation 元件並未針對伺服器端解決方案定價或授權；因此，沒有合適的授權方案可供部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 同樣提供非常具成本效益的伺服器端應用解決方案。

## **功能**

Aspose 元件提供管理 Office 檔案所需的一切，甚至遠超此範圍。它們的設計哲學是讓開發人員以最少的工作量達成最佳成果。與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/java/) 允許開發人員直接將 **DataTable** 或 **DataView** 匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/java/) 提供類似功能，可將資料填入 Word（即合併列印）文件。Aspose 系列中的[Every Component](https://products.aspose.com/total/java/) 都有各自獨特且強大的功能。

購買 Aspose 元件（或如[Aspose.Total](https://products.aspose.com/total/java/) 等元件套件）的最佳好處是可以取得我們的開發團隊支援。開發團隊深知若某家公司需要的功能，多半其他公司也會需要。雖然不可能接受所有功能請求，我們的團隊在提供協助時仍保持開放與彈性。正是這種心態使 Aspose 元件變得如此強大。若您需要 Office Automation 物件的其他功能，其被加入的機會極低。

## **結論**
{{% alert color="info" %}} 

雖然本文已涵蓋許多 Aspose 元件相較於 Office Automation 的關鍵優勢，事實上還有更多未盡述。本篇僅列出最重要的要點。所有不同的 Aspose 元件皆提供無風險、無義務的[Evaluation Version](https://downloads.aspose.com/slides/zh-hant/java)。我們鼓勵您利用此評估版，以更深入了解 Aspose 能為您的應用程式帶來何種效益。 

{{% /alert %}}