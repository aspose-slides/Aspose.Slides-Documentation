---
title: 為何不使用自動化
type: docs
weight: 40
url: /zh-hant/net/why-not-automation/
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
- .NET
- C#
- Aspose.Slides
description: "了解為何 Office 自動化對伺服器與服務具有風險，並看看 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

有幾個原因使 Aspose 元件成為自動化的更佳替代方案。主要原因包括：

- 安全性
- 穩定性
- 可擴展性/速度
- 價格
- 功能

以下是對每個關鍵點的更詳細說明。

## **重要問題**

在 Aspose，我們常聽到兩個問題：

- 您的產品是否需要先安裝 Microsoft Office 才能執行？

簡短且直接的答案是 **NO**。

Aspose 元件完全獨立，與 Microsoft Corporation 無關、未獲授權、未受贊助，也未經其認可。

- 為什麼要使用 Aspose 產品而不是 Microsoft Office Automation？

首先，使用 Aspose.Slides 時您可獲得許多[好處](/slides/zh-hant/net/product-overview/)。

其次，Microsoft 本身**強烈建議不要**在軟體解決方案中使用 Office Automation。

## **安全性**
以下直接引用自 Microsoft 文章：

> "Office 應用程式從未設計用於伺服器端，因此未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也無法防止您在伺服器端程式碼中不慎執行巨集，或啟動可能執行巨集的其他伺服器。不要開啟上傳至伺服器的匿名 Web 檔案！根據最後設定的安全性設定，伺服器可能在具有完整特權的 Administrator 或 System 身分下執行巨集，進而危及您的網路！此外，Office 使用許多用戶端元件（例如 Simple MAPI、WinInet、MSDAIPP），會快取用戶端驗證資訊以加速處理。如果在伺服器端自動化 Office，單一執行個體可能服務多個用戶端，且由於該會話已快取驗證資訊，可能導致一個用戶端使用另一用戶端的快取憑證，藉此冒充其他使用者取得未授權的存取權限。"

Aspose 產品非常 **安全**。Aspose 元件在與所有 ASP.NET 應用程式相同的使用者身分（ASPNET 使用者）下執行。因此，Aspose 元件 **不會**構成安全風險，也不會消耗關鍵系統資源。此外，當 Aspose 元件開啟文件時，巨集不會自動執行。Aspose 元件旨在讓開發者建立、操作並儲存 Office 檔案。

{{% alert color="primary" %}} 
Microsoft Office 套件相關的風險皆不適用於 Aspose 元件。 
{{% /alert %}} 

## **穩定性**
以下文字直接引用自先前提及的 Microsoft 文章：

> "Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，以便讓最終使用者更容易安裝與自行修復。MSI 引入「首次使用時安裝」概念，允許在執行時動態安裝或設定功能（針對系統，或更常見的是針對特定使用者）。在伺服器端環境中，這會降低效能並增加出現對話框要求使用者批准安裝或提供安裝光碟的可能性。雖然此機制旨在提升 Office 作為最終使用者產品的韌性，但 Office 在伺服器端環境中的 MSI 實作卻適得其反。此外，Office 整體的穩定性無法在伺服器端保證，因為它並未針對此類使用情境設計或測試。將 Office 作為服務元件在網路伺服器上使用，可能會降低該機器的穩定性，從而影響整個網路。如果您計畫在伺服器端自動化 Office，請嘗試將程式隔離到無法影響關鍵功能且可依需要重新啟動的專用電腦上。"

由於 Aspose 元件僅以單一 DLL 打包，使用者永遠不需要額外安裝任何部件。Aspose 元件僅供 .NET 應用程式使用，且元件程式碼中沒有任何等待人工回應的部分。

