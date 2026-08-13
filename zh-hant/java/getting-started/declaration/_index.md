---
title: 宣告
type: docs
weight: 60
url: /zh-hant/java/declaration/
keywords:
- 宣告
- 元件
- Full Trust 權限
- 註冊表設定
- 系統檔案
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的信任需求、權限與託管限制，讓您能安全地在伺服器上部署處理 PPT、PPTX 與 ODP 的應用程式。"
---
{{% alert color="info" %}} 

所有 Aspose Java 元件都需要 Full Trust 權限設定。原因是，Aspose Java 元件需要存取登錄表設定、系統檔案（虛擬目錄以外）以執行某些操作，例如解析字型等。此外，Aspose Java 元件基於核心 Java 系統類別，許多情況下也需要 Full Trust 權限設定。 

{{% /alert %}} 

提供多家公司多個應用程式的網際網路服務供應商通常會強制使用 Medium Trust 安全等級： 

- OleDbPermission 不可用。這表示您無法使用 ADO.NET 管理的 OLE DB 資料提供程序來存取資料庫。  
- EventLogPermission 不可用。這表示您無法存取 Windows 事件日志。  
- ReflectionPermission 不可用。這表示您無法使用反射。  
- RegistryPermission 不可用。這表示您無法存取登錄表。  
- WebPermission 受限制。這表示您的應用程式只能與您在 <trust> 元素中定義的位址或位址範圍通訊。  
- FileIOPermission 受限制。這表示您只能存取應用程式虛擬目錄層級中的檔案。  

{{% alert color="info" %}} 

基於上述原因，Aspose Java 元件無法在授予非 Full Trust 權限設定的伺服器上使用。 

{{% /alert %}}