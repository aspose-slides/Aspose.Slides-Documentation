---
title: Install with MSI Installer
type: docs
weight: 20
url: /reportingservices/install-with-msi-installer/
---

## **Installation**
You can install Aspose.Slides for Reporting Services through an MSI installer. 

{{% alert title="Note" color="warning" %}} 

**Aspose.Slides for Reporting Services** requires the installation of **.NET Framework 3.5** on the host machine. 

{{% /alert %}}

Run ***Aspose.Slides.ReportingServices.msi*** and follow the steps offered by the installer. 

The installer will copy the assembly and other files to the specified directory and install the product on the default Reporting Services instance. You do not need to copy or modify any files manually unless you want to add special configuration parameters. 

The installation involving the MSI installer is the best option in most cases. However, you may want to install the product manually in some situations: 

- Automatic installation fails due to security issues or other reasons. 
- the product has to be installed on a named (not default) instance of Reporting Services or on multiple instances.
- after upgrading to the latest version, you just want to replace the assembly instead of uninstalling the old version and installing the new one using the MSI installer. **Note** that you may end up with other files in this case.
