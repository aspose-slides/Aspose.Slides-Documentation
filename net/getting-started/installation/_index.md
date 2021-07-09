---
title: Installation
type: docs
weight: 70
url: /net/installation/
---

## **Installing Aspose.Slides for .NET Through NuGet**
NuGet provides the easiest means for you to download and install Aspose APIs for .NET. 

1. Open Microsoft Visual Studio and NuGet package manager.
2. Type "*aspose*" into the text field to search for your preferred Aspose API. Click **Install**. 

The selected API gets downloaded and referenced in your project.

![todo:image_alt_text](installation_1.png)
## **Install or Update Aspose.Slides Through the Package Manager Console**
To reference the [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.NET/) using the package manager console, do this:

1. Open your solution/project in Visual Studio.

1. Go through **Tools** > **Library Package Manager** > **Package Manager Console**. 

   The Package Manager Console opens. 

![todo:image_alt_text](installation_2.png)

4. Type the **Install-Package Aspose.Slides.NET** command. Hit the Enter button. 

   The latest full release gets installed into your application. 

   Alternatively, you can add the **-prerelease** suffix to the command to specify that the latest release (including hotfixes) must be installed as well.

![todo:image_alt_text](installation_3.png)

​	The **Installing Aspose.Slides.NET** tip appears around the bottom of the window. 

![todo:image_alt_text](installation_4.png)

​	Once the download reaches completion, you should see some confirmation messages. 

​	If you are not familiar with [Aspose EULA](http://www.aspose.com/corporate/purchase/end-user-license-agreement.aspx), then you may want to read the license referenced in the URL. 

![todo:image_alt_text](installation_5.png)

​	In your application, you should see that Aspose.Slides has been successfully added and referenced. 

![todo:image_alt_text](installation_6.png)

In the Package Manager Console, you can type the **Update-Package Aspose.Slides.NET** command and then hit the Enter button to check for updates to the Aspose.Slides package. Updates (if found) get installed automatically. You can also add the **-prerelease** suffix to update the latest release.
## **Considerations When Running on a Shared Server Environment**
We strongly recommend you run all Aspose .NET components with the **Full Trust** permission set because Aspose components sometimes need to access registry settings and files located in places other than the virtual directory—for example, when Aspose components need to read fonts. Furthermore, Aspose.NET components are based on the core .NET system classes—and some of these classes also require Full Trust permission for their operations in some cases.

Internet Service Providers, which host multiple applications from different companies, mostly enforce the Medium Trust security level. In .NET 2.0 case, such a security level may result in constraints that can affect Aspose.Slides' ability to perform properly:

- **RegistryPermission** is not available. This means you cannot access the registry, which is required to enumerate installed fonts when rendering documents.
- **FileIOPermission** is restricted. This means you can only access files in your application’s virtual directory hierarchy. This also potentially means fonts cannot be read during export operations. 

For these reasons above, we strongly recommend that you run Aspose.Slides on **Full Trust** permissions. If you use Medium trust, you may realize that some of the library features work when you perform some tasks while others (rendering, for example) may not work. 