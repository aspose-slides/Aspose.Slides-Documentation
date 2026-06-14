---
title: 宣告
type: docs
weight: 60
url: /zh-hant/java/declaration/
keywords:
- 宣告
- 元件
- 完全信任權限
- 登錄表設定
- 系統檔案
- PowerPoint
- OpenDocument
- 簡報
- Java
- Aspose.Slides
description: "了解 Aspose.Slides for Java 的信任需求、權限和託管限制，以便您能安全部署在伺服器上處理 PPT、PPTX 和 ODP 的應用程式。"
---
{{% alert color="primary" %}} 

所有 Aspose Java 元件都需要 Full Trust 權限設定。原因是，Aspose Java 元件需要存取登錄表設定、虛擬目錄以外的系統檔案，以執行解析字型等特定操作。此外，Aspose Java 元件是基於核心 Java 系統類別，許多情況下也需要 Full Trust 權限設定。 

{{% /alert %}} 

提供多家公司多個應用程式的網際網路服務供應商大多會套用 Medium Trust 安全等級： 

- OleDbPermission 不可用。這表示您無法使用 ADO.NET 管理的 OLE DB 資料提供程式來存取資料庫。
- EventLogPermission 不可用。這表示您無法存取 Windows 事件日誌。
- ReflectionPermission 不可用。這表示您無法使用反射。
- RegistryPermission 不可用。這表示您無法存取登錄表。
- WebPermission 受限制。這表示您的應用程式只能與您在 <trust> 元素中定義的位址或位址範圍進行通訊。
- FileIOPermission 受限制。這表示您只能存取應用程式虛擬目錄層級中的檔案。

{{% alert color="primary" %}} 

由於上述原因，Aspose Java 元件無法在授予除 Full Trust 之外的權限設定的伺服器上使用。 

{{% /alert %}}