---
title: 安裝前置條件
type: docs
weight: 20
url: /zh-hant/reportingservices/installation-prerequisites/
---
{{% alert color="primary" %}} 

在進行安裝之前，需要滿足以下前置條件。 

{{% /alert %}} 
## **Reporting Services Add-In for SharePoint**
**Reporting Services Add-In for SharePoint** 是使整合正常運作的關鍵元件之一。此 Add-In 必須安裝在 SharePoint 農場中的任何 **Web Front Ends (WFE)** 上，並與 Central Admin 伺服器一起。SQL 2008 R2 與 SharePoint 2010 的新變更之一是，2008 R2 Add‑In 現在是 SharePoint 安裝的先決條件。這表示在安裝 SharePoint 時會自動部署 RS Add‑In。圖中已顯示並加以標示。此舉實際上避免了我們在 SP 2007 與 RS 2008 安裝 Add‑In 時所遇到的許多問題。 

![todo:image_alt_text](installation-prerequisites_1.png)


**圖 1**：Reporting Services Add‑In for SharePoint 
## **SharePoint Authentication**
在進入 RS 整合的各項內容之前，首先必須處理的是如何在 SharePoint 農場中設定 **Site**。更具體而言，就是要為 Site 設定 **Classic** 或 **Claims** 認證方式。此選擇在一開始就相當重要。據我所知，完成設定後無法輕易變更；即使可以變更，過程也不簡單。 

{{% alert color="primary" %}} 

Reporting Services 2008 R2 不支援 Claims 

{{% /alert %}} 

即使您將 SharePoint 站台設定為使用 **Claims**，Reporting Services 本身仍不支援 Claims。這會影響 Reporting Services 的認證方式。那麼從 Reporting Services 的角度來看差異為何？關鍵在於是否要將使用者憑證轉送至資料來源。 

***Classic*** - 可使用 Kerberos，將使用者的憑證轉送至後端資料來源（須使用 Kerberos）。 

***Claims*** - 使用 Claims 令牌而非 Windows 令牌。在此情境下 RS 只會使用受信任認證，且只能取得 SPUser 令牌。必須在資料來源內自行儲存憑證。 

目前，我們僅需專注於 RS 的設定。此時 SharePoint 已安裝於 SharePoint Box，且以 **Classic Auth Site** 於 **port 80** 運行。此外，在 RS 伺服器上，我已 **僅安裝 Reporting Services**，就此結束。