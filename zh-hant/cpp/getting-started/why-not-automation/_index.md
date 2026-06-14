---
title: 為什麼不使用自動化
type: docs
weight: 50
url: /zh-hant/cpp/why-not-automation/
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
  - C++
  - Aspose.Slides
description: "了解為何 Office 自動化對伺服器和服務具有風險，並看看 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

有多個原因使得 Aspose 元件成為自動化的更佳替代方案。關鍵原因包括：

- 安全性
- 穩定性
- 可擴展性/速度
- 價格
- 功能

以下是每個重點的更詳細說明。

## **重要問題**
- 為什麼 Aspose 元件比 Microsoft Office 自動化更佳？

在 Aspose，我們最常聽到的兩個問題是：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

簡短且直接的答案是 **NO**。Aspose 與 Aspose 元件完全獨立，且與 Microsoft Corporation 無關，也未經授權、贊助或批准。

- 為什麼我們應該使用 Aspose 產品，而非使用 Microsoft Office 自動化？

我們能給出的最簡短答案是，有很多原因，最重要的是 Microsoft 本身強烈建議不要在軟體解決方案中使用 Office Automation： [Microsoft Article

## **安全性**
以下是上述 Microsoft 文章的直接引用：
*"Office 應用程式從未設計用於伺服器端使用，因此未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也不會保護您免於意外執行巨集，或從伺服器端程式碼啟動可能執行巨集的其他伺服器。不要開啟從匿名網站上傳至伺服器的檔案！根據最後設定的安全設定，伺服器可能在 Administrator 或 System 身份下執行巨集，取得完整權限，進而危及您的網路！此外，Office 使用許多客戶端元件（例如 Simple MAPI、WinInet、MSDAIPP），這些元件會快取客戶端驗證資訊以加速處理。若在伺服器端自動化 Office，單一實例可能同時服務多個客戶端，且由於該會話已快取驗證資訊，可能導致一個客戶端使用另一客戶端的快取憑證，藉此冒充其他使用者取得未授權的存取權限。*

Aspose 產品非常安全。因此，Aspose 元件不會對關鍵系統資源構成潛在風險。另外，當文件由 Aspose 元件開啟時，巨集不會自動執行。Aspose 元件的建構目標是讓開發人員能建立、操作與儲存 Office 檔案。Microsoft Office 套件相關的風險並不存在於 Aspose 元件中。

## **穩定性**
以下是上述 Microsoft 文章的直接引用：
*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer（MSI）技術，以簡化最終使用者的安裝與自行修復。MSI 引入「首次使用時安裝」的概念，允許在執行期間動態安裝或設定功能（針對系統，或更常見的是針對特定使用者）。在伺服器端環境中，這會降低效能，且增加出現對話框要求使用者批准安裝或提供相應安裝光碟的可能性。雖然此設計旨在提升 Office 作為終端使用者產品的韌性，但 Office 對 MSI 功能的實作在伺服器端環境中適得其反。此外，Office 整體的穩定性無法在伺服器端運行時得到保證，因為它並未為此類使用而設計或測試。將 Office 作為網路伺服器上的服務元件使用，可能會降低該機器的穩定性，進而影響整體網路的穩定性。如果您計畫在伺服器端自動化 Office，請盡量將程式隔離到無法影響關鍵功能且可依需要重新啟動的專用電腦上。*

由於 Aspose 元件打包成單一 DLL，永遠不需要安裝任何其他元件才能運作。Aspose 元件僅供 C++ 應用程式使用，且元件程式碼中沒有任何需要等待人工回應的部分。Aspose 元件已經過徹底測試，極為穩定。Aspose 元件已被 [Companies](https://about.aspose.com/customers) 如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 以及其他眾多公司使用。

## **可擴展性/速度**
以下是上述 Microsoft 文章的直接引用：
*"伺服器端元件需要具備高度可重入性、支援多執行緒的 COM 元件，且具有最小的開銷與高吞吐量，以服務多個客戶端。Office 應用程式在幾乎所有方面都恰恰相反。它們是非可重入、基於 STA 的自動化伺服器，設計上僅提供單一客戶端使用且資源密集的多樣功能。作為伺服器端解決方案，它們的可擴展性極低，且對重要元素（如記憶體）有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（例如記憶體映射檔案、全域外掛或範本、以及共享的自動化伺服器），這會限制同時執行的實例數量，且在多客戶端環境中可能導致競爭條件。計畫同時執行多個 Office 應用程式實例的開發人員需要考慮池化或序列化存取 Office 應用程式，以避免潛在的死結或資料損毀。」*

Aspose 元件高度可擴展且極速。Office 應用程式並未設計為可同時供數百或數千名使用者使用。然而，Aspose 元件正是為此而設計。我們的元件是真正的 C++ 解決方案，無論在單一伺服器上、支援單一應用程式，或在負載平衡的 Web Form 中為全企業級應用程式供能，都能完美運作。

## **價格**
當應用程式使用 Microsoft Office 自動化時，必須為執行該應用程式的每台機器購買 Microsoft Office 授權。許多情況下，應用程式需要建立或操作 Office 檔案卻不需要使用者安裝 Microsoft Office。Aspose 提供相當 [Cost Effective](https://purchase.aspose.com/) 且免版稅的再分發授權，允許無限制的使用者部署，無需擔憂授權問題。建立基於 Web 的應用程式時，必須了解 Microsoft Office 自動化元件並未為伺服器端解決方案定價或授權；因此，沒有合適的授權方案可用於部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 亦提供相當 [Cost Effective](https://purchase.aspose.com/) 的伺服器端應用程式解決方案。

## **功能**
Aspose 元件提供管理 Office 檔案所需的一切，甚至更多。它們的設計理念是讓開發人員以最少的工作量達成最佳結果。與 Office 自動化不同，Aspose 元件提供許多強大且節省時間的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/cpp/) 讓開發人員能直接將 **DataTable** 或 **DataView** 的資料匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/net/) 提供類似功能，允許開發人員直接從任何 C++ 資料物件填充 Word（即合併列印）文件。[Every Component](https://products.aspose.com/total/cpp/) 在 Aspose 系列中各自擁有獨特且強大的功能。購買 Aspose 元件的最大好處是可以取得我們開發團隊的支援。我們的開發團隊了解，若貴公司需要的功能，很可能其他公司也有相同需求。雖然不可能實作所有功能需求，我們的團隊在提供協助時盡可能保持開放與彈性。正是這種心態使 Aspose 元件變得如此強大。若您需要 Office 自動化物件的其他功能，加入的機會非常、非常低。

## **結論**
{{% alert color="primary" %}} 
雖然本文已涵蓋了許多 Aspose 元件相較於 Office 自動化更佳的關鍵點，實際上還有更多。本文僅著重於最重要的幾點。所有不同的 Aspose 元件皆提供免費、無義務的 [Evaluation Version](https://downloads.aspose.com/slides/zh-hant/cpp)。我們鼓勵您利用此 [Evaluation](https://downloads.aspose.com/slides/zh-hant/cpp) 來更深入了解 Aspose 能為您的應用程式帶來的價值。