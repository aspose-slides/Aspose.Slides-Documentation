---
title: 為何不使用自動化
type: docs
weight: 50
url: /zh-hant/cpp/why-not-automation/
keywords:
- 自動化
- Microsoft Office
- 比較
- 安全性
- 穩定性
- 可擴充性
- 功能
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索為何 Office 自動化對伺服器與服務具有風險，並了解 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **介紹**

有多個原因使 Aspose 元件成為自動化的更佳替代方案。主要原因包括：

- 安全性
- 穩定性
- 可擴充性/速度
- 價格
- 功能

以下為每個要點的更詳細說明。

## **重要問題**
- 為什麼 Aspose 元件遠比 Microsoft Office Automation 更好？

以下是我們在 Aspose 最常被問到的兩個問題：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

簡短的答案是 **NO**。Aspose 以及 Aspose 元件完全獨立，且與 Microsoft Corporation 無任何關聯，亦未獲授權、贊助或認可。

- 為什麼我們應該使用 Aspose 產品，而不是使用 Microsoft Office Automation？

我們能給出的最簡短答案是有許多原因，首要原因是 *Microsoft 本身強烈建議不要在軟體解決方案中使用 Office Automation： [Microsoft 文章](https://learn.microsoft.com/)

## **安全性**
以下直接引用自上述 Microsoft 文章：

*"Office 應用程式從未設計用於伺服器端使用，因而未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也無法防止您在伺服器端程式碼中不小心執行巨集，或啟動可能執行巨集的其他伺服器。請勿開啟從匿名網站上傳至伺服器的檔案！根據最後設定的安全設定，伺服器可能在 Administrator 或 System 上下文中以完整權限執行巨集，進而危及您的網路！此外，Office 使用許多客戶端元件（如 Simple MAPI、WinInet、MSDAIPP），這些元件會快取客戶端驗證資訊以加速處理。若在伺服器端自動化 Office，單一實例可能服務多個客戶端，且因該會話已快取驗證資訊，導致一個客戶端可以使用另一客戶端的快取憑證，從而透過冒充其他使用者取得未授權的存取權限。*"

Aspose 產品非常安全。因此，Aspose 元件不會對關鍵系統資源造成潛在風險。另外，當文件由 Aspose 元件開啟時，巨集不會自動執行。Aspose 元件的設計目標是讓開發人員建立、操作與保存 Office 檔案。Microsoft Office 套件所帶來的風險並不存在於 Aspose 元件中。

## **穩定性**
以下直接引用自上述 Microsoft 文章：

*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，以讓最終使用者安裝與自我修復更加簡易。MSI 引入「首次使用時安裝」的概念，允許功能在執行期間動態安裝或設定（針對系統或更常見的特定使用者）。在伺服器端環境中，這會降低效能且增加出現對話方塊的可能性，要求使用者批准安裝或提供適當的安裝光碟。雖然此設計是為了提升 Office 作為終端使用者產品的韌性，Office 在伺服器端環境中實作 MSI 功能卻適得其反。此外，Office 整體的穩定性在伺服器端執行時無法得到保證，因為它未針對此類使用情境設計或測試。將 Office 作為網路伺服器上的服務元件使用，可能會降低該機器的穩定性，進而影響整體網路。若您計畫在伺服器端自動化 Office，請儘可能將程式隔離到無法影響關鍵功能且可隨時重新啟動的專用電腦上。*"

由於 Aspose 元件打包成單一 DLL，永遠不需要安裝任何額外的部件才能運作。Aspose 元件僅供 C++ 應用程式使用，且元件程式碼中沒有任何需要等待人工回應的部分。Aspose 元件已經過徹底測試，極為穩定。Aspose 元件被 [公司](https://about.aspose.com/customers) 如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等大量企業採用。

## **可擴充性/速度**
以下直接引用自上述 Microsoft 文章：

*"伺服器端元件需要具備高度可重入性、多執行緒的 COM 元件，具最小開銷且能為多個客戶端提供高吞吐量。Office 應用程式在幾乎所有方面正好相反。它們是非可重入、基於 STA 的自動化伺服器，旨在為單一客戶端提供多樣且資源密集的功能。作為伺服器端解決方案，它們的可擴充性很低，且對重要元素（如記憶體）有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（例如記憶體映射檔、全域外掛或範本，以及共享的自動化伺服器），這會限制同時執行的實例數量，且在多客戶端環境中配置時可能導致競爭條件。計畫同時執行多個 Office 應用程式實例的開發人員，需要考慮對 Office 應用程式的池化或序列化存取，以避免潛在的死結或資料損毀。」*

Aspose 元件具備高度可擴充性且執行速度極快。Office 應用程式並未設計可同時供數百或數千名使用者使用，而 Aspose 元件正是為此而設計。我們的元件是真正的 C++ 解決方案，無論在單一伺服器上支援單一應用程式，或在負載平衡的 Web Form 上支援整個企業級應用，都能完美運作。

## **價格**
當應用程式使用 Microsoft Office Automation 時，必須為每一台執行該應用程式的機器購買 Microsoft Office。許多情況下，應用程式需要建立或操作 Office 檔案卻不需要使用者安裝 Microsoft Office。Aspose 提供極具[成本效益](https://purchase.aspose.com/)且免版稅的再分發授權，允許部署到無限制的使用者數量，無需擔憂授權問題。建立基於 Web 的應用程式時，需要注意 Microsoft Office Automation 元件並未針對伺服器端解決方案定價或授權；因此，沒有合適的授權方案可供部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 也提供極具[成本效益](https://purchase.aspose.com/)的伺服器端應用程式解決方案。

## **功能**
Aspose 元件提供管理 Office 檔案所需的全部功能，且遠超其他功能。它們的設計哲學是讓開發人員以最少的工作量達成最大的成果。與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/cpp/) 允許開發人員直接將 **DataTable** 或 **DataView** 匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/net/) 提供類似功能，讓開發人員可直接從任何 C++ 資料物件填入 Word（即合併列印）文件。[每個元件](https://products.aspose.com/total/cpp/) 在 Aspose 系列中都有各自獨特且強大的功能。購買 Aspose 元件的最佳好處是可取得我們開發團隊的協助。我們的開發團隊深知若某項功能是貴公司所需，其他公司很可能也有相同需求。雖然不是所有功能請求都能納入，但我們的團隊在提供協助時非常開放且具彈性。正是這種心態讓 Aspose 元件變得如此強大。若您希望從 Office Automation 物件取得其他功能，實現的機會極低。

## **結論**
{{% alert color="primary" %}} 

雖然本篇文章已說明許多 Aspose 元件相較於 Office Automation 的主要優勢，實際上還有更多優點。本篇僅探討最關鍵的幾點。所有 Aspose 元件皆提供無風險、無義務的[評估版](https://downloads.aspose.com/slides/zh-hant/cpp)。我們鼓勵您利用該[評估](https://downloads.aspose.com/slides/zh-hant/cpp)來更深入了解 Aspose 能為您的應用程式帶來的價值。 
{{% /alert %}}