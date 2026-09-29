---
title: 為何不使用自動化
type: docs
weight: 170
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
description: "探索 Office 自動化在伺服器與服務中的風險，並了解 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

使用 Aspose 元件是自動化的更佳替代方案，有多項原因。主要原因包括：

- 安全性
- 穩定性
- 可擴展性/速度
- 價格
- 功能

以下對每個要點作更詳細的說明。

## **重要問題**

我們在 Aspose 常聽到兩個問題：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

簡短而直接的答案是 **否**。

Aspose 元件完全獨立，與 Microsoft Corporation 無關，也未經其授權、贊助或批准。

- 為什麼要使用 Aspose 產品而不是 Microsoft Office Automation？

首先，使用 Aspose.Slides 時您可享有許多[使用 Aspose.Slides 的好處](/slides/zh-hant/java/product-overview/)。

其次，微軟本身強烈**建議不要**在軟體解決方案中使用 Office Automation。

## **安全性**

以下直接取自 Microsoft 文章的內容：

*"Office 應用程式從未設計為在伺服器端使用，因而未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也不會保護您免於不小心執行巨集，或從伺服器端程式碼啟動另一個可能執行巨集的伺服器。不要開啟從匿名網站上傳至伺服器的檔案！根據最後一次設定的安全性設定，伺服器可能在管理員或系統上下文中以完整權限執行巨集，從而危及您的網路！此外，Office 使用許多用戶端元件（如 Simple MAPI、WinInet、MSDAIPP），會快取用戶端驗證資訊以加速處理。如果在伺服器端自動化 Office，單一執行個體可能服務多個用戶端，而由於該會話已快取驗證資訊，可能導致一個用戶端使用另一個用戶端的快取憑證，藉此冒充其他使用者取得未授權的存取權限。"*

Aspose 產品非常安全。Aspose 元件不會對關鍵系統資源構成潛在風險。而且，當 Aspose 元件開啟文件時，巨集不會自動執行。Aspose 元件的設計目標是讓開發人員建立、操作並儲存 Office 檔案。與 Microsoft Office 套件相關的風險並不會遺傳至 Aspose 元件。

## **穩定性**

以下直接取自 Microsoft 文章的內容：

*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，以便讓最終使用者更容易安裝與自我修復。MSI 引入了「首次使用時安裝」的概念，允許在執行時動態安裝或設定功能（對系統或更常見的是對特定使用者）。在伺服器端環境中，這不僅會降低效能，還會增加出現對話方塊的可能性，要求使用者批准安裝或提供相應的安裝光碟。雖然此機制旨在提升 Office 作為最終使用者產品的彈性，但 Office 在伺服器端環境中的 MSI 實作卻適得其反。此外，因為 Office 並未針對此類使用情境設計或測試，在伺服器端執行時，其整體穩定性無法得到保證。將 Office 作為服務元件部署於網路伺服器，可能會降低該機器乃至整個網路的穩定性。若您計畫在伺服器端自動化 Office，請嘗試將程式隔離於無法影響關鍵功能且可依需求重新啟動的專用電腦上。"*

Aspose 元件已經過徹底測試，極其穩定。Aspose 元件被[公司]https://about.aspose.com/customers/ 如 **Bank of America** 等眾多客戶使用。

## **可擴展性/速度**

以下直接取自 Microsoft 文章的內容：

*"伺服器端元件需要高度可重入、具多執行緒的 COM 元件，具有最小的開銷與高吞吐量，以服務多個客戶端。而 Office 應用程式在幾乎所有方面皆恰恰相反。它們是非可重入、基於 STA 的自動化伺服器，設計上只為單一客戶端提供多樣且資源密集的功能。作為伺服器端解決方案，它們的可擴展性很低，且對記憶體等重要元素有固定限制，無法透過設定更改。更重要的是，它們使用全域資源（如記憶體映射檔、全域外掛或範本、共享自動化伺服器），這會限制同時執行的實例數量，且在多客戶端環境下可能導致競爭條件。開發人員若計畫同時執行多個 Office 應用程式實例，需考慮*Pooling*或*Serializing Access*以避免潛在的*Deadlocks*或*Data Corruption*。"*

Aspose 元件具備高度可擴展性且極速。Office 應用程式並未設計為同時供數百甚至數千名使用者使用。然而，Aspose 元件正是為此而生。無論是在單一伺服器上為單一應用程式供能，或是在負載平衡的 Web 伺服器群組中為整個企業級應用程式提供服務，我們的元件皆能完美運作。

## **價格**

當應用程式使用 Microsoft Office Automation 時，必須為每一台執行該應用程式的機器購買 Microsoft Office。許多情況下，應用程式需要建立或操作 Office 檔案，但並不需要使用者擁有 Microsoft Office。Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版稅的再分發授權，允許部署到無限制數量的使用者，無需擔憂授權問題。

在建立基於 Web 的應用程式時，需要了解 Microsoft Office Automation 元件並未為伺服器端解決方案定價或授權；因此，沒有合適的授權方案可供部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 同樣提供非常具成本效益的伺服器端應用方案。

## **功能**

Aspose 元件提供管理 Office 檔案所需的全部功能，甚至更多。它們的設計哲學是讓開發人員以最少的工作量達成最大的成果。與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/java/) 允許開發人員直接將 **DataTable** 或 **DataView** 匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/java/) 則提供類似功能，讓開發人員填充 Word（即合併列印）文件。Aspose 系列中的[每個元件](https://products.aspose.com/total/java/) 都擁有其獨有且強大的功能。

購買 Aspose 元件（或如[Aspose.Total](https://products.aspose.com/total/java/) 之元件套件）最大的好處，就是能取得我們開發團隊的支援。我們的開發團隊了解，如果貴公司需要的功能，其他公司很可能也有相同需求。雖然並非所有功能需求都能加入，但我們的團隊在提供協助時始終保持開放與彈性。正是這種心態，使 Aspose 元件變得如此強大。若您希望在 Office Automation 物件中取得其他功能，實際上被加入的機會極低。

## **結論**
{{% alert color="info" title="注意" %}}

雖然本文已說明許多 Aspose 元件相較於 Office Automation 的關鍵優勢，實際上還有更多未盡之處。本文僅聚焦於最重要的要點。所有不同的 Aspose 元件皆提供免費、無義務的[評估版本](https://releases.aspose.com/slides/zh-hant/java/)。我們鼓勵您利用此評估版，深入了解 Aspose 能為您的應用程式帶來的效益。
{{% /alert %}}