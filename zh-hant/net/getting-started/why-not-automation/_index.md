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
- 可擴充性
- 功能
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "探索為何 Office 自動化對伺服器與服務具有風險，並了解 Aspose.Slides 如何為 PowerPoint 與 OpenDocument 提供更安全、更快速的簡報處理。"
---
## **簡介**

Aspose 元件是自動化的更佳替代方案，原因有很多。以下是其中一些關鍵原因：

- 安全性
- 穩定性
- 可擴充性/速度
- 價格
- 功能

以下是每個關鍵要點的更詳細說明。

## **重要問題**

我們在 Aspose 常常聽到兩個問題：

- 您的產品是否需要安裝 Microsoft Office 才能執行？

  簡短且直接的答案是 **NO**。

  Aspose 元件完全獨立，且與 Microsoft Corporation 無關，也未經授權、贊助或認可。

- 為何我們要使用 Aspose 產品而非 Microsoft Office Automation？

  首先，使用 Aspose.Slides 時可享有的眾多好處[在此](/slides/zh-hant/net/product-overview/)。

  其次，Microsoft 本身強烈 **建議避免** 從軟體解決方案使用 Office Automation。

## **安全性**
以下為 Microsoft 文章的直接引用：

> Office 應用程式從未設計用於伺服器端使用，因此未考慮分散式元件所面臨的安全問題。Office 不會驗證傳入的請求，也無法防止您在不知情的情況下執行巨集，或從伺服器端程式碼啟動可能執行巨集的其他伺服器。請勿開啟從匿名 Web 上傳至伺服器的檔案！根據最後設定的安全性設定，伺服器可能在 Administrator 或 System 上下文中以完整權限執行巨集，從而危及您的網路！此外，Office 使用許多用戶端元件（如 Simple MAPI、WinInet、MSDAIPP），這些元件會快取用戶端驗證資訊以加速處理。如果在伺服器端自動化 Office，單一執行個體可能服務多個用戶端，且由於該會話已快取驗證資訊，可能會讓一個用戶端使用另一個用戶端的快取憑證，從而透過偽裝其他使用者取得未授予的存取權限。

Aspose 產品非常 **安全**。Aspose 元件在與所有 ASP.NET 應用程式相同的使用者上下文（ASPNET 使用者）下執行。因此，Aspose 元件 **不** 會造成安全風險，也不會消耗關鍵系統資源。此外，當 Aspose 元件開啟文件時，巨集不會自動執行。Aspose 元件的設計初衷是讓開發人員建立、操作與儲存 Office 檔案。

{{% alert color="info" %}} 

Microsoft Office 套件相關的風險皆不適用於 Aspose 元件。

{{% /alert %}} 

## **穩定性**
此文字為先前引用的 Microsoft 文章的直接引用：

> Office 2000、Office XP 與 Office 2003 使用 Microsoft Windows Installer（MSI）技術，使最終使用者的安裝與自我修復更為簡便。MSI 引入「首次使用時安裝」的概念，允許功能在執行階段動態安裝或設定（針對系統，或更常見的是針對特定使用者）。在伺服器端環境中，這會降低效能，且增加出現對話框要求使用者批准安裝或提供適當安裝光碟的可能性。雖然此設計旨在提升 Office 作為終端使用者產品的韌性，但 Office 在伺服器端環境中實作 MSI 功能卻適得其反。此外，Office 整體的穩定性無法在伺服器端保證，因為它並未針對此種使用情境設計或測試。將 Office 作為網路伺服器上的服務元件使用，可能會降低該機器的穩定性，進而影響整個網路。若計畫在伺服器端自動化 Office，請嘗試將程式隔離至專用電腦，以免影響關鍵功能，且能在需要時重新啟動。

由於 Aspose 元件僅以單一 DLL 方式封裝，使用者不需安裝其他部件即可運作。Aspose 元件僅供 .NET 應用程式使用，且元件程式碼中沒有設計需等待人工回應的部分。

{{% alert color="info" %}} 

