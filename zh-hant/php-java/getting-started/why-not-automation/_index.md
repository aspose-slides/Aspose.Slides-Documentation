---
title: 為什麼不使用自動化
type: docs
weight: 50
url: /zh-hant/php-java/why-not-automation/
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
- PHP
- Aspose.Slides
description: "了解為何 Office 自動化對伺服器和服務存在風險，並看看 Aspose.Slides 如何提供更安全、更快速的 PowerPoint 與 OpenDocument 簡報處理。"
---
## **概覽**

有多種原因使得 Aspose 元件比自動化更佳。主要原因包括：

- 安全性
- 穩定性
- 可擴展性/速度
- 價格
- 功能

以下對每個要點作更詳細的說明。

## **重要問題**

我們常聽到 Aspose 會被問到兩個問題：

- 您的產品是否需要先安裝 Microsoft Office 才能執行？

簡短而直接的答案是 **否**。

Aspose 元件是完全獨立的，與 Microsoft Corporation 無關，也未經授權、贊助或批准。

- 為什麼要使用 Aspose 產品，而不是 Microsoft Office Automation？

首先，使用 Aspose.Slides 時可享受的好處很多[使用 Aspose.Slides 時可享受的好處](/slides/zh-hant/php-java/product-overview/)。

其次，Microsoft 本身強烈 **建議不要** 在軟體解決方案中使用 Office Automation。

## **安全性**

以下是 Microsoft 文章的直接引述：

*"Office 應用程式從未設計為在伺服器端使用，因而未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入請求，也無法保護您免於無意間執行巨集，或在伺服器端程式碼中啟動可能執行巨集的其他伺服器。不要開啟從匿名網站上傳至伺服器的檔案！根據最後設定的安全性設定，伺服器可能在管理員或系統上下文中執行具完整權限的巨集，進而危害您的網路！此外，Office 使用許多用戶端元件（如 Simple MAPI、WinInet、MSDAIPP），這些元件會快取用戶端驗證資訊以加速處理。如果在伺服器端自動化 Office，單一執行個體可能服務多個用戶端，且因該工作階段已快取驗證資訊，可能導致一個用戶端使用另一用戶端的快取憑證，藉此冒充其他使用者取得未授權的存取權限。"* 

Aspose 產品非常安全。Aspose 元件不會對關鍵系統資源構成潛在風險。此外，當 Aspose 元件開啟文件時，巨集不會自動執行。Aspose 元件的設計目的是讓開發人員建立、操作與儲存 Office 檔案，並不會承襲 Microsoft Office 套件的任何風險。

## **穩定性**

以下是 Microsoft 文章的直接引述：

*"Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer (MSI) 技術，使安裝與自我修復對最終使用者更為簡便。MSI 引入「首次使用時安裝」概念，允許在執行時動態安裝或設定功能（針對系統或特定使用者）。在伺服器端環境中，這會拖慢效能，且增加出現對話方塊要求使用者批准安裝或提供安裝光碟的機會。雖然此設計旨在提高 Office 作為最終使用者產品的彈性，但在伺服器端環境中卻適得其反。此外，Office 在一般情況下的穩定性無法在伺服器端保證，因為它並未為此類使用方式設計或測試。將 Office 作為網路伺服器上的服務元件使用，可能會降低該機器的穩定性，進而影響整個網路。如果您計畫在伺服器端自動化 Office，請嘗試將程式隔離於專用電腦，避免影響關鍵功能，並可視需要重新啟動。"* 

Aspose 元件已經過徹底測試，極度穩定。Aspose 元件被[公司]((https://about.aspose.com/customers)如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等眾多企業大量使用。

## **可擴展性/速度**

以下是 Microsoft 文章的直接引述：

*"伺服器端元件需要具備高度可重入、支援多執行緒的 COM 元件，且具最小開銷與高吞吐量，以同時服務多個用戶端。Office 應用程式在幾乎所有面向上正好相反。它們是非可重入、基於 STA 的自動化伺服器，設計上只提供單一用戶端的多樣且資源密集功能。作為伺服器端解決方案，它們的可擴展性極低，且在記憶體等重要元素上有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（如記憶體映射檔、全域外掛或範本、共享自動化伺服器），這會限制同時執行的實例數量，且在多用戶端環境下可能造成競爭條件。計畫同時執行多個 Office 應用程式實例的開發人員，需要考慮* ***Pooling*** *或* ***Serializing Access*** *至 Office 應用程式，以避免潛在的* ***Deadlocks*** *或* ***Data Corruption*** *。"* 

Aspose 元件具備高度可擴展性且效能極快。Office 應用程式並未設計供數百甚至數千名使用者同時使用，而 Aspose 元件正是為此而生。無論在單一伺服器上為單一應用程式供能，或在負載平衡的 Web Form 中為全企業級應用程式提供支援，皆能表現完美。

## **價格**

當應用程式使用 Microsoft Office Automation 時，必須為每臺執行該應用程式的機器購買 Microsoft Office 授權。許多情況下，應用程式需要建立或操作 Office 檔案卻不需要使用者安裝 Microsoft Office。Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版稅的再散布授權，允許部署給無限制數量的使用者，毫無授權顧慮。

在建立基於 Web 的應用程式時，需要了解 Microsoft Office Automation 元件並未針對伺服器端解決方案訂價或授權；因此，沒有合適的授權方案可供部署使用 Microsoft Office 元件的 Web 應用程式。Aspose 同樣提供非常具成本效益的伺服器端應用解決方案。

## **功能**

Aspose 元件提供管理 Office 檔案所需的一切，甚至更多。它們的設計哲學是讓開發人員以最少的工作量達成最大的成果。與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。例如，[Aspose.Cells](https://products.aspose.com/cells/php-java/) 讓開發人員能直接將資料從 **DataTable** 或 **DataView** 匯入 Excel 檔案。Aspose 系列中的[每個元件](https://products.aspose.com/total/php-java/)都有其獨特且功能強大的特性。

購買 Aspose 元件（或如[Aspose.Total](https://products.aspose.com/total/php-java/) 等元件套件）的最佳好處是可取得我們開發團隊的支援。我們的開發團隊深知如果您的公司需要的功能，其他公司也很可能有相同需求。雖然不是所有功能需求都能立即加入，我們的團隊在提供協助時仍保持相當開放與彈性。正是這種心態讓 Aspose 元件變得如此強大。若您期待從 Office Automation 取得額外功能，實際上被加入的機率非常、非常低。

## **結論**
{{% alert color="primary" %}} 

雖然本文已說明許多 Aspose 元件優於 Office Automation 的關鍵點，實際上還有更多內容。本篇文章僅著重於最重要的幾點。所有不同的 Aspose 元件皆提供無風險、無義務的[評估版本](https://downloads.aspose.com/slides/zh-hant/java)。我們鼓勵您充分利用此評估版，以更清楚地了解 Aspose 能為您的應用程式帶來的價值。 

{{% /alert %}}