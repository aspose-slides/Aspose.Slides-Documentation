---
title: Declaration
type: docs
weight: 110
url: /pythonnet/declaration/
---

{{% alert color="primary" %}} 

All Aspose .NET components require the Full Trust permission set because they sometimes have to access registry settings, system files, and files stored in other locations (besides the virtual directory) for certain operations (parsing fonts, for example). Moreover, Aspose .NET Components are based on core .NET system classes, which require the Full Trust permission set in many cases. 

{{% /alert %}} 

Internet Service Providers, which host multiple applications from different companies, mostly enforce the Medium Trust security level. In a .NET 2.0 case, such a security level applies these constraints: 

- OleDbPermission is not available. This means you cannot use the ADO.NET managed OLE DB data provider to access databases.
- EventLogPermission is not available. This means you cannot access the Windows event log.
- ReflectionPermission is not available. This means you cannot use reflection.
- RegistryPermission is not available. This means you cannot access the registry.
- WebPermission is restricted. This means your application can only communicate with an address or the range of addresses that you defined in the <trust> element.
- FileIOPermission is restricted. This means you can only access files in your application's virtual directory hierarchy.

{{% alert color="primary" %}} 

Due to the reasons above, Aspose .NET components can only be used on servers that grant the Full Trust permission set. 

{{% /alert %}}