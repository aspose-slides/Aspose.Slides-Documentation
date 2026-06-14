---
title: 解除安裝 Aspose.Slides for SharePoint 授權
type: docs
weight: 20
url: /zh-hant/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
若要解除安裝授權，請從伺服器主控台執行以下步驟。

1. 從農場收回授權解決方案：

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. 立即執行管理計時器工作以完成收回：

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. 等待收回完成。您可以使用**中央管理**檢查收回是否已完成，路徑為**中央管理**>**作業**>**解決方案管理**。

4. 從 SharePoint 解決方案儲存區中移除該解決方案：

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```