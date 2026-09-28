---
title: License Aspose.Slides for Reporting Services
type: docs
weight: 70
url: /reportingservices/license-aspose-slides-for-reporting-services/
keywords:
- license
- licensing
- evaluation watermark
- temporary license
- Aspose.Slides for Reporting Services
description: "Apply a license to Aspose.Slides for Reporting Services by copying the license file to the report server, and check that exported presentations no longer carry the evaluation watermark."
---

## **License Support**

The evaluation version of Aspose.Slides for Reporting Services is the same package as the purchased one, from [its download page](https://releases.aspose.com/slides/reportingservices/), and provides the same functionality. Without a license, it works in evaluation mode and inserts an evaluation watermark into exported presentations.

The evaluation version becomes licensed when you copy a license file to the report server. No code is involved.

When you are happy with your evaluation, you can [purchase a license](https://purchase.aspose.com/pricing/slides/reporting-services/). We recommend you go through the different subscription types. If you have questions, contact the Aspose sales team.

## **Licensing in Aspose.Slides for Reporting Services**

* The license is a plain-text XML file that contains details such as the product name, the number of developers it is licensed to, the subscription expiry date, and so on.
* The license file is digitally signed, so you must not modify it. Even an inadvertent addition of an extra line break to the contents of the file will invalidate it.

To apply the license:

1. Copy the license file to the *ReportServer\bin* folder of each report server instance, where *Aspose.Slides.ReportingServices.dll* is installed — for example, *C:\Program Files\Microsoft SQL Server Reporting Services\SSRS\ReportServer\bin*. [Install Manually](/slides/reportingservices/install-manually/#find-the-report-server-folder) lists the default folders.
1. Make sure the file has one of the names the extension looks for: *Aspose.Slides.ReportingServices.lic*, *Aspose.Slides.Reporting.Services.lic*, *Aspose.Slides.Product.Family.lic*, *Aspose.Total.ReportingServices.lic*, *Aspose.Total.Reporting.Services.lic*, *Aspose.Total.Product.Family.lic* or *Aspose.Total.lic*.
1. Export any report as a presentation. If it does not contain a watermark, the license is active.

The extension also looks for the license file in *%ProgramData%\Aspose\Slides* (usually *C:\ProgramData\Aspose\Slides*), so one copy there serves every instance on the machine.

**Licensed Mode**

When a valid license file is found, exported presentations carry no evaluation watermark.

![A report exported with a license: no evaluation watermark](license-aspose-slides-for-reporting-services_2.png)

**Evaluation Mode**

Without a license, Aspose.Slides for Reporting Services inserts an evaluation watermark into exported presentations.

![A report exported in evaluation mode, with the evaluation watermark](license-aspose-slides-for-reporting-services_1.png)

{{% alert color="info" title="Note" %}}

To test Aspose.Slides for Reporting Services without limitations, you can ask for a **30-Day Temporary License**. See the [How to Get a Temporary License](https://purchase.aspose.com/temporary-license) page for more information.

{{% /alert %}}
