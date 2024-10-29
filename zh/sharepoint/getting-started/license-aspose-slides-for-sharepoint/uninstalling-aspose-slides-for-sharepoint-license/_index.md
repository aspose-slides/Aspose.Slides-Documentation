---
title: 卸载 Aspose.Slides for SharePoint 许可证
type: docs
weight: 20
url: /zh/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

要卸载许可证，请使用以下步骤从服务器控制台进行操作。

1. 从农场撤回许可证解决方案：

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. 执行管理定时作业以立即完成撤回：

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. 等待撤回完成。您可以使用中央管理检查撤回是否完成，路径为 **中央管理**，然后 **操作** 和 **解决方案管理**。
4. 从 SharePoint 解决方案库中删除解决方案：

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```