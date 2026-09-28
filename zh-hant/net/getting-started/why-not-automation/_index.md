---
title: 為什麼不使用自動化
type: docs
weight: 170
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
## **介紹**

有多項原因使 Aspose 元件成為自動化的更佳替代方案。主要原因包括：

- 安全性
- 穩定性
- 可擴展性/速度
- 價格
- 功能

以下是對每個要點的更詳細說明。

## **重要問題**

我們在 Aspose 常聽到兩個問題：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

簡短而直接的答案是 **否**。

Aspose 元件是完全獨立的，與 Microsoft Corporation 無關，也未經授權、贊助或其他形式的批准。

- 為什麼要使用 Aspose 產品而不是 Microsoft Office Automation？

首先，使用 Aspose.Slides 時您可以享受的[好處](/slides/zh-hant/net/product-overview/)。

其次，Microsoft 本身強烈 **建議不要** 在軟體解決方案中使用 Office Automation。

## **安全性**
以下摘自 Microsoft 文章的直接引述：

> "Office 應用程式從未設計為在伺服器端使用，因而未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也無法防止您在伺服器端程式碼中不小心執行巨集，或啟動可能執行巨集的其他伺服器。不要開啟匿名網站上傳到伺服器的檔案！根據最後設定的安全性設定，伺服器可能在 Administrator 或 System 身份下以完整權限執行巨集，進而危害您的網路！此外，Office 使用許多用戶端元件（如 Simple MAPI、WinInet、MSDAIPP），會快取用戶端驗證資訊以加速處理。如果在伺服器端自動化 Office，單一執行個體可能服務多個用戶端，而因已為該工作階段快取驗證資訊，可能導致一個用戶端使用另一用戶端的快取憑證，進而冒充其他使用者取得未授權的存取權限。"

Aspose 產品非常 **安全**。Aspose 元件在與所有 ASP.NET 應用程式相同的使用者上下文（ASPNET 使用者）下執行。因此，Aspose 元件 **不會**帶來安全風險，也不會消耗關鍵系統資源。此外，當 Aspose 元件開啟文件時，巨集不會自動執行。Aspose 元件的設計初衷是讓開發人員建立、操作並儲存 Office 檔案。

{{% alert color="info" title="Note" %}}
沒有任何與 Microsoft Office 套件相關的風險會影響 Aspose 元件。
{{% /alert %}}

## **穩定性**
以下摘自前述 Microsoft 文章的直接引述：

> "Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，以便讓最終使用者更容易安裝與自我修復。MSI 引入了「首次使用時安裝」的概念，允許在執行期間動態安裝或設定功能（針對系統，或更常見的是針對特定使用者）。在伺服器端環境中，這會降低效能，且增加出現對話方塊要求使用者批准安裝或提供安裝光碟的機會。雖然此機制旨在提升 Office 作為終端使用者產品的韌性，但在伺服器端環境中，Office 對 MSI 功能的實作適得其反。此外，Office 的整體穩定性在伺服器端執行時無法保證，因為它並未為此類使用情境設計或測試。將 Office 作為網路伺服器上的服務元件使用可能會降低該機器乃至整個網路的穩定性。如果您計畫在伺服器端自動化 Office，請嘗試將程式隔離至無法影響關鍵功能且可視需要重新啟動的專用電腦。"

由於 Aspose 元件被封裝成單一 DLL，使用者永遠不需要安裝額外的部件或組件以使其運作。Aspose 元件僅供 .NET 應用程式使用，且元件程式碼中沒有任何需要等待人工回應的部分。

{{% alert color="info" title="Note" %}}
Aspose 元件已經過徹底測試，證實相當穩定。Aspose 元件已被[公司](https://about.aspose.com/customers/)如 **Bank of America** 以及其他多個產業領先組織廣泛採用。
{{% /alert %}}

## **可擴展性/速度**
以下摘自 Microsoft 文章的直接引述：

> "伺服器端元件需要具備高度可重入性、多執行緒 COM 元件，且具最小開銷與高吞吐量，以支援多個用戶端。Office 應用程式在幾乎所有方面都恰恰相反。它們是非可重入、基於 STA 的 Automation 伺服器，設計上只能為單一用戶端提供多樣但資源密集的功能。作為伺服器端解決方案，它們的可擴展性極低，且在記憶體等重要資源上有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（如記憶體映射檔、全域外掛或範本、共享 Automation 伺服器），這會限制同時執行的實例數量，並在多用戶端環境中可能導致競爭條件。計畫同時執行多個 Office 應用程式實例的開發人員必須考慮資源池化或序列化存取，以避免潛在的死結或資料損毀。"

Aspose 元件具有極佳的可擴展性與閃電般的速度。Office 應用程式並未設計供數百或數千使用者同時使用，而 Aspose 元件正是為此目的而生。我們的元件是真正的 .NET 解決方案。

{{% alert color="info" title="Note" %}}
Aspose 元件的效能在單一伺服器（只支援單一應用程式）或在負載平衡的 Web 叢集（支援全企業級應用程式）上皆表現完美。
{{% /alert %}}

## **價格**
當應用程式使用 Microsoft Office Automation 時，必須為每一台執行該應用程式的機器購買 Microsoft Office。雖然應用程式可能需要多次建立或操作 Office 檔案，但此程序本身並不需要 Microsoft Office。

{{% alert color="info" title="Note" %}}
Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版稅的再分發授權，允許部署至無限制的使用者數量，無需擔心授權問題。
{{% /alert %}}

在建立基於 Web 的應用程式時，必須記住 Microsoft Office Automation 元件既不適用於伺服器端，也沒有相應的授權方案。因此，沒有合適的授權方式能支援使用 Microsoft Office 元件的 Web 應用程式部署。相較之下，Aspose 為伺服器端應用程式提供了非常[具成本效益](https://purchase.aspose.com/)的解決方案。

## **功能**
Aspose 元件提供了管理 Office 檔案所需的一切，甚至遠超需求。我們根據「以最少的努力達成最大成果」的理念設計這些元件。

{{% alert color="info" title="Note" %}}
與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。
{{% /alert %}}

舉例來說，[Aspose.Cells](https://products.aspose.com/cells/net/) 讓開發人員能直接將 **DataTable** 或 **DataView** 匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/net/) 提供類似功能，讓開發人員能直接從任何 .NET 資料物件填充 Word（即合併列印）文件。Aspose 系列的[每個元件](https://products.aspose.com/total/net/)都有其獨特且強大的功能。

購買 Aspose 元件的最大好處是可取得我們開發團隊的支援。例如，若您使用 Office Automation 物件並需要特定功能，取得該功能的可能性非常低。但 Aspose 元件的情況則有所不同。

{{% alert color="info" title="Note" %}}
我們的開發團隊了解，如果貴公司需要的功能，其他公司也可能有相同需求。雖然我們無法實作每一項請求，但會根據客戶回饋盡可能加入更多功能。
{{% /alert %}}

我們的團隊在提供協助時始終保持開放與彈性，這也是 Aspose 元件能發展至今如此強大的原因。

## **結論**
{{% alert color="info" title="Note" %}}
雖然本文僅列出部分 Aspose 元件相較於 Office Automation 的關鍵優勢，但實際上還有許多更多的好處。我們僅提及了其中一些主要優勢。

此外，所有 Aspose 產品與元件皆提供無風險、無義務的[評估版](https://releases.aspose.com/slides/zh-hant/net/)。我們鼓勵您利用評估版，親自體驗 Aspose 為您的應用程式或業務帶來的價值。
{{% /alert %}}