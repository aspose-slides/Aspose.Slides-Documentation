---
title: Declaration
type: docs
weight: 60
url: /php-java/declaration/
---

{{% alert color="primary" %}} 

All Aspose Java components require Full Trust permission set. The reason is, Aspose Java components need to access registry settings, system files other than virtual directory for certain operations like parsing fonts etc. Moreover, Aspose Java Components are based on core Java system classes that also require Full Trust permission set in many cases. 

{{% /alert %}} 

Internet Service Providers hosting multiple applications from different companies mostly enforce Medium Trust security level: 

- OleDbPermission is not available. This means you cannot use the ADO.NET managed OLE DB data provider to access databases.
- EventLogPermission is not available. This means you cannot access the Windows event log.
- ReflectionPermission is not available. This means you cannot use reflection.
- RegistryPermission is not available. This means you cannot access the registry.
- WebPermission is restricted. This means your application can only communicate with an address or range of addresses that you define in the <trust> element.
- FileIOPermission is restricted. This means you can only access files in your application's virtual directory hierarchy.

{{% alert color="primary" %}} 

Due to the reasons specified above, Aspose Java components cannot be used on servers granting permission set other than Full Trust. 

{{% /alert %}}