{{% alert color="primary" %}} 
Aspose 元件已經過徹底測試，確認相當穩定。Aspose 元件被[公司]([http://www.aspose.com/Corporate/Aspose/Customerlist.html](http://www.aspose.com/Corporate/Aspose/Customerlist.html))如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 以及多個行業與領域的其他領先組織廣泛採用。 
{{% /alert %}} 

## **可擴展性/速度**
以下直接引用自 Microsoft 文章：

> "伺服器端元件需要具備高度可重入性、多執行緒的 COM 元件，且具備最小開銷與高吞吐量，以支援多個用戶端。Office 應用程式在幾乎所有方面正好相反。它們是非可重入、基於 STA 的自動化伺服器，設計上只為單一用戶端提供多樣且資源密集的功能。作為伺服器端解決方案，它們的可擴展性很差，且對重要元素（如記憶體）有固定上限，無法透過設定變更。更重要的是，它們使用全域資源（例如記憶體映射檔、全域外掛或範本、共享自動化伺服器），這會限制同時執行的實例數量，且在多用戶端環境中配置時可能導致競爭條件。計畫同時執行多個 Office 應用程式實例的開發者必須考慮資源池化或序列化存取，以避免潛在的死結或資料損毀。" 

Aspose 元件具備極佳的可擴展性與閃電般的速度。Office 應用程式並未設計供數百或數千使用者同時使用，而 Aspose 元件正是為此而設計。我們的元件是真正的 .NET 解決方案。

{{% alert color="primary" %}} 
Aspose 元件的效能在單一伺服器（供單一應用程式使用）或負載平衡的 Web 表單（供企業級應用程式使用）上皆表現完美。 
{{% /alert %}} 

## **價格**
當應用程式使用 Microsoft Office Automation 時，必須為每台執行該應用程式的機器購買 Microsoft Office。雖然應用程式可能需要多次建立或操作 Office 檔案，但這個過程本身並不需要 Microsoft Office。

{{% alert color="primary" %}} 
Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版稅的再散佈授權，允許部署至無限制的使用者，無需擔心授權問題。 
{{% /alert %}} 

在建立基於 Web 的應用程式時，必須記住 Microsoft Office Automation 元件既未為伺服器端解決方案定價，也未取得相應授權。因此，沒有合適的授權方案可用於部署使用 Microsoft Office 元件的 Web 應用程式。相較之下，Aspose 為伺服器端應用程式提供非常[具成本效益](https://purchase.aspose.com/)的解決方案。

## **功能**
Aspose 元件提供管理 Office 檔案所需的一切，甚至更多。我們的設計理念是協助開發者以最少的努力達成最佳成果。

{{% alert color="primary" %}} 
與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。 
{{% /alert %}} 

例如，[Aspose.Cells](https://products.aspose.com/cells/net/) 讓開發者能直接將 **DataTable** 或 **DataView** 的資料匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/net/) 則提供類似功能，允許開發者直接從任何 .NET 資料物件填充 Word（即合併列印）文件。[Every component](https://products.aspose.com/total/net/) 在 Aspose 系列中各自擁有獨特且強大的功能。

購買 Aspose 元件的最大好處是可獲得我們開發團隊的支援。例如，若您使用 Office Automation 物件並需要特定功能，新增此功能的機會非常低；而 Aspose 元件則不同。

{{% alert color="primary" %}} 
我們的開發團隊了解，若貴公司需要的功能，其他公司也很可能有相同需求。雖然我們無法實作所有提出的功能，但會根據客戶回饋盡可能新增更多功能。 
{{% /alert %}} 

我們的團隊在提供協助時始終保持開放與彈性，這也是 Aspose 元件能成長為如今如此強大的原因。

## **結論**
{{% alert color="primary" %}} 

雖然本文已說明 Aspose 元件相較於 Office Automation 的幾個關鍵優勢，但實際上還有更多好處。我們僅列舉了部分主要優勢。 

此外，所有 Aspose 產品與元件皆提供無風險、無義務的[評估版](https://downloads.aspose.com/slides/zh-hant/net)。我們鼓勵您利用評估版，了解 Aspose 能為您的應用程式或業務帶來什麼幫助。 
{{% /alert %}}