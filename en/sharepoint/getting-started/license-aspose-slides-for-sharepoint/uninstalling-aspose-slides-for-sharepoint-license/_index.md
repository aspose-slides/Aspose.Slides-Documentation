---
title: Uninstalling Aspose.Slides for SharePoint License
type: docs
weight: 20
url: /sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

To uninstall the license, please use the steps below from the server console. 

1. Retract the license solution from the farm: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Execute administrative timer jobs to complete the retraction immediately: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Wait for the retraction to complete. You can use Central Administration to check if the retraction completed under **Central Administration**, then **Operations** and **Solution Management**.
4. Remove the solution from the SharePoint solution store: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```
