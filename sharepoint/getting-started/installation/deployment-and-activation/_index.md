---
title: Deployment and Activation
type: docs
weight: 20
url: /sharepoint/deployment-and-activation/
---

### **Deployment**
During deployment, Aspose.Slides for SharePoint: 

- Installs the **Aspose.Slides.SharePoint.dll** into the Global Assembly Cache and adds a SafeControl entry to the **web.config** file.
- Installs the feature manifest and other necessary files to the appropriate directories.
- Registers the feature in the SharePoint database and makes it available for activation at feature scope.
### **Activation**
Aspose.Slides for SharePoint is packaged as a site (site collection) level feature and can be activated or deactivated on site collections. During activation, the feature makes some changes to the virtual directory of the parent web application of the site collection. It: 

- Adds the conversion settings page to the sitemap file.
- Copies the necessary resource files to the App_GlobalResources folder in the virtual directory.
