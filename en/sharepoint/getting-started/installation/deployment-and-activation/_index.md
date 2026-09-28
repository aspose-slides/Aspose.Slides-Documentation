---
title: Deployment and Activation
type: docs
weight: 20
url: /sharepoint/deployment-and-activation/
description: "What the Aspose.Slides for SharePoint solution installs on the farm when it is deployed, and what its site collection feature adds when it is activated."
---

## **Deployment**

During deployment, the Aspose.Slides for SharePoint solution:

- Installs its assembly into the Global Assembly Cache and adds SafeControl entries for it to the **web.config** file. On SharePoint 2010 and later, this is *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* or *Aspose.Slides.SharePoint2016.dll* (the SharePoint 2019 package also installs *Aspose.Slides.SharePoint2016.dll*). On SharePoint 2007, it is *Aspose.Slides.SharePointUI.dll*, together with *Aspose.Slides.SharePoint.Deployment.dll*.
- Copies the conversion page and its images and other supporting files to the SharePoint installation folders.
- Installs the feature and makes it available for activation on site collections.

## **Activation**

Aspose.Slides for SharePoint is packaged as a site collection feature and can be activated or deactivated on site collections. When it is activated on a site collection, the feature adds:

- On SharePoint 2010 and later:
  - the **Convert via Aspose.Slides** item to the menu of documents in document libraries;
  - the **Aspose Tools** ribbon tab with the **Convert Slides** button, which converts the selected documents;
  - the **View Slides** item to the menu of PPT, PPTX, PPS and PPSX files.
- On SharePoint 2007:
  - the **Convert with Aspose.Slides** item to the menu of documents in document libraries;
  - the **Convert All with Aspose.Slides** item to the **Actions** menu of document libraries.

On SharePoint 2007, activation also makes changes to the virtual directory of the parent web application of the site collection. It:

- Adds the conversion settings page to the sitemap file.
- Copies the necessary resource files to the App_GlobalResources folder in the virtual directory.

The setup program activates the feature on the site collections you select during [installation](/slides/sharepoint/installing-aspose-slides-for-sharepoint/).
