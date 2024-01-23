---
title: Frequently Asked Questions
type: docs
weight: 110
url: /reportingservices/frequently-asked-questions/
---

{{% alert color="primary" %}} 

This page collects a number of frequently asked questions about:

- [Supported file formats](#Supported-File-Formats).
- [Support for Power BI Reporting services](#Support-for-Power-BI-Reporting-services).
- [Installation](#Installation).
- [Export Configuration](#Export-Configuration).

{{% /alert %}} 
### **Supported File Formats**
#### **Q: What formats can you export reports to using Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services makes it possible to export any report in PPT, PPS, PPTX, PPSX, XPS, or RPL format.
### **Support for Power BI Reporting services**
#### **Q: Does Aspose.Slides for Reporting Services support Power BI?**
**A**: Yes. Aspose.Slides for Reporting Services supports exporting paginated reports (RDL) in Power BI.
### **Installation**
#### **Q: The installation program does not start. Manual installation does not lead to the desired result.**
**A** : Make sure that .NET Framework 3.5 is installed on your system.
#### **Q: Export options missing after installation of Aspose.Slides for Reporting Services.**
**A**: If any CodeGroup in rssrvpolicy.config does not work correctly, the configuration file parser may skip the last sections of the group. So move all the CodeGroups associated with Aspose.Slides for Reporting Services to the top of the block that contains the Aspose.Slides for Reporting Services CodeGroups.
#### **Q: Could not load file or assembly Aspose.Slides.ReportingServices (Execution permission cannot be acquired \ Exception from HRESULT: 0x80131418).**
**A**: The error code (0x80131418) indicates that the dll module does not have enough rights. This may be due to a security feature that blocked full access to the .dll file if it was obtained from another computer. This can be fixed by opening the properties window of the dll file and clicking the "Unblock" button in the "Security" panel.
#### **Q: Cannot find license 'Aspose.Slides.Reporting.Services.lic'.**
**A**: The license file must be located next to the dll or in the Program Files(x86)\Aspose\Slides\ directory.
### **Export Configuration**
#### **Q: How can I change the color of hyperlinks in an exported report?**
**A**: Each Aspose.Slides for Reporting Services rendering extension in rsreportserver.config has its own configuration. To change the hyperlink color, set the required value in the <HyperlinkColor> section.
#### **Q: In exported presentations, text in tables is stretched vertically.**
**A**: This is done to make the document easier to read. To display text in the table as it appears in the report, set the required Aspose.Slides for Reporting Services extension to "Normal" in the rsreportserver.config configuration file.
