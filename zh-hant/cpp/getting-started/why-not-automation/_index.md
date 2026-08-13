---
title: 為什麼不使用自動化
type: docs
weight: 50
url: /zh-hant/cpp/why-not-automation/
keywords:
- 自動化
- 微軟 Office
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
description: "了解為什麼 Office 自動化對伺服器和服務存在風險，並看看 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

有幾個原因使得 Aspose 元件成為自動化的更佳替代方案。主要的原因如下：

- 安全性
- 穩定性
- 可擴充性/速度
- 價格
- 功能

以下是每個重點的更詳細說明。

## **重要問題**
- 為何 Aspose 元件比 Microsoft Office Automation 更佳選擇？

我們在 Aspose 最常聽到的兩個問題是：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

簡短的答案是 **NO**。Aspose 與 Aspose 元件完全獨立，未與 Microsoft Corporation 相關聯，也未獲得授權、贊助或其他任何形式的批准。

- 為何我們應該使用 Aspose 產品而非利用 Microsoft Office Automation？

我們能給出的最簡短答案是有許多原因，最上面的原因是 *Microsoft 本身強烈建議不要在軟體解決方案中使用 Office Automation： [Microsoft 文章*

## **安全性**
以下直接引用上述 Microsoft 文章：

*"Office 應用程式從未設計用於伺服器端使用，因而未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也不會保護您免於無意間執行巨集，或從您的伺服器端程式碼啟動可能執行巨集的其他伺服器。請勿開啟匿名網站上傳至伺服器的檔案！根據最後設定的安全性設定，伺服器可能在具有完整權限的管理員或系統上下文中執行巨集，從而危及您的網路！此外，Office 使用許多客戶端元件（例如 Simple MAPI、WinInet、MSDAIPP），這些元件會快取客戶端驗證資訊以加速處理。如果在伺服器端自動化 Office，一個執行個體可能服務多個客戶端，且由於該會話已快取驗證資訊，可能導致一個客戶端使用另一個客戶端的快取憑證，藉此冒充其他使用者取得未授予的存取權限。"*

Aspose 產品非常安全。因此，Aspose 元件不會對關鍵系統資源構成潛在風險。此外，當文件由 Aspose 元件開啟時，巨集不會自動執行。Aspose 元件的設計目標是讓開發人員建立、操作與儲存 Office 檔案。與 Microsoft Office 套件相關的風險並不會內建於 Aspose 元件。

## **穩定性**
以下直接引用上述 Microsoft 文章：

*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，以便讓最終使用者更容易安裝和自我修復。MSI 引入「首次使用時安裝」的概念，允許在執行期間動態安裝或設定功能（針對系統，或更常見的是針對特定使用者）。在伺服器端環境中，這會降低效能並增加出現對話框的可能性，該對話框可能要求使用者批准安裝或提供適當的安裝光碟。儘管此設計旨在提升 Office 作為終端使用者產品的彈性，但 Office 對 MSI 功能的實作在伺服器端環境中適得其反。此外，Office 整體的穩定性在伺服器端執行時無法保證，因為它並未針對此類使用情境設計或測試。將 Office 作為服務元件部署在網路伺服器上可能會降低該機器的穩定性，進而影響整個網路。若您計畫在伺服器端自動化 Office，請嘗試將程式隔離至無法影響關鍵功能且可依需求重新啟動的專用電腦。"*

由於 Aspose 元件僅以單一 DLL 打包，永遠不需要安裝任何額外的部件或組件。Aspose 元件僅供 C++ 應用程式使用，且元件程式碼中沒有任何需要等待人工回應的部分。Aspose 元件已徹底測試，極為穩定。Aspose 元件已被[公司](https://about.aspose.com/customers)如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等大量客戶採用。

## **可擴充性/速度**
以下直接引用上述 Microsoft 文章：

*"伺服器端元件需要高度可重入、具多執行緒的 COM 元件，具備最低開銷且能為多個客戶端提供高吞吐量。Office 應用程式在幾乎所有方面恰恰相反。它們是非可重入、基於 STA 的自動化伺服器，設計上提供多樣但資源密集的單一客戶端功能。它們作為伺服器端解決方案的可擴充性極低，且在記憶體等重要元素上有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（例如記憶體映射檔、全域外掛或範本，以及共用的自動化伺服器），這會限制同時執行的實例數量，且在多客戶端環境中配置時可能導致競爭條件。計畫同時執行多個 Office 應用程式實例的開發人員必須考慮資源池化或序列化存取，以避免潛在的死結或資料損毀。"*

Aspose 元件具備高度可擴充性且速度極快。Office 應用程式並未設計供數百甚至數千使用者同時使用；相對地，Aspose 元件正是為此而生。我們的元件是純 C++ 解決方案，無論是在單一伺服器上支援單一應用程式，或是在負載平衡的 Web Form 上支援全企業級應用程式，都能表現 flawless。

## **價格**
當應用程式使用 Microsoft Office Automation 時，必須為每台執行該應用程式的機器購買 Microsoft Office。許多情況下，應用程式只需要建立或操作 Office 檔案，而不需要使用者擁有 Microsoft Office。Aspose 提供非常[成本效益](https://purchase.aspose.com/)且免版稅的再散佈授權，允許部署到無限制的使用者而無需擔心授權問題。建立基於 Web 的應用程式時，必須了解 Microsoft Office Automation 元件並未為伺服器端解決方案定價或授權；因此，沒有合適的授權方案可用於部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 也提供非常[成本效益](https://purchase.aspose.com/)的伺服器端應用程式解決方案。

## **功能**
Aspose 元件提供管理 Office 檔案所需的一切，甚至更多。它們的設計哲學是讓開發人員以最少的工作量達成最大的成果。與 Office Automation 不同，Aspose 元件提供許多強大且省時的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/cpp/) 讓開發人員能直接從 **DataTable** 或 **DataView** 匯入資料至 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/net/) 提供類似功能，讓開發人員能直接從任何 C++ 資料物件填充 Word（即郵件合併）文件。[Every Component](https://products.aspose.com/total/cpp/) 在 Aspose 系列中各自提供獨特且強大的功能。購買 Aspose 元件的最佳好處是可取得我們的開發團隊支援。開發團隊瞭解如果貴公司需要的功能，有很大機會其他公司也會需要。雖然不是每個功能需求都能被加入，我們的團隊在提供協助時仍保持開放且彈性。正是這種心態讓 Aspose 元件變得如此強大。若您期待從 Office Automation 物件獲得額外功能，實際被加入的機會非常低。

## **結論**
{{% alert color="info" %}} 

雖然本文已說明許多 Aspose 元件相較於 Office Automation 為何是更佳選擇的關鍵點，實際上還有更多內容。本篇文章僅著重在最要點。所有不同的 Aspose 元件皆提供零風險、無義務的[評估版](https://downloads.aspose.com/slides/zh-hant/cpp)。我們鼓勵您利用此[評估](https://downloads.aspose.com/slides/zh-hant/cpp)來更深入了解 Aspose 能為您的應用程式帶來的效益。 
{{% /alert %}}