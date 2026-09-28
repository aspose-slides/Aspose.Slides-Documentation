---
title: Installing Aspose.Slides for SharePoint License
type: docs
weight: 10
url: /sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Install the Aspose.Slides for SharePoint license on a SharePoint farm: add the license solution to the solution store, deploy it, and check that converted files no longer carry the evaluation watermark."
---

{{% alert color="info" title="Note" %}}

Once you are happy with your evaluation, you can [purchase a license](https://purchase.aspose.com/pricing/slides/sharepoint/). Before purchasing, make sure you understand and agree to the license subscription terms. The license is emailed to you when the order has been paid.

The license is a ZIP archive containing a regular SharePoint solution package. The archive contains:

- Aspose.Slides.SharePoint.License.wsp – the SharePoint solution package file. The license is packaged as a SharePoint solution to make deployment and retraction across a server farm easy.
- readme.txt – License installation instructions.

{{% /alert %}}

## **Deploying the License**

License installation is performed from the server console via **stsadm.exe**.

{{% alert color="info" title="Note" %}}

The paths are omitted in the following section for clarity.

{{% /alert %}}

Perform the following steps to deploy the Aspose.Slides for SharePoint license:

1. Run stsadm to add the solution to the SharePoint solution store:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Deploy the solution to all servers in the farm:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Execute administrative timer jobs to complete the deployment immediately:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

The `addsolution` operation takes the path of the solution file in `-filename`; the `deploysolution` operation takes the name of the solution that is already in the solution store in `-name`.

{{% alert color="info" title="Note" %}}

You get a warning when running the deployment step if the SharePoint Administration service is not running. **stsadm.exe** relies on this service and the SharePoint Timer service to replicate solution data across the farm. If these services are not running on your server farm, you may need to deploy the license on each server.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

On SharePoint 2010 and later, the SharePoint Management Shell cmdlets `Add-SPSolution`, `Install-SPSolution` and `Start-SPAdminJob` correspond to the `addsolution`, `deploysolution` and `execadmsvcjobs` operations. See [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Test the License**

To test that the license has been installed correctly, convert any presentation into a new format. If there is no evaluation watermark in the converted file, the license is active.
