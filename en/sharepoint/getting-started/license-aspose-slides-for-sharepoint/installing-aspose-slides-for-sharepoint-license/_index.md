---
title: Installing Aspose.Slides for SharePoint License
type: docs
weight: 10
url: /sharepoint/installing-aspose-slides-for-sharepoint-license/
---

{{% alert color="primary" %}} 

Once you are happy with your evaluation, you can [purchase a license](https://purchase.aspose.com/buy). Before purchasing, make sure you understand and agree to the license subscription terms. The license is emailed to you when the order has been paid.

The license is a ZIP archive containing a regular SharePoint solution package. The archive contains:

- Aspose.Slides.SharePoint.License.wsp – the SharePoint solution package file. The licenses is packaged as a SharePoint solution to make deployment and retraction across a server farm easy.
- readme.txt – License installation instructions.

{{% /alert %}} 
## **Deploying the License**
License installation is performed from the server console via **stsadm.exe**.

{{% alert color="primary" %}} 

The paths are omitted in the following section for clarity.

{{% /alert %}} 

Perform following steps to deploy the Aspose.Slides for SharePoint license:

1. Run stsadm to add the solution to the SharePoint solution store: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Deploy the solution to all servers in the farm: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Execute administrative timer jobs to complete the deployment immediately: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

You get a warning when running the deployment step if Windows SharePoint Services Administration service is not running. **stsadm.exe** relies on this service and Windows SharePoint Timer Service to replicate solution data across the farm. If these services are not running on you server farm, you may need to deploy the license at each server. 

{{% /alert %}} 
## **Test the License**
To test that the license has been installed correctly, convert any document into a new format. If there's no evaluation watermark in the document, the license activated successfully. 
