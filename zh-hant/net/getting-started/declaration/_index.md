---
title: 宣告
type: docs
weight: 110
url: /zh-hant/net/declaration/
keywords:
- 宣告
- 元件
- Full Trust 權限
- 註冊表設定
- 系統檔案
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "了解 Aspose.Slides for .NET 的信任需求、權限與主機限制，讓您能安全地在伺服器上部署處理 PPT、PPTX 與 ODP 的應用程式。"
---
{{% alert color="primary" %}} 

所有 Aspose .NET 元件需要 Full Trust 權限集合，因為它們有時必須存取註冊表設定、系統檔案，以及儲存在其他位置（虛擬目錄之外）的檔案，以執行某些操作（例如解析字型）。此外，Aspose .NET 元件基於核心 .NET 系統類別，在許多情況下也需要 Full Trust 權限集合。 

{{% /alert %}} 

提供多家公司多個應用程式的網際網路服務提供者（ISP）通常會強制執行 Medium Trust 安全等級。在 .NET 2.0 環境中，此安全等級會套用以下限制： 

- OleDbPermission 不可用。這表示您無法使用 ADO.NET 管理的 OLE DB 資料提供程式來存取資料庫。 
- EventLogPermission 不可用。這表示您無法存取 Windows 事件記錄。 
- ReflectionPermission 不可用。這表示您無法使用反射功能。 
- RegistryPermission 不可用。這表示您無法存取註冊表。 
- WebPermission 受限制。這表示您的應用程式只能與您在 <trust> 元素中定義的位址或位址範圍通訊。 
- FileIOPermission 受限制。這表示您只能存取應用程式虛擬目錄層級中的檔案。 

{{% alert color="primary" %}} 

基於上述原因，Aspose .NET 元件只能在授予 Full Trust 權限集合的伺服器上使用。 

{{% /alert %}}