Aspose 元件已徹底測試並證實相當穩定。Aspose 元件被[公司](http://www.aspose.com/Corporate/Aspose/Customerlist.html)如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 以及其他多家領先產業與領域的組織所使用。

{{% /alert %}} 

## **可擴充性/速度**
以下為 Microsoft 文章的直接引用：

> 伺服器端元件需要具備高度可重入性、多執行緒的 COM 元件，且具最小開銷與高吞吐量，以支援多個用戶端。Office 應用程式在幾乎所有方面皆與之相反。它們是非重入、基於 STA 的 Automation 伺服器，設計上只能為單一用戶端提供多樣且資源密集的功能。作為伺服器端解決方案，它們的可擴充性極低，且在記憶體等重要元素上有固定限制，無法透過設定變更。更重要的是，它們使用全域資源（如記憶體對映檔、全域外掛或範本、共享 Automation 伺服器），這會限制同時執行的實例數量，且在多用戶端環境下可能導致競爭條件。計畫同時執行多個 Office 應用程式實例的開發人員必須考慮資源池化或序列化存取，以避免潛在的死結或資料損毀。

Aspose 元件具備極佳的可擴充性且速度極快。Office 應用程式並未設計供數百甚至數千使用者同時使用，而 Aspose 元件正是為此而設計。我們的元件是純 .NET 解決方案。

{{% alert color="info" %}} 

無論是單一伺服器（單一應用程式）或是負載平衡的 Web 表單（企業級應用程式），Aspose 元件的效能都表現完美。

{{% /alert %}} 

## **價格**
當應用程式使用 Microsoft Office Automation 時，必須為每台執行該應用程式的機器購買一套 Microsoft Office。儘管應用程式可能需要多次建立或操作 Office 檔案，但此過程本身並不需要 Microsoft Office。

{{% alert color="info" %}} 

Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版稅的再發佈授權，允許無限制的使用者部署，無需擔憂授權問題。

{{% /alert %}} 

在建立 Web 應用程式時，須記住 Microsoft Office Automation 元件既未為伺服器端解決方案定價，也未取得授權。因此，使用 Microsoft Office 元件的 Web 應用程式沒有合適的授權方案。相較之下，Aspose 為伺服器端應用程式提供了同樣[具成本效益](https://purchase.aspose.com/)的解決方案。

## **功能**
Aspose 元件提供管理 Office 檔案所需的一切，且遠超此範圍。我們的設計哲學是協助開發人員以最少的努力達成最大成果。

{{% alert color="info" %}} 

與 Office Automation 不同，Aspose 元件提供許多強大且節省時間的功能。

{{% /alert %}} 

例如，[Aspose.Cells](https://products.aspose.com/cells/net/) 讓開發人員能直接將 **DataTable** 或 **DataView** 的資料匯入 Excel 檔案。[Aspose.Words](https://products.aspose.com/words/net/) 提供類似功能，允許開發人員直接從任意 .NET 資料物件填充 Word（即合併列印）文件。Aspose 系列中的[Every component](https://products.aspose.com/total/net/) 都各自提供獨特且強大的功能。

購買 Aspose 元件的最大好處之一是可取得我們開發團隊的支援。例如，若使用 Office Automation 物件且需要特定功能，新增該功能的機會非常低。然而，Aspose 元件的情況則不同。

{{% alert color="info" %}} 

我們的開發團隊了解，若貴公司需要某項功能，其他公司很可能也有相同需求。雖然我們無法實作所有需求，但會盡可能根據客戶回饋加入更多功能。

{{% /alert %}} 

我們的團隊在提供協助時始終保持開放與彈性，這也是 Aspose 元件能發展成如今如此強大的原因。

## **結論**
{{% alert color="info" %}} 

雖然本文已說明為何 Aspose 元件比 Office Automation 更佳的關鍵要點，但實際上還有更多好處。我們僅列舉了部分主要優勢。

此外，所有 Aspose 產品與元件皆提供無風險、無義務的[評估版本](https://downloads.aspose.com/slides/zh-hant/net)。我們鼓勵您利用評估版，親自體驗 Aspose 能為您的應用程式或業務帶來的價值。

{{% /alert %}}