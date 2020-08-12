---
title: Uninstalling Aspose.Slides for SharePoint License
type: docs
weight: 20
url: /sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

To uninstall the license, please use the steps below from the server console. 

1. Retract the license solution from the farm: 

```

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

1. Execute administrative timer jobs to complete the retraction immediately: 

```

 stsadm.exe -o execadmsvcjobs

```

1. Wait for the retraction to complete. You can use Central Administration to check if the retraction completed under **Central Administration**, then **Operations** and **Solution Management**.
1. Remove the solution from the SharePoint solution store: 

```

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```
