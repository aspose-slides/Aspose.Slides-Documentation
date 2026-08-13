---
title: 宣告
type: docs
weight: 110
url: /zh-hant/net/declaration/
keywords:
- 宣告
- 元件
- 完全信任權限
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
{{% alert color="info" %}} 

所有 Aspose .NET 元件都需要 Full Trust 權限設定，因為它們有時必須存取登錄檔設定、系統檔案，以及除虛擬目錄之外的其他位置的檔案（例如解析字型時）。此外，Aspose .NET 元件是基於 .NET 核心系統類別，這些類別在許多情況下也需要 Full Trust 權限設定。 

{{% /alert %}} 

提供多家公司應用程式的網路服務供應商（ISP）多半會套用 Medium Trust 安全等級。以 .NET 2.0 為例，此安全等級會施加以下限制： 

- OleDbPermission 不可用。也就是說無法使用 ADO.NET 管理式 OLE DB 資料提供者來存取資料庫。  
- EventLogPermission 不可用。也就是說無法存取 Windows 事件記錄。  
- ReflectionPermission 不可用。也就是說無法使用反射。  
- RegistryPermission 不可用。也就是說無法存取登錄檔。  
- WebPermission 受限。也就是說應用程式只能與在 `<trust>` 元素中定義的位址或位址範圍通訊。  
- FileIOPermission 受限。也就是說只能存取應用程式虛擬目錄層級中的檔案。  

{{% alert color="info" %}} 

基於上述原因，Aspose .NET 元件只能在授予 Full Trust 權限設定的伺服器上使用。 

{{% /alert %}}